using System;
using System.Collections.Generic;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009CC RID: 2508
	internal class XCharacterEquipDocument : XDocComponent
	{
		// Token: 0x17002DA0 RID: 11680
		// (get) Token: 0x060097F3 RID: 38899 RVA: 0x00174F14 File Offset: 0x00173114
		public override uint ID
		{
			get
			{
				return XCharacterEquipDocument.uuID;
			}
		}

		// Token: 0x17002DA1 RID: 11681
		// (get) Token: 0x060097F4 RID: 38900 RVA: 0x00174F2C File Offset: 0x0017312C
		public static XEquipSuitManager SuitManager
		{
			get
			{
				return XCharacterEquipDocument._SuitManager;
			}
		}

		// Token: 0x17002DA2 RID: 11682
		// (get) Token: 0x060097F5 RID: 38901 RVA: 0x00174F44 File Offset: 0x00173144
		public static RandomAttrDataMgr RandomAttrMgr
		{
			get
			{
				return XCharacterEquipDocument._randomAttrMgr;
			}
		}

		// Token: 0x17002DA3 RID: 11683
		// (get) Token: 0x060097F6 RID: 38902 RVA: 0x00174F5C File Offset: 0x0017315C
		public static CharacterAttributesList AttributeTable
		{
			get
			{
				return XCharacterEquipDocument.m_AttributeTable;
			}
		}

		// Token: 0x17002DA4 RID: 11684
		// (get) Token: 0x060097F7 RID: 38903 RVA: 0x00174F74 File Offset: 0x00173174
		// (set) Token: 0x060097F8 RID: 38904 RVA: 0x00174F8C File Offset: 0x0017318C
		public CharacterEquipBagHandler Handler
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

		// Token: 0x17002DA5 RID: 11685
		// (get) Token: 0x060097F9 RID: 38905 RVA: 0x00174F98 File Offset: 0x00173198
		// (set) Token: 0x060097FA RID: 38906 RVA: 0x00174FB0 File Offset: 0x001731B0
		public bool bCanBePowerful
		{
			get
			{
				return this._bCanBePowerful;
			}
			set
			{
				this._bCanBePowerful = value;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Item_Equip, true);
			}
		}

		// Token: 0x17002DA6 RID: 11686
		// (get) Token: 0x060097FB RID: 38907 RVA: 0x00174FC8 File Offset: 0x001731C8
		public XNewItemTipsMgr NewItems
		{
			get
			{
				return this._NewItems;
			}
		}

		// Token: 0x17002DA7 RID: 11687
		// (get) Token: 0x060097FC RID: 38908 RVA: 0x00174FE0 File Offset: 0x001731E0
		public XItemRequiredCollector ItemRequiredCollector
		{
			get
			{
				return this.m_ItemRequiredCollector;
			}
		}

		// Token: 0x060097FD RID: 38909 RVA: 0x00174FF8 File Offset: 0x001731F8
		public static void Execute(OnLoadedCallback callback = null)
		{
			XCharacterEquipDocument.AsyncLoader.AddTask("Table/RandomAttributes", XCharacterEquipDocument.m_randomAttributesTab, false);
			XCharacterEquipDocument.AsyncLoader.AddTask("Table/CharacterAttributes", XCharacterEquipDocument.m_AttributeTable, false);
			XCharacterEquipDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060097FE RID: 38910 RVA: 0x00175033 File Offset: 0x00173233
		public static void CreateSuitManager(EquipSuitTable tableData)
		{
			XCharacterEquipDocument._SuitManager = new XEquipSuitManager(tableData.Table);
		}

		// Token: 0x060097FF RID: 38911 RVA: 0x00175046 File Offset: 0x00173246
		public static void OnTableLoaded()
		{
			XCharacterEquipDocument._randomAttrMgr = new RandomAttrDataMgr(XCharacterEquipDocument.m_randomAttributesTab);
		}

		// Token: 0x06009800 RID: 38912 RVA: 0x00175058 File Offset: 0x00173258
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._NewItems.ClearItemType();
			this._NewItems.Filter.AddItemType(ItemType.EQUIP);
		}

		// Token: 0x06009801 RID: 38913 RVA: 0x00175081 File Offset: 0x00173281
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			DlgBase<CapacityDownDlg, CapacityBehaviour>.singleton.IsInit = false;
			DlgBase<CapacityDownDlg, CapacityBehaviour>.singleton.m_oldPPT = 0;
		}

		// Token: 0x06009802 RID: 38914 RVA: 0x001750A4 File Offset: 0x001732A4
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_LoadEquip, new XComponent.XEventHandler(this.OnLoadEquip));
			base.RegisterEvent(XEventDefine.XEvent_UnloadEquip, new XComponent.XEventHandler(this.OnUnloadEquip));
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_SwapItem, new XComponent.XEventHandler(this.OnSwapItem));
			base.RegisterEvent(XEventDefine.XEvent_UpdateItem, new XComponent.XEventHandler(this.OnUpdateItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemNumChanged, new XComponent.XEventHandler(this.OnItemNumChanged));
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnFinishItemChange));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		// Token: 0x06009803 RID: 38915 RVA: 0x00175179 File Offset: 0x00173379
		public override void OnEnterSceneFinally()
		{
			XCharacterEquipDocument._randomAttrMgr.DataClear();
			base.OnEnterSceneFinally();
		}

		// Token: 0x06009804 RID: 38916 RVA: 0x00175190 File Offset: 0x00173390
		public List<XItem> GetEquips()
		{
			ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.EQUIP);
			this.m_ItemList.Clear();
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref this.m_ItemList);
			return this.m_ItemList;
		}

		// Token: 0x06009805 RID: 38917 RVA: 0x001751E0 File Offset: 0x001733E0
		private void _ShowSuitEffectTip(EquipSuitTable.RowData suit, int effectIndex, bool active)
		{
			int num = 0;
			int effectData = XEquipSuitManager.GetEffectData(suit, effectIndex, out num);
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SUIT_EFFECT_CHANGED", new object[]
			{
				suit.SuitName,
				effectIndex,
				XAttributeCommon.GetAttrStr(effectData) + " " + XAttributeCommon.GetAttrValueStr(effectData, (float)num),
				XStringDefineProxy.GetString(active ? "HAS_EFFECT" : "NO_EFFECT")
			}), "fece00");
		}

		// Token: 0x06009806 RID: 38918 RVA: 0x00175260 File Offset: 0x00173460
		private void _ProcessSuitEquiped(int itemid)
		{
			EquipSuitTable.RowData suit = XCharacterEquipDocument.SuitManager.GetSuit(itemid, false);
			bool flag = suit == null;
			if (!flag)
			{
				List<int> list = ListPool<int>.Get();
				XEquipSuitManager.GetEquipedSuits(suit, XSingleton<XGame>.singleton.Doc.XBagDoc.EquipBag, list);
				bool flag2 = XEquipSuitManager.IsEffectJustActivated(suit, list.Count);
				if (flag2)
				{
					this._ShowSuitEffectTip(suit, list.Count, true);
					CharacterEquipHandler characterEquipHandler = null;
					bool flag3 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible() && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.IsVisible();
					if (flag3)
					{
						characterEquipHandler = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler;
					}
					bool flag4 = characterEquipHandler != null;
					if (flag4)
					{
						characterEquipHandler.PlaySuitFx(list);
					}
				}
				ListPool<int>.Release(list);
			}
		}

		// Token: 0x06009807 RID: 38919 RVA: 0x00175328 File Offset: 0x00173528
		private void _ProcessSuitUnEquiped(int itemid)
		{
			EquipSuitTable.RowData suit = XCharacterEquipDocument.SuitManager.GetSuit(itemid, false);
			bool flag = suit == null;
			if (!flag)
			{
				int equipedSuits = XEquipSuitManager.GetEquipedSuits(suit, XSingleton<XGame>.singleton.Doc.XBagDoc.EquipBag, null);
				bool flag2 = XEquipSuitManager.IsEffectJustActivated(suit, equipedSuits + 1);
				if (flag2)
				{
					this._ShowSuitEffectTip(suit, equipedSuits + 1, false);
				}
			}
		}

		// Token: 0x06009808 RID: 38920 RVA: 0x00175384 File Offset: 0x00173584
		protected bool OnLoadEquip(XEventArgs args)
		{
			XLoadEquipEventArgs xloadEquipEventArgs = args as XLoadEquipEventArgs;
			bool flag = xloadEquipEventArgs.item.Type == ItemType.EQUIP;
			if (flag)
			{
				this._bShouldUpdateRedPoints = true;
				this._bShouldCalcMorePowerfulTip = true;
				this._bShouldUpdateOutlook = true;
			}
			bool flag2 = this._handler != null && this._handler.active;
			if (flag2)
			{
				this._handler.LoadEquip(xloadEquipEventArgs.item, xloadEquipEventArgs.slot);
			}
			this._ProcessSuitEquiped(xloadEquipEventArgs.item.itemID);
			return true;
		}

		// Token: 0x06009809 RID: 38921 RVA: 0x0017540C File Offset: 0x0017360C
		protected bool OnUnloadEquip(XEventArgs args)
		{
			XUnloadEquipEventArgs xunloadEquipEventArgs = args as XUnloadEquipEventArgs;
			bool flag = xunloadEquipEventArgs.type == ItemType.EQUIP;
			if (flag)
			{
				this._bShouldUpdateRedPoints = true;
				this._bShouldCalcMorePowerfulTip = true;
				this._bShouldUpdateOutlook = true;
			}
			bool flag2 = this._handler != null && this._handler.active;
			if (flag2)
			{
				this._handler.UnloadEquip(xunloadEquipEventArgs.slot);
			}
			this._ProcessSuitUnEquiped(xunloadEquipEventArgs.item.itemID);
			return true;
		}

		// Token: 0x0600980A RID: 38922 RVA: 0x00175488 File Offset: 0x00173688
		protected bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			this._bShouldUpdateRedPoints = this._NewItems.AddItems(xaddItemEventArgs.items, !xaddItemEventArgs.bNew);
			this._bShouldCalcMorePowerfulTip = this._bShouldUpdateRedPoints;
			bool flag = this._handler == null || !this._handler.active;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._handler.AddItem(xaddItemEventArgs.items);
				result = true;
			}
			return result;
		}

		// Token: 0x0600980B RID: 38923 RVA: 0x00175504 File Offset: 0x00173704
		protected bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			this._bShouldUpdateRedPoints = this._NewItems.RemoveItems(xremoveItemEventArgs.uids, xremoveItemEventArgs.types, true);
			this._bShouldCalcMorePowerfulTip = this._bShouldUpdateRedPoints;
			bool flag = this._handler == null || !this._handler.active;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._handler.RemoveItem(xremoveItemEventArgs.uids);
				result = true;
			}
			return result;
		}

		// Token: 0x0600980C RID: 38924 RVA: 0x0017557C File Offset: 0x0017377C
		protected bool OnSwapItem(XEventArgs args)
		{
			XSwapItemEventArgs xswapItemEventArgs = args as XSwapItemEventArgs;
			this._bShouldUpdateRedPoints = true;
			this._bShouldCalcMorePowerfulTip = true;
			this._bShouldUpdateOutlook = true;
			bool flag = xswapItemEventArgs.itemNowOnBody.Type != ItemType.EQUIP;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._NewItems.RemoveItem(xswapItemEventArgs.itemNowOnBody.uid, ItemType.EQUIP, false);
				bool flag2 = this._handler != null && this._handler.active;
				if (flag2)
				{
					this._handler.SwapItem(xswapItemEventArgs.itemNowOnBody, xswapItemEventArgs.itemNowInBag, xswapItemEventArgs.slot);
				}
				bool flag3 = XCharacterEquipDocument.SuitManager.WillChangeEquipedCount(xswapItemEventArgs.itemNowInBag.itemID, xswapItemEventArgs.itemNowOnBody.itemID) || XCharacterEquipDocument.SuitManager.WillChangeEquipedCount(xswapItemEventArgs.itemNowOnBody.itemID, xswapItemEventArgs.itemNowInBag.itemID);
				if (flag3)
				{
					this._ProcessSuitUnEquiped(xswapItemEventArgs.itemNowInBag.itemID);
					this._ProcessSuitEquiped(xswapItemEventArgs.itemNowOnBody.itemID);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600980D RID: 38925 RVA: 0x0017568C File Offset: 0x0017388C
		protected bool OnUpdateItem(XEventArgs args)
		{
			XUpdateItemEventArgs xupdateItemEventArgs = args as XUpdateItemEventArgs;
			bool flag = xupdateItemEventArgs.item.Type == ItemType.EQUIP;
			if (flag)
			{
				this._bShouldUpdateRedPoints = true;
				this._bShouldCalcMorePowerfulTip = true;
			}
			bool flag2 = XSingleton<XGame>.singleton.Doc.XBagDoc.EquipBag.HasItem(xupdateItemEventArgs.item.uid);
			if (flag2)
			{
				this._bShouldUpdateOutlook = true;
			}
			bool flag3 = this._handler == null || !this._handler.active;
			bool result;
			if (flag3)
			{
				result = false;
			}
			else
			{
				this._handler.UpdateItem(xupdateItemEventArgs.item);
				result = true;
			}
			return result;
		}

		// Token: 0x0600980E RID: 38926 RVA: 0x00175730 File Offset: 0x00173930
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
				this._handler.ItemNumChanged(xitemNumChangedEventArgs.item);
				result = true;
			}
			return result;
		}

		// Token: 0x0600980F RID: 38927 RVA: 0x00175780 File Offset: 0x00173980
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
				bool flag = this._handler != null && this._handler.active;
				if (flag)
				{
					this._handler.Refresh();
				}
				this._bShouldCalcMorePowerfulTip = false;
			}
			bool bShouldUpdateOutlook = this._bShouldUpdateOutlook;
			if (bShouldUpdateOutlook)
			{
				this._bShouldUpdateOutlook = false;
			}
			return true;
		}

		// Token: 0x06009810 RID: 38928 RVA: 0x001757FC File Offset: 0x001739FC
		public void RefreshBag()
		{
			bool flag = this._handler != null && this._handler.IsVisible();
			if (flag)
			{
				this._handler.Refresh();
			}
		}

		// Token: 0x06009811 RID: 38929 RVA: 0x00175834 File Offset: 0x00173A34
		public EquipCompare IsEquipMorePowerful(ulong uid)
		{
			return this.IsEquipMorePowerful(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(uid) as XEquipItem, XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
		}

		// Token: 0x06009812 RID: 38930 RVA: 0x00175878 File Offset: 0x00173A78
		public EquipCompare IsEquipMorePowerful(XEquipItem equip, uint playerLevel)
		{
			bool flag = equip == null;
			EquipCompare result;
			if (flag)
			{
				result = EquipCompare.EC_NONE;
			}
			else
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(equip.itemID);
				bool flag2 = itemConf == null;
				if (flag2)
				{
					result = EquipCompare.EC_NONE;
				}
				else
				{
					bool flag3 = (long)itemConf.ReqLevel > (long)((ulong)playerLevel);
					if (flag3)
					{
						result = EquipCompare.EC_NONE;
					}
					else
					{
						EquipList.RowData equipConf = XBagDocument.GetEquipConf(equip.itemID);
						bool flag4 = equipConf == null;
						if (flag4)
						{
							result = EquipCompare.EC_NONE;
						}
						else
						{
							bool flag5 = XBagDocument.IsProfMatched(equip.Prof);
							int equipPos = (int)equipConf.EquipPos;
							XBagDocument xbagDoc = XSingleton<XGame>.singleton.Doc.XBagDoc;
							XEquipItem xequipItem = xbagDoc.EquipBag[equipPos] as XEquipItem;
							bool flag6 = xequipItem == null;
							if (flag6)
							{
								bool flag7 = flag5;
								if (flag7)
								{
									result = EquipCompare.EC_MORE_POWERFUL;
								}
								else
								{
									result = EquipCompare.EC_NONE;
								}
							}
							else
							{
								bool flag8 = xequipItem.uid == equip.uid;
								if (flag8)
								{
									result = EquipCompare.EC_NONE;
								}
								else
								{
									EquipCompare equipCompare = EquipCompare.EC_NONE;
									bool flag9 = flag5;
									if (flag9)
									{
										ItemAttrCompareResult itemAttrCompareResult = xbagDoc.IsAttrMorePowerful(equip, xequipItem, ItemAttrCompareType.IACT_SELF);
										bool flag10 = itemAttrCompareResult == ItemAttrCompareResult.IACR_LARGER;
										if (flag10)
										{
											return EquipCompare.EC_MORE_POWERFUL;
										}
									}
									result = equipCompare;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06009813 RID: 38931 RVA: 0x00175990 File Offset: 0x00173B90
		public static EquipCompare GetFinal(EquipCompare mix)
		{
			bool flag = (mix & EquipCompare.EC_MORE_POWERFUL) > EquipCompare.EC_NONE;
			EquipCompare result;
			if (flag)
			{
				result = EquipCompare.EC_MORE_POWERFUL;
			}
			else
			{
				bool flag2 = (mix & EquipCompare.EC_CAN_EQUIP) > EquipCompare.EC_NONE;
				if (flag2)
				{
					result = EquipCompare.EC_CAN_EQUIP;
				}
				else
				{
					bool flag3 = (mix & EquipCompare.EC_CAN_SMELT) > EquipCompare.EC_NONE;
					if (flag3)
					{
						result = EquipCompare.EC_CAN_SMELT;
					}
					else
					{
						result = EquipCompare.EC_NONE;
					}
				}
			}
			return result;
		}

		// Token: 0x06009814 RID: 38932 RVA: 0x001759CD File Offset: 0x00173BCD
		public void UpdateRedPoints()
		{
			this.UpdateRedPoints(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
		}

		// Token: 0x06009815 RID: 38933 RVA: 0x001759E8 File Offset: 0x00173BE8
		public void UpdateRedPoints(uint playerLevel)
		{
			this._bCanBePowerful = false;
			List<XItem> equips = this.GetEquips();
			for (int i = 0; i < equips.Count; i++)
			{
				XEquipItem xequipItem = equips[i] as XEquipItem;
				bool flag = xequipItem == null;
				if (!flag)
				{
					EquipCompare equipCompare = this.IsEquipMorePowerful(xequipItem, playerLevel);
					bool flag2 = (equipCompare & EquipCompare.EC_MORE_POWERFUL) > EquipCompare.EC_NONE;
					if (flag2)
					{
						this.bCanBePowerful = true;
						break;
					}
				}
			}
			bool flag3 = !this._bCanBePowerful;
			if (flag3)
			{
				this.bCanBePowerful = false;
			}
		}

		// Token: 0x06009816 RID: 38934 RVA: 0x00175A70 File Offset: 0x00173C70
		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			XPlayerLevelChangedEventArgs xplayerLevelChangedEventArgs = arg as XPlayerLevelChangedEventArgs;
			this.UpdateRedPoints(xplayerLevelChangedEventArgs.level);
			return true;
		}

		// Token: 0x06009817 RID: 38935 RVA: 0x00175A98 File Offset: 0x00173C98
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.Handler != null && this.Handler.IsVisible();
			if (flag)
			{
				this.Handler.RefreshData();
			}
		}

		// Token: 0x04003412 RID: 13330
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CharacterEquipDocument");

		// Token: 0x04003413 RID: 13331
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003414 RID: 13332
		private static RandomAttributes m_randomAttributesTab = new RandomAttributes();

		// Token: 0x04003415 RID: 13333
		private static XEquipSuitManager _SuitManager;

		// Token: 0x04003416 RID: 13334
		private static RandomAttrDataMgr _randomAttrMgr;

		// Token: 0x04003417 RID: 13335
		private static CharacterAttributesList m_AttributeTable = new CharacterAttributesList();

		// Token: 0x04003418 RID: 13336
		private CharacterEquipBagHandler _handler = null;

		// Token: 0x04003419 RID: 13337
		private bool _bCanBePowerful = false;

		// Token: 0x0400341A RID: 13338
		private bool _bShouldUpdateRedPoints = false;

		// Token: 0x0400341B RID: 13339
		private bool _bShouldCalcMorePowerfulTip = false;

		// Token: 0x0400341C RID: 13340
		private bool _bShouldUpdateOutlook = false;

		// Token: 0x0400341D RID: 13341
		private XNewItemTipsMgr _NewItems = new XNewItemTipsMgr();

		// Token: 0x0400341E RID: 13342
		private XItemRequiredCollector m_ItemRequiredCollector = new XItemRequiredCollector();

		// Token: 0x0400341F RID: 13343
		private List<XItem> m_ItemList = new List<XItem>();
	}
}
