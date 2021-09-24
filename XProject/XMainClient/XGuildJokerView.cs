using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildJokerView : XGuildJokerCommonView<XGuildJokerView>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildSystem/GuildJokerDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XGuildJokerDocument>(XGuildJokerDocument.uuID);
			this.m_ScrollView = (base.uiBehaviour.transform.FindChild("Bg/Ranking/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.uiBehaviour.transform.FindChild("Bg/Ranking/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnRankWrapItemUpdate));
			this.m_TeamCheck = (base.uiBehaviour.transform.FindChild("Bg/Ranking/Team").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_GuildCheck = (base.uiBehaviour.transform.FindChild("Bg/Ranking/Guild").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_RuleTip = (base.uiBehaviour.transform.FindChild("Bg/Rule/Bg/RuleTip").GetComponent("XUILabel") as IXUILabel);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.WaitRpc = false;
			this._doc.CardStore = 5U;
			this.m_TeamCheck.bChecked = true;
			this._doc.QueryGameCount();
			this.RefreshRank();
			this.m_RuleTip.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("GUILD_JOKER_RULE_TIP")));
			this.WhenReturnShow();
		}

		protected override void OnHide()
		{
			bool flag = this._doc != null;
			if (flag)
			{
				this._doc.CurrentCard.Clear();
				this._doc.WaitRpc = false;
			}
			base.OnHide();
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		private void WhenReturnShow()
		{
			bool flag = this._doc.CurrentCard.Count == 0;
			if (flag)
			{
				base.SetButtonTip("START_GAME");
			}
			else
			{
				bool flag2 = this.CardResult != 8U;
				if (flag2)
				{
					base.SetButtonTip("GET_REWARD");
				}
				else
				{
					base.SetButtonTip("END_GAME");
				}
			}
			base.SetCardStore();
			base.RefreshCard();
			this.SetGameCount();
			base.SetGameTipStatus(true);
			this.SetCurrentReward();
		}

		protected override SeqListRef<uint> GetCardReward(int index)
		{
			return XGuildJokerDocument._CardRewardTable.Table[index].reward;
		}

		public void SetRankData(int length)
		{
			this.m_WrapContent.SetContentCount(length, false);
			this.m_ScrollView.ResetPosition();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_TeamCheck.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.TeamCheckHandler));
			this.m_GuildCheck.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.GuildCheckHandler));
		}

		private bool TeamCheckHandler(IXUICheckBox check)
		{
			this.m_WrapContent.SetContentCount(0, false);
			bool flag = !check.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.m_CurrType = XGuildJokerView.TabType.Team;
				this._doc.SendJokerRank(0U);
				result = true;
			}
			return result;
		}

		private bool GuildCheckHandler(IXUICheckBox check)
		{
			this.m_WrapContent.SetContentCount(0, false);
			bool flag = !check.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.m_CurrType = XGuildJokerView.TabType.Guild;
				this._doc.SendJokerRank(1U);
				result = true;
			}
			return result;
		}

		private void OnRankWrapItemUpdate(Transform t, int index)
		{
			IXUILabelSymbol ixuilabelSymbol = t.FindChild("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel = t.FindChild("Score").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = t.FindChild("IndexSprite").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel2 = t.FindChild("IndexLabel").GetComponent("XUILabel") as IXUILabel;
			bool flag = index < 3;
			if (flag)
			{
				ixuilabel2.Alpha = 0f;
				ixuisprite.SetAlpha(1f);
				ixuisprite.SetSprite(string.Format("N{0}", index + 1));
			}
			else
			{
				ixuilabel2.Alpha = 1f;
				ixuisprite.SetAlpha(0f);
				ixuilabel2.SetText((index + 1).ToString());
			}
			ixuilabel.SetText((index < this._doc.RankScores.Count) ? this._doc.RankScores[index].ToString() : "0");
			ixuilabelSymbol.InputText = ((index < this._doc.RankNames.Count) ? this._doc.RankNames[index].ToString() : string.Empty);
		}

		private bool OnBuyChangeCount(IXUIButton button)
		{
			this._doc.SendChangeCard(base.CardReAnalyze(this._currentChangeCard));
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		protected override bool OnStartGameClicked(IXUIButton button)
		{
			bool flag = this._changeCardLock || this._cardLock;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this._doc.CurrentCard.Count == 0;
				if (flag2)
				{
					this._doc.SendStartGame();
				}
				else
				{
					this._doc.SendGameEnd();
				}
				result = true;
			}
			return result;
		}

		public void RefreshRank()
		{
			bool flag = this.m_CurrType == XGuildJokerView.TabType.Team;
			if (flag)
			{
				this._doc.SendJokerRank(0U);
			}
			bool flag2 = this.m_CurrType == XGuildJokerView.TabType.Guild;
			if (flag2)
			{
				this._doc.SendJokerRank(1U);
			}
		}

		protected override bool OnEndGameClicked(IXUIButton button)
		{
			this._doc.SendGameEnd();
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this.SetVisible(false, true);
			return true;
		}

		protected override bool OnCloseClick(IXUIButton button)
		{
			bool flag = this._doc.CurrentCard.Count != 0;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("LEAVE_JOKER_CARD_GAME"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnEndGameClicked));
			}
			else
			{
				this.SetVisible(false, true);
			}
			return true;
		}

		public void SetGameCount()
		{
			base.uiBehaviour.m_GameCount.SetText(this._doc.GameCount.ToString());
			base.uiBehaviour.m_ChangeCount.SetText(this._doc.ChangeCount.ToString());
		}

		protected override string BestName
		{
			get
			{
				return this._doc.BestName;
			}
		}

		protected override int CurrentCardCount
		{
			get
			{
				return this._doc.CurrentCard.Count;
			}
		}

		protected override List<uint> CurrentCard
		{
			get
			{
				return this._doc.CurrentCard;
			}
		}

		protected override uint CardResult
		{
			get
			{
				return this._doc.CardResult;
			}
		}

		protected override int CurrentStore
		{
			get
			{
				return (int)this._doc.CardStore;
			}
		}

		protected override List<uint> BestCard
		{
			get
			{
				return this._doc.BestCard;
			}
		}

		protected override void OnCardClick(IXUISprite sp)
		{
			bool flag = this._changeCardLock || this._cardLock;
			if (!flag)
			{
				bool flag2 = false;
				for (int i = 0; i < this._doc.CurrentCard.Count; i++)
				{
					bool flag3 = this._doc.CurrentCard[i] == base.CardReAnalyze((uint)sp.ID);
					if (flag3)
					{
						flag2 = true;
					}
				}
				bool flag4 = !flag2;
				if (!flag4)
				{
					bool flag5 = this._doc.ChangeCount == 0;
					if (flag5)
					{
						CostInfo costInfo = XSingleton<XTakeCostMgr>.singleton.QueryCost("BuyCardChangeCost", this._doc.BuyChangeCount);
						this._currentChangeCard = (uint)sp.ID;
						XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("CHANGE_CARD_COST", new object[]
						{
							XLabelSymbolHelper.FormatCostWithIcon((int)costInfo.count, ItemEnum.DRAGON_COIN),
							costInfo.count + 1U
						}), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnBuyChangeCount));
					}
					else
					{
						this._doc.SendChangeCard(base.CardReAnalyze((uint)sp.ID));
					}
				}
			}
		}

		public override void SetCurrentReward()
		{
			string text = string.Format("{0}:", XStringDefineProxy.GetString("CURRENT_REWARD"));
			bool flag = this._doc.CurrentCard.Count == 0;
			if (flag)
			{
				base.SetCurrentRewardStr(text);
			}
			else
			{
				bool flag2 = (ulong)this._doc.CardResult >= (ulong)((long)XGuildJokerDocument._CardRewardTable.Table.Length);
				if (flag2)
				{
					text = string.Format("{0} {1}", text, XStringDefineProxy.GetString("NONE"));
					DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetButtonTip("END_GAME");
				}
				else
				{
					for (int i = 0; i < XGuildJokerDocument._CardRewardTable.Table[(int)this._doc.CardResult].reward.Count; i++)
					{
						text = string.Format("{0} {1}{2}", text, XLabelSymbolHelper.FormatSmallIcon((int)XGuildJokerDocument._CardRewardTable.Table[(int)this._doc.CardResult].reward[i, 0]), XGuildJokerDocument._CardRewardTable.Table[(int)this._doc.CardResult].reward[i, 1]);
					}
					DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetButtonTip("GET_REWARD");
					List<string> stringList = XSingleton<XGlobalConfig>.singleton.GetStringList("CardPointIcon");
					text = string.Format("{0} {1}{2}", text, XLabelSymbolHelper.FormatImage(stringList[0], stringList[1]), XGuildJokerDocument._CardRewardTable.Table[(int)this._doc.CardResult].point);
				}
				base.SetCurrentRewardStr(text);
				base.RefreshCardSelect();
			}
		}

		private XGuildJokerDocument _doc = null;

		private IXUIScrollView m_ScrollView;

		private IXUIWrapContent m_WrapContent;

		private IXUICheckBox m_TeamCheck;

		private IXUICheckBox m_GuildCheck;

		private XGuildJokerView.TabType m_CurrType = XGuildJokerView.TabType.Team;

		private IXUILabel m_RuleTip;

		public enum TabType
		{

			Team,

			Guild
		}
	}
}
