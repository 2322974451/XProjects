using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class WeekEndNestDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return WeekEndNestDocument.uuID;
			}
		}

		public static WeekEndNestDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(WeekEndNestDocument.uuID) as WeekEndNestDocument;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			WeekEndNestDocument.AsyncLoader.AddTask("Table/WeekEndNestActivity", WeekEndNestDocument.m_WeekEndNestTable, false);
			WeekEndNestDocument.AsyncLoader.Execute(callback);
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
			this.Clear();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		public uint LeftCount
		{
			get
			{
				return this.m_leftCount;
			}
		}

		public uint CanGetCount
		{
			get
			{
				return this.m_canGetCount;
			}
		}

		public uint GetStatus
		{
			get
			{
				return this.m_getStatue;
			}
		}

		public uint JoindTimes
		{
			get
			{
				return (this.MaxCount() - this.m_leftCount < 0U) ? 0U : (this.MaxCount() - this.m_leftCount);
			}
		}

		public bool NeedLoginShow
		{
			get
			{
				return this.m_bNeedLoginShow;
			}
			set
			{
				this.m_bNeedLoginShow = value;
			}
		}

		private void OnlineOpenSetTaskId()
		{
			bool flag = this.m_parentTaskId > 0U;
			if (!flag)
			{
				int serverOpenDay = XActivityDocument.Doc.ServerOpenDay;
				bool flag2 = WeekEndNestDocument.m_WeekEndNestTable == null;
				if (flag2)
				{
					this.m_parentTaskId = 0U;
				}
				else
				{
					for (int i = 0; i < WeekEndNestDocument.m_WeekEndNestTable.Table.Length; i++)
					{
						WeekEndNestActivity.RowData rowData = WeekEndNestDocument.m_WeekEndNestTable.Table[i];
						bool flag3 = (ulong)rowData.OpenSvrDay[0] <= (ulong)((long)serverOpenDay) && (ulong)rowData.OpenSvrDay[1] >= (ulong)((long)serverOpenDay);
						if (flag3)
						{
							this.m_parentTaskId = rowData.ParentTaskId;
							this.m_bNeedLoginShow = true;
							this.m_leftCount = this.MaxCount();
							DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_WeekEndNest, true);
							return;
						}
					}
					this.m_parentTaskId = 0U;
				}
			}
		}

		public void OfflineOpenSetTaskId()
		{
			SpActivityOne activity = XTempActivityDocument.Doc.GetActivity(this.m_actId);
			bool flag = activity == null;
			if (flag)
			{
				this.m_parentTaskId = 0U;
			}
			else
			{
				bool flag2 = this.m_parentTaskId == 0U;
				if (flag2)
				{
					this.m_bNeedLoginShow = true;
				}
				for (int i = 0; i < activity.task.Count; i++)
				{
					SuperActivityTask.RowData data = this.GetData(activity.task[i].taskid);
					bool flag3 = data != null && data.tasktype == 1U;
					if (flag3)
					{
						this.m_parentTaskId = data.taskid;
						int num = (int)(this.MaxCount() - XTempActivityDocument.Doc.GetActivityProgress(this.m_actId, this.m_parentTaskId));
						this.m_leftCount = (uint)((num > 0) ? num : 0);
						this.m_getStatue = XTempActivityDocument.Doc.GetActivityState(this.m_actId, this.m_parentTaskId);
						bool flag4 = data.taskson.Length != 0;
						if (flag4)
						{
							this.m_canGetCount = XTempActivityDocument.Doc.GetActivityProgress(this.m_actId, data.taskson[0]);
							this.m_canGetCount = ((this.m_canGetCount > this.m_leftCount) ? this.m_leftCount : this.m_canGetCount);
						}
						DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_WeekEndNest, true);
						return;
					}
				}
				this.m_parentTaskId = 0U;
			}
		}

		public List<SuperActivityTask.RowData> TaskList
		{
			get
			{
				bool flag = this.m_taskList == null;
				if (flag)
				{
					this.m_taskList = XTempActivityDocument.Doc.GetDataByActivityType(this.m_actId);
				}
				return this.m_taskList;
			}
		}

		private void Clear()
		{
			this.m_parentTaskId = 0U;
			this.m_bNeedLoginShow = false;
			this.m_getStatue = 0U;
		}

		private SuperActivityTask.RowData GetData(uint taskId)
		{
			for (int i = 0; i < this.TaskList.Count; i++)
			{
				bool flag = this.TaskList[i].taskid == taskId;
				if (flag)
				{
					return this.TaskList[i];
				}
			}
			return null;
		}

		private SuperActivityTask.RowData GetSonTask(uint parentTaskId)
		{
			SuperActivityTask.RowData data = this.GetData(parentTaskId);
			bool flag = data == null || data.taskson.Length == 0;
			SuperActivityTask.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				data = this.GetData(data.taskson[0]);
				result = data;
			}
			return result;
		}

		public int GetDnId()
		{
			SuperActivityTask.RowData sonTask = this.GetSonTask(this.m_parentTaskId);
			bool flag = sonTask == null || sonTask.num.Length == 0;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				result = (int)sonTask.num[0];
			}
			return result;
		}

		public string GetLevelName()
		{
			int dnId = this.GetDnId();
			bool flag = dnId == 0;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				XExpeditionDocument xexpeditionDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XExpeditionDocument.uuID) as XExpeditionDocument;
				ExpeditionTable.RowData expeditionDataByID = xexpeditionDocument.GetExpeditionDataByID(dnId);
				result = XExpeditionDocument.GetFullName(expeditionDataByID);
			}
			return result;
		}

		public string GetTexName()
		{
			WeekEndNestActivity.RowData byParentTaskId = WeekEndNestDocument.m_WeekEndNestTable.GetByParentTaskId(this.m_parentTaskId);
			bool flag = byParentTaskId == null;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				result = string.Format("{0}{1}", "atlas/UI/common/Pic/", byParentTaskId.BgTexName);
			}
			return result;
		}

		public uint MaxCount()
		{
			SuperActivityTask.RowData data = this.GetData(this.m_parentTaskId);
			bool flag = data == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				result = (uint)data.cnt;
			}
			return result;
		}

		public SeqListRef<uint> GetReward()
		{
			SuperActivityTask.RowData data = this.GetData(this.m_parentTaskId);
			bool flag = data == null;
			SeqListRef<uint> result;
			if (flag)
			{
				result = default(SeqListRef<uint>);
			}
			else
			{
				result = data.items;
			}
			return result;
		}

		public string GetRules()
		{
			return XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("WeekEndNestRule"));
		}

		public void ReqGetReward()
		{
			RpcC2G_GetSpActivityReward rpcC2G_GetSpActivityReward = new RpcC2G_GetSpActivityReward();
			rpcC2G_GetSpActivityReward.oArg.actid = this.m_actId;
			rpcC2G_GetSpActivityReward.oArg.taskid = this.m_parentTaskId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetSpActivityReward);
		}

		public void OnGetReward(GetSpActivityRewardRes oRes)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CarnivalSuccess"), "fece00");
		}

		public void TaskChangePtc(uint actId, uint taskId)
		{
			bool flag = this.m_actId != actId;
			if (!flag)
			{
				SuperActivityTask.RowData data = this.GetData(taskId);
				bool flag2 = data == null || data.tasktype != 1U;
				if (!flag2)
				{
					bool flag3 = taskId != this.m_parentTaskId;
					this.m_parentTaskId = taskId;
					int num = (int)(this.MaxCount() - XTempActivityDocument.Doc.GetActivityProgress(actId, this.m_parentTaskId));
					this.m_leftCount = (uint)((num > 0) ? num : 0);
					this.m_getStatue = XTempActivityDocument.Doc.GetActivityState(actId, this.m_parentTaskId);
					bool flag4 = data != null && data.taskson.Length != 0;
					if (flag4)
					{
						this.m_canGetCount = XTempActivityDocument.Doc.GetActivityProgress(actId, data.taskson[0]);
						this.m_canGetCount = ((this.m_canGetCount > this.m_leftCount) ? this.m_leftCount : this.m_canGetCount);
					}
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_WeekEndNest, true);
					bool flag5 = DlgBase<WeekEndNestDlg, WeekEndNestBehaviour>.singleton.IsVisible();
					if (flag5)
					{
						DlgBase<WeekEndNestDlg, WeekEndNestBehaviour>.singleton.Refresh();
					}
					bool flag6 = flag3;
					if (flag6)
					{
						bool flag7 = DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton.IsVisible();
						if (flag7)
						{
							bool flag8 = DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton.ActivityHandler != null && DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton.ActivityHandler.IsVisible();
							if (flag8)
							{
								DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton.ActivityHandler.RefreshMulActivity();
							}
						}
					}
				}
			}
		}

		public void OnSystemChanged(List<uint> openIds, List<uint> closedIds)
		{
			for (int i = 0; i < openIds.Count; i++)
			{
				bool flag = (ulong)openIds[i] == (ulong)((long)XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_WeekEndNest));
				if (flag)
				{
					this.OnlineOpenSetTaskId();
					return;
				}
			}
			for (int j = 0; j < closedIds.Count; j++)
			{
				bool flag2 = (ulong)closedIds[j] == (ulong)((long)XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_WeekEndNest));
				if (flag2)
				{
					this.Clear();
					bool flag3 = DlgBase<WeekEndNestDlg, WeekEndNestBehaviour>.singleton.IsVisible();
					if (flag3)
					{
						DlgBase<WeekEndNestDlg, WeekEndNestBehaviour>.singleton.SetVisible(false, true);
					}
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_WeekEndNest, true);
					break;
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("WeekEndNestDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static WeekEndNestActivity m_WeekEndNestTable = new WeekEndNestActivity();

		public readonly uint m_actId = 15U;

		private bool m_bNeedLoginShow = false;

		private uint m_parentTaskId = 0U;

		private uint m_leftCount = 0U;

		private uint m_canGetCount = 1U;

		private uint m_getStatue = 0U;

		private List<SuperActivityTask.RowData> m_taskList;
	}
}
