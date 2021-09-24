using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDeck
	{

		private XCardCollectDocument cardDoc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XCardCollectDocument>(XCardCollectDocument.uuID);
			}
		}

		public List<XDeck.Attribute> AttrBase
		{
			get
			{
				return this._AttrBase;
			}
		}

		public List<XDeck.Attribute> AttrPer
		{
			get
			{
				return this._AttrPer;
			}
		}

		public List<XDeck.Attribute> AttrSum
		{
			get
			{
				return this._AttrSum;
			}
		}

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

		public XCardCombination GetShowCardsGroupInfo(int index)
		{
			bool isDeckDirty = this.IsDeckDirty;
			if (isDeckDirty)
			{
				this.RefreshCardsGroup();
			}
			return this._ShowCardsGroupInfo[index];
		}

		public static readonly uint DECK_PER_REWARD_COUNT_MAX = 6U;

		public static readonly uint GROUP_NEED_CARD_MAX = 6U;

		public string Name;

		public int ActionNum;

		public bool IsDeckDirty;

		public XBetterDictionary<uint, XCardCombination> combDic = new XBetterDictionary<uint, XCardCombination>(0);

		private List<XCardCombination> _ShowCardsGroupInfo = new List<XCardCombination>();

		private List<XDeck.Attribute> _AttrBase = new List<XDeck.Attribute>();

		private List<XDeck.Attribute> _AttrPer = new List<XDeck.Attribute>();

		private List<XDeck.Attribute> _AttrSum = new List<XDeck.Attribute>();

		public List<List<CardsFireProperty.RowData>> ActionNumReward = new List<List<CardsFireProperty.RowData>>();

		public List<CardsList.RowData> CardList = new List<CardsList.RowData>();

		public int StarLevelMAX = 0;

		private int m_CurStarLevel;

		public bool redPoint;

		public struct Attribute
		{

			public uint id;

			public uint num;
		}
	}
}
