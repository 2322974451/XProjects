using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009EF RID: 2543
	internal class XEnhanceDocument : XDocComponent
	{
		// Token: 0x17002E48 RID: 11848
		// (get) Token: 0x06009B93 RID: 39827 RVA: 0x0018D80C File Offset: 0x0018BA0C
		public override uint ID
		{
			get
			{
				return XEnhanceDocument.uuID;
			}
		}

		// Token: 0x17002E49 RID: 11849
		// (get) Token: 0x06009B94 RID: 39828 RVA: 0x0018D824 File Offset: 0x0018BA24
		public static XEnhanceDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XEnhanceDocument.uuID) as XEnhanceDocument;
			}
		}

		// Token: 0x17002E4A RID: 11850
		// (get) Token: 0x06009B95 RID: 39829 RVA: 0x0018D850 File Offset: 0x0018BA50
		public EnhanceTable Enhance
		{
			get
			{
				return XEnhanceDocument.m_enhanceTable;
			}
		}

		// Token: 0x17002E4B RID: 11851
		// (get) Token: 0x06009B96 RID: 39830 RVA: 0x0018D868 File Offset: 0x0018BA68
		public EnhanceMaster EnhanceMasterTable
		{
			get
			{
				return XEnhanceDocument.m_EnhanceMasterTable;
			}
		}

		// Token: 0x17002E4C RID: 11852
		// (get) Token: 0x06009B97 RID: 39831 RVA: 0x0018D880 File Offset: 0x0018BA80
		// (set) Token: 0x06009B98 RID: 39832 RVA: 0x0018D898 File Offset: 0x0018BA98
		public bool bCanBePowerful
		{
			get
			{
				return this._bCanBePowerful;
			}
			set
			{
				this._bCanBePowerful = value;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Item_Enhance, true);
			}
		}

		// Token: 0x17002E4D RID: 11853
		// (get) Token: 0x06009B99 RID: 39833 RVA: 0x0018D8B0 File Offset: 0x0018BAB0
		public uint HistoryMaxLevel
		{
			get
			{
				return this.m_historyMaxLevel;
			}
		}

		// Token: 0x17002E4E RID: 11854
		// (get) Token: 0x06009B9A RID: 39834 RVA: 0x0018D8C8 File Offset: 0x0018BAC8
		public uint TheMasterMaxLevel
		{
			get
			{
				bool flag = XEnhanceDocument.m_EnhanceMasterTable.Table.Length == 0;
				uint result;
				if (flag)
				{
					result = 0U;
				}
				else
				{
					result = (uint)XEnhanceDocument.m_EnhanceMasterTable.Table[XEnhanceDocument.m_EnhanceMasterTable.Table.Length - 1].TotalEnhanceLevel;
				}
				return result;
			}
		}

		// Token: 0x17002E4F RID: 11855
		// (get) Token: 0x06009B9B RID: 39835 RVA: 0x0018D910 File Offset: 0x0018BB10
		public List<int> MorePowerfulEquips
		{
			get
			{
				return this.m_morePowerfulEquips;
			}
		}

		// Token: 0x17002E50 RID: 11856
		// (get) Token: 0x06009B9C RID: 39836 RVA: 0x0018D928 File Offset: 0x0018BB28
		public List<int> RedPointEquips
		{
			get
			{
				return this.m_RedPointEquips;
			}
		}

		// Token: 0x06009B9D RID: 39837 RVA: 0x0018D940 File Offset: 0x0018BB40
		public static void Execute(OnLoadedCallback callback = null)
		{
			XEnhanceDocument.AsyncLoader.AddTask("Table/Enhance", XEnhanceDocument.m_enhanceTable, false);
			XEnhanceDocument.AsyncLoader.AddTask("Table/EnhanceMaster", XEnhanceDocument.m_EnhanceMasterTable, false);
			XEnhanceDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009B9E RID: 39838 RVA: 0x0018D97C File Offset: 0x0018BB7C
		private static int MakeKey(uint profID, uint pos, uint enhanceLevel)
		{
			return (profID * 100000U + pos * 1000U + enhanceLevel).GetHashCode();
		}

		// Token: 0x06009B9F RID: 39839 RVA: 0x0018D9A8 File Offset: 0x0018BBA8
		public static void OnTableLoaded()
		{
			for (int i = 0; i < XEnhanceDocument.m_enhanceTable.Table.Length; i++)
			{
				EnhanceTable.RowData rowData = XEnhanceDocument.m_enhanceTable.Table[i];
				bool flag = rowData != null;
				if (flag)
				{
					bool flag2 = rowData.EquipPos > XEnhanceDocument.maxPos;
					if (flag2)
					{
						XEnhanceDocument.maxPos = rowData.EquipPos;
					}
					bool flag3 = rowData.EnhanceLevel > XEnhanceDocument.maxEnhanceLevel;
					if (flag3)
					{
						XEnhanceDocument.maxEnhanceLevel = rowData.EnhanceLevel;
					}
					bool flag4 = (long)i != (long)((ulong)(rowData.EquipPos * XEnhanceDocument.maxEnhanceLevel + rowData.EnhanceLevel - 1U));
					if (flag4)
					{
						XEnhanceDocument.enhanceIndexed = false;
						break;
					}
				}
			}
		}

		// Token: 0x06009BA0 RID: 39840 RVA: 0x0018DA5C File Offset: 0x0018BC5C
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.selectedEquip = 0UL;
			this._NewItems.ClearItemType();
			this._NewItems.Filter.AddItemType(ItemType.MATERAIL);
			this.RED_POINT_LEVEL_COUNT = XSingleton<XGlobalConfig>.singleton.GetInt("EnhanceRedPointLevelCount");
		}

		// Token: 0x06009BA1 RID: 39841 RVA: 0x0018DAB0 File Offset: 0x0018BCB0
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_UpdateItem, new XComponent.XEventHandler(this.OnUpdateItem));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnVirtualItemChanged));
			base.RegisterEvent(XEventDefine.XEvent_LoadEquip, new XComponent.XEventHandler(this.OnLoadEquip));
			base.RegisterEvent(XEventDefine.XEvent_UnloadEquip, new XComponent.XEventHandler(this.OnUnloadEquip));
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_SwapItem, new XComponent.XEventHandler(this.OnSwapItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemNumChanged, new XComponent.XEventHandler(this.OnItemNumChanged));
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnFinishItemChange));
		}

		// Token: 0x06009BA2 RID: 39842 RVA: 0x0018DB84 File Offset: 0x0018BD84
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.rpcState == XEnhanceRpcState.ERS_RECEIVING;
			if (flag)
			{
				this.rpcState = XEnhanceRpcState.ERS_NONE;
			}
			bool flag2 = this.enhanceView != null && this.enhanceView.IsVisible();
			if (flag2)
			{
				this.enhanceView.RefreshPage();
			}
		}

		// Token: 0x06009BA3 RID: 39843 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x06009BA4 RID: 39844 RVA: 0x0018DBD0 File Offset: 0x0018BDD0
		public bool OnUpdateItem(XEventArgs args)
		{
			XUpdateItemEventArgs xupdateItemEventArgs = args as XUpdateItemEventArgs;
			bool flag = xupdateItemEventArgs.item.Type == ItemType.EQUIP;
			if (flag)
			{
				this.m_bShouldUpdateRedPoints = true;
			}
			bool flag2 = this.enhanceView == null || !this.enhanceView.active;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				XItem item = xupdateItemEventArgs.item;
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(item.itemID);
				bool flag3 = equipConf != null;
				if (flag3)
				{
					DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SetEquipSlot((int)equipConf.EquipPos, item);
				}
				bool flag4 = item.uid == this.selectedEquip;
				if (flag4)
				{
					this.enhanceView.RefreshPage();
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06009BA5 RID: 39845 RVA: 0x0018DC80 File Offset: 0x0018BE80
		public bool OnVirtualItemChanged(XEventArgs args)
		{
			XVirtualItemChangedEventArgs xvirtualItemChangedEventArgs = args as XVirtualItemChangedEventArgs;
			bool flag = xvirtualItemChangedEventArgs.itemID == 1;
			if (flag)
			{
				this.m_bShouldUpdateRedPoints = true;
			}
			bool flag2 = this.enhanceView == null || !this.enhanceView.active;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				this.enhanceView.RefreshPage();
				result = true;
			}
			return result;
		}

		// Token: 0x06009BA6 RID: 39846 RVA: 0x0018DCDC File Offset: 0x0018BEDC
		protected bool OnLoadEquip(XEventArgs args)
		{
			XLoadEquipEventArgs xloadEquipEventArgs = args as XLoadEquipEventArgs;
			bool flag = xloadEquipEventArgs.item.Type == ItemType.EQUIP;
			if (flag)
			{
				this.m_bShouldUpdateRedPoints = true;
			}
			return true;
		}

		// Token: 0x06009BA7 RID: 39847 RVA: 0x0018DD14 File Offset: 0x0018BF14
		protected bool OnUnloadEquip(XEventArgs args)
		{
			XUnloadEquipEventArgs xunloadEquipEventArgs = args as XUnloadEquipEventArgs;
			bool flag = xunloadEquipEventArgs.type == ItemType.EQUIP;
			if (flag)
			{
				this.m_bShouldUpdateRedPoints = true;
			}
			return true;
		}

		// Token: 0x06009BA8 RID: 39848 RVA: 0x0018DD44 File Offset: 0x0018BF44
		protected bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			this.m_bShouldUpdateRedPoints = this._NewItems.AddItems(xaddItemEventArgs.items, true);
			return true;
		}

		// Token: 0x06009BA9 RID: 39849 RVA: 0x0018DD78 File Offset: 0x0018BF78
		protected bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			this.m_bShouldUpdateRedPoints = this._NewItems.RemoveItems(xremoveItemEventArgs.uids, xremoveItemEventArgs.types, true);
			return true;
		}

		// Token: 0x06009BAA RID: 39850 RVA: 0x0018DDB0 File Offset: 0x0018BFB0
		protected bool OnSwapItem(XEventArgs args)
		{
			XSwapItemEventArgs xswapItemEventArgs = args as XSwapItemEventArgs;
			this.m_bShouldUpdateRedPoints = true;
			return true;
		}

		// Token: 0x06009BAB RID: 39851 RVA: 0x0018DDD4 File Offset: 0x0018BFD4
		public bool OnItemNumChanged(XEventArgs args)
		{
			XItemNumChangedEventArgs xitemNumChangedEventArgs = args as XItemNumChangedEventArgs;
			bool flag = xitemNumChangedEventArgs.item.Type == ItemType.MATERAIL;
			if (flag)
			{
				this.m_bShouldUpdateRedPoints = true;
			}
			bool flag2 = this.enhanceView == null || !this.enhanceView.active;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				this.enhanceView.RefreshPage();
				result = true;
			}
			return result;
		}

		// Token: 0x06009BAC RID: 39852 RVA: 0x0018DE34 File Offset: 0x0018C034
		public bool OnFinishItemChange(XEventArgs args)
		{
			bool bShouldUpdateRedPoints = this.m_bShouldUpdateRedPoints;
			if (bShouldUpdateRedPoints)
			{
				this.UpdateRedPoints();
				this.m_bShouldUpdateRedPoints = false;
			}
			return true;
		}

		// Token: 0x06009BAD RID: 39853 RVA: 0x0018DE64 File Offset: 0x0018C064
		public void ReqEnhance()
		{
			RpcC2G_EnhanceItem rpcC2G_EnhanceItem = new RpcC2G_EnhanceItem();
			rpcC2G_EnhanceItem.oArg.UniqueItemId = this.selectedEquip;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_EnhanceItem);
			this.rpcState = XEnhanceRpcState.ERS_RECEIVING;
		}

		// Token: 0x06009BAE RID: 39854 RVA: 0x0018DEA0 File Offset: 0x0018C0A0
		public void ReqEnhanceAttr()
		{
			XEquipItem xequipItem = XBagDocument.BagDoc.GetItemByUID(this.selectedEquip) as XEquipItem;
			bool flag = xequipItem == null;
			if (!flag)
			{
				EnhanceTable.RowData enhanceRowData = this.GetEnhanceRowData(xequipItem);
				bool flag2 = enhanceRowData == null;
				if (!flag2)
				{
					bool flag3 = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
					if (!flag3)
					{
						RpcC2G_GetEnhanceAttr rpcC2G_GetEnhanceAttr = new RpcC2G_GetEnhanceAttr();
						rpcC2G_GetEnhanceAttr.oArg.prof = (uint)XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession;
						rpcC2G_GetEnhanceAttr.oArg.equippos = enhanceRowData.EquipPos;
						rpcC2G_GetEnhanceAttr.oArg.enhancelevel = xequipItem.enhanceInfo.EnhanceLevel + 1U;
						XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetEnhanceAttr);
					}
				}
			}
		}

		// Token: 0x06009BAF RID: 39855 RVA: 0x0018DF54 File Offset: 0x0018C154
		public void OnEnhanceBack(EnhanceItemRes oRes)
		{
			this.ProcessResult(oRes.ErrorCode);
			this.m_combainItems = oRes.comagates;
			bool flag = oRes.ErrorCode == ErrorCode.ERR_ENHANCE_SUCCEED;
			if (flag)
			{
				this.m_nextLevelAttr.Clear();
				for (int i = 0; i < oRes.nextAttrs.Count; i++)
				{
					AttributeInfo attributeInfo = oRes.nextAttrs[i];
					bool flag2 = attributeInfo != null;
					if (flag2)
					{
						this.m_nextLevelAttr.Add(new XTuple<uint, uint>(attributeInfo.id, attributeInfo.value));
					}
				}
			}
			bool flag3 = this.enhanceView != null && this.enhanceView.IsVisible();
			if (flag3)
			{
				this.enhanceView.PlayEffect();
			}
		}

		// Token: 0x17002E51 RID: 11857
		// (get) Token: 0x06009BB0 RID: 39856 RVA: 0x0018E014 File Offset: 0x0018C214
		public List<ComAgate> CombainItems
		{
			get
			{
				return this.m_combainItems;
			}
		}

		// Token: 0x06009BB1 RID: 39857 RVA: 0x0018E02C File Offset: 0x0018C22C
		public void ProcessResult(ErrorCode rpcErrCode)
		{
			bool flag = this.rpcState != XEnhanceRpcState.ERS_RECEIVING;
			if (!flag)
			{
				switch (rpcErrCode)
				{
				case ErrorCode.ERR_ENHANCE_LACKITEM:
				case ErrorCode.ERR_ENHANCE_MAX:
					XSingleton<UiUtility>.singleton.ShowSystemTip(rpcErrCode, "fece00");
					this.rpcState = XEnhanceRpcState.ERS_ERR;
					break;
				case ErrorCode.ERR_ENHANCE_FAILED:
					this.rpcState = XEnhanceRpcState.ERS_ENHANCEFAIED;
					break;
				case ErrorCode.ERR_ENHANCE_SUCCEED:
				{
					bool flag2 = !this.IsNeedBreak;
					if (flag2)
					{
						this.rpcState = XEnhanceRpcState.ERS_ENHANCESUCCEED;
					}
					else
					{
						this.rpcState = XEnhanceRpcState.ERS_BREAKSUCCEED;
					}
					break;
				}
				default:
				{
					bool flag3 = rpcErrCode > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(rpcErrCode, "fece00");
						this.rpcState = XEnhanceRpcState.ERS_ERR;
					}
					break;
				}
				}
			}
		}

		// Token: 0x06009BB2 RID: 39858 RVA: 0x0018E0D4 File Offset: 0x0018C2D4
		public void GetTotalEnhanceLevelBack(uint level)
		{
			this.m_historyMaxLevel = level;
			bool flag = this.isLoadingData;
			if (flag)
			{
				this.isLoadingData = false;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("ActiveNewEnhanceMaster"), this.m_historyMaxLevel), "fece00");
				bool flag2 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					bool flag3 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.IsVisible();
					if (flag3)
					{
						DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.PlayEnhanceMasterEffect();
					}
				}
			}
			bool flag4 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible();
			if (flag4)
			{
				bool flag5 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EquipBagHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EquipBagHandler.IsVisible();
				if (flag5)
				{
					DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EquipBagHandler.ShowEnhanceMasterLevel();
				}
			}
			bool flag6 = this.enhanceMasterView != null && this.enhanceMasterView.IsVisible();
			if (flag6)
			{
				this.enhanceMasterView.RefreshView();
			}
			bool flag7 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag7)
			{
				XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook.enhanceMasterLevel = level;
			}
			bool flag8 = XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.Equipment != null;
			if (flag8)
			{
				XSingleton<XEntityMgr>.singleton.Player.Equipment.RefreshEquipFx();
				XSingleton<X3DAvatarMgr>.singleton.OnEnhanceMasterChanged(XSingleton<XEntityMgr>.singleton.Player);
			}
		}

		// Token: 0x06009BB3 RID: 39859 RVA: 0x0018E258 File Offset: 0x0018C458
		public void OnReqEnhanceAttrBack(GetEnhanceAttrArg oArg, GetEnhanceAttrRes oRes)
		{
			XEquipItem xequipItem = XBagDocument.BagDoc.GetItemByUID(this.selectedEquip) as XEquipItem;
			bool flag = xequipItem == null;
			if (!flag)
			{
				EnhanceTable.RowData enhanceRowData = this.GetEnhanceRowData(xequipItem);
				bool flag2 = enhanceRowData == null;
				if (!flag2)
				{
					bool flag3 = enhanceRowData.EquipPos != oArg.equippos;
					if (!flag3)
					{
						this.m_nextLevelAttr.Clear();
						for (int i = 0; i < oRes.attrs.Count; i++)
						{
							AttributeInfo attributeInfo = oRes.attrs[i];
							bool flag4 = attributeInfo != null;
							if (flag4)
							{
								this.m_nextLevelAttr.Add(new XTuple<uint, uint>(attributeInfo.id, attributeInfo.value));
							}
						}
						this.SetEnhanceUIAttr(xequipItem);
						bool flag5 = this.enhanceView != null && this.enhanceView.IsVisible();
						if (flag5)
						{
							this.enhanceView.FillAttrUi();
						}
					}
				}
			}
		}

		// Token: 0x06009BB4 RID: 39860 RVA: 0x0018E354 File Offset: 0x0018C554
		public EnhanceTable.RowData GetEnhanceRowData(uint pos, uint enhanceLevel)
		{
			bool flag = XEnhanceDocument.enhanceIndexed && (long)XEnhanceDocument.m_enhanceTable.Table.Length == (long)((ulong)(XEnhanceDocument.maxEnhanceLevel * (1U + XEnhanceDocument.maxPos)));
			EnhanceTable.RowData result;
			if (flag)
			{
				result = XEnhanceDocument.m_enhanceTable.Table[(int)(pos * XEnhanceDocument.maxEnhanceLevel + enhanceLevel - 1U)];
			}
			else
			{
				for (int i = 0; i < XEnhanceDocument.m_enhanceTable.Table.Length; i++)
				{
					EnhanceTable.RowData rowData = XEnhanceDocument.m_enhanceTable.Table[i];
					bool flag2 = rowData != null && rowData.EquipPos == pos && rowData.EnhanceLevel == enhanceLevel;
					if (flag2)
					{
						return rowData;
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06009BB5 RID: 39861 RVA: 0x0018E400 File Offset: 0x0018C600
		public EnhanceTable.RowData GetEnhanceRowData(XEquipItem item)
		{
			bool flag = item == null;
			EnhanceTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(item.itemID);
				EnhanceTable.RowData enhanceRowData = this.GetEnhanceRowData((uint)equipConf.EquipPos, item.enhanceInfo.EnhanceLevel + 1U);
				result = enhanceRowData;
			}
			return result;
		}

		// Token: 0x06009BB6 RID: 39862 RVA: 0x0018E448 File Offset: 0x0018C648
		public EnhanceMaster.RowData GetCurStageEnhanceMasterRowData(uint level)
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
			EnhanceMaster.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				uint curStageLevel = this.GetCurStageLevel(level);
				uint profession = (uint)XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession;
				for (int i = 0; i < XEnhanceDocument.m_EnhanceMasterTable.Table.Length; i++)
				{
					EnhanceMaster.RowData rowData = XEnhanceDocument.m_EnhanceMasterTable.Table[i];
					bool flag2 = (long)rowData.ProfessionId == (long)((ulong)profession) && (long)rowData.TotalEnhanceLevel == (long)((ulong)curStageLevel);
					if (flag2)
					{
						return XEnhanceDocument.m_EnhanceMasterTable.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06009BB7 RID: 39863 RVA: 0x0018E4F0 File Offset: 0x0018C6F0
		private uint GetCurStageLevel(uint level)
		{
			uint profession = (uint)XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession;
			List<uint> list = new List<uint>();
			for (int i = 0; i < XEnhanceDocument.m_EnhanceMasterTable.Table.Length; i++)
			{
				EnhanceMaster.RowData rowData = XEnhanceDocument.m_EnhanceMasterTable.Table[i];
				bool flag = (long)rowData.ProfessionId == (long)((ulong)profession);
				if (flag)
				{
					list.Add((uint)rowData.TotalEnhanceLevel);
				}
			}
			bool flag2 = list.Count == 0;
			uint result;
			if (flag2)
			{
				result = 0U;
			}
			else
			{
				list.Sort();
				for (int j = 0; j < list.Count; j++)
				{
					bool flag3 = j == 0;
					if (flag3)
					{
						bool flag4 = level < list[j];
						if (flag4)
						{
							return 0U;
						}
					}
					else
					{
						bool flag5 = level < list[j];
						if (flag5)
						{
							return list[j - 1];
						}
					}
				}
				result = list[list.Count - 1];
			}
			return result;
		}

		// Token: 0x06009BB8 RID: 39864 RVA: 0x0018E5F4 File Offset: 0x0018C7F4
		public EnhanceMaster.RowData GetNextStageEnhanceMasterRowData(uint level)
		{
			uint profession = (uint)XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession;
			for (int i = 0; i < XEnhanceDocument.m_EnhanceMasterTable.Table.Length; i++)
			{
				EnhanceMaster.RowData rowData = XEnhanceDocument.m_EnhanceMasterTable.Table[i];
				bool flag = (long)rowData.ProfessionId == (long)((ulong)profession) && (long)rowData.TotalEnhanceLevel > (long)((ulong)level);
				if (flag)
				{
					return rowData;
				}
			}
			return null;
		}

		// Token: 0x06009BB9 RID: 39865 RVA: 0x0018E668 File Offset: 0x0018C868
		public void GetSuccessRate(XEquipItem item, ref uint oriValue, ref uint addValue)
		{
			EnhanceTable.RowData enhanceRowData = this.GetEnhanceRowData(item);
			bool flag = enhanceRowData == null;
			if (flag)
			{
				oriValue = 50U;
				addValue = 0U;
			}
			else
			{
				oriValue = enhanceRowData.SuccessRate;
				addValue = item.enhanceInfo.EnhanceTimes * enhanceRowData.UpRate;
			}
		}

		// Token: 0x17002E52 RID: 11858
		// (get) Token: 0x06009BBA RID: 39866 RVA: 0x0018E6AC File Offset: 0x0018C8AC
		public List<EnhanceAttr> EnhanceAttrLst
		{
			get
			{
				return this.m_EnhanceAttrLst;
			}
		}

		// Token: 0x06009BBB RID: 39867 RVA: 0x0018E6C4 File Offset: 0x0018C8C4
		public void SetEnhanceUIAttr(XEquipItem item)
		{
			this.m_EnhanceAttrLst.Clear();
			bool flag = this.m_nextLevelAttr == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("error,please check Enhance", null, null, null, null, null);
				for (int i = 0; i < item.enhanceInfo.EnhanceAttr.Count; i++)
				{
					uint num = item.enhanceInfo.EnhanceAttr[i].AttrID;
					uint num2 = item.enhanceInfo.EnhanceAttr[i].AttrValue;
					EnhanceAttr item2 = new EnhanceAttr(num, num2, num2);
					this.m_EnhanceAttrLst.Add(item2);
				}
			}
			else
			{
				bool flag2 = item.enhanceInfo.EnhanceAttr == null;
				if (flag2)
				{
					for (int j = 0; j < this.m_nextLevelAttr.Count; j++)
					{
						uint num = this.m_nextLevelAttr[j].Item1;
						uint num2 = 0U;
						uint afterValue = this.m_nextLevelAttr[j].Item2;
						EnhanceAttr item3 = new EnhanceAttr(num, num2, afterValue);
						this.m_EnhanceAttrLst.Add(item3);
					}
				}
				else
				{
					bool flag3 = item.enhanceInfo.EnhanceAttr.Count >= this.m_nextLevelAttr.Count;
					if (flag3)
					{
						for (int k = 0; k < item.enhanceInfo.EnhanceAttr.Count; k++)
						{
							uint num = item.enhanceInfo.EnhanceAttr[k].AttrID;
							uint num2 = item.enhanceInfo.EnhanceAttr[k].AttrValue;
							uint afterValue = this.GetAddValue(num, this.m_nextLevelAttr);
							EnhanceAttr item4 = new EnhanceAttr(num, num2, afterValue);
							this.m_EnhanceAttrLst.Add(item4);
						}
					}
					else
					{
						for (int l = 0; l < this.m_nextLevelAttr.Count; l++)
						{
							uint num = this.m_nextLevelAttr[l].Item1;
							uint num2 = this.GetValue(num, item.enhanceInfo.EnhanceAttr);
							uint afterValue = this.m_nextLevelAttr[l].Item2;
							EnhanceAttr item5 = new EnhanceAttr(num, num2, afterValue);
							this.m_EnhanceAttrLst.Add(item5);
						}
					}
				}
			}
		}

		// Token: 0x06009BBC RID: 39868 RVA: 0x0018E91C File Offset: 0x0018CB1C
		private uint GetAddValue(uint attrId, List<XTuple<uint, uint>> data)
		{
			for (int i = 0; i < data.Count; i++)
			{
				bool flag = attrId == data[i].Item1;
				if (flag)
				{
					return data[i].Item2;
				}
			}
			return 0U;
		}

		// Token: 0x06009BBD RID: 39869 RVA: 0x0018E968 File Offset: 0x0018CB68
		private uint GetValue(uint attrId, List<XItemChangeAttr> lst)
		{
			for (int i = 0; i < lst.Count; i++)
			{
				bool flag = attrId == lst[i].AttrID;
				if (flag)
				{
					return lst[i].AttrValue;
				}
			}
			return 0U;
		}

		// Token: 0x06009BBE RID: 39870 RVA: 0x0018E9B4 File Offset: 0x0018CBB4
		public void SelectEquip(ulong id)
		{
			this.selectedEquip = id;
			bool flag = !DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				bool flag2 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EnhanceHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EnhanceHandler.IsVisible();
				if (flag2)
				{
					DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EnhanceHandler.ChangeEquip();
				}
				else
				{
					DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.ShowRightPopView(DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EnhanceHandler);
				}
				bool flag3 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
				if (flag3)
				{
					DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SelectEquip(id);
				}
			}
		}

		// Token: 0x17002E53 RID: 11859
		// (get) Token: 0x06009BBF RID: 39871 RVA: 0x0018EA48 File Offset: 0x0018CC48
		public SeqList<int> ExchangeRateList
		{
			get
			{
				bool flag = this.m_exchangeRateList == null;
				if (flag)
				{
					this.m_exchangeRateList = XSingleton<XGlobalConfig>.singleton.GetSequence3List("ExchangeRate", false);
				}
				return this.m_exchangeRateList;
			}
		}

		// Token: 0x06009BC0 RID: 39872 RVA: 0x0018EA88 File Offset: 0x0018CC88
		public void GetLowestItemNeedCountByID(uint itemid, uint needCount, ref int lowestid, ref ulong lowestNeedCount)
		{
			lowestNeedCount = (ulong)needCount;
			lowestid = (int)itemid;
			bool flag = this.ExchangeRateList != null;
			if (flag)
			{
				uint oriId = itemid;
				int num = 0;
				int num2 = -1;
				for (;;)
				{
					this.GetId(oriId, ref num2, ref num);
					bool flag2 = num2 == -1;
					if (flag2)
					{
						break;
					}
					lowestid = num2;
					lowestNeedCount *= (ulong)((long)num);
					oriId = (uint)num2;
				}
			}
		}

		// Token: 0x06009BC1 RID: 39873 RVA: 0x0018EAE4 File Offset: 0x0018CCE4
		public void GetLowestItemOwnedCountByID(uint itemid, ref int lowestid, ref ulong lowestOwnedCount)
		{
			lowestOwnedCount = XBagDocument.BagDoc.GetItemCount((int)itemid);
			lowestid = (int)itemid;
			bool flag = this.ExchangeRateList != null;
			if (flag)
			{
				uint oriId = itemid;
				int num = 0;
				int num2 = -1;
				for (;;)
				{
					this.GetId(oriId, ref num2, ref num);
					bool flag2 = num2 == -1;
					if (flag2)
					{
						break;
					}
					lowestid = num2;
					lowestOwnedCount *= (ulong)((long)num);
					lowestOwnedCount += XBagDocument.BagDoc.GetItemCount(num2);
					oriId = (uint)num2;
				}
			}
		}

		// Token: 0x06009BC2 RID: 39874 RVA: 0x0018EB54 File Offset: 0x0018CD54
		public ulong GetItemCountByID(uint itemId)
		{
			int num = 1;
			bool flag = itemId == 1U;
			ulong result;
			if (flag)
			{
				result = XBagDocument.BagDoc.GetItemCount((int)itemId);
			}
			else
			{
				bool flag2 = this.ExchangeRateList == null;
				ulong num2;
				if (flag2)
				{
					num2 = XBagDocument.BagDoc.GetItemCount((int)itemId);
				}
				else
				{
					num2 = XBagDocument.BagDoc.GetItemCount((int)itemId);
					int num3 = 0;
					int num4 = 0;
					for (;;)
					{
						this.GetId(itemId, ref num4, ref num3);
						bool flag3 = num4 == -1;
						if (flag3)
						{
							break;
						}
						num *= num3;
						num2 *= (ulong)((long)num3);
						num2 += XBagDocument.BagDoc.GetItemCount(num4);
						itemId = (uint)num4;
					}
				}
				result = num2 / (ulong)((long)num);
			}
			return result;
		}

		// Token: 0x06009BC3 RID: 39875 RVA: 0x0018EBF8 File Offset: 0x0018CDF8
		private void GetId(uint oriId, ref int findId, ref int rate)
		{
			for (int i = 0; i < (int)this.ExchangeRateList.Count; i++)
			{
				bool flag = (ulong)oriId == (ulong)((long)this.ExchangeRateList[i, 0]);
				if (flag)
				{
					findId = this.ExchangeRateList[i, 1];
					rate = this.ExchangeRateList[i, 2];
					return;
				}
			}
			findId = -1;
			rate = 0;
		}

		// Token: 0x06009BC4 RID: 39876 RVA: 0x0018EC60 File Offset: 0x0018CE60
		public uint GetMaxEnhanceLevel()
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				PlayerLevelTable.RowData byLevel = XSingleton<XEntityMgr>.singleton.LevelTable.GetByLevel((int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
				bool flag2 = byLevel == null;
				if (flag2)
				{
					result = 0U;
				}
				else
				{
					result = byLevel.MaxEnhanceLevel;
				}
			}
			return result;
		}

		// Token: 0x06009BC5 RID: 39877 RVA: 0x0018ECB8 File Offset: 0x0018CEB8
		public void UpdateRedPoints()
		{
			this._bCanBePowerful = false;
			uint num;
			this.GetAllCanBeMorePowerfulEquips(out num);
			this.bCanBePowerful = ((ulong)num == (ulong)((long)this.RED_POINT_LEVEL_COUNT));
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EquipBagHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EquipBagHandler.IsVisible();
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EquipBagHandler.RefreshRedPoints();
			}
		}

		// Token: 0x06009BC6 RID: 39878 RVA: 0x0018ED1C File Offset: 0x0018CF1C
		public void GetAllCanBeMorePowerfulEquips(out uint maxTimes)
		{
			int num = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.EQUIP_START);
			int num2 = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.EQUIP_END);
			this.MorePowerfulEquips.Clear();
			this.m_RedPointEquips.Clear();
			maxTimes = 0U;
			Dictionary<int, ulong> dictionary = new Dictionary<int, ulong>();
			for (int i = num; i < num2; i++)
			{
				XEquipItem xequipItem = XBagDocument.BagDoc.EquipBag[i] as XEquipItem;
				uint canEnhanceTimes = this.GetCanEnhanceTimes(xequipItem);
				bool flag = canEnhanceTimes == 0U;
				if (!flag)
				{
					EquipList.RowData equipConf = XBagDocument.GetEquipConf(xequipItem.itemID);
					maxTimes = Math.Max(maxTimes, canEnhanceTimes);
					bool flag2 = (ulong)canEnhanceTimes == (ulong)((long)this.RED_POINT_LEVEL_COUNT);
					if (flag2)
					{
						this.m_RedPointEquips.Add((int)equipConf.EquipPos);
					}
					bool flag3 = canEnhanceTimes > 0U;
					if (flag3)
					{
						this.MorePowerfulEquips.Add((int)equipConf.EquipPos);
					}
				}
			}
		}

		// Token: 0x06009BC7 RID: 39879 RVA: 0x0018EE00 File Offset: 0x0018D000
		public uint GetCanEnhanceTimes(XEquipItem equip)
		{
			bool flag = equip == null || equip.itemID == 0;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(equip.itemID);
				bool flag2 = itemConf == null;
				if (flag2)
				{
					result = 0U;
				}
				else
				{
					bool flag3 = itemConf.ItemQuality < 2;
					if (flag3)
					{
						result = 0U;
					}
					else
					{
						this.m_ItemsRequiredCollector.Init();
						EquipList.RowData equipConf = XBagDocument.GetEquipConf(equip.itemID);
						bool flag4 = equipConf == null;
						if (flag4)
						{
							result = 0U;
						}
						else
						{
							uint num = 0U;
							int i = 1;
							while (i <= this.RED_POINT_LEVEL_COUNT)
							{
								bool flag5 = equip.enhanceInfo.EnhanceLevel + (uint)i > this.GetMaxEnhanceLevel();
								if (flag5)
								{
									break;
								}
								EnhanceTable.RowData enhanceRowData = this.GetEnhanceRowData((uint)equipConf.EquipPos, equip.enhanceInfo.EnhanceLevel + (uint)i);
								bool flag6 = enhanceRowData == null;
								if (flag6)
								{
									break;
								}
								for (int j = 0; j < enhanceRowData.NeedItem.Count; j++)
								{
									int num2 = 0;
									ulong itemcount = 0UL;
									this.GetLowestItemNeedCountByID(enhanceRowData.NeedItem[j, 0], enhanceRowData.NeedItem[j, 1], ref num2, ref itemcount);
									bool flag7 = !this.m_ItemsRequiredCollector.HasOwnedItem(num2);
									if (flag7)
									{
										ulong count = 0UL;
										this.GetLowestItemOwnedCountByID(enhanceRowData.NeedItem[j, 0], ref num2, ref count);
										this.m_ItemsRequiredCollector.SetNewOwnedItem(num2, count);
									}
									this.m_ItemsRequiredCollector.GetRequiredItem((uint)num2, itemcount, 1f);
									bool flag8 = !this.m_ItemsRequiredCollector.bItemsEnough;
									if (flag8)
									{
										break;
									}
								}
								bool flag9 = !this.m_ItemsRequiredCollector.bItemsEnough;
								if (flag9)
								{
									break;
								}
								i++;
								num += 1U;
							}
							result = num;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06009BC8 RID: 39880 RVA: 0x0018EFE8 File Offset: 0x0018D1E8
		private int _SortComparison(XEquipItem left, XEquipItem right)
		{
			return left.enhanceInfo.EnhanceLevel.CompareTo(right.enhanceInfo.EnhanceLevel);
		}

		// Token: 0x040035E2 RID: 13794
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("EnhanceDocument");

		// Token: 0x040035E3 RID: 13795
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040035E4 RID: 13796
		private static EnhanceTable m_enhanceTable = new EnhanceTable();

		// Token: 0x040035E5 RID: 13797
		private static EnhanceMaster m_EnhanceMasterTable = new EnhanceMaster();

		// Token: 0x040035E6 RID: 13798
		public EnhanceView enhanceView;

		// Token: 0x040035E7 RID: 13799
		public EnhanceMasterHandler enhanceMasterView;

		// Token: 0x040035E8 RID: 13800
		public ulong selectedEquip = 0UL;

		// Token: 0x040035E9 RID: 13801
		public bool IsNeedBreak = false;

		// Token: 0x040035EA RID: 13802
		public XEnhanceRpcState rpcState = XEnhanceRpcState.ERS_NONE;

		// Token: 0x040035EB RID: 13803
		private XNewItemTipsMgr _NewItems = new XNewItemTipsMgr();

		// Token: 0x040035EC RID: 13804
		private int RED_POINT_LEVEL_COUNT = 5;

		// Token: 0x040035ED RID: 13805
		private XItemRequiredCollector m_ItemsRequiredCollector = new XItemRequiredCollector();

		// Token: 0x040035EE RID: 13806
		private bool _bCanBePowerful = false;

		// Token: 0x040035EF RID: 13807
		private uint m_historyMaxLevel = 0U;

		// Token: 0x040035F0 RID: 13808
		private bool m_bShouldUpdateRedPoints = false;

		// Token: 0x040035F1 RID: 13809
		private List<int> m_morePowerfulEquips = new List<int>();

		// Token: 0x040035F2 RID: 13810
		private List<int> m_RedPointEquips = new List<int>();

		// Token: 0x040035F3 RID: 13811
		private static uint maxPos = 0U;

		// Token: 0x040035F4 RID: 13812
		private static uint maxEnhanceLevel = 0U;

		// Token: 0x040035F5 RID: 13813
		private static bool enhanceIndexed = true;

		// Token: 0x040035F6 RID: 13814
		private List<XTuple<uint, uint>> m_nextLevelAttr = new List<XTuple<uint, uint>>();

		// Token: 0x040035F7 RID: 13815
		private List<ComAgate> m_combainItems = null;

		// Token: 0x040035F8 RID: 13816
		private bool isLoadingData = true;

		// Token: 0x040035F9 RID: 13817
		private List<EnhanceAttr> m_EnhanceAttrLst = new List<EnhanceAttr>();

		// Token: 0x040035FA RID: 13818
		private SeqList<int> m_exchangeRateList;
	}
}
