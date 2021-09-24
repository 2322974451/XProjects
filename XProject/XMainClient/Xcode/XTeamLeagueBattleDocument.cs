using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamLeagueBattleDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XTeamLeagueBattleDocument.uuID;
			}
		}

		public LeagueBattleTeamData LoadingInfoBlue
		{
			get
			{
				return this.m_LoadingInfoBlue;
			}
		}

		public LeagueBattleTeamData LoadingInfoRed
		{
			get
			{
				return this.m_LoadingInfoRed;
			}
		}

		public LeagueBattleOneTeam BattleBaseInfoBlue
		{
			get
			{
				return this.m_BattleBaseInfoBlue;
			}
		}

		public LeagueBattleOneTeam BattleBaseInfoRed
		{
			get
			{
				return this.m_BattleBaseInfoRed;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			DlgBase<XTeamLeagueLoadingView, XTeamLeagueLoadingBehaviour>.singleton.HidePkLoading();
		}

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

		public void ReqBattle(LeagueBattleReadyOper type)
		{
			RpcC2G_LeagueBattleReadyReq rpcC2G_LeagueBattleReadyReq = new RpcC2G_LeagueBattleReadyReq();
			rpcC2G_LeagueBattleReadyReq.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_LeagueBattleReadyReq);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("TeamLeagueBattleDocument");

		private LeagueBattleTeamData m_LoadingInfoBlue;

		private LeagueBattleTeamData m_LoadingInfoRed;

		private LeagueBattleOneTeam m_BattleBaseInfoBlue;

		private LeagueBattleOneTeam m_BattleBaseInfoRed;

		public bool IsInTeamLeague = false;

		public bool IsInBattleTeamLeague = false;

		public LeagueBattleRoleState SelfBattleState = LeagueBattleRoleState.LBRoleState_None;

		public int BlueCanBattleNum = 0;

		public int RedCanBattleNum = 0;

		public ulong BluePKingRoleID = 0UL;

		public ulong RedPKingRoleID = 0UL;

		public LeagueBattleFightState BattleState = LeagueBattleFightState.LBFight_None;
	}
}
