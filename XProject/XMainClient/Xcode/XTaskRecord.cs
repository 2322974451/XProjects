using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{

	internal class XTaskRecord
	{

		public List<XTaskInfo> Tasks
		{
			get
			{
				return this.m_TaskList;
			}
		}

		public XTaskInfo MainTask
		{
			get
			{
				return this.m_MainTask;
			}
		}

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

		public void FinishTask(uint taskid)
		{
			this.m_FinishedTasks.Add(taskid);
			bool flag = this.m_MainTask != null && this.m_MainTask.ID == taskid;
			if (flag)
			{
				this.m_MainTask = null;
			}
		}

		public bool IsTaskFinished(uint taskid)
		{
			return this.m_FinishedTasks.Contains(taskid);
		}

		private void _UpdateMainTask(XTaskInfo info)
		{
			bool flag = this.m_MainTask == null && info.TableData.TaskType == 1U;
			if (flag)
			{
				this.m_MainTask = info;
			}
		}

		private List<XTaskInfo> m_TaskList = new List<XTaskInfo>();

		private HashSet<uint> m_FinishedTasks = new HashSet<uint>();

		private XTaskInfo m_MainTask = null;
	}
}
