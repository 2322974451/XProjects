using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200091C RID: 2332
	internal class XJokerKingDocument : XDocComponent
	{
		// Token: 0x17002B8C RID: 11148
		// (get) Token: 0x06008CB8 RID: 36024 RVA: 0x00131D78 File Offset: 0x0012FF78
		public override uint ID
		{
			get
			{
				return XJokerKingDocument.uuID;
			}
		}

		// Token: 0x17002B8D RID: 11149
		// (get) Token: 0x06008CB9 RID: 36025 RVA: 0x00131D90 File Offset: 0x0012FF90
		public uint JokerKingTimes
		{
			get
			{
				return this.m_JokerKingTimes;
			}
		}

		// Token: 0x17002B8E RID: 11150
		// (get) Token: 0x06008CBA RID: 36026 RVA: 0x00131DA8 File Offset: 0x0012FFA8
		public CardMatchState MatchState
		{
			get
			{
				return this.m_matchState;
			}
		}

		// Token: 0x17002B8F RID: 11151
		// (get) Token: 0x06008CBB RID: 36027 RVA: 0x00131DC0 File Offset: 0x0012FFC0
		// (set) Token: 0x06008CBC RID: 36028 RVA: 0x00131DD8 File Offset: 0x0012FFD8
		public double TimeLeft
		{
			get
			{
				return this.m_timeLeft;
			}
			set
			{
				this.m_timeLeft = value;
			}
		}

		// Token: 0x17002B90 RID: 11152
		// (get) Token: 0x06008CBD RID: 36029 RVA: 0x00131DE4 File Offset: 0x0012FFE4
		public uint ChangeCount
		{
			get
			{
				return this.m_changeount;
			}
		}

		// Token: 0x17002B91 RID: 11153
		// (get) Token: 0x06008CBE RID: 36030 RVA: 0x00131DFC File Offset: 0x0012FFFC
		public uint MatchRound
		{
			get
			{
				return this.m_matchRound;
			}
		}

		// Token: 0x17002B92 RID: 11154
		// (get) Token: 0x06008CBF RID: 36031 RVA: 0x00131E14 File Offset: 0x00130014
		public uint MatchResult
		{
			get
			{
				return this.m_matchResult;
			}
		}

		// Token: 0x17002B93 RID: 11155
		// (get) Token: 0x06008CC0 RID: 36032 RVA: 0x00131E2C File Offset: 0x0013002C
		public List<uint> MatchJockers
		{
			get
			{
				return this.m_matchJokers;
			}
		}

		// Token: 0x17002B94 RID: 11156
		// (get) Token: 0x06008CC1 RID: 36033 RVA: 0x00131E44 File Offset: 0x00130044
		public uint MatchJockerStore
		{
			get
			{
				return this.m_matchJockerStore;
			}
		}

		// Token: 0x17002B95 RID: 11157
		// (get) Token: 0x06008CC2 RID: 36034 RVA: 0x00131E5C File Offset: 0x0013005C
		public List<uint> MatchBestJockers
		{
			get
			{
				return this.m_matchBestJockers;
			}
		}

		// Token: 0x17002B96 RID: 11158
		// (get) Token: 0x06008CC3 RID: 36035 RVA: 0x00131E74 File Offset: 0x00130074
		public string MatchBestJockerName
		{
			get
			{
				return this.m_matchBestName;
			}
		}

		// Token: 0x17002B97 RID: 11159
		// (get) Token: 0x06008CC4 RID: 36036 RVA: 0x00131E8C File Offset: 0x0013008C
		public List<string> MatchRankNames
		{
			get
			{
				return this.m_matchRankName;
			}
		}

		// Token: 0x17002B98 RID: 11160
		// (get) Token: 0x06008CC5 RID: 36037 RVA: 0x00131EA4 File Offset: 0x001300A4
		public List<int> MatchRankScores
		{
			get
			{
				return this.m_matchRankScore;
			}
		}

		// Token: 0x17002B99 RID: 11161
		// (get) Token: 0x06008CC6 RID: 36038 RVA: 0x00131EBC File Offset: 0x001300BC
		public List<ItemBrief> MatchItems
		{
			get
			{
				return this.m_matchItems;
			}
		}

		// Token: 0x17002B9A RID: 11162
		// (get) Token: 0x06008CC7 RID: 36039 RVA: 0x00131ED4 File Offset: 0x001300D4
		public bool IsBegin
		{
			get
			{
				return this.m_isBegion;
			}
		}

		// Token: 0x17002B9B RID: 11163
		// (get) Token: 0x06008CC8 RID: 36040 RVA: 0x00131EEC File Offset: 0x001300EC
		public bool IsCanBegin
		{
			get
			{
				return this.m_isCanBegion;
			}
		}

		// Token: 0x17002B9C RID: 11164
		// (get) Token: 0x06008CC9 RID: 36041 RVA: 0x00131F04 File Offset: 0x00130104
		public bool IsSignUp
		{
			get
			{
				return this.m_isSignUp;
			}
		}

		// Token: 0x17002B9D RID: 11165
		// (get) Token: 0x06008CCB RID: 36043 RVA: 0x00131F8C File Offset: 0x0013018C
		// (set) Token: 0x06008CCA RID: 36042 RVA: 0x00131F1C File Offset: 0x0013011C
		public bool bAvaiableIconWhenShow
		{
			get
			{
				return this.m_bAvaiableIconWhenShow;
			}
			set
			{
				this.m_bAvaiableIconWhenShow = value;
				XSingleton<XDebug>.singleton.AddGreenLog("bAvaiableIconWhenShow:", this.bAvaiableIconWhenShow.ToString(), null, null, null, null);
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_JockerKing, true);
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_JockerKing, true);
				bool flag = DlgBase<JokerKingMainView, JokerKingMainBehavior>.singleton.IsVisible();
				if (flag)
				{
					this.JokerKingMatchQuery();
				}
			}
		}

		// Token: 0x06008CCC RID: 36044 RVA: 0x00131FA4 File Offset: 0x001301A4
		public void JokerKingGameOver()
		{
			this.m_isSignUp = false;
			this.m_matchState = CardMatchState.CardMatch_StateDummy;
			this.bAvaiableIconWhenShow = false;
			XSingleton<XDebug>.singleton.AddGreenLog("JokerKingGameOver", null, null, null, null, null);
			bool flag = DlgBase<JokerKingMainView, JokerKingMainBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<JokerKingMainView, JokerKingMainBehavior>.singleton.SetVisibleWithAnimation(false, null);
			}
		}

		// Token: 0x06008CCD RID: 36045 RVA: 0x00131FF8 File Offset: 0x001301F8
		public static void Execute(OnLoadedCallback callback = null)
		{
			XJokerKingDocument.AsynLoader.AddTask("Table/PokerTournamentReward", XJokerKingDocument.JokerTournamed, false);
			XJokerKingDocument.AsynLoader.Execute(callback);
		}

		// Token: 0x06008CCE RID: 36046 RVA: 0x0013201D File Offset: 0x0013021D
		public void JokerKingMatchQuery()
		{
			this.SendJokerKingMsg(CardMatchOp.CardMatch_Query, 0U);
		}

		// Token: 0x06008CCF RID: 36047 RVA: 0x00132029 File Offset: 0x00130229
		public void JokerKingMatchAdd()
		{
			this.SendJokerKingMsg(CardMatchOp.CardMatch_Add, 0U);
		}

		// Token: 0x06008CD0 RID: 36048 RVA: 0x00132035 File Offset: 0x00130235
		public void JokerKingMatchExit()
		{
			this.SendJokerKingMsg(CardMatchOp.CardMatch_Del, 0U);
		}

		// Token: 0x06008CD1 RID: 36049 RVA: 0x00132044 File Offset: 0x00130244
		public void JokerKingMatchSignUp()
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("PokerTournamentSignUpNum");
			bool flag = (ulong)this.m_JokerKingTimes < (ulong)((long)@int);
			if (flag)
			{
				this.SendJokerKingMsg(CardMatchOp.CardMatch_SignUp, 0U);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("JOKERKING_TIME_FULL"), "fece00");
			}
		}

		// Token: 0x06008CD2 RID: 36050 RVA: 0x0013209C File Offset: 0x0013029C
		public void JokerKingRoundChange(uint card)
		{
			bool flag = this.wattingPTC;
			if (!flag)
			{
				this.wattingPTC = true;
				this.SendJokerKingMsg(CardMatchOp.CardMatch_RoundChange, card);
			}
		}

		// Token: 0x06008CD3 RID: 36051 RVA: 0x001320C8 File Offset: 0x001302C8
		private void SendJokerKingMsg(CardMatchOp op, uint card = 0U)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Send JokerKing Message:", op.ToString(), null, null, null, null);
			PtcC2M_PokerTournamentReq ptcC2M_PokerTournamentReq = new PtcC2M_PokerTournamentReq();
			ptcC2M_PokerTournamentReq.Data.op = op;
			ptcC2M_PokerTournamentReq.Data.card = card;
			this.m_oldJockerID = card;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_PokerTournamentReq);
		}

		// Token: 0x06008CD4 RID: 36052 RVA: 0x0013212C File Offset: 0x0013032C
		public void JokerKingRoundOver()
		{
			PtcC2M_PokerTournamentReq ptcC2M_PokerTournamentReq = new PtcC2M_PokerTournamentReq();
			ptcC2M_PokerTournamentReq.Data.op = CardMatchOp.CardMatch_RoundEnd;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_PokerTournamentReq);
		}

		// Token: 0x06008CD5 RID: 36053 RVA: 0x0013215C File Offset: 0x0013035C
		public void SendJokerMatchRank()
		{
			PtcC2M_GuildCardRankReq ptcC2M_GuildCardRankReq = new PtcC2M_GuildCardRankReq();
			ptcC2M_GuildCardRankReq.Data.type = 3U;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_GuildCardRankReq);
		}

		// Token: 0x06008CD6 RID: 36054 RVA: 0x0013218C File Offset: 0x0013038C
		public void ReceiveJokerRank(List<string> names, List<int> scores)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Length:", names.Count.ToString(), null, null, null, null);
			this.m_matchRankName.Clear();
			this.m_matchRankName.AddRange(names);
			this.m_matchRankScore.Clear();
			this.m_matchRankScore.AddRange(scores);
			int score = 0;
			int rank = -1;
			for (int i = 0; i < names.Count; i++)
			{
				bool flag = names[i] == XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
				if (flag)
				{
					bool flag2 = i < scores.Count;
					if (flag2)
					{
						score = scores[i];
						rank = i;
						break;
					}
				}
			}
			bool flag3 = DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (flag3)
			{
				DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.SetRankInfo(this.m_matchRankName.Count);
				DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.RefreshSelfRank(score, rank);
			}
		}

		// Token: 0x06008CD7 RID: 36055 RVA: 0x00132280 File Offset: 0x00130480
		public void ReceiveJokerKingMatchInfo(GuildCardMatchNtf ntf)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Receive JokerKing Message:", ntf.op.ToString(), null, null, null, null);
			switch (ntf.op)
			{
			case CardMatchOp.CardMatch_Begin:
				this.JokerBegion();
				break;
			case CardMatchOp.CardMatch_Add:
				this.ShowJokerJoin(ntf);
				this.SendJokerMatchRank();
				break;
			case CardMatchOp.CardMatch_RoundBegin:
				this.ShowMatchBegin(ntf);
				break;
			case CardMatchOp.CardMatch_RoundChange:
				this.ChangeJocker(ntf);
				break;
			case CardMatchOp.CardMatch_RoundEnd:
				this.SendJokerMatchRank();
				this.EndJockerGame(ntf);
				break;
			case CardMatchOp.CardMatch_End:
				this.SendJokerMatchRank();
				this.JokerMatchOver();
				break;
			case CardMatchOp.CardMatch_Query:
				this.ShowJokerQuery(ntf);
				break;
			case CardMatchOp.CardMatch_RoundWaiting:
				this.ShowWaittingJocker(ntf);
				this.SendJokerMatchRank();
				break;
			case CardMatchOp.CardMatch_SignUp:
				this.JokerSignUpResult(ntf);
				break;
			}
		}

		// Token: 0x06008CD8 RID: 36056 RVA: 0x00132368 File Offset: 0x00130568
		private void JokerBegion()
		{
			this.m_matchState = CardMatchState.CardMatch_StateBegin;
			bool flag = !DlgBase<JokerKingMainView, JokerKingMainBehavior>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<JokerKingMainView, JokerKingMainBehavior>.singleton.RefreshData();
			}
		}

		// Token: 0x06008CD9 RID: 36057 RVA: 0x0013239C File Offset: 0x0013059C
		private void JokerMatchOver()
		{
			this.m_matchJokers.Clear();
			this.m_timeLeft = 0.0;
			this.m_matchState = CardMatchState.CardMatch_StateEnd;
			bool flag = !DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.RefreshWhenShow();
			}
		}

		// Token: 0x06008CDA RID: 36058 RVA: 0x001323EC File Offset: 0x001305EC
		private void SetMatchData(GuildCardMatchNtf ntf)
		{
			this.m_matchState = ntf.state;
			this.m_timeLeft = ntf.timeleft + 1U;
			this.m_changeount = ntf.changecount;
			this.m_matchResult = ntf.result;
			this.m_matchJockerStore = ntf.store;
			this.m_matchItems.Clear();
			this.m_matchItems.AddRange(ntf.items);
			this.m_matchRound = (uint)((long)XSingleton<XGlobalConfig>.singleton.GetInt("PokerTournamentRound") - (long)((ulong)((ntf.round == uint.MaxValue) ? 0U : (ntf.round + 1U))));
			this.m_matchJokers.Clear();
			this.m_matchJokers.AddRange(ntf.cards);
		}

		// Token: 0x06008CDB RID: 36059 RVA: 0x001324A4 File Offset: 0x001306A4
		private void ShowJokerJoin(GuildCardMatchNtf ntf)
		{
			this.SetMatchData(ntf);
			this.ClearBestJoker();
			bool flag = !DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
		}

		// Token: 0x06008CDC RID: 36060 RVA: 0x001324E0 File Offset: 0x001306E0
		private void ShowMatchBegin(GuildCardMatchNtf ntf)
		{
			this.SetMatchData(ntf);
			this.ClearBestJoker();
			bool flag = !DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.RefreshWhenShow();
			}
		}

		// Token: 0x06008CDD RID: 36061 RVA: 0x0013251C File Offset: 0x0013071C
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			bool flag = this.m_timeLeft > (double)fDeltaT;
			if (flag)
			{
				this.m_timeLeft -= (double)fDeltaT;
			}
			else
			{
				this.m_timeLeft = 0.0;
			}
		}

		// Token: 0x06008CDE RID: 36062 RVA: 0x00132560 File Offset: 0x00130760
		private void ShowJokerQuery(GuildCardMatchNtf ntf)
		{
			this.m_matchState = ntf.state;
			this.m_isBegion = ntf.isbegin;
			this.m_isCanBegion = true;
			this.m_timeLeft = ntf.timeleft;
			this.m_isSignUp = ntf.sign_up;
			this.m_JokerKingTimes = ntf.sign_up_num;
			XSingleton<XDebug>.singleton.AddGreenLog("ntf:", this.m_matchState.ToString(), " ", this.m_isSignUp.ToString(), null, null);
			bool flag = DlgBase<JokerKingMainView, JokerKingMainBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<JokerKingMainView, JokerKingMainBehavior>.singleton.RefreshData();
			}
		}

		// Token: 0x06008CDF RID: 36063 RVA: 0x00132600 File Offset: 0x00130800
		private void ShowWaittingJocker(GuildCardMatchNtf ntf)
		{
			this.m_timeLeft = ntf.timeleft + 1U;
			this.m_matchState = ntf.state;
			this.m_matchJokers.Clear();
			bool flag = !DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.RefreshWhenShow();
			}
		}

		// Token: 0x06008CE0 RID: 36064 RVA: 0x00132654 File Offset: 0x00130854
		public void EndJockerGame(GuildCardMatchNtf ntf)
		{
			this.m_matchState = CardMatchState.CardMatch_StateRoundEnd;
			this.m_matchJockerStore = 5U;
			this.MatchJockers.Clear();
			this.m_matchItems.Clear();
			this.m_matchItems.AddRange(ntf.items);
			bool flag = DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = this.MatchResult != 8U;
				if (flag2)
				{
					XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/pukeshenli", true, AudioChannel.Action);
					DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.JokerStatus(2);
					XSingleton<XTimerMgr>.singleton.KillTimer(this.JokerToken);
					this.JokerToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.ResetJokerStatusCb, null);
				}
				else
				{
					XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/pukeshibai", true, AudioChannel.Action);
					DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.JokerStatus(3);
					XSingleton<XTimerMgr>.singleton.KillTimer(this.JokerToken);
					this.JokerToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.ResetJokerStatusCb, null);
				}
			}
			bool flag3 = !DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag3)
			{
				DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.RefreshWhenShow();
			}
		}

		// Token: 0x06008CE1 RID: 36065 RVA: 0x00132780 File Offset: 0x00130980
		private void ChangeJocker(GuildCardMatchNtf ntf)
		{
			this.wattingPTC = false;
			this.m_matchResult = ntf.result;
			bool flag = this.m_changeount > 0U;
			if (flag)
			{
				this.m_changeount -= 1U;
			}
			uint oldJockerID = this.m_oldJockerID;
			uint newCard = 0U;
			int num = 0;
			int i = 0;
			int count = ntf.cards.Count;
			while (i < count)
			{
				bool flag2 = !this.m_matchJokers.Contains(ntf.cards[i]);
				if (flag2)
				{
					newCard = ntf.cards[i];
					num = this.m_matchJokers.IndexOf(this.m_oldJockerID);
					bool flag3 = num > -1;
					if (flag3)
					{
						this.m_matchJokers[num] = ntf.cards[i];
					}
					break;
				}
				i++;
			}
			bool flag4 = !DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag4)
			{
				DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.ChangeCard(oldJockerID, newCard, num);
				DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.SetGameCount();
			}
		}

		// Token: 0x06008CE2 RID: 36066 RVA: 0x00132888 File Offset: 0x00130A88
		private void JokerSignUpResult(GuildCardMatchNtf ntf)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Sign Up:", ntf.sign_up.ToString(), null, null, null, null);
			this.m_isSignUp = ntf.sign_up;
			this.m_JokerKingTimes = ntf.sign_up_num;
			bool flag = DlgBase<JokerKingMainView, JokerKingMainBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<JokerKingMainView, JokerKingMainBehavior>.singleton.RefreshData();
			}
		}

		// Token: 0x06008CE3 RID: 36067 RVA: 0x001328EC File Offset: 0x00130AEC
		private void JokerKingQueryResult(GuildCardMatchNtf ntf)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("ntf Query:", ntf.state.ToString(), ntf.isbegin.ToString(), ntf.sign_up.ToString(), null, null);
			this.m_matchState = ntf.state;
			this.m_isBegion = ntf.isbegin;
			this.m_isSignUp = ntf.sign_up;
			bool flag = DlgBase<JokerKingMainView, JokerKingMainBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<JokerKingMainView, JokerKingMainBehavior>.singleton.RefreshData();
			}
		}

		// Token: 0x06008CE4 RID: 36068 RVA: 0x0013297C File Offset: 0x00130B7C
		public void SetBestJocker(List<uint> jockers, string name)
		{
			this.m_matchBestJockers.Clear();
			this.m_matchBestJockers.AddRange(jockers);
			this.m_matchBestName = name;
			bool flag = !DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.SetupBestCard();
			}
		}

		// Token: 0x06008CE5 RID: 36069 RVA: 0x001329C8 File Offset: 0x00130BC8
		private void ClearBestJoker()
		{
			this.m_matchBestJockers.Clear();
			this.m_matchBestName = string.Empty;
			bool flag = !DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<JokerKingMatchView, XGuildJokerBehaviour>.singleton.SetupBestCard();
			}
		}

		// Token: 0x06008CE6 RID: 36070 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04002D8A RID: 11658
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XJokerKingDocument");

		// Token: 0x04002D8B RID: 11659
		public static XTableAsyncLoader AsynLoader = new XTableAsyncLoader();

		// Token: 0x04002D8C RID: 11660
		public static PokerTournamentReward JokerTournamed = new PokerTournamentReward();

		// Token: 0x04002D8D RID: 11661
		private CardMatchState m_matchState;

		// Token: 0x04002D8E RID: 11662
		private double m_timeLeft;

		// Token: 0x04002D8F RID: 11663
		private uint m_changeount;

		// Token: 0x04002D90 RID: 11664
		private uint m_matchRound;

		// Token: 0x04002D91 RID: 11665
		private uint m_matchResult;

		// Token: 0x04002D92 RID: 11666
		private uint m_matchJockerStore;

		// Token: 0x04002D93 RID: 11667
		private uint m_oldJockerID = 0U;

		// Token: 0x04002D94 RID: 11668
		private string m_matchBestName = string.Empty;

		// Token: 0x04002D95 RID: 11669
		private List<uint> m_matchJokers = new List<uint>();

		// Token: 0x04002D96 RID: 11670
		private List<uint> m_matchBestJockers = new List<uint>();

		// Token: 0x04002D97 RID: 11671
		private List<ItemBrief> m_matchItems = new List<ItemBrief>();

		// Token: 0x04002D98 RID: 11672
		private List<string> m_matchRankName = new List<string>();

		// Token: 0x04002D99 RID: 11673
		private List<int> m_matchRankScore = new List<int>();

		// Token: 0x04002D9A RID: 11674
		private uint JokerToken;

		// Token: 0x04002D9B RID: 11675
		private bool m_isBegion = false;

		// Token: 0x04002D9C RID: 11676
		private bool m_isSignUp = false;

		// Token: 0x04002D9D RID: 11677
		private bool m_isCanBegion = false;

		// Token: 0x04002D9E RID: 11678
		private uint m_JokerKingTimes = 0U;

		// Token: 0x04002D9F RID: 11679
		public bool wattingPTC = false;

		// Token: 0x04002DA0 RID: 11680
		private bool m_bAvaiableIconWhenShow = false;
	}
}
