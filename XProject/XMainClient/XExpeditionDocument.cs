using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A00 RID: 2560
	internal class XExpeditionDocument : XDocComponent
	{
		// Token: 0x17002E72 RID: 11890
		// (get) Token: 0x06009C9A RID: 40090 RVA: 0x00195858 File Offset: 0x00193A58
		public override uint ID
		{
			get
			{
				return XExpeditionDocument.uuID;
			}
		}

		// Token: 0x17002E73 RID: 11891
		// (get) Token: 0x06009C9B RID: 40091 RVA: 0x00195870 File Offset: 0x00193A70
		public static ExpeditionTable ExpTable
		{
			get
			{
				return XExpeditionDocument._ExpeditionReader;
			}
		}

		// Token: 0x17002E74 RID: 11892
		// (get) Token: 0x06009C9C RID: 40092 RVA: 0x00195887 File Offset: 0x00193A87
		// (set) Token: 0x06009C9D RID: 40093 RVA: 0x0019588F File Offset: 0x00193A8F
		public bool EnlargeMatch { get; set; }

		// Token: 0x17002E75 RID: 11893
		// (get) Token: 0x06009C9E RID: 40094 RVA: 0x00195898 File Offset: 0x00193A98
		public TeamTowerData SingleTowerData
		{
			get
			{
				return this._SingleTowerData;
			}
		}

		// Token: 0x17002E76 RID: 11894
		// (get) Token: 0x06009C9F RID: 40095 RVA: 0x001958B0 File Offset: 0x00193AB0
		// (set) Token: 0x06009CA0 RID: 40096 RVA: 0x001958C8 File Offset: 0x00193AC8
		public int ExpeditionId
		{
			get
			{
				return this.SelectExpId;
			}
			set
			{
				this.SelectExpId = value;
			}
		}

		// Token: 0x17002E77 RID: 11895
		// (get) Token: 0x06009CA1 RID: 40097 RVA: 0x001958D4 File Offset: 0x00193AD4
		public int GoddessRewardsCanGetTimes
		{
			get
			{
				return this.m_GoddessRewardsCanGetTimes;
			}
		}

		// Token: 0x06009CA2 RID: 40098 RVA: 0x001958EC File Offset: 0x00193AEC
		public static void Execute(OnLoadedCallback callback = null)
		{
			XExpeditionDocument.AsyncLoader.AddTask("Table/DNExpedition", XExpeditionDocument._ExpeditionReader, false);
			XExpeditionDocument.AsyncLoader.AddTask("Table/RandomSceneList", XExpeditionDocument._RandomSceneReader, false);
			XExpeditionDocument.AsyncLoader.AddTask("Table/TeamTower", XExpeditionDocument._TeamTowerRewardTable, false);
			XExpeditionDocument.AsyncLoader.AddTask("Table/PkProfession", XExpeditionDocument._PkProfTable, false);
			XExpeditionDocument.AsyncLoader.AddTask("Table/PVEAttrModify", XExpeditionDocument._PveAttrTable, false);
			XExpeditionDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009CA3 RID: 40099 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTableLoaded()
		{
		}

		// Token: 0x06009CA4 RID: 40100 RVA: 0x00195974 File Offset: 0x00193B74
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.TeamCategoryMgr.Init();
			this.InitTeamTowerData();
			this.currentDayCount.Clear();
			this.currentBuyCount.Clear();
		}

		// Token: 0x06009CA5 RID: 40101 RVA: 0x001959AA File Offset: 0x00193BAA
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_JoinTeam, new XComponent.XEventHandler(this.OnJoinTeam));
			base.RegisterEvent(XEventDefine.XEvent_LeaveTeam, new XComponent.XEventHandler(this.OnLeaveTeam));
		}

		// Token: 0x06009CA6 RID: 40102 RVA: 0x001959DE File Offset: 0x00193BDE
		public override void OnEnterScene()
		{
			base.OnEnterScene();
			this.TeamCategoryMgr.RefreshAbyssStates();
		}

		// Token: 0x06009CA7 RID: 40103 RVA: 0x001959F4 File Offset: 0x00193BF4
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_TOWER;
			if (flag)
			{
				XSingleton<XLevelDoodadMgr>.singleton.OnClearDoodad();
				XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_Activity_TeamTowerSingle, EXStage.Hall);
			}
			bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GODDESS;
			if (flag2)
			{
				int num = this.GetDayMaxCount(TeamLevelType.TeamLevelGoddessTrial, null) - this.GetDayCount(TeamLevelType.TeamLevelGoddessTrial, null);
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("GoddessTrialNeedJoinTimes");
				bool flag3 = @int <= 0;
				if (!flag3)
				{
					bool flag4 = this.GoddessRewardsCanGetTimes > 0 || (num > 0 && num % @int == 0);
					if (flag4)
					{
						XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_Activity_GoddessTrial, EXStage.Hall);
					}
				}
			}
		}

		// Token: 0x06009CA8 RID: 40104 RVA: 0x00195AB4 File Offset: 0x00193CB4
		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_TOWER;
			if (flag)
			{
				XSingleton<XLevelDoodadMgr>.singleton.OnClearDoodad();
			}
		}

		// Token: 0x06009CA9 RID: 40105 RVA: 0x00195AE8 File Offset: 0x00193CE8
		public static string GetFullName(ExpeditionTable.RowData rowData)
		{
			bool flag = rowData == null;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				TeamLevelType type = (TeamLevelType)rowData.Type;
				bool flag2 = type == TeamLevelType.TeamLevelNest;
				if (flag2)
				{
					NestListTable.RowData byNestID = XNestDocument.NestListData.GetByNestID(rowData.DNExpeditionID);
					bool flag3 = byNestID != null;
					if (flag3)
					{
						bool flag4 = rowData.CostCountType != 0;
						string @string;
						if (flag4)
						{
							@string = XStringDefineProxy.GetString(string.Format("TeamNestDifficult{0}", byNestID.Difficulty));
						}
						else
						{
							@string = XStringDefineProxy.GetString(string.Format("TeamNestDifficult{0}", (long)(byNestID.Difficulty * 100) + (long)((ulong)rowData.Stars[0])));
						}
						return XStringDefineProxy.GetString("EXP_FULL_NAME", new object[]
						{
							rowData.DNExpeditionName,
							@string
						});
					}
				}
				result = rowData.DNExpeditionName;
			}
			return result;
		}

		// Token: 0x06009CAA RID: 40106 RVA: 0x00195BD4 File Offset: 0x00193DD4
		public ExpeditionTable.RowData GetExpeditionDataByIndex(int index)
		{
			bool flag = index >= XExpeditionDocument._ExpeditionReader.Table.Length;
			ExpeditionTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = XExpeditionDocument._ExpeditionReader.Table[index];
			}
			return result;
		}

		// Token: 0x06009CAB RID: 40107 RVA: 0x00195C0C File Offset: 0x00193E0C
		public RandomSceneTable.RowData[] GetRandomSceneTable()
		{
			return XExpeditionDocument._RandomSceneReader.Table;
		}

		// Token: 0x06009CAC RID: 40108 RVA: 0x00195C28 File Offset: 0x00193E28
		public RandomSceneTable.RowData GetRandomSceneRowDataBySceneId(int sceneId)
		{
			for (int i = 0; i < XExpeditionDocument._RandomSceneReader.Table.Length; i++)
			{
				bool flag = (long)sceneId == (long)((ulong)XExpeditionDocument._RandomSceneReader.Table[i].SceneID);
				if (flag)
				{
					return XExpeditionDocument._RandomSceneReader.Table[i];
				}
			}
			return null;
		}

		// Token: 0x06009CAD RID: 40109 RVA: 0x00195C84 File Offset: 0x00193E84
		public TeamTowerRewardTable.RowData GetTeamTowerRewardData(int index)
		{
			bool flag = XExpeditionDocument._TeamTowerRewardTable.Table.Length > index;
			TeamTowerRewardTable.RowData result;
			if (flag)
			{
				result = XExpeditionDocument._TeamTowerRewardTable.Table[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06009CAE RID: 40110 RVA: 0x00195CBC File Offset: 0x00193EBC
		public TeamTowerRewardTable.RowData[] GetTeamTowerTable()
		{
			return XExpeditionDocument._TeamTowerRewardTable.Table;
		}

		// Token: 0x06009CAF RID: 40111 RVA: 0x00195CD8 File Offset: 0x00193ED8
		public List<uint> GetRandomSceneList(uint RandomID)
		{
			List<uint> list = new List<uint>();
			for (int i = 0; i < XExpeditionDocument._RandomSceneReader.Table.Length; i++)
			{
				bool flag = XExpeditionDocument._RandomSceneReader.Table[i].RandomID == RandomID;
				if (flag)
				{
					list.Add(XExpeditionDocument._RandomSceneReader.Table[i].SceneID);
				}
			}
			return list;
		}

		// Token: 0x06009CB0 RID: 40112 RVA: 0x00195D44 File Offset: 0x00193F44
		public ExpeditionTable.RowData GetExpeditionDataByID(int id)
		{
			return XExpeditionDocument._ExpeditionReader.GetByDNExpeditionID(id);
		}

		// Token: 0x06009CB1 RID: 40113 RVA: 0x00195D64 File Offset: 0x00193F64
		public List<ExpeditionTable.RowData> GetExpeditionList(TeamLevelType type)
		{
			this._TempExpList.Clear();
			for (int i = 0; i < XExpeditionDocument._ExpeditionReader.Table.Length; i++)
			{
				bool flag = XExpeditionDocument._ExpeditionReader.Table[i].Type == (int)type;
				if (flag)
				{
					this._TempExpList.Add(XExpeditionDocument._ExpeditionReader.Table[i]);
				}
			}
			return this._TempExpList;
		}

		// Token: 0x06009CB2 RID: 40114 RVA: 0x00195DD8 File Offset: 0x00193FD8
		public string GetExpNameByHardLevel(int hardlevel)
		{
			for (int i = 0; i < XExpeditionDocument._TeamTowerRewardTable.Table.Length; i++)
			{
				bool flag = XExpeditionDocument._TeamTowerRewardTable.Table[i].TowerHardLevel == hardlevel;
				if (flag)
				{
					return XExpeditionDocument._TeamTowerRewardTable.Table[i].Name;
				}
			}
			return "";
		}

		// Token: 0x06009CB3 RID: 40115 RVA: 0x00195E38 File Offset: 0x00194038
		public TeamTowerData GetTeamTowerDataByExpid(int expid)
		{
			TeamTowerData teamTowerData = null;
			bool flag = this._TowerData.TryGetValue(expid, out teamTowerData);
			TeamTowerData result;
			if (flag)
			{
				result = teamTowerData;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06009CB4 RID: 40116 RVA: 0x00195E64 File Offset: 0x00194064
		private void InitTeamTowerData()
		{
			this._TowerData.Clear();
			List<ExpeditionTable.RowData> expeditionList = this.GetExpeditionList(TeamLevelType.TeamLevelTeamTower);
			for (int i = 0; i < expeditionList.Count; i++)
			{
				bool flag = !this._TowerData.ContainsKey(expeditionList[i].DNExpeditionID);
				if (flag)
				{
					TeamTowerData teamTowerData = new TeamTowerData();
					teamTowerData.difficulty = 0;
					teamTowerData.time = 0;
					teamTowerData.level = 0;
					teamTowerData.maxlevel = expeditionList[i].RandomSceneIDs.Length;
					teamTowerData.open = false;
					teamTowerData.sweeplefttime = 0;
					teamTowerData.showteam = false;
					teamTowerData.sweepreqtime = Time.time;
					this._TowerData.Add(expeditionList[i].DNExpeditionID, teamTowerData);
				}
			}
			this.EnlargeMatch = false;
		}

		// Token: 0x06009CB5 RID: 40117 RVA: 0x00195F38 File Offset: 0x00194138
		public bool OnJoinTeam(XEventArgs args)
		{
			bool flag = this.ExpeditionView == null || !this.ExpeditionView.active;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XJoinTeamEventArgs xjoinTeamEventArgs = args as XJoinTeamEventArgs;
				bool flag2 = this.GetExpeditionDataByID((int)xjoinTeamEventArgs.dungeonID) != null;
				if (flag2)
				{
					this.ExpeditionView.ShowExpediFrame();
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06009CB6 RID: 40118 RVA: 0x00195F94 File Offset: 0x00194194
		public bool OnLeaveTeam(XEventArgs args)
		{
			bool flag = this.ExpeditionView == null || !this.ExpeditionView.active;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XLeaveTeamEventArgs xleaveTeamEventArgs = args as XLeaveTeamEventArgs;
				bool flag2 = this.GetExpeditionDataByID((int)xleaveTeamEventArgs.dungeonID) != null;
				if (flag2)
				{
					this.ExpeditionView.ShowExpediFrame();
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06009CB7 RID: 40119 RVA: 0x00195FF0 File Offset: 0x001941F0
		public void SetTeamCount(TeamOPRes oRes)
		{
			bool flag = oRes == null;
			if (!flag)
			{
				this.m_GoddessRewardsCanGetTimes = oRes.GoddessGetRewardsCount;
				XWeekNestDocument.Doc.CurDNid = oRes.weeknestexpid;
				bool flag2 = XWeekNestDocument.Doc.CurDNid == 0;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddGreenLog("curDNid cannot is 0", null, null, null, null, null);
				}
				for (int i = 0; i < oRes.teamcount.Count; i++)
				{
					bool flag3 = oRes.teamcount[i] == null;
					if (!flag3)
					{
						this.currentDayCount[(TeamLevelType)oRes.teamcount[i].teamtype] = oRes.teamcount[i].leftcount;
						this.maxCount[(TeamLevelType)oRes.teamcount[i].teamtype] = oRes.teamcount[i].maxcount;
						this.currentBuyCount[(TeamLevelType)oRes.teamcount[i].teamtype] = oRes.teamcount[i].buycount;
					}
				}
				this.currentDayCount[TeamLevelType.TeamLevelWeekNest] = (int)oRes.wnrewardleftcount;
				this.maxCount[TeamLevelType.TeamLevelWeekNest] = (int)oRes.wnrewardmaxcount;
				this.RefreshRedPoints();
				this._GeneralRefreshLeftCount();
			}
		}

		// Token: 0x06009CB8 RID: 40120 RVA: 0x0019614C File Offset: 0x0019434C
		private void _GeneralRefreshLeftCount()
		{
			bool flag = DlgBase<TheExpView, TheExpBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<TheExpView, TheExpBehaviour>.singleton.RefreshLeftCount();
			}
			bool flag2 = DlgBase<XTeamView, TabDlgBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView();
			}
			bool flag3 = DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.IsVisible();
			if (flag3)
			{
				DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.RefreshHardLeftCount();
			}
			bool flag4 = DlgBase<ActivityGoddessTrialDlg, ActivityGoddessTrialBehaviour>.singleton.IsVisible();
			if (flag4)
			{
				DlgBase<ActivityGoddessTrialDlg, ActivityGoddessTrialBehaviour>.singleton.RefreshTimes();
			}
			bool flag5 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag5)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetTeamLeftTimes();
			}
			XWeekNestDocument.Doc.RefreshUi();
		}

		// Token: 0x06009CB9 RID: 40121 RVA: 0x001961F4 File Offset: 0x001943F4
		public void SetGoddessRewardsCanGetTimes(GetGoddessTrialRewardsRes oRes)
		{
			this.m_GoddessRewardsCanGetTimes = (int)oRes.leftGoddessReward;
			bool flag = DlgBase<ActivityGoddessTrialDlg, ActivityGoddessTrialBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<ActivityGoddessTrialDlg, ActivityGoddessTrialBehaviour>.singleton.RefreshTimes();
			}
		}

		// Token: 0x06009CBA RID: 40122 RVA: 0x00196228 File Offset: 0x00194428
		public int GetDayMaxCount(TeamLevelType dungeonType, SceneTable.RowData sceneData = null)
		{
			bool flag = dungeonType == TeamLevelType.TeamLevelDragonNest;
			if (flag)
			{
				bool flag2 = sceneData != null;
				if (flag2)
				{
					return (int)sceneData.DayLimit;
				}
			}
			else
			{
				int result = 0;
				bool flag3 = this.maxCount.TryGetValue(dungeonType, out result);
				if (flag3)
				{
					return result;
				}
			}
			return 0;
		}

		// Token: 0x06009CBB RID: 40123 RVA: 0x00196278 File Offset: 0x00194478
		public int GetTotalCount(TeamLevelType dungeonType, SceneTable.RowData sceneData = null)
		{
			return this.GetDayMaxCount(dungeonType, sceneData) + this.GetBuyCount(dungeonType);
		}

		// Token: 0x06009CBC RID: 40124 RVA: 0x0019629C File Offset: 0x0019449C
		public int GetBuyLimit(TeamLevelType dungeonType)
		{
			int result;
			if (dungeonType != TeamLevelType.TeamLevelNest)
			{
				if (dungeonType != TeamLevelType.TeamLevelAbyss)
				{
					result = 0;
				}
				else
				{
					result = XSingleton<XGlobalConfig>.singleton.GetInt("BuyAbyssCountLimit");
				}
			}
			else
			{
				result = XSingleton<XGlobalConfig>.singleton.GetInt("BuyNestCountLimit");
			}
			return result;
		}

		// Token: 0x06009CBD RID: 40125 RVA: 0x001962E4 File Offset: 0x001944E4
		public CostInfo GetBuyCost(TeamLevelType dungeonType)
		{
			CostInfo result;
			if (dungeonType != TeamLevelType.TeamLevelNest)
			{
				if (dungeonType != TeamLevelType.TeamLevelAbyss)
				{
					result = default(CostInfo);
				}
				else
				{
					result = XSingleton<XTakeCostMgr>.singleton.QueryCost("BuyAbyssCountCost", this.GetBuyCount(dungeonType));
				}
			}
			else
			{
				result = XSingleton<XTakeCostMgr>.singleton.QueryCost("BuyNestCountCost", this.GetBuyCount(dungeonType));
			}
			return result;
		}

		// Token: 0x06009CBE RID: 40126 RVA: 0x00196340 File Offset: 0x00194540
		public bool CanBuy(TeamLevelType dungeonType, out int buyCount, out int buyLimit)
		{
			buyCount = this.GetBuyCount(dungeonType);
			buyLimit = this.GetBuyLimit(dungeonType);
			return buyCount < buyLimit;
		}

		// Token: 0x06009CBF RID: 40127 RVA: 0x0019636C File Offset: 0x0019456C
		public int GetBuyCount(TeamLevelType dungeonType)
		{
			int num;
			bool flag = this.currentBuyCount.TryGetValue(dungeonType, out num);
			int result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06009CC0 RID: 40128 RVA: 0x00196398 File Offset: 0x00194598
		public int GetDayCount(TeamLevelType dungeonType, SceneTable.RowData sceneData = null)
		{
			bool flag = dungeonType == TeamLevelType.TeamLevelTeamTower;
			int result;
			if (flag)
			{
				result = this.SingleTowerData.leftcount;
			}
			else
			{
				int num;
				bool flag2 = this.currentDayCount.TryGetValue(dungeonType, out num);
				if (flag2)
				{
					result = num;
				}
				else
				{
					bool flag3 = sceneData != null;
					if (flag3)
					{
						XLevelDocument specificDocument = XDocuments.GetSpecificDocument<XLevelDocument>(XLevelDocument.uuID);
						uint num2;
						bool flag4 = specificDocument.SceneDayEnter.TryGetValue((uint)sceneData.id, out num2);
						if (flag4)
						{
							return (int)((uint)sceneData.DayLimit - num2);
						}
					}
					result = this.GetDayMaxCount(dungeonType, sceneData);
				}
			}
			return result;
		}

		// Token: 0x06009CC1 RID: 40129 RVA: 0x00196420 File Offset: 0x00194620
		public void ReqBuyCount(TeamLevelType type)
		{
			RpcC2G_BuyTeamSceneCount rpcC2G_BuyTeamSceneCount = new RpcC2G_BuyTeamSceneCount();
			rpcC2G_BuyTeamSceneCount.oArg.type = XFastEnumIntEqualityComparer<TeamLevelType>.ToInt(type);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_BuyTeamSceneCount);
		}

		// Token: 0x06009CC2 RID: 40130 RVA: 0x00196454 File Offset: 0x00194654
		public void OnBuyCount(BuyTeamSceneCountP oArg, BuyTeamSceneCountRet oRes)
		{
			bool flag = oRes.errcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errcode, "fece00");
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("BUYCOUNT_SUCCESS"), "fece00");
				TeamLevelType type = (TeamLevelType)oArg.type;
				this.currentBuyCount[type] = (int)oRes.buycount;
				this.currentDayCount[type] = (int)(oRes.maxcount - oRes.entercount);
				this.maxCount[type] = (int)oRes.maxcount;
				this.RefreshRedPoints();
				this._GeneralRefreshLeftCount();
			}
		}

		// Token: 0x06009CC3 RID: 40131 RVA: 0x001964F7 File Offset: 0x001946F7
		public void OnRefreshTeamLevelAbyss(int hadCount)
		{
			this.currentDayCount[TeamLevelType.TeamLevelAbyss] = hadCount;
		}

		// Token: 0x06009CC4 RID: 40132 RVA: 0x00196508 File Offset: 0x00194708
		public void OnRefreshDayCount(TeamLevelType type, int count)
		{
			bool flag = this.currentDayCount.ContainsKey(type);
			if (flag)
			{
				this.currentDayCount[type] = count;
			}
		}

		// Token: 0x06009CC5 RID: 40133 RVA: 0x00196534 File Offset: 0x00194734
		public bool CheckCountAndBuy(int expid, SceneTable.RowData sceneData = null)
		{
			ExpeditionTable.RowData expeditionDataByID = this.GetExpeditionDataByID(expid);
			TeamLevelType type = (TeamLevelType)expeditionDataByID.Type;
			bool flag = this.GetDayCount(type, sceneData) == 0 && this.GetDayMaxCount(type, sceneData) != 0;
			bool result;
			if (flag)
			{
				int num;
				int num2;
				bool flag2 = this.CanBuy(type, out num, out num2);
				if (flag2)
				{
					DlgBase<XBuyCountView, XBuyCountBehaviour>.singleton.PassiveShow(type);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_SCENE_TODYCOUNTLIMIT, "fece00");
				}
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06009CC6 RID: 40134 RVA: 0x001965B0 File Offset: 0x001947B0
		private bool IsLastTeamFinished(int expid)
		{
			return expid <= 3010;
		}

		// Token: 0x06009CC7 RID: 40135 RVA: 0x001965D8 File Offset: 0x001947D8
		public void UpdateTowerActivtyTop(GetTowerActivityTopRes oRes)
		{
			List<int> list = new List<int>(this._TowerData.Keys);
			for (int i = 0; i < this._TowerData.Count; i++)
			{
				this._TowerData[list[i]].open = false;
				this._TowerData[list[i]].showteam = false;
				this._TowerData[list[i]].level = 0;
				this._TowerData[list[i]].time = 0;
				this._TowerData[list[i]].sweeplefttime = 0;
				this._TowerData[list[i]].sweepfloor = 0;
				this._TowerData[list[i]].sweepreqtime = 0f;
			}
			int num = 3001;
			ExpeditionTable.RowData expeditionDataByID = this.GetExpeditionDataByID(num);
			bool flag = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= (ulong)((long)expeditionDataByID.RequiredLevel);
			if (flag)
			{
				this._TowerData[num].open = true;
				this._TowerData[num].showteam = true;
			}
			for (int j = 0; j < oRes.infos.Count; j++)
			{
				TowerRecord towerRecord = oRes.infos[j];
				bool flag2 = towerRecord.openHardLevel <= 0;
				if (!flag2)
				{
					int num2 = (towerRecord.openHardLevel - 1) * 10 + 3001;
					bool flag3 = this._TowerData.ContainsKey(num2);
					if (flag3)
					{
						ExpeditionTable.RowData expeditionDataByID2 = this.GetExpeditionDataByID(num2);
						this._TowerData[num2].level = towerRecord.reachTopFloor;
						this._TowerData[num2].time = towerRecord.bestTime;
						this._TowerData[num2].sweeplefttime = towerRecord.sweepTime;
						this._TowerData[num2].sweepfloor = towerRecord.sweepFloor;
						this._TowerData[num2].sweepreqtime = Time.time;
						this._TowerData[num2].open = true;
						bool flag4 = this.GetTeamTowerTopLevel(towerRecord.openHardLevel) <= towerRecord.sweepFloor;
						if (flag4)
						{
							this._TowerData[num2].showteam = true;
						}
						else
						{
							bool flag5 = this._TowerData.ContainsKey(list[j] + towerRecord.sweepFloor / 5);
							if (flag5)
							{
								bool flag6 = towerRecord.sweepTime == 0 && towerRecord.sweepFloor > 0;
								if (flag6)
								{
									this._TowerData[num2 + towerRecord.reachTopFloor / 5].showteam = true;
									this._TowerData[num2].showteam = false;
								}
								else
								{
									this._TowerData[num2].showteam = true;
								}
							}
						}
					}
				}
			}
			bool flag7 = oRes.infos.Count > 0;
			if (flag7)
			{
				TowerRecord towerRecord2 = oRes.infos[oRes.infos.Count - 1];
				bool flag8 = towerRecord2.reachTopFloor == this.GetTeamTowerTopLevel(towerRecord2.openHardLevel);
				if (flag8)
				{
					bool flag9 = towerRecord2.openHardLevel == 1;
					if (flag9)
					{
						this._TowerData[num + 10].showteam = true;
						this._TowerData[num + 10].open = true;
					}
				}
			}
		}

		// Token: 0x06009CC8 RID: 40136 RVA: 0x0019697C File Offset: 0x00194B7C
		public void OnRefreshShowTeam()
		{
			for (int i = 0; i < 3; i++)
			{
				int key = i * 10 + 3001;
				bool flag = this._TowerData.ContainsKey(key);
				if (flag)
				{
				}
			}
		}

		// Token: 0x06009CC9 RID: 40137 RVA: 0x001969BC File Offset: 0x00194BBC
		public int GetTeamTowerTopLevel(int hardlevel)
		{
			int num = 1;
			for (int i = 0; i < XExpeditionDocument._TeamTowerRewardTable.Table.Length; i++)
			{
				bool flag = XExpeditionDocument._TeamTowerRewardTable.Table[i].TowerHardLevel == hardlevel && XExpeditionDocument._TeamTowerRewardTable.Table[i].TowerFloor > num;
				if (flag)
				{
					num = XExpeditionDocument._TeamTowerRewardTable.Table[i].TowerFloor;
				}
			}
			return num;
		}

		// Token: 0x06009CCA RID: 40138 RVA: 0x00196A34 File Offset: 0x00194C34
		public bool IsTeamTowerOpen(int expid)
		{
			bool flag = this._TowerData.ContainsKey(expid);
			return flag && this._TowerData[expid].showteam;
		}

		// Token: 0x06009CCB RID: 40139 RVA: 0x00196A6C File Offset: 0x00194C6C
		public bool IsNestOpen(int expid)
		{
			ExpeditionTable.RowData expeditionDataByID = this.GetExpeditionDataByID(expid);
			return this.IsNestOpen(expeditionDataByID);
		}

		// Token: 0x06009CCC RID: 40140 RVA: 0x00196A90 File Offset: 0x00194C90
		public bool IsNestOpen(ExpeditionTable.RowData rowData)
		{
			bool flag = rowData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = rowData.Type != 3;
				if (flag2)
				{
					result = false;
				}
				else
				{
					int rank = XSingleton<XStageProgress>.singleton.GetRank((int)this.GetSceneIDByExpID(rowData.DNExpeditionID));
					bool flag3 = rank <= 0;
					result = !flag3;
				}
			}
			return result;
		}

		// Token: 0x06009CCD RID: 40141 RVA: 0x00196AEC File Offset: 0x00194CEC
		public uint GetSceneIDByExpID(int expID)
		{
			ExpeditionTable.RowData expeditionDataByID = this.GetExpeditionDataByID(expID);
			bool flag = expeditionDataByID == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				TeamLevelType type = (TeamLevelType)expeditionDataByID.Type;
				bool flag2 = type == TeamLevelType.TeamLevelExpdition;
				if (flag2)
				{
					result = 0U;
				}
				else
				{
					RandomSceneTable.RowData[] randomSceneTable = this.GetRandomSceneTable();
					for (int i = 0; i < randomSceneTable.Length; i++)
					{
						bool flag3 = randomSceneTable[i].RandomID == expeditionDataByID.RandomSceneIDs[0];
						if (flag3)
						{
							return randomSceneTable[i].SceneID;
						}
					}
					result = 0U;
				}
			}
			return result;
		}

		// Token: 0x06009CCE RID: 40142 RVA: 0x00196B74 File Offset: 0x00194D74
		public int GetExpIDBySceneID(uint sceneID)
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			RandomSceneTable.RowData[] randomSceneTable = specificDocument.GetRandomSceneTable();
			for (int i = 0; i < randomSceneTable.Length; i++)
			{
				bool flag = randomSceneTable[i].SceneID == sceneID;
				if (flag)
				{
					for (int j = 0; j < XExpeditionDocument._ExpeditionReader.Table.Length; j++)
					{
						uint[] randomSceneIDs = XExpeditionDocument._ExpeditionReader.Table[j].RandomSceneIDs;
						for (int k = 0; k < randomSceneIDs.Length; k++)
						{
							bool flag2 = randomSceneIDs[k] == randomSceneTable[i].RandomID;
							if (flag2)
							{
								return XExpeditionDocument._ExpeditionReader.Table[j].DNExpeditionID;
							}
						}
					}
				}
			}
			return 0;
		}

		// Token: 0x06009CCF RID: 40143 RVA: 0x00196C48 File Offset: 0x00194E48
		public void RefreshRedPoints()
		{
			XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_Level_Elite, this.GetDayCount(TeamLevelType.TeamLevelAbyss, null) > 0);
			XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_Activity_TeamTower, this.GetDayCount(TeamLevelType.TeamLevelTeamTower, null) > 0);
			XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_Activity_Nest, this.GetDayCount(TeamLevelType.TeamLevelNest, null) > 0);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Activity_Nest, true);
			XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_WeekNest, this.GetDayCount(TeamLevelType.TeamLevelWeekNest, null) > 0);
		}

		// Token: 0x06009CD0 RID: 40144 RVA: 0x00196CD4 File Offset: 0x00194ED4
		public void GetSingleTowerActivityTop()
		{
			RpcC2G_GetTowerActivityTop rpc = new RpcC2G_GetTowerActivityTop();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009CD1 RID: 40145 RVA: 0x00196CF4 File Offset: 0x00194EF4
		public void GetSingleTowerActivityTopRes(GetTowerActivityTopRes oRes)
		{
			this._SingleTowerData.sweepreqtime = Time.time;
			bool flag = oRes.infos.Count == 0;
			if (flag)
			{
				this._SingleTowerData.sweeplefttime = 0;
				this._SingleTowerData.level = 0;
				this._SingleTowerData.maxlevel = 0;
				this._SingleTowerData.time = 0;
				this._SingleTowerData.leftcount = oRes.leftResetCount;
				this._SingleTowerData.sweepfloor = 0;
				this._SingleTowerData.sweepreqtime = Time.time;
				this._SingleTowerData.refreshcount = 5;
				this._SingleTowerData.firstpassreward = new List<int>();
			}
			else
			{
				this._SingleTowerData.sweeplefttime = oRes.infos[0].sweepTime;
				this._SingleTowerData.level = oRes.infos[0].curFloor;
				this._SingleTowerData.maxlevel = oRes.infos[0].reachTopFloor;
				this._SingleTowerData.time = oRes.infos[0].bestTime;
				this._SingleTowerData.leftcount = oRes.leftResetCount;
				this._SingleTowerData.sweepfloor = oRes.infos[0].sweepFloor;
				this._SingleTowerData.sweepreqtime = Time.time;
				this._SingleTowerData.refreshcount = 5 - oRes.infos[0].refreshCount;
				this._SingleTowerData.firstpassreward = new List<int>();
				for (int i = 0; i < oRes.infos[0].gotFloorFirstPassReward.Count; i++)
				{
					this._SingleTowerData.firstpassreward.Add(oRes.infos[0].gotFloorFirstPassReward[i]);
				}
			}
			bool flag2 = this.TeamTowerSingleView != null && this.TeamTowerSingleView.IsVisible();
			if (flag2)
			{
				this.TeamTowerSingleView.OnRefreshTopInfo();
			}
			XActivityDocument.Doc.OnGetDayCount();
		}

		// Token: 0x06009CD2 RID: 40146 RVA: 0x00196F04 File Offset: 0x00195104
		public void SweepSingleTower()
		{
			RpcC2G_SweepTower rpcC2G_SweepTower = new RpcC2G_SweepTower();
			rpcC2G_SweepTower.oArg.hardLevel = 1;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SweepTower);
		}

		// Token: 0x06009CD3 RID: 40147 RVA: 0x00196F34 File Offset: 0x00195134
		public void SweepSingleTowerRes(SweepTowerArg oArg, SweepTowerRes oRes)
		{
			bool flag = this.TeamTowerSingleView != null && this.TeamTowerSingleView.IsVisible();
			if (flag)
			{
				this.TeamTowerSingleView.OnStartSweepRes(oArg, oRes.leftTime);
			}
		}

		// Token: 0x06009CD4 RID: 40148 RVA: 0x00196F70 File Offset: 0x00195170
		public void ResetSingleTower()
		{
			RpcC2G_ResetTower rpcC2G_ResetTower = new RpcC2G_ResetTower();
			rpcC2G_ResetTower.oArg.hardLevel = 1;
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ResetTower);
		}

		// Token: 0x06009CD5 RID: 40149 RVA: 0x00196FAC File Offset: 0x001951AC
		public void ResetSingleTowerRes()
		{
			bool flag = this.TeamTowerSingleView != null && this.TeamTowerSingleView.IsVisible();
			if (flag)
			{
				this.TeamTowerSingleView.OnResetSweepRes();
			}
		}

		// Token: 0x06009CD6 RID: 40150 RVA: 0x00196FE0 File Offset: 0x001951E0
		public void RefreshSingleSweepReward()
		{
			RpcC2G_RefreshSweepReward rpc = new RpcC2G_RefreshSweepReward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009CD7 RID: 40151 RVA: 0x00197000 File Offset: 0x00195200
		public void RefreshSingleSweepRewardRes(ErrorCode code, int result)
		{
			bool flag = this.TeamTowerSingleView != null && this.TeamTowerSingleView.IsVisible();
			if (flag)
			{
				this.TeamTowerSingleView.OnStartPlayRefreshResultEffect(code, result);
			}
		}

		// Token: 0x06009CD8 RID: 40152 RVA: 0x00197038 File Offset: 0x00195238
		public void GetSweepSingleTowerReward()
		{
			RpcC2G_GetSweepTowerReward rpc = new RpcC2G_GetSweepTowerReward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009CD9 RID: 40153 RVA: 0x00197058 File Offset: 0x00195258
		public void GetSweepSingleTowerRewardRes()
		{
			bool flag = this.TeamTowerSingleView != null && this.TeamTowerSingleView.IsVisible();
			if (flag)
			{
				this.TeamTowerSingleView.OnGotReward();
			}
		}

		// Token: 0x06009CDA RID: 40154 RVA: 0x0019708C File Offset: 0x0019528C
		public void GetFirstPassReward(int floor)
		{
			RpcC2G_GetTowerFirstPassReward rpcC2G_GetTowerFirstPassReward = new RpcC2G_GetTowerFirstPassReward();
			rpcC2G_GetTowerFirstPassReward.oArg.floor = floor;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetTowerFirstPassReward);
		}

		// Token: 0x06009CDB RID: 40155 RVA: 0x001970BC File Offset: 0x001952BC
		public void GetFirstPassRewardRes(ErrorCode error)
		{
			bool flag = this.TeamTowerSingleView != null && this.TeamTowerSingleView.IsVisible();
			if (flag)
			{
				this.TeamTowerSingleView.OnGetFirstPassRewardRes(error);
			}
		}

		// Token: 0x06009CDC RID: 40156 RVA: 0x001970F4 File Offset: 0x001952F4
		public void OnAppPaused()
		{
			bool flag = this.TeamTowerSingleView != null && this.TeamTowerSingleView.IsVisible();
			if (flag)
			{
				this.TeamTowerSingleView.OnRefreshReverseCount();
			}
		}

		// Token: 0x06009CDD RID: 40157 RVA: 0x00197128 File Offset: 0x00195328
		public bool IsPveAttrModifyScene(uint sceneID)
		{
			return XExpeditionDocument._PveAttrTable.GetBySceneID(sceneID) != null;
		}

		// Token: 0x06009CDE RID: 40158 RVA: 0x00197148 File Offset: 0x00195348
		public void TryShowPveAttrTips(uint expID)
		{
			uint sceneIDByExpID = this.GetSceneIDByExpID((int)expID);
			bool flag = this.IsPveAttrModifyScene(sceneIDByExpID);
			if (flag)
			{
				DlgBase<CapacityDownDlg, CapacityBehaviour>.singleton.ShowTips(XOptionsDefine.OD_NO_REFINED_CONFIRM, "PveAttrModifyTips");
			}
		}

		// Token: 0x06009CDF RID: 40159 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04003710 RID: 14096
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ExpeditionDocument");

		// Token: 0x04003711 RID: 14097
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003712 RID: 14098
		public ActivityExpeditionHandler ExpeditionView;

		// Token: 0x04003713 RID: 14099
		public ActivityNestHandler NestView;

		// Token: 0x04003714 RID: 14100
		public ActivityTeamTowerSingleDlg TeamTowerSingleView;

		// Token: 0x04003715 RID: 14101
		public ActivityRiftDlg TeamMysteriourView;

		// Token: 0x04003716 RID: 14102
		public ActivityGoddessTrialDlg GoddessTrialView;

		// Token: 0x04003717 RID: 14103
		private static ExpeditionTable _ExpeditionReader = new ExpeditionTable();

		// Token: 0x04003718 RID: 14104
		private static RandomSceneTable _RandomSceneReader = new RandomSceneTable();

		// Token: 0x04003719 RID: 14105
		private static TeamTowerRewardTable _TeamTowerRewardTable = new TeamTowerRewardTable();

		// Token: 0x0400371A RID: 14106
		private static PkProfessionTable _PkProfTable = new PkProfessionTable();

		// Token: 0x0400371B RID: 14107
		private static PVEAttrModify _PveAttrTable = new PVEAttrModify();

		// Token: 0x0400371C RID: 14108
		private int SelectExpId;

		// Token: 0x0400371E RID: 14110
		private int m_GoddessRewardsCanGetTimes = 0;

		// Token: 0x0400371F RID: 14111
		public XTeamCategoryMgr TeamCategoryMgr = new XTeamCategoryMgr();

		// Token: 0x04003720 RID: 14112
		public Dictionary<TeamLevelType, int> currentDayCount = new Dictionary<TeamLevelType, int>(default(XFastEnumIntEqualityComparer<TeamLevelType>));

		// Token: 0x04003721 RID: 14113
		public Dictionary<TeamLevelType, int> currentBuyCount = new Dictionary<TeamLevelType, int>(default(XFastEnumIntEqualityComparer<TeamLevelType>));

		// Token: 0x04003722 RID: 14114
		public Dictionary<TeamLevelType, int> maxCount = new Dictionary<TeamLevelType, int>(default(XFastEnumIntEqualityComparer<TeamLevelType>));

		// Token: 0x04003723 RID: 14115
		private Dictionary<int, TeamTowerData> _TowerData = new Dictionary<int, TeamTowerData>();

		// Token: 0x04003724 RID: 14116
		private TeamTowerData _SingleTowerData = new TeamTowerData();

		// Token: 0x04003725 RID: 14117
		private List<ExpeditionTable.RowData> _TempExpList = new List<ExpeditionTable.RowData>();
	}
}
