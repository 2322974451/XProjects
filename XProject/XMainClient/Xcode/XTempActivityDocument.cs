using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTempActivityDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XTempActivityDocument.uuID;
			}
		}

		public static XTempActivityDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XTempActivityDocument.uuID) as XTempActivityDocument;
			}
		}

		public static SuperActivity SuperActivityTable
		{
			get
			{
				return XTempActivityDocument._superActivityTable;
			}
		}

		public static SuperActivityTime SuperActivityTimeTable
		{
			get
			{
				return XTempActivityDocument._superActivityTimeTable;
			}
		}

		public static SuperActivityTask SuperActivityTaskTable
		{
			get
			{
				return XTempActivityDocument._superActivityTaskTable;
			}
		}

		public SpActivity ActivityRecord
		{
			get
			{
				return this._spactivityRecord;
			}
			set
			{
				this._spactivityRecord = value;
				XBackFlowDocument.Doc.InitBackflowData();
			}
		}

		public List<SuperActivityTask.RowData> GetFatherTask(List<SuperActivityTask.RowData> data)
		{
			List<SuperActivityTask.RowData> list = new List<SuperActivityTask.RowData>();
			for (int i = 0; i < data.Count; i++)
			{
				bool flag = data[i].tasktype == 1U;
				if (flag)
				{
					list.Add(data[i]);
				}
			}
			return list;
		}

		public List<SuperActivityTask.RowData> GetSonTask(List<SuperActivityTask.RowData> data, SuperActivityTask.RowData fatherTask)
		{
			uint taskid = fatherTask.taskid;
			List<SuperActivityTask.RowData> list = new List<SuperActivityTask.RowData>();
			for (int i = 0; i < data.Count; i++)
			{
				bool flag = data[i].taskfather == taskid;
				if (flag)
				{
					list.Add(data[i]);
				}
			}
			return list;
		}

		public List<SuperActivityTask.RowData> GetDataByActivityType(uint aType)
		{
			List<SuperActivityTask.RowData> list = new List<SuperActivityTask.RowData>();
			for (int i = 0; i < XTempActivityDocument._superActivityTaskTable.Table.Length; i++)
			{
				bool flag = XTempActivityDocument._superActivityTaskTable.Table[i].actid == aType;
				if (flag)
				{
					list.Add(XTempActivityDocument._superActivityTaskTable.Table[i]);
				}
			}
			return list;
		}

		public SuperActivityTask.RowData GetDataByActivityByTypeID(uint aType, uint taskid)
		{
			for (int i = 0; i < XTempActivityDocument._superActivityTaskTable.Table.Length; i++)
			{
				SuperActivityTask.RowData rowData = XTempActivityDocument._superActivityTaskTable.Table[i];
				bool flag = rowData.actid == aType && rowData.taskid == taskid;
				if (flag)
				{
					return rowData;
				}
			}
			return null;
		}

		public SuperActivityTime.RowData GetDataByActivityID(uint actID)
		{
			for (int i = 0; i < XTempActivityDocument._superActivityTimeTable.Table.Length; i++)
			{
				SuperActivityTime.RowData rowData = XTempActivityDocument._superActivityTimeTable.Table[i];
				bool flag = rowData.actid == actID;
				if (flag)
				{
					return rowData;
				}
			}
			return null;
		}

		public SuperActivityTime.RowData GetDataBySystemID(uint systemid)
		{
			for (int i = 0; i < XTempActivityDocument._superActivityTimeTable.Table.Length; i++)
			{
				SuperActivityTime.RowData rowData = XTempActivityDocument._superActivityTimeTable.Table[i];
				bool flag = rowData.systemid == systemid;
				if (flag)
				{
					return rowData;
				}
			}
			return null;
		}

		public DateTime GetEndTime(uint actID)
		{
			return this.GetEndTime(this.GetDataByActivityID(actID), -1);
		}

		public DateTime GetEndTime(SuperActivityTime.RowData data, int stage = -1)
		{
			bool flag = data == null;
			DateTime result;
			if (flag)
			{
				result = default(DateTime);
			}
			else
			{
				DateTime dateTime = new DateTime((int)(data.starttime / 10000U), (int)(data.starttime / 100U % 100U), (int)(data.starttime % 100U));
				dateTime = dateTime.AddHours(data.starthour);
				bool flag2 = stage == -1;
				if (flag2)
				{
					stage = data.timestage.Count;
				}
				for (int i = 0; i < stage; i++)
				{
					dateTime = dateTime.AddHours(data.timestage[i, 0]);
				}
				result = dateTime;
			}
			return result;
		}

		public uint[] GetTaskListWithLevel(int level)
		{
			for (int i = 0; i < XTempActivityDocument._openServerActivity.Table.Length; i++)
			{
				bool flag = (ulong)XTempActivityDocument._openServerActivity.Table[i].ServerLevel == (ulong)((long)level);
				if (flag)
				{
					return XTempActivityDocument._openServerActivity.Table[i].TaskIDs;
				}
			}
			return null;
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XTempActivityDocument.AsyncLoader.AddTask("Table/SuperActivity", XTempActivityDocument._superActivityTable, false);
			XTempActivityDocument.AsyncLoader.AddTask("Table/SuperActivityTask", XTempActivityDocument._superActivityTaskTable, false);
			XTempActivityDocument.AsyncLoader.AddTask("Table/SuperActivityTime", XTempActivityDocument._superActivityTimeTable, false);
			XTempActivityDocument.AsyncLoader.AddTask("Table/OpenServerActivity", XTempActivityDocument._openServerActivity, false);
			XTempActivityDocument.AsyncLoader.Execute(callback);
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
			this.InitActivityRecordFromServerData(arg.PlayerInfo.spActivityRecord);
			WeekEndNestDocument.Doc.OfflineOpenSetTaskId();
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		public void InitActivityRecordFromServerData(SpActivity spActivityRecord)
		{
			this.ActivityRecord = spActivityRecord;
		}

		public void InitOffsetDayInfos(SpActivityOffsetDay data)
		{
			this.offsetDayInfos = data;
			bool flag = this.offsetDayInfos == null;
			if (!flag)
			{
				for (int i = 0; i < this.offsetDayInfos.actid.Count; i++)
				{
					bool flag2 = this.offsetDayInfos.actid[i] > 200U;
					if (flag2)
					{
						XOperatingActivityDocument.Doc.SealOffsetDayUpdate();
					}
					SuperActivityTime.RowData dataByActivityID = this.GetDataByActivityID(this.offsetDayInfos.actid[i]);
					bool flag3 = dataByActivityID != null;
					if (flag3)
					{
						bool flag4 = dataByActivityID.systemid == 427U;
						if (flag4)
						{
							XFlowerRankDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
							specificDocument.RecordActivityPastTime(this.offsetDayInfos.offsettime[i], dataByActivityID.timestage);
						}
						bool flag5 = dataByActivityID.systemid == 771U;
						if (flag5)
						{
							BiochemicalHellDogDocument specificDocument2 = XDocuments.GetSpecificDocument<BiochemicalHellDogDocument>(BiochemicalHellDogDocument.uuID);
							specificDocument2.RecordActivityPastTime(this.offsetDayInfos.offsettime[i], dataByActivityID.timestage);
						}
						bool flag6 = dataByActivityID.systemid == 614U;
						if (flag6)
						{
							XCampDuelDocument.Doc.RecordActivityPastTime(this.offsetDayInfos.offsettime[i], dataByActivityID.timestage);
						}
					}
				}
			}
		}

		public void UpdateOffsetDayInfos(uint actid, uint state)
		{
			bool flag = state == 0U;
			if (flag)
			{
				this.offsetDayInfos.actid.Add(actid);
				this.offsetDayInfos.offsetday.Add(0);
				bool flag2 = actid > 200U;
				if (flag2)
				{
					XOperatingActivityDocument.Doc.CurSealActID = actid;
				}
			}
			else
			{
				bool flag3 = state == 1U;
				if (flag3)
				{
					int num = this.offsetDayInfos.actid.IndexOf(actid);
					bool flag4 = num >= 0;
					if (flag4)
					{
						this.offsetDayInfos.actid.RemoveAt(num);
						this.offsetDayInfos.offsetday.RemoveAt(num);
						bool flag5 = actid > 200U;
						if (flag5)
						{
							XOperatingActivityDocument.Doc.CurSealActID = 0U;
						}
					}
				}
			}
		}

		public uint GetCrushingSealActid()
		{
			bool flag = this.offsetDayInfos == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				for (int i = 0; i < this.offsetDayInfos.actid.Count; i++)
				{
					bool flag2 = this.offsetDayInfos.actid[i] > 200U;
					if (flag2)
					{
						return this.offsetDayInfos.actid[i];
					}
				}
				result = 0U;
			}
			return result;
		}

		public SpActivityOne GetActivity(uint actid)
		{
			bool flag = this.ActivityRecord != null && this.ActivityRecord.spActivity.Count > 0;
			if (flag)
			{
				for (int i = 0; i < this.ActivityRecord.spActivity.Count; i++)
				{
					bool flag2 = this.ActivityRecord.spActivity[i].actid == actid;
					if (flag2)
					{
						return this.ActivityRecord.spActivity[i];
					}
				}
			}
			return null;
		}

		public uint GetActivityState(uint actid, uint taskid)
		{
			bool flag = this.ActivityRecord != null && this.ActivityRecord.spActivity.Count > 0;
			if (flag)
			{
				for (int i = 0; i < this.ActivityRecord.spActivity.Count; i++)
				{
					SpActivityOne spActivityOne = this.ActivityRecord.spActivity[i];
					bool flag2 = spActivityOne.actid == actid;
					if (flag2)
					{
						for (int j = 0; j < spActivityOne.task.Count; j++)
						{
							bool flag3 = spActivityOne.task[j].taskid == taskid;
							if (flag3)
							{
								return spActivityOne.task[j].state;
							}
						}
					}
				}
			}
			return 0U;
		}

		public uint GetActivityProgress(uint actid, uint taskid)
		{
			bool flag = this.ActivityRecord != null && this.ActivityRecord.spActivity.Count > 0;
			if (flag)
			{
				for (int i = 0; i < this.ActivityRecord.spActivity.Count; i++)
				{
					SpActivityOne spActivityOne = this.ActivityRecord.spActivity[i];
					bool flag2 = spActivityOne.actid == actid;
					if (flag2)
					{
						for (int j = 0; j < spActivityOne.task.Count; j++)
						{
							bool flag3 = spActivityOne.task[j].taskid == taskid;
							if (flag3)
							{
								return spActivityOne.task[j].progress;
							}
						}
					}
				}
			}
			return 0U;
		}

		public SpActivityTask GetActivityTaskInfo(uint actid, uint taskid)
		{
			bool flag = this.ActivityRecord != null && this.ActivityRecord.spActivity.Count > 0;
			if (flag)
			{
				for (int i = 0; i < this.ActivityRecord.spActivity.Count; i++)
				{
					SpActivityOne spActivityOne = this.ActivityRecord.spActivity[i];
					bool flag2 = spActivityOne.actid == actid;
					if (flag2)
					{
						for (int j = 0; j < spActivityOne.task.Count; j++)
						{
							bool flag3 = spActivityOne.task[j].taskid == taskid;
							if (flag3)
							{
								return spActivityOne.task[j];
							}
						}
					}
				}
			}
			return null;
		}

		public SpActivityTask GetActivityTaskInfoByIndex(uint actid, int index)
		{
			bool flag = this.ActivityRecord != null && this.ActivityRecord.spActivity.Count > 0;
			if (flag)
			{
				for (int i = 0; i < this.ActivityRecord.spActivity.Count; i++)
				{
					SpActivityOne spActivityOne = this.ActivityRecord.spActivity[i];
					bool flag2 = spActivityOne.actid == actid;
					if (flag2)
					{
						bool flag3 = index < spActivityOne.task.Count;
						if (flag3)
						{
							return spActivityOne.task[index];
						}
					}
				}
			}
			return null;
		}

		public void SortActivityTaskByType(uint actid)
		{
			List<SpActivityTask> activityTaskListByType = this.GetActivityTaskListByType(actid);
			bool flag = activityTaskListByType != null;
			if (flag)
			{
				activityTaskListByType.Sort(new Comparison<SpActivityTask>(this.SortActivityTask));
			}
		}

		public int GetActivityTaskCountByType(uint type)
		{
			bool flag = this.ActivityRecord != null && this.ActivityRecord.spActivity.Count > 0;
			if (flag)
			{
				for (int i = 0; i < this.ActivityRecord.spActivity.Count; i++)
				{
					SpActivityOne spActivityOne = this.ActivityRecord.spActivity[i];
					bool flag2 = spActivityOne.actid == type;
					if (flag2)
					{
						return spActivityOne.task.Count;
					}
				}
			}
			return 0;
		}

		public List<SpActivityTask> GetActivityTaskListByType(uint type)
		{
			bool flag = this.ActivityRecord != null && this.ActivityRecord.spActivity.Count > 0;
			if (flag)
			{
				for (int i = 0; i < this.ActivityRecord.spActivity.Count; i++)
				{
					SpActivityOne spActivityOne = this.ActivityRecord.spActivity[i];
					bool flag2 = spActivityOne.actid == type;
					if (flag2)
					{
						return spActivityOne.task;
					}
				}
			}
			return null;
		}

		public void UpdateActivityTaskState(uint actId, uint taskId, uint state, uint progress = 0U)
		{
			bool flag = this.ActivityRecord == null;
			if (!flag)
			{
				bool flag2 = true;
				for (int i = 0; i < this.ActivityRecord.spActivity.Count; i++)
				{
					SpActivityOne spActivityOne = this.ActivityRecord.spActivity[i];
					bool flag3 = spActivityOne.actid == actId;
					if (flag3)
					{
						flag2 = false;
						bool flag4 = true;
						for (int j = 0; j < spActivityOne.task.Count; j++)
						{
							bool flag5 = spActivityOne.task[j].taskid == taskId;
							if (flag5)
							{
								flag4 = false;
								spActivityOne.task[j].state = state;
								spActivityOne.task[j].progress = progress;
							}
						}
						bool flag6 = flag4;
						if (flag6)
						{
							spActivityOne.task.Add(new SpActivityTask
							{
								taskid = taskId,
								progress = progress,
								state = state
							});
						}
					}
				}
				bool flag7 = flag2;
				if (flag7)
				{
					SpActivityOne spActivityOne2 = new SpActivityOne();
					spActivityOne2.actid = actId;
					spActivityOne2.task.Add(new SpActivityTask
					{
						taskid = taskId,
						progress = progress,
						state = state
					});
					this.ActivityRecord.spActivity.Add(spActivityOne2);
				}
				XActivityTaskUpdatedArgs @event = XEventPool<XActivityTaskUpdatedArgs>.GetEvent();
				@event.xActID = actId;
				@event.xTaskID = taskId;
				@event.xState = state;
				@event.xProgress = progress;
				@event.Firer = XSingleton<XGame>.singleton.Doc;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		public int GetRemainDays(uint actID)
		{
			int result = 1;
			XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
			uint sealType = specificDocument.GetSealType();
			LevelSealTypeTable.RowData levelSealType = XLevelSealDocument.GetLevelSealType(sealType);
			int num = (int)(levelSealType.Time / 24U);
			for (int i = 0; i < this.offsetDayInfos.actid.Count; i++)
			{
				bool flag = actID == this.offsetDayInfos.actid[i];
				if (flag)
				{
					result = Mathf.Max(1, num - this.offsetDayInfos.offsetday[i]);
				}
			}
			return result;
		}

		public bool GetActivityAwards(uint actid, uint taskid)
		{
			RpcC2G_GetSpActivityReward rpcC2G_GetSpActivityReward = new RpcC2G_GetSpActivityReward();
			rpcC2G_GetSpActivityReward.oArg.actid = actid;
			rpcC2G_GetSpActivityReward.oArg.taskid = taskid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetSpActivityReward);
			return true;
		}

		private int SortActivityTask(SpActivityTask x, SpActivityTask y)
		{
			bool flag = x.state == 1U && y.state != 1U;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				bool flag2 = x.state != 1U && y.state == 1U;
				if (flag2)
				{
					result = 1;
				}
				else
				{
					bool flag3 = x.state != y.state;
					if (flag3)
					{
						result = (int)(x.state - y.state);
					}
					else
					{
						result = (int)(x.taskid - y.taskid);
					}
				}
			}
			return result;
		}

		public List<uint> GetActivityCompleteScene(uint actid)
		{
			List<uint> list;
			bool flag = !this.m_ActIDToCompleteSceneIDListDic.TryGetValue(actid, out list);
			if (flag)
			{
				list = new List<uint>();
				SpActivityOne activity = this.GetActivity(actid);
				bool flag2 = activity == null || activity.theme == null;
				if (flag2)
				{
					return list;
				}
				for (int i = 0; i < activity.theme.firstscene.Count; i++)
				{
					for (int j = 0; j < activity.theme.firstscene[i].sceneid.Count; j++)
					{
						list.Add(activity.theme.firstscene[i].sceneid[j]);
					}
				}
				this.m_ActIDToCompleteSceneIDListDic[actid] = list;
			}
			return list;
		}

		public void SetActivityCompleteScene(uint actid, List<SpFirstCompleteScene> scene)
		{
			List<uint> list = new List<uint>();
			for (int i = 0; i < scene.Count; i++)
			{
				for (int j = 0; j < scene[i].sceneid.Count; j++)
				{
					list.Add(scene[i].sceneid[j]);
				}
			}
			this.m_ActIDToCompleteSceneIDListDic[actid] = list;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("TempActivityDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static SuperActivity _superActivityTable = new SuperActivity();

		private static SuperActivityTask _superActivityTaskTable = new SuperActivityTask();

		private static SuperActivityTime _superActivityTimeTable = new SuperActivityTime();

		private static OpenServerActivity _openServerActivity = new OpenServerActivity();

		protected SpActivityOffsetDay offsetDayInfos;

		protected SpActivity _spactivityRecord;

		private Dictionary<uint, List<uint>> m_ActIDToCompleteSceneIDListDic = new Dictionary<uint, List<uint>>();
	}
}
