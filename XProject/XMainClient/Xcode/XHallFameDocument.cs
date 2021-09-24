using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XHallFameDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XHallFameDocument.uuID;
			}
		}

		public static XHallFameDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XHallFameDocument.uuID) as XHallFameDocument;
			}
		}

		public List<ArenaStarType> CanSupportType
		{
			get
			{
				return this._canSupportType;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
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
			XSingleton<XDebug>.singleton.AddGreenLog("XHallFameDocument...OnDetachFromHost", null, null, null, null, null);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

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

		public void SendArenaStarRoleReq(ArenaStarReqType reqType, ArenaStarType starType, ulong roleID)
		{
			RpcC2M_ArenaStarRoleReq rpcC2M_ArenaStarRoleReq = new RpcC2M_ArenaStarRoleReq();
			rpcC2M_ArenaStarRoleReq.oArg.reqtype = reqType;
			rpcC2M_ArenaStarRoleReq.oArg.roleid = roleID;
			rpcC2M_ArenaStarRoleReq.oArg.zantype = starType;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ArenaStarRoleReq);
		}

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

		public void OnGetSupportInfo(ArenaStarPara data)
		{
			this.CanSupportType.Clear();
			for (int i = 0; i < data.newdata.Count; i++)
			{
				this.CanSupportType.Add(data.newdata[i]);
			}
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_HallFame, true);
		}

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

		public string GetVictioryAction(uint basicType)
		{
			return string.Format("Player_{0}_{1}", XSingleton<XProfessionSkillMgr>.singleton.GetLowerCaseWord(basicType), "victory");
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("HallFameDocument");

		public static readonly int Max_Role_Num = 4;

		public ulong SeasonBeginTime = 0UL;

		public ulong SeasonEndTime = 0UL;

		public uint Season_time = 0U;

		private List<HallFameRoleInfo> _list = new List<HallFameRoleInfo>(XHallFameDocument.Max_Role_Num);

		private List<ArenaStarTopRoleData> _curShowedRoleData;

		private List<ArenaStarType> _canSupportType = new List<ArenaStarType>();
	}
}
