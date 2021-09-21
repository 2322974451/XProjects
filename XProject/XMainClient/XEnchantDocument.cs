using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A91 RID: 2705
	internal class XEnchantDocument : XDocComponent
	{
		// Token: 0x17002FD1 RID: 12241
		// (get) Token: 0x0600A483 RID: 42115 RVA: 0x001C7540 File Offset: 0x001C5740
		public override uint ID
		{
			get
			{
				return XEnchantDocument.uuID;
			}
		}

		// Token: 0x17002FD2 RID: 12242
		// (get) Token: 0x0600A484 RID: 42116 RVA: 0x001C7558 File Offset: 0x001C5758
		public ulong SelectedEquipUID
		{
			get
			{
				return this.m_SelectedEquip;
			}
		}

		// Token: 0x17002FD3 RID: 12243
		// (get) Token: 0x0600A485 RID: 42117 RVA: 0x001C7570 File Offset: 0x001C5770
		public int SelectedItemID
		{
			get
			{
				return this.m_SelectedItemID;
			}
		}

		// Token: 0x17002FD4 RID: 12244
		// (get) Token: 0x0600A486 RID: 42118 RVA: 0x001C7588 File Offset: 0x001C5788
		public List<XItem> ItemList
		{
			get
			{
				return this.m_ItemList;
			}
		}

		// Token: 0x17002FD5 RID: 12245
		// (get) Token: 0x0600A487 RID: 42119 RVA: 0x001C75A0 File Offset: 0x001C57A0
		public bool[] RedPointStates
		{
			get
			{
				return this.m_RedPointStates;
			}
		}

		// Token: 0x17002FD6 RID: 12246
		// (get) Token: 0x0600A488 RID: 42120 RVA: 0x001C75B8 File Offset: 0x001C57B8
		public XItemChangeAttr LastEnchantAttr
		{
			get
			{
				return this._lastEnchantAttr;
			}
		}

		// Token: 0x0600A489 RID: 42121 RVA: 0x001C75D0 File Offset: 0x001C57D0
		public static void Execute(OnLoadedCallback callback = null)
		{
			XEnchantDocument.AsyncLoader.AddTask("Table/EnchantEquip", XEnchantDocument._EnchantEquipTable, false);
			XEnchantDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600A48A RID: 42122 RVA: 0x001C75F8 File Offset: 0x001C57F8
		public static void OnTableLoaded()
		{
			XEnchantDocument._ItemFilter.Clear();
			XEnchantDocument._EnchantAttrs.Clear();
			for (int i = 0; i < XEnchantDocument._EnchantEquipTable.Table.Length; i++)
			{
				EnchantEquip.RowData rowData = XEnchantDocument._EnchantEquipTable.Table[i];
				XEnchantDocument._ItemFilter.AddItemID((int)rowData.EnchantID);
				for (int j = 0; j < rowData.Cost.Count; j++)
				{
					XEnchantDocument._ItemFilter.AddItemID((int)rowData.Cost[j, 0]);
				}
				XPrefixAttributes xprefixAttributes = new XPrefixAttributes();
				XEnchantDocument._EnchantAttrs.Add(rowData.EnchantID, xprefixAttributes);
				for (int k = 0; k < rowData.Attribute.Count; k++)
				{
					XPrefixAttribute xprefixAttribute = null;
					for (int l = 0; l < xprefixAttributes.AttributeList.Count; l++)
					{
						bool flag = xprefixAttributes.AttributeList[l].attrid == rowData.Attribute[k, 0];
						if (flag)
						{
							xprefixAttribute = xprefixAttributes.AttributeList[l];
							break;
						}
					}
					bool flag2 = xprefixAttribute == null;
					if (flag2)
					{
						xprefixAttribute = new XPrefixAttribute();
						xprefixAttribute.attrid = rowData.Attribute[k, 0];
						xprefixAttribute.minValue = float.MaxValue;
						xprefixAttributes.AttributeList.Add(xprefixAttribute);
					}
					xprefixAttribute.maxValue = Math.Max(xprefixAttribute.maxValue, rowData.Attribute[k, 2]);
					xprefixAttribute.minValue = Math.Min(xprefixAttribute.minValue, rowData.Attribute[k, 1]);
				}
			}
		}

		// Token: 0x0600A48B RID: 42123 RVA: 0x001C77C0 File Offset: 0x001C59C0
		public static void InitFromGlobalConfig()
		{
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("EnchantNeedLevel").Split(XGlobalConfig.ListSeparator);
			bool flag = XEnchantDocument.EnchantNeedLevel == null || XEnchantDocument.EnchantNeedLevel.Length != array.Length + 1;
			if (flag)
			{
				XEnchantDocument.EnchantNeedLevel = new uint[array.Length + 1];
				XEnchantDocument.EnchantNeedLevel[0] = 0U;
			}
			for (int i = 0; i < array.Length; i++)
			{
				XEnchantDocument.EnchantNeedLevel[i + 1] = uint.Parse(array[i]);
			}
			bool flag2 = XEnchantDocument.EnchantNeedLevel.Length > 1;
			if (flag2)
			{
				XEnchantDocument.EnchantMinLevel = XEnchantDocument.EnchantNeedLevel[1];
			}
			else
			{
				XEnchantDocument.EnchantMinLevel = 0U;
			}
		}

		// Token: 0x0600A48C RID: 42124 RVA: 0x001C7870 File Offset: 0x001C5A70
		public EnchantEquip.RowData GetEnchantEquipData(int itemid)
		{
			return XEnchantDocument._EnchantEquipTable.GetByEnchantID((uint)itemid);
		}

		// Token: 0x0600A48D RID: 42125 RVA: 0x001C7890 File Offset: 0x001C5A90
		public XPrefixAttributes GetEnchantAttrs(uint itemid)
		{
			XPrefixAttributes xprefixAttributes = null;
			bool flag = XEnchantDocument._EnchantAttrs.TryGetValue(itemid, out xprefixAttributes);
			XPrefixAttributes result;
			if (flag)
			{
				result = xprefixAttributes;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600A48E RID: 42126 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600A48F RID: 42127 RVA: 0x001C78BC File Offset: 0x001C5ABC
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_LoadEquip, new XComponent.XEventHandler(this.OnLoadEquip));
			base.RegisterEvent(XEventDefine.XEvent_UnloadEquip, new XComponent.XEventHandler(this.OnUnloadEquip));
			base.RegisterEvent(XEventDefine.XEvent_UpdateItem, new XComponent.XEventHandler(this.OnUpdateItem));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnVirtualItemChanged));
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemNumChanged, new XComponent.XEventHandler(this.OnItemNumChanged));
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnFinishItemChange));
		}

		// Token: 0x0600A490 RID: 42128 RVA: 0x001C797C File Offset: 0x001C5B7C
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this._EnchantOperateHandler != null && this._EnchantOperateHandler.IsVisible();
			if (flag)
			{
				this.ToggleBlock(false);
				this._EnchantOperateHandler.RefreshData();
			}
			bool flag2 = this._EnchantBagHandler != null && this._EnchantBagHandler.IsVisible();
			if (flag2)
			{
				this._EnchantBagHandler.RefreshData();
			}
		}

		// Token: 0x0600A491 RID: 42129 RVA: 0x001C79E0 File Offset: 0x001C5BE0
		public bool OnLoadEquip(XEventArgs args)
		{
			XLoadEquipEventArgs xloadEquipEventArgs = args as XLoadEquipEventArgs;
			bool flag = xloadEquipEventArgs.item.Type == ItemType.EQUIP;
			if (flag)
			{
				this._bShouldUpdateRedPoint = true;
			}
			return true;
		}

		// Token: 0x0600A492 RID: 42130 RVA: 0x001C7A14 File Offset: 0x001C5C14
		public bool OnUnloadEquip(XEventArgs args)
		{
			XUnloadEquipEventArgs xunloadEquipEventArgs = args as XUnloadEquipEventArgs;
			bool flag = xunloadEquipEventArgs.item.Type == ItemType.EQUIP;
			if (flag)
			{
				this._bShouldUpdateRedPoint = true;
			}
			return true;
		}

		// Token: 0x0600A493 RID: 42131 RVA: 0x001C7A48 File Offset: 0x001C5C48
		public bool OnUpdateItem(XEventArgs args)
		{
			XUpdateItemEventArgs xupdateItemEventArgs = args as XUpdateItemEventArgs;
			bool flag = xupdateItemEventArgs.item.Type == ItemType.EQUIP;
			if (flag)
			{
				this._bShouldUpdateRedPoint = true;
			}
			return true;
		}

		// Token: 0x0600A494 RID: 42132 RVA: 0x001C7A7C File Offset: 0x001C5C7C
		public bool OnVirtualItemChanged(XEventArgs args)
		{
			XVirtualItemChangedEventArgs xvirtualItemChangedEventArgs = args as XVirtualItemChangedEventArgs;
			bool flag = this._RelatedItemUpdated(xvirtualItemChangedEventArgs.itemID);
			if (flag)
			{
				this._bCostDirty |= this._IsUIShowed();
				this._bShouldUpdateRedPoint = true;
			}
			return true;
		}

		// Token: 0x0600A495 RID: 42133 RVA: 0x001C7AC4 File Offset: 0x001C5CC4
		protected bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			for (int i = 0; i < xaddItemEventArgs.items.Count; i++)
			{
				bool flag = this._RelatedItemUpdated(xaddItemEventArgs.items[i].itemID);
				if (flag)
				{
					this._bCostDirty |= this._IsUIShowed();
					this._bShouldUpdateRedPoint = true;
					break;
				}
			}
			return true;
		}

		// Token: 0x0600A496 RID: 42134 RVA: 0x001C7B34 File Offset: 0x001C5D34
		protected bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			for (int i = 0; i < xremoveItemEventArgs.ids.Count; i++)
			{
				bool flag = this._RelatedItemUpdated(xremoveItemEventArgs.ids[i]);
				if (flag)
				{
					this._bCostDirty |= this._IsUIShowed();
					this._bShouldUpdateRedPoint = true;
					break;
				}
			}
			return true;
		}

		// Token: 0x0600A497 RID: 42135 RVA: 0x001C7BA0 File Offset: 0x001C5DA0
		public bool OnItemNumChanged(XEventArgs args)
		{
			XItemNumChangedEventArgs xitemNumChangedEventArgs = args as XItemNumChangedEventArgs;
			bool flag = this._RelatedItemUpdated(xitemNumChangedEventArgs.item.itemID);
			if (flag)
			{
				this._bCostDirty |= this._IsUIShowed();
				this._bShouldUpdateRedPoint = true;
			}
			return true;
		}

		// Token: 0x0600A498 RID: 42136 RVA: 0x001C7BEC File Offset: 0x001C5DEC
		public bool OnFinishItemChange(XEventArgs args)
		{
			bool bShouldUpdateRedPoint = this._bShouldUpdateRedPoint;
			if (bShouldUpdateRedPoint)
			{
				this.UpdateRedPoints();
				this._bShouldUpdateRedPoint = false;
			}
			bool bCostDirty = this._bCostDirty;
			if (bCostDirty)
			{
				this._bCostDirty = false;
				bool flag = this._EnchantOperateHandler != null && this._EnchantOperateHandler.IsVisible();
				if (flag)
				{
					this._EnchantOperateHandler.RefreshItems();
				}
				bool flag2 = this._EnchantBagHandler != null && this._EnchantBagHandler.IsVisible();
				if (flag2)
				{
					this._EnchantBagHandler.RefreshData();
				}
			}
			return true;
		}

		// Token: 0x0600A499 RID: 42137 RVA: 0x001C7C7A File Offset: 0x001C5E7A
		public void UpdateRedPoints()
		{
			this.UpdateRedPoints(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
		}

		// Token: 0x0600A49A RID: 42138 RVA: 0x001C7C94 File Offset: 0x001C5E94
		public void UpdateRedPoints(uint playerLevel)
		{
			bool bState = false;
			bool flag = false;
			XBodyBag equipBag = XSingleton<XGame>.singleton.Doc.XBagDoc.EquipBag;
			for (int i = 0; i < XBagDocument.EquipMax; i++)
			{
				this.m_TempEquipConfList[i] = null;
				this.m_RedPointStates[i] = false;
				XEquipItem xequipItem = equipBag[i] as XEquipItem;
				bool flag2 = xequipItem == null || xequipItem.itemID == 0 || xequipItem.itemConf == null;
				if (!flag2)
				{
					bool flag3 = xequipItem.itemConf.ItemQuality < 3;
					if (!flag3)
					{
						EquipSuitTable.RowData suit = XCharacterEquipDocument.SuitManager.GetSuit(xequipItem.itemID, true);
						bool flag4 = suit == null;
						if (!flag4)
						{
							this.m_TempEquipConfList[i] = XBagDocument.GetEquipConf(xequipItem.itemID);
							flag |= (this.m_TempEquipConfList[i] != null);
						}
					}
				}
			}
			bool flag5 = flag;
			if (flag5)
			{
				List<XItem> allEnchantItemsTemporarily = this.GetAllEnchantItemsTemporarily();
				for (int j = 0; j < allEnchantItemsTemporarily.Count; j++)
				{
					EnchantEquip.RowData enchantEquipData = this.GetEnchantEquipData(allEnchantItemsTemporarily[j].itemID);
					bool flag6 = enchantEquipData == null;
					if (!flag6)
					{
						bool flag7 = (long)allEnchantItemsTemporarily[j].itemCount < (long)((ulong)enchantEquipData.Num);
						if (!flag7)
						{
							bool flag8 = true;
							for (int k = 0; k < (int)enchantEquipData.Cost.count; k++)
							{
								bool flag9 = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount((int)enchantEquipData.Cost[k, 0]) < (ulong)enchantEquipData.Cost[k, 1];
								if (flag9)
								{
									flag8 = false;
									break;
								}
							}
							bool flag10 = !flag8;
							if (!flag10)
							{
								bool flag11 = false;
								for (int l = 0; l < XBagDocument.EquipMax; l++)
								{
									EquipList.RowData rowData = this.m_TempEquipConfList[l];
									bool flag12 = rowData == null || this.m_RedPointStates[l];
									if (!flag12)
									{
										XEquipItem xequipItem2 = equipBag[l] as XEquipItem;
										bool bHasEnchant = xequipItem2.enchantInfo.bHasEnchant;
										if (!bHasEnchant)
										{
											flag11 = true;
											bool flag13 = !XEnchantDocument.IsEnchantMatched(rowData, enchantEquipData);
											if (!flag13)
											{
												bool flag14 = XEnchantDocument.CanEnchant((int)equipBag[l].itemConf.ReqLevel, enchantEquipData.EnchantLevel) == EnchantCheckResult.ECR_OK;
												if (flag14)
												{
													this.m_RedPointStates[l] = true;
													bState = true;
												}
											}
										}
									}
								}
								bool flag15 = !flag11;
								if (flag15)
								{
									break;
								}
							}
						}
					}
				}
			}
			XSingleton<XGameSysMgr>.singleton.SetSysRedState(XSysDefine.XSys_Item_Enchant, bState);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Item_Enchant, true);
			bool flag16 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EquipBagHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EquipBagHandler.IsVisible();
			if (flag16)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EquipBagHandler.RefreshRedPoints();
			}
		}

		// Token: 0x0600A49B RID: 42139 RVA: 0x001C7F88 File Offset: 0x001C6188
		private bool _IsUIShowed()
		{
			bool flag = this._EnchantOperateHandler == null || !this._EnchantOperateHandler.IsVisible();
			return !flag;
		}

		// Token: 0x0600A49C RID: 42140 RVA: 0x001C7FBC File Offset: 0x001C61BC
		private bool _RelatedItemUpdated(int itemid)
		{
			return XEnchantDocument._ItemFilter.Contains(itemid);
		}

		// Token: 0x0600A49D RID: 42141 RVA: 0x001C7FDC File Offset: 0x001C61DC
		public List<XItem> GetAllEnchantItemsTemporarily()
		{
			this.m_TempItemList.Clear();
			for (int i = 0; i < this.m_TempItemList2.Count; i++)
			{
				this.m_TempItemList2[i].Recycle();
			}
			this.m_TempItemList2.Clear();
			ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.ENCHANT);
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref this.m_TempItemList);
			this.m_TempItemList.Sort(new Comparison<XItem>(this._SortByID));
			this._MergeItemsWithSameID(this.m_TempItemList, this.m_TempItemList2);
			return this.m_TempItemList2;
		}

		// Token: 0x0600A49E RID: 42142 RVA: 0x001C8090 File Offset: 0x001C6290
		public List<XItem> GetEnchantItems()
		{
			ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.ENCHANT);
			for (int i = 0; i < this.m_ItemList.Count; i++)
			{
				this.m_ItemList[i].Recycle();
			}
			this.m_ItemList.Clear();
			this.m_TempItemList.Clear();
			this.m_TempDataDic.Clear();
			bool flag = this.m_SelectEquipItemConf == null;
			List<XItem> itemList;
			if (flag)
			{
				itemList = this.m_ItemList;
			}
			else
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(this.m_SelectEquipItemConf.ItemID);
				XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref this.m_TempItemList);
				int num = this.m_TempItemList.Count;
				int j = 0;
				while (j < num)
				{
					XItem xitem = this.m_TempItemList[j];
					EnchantEquip.RowData enchantEquipData = this.GetEnchantEquipData(xitem.itemID);
					bool flag2 = XEnchantDocument.IsEnchantMatched(equipConf, enchantEquipData);
					if (flag2)
					{
						this.m_TempDataDic[xitem.uid] = enchantEquipData;
						j++;
					}
					else
					{
						bool flag3 = --num > j;
						if (flag3)
						{
							XItem value = this.m_TempItemList[j];
							this.m_TempItemList[j] = this.m_TempItemList[num];
							this.m_TempItemList[num] = value;
						}
					}
				}
				bool flag4 = num < this.m_TempItemList.Count;
				if (flag4)
				{
					this.m_TempItemList.RemoveRange(num, this.m_TempItemList.Count - num);
				}
				this.m_TempItemList.Sort(new Comparison<XItem>(this._SortEnchantItems));
				this._MergeItemsWithSameID(this.m_TempItemList, this.m_ItemList);
				itemList = this.m_ItemList;
			}
			return itemList;
		}

		// Token: 0x0600A49F RID: 42143 RVA: 0x001C826C File Offset: 0x001C646C
		private void _MergeItemsWithSameID(List<XItem> from, List<XItem> to)
		{
			XItem xitem = null;
			for (int i = 0; i < from.Count; i++)
			{
				XItem xitem2 = from[i];
				bool flag = xitem == null || xitem.itemID != xitem2.itemID;
				if (flag)
				{
					xitem = XDataPool<XNormalItem>.GetData();
					to.Add(xitem);
					xitem.itemID = xitem2.itemID;
					xitem.itemConf = xitem2.itemConf;
				}
				xitem.itemCount += xitem2.itemCount;
			}
		}

		// Token: 0x0600A4A0 RID: 42144 RVA: 0x001C82F4 File Offset: 0x001C64F4
		private int _SortByID(XItem left, XItem right)
		{
			return left.itemID.CompareTo(right.itemID);
		}

		// Token: 0x0600A4A1 RID: 42145 RVA: 0x001C8318 File Offset: 0x001C6518
		private int _SortEnchantItems(XItem left, XItem right)
		{
			bool flag = this.m_SelectEquipItemConf == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				ItemList.RowData itemConf = left.itemConf;
				ItemList.RowData itemConf2 = right.itemConf;
				EnchantEquip.RowData rowData;
				this.m_TempDataDic.TryGetValue(left.uid, out rowData);
				EnchantEquip.RowData rowData2;
				this.m_TempDataDic.TryGetValue(right.uid, out rowData2);
				bool flag2 = itemConf == null || rowData == null;
				if (flag2)
				{
					result = 1;
				}
				else
				{
					bool flag3 = itemConf2 == null || rowData2 == null;
					if (flag3)
					{
						result = -1;
					}
					else
					{
						EnchantCheckResult enchantCheckResult = XEnchantDocument.CanEnchant((int)this.m_SelectEquipItemConf.ReqLevel, rowData.EnchantLevel);
						EnchantCheckResult enchantCheckResult2 = XEnchantDocument.CanEnchant((int)this.m_SelectEquipItemConf.ReqLevel, rowData2.EnchantLevel);
						bool flag4 = (enchantCheckResult == EnchantCheckResult.ECR_OK && enchantCheckResult2 == EnchantCheckResult.ECR_OK) || (enchantCheckResult != EnchantCheckResult.ECR_OK && enchantCheckResult2 > EnchantCheckResult.ECR_OK);
						if (flag4)
						{
							int num = -itemConf.ReqLevel.CompareTo(itemConf2.ReqLevel);
							bool flag5 = num != 0;
							if (flag5)
							{
								result = num;
							}
							else
							{
								num = -itemConf.ItemQuality.CompareTo(itemConf2.ItemQuality);
								bool flag6 = num != 0;
								if (flag6)
								{
									result = num;
								}
								else
								{
									num = itemConf.ItemID.CompareTo(itemConf2.ItemID);
									bool flag7 = num != 0;
									if (flag7)
									{
										result = num;
									}
									else
									{
										result = left.uid.CompareTo(right.uid);
									}
								}
							}
						}
						else
						{
							bool flag8 = enchantCheckResult == EnchantCheckResult.ECR_OK;
							if (flag8)
							{
								result = -1;
							}
							else
							{
								bool flag9 = enchantCheckResult2 == EnchantCheckResult.ECR_OK;
								if (flag9)
								{
									result = 1;
								}
								else
								{
									result = 0;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600A4A2 RID: 42146 RVA: 0x001C84A4 File Offset: 0x001C66A4
		public static EnchantCheckResult CanEnchant(int equipLevel, uint enchantItemLevel)
		{
			bool flag = (ulong)enchantItemLevel > (ulong)((long)XEnchantDocument.EnchantNeedLevel.Length);
			EnchantCheckResult result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("enchantItemLevel ", enchantItemLevel.ToString(), " > EnchantNeedLevel.Length ", XEnchantDocument.EnchantNeedLevel.Length.ToString(), null, null);
				result = EnchantCheckResult.ECR_INVALID;
			}
			else
			{
				bool flag2 = (long)equipLevel < (long)((ulong)XEnchantDocument.EnchantNeedLevel[(int)enchantItemLevel]);
				if (flag2)
				{
					result = EnchantCheckResult.ECR_ITEM_TOO_HIGH;
				}
				else
				{
					result = EnchantCheckResult.ECR_OK;
				}
			}
			return result;
		}

		// Token: 0x0600A4A3 RID: 42147 RVA: 0x001C8510 File Offset: 0x001C6710
		public static bool CanEquipEnchant(int equipLevel)
		{
			return (long)equipLevel >= (long)((ulong)XEnchantDocument.EnchantMinLevel);
		}

		// Token: 0x0600A4A4 RID: 42148 RVA: 0x001C8530 File Offset: 0x001C6730
		public static bool IsEnchantMatched(EquipList.RowData equipData, EnchantEquip.RowData enchantData)
		{
			bool flag = equipData == null || enchantData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < enchantData.Pos.Length; i++)
				{
					bool flag2 = enchantData.Pos[i] == (uint)equipData.EquipPos;
					if (flag2)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x0600A4A5 RID: 42149 RVA: 0x001C8588 File Offset: 0x001C6788
		public EnchantCheckResult CanEnchant(EnchantEquip.RowData enchantConf)
		{
			bool flag = this.m_SelectEquipItemConf == null || enchantConf == null;
			EnchantCheckResult result;
			if (flag)
			{
				result = EnchantCheckResult.ECR_INVALID;
			}
			else
			{
				result = XEnchantDocument.CanEnchant((int)this.m_SelectEquipItemConf.ReqLevel, enchantConf.EnchantLevel);
			}
			return result;
		}

		// Token: 0x0600A4A6 RID: 42150 RVA: 0x001C85C8 File Offset: 0x001C67C8
		public void SelectEquip(ulong uid)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(uid);
			bool flag = itemByUID == null || itemByUID.itemConf == null;
			if (!flag)
			{
				bool flag2 = !XEnchantDocument.CanEquipEnchant((int)itemByUID.itemConf.ReqLevel);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EnchantMinLevelRequired", new object[]
					{
						XEnchantDocument.EnchantMinLevel
					}), "fece00");
				}
				else
				{
					this.m_SelectEquipItemConf = itemByUID.itemConf;
					this.m_SelectedEquip = uid;
					bool flag3 = !DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible();
					if (!flag3)
					{
						bool flag4 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
						if (flag4)
						{
							DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SelectEquip(uid);
						}
						bool flag5 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EnchantHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EnchantHandler.IsVisible();
						if (flag5)
						{
							DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EnchantHandler.RefreshData();
						}
						else
						{
							DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.ShowRightPopView(DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EnchantHandler);
						}
					}
				}
			}
		}

		// Token: 0x0600A4A7 RID: 42151 RVA: 0x001C86E4 File Offset: 0x001C68E4
		public void SelectEnchantItem(int itemID)
		{
			this.m_SelectedItemID = itemID;
			bool flag = this._EnchantBagHandler != null && this._EnchantBagHandler.IsVisible();
			if (flag)
			{
				this._EnchantBagHandler.SetVisible(false);
			}
			bool flag2 = this._EnchantOperateHandler != null && this._EnchantOperateHandler.IsVisible();
			if (flag2)
			{
				this._EnchantOperateHandler.RefreshData();
			}
		}

		// Token: 0x0600A4A8 RID: 42152 RVA: 0x001C8748 File Offset: 0x001C6948
		public XEnchantInfo GetPreEnchantInfo()
		{
			return this._preInfo;
		}

		// Token: 0x0600A4A9 RID: 42153 RVA: 0x001C8760 File Offset: 0x001C6960
		public void SetPreEnchantInfo(XEnchantInfo info)
		{
			this._preInfo.Init();
			this._preInfo.AttrList = new List<XItemChangeAttr>(info.AttrList);
			this._preInfo.ChooseAttr = info.ChooseAttr;
			this._preInfo.EnchantIDList = new List<uint>(info.EnchantIDList);
		}

		// Token: 0x0600A4AA RID: 42154 RVA: 0x001C87B8 File Offset: 0x001C69B8
		public void ToggleBlock(bool bBlock)
		{
			XMainInterfaceDocument specificDocument = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
			specificDocument.AttrEventBlocker.bBlockReceiver = bBlock;
		}

		// Token: 0x0600A4AB RID: 42155 RVA: 0x001C87E0 File Offset: 0x001C69E0
		public void ReqEnchant()
		{
			RpcC2G_EnchantEquip rpcC2G_EnchantEquip = new RpcC2G_EnchantEquip();
			rpcC2G_EnchantEquip.oArg.enchantid = (uint)this.m_SelectedItemID;
			rpcC2G_EnchantEquip.oArg.uid = this.m_SelectedEquip;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_EnchantEquip);
			XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.SelectedEquipUID) as XEquipItem;
			this.ToggleBlock(true);
			bool flag = xequipItem == null;
			if (!flag)
			{
				this.SetPreEnchantInfo(xequipItem.enchantInfo);
			}
		}

		// Token: 0x0600A4AC RID: 42156 RVA: 0x001C8864 File Offset: 0x001C6A64
		public void OnGetEnchant(EnchantEquipArg oArg, EnchantEquipRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				this.ToggleBlock(false);
				bool flag2 = this._EnchantOperateHandler != null && this._EnchantOperateHandler.IsVisible();
				if (flag2)
				{
					this._EnchantOperateHandler.ResetOKCD();
				}
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				bool flag3 = oRes.attr != null;
				if (flag3)
				{
					this._lastEnchantAttr.AttrID = oRes.attr.id;
					this._lastEnchantAttr.AttrValue = oRes.attr.value;
				}
				bool flag4 = this._EnchantResultHandler != null && this._EnchantResultHandler.IsVisible();
				if (flag4)
				{
					this._EnchantResultHandler.RefreshData();
				}
				bool flag5 = this._EnchantOperateHandler != null && this._EnchantOperateHandler.IsVisible();
				if (flag5)
				{
					this._EnchantOperateHandler.RefreshData();
				}
			}
		}

		// Token: 0x0600A4AD RID: 42157 RVA: 0x001C8954 File Offset: 0x001C6B54
		public void SendEnchantActiveAttribute(uint curSelectedAttribute)
		{
			RpcC2G_EnchantActiveAttribute rpcC2G_EnchantActiveAttribute = new RpcC2G_EnchantActiveAttribute();
			rpcC2G_EnchantActiveAttribute.oArg.uid = this.m_SelectedEquip;
			rpcC2G_EnchantActiveAttribute.oArg.attrID = curSelectedAttribute;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_EnchantActiveAttribute);
		}

		// Token: 0x0600A4AE RID: 42158 RVA: 0x001C8994 File Offset: 0x001C6B94
		public void OnGetEnchantActiveAttr(EnchantActiveAttributeArg oArg, EnchantActiveAttributeRes oRes)
		{
			bool flag = this._EnchantActiveHandler != null && this._EnchantActiveHandler.IsVisible();
			if (flag)
			{
				this._EnchantActiveHandler.RefreshData();
			}
			bool flag2 = this._EnchantOperateHandler != null && this._EnchantOperateHandler.IsVisible();
			if (flag2)
			{
				this._EnchantOperateHandler.RefreshData();
			}
		}

		// Token: 0x04003BCD RID: 15309
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("EnchantDocument");

		// Token: 0x04003BCE RID: 15310
		public static uint EnchantMinLevel = 0U;

		// Token: 0x04003BCF RID: 15311
		public static uint[] EnchantNeedLevel;

		// Token: 0x04003BD0 RID: 15312
		private static EnchantEquip _EnchantEquipTable = new EnchantEquip();

		// Token: 0x04003BD1 RID: 15313
		private static XItemFilter _ItemFilter = new XItemFilter();

		// Token: 0x04003BD2 RID: 15314
		private static Dictionary<uint, XPrefixAttributes> _EnchantAttrs = new Dictionary<uint, XPrefixAttributes>();

		// Token: 0x04003BD3 RID: 15315
		private ulong m_SelectedEquip;

		// Token: 0x04003BD4 RID: 15316
		private ItemList.RowData m_SelectEquipItemConf;

		// Token: 0x04003BD5 RID: 15317
		private int m_SelectedItemID = 0;

		// Token: 0x04003BD6 RID: 15318
		private List<XItem> m_ItemList = new List<XItem>();

		// Token: 0x04003BD7 RID: 15319
		private List<XItem> m_TempItemList = new List<XItem>();

		// Token: 0x04003BD8 RID: 15320
		private List<XItem> m_TempItemList2 = new List<XItem>();

		// Token: 0x04003BD9 RID: 15321
		private EquipList.RowData[] m_TempEquipConfList = new EquipList.RowData[XBagDocument.EquipMax];

		// Token: 0x04003BDA RID: 15322
		private XItemRequiredCollector m_TempItemRequired = new XItemRequiredCollector();

		// Token: 0x04003BDB RID: 15323
		private bool[] m_RedPointStates = new bool[XBagDocument.EquipMax];

		// Token: 0x04003BDC RID: 15324
		private XItemChangeAttr _lastEnchantAttr;

		// Token: 0x04003BDD RID: 15325
		private Dictionary<ulong, EnchantEquip.RowData> m_TempDataDic = new Dictionary<ulong, EnchantEquip.RowData>();

		// Token: 0x04003BDE RID: 15326
		public EnchantOperateHandler _EnchantOperateHandler;

		// Token: 0x04003BDF RID: 15327
		public EnchantBagHandler _EnchantBagHandler;

		// Token: 0x04003BE0 RID: 15328
		public EnchantActiveHandler _EnchantActiveHandler;

		// Token: 0x04003BE1 RID: 15329
		public EnchantResultHandler _EnchantResultHandler;

		// Token: 0x04003BE2 RID: 15330
		private bool _bCostDirty = false;

		// Token: 0x04003BE3 RID: 15331
		private bool _bShouldUpdateRedPoint = false;

		// Token: 0x04003BE4 RID: 15332
		private XEnchantInfo _preInfo = default(XEnchantInfo);

		// Token: 0x04003BE5 RID: 15333
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();
	}
}
