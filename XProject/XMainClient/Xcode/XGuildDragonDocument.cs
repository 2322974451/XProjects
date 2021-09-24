using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildDragonDocument : XDocComponent, IRankSource, IWorldBossBattleSource
	{

		public override uint ID
		{
			get
			{
				return XGuildDragonDocument.uuID;
			}
		}

		public XGuildDragonView GuildDragonView { get; set; }

		public GuildDragonChallengeResultView _GuildDragonChallengeResultView { get; set; }

		public BattleWorldBossHandler BattleHandler { get; set; }

		public bool bCanFight { get; set; }

		public uint EncourageCount
		{
			get
			{
				return this._EncourageCount;
			}
		}

		public XGuildDragonGuildRoleRankList GuildRankList
		{
			get
			{
				return this.m_GuildRankList;
			}
		}

		public XWorldBossDamageRankList PersonRankList
		{
			get
			{
				return this.m_BossDamageRankList;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildDragonDocument.AsyncLoader.AddTask("Table/GuildBossConfig", XGuildDragonDocument._GuildBossConfigReader, false);
			XGuildDragonDocument.AsyncLoader.AddTask("Table/GuildBossReward", XGuildDragonDocument._GuildBossRewardTableReader, false);
			XGuildDragonDocument.AsyncLoader.AddTask("Table/GuildBossRoleReward", XGuildDragonDocument._GuildBossRoleRewardReader, false);
			XGuildDragonDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.bCanFight = false;
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.OnInGuildStateChanged));
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public uint GetEncourageCount(int index)
		{
			bool flag = index == 0;
			uint result;
			if (flag)
			{
				result = this._EncourageCount;
			}
			else
			{
				result = 0U;
			}
			return result;
		}

		public void ReqEncourageTwo()
		{
		}

		protected bool OnInGuildStateChanged(XEventArgs args)
		{
			XInGuildStateChangedEventArgs xinGuildStateChangedEventArgs = args as XInGuildStateChangedEventArgs;
			bool flag = !xinGuildStateChangedEventArgs.bIsEnter;
			if (flag)
			{
				bool flag2 = this.GuildDragonView != null && this.GuildDragonView.IsVisible();
				if (flag2)
				{
					this.GuildDragonView.SetVisible(false, true);
				}
				this.bCanFight = false;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildDragon, true);
			}
			return true;
		}

		public uint GetSceneID()
		{
			return (uint)XSingleton<XGlobalConfig>.singleton.GetInt("GuildBossSceneID");
		}

		public void ReqRankData(RankeType type, bool inFight)
		{
			this.ReqBossRoleRank(inFight);
		}

		public void ReqBossRoleRank(bool inFight)
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.GuildBossRoleRank);
			rpcC2M_ClientQueryRankListNtf.oArg.TimeStamp = this.m_GuildRankList.timeStamp;
			rpcC2M_ClientQueryRankListNtf.oArg.sendPunishData = (inFight ? 1U : 0U);
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			rpcC2M_ClientQueryRankListNtf.oArg.guildid = specificDocument.UID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		public void OnGuildBossRoleRank(ClientQueryRankListRes oRes)
		{
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
			}
			else
			{
				XBaseRankList rankList = this.GetRankList((RankeType)oRes.RankType);
				XRankDocument.ProcessRankListData(oRes.RankList, rankList);
				XRankDocument.ProcessSelfRankData(oRes, rankList);
				bool flag2 = this.GuildDragonView != null;
				if (flag2)
				{
					this.GuildDragonView._SetMyRankFrame(rankList);
				}
				bool flag3 = this.GuildDragonView != null && this.GuildDragonView.IsVisible();
				if (flag3)
				{
					this.GuildDragonView.RefreshGuildRoleRank();
				}
				bool flag4 = this.RankHandler != null && this.RankHandler.PanelObject != null && this.RankHandler.IsVisible();
				if (flag4)
				{
					this.RankHandler.RefreshPage();
				}
			}
		}

		public XBaseRankList GetRankList(RankeType type)
		{
			bool flag = type == RankeType.GuildBossRank;
			XBaseRankList result;
			if (flag)
			{
				result = this.m_GuildRankList;
			}
			else
			{
				bool flag2 = type == RankeType.GuildBossRoleRank;
				if (flag2)
				{
					result = this.m_BossDamageRankList;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		public void ReqWorldBossState()
		{
			RpcC2M_GetWorldBossStateNew rpcC2M_GetWorldBossStateNew = new RpcC2M_GetWorldBossStateNew();
			rpcC2M_GetWorldBossStateNew.oArg.type = 1U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetWorldBossStateNew);
		}

		public void OnGetWorldBossLeftState(GetWorldBossStateRes oRes)
		{
			bool flag = this.GuildDragonView != null && this.GuildDragonView.IsVisible();
			if (flag)
			{
				this.GuildDragonView.SetLeftTime(oRes.TimeLeft, oRes.BossHp);
			}
			bool flag2 = oRes.BossHp <= 0U;
			if (flag2)
			{
				this.bCanFight = false;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildDragon, true);
			}
		}

		public void ReqBattleInfo()
		{
			RpcC2G_ReqGuildBossTimeLeft rpc = new RpcC2G_ReqGuildBossTimeLeft();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetBattleInfo(getguildbosstimeleftRes oRes)
		{
			this._EncourageCount = oRes.addAttrCount;
			bool flag = this.BattleHandler != null && this.BattleHandler.active;
			if (flag)
			{
				this.BattleHandler.SetLeftTime(oRes.timeleft);
			}
		}

		public void ReqEncourage()
		{
			RpcC2G_AddTempAttr rpcC2G_AddTempAttr = new RpcC2G_AddTempAttr();
			rpcC2G_AddTempAttr.oArg.type = 1U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_AddTempAttr);
		}

		public void OnGetEncourage(AddTempAttrRes oRes)
		{
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
			}
			else
			{
				this.BattleHandler.RefreshEncourage(0);
			}
		}

		public void OnNotifyEncourage(uint oRes)
		{
			this._EncourageCount = oRes;
			this.BattleHandler.RefreshEncourage(0);
		}

		public void ReqGuildBossInfo()
		{
			RpcC2M_ReqGuildBossInfo rpc = new RpcC2M_ReqGuildBossInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		private GuildBossRoleRewardTable.RowData GetRoleRewardTableByBossID(uint bossid)
		{
			for (int i = 0; i < XGuildDragonDocument._GuildBossRoleRewardReader.Table.Length; i++)
			{
				bool flag = XGuildDragonDocument._GuildBossRoleRewardReader.Table[i].BossID == bossid;
				if (flag)
				{
					return XGuildDragonDocument._GuildBossRoleRewardReader.Table[i];
				}
			}
			return null;
		}

		public void OnGetGuildBossInfo(AskGuildBossInfoRes oRes)
		{
			bool flag = this.GuildDragonView == null || !this.GuildDragonView.IsVisible();
			if (!flag)
			{
				this.rdCfg = XGuildDragonDocument._GuildBossConfigReader.GetByBossID(oRes.bossId);
				bool flag2 = this.rdCfg == null;
				if (!flag2)
				{
					GuildBossRoleRewardTable.RowData roleRewardTableByBossID = this.GetRoleRewardTableByBossID(oRes.bossId);
					GuildBossRewardTable.RowData byrank = XGuildDragonDocument._GuildBossRewardTableReader.GetByrank(1U);
					this.currentRewardList.Clear();
					this.dicRewardName.Clear();
					this.dicRewardDes.Clear();
					int num = 0;
					bool flag3 = roleRewardTableByBossID != null && roleRewardTableByBossID.prestige.Count != 0;
					if (flag3)
					{
						this.GuildDragonView.ShowDropList(num++, XStringDefineProxy.GetString("GUILD_BOSS_HURT"), roleRewardTableByBossID.prestige[0, 0], roleRewardTableByBossID.prestige[0, 1]);
						this.currentRewardList.Add(new Seq2<uint>(roleRewardTableByBossID.prestige[0, 0], roleRewardTableByBossID.prestige[0, 1]));
						this.dicRewardName.Add("GUILD_BOSS_HURT");
						this.dicRewardDes.Add("GUILD_BOSS_REWARD_TYPE_HURT");
					}
					bool flag4 = byrank != null && byrank.guildexp.Count != 0;
					if (flag4)
					{
						this.GuildDragonView.ShowDropList(num++, XStringDefineProxy.GetString("GUILD_BOSS_PRE"), byrank.guildexp[0, 0], byrank.guildexp[0, 1]);
						this.currentRewardList.Add(new Seq2<uint>(byrank.guildexp[0, 0], byrank.guildexp[0, 1]));
						this.dicRewardName.Add("GUILD_BOSS_PRE");
						this.dicRewardDes.Add("GUILD_BOSS_REWARD_TYPE_PRE");
					}
					bool isFirstKill = oRes.isFirstKill;
					if (isFirstKill)
					{
						bool flag5 = this.rdCfg != null && this.rdCfg.FirsttKillReward.Count != 0;
						if (flag5)
						{
							this.GuildDragonView.ShowDropList(num++, XStringDefineProxy.GetString("GUILD_BOSS_FIRSTKILL"), this.rdCfg.FirsttKillReward[0, 0], this.rdCfg.FirsttKillReward[0, 1]);
							this.currentRewardList.Add(new Seq2<uint>(this.rdCfg.FirsttKillReward[0, 0], this.rdCfg.FirsttKillReward[0, 1]));
							this.dicRewardName.Add("GUILD_BOSS_FIRSTKILL");
							this.dicRewardDes.Add("GUILD_BOSS_REWARD_TYPE_FIRSTKILL");
						}
					}
					bool flag6 = this.rdCfg != null && this.rdCfg.JoinReward.Count != 0;
					if (flag6)
					{
						this.GuildDragonView.ShowDropList(num++, XStringDefineProxy.GetString("GUILD_BOSS_JOIN"), this.rdCfg.JoinReward[0, 0], this.rdCfg.JoinReward[0, 1]);
						this.currentRewardList.Add(new Seq2<uint>(this.rdCfg.JoinReward[0, 0], this.rdCfg.JoinReward[0, 1]));
						this.dicRewardName.Add("GUILD_BOSS_JOIN");
						this.dicRewardDes.Add("GUILD_BOSS_REWARD_TYPE_JOIN");
					}
					bool flag7 = this.rdCfg != null && this.rdCfg.KillReward.Count != 0;
					if (flag7)
					{
						this.GuildDragonView.ShowDropList(num++, XStringDefineProxy.GetString("GUILD_BOSS_KILL"), this.rdCfg.KillReward[0, 0], this.rdCfg.KillReward[0, 1]);
						this.currentRewardList.Add(new Seq2<uint>(this.rdCfg.KillReward[0, 0], this.rdCfg.KillReward[0, 1]));
						this.dicRewardName.Add("GUILD_BOSS_KILL");
						this.dicRewardDes.Add("GUILD_BOSS_REWARD_TYPE_KILL");
					}
					for (int i = num; i < 5; i++)
					{
						this.GuildDragonView.ShowDropList(i, null, uint.MaxValue, uint.MaxValue);
					}
					AuctionHouseDocument specificDocument = XDocuments.GetSpecificDocument<AuctionHouseDocument>(AuctionHouseDocument.uuID);
					List<GuildAuctReward.RowData> guildAuctReward = specificDocument.GetGuildAuctReward(AuctionActType.GuildBoss);
					bool flag8 = guildAuctReward.Count > 0;
					if (flag8)
					{
						uint[] rewardShow = guildAuctReward[0].RewardShow;
						bool flag9 = rewardShow != null;
						if (flag9)
						{
							for (int j = 0; j < rewardShow.Length; j++)
							{
								this.currentRewardList.Add(new Seq2<uint>(rewardShow[j], 0U));
								string item = string.Format("GUILD_BOSS_AUCTREWARD_{0}", rewardShow[j]);
								this.dicRewardName.Add(item);
								string item2 = string.Format("GUILD_BOSS_AUCTREWARD_{0}_DESC", rewardShow[j]);
								this.dicRewardDes.Add(item2);
							}
						}
					}
					this.GuildDragonView.ShowCurrentBoss(oRes, this.rdCfg.BossName, this.rdCfg.EnemyID, oRes.needguildlvl);
					bool flag10 = oRes.needguildlvl == 0U || oRes.needKillBossId == 0U;
					if (flag10)
					{
						this.GuildDragonView.ShowCurrentBoss(oRes, this.rdCfg.BossName, this.rdCfg.EnemyID, oRes.needguildlvl);
					}
				}
			}
		}

		public void GetWorldBossTime(ref int startTime, ref int endTime)
		{
			XActivityDocument doc = XActivityDocument.Doc;
			for (int i = 0; i < doc.MulActivityTable.Table.Length; i++)
			{
				bool flag = doc.MulActivityTable.Table[i].SystemID == XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildDragon);
				if (flag)
				{
					SeqListRef<uint> openDayTime = doc.MulActivityTable.Table[i].OpenDayTime;
					bool flag2 = openDayTime.Count > 0;
					if (flag2)
					{
						startTime = (int)openDayTime[0, 0];
						endTime = (int)openDayTime[0, 1];
					}
				}
			}
		}

		public void DragonChallengeResult(NoticeGuildBossEnd data)
		{
			this.mData = data;
			this.ShowChallengeResult();
		}

		public void GuildBossTimeOut()
		{
			this.mData = new NoticeGuildBossEnd();
			this.mData.isWin = false;
			this.StartCutScene(this.rdCfg.WinCutScene);
		}

		public void ShowChallengeResult()
		{
			bool flag = this.mData != null && this.mData.isWin;
			if (flag)
			{
				DlgBase<GuildDragonChallengeResultView, GuildDragonChallengeResultBehaviour>.singleton.SetVisible(true, true);
				this.StartCountDown();
			}
			else
			{
				bool flag2 = this.rdCfg != null;
				if (flag2)
				{
					this.StartCutScene(this.rdCfg.WinCutScene);
				}
			}
		}

		public void ReqEnterScene()
		{
			bool flag = Time.realtimeSinceStartup - this.fCdTime < 1f;
			if (!flag)
			{
				PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
				ptcC2G_EnterSceneReq.Data.sceneID = this.GetSceneID();
				XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildDragon, true);
				this.fCdTime = Time.realtimeSinceStartup;
			}
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GUILD_BOSS;
			if (flag)
			{
				this.BattleHandler.RefreshEncourage();
			}
		}

		public void ReqQutiScene()
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
		}

		public override void Update(float fDeltaT)
		{
			this.UpdateCutScene();
		}

		public void StartCutScene(string bossWinCutScene)
		{
			this.bStartCutScene = true;
			XSingleton<XCutScene>.singleton.Start("CutScene/" + bossWinCutScene, true, true);
		}

		private void UpdateCutScene()
		{
			bool flag = !this.bStartCutScene;
			if (!flag)
			{
				bool flag2 = !XSingleton<XCutScene>.singleton.IsPlaying;
				if (flag2)
				{
					this.bStartCutScene = false;
					DlgBase<GuildDragonChallengeResultView, GuildDragonChallengeResultBehaviour>.singleton.SetVisible(true, true);
					this.StartCountDown();
				}
			}
		}

		public void StartCountDown()
		{
			this.bCountDown = true;
			bool isWin = this.mData.isWin;
			if (isWin)
			{
				this._GuildDragonChallengeResultView.uiBehaviour.m_Desription.SetText(XStringDefineProxy.GetString("GUILD_BOSS_CHANGGLE_DES_WIN"));
			}
			else
			{
				this._GuildDragonChallengeResultView.uiBehaviour.m_Desription.SetText(XStringDefineProxy.GetString("GUILD_BOSS_CHANGGLE_DES_FAILED"));
			}
			this.CountDownTime.LeftTime = 5f;
		}

		private void UpdateCountDown()
		{
			bool flag = !this.bCountDown;
			if (!flag)
			{
				this.CountDownTime.Update();
				int num = (int)this.CountDownTime.LeftTime;
				bool flag2 = num <= 0;
				if (flag2)
				{
					this.bCountDown = false;
					this.CountDownTime.LeftTime = 5f;
					this.ReqQutiScene();
				}
				else
				{
					bool flag3 = this._GuildDragonChallengeResultView != null && this._GuildDragonChallengeResultView.IsLoaded();
					if (flag3)
					{
						this._GuildDragonChallengeResultView.uiBehaviour.m_Time.SetText(XStringDefineProxy.GetString("GUILD_BOSS_CHANGGLE_COUNTDOWN", new object[]
						{
							num
						}));
					}
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildDragonDocument");

		private uint _EncourageCount = 0U;

		public XWorldBossDamageRankHandler RankHandler;

		private XGuildDragonGuildRoleRankList m_GuildRankList = new XGuildDragonGuildRoleRankList();

		private XWorldBossDamageRankList m_BossDamageRankList = new XWorldBossDamageRankList();

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static GuildBossConfigTable _GuildBossConfigReader = new GuildBossConfigTable();

		private static GuildBossRewardTable _GuildBossRewardTableReader = new GuildBossRewardTable();

		private static GuildBossRoleRewardTable _GuildBossRoleRewardReader = new GuildBossRoleRewardTable();

		public List<Seq2<uint>> currentRewardList = new List<Seq2<uint>>();

		public List<string> dicRewardName = new List<string>();

		public List<string> dicRewardDes = new List<string>();

		private GuildBossConfigTable.RowData rdCfg = null;

		private NoticeGuildBossEnd mData;

		private float fCdTime = 0f;

		private bool bStartCutScene = false;

		private bool bCountDown = false;

		private XElapseTimer CountDownTime = new XElapseTimer();
	}
}
