using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009A6 RID: 2470
	internal class XGuildJokerDocument : XDocComponent
	{
		// Token: 0x17002D25 RID: 11557
		// (get) Token: 0x0600954C RID: 38220 RVA: 0x00165018 File Offset: 0x00163218
		public override uint ID
		{
			get
			{
				return XGuildJokerDocument.uuID;
			}
		}

		// Token: 0x17002D26 RID: 11558
		// (get) Token: 0x0600954D RID: 38221 RVA: 0x0016502F File Offset: 0x0016322F
		// (set) Token: 0x0600954E RID: 38222 RVA: 0x00165037 File Offset: 0x00163237
		public uint CardResult { get; set; }

		// Token: 0x17002D27 RID: 11559
		// (get) Token: 0x0600954F RID: 38223 RVA: 0x00165040 File Offset: 0x00163240
		// (set) Token: 0x06009550 RID: 38224 RVA: 0x00165048 File Offset: 0x00163248
		public uint CardStore { get; set; }

		// Token: 0x17002D28 RID: 11560
		// (get) Token: 0x06009551 RID: 38225 RVA: 0x00165051 File Offset: 0x00163251
		// (set) Token: 0x06009552 RID: 38226 RVA: 0x00165059 File Offset: 0x00163259
		public int GameCount { get; set; }

		// Token: 0x17002D29 RID: 11561
		// (get) Token: 0x06009553 RID: 38227 RVA: 0x00165062 File Offset: 0x00163262
		// (set) Token: 0x06009554 RID: 38228 RVA: 0x0016506A File Offset: 0x0016326A
		public int ChangeCount { get; set; }

		// Token: 0x17002D2A RID: 11562
		// (get) Token: 0x06009555 RID: 38229 RVA: 0x00165073 File Offset: 0x00163273
		// (set) Token: 0x06009556 RID: 38230 RVA: 0x0016507B File Offset: 0x0016327B
		public int BuyChangeCount { get; set; }

		// Token: 0x17002D2B RID: 11563
		// (get) Token: 0x06009557 RID: 38231 RVA: 0x00165084 File Offset: 0x00163284
		public List<string> RankNames
		{
			get
			{
				bool flag = this.m_RankNames == null;
				if (flag)
				{
					this.m_RankNames = new List<string>();
				}
				return this.m_RankNames;
			}
		}

		// Token: 0x17002D2C RID: 11564
		// (get) Token: 0x06009558 RID: 38232 RVA: 0x001650B4 File Offset: 0x001632B4
		public List<int> RankScores
		{
			get
			{
				bool flag = this.m_RankScores == null;
				if (flag)
				{
					this.m_RankScores = new List<int>();
				}
				return this.m_RankScores;
			}
		}

		// Token: 0x06009559 RID: 38233 RVA: 0x001650E6 File Offset: 0x001632E6
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildJokerDocument.AsyncLoader.AddTask("Table/CardReward", XGuildJokerDocument._CardRewardTable, false);
			XGuildJokerDocument.AsyncLoader.AddTask("Table/CardStore", XGuildJokerDocument._CardStoreTable, false);
			XGuildJokerDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600955A RID: 38234 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600955B RID: 38235 RVA: 0x00165124 File Offset: 0x00163324
		public override void OnEnterScene()
		{
			base.OnEnterScene();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this.QueryGameCount();
			}
		}

		// Token: 0x0600955C RID: 38236 RVA: 0x00165158 File Offset: 0x00163358
		public void QueryGameCount()
		{
			RpcC2G_QueryGuildCard rpc = new RpcC2G_QueryGuildCard();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600955D RID: 38237 RVA: 0x00165178 File Offset: 0x00163378
		public void SendJokerRank(uint type)
		{
			PtcC2M_GuildCardRankReq ptcC2M_GuildCardRankReq = new PtcC2M_GuildCardRankReq();
			ptcC2M_GuildCardRankReq.Data.type = type;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_GuildCardRankReq);
		}

		// Token: 0x0600955E RID: 38238 RVA: 0x001651A8 File Offset: 0x001633A8
		public void ReceiveJockerRank(List<string> names, List<int> scores)
		{
			this.m_RankNames = names;
			this.m_RankScores = scores;
			bool flag = DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetRankData(names.Count);
			}
		}

		// Token: 0x0600955F RID: 38239 RVA: 0x001651E4 File Offset: 0x001633E4
		public void SendStartGame()
		{
			bool flag = Time.time - this.guildJokerStartTime < 2f;
			if (!flag)
			{
				this.guildJokerStartTime = Time.time;
				RpcC2G_StartGuildCard rpc = new RpcC2G_StartGuildCard();
				XSingleton<XClientNetwork>.singleton.Send(rpc);
			}
		}

		// Token: 0x06009560 RID: 38240 RVA: 0x00165228 File Offset: 0x00163428
		public void SendChangeCard(uint card)
		{
			bool waitRpc = this.WaitRpc;
			if (!waitRpc)
			{
				this.WaitRpc = true;
				RpcC2G_ChangeGuildCard rpcC2G_ChangeGuildCard = new RpcC2G_ChangeGuildCard();
				rpcC2G_ChangeGuildCard.oArg.card = card;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChangeGuildCard);
			}
		}

		// Token: 0x06009561 RID: 38241 RVA: 0x00165268 File Offset: 0x00163468
		public void SendGameEnd()
		{
			RpcC2G_EndGuildCard rpc = new RpcC2G_EndGuildCard();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009562 RID: 38242 RVA: 0x00165288 File Offset: 0x00163488
		public void SetGameCount(uint gameCount, uint changeCount, uint buyChangeCount)
		{
			this.GameCount = (int)gameCount;
			this.ChangeCount = (int)changeCount;
			this.BuyChangeCount = (int)buyChangeCount;
			XGuildRelaxGameDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRelaxGameDocument>(XGuildRelaxGameDocument.uuID);
			specificDocument.RefreshRedPoint();
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildRelax_Joker, true);
			bool flag = !DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetGameCount();
			}
		}

		// Token: 0x06009563 RID: 38243 RVA: 0x001652F0 File Offset: 0x001634F0
		public void ShowCard(List<uint> card, uint result, uint store)
		{
			this.CardResult = result;
			this.CardStore = store;
			this.GameCount = Math.Max(0, this.GameCount - 1);
			this.CurrentCard.Clear();
			for (int i = 0; i < card.Count; i++)
			{
				this.CurrentCard.Add(card[i]);
			}
			XGuildRelaxGameDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRelaxGameDocument>(XGuildRelaxGameDocument.uuID);
			specificDocument.RefreshRedPoint();
			bool flag = !DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.RefreshCard();
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetCurrentReward();
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetGameTipStatus(true);
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetGameCount();
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetCardStore();
				bool flag2 = this.CardResult != 8U;
				if (flag2)
				{
					DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetButtonTip("GET_REWARD");
				}
				else
				{
					DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetButtonTip("END_GAME");
				}
			}
		}

		// Token: 0x06009564 RID: 38244 RVA: 0x001653F0 File Offset: 0x001635F0
		public void ChangeCard(uint oldCard, uint newCard, uint result)
		{
			this.WaitRpc = false;
			bool flag = this.ChangeCount != 0;
			if (flag)
			{
				this.ChangeCount--;
			}
			else
			{
				this.BuyChangeCount++;
			}
			this.CardResult = result;
			int cardNum = 0;
			for (int i = 0; i < this.CurrentCard.Count; i++)
			{
				bool flag2 = this.CurrentCard[i] != oldCard;
				if (!flag2)
				{
					this.CurrentCard[i] = newCard;
					cardNum = i;
				}
			}
			bool flag3 = !DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag3)
			{
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.ChangeCard(oldCard, newCard, cardNum);
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetGameCount();
			}
		}

		// Token: 0x06009565 RID: 38245 RVA: 0x001654B4 File Offset: 0x001636B4
		public void EndCardGame(uint result)
		{
			bool flag = DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.RefreshRank();
				bool flag2 = this.CardResult != 8U;
				if (flag2)
				{
					XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/pukeshenli", true, AudioChannel.Action);
					DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.JokerStatus(2);
					XSingleton<XTimerMgr>.singleton.KillTimer(this.JokerToken);
					this.JokerToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.ResetJokerStatusCb, null);
				}
				else
				{
					XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/pukeshibai", true, AudioChannel.Action);
					DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.JokerStatus(3);
					XSingleton<XTimerMgr>.singleton.KillTimer(this.JokerToken);
					this.JokerToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.ResetJokerStatusCb, null);
				}
			}
			this.CurrentCard.Clear();
			this.CardResult = 8U;
			this.CardStore = 5U;
			bool flag3 = !DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag3)
			{
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.ClearCard();
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetGameTipStatus(false);
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetButtonTip("START_GAME");
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetCurrentReward();
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetCardStore();
			}
		}

		// Token: 0x06009566 RID: 38246 RVA: 0x00165600 File Offset: 0x00163800
		public void SetBestCard(List<uint> card, string name)
		{
			this.BestCard.Clear();
			for (int i = 0; i < card.Count; i++)
			{
				this.BestCard.Add(card[i]);
			}
			this.BestName = name;
			bool flag = !DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetupBestCard();
			}
		}

		// Token: 0x06009567 RID: 38247 RVA: 0x00165669 File Offset: 0x00163869
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.WaitRpc = false;
		}

		// Token: 0x0400328E RID: 12942
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildJokerDocument");

		// Token: 0x0400328F RID: 12943
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003290 RID: 12944
		public static CardRewardTable _CardRewardTable = new CardRewardTable();

		// Token: 0x04003291 RID: 12945
		public static CardStoreTable _CardStoreTable = new CardStoreTable();

		// Token: 0x04003292 RID: 12946
		public List<uint> CurrentCard = new List<uint>();

		// Token: 0x04003298 RID: 12952
		public List<uint> BestCard = new List<uint>();

		// Token: 0x04003299 RID: 12953
		public string BestName;

		// Token: 0x0400329A RID: 12954
		public uint JokerToken;

		// Token: 0x0400329B RID: 12955
		public bool WaitRpc = false;

		// Token: 0x0400329C RID: 12956
		private float guildJokerStartTime = 0f;

		// Token: 0x0400329D RID: 12957
		private List<string> m_RankNames;

		// Token: 0x0400329E RID: 12958
		private List<int> m_RankScores;
	}
}
