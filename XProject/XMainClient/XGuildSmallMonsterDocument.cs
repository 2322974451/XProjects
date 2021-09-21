using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009A4 RID: 2468
	internal class XGuildSmallMonsterDocument : XDocComponent
	{
		// Token: 0x17002CF9 RID: 11513
		// (get) Token: 0x060094BB RID: 38075 RVA: 0x001603D4 File Offset: 0x0015E5D4
		public override uint ID
		{
			get
			{
				return XGuildSmallMonsterDocument.uuID;
			}
		}

		// Token: 0x17002CFA RID: 11514
		// (get) Token: 0x060094BC RID: 38076 RVA: 0x001603EC File Offset: 0x0015E5EC
		public int LeftEnterCount
		{
			get
			{
				return this._leftEnterCount;
			}
		}

		// Token: 0x17002CFB RID: 11515
		// (get) Token: 0x060094BD RID: 38077 RVA: 0x00160404 File Offset: 0x0015E604
		public int DayLimit
		{
			get
			{
				return XSingleton<XGlobalConfig>.singleton.GetInt("GuildCampDayCount");
			}
		}

		// Token: 0x17002CFC RID: 11516
		// (get) Token: 0x060094BE RID: 38078 RVA: 0x00160428 File Offset: 0x0015E628
		public GuildCamp.RowData currCamp
		{
			get
			{
				for (int i = 0; i < XGuildSmallMonsterDocument._guildCampTable.Table.Length; i++)
				{
					bool flag = (long)XGuildSmallMonsterDocument._guildCampTable.Table[i].ID == (long)((ulong)this.DNExpId);
					if (flag)
					{
						return XGuildSmallMonsterDocument._guildCampTable.Table[i];
					}
				}
				return null;
			}
		}

		// Token: 0x17002CFD RID: 11517
		// (get) Token: 0x060094BF RID: 38079 RVA: 0x00160488 File Offset: 0x0015E688
		public GuildCamp.RowData nextCamp
		{
			get
			{
				for (int i = 0; i < XGuildSmallMonsterDocument._guildCampTable.Table.Length; i++)
				{
					bool flag = (long)XGuildSmallMonsterDocument._guildCampTable.Table[i].ID == (long)((ulong)this.NextdayDneId);
					if (flag)
					{
						return XGuildSmallMonsterDocument._guildCampTable.Table[i];
					}
				}
				return null;
			}
		}

		// Token: 0x17002CFE RID: 11518
		// (get) Token: 0x060094C0 RID: 38080 RVA: 0x001604E8 File Offset: 0x0015E6E8
		public uint Small_Monster_SceneID
		{
			get
			{
				XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
				ExpeditionTable.RowData expeditionDataByID = specificDocument.GetExpeditionDataByID((int)this.DNExpId);
				bool flag = expeditionDataByID != null;
				if (flag)
				{
					List<uint> randomSceneList = specificDocument.GetRandomSceneList(expeditionDataByID.RandomSceneIDs[0]);
					bool flag2 = randomSceneList.Count > 0;
					if (flag2)
					{
						return randomSceneList[0];
					}
				}
				return 4500U;
			}
		}

		// Token: 0x17002CFF RID: 11519
		// (get) Token: 0x060094C1 RID: 38081 RVA: 0x0016054C File Offset: 0x0015E74C
		public List<GuildCampRankInfo> RankList
		{
			get
			{
				return this._rankList;
			}
		}

		// Token: 0x17002D00 RID: 11520
		// (get) Token: 0x060094C2 RID: 38082 RVA: 0x00160564 File Offset: 0x0015E764
		public bool isKillType
		{
			get
			{
				bool flag = this.currCamp != null;
				return flag && this.currCamp.Type == 2;
			}
		}

		// Token: 0x060094C3 RID: 38083 RVA: 0x00160595 File Offset: 0x0015E795
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildSmallMonsterDocument.AsyncLoader.AddTask("Table/GuildCamp", XGuildSmallMonsterDocument._guildCampTable, false);
			XGuildSmallMonsterDocument.AsyncLoader.AddTask("Table/GuildCampRank", XGuildSmallMonsterDocument._guildRankTable, false);
			XGuildSmallMonsterDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060094C4 RID: 38084 RVA: 0x001605D0 File Offset: 0x0015E7D0
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.GuildStateChanged));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		// Token: 0x060094C5 RID: 38085 RVA: 0x00160608 File Offset: 0x0015E808
		public bool IsOpen(ExpeditionTable.RowData rowData)
		{
			return (long)rowData.DNExpeditionID == (long)((ulong)this.DNExpId);
		}

		// Token: 0x060094C6 RID: 38086 RVA: 0x0016062C File Offset: 0x0015E82C
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this.SendQuerySmallMonterInfo();
			}
		}

		// Token: 0x060094C7 RID: 38087 RVA: 0x00160660 File Offset: 0x0015E860
		public bool CheckEnterLevel()
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			ExpeditionTable.RowData expeditionDataByID = specificDocument.GetExpeditionDataByID((int)this.DNExpId);
			return specificDocument.TeamCategoryMgr.IsExpOpened(expeditionDataByID);
		}

		// Token: 0x060094C8 RID: 38088 RVA: 0x00160698 File Offset: 0x0015E898
		public int GetEnterLevel()
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			int expIDBySceneID = specificDocument.GetExpIDBySceneID(this.Small_Monster_SceneID);
			ExpeditionTable.RowData expeditionDataByID = specificDocument.GetExpeditionDataByID(expIDBySceneID);
			return (expeditionDataByID == null) ? 24 : expeditionDataByID.RequiredLevel;
		}

		// Token: 0x060094C9 RID: 38089 RVA: 0x001606D8 File Offset: 0x0015E8D8
		private bool GuildStateChanged(XEventArgs args)
		{
			XInGuildStateChangedEventArgs xinGuildStateChangedEventArgs = args as XInGuildStateChangedEventArgs;
			bool bIsEnter = xinGuildStateChangedEventArgs.bIsEnter;
			if (bIsEnter)
			{
				this.SendQuerySmallMonterInfo();
			}
			else
			{
				this._leftEnterCount = 0;
			}
			return true;
		}

		// Token: 0x060094CA RID: 38090 RVA: 0x00160710 File Offset: 0x0015E910
		public void SendQuerySmallMonterInfo()
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool flag = !specificDocument.bInGuild;
			if (!flag)
			{
				bool flag2 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_GuildDungeon_SmallMonter);
				if (!flag2)
				{
					RpcC2M_GuildCampInfo rpc = new RpcC2M_GuildCampInfo();
					XSingleton<XClientNetwork>.singleton.Send(rpc);
				}
			}
		}

		// Token: 0x060094CB RID: 38091 RVA: 0x00160764 File Offset: 0x0015E964
		public void SetGuildSmallMonsterInfo(int leftEnterCount, int currID, int nextID, List<GuildCampRankInfo> rankList)
		{
			this._leftEnterCount = leftEnterCount;
			this._rankList.Clear();
			DlgBase<XGuildSmallMonsterView, XGuildSmallMonsterBehaviour>.singleton.RefreshRedp();
			bool flag = currID != 0 && nextID != 0;
			if (flag)
			{
				this.DNExpId = (uint)currID;
				this.NextdayDneId = (uint)nextID;
			}
			else
			{
				XSingleton<XDebug>.singleton.AddGreenLog("currID is 0", null, null, null, null, null);
			}
			for (int i = 0; i < rankList.Count; i++)
			{
				GuildCampRankInfo guildCampRankInfo = new GuildCampRankInfo();
				guildCampRankInfo.rankVar = rankList[i].rankVar;
				guildCampRankInfo.rank = rankList[i].rank;
				guildCampRankInfo.roles.Clear();
				for (int j = 0; j < rankList[i].roles.Count; j++)
				{
					guildCampRankInfo.roles.Add(rankList[i].roles[j]);
				}
				this._rankList.Add(guildCampRankInfo);
			}
			bool flag2 = !DlgBase<XGuildSmallMonsterView, XGuildSmallMonsterBehaviour>.singleton.IsVisible();
			if (!flag2)
			{
				DlgBase<XGuildSmallMonsterView, XGuildSmallMonsterBehaviour>.singleton.SetupDetailFrame();
				DlgBase<XGuildSmallMonsterView, XGuildSmallMonsterBehaviour>.singleton.SetupRankFrame();
			}
		}

		// Token: 0x060094CC RID: 38092 RVA: 0x001608A0 File Offset: 0x0015EAA0
		public void OpenTeamView()
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch((int)this.DNExpId);
		}

		// Token: 0x060094CD RID: 38093 RVA: 0x001608C8 File Offset: 0x0015EAC8
		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			this.SendQuerySmallMonterInfo();
			return true;
		}

		// Token: 0x060094CE RID: 38094 RVA: 0x001608E4 File Offset: 0x0015EAE4
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this.SendQuerySmallMonterInfo();
			}
		}

		// Token: 0x04003247 RID: 12871
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildSmallMonsterDocument");

		// Token: 0x04003248 RID: 12872
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003249 RID: 12873
		public uint DNExpId = 11U;

		// Token: 0x0400324A RID: 12874
		public uint NextdayDneId = 12U;

		// Token: 0x0400324B RID: 12875
		private int _leftEnterCount = 0;

		// Token: 0x0400324C RID: 12876
		private List<GuildCampRankInfo> _rankList = new List<GuildCampRankInfo>();

		// Token: 0x0400324D RID: 12877
		public static GuildCamp _guildCampTable = new GuildCamp();

		// Token: 0x0400324E RID: 12878
		public static GuildCampRank _guildRankTable = new GuildCampRank();
	}
}
