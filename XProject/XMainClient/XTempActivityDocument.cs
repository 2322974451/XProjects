using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A04 RID: 2564
	internal class XTempActivityDocument : XDocComponent
	{
		// Token: 0x17002E7D RID: 11901
		// (get) Token: 0x06009CF4 RID: 40180 RVA: 0x00197B48 File Offset: 0x00195D48
		public override uint ID
		{
			get
			{
				return XTempActivityDocument.uuID;
			}
		}

		// Token: 0x17002E7E RID: 11902
		// (get) Token: 0x06009CF5 RID: 40181 RVA: 0x00197B60 File Offset: 0x00195D60
		public static XTempActivityDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XTempActivityDocument.uuID) as XTempActivityDocument;
			}
		}

		// Token: 0x17002E7F RID: 11903
		// (get) Token: 0x06009CF6 RID: 40182 RVA: 0x00197B8C File Offset: 0x00195D8C
		public static SuperActivity SuperActivityTable
		{
			get
			{
				return XTempActivityDocument._superActivityTable;
			}
		}

		// Token: 0x17002E80 RID: 11904
		// (get) Token: 0x06009CF7 RID: 40183 RVA: 0x00197BA4 File Offset: 0x00195DA4
		public static SuperActivityTime SuperActivityTimeTable
		{
			get
			{
				return XTempActivityDocument._superActivityTimeTable;
			}
		}

		// Token: 0x17002E81 RID: 11905
		// (get) Token: 0x06009CF8 RID: 40184 RVA: 0x00197BBC File Offset: 0x00195DBC
		public static SuperActivityTask SuperActivityTaskTable
		{
			get
			{
				return XTempActivityDocument._superActivityTaskTable;
			}
		}

		// Token: 0x17002E82 RID: 11906
		// (get) Token: 0x06009CF9 RID: 40185 RVA: 0x00197BD4 File Offset: 0x00195DD4
		// (set) Token: 0x06009CFA RID: 40186 RVA: 0x00197BEC File Offset: 0x00195DEC
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

		// Token: 0x06009CFB RID: 40187 RVA: 0x00197C04 File Offset: 0x00195E04
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

		// Token: 0x06009CFC RID: 40188 RVA: 0x00197C58 File Offset: 0x00195E58
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

		// Token: 0x06009CFD RID: 40189 RVA: 0x00197CB4 File Offset: 0x00195EB4
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

		// Token: 0x06009CFE RID: 40190 RVA: 0x00197D18 File Offset: 0x00195F18
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

		// Token: 0x06009CFF RID: 40191 RVA: 0x00197D74 File Offset: 0x00195F74
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

		// Token: 0x06009D00 RID: 40192 RVA: 0x00197DC4 File Offset: 0x00195FC4
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

		// Token: 0x06009D01 RID: 40193 RVA: 0x00197E14 File Offset: 0x00196014
		public DateTime GetEndTime(uint actID)
		{
			return this.GetEndTime(this.GetDataByActivityID(actID), -1);
		}

		// Token: 0x06009D02 RID: 40194 RVA: 0x00197E34 File Offset: 0x00196034
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

		// Token: 0x06009D03 RID: 40195 RVA: 0x00197EE0 File Offset: 0x001960E0
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

		// Token: 0x06009D04 RID: 40196 RVA: 0x00197F40 File Offset: 0x00196140
		public static void Execute(OnLoadedCallback callback = null)
		{
			XTempActivityDocument.AsyncLoader.AddTask("Table/SuperActivity", XTempActivityDocument._superActivityTable, false);
			XTempActivityDocument.AsyncLoader.AddTask("Table/SuperActivityTask", XTempActivityDocument._superActivityTaskTable, false);
			XTempActivityDocument.AsyncLoader.AddTask("Table/SuperActivityTime", XTempActivityDocument._superActivityTimeTable, false);
			XTempActivityDocument.AsyncLoader.AddTask("Table/OpenServerActivity", XTempActivityDocument._openServerActivity, false);
			XTempActivityDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009D05 RID: 40197 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06009D06 RID: 40198 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x06009D07 RID: 40199 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x06009D08 RID: 40200 RVA: 0x00197FB2 File Offset: 0x001961B2
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.InitActivityRecordFromServerData(arg.PlayerInfo.spActivityRecord);
			WeekEndNestDocument.Doc.OfflineOpenSetTaskId();
		}

		// Token: 0x06009D09 RID: 40201 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x06009D0A RID: 40202 RVA: 0x00197FD2 File Offset: 0x001961D2
		public void InitActivityRecordFromServerData(SpActivity spActivityRecord)
		{
			this.ActivityRecord = spActivityRecord;
		}

		// Token: 0x06009D0B RID: 40203 RVA: 0x00197FE0 File Offset: 0x001961E0
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

		// Token: 0x06009D0C RID: 40204 RVA: 0x00198138 File Offset: 0x00196338
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

		// Token: 0x06009D0D RID: 40205 RVA: 0x001981FC File Offset: 0x001963FC
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

		// Token: 0x06009D0E RID: 40206 RVA: 0x00198274 File Offset: 0x00196474
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

		// Token: 0x06009D0F RID: 40207 RVA: 0x00198300 File Offset: 0x00196500
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

		// Token: 0x06009D10 RID: 40208 RVA: 0x001983D8 File Offset: 0x001965D8
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

		// Token: 0x06009D11 RID: 40209 RVA: 0x001984B0 File Offset: 0x001966B0
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

		// Token: 0x06009D12 RID: 40210 RVA: 0x00198584 File Offset: 0x00196784
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

		// Token: 0x06009D13 RID: 40211 RVA: 0x00198628 File Offset: 0x00196828
		public void SortActivityTaskByType(uint actid)
		{
			List<SpActivityTask> activityTaskListByType = this.GetActivityTaskListByType(actid);
			bool flag = activityTaskListByType != null;
			if (flag)
			{
				activityTaskListByType.Sort(new Comparison<SpActivityTask>(this.SortActivityTask));
			}
		}

		// Token: 0x06009D14 RID: 40212 RVA: 0x0019865C File Offset: 0x0019685C
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

		// Token: 0x06009D15 RID: 40213 RVA: 0x001986E8 File Offset: 0x001968E8
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

		// Token: 0x06009D16 RID: 40214 RVA: 0x00198770 File Offset: 0x00196970
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

		// Token: 0x06009D17 RID: 40215 RVA: 0x00198924 File Offset: 0x00196B24
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

		// Token: 0x06009D18 RID: 40216 RVA: 0x001989C4 File Offset: 0x00196BC4
		public bool GetActivityAwards(uint actid, uint taskid)
		{
			RpcC2G_GetSpActivityReward rpcC2G_GetSpActivityReward = new RpcC2G_GetSpActivityReward();
			rpcC2G_GetSpActivityReward.oArg.actid = actid;
			rpcC2G_GetSpActivityReward.oArg.taskid = taskid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetSpActivityReward);
			return true;
		}

		// Token: 0x06009D19 RID: 40217 RVA: 0x00198A04 File Offset: 0x00196C04
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

		// Token: 0x06009D1A RID: 40218 RVA: 0x00198A88 File Offset: 0x00196C88
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

		// Token: 0x06009D1B RID: 40219 RVA: 0x00198B70 File Offset: 0x00196D70
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

		// Token: 0x0400373E RID: 14142
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("TempActivityDocument");

		// Token: 0x0400373F RID: 14143
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003740 RID: 14144
		private static SuperActivity _superActivityTable = new SuperActivity();

		// Token: 0x04003741 RID: 14145
		private static SuperActivityTask _superActivityTaskTable = new SuperActivityTask();

		// Token: 0x04003742 RID: 14146
		private static SuperActivityTime _superActivityTimeTable = new SuperActivityTime();

		// Token: 0x04003743 RID: 14147
		private static OpenServerActivity _openServerActivity = new OpenServerActivity();

		// Token: 0x04003744 RID: 14148
		protected SpActivityOffsetDay offsetDayInfos;

		// Token: 0x04003745 RID: 14149
		protected SpActivity _spactivityRecord;

		// Token: 0x04003746 RID: 14150
		private Dictionary<uint, List<uint>> m_ActIDToCompleteSceneIDListDic = new Dictionary<uint, List<uint>>();
	}
}
