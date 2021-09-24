using System;
using System.Collections.Generic;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCharacterEquipDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XCharacterEquipDocument.uuID;
			}
		}

		public static XEquipSuitManager SuitManager
		{
			get
			{
				return XCharacterEquipDocument._SuitManager;
			}
		}

		public static RandomAttrDataMgr RandomAttrMgr
		{
			get
			{
				return XCharacterEquipDocument._randomAttrMgr;
			}
		}

		public static CharacterAttributesList AttributeTable
		{
			get
			{
				return XCharacterEquipDocument.m_AttributeTable;
			}
		}

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

		public XNewItemTipsMgr NewItems
		{
			get
			{
				return this._NewItems;
			}
		}

		public XItemRequiredCollector ItemRequiredCollector
		{
			get
			{
				return this.m_ItemRequiredCollector;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XCharacterEquipDocument.AsyncLoader.AddTask("Table/RandomAttributes", XCharacterEquipDocument.m_randomAttributesTab, false);
			XCharacterEquipDocument.AsyncLoader.AddTask("Table/CharacterAttributes", XCharacterEquipDocument.m_AttributeTable, false);
			XCharacterEquipDocument.AsyncLoader.Execute(callback);
		}

		public static void CreateSuitManager(EquipSuitTable tableData)
		{
			XCharacterEquipDocument._SuitManager = new XEquipSuitManager(tableData.Table);
		}

		public static void OnTableLoaded()
		{
			XCharacterEquipDocument._randomAttrMgr = new RandomAttrDataMgr(XCharacterEquipDocument.m_randomAttributesTab);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._NewItems.ClearItemType();
			this._NewItems.Filter.AddItemType(ItemType.EQUIP);
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			DlgBase<CapacityDownDlg, CapacityBehaviour>.singleton.IsInit = false;
			DlgBase<CapacityDownDlg, CapacityBehaviour>.singleton.m_oldPPT = 0;
		}

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

		public override void OnEnterSceneFinally()
		{
			XCharacterEquipDocument._randomAttrMgr.DataClear();
			base.OnEnterSceneFinally();
		}

		public List<XItem> GetEquips()
		{
			ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.EQUIP);
			this.m_ItemList.Clear();
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref this.m_ItemList);
			return this.m_ItemList;
		}

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

		public void RefreshBag()
		{
			bool flag = this._handler != null && this._handler.IsVisible();
			if (flag)
			{
				this._handler.Refresh();
			}
		}

		public EquipCompare IsEquipMorePowerful(ulong uid)
		{
			return this.IsEquipMorePowerful(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(uid) as XEquipItem, XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
		}

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

		public void UpdateRedPoints()
		{
			this.UpdateRedPoints(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
		}

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

		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			XPlayerLevelChangedEventArgs xplayerLevelChangedEventArgs = arg as XPlayerLevelChangedEventArgs;
			this.UpdateRedPoints(xplayerLevelChangedEventArgs.level);
			return true;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.Handler != null && this.Handler.IsVisible();
			if (flag)
			{
				this.Handler.RefreshData();
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CharacterEquipDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static RandomAttributes m_randomAttributesTab = new RandomAttributes();

		private static XEquipSuitManager _SuitManager;

		private static RandomAttrDataMgr _randomAttrMgr;

		private static CharacterAttributesList m_AttributeTable = new CharacterAttributesList();

		private CharacterEquipBagHandler _handler = null;

		private bool _bCanBePowerful = false;

		private bool _bShouldUpdateRedPoints = false;

		private bool _bShouldCalcMorePowerfulTip = false;

		private bool _bShouldUpdateOutlook = false;

		private XNewItemTipsMgr _NewItems = new XNewItemTipsMgr();

		private XItemRequiredCollector m_ItemRequiredCollector = new XItemRequiredCollector();

		private List<XItem> m_ItemList = new List<XItem>();
	}
}
