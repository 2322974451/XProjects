using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008E8 RID: 2280
	internal class XForgeDocument : XDocComponent
	{
		// Token: 0x17002AF5 RID: 10997
		// (get) Token: 0x060089E0 RID: 35296 RVA: 0x00122638 File Offset: 0x00120838
		public override uint ID
		{
			get
			{
				return XForgeDocument.uuID;
			}
		}

		// Token: 0x17002AF6 RID: 10998
		// (get) Token: 0x060089E1 RID: 35297 RVA: 0x00122650 File Offset: 0x00120850
		public static XForgeDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XForgeDocument.uuID) as XForgeDocument;
			}
		}

		// Token: 0x17002AF7 RID: 10999
		// (get) Token: 0x060089E2 RID: 35298 RVA: 0x0012267C File Offset: 0x0012087C
		public static EquipAttrDataMgr ForgeAttrMgr
		{
			get
			{
				return XForgeDocument.m_forgeAttrMgr;
			}
		}

		// Token: 0x060089E3 RID: 35299 RVA: 0x00122693 File Offset: 0x00120893
		public static void Execute(OnLoadedCallback callback = null)
		{
			XForgeDocument.AsyncLoader.AddTask("Table/ForgeAttributes", XForgeDocument.m_forgeAttrTab, false);
			XForgeDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060089E4 RID: 35300 RVA: 0x001226B8 File Offset: 0x001208B8
		public static void OnTableLoaded()
		{
			XForgeDocument.m_forgeAttrMgr = new ForgeAttrDataMgr(XForgeDocument.m_forgeAttrTab);
		}

		// Token: 0x060089E5 RID: 35301 RVA: 0x001226CA File Offset: 0x001208CA
		public override void OnAttachToHost(XObject host)
		{
			this.IsSelect = false;
			base.OnAttachToHost(host);
		}

		// Token: 0x060089E6 RID: 35302 RVA: 0x001226DC File Offset: 0x001208DC
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

		// Token: 0x060089E7 RID: 35303 RVA: 0x00122799 File Offset: 0x00120999
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			this.IsSelect = false;
			this.Clear();
		}

		// Token: 0x060089E8 RID: 35304 RVA: 0x001227B4 File Offset: 0x001209B4
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.ShowUI();
			}
		}

		// Token: 0x060089E9 RID: 35305 RVA: 0x001227EA File Offset: 0x001209EA
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			XForgeDocument.m_forgeAttrMgr.DataClear();
		}

		// Token: 0x060089EA RID: 35306 RVA: 0x00122800 File Offset: 0x00120A00
		public bool OnUpdateItem(XEventArgs args)
		{
			XUpdateItemEventArgs xupdateItemEventArgs = args as XUpdateItemEventArgs;
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
			}
			return true;
		}

		// Token: 0x060089EB RID: 35307 RVA: 0x00122838 File Offset: 0x00120A38
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

		// Token: 0x060089EC RID: 35308 RVA: 0x00122878 File Offset: 0x00120A78
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

		// Token: 0x060089ED RID: 35309 RVA: 0x001228AC File Offset: 0x00120AAC
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

		// Token: 0x060089EE RID: 35310 RVA: 0x001228E0 File Offset: 0x00120AE0
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

		// Token: 0x060089EF RID: 35311 RVA: 0x00122914 File Offset: 0x00120B14
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

		// Token: 0x060089F0 RID: 35312 RVA: 0x0012296C File Offset: 0x00120B6C
		public bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			return true;
		}

		// Token: 0x060089F1 RID: 35313 RVA: 0x00122988 File Offset: 0x00120B88
		public bool OnItemChangedFinished(XEventArgs args)
		{
			return true;
		}

		// Token: 0x17002AF8 RID: 11000
		// (get) Token: 0x060089F2 RID: 35314 RVA: 0x0012299C File Offset: 0x00120B9C
		public EquipList.RowData EquipRow
		{
			get
			{
				return this.m_equipRow;
			}
		}

		// Token: 0x17002AF9 RID: 11001
		// (get) Token: 0x060089F3 RID: 35315 RVA: 0x001229B4 File Offset: 0x00120BB4
		public ulong CurUid
		{
			get
			{
				return this.m_curUid;
			}
		}

		// Token: 0x060089F4 RID: 35316 RVA: 0x001229CC File Offset: 0x00120BCC
		public void Clear()
		{
			this.m_curUid = 0UL;
			bool flag = !this.m_bRedDotIsDirty;
			if (flag)
			{
				this.m_bRedDotIsDirty = true;
			}
		}

		// Token: 0x17002AFA RID: 11002
		// (get) Token: 0x060089F5 RID: 35317 RVA: 0x001229F8 File Offset: 0x00120BF8
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

		// Token: 0x060089F6 RID: 35318 RVA: 0x00122A5C File Offset: 0x00120C5C
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

		// Token: 0x060089F7 RID: 35319 RVA: 0x00122AC8 File Offset: 0x00120CC8
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

		// Token: 0x060089F8 RID: 35320 RVA: 0x00122BF0 File Offset: 0x00120DF0
		public void ReqForgeEquip(ForgeOpType type)
		{
			RpcC2G_ForgeEquip rpcC2G_ForgeEquip = new RpcC2G_ForgeEquip();
			rpcC2G_ForgeEquip.oArg.uid = this.CurUid;
			rpcC2G_ForgeEquip.oArg.isUsedStone = this.IsUsedStone;
			rpcC2G_ForgeEquip.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ForgeEquip);
		}

		// Token: 0x060089F9 RID: 35321 RVA: 0x00122C44 File Offset: 0x00120E44
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

		// Token: 0x17002AFB RID: 11003
		// (get) Token: 0x060089FA RID: 35322 RVA: 0x00122DF0 File Offset: 0x00120FF0
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

		// Token: 0x04002BC5 RID: 11205
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XForgeDocument");

		// Token: 0x04002BC6 RID: 11206
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002BC7 RID: 11207
		private static ForgeAttributes m_forgeAttrTab = new ForgeAttributes();

		// Token: 0x04002BC8 RID: 11208
		private static EquipAttrDataMgr m_forgeAttrMgr;

		// Token: 0x04002BC9 RID: 11209
		private ulong m_curUid = 0UL;

		// Token: 0x04002BCA RID: 11210
		private EquipList.RowData m_equipRow = null;

		// Token: 0x04002BCB RID: 11211
		private bool m_bRedDotIsDirty = false;

		// Token: 0x04002BCC RID: 11212
		public ForgeMainHandler View;

		// Token: 0x04002BCD RID: 11213
		public bool IsUsedStone = false;

		// Token: 0x04002BCE RID: 11214
		public bool IsSelect = false;

		// Token: 0x04002BCF RID: 11215
		public bool IsShowTips = true;

		// Token: 0x04002BD0 RID: 11216
		private int m_transRate = -1;

		// Token: 0x04002BD1 RID: 11217
		private Dictionary<int, List<int>> m_attackTypeDic;
	}
}
