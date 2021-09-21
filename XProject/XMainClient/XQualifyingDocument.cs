using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009BC RID: 2492
	internal class XQualifyingDocument : XDocComponent
	{
		// Token: 0x17002D6E RID: 11630
		// (get) Token: 0x060096E9 RID: 38633 RVA: 0x0016D9F4 File Offset: 0x0016BBF4
		public override uint ID
		{
			get
			{
				return XQualifyingDocument.uuID;
			}
		}

		// Token: 0x17002D6F RID: 11631
		// (get) Token: 0x060096EA RID: 38634 RVA: 0x0016DA0C File Offset: 0x0016BC0C
		public uint MatchTime
		{
			get
			{
				return this._matchTime;
			}
		}

		// Token: 0x17002D70 RID: 11632
		// (get) Token: 0x060096EB RID: 38635 RVA: 0x0016DA24 File Offset: 0x0016BC24
		public uint CurrentTime
		{
			get
			{
				return this._currentTime;
			}
		}

		// Token: 0x17002D71 RID: 11633
		// (get) Token: 0x060096EC RID: 38636 RVA: 0x0016DA3C File Offset: 0x0016BC3C
		public bool IsMatching
		{
			get
			{
				return this._isMatching;
			}
		}

		// Token: 0x17002D72 RID: 11634
		// (get) Token: 0x060096ED RID: 38637 RVA: 0x0016DA54 File Offset: 0x0016BC54
		public uint RankRewardLeftTime
		{
			get
			{
				return this._rankRewardLeftTime;
			}
		}

		// Token: 0x17002D73 RID: 11635
		// (get) Token: 0x060096EE RID: 38638 RVA: 0x0016DA6C File Offset: 0x0016BC6C
		public float RewardSignTime
		{
			get
			{
				return this._rewardSignTime;
			}
		}

		// Token: 0x17002D74 RID: 11636
		// (get) Token: 0x060096EF RID: 38639 RVA: 0x0016DA84 File Offset: 0x0016BC84
		public uint MatchTotalCount
		{
			get
			{
				return this._matchTotalWin[this.CurrentSelect] + this._matchTotalLose[this.CurrentSelect] + this._matchTotalDraw[this.CurrentSelect];
			}
		}

		// Token: 0x17002D75 RID: 11637
		// (get) Token: 0x060096F0 RID: 38640 RVA: 0x0016DAC0 File Offset: 0x0016BCC0
		public uint MatchTotalWin
		{
			get
			{
				return this._matchTotalWin[this.CurrentSelect];
			}
		}

		// Token: 0x17002D76 RID: 11638
		// (get) Token: 0x060096F1 RID: 38641 RVA: 0x0016DAE0 File Offset: 0x0016BCE0
		public uint MatchTotalDraw
		{
			get
			{
				return this._matchTotalDraw[this.CurrentSelect];
			}
		}

		// Token: 0x17002D77 RID: 11639
		// (get) Token: 0x060096F2 RID: 38642 RVA: 0x0016DB00 File Offset: 0x0016BD00
		public uint MatchTotalLose
		{
			get
			{
				return this._matchTotalLose[this.CurrentSelect];
			}
		}

		// Token: 0x17002D78 RID: 11640
		// (get) Token: 0x060096F3 RID: 38643 RVA: 0x0016DB20 File Offset: 0x0016BD20
		public uint ContinueWin
		{
			get
			{
				return this._continueWin;
			}
		}

		// Token: 0x17002D79 RID: 11641
		// (get) Token: 0x060096F4 RID: 38644 RVA: 0x0016DB38 File Offset: 0x0016BD38
		public uint ContinueLose
		{
			get
			{
				return this._continueLose;
			}
		}

		// Token: 0x17002D7A RID: 11642
		// (get) Token: 0x060096F5 RID: 38645 RVA: 0x0016DB50 File Offset: 0x0016BD50
		public List<uint> ProfessionWin
		{
			get
			{
				return this._professionWin;
			}
		}

		// Token: 0x17002D7B RID: 11643
		// (get) Token: 0x060096F6 RID: 38646 RVA: 0x0016DB68 File Offset: 0x0016BD68
		public uint MaxRewardRank
		{
			get
			{
				return XQualifyingDocument._maxRewardRank;
			}
		}

		// Token: 0x17002D7C RID: 11644
		// (get) Token: 0x060096F7 RID: 38647 RVA: 0x0016DB80 File Offset: 0x0016BD80
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

		// Token: 0x17002D7D RID: 11645
		// (get) Token: 0x060096F8 RID: 38648 RVA: 0x0016DBCC File Offset: 0x0016BDCC
		public uint MatchRank
		{
			get
			{
				return this._matchRank[this.CurrentSelect];
			}
		}

		// Token: 0x17002D7E RID: 11646
		// (get) Token: 0x060096F9 RID: 38649 RVA: 0x0016DBEC File Offset: 0x0016BDEC
		public uint WinStreak
		{
			get
			{
				return this._winStreak;
			}
		}

		// Token: 0x17002D7F RID: 11647
		// (get) Token: 0x060096FA RID: 38650 RVA: 0x0016DC04 File Offset: 0x0016BE04
		public uint WinOfPoint
		{
			get
			{
				return this._winOfPoint[this.CurrentSelect];
			}
		}

		// Token: 0x17002D80 RID: 11648
		// (get) Token: 0x060096FC RID: 38652 RVA: 0x0016DC34 File Offset: 0x0016BE34
		// (set) Token: 0x060096FB RID: 38651 RVA: 0x0016DC23 File Offset: 0x0016BE23
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

		// Token: 0x17002D81 RID: 11649
		// (get) Token: 0x060096FD RID: 38653 RVA: 0x0016DC54 File Offset: 0x0016BE54
		public uint LeftFirstRewardCount
		{
			get
			{
				return this._leftFirstRewardCount;
			}
		}

		// Token: 0x17002D82 RID: 11650
		// (get) Token: 0x060096FE RID: 38654 RVA: 0x0016DC6C File Offset: 0x0016BE6C
		public List<PkOneRecord> GameRecords
		{
			get
			{
				return this._gameRecords;
			}
		}

		// Token: 0x17002D83 RID: 11651
		// (get) Token: 0x060096FF RID: 38655 RVA: 0x0016DC84 File Offset: 0x0016BE84
		public List<BattleRecordGameInfo> GameRecords2V2
		{
			get
			{
				return this._gameRecords2V2;
			}
		}

		// Token: 0x17002D84 RID: 11652
		// (get) Token: 0x06009700 RID: 38656 RVA: 0x0016DC9C File Offset: 0x0016BE9C
		public List<PointRewardStatus> PointRewardList
		{
			get
			{
				return this._pointRewardList;
			}
		}

		// Token: 0x17002D85 RID: 11653
		// (get) Token: 0x06009701 RID: 38657 RVA: 0x0016DCB4 File Offset: 0x0016BEB4
		public List<RankRewardStatus> RankRewardList
		{
			get
			{
				return this._rankRewardList;
			}
		}

		// Token: 0x17002D86 RID: 11654
		// (get) Token: 0x06009702 RID: 38658 RVA: 0x0016DCCC File Offset: 0x0016BECC
		public List<List<QualifyingRankInfo>> RankList
		{
			get
			{
				return this._rankList;
			}
		}

		// Token: 0x17002D87 RID: 11655
		// (get) Token: 0x06009703 RID: 38659 RVA: 0x0016DCE4 File Offset: 0x0016BEE4
		// (set) Token: 0x06009704 RID: 38660 RVA: 0x0016DCFC File Offset: 0x0016BEFC
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

		// Token: 0x06009705 RID: 38661 RVA: 0x0016DD08 File Offset: 0x0016BF08
		public void SetCurrentSys(int num)
		{
			this.CurrentSelect = num;
			bool flag = DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.Refresh(true);
			}
		}

		// Token: 0x06009706 RID: 38662 RVA: 0x0016DD38 File Offset: 0x0016BF38
		public void InitFxNum()
		{
			for (int i = 0; i < this._lastWinOfPoint.Length; i++)
			{
				this._lastWinOfPoint[i] = -1000;
			}
		}

		// Token: 0x06009707 RID: 38663 RVA: 0x0016DD6A File Offset: 0x0016BF6A
		public static void Execute(OnLoadedCallback callback = null)
		{
			XQualifyingDocument.AsyncLoader.AddTask("Table/PkPointReward", XQualifyingDocument._pkPointTable, false);
			XQualifyingDocument.AsyncLoader.AddTask("Table/PkRankReward", XQualifyingDocument._pkRankTable, false);
			XQualifyingDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009708 RID: 38664 RVA: 0x0016DDA8 File Offset: 0x0016BFA8
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

		// Token: 0x06009709 RID: 38665 RVA: 0x0016DE77 File Offset: 0x0016C077
		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			this._isMatching = false;
		}

		// Token: 0x0600970A RID: 38666 RVA: 0x0016DE88 File Offset: 0x0016C088
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

		// Token: 0x0600970B RID: 38667 RVA: 0x0016DF0C File Offset: 0x0016C10C
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

		// Token: 0x0600970C RID: 38668 RVA: 0x0016DF64 File Offset: 0x0016C164
		public void SendQueryPKInfo()
		{
			RpcC2M_PkReqC2M rpcC2M_PkReqC2M = new RpcC2M_PkReqC2M();
			rpcC2M_PkReqC2M.oArg.type = PkReqType.PKREQ_ALLINFO;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_PkReqC2M);
		}

		// Token: 0x0600970D RID: 38669 RVA: 0x0016DF94 File Offset: 0x0016C194
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

		// Token: 0x0600970E RID: 38670 RVA: 0x0016E004 File Offset: 0x0016C204
		public void SendFetchPointReward(uint index)
		{
			RpcC2M_PkReqC2M rpcC2M_PkReqC2M = new RpcC2M_PkReqC2M();
			rpcC2M_PkReqC2M.oArg.type = PkReqType.PKREQ_FETCHPOINTREWARD;
			rpcC2M_PkReqC2M.oArg.index = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_PkReqC2M);
		}

		// Token: 0x0600970F RID: 38671 RVA: 0x0016E040 File Offset: 0x0016C240
		public void SetQulifyingRewardCount(PkRecord data)
		{
			bool flag = data == null;
			if (!flag)
			{
				this._leftFirstRewardCount = data.rewardcounttoday;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Qualifying, true);
			}
		}

		// Token: 0x06009710 RID: 38672 RVA: 0x0016E074 File Offset: 0x0016C274
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

		// Token: 0x06009711 RID: 38673 RVA: 0x0016E404 File Offset: 0x0016C604
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

		// Token: 0x06009712 RID: 38674 RVA: 0x0016E564 File Offset: 0x0016C764
		public BattleRecordPlayerInfo GetOnePlayerInfo(PvpRoleBrief data)
		{
			return new BattleRecordPlayerInfo
			{
				name = data.rolename,
				profression = data.roleprofession,
				roleID = data.roleid
			};
		}

		// Token: 0x06009713 RID: 38675 RVA: 0x0016E5A4 File Offset: 0x0016C7A4
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

		// Token: 0x06009714 RID: 38676 RVA: 0x0016E604 File Offset: 0x0016C804
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

		// Token: 0x06009715 RID: 38677 RVA: 0x0016E700 File Offset: 0x0016C900
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

		// Token: 0x06009716 RID: 38678 RVA: 0x0016E7B4 File Offset: 0x0016C9B4
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

		// Token: 0x06009717 RID: 38679 RVA: 0x0016E834 File Offset: 0x0016CA34
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

		// Token: 0x06009718 RID: 38680 RVA: 0x0016E8A0 File Offset: 0x0016CAA0
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

		// Token: 0x06009719 RID: 38681 RVA: 0x0016E958 File Offset: 0x0016CB58
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

		// Token: 0x0600971A RID: 38682 RVA: 0x0016EA78 File Offset: 0x0016CC78
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

		// Token: 0x0600971B RID: 38683 RVA: 0x0016EB98 File Offset: 0x0016CD98
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

		// Token: 0x0600971C RID: 38684 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnPkHyperLinkClick(string param)
		{
		}

		// Token: 0x0600971D RID: 38685 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04003376 RID: 13174
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("QualifyingDocument");

		// Token: 0x04003377 RID: 13175
		public static readonly int DATACOUNT = 2;

		// Token: 0x04003378 RID: 13176
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003379 RID: 13177
		private uint _matchTime = 0U;

		// Token: 0x0400337A RID: 13178
		private uint _currentTime = 0U;

		// Token: 0x0400337B RID: 13179
		private bool _isMatching = false;

		// Token: 0x0400337C RID: 13180
		private uint _rankRewardLeftTime = 0U;

		// Token: 0x0400337D RID: 13181
		private float _rewardSignTime;

		// Token: 0x0400337E RID: 13182
		private uint[] _matchTotalWin = new uint[XQualifyingDocument.DATACOUNT];

		// Token: 0x0400337F RID: 13183
		private uint[] _matchTotalDraw = new uint[XQualifyingDocument.DATACOUNT];

		// Token: 0x04003380 RID: 13184
		private uint[] _matchTotalLose = new uint[XQualifyingDocument.DATACOUNT];

		// Token: 0x04003381 RID: 13185
		private uint _continueWin = 0U;

		// Token: 0x04003382 RID: 13186
		private uint _continueLose = 0U;

		// Token: 0x04003383 RID: 13187
		private List<uint> _professionWin = new List<uint>();

		// Token: 0x04003384 RID: 13188
		private uint[] _matchRank = new uint[XQualifyingDocument.DATACOUNT];

		// Token: 0x04003385 RID: 13189
		private static uint _maxRewardRank;

		// Token: 0x04003386 RID: 13190
		private uint _winStreak = 0U;

		// Token: 0x04003387 RID: 13191
		private uint[] _winOfPoint = new uint[XQualifyingDocument.DATACOUNT];

		// Token: 0x04003388 RID: 13192
		private int[] _lastWinOfPoint = new int[XQualifyingDocument.DATACOUNT];

		// Token: 0x04003389 RID: 13193
		private uint _leftFirstRewardCount = 0U;

		// Token: 0x0400338A RID: 13194
		private List<PkOneRecord> _gameRecords = new List<PkOneRecord>();

		// Token: 0x0400338B RID: 13195
		private List<BattleRecordGameInfo> _gameRecords2V2 = new List<BattleRecordGameInfo>();

		// Token: 0x0400338C RID: 13196
		private float _beginTime = 0f;

		// Token: 0x0400338D RID: 13197
		private static PkPointTable _pkPointTable = new PkPointTable();

		// Token: 0x0400338E RID: 13198
		private static PkRankTable _pkRankTable = new PkRankTable();

		// Token: 0x0400338F RID: 13199
		private List<PointRewardStatus> _pointRewardList = new List<PointRewardStatus>();

		// Token: 0x04003390 RID: 13200
		private List<RankRewardStatus> _rankRewardList = new List<RankRewardStatus>();

		// Token: 0x04003391 RID: 13201
		private List<List<QualifyingRankInfo>> _rankList = new List<List<QualifyingRankInfo>>();

		// Token: 0x04003392 RID: 13202
		public List<QualifyingRankInfo> LastSeasonRankList = new List<QualifyingRankInfo>();

		// Token: 0x04003393 RID: 13203
		private bool _redPoint = false;

		// Token: 0x04003394 RID: 13204
		public List<PkInfo> PkInfoList = new List<PkInfo>();

		// Token: 0x04003395 RID: 13205
		private bool _lastSceneIsQualifying = false;

		// Token: 0x04003396 RID: 13206
		public int CurrentSelect = 0;
	}
}
