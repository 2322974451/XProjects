using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000974 RID: 2420
	internal class XCardCollectDocument : XDocComponent
	{
		// Token: 0x17002C71 RID: 11377
		// (get) Token: 0x060091B7 RID: 37303 RVA: 0x0014E788 File Offset: 0x0014C988
		public override uint ID
		{
			get
			{
				return XCardCollectDocument.uuID;
			}
		}

		// Token: 0x17002C72 RID: 11378
		// (get) Token: 0x060091B8 RID: 37304 RVA: 0x0014E7A0 File Offset: 0x0014C9A0
		// (set) Token: 0x060091B9 RID: 37305 RVA: 0x0014E7B8 File Offset: 0x0014C9B8
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

		// Token: 0x17002C73 RID: 11379
		// (get) Token: 0x060091BA RID: 37306 RVA: 0x0014E7C4 File Offset: 0x0014C9C4
		public XBetterDictionary<int, XItem> HasCardList
		{
			get
			{
				return this.m_HasCardList;
			}
		}

		// Token: 0x17002C74 RID: 11380
		// (get) Token: 0x060091BB RID: 37307 RVA: 0x0014E7DC File Offset: 0x0014C9DC
		public List<XDeck> CardsGroupInfo
		{
			get
			{
				return XCardCollectDocument._CardsGroupInfo;
			}
		}

		// Token: 0x17002C75 RID: 11381
		// (get) Token: 0x060091BC RID: 37308 RVA: 0x0014E7F4 File Offset: 0x0014C9F4
		public XBetterDictionary<uint, uint> AttrSum
		{
			get
			{
				return this.m_AttrSum;
			}
		}

		// Token: 0x17002C76 RID: 11382
		// (get) Token: 0x060091BD RID: 37309 RVA: 0x0014E80C File Offset: 0x0014CA0C
		public int CurSelectGroup
		{
			get
			{
				return (int)this.m_CurSelectGroup;
			}
		}

		// Token: 0x17002C77 RID: 11383
		// (get) Token: 0x060091BE RID: 37310 RVA: 0x0014E824 File Offset: 0x0014CA24
		public XDeck CurDeck
		{
			get
			{
				return this.CardsGroupInfo[this.CurSelectGroup];
			}
		}

		// Token: 0x17002C78 RID: 11384
		// (get) Token: 0x060091BF RID: 37311 RVA: 0x0014E848 File Offset: 0x0014CA48
		public uint CurOpenGroup
		{
			get
			{
				return this.m_CurOpenGroup;
			}
		}

		// Token: 0x17002C79 RID: 11385
		// (get) Token: 0x060091C0 RID: 37312 RVA: 0x0014E860 File Offset: 0x0014CA60
		public uint CurShowGroup
		{
			get
			{
				return this.m_CurShowGroup;
			}
		}

		// Token: 0x17002C7A RID: 11386
		// (get) Token: 0x060091C1 RID: 37313 RVA: 0x0014E878 File Offset: 0x0014CA78
		public static int GroupMax
		{
			get
			{
				return XCardCollectDocument._CardsGroupListTable.Table.Length;
			}
		}

		// Token: 0x060091C2 RID: 37314 RVA: 0x0014E896 File Offset: 0x0014CA96
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.m_Filter.Clear();
			this.m_Filter.AddItemType(ItemType.CARD);
		}

		// Token: 0x060091C3 RID: 37315 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnEnterSceneFinally()
		{
		}

		// Token: 0x060091C4 RID: 37316 RVA: 0x0013A712 File Offset: 0x00138912
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		// Token: 0x060091C5 RID: 37317 RVA: 0x0014E8BC File Offset: 0x0014CABC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.InitCardData(arg.PlayerInfo.atlas);
			bool flag = DlgBase<CardCollectView, CardCollectBehaviour>.singleton.IsVisible() && DlgBase<CardCollectView, CardCollectBehaviour>.singleton.CurPage == CardPage.Deck;
			if (flag)
			{
				DlgBase<CardCollectView, CardCollectBehaviour>.singleton.RefreshShowDeck(false);
			}
		}

		// Token: 0x060091C6 RID: 37318 RVA: 0x0014E908 File Offset: 0x0014CB08
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemNumChanged, new XComponent.XEventHandler(this.OnItemNumChanged));
		}

		// Token: 0x060091C7 RID: 37319 RVA: 0x0014E95C File Offset: 0x0014CB5C
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

		// Token: 0x060091C8 RID: 37320 RVA: 0x0014EAF4 File Offset: 0x0014CCF4
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

		// Token: 0x060091C9 RID: 37321 RVA: 0x0014EC78 File Offset: 0x0014CE78
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

		// Token: 0x060091CA RID: 37322 RVA: 0x0014EDD0 File Offset: 0x0014CFD0
		public static void Execute(OnLoadedCallback callback = null)
		{
			XCardCollectDocument.AsyncLoader.AddTask("Table/CardsFireProperty", XCardCollectDocument._CardsFirePropertyTable, false);
			XCardCollectDocument.AsyncLoader.AddTask("Table/CardsGroup", XCardCollectDocument._CardsGroupTable, false);
			XCardCollectDocument.AsyncLoader.AddTask("Table/CardsGroupList", XCardCollectDocument._CardsGroupListTable, false);
			XCardCollectDocument.AsyncLoader.AddTask("Table/CardsList", XCardCollectDocument._CardsListTable, false);
			XCardCollectDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060091CB RID: 37323 RVA: 0x0014EE44 File Offset: 0x0014D044
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

		// Token: 0x060091CC RID: 37324 RVA: 0x0014F088 File Offset: 0x0014D288
		public static CardsGroup.RowData GetCardsGroup(uint teamId)
		{
			return XCardCollectDocument._CardsGroupTable.GetByTeamId(teamId);
		}

		// Token: 0x060091CD RID: 37325 RVA: 0x0014F0A8 File Offset: 0x0014D2A8
		public static CardsList.RowData GetCards(uint cardId)
		{
			return XCardCollectDocument._CardsListTable.GetByCardId(cardId);
		}

		// Token: 0x060091CE RID: 37326 RVA: 0x0014F0C8 File Offset: 0x0014D2C8
		public static CardsGroupList.RowData GetCardGroup(uint groupId)
		{
			return XCardCollectDocument._CardsGroupListTable.GetByGroupId(groupId);
		}

		// Token: 0x060091CF RID: 37327 RVA: 0x0014F0E8 File Offset: 0x0014D2E8
		public static CardsList.RowData[] GetCards()
		{
			return XCardCollectDocument._CardsListTable.Table;
		}

		// Token: 0x060091D0 RID: 37328 RVA: 0x0014F104 File Offset: 0x0014D304
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

		// Token: 0x060091D1 RID: 37329 RVA: 0x0014F194 File Offset: 0x0014D394
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

		// Token: 0x060091D2 RID: 37330 RVA: 0x0014F2DC File Offset: 0x0014D4DC
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

		// Token: 0x060091D3 RID: 37331 RVA: 0x0014F360 File Offset: 0x0014D560
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

		// Token: 0x060091D4 RID: 37332 RVA: 0x0014F3AC File Offset: 0x0014D5AC
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

		// Token: 0x060091D5 RID: 37333 RVA: 0x0014F3F4 File Offset: 0x0014D5F4
		public void OnRefreshAttr(PtcG2C_SynAtlasAttr roPtc)
		{
			this.m_AttrSum.Clear();
			for (int i = 0; i < roPtc.Data.allAttrs.Count; i++)
			{
				XCardCollectDocument._CardsGroupInfo[i + 1].RefreshAttr(roPtc.Data.allAttrs[i]);
			}
		}

		// Token: 0x060091D6 RID: 37334 RVA: 0x0014F454 File Offset: 0x0014D654
		public List<XItem> GetCard()
		{
			ulong filterValue = this.m_Filter.FilterValue;
			this.m_ItemList.Clear();
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(filterValue, ref this.m_ItemList);
			return this.m_ItemList;
		}

		// Token: 0x060091D7 RID: 37335 RVA: 0x0014F4A0 File Offset: 0x0014D6A0
		public void ReqActive(uint teamid)
		{
			RpcC2G_ActivatAtlas rpcC2G_ActivatAtlas = new RpcC2G_ActivatAtlas();
			rpcC2G_ActivatAtlas.oArg.teamid = teamid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ActivatAtlas);
		}

		// Token: 0x060091D8 RID: 37336 RVA: 0x0014F4D0 File Offset: 0x0014D6D0
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

		// Token: 0x060091D9 RID: 37337 RVA: 0x0014F5F0 File Offset: 0x0014D7F0
		public void ReqBreak(int itemID, int num)
		{
			RpcC2G_breakAtlas rpcC2G_breakAtlas = new RpcC2G_breakAtlas();
			rpcC2G_breakAtlas.oArg.atlaId = (uint)itemID;
			rpcC2G_breakAtlas.oArg.atlaNum = (uint)num;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_breakAtlas);
		}

		// Token: 0x060091DA RID: 37338 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void OnBreak(breakAtlas oArg, breakAtlasRes oRes)
		{
		}

		// Token: 0x060091DB RID: 37339 RVA: 0x0014F62C File Offset: 0x0014D82C
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

		// Token: 0x060091DC RID: 37340 RVA: 0x0014F690 File Offset: 0x0014D890
		public void OnAutoBreak(AutoBreakAtlasArg oArg, AutoBreakAtlasRes oRes)
		{
			bool flag = this.View != null && this.View.CurPage == CardPage.CardAll;
			if (flag)
			{
				this.View.TotalHandler.ShowHandler(false);
			}
		}

		// Token: 0x060091DD RID: 37341 RVA: 0x0014F6D0 File Offset: 0x0014D8D0
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

		// Token: 0x060091DE RID: 37342 RVA: 0x0014F710 File Offset: 0x0014D910
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

		// Token: 0x060091DF RID: 37343 RVA: 0x0014F770 File Offset: 0x0014D970
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

		// Token: 0x060091E0 RID: 37344 RVA: 0x0014F7B4 File Offset: 0x0014D9B4
		public void ReqUpStar()
		{
			RpcC2G_AtlasUpStar rpcC2G_AtlasUpStar = new RpcC2G_AtlasUpStar();
			rpcC2G_AtlasUpStar.oArg.groupid = (uint)this.CurSelectGroup;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_AtlasUpStar);
		}

		// Token: 0x060091E1 RID: 37345 RVA: 0x0014F7E8 File Offset: 0x0014D9E8
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

		// Token: 0x04003082 RID: 12418
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XCardCollectDocument");

		// Token: 0x04003083 RID: 12419
		private CardCollectView _view = null;

		// Token: 0x04003084 RID: 12420
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003085 RID: 12421
		private static CardsFireProperty _CardsFirePropertyTable = new CardsFireProperty();

		// Token: 0x04003086 RID: 12422
		private static CardsGroup _CardsGroupTable = new CardsGroup();

		// Token: 0x04003087 RID: 12423
		private static CardsGroupList _CardsGroupListTable = new CardsGroupList();

		// Token: 0x04003088 RID: 12424
		private static CardsList _CardsListTable = new CardsList();

		// Token: 0x04003089 RID: 12425
		private XBetterDictionary<int, XItem> m_HasCardList = new XBetterDictionary<int, XItem>(0);

		// Token: 0x0400308A RID: 12426
		public bool IsCardDirty;

		// Token: 0x0400308B RID: 12427
		private static List<XDeck> _CardsGroupInfo = new List<XDeck>();

		// Token: 0x0400308C RID: 12428
		private XBetterDictionary<uint, uint> m_AttrSum = new XBetterDictionary<uint, uint>(0);

		// Token: 0x0400308D RID: 12429
		private uint m_CurSelectGroup = 1U;

		// Token: 0x0400308E RID: 12430
		public uint m_CurOpenGroup;

		// Token: 0x0400308F RID: 12431
		public uint m_CurShowGroup;

		// Token: 0x04003090 RID: 12432
		private XItemFilter m_Filter = new XItemFilter();

		// Token: 0x04003091 RID: 12433
		private List<XItem> m_ItemList = new List<XItem>();

		// Token: 0x04003092 RID: 12434
		private Dictionary<uint, XItem> _CardList = new Dictionary<uint, XItem>();
	}
}
