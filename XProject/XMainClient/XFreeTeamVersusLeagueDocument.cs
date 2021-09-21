using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000919 RID: 2329
	internal class XFreeTeamVersusLeagueDocument : XDocComponent
	{
		// Token: 0x17002B77 RID: 11127
		// (get) Token: 0x06008C51 RID: 35921 RVA: 0x0012FAD8 File Offset: 0x0012DCD8
		public override uint ID
		{
			get
			{
				return XFreeTeamVersusLeagueDocument.uuID;
			}
		}

		// Token: 0x17002B78 RID: 11128
		// (get) Token: 0x06008C52 RID: 35922 RVA: 0x0012FAF0 File Offset: 0x0012DCF0
		public static XFreeTeamVersusLeagueDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XFreeTeamVersusLeagueDocument.uuID) as XFreeTeamVersusLeagueDocument;
			}
		}

		// Token: 0x17002B79 RID: 11129
		// (get) Token: 0x06008C53 RID: 35923 RVA: 0x0012FB1C File Offset: 0x0012DD1C
		public static LeagueRankReward LeagueRankRewardTable
		{
			get
			{
				return XFreeTeamVersusLeagueDocument.leagueRankRewardTable;
			}
		}

		// Token: 0x17002B7A RID: 11130
		// (get) Token: 0x06008C54 RID: 35924 RVA: 0x0012FB34 File Offset: 0x0012DD34
		// (set) Token: 0x06008C55 RID: 35925 RVA: 0x0012FB4C File Offset: 0x0012DD4C
		public LeagueTeamDetail TeamInfoDetail
		{
			get
			{
				return this._teamInfoDetail;
			}
			set
			{
				this._teamInfoDetail = value;
			}
		}

		// Token: 0x17002B7B RID: 11131
		// (get) Token: 0x06008C56 RID: 35926 RVA: 0x0012FB58 File Offset: 0x0012DD58
		public ulong TeamLeagueID
		{
			get
			{
				return this._teamLeagueID;
			}
		}

		// Token: 0x17002B7C RID: 11132
		// (get) Token: 0x06008C57 RID: 35927 RVA: 0x0012FB70 File Offset: 0x0012DD70
		public bool IsOpen
		{
			get
			{
				return this._isOpen;
			}
		}

		// Token: 0x17002B7D RID: 11133
		// (get) Token: 0x06008C58 RID: 35928 RVA: 0x0012FB88 File Offset: 0x0012DD88
		public bool IsCross
		{
			get
			{
				return this._isCross;
			}
		}

		// Token: 0x17002B7E RID: 11134
		// (get) Token: 0x06008C59 RID: 35929 RVA: 0x0012FBA0 File Offset: 0x0012DDA0
		public bool IsTeamMatching
		{
			get
			{
				return this._isTeamMatching;
			}
		}

		// Token: 0x17002B7F RID: 11135
		// (get) Token: 0x06008C5A RID: 35930 RVA: 0x0012FBB8 File Offset: 0x0012DDB8
		// (set) Token: 0x06008C5B RID: 35931 RVA: 0x0012FBD0 File Offset: 0x0012DDD0
		public LeagueTeamDetail EliChampionTeam
		{
			get
			{
				return this._eliChampionTeam;
			}
			set
			{
				this._eliChampionTeam = value;
			}
		}

		// Token: 0x17002B80 RID: 11136
		// (get) Token: 0x06008C5C RID: 35932 RVA: 0x0012FBDA File Offset: 0x0012DDDA
		// (set) Token: 0x06008C5D RID: 35933 RVA: 0x0012FBE2 File Offset: 0x0012DDE2
		public LeagueEliType EliStateType { get; private set; }

		// Token: 0x06008C5E RID: 35934 RVA: 0x0012FBEB File Offset: 0x0012DDEB
		public static void Execute(OnLoadedCallback callback = null)
		{
			XFreeTeamVersusLeagueDocument.AsyncLoader.AddTask("Table/LeagueRankReward", XFreeTeamVersusLeagueDocument.LeagueRankRewardTable, false);
			XFreeTeamVersusLeagueDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008C5F RID: 35935 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06008C60 RID: 35936 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x06008C61 RID: 35937 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x06008C62 RID: 35938 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008C63 RID: 35939 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x06008C64 RID: 35940 RVA: 0x0012FC10 File Offset: 0x0012DE10
		private uint GetMaxRound()
		{
			uint result = 0U;
			foreach (KeyValuePair<uint, List<LBEleRoomInfo>> keyValuePair in this._eliminationVersusDic)
			{
				result = keyValuePair.Key;
				for (int i = 1; i < keyValuePair.Value.Count; i++)
				{
					bool flag = keyValuePair.Value[i].team1 == null || keyValuePair.Value[i].team1.leagueid == 0UL || keyValuePair.Value[i].team2 == null || keyValuePair.Value[i].team2.leagueid == 0UL;
					if (flag)
					{
						return result;
					}
				}
			}
			return result;
		}

		// Token: 0x06008C65 RID: 35941 RVA: 0x0012FD08 File Offset: 0x0012DF08
		public void OnGetLeagueSeasonInfo(PtcM2C_UpdateLeagueBattleSeasonInfo roPtc)
		{
			this._teamLeagueID = roPtc.Data.league_teamid;
			this._isCross = roPtc.Data.is_cross;
			this._isOpen = roPtc.Data.is_open;
			this.TodayState = roPtc.Data.state;
		}

		// Token: 0x06008C66 RID: 35942 RVA: 0x0012FD5C File Offset: 0x0012DF5C
		public void SendGetLeagueTeamInfo(ulong teamID)
		{
			RpcC2M_GetLeagueTeamInfo rpcC2M_GetLeagueTeamInfo = new RpcC2M_GetLeagueTeamInfo();
			rpcC2M_GetLeagueTeamInfo.oArg.league_teamid = teamID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetLeagueTeamInfo);
		}

		// Token: 0x06008C67 RID: 35943 RVA: 0x0012FD8C File Offset: 0x0012DF8C
		public void OnGetLeagueTeamInfo(GetLeagueTeamInfoArg oArg, GetLeagueTeamInfoRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				this._teamInfoDetail = oRes.team;
				DlgBase<XTeamLeagueDetailView, XTeamLeagueDetailBehaviour>.singleton.ShowDetail(oRes.team.teamname, oRes.team.members);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.result);
			}
		}

		// Token: 0x06008C68 RID: 35944 RVA: 0x0012FDEC File Offset: 0x0012DFEC
		public void SendGetLeagueBattleInfo()
		{
			RpcC2M_GetLeagueBattleInfo rpc = new RpcC2M_GetLeagueBattleInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008C69 RID: 35945 RVA: 0x0012FE0C File Offset: 0x0012E00C
		public void OnGetLeagueBattleInfo(GetLeagueBattleInfoRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				this.TodayState = oRes.today_state;
				this.TimeStamp = oRes.timestamp;
				this._teamLeagueID = oRes.league_teamid;
				this.LeagueTeamName = oRes.league_teamname;
				this.BattleScore = oRes.score;
				this.BattledTimes = oRes.battlenum;
				this.BattleNumWeekly = oRes.week_battlenum;
				this.BattleWinRate = oRes.winrate;
				this.updateTime = (uint)Time.time;
				this.pointRaceRewardsLeftTime = oRes.rankreward_lefttime;
				this.crossRewardsLeftTime = oRes.crossrankreward_lefttime;
				this.MyTeamRank = oRes.rank;
				this.EliStateType = oRes.eli_type;
				this.UpdateTeamMemberInfo(oRes.member);
				bool flag2 = DlgBase<XFreeTeamLeagueMainView, XFreeTeamLeagueMainBehavior>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XFreeTeamLeagueMainView, XFreeTeamLeagueMainBehavior>.singleton.RefreshUI();
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
		}

		// Token: 0x06008C6A RID: 35946 RVA: 0x0012FF0C File Offset: 0x0012E10C
		private void UpdateTeamMemberInfo(List<LeagueTeamMemberDetail> member)
		{
			this._teamInfoList.Clear();
			bool flag = this._teamLeagueID > 0UL;
			if (flag)
			{
				for (int i = 0; i < member.Count; i++)
				{
					this._teamInfoList.Add(new LeagueTeamDetailInfo
					{
						roleBrief = member[i].brief,
						pkPoints = member[i].pkpoint
					});
				}
			}
		}

		// Token: 0x06008C6B RID: 35947 RVA: 0x0012FF84 File Offset: 0x0012E184
		public int GetPkRecordCount()
		{
			return this._pkRecordList.Count;
		}

		// Token: 0x06008C6C RID: 35948 RVA: 0x0012FFA4 File Offset: 0x0012E1A4
		public LeaguePKRecordInfo GetPkRecordInfoByIndex(int index)
		{
			bool flag = index < this._pkRecordList.Count;
			LeaguePKRecordInfo result;
			if (flag)
			{
				result = this._pkRecordList[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06008C6D RID: 35949 RVA: 0x0012FFD8 File Offset: 0x0012E1D8
		public void SendGetLeagueBattleRecord()
		{
			RpcC2M_GetLeagueBattleRecord rpc = new RpcC2M_GetLeagueBattleRecord();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008C6E RID: 35950 RVA: 0x0012FFF8 File Offset: 0x0012E1F8
		public void OnGetLeagueBattleRecord(GetLeagueBattleRecordRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				this.PKRecordBaseInfo.totalWinNum = oRes.winnum;
				this.PKRecordBaseInfo.totalLoseNum = oRes.losenum;
				this.PKRecordBaseInfo.winRate = oRes.winrate;
				this.PKRecordBaseInfo.maxContinueLose = oRes.max_continuelose;
				this.PKRecordBaseInfo.maxContinueWin = oRes.max_continuewin;
				this._pkRecordList.Clear();
				for (int i = 0; i < oRes.records.Count; i++)
				{
					LeagueBattleOneRecord leagueBattleOneRecord = oRes.records[i];
					this._pkRecordList.Add(new LeaguePKRecordInfo
					{
						opponentTeamId = leagueBattleOneRecord.other_teamid,
						opponentTeamName = leagueBattleOneRecord.other_teamname,
						serverId = leagueBattleOneRecord.serverid,
						serverName = leagueBattleOneRecord.servername,
						scoreChange = leagueBattleOneRecord.score_change,
						result = leagueBattleOneRecord.result,
						time = leagueBattleOneRecord.time
					});
				}
				this._pkRecordList.Reverse();
				bool flag2 = DlgBase<XTeamLeagueRecordView, XTeamLeagueRecordBehavior>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XTeamLeagueRecordView, XTeamLeagueRecordBehavior>.singleton.RefreshUI();
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
		}

		// Token: 0x06008C6F RID: 35951 RVA: 0x0013014C File Offset: 0x0012E34C
		public LeagueTeamDetailInfo GetMyTeamMemberInfoByIndex(int index)
		{
			bool flag = index < this._teamInfoList.Count;
			LeagueTeamDetailInfo result;
			if (flag)
			{
				result = this._teamInfoList[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06008C70 RID: 35952 RVA: 0x00130180 File Offset: 0x0012E380
		public int GetMyTeamMemberCount()
		{
			return this._teamInfoList.Count;
		}

		// Token: 0x06008C71 RID: 35953 RVA: 0x001301A0 File Offset: 0x0012E3A0
		public LeagueTeamMemberDetail GetTeamMemberInfoByIndex(int index)
		{
			bool flag = this._teamInfoDetail != null && index < this._teamInfoDetail.members.Count;
			LeagueTeamMemberDetail result;
			if (flag)
			{
				result = this._teamInfoDetail.members[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06008C72 RID: 35954 RVA: 0x001301EC File Offset: 0x0012E3EC
		public LeagueTeamMemberDetail GetTeamMemberInfoByRoleID(ulong roleID)
		{
			return null;
		}

		// Token: 0x06008C73 RID: 35955 RVA: 0x00130200 File Offset: 0x0012E400
		public void SetMainInterfaceBtnState(bool state)
		{
			this.MainInterfaceState = state;
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_TeamLeague, true);
			}
		}

		// Token: 0x06008C74 RID: 35956 RVA: 0x00130236 File Offset: 0x0012E436
		public void OnTeamLeagueCreateNtf(PtcM2C_NotifyLeagueTeamCreate roPtc)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_LEAGUE_CREATE_SUCC"), "fece00");
			this._teamLeagueID = roPtc.Data.league_teamid;
			this.LeagueTeamName = roPtc.Data.name;
		}

		// Token: 0x06008C75 RID: 35957 RVA: 0x00130278 File Offset: 0x0012E478
		public void OnTeamLeagueDissolveNtf(PtcM2C_NotifyLeagueTeamDissolve roPtc)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_LEAGUE_DISSOLVE", new object[]
			{
				roPtc.Data.leave_rolename
			}), "fece00");
			this._teamLeagueID = 0UL;
			bool flag = DlgBase<XFreeTeamLeagueMainView, XFreeTeamLeagueMainBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XFreeTeamLeagueMainView, XFreeTeamLeagueMainBehavior>.singleton.UpdateTeamDetailInfo();
				DlgBase<XFreeTeamLeagueMainView, XFreeTeamLeagueMainBehavior>.singleton.ClearState();
			}
		}

		// Token: 0x06008C76 RID: 35958 RVA: 0x001302E4 File Offset: 0x0012E4E4
		public void ReqLeaveTeamLeague()
		{
			RpcC2M_LeaveLeagueTeam rpc = new RpcC2M_LeaveLeagueTeam();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008C77 RID: 35959 RVA: 0x00130304 File Offset: 0x0012E504
		public void ReqMatchGame(bool match)
		{
			RpcC2M_LeagueBattleReq rpcC2M_LeagueBattleReq = new RpcC2M_LeagueBattleReq();
			rpcC2M_LeagueBattleReq.oArg.type = (match ? LeagueBattleReqType.LBReqType_Match : LeagueBattleReqType.LBReqType_CancelMatch);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_LeagueBattleReq);
		}

		// Token: 0x06008C78 RID: 35960 RVA: 0x00130338 File Offset: 0x0012E538
		public void SetTeamMatchState(bool state)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool flag = specificDocument.MyTeamView != null && specificDocument.MyTeamView.IsVisible();
			if (flag)
			{
				if (state)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_MATCH_START"), "fece00");
				}
			}
		}

		// Token: 0x06008C79 RID: 35961 RVA: 0x00130390 File Offset: 0x0012E590
		public void SendGetLeagueEleInfo()
		{
			RpcC2M_GetLeagueEleInfo rpc = new RpcC2M_GetLeagueEleInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008C7A RID: 35962 RVA: 0x001303B0 File Offset: 0x0012E5B0
		public void OnGetLeagueEleInfo(GetLeagueEleInfoRes oRes)
		{
			bool flag = oRes.rounds.Count > 0;
			if (flag)
			{
				this._eliminationVersusDic.Clear();
				uint num = 0U;
				List<LBEleRoundInfo> rounds = oRes.rounds;
				for (int i = 0; i < rounds.Count; i++)
				{
					bool flag2 = num != rounds[i].round;
					if (flag2)
					{
						num = rounds[i].round;
						this._eliminationVersusDic[num] = new List<LBEleRoomInfo>();
					}
					this._eliminationVersusDic[num].AddRange(rounds[i].rooms);
				}
				this._eliChampionTeam = oRes.chamption;
				bool flag3 = DlgBase<XTeamLeagueFinalResultView, XTeamLeagueFinalResultBehavior>.singleton.IsVisible();
				if (flag3)
				{
					DlgBase<XTeamLeagueFinalResultView, XTeamLeagueFinalResultBehavior>.singleton.RefreshUI();
				}
			}
		}

		// Token: 0x06008C7B RID: 35963 RVA: 0x00130484 File Offset: 0x0012E684
		public List<LBEleRoomInfo> GetRoomsInfoByRound(uint round)
		{
			List<LBEleRoomInfo> result = null;
			this._eliminationVersusDic.TryGetValue(round, out result);
			return result;
		}

		// Token: 0x06008C7C RID: 35964 RVA: 0x001304A8 File Offset: 0x0012E6A8
		public void SendJoinLeagueEleBattle()
		{
			RpcC2M_JoinLeagueEleBattle rpc = new RpcC2M_JoinLeagueEleBattle();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008C7D RID: 35965 RVA: 0x001304C8 File Offset: 0x0012E6C8
		public void SendCloseLeagueEleNtf()
		{
			PtcC2M_CloseLeagueEleNtf proto = new PtcC2M_CloseLeagueEleNtf();
			XSingleton<XClientNetwork>.singleton.Send(proto);
		}

		// Token: 0x06008C7E RID: 35966 RVA: 0x001304E8 File Offset: 0x0012E6E8
		public void OnUpdateEliRoomInfo(PtcM2C_UpdateLeagueEleRoomStateNtf roPtc)
		{
			bool flag = false;
			foreach (KeyValuePair<uint, List<LBEleRoomInfo>> keyValuePair in this._eliminationVersusDic)
			{
				int i = 0;
				while (i < keyValuePair.Value.Count)
				{
					bool flag2 = keyValuePair.Value[i].roomid == roPtc.Data.room.roomid;
					if (flag2)
					{
						keyValuePair.Value[i] = roPtc.Data.room;
						bool flag3 = keyValuePair.Key == 3U && keyValuePair.Value[i].state == LBEleRoomState.LBEleRoomState_Finish;
						if (flag3)
						{
							this.SendGetLeagueEleInfo();
							return;
						}
						flag = true;
						break;
					}
					else
					{
						i++;
					}
				}
			}
			bool flag4 = flag && DlgBase<XTeamLeagueFinalResultView, XTeamLeagueFinalResultBehavior>.singleton.IsVisible();
			if (flag4)
			{
				DlgBase<XTeamLeagueFinalResultView, XTeamLeagueFinalResultBehavior>.singleton.RefreshUI();
			}
		}

		// Token: 0x06008C7F RID: 35967 RVA: 0x00130604 File Offset: 0x0012E804
		public bool IsMyTeamInFighting()
		{
			bool flag = this._teamLeagueID > 0UL;
			if (flag)
			{
				foreach (KeyValuePair<uint, List<LBEleRoomInfo>> keyValuePair in this._eliminationVersusDic)
				{
					for (int i = 0; i < keyValuePair.Value.Count; i++)
					{
						bool flag2 = keyValuePair.Value[i].state == LBEleRoomState.LBEleRoomState_Fighting;
						if (flag2)
						{
							bool flag3 = (keyValuePair.Value[i].team1 != null && keyValuePair.Value[i].team1.leagueid == this._teamLeagueID) || (keyValuePair.Value[i].team2 != null && keyValuePair.Value[i].team2.leagueid == this._teamLeagueID);
							if (flag3)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06008C80 RID: 35968 RVA: 0x00130730 File Offset: 0x0012E930
		public bool IsMyTeamInFinal()
		{
			bool flag = this._teamLeagueID > 0UL;
			if (flag)
			{
				foreach (KeyValuePair<uint, List<LBEleRoomInfo>> keyValuePair in this._eliminationVersusDic)
				{
					for (int i = 0; i < keyValuePair.Value.Count; i++)
					{
						LBEleRoomInfo lbeleRoomInfo = keyValuePair.Value[i];
						bool flag2 = (keyValuePair.Value[i].team1 != null && keyValuePair.Value[i].team1.leagueid == this._teamLeagueID) || (keyValuePair.Value[i].team2 != null && keyValuePair.Value[i].team2.leagueid == this._teamLeagueID);
						if (flag2)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06008C81 RID: 35969 RVA: 0x0013084C File Offset: 0x0012EA4C
		public int GetRewardsLeftTime()
		{
			int result = 0;
			bool flag = this.TodayState == LeagueBattleTimeState.LBTS_PointRace || this.TodayState == LeagueBattleTimeState.LBTS_Idle;
			if (flag)
			{
				result = (int)(this.pointRaceRewardsLeftTime + this.updateTime - (uint)Time.time);
			}
			else
			{
				bool flag2 = this.TodayState == LeagueBattleTimeState.LBTS_CrossPointRace || this.TodayState == LeagueBattleTimeState.LBTS_CrossIdle;
				if (flag2)
				{
					result = (int)(this.crossRewardsLeftTime + this.updateTime - (uint)Time.time);
				}
			}
			return result;
		}

		// Token: 0x06008C82 RID: 35970 RVA: 0x001308C0 File Offset: 0x0012EAC0
		public string GetOpenInstructionString()
		{
			string text = XSingleton<XStringTable>.singleton.GetString("LeagueTeamRules");
			text = XSingleton<UiUtility>.singleton.ReplaceReturn(text);
			DateTime t = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			t = t.AddSeconds(this.TimeStamp).ToLocalTime();
			SeqList<int> sequence3List = XSingleton<XGlobalConfig>.singleton.GetSequence3List("LeagueBattleOpenDate", true);
			int count = (int)sequence3List.Count;
			DateTime dateTime = new DateTime(t.Year, sequence3List[count - 1, 0], sequence3List[count - 1, 1]);
			for (int i = (int)(sequence3List.Count - 2); i >= 0; i--)
			{
				DateTime t2 = new DateTime(t.Year, sequence3List[i + 1, 0], sequence3List[i + 1, 1]);
				DateTime dateTime2 = new DateTime(t.Year, sequence3List[i, 0], sequence3List[i, 1]);
				bool flag = t >= dateTime2 && t < t2;
				if (flag)
				{
					dateTime = dateTime2;
					break;
				}
			}
			int num = XSingleton<XGlobalConfig>.singleton.GetInt("LeagueMatchSign") - 1;
			DateTime dateTime3 = dateTime.AddDays((double)num);
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("LeagueBattleNeedLevel");
			int int2 = XSingleton<XGlobalConfig>.singleton.GetInt("LeagueTeamRoleNum");
			DateTime dateTime4 = dateTime.AddDays((double)(num + 1));
			int num2 = XSingleton<XGlobalConfig>.singleton.GetInt("LeagueRacePointLastDay") - 1;
			DateTime dateTime5 = dateTime4.AddDays((double)num2);
			int int3 = XSingleton<XGlobalConfig>.singleton.GetInt("LeagueEleminationAfterDay");
			DateTime dateTime6 = dateTime5.AddDays((double)int3);
			int int4 = XSingleton<XGlobalConfig>.singleton.GetInt("LeagueCrossRacePointAfterDay");
			DateTime dateTime7 = dateTime6.AddDays((double)(int4 + 1));
			int int5 = XSingleton<XGlobalConfig>.singleton.GetInt("LeagueCrossRacePointLastDay");
			DateTime dateTime8 = dateTime7.AddDays((double)(int5 - 1));
			int int6 = XSingleton<XGlobalConfig>.singleton.GetInt("LeagueCrossEleminationAfterDay");
			DateTime dateTime9 = dateTime8.AddDays((double)int6);
			string @string = XStringDefineProxy.GetString("TIME_FORMAT_MONTHDAY");
			return string.Format(text, new object[]
			{
				dateTime.ToString(@string),
				dateTime3.ToString(@string),
				@int,
				int2,
				dateTime4.ToString(@string),
				dateTime5.ToString(@string),
				dateTime6.ToString(@string),
				dateTime7.ToString(@string),
				dateTime8.ToString(@string),
				dateTime9.ToString(@string)
			});
		}

		// Token: 0x04002D51 RID: 11601
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FreeTeamVersusLeagueDocument");

		// Token: 0x04002D52 RID: 11602
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002D53 RID: 11603
		private LeagueTeamDetail _teamInfoDetail;

		// Token: 0x04002D54 RID: 11604
		private ulong _teamLeagueID = 0UL;

		// Token: 0x04002D55 RID: 11605
		private bool _isOpen = false;

		// Token: 0x04002D56 RID: 11606
		private bool _isCross = false;

		// Token: 0x04002D57 RID: 11607
		private bool _isTeamMatching = false;

		// Token: 0x04002D59 RID: 11609
		private LeagueTeamDetail _eliChampionTeam;

		// Token: 0x04002D5A RID: 11610
		private static LeagueRankReward leagueRankRewardTable = new LeagueRankReward();

		// Token: 0x04002D5B RID: 11611
		public bool MainInterfaceState = false;

		// Token: 0x04002D5C RID: 11612
		public uint TimeStamp;

		// Token: 0x04002D5D RID: 11613
		public string LeagueTeamName;

		// Token: 0x04002D5E RID: 11614
		public uint BattleScore;

		// Token: 0x04002D5F RID: 11615
		public uint BattledTimes;

		// Token: 0x04002D60 RID: 11616
		public uint BattleNumWeekly;

		// Token: 0x04002D61 RID: 11617
		public float BattleWinRate;

		// Token: 0x04002D62 RID: 11618
		public uint MyTeamRank = uint.MaxValue;

		// Token: 0x04002D63 RID: 11619
		public LeagueBattleTimeState TodayState = LeagueBattleTimeState.LBTS_BeforeOpen;

		// Token: 0x04002D64 RID: 11620
		public LeagueBattleRecordBaseInfo PKRecordBaseInfo = new LeagueBattleRecordBaseInfo();

		// Token: 0x04002D65 RID: 11621
		private uint pointRaceRewardsLeftTime = 0U;

		// Token: 0x04002D66 RID: 11622
		private uint crossRewardsLeftTime = 0U;

		// Token: 0x04002D67 RID: 11623
		private uint updateTime = 0U;

		// Token: 0x04002D68 RID: 11624
		private List<LeagueTeamDetailInfo> _teamInfoList = new List<LeagueTeamDetailInfo>();

		// Token: 0x04002D69 RID: 11625
		private List<LeaguePKRecordInfo> _pkRecordList = new List<LeaguePKRecordInfo>();

		// Token: 0x04002D6A RID: 11626
		private SortedDictionary<uint, List<LBEleRoomInfo>> _eliminationVersusDic = new SortedDictionary<uint, List<LBEleRoomInfo>>();
	}
}
