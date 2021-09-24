using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildWeeklyBountyDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildWeeklyBountyDocument.uuID;
			}
		}

		public static XGuildWeeklyBountyDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XGuildWeeklyBountyDocument.uuID) as XGuildWeeklyBountyDocument;
			}
		}

		public List<GuildWeeklyTaskInfo> CurGuildWeeklyTaskList
		{
			get
			{
				return this._curGuildWeeklyTaskList;
			}
		}

		public List<uint> RewardedBoxList
		{
			get
			{
				return this._rewardedBoxList;
			}
		}

		public uint WeeklyScore
		{
			get
			{
				return this._weeklyScore;
			}
		}

		public uint WeeklyAskedHelpNum
		{
			get
			{
				return this._weeklyAskedHelpNum;
			}
		}

		public List<uint> ChestValueList
		{
			get
			{
				return this._chestValueList;
			}
		}

		public List<TaskHelpInfo> TaskHelpInfoList
		{
			get
			{
				return this._taskHelpInfoList;
			}
		}

		public double ActivityLeftTime
		{
			get
			{
				return this._activityLeftTime;
			}
			set
			{
				this._activityLeftTime = value;
			}
		}

		public uint RemainedFreshTimes
		{
			get
			{
				return this._remainedFreshTimes;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildWeeklyBountyDocument.AsyncLoader.Execute(callback);
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
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		public void SendGetWeeklyTaskInfo()
		{
			RpcC2G_GetWeeklyTaskInfo rpc = new RpcC2G_GetWeeklyTaskInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetWeeklyTaskInfo(GetWeeklyTaskInfoRes oRes)
		{
			this._weeklyScore = oRes.score;
			this._weeklyAskedHelpNum = oRes.askhelp_num;
			this._rewardedBoxList = oRes.rewarded_box;
			this._taskHelpInfoList = oRes.helpinfo;
			this._taskRoleLevel = oRes.accept_level;
			this._activityLeftTime = oRes.lefttime;
			this._remainedFreshTimes = oRes.remain_free_refresh_count;
			this.UpdateTaskContent(oRes.task);
			this.ResetRewardsMap();
			bool flag = DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.RefreshUI();
			}
		}

		public bool HasFinishWeeklyTasks()
		{
			return this.IsAllBoxsReward() && this.IsAllTaskFinished();
		}

		public void SendToGetWeeklyTaskReward(uint type, uint value)
		{
			RpcC2G_GetWeeklyTaskReward rpcC2G_GetWeeklyTaskReward = new RpcC2G_GetWeeklyTaskReward();
			rpcC2G_GetWeeklyTaskReward.oArg.type = type;
			rpcC2G_GetWeeklyTaskReward.oArg.value = value;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetWeeklyTaskReward);
		}

		public void OnGetWeeklyTaskReward(GetWeeklyTaskRewardArg oArg, GetWeeklyTaskRewardRes oRes)
		{
			bool flag = oArg.type == 1U && (ulong)oArg.value < (ulong)((long)this._curGuildWeeklyTaskList.Count);
			if (flag)
			{
				this._weeklyScore = oRes.score;
				for (int i = 0; i < this._curGuildWeeklyTaskList.Count; i++)
				{
					GuildWeeklyTaskInfo guildWeeklyTaskInfo = this._curGuildWeeklyTaskList[i];
					bool flag2 = guildWeeklyTaskInfo.originIndex == oArg.value;
					if (flag2)
					{
						guildWeeklyTaskInfo.isRewarded = true;
						break;
					}
				}
				bool flag3 = DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.IsVisible();
				if (flag3)
				{
					DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.RefreshTaskList(false);
					DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.RefreshChestList();
					DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.PlayCompleteEffect();
				}
			}
			else
			{
				bool flag4 = oArg.type == 2U;
				if (flag4)
				{
					bool flag5 = !this._rewardedBoxList.Contains(oArg.value);
					if (flag5)
					{
						this._rewardedBoxList.Add(oArg.value);
					}
					bool flag6 = DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.IsVisible();
					if (flag6)
					{
						DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.RefreshChestList();
					}
				}
			}
		}

		private bool IsAllBoxsReward()
		{
			List<uint> chestValueList = XGuildWeeklyBountyDocument.Doc.ChestValueList;
			for (int i = 0; i < chestValueList.Count; i++)
			{
				bool flag = !this.RewardedBoxList.Contains(chestValueList[i]);
				if (flag)
				{
					return false;
				}
			}
			return true;
		}

		private bool IsAllTaskFinished()
		{
			for (int i = 0; i < this._curGuildWeeklyTaskList.Count; i++)
			{
				bool flag = !this._curGuildWeeklyTaskList[i].isRewarded;
				if (flag)
				{
					return false;
				}
			}
			return true;
		}

		private void UpdateTaskContent(List<WeeklyTaskInfo> task)
		{
			this.CurGuildWeeklyTaskList.Clear();
			for (int i = 0; i < task.Count; i++)
			{
				WeeklyTaskInfo weeklyTaskInfo = task[i];
				this.CurGuildWeeklyTaskList.Add(new GuildWeeklyTaskInfo
				{
					taskID = weeklyTaskInfo.id,
					step = weeklyTaskInfo.step,
					isRewarded = weeklyTaskInfo.is_rewarded,
					hasAsked = weeklyTaskInfo.ask_help,
					refreshedCount = weeklyTaskInfo.refresh_count,
					originIndex = weeklyTaskInfo.index,
					category = WeeklyTaskCategory.None
				});
			}
			this._curGuildWeeklyTaskList.Sort(new Comparison<GuildWeeklyTaskInfo>(this.SortWeeklyTaskList));
		}

		private int SortWeeklyTaskList(GuildWeeklyTaskInfo x, GuildWeeklyTaskInfo y)
		{
			DailyTask.RowData dailyTaskTableInfoByID = XGuildDailyTaskDocument.Doc.GetDailyTaskTableInfoByID(x.taskID);
			DailyTask.RowData dailyTaskTableInfoByID2 = XGuildDailyTaskDocument.Doc.GetDailyTaskTableInfoByID(y.taskID);
			bool flag = dailyTaskTableInfoByID != null && dailyTaskTableInfoByID2 != null;
			if (flag)
			{
				bool flag2 = x.isRewarded ^ y.isRewarded;
				if (flag2)
				{
					bool isRewarded = x.isRewarded;
					if (isRewarded)
					{
						return 1;
					}
					bool isRewarded2 = y.isRewarded;
					if (isRewarded2)
					{
						return -1;
					}
				}
				else
				{
					bool flag3 = !x.isRewarded && x.step >= dailyTaskTableInfoByID.conditionNum;
					bool flag4 = !y.isRewarded && y.step >= dailyTaskTableInfoByID2.conditionNum;
					bool flag5 = flag3 ^ flag4;
					if (flag5)
					{
						bool flag6 = flag3;
						if (flag6)
						{
							return -1;
						}
						bool flag7 = flag4;
						if (flag7)
						{
							return 1;
						}
					}
					else
					{
						bool flag8 = dailyTaskTableInfoByID.taskquality != dailyTaskTableInfoByID2.taskquality;
						if (flag8)
						{
							return (int)(dailyTaskTableInfoByID2.taskquality - dailyTaskTableInfoByID.taskquality);
						}
					}
				}
			}
			return (int)(x.taskID - y.taskID);
		}

		private void ResetRewardsMap()
		{
			this._guildTaskRewardWithMap.Clear();
			this._chestValueList.Clear();
			for (int i = 0; i < XGuildDailyTaskDocument.DailyTaskRewardTable.Table.Length; i++)
			{
				DailyTaskReward.RowData rowData = XGuildDailyTaskDocument.DailyTaskRewardTable.Table[i];
				uint num = rowData.level[0];
				uint num2 = rowData.level[1];
				bool flag = this._taskRoleLevel >= num && this._taskRoleLevel <= num2;
				if (flag)
				{
					uint mappingValueWithQualityAndType = XGuildDailyTaskDocument.GetMappingValueWithQualityAndType((GuildTaskType)rowData.category, rowData.tasktype, rowData.taskquality);
					bool flag2 = rowData.category == 2U && !this._guildTaskRewardWithMap.ContainsKey(mappingValueWithQualityAndType);
					if (flag2)
					{
						this._guildTaskRewardWithMap.Add(mappingValueWithQualityAndType, new List<GuildTaskReward>());
						for (int j = 0; j < rowData.taskreward.Count; j++)
						{
							this._guildTaskRewardWithMap[mappingValueWithQualityAndType].Add(new GuildTaskReward
							{
								itemID = rowData.taskreward[j, 0],
								count = rowData.taskreward[j, 1]
							});
						}
					}
					bool flag3 = rowData.category == 2U && rowData.tasktype == 2U;
					if (flag3)
					{
						bool flag4 = !this._chestValueList.Contains(rowData.taskquality);
						if (flag4)
						{
							this._chestValueList.Add(rowData.taskquality);
						}
					}
				}
			}
			this._chestValueList.Sort();
		}

		public List<GuildTaskReward> GetSingleTaskRewardInfoByID(GuildTaskType type, uint taskID)
		{
			DailyTask.RowData dailyTaskTableInfoByID = XGuildDailyTaskDocument.Doc.GetDailyTaskTableInfoByID(taskID);
			bool flag = dailyTaskTableInfoByID != null;
			if (flag)
			{
				uint mappingValueWithQualityAndType = XGuildDailyTaskDocument.GetMappingValueWithQualityAndType(type, 1U, dailyTaskTableInfoByID.taskquality);
				List<GuildTaskReward> result = new List<GuildTaskReward>();
				bool flag2 = this._guildTaskRewardWithMap.TryGetValue(mappingValueWithQualityAndType, out result);
				if (flag2)
				{
					return result;
				}
			}
			return new List<GuildTaskReward>();
		}

		public List<GuildTaskReward> GetTotalTaskRewardInfo(GuildTaskType type, uint count)
		{
			uint mappingValueWithQualityAndType = XGuildDailyTaskDocument.GetMappingValueWithQualityAndType(type, 2U, count);
			List<GuildTaskReward> list = new List<GuildTaskReward>();
			bool flag = this._guildTaskRewardWithMap.TryGetValue(mappingValueWithQualityAndType, out list);
			List<GuildTaskReward> result;
			if (flag)
			{
				result = list;
			}
			else
			{
				result = new List<GuildTaskReward>();
			}
			return result;
		}

		public void SendCommitWeeklyItem(uint index, List<ulong> items)
		{
			RpcC2G_TurnOverWeeklyTaskItem rpcC2G_TurnOverWeeklyTaskItem = new RpcC2G_TurnOverWeeklyTaskItem();
			rpcC2G_TurnOverWeeklyTaskItem.oArg.index = index;
			rpcC2G_TurnOverWeeklyTaskItem.oArg.itemuid.Clear();
			rpcC2G_TurnOverWeeklyTaskItem.oArg.itemuid.AddRange(items);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TurnOverWeeklyTaskItem);
		}

		public void OnTurnOverWeeklyTaskReply(TurnOverWeeklyTaskItemArg oArg, TurnOverWeeklyTaskItemRes oRes)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("weeklyCommitSuccess"), "fece00");
			bool flag = (ulong)oArg.index < (ulong)((long)this._curGuildWeeklyTaskList.Count);
			if (flag)
			{
				for (int i = 0; i < this._curGuildWeeklyTaskList.Count; i++)
				{
					bool flag2 = oArg.index == this._curGuildWeeklyTaskList[i].originIndex;
					if (flag2)
					{
						GuildWeeklyTaskInfo guildWeeklyTaskInfo = this._curGuildWeeklyTaskList[i];
						guildWeeklyTaskInfo.step += (uint)oArg.itemuid.Count;
						bool flag3 = DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.IsVisible();
						if (flag3)
						{
							DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.RefreshTaskList(false);
						}
						break;
					}
				}
			}
		}

		public void SendToRefreshTaskList(uint taskIndex)
		{
			RpcC2G_RefreshWeeklyTask rpcC2G_RefreshWeeklyTask = new RpcC2G_RefreshWeeklyTask();
			rpcC2G_RefreshWeeklyTask.oArg.index = taskIndex;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_RefreshWeeklyTask);
		}

		internal void OnRefreshTaskList(RefreshWeeklyTaskArg oArg, RefreshWeeklyTaskRes oRes)
		{
			bool flag = this._remainedFreshTimes > 0U;
			if (flag)
			{
				this._remainedFreshTimes -= 1U;
			}
			for (int i = 0; i < this._curGuildWeeklyTaskList.Count; i++)
			{
				bool flag2 = this._curGuildWeeklyTaskList[i].originIndex == oArg.index;
				if (flag2)
				{
					WeeklyTaskInfo task = oRes.task;
					this.CurGuildWeeklyTaskList[i] = new GuildWeeklyTaskInfo
					{
						taskID = task.id,
						step = task.step,
						isRewarded = task.is_rewarded,
						hasAsked = task.ask_help,
						refreshedCount = task.refresh_count,
						originIndex = task.index
					};
					break;
				}
			}
			bool flag3 = DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.IsVisible();
			if (flag3)
			{
				DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.RefreshTaskList(false);
				DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.PlayRefreshEffect();
			}
		}

		public int GetTaskOriginalIndexByID(uint curSelectTaskID)
		{
			for (int i = 0; i < this._curGuildWeeklyTaskList.Count; i++)
			{
				bool flag = this._curGuildWeeklyTaskList[i].taskID == curSelectTaskID;
				if (flag)
				{
					return (int)this._curGuildWeeklyTaskList[i].originIndex;
				}
			}
			return -1;
		}

		public GuildWeeklyTaskInfo GetTaskInfoByTaskID(uint curSelectTaskID)
		{
			for (int i = 0; i < this._curGuildWeeklyTaskList.Count; i++)
			{
				bool flag = this._curGuildWeeklyTaskList[i].taskID == curSelectTaskID;
				if (flag)
				{
					return this._curGuildWeeklyTaskList[i];
				}
			}
			return null;
		}

		public GuildWeeklyTaskInfo GetTaskInfoByIndex(uint curSelectIndex)
		{
			for (int i = 0; i < this._curGuildWeeklyTaskList.Count; i++)
			{
				bool flag = this._curGuildWeeklyTaskList[i].originIndex == curSelectIndex;
				if (flag)
				{
					return this._curGuildWeeklyTaskList[i];
				}
			}
			return null;
		}

		public int GetRewardedTaskCount()
		{
			int num = 0;
			for (int i = 0; i < this._curGuildWeeklyTaskList.Count; i++)
			{
				bool isRewarded = this._curGuildWeeklyTaskList[i].isRewarded;
				if (isRewarded)
				{
					num++;
				}
			}
			return num;
		}

		public void OnGetWeeklyHelpReply(DailyTaskAskHelpArg oArg, DailyTaskAskHelpRes oRes)
		{
			bool flag = oRes.code == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				DailyTask.RowData dailyTaskTableInfoByID = XGuildDailyTaskDocument.Doc.GetDailyTaskTableInfoByID(oArg.task_id);
				GuildWeeklyTaskInfo taskInfoByTaskID = this.GetTaskInfoByTaskID(oArg.task_id);
				bool flag2 = taskInfoByTaskID != null && dailyTaskTableInfoByID != null;
				if (flag2)
				{
					bool flag3 = dailyTaskTableInfoByID.tasktype == 4U;
					if (flag3)
					{
						XGuildDailyTaskDocument.Doc.SendGuildDonateReq(dailyTaskTableInfoByID.conditionNum - taskInfoByTaskID.step, dailyTaskTableInfoByID.BQ[0, 0], oRes.ask_uid, NoticeType.NT_GUILD_Weekly_DONATE_REQ);
					}
					else
					{
						XGuildDailyTaskDocument.Doc.SendGuildDonateReq(dailyTaskTableInfoByID.conditionNum - taskInfoByTaskID.step, dailyTaskTableInfoByID.conditionId[0], oRes.ask_uid, NoticeType.NT_GUILD_Weekly_DONATE_REQ);
					}
					taskInfoByTaskID.hasAsked = true;
					this._weeklyAskedHelpNum += 1U;
					bool flag4 = DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.IsVisible();
					if (flag4)
					{
						DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.RefreshTaskItem();
					}
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.code, "fece00");
			}
		}

		public bool GoToTakeTask()
		{
			XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
			XTaskRecord taskRecord = specificDocument.TaskRecord;
			for (int i = 0; i < taskRecord.Tasks.Count; i++)
			{
				bool flag = taskRecord.Tasks[i].Status == TaskStatus.TaskStatus_CanTake && taskRecord.Tasks[i].TableData.TaskType == 7U;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildWeeklyBountyDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private uint _weeklyScore;

		private uint _weeklyAskedHelpNum;

		private uint _taskRoleLevel = 0U;

		private List<uint> _rewardedBoxList = new List<uint>();

		private List<GuildWeeklyTaskInfo> _curGuildWeeklyTaskList = new List<GuildWeeklyTaskInfo>();

		private Dictionary<uint, List<GuildTaskReward>> _guildTaskRewardWithMap = new Dictionary<uint, List<GuildTaskReward>>();

		private List<uint> _chestValueList = new List<uint>();

		private List<TaskHelpInfo> _taskHelpInfoList = new List<TaskHelpInfo>();

		private double _activityLeftTime = 0.0;

		private uint _remainedFreshTimes = 0U;
	}
}
