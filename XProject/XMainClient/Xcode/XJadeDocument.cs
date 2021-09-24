using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XJadeDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XJadeDocument.uuID;
			}
		}

		public JadeTable jadeTable
		{
			get
			{
				return XJadeDocument._JadeTable;
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
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Item_Jade, true);
			}
		}

		public int[] JadeLevelUpCost
		{
			get
			{
				bool flag = this.jadeLevelUpCost == null;
				if (flag)
				{
					this.jadeLevelUpCost = XSingleton<XGlobalConfig>.singleton.GetIntList("JadeLevelUpCost").ToArray();
				}
				return this.jadeLevelUpCost;
			}
		}

		public XNewItemTipsMgr NewItems
		{
			get
			{
				return this._NewItems;
			}
		}

		public List<XItem> SelectedSlotItemList
		{
			get
			{
				return this.m_SelectedSlotItemList;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XJadeDocument.AsyncLoader.AddTask("Table/Jade", XJadeDocument._JadeTable, false);
			XJadeDocument.AsyncLoader.AddTask("Table/JadeSlot", XJadeDocument._JadeSlotTable, false);
			XJadeDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._NewItems.ClearItemType();
			this._NewItems.Filter.AddItemType(ItemType.JADE);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_LoadEquip, new XComponent.XEventHandler(this.OnLoadEquip));
			base.RegisterEvent(XEventDefine.XEvent_UnloadEquip, new XComponent.XEventHandler(this.OnUnloadEquip));
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_UpdateItem, new XComponent.XEventHandler(this.OnUpdateItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemNumChanged, new XComponent.XEventHandler(this.OnItemNumChanged));
			base.RegisterEvent(XEventDefine.XEvent_SwapItem, new XComponent.XEventHandler(this.OnSwapItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnFinishItemChange));
		}

		public XJadeItem GetJadeItem(ulong uid)
		{
			return XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(uid) as XJadeItem;
		}

		public SeqListRef<uint> GetSlotInfoByPos(byte pos)
		{
			JadeSlotTable.RowData byEquipSlot = XJadeDocument._JadeSlotTable.GetByEquipSlot(pos);
			bool flag = byEquipSlot == null;
			SeqListRef<uint> result;
			if (flag)
			{
				result = default(SeqListRef<uint>);
			}
			else
			{
				result = byEquipSlot.JadeSlotAndLevel;
			}
			return result;
		}

		public uint GetSlot(byte pos, int index)
		{
			SeqListRef<uint> slotInfoByPos = this.GetSlotInfoByPos(pos);
			bool flag = (int)slotInfoByPos.count > index;
			uint result;
			if (flag)
			{
				result = slotInfoByPos[index, 0];
			}
			else
			{
				result = 0U;
			}
			return result;
		}

		public bool JadeIsOpen(byte pos, uint level)
		{
			SeqListRef<uint> slotInfoByPos = this.GetSlotInfoByPos(pos);
			for (int i = 0; i < (int)slotInfoByPos.count; i++)
			{
				bool flag = level >= slotInfoByPos[i, 1];
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public int GetSlotOpenLevel(byte pos, int index)
		{
			SeqListRef<uint> slotInfoByPos = this.GetSlotInfoByPos(pos);
			bool flag = (int)slotInfoByPos.count > index;
			int result;
			if (flag)
			{
				result = (int)slotInfoByPos[index, 1];
			}
			else
			{
				result = -1;
			}
			return result;
		}

		public bool SlotLevelIsOpen(byte pos, int index)
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int slotOpenLevel = this.GetSlotOpenLevel(pos, index);
				bool flag2 = slotOpenLevel == -1;
				result = (!flag2 && (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= (ulong)((long)slotOpenLevel));
			}
			return result;
		}

		public List<XItem> GetJades()
		{
			ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.JADE);
			this.m_ItemList.Clear();
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref this.m_ItemList);
			return this.m_ItemList;
		}

		public void SelectEquip(ulong uid)
		{
			this.selectedEquip = uid;
			XEquipItem equipNew = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(uid) as XEquipItem;
			bool flag = this.equipHandler != null;
			if (flag)
			{
				this.equipHandler.SetEquipNew(equipNew);
			}
			JadeBagHandler jadeBagHandler = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._JadeBagHandler;
			bool flag2 = jadeBagHandler != null && jadeBagHandler.IsVisible();
			if (flag2)
			{
				jadeBagHandler.SetVisible(false);
			}
			bool flag3 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
			if (flag3)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SelectEquip(uid);
			}
		}

		public void SelectSlot(int slotIndex)
		{
			this.selectedSlotIndex = slotIndex;
			XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.selectedEquip) as XEquipItem;
			this.m_SelectedSlotItemList.Clear();
			bool flag = xequipItem == null;
			if (!flag)
			{
				bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
				if (!flag2)
				{
					EquipList.RowData equipConf = XBagDocument.GetEquipConf(xequipItem.itemID);
					bool flag3 = equipConf == null;
					if (!flag3)
					{
						this.GetJades();
						uint slot = this.GetSlot(equipConf.EquipPos, this.selectedSlotIndex);
						this.m_TempList0.Clear();
						this.m_TempList1.Clear();
						for (int i = 0; i < this.m_ItemList.Count; i++)
						{
							XJadeItem xjadeItem = this.m_ItemList[i] as XJadeItem;
							bool flag4 = xjadeItem == null;
							if (!flag4)
							{
								JadeTable.RowData byJadeID = XJadeDocument._JadeTable.GetByJadeID((uint)xjadeItem.itemID);
								bool flag5 = byJadeID == null;
								if (!flag5)
								{
									bool flag6 = byJadeID.JadeEquip != slot;
									if (!flag6)
									{
										int num = this.JadeLevelToMosaicLevel(byJadeID.JadeLevel);
										bool flag7 = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)num);
										if (flag7)
										{
											this.m_TempList1.Add(xjadeItem);
										}
										else
										{
											this.m_TempList0.Add(xjadeItem);
										}
									}
								}
							}
						}
						this.m_TempList0.Sort(new Comparison<XItem>(this._SortJade));
						this.m_TempList1.Sort(new Comparison<XItem>(this._SortJade));
						for (int j = 0; j < this.m_TempList0.Count; j++)
						{
							this.m_SelectedSlotItemList.Add(this.m_TempList0[j]);
						}
						for (int k = 0; k < this.m_TempList1.Count; k++)
						{
							this.m_SelectedSlotItemList.Add(this.m_TempList1[k]);
						}
						JadeBagHandler jadeBagHandler = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._JadeBagHandler;
						bool flag8 = jadeBagHandler != null;
						if (flag8)
						{
							bool flag9 = jadeBagHandler.IsVisible();
							if (flag9)
							{
								jadeBagHandler.RefreshData();
							}
							else
							{
								jadeBagHandler.SetVisible(true);
							}
						}
					}
				}
			}
		}

		private int _SortJade(XItem jade0, XItem jade1)
		{
			JadeTable.RowData byJadeID = XJadeDocument._JadeTable.GetByJadeID((uint)jade0.itemID);
			JadeTable.RowData byJadeID2 = XJadeDocument._JadeTable.GetByJadeID((uint)jade1.itemID);
			bool flag = byJadeID.JadeLevel == byJadeID2.JadeLevel;
			int result;
			if (flag)
			{
				result = byJadeID.JadeID.CompareTo(byJadeID2.JadeID);
			}
			else
			{
				result = -byJadeID.JadeLevel.CompareTo(byJadeID2.JadeLevel);
			}
			return result;
		}

		public void ReqComposeJade(ulong uid, uint addLevel)
		{
			RpcC2G_JadeCompose rpcC2G_JadeCompose = new RpcC2G_JadeCompose();
			rpcC2G_JadeCompose.oArg.JadeUniqueId = uid;
			rpcC2G_JadeCompose.oArg.ComposeType = 0U;
			rpcC2G_JadeCompose.oArg.AddLevel = addLevel;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_JadeCompose);
		}

		public void ReqUpdateJade(uint slot, uint addLevel)
		{
			RpcC2G_JadeCompose rpcC2G_JadeCompose = new RpcC2G_JadeCompose();
			rpcC2G_JadeCompose.oArg.SlotPos = slot;
			rpcC2G_JadeCompose.oArg.ComposeType = 1U;
			rpcC2G_JadeCompose.oArg.EquipUniqueId = this.selectedEquip;
			rpcC2G_JadeCompose.oArg.AddLevel = addLevel;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_JadeCompose);
		}

		public void OnComposeJade(JadeComposeArg oArg, JadeComposeRes oRes)
		{
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				bool flag2 = oRes.ErrorCode == ErrorCode.ERR_JADE_COUNTNOTENOUGH;
				if (flag2)
				{
					bool flag3 = oArg.ComposeType == 1U;
					if (flag3)
					{
						XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(oArg.EquipUniqueId) as XEquipItem;
						XJadeItem xjadeItem = xequipItem.jadeInfo.jades[(int)oArg.SlotPos];
						int itemID = xjadeItem.itemID;
						XSingleton<UiUtility>.singleton.ShowItemAccess(itemID, null);
					}
					else
					{
						int itemID2 = this.GetJadeItem(oArg.JadeUniqueId).itemID;
						XSingleton<UiUtility>.singleton.ShowItemAccess(itemID2, null);
					}
				}
				bool flag4 = oRes.ErrorCode == ErrorCode.ERR_JADE_MINEQUIPLEVEL;
				if (flag4)
				{
					bool flag5 = oArg.ComposeType == 1U;
					XJadeItem xjadeItem2;
					if (flag5)
					{
						XEquipItem xequipItem2 = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(oArg.EquipUniqueId) as XEquipItem;
						xjadeItem2 = xequipItem2.jadeInfo.jades[(int)oArg.SlotPos];
					}
					else
					{
						xjadeItem2 = this.GetJadeItem(oArg.JadeUniqueId);
					}
					ItemList.RowData itemConf = XBagDocument.GetItemConf(xjadeItem2.itemID);
					JadeTable.RowData byJadeID = this.jadeTable.GetByJadeID((uint)xjadeItem2.itemID);
					bool flag6 = itemConf == null || byJadeID == null;
					if (!flag6)
					{
						uint jadeLevel = byJadeID.JadeLevel;
						int num = this.JadeLevelToMosaicLevel(byJadeID.JadeLevel);
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("ERR_JADE_MINEQUIPLEVEL"), itemConf.ItemName[0], num.ToString()), "fece00");
					}
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
				}
			}
			else
			{
				JadeComposeFrameHandler jadeComposeFrameHandler = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._JadeComposeFrameHandler;
				bool flag7 = jadeComposeFrameHandler != null && jadeComposeFrameHandler.IsVisible();
				if (flag7)
				{
					bool flag8 = oArg.ComposeType == 1U;
					if (flag8)
					{
						this.RefreshUi(oArg.SlotPos);
					}
					else
					{
						List<XItem> list;
						bool itemByItemId = XBagDocument.BagDoc.GetItemByItemId((int)this.TargetItemId, out list);
						if (itemByItemId)
						{
							this.RefreshUi(list[0].uid);
						}
						else
						{
							jadeComposeFrameHandler.SetVisible(false);
						}
					}
				}
			}
		}

		public void ReqOperateJade0(ulong uid, uint type)
		{
			bool flag = this.selectedEquip == 0UL;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("JADE_DIALOG_NOEQUIP"), "fece00");
			}
			else
			{
				RpcC2G_JadeOperation rpcC2G_JadeOperation = new RpcC2G_JadeOperation();
				rpcC2G_JadeOperation.oArg.OperationType = type;
				rpcC2G_JadeOperation.oArg.JadeUniqueId = uid;
				rpcC2G_JadeOperation.oArg.EquipUniqueId = this.selectedEquip;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_JadeOperation);
			}
		}

		public void ReqPutOnJade(ulong uid)
		{
			bool flag = this.selectedEquip == 0UL;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("JADE_DIALOG_NOEQUIP"), "fece00");
			}
			else
			{
				RpcC2G_JadeOperation rpcC2G_JadeOperation = new RpcC2G_JadeOperation();
				rpcC2G_JadeOperation.oArg.OperationType = 0U;
				rpcC2G_JadeOperation.oArg.JadeUniqueId = uid;
				rpcC2G_JadeOperation.oArg.EquipUniqueId = this.selectedEquip;
				rpcC2G_JadeOperation.oArg.Pos = (uint)this.selectedSlotIndex;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_JadeOperation);
			}
		}

		public void ReqTakeOffJade(uint slotIndex)
		{
			bool flag = this.selectedEquip == 0UL;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("JADE_DIALOG_NOEQUIP"), "fece00");
			}
			else
			{
				RpcC2G_JadeOperation rpcC2G_JadeOperation = new RpcC2G_JadeOperation();
				rpcC2G_JadeOperation.oArg.OperationType = 1U;
				rpcC2G_JadeOperation.oArg.EquipUniqueId = this.selectedEquip;
				rpcC2G_JadeOperation.oArg.Pos = slotIndex;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_JadeOperation);
			}
		}

		public void OnOperateJade(JadeOperationArg oArg, JadeOperationRes oRes)
		{
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				bool flag2 = oRes.ErrorCode == ErrorCode.ERR_JADE_MINEQUIPLEVEL;
				if (flag2)
				{
					XJadeItem jadeItem = this.GetJadeItem(oArg.JadeUniqueId);
					ItemList.RowData itemConf = XBagDocument.GetItemConf(jadeItem.itemID);
					JadeTable.RowData byJadeID = this.jadeTable.GetByJadeID((uint)jadeItem.itemID);
					bool flag3 = itemConf == null || byJadeID == null;
					if (!flag3)
					{
						uint jadeLevel = byJadeID.JadeLevel;
						int num = this.JadeLevelToMosaicLevel(byJadeID.JadeLevel);
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("ERR_JADE_MINEQUIPLEVEL"), itemConf.ItemName[0], num.ToString()), "fece00");
					}
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
				}
			}
		}

		public void ReqBuySlot()
		{
			RpcC2G_BuyJadeSlot rpcC2G_BuyJadeSlot = new RpcC2G_BuyJadeSlot();
			rpcC2G_BuyJadeSlot.oArg.EquipUId = this.selectedEquip;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_BuyJadeSlot);
		}

		public void OnBuySlot(BuyJadeSlotRes oRes)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
		}

		public void TryToCompose(ulong uid)
		{
			this.composeSource = uid;
			XJadeItem jadeItem = this.GetJadeItem(uid);
			bool flag = jadeItem == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Cant find source jade. id = ", uid.ToString(), null, null, null, null);
			}
			else
			{
				JadeTable.RowData byJadeID = this.jadeTable.GetByJadeID((uint)jadeItem.itemID);
				bool flag2 = byJadeID == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Cant find jade config. id = ", jadeItem.itemID.ToString(), null, null, null, null);
				}
				else
				{
					ulong num = (ulong)byJadeID.JadeCompose[1];
					bool flag3 = num == 0UL;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("JADE_DIALOG_COMPOSE_MAX_LEVEL"), "fece00");
						this.composeSource = 0UL;
					}
					else
					{
						int num2 = (int)byJadeID.JadeCompose[0];
						JadeComposeFrameHandler jadeComposeFrameHandler = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._JadeComposeFrameHandler;
						bool flag4 = jadeComposeFrameHandler != null;
						if (flag4)
						{
							jadeComposeFrameHandler.ShowUi(-1, (uint)jadeItem.itemID, byJadeID.JadeLevel, this.composeSource);
						}
					}
				}
			}
		}

		private void RefreshUi(ulong uid)
		{
			this.composeSource = uid;
			XJadeItem jadeItem = this.GetJadeItem(uid);
			bool flag = jadeItem == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Cant find source jade. id = ", uid.ToString(), null, null, null, null);
			}
			else
			{
				JadeTable.RowData byJadeID = this.jadeTable.GetByJadeID((uint)jadeItem.itemID);
				bool flag2 = byJadeID == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Cant find jade config. id = ", jadeItem.itemID.ToString(), null, null, null, null);
				}
				else
				{
					JadeComposeFrameHandler jadeComposeFrameHandler = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._JadeComposeFrameHandler;
					bool flag3 = jadeComposeFrameHandler != null;
					if (flag3)
					{
						jadeComposeFrameHandler.ShowUi(-1, (uint)jadeItem.itemID, byJadeID.JadeLevel, this.composeSource);
					}
				}
			}
		}

		private void RefreshUi(uint slot)
		{
			XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.selectedEquip) as XEquipItem;
			bool flag = xequipItem == null;
			if (!flag)
			{
				XJadeItem xjadeItem = xequipItem.jadeInfo.jades[(int)slot];
				bool flag2 = xjadeItem == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Cant find source jade.", null, null, null, null, null);
				}
				else
				{
					JadeTable.RowData byJadeID = this.jadeTable.GetByJadeID((uint)xjadeItem.itemID);
					bool flag3 = byJadeID == null;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Cant find jade config. id = ", xjadeItem.itemID.ToString(), null, null, null, null);
					}
					else
					{
						JadeComposeFrameHandler jadeComposeFrameHandler = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._JadeComposeFrameHandler;
						bool flag4 = jadeComposeFrameHandler != null;
						if (flag4)
						{
							jadeComposeFrameHandler.ShowUi((int)slot, (uint)xjadeItem.itemID, byJadeID.JadeLevel, 0UL);
						}
					}
				}
			}
		}

		public void TryToCompose(uint slot)
		{
			XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.selectedEquip) as XEquipItem;
			bool flag = xequipItem == null;
			if (!flag)
			{
				XJadeItem xjadeItem = xequipItem.jadeInfo.jades[(int)slot];
				bool flag2 = xjadeItem == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Cant find source jade.", null, null, null, null, null);
				}
				else
				{
					JadeTable.RowData byJadeID = this.jadeTable.GetByJadeID((uint)xjadeItem.itemID);
					bool flag3 = byJadeID == null;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Cant find jade config. id = ", xjadeItem.itemID.ToString(), null, null, null, null);
					}
					else
					{
						ulong num = (ulong)byJadeID.JadeCompose[1];
						bool flag4 = num == 0UL;
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("JADE_DIALOG_COMPOSE_MAX_LEVEL"), "fece00");
							this.composeSource = 0UL;
						}
						else
						{
							int num2 = (int)byJadeID.JadeCompose[0];
							int num3 = this.JadeLevelToMosaicLevel(byJadeID.JadeLevel + 1U);
							bool flag5 = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
							if (flag5)
							{
								XSingleton<XDebug>.singleton.AddErrorLog("XPlayerData is null", null, null, null, null, null);
							}
							else
							{
								bool flag6 = (long)num3 > (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
								if (flag6)
								{
									XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("JADE_COMPOSE_TIP2"), num3), "fece00");
								}
								else
								{
									JadeComposeFrameHandler jadeComposeFrameHandler = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._JadeComposeFrameHandler;
									bool flag7 = jadeComposeFrameHandler != null;
									if (flag7)
									{
										jadeComposeFrameHandler.ShowUi((int)slot, (uint)xjadeItem.itemID, byJadeID.JadeLevel, 0UL);
									}
								}
							}
						}
					}
				}
			}
		}

		public XJadeItem CheckEquipedJadesAttrs(XJadeItem jade)
		{
			XEquipItem equip = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.selectedEquip) as XEquipItem;
			return this.CheckJadesAttrs(equip, jade);
		}

		public XJadeItem CheckJadesAttrs(XEquipItem equip, XJadeItem jade)
		{
			bool flag = equip == null || jade == null || jade.changeAttr.Count == 0;
			XJadeItem result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < equip.jadeInfo.jades.Length; i++)
				{
					XJadeItem xjadeItem = equip.jadeInfo.jades[i];
					bool flag2 = this.IsSameType(xjadeItem, jade);
					if (flag2)
					{
						return xjadeItem;
					}
				}
				result = null;
			}
			return result;
		}

		public bool IsSameType(XJadeItem jade0, XJadeItem jade1)
		{
			return jade0 != null && jade1 != null && jade0.changeAttr.Count > 0 && jade1.changeAttr.Count > 0 && jade0.changeAttr[0].AttrID == jade1.changeAttr[0].AttrID;
		}

		public int CheckProperSlot(XJadeItem jade)
		{
			bool flag = jade == null;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				XEquipItem equip = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.selectedEquip) as XEquipItem;
				result = this.CheckProperSlot(equip, jade);
			}
			return result;
		}

		public int CheckProperSlot(XEquipItem equip, XJadeItem jade)
		{
			bool flag = equip == null || jade == null;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				JadeTable.RowData byJadeID = XJadeDocument._JadeTable.GetByJadeID((uint)jade.itemID);
				bool flag2 = byJadeID == null;
				if (flag2)
				{
					result = -1;
				}
				else
				{
					int num = -1;
					foreach (uint slot in equip.jadeInfo.AllSlots())
					{
						num++;
						bool flag3 = this.IsSlotMatch(slot, byJadeID) && equip.jadeInfo.jades[num] == null;
						if (flag3)
						{
							return num;
						}
					}
					result = -1;
				}
			}
			return result;
		}

		public bool IsSlotMatch(uint slot, XJadeItem jade)
		{
			JadeTable.RowData byJadeID = XJadeDocument._JadeTable.GetByJadeID((uint)jade.itemID);
			bool flag = byJadeID == null;
			return !flag && this.IsSlotMatch(slot, byJadeID);
		}

		public bool IsSlotMatch(uint slot, JadeTable.RowData rowData)
		{
			return slot == rowData.JadeEquip;
		}

		public bool CanUpdate(int slotIndex)
		{
			bool flag = this.selectedEquip == 0UL;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XEquipItem equip = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.selectedEquip) as XEquipItem;
				result = this.CanUpdate(equip, slotIndex);
			}
			return result;
		}

		public bool CanUpdate(XEquipItem equip, int slotIndex)
		{
			bool flag = equip == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XJadeItem xjadeItem = equip.jadeInfo.jades[slotIndex];
				bool flag2 = xjadeItem == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					JadeTable.RowData byJadeID = this.jadeTable.GetByJadeID((uint)xjadeItem.itemID);
					bool flag3 = byJadeID == null;
					if (flag3)
					{
						result = false;
					}
					else
					{
						ulong num = (ulong)byJadeID.JadeCompose[1];
						bool flag4 = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(xjadeItem.itemID) >= (ulong)(byJadeID.JadeCompose[0] - 1U) && num != 0UL && this.IsLeveLOK(equip, xjadeItem, 1U);
						result = flag4;
					}
				}
			}
			return result;
		}

		public bool CanReplace(XEquipItem equipItem, int slotIndex)
		{
			this.GetJades();
			return this.CanReplace(equipItem, slotIndex, this.m_ItemList);
		}

		public bool CanReplace(XEquipItem equipItem, int slotIndex, List<XItem> jades)
		{
			bool flag = equipItem == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < jades.Count; i++)
				{
					XJadeItem jadeItem = jades[i] as XJadeItem;
					bool flag2 = this.CanBeMorePowerful(equipItem, slotIndex, jadeItem);
					if (flag2)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		public bool CanBeMorePowerful(XEquipItem equipItem, int slotIndex, XJadeItem jadeItem)
		{
			bool flag = equipItem == null || jadeItem == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = !this.IsLeveLOK(equipItem, jadeItem, 0U);
				if (flag2)
				{
					result = false;
				}
				else
				{
					XJadeItem xjadeItem = equipItem.jadeInfo.jades[slotIndex];
					bool flag3 = xjadeItem == null;
					if (flag3)
					{
						xjadeItem = this.CheckEquipedJadesAttrs(jadeItem);
						EquipList.RowData equipConf = XBagDocument.GetEquipConf(equipItem.itemID);
						bool flag4 = equipConf == null;
						if (flag4)
						{
							result = false;
						}
						else
						{
							SeqListRef<uint> slotInfoByPos = this.GetSlotInfoByPos(equipConf.EquipPos);
							bool flag5 = slotIndex >= (int)slotInfoByPos.count;
							result = (!flag5 && xjadeItem == null && this.IsSlotMatch(slotInfoByPos[slotIndex, 0], jadeItem));
						}
					}
					else
					{
						result = (this.IsSameType(jadeItem, xjadeItem) && XSingleton<XGame>.singleton.Doc.XBagDoc.IsAttrMorePowerful(jadeItem, xjadeItem, ItemAttrCompareType.IACT_SELF) == ItemAttrCompareResult.IACR_LARGER);
					}
				}
			}
			return result;
		}

		public List<int> MorePowerfulEquips
		{
			get
			{
				return this.m_MorePowerfulEquips;
			}
		}

		public List<int> GetAllCanBeMorePowerfulEquips()
		{
			List<XItem> jades = this.GetJades();
			XBagDocument xbagDoc = XSingleton<XGame>.singleton.Doc.XBagDoc;
			int num = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.EQUIP_START);
			int num2 = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.EQUIP_END);
			this.m_MorePowerfulEquips.Clear();
			for (int i = num; i < num2; i++)
			{
				XEquipItem xequipItem = xbagDoc.EquipBag[i] as XEquipItem;
				bool flag = xequipItem == null;
				if (!flag)
				{
					bool flag2 = false;
					foreach (XItem xitem in jades)
					{
						XJadeItem xjadeItem = xitem as XJadeItem;
						XJadeItem xjadeItem2 = this.CheckJadesAttrs(xequipItem, xjadeItem);
						bool flag3 = !this.IsLeveLOK(xequipItem, xjadeItem, 0U);
						if (!flag3)
						{
							bool flag4 = xjadeItem2 == null;
							if (flag4)
							{
								int num3 = this.CheckProperSlot(xequipItem, xjadeItem);
								bool flag5 = num3 != -1;
								if (flag5)
								{
									this.m_MorePowerfulEquips.Add(i);
									flag2 = true;
									break;
								}
							}
							else
							{
								bool flag6 = xbagDoc.IsAttrMorePowerful(xjadeItem, xjadeItem2, ItemAttrCompareType.IACT_SELF) == ItemAttrCompareResult.IACR_LARGER;
								if (flag6)
								{
									this.m_MorePowerfulEquips.Add(i);
									flag2 = true;
									break;
								}
							}
						}
					}
					bool flag7 = flag2;
					if (!flag7)
					{
						int num4 = 0;
						while ((long)num4 < (long)((ulong)xequipItem.jadeInfo.slotCount))
						{
							bool flag8 = this.CanUpdate(xequipItem, num4);
							if (flag8)
							{
								this.m_MorePowerfulEquips.Add(i);
								flag2 = true;
								break;
							}
							num4++;
						}
					}
				}
			}
			return this.m_MorePowerfulEquips;
		}

		public bool HasRedPoint(int equip)
		{
			for (int i = 0; i < this.MorePowerfulEquips.Count; i++)
			{
				bool flag = this.MorePowerfulEquips[i] == equip;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		protected bool OnLoadEquip(XEventArgs args)
		{
			XLoadEquipEventArgs xloadEquipEventArgs = args as XLoadEquipEventArgs;
			bool flag = xloadEquipEventArgs.item.Type == ItemType.EQUIP;
			if (flag)
			{
				this._bShouldUpdateRedPoints = true;
				this._bShouldCalcMorePowerfulTip = true;
			}
			return true;
		}

		protected bool OnUnloadEquip(XEventArgs args)
		{
			XUnloadEquipEventArgs xunloadEquipEventArgs = args as XUnloadEquipEventArgs;
			bool flag = xunloadEquipEventArgs.type == ItemType.EQUIP;
			if (flag)
			{
				this._bShouldUpdateRedPoints = true;
				this._bShouldCalcMorePowerfulTip = true;
			}
			return true;
		}

		public bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			this._bShouldUpdateRedPoints = this._NewItems.AddItems(xaddItemEventArgs.items, !xaddItemEventArgs.bNew);
			this._bShouldCalcMorePowerfulTip = this._bShouldUpdateRedPoints;
			return true;
		}

		public bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			this._bShouldUpdateRedPoints = this._NewItems.RemoveItems(xremoveItemEventArgs.uids, xremoveItemEventArgs.types, true);
			this._bShouldCalcMorePowerfulTip = this._bShouldUpdateRedPoints;
			return true;
		}

		public bool OnItemNumChanged(XEventArgs args)
		{
			XItemNumChangedEventArgs xitemNumChangedEventArgs = args as XItemNumChangedEventArgs;
			bool flag = xitemNumChangedEventArgs.item.Type == ItemType.JADE;
			if (flag)
			{
				this._bShouldUpdateRedPoints = true;
				this._bShouldCalcMorePowerfulTip = true;
			}
			return true;
		}

		public bool OnUpdateItem(XEventArgs args)
		{
			XUpdateItemEventArgs xupdateItemEventArgs = args as XUpdateItemEventArgs;
			XItem item = xupdateItemEventArgs.item;
			bool flag = xupdateItemEventArgs.item.Type == ItemType.EQUIP;
			if (flag)
			{
				this._bShouldUpdateRedPoints = true;
				this._bShouldCalcMorePowerfulTip = true;
			}
			bool flag2 = item.uid == this.selectedEquip;
			if (flag2)
			{
				bool flag3 = this.equipHandler != null && this.equipHandler.active;
				if (flag3)
				{
					this.equipHandler.SetEquipNew(item as XEquipItem);
				}
			}
			return true;
		}

		public bool OnSwapItem(XEventArgs args)
		{
			this._bShouldUpdateRedPoints = true;
			this._bShouldCalcMorePowerfulTip = true;
			return true;
		}

		public bool OnFinishItemChange(XEventArgs args)
		{
			bool bShouldUpdateRedPoints = this._bShouldUpdateRedPoints;
			if (bShouldUpdateRedPoints)
			{
				this.UpdateRedPoints();
				this._bShouldUpdateRedPoints = false;
			}
			bool bShouldCalcMorePowerfulTip = this._bShouldCalcMorePowerfulTip;
			if (bShouldCalcMorePowerfulTip)
			{
				JadeBagHandler jadeBagHandler = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._JadeBagHandler;
				bool flag = jadeBagHandler != null && jadeBagHandler.active;
				if (flag)
				{
					jadeBagHandler.RefreshData();
				}
				bool flag2 = this.equipHandler != null && this.equipHandler.active;
				if (flag2)
				{
					this.equipHandler.RecalcMorePowerfulTip();
				}
				this._bShouldCalcMorePowerfulTip = false;
			}
			return true;
		}

		public bool IsJadeMorePowerful(ulong uid)
		{
			return this.IsJadeMorePowerful(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(uid) as XJadeItem);
		}

		public bool IsJadeMorePowerful(XJadeItem jade)
		{
			bool flag = jade == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XBagDocument xbagDoc = XSingleton<XGame>.singleton.Doc.XBagDoc;
				XJadeItem xjadeItem = this.CheckEquipedJadesAttrs(jade);
				bool flag2 = !this.IsLeveLOK(jade, 0U);
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = xjadeItem == null;
					if (flag3)
					{
						int num = this.CheckProperSlot(jade);
						result = (num != -1);
					}
					else
					{
						result = (xbagDoc.IsAttrMorePowerful(jade, xjadeItem, ItemAttrCompareType.IACT_SELF) == ItemAttrCompareResult.IACR_LARGER);
					}
				}
			}
			return result;
		}

		public List<int> UpdateRedPoints()
		{
			List<int> allCanBeMorePowerfulEquips = this.GetAllCanBeMorePowerfulEquips();
			this.bCanBePowerful = (allCanBeMorePowerfulEquips.Count > 0);
			bool flag = this.equipHandler != null && this.equipHandler.active;
			if (flag)
			{
				this.equipHandler.EquipHandler.SetRedPoints(allCanBeMorePowerfulEquips);
			}
			return allCanBeMorePowerfulEquips;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.equipHandler != null && this.equipHandler.IsVisible();
			if (flag)
			{
				this.SelectEquip(this.selectedEquip);
			}
		}

		public void ShowTip(int itemId)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(itemId);
			bool flag = itemConf == null;
			if (!flag)
			{
				string @string = XStringDefineProxy.GetString("JADE_REPLACE_OK");
				object[] itemName = itemConf.ItemName;
				string text = string.Format(XStringDefineProxy.GetString(@string, itemName), new object[0]);
				XSingleton<UiUtility>.singleton.ShowSystemTip(text, "fece00");
			}
		}

		public int JadeLevelToMosaicLevel(uint jadeLevel)
		{
			bool flag = (ulong)jadeLevel > (ulong)((long)this.JadeMosaicLevel.Count);
			int result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("Jade Level = " + jadeLevel + " GlobalConfig No Deploy!", null, null, null, null, null);
				result = -1;
			}
			else
			{
				result = this.JadeMosaicLevel[(int)(jadeLevel - 1U)];
			}
			return result;
		}

		public int EquipLevel2JadeLevel(int equipLevel)
		{
			for (int i = this.JadeMosaicLevel.Count - 1; i >= 0; i--)
			{
				bool flag = this.JadeMosaicLevel[i] <= equipLevel;
				if (flag)
				{
					return i + 1;
				}
			}
			return 0;
		}

		public bool IsLeveLOK(XJadeItem jade, uint jadeLevelUp = 0U)
		{
			bool flag = jade == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.selectedEquip == 0UL;
				if (flag2)
				{
					result = false;
				}
				else
				{
					XEquipItem equip = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.selectedEquip) as XEquipItem;
					result = this.IsLeveLOK(equip, jade, jadeLevelUp);
				}
			}
			return result;
		}

		public bool IsLeveLOK(XEquipItem equip, XJadeItem jade, uint jadeLevelUp = 0U)
		{
			bool flag = equip == null || jade == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				JadeTable.RowData byJadeID = this.jadeTable.GetByJadeID((uint)jade.itemID);
				bool flag2 = byJadeID == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					int num = this.JadeLevelToMosaicLevel(byJadeID.JadeLevel + jadeLevelUp);
					bool flag3 = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
					if (flag3)
					{
						result = false;
					}
					else
					{
						bool flag4 = (long)num <= (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
						result = flag4;
					}
				}
			}
			return result;
		}

		private JadeTable.RowData GetRowDataByParentItemId(uint itemId)
		{
			bool flag = this.jadeTable == null;
			JadeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.jadeTable.Table.Length; i++)
				{
					bool flag2 = this.jadeTable.Table[i].JadeCompose[1] == itemId;
					if (flag2)
					{
						return this.jadeTable.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		public uint GetTargetItemId(uint sourceItemId, uint addLevel)
		{
			bool flag = addLevel == 0U;
			uint result;
			if (flag)
			{
				result = sourceItemId;
			}
			else
			{
				JadeTable.RowData byJadeID = this.jadeTable.GetByJadeID(sourceItemId);
				bool flag2 = byJadeID == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("cannot find id,sourceItemId = " + sourceItemId, null, null, null, null, null);
					result = 0U;
				}
				else
				{
					bool flag3 = addLevel == 1U;
					if (flag3)
					{
						result = byJadeID.JadeCompose[1];
					}
					else
					{
						uint num = byJadeID.JadeCompose[1];
						int num2 = 0;
						while ((long)num2 < (long)((ulong)(addLevel - 1U)))
						{
							byJadeID = this.jadeTable.GetByJadeID(num);
							bool flag4 = byJadeID == null;
							if (flag4)
							{
								XSingleton<XDebug>.singleton.AddErrorLog("not find this jade in jadetxt,id = " + num, null, null, null, null, null);
								break;
							}
							bool flag5 = byJadeID.JadeCompose[1] == 0U;
							if (flag5)
							{
								XSingleton<XDebug>.singleton.AddGreenLog("is end,id = " + num, null, null, null, null, null);
								break;
							}
							num = byJadeID.JadeCompose[1];
							num2++;
						}
						result = num;
					}
				}
			}
			return result;
		}

		public bool GetNeedItems(uint targetId, uint hadItemId, int type, out List<XTuple<uint, uint>> hadJades, out XTuple<uint, uint> needBuyJade, out ulong needGold, out uint needMall)
		{
			needGold = 0UL;
			needMall = 0U;
			hadJades = new List<XTuple<uint, uint>>();
			needBuyJade = new XTuple<uint, uint>();
			bool flag = targetId == hadItemId;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				ulong num = 1UL;
				for (JadeTable.RowData rowDataByParentItemId = this.GetRowDataByParentItemId(targetId); rowDataByParentItemId != null; rowDataByParentItemId = this.GetRowDataByParentItemId(rowDataByParentItemId.JadeID))
				{
					bool flag2 = (long)this.JadeLevelUpCost.Length > (long)((ulong)rowDataByParentItemId.JadeLevel);
					if (flag2)
					{
						needGold += (ulong)this.JadeLevelUpCost[(int)rowDataByParentItemId.JadeLevel] * num;
					}
					ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)rowDataByParentItemId.JadeID);
					num *= (ulong)rowDataByParentItemId.JadeCompose[0];
					bool flag3 = type != -1 && hadItemId == rowDataByParentItemId.JadeID && num > 0UL;
					if (flag3)
					{
						num -= 1UL;
					}
					bool flag4 = itemCount >= num;
					if (flag4)
					{
						XTuple<uint, uint> item = new XTuple<uint, uint>(rowDataByParentItemId.JadeID, (uint)num);
						hadJades.Add(item);
						return false;
					}
					bool flag5 = itemCount > 0UL;
					if (flag5)
					{
						XTuple<uint, uint> item2 = new XTuple<uint, uint>(rowDataByParentItemId.JadeID, (uint)itemCount);
						hadJades.Add(item2);
					}
					num -= itemCount;
					needBuyJade.Item1 = rowDataByParentItemId.JadeID;
					needBuyJade.Item2 = (uint)num;
				}
				XGameMallDocument specificDocument = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
				uint num2 = specificDocument.FindItemPrice(needBuyJade.Item1, 7U);
				needMall = num2 * needBuyJade.Item2;
				result = true;
			}
			return result;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("JadeDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static JadeTable _JadeTable = new JadeTable();

		private static JadeSlotTable _JadeSlotTable = new JadeSlotTable();

		public List<int> JadeMosaicLevel = XSingleton<XGlobalConfig>.singleton.GetIntList("JadeMosaicLevel");

		public JadeEquipHandler equipHandler;

		public ulong selectedEquip;

		public int selectedSlotIndex;

		public ulong composeSource;

		public uint TargetItemId = 0U;

		private bool _bCanBePowerful = false;

		private int[] jadeLevelUpCost;

		private bool _bShouldUpdateRedPoints = false;

		private bool _bShouldCalcMorePowerfulTip = false;

		private XNewItemTipsMgr _NewItems = new XNewItemTipsMgr();

		private List<XItem> m_ItemList = new List<XItem>();

		private List<XItem> m_SelectedSlotItemList = new List<XItem>();

		private List<XItem> m_TempList0 = new List<XItem>();

		private List<XItem> m_TempList1 = new List<XItem>();

		private List<int> m_MorePowerfulEquips = new List<int>();
	}
}
