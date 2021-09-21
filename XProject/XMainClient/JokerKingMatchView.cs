using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C10 RID: 3088
	internal class JokerKingMatchView : XGuildJokerCommonView<JokerKingMatchView>
	{
		// Token: 0x170030EC RID: 12524
		// (get) Token: 0x0600AF5B RID: 44891 RVA: 0x00213460 File Offset: 0x00211660
		public override string fileName
		{
			get
			{
				return "OperatingActivity/JokerkingDuelDlg";
			}
		}

		// Token: 0x170030ED RID: 12525
		// (get) Token: 0x0600AF5C RID: 44892 RVA: 0x00213478 File Offset: 0x00211678
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600AF5D RID: 44893 RVA: 0x0021348B File Offset: 0x0021168B
		protected override void OnLoad()
		{
			base.OnLoad();
			DlgHandlerBase.EnsureCreate<XYuyinView>(ref this._yuyinHandler, base.uiBehaviour.transform, true, this);
		}

		// Token: 0x0600AF5E RID: 44894 RVA: 0x002134B0 File Offset: 0x002116B0
		protected override void OnUnload()
		{
			bool flag = this.m_rewardPool != null;
			if (flag)
			{
				this.m_rewardPool = null;
			}
			DlgHandlerBase.EnsureUnload<XYuyinView>(ref this._yuyinHandler);
			base.OnUnload();
		}

		// Token: 0x0600AF5F RID: 44895 RVA: 0x002134E8 File Offset: 0x002116E8
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this._Doc.TimeLeft > 0.0;
			if (flag)
			{
				string @string = XStringDefineProxy.GetString("GUILD_JOCKER_MATCH_WAITTING_LABEL");
				bool flag2 = this.m_beginTime.IsVisible();
				if (flag2)
				{
					this.m_beginTime.SetText(string.Format(@string, XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)this._Doc.TimeLeft, 5)));
				}
				bool flag3 = this.m_roundTime.IsVisible();
				if (flag3)
				{
					this.m_roundTime.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)this._Doc.TimeLeft, 5));
				}
			}
		}

		// Token: 0x0600AF60 RID: 44896 RVA: 0x00213590 File Offset: 0x00211790
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XJokerKingDocument>(XJokerKingDocument.uuID);
			this.m_beginTime = (base.uiBehaviour.transform.FindChild("Bg/BeginTime").GetComponent("XUILabel") as IXUILabel);
			this.m_roundTime = (base.uiBehaviour.transform.FindChild("Bg/RoundTime").GetComponent("XUILabel") as IXUILabel);
			this.m_RankScrollView = (base.uiBehaviour.transform.FindChild("Bg/Ranking/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_RankWrapContent = (base.uiBehaviour.transform.FindChild("Bg/Ranking/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_RankWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnRankWrapItemUpdate));
			this.m_RuleTip = (base.uiBehaviour.transform.FindChild("Bg/Rule/Bg/RuleTip").GetComponent("XUILabel") as IXUILabel);
			IXUIPanel ixuipanel = base.uiBehaviour.transform.GetComponent("XUIPanel") as IXUIPanel;
			ixuipanel.SetDepth(2);
			this.m_MyRank = base.uiBehaviour.transform.Find("Bg/Ranking/MyRank");
			this.m_addCountPerRound = (base.uiBehaviour.transform.Find("Bg/AddCount/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_GameTip2 = (base.uiBehaviour.transform.Find("Bg/GameTip2").GetComponent("XUILabel") as IXUILabel);
			this.m_rewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			this.m_TotalIncomeTransform = base.uiBehaviour.transform.FindChild("Bg/TotalIncome");
			this.m_rewardTransform = base.uiBehaviour.transform.FindChild("Bg/TotalIncome/RewardList");
			Transform transform = base.uiBehaviour.transform.FindChild("Bg/TotalIncome/RewardList/Reward");
			this.m_rewardPool.SetupPool(transform.parent.parent.gameObject, transform.gameObject, 4U, true);
		}

		// Token: 0x170030EE RID: 12526
		// (get) Token: 0x0600AF61 RID: 44897 RVA: 0x002137B8 File Offset: 0x002119B8
		private CardMatchState MatchState
		{
			get
			{
				return this._Doc.MatchState;
			}
		}

		// Token: 0x170030EF RID: 12527
		// (get) Token: 0x0600AF62 RID: 44898 RVA: 0x002137D8 File Offset: 0x002119D8
		protected override int CurrentStore
		{
			get
			{
				return (int)this._Doc.MatchJockerStore;
			}
		}

		// Token: 0x170030F0 RID: 12528
		// (get) Token: 0x0600AF63 RID: 44899 RVA: 0x002137F8 File Offset: 0x002119F8
		protected override int CurrentCardCount
		{
			get
			{
				return this._Doc.MatchJockers.Count;
			}
		}

		// Token: 0x170030F1 RID: 12529
		// (get) Token: 0x0600AF64 RID: 44900 RVA: 0x0021381C File Offset: 0x00211A1C
		protected override uint CardResult
		{
			get
			{
				return this._Doc.MatchResult;
			}
		}

		// Token: 0x170030F2 RID: 12530
		// (get) Token: 0x0600AF65 RID: 44901 RVA: 0x0021383C File Offset: 0x00211A3C
		protected override List<uint> BestCard
		{
			get
			{
				return this._Doc.MatchBestJockers;
			}
		}

		// Token: 0x170030F3 RID: 12531
		// (get) Token: 0x0600AF66 RID: 44902 RVA: 0x0021385C File Offset: 0x00211A5C
		protected override string BestName
		{
			get
			{
				return this._Doc.MatchBestJockerName;
			}
		}

		// Token: 0x170030F4 RID: 12532
		// (get) Token: 0x0600AF67 RID: 44903 RVA: 0x0021387C File Offset: 0x00211A7C
		protected override List<uint> CurrentCard
		{
			get
			{
				return this._Doc.MatchJockers;
			}
		}

		// Token: 0x0600AF68 RID: 44904 RVA: 0x0021389C File Offset: 0x00211A9C
		protected override bool OnCloseClick(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600AF69 RID: 44905 RVA: 0x002138B8 File Offset: 0x00211AB8
		protected override void OnShow()
		{
			base.OnShow();
			base.OnShow();
			this._Doc.wattingPTC = false;
			base.SetupBestCard();
			this.RefreshWhenShow();
			this.SetRankInfo(this._Doc.MatchRankNames.Count);
			ShowSettingArgs showSettingArgs = new ShowSettingArgs();
			showSettingArgs.position = 1;
			showSettingArgs.needforceshow = true;
			showSettingArgs.forceshow = true;
			showSettingArgs.needdepth = true;
			showSettingArgs.depth = 4;
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.ShowChatMiniUI(showSettingArgs);
			this.m_RuleTip.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("GUILD_JOKER_MATCH_RULE_TIP")));
			this.m_addCountPerRound.SetText(XSingleton<XGlobalConfig>.singleton.GetValue("PokerTournamentChangeAdd"));
			bool flag = this._yuyinHandler != null;
			if (flag)
			{
				this._yuyinHandler.Show(YuyinIconType.JOKER, 4);
				this._yuyinHandler.Refresh(YuyinIconType.JOKER);
			}
		}

		// Token: 0x0600AF6A RID: 44906 RVA: 0x002139A6 File Offset: 0x00211BA6
		public void SetRankInfo(int count)
		{
			this.m_RankWrapContent.SetContentCount(count, false);
			this.m_RankScrollView.ResetPosition();
		}

		// Token: 0x0600AF6B RID: 44907 RVA: 0x002139C3 File Offset: 0x00211BC3
		public void RefreshSelfRank(int score, int rank)
		{
			this.SetBaseInfo(this.m_MyRank, XSingleton<XAttributeMgr>.singleton.XPlayerData.Name, rank, score);
		}

		// Token: 0x0600AF6C RID: 44908 RVA: 0x002139E4 File Offset: 0x00211BE4
		protected override SeqListRef<uint> GetCardReward(int index)
		{
			return XGuildJokerDocument._CardRewardTable.Table[index].jokerreward;
		}

		// Token: 0x0600AF6D RID: 44909 RVA: 0x00213A08 File Offset: 0x00211C08
		private void SetBaseInfo(Transform t, string name, int index, int score)
		{
			IXUILabelSymbol ixuilabelSymbol = t.FindChild("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel = t.FindChild("Score").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = t.FindChild("IndexSprite").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel2 = t.FindChild("IndexLabel").GetComponent("XUILabel") as IXUILabel;
			bool flag = index == -1;
			if (flag)
			{
				ixuilabel2.Alpha = 1f;
				ixuisprite.SetAlpha(0f);
				ixuilabel2.SetText(XSingleton<XStringTable>.singleton.GetString("NoRank"));
			}
			else
			{
				bool flag2 = index < 3;
				if (flag2)
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
			}
			ixuilabel.SetText(score.ToString());
			ixuilabelSymbol.InputText = name;
		}

		// Token: 0x0600AF6E RID: 44910 RVA: 0x00213B40 File Offset: 0x00211D40
		private void OnRankWrapItemUpdate(Transform t, int index)
		{
			this.SetBaseInfo(t, (index < this._Doc.MatchRankNames.Count) ? this._Doc.MatchRankNames[index].ToString() : string.Empty, index, (index < this._Doc.MatchRankScores.Count) ? this._Doc.MatchRankScores[index] : 0);
		}

		// Token: 0x0600AF6F RID: 44911 RVA: 0x00213BB0 File Offset: 0x00211DB0
		protected override void OnHide()
		{
			this._Doc.JokerKingMatchExit();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_changeTimer);
			ShowSettingArgs showSettingArgs = new ShowSettingArgs();
			showSettingArgs.position = 0;
			showSettingArgs.needforceshow = true;
			showSettingArgs.forceshow = false;
			showSettingArgs.needdepth = true;
			showSettingArgs.depth = 0;
			showSettingArgs.anim = false;
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.ShowChatMiniUI(showSettingArgs);
			base.OnHide();
		}

		// Token: 0x0600AF70 RID: 44912 RVA: 0x00213C20 File Offset: 0x00211E20
		private void ShowTimeClock()
		{
			bool flag = this.MatchState == CardMatchState.CardMatch_StateEnd;
			if (flag)
			{
				this.ShowGameOver();
			}
			else
			{
				bool flag2 = this.MatchState == CardMatchState.CardMatch_StateRoundBegin || this.MatchState == CardMatchState.CardMatch_StateRounding || this.MatchState == CardMatchState.CardMatch_StateRoundEnd;
				if (flag2)
				{
					this.ShowRoundTime();
				}
				else
				{
					this.ShowWattingTime();
				}
			}
		}

		// Token: 0x0600AF71 RID: 44913 RVA: 0x00213C78 File Offset: 0x00211E78
		protected override void OnCardClick(IXUISprite sp)
		{
			bool flag = this._changeCardLock || this._cardLock;
			if (!flag)
			{
				bool flag2 = false;
				for (int i = 0; i < this._Doc.MatchJockers.Count; i++)
				{
					bool flag3 = this._Doc.MatchJockers[i] == base.CardReAnalyze((uint)sp.ID);
					if (flag3)
					{
						flag2 = true;
					}
				}
				bool flag4 = !flag2;
				if (!flag4)
				{
					bool flag5 = this._Doc.ChangeCount > 0U;
					if (flag5)
					{
						this._Doc.JokerKingRoundChange(base.CardReAnalyze((uint)sp.ID));
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_JOCKER_NOTFREECOUNT"), "fece00");
					}
				}
			}
		}

		// Token: 0x0600AF72 RID: 44914 RVA: 0x00213D46 File Offset: 0x00211F46
		private void ShowWattingTime()
		{
			this.m_beginTime.SetVisible(true);
			this.m_roundTime.SetVisible(false);
			base.SetGameTipStatus(false);
			base.uiBehaviour.m_CurrentRewardTransfrom.gameObject.SetActive(false);
		}

		// Token: 0x0600AF73 RID: 44915 RVA: 0x00213D84 File Offset: 0x00211F84
		private void ShowRoundTime()
		{
			base.uiBehaviour.m_CurrentRewardTransfrom.gameObject.SetActive(true);
			this.m_beginTime.SetVisible(false);
			this.m_roundTime.SetVisible(true);
			base.SetGameTipStatus(this.MatchState == CardMatchState.CardMatch_StateRounding || this.MatchState == CardMatchState.CardMatch_StateRoundBegin);
		}

		// Token: 0x0600AF74 RID: 44916 RVA: 0x00213DE0 File Offset: 0x00211FE0
		protected override bool OnStartGameClicked(IXUIButton button)
		{
			bool flag = (this.MatchState == CardMatchState.CardMatch_StateRounding || this.MatchState == CardMatchState.CardMatch_StateRoundBegin) && this.CurrentCard.Count > 0;
			if (flag)
			{
				this._Doc.JokerKingRoundOver();
			}
			else
			{
				bool flag2 = this.MatchState == CardMatchState.CardMatch_StateEnd;
				if (flag2)
				{
					this.SetVisibleWithAnimation(false, null);
				}
			}
			return true;
		}

		// Token: 0x0600AF75 RID: 44917 RVA: 0x00213E44 File Offset: 0x00212044
		private void ShowGameOver()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_changeTimer);
			base.uiBehaviour.m_CurrentRewardTransfrom.gameObject.SetActive(false);
			this.m_beginTime.SetVisible(false);
			this.m_roundTime.SetVisible(false);
			base.SetGameTipStatus(false);
		}

		// Token: 0x0600AF76 RID: 44918 RVA: 0x00213E9C File Offset: 0x0021209C
		public void SetGameCount()
		{
			base.uiBehaviour.m_GameCount.SetText(this._Doc.MatchRound.ToString());
			base.uiBehaviour.m_ChangeCount.SetText(this._Doc.ChangeCount.ToString());
		}

		// Token: 0x0600AF77 RID: 44919 RVA: 0x00213EF2 File Offset: 0x002120F2
		public void SetRoundInfo()
		{
			base.RefreshCard();
			this.SetCurrentReward();
			this.SetGameCount();
			base.SetCardStore();
		}

		// Token: 0x0600AF78 RID: 44920 RVA: 0x00213F14 File Offset: 0x00212114
		private void SetButtonState()
		{
			this.m_GameTip2.SetVisible(false);
			bool flag = this.MatchState == CardMatchState.CardMatch_StateRounding || this.MatchState == CardMatchState.CardMatch_StateRoundBegin;
			if (flag)
			{
				base.uiBehaviour.m_StartGame.SetGrey(this.CurrentCard.Count > 0);
				base.uiBehaviour.m_StartGame.SetVisible(true);
				base.SetButtonTip("GUILD_JOCKER_MATCH_GET");
			}
			else
			{
				bool flag2 = this.MatchState == CardMatchState.CardMatch_StateRoundWaiting;
				if (flag2)
				{
					base.uiBehaviour.m_StartGame.SetGrey(true);
					base.uiBehaviour.m_StartGame.SetVisible(true);
					base.SetButtonTip("GUILD_JOCKER_MATCH_WAITTING");
				}
				else
				{
					bool flag3 = this.MatchState == CardMatchState.CardMatch_StateRoundEnd;
					if (flag3)
					{
						base.uiBehaviour.m_StartGame.SetVisible(true);
						base.uiBehaviour.m_StartGame.SetGrey(false);
					}
					else
					{
						bool flag4 = this.MatchState == CardMatchState.CardMatch_StateEnd;
						if (flag4)
						{
							base.uiBehaviour.m_StartGame.SetVisible(true);
							base.uiBehaviour.m_StartGame.SetGrey(true);
							base.SetButtonTip("GUILD_REDPACKET_DETAIL_EXIT");
							this.m_GameTip2.SetVisible(true);
							this.m_GameTip2.SetText(XSingleton<XStringTable>.singleton.GetString("GUILD_JOCKER_MATCH_TIP_END"));
						}
						else
						{
							this.m_GameTip2.SetVisible(true);
							this.m_GameTip2.SetText(XStringDefineProxy.GetString("JOKERKING_MESSAGE", new object[]
							{
								XSingleton<XGlobalConfig>.singleton.GetValue("PokerTournamentRound"),
								XSingleton<XGlobalConfig>.singleton.GetValue("PokerTournamentRounding")
							}));
							base.uiBehaviour.m_StartGame.SetVisible(false);
						}
					}
				}
			}
		}

		// Token: 0x0600AF79 RID: 44921 RVA: 0x002140D2 File Offset: 0x002122D2
		public void RefreshWhenShow()
		{
			this.SetGameCount();
			base.SetCardStore();
			this.SetButtonState();
			this.ShowTimeClock();
			this.SetRoundInfo();
			this.SetRewardList();
		}

		// Token: 0x0600AF7A RID: 44922 RVA: 0x00214100 File Offset: 0x00212300
		public override void SetCurrentReward()
		{
			string text = string.Format("{0}:", XStringDefineProxy.GetString("CURRENT_REWARD"));
			bool flag = this._Doc.MatchJockers.Count == 0;
			if (flag)
			{
				base.SetCurrentRewardStr(text);
			}
			else
			{
				bool flag2 = this.CurrentCard.Count == 0;
				if (flag2)
				{
					base.SetCurrentRewardStr(text);
				}
				else
				{
					bool flag3 = (ulong)this._Doc.MatchResult >= (ulong)((long)XGuildJokerDocument._CardRewardTable.Table.Length);
					if (flag3)
					{
						text = string.Format("{0} {1}", text, XStringDefineProxy.GetString("NONE"));
					}
					else
					{
						CardRewardTable.RowData rowData = XGuildJokerDocument._CardRewardTable.Table[(int)this._Doc.MatchResult];
						for (int i = 0; i < rowData.jokerreward.Count; i++)
						{
							text = string.Format("{0} {1}{2}", text, XLabelSymbolHelper.FormatSmallIcon((int)rowData.jokerreward[i, 0]), rowData.jokerreward[i, 1]);
						}
						List<string> stringList = XSingleton<XGlobalConfig>.singleton.GetStringList("CardPointIcon");
						text = string.Format("{0} {1}{2}", text, XLabelSymbolHelper.FormatImage(stringList[0], stringList[1]), rowData.point);
					}
					base.SetCurrentRewardStr(text);
					base.RefreshCardSelect();
				}
			}
		}

		// Token: 0x0600AF7B RID: 44923 RVA: 0x00214268 File Offset: 0x00212468
		private void SetRewardList()
		{
			int count = this._Doc.MatchItems.Count;
			this.m_rewardPool.ReturnAll(false);
			this.m_TotalIncomeTransform.gameObject.SetActive(count > 0);
			for (int i = 0; i < count; i++)
			{
				GameObject gameObject = this.m_rewardPool.FetchGameObject(false);
				gameObject.transform.parent = this.m_rewardTransform;
				gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)i * 28));
				ItemBrief itemBrief = this._Doc.MatchItems[i];
				IXUILabelSymbol ixuilabelSymbol = gameObject.GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				string text = string.Format("{0} X{1}", XLabelSymbolHelper.FormatSmallIcon((int)itemBrief.itemID), itemBrief.itemCount);
				XSingleton<XDebug>.singleton.AddGreenLog("StrTemp:", text, null, null, null, null);
				ixuilabelSymbol.InputText = text;
			}
		}

		// Token: 0x040042CF RID: 17103
		private XJokerKingDocument _Doc;

		// Token: 0x040042D0 RID: 17104
		private IXUILabel m_beginTime;

		// Token: 0x040042D1 RID: 17105
		private IXUILabel m_roundTime;

		// Token: 0x040042D2 RID: 17106
		private IXUIScrollView m_RankScrollView;

		// Token: 0x040042D3 RID: 17107
		private IXUIWrapContent m_RankWrapContent;

		// Token: 0x040042D4 RID: 17108
		private IXUILabel m_RuleTip;

		// Token: 0x040042D5 RID: 17109
		public XYuyinView _yuyinHandler;

		// Token: 0x040042D6 RID: 17110
		public Transform m_MyRank;

		// Token: 0x040042D7 RID: 17111
		public IXUILabel m_addCountPerRound;

		// Token: 0x040042D8 RID: 17112
		public IXUILabel m_GameTip2;

		// Token: 0x040042D9 RID: 17113
		private uint m_changeTimer = 0U;

		// Token: 0x040042DA RID: 17114
		private XUIPool m_rewardPool;

		// Token: 0x040042DB RID: 17115
		private Transform m_rewardTransform;

		// Token: 0x040042DC RID: 17116
		private Transform m_TotalIncomeTransform;
	}
}
