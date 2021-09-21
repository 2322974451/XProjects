using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000928 RID: 2344
	internal class XCarnivalDocument : XDocComponent
	{
		// Token: 0x17002BB9 RID: 11193
		// (get) Token: 0x06008D87 RID: 36231 RVA: 0x001365AC File Offset: 0x001347AC
		public override uint ID
		{
			get
			{
				return XCarnivalDocument.uuID;
			}
		}

		// Token: 0x17002BBA RID: 11194
		// (get) Token: 0x06008D88 RID: 36232 RVA: 0x001365C4 File Offset: 0x001347C4
		public static SuperActivity activityTable
		{
			get
			{
				return XTempActivityDocument.SuperActivityTable;
			}
		}

		// Token: 0x17002BBB RID: 11195
		// (get) Token: 0x06008D89 RID: 36233 RVA: 0x001365DC File Offset: 0x001347DC
		public static SuperActivityTask activityListTable
		{
			get
			{
				return XTempActivityDocument.SuperActivityTaskTable;
			}
		}

		// Token: 0x17002BBC RID: 11196
		// (get) Token: 0x06008D8A RID: 36234 RVA: 0x001365F4 File Offset: 0x001347F4
		public static SuperActivityTime activityTimeTable
		{
			get
			{
				return XTempActivityDocument.SuperActivityTimeTable;
			}
		}

		// Token: 0x17002BBD RID: 11197
		// (get) Token: 0x06008D8B RID: 36235 RVA: 0x0013660C File Offset: 0x0013480C
		public SpActivity allServerActivity
		{
			get
			{
				return XTempActivityDocument.Doc.ActivityRecord;
			}
		}

		// Token: 0x06008D8C RID: 36236 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void Execute(OnLoadedCallback callback = null)
		{
		}

		// Token: 0x06008D8D RID: 36237 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008D8E RID: 36238 RVA: 0x00136628 File Offset: 0x00134828
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

		// Token: 0x06008D8F RID: 36239 RVA: 0x001367C4 File Offset: 0x001349C4
		public List<SpActivityNode> GetCurrList()
		{
			this.currCarnivals = this.GetTabList(this.currBelong, this.currType);
			return this.currCarnivals;
		}

		// Token: 0x06008D90 RID: 36240 RVA: 0x001367F4 File Offset: 0x001349F4
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

		// Token: 0x06008D91 RID: 36241 RVA: 0x00136930 File Offset: 0x00134B30
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

		// Token: 0x06008D92 RID: 36242 RVA: 0x00136A44 File Offset: 0x00134C44
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

		// Token: 0x06008D93 RID: 36243 RVA: 0x00136AA0 File Offset: 0x00134CA0
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

		// Token: 0x06008D94 RID: 36244 RVA: 0x00136AF8 File Offset: 0x00134CF8
		public bool IsOpen(int belong)
		{
			SuperActivity.RowData superActivity = this.GetSuperActivity(belong);
			return this.openDay >= superActivity.offset;
		}

		// Token: 0x06008D95 RID: 36245 RVA: 0x00136B24 File Offset: 0x00134D24
		public bool IsActivityExpire()
		{
			return this.openDay >= this.activityCloseDay;
		}

		// Token: 0x06008D96 RID: 36246 RVA: 0x00136B48 File Offset: 0x00134D48
		public bool IsActivityClosed()
		{
			return this.openDay >= this.claimCloseDay;
		}

		// Token: 0x06008D97 RID: 36247 RVA: 0x00136B6C File Offset: 0x00134D6C
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

		// Token: 0x06008D98 RID: 36248 RVA: 0x00136BD0 File Offset: 0x00134DD0
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

		// Token: 0x06008D99 RID: 36249 RVA: 0x00136C25 File Offset: 0x00134E25
		public void UpdateHallPoint(bool show)
		{
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetSystemRedPointState(XSysDefine.XSys_Carnival, show);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Carnival, true);
		}

		// Token: 0x06008D9A RID: 36250 RVA: 0x00136C44 File Offset: 0x00134E44
		public void OnSpActivityChange(SpActivityChange data)
		{
			bool flag = data.actid == 1U;
			if (flag)
			{
				DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.Refresh();
			}
		}

		// Token: 0x06008D9B RID: 36251 RVA: 0x00136C6C File Offset: 0x00134E6C
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

		// Token: 0x06008D9C RID: 36252 RVA: 0x00136D0C File Offset: 0x00134F0C
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

		// Token: 0x06008D9D RID: 36253 RVA: 0x00136D94 File Offset: 0x00134F94
		public void RequestClaim(uint taskid)
		{
			RpcC2G_GetSpActivityReward rpcC2G_GetSpActivityReward = new RpcC2G_GetSpActivityReward();
			rpcC2G_GetSpActivityReward.oArg.taskid = taskid;
			rpcC2G_GetSpActivityReward.oArg.actid = 1U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetSpActivityReward);
		}

		// Token: 0x06008D9E RID: 36254 RVA: 0x00136DCE File Offset: 0x00134FCE
		public void RespClaim(uint taskid)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CarnivalSuccess"), "fece00");
		}

		// Token: 0x06008D9F RID: 36255 RVA: 0x00136DEC File Offset: 0x00134FEC
		public void ExchangePoint()
		{
			RpcC2G_GetSpActivityBigPrize rpcC2G_GetSpActivityBigPrize = new RpcC2G_GetSpActivityBigPrize();
			rpcC2G_GetSpActivityBigPrize.oArg.actid = 1U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetSpActivityBigPrize);
		}

		// Token: 0x06008DA0 RID: 36256 RVA: 0x00136E1C File Offset: 0x0013501C
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

		// Token: 0x06008DA1 RID: 36257 RVA: 0x00136E6C File Offset: 0x0013506C
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

		// Token: 0x04002DEE RID: 11758
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XCarnivalDocument");

		// Token: 0x04002DEF RID: 11759
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002DF0 RID: 11760
		public int currBelong;

		// Token: 0x04002DF1 RID: 11761
		public int currType;

		// Token: 0x04002DF2 RID: 11762
		public const int currActID = 1;

		// Token: 0x04002DF3 RID: 11763
		public int pointItemID = 33;

		// Token: 0x04002DF4 RID: 11764
		public uint activityCloseDay = 7U;

		// Token: 0x04002DF5 RID: 11765
		public uint claimCloseDay = 14U;

		// Token: 0x04002DF6 RID: 11766
		public uint needPoint = 100U;

		// Token: 0x04002DF7 RID: 11767
		public uint openDay = 8U;

		// Token: 0x04002DF8 RID: 11768
		public float rate = 1f;

		// Token: 0x04002DF9 RID: 11769
		private int _curActID = -1;

		// Token: 0x04002DFA RID: 11770
		public List<SpActivity> carnivalServerActivity = new List<SpActivity>();

		// Token: 0x04002DFB RID: 11771
		private List<SpActivityNode> currCarnivals = new List<SpActivityNode>();

		// Token: 0x04002DFC RID: 11772
		private List<SpActivityNode> tmp = new List<SpActivityNode>();
	}
}
