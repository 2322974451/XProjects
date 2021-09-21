using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A5E RID: 2654
	internal class XGuildWeeklyBountyDocument : XDocComponent
	{
		// Token: 0x17002F09 RID: 12041
		// (get) Token: 0x0600A0D3 RID: 41171 RVA: 0x001B00B4 File Offset: 0x001AE2B4
		public override uint ID
		{
			get
			{
				return XGuildWeeklyBountyDocument.uuID;
			}
		}

		// Token: 0x17002F0A RID: 12042
		// (get) Token: 0x0600A0D4 RID: 41172 RVA: 0x001B00CC File Offset: 0x001AE2CC
		public static XGuildWeeklyBountyDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XGuildWeeklyBountyDocument.uuID) as XGuildWeeklyBountyDocument;
			}
		}

		// Token: 0x17002F0B RID: 12043
		// (get) Token: 0x0600A0D5 RID: 41173 RVA: 0x001B00F8 File Offset: 0x001AE2F8
		public List<GuildWeeklyTaskInfo> CurGuildWeeklyTaskList
		{
			get
			{
				return this._curGuildWeeklyTaskList;
			}
		}

		// Token: 0x17002F0C RID: 12044
		// (get) Token: 0x0600A0D6 RID: 41174 RVA: 0x001B0110 File Offset: 0x001AE310
		public List<uint> RewardedBoxList
		{
			get
			{
				return this._rewardedBoxList;
			}
		}

		// Token: 0x17002F0D RID: 12045
		// (get) Token: 0x0600A0D7 RID: 41175 RVA: 0x001B0128 File Offset: 0x001AE328
		public uint WeeklyScore
		{
			get
			{
				return this._weeklyScore;
			}
		}

		// Token: 0x17002F0E RID: 12046
		// (get) Token: 0x0600A0D8 RID: 41176 RVA: 0x001B0140 File Offset: 0x001AE340
		public uint WeeklyAskedHelpNum
		{
			get
			{
				return this._weeklyAskedHelpNum;
			}
		}

		// Token: 0x17002F0F RID: 12047
		// (get) Token: 0x0600A0D9 RID: 41177 RVA: 0x001B0158 File Offset: 0x001AE358
		public List<uint> ChestValueList
		{
			get
			{
				return this._chestValueList;
			}
		}

		// Token: 0x17002F10 RID: 12048
		// (get) Token: 0x0600A0DA RID: 41178 RVA: 0x001B0170 File Offset: 0x001AE370
		public List<TaskHelpInfo> TaskHelpInfoList
		{
			get
			{
				return this._taskHelpInfoList;
			}
		}

		// Token: 0x17002F11 RID: 12049
		// (get) Token: 0x0600A0DB RID: 41179 RVA: 0x001B0188 File Offset: 0x001AE388
		// (set) Token: 0x0600A0DC RID: 41180 RVA: 0x001B01A0 File Offset: 0x001AE3A0
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

		// Token: 0x17002F12 RID: 12050
		// (get) Token: 0x0600A0DD RID: 41181 RVA: 0x001B01AC File Offset: 0x001AE3AC
		public uint RemainedFreshTimes
		{
			get
			{
				return this._remainedFreshTimes;
			}
		}

		// Token: 0x0600A0DE RID: 41182 RVA: 0x001B01C4 File Offset: 0x001AE3C4
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildWeeklyBountyDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600A0DF RID: 41183 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600A0E0 RID: 41184 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600A0E1 RID: 41185 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x0600A0E2 RID: 41186 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600A0E3 RID: 41187 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x0600A0E4 RID: 41188 RVA: 0x001B01D4 File Offset: 0x001AE3D4
		public void SendGetWeeklyTaskInfo()
		{
			RpcC2G_GetWeeklyTaskInfo rpc = new RpcC2G_GetWeeklyTaskInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A0E5 RID: 41189 RVA: 0x001B01F4 File Offset: 0x001AE3F4
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

		// Token: 0x0600A0E6 RID: 41190 RVA: 0x001B0288 File Offset: 0x001AE488
		public bool HasFinishWeeklyTasks()
		{
			return this.IsAllBoxsReward() && this.IsAllTaskFinished();
		}

		// Token: 0x0600A0E7 RID: 41191 RVA: 0x001B02AC File Offset: 0x001AE4AC
		public void SendToGetWeeklyTaskReward(uint type, uint value)
		{
			RpcC2G_GetWeeklyTaskReward rpcC2G_GetWeeklyTaskReward = new RpcC2G_GetWeeklyTaskReward();
			rpcC2G_GetWeeklyTaskReward.oArg.type = type;
			rpcC2G_GetWeeklyTaskReward.oArg.value = value;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetWeeklyTaskReward);
		}

		// Token: 0x0600A0E8 RID: 41192 RVA: 0x001B02E8 File Offset: 0x001AE4E8
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

		// Token: 0x0600A0E9 RID: 41193 RVA: 0x001B0404 File Offset: 0x001AE604
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

		// Token: 0x0600A0EA RID: 41194 RVA: 0x001B0458 File Offset: 0x001AE658
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

		// Token: 0x0600A0EB RID: 41195 RVA: 0x001B04A4 File Offset: 0x001AE6A4
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

		// Token: 0x0600A0EC RID: 41196 RVA: 0x001B0558 File Offset: 0x001AE758
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

		// Token: 0x0600A0ED RID: 41197 RVA: 0x001B0680 File Offset: 0x001AE880
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

		// Token: 0x0600A0EE RID: 41198 RVA: 0x001B081C File Offset: 0x001AEA1C
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

		// Token: 0x0600A0EF RID: 41199 RVA: 0x001B087C File Offset: 0x001AEA7C
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

		// Token: 0x0600A0F0 RID: 41200 RVA: 0x001B08BC File Offset: 0x001AEABC
		public void SendCommitWeeklyItem(uint index, List<ulong> items)
		{
			RpcC2G_TurnOverWeeklyTaskItem rpcC2G_TurnOverWeeklyTaskItem = new RpcC2G_TurnOverWeeklyTaskItem();
			rpcC2G_TurnOverWeeklyTaskItem.oArg.index = index;
			rpcC2G_TurnOverWeeklyTaskItem.oArg.itemuid.Clear();
			rpcC2G_TurnOverWeeklyTaskItem.oArg.itemuid.AddRange(items);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TurnOverWeeklyTaskItem);
		}

		// Token: 0x0600A0F1 RID: 41201 RVA: 0x001B090C File Offset: 0x001AEB0C
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

		// Token: 0x0600A0F2 RID: 41202 RVA: 0x001B09D4 File Offset: 0x001AEBD4
		public void SendToRefreshTaskList(uint taskIndex)
		{
			RpcC2G_RefreshWeeklyTask rpcC2G_RefreshWeeklyTask = new RpcC2G_RefreshWeeklyTask();
			rpcC2G_RefreshWeeklyTask.oArg.index = taskIndex;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_RefreshWeeklyTask);
		}

		// Token: 0x0600A0F3 RID: 41203 RVA: 0x001B0A04 File Offset: 0x001AEC04
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

		// Token: 0x0600A0F4 RID: 41204 RVA: 0x001B0AFC File Offset: 0x001AECFC
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

		// Token: 0x0600A0F5 RID: 41205 RVA: 0x001B0B58 File Offset: 0x001AED58
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

		// Token: 0x0600A0F6 RID: 41206 RVA: 0x001B0BB0 File Offset: 0x001AEDB0
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

		// Token: 0x0600A0F7 RID: 41207 RVA: 0x001B0C08 File Offset: 0x001AEE08
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

		// Token: 0x0600A0F8 RID: 41208 RVA: 0x001B0C54 File Offset: 0x001AEE54
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

		// Token: 0x0600A0F9 RID: 41209 RVA: 0x001B0D60 File Offset: 0x001AEF60
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

		// Token: 0x040039DC RID: 14812
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildWeeklyBountyDocument");

		// Token: 0x040039DD RID: 14813
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040039DE RID: 14814
		private uint _weeklyScore;

		// Token: 0x040039DF RID: 14815
		private uint _weeklyAskedHelpNum;

		// Token: 0x040039E0 RID: 14816
		private uint _taskRoleLevel = 0U;

		// Token: 0x040039E1 RID: 14817
		private List<uint> _rewardedBoxList = new List<uint>();

		// Token: 0x040039E2 RID: 14818
		private List<GuildWeeklyTaskInfo> _curGuildWeeklyTaskList = new List<GuildWeeklyTaskInfo>();

		// Token: 0x040039E3 RID: 14819
		private Dictionary<uint, List<GuildTaskReward>> _guildTaskRewardWithMap = new Dictionary<uint, List<GuildTaskReward>>();

		// Token: 0x040039E4 RID: 14820
		private List<uint> _chestValueList = new List<uint>();

		// Token: 0x040039E5 RID: 14821
		private List<TaskHelpInfo> _taskHelpInfoList = new List<TaskHelpInfo>();

		// Token: 0x040039E6 RID: 14822
		private double _activityLeftTime = 0.0;

		// Token: 0x040039E7 RID: 14823
		private uint _remainedFreshTimes = 0U;
	}
}
