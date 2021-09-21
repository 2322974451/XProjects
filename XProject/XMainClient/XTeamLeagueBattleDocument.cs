using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A01 RID: 2561
	internal class XTeamLeagueBattleDocument : XDocComponent
	{
		// Token: 0x17002E78 RID: 11896
		// (get) Token: 0x06009CE2 RID: 40162 RVA: 0x00197274 File Offset: 0x00195474
		public override uint ID
		{
			get
			{
				return XTeamLeagueBattleDocument.uuID;
			}
		}

		// Token: 0x17002E79 RID: 11897
		// (get) Token: 0x06009CE3 RID: 40163 RVA: 0x0019728C File Offset: 0x0019548C
		public LeagueBattleTeamData LoadingInfoBlue
		{
			get
			{
				return this.m_LoadingInfoBlue;
			}
		}

		// Token: 0x17002E7A RID: 11898
		// (get) Token: 0x06009CE4 RID: 40164 RVA: 0x001972A4 File Offset: 0x001954A4
		public LeagueBattleTeamData LoadingInfoRed
		{
			get
			{
				return this.m_LoadingInfoRed;
			}
		}

		// Token: 0x17002E7B RID: 11899
		// (get) Token: 0x06009CE5 RID: 40165 RVA: 0x001972BC File Offset: 0x001954BC
		public LeagueBattleOneTeam BattleBaseInfoBlue
		{
			get
			{
				return this.m_BattleBaseInfoBlue;
			}
		}

		// Token: 0x17002E7C RID: 11900
		// (get) Token: 0x06009CE6 RID: 40166 RVA: 0x001972D4 File Offset: 0x001954D4
		public LeagueBattleOneTeam BattleBaseInfoRed
		{
			get
			{
				return this.m_BattleBaseInfoRed;
			}
		}

		// Token: 0x06009CE7 RID: 40167 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06009CE8 RID: 40168 RVA: 0x001972EC File Offset: 0x001954EC
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			DlgBase<XTeamLeagueLoadingView, XTeamLeagueLoadingBehaviour>.singleton.HidePkLoading();
		}

		// Token: 0x06009CE9 RID: 40169 RVA: 0x00197304 File Offset: 0x00195504
		public ulong GetBattleTeamLeagueID(ulong roleID)
		{
			bool flag = this.LoadingInfoBlue != null;
			if (flag)
			{
				for (int i = 0; i < this.LoadingInfoBlue.members.Count; i++)
				{
					bool flag2 = this.LoadingInfoBlue.members[i].roleid == roleID;
					if (flag2)
					{
						return this.LoadingInfoBlue.league_teamid;
					}
				}
			}
			bool flag3 = this.LoadingInfoRed != null;
			if (flag3)
			{
				for (int j = 0; j < this.LoadingInfoRed.members.Count; j++)
				{
					bool flag4 = this.LoadingInfoRed.members[j].roleid == roleID;
					if (flag4)
					{
						return this.LoadingInfoRed.league_teamid;
					}
				}
			}
			return 0UL;
		}

		// Token: 0x06009CEA RID: 40170 RVA: 0x001973E0 File Offset: 0x001955E0
		public void SetBattlePKInfo(LeagueBattleLoadInfoNtf data)
		{
			XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
			bool flag = data.team1 == null || data.team2 == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("[TeamLeague:SetBattlePKInfo] LeagueBattleLoadInfoNtf team == null", null, null, null, null, null);
			}
			else
			{
				bool flag2 = data.team1.league_teamid == specificDocument.TeamLeagueID;
				if (flag2)
				{
					this.m_LoadingInfoBlue = data.team1;
					this.m_LoadingInfoRed = data.team2;
				}
				else
				{
					bool flag3 = data.team2.league_teamid == specificDocument.TeamLeagueID;
					if (flag3)
					{
						this.m_LoadingInfoBlue = data.team2;
						this.m_LoadingInfoRed = data.team1;
					}
					else
					{
						this.m_LoadingInfoBlue = data.team1;
						this.m_LoadingInfoRed = data.team2;
					}
				}
			}
		}

		// Token: 0x06009CEB RID: 40171 RVA: 0x001974AC File Offset: 0x001956AC
		public void UpdateBattleBaseData(LeagueBattleBaseDataNtf data)
		{
			XSingleton<XDebug>.singleton.AddLog("[TeamLeague]UpdateBattleBaseData", null, null, null, null, null, XDebugColor.XDebug_None);
			bool flag = data.team1 == null || data.team2 == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("[TeamLeague]UpdateBattleBaseData team == null", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				this.IsInTeamLeague = false;
				this.IsInBattleTeamLeague = false;
				this.SelfBattleState = LeagueBattleRoleState.LBRoleState_None;
				this.BlueCanBattleNum = 0;
				this.RedCanBattleNum = 0;
				this.BluePKingRoleID = 0UL;
				this.RedPKingRoleID = 0UL;
				XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
				List<LeagueBattleOneTeam> list = new List<LeagueBattleOneTeam>();
				list.Add(data.team1);
				list.Add(data.team2);
				bool flag2 = data.team1.league_teamid == specificDocument.TeamLeagueID;
				if (flag2)
				{
					this.m_BattleBaseInfoBlue = data.team1;
					this.m_BattleBaseInfoRed = data.team2;
					this.IsInTeamLeague = true;
				}
				else
				{
					bool flag3 = data.team2.league_teamid == specificDocument.TeamLeagueID;
					if (flag3)
					{
						this.m_BattleBaseInfoBlue = data.team2;
						this.m_BattleBaseInfoRed = data.team1;
						this.IsInTeamLeague = true;
					}
					else
					{
						this.m_BattleBaseInfoBlue = data.team1;
						this.m_BattleBaseInfoRed = data.team2;
					}
				}
				for (int i = 0; i < list.Count; i++)
				{
					LeagueBattleOneTeam leagueBattleOneTeam = list[i];
					for (int j = 0; j < leagueBattleOneTeam.members.Count; j++)
					{
						bool flag4 = leagueBattleOneTeam.members[j].basedata.roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
						if (flag4)
						{
							this.IsInBattleTeamLeague = true;
							this.SelfBattleState = leagueBattleOneTeam.members[j].state;
						}
						bool flag5 = leagueBattleOneTeam.members[j].state == LeagueBattleRoleState.LBRoleState_Fighting;
						if (flag5)
						{
							bool flag6 = leagueBattleOneTeam == this.m_BattleBaseInfoBlue;
							if (flag6)
							{
								this.BluePKingRoleID = leagueBattleOneTeam.members[j].basedata.roleid;
							}
							else
							{
								bool flag7 = leagueBattleOneTeam == this.m_BattleBaseInfoRed;
								if (flag7)
								{
									this.RedPKingRoleID = leagueBattleOneTeam.members[j].basedata.roleid;
								}
							}
						}
						bool flag8 = leagueBattleOneTeam.members[j].state != LeagueBattleRoleState.LBRoleState_Failed && leagueBattleOneTeam.members[j].state != LeagueBattleRoleState.LBRoleState_Leave && leagueBattleOneTeam.members[j].state != LeagueBattleRoleState.LBRoleState_None;
						if (flag8)
						{
							bool flag9 = leagueBattleOneTeam == this.m_BattleBaseInfoBlue;
							if (flag9)
							{
								this.BlueCanBattleNum++;
							}
							else
							{
								bool flag10 = leagueBattleOneTeam == this.m_BattleBaseInfoRed;
								if (flag10)
								{
									this.RedCanBattleNum++;
								}
							}
						}
					}
				}
				bool flag11 = DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.IsVisible();
				if (flag11)
				{
					DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.RefreshBattleBaseInfo();
					DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.RefreshBattleState();
				}
			}
		}

		// Token: 0x06009CEC RID: 40172 RVA: 0x001977D0 File Offset: 0x001959D0
		public void ReqBattle(LeagueBattleReadyOper type)
		{
			RpcC2G_LeagueBattleReadyReq rpcC2G_LeagueBattleReadyReq = new RpcC2G_LeagueBattleReadyReq();
			rpcC2G_LeagueBattleReadyReq.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_LeagueBattleReadyReq);
		}

		// Token: 0x06009CED RID: 40173 RVA: 0x00197800 File Offset: 0x00195A00
		public void OnLeagueBattleStateNtf(LeagueBattleStateNtf data)
		{
			XSingleton<XDebug>.singleton.AddLog("[TeamLeague]OnLeagueBattleStateNtf", data.state.ToString(), " ", data.lefttime.ToString(), null, null, XDebugColor.XDebug_None);
			this.BattleState = data.state;
			switch (data.state)
			{
			case LeagueBattleFightState.LBFight_None:
				XSingleton<XDebug>.singleton.AddErrorLog("OnLeagueBattleStateNtf state == LBFight_None", null, null, null, null, null);
				break;
			case LeagueBattleFightState.LBFight_Wait:
				DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.SetVisible(true, true);
				DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.RefreshBattleState();
				DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.ResetCommonUI(false);
				DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.CloseSmallReward();
				DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.RefreahCountTime(data.lefttime);
				break;
			case LeagueBattleFightState.LBFight_Fight:
				DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.SetVisible(true, true);
				DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.RefreshBattleState();
				DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.ResetCommonUI(true);
				DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.CloseSmallReward();
				DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.RefreahCountTime(data.lefttime);
				break;
			case LeagueBattleFightState.LBFight_Result:
				DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.SetVisible(false, true);
				break;
			}
			bool flag = DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.RefreshBattleBaseInfo();
			}
		}

		// Token: 0x06009CEE RID: 40174 RVA: 0x00197944 File Offset: 0x00195B44
		public void OnSmallReward(LeagueBattleOneResultNtf data)
		{
			bool flag = data == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("SmallReward Is Null", null, null, null, null, null);
			}
			else
			{
				bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_LEAGUE_BATTLE;
				if (flag2)
				{
					DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.PlaySmallReward(data);
				}
			}
		}

		// Token: 0x06009CEF RID: 40175 RVA: 0x00197994 File Offset: 0x00195B94
		public void OnBigReward(LeagueBattleResultNtf data)
		{
			bool flag = data == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("BigReward Is Null", null, null, null, null, null);
			}
			else
			{
				bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_LEAGUE_BATTLE;
				if (flag2)
				{
					DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.PlayBigReward(data);
				}
			}
		}

		// Token: 0x06009CF0 RID: 40176 RVA: 0x001979E4 File Offset: 0x00195BE4
		public bool FindBlueMember(ulong roleid)
		{
			bool flag = this.m_LoadingInfoBlue == null;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("m_LoadingInfoBlue is null", null, null, null, null, null);
				result = false;
			}
			else
			{
				for (int i = 0; i < this.m_LoadingInfoBlue.members.Count; i++)
				{
					bool flag2 = roleid == this.m_LoadingInfoBlue.members[i].roleid;
					if (flag2)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06009CF1 RID: 40177 RVA: 0x00197A64 File Offset: 0x00195C64
		public bool FindRedMember(ulong roleid)
		{
			bool flag = this.m_LoadingInfoRed == null;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("m_LoadingInfoRed is null", null, null, null, null, null);
				result = false;
			}
			else
			{
				for (int i = 0; i < this.m_LoadingInfoRed.members.Count; i++)
				{
					bool flag2 = roleid == this.m_LoadingInfoRed.members[i].roleid;
					if (flag2)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x04003726 RID: 14118
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("TeamLeagueBattleDocument");

		// Token: 0x04003727 RID: 14119
		private LeagueBattleTeamData m_LoadingInfoBlue;

		// Token: 0x04003728 RID: 14120
		private LeagueBattleTeamData m_LoadingInfoRed;

		// Token: 0x04003729 RID: 14121
		private LeagueBattleOneTeam m_BattleBaseInfoBlue;

		// Token: 0x0400372A RID: 14122
		private LeagueBattleOneTeam m_BattleBaseInfoRed;

		// Token: 0x0400372B RID: 14123
		public bool IsInTeamLeague = false;

		// Token: 0x0400372C RID: 14124
		public bool IsInBattleTeamLeague = false;

		// Token: 0x0400372D RID: 14125
		public LeagueBattleRoleState SelfBattleState = LeagueBattleRoleState.LBRoleState_None;

		// Token: 0x0400372E RID: 14126
		public int BlueCanBattleNum = 0;

		// Token: 0x0400372F RID: 14127
		public int RedCanBattleNum = 0;

		// Token: 0x04003730 RID: 14128
		public ulong BluePKingRoleID = 0UL;

		// Token: 0x04003731 RID: 14129
		public ulong RedPKingRoleID = 0UL;

		// Token: 0x04003732 RID: 14130
		public LeagueBattleFightState BattleState = LeagueBattleFightState.LBFight_None;
	}
}
