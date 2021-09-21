using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000921 RID: 2337
	internal class XGuildDailyTaskDocument : XDocComponent
	{
		// Token: 0x17002B9F RID: 11167
		// (get) Token: 0x06008CF7 RID: 36087 RVA: 0x00132D5C File Offset: 0x00130F5C
		public override uint ID
		{
			get
			{
				return XGuildDailyTaskDocument.uuID;
			}
		}

		// Token: 0x17002BA0 RID: 11168
		// (get) Token: 0x06008CF8 RID: 36088 RVA: 0x00132D74 File Offset: 0x00130F74
		public static XGuildDailyTaskDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XGuildDailyTaskDocument.uuID) as XGuildDailyTaskDocument;
			}
		}

		// Token: 0x06008CF9 RID: 36089 RVA: 0x00132D9F File Offset: 0x00130F9F
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildDailyTaskDocument.AsyncLoader.AddTask("Table/DailyTask", XGuildDailyTaskDocument._dailyTaskInfoTable, false);
			XGuildDailyTaskDocument.AsyncLoader.AddTask("Table/DailyTaskReward", XGuildDailyTaskDocument.DailyTaskRewardTable, false);
			XGuildDailyTaskDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008CFA RID: 36090 RVA: 0x00132DDA File Offset: 0x00130FDA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.DailyTaskHelpRefreshIcon = false;
			this.DailyTaskBeenRefreshIcon = false;
		}

		// Token: 0x06008CFB RID: 36091 RVA: 0x00132DF5 File Offset: 0x00130FF5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_TaskStateChange, new XComponent.XEventHandler(this.OnTaskStateChanged));
		}

		// Token: 0x06008CFC RID: 36092 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x06008CFD RID: 36093 RVA: 0x00132E17 File Offset: 0x00131017
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.InitFromServerData(arg.PlayerInfo.task_record);
		}

		// Token: 0x06008CFE RID: 36094 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x17002BA1 RID: 11169
		// (get) Token: 0x06008CFF RID: 36095 RVA: 0x00132E2C File Offset: 0x0013102C
		// (set) Token: 0x06008D00 RID: 36096 RVA: 0x00132E44 File Offset: 0x00131044
		public uint TaskRoleLevel
		{
			get
			{
				return this._taskRoleLevel;
			}
			set
			{
				this._taskRoleLevel = value;
				this.ResetRewardsMap();
			}
		}

		// Token: 0x17002BA2 RID: 11170
		// (get) Token: 0x06008D01 RID: 36097 RVA: 0x00132E58 File Offset: 0x00131058
		// (set) Token: 0x06008D02 RID: 36098 RVA: 0x00132E70 File Offset: 0x00131070
		public uint AskedNum
		{
			get
			{
				return this._askedNum;
			}
			set
			{
				this._askedNum = value;
			}
		}

		// Token: 0x17002BA3 RID: 11171
		// (get) Token: 0x06008D03 RID: 36099 RVA: 0x00132E7C File Offset: 0x0013107C
		// (set) Token: 0x06008D04 RID: 36100 RVA: 0x00132E94 File Offset: 0x00131094
		public uint Count
		{
			get
			{
				return this._count;
			}
			set
			{
				this._count = value;
			}
		}

		// Token: 0x17002BA4 RID: 11172
		// (get) Token: 0x06008D05 RID: 36101 RVA: 0x00132EA0 File Offset: 0x001310A0
		// (set) Token: 0x06008D06 RID: 36102 RVA: 0x00132EB8 File Offset: 0x001310B8
		public bool IsRewarded
		{
			get
			{
				return this._isRewarded;
			}
			set
			{
				this._isRewarded = value;
			}
		}

		// Token: 0x17002BA5 RID: 11173
		// (get) Token: 0x06008D07 RID: 36103 RVA: 0x00132EC4 File Offset: 0x001310C4
		public List<DailyTaskRefreshRoleInfo> DailyTaskRefreshRoleInfoList
		{
			get
			{
				return this._dailyTaskRefreshRoleInfoList;
			}
		}

		// Token: 0x17002BA6 RID: 11174
		// (get) Token: 0x06008D08 RID: 36104 RVA: 0x00132EDC File Offset: 0x001310DC
		public List<DailyTaskRefreshRoleInfo> AskInfoList
		{
			get
			{
				return this._askInfoList;
			}
		}

		// Token: 0x17002BA7 RID: 11175
		// (get) Token: 0x06008D09 RID: 36105 RVA: 0x00132EF4 File Offset: 0x001310F4
		public List<DailyTaskRefreshInfo> DailyTaskRefreshRecordList
		{
			get
			{
				return this._dailyTaskRefreshRecordList;
			}
		}

		// Token: 0x17002BA8 RID: 11176
		// (get) Token: 0x06008D0A RID: 36106 RVA: 0x00132F0C File Offset: 0x0013110C
		public uint Refresh_num
		{
			get
			{
				return this._refresh_num;
			}
		}

		// Token: 0x17002BA9 RID: 11177
		// (get) Token: 0x06008D0B RID: 36107 RVA: 0x00132F24 File Offset: 0x00131124
		public uint CurScore
		{
			get
			{
				return this._curScore;
			}
		}

		// Token: 0x17002BAA RID: 11178
		// (get) Token: 0x06008D0C RID: 36108 RVA: 0x00132F3C File Offset: 0x0013113C
		public uint TodayBuyNumber
		{
			get
			{
				return this._todayBuyNum;
			}
		}

		// Token: 0x17002BAB RID: 11179
		// (get) Token: 0x06008D0D RID: 36109 RVA: 0x00132F54 File Offset: 0x00131154
		public uint HelpNum
		{
			get
			{
				return this._helpNum;
			}
		}

		// Token: 0x17002BAC RID: 11180
		// (get) Token: 0x06008D0E RID: 36110 RVA: 0x00132F6C File Offset: 0x0013116C
		public uint MyLuck
		{
			get
			{
				return this._myLuck;
			}
		}

		// Token: 0x17002BAD RID: 11181
		// (get) Token: 0x06008D0F RID: 36111 RVA: 0x00132F84 File Offset: 0x00131184
		// (set) Token: 0x06008D10 RID: 36112 RVA: 0x00132F8C File Offset: 0x0013118C
		public bool DailyTaskHelpRefreshIcon { get; set; }

		// Token: 0x17002BAE RID: 11182
		// (get) Token: 0x06008D11 RID: 36113 RVA: 0x00132F95 File Offset: 0x00131195
		// (set) Token: 0x06008D12 RID: 36114 RVA: 0x00132F9D File Offset: 0x0013119D
		public bool DailyTaskBeenRefreshIcon { get; set; }

		// Token: 0x06008D13 RID: 36115 RVA: 0x00132FA8 File Offset: 0x001311A8
		public void SendGetDailyTaskInfo()
		{
			RpcC2G_GetDailyTaskInfo rpc = new RpcC2G_GetDailyTaskInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008D14 RID: 36116 RVA: 0x00132FC8 File Offset: 0x001311C8
		public void OnGetDailyTasks(GetDailyTaskInfoRes res)
		{
			this.UpdateTaskContent(res.task);
			this.TaskRoleLevel = res.accept_level;
			this.AskedNum = res.askhelp_num;
			this.Count = res.count;
			this.IsRewarded = res.is_rewarded;
			this._curScore = res.score;
			this._refresh_num = res.remain_refresh_count;
			this._myLuck = Math.Max(1U, res.luck);
			bool flag = DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.RefreshTaskContent();
			}
		}

		// Token: 0x06008D15 RID: 36117 RVA: 0x0013305C File Offset: 0x0013125C
		public void GiveUpTask()
		{
			RpcC2G_DailyTaskGiveUp rpc = new RpcC2G_DailyTaskGiveUp();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008D16 RID: 36118 RVA: 0x0013307C File Offset: 0x0013127C
		public void OnGiveUpTask(DailyTaskGiveUpRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				bool flag2 = DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.SetVisibleWithAnimation(false, null);
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
		}

		// Token: 0x06008D17 RID: 36119 RVA: 0x001330D0 File Offset: 0x001312D0
		private bool OnTaskStateChanged(XEventArgs e)
		{
			XTaskStatusChangeArgs xtaskStatusChangeArgs = e as XTaskStatusChangeArgs;
			bool flag = xtaskStatusChangeArgs.status == TaskStatus.TaskStatus_Taked;
			if (flag)
			{
				uint id = xtaskStatusChangeArgs.id;
				TaskTableNew.RowData taskData = XTaskDocument.GetTaskData(id);
				bool flag2 = taskData != null;
				if (flag2)
				{
					bool flag3 = taskData.TaskType == 4U;
					if (flag3)
					{
						DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.SetVisibleWithAnimation(true, null);
					}
					bool flag4 = taskData.TaskType == 7U;
					if (flag4)
					{
						DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.SetVisibleWithAnimation(true, null);
					}
				}
			}
			return true;
		}

		// Token: 0x06008D18 RID: 36120 RVA: 0x00133154 File Offset: 0x00131354
		private void UpdateTaskContent(List<DailyTaskInfo> task)
		{
			this._curGuildDailyTaskList.Clear();
			for (int i = 0; i < task.Count; i++)
			{
				DailyTaskInfo dailyTaskInfo = task[i];
				this._curGuildDailyTaskList.Add(new GuildDailyTaskInfo
				{
					taskID = dailyTaskInfo.id,
					step = dailyTaskInfo.step,
					isRewarded = dailyTaskInfo.is_rewarded,
					hasAsked = dailyTaskInfo.ask_help
				});
			}
			this._curGuildDailyTaskList.Sort(new Comparison<GuildDailyTaskInfo>(this.SortDailyTask));
		}

		// Token: 0x06008D19 RID: 36121 RVA: 0x001331E8 File Offset: 0x001313E8
		public DailyTaskReward.RowData GetSingleTaskRewardInfoByID(GuildTaskType type, uint taskID)
		{
			DailyTask.RowData dailyTaskTableInfoByID = this.GetDailyTaskTableInfoByID(taskID);
			bool flag = dailyTaskTableInfoByID != null;
			if (flag)
			{
				uint mappingValueWithQualityAndType = XGuildDailyTaskDocument.GetMappingValueWithQualityAndType(type, 1U, dailyTaskTableInfoByID.taskquality);
				DailyTaskReward.RowData result;
				bool flag2 = this._guildTaskRewardWithMap.TryGetValue(mappingValueWithQualityAndType, out result);
				if (flag2)
				{
					return result;
				}
			}
			return null;
		}

		// Token: 0x06008D1A RID: 36122 RVA: 0x00133238 File Offset: 0x00131438
		public DailyTaskReward.RowData GetTotalTaskRewardInfo(GuildTaskType type, uint count)
		{
			uint mappingValueWithQualityAndType = XGuildDailyTaskDocument.GetMappingValueWithQualityAndType(type, 2U, count);
			DailyTaskReward.RowData rowData;
			bool flag = this._guildTaskRewardWithMap.TryGetValue(mappingValueWithQualityAndType, out rowData);
			DailyTaskReward.RowData result;
			if (flag)
			{
				result = rowData;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06008D1B RID: 36123 RVA: 0x0013326C File Offset: 0x0013146C
		public bool GoToTakeTask()
		{
			XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
			XTaskRecord taskRecord = specificDocument.TaskRecord;
			for (int i = 0; i < taskRecord.Tasks.Count; i++)
			{
				bool flag = taskRecord.Tasks[i].Status == TaskStatus.TaskStatus_CanTake && taskRecord.Tasks[i].TableData.TaskType == 4U;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06008D1C RID: 36124 RVA: 0x001332EC File Offset: 0x001314EC
		public int GetRewardedTaskCount()
		{
			int num = 0;
			for (int i = 0; i < this._curGuildDailyTaskList.Count; i++)
			{
				bool isRewarded = this._curGuildDailyTaskList[i].isRewarded;
				if (isRewarded)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06008D1D RID: 36125 RVA: 0x00133338 File Offset: 0x00131538
		internal GuildDailyTaskInfo GetTaskInfoByIndex(int index)
		{
			bool flag = index < this._curGuildDailyTaskList.Count;
			GuildDailyTaskInfo result;
			if (flag)
			{
				result = this._curGuildDailyTaskList[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06008D1E RID: 36126 RVA: 0x0013336C File Offset: 0x0013156C
		public int GetTaskItemCount()
		{
			return this._curGuildDailyTaskList.Count;
		}

		// Token: 0x06008D1F RID: 36127 RVA: 0x0013338C File Offset: 0x0013158C
		public void SendToGetMyTaskReward(uint type, uint id)
		{
			RpcC2G_GetDailyTaskReward rpcC2G_GetDailyTaskReward = new RpcC2G_GetDailyTaskReward();
			rpcC2G_GetDailyTaskReward.oArg.type = type;
			rpcC2G_GetDailyTaskReward.oArg.id = id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetDailyTaskReward);
		}

		// Token: 0x06008D20 RID: 36128 RVA: 0x001333C8 File Offset: 0x001315C8
		public void OnGetDailyTaskReward(GetDailyTaskRewardArg oArg, GetDailyTaskRewardRes oRes)
		{
			bool flag = oRes.code == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
				int rewardedTaskCount = XGuildDailyTaskDocument.Doc.GetRewardedTaskCount();
				bool flag2 = rewardedTaskCount >= XSingleton<XGlobalConfig>.singleton.GetInt("DailyTaskMinTotalTaskCount") && oArg.type == 2U;
				if (flag2)
				{
					DailyTaskReward.RowData totalTaskRewardInfo = this.GetTotalTaskRewardInfo(GuildTaskType.DailyTask, (uint)rewardedTaskCount);
					bool flag3 = totalTaskRewardInfo == null;
					if (flag3)
					{
						return;
					}
					List<ItemBrief> list = new List<ItemBrief>();
					SeqListRef<uint>? rewadsByScore = this.GetRewadsByScore(totalTaskRewardInfo, this._curScore);
					bool flag4 = rewadsByScore != null;
					if (flag4)
					{
						for (int i = 0; i < (int)rewadsByScore.Value.count; i++)
						{
							ItemBrief itemBrief = new ItemBrief();
							itemBrief.itemID = rewadsByScore.Value[i, 0];
							int num = (int)rewadsByScore.Value[i, 1];
							bool flag5 = itemBrief.itemID == 4U && specificDocument.IsInLevelSeal();
							if (flag5)
							{
								num = (int)((double)num * 0.5);
							}
							itemBrief.itemCount = (uint)num;
							list.Add(itemBrief);
						}
					}
					bool flag6 = rewardedTaskCount >= this.GetTaskItemCount();
					if (flag6)
					{
						List<GuildTaskReward> additionalRewards = this.GetAdditionalRewards();
						foreach (GuildTaskReward guildTaskReward in additionalRewards)
						{
							ItemBrief itemBrief2 = new ItemBrief();
							itemBrief2.itemID = guildTaskReward.itemID;
							uint num2 = guildTaskReward.count;
							bool flag7 = guildTaskReward.itemID == 4U && specificDocument.IsInLevelSeal();
							if (flag7)
							{
								num2 = (uint)(num2 * 0.5);
							}
							itemBrief2.itemCount = num2;
							list.Add(itemBrief2);
						}
					}
					DlgBase<RewdAnimDlg, RewdAnimBehaviour>.singleton.ShowByTitle(list, XSingleton<XStringTable>.singleton.GetString("DailyTaskRewards"), null);
				}
				this.UpdateTaskContent(oRes.task);
				bool flag8 = oArg.type == 1U;
				if (flag8)
				{
					bool flag9 = DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.IsVisible();
					if (flag9)
					{
						DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.RefreshTaskItemByID(oArg.id);
					}
				}
				else
				{
					bool flag10 = oArg.type == 2U;
					if (flag10)
					{
						bool flag11 = DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.IsVisible();
						if (flag11)
						{
							DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.SetVisibleWithAnimation(false, null);
						}
					}
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.code, "fece00");
			}
		}

		// Token: 0x06008D21 RID: 36129 RVA: 0x00133668 File Offset: 0x00131868
		public GuildDailyTaskInfo GetTaskInfoByID(uint id)
		{
			for (int i = 0; i < this._curGuildDailyTaskList.Count; i++)
			{
				bool flag = this._curGuildDailyTaskList[i].taskID == id;
				if (flag)
				{
					return this._curGuildDailyTaskList[i];
				}
			}
			return null;
		}

		// Token: 0x06008D22 RID: 36130 RVA: 0x001336C0 File Offset: 0x001318C0
		public DailyTask.RowData GetDailyTaskTableInfoByID(uint taskID)
		{
			for (int i = 0; i < XGuildDailyTaskDocument._dailyTaskInfoTable.Table.Length; i++)
			{
				DailyTask.RowData rowData = XGuildDailyTaskDocument._dailyTaskInfoTable.Table[i];
				bool flag = rowData.taskID == taskID;
				if (flag)
				{
					return rowData;
				}
			}
			return null;
		}

		// Token: 0x06008D23 RID: 36131 RVA: 0x00133710 File Offset: 0x00131910
		public List<GuildTaskReward> GetAdditionalRewards()
		{
			for (int i = 0; i < XGuildDailyTaskDocument.DailyTaskRewardTable.Table.Length; i++)
			{
				DailyTaskReward.RowData rowData = XGuildDailyTaskDocument.DailyTaskRewardTable.Table[i];
				uint num = rowData.level[0];
				uint num2 = rowData.level[1];
				SeqListRef<uint>? extraRewadsByScore = this.GetExtraRewadsByScore(rowData, this._curScore);
				bool flag = this._taskRoleLevel >= num && this._taskRoleLevel <= num2 && extraRewadsByScore != null && extraRewadsByScore.Value.count > 0;
				if (flag)
				{
					List<GuildTaskReward> list = new List<GuildTaskReward>();
					for (int j = 0; j < extraRewadsByScore.Value.Count; j++)
					{
						list.Add(new GuildTaskReward
						{
							itemID = extraRewadsByScore.Value[j, 0],
							count = extraRewadsByScore.Value[j, 1]
						});
					}
					return list;
				}
			}
			return null;
		}

		// Token: 0x06008D24 RID: 36132 RVA: 0x00133828 File Offset: 0x00131A28
		public static uint GetMappingValueWithQualityAndType(GuildTaskType category, uint type, uint quality)
		{
			return (uint)((int)(GuildTaskType)10000 * (int)category + (int)(1000U * type) + (int)quality);
		}

		// Token: 0x06008D25 RID: 36133 RVA: 0x00133850 File Offset: 0x00131A50
		public SeqListRef<uint>? GetRewadsByScore(DailyTaskReward.RowData data, uint score)
		{
			SeqListRef<uint>? result;
			switch (score)
			{
			case 0U:
				result = new SeqListRef<uint>?(data.reward_d);
				break;
			case 1U:
				result = new SeqListRef<uint>?(data.reward_c);
				break;
			case 2U:
				result = new SeqListRef<uint>?(data.reward_b);
				break;
			case 3U:
				result = new SeqListRef<uint>?(data.reward_a);
				break;
			case 4U:
				result = new SeqListRef<uint>?(data.reward_s);
				break;
			default:
				result = null;
				break;
			}
			return result;
		}

		// Token: 0x06008D26 RID: 36134 RVA: 0x001338D0 File Offset: 0x00131AD0
		public SeqListRef<uint>? GetExtraRewadsByScore(DailyTaskReward.RowData data, uint score)
		{
			SeqListRef<uint>? result;
			switch (score)
			{
			case 0U:
				result = new SeqListRef<uint>?(data.extrareward_d);
				break;
			case 1U:
				result = new SeqListRef<uint>?(data.extrareward_c);
				break;
			case 2U:
				result = new SeqListRef<uint>?(data.extrareward_b);
				break;
			case 3U:
				result = new SeqListRef<uint>?(data.extrareward_a);
				break;
			case 4U:
				result = new SeqListRef<uint>?(data.extrareward_s);
				break;
			default:
				result = null;
				break;
			}
			return result;
		}

		// Token: 0x06008D27 RID: 36135 RVA: 0x00133950 File Offset: 0x00131B50
		private int SortDailyTask(GuildDailyTaskInfo x, GuildDailyTaskInfo y)
		{
			bool flag = x.isRewarded ^ y.isRewarded;
			int result;
			if (flag)
			{
				result = (x.isRewarded ? 1 : -1);
			}
			else
			{
				DailyTask.RowData dailyTaskTableInfoByID = this.GetDailyTaskTableInfoByID(x.taskID);
				DailyTask.RowData dailyTaskTableInfoByID2 = this.GetDailyTaskTableInfoByID(y.taskID);
				bool flag2 = dailyTaskTableInfoByID == null || dailyTaskTableInfoByID2 == null;
				if (flag2)
				{
					result = 0;
				}
				else
				{
					bool flag3 = dailyTaskTableInfoByID.taskquality != dailyTaskTableInfoByID2.taskquality;
					if (flag3)
					{
						result = (int)(dailyTaskTableInfoByID2.taskquality - dailyTaskTableInfoByID.taskquality);
					}
					else
					{
						result = (int)(dailyTaskTableInfoByID.taskID - dailyTaskTableInfoByID2.taskID);
					}
				}
			}
			return result;
		}

		// Token: 0x06008D28 RID: 36136 RVA: 0x001339E8 File Offset: 0x00131BE8
		private void ResetRewardsMap()
		{
			this._guildTaskRewardWithMap.Clear();
			for (int i = 0; i < XGuildDailyTaskDocument.DailyTaskRewardTable.Table.Length; i++)
			{
				DailyTaskReward.RowData rowData = XGuildDailyTaskDocument.DailyTaskRewardTable.Table[i];
				uint num = rowData.level[0];
				uint num2 = rowData.level[1];
				bool flag = this._taskRoleLevel >= num && this._taskRoleLevel <= num2;
				if (flag)
				{
					uint mappingValueWithQualityAndType = XGuildDailyTaskDocument.GetMappingValueWithQualityAndType((GuildTaskType)rowData.category, rowData.tasktype, rowData.taskquality);
					bool flag2 = !this._guildTaskRewardWithMap.ContainsKey(mappingValueWithQualityAndType);
					if (flag2)
					{
						this._guildTaskRewardWithMap.Add(mappingValueWithQualityAndType, rowData);
					}
					else
					{
						XSingleton<XDebug>.singleton.AddGreenLog(string.Concat(new object[]
						{
							"Same taskType and quality",
							this._taskRoleLevel,
							" type",
							rowData.tasktype,
							"  quality",
							rowData.taskquality,
							" index",
							i
						}), null, null, null, null, null);
					}
				}
			}
		}

		// Token: 0x06008D29 RID: 36137 RVA: 0x00133B24 File Offset: 0x00131D24
		public void SendDailyTaskAskHelp(PeriodTaskType type, uint taskID)
		{
			RpcC2G_DailyTaskAskHelp rpcC2G_DailyTaskAskHelp = new RpcC2G_DailyTaskAskHelp();
			rpcC2G_DailyTaskAskHelp.oArg.task_id = taskID;
			rpcC2G_DailyTaskAskHelp.oArg.task_type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_DailyTaskAskHelp);
		}

		// Token: 0x06008D2A RID: 36138 RVA: 0x00133B60 File Offset: 0x00131D60
		public void OnGetDailyHelpReply(DailyTaskAskHelpArg oArg, DailyTaskAskHelpRes oRes)
		{
			bool flag = oRes.code == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ReqHelpSuccess"), "fece00");
				DailyTask.RowData dailyTaskTableInfoByID = this.GetDailyTaskTableInfoByID(oArg.task_id);
				this.SendGuildDonateReq(dailyTaskTableInfoByID.conditionNum, dailyTaskTableInfoByID.conditionId[0], oRes.ask_uid, NoticeType.NT_GUILD_Daily_DONATE_REQ);
				GuildDailyTaskInfo taskInfoByID = this.GetTaskInfoByID(oArg.task_id);
				bool flag2 = taskInfoByID != null;
				if (flag2)
				{
					taskInfoByID.hasAsked = true;
					uint askedNum = this.AskedNum;
					this.AskedNum = askedNum + 1U;
					bool flag3 = DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.IsVisible();
					if (flag3)
					{
						DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.RefreshTaskItemByID(oArg.task_id);
					}
				}
			}
		}

		// Token: 0x06008D2B RID: 36139 RVA: 0x00133C20 File Offset: 0x00131E20
		public void SendToRefreshTasks()
		{
			RpcC2M_GetDailyTaskRefreshInfo rpc = new RpcC2M_GetDailyTaskRefreshInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008D2C RID: 36140 RVA: 0x00133C40 File Offset: 0x00131E40
		public void OnGetTaskRefreshInfo(GetDailyTaskRefreshInfoRes oRes)
		{
			this._dailyTaskRefreshRoleInfoList = oRes.friendinfo;
			this._myLuck = Math.Max(1U, oRes.luck);
			this._refresh_num = oRes.refresh_num;
			this._todayBuyNum = oRes.today_buy_num;
			this._dailyTaskRefreshRoleInfoList.Sort(new Comparison<DailyTaskRefreshRoleInfo>(this.SortTaskRefreshInfo));
			this._dailyTaskRefreshRoleInfoList.Insert(0, new DailyTaskRefreshRoleInfo
			{
				luck = this._myLuck,
				refresh_num = this._refresh_num,
				roleid = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID,
				profession = XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession,
				already_ask = (this._refresh_num <= 0U),
				name = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name
			});
			bool flag = DlgBase<XGuildDailyRefreshTaskDlg, XGuildDailyRefreshTaskBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildDailyRefreshTaskDlg, XGuildDailyRefreshTaskBehavior>.singleton.RefreshContent();
			}
		}

		// Token: 0x06008D2D RID: 36141 RVA: 0x00133D38 File Offset: 0x00131F38
		private int SortTaskRefreshInfo(DailyTaskRefreshRoleInfo x, DailyTaskRefreshRoleInfo y)
		{
			bool flag = x.luck != y.luck;
			int result;
			if (flag)
			{
				result = (int)(y.luck - x.luck);
			}
			else
			{
				bool flag2 = x.time != y.time;
				if (flag2)
				{
					result = (int)(y.time - x.time);
				}
				else
				{
					int friendDegreeAll = (int)DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetFriendDegreeAll(x.roleid);
					int friendDegreeAll2 = (int)DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetFriendDegreeAll(y.roleid);
					result = friendDegreeAll2 - friendDegreeAll;
				}
			}
			return result;
		}

		// Token: 0x06008D2E RID: 36142 RVA: 0x00133DBC File Offset: 0x00131FBC
		public void SendToGetAskRefreshTaskInfo()
		{
			RpcC2M_GetDailyTaskAskHelp rpc = new RpcC2M_GetDailyTaskAskHelp();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008D2F RID: 36143 RVA: 0x00133DDC File Offset: 0x00131FDC
		public void OnGetTaskHelpInfo(GetDailyTaskAskHelpRes oRes)
		{
			this._askInfoList = oRes.askinfos;
			bool flag = this._askInfoList.Count == 0;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DailyTaskRefreshOutdate"), "fece00");
			}
			this._helpNum = oRes.help_num;
			this._myLuck = Math.Max(1U, oRes.luck);
			this.RefreshRequestSysIcon();
			bool flag2 = DlgBase<XGuildDailyHandleRefreshDlg, XGuildDailyHandleRefreshBehavior>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<XGuildDailyHandleRefreshDlg, XGuildDailyHandleRefreshBehavior>.singleton.RefreshContent();
			}
		}

		// Token: 0x06008D30 RID: 36144 RVA: 0x00133E60 File Offset: 0x00132060
		public void SendToGetRefreshLogInfo()
		{
			RpcC2M_GetDailyTaskRefreshRecord rpc = new RpcC2M_GetDailyTaskRefreshRecord();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008D31 RID: 36145 RVA: 0x00133E80 File Offset: 0x00132080
		public void OnGetRefreshRecordInfo(GetDailyTaskRefreshRecordRes oRes)
		{
			this._dailyTaskRefreshRecordList = oRes.records;
			this._dailyTaskRefreshRecordList.Reverse();
			bool flag = DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = false;
				for (int i = 0; i < this._dailyTaskRefreshRecordList.Count; i++)
				{
					bool isnew = this._dailyTaskRefreshRecordList[i].isnew;
					if (isnew)
					{
						flag2 = true;
						break;
					}
				}
				bool flag3 = flag2;
				if (flag3)
				{
					DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.RefreshLogContent();
				}
			}
		}

		// Token: 0x06008D32 RID: 36146 RVA: 0x00133F04 File Offset: 0x00132104
		public void SendToRefreshTaskOp(DailyRefreshOperType type, ulong roleID)
		{
			RpcC2M_DailyTaskRefreshOper rpcC2M_DailyTaskRefreshOper = new RpcC2M_DailyTaskRefreshOper();
			rpcC2M_DailyTaskRefreshOper.oArg.type = type;
			rpcC2M_DailyTaskRefreshOper.oArg.roleid = roleID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_DailyTaskRefreshOper);
		}

		// Token: 0x06008D33 RID: 36147 RVA: 0x00133F40 File Offset: 0x00132140
		public void OnGetTaskRefreshOperResult(DailyTaskRefreshOperArg oArg, DailyTaskRefreshOperRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				switch (oArg.type)
				{
				case DailyRefreshOperType.DROT_Refresh:
				{
					bool flag2 = this._refresh_num > 0U;
					if (flag2)
					{
						this._refresh_num -= 1U;
					}
					for (int i = 0; i < this._askInfoList.Count; i++)
					{
						bool flag3 = this._askInfoList[i].roleid == oArg.roleid;
						if (flag3)
						{
							this._askInfoList[i].refresh_num -= 1U;
							this._askInfoList[i].score = oRes.score;
							List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("DailyGuildRefreshNotifyLevel");
							bool flag4 = intList.Contains((int)oRes.score);
							if (flag4)
							{
								this.SendNotifyToGuildChannel(this._askInfoList[i], (int)oRes.score);
							}
							bool flag5 = this._askInfoList[i].refresh_num <= 0U || oRes.score == 4U;
							if (flag5)
							{
								this._askInfoList.RemoveAt(i);
							}
							break;
						}
					}
					bool flag6 = oArg.roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag6)
					{
						this._curScore = oRes.score;
						bool flag7 = DlgBase<XGuildDailyRefreshTaskDlg, XGuildDailyRefreshTaskBehavior>.singleton.IsVisible();
						if (flag7)
						{
							bool flag8 = this._dailyTaskRefreshRoleInfoList.Count > 0 && this._dailyTaskRefreshRoleInfoList[0].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
							if (flag8)
							{
								this._dailyTaskRefreshRoleInfoList[0].refresh_num = this._refresh_num;
								this._dailyTaskRefreshRoleInfoList[0].already_ask = (this._dailyTaskRefreshRoleInfoList[0].refresh_num <= 0U);
							}
							DlgBase<XGuildDailyRefreshTaskDlg, XGuildDailyRefreshTaskBehavior>.singleton.RefreshContent();
						}
					}
					else
					{
						this._helpNum -= 1U;
					}
					bool flag9 = DlgBase<XGuildDailyHandleRefreshDlg, XGuildDailyHandleRefreshBehavior>.singleton.IsVisible();
					if (flag9)
					{
						DlgBase<XGuildDailyHandleRefreshDlg, XGuildDailyHandleRefreshBehavior>.singleton.RefreshContent();
					}
					DlgBase<XGuildTaskRefreshResultDlg, XGuildTaskRefreshResultDlgBehavior>.singleton.AfterScore = oRes.score;
					DlgBase<XGuildTaskRefreshResultDlg, XGuildTaskRefreshResultDlgBehavior>.singleton.BeforeScore = oRes.oldscore;
					DlgBase<XGuildTaskRefreshResultDlg, XGuildTaskRefreshResultDlgBehavior>.singleton.SetVisibleWithAnimation(true, null);
					XGuildMemberDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMemberDocument>(XGuildMemberDocument.uuID);
					specificDocument.RefreshMemberTaskScore(oArg.roleid, oRes.score);
					bool flag10 = DlgBase<XGuildMembersView, XGuildMembersBehaviour>.singleton.IsVisible();
					if (flag10)
					{
						DlgBase<XGuildMembersView, XGuildMembersBehaviour>.singleton.OnRefreshDailyTaskReply();
					}
					break;
				}
				case DailyRefreshOperType.DROT_Refuse:
				{
					for (int j = 0; j < this._askInfoList.Count; j++)
					{
						bool flag11 = this._askInfoList[j].roleid == oArg.roleid;
						if (flag11)
						{
							this._askInfoList.RemoveAt(j);
							break;
						}
					}
					bool flag12 = this._askInfoList.Count == 0;
					if (flag12)
					{
						this.DailyTaskHelpRefreshIcon = false;
						DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildDailyRequest, true);
					}
					bool flag13 = DlgBase<XGuildDailyHandleRefreshDlg, XGuildDailyHandleRefreshBehavior>.singleton.IsVisible();
					if (flag13)
					{
						DlgBase<XGuildDailyHandleRefreshDlg, XGuildDailyHandleRefreshBehavior>.singleton.RefreshContent();
					}
					break;
				}
				case DailyRefreshOperType.DROT_BuyCount:
				{
					this._refresh_num += 1U;
					this._todayBuyNum += 1U;
					bool flag14 = this._dailyTaskRefreshRoleInfoList.Count > 0 && this._dailyTaskRefreshRoleInfoList[0].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag14)
					{
						this._dailyTaskRefreshRoleInfoList[0].refresh_num = this._refresh_num;
						this._dailyTaskRefreshRoleInfoList[0].already_ask = (this._dailyTaskRefreshRoleInfoList[0].refresh_num <= 0U);
					}
					bool flag15 = DlgBase<XGuildDailyRefreshTaskDlg, XGuildDailyRefreshTaskBehavior>.singleton.IsVisible();
					if (flag15)
					{
						DlgBase<XGuildDailyRefreshTaskDlg, XGuildDailyRefreshTaskBehavior>.singleton.RefreshContent();
					}
					break;
				}
				case DailyRefreshOperType.DROT_AskHelp:
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DailyAskForHelpSuccess"), "fece00");
					for (int k = 0; k < this._dailyTaskRefreshRoleInfoList.Count; k++)
					{
						bool flag16 = this._dailyTaskRefreshRoleInfoList[k].roleid == oArg.roleid;
						if (flag16)
						{
							this._dailyTaskRefreshRoleInfoList[k].already_ask = true;
							break;
						}
					}
					bool flag17 = DlgBase<XGuildDailyRefreshTaskDlg, XGuildDailyRefreshTaskBehavior>.singleton.IsVisible();
					if (flag17)
					{
						DlgBase<XGuildDailyRefreshTaskDlg, XGuildDailyRefreshTaskBehavior>.singleton.RefreshContent();
					}
					break;
				}
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				bool flag18 = oArg.roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID && oArg.type == DailyRefreshOperType.DROT_Refresh && oRes.result == ErrorCode.ERR_DAILY_TASK_NO_REFRESH_COUNT;
				if (flag18)
				{
					this._refresh_num = 0U;
					bool flag19 = DlgBase<XGuildDailyRefreshTaskDlg, XGuildDailyRefreshTaskBehavior>.singleton.IsVisible();
					if (flag19)
					{
						bool flag20 = this._dailyTaskRefreshRoleInfoList.Count > 0 && this._dailyTaskRefreshRoleInfoList[0].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
						if (flag20)
						{
							this._dailyTaskRefreshRoleInfoList[0].refresh_num = this._refresh_num;
							this._dailyTaskRefreshRoleInfoList[0].already_ask = (this._dailyTaskRefreshRoleInfoList[0].refresh_num <= 0U);
						}
						DlgBase<XGuildDailyRefreshTaskDlg, XGuildDailyRefreshTaskBehavior>.singleton.RefreshContent();
					}
				}
				bool flag21 = oArg.type == DailyRefreshOperType.DROT_Refuse || oArg.type == DailyRefreshOperType.DROT_Refresh;
				if (flag21)
				{
					for (int l = 0; l < this._askInfoList.Count; l++)
					{
						bool flag22 = this._askInfoList[l].roleid == oArg.roleid;
						if (flag22)
						{
							this._askInfoList.RemoveAt(l);
							break;
						}
					}
				}
				this.RefreshRequestSysIcon();
				bool flag23 = DlgBase<XGuildDailyHandleRefreshDlg, XGuildDailyHandleRefreshBehavior>.singleton.IsVisible();
				if (flag23)
				{
					DlgBase<XGuildDailyHandleRefreshDlg, XGuildDailyHandleRefreshBehavior>.singleton.RefreshContent();
				}
			}
		}

		// Token: 0x06008D34 RID: 36148 RVA: 0x00134570 File Offset: 0x00132770
		private void SendNotifyToGuildChannel(DailyTaskRefreshRoleInfo dailyTaskRefreshRoleInfo, int level)
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool flag = !specificDocument.CheckInGuild();
			if (!flag)
			{
				XInvitationDocument specificDocument2 = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
				NoticeTable.RowData noticeData = specificDocument2.GetNoticeData(NoticeType.NT_GUILD_Daily_Refresh_Thanks_REQ);
				bool flag2 = noticeData == null;
				if (!flag2)
				{
					string itemQualityName = XSingleton<UiUtility>.singleton.GetItemQualityName(level);
					List<string> stringList = XSingleton<XGlobalConfig>.singleton.GetStringList("LuckyLevel");
					int index = Math.Min((int)(this._myLuck - 1U), stringList.Count - 1);
					List<ChatParam> list = new List<ChatParam>();
					ChatParam chatParam = new ChatParam();
					chatParam.link = new ChatParamLink();
					chatParam.link.id = noticeData.linkparam;
					chatParam.link.content = noticeData.linkcontent;
					ChatParam chatParam2 = new ChatParam();
					chatParam2.role = new ChatParamRole();
					chatParam2.role.uniqueid = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					chatParam2.role.name = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
					chatParam2.role.profession = XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID;
					ChatParam chatParam3 = new ChatParam();
					chatParam3.role = new ChatParamRole();
					chatParam3.role.uniqueid = dailyTaskRefreshRoleInfo.roleid;
					chatParam3.role.name = dailyTaskRefreshRoleInfo.name;
					chatParam3.role.profession = (uint)dailyTaskRefreshRoleInfo.profession;
					list.Add(chatParam2);
					list.Add(chatParam3);
					list.Add(chatParam);
					DlgBase<XChatView, XChatBehaviour>.singleton.SendChatContent(string.Format(noticeData.info, stringList[index], itemQualityName), (ChatChannelType)noticeData.channel, true, list, true, 0UL, 0f, false, false);
				}
			}
		}

		// Token: 0x06008D35 RID: 36149 RVA: 0x00134740 File Offset: 0x00132940
		public void OnGetDailyTaskEvent(PtcM2C_DailyTaskEventNtf roPtc)
		{
			bool flag = roPtc.Data.type == DailyTaskIconType.DailyTaskIcon_AskHelp;
			if (flag)
			{
				this.DailyTaskHelpRefreshIcon = true;
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildDailyRequest, true);
			}
			else
			{
				bool flag2 = roPtc.Data.type == DailyTaskIconType.DailyTaskIcon_BeHelp;
				if (flag2)
				{
					this.DailyTaskBeenRefreshIcon = true;
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildDailyTask, true);
				}
				else
				{
					bool flag3 = roPtc.Data.type == DailyTaskIconType.DailyTaskIcon_AskHelpDispear;
					if (flag3)
					{
						this.DailyTaskHelpRefreshIcon = false;
						DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildDailyRequest, true);
					}
				}
			}
		}

		// Token: 0x06008D36 RID: 36150 RVA: 0x001347DC File Offset: 0x001329DC
		public DailyTaskRefreshRoleInfo GetTaskAskInfoByIndex(int index)
		{
			bool flag = index < this._askInfoList.Count;
			DailyTaskRefreshRoleInfo result;
			if (flag)
			{
				result = this._askInfoList[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06008D37 RID: 36151 RVA: 0x00134810 File Offset: 0x00132A10
		public DailyTaskRefreshRoleInfo GetRefreshTaskItemInfo(int index)
		{
			bool flag = index < this._dailyTaskRefreshRoleInfoList.Count;
			DailyTaskRefreshRoleInfo result;
			if (flag)
			{
				result = this._dailyTaskRefreshRoleInfoList[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06008D38 RID: 36152 RVA: 0x00134844 File Offset: 0x00132A44
		public DailyTaskRefreshInfo GetRefreshTaskLogInfo(int index)
		{
			bool flag = index < this._dailyTaskRefreshRecordList.Count;
			DailyTaskRefreshInfo result;
			if (flag)
			{
				result = this._dailyTaskRefreshRecordList[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06008D39 RID: 36153 RVA: 0x00134878 File Offset: 0x00132A78
		public DailyTaskRefreshInfo GetRefreshTaskLogInfoByRoleID(ulong roleID)
		{
			for (int i = 0; i < this._dailyTaskRefreshRecordList.Count; i++)
			{
				bool flag = this._dailyTaskRefreshRecordList[i].roleid == roleID;
				if (flag)
				{
					return this._dailyTaskRefreshRecordList[i];
				}
			}
			return null;
		}

		// Token: 0x06008D3A RID: 36154 RVA: 0x001348D0 File Offset: 0x00132AD0
		public void SendGuildDonateReq(uint number, uint itemID, uint reqID, NoticeType type = NoticeType.NT_GUILD_Daily_DONATE_REQ)
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool flag = !specificDocument.CheckInGuild();
			if (!flag)
			{
				XInvitationDocument specificDocument2 = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
				NoticeTable.RowData noticeData = specificDocument2.GetNoticeData(type);
				bool flag2 = noticeData == null;
				if (!flag2)
				{
					List<ChatParam> list = new List<ChatParam>();
					ChatParam chatParam = new ChatParam();
					chatParam.link = new ChatParamLink();
					chatParam.link.id = noticeData.linkparam;
					chatParam.link.param.Add((ulong)reqID);
					chatParam.link.content = noticeData.linkcontent;
					ChatParam chatParam2 = new ChatParam();
					chatParam2.role = new ChatParamRole();
					chatParam2.role.uniqueid = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					chatParam2.role.name = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
					chatParam2.role.profession = XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID;
					ChatParam chatParam3 = new ChatParam();
					chatParam3.item = new ChatParamItem();
					chatParam3.item.item = new ItemBrief();
					chatParam3.item.item.itemCount = number;
					chatParam3.item.item.itemID = itemID;
					list.Add(chatParam2);
					list.Add(chatParam3);
					list.Add(chatParam);
					DlgBase<XChatView, XChatBehaviour>.singleton.SendChatContent(noticeData.info, (ChatChannelType)noticeData.channel, true, list, true, 0UL, 0f, false, false);
				}
			}
		}

		// Token: 0x06008D3B RID: 36155 RVA: 0x00134A68 File Offset: 0x00132C68
		public void InitFromServerData(RoleTask roleTask)
		{
			bool flag = roleTask.dailytask.Count == 0;
			if (flag)
			{
				XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_GuildDailyTask, false);
			}
			else
			{
				XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_GuildDailyTask, roleTask.daily_red_point);
			}
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildDailyTask, true);
			XGuildDonateDocument.Doc.DailyDonatedNum = roleTask.today_donate_count;
		}

		// Token: 0x06008D3C RID: 36156 RVA: 0x00134AD8 File Offset: 0x00132CD8
		public void ClearRequesetItems()
		{
			this._askInfoList.Clear();
			bool flag = DlgBase<XGuildDailyHandleRefreshDlg, XGuildDailyHandleRefreshBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildDailyHandleRefreshDlg, XGuildDailyHandleRefreshBehavior>.singleton.RefreshContent();
			}
			this.RefreshRequestSysIcon();
		}

		// Token: 0x06008D3D RID: 36157 RVA: 0x00134B14 File Offset: 0x00132D14
		public void OnTaskRefreshNtf(PtcM2C_TaskRefreshNtf roPtc)
		{
			this._curScore = roPtc.Data.score;
			this._refresh_num = roPtc.Data.remain_refresh_count;
			bool flag = DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.IsVisible();
			if (flag)
			{
				this.SendGetDailyTaskInfo();
			}
			bool flag2 = DlgBase<XGuildDailyRefreshTaskDlg, XGuildDailyRefreshTaskBehavior>.singleton.IsVisible();
			if (flag2)
			{
				bool flag3 = this._dailyTaskRefreshRoleInfoList.Count > 0 && this._dailyTaskRefreshRoleInfoList[0].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag3)
				{
					this._dailyTaskRefreshRoleInfoList[0].refresh_num = this._refresh_num;
					this._dailyTaskRefreshRoleInfoList[0].already_ask = (this._dailyTaskRefreshRoleInfoList[0].refresh_num <= 0U);
				}
				DlgBase<XGuildDailyRefreshTaskDlg, XGuildDailyRefreshTaskBehavior>.singleton.RefreshContent();
			}
		}

		// Token: 0x06008D3E RID: 36158 RVA: 0x00134BF4 File Offset: 0x00132DF4
		private void RefreshRequestSysIcon()
		{
			bool flag = this._askInfoList.Count == 0;
			if (flag)
			{
				this.DailyTaskHelpRefreshIcon = false;
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildDailyRequest, true);
			}
		}

		// Token: 0x04002DAC RID: 11692
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildDailyTaskDocument");

		// Token: 0x04002DAD RID: 11693
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002DAE RID: 11694
		private static DailyTask _dailyTaskInfoTable = new DailyTask();

		// Token: 0x04002DAF RID: 11695
		public static DailyTaskReward DailyTaskRewardTable = new DailyTaskReward();

		// Token: 0x04002DB0 RID: 11696
		private Dictionary<uint, DailyTaskReward.RowData> _guildTaskRewardWithMap = new Dictionary<uint, DailyTaskReward.RowData>();

		// Token: 0x04002DB1 RID: 11697
		private List<GuildDailyTaskInfo> _curGuildDailyTaskList = new List<GuildDailyTaskInfo>();

		// Token: 0x04002DB2 RID: 11698
		private uint _taskRoleLevel = 1U;

		// Token: 0x04002DB3 RID: 11699
		private uint _askedNum = 0U;

		// Token: 0x04002DB4 RID: 11700
		private uint _count = 0U;

		// Token: 0x04002DB5 RID: 11701
		private bool _isRewarded = false;

		// Token: 0x04002DB6 RID: 11702
		private List<DailyTaskRefreshRoleInfo> _dailyTaskRefreshRoleInfoList = new List<DailyTaskRefreshRoleInfo>();

		// Token: 0x04002DB7 RID: 11703
		private uint _myLuck = 1U;

		// Token: 0x04002DB8 RID: 11704
		private uint _refresh_num;

		// Token: 0x04002DB9 RID: 11705
		private uint _todayBuyNum;

		// Token: 0x04002DBA RID: 11706
		private List<DailyTaskRefreshRoleInfo> _askInfoList = new List<DailyTaskRefreshRoleInfo>();

		// Token: 0x04002DBB RID: 11707
		private uint _helpNum;

		// Token: 0x04002DBC RID: 11708
		private List<DailyTaskRefreshInfo> _dailyTaskRefreshRecordList = new List<DailyTaskRefreshInfo>();

		// Token: 0x04002DBD RID: 11709
		private uint _curScore;
	}
}
