using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildSmallMonsterDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildSmallMonsterDocument.uuID;
			}
		}

		public int LeftEnterCount
		{
			get
			{
				return this._leftEnterCount;
			}
		}

		public int DayLimit
		{
			get
			{
				return XSingleton<XGlobalConfig>.singleton.GetInt("GuildCampDayCount");
			}
		}

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

		public List<GuildCampRankInfo> RankList
		{
			get
			{
				return this._rankList;
			}
		}

		public bool isKillType
		{
			get
			{
				bool flag = this.currCamp != null;
				return flag && this.currCamp.Type == 2;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildSmallMonsterDocument.AsyncLoader.AddTask("Table/GuildCamp", XGuildSmallMonsterDocument._guildCampTable, false);
			XGuildSmallMonsterDocument.AsyncLoader.AddTask("Table/GuildCampRank", XGuildSmallMonsterDocument._guildRankTable, false);
			XGuildSmallMonsterDocument.AsyncLoader.Execute(callback);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.GuildStateChanged));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		public bool IsOpen(ExpeditionTable.RowData rowData)
		{
			return (long)rowData.DNExpeditionID == (long)((ulong)this.DNExpId);
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this.SendQuerySmallMonterInfo();
			}
		}

		public bool CheckEnterLevel()
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			ExpeditionTable.RowData expeditionDataByID = specificDocument.GetExpeditionDataByID((int)this.DNExpId);
			return specificDocument.TeamCategoryMgr.IsExpOpened(expeditionDataByID);
		}

		public int GetEnterLevel()
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			int expIDBySceneID = specificDocument.GetExpIDBySceneID(this.Small_Monster_SceneID);
			ExpeditionTable.RowData expeditionDataByID = specificDocument.GetExpeditionDataByID(expIDBySceneID);
			return (expeditionDataByID == null) ? 24 : expeditionDataByID.RequiredLevel;
		}

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

		public void OpenTeamView()
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch((int)this.DNExpId);
		}

		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			this.SendQuerySmallMonterInfo();
			return true;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this.SendQuerySmallMonterInfo();
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildSmallMonsterDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public uint DNExpId = 11U;

		public uint NextdayDneId = 12U;

		private int _leftEnterCount = 0;

		private List<GuildCampRankInfo> _rankList = new List<GuildCampRankInfo>();

		public static GuildCamp _guildCampTable = new GuildCamp();

		public static GuildCampRank _guildRankTable = new GuildCampRank();
	}
}
