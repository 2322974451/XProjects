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

	internal class XTaskDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XTaskDocument.uuID;
			}
		}

		public XTaskRecord TaskRecord
		{
			get
			{
				return this.m_TaskRecord;
			}
		}

		public uint CurrentSelect { get; set; }

		public Dictionary<uint, uint> TaskMonstersKilled
		{
			get
			{
				return this.m_TaskMonstersKilled;
			}
		}

		public int NaviTarget
		{
			get
			{
				return this.m_NaviTarget;
			}
		}

		public uint NaviScene
		{
			get
			{
				return this.m_NaviScene;
			}
		}

		public uint NaviTask
		{
			get
			{
				return this.m_NaviTask;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XTaskDocument.AsyncLoader.AddTask("Table/TaskListNew", XTaskDocument._TaskTable, false);
			XTaskDocument.AsyncLoader.Execute(callback);
		}

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

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_RealDead, new XComponent.XEventHandler(this._OnEntityDie));
			base.RegisterEvent(XEventDefine.XEvent_TaskStateChange, new XComponent.XEventHandler(this._OnTaskStateChanged));
			base.RegisterEvent(XEventDefine.XEvent_NpcFavorFxChange, new XComponent.XEventHandler(this._NotifyXTaskDocFx));
		}

		public static TaskTableNew.RowData GetTaskData(uint taskID)
		{
			return XTaskDocument._TaskTable.GetByTaskID(taskID);
		}

		public void ResetNavi()
		{
			this.m_NaviScene = 0U;
			this.m_NaviTarget = 0;
		}

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

		public void SetHighestPriorityTask(uint taskID)
		{
			XTaskDocument._HighestPriorityTask = taskID;
			this._OnHighestPriorityTaskChanged(true);
		}

		private void _ResetHighestPriorityTask(bool bUpdateUI)
		{
			bool flag = XTaskDocument._HighestPriorityTask > 0U;
			if (flag)
			{
				XTaskDocument._HighestPriorityTask = 0U;
				this._OnHighestPriorityTaskChanged(bUpdateUI);
			}
		}

		private void _OnHighestPriorityTaskChanged(bool bUpdateUI)
		{
			this.TaskRecord.Tasks.Sort(new Comparison<XTaskInfo>(XTaskDocument.SortInTaskList));
			if (bUpdateUI)
			{
				this._RefreshUI();
				this.SetupNpcHeadFx();
			}
		}

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

		private bool _NotifyXTaskDocFx(XEventArgs e)
		{
			this.SetupNpcHeadFx();
			return true;
		}

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

		protected void ClearFx()
		{
			for (int i = 0; i < this.m_Fxes.Count; i++)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_Fxes[i], true);
			}
			this.m_Fxes.Clear();
		}

		private void _ResetTaskMonsters()
		{
			this.m_TaskMonstersKilled.Clear();
		}

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

		public static uint GetSceneID(ref SeqListRef<uint> sceneData)
		{
			return XSingleton<UiUtility>.singleton.ChooseProfData<uint>(ref sceneData, 0U, 0);
		}

		public static int SortByType(int type0, int type1)
		{
			return XTaskDocument.TypeSortValue[type0].CompareTo(XTaskDocument.TypeSortValue[type1]);
		}

		public static int SortByNpcState(NpcTaskState state0, NpcTaskState state1)
		{
			return state0.CompareTo(state1);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.TaskRecord.InitFromServerData(arg.PlayerInfo.task_record);
			this._RefreshUI();
			this.SetupNpcHeadFx();
		}

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

		public override void OnLeaveScene()
		{
			this.ClearFx();
			this._ResetHighestPriorityTask(false);
			base.OnLeaveScene();
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("TaskDocument");

		private string FX_TASK_BEGIN = "Effects/FX_Particle/Scene/Lzg_scene/rwts_01";

		private string FX_TASK_INPROCESS = "Effects/FX_Particle/Scene/Lzg_scene/rwts_02";

		private string FX_TASK_END = "Effects/FX_Particle/Scene/Lzg_scene/rwts_03";

		private List<XFx> m_Fxes = new List<XFx>();

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static TaskTableNew _TaskTable = new TaskTableNew();

		private Dictionary<uint, List<uint>> m_AppearNpcs = new Dictionary<uint, List<uint>>();

		private Dictionary<uint, List<uint>> m_DisappearNpcs = new Dictionary<uint, List<uint>>();

		private XTaskRecord m_TaskRecord = new XTaskRecord();

		private static uint[] TypeSortValue = new uint[20];

		private string m_TempTarget;

		private uint[] m_TempNpcData;

		private Dictionary<uint, XTaskInfo> m_TempNpcTopTask = new Dictionary<uint, XTaskInfo>();

		private List<uint> m_TempTasks = new List<uint>();

		private Dictionary<uint, uint> m_TaskMonstersKilled = new Dictionary<uint, uint>();

		private int m_NaviTarget;

		private uint m_NaviScene;

		private uint m_NaviTask;

		private static uint _HighestPriorityTask = 0U;
	}
}
