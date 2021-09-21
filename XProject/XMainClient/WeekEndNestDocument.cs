using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E8C RID: 3724
	internal class WeekEndNestDocument : XDocComponent
	{
		// Token: 0x170034A5 RID: 13477
		// (get) Token: 0x0600C6D7 RID: 50903 RVA: 0x002C0A00 File Offset: 0x002BEC00
		public override uint ID
		{
			get
			{
				return WeekEndNestDocument.uuID;
			}
		}

		// Token: 0x170034A6 RID: 13478
		// (get) Token: 0x0600C6D8 RID: 50904 RVA: 0x002C0A18 File Offset: 0x002BEC18
		public static WeekEndNestDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(WeekEndNestDocument.uuID) as WeekEndNestDocument;
			}
		}

		// Token: 0x0600C6D9 RID: 50905 RVA: 0x002C0A43 File Offset: 0x002BEC43
		public static void Execute(OnLoadedCallback callback = null)
		{
			WeekEndNestDocument.AsyncLoader.AddTask("Table/WeekEndNestActivity", WeekEndNestDocument.m_WeekEndNestTable, false);
			WeekEndNestDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600C6DA RID: 50906 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600C6DB RID: 50907 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600C6DC RID: 50908 RVA: 0x002C0A68 File Offset: 0x002BEC68
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			this.Clear();
		}

		// Token: 0x0600C6DD RID: 50909 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600C6DE RID: 50910 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x170034A7 RID: 13479
		// (get) Token: 0x0600C6DF RID: 50911 RVA: 0x002C0A7C File Offset: 0x002BEC7C
		public uint LeftCount
		{
			get
			{
				return this.m_leftCount;
			}
		}

		// Token: 0x170034A8 RID: 13480
		// (get) Token: 0x0600C6E0 RID: 50912 RVA: 0x002C0A94 File Offset: 0x002BEC94
		public uint CanGetCount
		{
			get
			{
				return this.m_canGetCount;
			}
		}

		// Token: 0x170034A9 RID: 13481
		// (get) Token: 0x0600C6E1 RID: 50913 RVA: 0x002C0AAC File Offset: 0x002BECAC
		public uint GetStatus
		{
			get
			{
				return this.m_getStatue;
			}
		}

		// Token: 0x170034AA RID: 13482
		// (get) Token: 0x0600C6E2 RID: 50914 RVA: 0x002C0AC4 File Offset: 0x002BECC4
		public uint JoindTimes
		{
			get
			{
				return (this.MaxCount() - this.m_leftCount < 0U) ? 0U : (this.MaxCount() - this.m_leftCount);
			}
		}

		// Token: 0x170034AB RID: 13483
		// (get) Token: 0x0600C6E3 RID: 50915 RVA: 0x002C0AF8 File Offset: 0x002BECF8
		// (set) Token: 0x0600C6E4 RID: 50916 RVA: 0x002C0B10 File Offset: 0x002BED10
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

		// Token: 0x0600C6E5 RID: 50917 RVA: 0x002C0B1C File Offset: 0x002BED1C
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

		// Token: 0x0600C6E6 RID: 50918 RVA: 0x002C0BFC File Offset: 0x002BEDFC
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

		// Token: 0x170034AC RID: 13484
		// (get) Token: 0x0600C6E7 RID: 50919 RVA: 0x002C0D64 File Offset: 0x002BEF64
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

		// Token: 0x0600C6E8 RID: 50920 RVA: 0x002C0DA1 File Offset: 0x002BEFA1
		private void Clear()
		{
			this.m_parentTaskId = 0U;
			this.m_bNeedLoginShow = false;
			this.m_getStatue = 0U;
		}

		// Token: 0x0600C6E9 RID: 50921 RVA: 0x002C0DBC File Offset: 0x002BEFBC
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

		// Token: 0x0600C6EA RID: 50922 RVA: 0x002C0E14 File Offset: 0x002BF014
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

		// Token: 0x0600C6EB RID: 50923 RVA: 0x002C0E58 File Offset: 0x002BF058
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

		// Token: 0x0600C6EC RID: 50924 RVA: 0x002C0E98 File Offset: 0x002BF098
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

		// Token: 0x0600C6ED RID: 50925 RVA: 0x002C0EEC File Offset: 0x002BF0EC
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

		// Token: 0x0600C6EE RID: 50926 RVA: 0x002C0F34 File Offset: 0x002BF134
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

		// Token: 0x0600C6EF RID: 50927 RVA: 0x002C0F68 File Offset: 0x002BF168
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

		// Token: 0x0600C6F0 RID: 50928 RVA: 0x002C0FA4 File Offset: 0x002BF1A4
		public string GetRules()
		{
			return XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("WeekEndNestRule"));
		}

		// Token: 0x0600C6F1 RID: 50929 RVA: 0x002C0FD0 File Offset: 0x002BF1D0
		public void ReqGetReward()
		{
			RpcC2G_GetSpActivityReward rpcC2G_GetSpActivityReward = new RpcC2G_GetSpActivityReward();
			rpcC2G_GetSpActivityReward.oArg.actid = this.m_actId;
			rpcC2G_GetSpActivityReward.oArg.taskid = this.m_parentTaskId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetSpActivityReward);
		}

		// Token: 0x0600C6F2 RID: 50930 RVA: 0x002C1014 File Offset: 0x002BF214
		public void OnGetReward(GetSpActivityRewardRes oRes)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CarnivalSuccess"), "fece00");
		}

		// Token: 0x0600C6F3 RID: 50931 RVA: 0x002C1038 File Offset: 0x002BF238
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

		// Token: 0x0600C6F4 RID: 50932 RVA: 0x002C11A0 File Offset: 0x002BF3A0
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

		// Token: 0x0400573E RID: 22334
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("WeekEndNestDocument");

		// Token: 0x0400573F RID: 22335
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04005740 RID: 22336
		private static WeekEndNestActivity m_WeekEndNestTable = new WeekEndNestActivity();

		// Token: 0x04005741 RID: 22337
		public readonly uint m_actId = 15U;

		// Token: 0x04005742 RID: 22338
		private bool m_bNeedLoginShow = false;

		// Token: 0x04005743 RID: 22339
		private uint m_parentTaskId = 0U;

		// Token: 0x04005744 RID: 22340
		private uint m_leftCount = 0U;

		// Token: 0x04005745 RID: 22341
		private uint m_canGetCount = 1U;

		// Token: 0x04005746 RID: 22342
		private uint m_getStatue = 0U;

		// Token: 0x04005747 RID: 22343
		private List<SuperActivityTask.RowData> m_taskList;
	}
}
