using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDragonGuildTaskDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XDragonGuildTaskDocument.uuID;
			}
		}

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

		public static void Execute(OnLoadedCallback callback = null)
		{
			XDragonGuildTaskDocument.AsyncLoader.AddTask("Table/DragonGuildTask", XDragonGuildTaskDocument.m_dragontaskTab, false);
			XDragonGuildTaskDocument.AsyncLoader.AddTask("Table/DragonGuildAchieve", XDragonGuildTaskDocument.m_dragonachieveTab, false);
			XDragonGuildTaskDocument.AsyncLoader.Execute(callback);
		}

		public override void OnGamePause(bool pause)
		{
			base.OnGamePause(pause);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<XDragonGuildTaskView, XDragonGuildTaskBehaviour>.singleton != null && DlgBase<XDragonGuildTaskView, XDragonGuildTaskBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.ReqInfo();
			}
		}

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

		public void ReqInfo()
		{
			RpcC2M_GetDragonGuildTaskInfo rpc = new RpcC2M_GetDragonGuildTaskInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReqFetchAchieve(int id)
		{
			RpcC2G_GetDragonGuildTaskChest rpcC2G_GetDragonGuildTaskChest = new RpcC2G_GetDragonGuildTaskChest();
			rpcC2G_GetDragonGuildTaskChest.oArg.type = DragonGuildTaskType.TASK_ACHIVEMENT;
			rpcC2G_GetDragonGuildTaskChest.oArg.taskid = (uint)id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetDragonGuildTaskChest);
		}

		public void ReqFetchTask(int id)
		{
			RpcC2G_GetDragonGuildTaskChest rpcC2G_GetDragonGuildTaskChest = new RpcC2G_GetDragonGuildTaskChest();
			rpcC2G_GetDragonGuildTaskChest.oArg.type = DragonGuildTaskType.TASK_NORMAL;
			rpcC2G_GetDragonGuildTaskChest.oArg.taskid = (uint)id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetDragonGuildTaskChest);
		}

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

		public int AchieveSort(XDragonGuildTpl a, XDragonGuildTpl b)
		{
			int achieveSortNum = this.GetAchieveSortNum(a);
			int achieveSortNum2 = this.GetAchieveSortNum(b);
			return achieveSortNum2 - achieveSortNum;
		}

		public void OnFetchAchieve(uint id)
		{
			this.ReqInfo();
		}

		public void OnFetchTask(uint id)
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.OnTaskFetch(id);
			}
			XDragonGuildDocument.Doc.IsHadRecordRedPoint = (this.HadAchieveRedPoint() || this.HadTaskRedPoint());
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XDragonGuildTaskDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static DragonGuildAchieveTable m_dragonachieveTab = new DragonGuildAchieveTable();

		public static DragonGuildTaskTable m_dragontaskTab = new DragonGuildTaskTable();

		public List<XDragonGuildTpl> m_achievelist = new List<XDragonGuildTpl>();

		public List<XDragonGuildTpl> m_tasklist = new List<XDragonGuildTpl>();

		public string m_taskresettime;

		private XDragonGuildTaskView _view = null;
	}
}
