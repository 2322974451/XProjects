using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000A8E RID: 2702
	internal class XTaskRecord
	{
		// Token: 0x17002FC8 RID: 12232
		// (get) Token: 0x0600A449 RID: 42057 RVA: 0x001C5A6C File Offset: 0x001C3C6C
		public List<XTaskInfo> Tasks
		{
			get
			{
				return this.m_TaskList;
			}
		}

		// Token: 0x17002FC9 RID: 12233
		// (get) Token: 0x0600A44A RID: 42058 RVA: 0x001C5A84 File Offset: 0x001C3C84
		public XTaskInfo MainTask
		{
			get
			{
				return this.m_MainTask;
			}
		}

		// Token: 0x0600A44B RID: 42059 RVA: 0x001C5A9C File Offset: 0x001C3C9C
		public void InitFromServerData(RoleTask roleTask)
		{
			this.m_TaskList.Clear();
			this.m_FinishedTasks.Clear();
			bool flag = roleTask == null;
			if (!flag)
			{
				for (int i = 0; i < roleTask.tasks.Count; i++)
				{
					XTaskInfo xtaskInfo = new XTaskInfo();
					bool flag2 = xtaskInfo.Init(roleTask.tasks[i]);
					if (flag2)
					{
						this.m_TaskList.Add(xtaskInfo);
						this._UpdateMainTask(xtaskInfo);
					}
				}
				for (int j = 0; j < roleTask.finished.Count; j++)
				{
					this.m_FinishedTasks.Add(roleTask.finished[j]);
				}
				this.m_TaskList.Sort(new Comparison<XTaskInfo>(XTaskDocument.SortInTaskList));
			}
		}

		// Token: 0x0600A44C RID: 42060 RVA: 0x001C5B74 File Offset: 0x001C3D74
		public XTaskInfo AddTask(TaskInfo info)
		{
			XTaskInfo xtaskInfo = new XTaskInfo();
			bool flag = xtaskInfo.Init(info);
			if (flag)
			{
				this.m_TaskList.Add(xtaskInfo);
				this.m_TaskList.Sort(new Comparison<XTaskInfo>(XTaskDocument.SortInTaskList));
				this._UpdateMainTask(xtaskInfo);
			}
			else
			{
				xtaskInfo = null;
			}
			return xtaskInfo;
		}

		// Token: 0x0600A44D RID: 42061 RVA: 0x001C5BD0 File Offset: 0x001C3DD0
		public void FinishTask(uint taskid)
		{
			this.m_FinishedTasks.Add(taskid);
			bool flag = this.m_MainTask != null && this.m_MainTask.ID == taskid;
			if (flag)
			{
				this.m_MainTask = null;
			}
		}

		// Token: 0x0600A44E RID: 42062 RVA: 0x001C5C10 File Offset: 0x001C3E10
		public bool IsTaskFinished(uint taskid)
		{
			return this.m_FinishedTasks.Contains(taskid);
		}

		// Token: 0x0600A44F RID: 42063 RVA: 0x001C5C30 File Offset: 0x001C3E30
		private void _UpdateMainTask(XTaskInfo info)
		{
			bool flag = this.m_MainTask == null && info.TableData.TaskType == 1U;
			if (flag)
			{
				this.m_MainTask = info;
			}
		}

		// Token: 0x04003BAF RID: 15279
		private List<XTaskInfo> m_TaskList = new List<XTaskInfo>();

		// Token: 0x04003BB0 RID: 15280
		private HashSet<uint> m_FinishedTasks = new HashSet<uint>();

		// Token: 0x04003BB1 RID: 15281
		private XTaskInfo m_MainTask = null;
	}
}
