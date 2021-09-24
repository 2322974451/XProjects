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

	internal class XGuildJockerMatchView : XGuildJokerCommonView<XGuildJockerMatchView>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildSystem/GuildJokerMatchDlg";
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildJockerMatchDocument>(XGuildJockerMatchDocument.uuID);
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

		protected override SeqListRef<uint> GetCardReward(int index)
		{
			return XGuildJokerDocument._CardRewardTable.Table[index].matchreward;
		}

		public void RefreshSelfRank(int score, int rank)
		{
			this.SetBaseInfo(this.m_MyRank, XSingleton<XAttributeMgr>.singleton.XPlayerData.Name, rank, score);
		}

		public void SetRankInfo(int count)
		{
			this.m_RankWrapContent.SetContentCount(count, false);
			this.m_RankScrollView.ResetPosition();
		}

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

		private void OnRankWrapItemUpdate(Transform t, int index)
		{
			this.SetBaseInfo(t, (index < this._Doc.MatchRankNames.Count) ? this._Doc.MatchRankNames[index].ToString() : string.Empty, index, (index < this._Doc.MatchRankScores.Count) ? this._Doc.MatchRankScores[index] : 0);
		}

		public void SetGameCount()
		{
			base.uiBehaviour.m_GameCount.SetText(this._Doc.MatchRound.ToString());
			base.uiBehaviour.m_ChangeCount.SetText(this._Doc.ChangeCount.ToString());
		}

		private CardMatchState MatchState
		{
			get
			{
				return this._Doc.MatchState;
			}
		}

		protected override string BestName
		{
			get
			{
				return this._Doc.MatchBestJockerName;
			}
		}

		protected override int CurrentCardCount
		{
			get
			{
				return this._Doc.MatchJockers.Count;
			}
		}

		protected override List<uint> CurrentCard
		{
			get
			{
				return this._Doc.MatchJockers;
			}
		}

		protected override uint CardResult
		{
			get
			{
				return this._Doc.MatchResult;
			}
		}

		protected override List<uint> BestCard
		{
			get
			{
				return this._Doc.MatchBestJockers;
			}
		}

		protected override int CurrentStore
		{
			get
			{
				return (int)this._Doc.MatchJockerStore;
			}
		}

		protected override void OnShow()
		{
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
			this.m_addCountPerRound.SetText(XSingleton<XGlobalConfig>.singleton.GetValue("CardMatchChangeAdd"));
			bool flag = this._yuyinHandler != null;
			if (flag)
			{
				this._yuyinHandler.Show(YuyinIconType.JOKER, 4);
				this._yuyinHandler.Refresh(YuyinIconType.JOKER);
			}
		}

		public void RefreshWhenShow()
		{
			this.SetGameCount();
			base.SetCardStore();
			this.SetButtonState();
			this.ShowTimeClock();
			this.SetRoundInfo();
			this.SetRewardList();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshWhenShow();
		}

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

		public void SetRoundInfo()
		{
			base.RefreshCard();
			this.SetCurrentReward();
			this.SetGameCount();
			base.SetCardStore();
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			DlgHandlerBase.EnsureCreate<XYuyinView>(ref this._yuyinHandler, base.uiBehaviour.transform, true, this);
		}

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

		protected override void OnHide()
		{
			this._Doc.SendJokerMatchExit();
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

		private void ShowWattingTime()
		{
			this.m_beginTime.SetVisible(true);
			this.m_roundTime.SetVisible(false);
			base.SetGameTipStatus(false);
			base.uiBehaviour.m_CurrentRewardTransfrom.gameObject.SetActive(false);
		}

		private void ShowRoundTime()
		{
			base.uiBehaviour.m_CurrentRewardTransfrom.gameObject.SetActive(true);
			this.m_beginTime.SetVisible(false);
			this.m_roundTime.SetVisible(true);
			base.SetGameTipStatus(this.MatchState == CardMatchState.CardMatch_StateRounding || this.MatchState == CardMatchState.CardMatch_StateRoundBegin);
		}

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
							this.m_GameTip2.SetText(XStringDefineProxy.GetString("GUILD_JOCKER_MATCH_TIP_START", new object[]
							{
								XSingleton<XGlobalConfig>.singleton.GetValue("CardMatchRound"),
								XSingleton<XGlobalConfig>.singleton.GetValue("CardMatchRounding")
							}));
							base.uiBehaviour.m_StartGame.SetVisible(false);
						}
					}
				}
			}
		}

		private void ShowGameOver()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_changeTimer);
			base.uiBehaviour.m_CurrentRewardTransfrom.gameObject.SetActive(false);
			this.m_beginTime.SetVisible(false);
			this.m_roundTime.SetVisible(false);
			base.SetGameTipStatus(false);
		}

		protected override bool OnCloseClick(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		protected override bool OnStartGameClicked(IXUIButton button)
		{
			bool flag = (this.MatchState == CardMatchState.CardMatch_StateRounding || this.MatchState == CardMatchState.CardMatch_StateRoundBegin) && this.CurrentCard.Count > 0;
			if (flag)
			{
				this._Doc.SetJokerMatchRoundOver();
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
						this._Doc.SendGuildCardMatchChange(base.CardReAnalyze((uint)sp.ID));
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_JOCKER_NOTFREECOUNT"), "fece00");
					}
				}
			}
		}

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
						for (int i = 0; i < rowData.matchreward.Count; i++)
						{
							text = string.Format("{0} {1}{2}", text, XLabelSymbolHelper.FormatSmallIcon((int)rowData.matchreward[i, 0]), rowData.matchreward[i, 1]);
						}
						List<string> stringList = XSingleton<XGlobalConfig>.singleton.GetStringList("CardPointIcon");
						text = string.Format("{0} {1}{2}", text, XLabelSymbolHelper.FormatImage(stringList[0], stringList[1]), rowData.point);
					}
					base.SetCurrentRewardStr(text);
					base.RefreshCardSelect();
				}
			}
		}

		private void SetRewardList()
		{
			int count = this._Doc.MatchItems.Count;
			this.m_TotalIncomeTransform.gameObject.SetActive(count > 0);
			this.m_rewardPool.ReturnAll(false);
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

		private XGuildJockerMatchDocument _Doc;

		private IXUILabel m_beginTime;

		private IXUILabel m_roundTime;

		private IXUIScrollView m_RankScrollView;

		private IXUIWrapContent m_RankWrapContent;

		private IXUILabel m_RuleTip;

		public XYuyinView _yuyinHandler;

		public Transform m_MyRank;

		public IXUILabel m_addCountPerRound;

		public IXUILabel m_GameTip2;

		private uint m_changeTimer = 0U;

		private XUIPool m_rewardPool;

		private Transform m_rewardTransform;

		private Transform m_TotalIncomeTransform;
	}
}
