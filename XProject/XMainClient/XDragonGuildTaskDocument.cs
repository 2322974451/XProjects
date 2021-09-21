using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000907 RID: 2311
	internal class XDragonGuildTaskDocument : XDocComponent
	{
		// Token: 0x17002B63 RID: 11107
		// (get) Token: 0x06008BB4 RID: 35764 RVA: 0x0012BF0C File Offset: 0x0012A10C
		public override uint ID
		{
			get
			{
				return XDragonGuildTaskDocument.uuID;
			}
		}

		// Token: 0x17002B64 RID: 11108
		// (get) Token: 0x06008BB5 RID: 35765 RVA: 0x0012BF24 File Offset: 0x0012A124
		// (set) Token: 0x06008BB6 RID: 35766 RVA: 0x0012BF3C File Offset: 0x0012A13C
		public XDragonGuildTaskView View
		{
			get
			{
				return this._view;
			}
			set
			{
				this._view = value;
			}
		}

		// Token: 0x06008BB7 RID: 35767 RVA: 0x0012BF46 File Offset: 0x0012A146
		public static void Execute(OnLoadedCallback callback = null)
		{
			XDragonGuildTaskDocument.AsyncLoader.AddTask("Table/DragonGuildTask", XDragonGuildTaskDocument.m_dragontaskTab, false);
			XDragonGuildTaskDocument.AsyncLoader.AddTask("Table/DragonGuildAchieve", XDragonGuildTaskDocument.m_dragonachieveTab, false);
			XDragonGuildTaskDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008BB8 RID: 35768 RVA: 0x0012BF81 File Offset: 0x0012A181
		public override void OnGamePause(bool pause)
		{
			base.OnGamePause(pause);
		}

		// Token: 0x06008BB9 RID: 35769 RVA: 0x0012BF8C File Offset: 0x0012A18C
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<XDragonGuildTaskView, XDragonGuildTaskBehaviour>.singleton != null && DlgBase<XDragonGuildTaskView, XDragonGuildTaskBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.ReqInfo();
			}
		}

		// Token: 0x06008BBA RID: 35770 RVA: 0x0012BFBC File Offset: 0x0012A1BC
		public bool HadTaskRedPoint()
		{
			bool result = false;
			for (int i = 0; i < this.m_tasklist.Count; i++)
			{
				bool flag = this.m_tasklist[i].state == 2;
				if (flag)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x06008BBB RID: 35771 RVA: 0x0012C00C File Offset: 0x0012A20C
		public bool HadAchieveRedPoint()
		{
			bool result = false;
			for (int i = 0; i < this.m_achievelist.Count; i++)
			{
				bool flag = this.m_achievelist[i].state == 2;
				if (flag)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x06008BBC RID: 35772 RVA: 0x0012C05C File Offset: 0x0012A25C
		private DragonGuildTaskTable.RowData GetTaskById(uint id)
		{
			for (int i = 0; i < XDragonGuildTaskDocument.m_dragontaskTab.Table.Length; i++)
			{
				bool flag = XDragonGuildTaskDocument.m_dragontaskTab.Table[i].taskID == id;
				if (flag)
				{
					return XDragonGuildTaskDocument.m_dragontaskTab.Table[i];
				}
			}
			return null;
		}

		// Token: 0x06008BBD RID: 35773 RVA: 0x0012C0B4 File Offset: 0x0012A2B4
		private DragonGuildAchieveTable.RowData GetAchieveById(uint id)
		{
			for (int i = 0; i < XDragonGuildTaskDocument.m_dragonachieveTab.Table.Length; i++)
			{
				bool flag = XDragonGuildTaskDocument.m_dragonachieveTab.Table[i].ID == id;
				if (flag)
				{
					return XDragonGuildTaskDocument.m_dragonachieveTab.Table[i];
				}
			}
			return null;
		}

		// Token: 0x06008BBE RID: 35774 RVA: 0x0012C10C File Offset: 0x0012A30C
		public XDragonGuildTpl GetDataByindex(int index, uint state)
		{
			bool flag = state == 1U;
			XDragonGuildTpl result;
			if (flag)
			{
				result = this.m_tasklist[index];
			}
			else
			{
				bool flag2 = state == 2U;
				if (flag2)
				{
					result = this.m_achievelist[index];
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("DragonGuildTask state is error", null, null, null, null, null);
					result = null;
				}
			}
			return result;
		}

		// Token: 0x06008BBF RID: 35775 RVA: 0x0012C164 File Offset: 0x0012A364
		public void ReqInfo()
		{
			RpcC2M_GetDragonGuildTaskInfo rpc = new RpcC2M_GetDragonGuildTaskInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008BC0 RID: 35776 RVA: 0x0012C184 File Offset: 0x0012A384
		public void ReqFetchAchieve(int id)
		{
			RpcC2G_GetDragonGuildTaskChest rpcC2G_GetDragonGuildTaskChest = new RpcC2G_GetDragonGuildTaskChest();
			rpcC2G_GetDragonGuildTaskChest.oArg.type = DragonGuildTaskType.TASK_ACHIVEMENT;
			rpcC2G_GetDragonGuildTaskChest.oArg.taskid = (uint)id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetDragonGuildTaskChest);
		}

		// Token: 0x06008BC1 RID: 35777 RVA: 0x0012C1C0 File Offset: 0x0012A3C0
		public void ReqFetchTask(int id)
		{
			RpcC2G_GetDragonGuildTaskChest rpcC2G_GetDragonGuildTaskChest = new RpcC2G_GetDragonGuildTaskChest();
			rpcC2G_GetDragonGuildTaskChest.oArg.type = DragonGuildTaskType.TASK_NORMAL;
			rpcC2G_GetDragonGuildTaskChest.oArg.taskid = (uint)id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetDragonGuildTaskChest);
		}

		// Token: 0x06008BC2 RID: 35778 RVA: 0x0012C1FC File Offset: 0x0012A3FC
		public void OnGetInfo(GetDragonGuildTaskInfoRes oRes)
		{
			this.m_achievelist.Clear();
			this.m_tasklist.Clear();
			this.m_taskresettime = oRes.task_refreshtime;
			for (int i = 0; i < oRes.taskrecord.Count; i++)
			{
				DragonGuildTaskInfo dragonGuildTaskInfo = oRes.taskrecord[i];
				XDragonGuildTpl xdragonGuildTpl = new XDragonGuildTpl();
				DragonGuildTaskTable.RowData taskById = this.GetTaskById(dragonGuildTaskInfo.taskID);
				xdragonGuildTpl.id = dragonGuildTaskInfo.taskID;
				xdragonGuildTpl.title = taskById.name;
				xdragonGuildTpl.desc = "";
				xdragonGuildTpl.exp = taskById.guildExp;
				xdragonGuildTpl.type = taskById.taskType;
				xdragonGuildTpl.item = taskById.viewabledrop;
				xdragonGuildTpl.finishCount = taskById.count;
				xdragonGuildTpl.doingCount = dragonGuildTaskInfo.finishCount;
				xdragonGuildTpl.state = 1;
				bool flag = xdragonGuildTpl.finishCount <= xdragonGuildTpl.doingCount && xdragonGuildTpl.type != 3U;
				if (flag)
				{
					xdragonGuildTpl.state = 2;
				}
				bool flag2 = xdragonGuildTpl.type == 3U && xdragonGuildTpl.doingCount > 0U;
				if (flag2)
				{
					xdragonGuildTpl.state = 2;
				}
				bool flag3 = oRes.taskcompleted[i];
				if (flag3)
				{
					xdragonGuildTpl.state = 3;
				}
				this.m_tasklist.Add(xdragonGuildTpl);
			}
			for (int j = 0; j < oRes.achiverecord.Count; j++)
			{
				DragonGuildTaskInfo dragonGuildTaskInfo2 = oRes.achiverecord[j];
				XDragonGuildTpl xdragonGuildTpl2 = new XDragonGuildTpl();
				DragonGuildAchieveTable.RowData achieveById = this.GetAchieveById(dragonGuildTaskInfo2.taskID);
				xdragonGuildTpl2.id = dragonGuildTaskInfo2.taskID;
				xdragonGuildTpl2.title = achieveById.name;
				xdragonGuildTpl2.desc = achieveById.description;
				xdragonGuildTpl2.exp = achieveById.guildExp;
				xdragonGuildTpl2.type = achieveById.Type;
				xdragonGuildTpl2.item = achieveById.viewabledrop;
				xdragonGuildTpl2.lefttime = achieveById.chestCount - dragonGuildTaskInfo2.receiveCount;
				xdragonGuildTpl2.finishCount = achieveById.count;
				xdragonGuildTpl2.doingCount = dragonGuildTaskInfo2.finishCount;
				xdragonGuildTpl2.state = 1;
				bool flag4 = xdragonGuildTpl2.doingCount == xdragonGuildTpl2.finishCount && xdragonGuildTpl2.type != 3U;
				if (flag4)
				{
					xdragonGuildTpl2.state = 2;
				}
				bool flag5 = xdragonGuildTpl2.type == 3U && xdragonGuildTpl2.doingCount > 0U;
				if (flag5)
				{
					xdragonGuildTpl2.state = 2;
				}
				bool flag6 = xdragonGuildTpl2.lefttime == 0U;
				if (flag6)
				{
					xdragonGuildTpl2.state = 4;
				}
				bool flag7 = oRes.achivecompleted[j];
				if (flag7)
				{
					xdragonGuildTpl2.state = 3;
				}
				this.m_achievelist.Add(xdragonGuildTpl2);
			}
			this.m_achievelist.Sort(new Comparison<XDragonGuildTpl>(this.AchieveSort));
			XDragonGuildDocument.Doc.IsHadRecordRedPoint = (this.HadAchieveRedPoint() || this.HadTaskRedPoint());
			bool flag8 = this.View != null && this.View.IsVisible();
			if (flag8)
			{
				this.View.RefreshUI();
			}
		}

		// Token: 0x06008BC3 RID: 35779 RVA: 0x0012C518 File Offset: 0x0012A718
		private int GetAchieveSortNum(XDragonGuildTpl a)
		{
			bool flag = a.state == 2;
			int result;
			if (flag)
			{
				result = 4;
			}
			else
			{
				bool flag2 = a.state == 1;
				if (flag2)
				{
					result = 3;
				}
				else
				{
					bool flag3 = a.state == 4;
					if (flag3)
					{
						result = 2;
					}
					else
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x06008BC4 RID: 35780 RVA: 0x0012C560 File Offset: 0x0012A760
		public int AchieveSort(XDragonGuildTpl a, XDragonGuildTpl b)
		{
			int achieveSortNum = this.GetAchieveSortNum(a);
			int achieveSortNum2 = this.GetAchieveSortNum(b);
			return achieveSortNum2 - achieveSortNum;
		}

		// Token: 0x06008BC5 RID: 35781 RVA: 0x0012C585 File Offset: 0x0012A785
		public void OnFetchAchieve(uint id)
		{
			this.ReqInfo();
		}

		// Token: 0x06008BC6 RID: 35782 RVA: 0x0012C590 File Offset: 0x0012A790
		public void OnFetchTask(uint id)
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.OnTaskFetch(id);
			}
			XDragonGuildDocument.Doc.IsHadRecordRedPoint = (this.HadAchieveRedPoint() || this.HadTaskRedPoint());
		}

		// Token: 0x04002CC1 RID: 11457
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XDragonGuildTaskDocument");

		// Token: 0x04002CC2 RID: 11458
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002CC3 RID: 11459
		public static DragonGuildAchieveTable m_dragonachieveTab = new DragonGuildAchieveTable();

		// Token: 0x04002CC4 RID: 11460
		public static DragonGuildTaskTable m_dragontaskTab = new DragonGuildTaskTable();

		// Token: 0x04002CC5 RID: 11461
		public List<XDragonGuildTpl> m_achievelist = new List<XDragonGuildTpl>();

		// Token: 0x04002CC6 RID: 11462
		public List<XDragonGuildTpl> m_tasklist = new List<XDragonGuildTpl>();

		// Token: 0x04002CC7 RID: 11463
		public string m_taskresettime;

		// Token: 0x04002CC8 RID: 11464
		private XDragonGuildTaskView _view = null;
	}
}
