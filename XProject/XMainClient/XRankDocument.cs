using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009ED RID: 2541
	internal class XRankDocument : XDocComponent
	{
		// Token: 0x17002E37 RID: 11831
		// (get) Token: 0x06009B66 RID: 39782 RVA: 0x0018C59C File Offset: 0x0018A79C
		public override uint ID
		{
			get
			{
				return XRankDocument.uuID;
			}
		}

		// Token: 0x17002E38 RID: 11832
		// (get) Token: 0x06009B67 RID: 39783 RVA: 0x0018C5B4 File Offset: 0x0018A7B4
		// (set) Token: 0x06009B68 RID: 39784 RVA: 0x0018C5CC File Offset: 0x0018A7CC
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

		// Token: 0x17002E39 RID: 11833
		// (get) Token: 0x06009B69 RID: 39785 RVA: 0x0018C5D8 File Offset: 0x0018A7D8
		public static XRankDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XRankDocument.uuID) as XRankDocument;
			}
		}

		// Token: 0x17002E3A RID: 11834
		// (get) Token: 0x06009B6A RID: 39786 RVA: 0x0018C604 File Offset: 0x0018A804
		public XBaseRankList PPTRankList
		{
			get
			{
				return this._PPTRankList;
			}
		}

		// Token: 0x17002E3B RID: 11835
		// (get) Token: 0x06009B6B RID: 39787 RVA: 0x0018C61C File Offset: 0x0018A81C
		public XBaseRankList LevelRankList
		{
			get
			{
				return this._LevelRankList;
			}
		}

		// Token: 0x17002E3C RID: 11836
		// (get) Token: 0x06009B6C RID: 39788 RVA: 0x0018C634 File Offset: 0x0018A834
		public XBaseRankList FashionRankList
		{
			get
			{
				return this._FashionRankList;
			}
		}

		// Token: 0x17002E3D RID: 11837
		// (get) Token: 0x06009B6D RID: 39789 RVA: 0x0018C64C File Offset: 0x0018A84C
		public XGuildRankList GuildRankList
		{
			get
			{
				return this._GuildRankList;
			}
		}

		// Token: 0x17002E3E RID: 11838
		// (get) Token: 0x06009B6E RID: 39790 RVA: 0x0018C664 File Offset: 0x0018A864
		public XDragonGuildRankList DragonRankList
		{
			get
			{
				return this._DragonGuildRankList;
			}
		}

		// Token: 0x17002E3F RID: 11839
		// (get) Token: 0x06009B6F RID: 39791 RVA: 0x0018C67C File Offset: 0x0018A87C
		public XTeamTowerRankList TowerRankList
		{
			get
			{
				return this._TowerRankList;
			}
		}

		// Token: 0x17002E40 RID: 11840
		// (get) Token: 0x06009B70 RID: 39792 RVA: 0x0018C694 File Offset: 0x0018A894
		public XGuildBossRankList GuildBossRankList
		{
			get
			{
				return this._GuildBossRankList;
			}
		}

		// Token: 0x17002E41 RID: 11841
		// (get) Token: 0x06009B71 RID: 39793 RVA: 0x0018C6AC File Offset: 0x0018A8AC
		public XPetRankList PetRankList
		{
			get
			{
				return this._PetRankList;
			}
		}

		// Token: 0x17002E42 RID: 11842
		// (get) Token: 0x06009B72 RID: 39794 RVA: 0x0018C6C4 File Offset: 0x0018A8C4
		public XBigMeleeRankList BigMeleeRankList
		{
			get
			{
				return this._BigMeleeRankList;
			}
		}

		// Token: 0x17002E43 RID: 11843
		// (get) Token: 0x06009B73 RID: 39795 RVA: 0x0018C6DC File Offset: 0x0018A8DC
		public XSkyArenaList SkyArenaList
		{
			get
			{
				return this._XSkyArenaList;
			}
		}

		// Token: 0x17002E44 RID: 11844
		// (get) Token: 0x06009B74 RID: 39796 RVA: 0x0018C6F4 File Offset: 0x0018A8F4
		public XQualifyingRankList QualifyingRankList
		{
			get
			{
				return this._QualifyingRankList;
			}
		}

		// Token: 0x17002E45 RID: 11845
		// (get) Token: 0x06009B75 RID: 39797 RVA: 0x0018C70C File Offset: 0x0018A90C
		public XQualifyingRankList LastWeekQualifyingRankList
		{
			get
			{
				return this._LastWeekQualifyingRankList;
			}
		}

		// Token: 0x17002E46 RID: 11846
		// (get) Token: 0x06009B76 RID: 39798 RVA: 0x0018C724 File Offset: 0x0018A924
		public XLeagueTeamRankList LastWeekLeagueTeamRankList
		{
			get
			{
				return this._LastWeekLeagueTeamRankList;
			}
		}

		// Token: 0x17002E47 RID: 11847
		// (get) Token: 0x06009B77 RID: 39799 RVA: 0x0018C73C File Offset: 0x0018A93C
		public XRiftRankList RiftRankList
		{
			get
			{
				return this._RiftRankList;
			}
		}

		// Token: 0x06009B78 RID: 39800 RVA: 0x0018C754 File Offset: 0x0018A954
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

		// Token: 0x06009B79 RID: 39801 RVA: 0x0018C9C0 File Offset: 0x0018ABC0
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

		// Token: 0x06009B7A RID: 39802 RVA: 0x0018C9EC File Offset: 0x0018ABEC
		public void ReqPetUnitAppearance(ulong roleid, ulong petUID)
		{
			RpcC2M_GetUnitAppearanceNew rpcC2M_GetUnitAppearanceNew = new RpcC2M_GetUnitAppearanceNew();
			rpcC2M_GetUnitAppearanceNew.oArg.roleid = roleid;
			rpcC2M_GetUnitAppearanceNew.oArg.mask = XFastEnumIntEqualityComparer<UnitAppearanceField>.ToInt(UnitAppearanceField.UNIT_PETS);
			rpcC2M_GetUnitAppearanceNew.oArg.type = 6U;
			rpcC2M_GetUnitAppearanceNew.oArg.petId = petUID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetUnitAppearanceNew);
		}

		// Token: 0x06009B7B RID: 39803 RVA: 0x0018CA4C File Offset: 0x0018AC4C
		public void ReqUnitAppearance(ulong id)
		{
			RpcC2M_GetUnitAppearanceNew rpcC2M_GetUnitAppearanceNew = new RpcC2M_GetUnitAppearanceNew();
			rpcC2M_GetUnitAppearanceNew.oArg.roleid = id;
			rpcC2M_GetUnitAppearanceNew.oArg.type = 1U;
			rpcC2M_GetUnitAppearanceNew.oArg.mask = 17301711;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetUnitAppearanceNew);
		}

		// Token: 0x06009B7C RID: 39804 RVA: 0x0018CA98 File Offset: 0x0018AC98
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

		// Token: 0x06009B7D RID: 39805 RVA: 0x0018CAE0 File Offset: 0x0018ACE0
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

		// Token: 0x06009B7E RID: 39806 RVA: 0x0018CB60 File Offset: 0x0018AD60
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

		// Token: 0x06009B7F RID: 39807 RVA: 0x0018CC6C File Offset: 0x0018AE6C
		public void ReqDragonGuildRankList()
		{
			RpcC2M_FetchDragonGuildList rpcC2M_FetchDragonGuildList = new RpcC2M_FetchDragonGuildList();
			rpcC2M_FetchDragonGuildList.oArg.start = 0;
			rpcC2M_FetchDragonGuildList.oArg.count = 20;
			rpcC2M_FetchDragonGuildList.oArg.reason = 2;
			rpcC2M_FetchDragonGuildList.oArg.sortType = XFastEnumIntEqualityComparer<DragonGuildSortType>.ToInt(DragonGuildSortType.DragonGuildSortBySceneID);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_FetchDragonGuildList);
		}

		// Token: 0x06009B80 RID: 39808 RVA: 0x0018CCC8 File Offset: 0x0018AEC8
		public void ReqMysteriourRanklist()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.RiftRank);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		// Token: 0x06009B81 RID: 39809 RVA: 0x0018CCFC File Offset: 0x0018AEFC
		public void ReqGuildRankList()
		{
			RpcC2M_ReqGuildList rpcC2M_ReqGuildList = new RpcC2M_ReqGuildList();
			rpcC2M_ReqGuildList.oArg.start = 0;
			rpcC2M_ReqGuildList.oArg.count = 20;
			rpcC2M_ReqGuildList.oArg.reason = 2;
			rpcC2M_ReqGuildList.oArg.sortType = 5;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ReqGuildList);
		}

		// Token: 0x06009B82 RID: 39810 RVA: 0x0018CD54 File Offset: 0x0018AF54
		public void ReqGuildBossRankList()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.GuildBossRank);
			rpcC2M_ClientQueryRankListNtf.oArg.TimeStamp = this._GuildBossRankList.timeStamp;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		// Token: 0x06009B83 RID: 39811 RVA: 0x0018CDA0 File Offset: 0x0018AFA0
		public void ReqQualifyingRankList()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.PkRealTimeRank);
			rpcC2M_ClientQueryRankListNtf.oArg.TimeStamp = 0U;
			rpcC2M_ClientQueryRankListNtf.oArg.profession = 0U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		// Token: 0x06009B84 RID: 39812 RVA: 0x0018CDF0 File Offset: 0x0018AFF0
		public void ReqLastWeekQualifyingRankList()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.LastWeek_PkRank);
			rpcC2M_ClientQueryRankListNtf.oArg.TimeStamp = 3U;
			rpcC2M_ClientQueryRankListNtf.oArg.profession = 0U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		// Token: 0x06009B85 RID: 39813 RVA: 0x0018CE40 File Offset: 0x0018B040
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

		// Token: 0x06009B86 RID: 39814 RVA: 0x0018CEAC File Offset: 0x0018B0AC
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

		// Token: 0x06009B87 RID: 39815 RVA: 0x0018CF78 File Offset: 0x0018B178
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

		// Token: 0x06009B88 RID: 39816 RVA: 0x0018D058 File Offset: 0x0018B258
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

		// Token: 0x06009B89 RID: 39817 RVA: 0x0018D0C4 File Offset: 0x0018B2C4
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

		// Token: 0x06009B8A RID: 39818 RVA: 0x0018D128 File Offset: 0x0018B328
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

		// Token: 0x06009B8B RID: 39819 RVA: 0x0018D364 File Offset: 0x0018B564
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

		// Token: 0x06009B8C RID: 39820 RVA: 0x0018D444 File Offset: 0x0018B644
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

		// Token: 0x06009B8D RID: 39821 RVA: 0x0018D524 File Offset: 0x0018B724
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

		// Token: 0x06009B8E RID: 39822 RVA: 0x0018D59C File Offset: 0x0018B79C
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

		// Token: 0x06009B8F RID: 39823 RVA: 0x0018D670 File Offset: 0x0018B870
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

		// Token: 0x06009B90 RID: 39824 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x040035C2 RID: 13762
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("RankDocument");

		// Token: 0x040035C3 RID: 13763
		public static readonly uint INVALID_RANK = uint.MaxValue;

		// Token: 0x040035C4 RID: 13764
		private XRankView _view = null;

		// Token: 0x040035C5 RID: 13765
		private XPPTRankList _PPTRankList;

		// Token: 0x040035C6 RID: 13766
		private XLevelRankList _LevelRankList;

		// Token: 0x040035C7 RID: 13767
		private XFashionRankList _FashionRankList;

		// Token: 0x040035C8 RID: 13768
		private XGuildRankList _GuildRankList;

		// Token: 0x040035C9 RID: 13769
		private XDragonGuildRankList _DragonGuildRankList;

		// Token: 0x040035CA RID: 13770
		private XTeamTowerRankList _TowerRankList;

		// Token: 0x040035CB RID: 13771
		private XGuildBossRankList _GuildBossRankList;

		// Token: 0x040035CC RID: 13772
		private XWorldBossDamageRankList _WorldBossRankList;

		// Token: 0x040035CD RID: 13773
		private XPetRankList _PetRankList;

		// Token: 0x040035CE RID: 13774
		private XSpriteRankList _SpriteRankList;

		// Token: 0x040035CF RID: 13775
		private XQualifyingRankList _QualifyingRankList;

		// Token: 0x040035D0 RID: 13776
		private XLeagueTeamRankList _LeagueTeamRankList;

		// Token: 0x040035D1 RID: 13777
		private XRiftRankList _RiftRankList;

		// Token: 0x040035D2 RID: 13778
		private XCampDuelRankLeftList _CampDuelRankLeftList;

		// Token: 0x040035D3 RID: 13779
		private XCampDuelRankRightList _CampDuelRankRightList;

		// Token: 0x040035D4 RID: 13780
		private XLeagueTeamRankList _LastWeekLeagueTeamRankList;

		// Token: 0x040035D5 RID: 13781
		private XQualifyingRankList _LastWeekQualifyingRankList;

		// Token: 0x040035D6 RID: 13782
		private XBigMeleeRankList _BigMeleeRankList;

		// Token: 0x040035D7 RID: 13783
		private XSkyArenaList _XSkyArenaList;

		// Token: 0x040035D8 RID: 13784
		public XRankType currentSelectRankList = XRankType.PPTRank;

		// Token: 0x040035D9 RID: 13785
		public uint currentSelectIndex = 0U;

		// Token: 0x040035DA RID: 13786
		private Dictionary<XRankType, XBaseRankList> _RankDic = new Dictionary<XRankType, XBaseRankList>(default(XFastEnumIntEqualityComparer<XRankType>));
	}
}
