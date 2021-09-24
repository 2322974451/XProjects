using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildJockerMatchDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildJockerMatchDocument.uuID;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.SendJokerMatchQuery();
			}
		}

		public XGuildJockerMatchStep MatchStep
		{
			get
			{
				return this.m_MatchStep;
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

		public double BeginTime
		{
			get
			{
				return this.m_BeginTime;
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
				bool flag = this.m_bAvaiableIconWhenShow != value;
				if (flag)
				{
					this.m_bAvaiableIconWhenShow = value;
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildRelax_JokerMatch, true);
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildRelax_JokerMatch, true);
				}
			}
		}

		public void SendJokerMatchRank()
		{
			PtcC2M_GuildCardRankReq ptcC2M_GuildCardRankReq = new PtcC2M_GuildCardRankReq();
			ptcC2M_GuildCardRankReq.Data.type = 2U;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_GuildCardRankReq);
		}

		public void ReceiveJokerRank(List<string> names, List<int> scores)
		{
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
			bool flag3 = DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (flag3)
			{
				DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.SetRankInfo(this.m_matchRankName.Count);
				DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.RefreshSelfRank(score, rank);
			}
		}

		public void SendJokerMatchQuery()
		{
			this.SendGuildJokerMatchInfo(CardMatchOp.CardMatch_Query, 0U);
		}

		public void SendJokerMatchBegion()
		{
			this.SendGuildJokerMatchInfo(CardMatchOp.CardMatch_Begin, 0U);
		}

		public void SendReqJokerMatchJoin()
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("GUILD_JOCKER_MATCH_REQ_JOIN"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnReqJokerMatchJoin));
		}

		private bool OnReqJokerMatchJoin(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this.SendJokerMatchJoin();
			return true;
		}

		public void SendJokerMatchJoin()
		{
			this.SendGuildJokerMatchInfo(CardMatchOp.CardMatch_Add, 0U);
		}

		public void SendJokerMatchExit()
		{
			bool flag = this.m_matchState == CardMatchState.CardMatch_StateEnd;
			if (!flag)
			{
				this.SendGuildJokerMatchInfo(CardMatchOp.CardMatch_Del, 0U);
			}
		}

		public void SetJokerMatchRoundOver()
		{
			this.SendGuildJokerMatchInfo(CardMatchOp.CardMatch_RoundEnd, 0U);
		}

		public void SendGuildCardMatchChange(uint card)
		{
			bool flag = this.wattingPTC;
			if (!flag)
			{
				this.wattingPTC = true;
				this.SendGuildJokerMatchInfo(CardMatchOp.CardMatch_RoundChange, card);
			}
		}

		private void SendGuildJokerMatchInfo(CardMatchOp op, uint card = 0U)
		{
			PtcC2M_GuildCardMatchReq ptcC2M_GuildCardMatchReq = new PtcC2M_GuildCardMatchReq();
			ptcC2M_GuildCardMatchReq.Data.op = op;
			ptcC2M_GuildCardMatchReq.Data.card = card;
			this.m_oldJockerID = card;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_GuildCardMatchReq);
		}

		public void ReceiveGuildJokerMatchInfo(GuildCardMatchNtf ntf)
		{
			switch (ntf.op)
			{
			case CardMatchOp.CardMatch_Begin:
				this.ShowJokerBegin();
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
			}
		}

		private void JokerMatchOver()
		{
			this.m_matchJokers.Clear();
			this.m_timeLeft = 0.0;
			this.m_matchState = CardMatchState.CardMatch_StateEnd;
			bool flag = !DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.RefreshWhenShow();
			}
		}

		private void ShowJokerBegin()
		{
			this.m_isBegion = true;
			this.m_isCanBegion = true;
			this.m_BeginTime = 0.0;
			bool flag = DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>.singleton.Refresh(XSysDefine.XSys_GuildRelax_JokerMatch);
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
			this.m_matchRound = (uint)((long)XSingleton<XGlobalConfig>.singleton.GetInt("CardMatchRound") - (long)((ulong)((ntf.round == uint.MaxValue) ? 0U : (ntf.round + 1U))));
			this.m_matchJokers.Clear();
			this.m_matchJokers.AddRange(ntf.cards);
		}

		private void ShowJokerJoin(GuildCardMatchNtf ntf)
		{
			this.SetMatchData(ntf);
			this.ClearBestJoker();
			bool flag = !DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
		}

		private void ShowMatchBegin(GuildCardMatchNtf ntf)
		{
			this.SetMatchData(ntf);
			this.ClearBestJoker();
			bool flag = !DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.RefreshWhenShow();
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
			this.m_isCanBegion = ntf.iscanbegin;
			this.m_timeLeft = ntf.timeleft;
			bool flag = DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>.singleton.Refresh(XSysDefine.XSys_GuildRelax_JokerMatch);
				DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>.singleton.RefreshRedPoint(XSysDefine.XSys_GuildRelax_JokerMatch);
			}
		}

		private void ShowWaittingJocker(GuildCardMatchNtf ntf)
		{
			this.m_timeLeft = ntf.timeleft + 1U;
			this.m_matchState = ntf.state;
			this.m_matchJokers.Clear();
			bool flag = !DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.RefreshWhenShow();
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
			bool flag3 = !DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag3)
			{
				DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.RefreshWhenShow();
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
			bool flag4 = !DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag4)
			{
				DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.ChangeCard(oldJockerID, newCard, num);
				DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.SetGameCount();
			}
		}

		public void SetBestJocker(List<uint> jockers, string name)
		{
			this.m_matchBestJockers.Clear();
			this.m_matchBestJockers.AddRange(jockers);
			this.m_matchBestName = name;
			bool flag = !DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.SetupBestCard();
			}
		}

		private void ClearBestJoker()
		{
			this.m_matchBestJockers.Clear();
			this.m_matchBestName = string.Empty;
			bool flag = !DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XGuildJockerMatchView, XGuildJokerBehaviour>.singleton.SetupBestCard();
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildJokerMatchDocument");

		private bool m_bAvaiableIconWhenShow = false;

		private XGuildJockerMatchStep m_MatchStep = XGuildJockerMatchStep.BeforeGame;

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

		private List<string> m_matchRankName = new List<string>();

		private List<int> m_matchRankScore = new List<int>();

		private uint JokerToken;

		private bool m_isBegion = false;

		private bool m_isCanBegion = false;

		private double m_BeginTime = 0.0;

		public bool wattingPTC = false;

		private List<ItemBrief> m_matchItems = new List<ItemBrief>();
	}
}
