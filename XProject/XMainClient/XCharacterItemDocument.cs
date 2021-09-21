using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A81 RID: 2689
	internal class XCharacterItemDocument : XDocComponent
	{
		// Token: 0x17002F9F RID: 12191
		// (get) Token: 0x0600A387 RID: 41863 RVA: 0x001BFF74 File Offset: 0x001BE174
		public override uint ID
		{
			get
			{
				return XCharacterItemDocument.uuID;
			}
		}

		// Token: 0x17002FA0 RID: 12192
		// (get) Token: 0x0600A388 RID: 41864 RVA: 0x001BFF8C File Offset: 0x001BE18C
		// (set) Token: 0x0600A389 RID: 41865 RVA: 0x001BFFA4 File Offset: 0x001BE1A4
		public CharacterItemBagHandler Handler
		{
			get
			{
				return this._handler;
			}
			set
			{
				this._handler = value;
			}
		}

		// Token: 0x17002FA1 RID: 12193
		// (get) Token: 0x0600A38A RID: 41866 RVA: 0x001BFFB0 File Offset: 0x001BE1B0
		public bool bHasAvailableItems
		{
			get
			{
				return this._AvailableItems.bHasNew;
			}
		}

		// Token: 0x17002FA2 RID: 12194
		// (get) Token: 0x0600A38B RID: 41867 RVA: 0x001BFFD0 File Offset: 0x001BE1D0
		public XNewItemTipsMgr NewItems
		{
			get
			{
				return this._NewItems;
			}
		}

		// Token: 0x17002FA3 RID: 12195
		// (get) Token: 0x0600A38C RID: 41868 RVA: 0x001BFFE8 File Offset: 0x001BE1E8
		public XNewItemTipsMgr AvailableItems
		{
			get
			{
				return this._AvailableItems;
			}
		}

		// Token: 0x17002FA4 RID: 12196
		// (get) Token: 0x0600A38D RID: 41869 RVA: 0x001C0000 File Offset: 0x001BE200
		public static List<XTuple<uint, string>> TabList
		{
			get
			{
				return XCharacterItemDocument.m_tabList;
			}
		}

		// Token: 0x17002FA5 RID: 12197
		// (get) Token: 0x0600A38E RID: 41870 RVA: 0x001C0017 File Offset: 0x001BE217
		// (set) Token: 0x0600A38F RID: 41871 RVA: 0x001C001F File Offset: 0x001BE21F
		public uint BagType { get; set; }

		// Token: 0x17002FA6 RID: 12198
		// (get) Token: 0x0600A390 RID: 41872 RVA: 0x001C0028 File Offset: 0x001BE228
		// (set) Token: 0x0600A391 RID: 41873 RVA: 0x001C0040 File Offset: 0x001BE240
		public bool bBlock
		{
			get
			{
				return this.m_bBlock;
			}
			set
			{
				this.m_bBlock = value;
				bool flag = !this.m_bBlock;
				if (flag)
				{
					bool flag2 = this.Handler != null && this.Handler.IsVisible();
					if (flag2)
					{
						this.Handler.UpdateBag();
					}
				}
			}
		}

		// Token: 0x0600A392 RID: 41874 RVA: 0x001C008A File Offset: 0x001BE28A
		public static void Execute(OnLoadedCallback callback = null)
		{
			XCharacterItemDocument.ItemID_Index.Clear();
			XCharacterItemDocument.TypeID_Index.Clear();
			XCharacterItemDocument.AsyncLoader.AddTask("Table/ItemUseButtonList", XCharacterItemDocument.m_ItemUseButtonListTable, false);
			XCharacterItemDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600A393 RID: 41875 RVA: 0x001C00C8 File Offset: 0x001BE2C8
		public static void OnTableLoaded()
		{
			for (int i = 0; i < XCharacterItemDocument.m_ItemUseButtonListTable.Table.Length; i++)
			{
				ItemUseButtonList.RowData rowData = XCharacterItemDocument.m_ItemUseButtonListTable.Table[i];
				bool flag = rowData.ItemID > 0U;
				if (flag)
				{
					bool flag2 = XCharacterItemDocument.ItemID_Index.ContainsKey(rowData.ItemID);
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Duplicate ItemID in ItemUseButtonList ", rowData.ItemID.ToString(), null, null, null, null);
					}
					else
					{
						XCharacterItemDocument.ItemID_Index.Add(rowData.ItemID, i);
					}
				}
				else
				{
					bool flag3 = rowData.TypeID > 0U;
					if (flag3)
					{
						bool flag4 = XCharacterItemDocument.TypeID_Index.ContainsKey(rowData.TypeID);
						if (flag4)
						{
							XSingleton<XDebug>.singleton.AddErrorLog("Duplicate TypeID in ItemUseButtonList ", rowData.TypeID.ToString(), null, null, null, null);
						}
						else
						{
							XCharacterItemDocument.TypeID_Index.Add(rowData.TypeID, i);
						}
					}
				}
			}
		}

		// Token: 0x0600A394 RID: 41876 RVA: 0x001C01C4 File Offset: 0x001BE3C4
		public static void InitFromGlobalConfig()
		{
			XCharacterItemDocument._NoRedPointItems.Clear();
			List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("NoRedPointItems");
			XCharacterItemDocument._NoRedPointItems.UnionWith(intList);
		}

		// Token: 0x0600A395 RID: 41877 RVA: 0x001C01FC File Offset: 0x001BE3FC
		private ItemUseButtonList.RowData GetByItemID(uint itemID)
		{
			int num;
			bool flag = XCharacterItemDocument.ItemID_Index.TryGetValue(itemID, out num);
			ItemUseButtonList.RowData result;
			if (flag)
			{
				result = XCharacterItemDocument.m_ItemUseButtonListTable.Table[num];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600A396 RID: 41878 RVA: 0x001C0230 File Offset: 0x001BE430
		private ItemUseButtonList.RowData GetByTypeID(uint typeID)
		{
			int num;
			bool flag = XCharacterItemDocument.TypeID_Index.TryGetValue(typeID, out num);
			ItemUseButtonList.RowData result;
			if (flag)
			{
				result = XCharacterItemDocument.m_ItemUseButtonListTable.Table[num];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600A397 RID: 41879 RVA: 0x001C0264 File Offset: 0x001BE464
		public ItemUseButtonList.RowData GetButtonData(uint itemID, uint typeID)
		{
			ItemUseButtonList.RowData rowData = this.GetByItemID(itemID);
			bool flag = rowData == null;
			if (flag)
			{
				rowData = this.GetByTypeID(typeID);
			}
			return rowData;
		}

		// Token: 0x0600A398 RID: 41880 RVA: 0x001C0290 File Offset: 0x001BE490
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._NewItems.ClearItemType();
			List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("BagExcludedTypes");
			for (int i = 0; i < intList.Count; i++)
			{
				ItemType type = (ItemType)intList[i];
				this._NewItems.Filter.ExcludeItemType(type);
			}
			this._AvailableItems.ClearItemType();
			this._AvailableItems.Filter.AddItemType(ItemType.PECK);
			this._AvailableItems.Filter.AddItemType(ItemType.LOTTERY_BOX);
			this._AvailableItems.Filter.AddItemType(ItemType.FISH);
			this._AvailableItems.Filter.AddItemType(ItemType.PANDORA);
			this.m_UsedItem = 0UL;
			this.bBlock = false;
		}

		// Token: 0x0600A399 RID: 41881 RVA: 0x001C035C File Offset: 0x001BE55C
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_UpdateItem, new XComponent.XEventHandler(this.OnUpdateItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemNumChanged, new XComponent.XEventHandler(this.OnItemNumChanged));
			base.RegisterEvent(XEventDefine.XEvent_UnloadEquip, new XComponent.XEventHandler(this.OnUnloadEquip));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		// Token: 0x0600A39A RID: 41882 RVA: 0x001C03F4 File Offset: 0x001BE5F4
		public List<XItem> GetItem()
		{
			ulong filterValue = this._NewItems.Filter.FilterValue;
			this.m_ItemList.Clear();
			for (int i = 0; i < XBagDocument.BagDoc.ItemBag.Count; i++)
			{
				XItem xitem = XBagDocument.BagDoc.ItemBag[i];
				bool flag = xitem == null;
				if (!flag)
				{
					ulong num = 1UL << (int)xitem.type;
					bool flag2 = (num & filterValue) > 0UL;
					if (flag2)
					{
						bool flag3 = this.BagType > 0U;
						if (flag3)
						{
							bool flag4 = xitem.itemConf != null && (uint)xitem.itemConf.BagType == this.BagType;
							if (flag4)
							{
								this.m_ItemList.Add(xitem);
							}
						}
						else
						{
							this.m_ItemList.Add(xitem);
						}
					}
				}
			}
			return this.m_ItemList;
		}

		// Token: 0x0600A39B RID: 41883 RVA: 0x001C04E4 File Offset: 0x001BE6E4
		public int GetTotalNum()
		{
			ulong filterValue = this._NewItems.Filter.FilterValue;
			this.m_ItemList.Clear();
			XBagDocument.BagDoc.GetItemsByType(filterValue, ref this.m_ItemList);
			return this.m_ItemList.Count;
		}

		// Token: 0x0600A39C RID: 41884 RVA: 0x001C0530 File Offset: 0x001BE730
		public void UpdateBagTypeReddot()
		{
			this.m_bagTypeRedDotDic.Clear();
			foreach (ulong uid in this.AvailableItems.NewItems)
			{
				XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(uid);
				bool flag = itemByUID == null;
				if (!flag)
				{
					bool flag2 = itemByUID.itemConf != null;
					if (flag2)
					{
						bool flag3 = !this.m_bagTypeRedDotDic.ContainsKey((uint)itemByUID.itemConf.BagType);
						if (flag3)
						{
							this.m_bagTypeRedDotDic.Add((uint)itemByUID.itemConf.BagType, true);
						}
					}
				}
			}
			bool flag4 = this.m_bagTypeRedDotDic.Count != 0;
			if (flag4)
			{
				bool flag5 = !this.m_bagTypeRedDotDic.ContainsKey(0U);
				if (flag5)
				{
					this.m_bagTypeRedDotDic.Add(0U, true);
				}
			}
			bool flag6 = this.Handler != null && this.Handler.IsVisible();
			if (flag6)
			{
				this.Handler.UpdateTabRedDot();
			}
		}

		// Token: 0x0600A39D RID: 41885 RVA: 0x001C0654 File Offset: 0x001BE854
		protected bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			bool flag = false;
			bool flag2 = XSingleton<XEntityMgr>.singleton.Player != null;
			if (flag2)
			{
				uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				bool flag3 = false;
				for (int i = 0; i < xaddItemEventArgs.items.Count; i++)
				{
					bool flag4 = !flag;
					if (flag4)
					{
						bool flag5 = xaddItemEventArgs.items[i].Type != ItemType.EQUIP && xaddItemEventArgs.items[i].Type != ItemType.ARTIFACT && xaddItemEventArgs.items[i].Type != ItemType.EMBLEM;
						if (flag5)
						{
							flag = true;
						}
					}
					bool flag6 = xaddItemEventArgs.items[i].Type == ItemType.PANDORA;
					if (flag6)
					{
						PandoraHeart.RowData pandoraHeartConf = XBagDocument.GetPandoraHeartConf(xaddItemEventArgs.items[i].itemID, XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID);
						bool flag7 = pandoraHeartConf != null;
						if (flag7)
						{
							break;
						}
						bool flag8 = this._AvailableItems.AddItem(xaddItemEventArgs.items[i], true) && this._IsItemAvailable(xaddItemEventArgs.items[i], level);
						if (flag8)
						{
							this._AvailableItems.AddItem(xaddItemEventArgs.items[i], false);
							flag3 = true;
						}
					}
					else
					{
						bool flag9 = this._AvailableItems.AddItem(xaddItemEventArgs.items[i], true) && this._IsItemAvailable(xaddItemEventArgs.items[i], level);
						if (flag9)
						{
							this._AvailableItems.AddItem(xaddItemEventArgs.items[i], false);
							flag3 = true;
						}
					}
				}
				bool flag10 = flag3;
				if (flag10)
				{
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Bag_Item, true);
				}
			}
			bool flag11 = flag;
			if (flag11)
			{
				this.UpdateRedPoints();
			}
			bool flag12 = this._handler == null || !this._handler.active;
			bool result;
			if (flag12)
			{
				bool bNew = xaddItemEventArgs.bNew;
				if (bNew)
				{
					this._NewItems.AddItems(xaddItemEventArgs.items, false);
				}
				result = false;
			}
			else
			{
				bool flag13 = !this.bBlock;
				if (flag13)
				{
					this._handler.AddItem(xaddItemEventArgs.items);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600A39E RID: 41886 RVA: 0x001C08B8 File Offset: 0x001BEAB8
		protected bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < xremoveItemEventArgs.types.Count; i++)
			{
				bool flag3 = !flag2;
				if (flag3)
				{
					bool flag4 = xremoveItemEventArgs.types[i] != ItemType.EQUIP && xremoveItemEventArgs.types[i] != ItemType.ARTIFACT && xremoveItemEventArgs.types[i] != ItemType.EMBLEM;
					if (flag4)
					{
						flag2 = true;
					}
				}
				bool flag5 = this._AvailableItems.Filter.Contains(xremoveItemEventArgs.types[i]) && xremoveItemEventArgs.types[i] == ItemType.PANDORA;
				if (flag5)
				{
					flag = true;
					break;
				}
			}
			bool flag6 = !flag;
			if (flag6)
			{
				bool flag7 = this._AvailableItems.RemoveItems(xremoveItemEventArgs.uids, xremoveItemEventArgs.types, false);
				if (flag7)
				{
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Bag_Item, true);
				}
			}
			bool flag8 = flag2;
			if (flag8)
			{
				this.UpdateRedPoints();
			}
			bool flag9 = this._handler == null || !this._handler.active;
			bool result;
			if (flag9)
			{
				result = false;
			}
			else
			{
				this._NewItems.RemoveItems(xremoveItemEventArgs.uids, xremoveItemEventArgs.types, true);
				bool flag10 = !this.bBlock;
				if (flag10)
				{
					this._handler.RemoveItem(xremoveItemEventArgs.uids);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600A39F RID: 41887 RVA: 0x001C0A2C File Offset: 0x001BEC2C
		protected bool OnUpdateItem(XEventArgs args)
		{
			bool flag = this._handler == null || !this._handler.active;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XUpdateItemEventArgs xupdateItemEventArgs = args as XUpdateItemEventArgs;
				bool flag2 = !this.bBlock;
				if (flag2)
				{
					this._handler.UpdateItem(xupdateItemEventArgs.item);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600A3A0 RID: 41888 RVA: 0x001C0A88 File Offset: 0x001BEC88
		protected bool OnItemNumChanged(XEventArgs args)
		{
			bool flag = this._handler == null || !this._handler.active;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XItemNumChangedEventArgs xitemNumChangedEventArgs = args as XItemNumChangedEventArgs;
				bool flag2 = !this.bBlock;
				if (flag2)
				{
					this._handler.ItemNumChanged(xitemNumChangedEventArgs.item);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600A3A1 RID: 41889 RVA: 0x001C0AE4 File Offset: 0x001BECE4
		protected bool OnUnloadEquip(XEventArgs args)
		{
			bool flag = this._handler == null || !this._handler.active;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XUnloadEquipEventArgs xunloadEquipEventArgs = args as XUnloadEquipEventArgs;
				DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.HideToolTip(true);
				result = true;
			}
			return result;
		}

		// Token: 0x0600A3A2 RID: 41890 RVA: 0x001C0B2B File Offset: 0x001BED2B
		public void UpdateRedPoints()
		{
			this.UpdateRedPoints(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
		}

		// Token: 0x0600A3A3 RID: 41891 RVA: 0x001C0B44 File Offset: 0x001BED44
		public void UpdateRedPoints(uint playerLevel)
		{
			this._AvailableItems.Clear();
			this.m_AvailableItemList.Clear();
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(this._AvailableItems.Filter.FilterValue, ref this.m_AvailableItemList);
			for (int i = 0; i < this.m_AvailableItemList.Count; i++)
			{
				bool flag = this._IsItemAvailable(this.m_AvailableItemList[i], playerLevel);
				if (flag)
				{
					this._AvailableItems.AddItem(this.m_AvailableItemList[i], false);
				}
			}
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Bag_Item, true);
			this.UpdateBagTypeReddot();
		}

		// Token: 0x0600A3A4 RID: 41892 RVA: 0x001C0BFC File Offset: 0x001BEDFC
		private bool _IsItemAvailable(XItem item, uint playerLevel)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(item.itemID);
			bool flag = itemConf == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = item.Type == ItemType.PANDORA;
				if (flag2)
				{
					PandoraHeart.RowData pandoraHeartConf = XBagDocument.GetPandoraHeartConf(item.itemID, XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID);
					int num = 0;
					int num2 = 0;
					bool flag3 = pandoraHeartConf != null;
					if (flag3)
					{
						num = XBagDocument.BagDoc.ItemBag.GetItemCount((int)pandoraHeartConf.FireID);
						num2 = XBagDocument.BagDoc.ItemBag.GetItemCount((int)pandoraHeartConf.PandoraID);
					}
					bool flag4 = num2 < 1 || num < 1;
					if (flag4)
					{
						return false;
					}
				}
				bool flag5 = XCharacterItemDocument._NoRedPointItems.Contains(item.itemID);
				result = (!flag5 && (long)itemConf.ReqLevel <= (long)((ulong)playerLevel));
			}
			return result;
		}

		// Token: 0x0600A3A5 RID: 41893 RVA: 0x001C0CD8 File Offset: 0x001BEED8
		public void ToggleBlock(bool block)
		{
			XMainInterfaceDocument specificDocument = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
			specificDocument.AttrEventBlocker.bBlockReceiver = block;
			specificDocument.SetBlockItemsChange(block);
			XShowGetItemDocument specificDocument2 = XDocuments.GetSpecificDocument<XShowGetItemDocument>(XShowGetItemDocument.uuID);
			specificDocument2.bBlock = block;
			XLevelUpStatusDocument specificDocument3 = XDocuments.GetSpecificDocument<XLevelUpStatusDocument>(XLevelUpStatusDocument.uuID);
			specificDocument3.bBlock = block;
			this.bBlock = block;
		}

		// Token: 0x0600A3A6 RID: 41894 RVA: 0x001C0D34 File Offset: 0x001BEF34
		public void UseItem(ulong uid)
		{
			bool flag = this.m_UsedItem > 0UL;
			if (!flag)
			{
				RpcC2G_UseItem rpcC2G_UseItem = new RpcC2G_UseItem();
				rpcC2G_UseItem.oArg.uid = uid;
				rpcC2G_UseItem.oArg.count = 1U;
				rpcC2G_UseItem.oArg.OpType = ItemUseMgr.GetItemUseValue(ItemUse.BagFind);
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_UseItem);
				this.m_UsedItem = uid;
				this.ToggleBlock(true);
			}
		}

		// Token: 0x0600A3A7 RID: 41895 RVA: 0x001C0DA0 File Offset: 0x001BEFA0
		public void OnUseItem(UseItemArg oArg, UseItemRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				this.ShowEmblemTips(oArg, oRes);
			}
			bool flag2 = oArg.uid != this.m_UsedItem && this.m_UsedItem > 0UL;
			if (!flag2)
			{
				bool flag3 = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
				if (flag3)
				{
					this.ToggleBlock(false);
					bool flag4 = this.Handler != null && this.Handler.active && this.Handler.WheelOfFortune.active;
					if (flag4)
					{
						this.Handler.WheelOfFortune.ToggleOperation(false, false);
					}
				}
				else
				{
					bool flag5 = this.Handler != null && this.Handler.IsVisible();
					if (flag5)
					{
						this.Handler.RefreshTips(oArg.uid);
					}
				}
				this.m_UsedItem = 0UL;
			}
		}

		// Token: 0x0600A3A8 RID: 41896 RVA: 0x001C0E7C File Offset: 0x001BF07C
		private void ShowEmblemTips(UseItemArg oArg, UseItemRes oRes)
		{
			bool flag = oArg.OpType != 0U && oArg.OpType != 1U;
			if (!flag)
			{
				XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(oArg.uid);
				bool flag2 = itemByUID != null && itemByUID.Type == ItemType.EMBLEM;
				if (flag2)
				{
					XEmblemItem xemblemItem = itemByUID as XEmblemItem;
					bool flag3 = !xemblemItem.bIsSkillEmblem;
					if (!flag3)
					{
						SkillEmblem.RowData emblemSkillConf = XEmblemDocument.GetEmblemSkillConf((uint)xemblemItem.itemID);
						bool flag4 = emblemSkillConf == null;
						if (!flag4)
						{
							XSkillTreeDocument specificDocument = XDocuments.GetSpecificDocument<XSkillTreeDocument>(XSkillTreeDocument.uuID);
							List<string> skillNames = new List<string>
							{
								emblemSkillConf.SkillName,
								emblemSkillConf.ExSkillScript
							};
							bool flag5 = specificDocument.IsEquipThisSkill(skillNames);
							bool flag6 = !flag5;
							if (!flag6)
							{
								ItemList.RowData itemConf = XBagDocument.GetItemConf((int)emblemSkillConf.EmblemID);
								bool flag7 = itemConf == null;
								if (!flag7)
								{
									bool flag8 = oArg.OpType == 0U;
									if (flag8)
									{
										XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("Active_Emblem"), itemConf.ItemName[0], emblemSkillConf.SkillPPT), "fece00");
									}
									else
									{
										bool flag9 = oArg.OpType == 1U;
										if (flag9)
										{
											XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("Deactive_Emblem"), itemConf.ItemName[0], emblemSkillConf.SkillPPT), "fece00");
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600A3A9 RID: 41897 RVA: 0x001C1008 File Offset: 0x001BF208
		public void RefreshBag()
		{
			bool flag = this._handler != null && this._handler.IsVisible();
			if (flag)
			{
				this._handler.Refresh();
			}
		}

		// Token: 0x0600A3AA RID: 41898 RVA: 0x001C1040 File Offset: 0x001BF240
		public void ShowLotteryResult(int index)
		{
			bool flag = this.Handler != null && this.Handler.active && this.Handler.WheelOfFortune.active;
			if (flag)
			{
				this.Handler.WheelOfFortune.ShowResult(index);
			}
		}

		// Token: 0x0600A3AB RID: 41899 RVA: 0x001C1090 File Offset: 0x001BF290
		public void ShowWheelView(XItem item)
		{
			bool flag = this.Handler != null && this.Handler.active;
			if (flag)
			{
				this.Handler.WheelOfFortune.OpenWheel(item as XLotteryBoxItem);
			}
		}

		// Token: 0x0600A3AC RID: 41900 RVA: 0x001C10D0 File Offset: 0x001BF2D0
		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			XPlayerLevelChangedEventArgs xplayerLevelChangedEventArgs = arg as XPlayerLevelChangedEventArgs;
			this.UpdateRedPoints(xplayerLevelChangedEventArgs.level);
			return true;
		}

		// Token: 0x0600A3AD RID: 41901 RVA: 0x001C10F8 File Offset: 0x001BF2F8
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.m_UsedItem = 0UL;
			bool flag = this.Handler != null && this.Handler.IsVisible();
			if (flag)
			{
				this.Handler.UpdateBag();
			}
		}

		// Token: 0x0600A3AE RID: 41902 RVA: 0x001C1138 File Offset: 0x001BF338
		public static void InitTabList()
		{
			XCharacterItemDocument.m_tabList = new List<XTuple<uint, string>>();
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("ItemBagType");
			string[] array = value.Split(XGlobalConfig.AllSeparators);
			for (int i = 0; i < array.Length; i += 2)
			{
				XTuple<uint, string> xtuple = new XTuple<uint, string>();
				bool flag = !string.IsNullOrEmpty(array[i]) && !string.IsNullOrEmpty(array[i + 1]);
				if (flag)
				{
					xtuple.Item1 = uint.Parse(array[i]);
					xtuple.Item2 = array[i + 1];
					XCharacterItemDocument.m_tabList.Add(xtuple);
				}
			}
		}

		// Token: 0x04003B30 RID: 15152
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CharacterItemDocument");

		// Token: 0x04003B31 RID: 15153
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003B32 RID: 15154
		private static ItemUseButtonList m_ItemUseButtonListTable = new ItemUseButtonList();

		// Token: 0x04003B33 RID: 15155
		private static Dictionary<uint, int> ItemID_Index = new Dictionary<uint, int>();

		// Token: 0x04003B34 RID: 15156
		private static Dictionary<uint, int> TypeID_Index = new Dictionary<uint, int>();

		// Token: 0x04003B35 RID: 15157
		private CharacterItemBagHandler _handler = null;

		// Token: 0x04003B36 RID: 15158
		private XNewItemTipsMgr _NewItems = new XNewItemTipsMgr();

		// Token: 0x04003B37 RID: 15159
		private XNewItemTipsMgr _AvailableItems = new XNewItemTipsMgr();

		// Token: 0x04003B38 RID: 15160
		private static List<XTuple<uint, string>> m_tabList = null;

		// Token: 0x04003B39 RID: 15161
		private ulong m_UsedItem = 0UL;

		// Token: 0x04003B3A RID: 15162
		private List<XItem> m_ItemList = new List<XItem>();

		// Token: 0x04003B3B RID: 15163
		private List<XItem> m_AvailableItemList = new List<XItem>();

		// Token: 0x04003B3C RID: 15164
		private static HashSet<int> _NoRedPointItems = new HashSet<int>();

		// Token: 0x04003B3E RID: 15166
		private bool m_bBlock;

		// Token: 0x04003B3F RID: 15167
		public Dictionary<uint, bool> m_bagTypeRedDotDic = new Dictionary<uint, bool>();
	}
}
