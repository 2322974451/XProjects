using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XForgeDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XForgeDocument.uuID;
			}
		}

		public static XForgeDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XForgeDocument.uuID) as XForgeDocument;
			}
		}

		public static EquipAttrDataMgr ForgeAttrMgr
		{
			get
			{
				return XForgeDocument.m_forgeAttrMgr;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XForgeDocument.AsyncLoader.AddTask("Table/ForgeAttributes", XForgeDocument.m_forgeAttrTab, false);
			XForgeDocument.AsyncLoader.Execute(callback);
		}

		public static void OnTableLoaded()
		{
			XForgeDocument.m_forgeAttrMgr = new ForgeAttrDataMgr(XForgeDocument.m_forgeAttrTab);
		}

		public override void OnAttachToHost(XObject host)
		{
			this.IsSelect = false;
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_UpdateItem, new XComponent.XEventHandler(this.OnUpdateItem));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnVirtualItemChanged));
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_LoadEquip, new XComponent.XEventHandler(this.OnLoadEquip));
			base.RegisterEvent(XEventDefine.XEvent_UnloadEquip, new XComponent.XEventHandler(this.OnUnloadEquip));
			base.RegisterEvent(XEventDefine.XEvent_SwapItem, new XComponent.XEventHandler(this.OnSwapItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnItemChangedFinished));
			base.EventSubscribe();
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			this.IsSelect = false;
			this.Clear();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.ShowUI();
			}
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			XForgeDocument.m_forgeAttrMgr.DataClear();
		}

		public bool OnUpdateItem(XEventArgs args)
		{
			XUpdateItemEventArgs xupdateItemEventArgs = args as XUpdateItemEventArgs;
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
			}
			return true;
		}

		public bool OnVirtualItemChanged(XEventArgs args)
		{
			XVirtualItemChangedEventArgs xvirtualItemChangedEventArgs = args as XVirtualItemChangedEventArgs;
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
			}
			this.m_bRedDotIsDirty = true;
			return true;
		}

		public bool OnSwapItem(XEventArgs args)
		{
			XSwapItemEventArgs xswapItemEventArgs = args as XSwapItemEventArgs;
			bool flag = xswapItemEventArgs.itemNowOnBody.Type == ItemType.EQUIP;
			if (flag)
			{
				this.m_bRedDotIsDirty = true;
			}
			return true;
		}

		public bool OnLoadEquip(XEventArgs args)
		{
			XLoadEquipEventArgs xloadEquipEventArgs = args as XLoadEquipEventArgs;
			bool flag = xloadEquipEventArgs.item.Type == ItemType.EQUIP;
			if (flag)
			{
				this.m_bRedDotIsDirty = true;
			}
			return true;
		}

		public bool OnUnloadEquip(XEventArgs args)
		{
			XUnloadEquipEventArgs xunloadEquipEventArgs = args as XUnloadEquipEventArgs;
			bool flag = xunloadEquipEventArgs.item.Type == ItemType.EQUIP;
			if (flag)
			{
				this.m_bRedDotIsDirty = true;
			}
			return true;
		}

		public bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			for (int i = 0; i < xaddItemEventArgs.items.Count; i++)
			{
				bool flag = xaddItemEventArgs.items[i].Type == ItemType.EQUIP;
				if (flag)
				{
					this.m_bRedDotIsDirty = true;
				}
			}
			return true;
		}

		public bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			return true;
		}

		public bool OnItemChangedFinished(XEventArgs args)
		{
			return true;
		}

		public EquipList.RowData EquipRow
		{
			get
			{
				return this.m_equipRow;
			}
		}

		public ulong CurUid
		{
			get
			{
				return this.m_curUid;
			}
		}

		public void Clear()
		{
			this.m_curUid = 0UL;
			bool flag = !this.m_bRedDotIsDirty;
			if (flag)
			{
				this.m_bRedDotIsDirty = true;
			}
		}

		public int TransRate
		{
			get
			{
				bool flag = this.m_transRate == -1;
				if (flag)
				{
					this.m_transRate = XSingleton<XGlobalConfig>.singleton.GetInt("ForgeSmeltTransRate");
					XSingleton<XDebug>.singleton.AddGreenLog(string.Format("m_transRate = {0}", this.m_transRate), null, null, null, null, null);
				}
				return this.m_transRate;
			}
		}

		private void InitData(ulong uid)
		{
			this.m_curUid = uid;
			XEquipItem xequipItem = XBagDocument.BagDoc.GetItemByUID(this.CurUid) as XEquipItem;
			bool flag = xequipItem == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog(string.Format("not find item ,curUid = {0}", this.CurUid), null, null, null, null, null);
			}
			else
			{
				this.m_equipRow = XBagDocument.GetEquipConf(xequipItem.itemID);
			}
		}

		public void SelectEquip(ulong uid)
		{
			bool flag = uid == 0UL;
			if (!flag)
			{
				bool flag2 = uid == this.m_curUid;
				if (!flag2)
				{
					XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(uid);
					bool flag3 = itemByUID.Type != ItemType.EQUIP;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("OnlyEquipCanForge"), "fece00");
					}
					else
					{
						bool flag4 = !XForgeDocument.ForgeAttrMgr.IsHadThisEquip(itemByUID.itemID);
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ThisEquipCannotForge"), "fece00");
						}
						else
						{
							this.InitData(uid);
							bool flag5 = !DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible();
							if (!flag5)
							{
								bool flag6 = this.View != null && this.View.IsVisible();
								if (flag6)
								{
									this.View.ShowUI();
								}
								else
								{
									DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.ShowRightPopView(DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ForgeMainHandler);
								}
								bool flag7 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
								if (flag7)
								{
									DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SelectEquip(uid);
								}
							}
						}
					}
				}
			}
		}

		public void ReqForgeEquip(ForgeOpType type)
		{
			RpcC2G_ForgeEquip rpcC2G_ForgeEquip = new RpcC2G_ForgeEquip();
			rpcC2G_ForgeEquip.oArg.uid = this.CurUid;
			rpcC2G_ForgeEquip.oArg.isUsedStone = this.IsUsedStone;
			rpcC2G_ForgeEquip.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ForgeEquip);
		}

		public void OnForgeEquipBack(ForgeOpType type, ForgeEquipRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.errorcode != ErrorCode.ERR_SUCCESS && oRes.errorcode != ErrorCode.ERR_EQUIP_FORGE_FAILED;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
					}
					else
					{
						bool flag4 = this.View != null && this.View.IsVisible();
						if (flag4)
						{
							bool flag5 = type == ForgeOpType.Forge_Replace;
							if (flag5)
							{
								this.View.ShowUI();
								this.View.ShowEffect(true);
							}
							else
							{
								bool flag6 = type == ForgeOpType.Forge_Equip;
								if (flag6)
								{
									XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.CurUid);
									bool flag7 = itemByUID == null;
									if (!flag7)
									{
										XEquipItem xequipItem = itemByUID as XEquipItem;
										bool flag8 = xequipItem.forgeAttrInfo.UnSavedAttrid != 0U && xequipItem.forgeAttrInfo.ForgeAttr.Count > 0;
										if (flag8)
										{
											this.View.ShowReplaceHandler();
										}
										else
										{
											this.View.ShowUI();
											bool flag9 = oRes.errorcode == ErrorCode.ERR_EQUIP_FORGE_FAILED;
											if (flag9)
											{
												this.View.ShowEffect(false);
											}
											else
											{
												this.View.ShowEffect(true);
											}
										}
									}
								}
								else
								{
									this.View.ShowUI();
								}
							}
						}
					}
				}
			}
		}

		public Dictionary<int, List<int>> AttackTypeDic
		{
			get
			{
				bool flag = this.m_attackTypeDic == null;
				if (flag)
				{
					this.m_attackTypeDic = new Dictionary<int, List<int>>();
					SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("AttackTypeAndAttributeId", true);
					for (int i = 0; i < (int)sequenceList.Count; i++)
					{
						bool flag2 = this.m_attackTypeDic.ContainsKey(sequenceList[i, 0]);
						if (flag2)
						{
							this.m_attackTypeDic[sequenceList[i, 0]].Add(sequenceList[i, 1]);
						}
						else
						{
							this.m_attackTypeDic.Add(sequenceList[i, 0], new List<int>
							{
								sequenceList[i, 1]
							});
						}
					}
				}
				return this.m_attackTypeDic;
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XForgeDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static ForgeAttributes m_forgeAttrTab = new ForgeAttributes();

		private static EquipAttrDataMgr m_forgeAttrMgr;

		private ulong m_curUid = 0UL;

		private EquipList.RowData m_equipRow = null;

		private bool m_bRedDotIsDirty = false;

		public ForgeMainHandler View;

		public bool IsUsedStone = false;

		public bool IsSelect = false;

		public bool IsShowTips = true;

		private int m_transRate = -1;

		private Dictionary<int, List<int>> m_attackTypeDic;
	}
}
