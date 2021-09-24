using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCarnivalDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XCarnivalDocument.uuID;
			}
		}

		public static SuperActivity activityTable
		{
			get
			{
				return XTempActivityDocument.SuperActivityTable;
			}
		}

		public static SuperActivityTask activityListTable
		{
			get
			{
				return XTempActivityDocument.SuperActivityTaskTable;
			}
		}

		public static SuperActivityTime activityTimeTable
		{
			get
			{
				return XTempActivityDocument.SuperActivityTimeTable;
			}
		}

		public SpActivity allServerActivity
		{
			get
			{
				return XTempActivityDocument.Doc.ActivityRecord;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			for (int i = 0; i < XCarnivalDocument.activityTimeTable.Table.Length; i++)
			{
				bool flag = XCarnivalDocument.activityTimeTable.Table[i].actid == 1U;
				if (flag)
				{
					this.activityCloseDay = XCarnivalDocument.activityTimeTable.Table[i].duration;
					this.claimCloseDay = XCarnivalDocument.activityTimeTable.Table[i].duration + XCarnivalDocument.activityTimeTable.Table[i].rewardtime;
					this.needPoint = XCarnivalDocument.activityTimeTable.Table[i].needpoint;
					this.rate = XCarnivalDocument.activityTimeTable.Table[i].rate;
					this.pointItemID = (int)XCarnivalDocument.activityTimeTable.Table[i].pointid;
				}
			}
			bool flag2 = this.allServerActivity != null;
			if (flag2)
			{
				for (int j = 0; j < this.allServerActivity.spActivity.Count; j++)
				{
					bool flag3 = this.allServerActivity.spActivity[j].actid == 1U;
					if (flag3)
					{
						bool getBigPrize = this.allServerActivity.spActivity[j].getBigPrize;
						XSingleton<XAttributeMgr>.singleton.XPlayerData.CarnivalClaimed = getBigPrize;
						break;
					}
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddLog("allserver: " + (this.allServerActivity == null).ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
			}
			DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.RefreshHallRedp();
		}

		public List<SpActivityNode> GetCurrList()
		{
			this.currCarnivals = this.GetTabList(this.currBelong, this.currType);
			return this.currCarnivals;
		}

		public List<SpActivityNode> GetTabList(int belong, int type)
		{
			this.tmp.Clear();
			int num = XSingleton<XAttributeMgr>.singleton.BackFlowLevel();
			SuperActivityTask.RowData[] table = XCarnivalDocument.activityListTable.Table;
			uint[] taskListWithLevel = XTempActivityDocument.Doc.GetTaskListWithLevel(num);
			bool flag = taskListWithLevel == null;
			List<SpActivityNode> result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("OpenSeverActivity config error with level  " + num, null, null, null, null, null);
				result = this.tmp;
			}
			else
			{
				for (int i = 0; i < table.Length; i++)
				{
					bool flag2 = (ulong)table[i].belong == (ulong)((long)belong) && (ulong)table[i].type == (ulong)((long)type) && table[i].actid == 1U;
					if (flag2)
					{
						bool flag3 = false;
						for (int j = 0; j < taskListWithLevel.Length; j++)
						{
							bool flag4 = taskListWithLevel[j] == table[i].taskid;
							if (flag4)
							{
								flag3 = true;
								break;
							}
						}
						bool flag5 = flag3;
						if (flag5)
						{
							SpActivityNode spActivityNode = new SpActivityNode();
							spActivityNode.row = table[i];
							this.SetState(ref spActivityNode);
							this.tmp.Add(spActivityNode);
						}
					}
				}
				result = this.tmp;
			}
			return result;
		}

		public void SetState(ref SpActivityNode node)
		{
			bool flag = false;
			bool flag2 = this.allServerActivity != null;
			if (flag2)
			{
				for (int i = 0; i < this.allServerActivity.spActivity.Count; i++)
				{
					bool flag3 = this.allServerActivity.spActivity[i].actid == 1U;
					if (flag3)
					{
						List<SpActivityTask> task = this.allServerActivity.spActivity[i].task;
						for (int j = 0; j < task.Count; j++)
						{
							bool flag4 = task[j].taskid == node.row.taskid;
							if (flag4)
							{
								flag = true;
								node.state = task[j].state;
								node.progress = task[j].progress;
								break;
							}
						}
						break;
					}
				}
			}
			bool flag5 = !flag;
			if (flag5)
			{
				node.state = 0U;
				node.progress = 0U;
			}
		}

		public SuperActivity.RowData GetSuperActivity(int belong)
		{
			SuperActivity.RowData[] table = XCarnivalDocument.activityTable.Table;
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = (ulong)table[i].belong == (ulong)((long)belong) && table[i].actid == 1U;
				if (flag)
				{
					return table[i];
				}
			}
			return null;
		}

		public SuperActivityTask.RowData GetSuperActivityTask(uint taskid)
		{
			for (int i = 0; i < XCarnivalDocument.activityListTable.Table.Length; i++)
			{
				bool flag = XCarnivalDocument.activityListTable.Table[i].taskid == taskid;
				if (flag)
				{
					return XCarnivalDocument.activityListTable.Table[i];
				}
			}
			return null;
		}

		public bool IsOpen(int belong)
		{
			SuperActivity.RowData superActivity = this.GetSuperActivity(belong);
			return this.openDay >= superActivity.offset;
		}

		public bool IsActivityExpire()
		{
			return this.openDay >= this.activityCloseDay;
		}

		public bool IsActivityClosed()
		{
			return this.openDay >= this.claimCloseDay;
		}

		public bool HasRwdClaimed(int belong)
		{
			SuperActivity.RowData superActivity = this.GetSuperActivity(belong);
			bool flag = superActivity != null && superActivity.childs != null;
			if (flag)
			{
				int num = superActivity.childs.Length;
				for (int i = 0; i < num; i++)
				{
					bool flag2 = this.HasRwdClaimed(belong, i + 1);
					if (flag2)
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool HasRwdClaimed(int belong, int type)
		{
			this.GetTabList(belong, type);
			for (int i = 0; i < this.tmp.Count; i++)
			{
				bool flag = this.tmp[i].state == 1U;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public void UpdateHallPoint(bool show)
		{
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetSystemRedPointState(XSysDefine.XSys_Carnival, show);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Carnival, true);
		}

		public void OnSpActivityChange(SpActivityChange data)
		{
			bool flag = data.actid == 1U;
			if (flag)
			{
				DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.Refresh();
			}
		}

		public void RespInfo(int offday)
		{
			this.openDay = (uint)offday;
			bool flag = DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = (long)offday > (long)((ulong)this.claimCloseDay);
				if (flag2)
				{
					bool flag3 = DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.IsVisible();
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CarnivalTerminal"), "fece00");
						DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.SetVisible(false, true);
					}
					XPlayerAttributes xplayerAttributes = XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes;
					bool flag4 = xplayerAttributes != null;
					if (flag4)
					{
						xplayerAttributes.CloseSystem(67U);
					}
				}
			}
			DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.Refresh();
		}

		public void OnActivityStateChange(uint state)
		{
			bool flag = state == 1U;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog(XStringDefineProxy.GetString("CarnivalTerminal"), null, null, null, null, null, XDebugColor.XDebug_None);
				bool flag2 = DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.IsVisible();
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CarnivalTerminal"), "fece00");
					DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.SetVisible(false, true);
				}
				XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
				bool flag3 = xplayerData != null;
				if (flag3)
				{
					xplayerData.CloseSystem(67U);
				}
			}
		}

		public void RequestClaim(uint taskid)
		{
			RpcC2G_GetSpActivityReward rpcC2G_GetSpActivityReward = new RpcC2G_GetSpActivityReward();
			rpcC2G_GetSpActivityReward.oArg.taskid = taskid;
			rpcC2G_GetSpActivityReward.oArg.actid = 1U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetSpActivityReward);
		}

		public void RespClaim(uint taskid)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CarnivalSuccess"), "fece00");
		}

		public void ExchangePoint()
		{
			RpcC2G_GetSpActivityBigPrize rpcC2G_GetSpActivityBigPrize = new RpcC2G_GetSpActivityBigPrize();
			rpcC2G_GetSpActivityBigPrize.oArg.actid = 1U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetSpActivityBigPrize);
		}

		public void RespExchange()
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CarnivalSuccess"), "fece00");
			XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			bool flag = xplayerData != null;
			if (flag)
			{
				xplayerData.CarnivalClaimed = true;
			}
			DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.Refresh();
		}

		private int GetCurActID()
		{
			bool flag = this._curActID < 0;
			if (flag)
			{
				this._curActID = 1;
				int num = XSingleton<XAttributeMgr>.singleton.BackFlowLevel();
				bool flag2 = num >= 0;
				if (flag2)
				{
					SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("BackFlowLevel2ActID", true);
					for (int i = 0; i < (int)sequenceList.Count; i++)
					{
						bool flag3 = sequenceList[i, 0] == num;
						if (flag3)
						{
							this._curActID = sequenceList[i, 1];
							break;
						}
					}
				}
			}
			return this._curActID;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XCarnivalDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public int currBelong;

		public int currType;

		public const int currActID = 1;

		public int pointItemID = 33;

		public uint activityCloseDay = 7U;

		public uint claimCloseDay = 14U;

		public uint needPoint = 100U;

		public uint openDay = 8U;

		public float rate = 1f;

		private int _curActID = -1;

		public List<SpActivity> carnivalServerActivity = new List<SpActivity>();

		private List<SpActivityNode> currCarnivals = new List<SpActivityNode>();

		private List<SpActivityNode> tmp = new List<SpActivityNode>();
	}
}
