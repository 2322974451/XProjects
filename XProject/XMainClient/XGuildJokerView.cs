using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E43 RID: 3651
	internal class XGuildJokerView : XGuildJokerCommonView<XGuildJokerView>
	{
		// Token: 0x17003452 RID: 13394
		// (get) Token: 0x0600C412 RID: 50194 RVA: 0x002ABCA0 File Offset: 0x002A9EA0
		public override string fileName
		{
			get
			{
				return "Guild/GuildSystem/GuildJokerDlg";
			}
		}

		// Token: 0x0600C414 RID: 50196 RVA: 0x002ABCD0 File Offset: 0x002A9ED0
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

		// Token: 0x0600C415 RID: 50197 RVA: 0x002ABDE0 File Offset: 0x002A9FE0
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

		// Token: 0x0600C416 RID: 50198 RVA: 0x002ABE5C File Offset: 0x002AA05C
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

		// Token: 0x17003453 RID: 13395
		// (get) Token: 0x0600C417 RID: 50199 RVA: 0x002ABEA0 File Offset: 0x002AA0A0
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C418 RID: 50200 RVA: 0x002ABEB4 File Offset: 0x002AA0B4
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

		// Token: 0x0600C419 RID: 50201 RVA: 0x002ABF38 File Offset: 0x002AA138
		protected override SeqListRef<uint> GetCardReward(int index)
		{
			return XGuildJokerDocument._CardRewardTable.Table[index].reward;
		}

		// Token: 0x0600C41A RID: 50202 RVA: 0x002ABF5B File Offset: 0x002AA15B
		public void SetRankData(int length)
		{
			this.m_WrapContent.SetContentCount(length, false);
			this.m_ScrollView.ResetPosition();
		}

		// Token: 0x0600C41B RID: 50203 RVA: 0x002ABF78 File Offset: 0x002AA178
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_TeamCheck.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.TeamCheckHandler));
			this.m_GuildCheck.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.GuildCheckHandler));
		}

		// Token: 0x0600C41C RID: 50204 RVA: 0x002ABFB4 File Offset: 0x002AA1B4
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

		// Token: 0x0600C41D RID: 50205 RVA: 0x002ABFFC File Offset: 0x002AA1FC
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

		// Token: 0x0600C41E RID: 50206 RVA: 0x002AC044 File Offset: 0x002AA244
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

		// Token: 0x0600C41F RID: 50207 RVA: 0x002AC19C File Offset: 0x002AA39C
		private bool OnBuyChangeCount(IXUIButton button)
		{
			this._doc.SendChangeCard(base.CardReAnalyze(this._currentChangeCard));
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600C420 RID: 50208 RVA: 0x002AC1D4 File Offset: 0x002AA3D4
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

		// Token: 0x0600C421 RID: 50209 RVA: 0x002AC238 File Offset: 0x002AA438
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

		// Token: 0x0600C422 RID: 50210 RVA: 0x002AC280 File Offset: 0x002AA480
		protected override bool OnEndGameClicked(IXUIButton button)
		{
			this._doc.SendGameEnd();
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600C423 RID: 50211 RVA: 0x002AC2B8 File Offset: 0x002AA4B8
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

		// Token: 0x0600C424 RID: 50212 RVA: 0x002AC328 File Offset: 0x002AA528
		public void SetGameCount()
		{
			base.uiBehaviour.m_GameCount.SetText(this._doc.GameCount.ToString());
			base.uiBehaviour.m_ChangeCount.SetText(this._doc.ChangeCount.ToString());
		}

		// Token: 0x17003454 RID: 13396
		// (get) Token: 0x0600C425 RID: 50213 RVA: 0x002AC380 File Offset: 0x002AA580
		protected override string BestName
		{
			get
			{
				return this._doc.BestName;
			}
		}

		// Token: 0x17003455 RID: 13397
		// (get) Token: 0x0600C426 RID: 50214 RVA: 0x002AC3A0 File Offset: 0x002AA5A0
		protected override int CurrentCardCount
		{
			get
			{
				return this._doc.CurrentCard.Count;
			}
		}

		// Token: 0x17003456 RID: 13398
		// (get) Token: 0x0600C427 RID: 50215 RVA: 0x002AC3C4 File Offset: 0x002AA5C4
		protected override List<uint> CurrentCard
		{
			get
			{
				return this._doc.CurrentCard;
			}
		}

		// Token: 0x17003457 RID: 13399
		// (get) Token: 0x0600C428 RID: 50216 RVA: 0x002AC3E4 File Offset: 0x002AA5E4
		protected override uint CardResult
		{
			get
			{
				return this._doc.CardResult;
			}
		}

		// Token: 0x17003458 RID: 13400
		// (get) Token: 0x0600C429 RID: 50217 RVA: 0x002AC404 File Offset: 0x002AA604
		protected override int CurrentStore
		{
			get
			{
				return (int)this._doc.CardStore;
			}
		}

		// Token: 0x17003459 RID: 13401
		// (get) Token: 0x0600C42A RID: 50218 RVA: 0x002AC424 File Offset: 0x002AA624
		protected override List<uint> BestCard
		{
			get
			{
				return this._doc.BestCard;
			}
		}

		// Token: 0x0600C42B RID: 50219 RVA: 0x002AC444 File Offset: 0x002AA644
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

		// Token: 0x0600C42C RID: 50220 RVA: 0x002AC584 File Offset: 0x002AA784
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

		// Token: 0x0400553A RID: 21818
		private XGuildJokerDocument _doc = null;

		// Token: 0x0400553B RID: 21819
		private IXUIScrollView m_ScrollView;

		// Token: 0x0400553C RID: 21820
		private IXUIWrapContent m_WrapContent;

		// Token: 0x0400553D RID: 21821
		private IXUICheckBox m_TeamCheck;

		// Token: 0x0400553E RID: 21822
		private IXUICheckBox m_GuildCheck;

		// Token: 0x0400553F RID: 21823
		private XGuildJokerView.TabType m_CurrType = XGuildJokerView.TabType.Team;

		// Token: 0x04005540 RID: 21824
		private IXUILabel m_RuleTip;

		// Token: 0x020019CD RID: 6605
		public enum TabType
		{
			// Token: 0x04007FF2 RID: 32754
			Team,
			// Token: 0x04007FF3 RID: 32755
			Guild
		}
	}
}
