using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000975 RID: 2421
	internal class XDeck
	{
		// Token: 0x17002C7B RID: 11387
		// (get) Token: 0x060091E4 RID: 37348 RVA: 0x0014F90C File Offset: 0x0014DB0C
		private XCardCollectDocument cardDoc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XCardCollectDocument>(XCardCollectDocument.uuID);
			}
		}

		// Token: 0x17002C7C RID: 11388
		// (get) Token: 0x060091E5 RID: 37349 RVA: 0x0014F928 File Offset: 0x0014DB28
		public List<XDeck.Attribute> AttrBase
		{
			get
			{
				return this._AttrBase;
			}
		}

		// Token: 0x17002C7D RID: 11389
		// (get) Token: 0x060091E6 RID: 37350 RVA: 0x0014F940 File Offset: 0x0014DB40
		public List<XDeck.Attribute> AttrPer
		{
			get
			{
				return this._AttrPer;
			}
		}

		// Token: 0x17002C7E RID: 11390
		// (get) Token: 0x060091E7 RID: 37351 RVA: 0x0014F958 File Offset: 0x0014DB58
		public List<XDeck.Attribute> AttrSum
		{
			get
			{
				return this._AttrSum;
			}
		}

		// Token: 0x17002C7F RID: 11391
		// (get) Token: 0x060091E8 RID: 37352 RVA: 0x0014F970 File Offset: 0x0014DB70
		// (set) Token: 0x060091E9 RID: 37353 RVA: 0x0014F988 File Offset: 0x0014DB88
		public int CurStarLevel
		{
			get
			{
				return this.m_CurStarLevel;
			}
			set
			{
				bool flag = value > this.StarLevelMAX;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
					{
						"CardGroupID ",
						this.cardDoc.CurSelectGroup,
						" Star Error!\nStar:",
						value,
						" StarMAX:",
						this.StarLevelMAX
					}), null, null, null, null, null);
				}
				this.m_CurStarLevel = value;
			}
		}

		// Token: 0x060091EB RID: 37355 RVA: 0x0014FA78 File Offset: 0x0014DC78
		public void Init()
		{
			this.IsDeckDirty = true;
			this.ActionNum = 0;
			this.m_CurStarLevel = 0;
			for (int i = 0; i < this.combDic.BufferValues.Count; i++)
			{
				XCardCombination xcardCombination = this.combDic.BufferValues[i];
				xcardCombination.status = CardCombinationStatus.None;
			}
			this._AttrBase.Clear();
			this._AttrPer.Clear();
			this._AttrSum.Clear();
			this.redPoint = false;
		}

		// Token: 0x060091EC RID: 37356 RVA: 0x0014FB00 File Offset: 0x0014DD00
		public XCardCombination FindCardCombination(uint teamId)
		{
			XCardCombination result;
			bool flag = !this.combDic.TryGetValue(teamId, out result);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Card TeamId No Find! CardTeamId: " + teamId, null, null, null, null, null);
			}
			return result;
		}

		// Token: 0x060091ED RID: 37357 RVA: 0x0014FB4C File Offset: 0x0014DD4C
		public void RefreshRedPoint()
		{
			this.redPoint = false;
			for (int i = 0; i < this.combDic.BufferValues.Count; i++)
			{
				bool flag = this.combDic.BufferValues[i].status == CardCombinationStatus.Activated;
				if (!flag)
				{
					XCardCombination xcardCombination = this.combDic.BufferValues[i];
					bool flag2 = true;
					int curStarLevel = this.CurStarLevel;
					bool flag3 = curStarLevel >= xcardCombination.starPostion.Count;
					if (flag3)
					{
						xcardCombination.status = CardCombinationStatus.NoCanActive;
					}
					else
					{
						int num = xcardCombination.starPostion[curStarLevel];
						int num2 = 0;
						while ((long)num2 < (long)((ulong)xcardCombination.data.StarFireCondition[num, 0]))
						{
							int itemID = (int)xcardCombination.data.StarFireCondition[num + num2 + 1, 0];
							bool flag4 = (long)this.cardDoc.GetCardCount(itemID) < (long)((ulong)xcardCombination.data.StarFireCondition[num + num2 + 1, 1]);
							if (flag4)
							{
								flag2 = false;
								break;
							}
							num2++;
						}
						bool flag5 = flag2;
						if (flag5)
						{
							xcardCombination.status = CardCombinationStatus.CanActive;
							this.redPoint = true;
						}
						else
						{
							xcardCombination.status = CardCombinationStatus.NoCanActive;
						}
					}
				}
			}
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_CardCollect, true);
		}

		// Token: 0x060091EE RID: 37358 RVA: 0x0014FCA8 File Offset: 0x0014DEA8
		private void RefreshCardsGroup()
		{
			this.RefreshRedPoint();
			this._ShowCardsGroupInfo.Clear();
			for (int i = 0; i < this.combDic.BufferValues.Count; i++)
			{
				bool flag = this.combDic.BufferValues[i].status == CardCombinationStatus.CanActive;
				if (flag)
				{
					this._ShowCardsGroupInfo.Add(this.combDic.BufferValues[i]);
				}
			}
			for (int j = 0; j < this.combDic.BufferValues.Count; j++)
			{
				bool flag2 = this.combDic.BufferValues[j].status == CardCombinationStatus.NoCanActive;
				if (flag2)
				{
					this._ShowCardsGroupInfo.Add(this.combDic.BufferValues[j]);
				}
			}
			for (int k = 0; k < this.combDic.BufferValues.Count; k++)
			{
				bool flag3 = this.combDic.BufferValues[k].status == CardCombinationStatus.Activated;
				if (flag3)
				{
					this._ShowCardsGroupInfo.Add(this.combDic.BufferValues[k]);
				}
			}
			this.IsDeckDirty = false;
		}

		// Token: 0x060091EF RID: 37359 RVA: 0x0014FDF8 File Offset: 0x0014DFF8
		public void RefreshAttr(SynCardAttr data)
		{
			this._AttrBase.Clear();
			this._AttrPer.Clear();
			this._AttrSum.Clear();
			for (int i = 0; i < data.addAttr.Count; i++)
			{
				XDeck.Attribute item = default(XDeck.Attribute);
				item.id = data.addAttr[i].id;
				item.num = data.addAttr[i].num;
				this._AttrBase.Add(item);
			}
			for (int j = 0; j < data.addper.Count; j++)
			{
				XDeck.Attribute item2 = default(XDeck.Attribute);
				item2.id = data.addper[j].id;
				item2.num = data.addper[j].num;
				this._AttrPer.Add(item2);
			}
			for (int k = 0; k < data.allAttr.Count; k++)
			{
				XDeck.Attribute attribute = default(XDeck.Attribute);
				attribute.id = data.allAttr[k].id;
				attribute.num = data.allAttr[k].num;
				this.cardDoc.AddAttribute(attribute.id, attribute.num);
				this._AttrSum.Add(attribute);
			}
		}

		// Token: 0x060091F0 RID: 37360 RVA: 0x0014FF74 File Offset: 0x0014E174
		public XCardCombination GetShowCardsGroupInfo(int index)
		{
			bool isDeckDirty = this.IsDeckDirty;
			if (isDeckDirty)
			{
				this.RefreshCardsGroup();
			}
			return this._ShowCardsGroupInfo[index];
		}

		// Token: 0x04003093 RID: 12435
		public static readonly uint DECK_PER_REWARD_COUNT_MAX = 6U;

		// Token: 0x04003094 RID: 12436
		public static readonly uint GROUP_NEED_CARD_MAX = 6U;

		// Token: 0x04003095 RID: 12437
		public string Name;

		// Token: 0x04003096 RID: 12438
		public int ActionNum;

		// Token: 0x04003097 RID: 12439
		public bool IsDeckDirty;

		// Token: 0x04003098 RID: 12440
		public XBetterDictionary<uint, XCardCombination> combDic = new XBetterDictionary<uint, XCardCombination>(0);

		// Token: 0x04003099 RID: 12441
		private List<XCardCombination> _ShowCardsGroupInfo = new List<XCardCombination>();

		// Token: 0x0400309A RID: 12442
		private List<XDeck.Attribute> _AttrBase = new List<XDeck.Attribute>();

		// Token: 0x0400309B RID: 12443
		private List<XDeck.Attribute> _AttrPer = new List<XDeck.Attribute>();

		// Token: 0x0400309C RID: 12444
		private List<XDeck.Attribute> _AttrSum = new List<XDeck.Attribute>();

		// Token: 0x0400309D RID: 12445
		public List<List<CardsFireProperty.RowData>> ActionNumReward = new List<List<CardsFireProperty.RowData>>();

		// Token: 0x0400309E RID: 12446
		public List<CardsList.RowData> CardList = new List<CardsList.RowData>();

		// Token: 0x0400309F RID: 12447
		public int StarLevelMAX = 0;

		// Token: 0x040030A0 RID: 12448
		private int m_CurStarLevel;

		// Token: 0x040030A1 RID: 12449
		public bool redPoint;

		// Token: 0x02001966 RID: 6502
		public struct Attribute
		{
			// Token: 0x04007E10 RID: 32272
			public uint id;

			// Token: 0x04007E11 RID: 32273
			public uint num;
		}
	}
}
