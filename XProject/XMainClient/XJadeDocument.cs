using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009D2 RID: 2514
	internal class XJadeDocument : XDocComponent
	{
		// Token: 0x17002DBB RID: 11707
		// (get) Token: 0x060098B6 RID: 39094 RVA: 0x0017A8C4 File Offset: 0x00178AC4
		public override uint ID
		{
			get
			{
				return XJadeDocument.uuID;
			}
		}

		// Token: 0x17002DBC RID: 11708
		// (get) Token: 0x060098B7 RID: 39095 RVA: 0x0017A8DC File Offset: 0x00178ADC
		public JadeTable jadeTable
		{
			get
			{
				return XJadeDocument._JadeTable;
			}
		}

		// Token: 0x17002DBD RID: 11709
		// (get) Token: 0x060098B8 RID: 39096 RVA: 0x0017A8F4 File Offset: 0x00178AF4
		// (set) Token: 0x060098B9 RID: 39097 RVA: 0x0017A90C File Offset: 0x00178B0C
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

		// Token: 0x17002DBE RID: 11710
		// (get) Token: 0x060098BA RID: 39098 RVA: 0x0017A924 File Offset: 0x00178B24
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

		// Token: 0x17002DBF RID: 11711
		// (get) Token: 0x060098BB RID: 39099 RVA: 0x0017A964 File Offset: 0x00178B64
		public XNewItemTipsMgr NewItems
		{
			get
			{
				return this._NewItems;
			}
		}

		// Token: 0x17002DC0 RID: 11712
		// (get) Token: 0x060098BC RID: 39100 RVA: 0x0017A97C File Offset: 0x00178B7C
		public List<XItem> SelectedSlotItemList
		{
			get
			{
				return this.m_SelectedSlotItemList;
			}
		}

		// Token: 0x060098BD RID: 39101 RVA: 0x0017A994 File Offset: 0x00178B94
		public static void Execute(OnLoadedCallback callback = null)
		{
			XJadeDocument.AsyncLoader.AddTask("Table/Jade", XJadeDocument._JadeTable, false);
			XJadeDocument.AsyncLoader.AddTask("Table/JadeSlot", XJadeDocument._JadeSlotTable, false);
			XJadeDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060098BE RID: 39102 RVA: 0x0017A9CF File Offset: 0x00178BCF
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._NewItems.ClearItemType();
			this._NewItems.Filter.AddItemType(ItemType.JADE);
		}

		// Token: 0x060098BF RID: 39103 RVA: 0x0017A9F8 File Offset: 0x00178BF8
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

		// Token: 0x060098C0 RID: 39104 RVA: 0x0017AAB8 File Offset: 0x00178CB8
		public XJadeItem GetJadeItem(ulong uid)
		{
			return XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(uid) as XJadeItem;
		}

		// Token: 0x060098C1 RID: 39105 RVA: 0x0017AAE4 File Offset: 0x00178CE4
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

		// Token: 0x060098C2 RID: 39106 RVA: 0x0017AB1C File Offset: 0x00178D1C
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

		// Token: 0x060098C3 RID: 39107 RVA: 0x0017AB50 File Offset: 0x00178D50
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

		// Token: 0x060098C4 RID: 39108 RVA: 0x0017AB9C File Offset: 0x00178D9C
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

		// Token: 0x060098C5 RID: 39109 RVA: 0x0017ABD0 File Offset: 0x00178DD0
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

		// Token: 0x060098C6 RID: 39110 RVA: 0x0017AC24 File Offset: 0x00178E24
		public List<XItem> GetJades()
		{
			ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.JADE);
			this.m_ItemList.Clear();
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref this.m_ItemList);
			return this.m_ItemList;
		}

		// Token: 0x060098C7 RID: 39111 RVA: 0x0017AC74 File Offset: 0x00178E74
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

		// Token: 0x060098C8 RID: 39112 RVA: 0x0017AD08 File Offset: 0x00178F08
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

		// Token: 0x060098C9 RID: 39113 RVA: 0x0017AF60 File Offset: 0x00179160
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

		// Token: 0x060098CA RID: 39114 RVA: 0x0017AFCC File Offset: 0x001791CC
		public void ReqComposeJade(ulong uid, uint addLevel)
		{
			RpcC2G_JadeCompose rpcC2G_JadeCompose = new RpcC2G_JadeCompose();
			rpcC2G_JadeCompose.oArg.JadeUniqueId = uid;
			rpcC2G_JadeCompose.oArg.ComposeType = 0U;
			rpcC2G_JadeCompose.oArg.AddLevel = addLevel;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_JadeCompose);
		}

		// Token: 0x060098CB RID: 39115 RVA: 0x0017B014 File Offset: 0x00179214
		public void ReqUpdateJade(uint slot, uint addLevel)
		{
			RpcC2G_JadeCompose rpcC2G_JadeCompose = new RpcC2G_JadeCompose();
			rpcC2G_JadeCompose.oArg.SlotPos = slot;
			rpcC2G_JadeCompose.oArg.ComposeType = 1U;
			rpcC2G_JadeCompose.oArg.EquipUniqueId = this.selectedEquip;
			rpcC2G_JadeCompose.oArg.AddLevel = addLevel;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_JadeCompose);
		}

		// Token: 0x060098CC RID: 39116 RVA: 0x0017B070 File Offset: 0x00179270
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

		// Token: 0x060098CD RID: 39117 RVA: 0x0017B2A8 File Offset: 0x001794A8
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

		// Token: 0x060098CE RID: 39118 RVA: 0x0017B320 File Offset: 0x00179520
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

		// Token: 0x060098CF RID: 39119 RVA: 0x0017B3AC File Offset: 0x001795AC
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

		// Token: 0x060098D0 RID: 39120 RVA: 0x0017B424 File Offset: 0x00179624
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

		// Token: 0x060098D1 RID: 39121 RVA: 0x0017B4FC File Offset: 0x001796FC
		public void ReqBuySlot()
		{
			RpcC2G_BuyJadeSlot rpcC2G_BuyJadeSlot = new RpcC2G_BuyJadeSlot();
			rpcC2G_BuyJadeSlot.oArg.EquipUId = this.selectedEquip;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_BuyJadeSlot);
		}

		// Token: 0x060098D2 RID: 39122 RVA: 0x0017B52E File Offset: 0x0017972E
		public void OnBuySlot(BuyJadeSlotRes oRes)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
		}

		// Token: 0x060098D3 RID: 39123 RVA: 0x0017B548 File Offset: 0x00179748
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

		// Token: 0x060098D4 RID: 39124 RVA: 0x0017B650 File Offset: 0x00179850
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

		// Token: 0x060098D5 RID: 39125 RVA: 0x0017B704 File Offset: 0x00179904
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

		// Token: 0x060098D6 RID: 39126 RVA: 0x0017B7DC File Offset: 0x001799DC
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

		// Token: 0x060098D7 RID: 39127 RVA: 0x0017B98C File Offset: 0x00179B8C
		public XJadeItem CheckEquipedJadesAttrs(XJadeItem jade)
		{
			XEquipItem equip = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.selectedEquip) as XEquipItem;
			return this.CheckJadesAttrs(equip, jade);
		}

		// Token: 0x060098D8 RID: 39128 RVA: 0x0017B9C8 File Offset: 0x00179BC8
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

		// Token: 0x060098D9 RID: 39129 RVA: 0x0017BA3C File Offset: 0x00179C3C
		public bool IsSameType(XJadeItem jade0, XJadeItem jade1)
		{
			return jade0 != null && jade1 != null && jade0.changeAttr.Count > 0 && jade1.changeAttr.Count > 0 && jade0.changeAttr[0].AttrID == jade1.changeAttr[0].AttrID;
		}

		// Token: 0x060098DA RID: 39130 RVA: 0x0017BA98 File Offset: 0x00179C98
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

		// Token: 0x060098DB RID: 39131 RVA: 0x0017BAE0 File Offset: 0x00179CE0
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

		// Token: 0x060098DC RID: 39132 RVA: 0x0017BBA0 File Offset: 0x00179DA0
		public bool IsSlotMatch(uint slot, XJadeItem jade)
		{
			JadeTable.RowData byJadeID = XJadeDocument._JadeTable.GetByJadeID((uint)jade.itemID);
			bool flag = byJadeID == null;
			return !flag && this.IsSlotMatch(slot, byJadeID);
		}

		// Token: 0x060098DD RID: 39133 RVA: 0x0017BBD8 File Offset: 0x00179DD8
		public bool IsSlotMatch(uint slot, JadeTable.RowData rowData)
		{
			return slot == rowData.JadeEquip;
		}

		// Token: 0x060098DE RID: 39134 RVA: 0x0017BBF4 File Offset: 0x00179DF4
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

		// Token: 0x060098DF RID: 39135 RVA: 0x0017BC40 File Offset: 0x00179E40
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

		// Token: 0x060098E0 RID: 39136 RVA: 0x0017BCF8 File Offset: 0x00179EF8
		public bool CanReplace(XEquipItem equipItem, int slotIndex)
		{
			this.GetJades();
			return this.CanReplace(equipItem, slotIndex, this.m_ItemList);
		}

		// Token: 0x060098E1 RID: 39137 RVA: 0x0017BD20 File Offset: 0x00179F20
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

		// Token: 0x060098E2 RID: 39138 RVA: 0x0017BD78 File Offset: 0x00179F78
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

		// Token: 0x17002DC1 RID: 11713
		// (get) Token: 0x060098E3 RID: 39139 RVA: 0x0017BE5C File Offset: 0x0017A05C
		public List<int> MorePowerfulEquips
		{
			get
			{
				return this.m_MorePowerfulEquips;
			}
		}

		// Token: 0x060098E4 RID: 39140 RVA: 0x0017BE74 File Offset: 0x0017A074
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

		// Token: 0x060098E5 RID: 39141 RVA: 0x0017C030 File Offset: 0x0017A230
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

		// Token: 0x060098E6 RID: 39142 RVA: 0x0017C078 File Offset: 0x0017A278
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

		// Token: 0x060098E7 RID: 39143 RVA: 0x0017C0B4 File Offset: 0x0017A2B4
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

		// Token: 0x060098E8 RID: 39144 RVA: 0x0017C0EC File Offset: 0x0017A2EC
		public bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			this._bShouldUpdateRedPoints = this._NewItems.AddItems(xaddItemEventArgs.items, !xaddItemEventArgs.bNew);
			this._bShouldCalcMorePowerfulTip = this._bShouldUpdateRedPoints;
			return true;
		}

		// Token: 0x060098E9 RID: 39145 RVA: 0x0017C134 File Offset: 0x0017A334
		public bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			this._bShouldUpdateRedPoints = this._NewItems.RemoveItems(xremoveItemEventArgs.uids, xremoveItemEventArgs.types, true);
			this._bShouldCalcMorePowerfulTip = this._bShouldUpdateRedPoints;
			return true;
		}

		// Token: 0x060098EA RID: 39146 RVA: 0x0017C178 File Offset: 0x0017A378
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

		// Token: 0x060098EB RID: 39147 RVA: 0x0017C1B4 File Offset: 0x0017A3B4
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

		// Token: 0x060098EC RID: 39148 RVA: 0x0017C23C File Offset: 0x0017A43C
		public bool OnSwapItem(XEventArgs args)
		{
			this._bShouldUpdateRedPoints = true;
			this._bShouldCalcMorePowerfulTip = true;
			return true;
		}

		// Token: 0x060098ED RID: 39149 RVA: 0x0017C260 File Offset: 0x0017A460
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

		// Token: 0x060098EE RID: 39150 RVA: 0x0017C2F0 File Offset: 0x0017A4F0
		public bool IsJadeMorePowerful(ulong uid)
		{
			return this.IsJadeMorePowerful(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(uid) as XJadeItem);
		}

		// Token: 0x060098EF RID: 39151 RVA: 0x0017C324 File Offset: 0x0017A524
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

		// Token: 0x060098F0 RID: 39152 RVA: 0x0017C39C File Offset: 0x0017A59C
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

		// Token: 0x060098F1 RID: 39153 RVA: 0x0017C3F4 File Offset: 0x0017A5F4
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.equipHandler != null && this.equipHandler.IsVisible();
			if (flag)
			{
				this.SelectEquip(this.selectedEquip);
			}
		}

		// Token: 0x060098F2 RID: 39154 RVA: 0x0017C42C File Offset: 0x0017A62C
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

		// Token: 0x060098F3 RID: 39155 RVA: 0x0017C480 File Offset: 0x0017A680
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

		// Token: 0x060098F4 RID: 39156 RVA: 0x0017C4E0 File Offset: 0x0017A6E0
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

		// Token: 0x060098F5 RID: 39157 RVA: 0x0017C530 File Offset: 0x0017A730
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

		// Token: 0x060098F6 RID: 39158 RVA: 0x0017C58C File Offset: 0x0017A78C
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

		// Token: 0x060098F7 RID: 39159 RVA: 0x0017C61C File Offset: 0x0017A81C
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

		// Token: 0x060098F8 RID: 39160 RVA: 0x0017C690 File Offset: 0x0017A890
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

		// Token: 0x060098F9 RID: 39161 RVA: 0x0017C7BC File Offset: 0x0017A9BC
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

		// Token: 0x04003457 RID: 13399
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("JadeDocument");

		// Token: 0x04003458 RID: 13400
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003459 RID: 13401
		private static JadeTable _JadeTable = new JadeTable();

		// Token: 0x0400345A RID: 13402
		private static JadeSlotTable _JadeSlotTable = new JadeSlotTable();

		// Token: 0x0400345B RID: 13403
		public List<int> JadeMosaicLevel = XSingleton<XGlobalConfig>.singleton.GetIntList("JadeMosaicLevel");

		// Token: 0x0400345C RID: 13404
		public JadeEquipHandler equipHandler;

		// Token: 0x0400345D RID: 13405
		public ulong selectedEquip;

		// Token: 0x0400345E RID: 13406
		public int selectedSlotIndex;

		// Token: 0x0400345F RID: 13407
		public ulong composeSource;

		// Token: 0x04003460 RID: 13408
		public uint TargetItemId = 0U;

		// Token: 0x04003461 RID: 13409
		private bool _bCanBePowerful = false;

		// Token: 0x04003462 RID: 13410
		private int[] jadeLevelUpCost;

		// Token: 0x04003463 RID: 13411
		private bool _bShouldUpdateRedPoints = false;

		// Token: 0x04003464 RID: 13412
		private bool _bShouldCalcMorePowerfulTip = false;

		// Token: 0x04003465 RID: 13413
		private XNewItemTipsMgr _NewItems = new XNewItemTipsMgr();

		// Token: 0x04003466 RID: 13414
		private List<XItem> m_ItemList = new List<XItem>();

		// Token: 0x04003467 RID: 13415
		private List<XItem> m_SelectedSlotItemList = new List<XItem>();

		// Token: 0x04003468 RID: 13416
		private List<XItem> m_TempList0 = new List<XItem>();

		// Token: 0x04003469 RID: 13417
		private List<XItem> m_TempList1 = new List<XItem>();

		// Token: 0x0400346A RID: 13418
		private List<int> m_MorePowerfulEquips = new List<int>();
	}
}
