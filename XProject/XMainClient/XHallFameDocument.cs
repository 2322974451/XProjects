using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000913 RID: 2323
	internal class XHallFameDocument : XDocComponent
	{
		// Token: 0x17002B6D RID: 11117
		// (get) Token: 0x06008C1E RID: 35870 RVA: 0x0012EAA8 File Offset: 0x0012CCA8
		public override uint ID
		{
			get
			{
				return XHallFameDocument.uuID;
			}
		}

		// Token: 0x17002B6E RID: 11118
		// (get) Token: 0x06008C1F RID: 35871 RVA: 0x0012EAC0 File Offset: 0x0012CCC0
		public static XHallFameDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XHallFameDocument.uuID) as XHallFameDocument;
			}
		}

		// Token: 0x17002B6F RID: 11119
		// (get) Token: 0x06008C20 RID: 35872 RVA: 0x0012EAEC File Offset: 0x0012CCEC
		public List<ArenaStarType> CanSupportType
		{
			get
			{
				return this._canSupportType;
			}
		}

		// Token: 0x06008C21 RID: 35873 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void Execute(OnLoadedCallback callback = null)
		{
		}

		// Token: 0x06008C22 RID: 35874 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06008C23 RID: 35875 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x06008C24 RID: 35876 RVA: 0x0012EB04 File Offset: 0x0012CD04
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			XSingleton<XDebug>.singleton.AddGreenLog("XHallFameDocument...OnDetachFromHost", null, null, null, null, null);
		}

		// Token: 0x06008C25 RID: 35877 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008C26 RID: 35878 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x06008C27 RID: 35879 RVA: 0x0012EB24 File Offset: 0x0012CD24
		public List<HallFameRoleInfo> GetRankInfoListBySysID(ArenaStarType id)
		{
			this._list.Clear();
			XRankType rankTypeByStarType = this.GetRankTypeByStarType(id);
			bool flag = rankTypeByStarType != XRankType.InValid;
			if (flag)
			{
				int rankListCountByType = this.GetRankListCountByType(id);
				for (int i = 0; i < this._curShowedRoleData.Count; i++)
				{
					HallFameRoleInfo hallFameRoleInfo = new HallFameRoleInfo();
					hallFameRoleInfo.OutLook = this._curShowedRoleData[i].outlook;
					hallFameRoleInfo.hisData = this._curShowedRoleData[i].historydata;
					this._list.Add(hallFameRoleInfo);
					switch (rankTypeByStarType)
					{
					case XRankType.LastWeek_PKRank:
					{
						bool flag2 = i < rankListCountByType;
						if (flag2)
						{
							XQualifyingDocument specificDocument = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
							QualifyingRankInfo qualifyingRankInfo = specificDocument.LastSeasonRankList[i];
							hallFameRoleInfo.LastData.Add((int)qualifyingRankInfo.point);
							hallFameRoleInfo.LastData.Add((int)qualifyingRankInfo.totalNum);
							hallFameRoleInfo.Rank = (uint)(i + 1);
							hallFameRoleInfo.TeamName = "";
						}
						break;
					}
					case XRankType.LastWeek_NestWeekRank:
					{
						FirstPassRankList lastWeekRankList = XWeekNestDocument.Doc.LastWeekRankList;
						hallFameRoleInfo.LastData.Add((int)lastWeekRankList.InfoList[0].UseTime);
						hallFameRoleInfo.Rank = 1U;
						hallFameRoleInfo.TeamName = "";
						break;
					}
					case XRankType.LastWeek_HeroBattleRank:
					{
						bool flag3 = i < rankListCountByType;
						if (flag3)
						{
							XHeroBattleDocument specificDocument2 = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
							HeroBattleRankData heroBattleRankData = specificDocument2.LastWeek_MainRankList[i];
							hallFameRoleInfo.LastData.Add((int)heroBattleRankData.fightTotal);
							hallFameRoleInfo.LastData.Add((int)heroBattleRankData.maxContinue);
							hallFameRoleInfo.LastData.Add((int)(heroBattleRankData.winTotal / heroBattleRankData.fightTotal * 100f));
							hallFameRoleInfo.LastData.Add((int)heroBattleRankData.maxKills);
							hallFameRoleInfo.Rank = (uint)(i + 1);
							hallFameRoleInfo.TeamName = "";
						}
						break;
					}
					case XRankType.LastWeek_LeagueTeamRank:
					{
						XRankDocument specificDocument3 = XDocuments.GetSpecificDocument<XRankDocument>(XRankDocument.uuID);
						XBaseRankList rankList = specificDocument3.GetRankList(rankTypeByStarType);
						bool flag4 = rankList.rankList.Count > 0;
						if (flag4)
						{
							XBaseRankInfo xbaseRankInfo = rankList.rankList[0];
							XLeagueTeamRankInfo xleagueTeamRankInfo = xbaseRankInfo as XLeagueTeamRankInfo;
							hallFameRoleInfo.LastData.Add((int)xleagueTeamRankInfo.point);
							hallFameRoleInfo.LastData.Add((int)xleagueTeamRankInfo.winNum);
							hallFameRoleInfo.LastData.Add((int)(xleagueTeamRankInfo.winRate * 100f));
							hallFameRoleInfo.LastData.Add((int)xleagueTeamRankInfo.maxContineWins);
							hallFameRoleInfo.Rank = 1U;
							hallFameRoleInfo.TeamName = xleagueTeamRankInfo.teamName;
						}
						break;
					}
					}
				}
			}
			return this._list;
		}

		// Token: 0x06008C28 RID: 35880 RVA: 0x0012EE00 File Offset: 0x0012D000
		public HallFameRoleInfo GetRoleInfoByRoleID(ulong roleID)
		{
			for (int i = 0; i < this._list.Count; i++)
			{
				bool flag = this._list[i].OutLook.roleid == roleID;
				if (flag)
				{
					return this._list[i];
				}
			}
			return null;
		}

		// Token: 0x06008C29 RID: 35881 RVA: 0x0012EE5C File Offset: 0x0012D05C
		public void SendArenaStarRoleReq(ArenaStarReqType reqType, ArenaStarType starType, ulong roleID)
		{
			RpcC2M_ArenaStarRoleReq rpcC2M_ArenaStarRoleReq = new RpcC2M_ArenaStarRoleReq();
			rpcC2M_ArenaStarRoleReq.oArg.reqtype = reqType;
			rpcC2M_ArenaStarRoleReq.oArg.roleid = roleID;
			rpcC2M_ArenaStarRoleReq.oArg.zantype = starType;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ArenaStarRoleReq);
		}

		// Token: 0x06008C2A RID: 35882 RVA: 0x0012EEA4 File Offset: 0x0012D0A4
		public void OnGetStarRoleInfo(ArenaStarReqArg oArg, ArenaStarReqRes oRes)
		{
			bool flag = oArg.reqtype == ArenaStarReqType.ASRT_ROLEDATA;
			if (flag)
			{
				this._curShowedRoleData = oRes.toproledata;
				this.SeasonBeginTime = (ulong)oRes.seasonbegintime;
				this.SeasonEndTime = (ulong)oRes.seasonendtime;
				this.Season_time = oRes.season_num;
				bool flag2 = DlgBase<HallFameDlg, HallFameBehavior>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<HallFameDlg, HallFameBehavior>.singleton.RefreshRightView(oArg.zantype);
				}
			}
			else
			{
				bool flag3 = oArg.reqtype == ArenaStarReqType.ASRT_DIANZAN;
				if (flag3)
				{
					bool flag4 = this.CanSupportType.Contains(oArg.zantype);
					if (flag4)
					{
						this.CanSupportType.Remove(oArg.zantype);
					}
					bool flag5 = DlgBase<HallFameDlg, HallFameBehavior>.singleton.IsVisible();
					if (flag5)
					{
						DlgBase<HallFameDlg, HallFameBehavior>.singleton.RefreshRedPoint();
					}
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_HallFame, true);
				}
			}
		}

		// Token: 0x06008C2B RID: 35883 RVA: 0x0012EF78 File Offset: 0x0012D178
		public XRankType GetRankTypeByStarType(ArenaStarType type)
		{
			XRankType result;
			switch (type)
			{
			case ArenaStarType.AST_PK:
				result = XRankType.LastWeek_PKRank;
				break;
			case ArenaStarType.AST_HEROBATTLE:
				result = XRankType.LastWeek_HeroBattleRank;
				break;
			case ArenaStarType.AST_WEEKNEST:
				result = XRankType.LastWeek_NestWeekRank;
				break;
			case ArenaStarType.AST_LEAGUE:
				result = XRankType.LastWeek_LeagueTeamRank;
				break;
			default:
				result = XRankType.InValid;
				break;
			}
			return result;
		}

		// Token: 0x06008C2C RID: 35884 RVA: 0x0012EFBC File Offset: 0x0012D1BC
		public void OnGetSupportInfo(ArenaStarPara data)
		{
			this.CanSupportType.Clear();
			for (int i = 0; i < data.newdata.Count; i++)
			{
				this.CanSupportType.Add(data.newdata[i]);
			}
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_HallFame, true);
		}

		// Token: 0x06008C2D RID: 35885 RVA: 0x0012F018 File Offset: 0x0012D218
		public ArenaStarHistData GetHistoryDataByRoleID(ulong roleID)
		{
			for (int i = 0; i < this._list.Count; i++)
			{
				bool flag = this._list[i].OutLook.roleid == roleID;
				if (flag)
				{
					return this._list[i].hisData;
				}
			}
			return null;
		}

		// Token: 0x06008C2E RID: 35886 RVA: 0x0012F078 File Offset: 0x0012D278
		public List<int> GetLastSeasonDataByRoleID(ulong roleID)
		{
			for (int i = 0; i < this._list.Count; i++)
			{
				bool flag = this._list[i].OutLook.roleid == roleID;
				if (flag)
				{
					return this._list[i].LastData;
				}
			}
			return null;
		}

		// Token: 0x06008C2F RID: 35887 RVA: 0x0012F0D8 File Offset: 0x0012D2D8
		public string GetVictioryAction(uint basicType)
		{
			return string.Format("Player_{0}_{1}", XSingleton<XProfessionSkillMgr>.singleton.GetLowerCaseWord(basicType), "victory");
		}

		// Token: 0x06008C30 RID: 35888 RVA: 0x0012F104 File Offset: 0x0012D304
		private int GetRankListCountByType(ArenaStarType type)
		{
			int result = 0;
			XRankDocument specificDocument = XDocuments.GetSpecificDocument<XRankDocument>(XRankDocument.uuID);
			switch (type)
			{
			case ArenaStarType.AST_PK:
			{
				bool flag = specificDocument.LastWeekQualifyingRankList != null;
				if (flag)
				{
					XQualifyingDocument specificDocument2 = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
					result = specificDocument2.LastSeasonRankList.Count;
				}
				break;
			}
			case ArenaStarType.AST_HEROBATTLE:
			{
				XHeroBattleDocument specificDocument3 = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
				result = specificDocument3.LastWeek_MainRankList.Count;
				break;
			}
			case ArenaStarType.AST_WEEKNEST:
				result = XWeekNestDocument.Doc.LastWeekRankList.InfoList.Count;
				break;
			case ArenaStarType.AST_LEAGUE:
			{
				bool flag2 = specificDocument.LastWeekLeagueTeamRankList != null;
				if (flag2)
				{
					result = specificDocument.LastWeekLeagueTeamRankList.rankList.Count;
				}
				break;
			}
			}
			return result;
		}

		// Token: 0x04002D29 RID: 11561
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("HallFameDocument");

		// Token: 0x04002D2A RID: 11562
		public static readonly int Max_Role_Num = 4;

		// Token: 0x04002D2B RID: 11563
		public ulong SeasonBeginTime = 0UL;

		// Token: 0x04002D2C RID: 11564
		public ulong SeasonEndTime = 0UL;

		// Token: 0x04002D2D RID: 11565
		public uint Season_time = 0U;

		// Token: 0x04002D2E RID: 11566
		private List<HallFameRoleInfo> _list = new List<HallFameRoleInfo>(XHallFameDocument.Max_Role_Num);

		// Token: 0x04002D2F RID: 11567
		private List<ArenaStarTopRoleData> _curShowedRoleData;

		// Token: 0x04002D30 RID: 11568
		private List<ArenaStarType> _canSupportType = new List<ArenaStarType>();
	}
}
