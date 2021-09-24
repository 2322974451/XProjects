using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XEnhanceDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XEnhanceDocument.uuID;
			}
		}

		public static XEnhanceDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XEnhanceDocument.uuID) as XEnhanceDocument;
			}
		}

		public EnhanceTable Enhance
		{
			get
			{
				return XEnhanceDocument.m_enhanceTable;
			}
		}

		public EnhanceMaster EnhanceMasterTable
		{
			get
			{
				return XEnhanceDocument.m_EnhanceMasterTable;
			}
		}

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

		public uint HistoryMaxLevel
		{
			get
			{
				return this.m_historyMaxLevel;
			}
		}

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

		public List<int> MorePowerfulEquips
		{
			get
			{
				return this.m_morePowerfulEquips;
			}
		}

		public List<int> RedPointEquips
		{
			get
			{
				return this.m_RedPointEquips;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XEnhanceDocument.AsyncLoader.AddTask("Table/Enhance", XEnhanceDocument.m_enhanceTable, false);
			XEnhanceDocument.AsyncLoader.AddTask("Table/EnhanceMaster", XEnhanceDocument.m_EnhanceMasterTable, false);
			XEnhanceDocument.AsyncLoader.Execute(callback);
		}

		private static int MakeKey(uint profID, uint pos, uint enhanceLevel)
		{
			return (profID * 100000U + pos * 1000U + enhanceLevel).GetHashCode();
		}

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

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.selectedEquip = 0UL;
			this._NewItems.ClearItemType();
			this._NewItems.Filter.AddItemType(ItemType.MATERAIL);
			this.RED_POINT_LEVEL_COUNT = XSingleton<XGlobalConfig>.singleton.GetInt("EnhanceRedPointLevelCount");
		}

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

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

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

		protected bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			this.m_bShouldUpdateRedPoints = this._NewItems.AddItems(xaddItemEventArgs.items, true);
			return true;
		}

		protected bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			this.m_bShouldUpdateRedPoints = this._NewItems.RemoveItems(xremoveItemEventArgs.uids, xremoveItemEventArgs.types, true);
			return true;
		}

		protected bool OnSwapItem(XEventArgs args)
		{
			XSwapItemEventArgs xswapItemEventArgs = args as XSwapItemEventArgs;
			this.m_bShouldUpdateRedPoints = true;
			return true;
		}

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

		public void ReqEnhance()
		{
			RpcC2G_EnhanceItem rpcC2G_EnhanceItem = new RpcC2G_EnhanceItem();
			rpcC2G_EnhanceItem.oArg.UniqueItemId = this.selectedEquip;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_EnhanceItem);
			this.rpcState = XEnhanceRpcState.ERS_RECEIVING;
		}

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

		public List<ComAgate> CombainItems
		{
			get
			{
				return this.m_combainItems;
			}
		}

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

		public List<EnhanceAttr> EnhanceAttrLst
		{
			get
			{
				return this.m_EnhanceAttrLst;
			}
		}

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

		private int _SortComparison(XEquipItem left, XEquipItem right)
		{
			return left.enhanceInfo.EnhanceLevel.CompareTo(right.enhanceInfo.EnhanceLevel);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("EnhanceDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static EnhanceTable m_enhanceTable = new EnhanceTable();

		private static EnhanceMaster m_EnhanceMasterTable = new EnhanceMaster();

		public EnhanceView enhanceView;

		public EnhanceMasterHandler enhanceMasterView;

		public ulong selectedEquip = 0UL;

		public bool IsNeedBreak = false;

		public XEnhanceRpcState rpcState = XEnhanceRpcState.ERS_NONE;

		private XNewItemTipsMgr _NewItems = new XNewItemTipsMgr();

		private int RED_POINT_LEVEL_COUNT = 5;

		private XItemRequiredCollector m_ItemsRequiredCollector = new XItemRequiredCollector();

		private bool _bCanBePowerful = false;

		private uint m_historyMaxLevel = 0U;

		private bool m_bShouldUpdateRedPoints = false;

		private List<int> m_morePowerfulEquips = new List<int>();

		private List<int> m_RedPointEquips = new List<int>();

		private static uint maxPos = 0U;

		private static uint maxEnhanceLevel = 0U;

		private static bool enhanceIndexed = true;

		private List<XTuple<uint, uint>> m_nextLevelAttr = new List<XTuple<uint, uint>>();

		private List<ComAgate> m_combainItems = null;

		private bool isLoadingData = true;

		private List<EnhanceAttr> m_EnhanceAttrLst = new List<EnhanceAttr>();

		private SeqList<int> m_exchangeRateList;
	}
}
