using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFreeTeamVersusLeagueDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XFreeTeamVersusLeagueDocument.uuID;
			}
		}

		public static XFreeTeamVersusLeagueDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XFreeTeamVersusLeagueDocument.uuID) as XFreeTeamVersusLeagueDocument;
			}
		}

		public static LeagueRankReward LeagueRankRewardTable
		{
			get
			{
				return XFreeTeamVersusLeagueDocument.leagueRankRewardTable;
			}
		}

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

		public ulong TeamLeagueID
		{
			get
			{
				return this._teamLeagueID;
			}
		}

		public bool IsOpen
		{
			get
			{
				return this._isOpen;
			}
		}

		public bool IsCross
		{
			get
			{
				return this._isCross;
			}
		}

		public bool IsTeamMatching
		{
			get
			{
				return this._isTeamMatching;
			}
		}

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

		public LeagueEliType EliStateType { get; private set; }

		public static void Execute(OnLoadedCallback callback = null)
		{
			XFreeTeamVersusLeagueDocument.AsyncLoader.AddTask("Table/LeagueRankReward", XFreeTeamVersusLeagueDocument.LeagueRankRewardTable, false);
			XFreeTeamVersusLeagueDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

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

		public void OnGetLeagueSeasonInfo(PtcM2C_UpdateLeagueBattleSeasonInfo roPtc)
		{
			this._teamLeagueID = roPtc.Data.league_teamid;
			this._isCross = roPtc.Data.is_cross;
			this._isOpen = roPtc.Data.is_open;
			this.TodayState = roPtc.Data.state;
		}

		public void SendGetLeagueTeamInfo(ulong teamID)
		{
			RpcC2M_GetLeagueTeamInfo rpcC2M_GetLeagueTeamInfo = new RpcC2M_GetLeagueTeamInfo();
			rpcC2M_GetLeagueTeamInfo.oArg.league_teamid = teamID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetLeagueTeamInfo);
		}

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

		public void SendGetLeagueBattleInfo()
		{
			RpcC2M_GetLeagueBattleInfo rpc = new RpcC2M_GetLeagueBattleInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public int GetPkRecordCount()
		{
			return this._pkRecordList.Count;
		}

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

		public void SendGetLeagueBattleRecord()
		{
			RpcC2M_GetLeagueBattleRecord rpc = new RpcC2M_GetLeagueBattleRecord();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public int GetMyTeamMemberCount()
		{
			return this._teamInfoList.Count;
		}

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

		public LeagueTeamMemberDetail GetTeamMemberInfoByRoleID(ulong roleID)
		{
			return null;
		}

		public void SetMainInterfaceBtnState(bool state)
		{
			this.MainInterfaceState = state;
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_TeamLeague, true);
			}
		}

		public void OnTeamLeagueCreateNtf(PtcM2C_NotifyLeagueTeamCreate roPtc)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_LEAGUE_CREATE_SUCC"), "fece00");
			this._teamLeagueID = roPtc.Data.league_teamid;
			this.LeagueTeamName = roPtc.Data.name;
		}

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

		public void ReqLeaveTeamLeague()
		{
			RpcC2M_LeaveLeagueTeam rpc = new RpcC2M_LeaveLeagueTeam();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReqMatchGame(bool match)
		{
			RpcC2M_LeagueBattleReq rpcC2M_LeagueBattleReq = new RpcC2M_LeagueBattleReq();
			rpcC2M_LeagueBattleReq.oArg.type = (match ? LeagueBattleReqType.LBReqType_Match : LeagueBattleReqType.LBReqType_CancelMatch);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_LeagueBattleReq);
		}

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

		public void SendGetLeagueEleInfo()
		{
			RpcC2M_GetLeagueEleInfo rpc = new RpcC2M_GetLeagueEleInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public List<LBEleRoomInfo> GetRoomsInfoByRound(uint round)
		{
			List<LBEleRoomInfo> result = null;
			this._eliminationVersusDic.TryGetValue(round, out result);
			return result;
		}

		public void SendJoinLeagueEleBattle()
		{
			RpcC2M_JoinLeagueEleBattle rpc = new RpcC2M_JoinLeagueEleBattle();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void SendCloseLeagueEleNtf()
		{
			PtcC2M_CloseLeagueEleNtf proto = new PtcC2M_CloseLeagueEleNtf();
			XSingleton<XClientNetwork>.singleton.Send(proto);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FreeTeamVersusLeagueDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private LeagueTeamDetail _teamInfoDetail;

		private ulong _teamLeagueID = 0UL;

		private bool _isOpen = false;

		private bool _isCross = false;

		private bool _isTeamMatching = false;

		private LeagueTeamDetail _eliChampionTeam;

		private static LeagueRankReward leagueRankRewardTable = new LeagueRankReward();

		public bool MainInterfaceState = false;

		public uint TimeStamp;

		public string LeagueTeamName;

		public uint BattleScore;

		public uint BattledTimes;

		public uint BattleNumWeekly;

		public float BattleWinRate;

		public uint MyTeamRank = uint.MaxValue;

		public LeagueBattleTimeState TodayState = LeagueBattleTimeState.LBTS_BeforeOpen;

		public LeagueBattleRecordBaseInfo PKRecordBaseInfo = new LeagueBattleRecordBaseInfo();

		private uint pointRaceRewardsLeftTime = 0U;

		private uint crossRewardsLeftTime = 0U;

		private uint updateTime = 0U;

		private List<LeagueTeamDetailInfo> _teamInfoList = new List<LeagueTeamDetailInfo>();

		private List<LeaguePKRecordInfo> _pkRecordList = new List<LeaguePKRecordInfo>();

		private SortedDictionary<uint, List<LBEleRoomInfo>> _eliminationVersusDic = new SortedDictionary<uint, List<LBEleRoomInfo>>();
	}
}
