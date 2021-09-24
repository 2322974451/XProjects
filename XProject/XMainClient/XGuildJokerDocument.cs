using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildJokerDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildJokerDocument.uuID;
			}
		}

		public uint CardResult { get; set; }

		public uint CardStore { get; set; }

		public int GameCount { get; set; }

		public int ChangeCount { get; set; }

		public int BuyChangeCount { get; set; }

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

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildJokerDocument.AsyncLoader.AddTask("Table/CardReward", XGuildJokerDocument._CardRewardTable, false);
			XGuildJokerDocument.AsyncLoader.AddTask("Table/CardStore", XGuildJokerDocument._CardStoreTable, false);
			XGuildJokerDocument.AsyncLoader.Execute(callback);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public override void OnEnterScene()
		{
			base.OnEnterScene();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this.QueryGameCount();
			}
		}

		public void QueryGameCount()
		{
			RpcC2G_QueryGuildCard rpc = new RpcC2G_QueryGuildCard();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void SendJokerRank(uint type)
		{
			PtcC2M_GuildCardRankReq ptcC2M_GuildCardRankReq = new PtcC2M_GuildCardRankReq();
			ptcC2M_GuildCardRankReq.Data.type = type;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_GuildCardRankReq);
		}

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

		public void SendGameEnd()
		{
			RpcC2G_EndGuildCard rpc = new RpcC2G_EndGuildCard();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.WaitRpc = false;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildJokerDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static CardRewardTable _CardRewardTable = new CardRewardTable();

		public static CardStoreTable _CardStoreTable = new CardStoreTable();

		public List<uint> CurrentCard = new List<uint>();

		public List<uint> BestCard = new List<uint>();

		public string BestName;

		public uint JokerToken;

		public bool WaitRpc = false;

		private float guildJokerStartTime = 0f;

		private List<string> m_RankNames;

		private List<int> m_RankScores;
	}
}
