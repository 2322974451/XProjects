using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XJokerKingDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XJokerKingDocument.uuID;
			}
		}

		public uint JokerKingTimes
		{
			get
			{
				return this.m_JokerKingTimes;
			}
		}

		public CardMatchState MatchState
		{
			get
			{
				return this.m_matchState;
			}
		}

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

		public uint ChangeCount
		{
			get
			{
				return this.m_changeount;
			}
		}

		public uint MatchRound
		{
			get
			{
				return this.m_matchRound;
			}
		}

		public uint MatchResult
		{
			get
			{
				return this.m_matchResult;
			}
		}

		public List<uint> MatchJockers
		{
			get
			{
				return this.m_matchJokers;
			}
		}

		public uint MatchJockerStore
		{
			get
			{
				return this.m_matchJockerStore;
			}
		}

		public List<uint> MatchBestJockers
		{
			get
			{
				return this.m_matchBestJockers;
			}
		}

		public string MatchBestJockerName
		{
			get
			{
				return this.m_matchBestName;
			}
		}

		public List<string> MatchRankNames
		{
			get
			{
				return this.m_matchRankName;
			}
		}

		public List<int> MatchRankScores
		{
			get
			{
				return this.m_matchRankScore;
			}
		}

		public List<ItemBrief> MatchItems
		{
			get
			{
				return this.m_matchItems;
			}
		}

		public bool IsBegin
		{
			get
			{
				return this.m_isBegion;
			}
		}

		public bool IsCanBegin
		{
			get
			{
				return this.m_isCanBegion;
			}
		}

		public bool IsSignUp
		{
			get
			{
				return this.m_isSignUp;
			}
		}

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

		public static void Execute(OnLoadedCallback callback = null)
		{
			XJokerKingDocument.AsynLoader.AddTask("Table/PokerTournamentReward", XJokerKingDocument.JokerTournamed, false);
			XJokerKingDocument.AsynLoader.Execute(callback);
		}

		public void JokerKingMatchQuery()
		{
			this.SendJokerKingMsg(CardMatchOp.CardMatch_Query, 0U);
		}

		public void JokerKingMatchAdd()
		{
			this.SendJokerKingMsg(CardMatchOp.CardMatch_Add, 0U);
		}

		public void JokerKingMatchExit()
		{
			this.SendJokerKingMsg(CardMatchOp.CardMatch_Del, 0U);
		}

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

		public void JokerKingRoundChange(uint card)
		{
			bool flag = this.wattingPTC;
			if (!flag)
			{
				this.wattingPTC = true;
				this.SendJokerKingMsg(CardMatchOp.CardMatch_RoundChange, card);
			}
		}

		private void SendJokerKingMsg(CardMatchOp op, uint card = 0U)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Send JokerKing Message:", op.ToString(), null, null, null, null);
			PtcC2M_PokerTournamentReq ptcC2M_PokerTournamentReq = new PtcC2M_PokerTournamentReq();
			ptcC2M_PokerTournamentReq.Data.op = op;
			ptcC2M_PokerTournamentReq.Data.card = card;
			this.m_oldJockerID = card;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_PokerTournamentReq);
		}

		public void JokerKingRoundOver()
		{
			PtcC2M_PokerTournamentReq ptcC2M_PokerTournamentReq = new PtcC2M_PokerTournamentReq();
			ptcC2M_PokerTournamentReq.Data.op = CardMatchOp.CardMatch_RoundEnd;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_PokerTournamentReq);
		}

		public void SendJokerMatchRank()
		{
			PtcC2M_GuildCardRankReq ptcC2M_GuildCardRankReq = new PtcC2M_GuildCardRankReq();
			ptcC2M_GuildCardRankReq.Data.type = 3U;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_GuildCardRankReq);
		}

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

		private void JokerBegion()
		{
			this.m_matchState = CardMatchState.CardMatch_StateBegin;
			bool flag = !DlgBase<JokerKingMainView, JokerKingMainBehavior>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<JokerKingMainView, JokerKingMainBehavior>.singleton.RefreshData();
			}
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XJokerKingDocument");

		public static XTableAsyncLoader AsynLoader = new XTableAsyncLoader();

		public static PokerTournamentReward JokerTournamed = new PokerTournamentReward();

		private CardMatchState m_matchState;

		private double m_timeLeft;

		private uint m_changeount;

		private uint m_matchRound;

		private uint m_matchResult;

		private uint m_matchJockerStore;

		private uint m_oldJockerID = 0U;

		private string m_matchBestName = string.Empty;

		private List<uint> m_matchJokers = new List<uint>();

		private List<uint> m_matchBestJockers = new List<uint>();

		private List<ItemBrief> m_matchItems = new List<ItemBrief>();

		private List<string> m_matchRankName = new List<string>();

		private List<int> m_matchRankScore = new List<int>();

		private uint JokerToken;

		private bool m_isBegion = false;

		private bool m_isSignUp = false;

		private bool m_isCanBegion = false;

		private uint m_JokerKingTimes = 0U;

		public bool wattingPTC = false;

		private bool m_bAvaiableIconWhenShow = false;
	}
}
