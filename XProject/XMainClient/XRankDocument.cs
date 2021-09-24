using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XRankDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XRankDocument.uuID;
			}
		}

		public XRankView View
		{
			get
			{
				return this._view;
			}
			set
			{
				this._view = value;
			}
		}

		public static XRankDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XRankDocument.uuID) as XRankDocument;
			}
		}

		public XBaseRankList PPTRankList
		{
			get
			{
				return this._PPTRankList;
			}
		}

		public XBaseRankList LevelRankList
		{
			get
			{
				return this._LevelRankList;
			}
		}

		public XBaseRankList FashionRankList
		{
			get
			{
				return this._FashionRankList;
			}
		}

		public XGuildRankList GuildRankList
		{
			get
			{
				return this._GuildRankList;
			}
		}

		public XDragonGuildRankList DragonRankList
		{
			get
			{
				return this._DragonGuildRankList;
			}
		}

		public XTeamTowerRankList TowerRankList
		{
			get
			{
				return this._TowerRankList;
			}
		}

		public XGuildBossRankList GuildBossRankList
		{
			get
			{
				return this._GuildBossRankList;
			}
		}

		public XPetRankList PetRankList
		{
			get
			{
				return this._PetRankList;
			}
		}

		public XBigMeleeRankList BigMeleeRankList
		{
			get
			{
				return this._BigMeleeRankList;
			}
		}

		public XSkyArenaList SkyArenaList
		{
			get
			{
				return this._XSkyArenaList;
			}
		}

		public XQualifyingRankList QualifyingRankList
		{
			get
			{
				return this._QualifyingRankList;
			}
		}

		public XQualifyingRankList LastWeekQualifyingRankList
		{
			get
			{
				return this._LastWeekQualifyingRankList;
			}
		}

		public XLeagueTeamRankList LastWeekLeagueTeamRankList
		{
			get
			{
				return this._LastWeekLeagueTeamRankList;
			}
		}

		public XRiftRankList RiftRankList
		{
			get
			{
				return this._RiftRankList;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._PPTRankList = new XPPTRankList();
			this._LevelRankList = new XLevelRankList();
			this._GuildRankList = new XGuildRankList();
			this._DragonGuildRankList = new XDragonGuildRankList();
			this._FashionRankList = new XFashionRankList();
			this._TowerRankList = new XTeamTowerRankList();
			this._GuildBossRankList = new XGuildBossRankList();
			this._WorldBossRankList = new XWorldBossDamageRankList();
			this._PetRankList = new XPetRankList();
			this._SpriteRankList = new XSpriteRankList();
			this._QualifyingRankList = new XQualifyingRankList();
			this._LeagueTeamRankList = new XLeagueTeamRankList();
			this._LastWeekQualifyingRankList = new XQualifyingRankList();
			this._LastWeekLeagueTeamRankList = new XLeagueTeamRankList();
			this._BigMeleeRankList = new XBigMeleeRankList();
			this._XSkyArenaList = new XSkyArenaList();
			this._RiftRankList = new XRiftRankList();
			this._CampDuelRankLeftList = new XCampDuelRankLeftList();
			this._CampDuelRankRightList = new XCampDuelRankRightList();
			this._RankDic.Clear();
			this._RankDic.Add(XRankType.PPTRank, this._PPTRankList);
			this._RankDic.Add(XRankType.LevelRank, this._LevelRankList);
			this._RankDic.Add(XRankType.FashionRank, this._FashionRankList);
			this._RankDic.Add(XRankType.GuildRank, this._GuildRankList);
			this._RankDic.Add(XRankType.DragonGuildRank, this._DragonGuildRankList);
			this._RankDic.Add(XRankType.TeamTowerRank, this._TowerRankList);
			this._RankDic.Add(XRankType.GuildBossRank, this._GuildBossRankList);
			this._RankDic.Add(XRankType.WorldBossDamageRank, this._WorldBossRankList);
			this._RankDic.Add(XRankType.PetRank, this._PetRankList);
			this._RankDic.Add(XRankType.SpriteRank, this._SpriteRankList);
			this._RankDic.Add(XRankType.QualifyingRank, this._QualifyingRankList);
			this._RankDic.Add(XRankType.LeagueTeamRank, this._LeagueTeamRankList);
			this._RankDic.Add(XRankType.LastWeek_PKRank, this._LastWeekQualifyingRankList);
			this._RankDic.Add(XRankType.LastWeek_LeagueTeamRank, this._LastWeekLeagueTeamRankList);
			this._RankDic.Add(XRankType.BigMeleeRank, this._BigMeleeRankList);
			this._RankDic.Add(XRankType.SkyArenaRank, this._XSkyArenaList);
			this._RankDic.Add(XRankType.RiftRank, this._RiftRankList);
			this._RankDic.Add(XRankType.CampDuelRankLeft, this._CampDuelRankLeftList);
			this._RankDic.Add(XRankType.CampDuelRankRight, this._CampDuelRankRightList);
		}

		public XBaseRankList GetRankList(XRankType type)
		{
			XBaseRankList xbaseRankList;
			bool flag = this._RankDic.TryGetValue(type, out xbaseRankList);
			XBaseRankList result;
			if (flag)
			{
				result = xbaseRankList;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public void ReqPetUnitAppearance(ulong roleid, ulong petUID)
		{
			RpcC2M_GetUnitAppearanceNew rpcC2M_GetUnitAppearanceNew = new RpcC2M_GetUnitAppearanceNew();
			rpcC2M_GetUnitAppearanceNew.oArg.roleid = roleid;
			rpcC2M_GetUnitAppearanceNew.oArg.mask = XFastEnumIntEqualityComparer<UnitAppearanceField>.ToInt(UnitAppearanceField.UNIT_PETS);
			rpcC2M_GetUnitAppearanceNew.oArg.type = 6U;
			rpcC2M_GetUnitAppearanceNew.oArg.petId = petUID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetUnitAppearanceNew);
		}

		public void ReqUnitAppearance(ulong id)
		{
			RpcC2M_GetUnitAppearanceNew rpcC2M_GetUnitAppearanceNew = new RpcC2M_GetUnitAppearanceNew();
			rpcC2M_GetUnitAppearanceNew.oArg.roleid = id;
			rpcC2M_GetUnitAppearanceNew.oArg.type = 1U;
			rpcC2M_GetUnitAppearanceNew.oArg.mask = 17301711;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetUnitAppearanceNew);
		}

		public void OnGetUnitAppearance(GetUnitAppearanceRes oRes)
		{
			bool flag = oRes.UnitAppearance == null;
			if (!flag)
			{
				bool flag2 = this.View != null && this.View.IsVisible();
				if (flag2)
				{
					this.View.UpdateCharacterInfo(oRes);
				}
			}
		}

		public void ReqRankList(XRankType type)
		{
			XBaseRankList rankList = this.GetRankList(type);
			bool flag = rankList != null;
			if (flag)
			{
				RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
				rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(XBaseRankList.GetKKSGType(type));
				rpcC2M_ClientQueryRankListNtf.oArg.TimeStamp = rankList.timeStamp;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Rank type not init: ", type.ToString(), null, null, null, null);
			}
		}

		public void OnGetRankList(ClientQueryRankListRes oRes)
		{
			XRankType xtype = XBaseRankList.GetXType((RankeType)oRes.RankType);
			bool flag = xtype != XRankType.LeagueTeamRank;
			if (flag)
			{
				this.currentSelectRankList = xtype;
			}
			bool flag2 = oRes.ErrorCode == ErrorCode.ERR_SUCCESS;
			if (flag2)
			{
				XBaseRankList rankList = this.GetRankList(xtype);
				bool flag3 = rankList != null;
				if (flag3)
				{
					bool flag4 = oRes.RankList != null;
					if (flag4)
					{
						rankList.timeStamp = oRes.TimeStamp;
						XRankDocument.ProcessRankListData(oRes.RankList, rankList);
						XRankDocument.ProcessSelfRankData(oRes, rankList);
					}
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Rank type not inited: ", xtype.ToString(), null, null, null, null);
				}
			}
			bool flag5 = xtype != XRankType.LeagueTeamRank;
			if (flag5)
			{
				bool flag6 = this.View != null && this.View.IsVisible();
				if (flag6)
				{
					this.View.RefreshRankWindow();
				}
			}
			else
			{
				bool flag7 = DlgBase<XTeamLeagueRankView, XTeamLeagueRankBehavior>.singleton.IsVisible();
				if (flag7)
				{
					XBaseRankList rankList2 = this.GetRankList(xtype);
					DlgBase<XTeamLeagueRankView, XTeamLeagueRankBehavior>.singleton.RefreshUI(rankList2);
				}
			}
		}

		public void ReqDragonGuildRankList()
		{
			RpcC2M_FetchDragonGuildList rpcC2M_FetchDragonGuildList = new RpcC2M_FetchDragonGuildList();
			rpcC2M_FetchDragonGuildList.oArg.start = 0;
			rpcC2M_FetchDragonGuildList.oArg.count = 20;
			rpcC2M_FetchDragonGuildList.oArg.reason = 2;
			rpcC2M_FetchDragonGuildList.oArg.sortType = XFastEnumIntEqualityComparer<DragonGuildSortType>.ToInt(DragonGuildSortType.DragonGuildSortBySceneID);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_FetchDragonGuildList);
		}

		public void ReqMysteriourRanklist()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.RiftRank);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		public void ReqGuildRankList()
		{
			RpcC2M_ReqGuildList rpcC2M_ReqGuildList = new RpcC2M_ReqGuildList();
			rpcC2M_ReqGuildList.oArg.start = 0;
			rpcC2M_ReqGuildList.oArg.count = 20;
			rpcC2M_ReqGuildList.oArg.reason = 2;
			rpcC2M_ReqGuildList.oArg.sortType = 5;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ReqGuildList);
		}

		public void ReqGuildBossRankList()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.GuildBossRank);
			rpcC2M_ClientQueryRankListNtf.oArg.TimeStamp = this._GuildBossRankList.timeStamp;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		public void ReqQualifyingRankList()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.PkRealTimeRank);
			rpcC2M_ClientQueryRankListNtf.oArg.TimeStamp = 0U;
			rpcC2M_ClientQueryRankListNtf.oArg.profession = 0U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		public void ReqLastWeekQualifyingRankList()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.LastWeek_PkRank);
			rpcC2M_ClientQueryRankListNtf.oArg.TimeStamp = 3U;
			rpcC2M_ClientQueryRankListNtf.oArg.profession = 0U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		public void OnGetDragonGuildList(FetchDragonGuildListArg oArg, FetchDragonGuildRes oRes)
		{
			this.currentSelectRankList = this._DragonGuildRankList.type;
			XRankDocument.ProcessRankListData(oRes.dragonguilds, this._DragonGuildRankList);
			XRankDocument.ProcessSelfRankData(oRes.dragonguilds, this._DragonGuildRankList);
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshRankWindow();
			}
		}

		public static void ProcessSelfRankData(List<DragonGuildInfo> data, XDragonGuildRankList rank)
		{
			XDragonGuildDocument doc = XDragonGuildDocument.Doc;
			bool flag = doc.IsInDragonGuild();
			if (flag)
			{
				rank.myRankInfo = rank.CreateNewInfo();
				XDragonGuildRankInfo xdragonGuildRankInfo = rank.myRankInfo as XDragonGuildRankInfo;
				xdragonGuildRankInfo.name = doc.BaseData.dragonGuildName;
				xdragonGuildRankInfo.value = (ulong)doc.BaseData.sceneCnt;
				xdragonGuildRankInfo.passSceneName = doc.BaseData.sceneName;
				xdragonGuildRankInfo.rank = XRankDocument.INVALID_RANK;
				for (int i = 0; i < data.Count; i++)
				{
					bool flag2 = data[i].id == doc.UID;
					if (flag2)
					{
						xdragonGuildRankInfo.rank = (uint)i;
						xdragonGuildRankInfo.ProcessData(data[i]);
						return;
					}
				}
			}
			rank.myRankInfo = null;
		}

		public static void ProcessRankListData(List<DragonGuildInfo> data, XDragonGuildRankList rank)
		{
			int num = Math.Max(rank.rankList.Count, data.Count);
			for (int i = rank.rankList.Count; i < num; i++)
			{
				rank.rankList.Add(rank.CreateNewInfo());
			}
			bool flag = data.Count < rank.rankList.Count;
			if (flag)
			{
				rank.rankList.RemoveRange(data.Count, rank.rankList.Count - data.Count);
			}
			for (int j = 0; j < rank.rankList.Count; j++)
			{
				XDragonGuildRankInfo xdragonGuildRankInfo = rank.rankList[j] as XDragonGuildRankInfo;
				xdragonGuildRankInfo.ProcessData(data[j]);
				xdragonGuildRankInfo.rank = (uint)j;
			}
		}

		public void OnGetGuildList(FetchGuildListArg oArg, FetchGuildListRes oRes)
		{
			this.currentSelectRankList = this._GuildRankList.type;
			XRankDocument.ProcessRankListData(oRes.guilds, this._GuildRankList);
			XRankDocument.ProcessSelfRankData(oRes.guilds, this._GuildRankList);
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshRankWindow();
			}
		}

		private static bool ContainsRole(ulong roleid, XBaseRankList rank)
		{
			bool flag = rank != null && rank.rankList != null;
			if (flag)
			{
				for (int i = 0; i < rank.rankList.Count; i++)
				{
					bool flag2 = rank.rankList[i].id == roleid;
					if (flag2)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static void ProcessRankListData(RankList data, XBaseRankList rank)
		{
			bool flag = rank.type == XRankType.RiftRank;
			if (flag)
			{
				int count = data.RankData.Count;
				rank.rankList.Clear();
				int i = 0;
				int count2 = data.RankData.Count;
				while (i < count2)
				{
					List<string> roleNames = data.RankData[i].RoleNames;
					for (int j = 0; j < roleNames.Count; j++)
					{
						bool flag2 = XRankDocument.ContainsRole(data.RankData[i].RoleIds[j], rank);
						if (!flag2)
						{
							XBaseRankInfo xbaseRankInfo = rank.CreateNewInfo();
							xbaseRankInfo.ProcessData(data.RankData[i]);
							xbaseRankInfo.name = roleNames[j];
							xbaseRankInfo.id = data.RankData[i].RoleIds[j];
							xbaseRankInfo.rank = (uint)i;
							rank.rankList.Add(xbaseRankInfo);
							bool flag3 = xbaseRankInfo.id == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
							if (flag3)
							{
								rank.myRankInfo = xbaseRankInfo;
							}
						}
					}
					i++;
				}
			}
			else
			{
				int num = Math.Max(rank.rankList.Count, data.RankData.Count);
				for (int k = rank.rankList.Count; k < num; k++)
				{
					rank.rankList.Add(rank.CreateNewInfo());
				}
				bool flag4 = data.RankData.Count < rank.rankList.Count;
				if (flag4)
				{
					rank.rankList.RemoveRange(data.RankData.Count, rank.rankList.Count - data.RankData.Count);
				}
				for (int l = 0; l < rank.rankList.Count; l++)
				{
					XBaseRankInfo xbaseRankInfo2 = rank.rankList[l];
					xbaseRankInfo2.ProcessData(data.RankData[l]);
					xbaseRankInfo2.rank = (uint)l;
				}
			}
		}

		public static void ProcessRankListData(List<GuildInfo> data, XGuildRankList rank)
		{
			int num = Math.Max(rank.rankList.Count, data.Count);
			for (int i = rank.rankList.Count; i < num; i++)
			{
				rank.rankList.Add(rank.CreateNewInfo());
			}
			bool flag = data.Count < rank.rankList.Count;
			if (flag)
			{
				rank.rankList.RemoveRange(data.Count, rank.rankList.Count - data.Count);
			}
			for (int j = 0; j < rank.rankList.Count; j++)
			{
				XGuildRankInfo xguildRankInfo = rank.rankList[j] as XGuildRankInfo;
				xguildRankInfo.ProcessData(data[j]);
				xguildRankInfo.rank = (uint)j;
			}
		}

		public static void ProcessRankListData(List<MayhemRankInfo> data, XBigMeleeRankList rank)
		{
			int num = Math.Max(rank.rankList.Count, data.Count);
			for (int i = rank.rankList.Count; i < num; i++)
			{
				rank.rankList.Add(rank.CreateNewInfo());
			}
			bool flag = data.Count < rank.rankList.Count;
			if (flag)
			{
				rank.rankList.RemoveRange(data.Count, rank.rankList.Count - data.Count);
			}
			for (int j = 0; j < rank.rankList.Count; j++)
			{
				XBigMeleeRankInfo xbigMeleeRankInfo = rank.rankList[j] as XBigMeleeRankInfo;
				xbigMeleeRankInfo.ProcessData(data[j]);
				xbigMeleeRankInfo.rank = (uint)j;
			}
		}

		public static void ProcessSelfRankData(ClientQueryRankListRes oRes, XBaseRankList rank)
		{
			bool flag = oRes.RoleRankData != null;
			if (flag)
			{
				XRankType xtype = XBaseRankList.GetXType((RankeType)oRes.RankType);
				bool flag2 = xtype != XRankType.RiftRank || rank.myRankInfo == null;
				if (flag2)
				{
					rank.myRankInfo = rank.CreateNewInfo();
					rank.myRankInfo.ProcessData(oRes.RoleRankData);
					rank.upperBound = oRes.RankAllCount;
				}
			}
			else
			{
				rank.myRankInfo = null;
			}
		}

		public static void ProcessSelfRankData(List<GuildInfo> data, XGuildRankList rank)
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool bInGuild = specificDocument.bInGuild;
			if (bInGuild)
			{
				rank.myRankInfo = rank.CreateNewInfo();
				XGuildRankInfo xguildRankInfo = rank.myRankInfo as XGuildRankInfo;
				xguildRankInfo.name = specificDocument.BasicData.guildName;
				xguildRankInfo.name2 = specificDocument.BasicData.leaderName;
				xguildRankInfo.value = (ulong)specificDocument.BasicData.level;
				xguildRankInfo.rank = XRankDocument.INVALID_RANK;
				for (int i = 0; i < data.Count; i++)
				{
					bool flag = data[i].id == specificDocument.UID;
					if (flag)
					{
						xguildRankInfo.rank = (uint)i;
						xguildRankInfo.ProcessData(data[i]);
						return;
					}
				}
			}
			rank.myRankInfo = null;
		}

		public void SelectItem(uint index)
		{
			this.currentSelectIndex = index;
			XBaseRankList rankList = this.GetRankList(this.currentSelectRankList);
			bool flag = rankList != null && rankList.type != XRankType.GuildRank && rankList.type != XRankType.DragonGuildRank && rankList.type != XRankType.TeamTowerRank && rankList.type != XRankType.GuildBossRank && rankList.type != XRankType.LeagueTeamRank;
			if (flag)
			{
				bool flag2 = (ulong)index < (ulong)((long)rankList.rankList.Count);
				if (flag2)
				{
					bool flag3 = rankList.type == XRankType.PetRank;
					if (flag3)
					{
						XPetRankInfo xpetRankInfo = rankList.rankList[(int)index] as XPetRankInfo;
						this.View.UpdatePetInfo(xpetRankInfo.petID);
					}
					else
					{
						XBaseRankInfo xbaseRankInfo = rankList.rankList[(int)index];
						this.ReqUnitAppearance(xbaseRankInfo.id);
						this.View.UpdateGuildInfo(xbaseRankInfo);
					}
				}
				else
				{
					XSingleton<XDebug>.singleton.AddLog(string.Format("index out of range. index = {0} while list count = {1}", index, rankList.rankList.Count), null, null, null, null, null, XDebugColor.XDebug_None);
				}
			}
			bool flag4 = this.View != null && this.View.IsVisible();
			if (flag4)
			{
				this.View.RefreshContent();
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("RankDocument");

		public static readonly uint INVALID_RANK = uint.MaxValue;

		private XRankView _view = null;

		private XPPTRankList _PPTRankList;

		private XLevelRankList _LevelRankList;

		private XFashionRankList _FashionRankList;

		private XGuildRankList _GuildRankList;

		private XDragonGuildRankList _DragonGuildRankList;

		private XTeamTowerRankList _TowerRankList;

		private XGuildBossRankList _GuildBossRankList;

		private XWorldBossDamageRankList _WorldBossRankList;

		private XPetRankList _PetRankList;

		private XSpriteRankList _SpriteRankList;

		private XQualifyingRankList _QualifyingRankList;

		private XLeagueTeamRankList _LeagueTeamRankList;

		private XRiftRankList _RiftRankList;

		private XCampDuelRankLeftList _CampDuelRankLeftList;

		private XCampDuelRankRightList _CampDuelRankRightList;

		private XLeagueTeamRankList _LastWeekLeagueTeamRankList;

		private XQualifyingRankList _LastWeekQualifyingRankList;

		private XBigMeleeRankList _BigMeleeRankList;

		private XSkyArenaList _XSkyArenaList;

		public XRankType currentSelectRankList = XRankType.PPTRank;

		public uint currentSelectIndex = 0U;

		private Dictionary<XRankType, XBaseRankList> _RankDic = new Dictionary<XRankType, XBaseRankList>(default(XFastEnumIntEqualityComparer<XRankType>));
	}
}
