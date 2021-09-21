using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000932 RID: 2354
	internal class XGuildJockerMatchDocument : XDocComponent
	{
		// Token: 0x17002BD3 RID: 11219
		// (get) Token: 0x06008E0D RID: 36365 RVA: 0x00139B94 File Offset: 0x00137D94
		public override uint ID
		{
			get
			{
				return XGuildJockerMatchDocument.uuID;
			}
		}

		// Token: 0x06008E0E RID: 36366 RVA: 0x00139BAC File Offset: 0x00137DAC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.SendJokerMatchQuery();
			}
		}

		// Token: 0x17002BD4 RID: 11220
		// (get) Token: 0x06008E0F RID: 36367 RVA: 0x00139BD0 File Offset: 0x00137DD0
		public XGuildJockerMatchStep MatchStep
		{
			get
			{
				return this.m_MatchStep;
			}
		}

		// Token: 0x17002BD5 RID: 11221
		// (get) Token: 0x06008E10 RID: 36368 RVA: 0x00139BE8 File Offset: 0x00137DE8
		public CardMatchState MatchState
		{
			get
			{
				return this.m_matchState;
			}
		}

		// Token: 0x17002BD6 RID: 11222
		// (get) Token: 0x06008E11 RID: 36369 RVA: 0x00139C00 File Offset: 0x00137E00
		// (set) Token: 0x06008E12 RID: 36370 RVA: 0x00139C18 File Offset: 0x00137E18
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

		// Token: 0x17002BD7 RID: 11223
		// (get) Token: 0x06008E13 RID: 36371 RVA: 0x00139C24 File Offset: 0x00137E24
		public uint ChangeCount
		{
			get
			{
				return this.m_changeount;
			}
		}

		// Token: 0x17002BD8 RID: 11224
		// (get) Token: 0x06008E14 RID: 36372 RVA: 0x00139C3C File Offset: 0x00137E3C
		public uint MatchRound
		{
			get
			{
				return this.m_matchRound;
			}
		}

		// Token: 0x17002BD9 RID: 11225
		// (get) Token: 0x06008E15 RID: 36373 RVA: 0x00139C54 File Offset: 0x00137E54
		public uint MatchResult
		{
			get
			{
				return this.m_matchResult;
			}
		}

		// Token: 0x17002BDA RID: 11226
		// (get) Token: 0x06008E16 RID: 36374 RVA: 0x00139C6C File Offset: 0x00137E6C
		public List<uint> MatchJockers
		{
			get
			{
				return this.m_matchJokers;
			}
		}

		// Token: 0x17002BDB RID: 11227
		// (get) Token: 0x06008E17 RID: 36375 RVA: 0x00139C84 File Offset: 0x00137E84
		public uint MatchJockerStore
		{
			get
			{
				return this.m_matchJockerStore;
			}
		}

		// Token: 0x17002BDC RID: 11228
		// (get) Token: 0x06008E18 RID: 36376 RVA: 0x00139C9C File Offset: 0x00137E9C
		public List<uint> MatchBestJockers
		{
			get
			{
				return this.m_matchBestJockers;
			}
		}

		// Token: 0x17002BDD RID: 11229
		// (get) Token: 0x06008E19 RID: 36377 RVA: 0x00139CB4 File Offset: 0x00137EB4
		public string MatchBestJockerName
		{
			get
			{
				return this.m_matchBestName;
			}
		}

		// Token: 0x17002BDE RID: 11230
		// (get) Token: 0x06008E1A RID: 36378 RVA: 0x00139CCC File Offset: 0x00137ECC
		public List<string> MatchRankNames
		{
			get
			{
				return this.m_matchRankName;
			}
		}

		// Token: 0x17002BDF RID: 11231
		// (get) Token: 0x06008E1B RID: 36379 RVA: 0x00139CE4 File Offset: 0x00137EE4
		public List<int> MatchRankScores
		{
			get
			{
				return this.m_matchRankScore;
			}
		}

		// Token: 0x17002BE0 RID: 11232
		// (get) Token: 0x06008E1C RID: 36380 RVA: 0x00139CFC File Offset: 0x00137EFC
		public List<ItemBrief> MatchItems
		{
			get
			{
				return this.m_matchItems;
			}
		}

		// Token: 0x17002BE1 RID: 11233
		// (get) Token: 0x06008E1D RID: 36381 RVA: 0x00139D14 File Offset: 0x00137F14
		public bool IsBegin
		{
			get
			{
				return this.m_isBegion;
			}
		}

		// Token: 0x17002BE2 RID: 11234
		// (get) Token: 0x06008E1E RID: 36382 RVA: 0x00139D2C File Offset: 0x00137F2C
		public bool IsCanBegin
		{
			get
			{
				return this.m_isCanBegion;
			}
		}

		// Token: 0x17002BE3 RID: 11235
		// (get) Token: 0x06008E1F RID: 36383 RVA: 0x00139D44 File Offset: 0x00137F44
		public double BeginTime
		{
			get
			{
				return this.m_BeginTime;
			}
		}

		// Token: 0x17002BE4 RID: 11236
		// (get) Token: 0x06008E21 RID: 36385 RVA: 0x00139DA8 File Offset: 0x00137FA8
		// (set) Token: 0x06008E20 RID: 36384 RVA: 0x00139D5C File Offset: 0x00137F5C
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

		// Token: 0x06008E22 RID: 36386 RVA: 0x00139DC0 File Offset: 0x00137FC0
		public void SendJokerMatchRank()
		{
			PtcC2M_GuildCardRankReq ptcC2M_GuildCardRankReq = new PtcC2M_GuildCardRankReq();
			ptcC2M_GuildCardRankReq.Data.type = 2U;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_GuildCardRankReq);
		}

		// Token: 0x06008E23 RID: 36387 RVA: 0x00139DF0 File Offset: 0x00137FF0
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

		// Token: 0x06008E24 RID: 36388 RVA: 0x00139EBF File Offset: 0x001380BF
		public void SendJokerMatchQuery()
		{
			this.SendGuildJokerMatchInfo(CardMatchOp.CardMatch_Query, 0U);
		}

		// Token: 0x06008E25 RID: 36389 RVA: 0x00139ECB File Offset: 0x001380CB
		public void SendJokerMatchBegion()
		{
			this.SendGuildJokerMatchInfo(CardMatchOp.CardMatch_Begin, 0U);
		}

		// Token: 0x06008E26 RID: 36390 RVA: 0x00139ED7 File Offset: 0x001380D7
		public void SendReqJokerMatchJoin()
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("GUILD_JOCKER_MATCH_REQ_JOIN"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnReqJokerMatchJoin));
		}

		// Token: 0x06008E27 RID: 36391 RVA: 0x00139F10 File Offset: 0x00138110
		private bool OnReqJokerMatchJoin(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this.SendJokerMatchJoin();
			return true;
		}

		// Token: 0x06008E28 RID: 36392 RVA: 0x00139F37 File Offset: 0x00138137
		public void SendJokerMatchJoin()
		{
			this.SendGuildJokerMatchInfo(CardMatchOp.CardMatch_Add, 0U);
		}

		// Token: 0x06008E29 RID: 36393 RVA: 0x00139F44 File Offset: 0x00138144
		public void SendJokerMatchExit()
		{
			bool flag = this.m_matchState == CardMatchState.CardMatch_StateEnd;
			if (!flag)
			{
				this.SendGuildJokerMatchInfo(CardMatchOp.CardMatch_Del, 0U);
			}
		}

		// Token: 0x06008E2A RID: 36394 RVA: 0x00139F6A File Offset: 0x0013816A
		public void SetJokerMatchRoundOver()
		{
			this.SendGuildJokerMatchInfo(CardMatchOp.CardMatch_RoundEnd, 0U);
		}

		// Token: 0x06008E2B RID: 36395 RVA: 0x00139F78 File Offset: 0x00138178
		public void SendGuildCardMatchChange(uint card)
		{
			bool flag = this.wattingPTC;
			if (!flag)
			{
				this.wattingPTC = true;
				this.SendGuildJokerMatchInfo(CardMatchOp.CardMatch_RoundChange, card);
			}
		}

		// Token: 0x06008E2C RID: 36396 RVA: 0x00139FA4 File Offset: 0x001381A4
		private void SendGuildJokerMatchInfo(CardMatchOp op, uint card = 0U)
		{
			PtcC2M_GuildCardMatchReq ptcC2M_GuildCardMatchReq = new PtcC2M_GuildCardMatchReq();
			ptcC2M_GuildCardMatchReq.Data.op = op;
			ptcC2M_GuildCardMatchReq.Data.card = card;
			this.m_oldJockerID = card;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_GuildCardMatchReq);
		}

		// Token: 0x06008E2D RID: 36397 RVA: 0x00139FE8 File Offset: 0x001381E8
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

		// Token: 0x06008E2E RID: 36398 RVA: 0x0013A098 File Offset: 0x00138298
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

		// Token: 0x06008E2F RID: 36399 RVA: 0x0013A0E8 File Offset: 0x001382E8
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

		// Token: 0x06008E30 RID: 36400 RVA: 0x0013A134 File Offset: 0x00138334
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

		// Token: 0x06008E31 RID: 36401 RVA: 0x0013A1EC File Offset: 0x001383EC
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

		// Token: 0x06008E32 RID: 36402 RVA: 0x0013A228 File Offset: 0x00138428
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

		// Token: 0x06008E33 RID: 36403 RVA: 0x0013A264 File Offset: 0x00138464
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

		// Token: 0x06008E34 RID: 36404 RVA: 0x0013A2A8 File Offset: 0x001384A8
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

		// Token: 0x06008E35 RID: 36405 RVA: 0x0013A318 File Offset: 0x00138518
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

		// Token: 0x06008E36 RID: 36406 RVA: 0x0013A36C File Offset: 0x0013856C
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

		// Token: 0x06008E37 RID: 36407 RVA: 0x0013A498 File Offset: 0x00138698
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

		// Token: 0x06008E38 RID: 36408 RVA: 0x0013A5A0 File Offset: 0x001387A0
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

		// Token: 0x06008E39 RID: 36409 RVA: 0x0013A5EC File Offset: 0x001387EC
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

		// Token: 0x04002E45 RID: 11845
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildJokerMatchDocument");

		// Token: 0x04002E46 RID: 11846
		private bool m_bAvaiableIconWhenShow = false;

		// Token: 0x04002E47 RID: 11847
		private XGuildJockerMatchStep m_MatchStep = XGuildJockerMatchStep.BeforeGame;

		// Token: 0x04002E48 RID: 11848
		private CardMatchState m_matchState;

		// Token: 0x04002E49 RID: 11849
		private double m_timeLeft;

		// Token: 0x04002E4A RID: 11850
		private uint m_changeount;

		// Token: 0x04002E4B RID: 11851
		private uint m_matchRound;

		// Token: 0x04002E4C RID: 11852
		private uint m_matchResult;

		// Token: 0x04002E4D RID: 11853
		private uint m_matchJockerStore;

		// Token: 0x04002E4E RID: 11854
		private uint m_oldJockerID = 0U;

		// Token: 0x04002E4F RID: 11855
		private string m_matchBestName = string.Empty;

		// Token: 0x04002E50 RID: 11856
		private List<uint> m_matchJokers = new List<uint>();

		// Token: 0x04002E51 RID: 11857
		private List<uint> m_matchBestJockers = new List<uint>();

		// Token: 0x04002E52 RID: 11858
		private List<string> m_matchRankName = new List<string>();

		// Token: 0x04002E53 RID: 11859
		private List<int> m_matchRankScore = new List<int>();

		// Token: 0x04002E54 RID: 11860
		private uint JokerToken;

		// Token: 0x04002E55 RID: 11861
		private bool m_isBegion = false;

		// Token: 0x04002E56 RID: 11862
		private bool m_isCanBegion = false;

		// Token: 0x04002E57 RID: 11863
		private double m_BeginTime = 0.0;

		// Token: 0x04002E58 RID: 11864
		public bool wattingPTC = false;

		// Token: 0x04002E59 RID: 11865
		private List<ItemBrief> m_matchItems = new List<ItemBrief>();
	}
}
