using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XQualifyingDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XQualifyingDocument.uuID;
			}
		}

		public uint MatchTime
		{
			get
			{
				return this._matchTime;
			}
		}

		public uint CurrentTime
		{
			get
			{
				return this._currentTime;
			}
		}

		public bool IsMatching
		{
			get
			{
				return this._isMatching;
			}
		}

		public uint RankRewardLeftTime
		{
			get
			{
				return this._rankRewardLeftTime;
			}
		}

		public float RewardSignTime
		{
			get
			{
				return this._rewardSignTime;
			}
		}

		public uint MatchTotalCount
		{
			get
			{
				return this._matchTotalWin[this.CurrentSelect] + this._matchTotalLose[this.CurrentSelect] + this._matchTotalDraw[this.CurrentSelect];
			}
		}

		public uint MatchTotalWin
		{
			get
			{
				return this._matchTotalWin[this.CurrentSelect];
			}
		}

		public uint MatchTotalDraw
		{
			get
			{
				return this._matchTotalDraw[this.CurrentSelect];
			}
		}

		public uint MatchTotalLose
		{
			get
			{
				return this._matchTotalLose[this.CurrentSelect];
			}
		}

		public uint ContinueWin
		{
			get
			{
				return this._continueWin;
			}
		}

		public uint ContinueLose
		{
			get
			{
				return this._continueLose;
			}
		}

		public List<uint> ProfessionWin
		{
			get
			{
				return this._professionWin;
			}
		}

		public uint MaxRewardRank
		{
			get
			{
				return XQualifyingDocument._maxRewardRank;
			}
		}

		public uint MatchTotalPercent
		{
			get
			{
				bool flag = this.MatchTotalCount == 0U;
				uint result;
				if (flag)
				{
					result = 0U;
				}
				else
				{
					bool flag2 = this.MatchTotalWin == 0U;
					if (flag2)
					{
						result = 0U;
					}
					else
					{
						result = Math.Max(1U, 100U * this.MatchTotalWin / this.MatchTotalCount);
					}
				}
				return result;
			}
		}

		public uint MatchRank
		{
			get
			{
				return this._matchRank[this.CurrentSelect];
			}
		}

		public uint WinStreak
		{
			get
			{
				return this._winStreak;
			}
		}

		public uint WinOfPoint
		{
			get
			{
				return this._winOfPoint[this.CurrentSelect];
			}
		}

		public int LastWinOfPoint
		{
			get
			{
				return this._lastWinOfPoint[this.CurrentSelect];
			}
			set
			{
				this._lastWinOfPoint[this.CurrentSelect] = value;
			}
		}

		public uint LeftFirstRewardCount
		{
			get
			{
				return this._leftFirstRewardCount;
			}
		}

		public List<PkOneRecord> GameRecords
		{
			get
			{
				return this._gameRecords;
			}
		}

		public List<BattleRecordGameInfo> GameRecords2V2
		{
			get
			{
				return this._gameRecords2V2;
			}
		}

		public List<PointRewardStatus> PointRewardList
		{
			get
			{
				return this._pointRewardList;
			}
		}

		public List<RankRewardStatus> RankRewardList
		{
			get
			{
				return this._rankRewardList;
			}
		}

		public List<List<QualifyingRankInfo>> RankList
		{
			get
			{
				return this._rankList;
			}
		}

		public bool RedPoint
		{
			get
			{
				return this._redPoint;
			}
			set
			{
				this._redPoint = value;
			}
		}

		public void SetCurrentSys(int num)
		{
			this.CurrentSelect = num;
			bool flag = DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.Refresh(true);
			}
		}

		public void InitFxNum()
		{
			for (int i = 0; i < this._lastWinOfPoint.Length; i++)
			{
				this._lastWinOfPoint[i] = -1000;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XQualifyingDocument.AsyncLoader.AddTask("Table/PkPointReward", XQualifyingDocument._pkPointTable, false);
			XQualifyingDocument.AsyncLoader.AddTask("Table/PkRankReward", XQualifyingDocument._pkRankTable, false);
			XQualifyingDocument.AsyncLoader.Execute(callback);
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			DlgBase<XPkLoadingView, XPkLoadingBehaviour>.singleton.HidePkLoading();
			DlgBase<XMultiPkLoadingView, XMultiPkLoadingBehaviour>.singleton.HidePkLoading();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall && this._lastSceneIsQualifying;
			if (flag)
			{
				this._lastSceneIsQualifying = false;
				this.SendQueryPKInfo();
			}
			bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PK || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PKTWO;
			if (flag2)
			{
				this._lastSceneIsQualifying = true;
			}
			bool flag3 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PKTWO;
			if (flag3)
			{
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				bool flag4 = !XSingleton<XScene>.singleton.bSpectator && !specificDocument.bInTeam;
				if (flag4)
				{
					XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_Qualifying, EXStage.Hall);
				}
			}
		}

		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			this._isMatching = false;
		}

		public void SendBeginMatch()
		{
			bool flag = this.CurrentSelect == 0;
			if (flag)
			{
				RpcC2M_PkReqC2M rpcC2M_PkReqC2M = new RpcC2M_PkReqC2M();
				rpcC2M_PkReqC2M.oArg.type = PkReqType.PKREQ_ADDPK;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_PkReqC2M);
			}
			else
			{
				bool isMatching = this.IsMatching;
				if (isMatching)
				{
					RpcC2M_PkReqC2M rpcC2M_PkReqC2M2 = new RpcC2M_PkReqC2M();
					rpcC2M_PkReqC2M2.oArg.type = PkReqType.PKREQ_REMOVEPK;
					XSingleton<XClientNetwork>.singleton.Send(rpcC2M_PkReqC2M2);
				}
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				specificDocument.ReqMatchStateChange(KMatchType.KMT_PKTWO, KMatchOp.KMATCH_OP_START, false);
			}
		}

		public void SendEndMatch()
		{
			bool flag = this.CurrentSelect == 0;
			if (flag)
			{
				RpcC2M_PkReqC2M rpcC2M_PkReqC2M = new RpcC2M_PkReqC2M();
				rpcC2M_PkReqC2M.oArg.type = PkReqType.PKREQ_REMOVEPK;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_PkReqC2M);
			}
			else
			{
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				specificDocument.ReqMatchStateChange(KMatchType.KMT_PKTWO, KMatchOp.KMATCH_OP_STOP, false);
			}
		}

		public void SendQueryPKInfo()
		{
			RpcC2M_PkReqC2M rpcC2M_PkReqC2M = new RpcC2M_PkReqC2M();
			rpcC2M_PkReqC2M.oArg.type = PkReqType.PKREQ_ALLINFO;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_PkReqC2M);
		}

		public void SendQueryRankInfo(uint profession)
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			bool flag = this.CurrentSelect == 0;
			if (flag)
			{
				rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.PkRealTimeRank);
			}
			else
			{
				rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.PkRank2v2);
			}
			rpcC2M_ClientQueryRankListNtf.oArg.TimeStamp = 1U;
			rpcC2M_ClientQueryRankListNtf.oArg.profession = profession;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		public void SendFetchPointReward(uint index)
		{
			RpcC2M_PkReqC2M rpcC2M_PkReqC2M = new RpcC2M_PkReqC2M();
			rpcC2M_PkReqC2M.oArg.type = PkReqType.PKREQ_FETCHPOINTREWARD;
			rpcC2M_PkReqC2M.oArg.index = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_PkReqC2M);
		}

		public void SetQulifyingRewardCount(PkRecord data)
		{
			bool flag = data == null;
			if (!flag)
			{
				this._leftFirstRewardCount = data.rewardcounttoday;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Qualifying, true);
			}
		}

		public void SetQualifyingInfo(QueryPkInfoRes oRes)
		{
			this._matchTotalWin[0] = oRes.info.histweek.win;
			this._matchTotalDraw[0] = oRes.info.histweek.draw;
			this._matchTotalLose[0] = oRes.info.histweek.lose;
			this._matchTotalWin[1] = oRes.info.info2v2.seasondata.win;
			this._matchTotalDraw[1] = oRes.info.info2v2.seasondata.draw;
			this._matchTotalLose[1] = oRes.info.info2v2.seasondata.lose;
			this._matchRank[0] = oRes.rank1v1;
			this._matchRank[1] = oRes.rank2v2;
			this._winOfPoint[0] = oRes.info.point;
			this._winOfPoint[1] = oRes.info.info2v2.point;
			this._leftFirstRewardCount = oRes.rewardcount;
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Qualifying, true);
			this._winStreak = oRes.info.histweek.continuewin;
			this._rankRewardLeftTime = oRes.rankrewardleftT;
			this._rewardSignTime = Time.time;
			XQualifyingDocument._maxRewardRank = XQualifyingDocument._pkRankTable.Table[XQualifyingDocument._pkRankTable.Table.Length - 1].rank[1];
			this.RedPoint = false;
			this._pointRewardList.Clear();
			for (int i = 0; i < XQualifyingDocument._pkPointTable.Table.Length; i++)
			{
				PointRewardStatus pointRewardStatus = new PointRewardStatus();
				pointRewardStatus.point = XQualifyingDocument._pkPointTable.Table[i].point;
				pointRewardStatus.reward = XQualifyingDocument._pkPointTable.Table[i].reward;
				bool flag = i < oRes.info.boxtaken.Count;
				if (flag)
				{
					pointRewardStatus.status = oRes.info.boxtaken[i];
					bool flag2 = oRes.info.boxtaken[i] == 1U;
					if (flag2)
					{
						this.RedPoint = true;
					}
				}
				else
				{
					pointRewardStatus.status = 0U;
				}
				this._pointRewardList.Add(pointRewardStatus);
			}
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Qualifying, true);
			this._rankRewardList.Clear();
			for (int j = 0; j < XQualifyingDocument._pkRankTable.Table.Length; j++)
			{
				RankRewardStatus rankRewardStatus = new RankRewardStatus();
				rankRewardStatus.rank = XQualifyingDocument._pkRankTable.Table[j].rank[1];
				rankRewardStatus.reward = XQualifyingDocument._pkRankTable.Table[j].reward;
				rankRewardStatus.isRange = (XQualifyingDocument._pkRankTable.Table[j].rank[0] != XQualifyingDocument._pkRankTable.Table[j].rank[1]);
				this._rankRewardList.Add(rankRewardStatus);
			}
			this._gameRecords.Clear();
			for (int k = oRes.info.records.Count - 1; k >= 0; k--)
			{
				this._gameRecords.Add(oRes.info.records[k]);
			}
			this.Set2V2BattleRecord(oRes.info.info2v2.recs);
			bool flag3 = DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.IsVisible();
			if (flag3)
			{
				DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.Refresh(false);
			}
		}

		public void Set2V2BattleRecord(List<PkOneRec> list)
		{
			this._gameRecords2V2.Clear();
			for (int i = 0; i < list.Count; i++)
			{
				BattleRecordGameInfo battleRecordGameInfo = new BattleRecordGameInfo();
				for (int j = 0; j < list[i].myside.Count; j++)
				{
					bool flag = list[i].myside[j].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag)
					{
						battleRecordGameInfo.left.Insert(0, this.GetOnePlayerInfo(list[i].myside[j]));
					}
					else
					{
						battleRecordGameInfo.left.Add(this.GetOnePlayerInfo(list[i].myside[j]));
					}
				}
				for (int k = 0; k < list[i].opside.Count; k++)
				{
					battleRecordGameInfo.right.Add(this.GetOnePlayerInfo(list[i].opside[k]));
				}
				battleRecordGameInfo.result = (HeroBattleOver)XFastEnumIntEqualityComparer<PkResultType>.ToInt(list[i].ret);
				battleRecordGameInfo.point2V2 = list[i].cpoint;
				this._gameRecords2V2.Add(battleRecordGameInfo);
			}
		}

		public BattleRecordPlayerInfo GetOnePlayerInfo(PvpRoleBrief data)
		{
			return new BattleRecordPlayerInfo
			{
				name = data.rolename,
				profression = data.roleprofession,
				roleID = data.roleid
			};
		}

		public int GetIconIndex(uint point)
		{
			int result = 0;
			for (int i = 0; i < XQualifyingDocument._pkPointTable.Table.Length; i++)
			{
				bool flag = point > XQualifyingDocument._pkPointTable.Table[i].point;
				if (flag)
				{
					result = XQualifyingDocument._pkPointTable.Table[i].IconIndex;
				}
			}
			return result;
		}

		public void SetChallengeRecordInfo(QueryPkInfoRes oRes)
		{
			this._continueWin = oRes.info.histweek.continuewin;
			this._continueLose = oRes.info.histweek.continuelose;
			this._professionWin.Clear();
			for (int i = 0; i < oRes.info.prowin.Count; i++)
			{
				uint num = oRes.info.prowin[i] + oRes.info.prolose[i];
				bool flag = num == 0U;
				if (flag)
				{
					this._professionWin.Add(0U);
				}
				else
				{
					bool flag2 = oRes.info.prowin[i] == 0U;
					if (flag2)
					{
						this._professionWin.Add(0U);
					}
					else
					{
						this._professionWin.Add(Math.Max(1U, 100U * oRes.info.prowin[i] / num));
					}
				}
			}
		}

		public void SetMatchTime(uint time, bool status)
		{
			this._matchTime = time;
			this._isMatching = status;
			this._currentTime = 0U;
			bool flag = !DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				bool flag2 = !this.IsMatching;
				if (flag2)
				{
					DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.SetBeginMatchButton(XStringDefineProxy.GetString("BEGIN_MATCH"));
				}
				else
				{
					DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.SetBeginMatchButton(string.Format("{0}...\n{1}", XStringDefineProxy.GetString("MATCHING"), XStringDefineProxy.GetString("LEFT_MATCH_TIME", new object[]
					{
						this.CurrentTime,
						this.MatchTime
					})));
					this._beginTime = Time.time;
				}
			}
		}

		public void SetMatchButtonTime()
		{
			bool flag = !DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				this._currentTime = (uint)(Time.time - this._beginTime);
				DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.SetBeginMatchButton(string.Format("{0}...\n{1}", XStringDefineProxy.GetString("MATCHING"), XStringDefineProxy.GetString("LEFT_MATCH_TIME", new object[]
				{
					this.CurrentTime,
					this.MatchTime
				})));
			}
		}

		public int PointRewardCompare(int reward1, int reward2)
		{
			int num = (int)this.PointRewardList[reward1].status;
			int num2 = (int)this.PointRewardList[reward2].status;
			bool flag = num == 2;
			if (flag)
			{
				num = -1;
			}
			bool flag2 = num2 == 2;
			if (flag2)
			{
				num2 = -1;
			}
			bool flag3 = num2 == num;
			int result;
			if (flag3)
			{
				result = reward1.CompareTo(reward2);
			}
			else
			{
				result = num2.CompareTo(num);
			}
			return result;
		}

		public void RefreshPointReward(uint index)
		{
			this._pointRewardList[(int)index].status = 2U;
			this.RedPoint = false;
			for (int i = 0; i < XQualifyingDocument._pkPointTable.Table.Length; i++)
			{
				bool flag = this._pointRewardList[i].status == 1U;
				if (flag)
				{
					this.RedPoint = true;
					break;
				}
			}
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Qualifying, true);
			bool flag2 = !DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.IsVisible();
			if (!flag2)
			{
				DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.uiBehaviour.m_PointRewardRedPoint.gameObject.SetActive(this.RedPoint);
				DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.SetupPointRewardWindow(false);
			}
		}

		public void OnGetRankInfo(ClientQueryRankListRes oRes, int profession)
		{
			this._rankList[profession].Clear();
			for (int i = 0; i < oRes.RankList.RankData.Count; i++)
			{
				QualifyingRankInfo qualifyingRankInfo = new QualifyingRankInfo();
				qualifyingRankInfo.uid = oRes.RankList.RankData[i].RoleId;
				qualifyingRankInfo.rank = (uint)(i + 1);
				qualifyingRankInfo.level = oRes.RankList.RankData[i].RoleLevel;
				qualifyingRankInfo.name = oRes.RankList.RankData[i].RoleName;
				qualifyingRankInfo.point = oRes.RankList.RankData[i].pkpoint;
				this._rankList[profession].Add(qualifyingRankInfo);
			}
			bool flag = !DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				bool isVisible = DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.uiBehaviour.m_RankWindow.IsVisible;
				if (isVisible)
				{
					DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.SetupRankWindow(this.RankList[profession]);
				}
			}
		}

		public void OnGetLastSeasonRankInfo(ClientQueryRankListRes oRes)
		{
			bool flag = oRes.RankList == null;
			if (!flag)
			{
				this.LastSeasonRankList.Clear();
				for (int i = 0; i < oRes.RankList.RankData.Count; i++)
				{
					QualifyingRankInfo qualifyingRankInfo = new QualifyingRankInfo();
					qualifyingRankInfo.uid = oRes.RankList.RankData[i].RoleId;
					qualifyingRankInfo.rank = (uint)(i + 1);
					qualifyingRankInfo.level = oRes.RankList.RankData[i].RoleLevel;
					qualifyingRankInfo.name = oRes.RankList.RankData[i].RoleName;
					qualifyingRankInfo.point = oRes.RankList.RankData[i].pkpoint;
					bool flag2 = oRes.RankList.RankData[i].pkextradata != null;
					if (flag2)
					{
						qualifyingRankInfo.totalNum = oRes.RankList.RankData[i].pkextradata.joincount;
					}
					this.LastSeasonRankList.Add(qualifyingRankInfo);
				}
			}
		}

		public void SetPkRoleInfo(List<PkRoleInfo> otherInfo)
		{
			this.PkInfoList.Clear();
			int num = -1;
			for (int i = 0; i < otherInfo.Count; i++)
			{
				PkInfo pkInfo = new PkInfo();
				pkInfo.brief = otherInfo[i].rolebrief;
				pkInfo.lose = otherInfo[i].pkrec.lose;
				pkInfo.point = otherInfo[i].pkrec.point;
				pkInfo.records = otherInfo[i].pkrec.records;
				pkInfo.win = otherInfo[i].pkrec.win;
				bool flag = pkInfo.brief.roleID != XSingleton<XAttributeMgr>.singleton.XPlayerData.EntityID;
				if (flag)
				{
					this.PkInfoList.Add(pkInfo);
				}
				else
				{
					bool flag2 = i < 2;
					if (flag2)
					{
						num = 1 - i;
					}
					else
					{
						num = 5 - i;
					}
					this.PkInfoList.Insert(0, pkInfo);
				}
			}
			bool flag3 = num != -1 && num < otherInfo.Count;
			if (flag3)
			{
				int num2 = 2;
				while (num2 < 4 && num2 < this.PkInfoList.Count)
				{
					bool flag4 = this.PkInfoList[num2].brief.roleID == otherInfo[num].rolebrief.roleID;
					if (flag4)
					{
						PkInfo item = this.PkInfoList[num2];
						this.PkInfoList.RemoveAt(num2);
						this.PkInfoList.Insert(1, item);
						break;
					}
					num2++;
				}
			}
		}

		public static void OnPkHyperLinkClick(string param)
		{
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("QualifyingDocument");

		public static readonly int DATACOUNT = 2;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private uint _matchTime = 0U;

		private uint _currentTime = 0U;

		private bool _isMatching = false;

		private uint _rankRewardLeftTime = 0U;

		private float _rewardSignTime;

		private uint[] _matchTotalWin = new uint[XQualifyingDocument.DATACOUNT];

		private uint[] _matchTotalDraw = new uint[XQualifyingDocument.DATACOUNT];

		private uint[] _matchTotalLose = new uint[XQualifyingDocument.DATACOUNT];

		private uint _continueWin = 0U;

		private uint _continueLose = 0U;

		private List<uint> _professionWin = new List<uint>();

		private uint[] _matchRank = new uint[XQualifyingDocument.DATACOUNT];

		private static uint _maxRewardRank;

		private uint _winStreak = 0U;

		private uint[] _winOfPoint = new uint[XQualifyingDocument.DATACOUNT];

		private int[] _lastWinOfPoint = new int[XQualifyingDocument.DATACOUNT];

		private uint _leftFirstRewardCount = 0U;

		private List<PkOneRecord> _gameRecords = new List<PkOneRecord>();

		private List<BattleRecordGameInfo> _gameRecords2V2 = new List<BattleRecordGameInfo>();

		private float _beginTime = 0f;

		private static PkPointTable _pkPointTable = new PkPointTable();

		private static PkRankTable _pkRankTable = new PkRankTable();

		private List<PointRewardStatus> _pointRewardList = new List<PointRewardStatus>();

		private List<RankRewardStatus> _rankRewardList = new List<RankRewardStatus>();

		private List<List<QualifyingRankInfo>> _rankList = new List<List<QualifyingRankInfo>>();

		public List<QualifyingRankInfo> LastSeasonRankList = new List<QualifyingRankInfo>();

		private bool _redPoint = false;

		public List<PkInfo> PkInfoList = new List<PkInfo>();

		private bool _lastSceneIsQualifying = false;

		public int CurrentSelect = 0;
	}
}
