using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildDailyTaskDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildDailyTaskDocument.uuID;
			}
		}

		public static XGuildDailyTaskDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XGuildDailyTaskDocument.uuID) as XGuildDailyTaskDocument;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildDailyTaskDocument.AsyncLoader.AddTask("Table/DailyTask", XGuildDailyTaskDocument._dailyTaskInfoTable, false);
			XGuildDailyTaskDocument.AsyncLoader.AddTask("Table/DailyTaskReward", XGuildDailyTaskDocument.DailyTaskRewardTable, false);
			XGuildDailyTaskDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.DailyTaskHelpRefreshIcon = false;
			this.DailyTaskBeenRefreshIcon = false;
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_TaskStateChange, new XComponent.XEventHandler(this.OnTaskStateChanged));
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.InitFromServerData(arg.PlayerInfo.task_record);
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

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

		public List<DailyTaskRefreshRoleInfo> DailyTaskRefreshRoleInfoList
		{
			get
			{
				return this._dailyTaskRefreshRoleInfoList;
			}
		}

		public List<DailyTaskRefreshRoleInfo> AskInfoList
		{
			get
			{
				return this._askInfoList;
			}
		}

		public List<DailyTaskRefreshInfo> DailyTaskRefreshRecordList
		{
			get
			{
				return this._dailyTaskRefreshRecordList;
			}
		}

		public uint Refresh_num
		{
			get
			{
				return this._refresh_num;
			}
		}

		public uint CurScore
		{
			get
			{
				return this._curScore;
			}
		}

		public uint TodayBuyNumber
		{
			get
			{
				return this._todayBuyNum;
			}
		}

		public uint HelpNum
		{
			get
			{
				return this._helpNum;
			}
		}

		public uint MyLuck
		{
			get
			{
				return this._myLuck;
			}
		}

		public bool DailyTaskHelpRefreshIcon { get; set; }

		public bool DailyTaskBeenRefreshIcon { get; set; }

		public void SendGetDailyTaskInfo()
		{
			RpcC2G_GetDailyTaskInfo rpc = new RpcC2G_GetDailyTaskInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void GiveUpTask()
		{
			RpcC2G_DailyTaskGiveUp rpc = new RpcC2G_DailyTaskGiveUp();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public int GetTaskItemCount()
		{
			return this._curGuildDailyTaskList.Count;
		}

		public void SendToGetMyTaskReward(uint type, uint id)
		{
			RpcC2G_GetDailyTaskReward rpcC2G_GetDailyTaskReward = new RpcC2G_GetDailyTaskReward();
			rpcC2G_GetDailyTaskReward.oArg.type = type;
			rpcC2G_GetDailyTaskReward.oArg.id = id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetDailyTaskReward);
		}

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

		public static uint GetMappingValueWithQualityAndType(GuildTaskType category, uint type, uint quality)
		{
			return (uint)((int)(GuildTaskType)10000 * (int)category + (int)(1000U * type) + (int)quality);
		}

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

		public void SendDailyTaskAskHelp(PeriodTaskType type, uint taskID)
		{
			RpcC2G_DailyTaskAskHelp rpcC2G_DailyTaskAskHelp = new RpcC2G_DailyTaskAskHelp();
			rpcC2G_DailyTaskAskHelp.oArg.task_id = taskID;
			rpcC2G_DailyTaskAskHelp.oArg.task_type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_DailyTaskAskHelp);
		}

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

		public void SendToRefreshTasks()
		{
			RpcC2M_GetDailyTaskRefreshInfo rpc = new RpcC2M_GetDailyTaskRefreshInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void SendToGetAskRefreshTaskInfo()
		{
			RpcC2M_GetDailyTaskAskHelp rpc = new RpcC2M_GetDailyTaskAskHelp();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void SendToGetRefreshLogInfo()
		{
			RpcC2M_GetDailyTaskRefreshRecord rpc = new RpcC2M_GetDailyTaskRefreshRecord();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void SendToRefreshTaskOp(DailyRefreshOperType type, ulong roleID)
		{
			RpcC2M_DailyTaskRefreshOper rpcC2M_DailyTaskRefreshOper = new RpcC2M_DailyTaskRefreshOper();
			rpcC2M_DailyTaskRefreshOper.oArg.type = type;
			rpcC2M_DailyTaskRefreshOper.oArg.roleid = roleID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_DailyTaskRefreshOper);
		}

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

		private void RefreshRequestSysIcon()
		{
			bool flag = this._askInfoList.Count == 0;
			if (flag)
			{
				this.DailyTaskHelpRefreshIcon = false;
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildDailyRequest, true);
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildDailyTaskDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static DailyTask _dailyTaskInfoTable = new DailyTask();

		public static DailyTaskReward DailyTaskRewardTable = new DailyTaskReward();

		private Dictionary<uint, DailyTaskReward.RowData> _guildTaskRewardWithMap = new Dictionary<uint, DailyTaskReward.RowData>();

		private List<GuildDailyTaskInfo> _curGuildDailyTaskList = new List<GuildDailyTaskInfo>();

		private uint _taskRoleLevel = 1U;

		private uint _askedNum = 0U;

		private uint _count = 0U;

		private bool _isRewarded = false;

		private List<DailyTaskRefreshRoleInfo> _dailyTaskRefreshRoleInfoList = new List<DailyTaskRefreshRoleInfo>();

		private uint _myLuck = 1U;

		private uint _refresh_num;

		private uint _todayBuyNum;

		private List<DailyTaskRefreshRoleInfo> _askInfoList = new List<DailyTaskRefreshRoleInfo>();

		private uint _helpNum;

		private List<DailyTaskRefreshInfo> _dailyTaskRefreshRecordList = new List<DailyTaskRefreshInfo>();

		private uint _curScore;
	}
}
