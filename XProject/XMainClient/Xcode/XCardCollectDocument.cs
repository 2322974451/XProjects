using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCardCollectDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XCardCollectDocument.uuID;
			}
		}

		public CardCollectView View
		{
			get
			{
				return this._view;
			}
			set
			{
				this._view = value;
			}
		}

		public XBetterDictionary<int, XItem> HasCardList
		{
			get
			{
				return this.m_HasCardList;
			}
		}

		public List<XDeck> CardsGroupInfo
		{
			get
			{
				return XCardCollectDocument._CardsGroupInfo;
			}
		}

		public XBetterDictionary<uint, uint> AttrSum
		{
			get
			{
				return this.m_AttrSum;
			}
		}

		public int CurSelectGroup
		{
			get
			{
				return (int)this.m_CurSelectGroup;
			}
		}

		public XDeck CurDeck
		{
			get
			{
				return this.CardsGroupInfo[this.CurSelectGroup];
			}
		}

		public uint CurOpenGroup
		{
			get
			{
				return this.m_CurOpenGroup;
			}
		}

		public uint CurShowGroup
		{
			get
			{
				return this.m_CurShowGroup;
			}
		}

		public static int GroupMax
		{
			get
			{
				return XCardCollectDocument._CardsGroupListTable.Table.Length;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.m_Filter.Clear();
			this.m_Filter.AddItemType(ItemType.CARD);
		}

		public override void OnEnterSceneFinally()
		{
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.InitCardData(arg.PlayerInfo.atlas);
			bool flag = DlgBase<CardCollectView, CardCollectBehaviour>.singleton.IsVisible() && DlgBase<CardCollectView, CardCollectBehaviour>.singleton.CurPage == CardPage.Deck;
			if (flag)
			{
				DlgBase<CardCollectView, CardCollectBehaviour>.singleton.RefreshShowDeck(false);
			}
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemNumChanged, new XComponent.XEventHandler(this.OnItemNumChanged));
		}

		public bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			for (int i = 0; i < xaddItemEventArgs.items.Count; i++)
			{
				bool flag = xaddItemEventArgs.items[i].type == 19U;
				if (flag)
				{
					this.IsCardDirty = true;
					CardsList.RowData cards = XCardCollectDocument.GetCards((uint)xaddItemEventArgs.items[i].itemID);
					bool flag2 = cards == null;
					bool result;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("CardID:" + xaddItemEventArgs.items[i].itemID + " No Find", null, null, null, null, null);
						result = false;
					}
					else
					{
						int groupId = (int)cards.GroupId;
						bool flag3 = groupId >= XCardCollectDocument._CardsGroupInfo.Count;
						if (flag3)
						{
							XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
							{
								"CardID:",
								xaddItemEventArgs.items[i].itemID,
								"groupId:",
								cards.GroupId,
								" _CardsGroupInfo.Count:",
								XCardCollectDocument._CardsGroupInfo.Count
							}), null, null, null, null, null);
							result = false;
						}
						else
						{
							XCardCollectDocument._CardsGroupInfo[groupId].IsDeckDirty = true;
							XCardCollectDocument._CardsGroupInfo[groupId].RefreshRedPoint();
							bool flag4 = this.View != null;
							if (flag4)
							{
								this.View.RefreshDetail();
							}
							result = true;
						}
					}
					return result;
				}
			}
			return false;
		}

		public bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			for (int i = 0; i < xremoveItemEventArgs.types.Count; i++)
			{
				bool flag = xremoveItemEventArgs.types[i] == ItemType.CARD;
				if (flag)
				{
					this.IsCardDirty = true;
					CardsList.RowData cards = XCardCollectDocument.GetCards((uint)xremoveItemEventArgs.ids[i]);
					bool flag2 = cards == null;
					bool result;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("CardID:" + xremoveItemEventArgs.ids[i] + " No Find", null, null, null, null, null);
						result = false;
					}
					else
					{
						int groupId = (int)cards.GroupId;
						bool flag3 = groupId >= XCardCollectDocument._CardsGroupInfo.Count;
						if (flag3)
						{
							XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
							{
								"CardID:",
								xremoveItemEventArgs.ids[i],
								"groupId:",
								cards.GroupId,
								" _CardsGroupInfo.Count:",
								XCardCollectDocument._CardsGroupInfo.Count
							}), null, null, null, null, null);
							result = false;
						}
						else
						{
							XCardCollectDocument._CardsGroupInfo[groupId].IsDeckDirty = true;
							XCardCollectDocument._CardsGroupInfo[groupId].RefreshRedPoint();
							bool flag4 = this.View != null;
							if (flag4)
							{
								this.View.RefreshDetail();
							}
							result = true;
						}
					}
					return result;
				}
			}
			return false;
		}

		public bool OnItemNumChanged(XEventArgs args)
		{
			XItemNumChangedEventArgs xitemNumChangedEventArgs = args as XItemNumChangedEventArgs;
			bool flag = xitemNumChangedEventArgs.item.Type == ItemType.CARD;
			bool result;
			if (flag)
			{
				this.IsCardDirty = true;
				CardsList.RowData cards = XCardCollectDocument.GetCards((uint)xitemNumChangedEventArgs.item.itemID);
				bool flag2 = cards == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("CardID:" + xitemNumChangedEventArgs.item.itemID + " No Find", null, null, null, null, null);
					result = false;
				}
				else
				{
					int groupId = (int)cards.GroupId;
					bool flag3 = groupId >= XCardCollectDocument._CardsGroupInfo.Count;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
						{
							"CardID:",
							xitemNumChangedEventArgs.item.itemID,
							"groupId:",
							cards.GroupId,
							" _CardsGroupInfo.Count:",
							XCardCollectDocument._CardsGroupInfo.Count
						}), null, null, null, null, null);
						result = false;
					}
					else
					{
						XCardCollectDocument._CardsGroupInfo[groupId].IsDeckDirty = true;
						XCardCollectDocument._CardsGroupInfo[groupId].RefreshRedPoint();
						bool flag4 = this.View != null;
						if (flag4)
						{
							this.View.RefreshDetail();
						}
						result = true;
					}
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XCardCollectDocument.AsyncLoader.AddTask("Table/CardsFireProperty", XCardCollectDocument._CardsFirePropertyTable, false);
			XCardCollectDocument.AsyncLoader.AddTask("Table/CardsGroup", XCardCollectDocument._CardsGroupTable, false);
			XCardCollectDocument.AsyncLoader.AddTask("Table/CardsGroupList", XCardCollectDocument._CardsGroupListTable, false);
			XCardCollectDocument.AsyncLoader.AddTask("Table/CardsList", XCardCollectDocument._CardsListTable, false);
			XCardCollectDocument.AsyncLoader.Execute(callback);
		}

		public static void OnTableLoaded()
		{
			XCardCollectDocument._CardsGroupInfo.Clear();
			for (int i = 0; i <= XCardCollectDocument.GroupMax; i++)
			{
				bool flag = i == 0;
				if (flag)
				{
					XCardCollectDocument._CardsGroupInfo.Add(null);
				}
				else
				{
					XDeck xdeck = new XDeck();
					xdeck.StarLevelMAX = XCardCollectDocument._CardsGroupListTable.Table[i - 1].BreakLevel.Length;
					xdeck.Name = XCardCollectDocument._CardsGroupListTable.Table[i - 1].GroupName;
					for (int j = 0; j <= xdeck.StarLevelMAX; j++)
					{
						xdeck.ActionNumReward.Add(new List<CardsFireProperty.RowData>());
					}
					XCardCollectDocument._CardsGroupInfo.Add(xdeck);
				}
			}
			for (int k = 0; k < XCardCollectDocument._CardsGroupTable.Table.Length; k++)
			{
				XCardCombination xcardCombination = new XCardCombination();
				xcardCombination.status = CardCombinationStatus.None;
				xcardCombination.data = XCardCollectDocument._CardsGroupTable.Table[k];
				xcardCombination.InitStarPostion(xcardCombination.data);
				int groupId = (int)xcardCombination.data.GroupId;
				XCardCollectDocument._CardsGroupInfo[groupId].combDic.Add(xcardCombination.data.TeamId, xcardCombination);
			}
			for (int l = 0; l < XCardCollectDocument._CardsFirePropertyTable.Table.Length; l++)
			{
				CardsFireProperty.RowData rowData = XCardCollectDocument._CardsFirePropertyTable.Table[l];
				int groupId2 = (int)rowData.GroupId;
				int breakLevel = (int)rowData.BreakLevel;
				XCardCollectDocument._CardsGroupInfo[groupId2].ActionNumReward[breakLevel].Add(rowData);
			}
			for (int m = 0; m < XCardCollectDocument._CardsListTable.Table.Length; m++)
			{
				CardsList.RowData rowData2 = XCardCollectDocument._CardsListTable.Table[m];
				int groupId3 = (int)rowData2.GroupId;
				bool flag2 = groupId3 < 0 || groupId3 >= XCardCollectDocument._CardsGroupInfo.Count;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddLog(groupId3.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
				}
				XCardCollectDocument._CardsGroupInfo[groupId3].CardList.Add(rowData2);
			}
		}

		public static CardsGroup.RowData GetCardsGroup(uint teamId)
		{
			return XCardCollectDocument._CardsGroupTable.GetByTeamId(teamId);
		}

		public static CardsList.RowData GetCards(uint cardId)
		{
			return XCardCollectDocument._CardsListTable.GetByCardId(cardId);
		}

		public static CardsGroupList.RowData GetCardGroup(uint groupId)
		{
			return XCardCollectDocument._CardsGroupListTable.GetByGroupId(groupId);
		}

		public static CardsList.RowData[] GetCards()
		{
			return XCardCollectDocument._CardsListTable.Table;
		}

		public static SeqListRef<uint> GetCardGroupAttribute(uint teamId)
		{
			CardsGroup.RowData cardsGroup = XCardCollectDocument.GetCardsGroup(teamId);
			SeqListRef<uint> result = default(SeqListRef<uint>);
			uint key = (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession);
			AttackType attackType = (AttackType)XSingleton<XEntityMgr>.singleton.RoleInfo.GetByProfID(key).AttackType;
			AttackType attackType2 = attackType;
			if (attackType2 != AttackType.PhysicalAttack)
			{
				if (attackType2 != AttackType.MagicAttack)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("AttackType No Find", null, null, null, null, null);
				}
				else
				{
					result = cardsGroup.FireProperty_2;
				}
			}
			else
			{
				result = cardsGroup.FireProperty_1;
			}
			return result;
		}

		public void InitCardData(SAtlasRecord record)
		{
			for (int i = 1; i <= XCardCollectDocument.GroupMax; i++)
			{
				XCardCollectDocument._CardsGroupInfo[i].Init();
			}
			bool flag = record == null;
			if (!flag)
			{
				for (int j = 0; j < record.atlas.Count; j++)
				{
					uint teamId = record.atlas[j];
					CardsGroup.RowData cardsGroup = XCardCollectDocument.GetCardsGroup(teamId);
					uint groupId = cardsGroup.GroupId;
					XDeck xdeck = XCardCollectDocument._CardsGroupInfo[(int)groupId];
					XCardCombination xcardCombination = xdeck.FindCardCombination(teamId);
					xcardCombination.status = CardCombinationStatus.Activated;
					xdeck.ActionNum++;
				}
				for (int k = 0; k < record.finishdata.Count; k++)
				{
					XDeck xdeck2 = XCardCollectDocument._CardsGroupInfo[(int)record.finishdata[k].groupid];
					xdeck2.CurStarLevel = (int)record.finishdata[k].finishid;
				}
				this.IsCardDirty = true;
				for (int l = 1; l <= XCardCollectDocument.GroupMax; l++)
				{
					XCardCollectDocument._CardsGroupInfo[l].RefreshRedPoint();
				}
			}
		}

		public void RefreshCardGroupListShow()
		{
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			for (int i = 0; i < XCardCollectDocument.GroupMax; i++)
			{
				CardsGroupList.RowData rowData = XCardCollectDocument._CardsGroupListTable.Table[i];
				bool flag = rowData.ShowLevel <= level;
				if (flag)
				{
					this.m_CurShowGroup = rowData.GroupId;
				}
				bool flag2 = rowData.OpenLevel <= level;
				if (flag2)
				{
					this.m_CurOpenGroup = rowData.GroupId;
				}
			}
		}

		public void Select(uint index)
		{
			bool flag = index > 0U || (ulong)index <= (ulong)((long)XCardCollectDocument.GroupMax);
			if (flag)
			{
				this.m_CurSelectGroup = index;
			}
			bool flag2 = DlgBase<CardCollectView, CardCollectBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				this.View.RefreshShowDeck(false);
			}
		}

		public void AddAttribute(uint id, uint addVal)
		{
			uint num;
			bool flag = !this.m_AttrSum.TryGetValue(id, out num);
			if (flag)
			{
				this.m_AttrSum.Add(id, addVal);
			}
			else
			{
				this.m_AttrSum[id] = num + addVal;
			}
		}

		public void OnRefreshAttr(PtcG2C_SynAtlasAttr roPtc)
		{
			this.m_AttrSum.Clear();
			for (int i = 0; i < roPtc.Data.allAttrs.Count; i++)
			{
				XCardCollectDocument._CardsGroupInfo[i + 1].RefreshAttr(roPtc.Data.allAttrs[i]);
			}
		}

		public List<XItem> GetCard()
		{
			ulong filterValue = this.m_Filter.FilterValue;
			this.m_ItemList.Clear();
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(filterValue, ref this.m_ItemList);
			return this.m_ItemList;
		}

		public void ReqActive(uint teamid)
		{
			RpcC2G_ActivatAtlas rpcC2G_ActivatAtlas = new RpcC2G_ActivatAtlas();
			rpcC2G_ActivatAtlas.oArg.teamid = teamid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ActivatAtlas);
		}

		public void OnActive(ActivatAtlasArg oArg, ActivatAtlasRes oRes)
		{
			CardsGroup.RowData cardsGroup = XCardCollectDocument.GetCardsGroup(oArg.teamid);
			XDeck xdeck = XCardCollectDocument._CardsGroupInfo[(int)cardsGroup.GroupId];
			XCardCombination xcardCombination = null;
			xdeck.combDic.TryGetValue(oArg.teamid, out xcardCombination);
			xcardCombination.status = CardCombinationStatus.Activated;
			xdeck.ActionNum++;
			xdeck.IsDeckDirty = true;
			XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("CARD_ACTIVE_OK"), xcardCombination.data.TeamName), "fece00");
			bool flag = this.View != null;
			if (flag)
			{
				this.View.RefreshShowDeck(false);
			}
			for (int i = 0; i < xdeck.ActionNumReward[xdeck.CurStarLevel].Count; i++)
			{
				bool flag2 = (ulong)xdeck.ActionNumReward[xdeck.CurStarLevel][i].FireCounts == (ulong)((long)xdeck.ActionNum);
				if (flag2)
				{
					bool flag3 = this.View != null;
					if (flag3)
					{
						this.View.ShowGetReward(i);
					}
				}
			}
		}

		public void ReqBreak(int itemID, int num)
		{
			RpcC2G_breakAtlas rpcC2G_breakAtlas = new RpcC2G_breakAtlas();
			rpcC2G_breakAtlas.oArg.atlaId = (uint)itemID;
			rpcC2G_breakAtlas.oArg.atlaNum = (uint)num;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_breakAtlas);
		}

		public void OnBreak(breakAtlas oArg, breakAtlasRes oRes)
		{
		}

		public void ReqAutoBreak(List<uint> quality)
		{
			RpcC2G_AutoBreakAtlas rpcC2G_AutoBreakAtlas = new RpcC2G_AutoBreakAtlas();
			for (int i = 0; i < quality.Count; i++)
			{
				rpcC2G_AutoBreakAtlas.oArg.quilts.Add(quality[i]);
			}
			rpcC2G_AutoBreakAtlas.oArg.groupId = (uint)this.CurSelectGroup;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_AutoBreakAtlas);
		}

		public void OnAutoBreak(AutoBreakAtlasArg oArg, AutoBreakAtlasRes oRes)
		{
			bool flag = this.View != null && this.View.CurPage == CardPage.CardAll;
			if (flag)
			{
				this.View.TotalHandler.ShowHandler(false);
			}
		}

		public int GetCardCount(int itemID)
		{
			bool isCardDirty = this.IsCardDirty;
			if (isCardDirty)
			{
				this.RefreshCardList();
			}
			XItem xitem;
			this.m_HasCardList.TryGetValue(itemID, out xitem);
			return (xitem == null) ? 0 : xitem.itemCount;
		}

		public void RefreshCardList()
		{
			this.IsCardDirty = false;
			this.m_HasCardList.Clear();
			List<XItem> card = this.GetCard();
			for (int i = 0; i < card.Count; i++)
			{
				this.m_HasCardList.Add(card[i].itemID, card[i]);
			}
		}

		public bool GetRedPoint()
		{
			for (int i = 1; i <= XCardCollectDocument.GroupMax; i++)
			{
				bool redPoint = XCardCollectDocument._CardsGroupInfo[i].redPoint;
				if (redPoint)
				{
					return true;
				}
			}
			return false;
		}

		public void ReqUpStar()
		{
			RpcC2G_AtlasUpStar rpcC2G_AtlasUpStar = new RpcC2G_AtlasUpStar();
			rpcC2G_AtlasUpStar.oArg.groupid = (uint)this.CurSelectGroup;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_AtlasUpStar);
		}

		public void ChangeStar(int star, int groupid = 0)
		{
			bool flag = groupid == 0;
			if (flag)
			{
				groupid = this.CurSelectGroup;
			}
			XCardCollectDocument._CardsGroupInfo[groupid].Init();
			XCardCollectDocument._CardsGroupInfo[groupid].CurStarLevel = star;
			bool flag2 = this.View != null;
			if (flag2)
			{
				this.View.RefreshShowDeck(false);
			}
			DlgBase<CardCollectView, CardCollectBehaviour>.singleton.PlayLevelUpFx();
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XCardCollectDocument");

		private CardCollectView _view = null;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static CardsFireProperty _CardsFirePropertyTable = new CardsFireProperty();

		private static CardsGroup _CardsGroupTable = new CardsGroup();

		private static CardsGroupList _CardsGroupListTable = new CardsGroupList();

		private static CardsList _CardsListTable = new CardsList();

		private XBetterDictionary<int, XItem> m_HasCardList = new XBetterDictionary<int, XItem>(0);

		public bool IsCardDirty;

		private static List<XDeck> _CardsGroupInfo = new List<XDeck>();

		private XBetterDictionary<uint, uint> m_AttrSum = new XBetterDictionary<uint, uint>(0);

		private uint m_CurSelectGroup = 1U;

		public uint m_CurOpenGroup;

		public uint m_CurShowGroup;

		private XItemFilter m_Filter = new XItemFilter();

		private List<XItem> m_ItemList = new List<XItem>();

		private Dictionary<uint, XItem> _CardList = new Dictionary<uint, XItem>();
	}
}
