using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009A3 RID: 2467
	internal class XGuildDragonDocument : XDocComponent, IRankSource, IWorldBossBattleSource
	{
		// Token: 0x17002CF1 RID: 11505
		// (get) Token: 0x0600948B RID: 38027 RVA: 0x0015F488 File Offset: 0x0015D688
		public override uint ID
		{
			get
			{
				return XGuildDragonDocument.uuID;
			}
		}

		// Token: 0x17002CF2 RID: 11506
		// (get) Token: 0x0600948C RID: 38028 RVA: 0x0015F49F File Offset: 0x0015D69F
		// (set) Token: 0x0600948D RID: 38029 RVA: 0x0015F4A7 File Offset: 0x0015D6A7
		public XGuildDragonView GuildDragonView { get; set; }

		// Token: 0x17002CF3 RID: 11507
		// (get) Token: 0x0600948E RID: 38030 RVA: 0x0015F4B0 File Offset: 0x0015D6B0
		// (set) Token: 0x0600948F RID: 38031 RVA: 0x0015F4B8 File Offset: 0x0015D6B8
		public GuildDragonChallengeResultView _GuildDragonChallengeResultView { get; set; }

		// Token: 0x17002CF4 RID: 11508
		// (get) Token: 0x06009490 RID: 38032 RVA: 0x0015F4C1 File Offset: 0x0015D6C1
		// (set) Token: 0x06009491 RID: 38033 RVA: 0x0015F4C9 File Offset: 0x0015D6C9
		public BattleWorldBossHandler BattleHandler { get; set; }

		// Token: 0x17002CF5 RID: 11509
		// (get) Token: 0x06009492 RID: 38034 RVA: 0x0015F4D2 File Offset: 0x0015D6D2
		// (set) Token: 0x06009493 RID: 38035 RVA: 0x0015F4DA File Offset: 0x0015D6DA
		public bool bCanFight { get; set; }

		// Token: 0x17002CF6 RID: 11510
		// (get) Token: 0x06009494 RID: 38036 RVA: 0x0015F4E4 File Offset: 0x0015D6E4
		public uint EncourageCount
		{
			get
			{
				return this._EncourageCount;
			}
		}

		// Token: 0x17002CF7 RID: 11511
		// (get) Token: 0x06009495 RID: 38037 RVA: 0x0015F4FC File Offset: 0x0015D6FC
		public XGuildDragonGuildRoleRankList GuildRankList
		{
			get
			{
				return this.m_GuildRankList;
			}
		}

		// Token: 0x17002CF8 RID: 11512
		// (get) Token: 0x06009496 RID: 38038 RVA: 0x0015F514 File Offset: 0x0015D714
		public XWorldBossDamageRankList PersonRankList
		{
			get
			{
				return this.m_BossDamageRankList;
			}
		}

		// Token: 0x06009497 RID: 38039 RVA: 0x0015F52C File Offset: 0x0015D72C
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildDragonDocument.AsyncLoader.AddTask("Table/GuildBossConfig", XGuildDragonDocument._GuildBossConfigReader, false);
			XGuildDragonDocument.AsyncLoader.AddTask("Table/GuildBossReward", XGuildDragonDocument._GuildBossRewardTableReader, false);
			XGuildDragonDocument.AsyncLoader.AddTask("Table/GuildBossRoleReward", XGuildDragonDocument._GuildBossRoleRewardReader, false);
			XGuildDragonDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009498 RID: 38040 RVA: 0x0015F588 File Offset: 0x0015D788
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.bCanFight = false;
		}

		// Token: 0x06009499 RID: 38041 RVA: 0x0015F59B File Offset: 0x0015D79B
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.OnInGuildStateChanged));
		}

		// Token: 0x0600949A RID: 38042 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600949B RID: 38043 RVA: 0x0015F5BC File Offset: 0x0015D7BC
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

		// Token: 0x0600949C RID: 38044 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void ReqEncourageTwo()
		{
		}

		// Token: 0x0600949D RID: 38045 RVA: 0x0015F5E0 File Offset: 0x0015D7E0
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

		// Token: 0x0600949E RID: 38046 RVA: 0x0015F648 File Offset: 0x0015D848
		public uint GetSceneID()
		{
			return (uint)XSingleton<XGlobalConfig>.singleton.GetInt("GuildBossSceneID");
		}

		// Token: 0x0600949F RID: 38047 RVA: 0x0015F669 File Offset: 0x0015D869
		public void ReqRankData(RankeType type, bool inFight)
		{
			this.ReqBossRoleRank(inFight);
		}

		// Token: 0x060094A0 RID: 38048 RVA: 0x0015F674 File Offset: 0x0015D874
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

		// Token: 0x060094A1 RID: 38049 RVA: 0x0015F6F0 File Offset: 0x0015D8F0
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

		// Token: 0x060094A2 RID: 38050 RVA: 0x0015F7C4 File Offset: 0x0015D9C4
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

		// Token: 0x060094A3 RID: 38051 RVA: 0x0015F7FC File Offset: 0x0015D9FC
		public void ReqWorldBossState()
		{
			RpcC2M_GetWorldBossStateNew rpcC2M_GetWorldBossStateNew = new RpcC2M_GetWorldBossStateNew();
			rpcC2M_GetWorldBossStateNew.oArg.type = 1U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetWorldBossStateNew);
		}

		// Token: 0x060094A4 RID: 38052 RVA: 0x0015F82C File Offset: 0x0015DA2C
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

		// Token: 0x060094A5 RID: 38053 RVA: 0x0015F898 File Offset: 0x0015DA98
		public void ReqBattleInfo()
		{
			RpcC2G_ReqGuildBossTimeLeft rpc = new RpcC2G_ReqGuildBossTimeLeft();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x060094A6 RID: 38054 RVA: 0x0015F8B8 File Offset: 0x0015DAB8
		public void OnGetBattleInfo(getguildbosstimeleftRes oRes)
		{
			this._EncourageCount = oRes.addAttrCount;
			bool flag = this.BattleHandler != null && this.BattleHandler.active;
			if (flag)
			{
				this.BattleHandler.SetLeftTime(oRes.timeleft);
			}
		}

		// Token: 0x060094A7 RID: 38055 RVA: 0x0015F900 File Offset: 0x0015DB00
		public void ReqEncourage()
		{
			RpcC2G_AddTempAttr rpcC2G_AddTempAttr = new RpcC2G_AddTempAttr();
			rpcC2G_AddTempAttr.oArg.type = 1U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_AddTempAttr);
		}

		// Token: 0x060094A8 RID: 38056 RVA: 0x0015F930 File Offset: 0x0015DB30
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

		// Token: 0x060094A9 RID: 38057 RVA: 0x0015F971 File Offset: 0x0015DB71
		public void OnNotifyEncourage(uint oRes)
		{
			this._EncourageCount = oRes;
			this.BattleHandler.RefreshEncourage(0);
		}

		// Token: 0x060094AA RID: 38058 RVA: 0x0015F988 File Offset: 0x0015DB88
		public void ReqGuildBossInfo()
		{
			RpcC2M_ReqGuildBossInfo rpc = new RpcC2M_ReqGuildBossInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x060094AB RID: 38059 RVA: 0x0015F9A8 File Offset: 0x0015DBA8
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

		// Token: 0x060094AC RID: 38060 RVA: 0x0015FA00 File Offset: 0x0015DC00
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

		// Token: 0x060094AD RID: 38061 RVA: 0x0015FF94 File Offset: 0x0015E194
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

		// Token: 0x060094AE RID: 38062 RVA: 0x00160024 File Offset: 0x0015E224
		public void DragonChallengeResult(NoticeGuildBossEnd data)
		{
			this.mData = data;
			this.ShowChallengeResult();
		}

		// Token: 0x060094AF RID: 38063 RVA: 0x00160035 File Offset: 0x0015E235
		public void GuildBossTimeOut()
		{
			this.mData = new NoticeGuildBossEnd();
			this.mData.isWin = false;
			this.StartCutScene(this.rdCfg.WinCutScene);
		}

		// Token: 0x060094B0 RID: 38064 RVA: 0x00160064 File Offset: 0x0015E264
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

		// Token: 0x060094B1 RID: 38065 RVA: 0x001600C8 File Offset: 0x0015E2C8
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

		// Token: 0x060094B2 RID: 38066 RVA: 0x0016012C File Offset: 0x0015E32C
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GUILD_BOSS;
			if (flag)
			{
				this.BattleHandler.RefreshEncourage();
			}
		}

		// Token: 0x060094B3 RID: 38067 RVA: 0x00160161 File Offset: 0x0015E361
		public void ReqQutiScene()
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
		}

		// Token: 0x060094B4 RID: 38068 RVA: 0x0016016F File Offset: 0x0015E36F
		public override void Update(float fDeltaT)
		{
			this.UpdateCutScene();
		}

		// Token: 0x060094B5 RID: 38069 RVA: 0x00160179 File Offset: 0x0015E379
		public void StartCutScene(string bossWinCutScene)
		{
			this.bStartCutScene = true;
			XSingleton<XCutScene>.singleton.Start("CutScene/" + bossWinCutScene, true, true);
		}

		// Token: 0x060094B6 RID: 38070 RVA: 0x0016019C File Offset: 0x0015E39C
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

		// Token: 0x060094B7 RID: 38071 RVA: 0x001601E8 File Offset: 0x0015E3E8
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

		// Token: 0x060094B8 RID: 38072 RVA: 0x00160264 File Offset: 0x0015E464
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

		// Token: 0x04003231 RID: 12849
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildDragonDocument");

		// Token: 0x04003236 RID: 12854
		private uint _EncourageCount = 0U;

		// Token: 0x04003237 RID: 12855
		public XWorldBossDamageRankHandler RankHandler;

		// Token: 0x04003238 RID: 12856
		private XGuildDragonGuildRoleRankList m_GuildRankList = new XGuildDragonGuildRoleRankList();

		// Token: 0x04003239 RID: 12857
		private XWorldBossDamageRankList m_BossDamageRankList = new XWorldBossDamageRankList();

		// Token: 0x0400323A RID: 12858
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x0400323B RID: 12859
		public static GuildBossConfigTable _GuildBossConfigReader = new GuildBossConfigTable();

		// Token: 0x0400323C RID: 12860
		private static GuildBossRewardTable _GuildBossRewardTableReader = new GuildBossRewardTable();

		// Token: 0x0400323D RID: 12861
		private static GuildBossRoleRewardTable _GuildBossRoleRewardReader = new GuildBossRoleRewardTable();

		// Token: 0x0400323E RID: 12862
		public List<Seq2<uint>> currentRewardList = new List<Seq2<uint>>();

		// Token: 0x0400323F RID: 12863
		public List<string> dicRewardName = new List<string>();

		// Token: 0x04003240 RID: 12864
		public List<string> dicRewardDes = new List<string>();

		// Token: 0x04003241 RID: 12865
		private GuildBossConfigTable.RowData rdCfg = null;

		// Token: 0x04003242 RID: 12866
		private NoticeGuildBossEnd mData;

		// Token: 0x04003243 RID: 12867
		private float fCdTime = 0f;

		// Token: 0x04003244 RID: 12868
		private bool bStartCutScene = false;

		// Token: 0x04003245 RID: 12869
		private bool bCountDown = false;

		// Token: 0x04003246 RID: 12870
		private XElapseTimer CountDownTime = new XElapseTimer();
	}
}
