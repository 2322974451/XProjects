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
	// Token: 0x02000C42 RID: 3138
	internal class XGuildJockerMatchView : XGuildJokerCommonView<XGuildJockerMatchView>
	{
		// Token: 0x17003169 RID: 12649
		// (get) Token: 0x0600B1DD RID: 45533 RVA: 0x00223518 File Offset: 0x00221718
		public override string fileName
		{
			get
			{
				return "Guild/GuildSystem/GuildJokerMatchDlg";
			}
		}

		// Token: 0x1700316A RID: 12650
		// (get) Token: 0x0600B1DE RID: 45534 RVA: 0x00223530 File Offset: 0x00221730
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B1E0 RID: 45536 RVA: 0x00223554 File Offset: 0x00221754
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

		// Token: 0x0600B1E1 RID: 45537 RVA: 0x0022377C File Offset: 0x0022197C
		protected override SeqListRef<uint> GetCardReward(int index)
		{
			return XGuildJokerDocument._CardRewardTable.Table[index].matchreward;
		}

		// Token: 0x0600B1E2 RID: 45538 RVA: 0x0022379F File Offset: 0x0022199F
		public void RefreshSelfRank(int score, int rank)
		{
			this.SetBaseInfo(this.m_MyRank, XSingleton<XAttributeMgr>.singleton.XPlayerData.Name, rank, score);
		}

		// Token: 0x0600B1E3 RID: 45539 RVA: 0x002237C0 File Offset: 0x002219C0
		public void SetRankInfo(int count)
		{
			this.m_RankWrapContent.SetContentCount(count, false);
			this.m_RankScrollView.ResetPosition();
		}

		// Token: 0x0600B1E4 RID: 45540 RVA: 0x002237E0 File Offset: 0x002219E0
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

		// Token: 0x0600B1E5 RID: 45541 RVA: 0x00223918 File Offset: 0x00221B18
		private void OnRankWrapItemUpdate(Transform t, int index)
		{
			this.SetBaseInfo(t, (index < this._Doc.MatchRankNames.Count) ? this._Doc.MatchRankNames[index].ToString() : string.Empty, index, (index < this._Doc.MatchRankScores.Count) ? this._Doc.MatchRankScores[index] : 0);
		}

		// Token: 0x0600B1E6 RID: 45542 RVA: 0x00223988 File Offset: 0x00221B88
		public void SetGameCount()
		{
			base.uiBehaviour.m_GameCount.SetText(this._Doc.MatchRound.ToString());
			base.uiBehaviour.m_ChangeCount.SetText(this._Doc.ChangeCount.ToString());
		}

		// Token: 0x1700316B RID: 12651
		// (get) Token: 0x0600B1E7 RID: 45543 RVA: 0x002239E0 File Offset: 0x00221BE0
		private CardMatchState MatchState
		{
			get
			{
				return this._Doc.MatchState;
			}
		}

		// Token: 0x1700316C RID: 12652
		// (get) Token: 0x0600B1E8 RID: 45544 RVA: 0x00223A00 File Offset: 0x00221C00
		protected override string BestName
		{
			get
			{
				return this._Doc.MatchBestJockerName;
			}
		}

		// Token: 0x1700316D RID: 12653
		// (get) Token: 0x0600B1E9 RID: 45545 RVA: 0x00223A20 File Offset: 0x00221C20
		protected override int CurrentCardCount
		{
			get
			{
				return this._Doc.MatchJockers.Count;
			}
		}

		// Token: 0x1700316E RID: 12654
		// (get) Token: 0x0600B1EA RID: 45546 RVA: 0x00223A44 File Offset: 0x00221C44
		protected override List<uint> CurrentCard
		{
			get
			{
				return this._Doc.MatchJockers;
			}
		}

		// Token: 0x1700316F RID: 12655
		// (get) Token: 0x0600B1EB RID: 45547 RVA: 0x00223A64 File Offset: 0x00221C64
		protected override uint CardResult
		{
			get
			{
				return this._Doc.MatchResult;
			}
		}

		// Token: 0x17003170 RID: 12656
		// (get) Token: 0x0600B1EC RID: 45548 RVA: 0x00223A84 File Offset: 0x00221C84
		protected override List<uint> BestCard
		{
			get
			{
				return this._Doc.MatchBestJockers;
			}
		}

		// Token: 0x17003171 RID: 12657
		// (get) Token: 0x0600B1ED RID: 45549 RVA: 0x00223AA4 File Offset: 0x00221CA4
		protected override int CurrentStore
		{
			get
			{
				return (int)this._Doc.MatchJockerStore;
			}
		}

		// Token: 0x0600B1EE RID: 45550 RVA: 0x00223AC4 File Offset: 0x00221CC4
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

		// Token: 0x0600B1EF RID: 45551 RVA: 0x00223BAB File Offset: 0x00221DAB
		public void RefreshWhenShow()
		{
			this.SetGameCount();
			base.SetCardStore();
			this.SetButtonState();
			this.ShowTimeClock();
			this.SetRoundInfo();
			this.SetRewardList();
		}

		// Token: 0x0600B1F0 RID: 45552 RVA: 0x00223BD8 File Offset: 0x00221DD8
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshWhenShow();
		}

		// Token: 0x0600B1F1 RID: 45553 RVA: 0x00223BEC File Offset: 0x00221DEC
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

		// Token: 0x0600B1F2 RID: 45554 RVA: 0x00223C42 File Offset: 0x00221E42
		public void SetRoundInfo()
		{
			base.RefreshCard();
			this.SetCurrentReward();
			this.SetGameCount();
			base.SetCardStore();
		}

		// Token: 0x0600B1F3 RID: 45555 RVA: 0x00223C61 File Offset: 0x00221E61
		protected override void OnLoad()
		{
			base.OnLoad();
			DlgHandlerBase.EnsureCreate<XYuyinView>(ref this._yuyinHandler, base.uiBehaviour.transform, true, this);
		}

		// Token: 0x0600B1F4 RID: 45556 RVA: 0x00223C84 File Offset: 0x00221E84
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

		// Token: 0x0600B1F5 RID: 45557 RVA: 0x00223D2C File Offset: 0x00221F2C
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

		// Token: 0x0600B1F6 RID: 45558 RVA: 0x00223D9C File Offset: 0x00221F9C
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

		// Token: 0x0600B1F7 RID: 45559 RVA: 0x00223DD1 File Offset: 0x00221FD1
		private void ShowWattingTime()
		{
			this.m_beginTime.SetVisible(true);
			this.m_roundTime.SetVisible(false);
			base.SetGameTipStatus(false);
			base.uiBehaviour.m_CurrentRewardTransfrom.gameObject.SetActive(false);
		}

		// Token: 0x0600B1F8 RID: 45560 RVA: 0x00223E10 File Offset: 0x00222010
		private void ShowRoundTime()
		{
			base.uiBehaviour.m_CurrentRewardTransfrom.gameObject.SetActive(true);
			this.m_beginTime.SetVisible(false);
			this.m_roundTime.SetVisible(true);
			base.SetGameTipStatus(this.MatchState == CardMatchState.CardMatch_StateRounding || this.MatchState == CardMatchState.CardMatch_StateRoundBegin);
		}

		// Token: 0x0600B1F9 RID: 45561 RVA: 0x00223E6C File Offset: 0x0022206C
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

		// Token: 0x0600B1FA RID: 45562 RVA: 0x0022402C File Offset: 0x0022222C
		private void ShowGameOver()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_changeTimer);
			base.uiBehaviour.m_CurrentRewardTransfrom.gameObject.SetActive(false);
			this.m_beginTime.SetVisible(false);
			this.m_roundTime.SetVisible(false);
			base.SetGameTipStatus(false);
		}

		// Token: 0x0600B1FB RID: 45563 RVA: 0x00224084 File Offset: 0x00222284
		protected override bool OnCloseClick(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600B1FC RID: 45564 RVA: 0x002240A0 File Offset: 0x002222A0
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

		// Token: 0x0600B1FD RID: 45565 RVA: 0x00224104 File Offset: 0x00222304
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

		// Token: 0x0600B1FE RID: 45566 RVA: 0x002241D4 File Offset: 0x002223D4
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

		// Token: 0x0600B1FF RID: 45567 RVA: 0x0022433C File Offset: 0x0022253C
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

		// Token: 0x04004480 RID: 17536
		private XGuildJockerMatchDocument _Doc;

		// Token: 0x04004481 RID: 17537
		private IXUILabel m_beginTime;

		// Token: 0x04004482 RID: 17538
		private IXUILabel m_roundTime;

		// Token: 0x04004483 RID: 17539
		private IXUIScrollView m_RankScrollView;

		// Token: 0x04004484 RID: 17540
		private IXUIWrapContent m_RankWrapContent;

		// Token: 0x04004485 RID: 17541
		private IXUILabel m_RuleTip;

		// Token: 0x04004486 RID: 17542
		public XYuyinView _yuyinHandler;

		// Token: 0x04004487 RID: 17543
		public Transform m_MyRank;

		// Token: 0x04004488 RID: 17544
		public IXUILabel m_addCountPerRound;

		// Token: 0x04004489 RID: 17545
		public IXUILabel m_GameTip2;

		// Token: 0x0400448A RID: 17546
		private uint m_changeTimer = 0U;

		// Token: 0x0400448B RID: 17547
		private XUIPool m_rewardPool;

		// Token: 0x0400448C RID: 17548
		private Transform m_rewardTransform;

		// Token: 0x0400448D RID: 17549
		private Transform m_TotalIncomeTransform;
	}
}
