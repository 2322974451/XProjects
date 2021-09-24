using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildArenaDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildArenaDocument.uuID;
			}
		}

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

		public void UpdateView(GuildArenaTab tab)
		{
			bool flag = DlgBase<XGuildArenaDlg, TabDlgBehaviour>.singleton.IsVisible() && this.SelectTabIndex == tab;
			if (flag)
			{
				DlgBase<XGuildArenaDlg, TabDlgBehaviour>.singleton.RefreshData();
			}
		}

		public uint CanEnterBattle
		{
			get
			{
				return this.m_canEnterBattle;
			}
		}

		public bool VisibleEnterBattle
		{
			get
			{
				return this.m_visibleEnterBattle;
			}
		}

		public bool RegistrationStatu
		{
			get
			{
				return this.m_registrationStatu;
			}
		}

		public double RegistrationTime
		{
			get
			{
				return this.m_registrationTime;
			}
		}

		public uint RegistrationCount
		{
			get
			{
				return this.m_registrationCount;
			}
		}

		public GuildArenaType BattleStep
		{
			get
			{
				return this.m_battleStep;
			}
		}

		public GuildArenaState TimeState
		{
			get
			{
				return this.m_timeState;
			}
		}

		public bool bInArenaTime
		{
			get
			{
				return this.m_inArenaTime;
			}
		}

		public bool bHasAvailableJion
		{
			get
			{
				return this.m_hasAvailableJoin;
			}
		}

		public List<int> CombatTabs
		{
			get
			{
				return this.m_CombatTabs;
			}
		}

		public bool TryGetGuildInfo(ulong guildID, out XGuildBasicData guildInfo)
		{
			guildInfo = null;
			return guildID > 0UL && this.m_GuildListDic.TryGetValue(guildID, out guildInfo);
		}

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

		public void ReceiveGuildArenaJoinBattle(gmfjoinres res)
		{
			this.m_sendJoinRpc = false;
			bool flag = res.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(res.errorcode, "fece00");
			}
		}

		public void SendGuildArenaInfo()
		{
			RpcC2M_AskGuildArenaInfoNew rpc = new RpcC2M_AskGuildArenaInfoNew();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void SendGuildIntegralInfo()
		{
			RpcC2M_GetGuildIntegralInfo rpc = new RpcC2M_GetGuildIntegralInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void ReceiveGuildArenaNextTime(NoticeGuildArenaNextTime time)
		{
			this.m_timeState = time.state;
			this.UpdateView(GuildArenaTab.Combat);
		}

		public void SendIntegralBattleInfo()
		{
			RpcC2M_getintegralbattleInfo rpc = new RpcC2M_getintegralbattleInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void SendApplyGuildArena()
		{
			RpcC2M_applyguildarena rpc = new RpcC2M_applyguildarena();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void SendGetApplyGuildList()
		{
			RpcC2M_getapplyguildlist rpc = new RpcC2M_getapplyguildlist();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReceiveApplyGuildList(getapplyguildlistres res)
		{
			this.IntegralUnits.Clear();
			this.IntegralUnits.AddRange(res.guildlist);
			this.UpdateView(GuildArenaTab.Hall);
		}

		private int IntegralUnitsCompare(Integralunit u1, Integralunit u2)
		{
			return (int)(u2.guildscore - u1.guildscore);
		}

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

		public void SendReqGuildArenaHistory()
		{
			RpcC2M_ReqGuildArenaHistory rpc = new RpcC2M_ReqGuildArenaHistory();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReceiveGuildArenaHistory(ReqGuildArenaHistoryRse res)
		{
			bool flag = DlgBase<GuildArenaRankDlg, GuildArenaRankBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<GuildArenaRankDlg, GuildArenaRankBehaviour>.singleton.SetHistoryList(res.history);
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildArenaDocument");

		private Dictionary<ulong, XGuildBasicData> m_GuildListDic = new Dictionary<ulong, XGuildBasicData>();

		private Dictionary<uint, Dictionary<uint, GuildArenaGroupData>> m_combatGroupDic = new Dictionary<uint, Dictionary<uint, GuildArenaGroupData>>();

		private List<int> m_CombatTabs = new List<int>();

		private bool m_hasAvailableArenaIcon = false;

		private bool m_inArenaTime = false;

		private bool m_hasAvailableJoin = false;

		private uint m_canEnterBattle = 0U;

		private bool m_visibleEnterBattle = false;

		private uint m_selectBattleID = 0U;

		private double m_iconVisibleTime = 0.0;

		public int SelectWarIndex = 1;

		public GuildArenaTab SelectTabIndex = GuildArenaTab.Hall;

		private GuildArenaState m_timeState = GuildArenaState.GUILD_ARENA_NOT_BEGIN;

		public List<Integralunit> IntegralUnits = new List<Integralunit>();

		public List<GuildArenaDuelCombatInfo> DuelCombatInfos = new List<GuildArenaDuelCombatInfo>();

		private GuildArenaType m_battleStep = GuildArenaType.notopen;

		private bool m_registrationStatu = false;

		private double m_registrationTime = 0.0;

		private uint m_registrationCount = 0U;

		private bool m_sendJoinRpc = false;
	}
}
