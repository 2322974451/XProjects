using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CF0 RID: 3312
	internal class XGuildArenaDocument : XDocComponent
	{
		// Token: 0x1700328F RID: 12943
		// (get) Token: 0x0600B941 RID: 47425 RVA: 0x00259424 File Offset: 0x00257624
		public override uint ID
		{
			get
			{
				return XGuildArenaDocument.uuID;
			}
		}

		// Token: 0x0600B942 RID: 47426 RVA: 0x0025943C File Offset: 0x0025763C
		protected override void OnReconnected(XReconnectedEventArgs args)
		{
			bool flag = !DlgBase<XGuildArenaDlg, TabDlgBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				switch (this.SelectTabIndex)
				{
				case GuildArenaTab.Hall:
					this.SendGuildIntegralInfo();
					this.SendGetApplyGuildList();
					break;
				case GuildArenaTab.Duel:
					this.SendIntegralBattleInfo();
					break;
				case GuildArenaTab.Combat:
					this.SendGuildArenaInfo();
					break;
				}
			}
		}

		// Token: 0x17003290 RID: 12944
		// (get) Token: 0x0600B943 RID: 47427 RVA: 0x0025949C File Offset: 0x0025769C
		// (set) Token: 0x0600B944 RID: 47428 RVA: 0x002594B4 File Offset: 0x002576B4
		public bool bHasAvailableArenaIcon
		{
			get
			{
				return this.m_hasAvailableArenaIcon;
			}
			set
			{
				this.m_hasAvailableArenaIcon = value;
				this.m_iconVisibleTime = (double)(this.m_hasAvailableArenaIcon ? 600 : 0);
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildPvp, true);
				SceneType sceneType = XSingleton<XSceneMgr>.singleton.GetSceneType(XSingleton<XScene>.singleton.SceneID);
				bool flag = sceneType == SceneType.SCENE_HALL || sceneType == SceneType.SCENE_GUILD_HALL;
				if (flag)
				{
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildPvpMainInterface, true);
				}
			}
		}

		// Token: 0x0600B945 RID: 47429 RVA: 0x00259528 File Offset: 0x00257728
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			bool flag = this.m_iconVisibleTime > 0.0;
			if (flag)
			{
				this.m_iconVisibleTime -= (double)fDeltaT;
				bool flag2 = this.m_iconVisibleTime <= 0.0;
				if (flag2)
				{
					this.bHasAvailableArenaIcon = false;
				}
			}
			bool flag3 = this.m_registrationTime > (double)fDeltaT;
			if (flag3)
			{
				this.m_registrationTime -= (double)fDeltaT;
			}
			else
			{
				this.m_registrationTime = 0.0;
			}
		}

		// Token: 0x0600B946 RID: 47430 RVA: 0x002595B4 File Offset: 0x002577B4
		public void UpdateView(GuildArenaTab tab)
		{
			bool flag = DlgBase<XGuildArenaDlg, TabDlgBehaviour>.singleton.IsVisible() && this.SelectTabIndex == tab;
			if (flag)
			{
				DlgBase<XGuildArenaDlg, TabDlgBehaviour>.singleton.RefreshData();
			}
		}

		// Token: 0x17003291 RID: 12945
		// (get) Token: 0x0600B947 RID: 47431 RVA: 0x002595EC File Offset: 0x002577EC
		public uint CanEnterBattle
		{
			get
			{
				return this.m_canEnterBattle;
			}
		}

		// Token: 0x17003292 RID: 12946
		// (get) Token: 0x0600B948 RID: 47432 RVA: 0x00259604 File Offset: 0x00257804
		public bool VisibleEnterBattle
		{
			get
			{
				return this.m_visibleEnterBattle;
			}
		}

		// Token: 0x17003293 RID: 12947
		// (get) Token: 0x0600B949 RID: 47433 RVA: 0x0025961C File Offset: 0x0025781C
		public bool RegistrationStatu
		{
			get
			{
				return this.m_registrationStatu;
			}
		}

		// Token: 0x17003294 RID: 12948
		// (get) Token: 0x0600B94A RID: 47434 RVA: 0x00259634 File Offset: 0x00257834
		public double RegistrationTime
		{
			get
			{
				return this.m_registrationTime;
			}
		}

		// Token: 0x17003295 RID: 12949
		// (get) Token: 0x0600B94B RID: 47435 RVA: 0x0025964C File Offset: 0x0025784C
		public uint RegistrationCount
		{
			get
			{
				return this.m_registrationCount;
			}
		}

		// Token: 0x17003296 RID: 12950
		// (get) Token: 0x0600B94C RID: 47436 RVA: 0x00259664 File Offset: 0x00257864
		public GuildArenaType BattleStep
		{
			get
			{
				return this.m_battleStep;
			}
		}

		// Token: 0x17003297 RID: 12951
		// (get) Token: 0x0600B94D RID: 47437 RVA: 0x0025967C File Offset: 0x0025787C
		public GuildArenaState TimeState
		{
			get
			{
				return this.m_timeState;
			}
		}

		// Token: 0x17003298 RID: 12952
		// (get) Token: 0x0600B94E RID: 47438 RVA: 0x00259694 File Offset: 0x00257894
		public bool bInArenaTime
		{
			get
			{
				return this.m_inArenaTime;
			}
		}

		// Token: 0x17003299 RID: 12953
		// (get) Token: 0x0600B94F RID: 47439 RVA: 0x002596AC File Offset: 0x002578AC
		public bool bHasAvailableJion
		{
			get
			{
				return this.m_hasAvailableJoin;
			}
		}

		// Token: 0x1700329A RID: 12954
		// (get) Token: 0x0600B950 RID: 47440 RVA: 0x002596C4 File Offset: 0x002578C4
		public List<int> CombatTabs
		{
			get
			{
				return this.m_CombatTabs;
			}
		}

		// Token: 0x0600B951 RID: 47441 RVA: 0x002596DC File Offset: 0x002578DC
		public bool TryGetGuildInfo(ulong guildID, out XGuildBasicData guildInfo)
		{
			guildInfo = null;
			return guildID > 0UL && this.m_GuildListDic.TryGetValue(guildID, out guildInfo);
		}

		// Token: 0x0600B952 RID: 47442 RVA: 0x00259708 File Offset: 0x00257908
		public GuildArenaGroupData GetGuildGroup(uint combatID, uint battleID)
		{
			Dictionary<uint, GuildArenaGroupData> dictionary;
			bool flag = this.m_combatGroupDic.TryGetValue(combatID, out dictionary);
			GuildArenaGroupData result;
			if (flag)
			{
				result = (dictionary.ContainsKey(battleID) ? dictionary[battleID] : null);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600B953 RID: 47443 RVA: 0x00259744 File Offset: 0x00257944
		public ulong GetArenaWinnerGuildID(uint combatTeamID, uint battleID = 7U)
		{
			Dictionary<uint, GuildArenaGroupData> dictionary;
			bool flag = this.m_combatGroupDic.TryGetValue(combatTeamID, out dictionary);
			ulong result;
			if (flag)
			{
				result = ((dictionary.ContainsKey(battleID) && dictionary[battleID] != null) ? dictionary[battleID].winerId : 0UL);
			}
			else
			{
				result = 0UL;
			}
			return result;
		}

		// Token: 0x0600B954 RID: 47444 RVA: 0x00259790 File Offset: 0x00257990
		private int GetCurRoundIndex()
		{
			int result = 0;
			switch (this.BattleStep)
			{
			case GuildArenaType.battleone:
				result = 0;
				break;
			case GuildArenaType.battletwo:
				result = 1;
				break;
			case GuildArenaType.battlethree:
				result = 2;
				break;
			case GuildArenaType.battlefour:
				result = 3;
				break;
			}
			return result;
		}

		// Token: 0x0600B955 RID: 47445 RVA: 0x002597D8 File Offset: 0x002579D8
		public void SendGuildArenaJoinBattle()
		{
			bool flag = this.m_canEnterBattle != 1U && this.m_canEnterBattle != 2U;
			if (!flag)
			{
				bool sendJoinRpc = this.m_sendJoinRpc;
				if (!sendJoinRpc)
				{
					RpcC2M_gmfjoinreq rpc = new RpcC2M_gmfjoinreq();
					XSingleton<XClientNetwork>.singleton.Send(rpc);
					this.m_sendJoinRpc = true;
				}
			}
		}

		// Token: 0x0600B956 RID: 47446 RVA: 0x0025982C File Offset: 0x00257A2C
		public void ReceiveGuildArenaJoinBattle(gmfjoinres res)
		{
			this.m_sendJoinRpc = false;
			bool flag = res.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(res.errorcode, "fece00");
			}
		}

		// Token: 0x0600B957 RID: 47447 RVA: 0x00259868 File Offset: 0x00257A68
		public void SendGuildArenaInfo()
		{
			RpcC2M_AskGuildArenaInfoNew rpc = new RpcC2M_AskGuildArenaInfoNew();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B958 RID: 47448 RVA: 0x00259888 File Offset: 0x00257A88
		public void OnGuildArenaInfo(AskGuildArenaInfoReq oRes)
		{
			this.m_GuildListDic.Clear();
			this.m_CombatTabs.Clear();
			this.m_combatGroupDic.Clear();
			this.m_timeState = oRes.timeState;
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool bInGuild = specificDocument.bInGuild;
			List<GuildInfo> allguildInfo = oRes.allguildInfo;
			int i = 0;
			int count = allguildInfo.Count;
			while (i < count)
			{
				XGuildBasicData xguildBasicData = new XGuildBasicData();
				xguildBasicData.Init(allguildInfo[i]);
				this.m_GuildListDic[xguildBasicData.uid] = xguildBasicData;
				i++;
			}
			this.m_inArenaTime = (allguildInfo.Count > 0);
			List<guildArenaWarData> warData = oRes.warData;
			this.m_hasAvailableJoin = false;
			this.m_canEnterBattle = 0U;
			this.m_selectBattleID = 0U;
			i = 0;
			count = warData.Count;
			while (i < count)
			{
				this.m_CombatTabs.Add((int)warData[i].warType);
				this.m_combatGroupDic[warData[i].warType] = new Dictionary<uint, GuildArenaGroupData>();
				int count2 = warData[i].guildArenaGroupData.Count;
				for (int j = count2 - 1; j >= 0; j--)
				{
					GuildArenaGroupData guildArenaGroupData = warData[i].guildArenaGroupData[j];
					this.m_combatGroupDic[warData[i].warType].Add(guildArenaGroupData.battleId, guildArenaGroupData);
					bool flag = guildArenaGroupData.guildOneId == specificDocument.BasicData.uid || guildArenaGroupData.guildTwoId == specificDocument.BasicData.uid;
					if (flag)
					{
						this.SelectWarIndex = (int)warData[i].warType;
						this.m_hasAvailableJoin = true;
						bool flag2 = this.m_selectBattleID == 0U || this.m_selectBattleID < guildArenaGroupData.battleId;
						if (flag2)
						{
							this.m_canEnterBattle = guildArenaGroupData.state;
							this.m_selectBattleID = guildArenaGroupData.battleId;
							this.m_visibleEnterBattle = (guildArenaGroupData.winerId == 0UL || (guildArenaGroupData.winerId == specificDocument.BasicData.uid && guildArenaGroupData.battleId != 7U));
						}
					}
				}
				i++;
			}
			this.UpdateView(GuildArenaTab.Combat);
		}

		// Token: 0x0600B959 RID: 47449 RVA: 0x00259AF0 File Offset: 0x00257CF0
		public void OnSynGuildArenaBattleInfos(SynGuildArenaBattleInfo info)
		{
			uint warType = info.warType;
			List<GuildArenaGroupData> arenaBattleInfo = info.arenaBattleInfo;
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			Dictionary<uint, GuildArenaGroupData> dictionary;
			bool flag = this.m_combatGroupDic.TryGetValue(info.warType, out dictionary);
			if (flag)
			{
				int i = 0;
				int count = arenaBattleInfo.Count;
				while (i < count)
				{
					bool flag2 = dictionary.ContainsKey(arenaBattleInfo[i].battleId);
					if (flag2)
					{
						dictionary[arenaBattleInfo[i].battleId] = arenaBattleInfo[i];
					}
					else
					{
						dictionary.Add(arenaBattleInfo[i].battleId, arenaBattleInfo[i]);
					}
					bool flag3 = arenaBattleInfo[i].guildOneId == specificDocument.BasicData.uid || arenaBattleInfo[i].guildTwoId == specificDocument.BasicData.uid;
					if (flag3)
					{
						this.m_canEnterBattle = arenaBattleInfo[i].state;
						this.m_selectBattleID = arenaBattleInfo[i].battleId;
						this.m_visibleEnterBattle = (arenaBattleInfo[i].winerId == 0UL || (arenaBattleInfo[i].winerId == specificDocument.BasicData.uid && arenaBattleInfo[i].battleId != 7U));
					}
					i++;
				}
			}
			this.UpdateView(GuildArenaTab.Combat);
		}

		// Token: 0x0600B95A RID: 47450 RVA: 0x00259C64 File Offset: 0x00257E64
		public void SendGuildIntegralInfo()
		{
			RpcC2M_GetGuildIntegralInfo rpc = new RpcC2M_GetGuildIntegralInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B95B RID: 47451 RVA: 0x00259C84 File Offset: 0x00257E84
		public void ReceiveIntegralBattleInfo(GetGuildIntegralInfoRes res)
		{
			this.m_battleStep = res.battletype;
			this.m_registrationTime = res.applytime;
			this.m_registrationStatu = res.isapply;
			this.m_registrationCount = res.curturn;
			GuildArenaType battleStep = this.m_battleStep;
			GuildArenaTab guildArenaTab;
			if (battleStep - GuildArenaType.battleone > 3)
			{
				if (battleStep != GuildArenaType.battlefinal)
				{
					guildArenaTab = GuildArenaTab.Hall;
				}
				else
				{
					guildArenaTab = GuildArenaTab.Combat;
				}
			}
			else
			{
				guildArenaTab = GuildArenaTab.Duel;
			}
			bool flag = DlgBase<XGuildArenaDlg, TabDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = this.SelectTabIndex == guildArenaTab;
				if (flag2)
				{
					DlgBase<XGuildArenaDlg, TabDlgBehaviour>.singleton.RefreshData();
				}
				else
				{
					DlgBase<XGuildArenaDlg, TabDlgBehaviour>.singleton.SelectTabIndex(guildArenaTab);
				}
			}
		}

		// Token: 0x0600B95C RID: 47452 RVA: 0x00259D20 File Offset: 0x00257F20
		public void OnUpdateGuildArenaState(UpdateGuildArenaState state)
		{
			GuildArenaGroupData guildGroup = this.GetGuildGroup(state.warType, state.battleId);
			bool flag = guildGroup == null;
			if (!flag)
			{
				guildGroup.warstate = state.state;
				this.UpdateView(GuildArenaTab.Combat);
			}
		}

		// Token: 0x0600B95D RID: 47453 RVA: 0x00259D60 File Offset: 0x00257F60
		public void ReceiveGuildArenaNextTime(NoticeGuildArenaNextTime time)
		{
			this.m_timeState = time.state;
			this.UpdateView(GuildArenaTab.Combat);
		}

		// Token: 0x0600B95E RID: 47454 RVA: 0x00259D78 File Offset: 0x00257F78
		public void SendIntegralBattleInfo()
		{
			RpcC2M_getintegralbattleInfo rpc = new RpcC2M_getintegralbattleInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B95F RID: 47455 RVA: 0x00259D98 File Offset: 0x00257F98
		public void ReceiveIntegralBattleInfo(getintegralbattleInfores res)
		{
			this.DuelCombatInfos.Clear();
			ulong uid = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID).UID;
			int curRoundIndex = this.GetCurRoundIndex();
			int i = 0;
			int count = res.battleTime.Count;
			while (i < count)
			{
				GuildArenaDuelCombatInfo guildArenaDuelCombatInfo = new GuildArenaDuelCombatInfo();
				guildArenaDuelCombatInfo.CombatTime = res.battleTime[i];
				bool flag = i < res.battleinfo.Count;
				if (flag)
				{
					IntegralBattle integralBattle = res.battleinfo[i];
					guildArenaDuelCombatInfo.IsDo = integralBattle.isdo;
					guildArenaDuelCombatInfo.Step = integralBattle.state;
					guildArenaDuelCombatInfo.Statu = ((integralBattle.state == IntegralState.integralend) ? GuildArenaDuelCombatStatu.Used : GuildArenaDuelCombatStatu.Current);
					guildArenaDuelCombatInfo.isShow = true;
					bool flag2 = integralBattle.guildone == uid;
					if (flag2)
					{
						guildArenaDuelCombatInfo.GuildID = integralBattle.guildtwo;
						guildArenaDuelCombatInfo.GuildName = integralBattle.nametwo;
						guildArenaDuelCombatInfo.Winner = (integralBattle.guildonescore > integralBattle.guildtwoscore);
						guildArenaDuelCombatInfo.GuildIcon = integralBattle.icontwo;
						guildArenaDuelCombatInfo.GuildScore = integralBattle.guildonescore;
					}
					else
					{
						bool flag3 = integralBattle.guildtwo == uid;
						if (flag3)
						{
							guildArenaDuelCombatInfo.GuildID = integralBattle.guildone;
							guildArenaDuelCombatInfo.GuildName = integralBattle.nameone;
							guildArenaDuelCombatInfo.GuildScore = integralBattle.guildtwoscore;
							guildArenaDuelCombatInfo.Winner = (integralBattle.guildtwoscore > integralBattle.guildonescore);
							guildArenaDuelCombatInfo.GuildIcon = integralBattle.iconone;
						}
					}
				}
				else
				{
					guildArenaDuelCombatInfo.Statu = GuildArenaDuelCombatStatu.Next;
					guildArenaDuelCombatInfo.isShow = false;
				}
				this.DuelCombatInfos.Add(guildArenaDuelCombatInfo);
				i++;
			}
			this.UpdateView(GuildArenaTab.Duel);
		}

		// Token: 0x0600B960 RID: 47456 RVA: 0x00259F58 File Offset: 0x00258158
		public void SendApplyGuildArena()
		{
			RpcC2M_applyguildarena rpc = new RpcC2M_applyguildarena();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B961 RID: 47457 RVA: 0x00259F78 File Offset: 0x00258178
		public void ReceiveApplyGuildArena(applyguildarenares res)
		{
			bool flag = res.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(res.errorcode);
			}
			else
			{
				this.m_registrationStatu = true;
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_ARENA_SIGN_SUCCESS"), "fece00");
				this.SendGetApplyGuildList();
				this.UpdateView(GuildArenaTab.Hall);
			}
		}

		// Token: 0x0600B962 RID: 47458 RVA: 0x00259FD8 File Offset: 0x002581D8
		public void SendGetApplyGuildList()
		{
			RpcC2M_getapplyguildlist rpc = new RpcC2M_getapplyguildlist();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B963 RID: 47459 RVA: 0x00259FF8 File Offset: 0x002581F8
		public void ReceiveApplyGuildList(getapplyguildlistres res)
		{
			this.IntegralUnits.Clear();
			this.IntegralUnits.AddRange(res.guildlist);
			this.UpdateView(GuildArenaTab.Hall);
		}

		// Token: 0x0600B964 RID: 47460 RVA: 0x0025A024 File Offset: 0x00258224
		private int IntegralUnitsCompare(Integralunit u1, Integralunit u2)
		{
			return (int)(u2.guildscore - u1.guildscore);
		}

		// Token: 0x0600B965 RID: 47461 RVA: 0x0025A044 File Offset: 0x00258244
		public int GetMyIntegralUnitIndex()
		{
			int result = -1;
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			ulong uid = specificDocument.BasicData.uid;
			int i = 0;
			int count = this.IntegralUnits.Count;
			while (i < count)
			{
				bool flag = this.IntegralUnits[i].guildid != uid;
				if (!flag)
				{
					result = i;
					break;
				}
				i++;
			}
			return result;
		}

		// Token: 0x0600B966 RID: 47462 RVA: 0x0025A0B8 File Offset: 0x002582B8
		public void SendEnterDuelBattle(int index)
		{
			bool flag = index >= this.DuelCombatInfos.Count;
			if (!flag)
			{
				GuildArenaDuelCombatInfo guildArenaDuelCombatInfo = this.DuelCombatInfos[index];
				bool flag2 = guildArenaDuelCombatInfo.Step == IntegralState.integralwatch || guildArenaDuelCombatInfo.Step == IntegralState.integralenterscene;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddGreenLog("XMainClient.GuildArenaDocument.SendEnterDuelBattle", null, null, null, null, null);
					RpcC2M_gmfjoinreq rpc = new RpcC2M_gmfjoinreq();
					XSingleton<XClientNetwork>.singleton.Send(rpc);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_ARENA_OUTTIME"), "fece00");
				}
			}
		}

		// Token: 0x0600B967 RID: 47463 RVA: 0x0025A14C File Offset: 0x0025834C
		public void ReceiveUpdateBattleStatu(IntegralState state)
		{
			int curRoundIndex = this.GetCurRoundIndex();
			bool flag = curRoundIndex == -1 || curRoundIndex >= this.DuelCombatInfos.Count;
			if (!flag)
			{
				GuildArenaDuelCombatInfo guildArenaDuelCombatInfo = this.DuelCombatInfos[curRoundIndex];
				guildArenaDuelCombatInfo.Step = state;
				bool flag2 = this.SelectTabIndex == GuildArenaTab.Duel;
				if (flag2)
				{
					bool flag3 = !guildArenaDuelCombatInfo.isShow;
					if (flag3)
					{
						this.SendIntegralBattleInfo();
					}
					else
					{
						this.UpdateView(GuildArenaTab.Duel);
					}
				}
				else
				{
					bool flag4 = DlgBase<XGuildArenaDlg, TabDlgBehaviour>.singleton.IsVisible() && (guildArenaDuelCombatInfo.Step == IntegralState.integralenterscene || guildArenaDuelCombatInfo.Step == IntegralState.integralwatch);
					if (flag4)
					{
						DlgBase<XGuildArenaDlg, TabDlgBehaviour>.singleton.SelectTabIndex(GuildArenaTab.Duel);
					}
				}
			}
		}

		// Token: 0x0600B968 RID: 47464 RVA: 0x0025A1F8 File Offset: 0x002583F8
		public void SendReqGuildArenaHistory()
		{
			RpcC2M_ReqGuildArenaHistory rpc = new RpcC2M_ReqGuildArenaHistory();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B969 RID: 47465 RVA: 0x0025A218 File Offset: 0x00258418
		public void ReceiveGuildArenaHistory(ReqGuildArenaHistoryRse res)
		{
			bool flag = DlgBase<GuildArenaRankDlg, GuildArenaRankBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<GuildArenaRankDlg, GuildArenaRankBehaviour>.singleton.SetHistoryList(res.history);
			}
		}

		// Token: 0x040049DC RID: 18908
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildArenaDocument");

		// Token: 0x040049DD RID: 18909
		private Dictionary<ulong, XGuildBasicData> m_GuildListDic = new Dictionary<ulong, XGuildBasicData>();

		// Token: 0x040049DE RID: 18910
		private Dictionary<uint, Dictionary<uint, GuildArenaGroupData>> m_combatGroupDic = new Dictionary<uint, Dictionary<uint, GuildArenaGroupData>>();

		// Token: 0x040049DF RID: 18911
		private List<int> m_CombatTabs = new List<int>();

		// Token: 0x040049E0 RID: 18912
		private bool m_hasAvailableArenaIcon = false;

		// Token: 0x040049E1 RID: 18913
		private bool m_inArenaTime = false;

		// Token: 0x040049E2 RID: 18914
		private bool m_hasAvailableJoin = false;

		// Token: 0x040049E3 RID: 18915
		private uint m_canEnterBattle = 0U;

		// Token: 0x040049E4 RID: 18916
		private bool m_visibleEnterBattle = false;

		// Token: 0x040049E5 RID: 18917
		private uint m_selectBattleID = 0U;

		// Token: 0x040049E6 RID: 18918
		private double m_iconVisibleTime = 0.0;

		// Token: 0x040049E7 RID: 18919
		public int SelectWarIndex = 1;

		// Token: 0x040049E8 RID: 18920
		public GuildArenaTab SelectTabIndex = GuildArenaTab.Hall;

		// Token: 0x040049E9 RID: 18921
		private GuildArenaState m_timeState = GuildArenaState.GUILD_ARENA_NOT_BEGIN;

		// Token: 0x040049EA RID: 18922
		public List<Integralunit> IntegralUnits = new List<Integralunit>();

		// Token: 0x040049EB RID: 18923
		public List<GuildArenaDuelCombatInfo> DuelCombatInfos = new List<GuildArenaDuelCombatInfo>();

		// Token: 0x040049EC RID: 18924
		private GuildArenaType m_battleStep = GuildArenaType.notopen;

		// Token: 0x040049ED RID: 18925
		private bool m_registrationStatu = false;

		// Token: 0x040049EE RID: 18926
		private double m_registrationTime = 0.0;

		// Token: 0x040049EF RID: 18927
		private uint m_registrationCount = 0U;

		// Token: 0x040049F0 RID: 18928
		private bool m_sendJoinRpc = false;
	}
}
