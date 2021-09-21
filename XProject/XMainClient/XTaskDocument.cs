using System;
using System.Collections.Generic;
using System.Text;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A8F RID: 2703
	internal class XTaskDocument : XDocComponent
	{
		// Token: 0x17002FCA RID: 12234
		// (get) Token: 0x0600A451 RID: 42065 RVA: 0x001C5C8C File Offset: 0x001C3E8C
		public override uint ID
		{
			get
			{
				return XTaskDocument.uuID;
			}
		}

		// Token: 0x17002FCB RID: 12235
		// (get) Token: 0x0600A452 RID: 42066 RVA: 0x001C5CA4 File Offset: 0x001C3EA4
		public XTaskRecord TaskRecord
		{
			get
			{
				return this.m_TaskRecord;
			}
		}

		// Token: 0x17002FCC RID: 12236
		// (get) Token: 0x0600A453 RID: 42067 RVA: 0x001C5CBC File Offset: 0x001C3EBC
		// (set) Token: 0x0600A454 RID: 42068 RVA: 0x001C5CC4 File Offset: 0x001C3EC4
		public uint CurrentSelect { get; set; }

		// Token: 0x17002FCD RID: 12237
		// (get) Token: 0x0600A455 RID: 42069 RVA: 0x001C5CD0 File Offset: 0x001C3ED0
		public Dictionary<uint, uint> TaskMonstersKilled
		{
			get
			{
				return this.m_TaskMonstersKilled;
			}
		}

		// Token: 0x17002FCE RID: 12238
		// (get) Token: 0x0600A456 RID: 42070 RVA: 0x001C5CE8 File Offset: 0x001C3EE8
		public int NaviTarget
		{
			get
			{
				return this.m_NaviTarget;
			}
		}

		// Token: 0x17002FCF RID: 12239
		// (get) Token: 0x0600A457 RID: 42071 RVA: 0x001C5D00 File Offset: 0x001C3F00
		public uint NaviScene
		{
			get
			{
				return this.m_NaviScene;
			}
		}

		// Token: 0x17002FD0 RID: 12240
		// (get) Token: 0x0600A458 RID: 42072 RVA: 0x001C5D18 File Offset: 0x001C3F18
		public uint NaviTask
		{
			get
			{
				return this.m_NaviTask;
			}
		}

		// Token: 0x0600A459 RID: 42073 RVA: 0x001C5D30 File Offset: 0x001C3F30
		public static void Execute(OnLoadedCallback callback = null)
		{
			XTaskDocument.AsyncLoader.AddTask("Table/TaskListNew", XTaskDocument._TaskTable, false);
			XTaskDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600A45A RID: 42074 RVA: 0x001C5D58 File Offset: 0x001C3F58
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("TaskTypeSort", XGlobalConfig.ListSeparator);
			uint num = 0U;
			while ((ulong)num < (ulong)((long)andSeparateValue.Length))
			{
				XTaskDocument.TypeSortValue[(int)uint.Parse(andSeparateValue[(int)num])] = num;
				num += 1U;
			}
			this.m_AppearNpcs.Clear();
			this.m_DisappearNpcs.Clear();
			XNpcInfo npcInfo = XSingleton<XEntityMgr>.singleton.NpcInfo;
			for (int i = 0; i < npcInfo.Table.Length; i++)
			{
				XNpcInfo.RowData rowData = npcInfo.Table[i];
				bool flag = rowData.RequiredTaskID > 0U;
				if (flag)
				{
					List<uint> list;
					bool flag2 = !this.m_AppearNpcs.TryGetValue(rowData.RequiredTaskID, out list);
					if (flag2)
					{
						list = new List<uint>();
						this.m_AppearNpcs.Add(rowData.RequiredTaskID, list);
					}
					list.Add(rowData.ID);
				}
				bool flag3 = rowData.DisappearTask > 0U;
				if (flag3)
				{
					List<uint> list2;
					bool flag4 = !this.m_DisappearNpcs.TryGetValue(rowData.DisappearTask, out list2);
					if (flag4)
					{
						list2 = new List<uint>();
						this.m_DisappearNpcs.Add(rowData.DisappearTask, list2);
					}
					list2.Add(rowData.ID);
				}
			}
		}

		// Token: 0x0600A45B RID: 42075 RVA: 0x001C5EB4 File Offset: 0x001C40B4
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_RealDead, new XComponent.XEventHandler(this._OnEntityDie));
			base.RegisterEvent(XEventDefine.XEvent_TaskStateChange, new XComponent.XEventHandler(this._OnTaskStateChanged));
			base.RegisterEvent(XEventDefine.XEvent_NpcFavorFxChange, new XComponent.XEventHandler(this._NotifyXTaskDocFx));
		}

		// Token: 0x0600A45C RID: 42076 RVA: 0x001C5F10 File Offset: 0x001C4110
		public static TaskTableNew.RowData GetTaskData(uint taskID)
		{
			return XTaskDocument._TaskTable.GetByTaskID(taskID);
		}

		// Token: 0x0600A45D RID: 42077 RVA: 0x001C5F2D File Offset: 0x001C412D
		public void ResetNavi()
		{
			this.m_NaviScene = 0U;
			this.m_NaviTarget = 0;
		}

		// Token: 0x0600A45E RID: 42078 RVA: 0x001C5F40 File Offset: 0x001C4140
		public XTaskInfo GetTaskInfo(uint taskID)
		{
			for (int i = 0; i < this.TaskRecord.Tasks.Count; i++)
			{
				bool flag = this.TaskRecord.Tasks[i].ID == taskID;
				if (flag)
				{
					return this.TaskRecord.Tasks[i];
				}
			}
			return null;
		}

		// Token: 0x0600A45F RID: 42079 RVA: 0x001C5FA8 File Offset: 0x001C41A8
		public TaskStatus GetTaskStatue()
		{
			TaskStatus taskStatus = TaskStatus.TaskStatus_Over;
			for (int i = 0; i < this.TaskRecord.Tasks.Count; i++)
			{
				TaskTableNew.RowData taskData = XTaskDocument.GetTaskData(this.TaskRecord.Tasks[i].ID);
				bool flag = taskData == null || (ulong)this.TaskRecord.Tasks[i].TableData.TaskType != (ulong)((long)XFastEnumIntEqualityComparer<XTaskType>.ToInt(XTaskType.TT_GuildDailyTask));
				if (!flag)
				{
					taskStatus = this.TaskRecord.Tasks[i].Status;
					bool flag2 = taskStatus == TaskStatus.TaskStatus_Taked || taskStatus == TaskStatus.TaskStatus_Finish;
					if (flag2)
					{
						break;
					}
				}
			}
			return taskStatus;
		}

		// Token: 0x0600A460 RID: 42080 RVA: 0x001C6064 File Offset: 0x001C4264
		private bool _GetNpcData(TaskTableNew.RowData data, XTaskInfo info)
		{
			bool flag = data == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = info == null;
				if (flag2)
				{
					this.m_TempNpcData = data.BeginTaskNPCID;
				}
				else
				{
					TaskStatus status = info.Status;
					if (status - TaskStatus.TaskStatus_Taked > 1)
					{
						this.m_TempNpcData = data.BeginTaskNPCID;
					}
					else
					{
						this.m_TempNpcData = data.EndTaskNPCID;
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600A461 RID: 42081 RVA: 0x001C60C8 File Offset: 0x001C42C8
		private bool _GetTempData(TaskTableNew.RowData data, XTaskInfo info)
		{
			bool flag = data == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = info == null;
				if (flag2)
				{
					this.m_TempNpcData = data.BeginTaskNPCID;
					this.m_TempTarget = data.BeginDesc;
				}
				else
				{
					TaskStatus status = info.Status;
					if (status != TaskStatus.TaskStatus_Taked)
					{
						if (status != TaskStatus.TaskStatus_Finish)
						{
							this.m_TempNpcData = data.BeginTaskNPCID;
							this.m_TempTarget = data.BeginDesc;
						}
						else
						{
							this.m_TempTarget = data.EndDesc;
							this.m_TempNpcData = data.EndTaskNPCID;
						}
					}
					else
					{
						this.m_TempTarget = data.InprocessDesc;
						this.m_TempNpcData = null;
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600A462 RID: 42082 RVA: 0x001C616C File Offset: 0x001C436C
		public string ParseTaskDesc(TaskTableNew.RowData data, XTaskInfo info, bool bCRLF)
		{
			bool flag = !this._GetTempData(data, info);
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder(this.m_TempTarget);
				if (bCRLF)
				{
					stringBuilder.Replace("{n}", "\n");
				}
				else
				{
					stringBuilder.Replace("{n}", "  ");
				}
				uint key = XSingleton<UiUtility>.singleton.ChooseProfData<uint>(this.m_TempNpcData, 0U);
				XNpcInfo.RowData byNPCID = XSingleton<XEntityMgr>.singleton.NpcInfo.GetByNPCID(key);
				bool flag2 = byNPCID != null;
				if (flag2)
				{
					stringBuilder = stringBuilder.Replace("{npc}", byNPCID.Name);
				}
				bool flag3 = info == null;
				if (flag3)
				{
					uint num = XSingleton<UiUtility>.singleton.ChooseProfData<uint>(ref data.PassScene, 0U, 0);
					SceneTable.RowData rowData = null;
					bool flag4 = num > 0U;
					if (flag4)
					{
						rowData = XSingleton<XSceneMgr>.singleton.GetSceneData(num);
					}
					bool flag5 = rowData != null;
					if (flag5)
					{
						stringBuilder.Replace("{scene}", rowData.Comment);
					}
				}
				else
				{
					for (int i = 0; i < info.Conds.Count; i++)
					{
						TaskConditionInfo taskConditionInfo = info.Conds[i];
						switch (taskConditionInfo.type)
						{
						case TaskConnType.TaskConn_ItemID:
						{
							ItemList.RowData itemConf = XBagDocument.GetItemConf((int)taskConditionInfo.id);
							bool flag6 = itemConf != null;
							if (flag6)
							{
								stringBuilder.Replace("{item}", XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U));
							}
							break;
						}
						case TaskConnType.TaskConn_StageID:
						{
							SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(taskConditionInfo.id);
							bool flag7 = sceneData != null;
							if (flag7)
							{
								stringBuilder.Replace("{scene}", sceneData.Comment);
							}
							break;
						}
						case TaskConnType.TaskConn_MonsterID:
						{
							XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(taskConditionInfo.id);
							bool flag8 = byID != null;
							if (flag8)
							{
								stringBuilder.Replace("{monster}", byID.Name);
							}
							break;
						}
						}
						this._FormatCount(stringBuilder, taskConditionInfo);
					}
				}
				result = stringBuilder.ToString();
			}
			return result;
		}

		// Token: 0x0600A463 RID: 42083 RVA: 0x001C6388 File Offset: 0x001C4588
		private void _FormatCount(StringBuilder sb, TaskConditionInfo cond)
		{
			bool flag = cond != null;
			if (flag)
			{
				string newValue = XSingleton<XCommon>.singleton.StringCombine(cond.step.ToString(), "/", cond.max_step.ToString());
				switch (cond.type)
				{
				case TaskConnType.TaskConn_ItemID:
					sb.Replace("{itemcount}", newValue);
					break;
				case TaskConnType.TaskConn_StageID:
					sb.Replace("{scenecount}", newValue);
					break;
				case TaskConnType.TaskConn_MonsterID:
					sb.Replace("{monstercount}", newValue);
					break;
				}
			}
		}

		// Token: 0x0600A464 RID: 42084 RVA: 0x001C6418 File Offset: 0x001C4618
		public void OnTaskStatusUpdate(TaskInfo info)
		{
			bool flag = false;
			for (int i = 0; i < this.TaskRecord.Tasks.Count; i++)
			{
				bool flag2 = this.TaskRecord.Tasks[i].ID == info.id;
				if (flag2)
				{
					flag = true;
					this.TaskRecord.Tasks[i].Init(info);
					bool flag3 = info.status == TaskStatus.TaskStatus_Over;
					if (flag3)
					{
						this.TaskRecord.Tasks.RemoveAt(i);
						this.TaskRecord.FinishTask(info.id);
						bool flag4 = info.id == XTaskDocument._HighestPriorityTask;
						if (flag4)
						{
							this._ResetHighestPriorityTask(false);
						}
					}
					break;
				}
			}
			bool flag5 = !flag;
			if (flag5)
			{
				bool flag6 = info.status == TaskStatus.TaskStatus_Over;
				if (flag6)
				{
					this.TaskRecord.FinishTask(info.id);
				}
				else
				{
					this.TaskRecord.AddTask(info);
				}
			}
			this._RefreshUI();
			this.SetupNpcHeadFx();
			XTaskStatusChangeArgs @event = XEventPool<XTaskStatusChangeArgs>.GetEvent();
			@event.id = info.id;
			@event.status = info.status;
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x0600A465 RID: 42085 RVA: 0x001C6568 File Offset: 0x001C4768
		private void _RefreshUI()
		{
			bool flag = DlgBase<XTaskView, XTaskBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XTaskView, XTaskBehaviour>.singleton.RefreshPage();
			}
			bool flag2 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				bool flag3 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._TaskNaviHandler.TaskHandler.IsVisible();
				if (flag3)
				{
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._TaskNaviHandler.TaskHandler.RefreshData();
				}
			}
		}

		// Token: 0x0600A466 RID: 42086 RVA: 0x001C65CC File Offset: 0x001C47CC
		public void SetHighestPriorityTask(uint taskID)
		{
			XTaskDocument._HighestPriorityTask = taskID;
			this._OnHighestPriorityTaskChanged(true);
		}

		// Token: 0x0600A467 RID: 42087 RVA: 0x001C65E0 File Offset: 0x001C47E0
		private void _ResetHighestPriorityTask(bool bUpdateUI)
		{
			bool flag = XTaskDocument._HighestPriorityTask > 0U;
			if (flag)
			{
				XTaskDocument._HighestPriorityTask = 0U;
				this._OnHighestPriorityTaskChanged(bUpdateUI);
			}
		}

		// Token: 0x0600A468 RID: 42088 RVA: 0x001C660C File Offset: 0x001C480C
		private void _OnHighestPriorityTaskChanged(bool bUpdateUI)
		{
			this.TaskRecord.Tasks.Sort(new Comparison<XTaskInfo>(XTaskDocument.SortInTaskList));
			if (bUpdateUI)
			{
				this._RefreshUI();
				this.SetupNpcHeadFx();
			}
		}

		// Token: 0x0600A469 RID: 42089 RVA: 0x001C664C File Offset: 0x001C484C
		public void DoTask(uint id)
		{
			XTaskInfo taskInfo = this.GetTaskInfo(id);
			bool flag = taskInfo == null;
			if (!flag)
			{
				TaskTableNew.RowData tableData = taskInfo.TableData;
				bool flag2 = !this._GetTempData(tableData, taskInfo);
				if (!flag2)
				{
					uint num = XSingleton<UiUtility>.singleton.ChooseProfData<uint>(this.m_TempNpcData, 0U);
					uint sceneID = XTaskDocument.GetSceneID(ref tableData.TaskScene);
					bool flag3 = sceneID != 0U && taskInfo.Status == TaskStatus.TaskStatus_Taked;
					if (flag3)
					{
						XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
						int expIDBySceneID = specificDocument.GetExpIDBySceneID(sceneID);
						bool flag4 = expIDBySceneID != 0;
						if (flag4)
						{
							XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
							specificDocument2.SetAndMatch(expIDBySceneID);
						}
						else
						{
							PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
							ptcC2G_EnterSceneReq.Data.sceneID = sceneID;
							XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
						}
					}
					else
					{
						bool flag5 = num == 0U && tableData.TaskType == 4U;
						if (flag5)
						{
							DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.SetVisibleWithAnimation(true, null);
						}
						else
						{
							bool flag6 = num == 0U && tableData.TaskType == 7U;
							if (flag6)
							{
								DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.SetVisibleWithAnimation(true, null);
							}
							else
							{
								bool flag7 = num == 0U && tableData.TaskID == XCampDuelDocument.Doc.TaskID;
								if (flag7)
								{
									DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.Show(XSysDefine.XSys_CampDuel, false);
								}
								else
								{
									uint sceneID2 = XTaskDocument.GetSceneID(ref tableData.PassScene);
									this.NaviToNpc(num, sceneID2);
									this.m_NaviTask = id;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600A46A RID: 42090 RVA: 0x001C67C4 File Offset: 0x001C49C4
		public void NaviToNpc(uint npcid, uint sceneid)
		{
			bool flag = npcid == 0U;
			if (flag)
			{
				DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.IsTaskMode = true;
				this._NavigateToBattle();
				this.m_NaviTarget = 1;
				this.m_NaviScene = sceneid;
			}
			else
			{
				XSingleton<XInput>.singleton.LastNpc = XSingleton<XEntityMgr>.singleton.GetNpc(npcid);
			}
		}

		// Token: 0x0600A46B RID: 42091 RVA: 0x001C6818 File Offset: 0x001C4A18
		private void _NavigateToBattle()
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player == null || XSingleton<XEntityMgr>.singleton.Player.Deprecated;
			if (!flag)
			{
				XSingleton<XInput>.singleton.LastNpc = null;
				Vector3 normalized = (XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position - XSingleton<XScene>.singleton.BattleTargetPoint).normalized;
				Vector3 dest = XSingleton<XScene>.singleton.BattleTargetPoint + normalized * 5.8f;
				XNavigationEventArgs @event = XEventPool<XNavigationEventArgs>.GetEvent();
				@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
				@event.Dest = dest;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x0600A46C RID: 42092 RVA: 0x001C68C8 File Offset: 0x001C4AC8
		public List<uint> GetSceneTaskState(uint sceneid)
		{
			this.m_TempTasks.Clear();
			for (int i = 0; i < this.TaskRecord.Tasks.Count; i++)
			{
				XTaskInfo xtaskInfo = this.TaskRecord.Tasks[i];
				bool flag = xtaskInfo == null || xtaskInfo.TableData == null;
				if (!flag)
				{
					bool flag2 = sceneid == XTaskDocument.GetSceneID(ref xtaskInfo.TableData.PassScene);
					if (flag2)
					{
						this.m_TempTasks.Add(xtaskInfo.ID);
					}
					else
					{
						bool flag3 = sceneid == XTaskDocument.GetSceneID(ref xtaskInfo.TableData.TaskScene);
						if (flag3)
						{
							this.m_TempTasks.Add(xtaskInfo.ID);
						}
					}
				}
			}
			return this.m_TempTasks;
		}

		// Token: 0x0600A46D RID: 42093 RVA: 0x001C6998 File Offset: 0x001C4B98
		public NpcTaskState GetNpcTaskState(uint npcid, ref XTaskInfo task)
		{
			task = null;
			for (int i = 0; i < this.TaskRecord.Tasks.Count; i++)
			{
				XTaskInfo xtaskInfo = this.TaskRecord.Tasks[i];
				TaskTableNew.RowData tableData = xtaskInfo.TableData;
				bool flag = !this._GetNpcData(tableData, xtaskInfo);
				if (!flag)
				{
					bool flag2 = tableData != null && XSingleton<UiUtility>.singleton.ChooseProfData<uint>(this.m_TempNpcData, 0U) == npcid;
					if (flag2)
					{
						bool flag3 = xtaskInfo.ID == this.m_NaviTask;
						if (flag3)
						{
							task = xtaskInfo;
							return xtaskInfo.NpcState;
						}
						bool flag4 = XTaskDocument.SortInDialog(xtaskInfo, task) < 0;
						if (flag4)
						{
							task = xtaskInfo;
						}
					}
				}
			}
			bool flag5 = task != null;
			if (flag5)
			{
				return task.NpcState;
			}
			return NpcTaskState.Normal;
		}

		// Token: 0x0600A46E RID: 42094 RVA: 0x001C6A74 File Offset: 0x001C4C74
		private XTaskInfo FindTaskInfo(uint npcId)
		{
			XTaskInfo xtaskInfo = null;
			for (int i = 0; i < this.TaskRecord.Tasks.Count; i++)
			{
				XTaskInfo xtaskInfo2 = this.TaskRecord.Tasks[i];
				bool flag = !this._GetNpcData(xtaskInfo2.TableData, xtaskInfo2);
				if (!flag)
				{
					uint num = XSingleton<UiUtility>.singleton.ChooseProfData<uint>(this.m_TempNpcData, 0U);
					bool flag2 = npcId != num;
					if (!flag2)
					{
						bool flag3 = xtaskInfo == null;
						if (flag3)
						{
							xtaskInfo = xtaskInfo2;
						}
						else
						{
							bool flag4 = XTaskDocument.SortInDialog(xtaskInfo2, xtaskInfo) < 0;
							if (flag4)
							{
								xtaskInfo = xtaskInfo2;
							}
						}
					}
				}
			}
			return xtaskInfo;
		}

		// Token: 0x0600A46F RID: 42095 RVA: 0x001C6B20 File Offset: 0x001C4D20
		private bool _NotifyXTaskDocFx(XEventArgs e)
		{
			this.SetupNpcHeadFx();
			return true;
		}

		// Token: 0x0600A470 RID: 42096 RVA: 0x001C6B3C File Offset: 0x001C4D3C
		protected void SetupNpcHeadFx()
		{
			List<uint> npcs = XSingleton<XEntityMgr>.singleton.GetNpcs(XSingleton<XScene>.singleton.SceneID);
			this.m_TempNpcTopTask.Clear();
			this.ClearFx();
			bool flag = npcs == null;
			if (!flag)
			{
				for (int i = 0; i < this.TaskRecord.Tasks.Count; i++)
				{
					XTaskInfo xtaskInfo = this.TaskRecord.Tasks[i];
					bool flag2 = !this._GetNpcData(xtaskInfo.TableData, xtaskInfo);
					if (!flag2)
					{
						uint key = XSingleton<UiUtility>.singleton.ChooseProfData<uint>(this.m_TempNpcData, 0U);
						XTaskInfo task;
						bool flag3 = this.m_TempNpcTopTask.TryGetValue(key, out task);
						if (flag3)
						{
							bool flag4 = XTaskDocument.SortInDialog(xtaskInfo, task) < 0;
							if (flag4)
							{
								this.m_TempNpcTopTask[key] = xtaskInfo;
							}
						}
						else
						{
							this.m_TempNpcTopTask[key] = xtaskInfo;
						}
					}
				}
				for (int j = 0; j < npcs.Count; j++)
				{
					XTaskInfo xtaskInfo2;
					bool flag5 = !this.m_TempNpcTopTask.TryGetValue(npcs[j], out xtaskInfo2);
					if (!flag5)
					{
						XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc(npcs[j]);
						bool flag6 = npc == null;
						if (!flag6)
						{
							NpcTaskState npcState = xtaskInfo2.NpcState;
							XFx xfx = null;
							bool flag7 = npcState == NpcTaskState.TaskBegin;
							if (flag7)
							{
								xfx = XSingleton<XFxMgr>.singleton.CreateFx(this.FX_TASK_BEGIN, null, true);
							}
							else
							{
								bool flag8 = npcState == NpcTaskState.TaskInprocess;
								if (flag8)
								{
									bool flag9 = false;
									bool flag10 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_NPCFavor);
									if (flag10)
									{
										XNPCFavorDocument specificDocument = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
										flag9 = specificDocument.IsShowFavorFx(npcs[j]);
									}
									bool flag11 = !flag9;
									if (flag11)
									{
										xfx = XSingleton<XFxMgr>.singleton.CreateFx(this.FX_TASK_INPROCESS, null, true);
									}
								}
								else
								{
									bool flag12 = npcState == NpcTaskState.TaskEnd;
									if (flag12)
									{
										xfx = XSingleton<XFxMgr>.singleton.CreateFx(this.FX_TASK_END, null, true);
									}
								}
							}
							bool flag13 = xfx != null;
							if (flag13)
							{
								this.m_Fxes.Add(xfx);
								xfx.Play(npc.EngineObject, new Vector3(-0.05f, npc.Height + 0.7f, 0f), Vector3.one, 1f, true, false, "", 0f);
							}
						}
					}
				}
				this.m_TempNpcTopTask.Clear();
			}
		}

		// Token: 0x0600A471 RID: 42097 RVA: 0x001C6DB8 File Offset: 0x001C4FB8
		public void CreateFx(XNpc npc, uint npcId)
		{
			XTaskInfo xtaskInfo = this.FindTaskInfo(npcId);
			bool flag = xtaskInfo != null;
			if (flag)
			{
				NpcTaskState npcState = xtaskInfo.NpcState;
				XFx xfx = null;
				bool flag2 = npcState == NpcTaskState.TaskBegin;
				if (flag2)
				{
					xfx = XSingleton<XFxMgr>.singleton.CreateFx(this.FX_TASK_BEGIN, null, true);
				}
				else
				{
					bool flag3 = npcState == NpcTaskState.TaskInprocess;
					if (flag3)
					{
						xfx = XSingleton<XFxMgr>.singleton.CreateFx(this.FX_TASK_INPROCESS, null, true);
					}
					else
					{
						bool flag4 = npcState == NpcTaskState.TaskEnd;
						if (flag4)
						{
							xfx = XSingleton<XFxMgr>.singleton.CreateFx(this.FX_TASK_END, null, true);
						}
					}
				}
				bool flag5 = xfx != null;
				if (flag5)
				{
					this.m_Fxes.Add(xfx);
					xfx.Play(npc.EngineObject, new Vector3(-0.05f, npc.Height + 0.7f, 0f), Vector3.one, 1f, true, false, "", 0f);
				}
			}
		}

		// Token: 0x0600A472 RID: 42098 RVA: 0x001C6E9C File Offset: 0x001C509C
		protected void ClearFx()
		{
			for (int i = 0; i < this.m_Fxes.Count; i++)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_Fxes[i], true);
			}
			this.m_Fxes.Clear();
		}

		// Token: 0x0600A473 RID: 42099 RVA: 0x001C6EEA File Offset: 0x001C50EA
		private void _ResetTaskMonsters()
		{
			this.m_TaskMonstersKilled.Clear();
		}

		// Token: 0x0600A474 RID: 42100 RVA: 0x001C6EFC File Offset: 0x001C50FC
		private void _InitTaskMonsters()
		{
			for (int i = 0; i < this.TaskRecord.Tasks.Count; i++)
			{
				XTaskInfo xtaskInfo = this.TaskRecord.Tasks[i];
				for (int j = 0; j < xtaskInfo.Conds.Count; j++)
				{
					TaskConditionInfo taskConditionInfo = xtaskInfo.Conds[j];
					bool flag = taskConditionInfo.type == TaskConnType.TaskConn_MonsterID && !this.m_TaskMonstersKilled.ContainsKey(taskConditionInfo.id);
					if (flag)
					{
						this.m_TaskMonstersKilled.Add(taskConditionInfo.id, 0U);
					}
				}
			}
		}

		// Token: 0x0600A475 RID: 42101 RVA: 0x001C6FA8 File Offset: 0x001C51A8
		private bool _OnEntityDie(XEventArgs arg)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			bool result;
			if (syncMode)
			{
				result = true;
			}
			else
			{
				XRealDeadEventArgs xrealDeadEventArgs = arg as XRealDeadEventArgs;
				bool flag = xrealDeadEventArgs.TheDead.IsEnemy && this.m_TaskMonstersKilled.ContainsKey(xrealDeadEventArgs.TheDead.TypeID);
				if (flag)
				{
					Dictionary<uint, uint> taskMonstersKilled = this.m_TaskMonstersKilled;
					uint typeID = xrealDeadEventArgs.TheDead.TypeID;
					uint value = taskMonstersKilled[typeID] + 1U;
					taskMonstersKilled[typeID] = value;
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600A476 RID: 42102 RVA: 0x001C7028 File Offset: 0x001C5228
		private bool _OnTaskStateChanged(XEventArgs arg)
		{
			XTaskStatusChangeArgs xtaskStatusChangeArgs = arg as XTaskStatusChangeArgs;
			bool flag = xtaskStatusChangeArgs.status == TaskStatus.TaskStatus_Over;
			if (flag)
			{
				List<uint> list;
				bool flag2 = this.m_AppearNpcs.TryGetValue(xtaskStatusChangeArgs.id, out list);
				if (flag2)
				{
					for (int i = 0; i < list.Count; i++)
					{
						XSingleton<XEntityMgr>.singleton.CreateNpc(list[i], true);
					}
				}
				bool flag3 = this.m_DisappearNpcs.TryGetValue(xtaskStatusChangeArgs.id, out list);
				if (flag3)
				{
					for (int j = 0; j < list.Count; j++)
					{
						XSingleton<XEntityMgr>.singleton.DestroyNpc(list[j]);
					}
				}
			}
			return true;
		}

		// Token: 0x0600A477 RID: 42103 RVA: 0x001C70EC File Offset: 0x001C52EC
		public static NpcTaskState TaskStatus2TaskState(TaskStatus status)
		{
			NpcTaskState result;
			switch (status)
			{
			case TaskStatus.TaskStatus_CanTake:
				result = NpcTaskState.TaskBegin;
				break;
			case TaskStatus.TaskStatus_Taked:
				result = NpcTaskState.TaskInprocess;
				break;
			case TaskStatus.TaskStatus_Finish:
				result = NpcTaskState.TaskEnd;
				break;
			case TaskStatus.TaskStatus_Over:
				result = NpcTaskState.Normal;
				break;
			default:
				result = NpcTaskState.Invalid;
				break;
			}
			return result;
		}

		// Token: 0x0600A478 RID: 42104 RVA: 0x001C712C File Offset: 0x001C532C
		public static uint GetSceneID(ref SeqListRef<uint> sceneData)
		{
			return XSingleton<UiUtility>.singleton.ChooseProfData<uint>(ref sceneData, 0U, 0);
		}

		// Token: 0x0600A479 RID: 42105 RVA: 0x001C714C File Offset: 0x001C534C
		public static int SortByType(int type0, int type1)
		{
			return XTaskDocument.TypeSortValue[type0].CompareTo(XTaskDocument.TypeSortValue[type1]);
		}

		// Token: 0x0600A47A RID: 42106 RVA: 0x001C7178 File Offset: 0x001C5378
		public static int SortByNpcState(NpcTaskState state0, NpcTaskState state1)
		{
			return state0.CompareTo(state1);
		}

		// Token: 0x0600A47B RID: 42107 RVA: 0x001C71A0 File Offset: 0x001C53A0
		public static int SortInTaskList(XTaskInfo task0, XTaskInfo task1)
		{
			bool flag = task0 == null;
			int result;
			if (flag)
			{
				result = 1;
			}
			else
			{
				bool flag2 = task1 == null;
				if (flag2)
				{
					result = -1;
				}
				else
				{
					bool flag3 = XTaskDocument._HighestPriorityTask > 0U;
					if (flag3)
					{
						bool flag4 = task0.ID == task1.ID;
						if (flag4)
						{
							return 0;
						}
						bool flag5 = task0.ID == XTaskDocument._HighestPriorityTask;
						if (flag5)
						{
							return -1;
						}
						bool flag6 = task1.ID == XTaskDocument._HighestPriorityTask;
						if (flag6)
						{
							return 1;
						}
					}
					int num = XTaskDocument.SortByType((int)task0.TableData.TaskType, (int)task1.TableData.TaskType);
					bool flag7 = num == 0;
					if (flag7)
					{
						num = XTaskDocument.SortByNpcState(task0.NpcState, task1.NpcState);
					}
					bool flag8 = num == 0;
					if (flag8)
					{
						num = task0.ID.CompareTo(task1.ID);
					}
					result = num;
				}
			}
			return result;
		}

		// Token: 0x0600A47C RID: 42108 RVA: 0x001C7284 File Offset: 0x001C5484
		public static int SortInDialog(XTaskInfo task0, XTaskInfo task1)
		{
			bool flag = task0 == null;
			int result;
			if (flag)
			{
				result = 1;
			}
			else
			{
				bool flag2 = task1 == null;
				if (flag2)
				{
					result = -1;
				}
				else
				{
					bool flag3 = XTaskDocument._HighestPriorityTask > 0U;
					if (flag3)
					{
						bool flag4 = task0.ID == task1.ID;
						if (flag4)
						{
							return 0;
						}
						bool flag5 = task0.ID == XTaskDocument._HighestPriorityTask;
						if (flag5)
						{
							return -1;
						}
						bool flag6 = task0.ID == XTaskDocument._HighestPriorityTask;
						if (flag6)
						{
							return 1;
						}
					}
					int num = XTaskDocument.SortByNpcState(task0.NpcState, task1.NpcState);
					bool flag7 = num == 0;
					if (flag7)
					{
						num = XTaskDocument.SortByType((int)task0.TableData.TaskType, (int)task1.TableData.TaskType);
					}
					bool flag8 = num == 0;
					if (flag8)
					{
						num = task0.ID.CompareTo(task1.ID);
					}
					result = num;
				}
			}
			return result;
		}

		// Token: 0x0600A47D RID: 42109 RVA: 0x001C7366 File Offset: 0x001C5566
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.TaskRecord.InitFromServerData(arg.PlayerInfo.task_record);
			this._RefreshUI();
			this.SetupNpcHeadFx();
		}

		// Token: 0x0600A47E RID: 42110 RVA: 0x001C7390 File Offset: 0x001C5590
		public override void OnEnterScene()
		{
			base.OnEnterScene();
			this.SetupNpcHeadFx();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this._ResetTaskMonsters();
			}
			else
			{
				bool flag2 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World;
				if (flag2)
				{
					this._InitTaskMonsters();
				}
			}
		}

		// Token: 0x0600A47F RID: 42111 RVA: 0x001C73E8 File Offset: 0x001C55E8
		public override void OnLeaveScene()
		{
			this.ClearFx();
			this._ResetHighestPriorityTask(false);
			base.OnLeaveScene();
		}

		// Token: 0x0600A480 RID: 42112 RVA: 0x001C7404 File Offset: 0x001C5604
		public bool ShouldNpcExist(uint npcID)
		{
			XNpcInfo.RowData byNPCID = XSingleton<XEntityMgr>.singleton.NpcInfo.GetByNPCID(npcID);
			bool flag = byNPCID == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = byNPCID.DisappearTask != 0U && this.TaskRecord.IsTaskFinished(byNPCID.DisappearTask);
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = byNPCID.RequiredTaskID == 0U || this.TaskRecord.IsTaskFinished(byNPCID.RequiredTaskID);
					result = flag3;
				}
			}
			return result;
		}

		// Token: 0x04003BB2 RID: 15282
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("TaskDocument");

		// Token: 0x04003BB3 RID: 15283
		private string FX_TASK_BEGIN = "Effects/FX_Particle/Scene/Lzg_scene/rwts_01";

		// Token: 0x04003BB4 RID: 15284
		private string FX_TASK_INPROCESS = "Effects/FX_Particle/Scene/Lzg_scene/rwts_02";

		// Token: 0x04003BB5 RID: 15285
		private string FX_TASK_END = "Effects/FX_Particle/Scene/Lzg_scene/rwts_03";

		// Token: 0x04003BB6 RID: 15286
		private List<XFx> m_Fxes = new List<XFx>();

		// Token: 0x04003BB7 RID: 15287
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003BB8 RID: 15288
		private static TaskTableNew _TaskTable = new TaskTableNew();

		// Token: 0x04003BB9 RID: 15289
		private Dictionary<uint, List<uint>> m_AppearNpcs = new Dictionary<uint, List<uint>>();

		// Token: 0x04003BBA RID: 15290
		private Dictionary<uint, List<uint>> m_DisappearNpcs = new Dictionary<uint, List<uint>>();

		// Token: 0x04003BBB RID: 15291
		private XTaskRecord m_TaskRecord = new XTaskRecord();

		// Token: 0x04003BBD RID: 15293
		private static uint[] TypeSortValue = new uint[20];

		// Token: 0x04003BBE RID: 15294
		private string m_TempTarget;

		// Token: 0x04003BBF RID: 15295
		private uint[] m_TempNpcData;

		// Token: 0x04003BC0 RID: 15296
		private Dictionary<uint, XTaskInfo> m_TempNpcTopTask = new Dictionary<uint, XTaskInfo>();

		// Token: 0x04003BC1 RID: 15297
		private List<uint> m_TempTasks = new List<uint>();

		// Token: 0x04003BC2 RID: 15298
		private Dictionary<uint, uint> m_TaskMonstersKilled = new Dictionary<uint, uint>();

		// Token: 0x04003BC3 RID: 15299
		private int m_NaviTarget;

		// Token: 0x04003BC4 RID: 15300
		private uint m_NaviScene;

		// Token: 0x04003BC5 RID: 15301
		private uint m_NaviTask;

		// Token: 0x04003BC6 RID: 15302
		private static uint _HighestPriorityTask = 0U;
	}
}
