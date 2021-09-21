using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008F5 RID: 2293
	internal class XAncientDocument : XDocComponent
	{
		// Token: 0x17002B24 RID: 11044
		// (get) Token: 0x06008ABA RID: 35514 RVA: 0x00127578 File Offset: 0x00125778
		public override uint ID
		{
			get
			{
				return XAncientDocument.uuID;
			}
		}

		// Token: 0x06008ABB RID: 35515 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008ABC RID: 35516 RVA: 0x0012758F File Offset: 0x0012578F
		public static void Execute(OnLoadedCallback callback = null)
		{
			XAncientDocument.AsyncLoader.AddTask("Table/AncientTimesTable", XAncientDocument.ancientTable, false);
			XAncientDocument.AsyncLoader.AddTask("Table/AncientTask", XAncientDocument.ancientTask, false);
		}

		// Token: 0x06008ABD RID: 35517 RVA: 0x001275BE File Offset: 0x001257BE
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ActivityTaskUpdate, new XComponent.XEventHandler(this.OnTaskChange));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnAddVirtualItem));
		}

		// Token: 0x06008ABE RID: 35518 RVA: 0x001275F8 File Offset: 0x001257F8
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			int aType = XFastEnumIntEqualityComparer<ActivityType>.ToInt(ActivityType.BigPrize);
			bool flag = this.list == null;
			if (flag)
			{
				this.list = XTempActivityDocument.Doc.GetDataByActivityType((uint)aType);
			}
			bool flag2 = this.itemid == 0;
			if (flag2)
			{
				this.itemid = XSingleton<XGlobalConfig>.singleton.GetInt("BigPrizeItemid");
			}
			this.RecultState();
			this.CheckRed();
		}

		// Token: 0x06008ABF RID: 35519 RVA: 0x00127668 File Offset: 0x00125868
		protected bool OnAddVirtualItem(XEventArgs args)
		{
			XVirtualItemChangedEventArgs xvirtualItemChangedEventArgs = args as XVirtualItemChangedEventArgs;
			bool flag = xvirtualItemChangedEventArgs.itemID == this.itemid;
			if (flag)
			{
				this.CheckRed();
			}
			return true;
		}

		// Token: 0x06008AC0 RID: 35520 RVA: 0x001276A0 File Offset: 0x001258A0
		public bool PointEnough(int pos)
		{
			SeqRef<uint> nPoints = XAncientDocument.ancientTable.Table[pos].nPoints;
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(this.itemid);
			return itemCount >= (ulong)nPoints[1];
		}

		// Token: 0x06008AC1 RID: 35521 RVA: 0x001276E4 File Offset: 0x001258E4
		public List<BigPrizeNode> GetSortTask()
		{
			List<BigPrizeNode> list = new List<BigPrizeNode>();
			int actid = XFastEnumIntEqualityComparer<ActivityType>.ToInt(ActivityType.BigPrize);
			bool flag = this.list != null;
			if (flag)
			{
				int i = 0;
				int count = this.list.Count;
				while (i < count)
				{
					BigPrizeNode bigPrizeNode = default(BigPrizeNode);
					bigPrizeNode.row = this.list[i];
					bigPrizeNode.state = XTempActivityDocument.Doc.GetActivityState((uint)actid, this.list[i].taskid);
					bigPrizeNode.sort = (int)bigPrizeNode.state;
					bool flag2 = bigPrizeNode.sort == 2;
					if (flag2)
					{
						bigPrizeNode.sort = -1;
					}
					bigPrizeNode.progress = XTempActivityDocument.Doc.GetActivityProgress((uint)actid, this.list[i].taskid);
					bigPrizeNode.taskid = this.list[i].taskid;
					list.Add(bigPrizeNode);
					i++;
				}
			}
			list.Sort(new Comparison<BigPrizeNode>(this.Sort));
			return list;
		}

		// Token: 0x06008AC2 RID: 35522 RVA: 0x001277FC File Offset: 0x001259FC
		private int Sort(BigPrizeNode x, BigPrizeNode y)
		{
			bool flag = x.sort != y.sort;
			int result;
			if (flag)
			{
				result = y.sort - x.sort;
			}
			else
			{
				result = (int)(x.row.taskid - y.row.taskid);
			}
			return result;
		}

		// Token: 0x06008AC3 RID: 35523 RVA: 0x0012784C File Offset: 0x00125A4C
		private void RecultState()
		{
			int num = XFastEnumIntEqualityComparer<ActivityType>.ToInt(ActivityType.BigPrize);
			int num2 = XAncientDocument.ancientTable.Table.Length;
			this.state = new bool[num2];
			SpActivity activityRecord = XTempActivityDocument.Doc.ActivityRecord;
			List<SpActivityOne> spActivity = activityRecord.spActivity;
			bool flag = this.reward == 0;
			if (flag)
			{
				int i = 0;
				int count = spActivity.Count;
				while (i < count)
				{
					bool flag2 = spActivity[i].actid == (uint)num;
					if (flag2)
					{
						AncientTimes ancient = spActivity[i].ancient;
						bool flag3 = this.reward == 0 && ancient != null;
						if (flag3)
						{
							this.reward = (byte)ancient.award;
						}
						break;
					}
					i++;
				}
			}
			for (int j = 1; j <= num2; j++)
			{
				int num3 = this.reward >> j & 1;
				this.state[j - 1] = (num3 == 1);
			}
		}

		// Token: 0x06008AC4 RID: 35524 RVA: 0x00127948 File Offset: 0x00125B48
		private bool OnTaskChange(XEventArgs e)
		{
			XActivityTaskUpdatedArgs xactivityTaskUpdatedArgs = e as XActivityTaskUpdatedArgs;
			uint xActID = xactivityTaskUpdatedArgs.xActID;
			uint xTaskID = xactivityTaskUpdatedArgs.xTaskID;
			uint xState = xactivityTaskUpdatedArgs.xState;
			uint xProgress = xactivityTaskUpdatedArgs.xProgress;
			this.RefreshAnicent();
			return true;
		}

		// Token: 0x06008AC5 RID: 35525 RVA: 0x00127988 File Offset: 0x00125B88
		public void ReqClaim(uint taskid)
		{
			int actid = XFastEnumIntEqualityComparer<ActivityType>.ToInt(ActivityType.BigPrize);
			RpcC2G_GetSpActivityReward rpcC2G_GetSpActivityReward = new RpcC2G_GetSpActivityReward();
			rpcC2G_GetSpActivityReward.oArg.taskid = taskid;
			rpcC2G_GetSpActivityReward.oArg.actid = (uint)actid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetSpActivityReward);
		}

		// Token: 0x06008AC6 RID: 35526 RVA: 0x001279CA File Offset: 0x00125BCA
		public void ResClaim()
		{
			this.RefreshAnicent();
			this.CheckRed();
		}

		// Token: 0x06008AC7 RID: 35527 RVA: 0x001279DC File Offset: 0x00125BDC
		public void CheckRed()
		{
			XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_Shanggu, this.HasRed());
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Shanggu, true);
			bool flag = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.RefreshRedpoint();
			}
		}

		// Token: 0x06008AC8 RID: 35528 RVA: 0x00127A2C File Offset: 0x00125C2C
		private bool HasRed()
		{
			bool flag = false;
			bool flag2 = this.state != null;
			if (flag2)
			{
				int i = 0;
				int num = 5;
				while (i < num)
				{
					bool flag3 = !this.state[i] && this.PointEnough(i);
					bool flag4 = flag3;
					if (flag4)
					{
						flag = true;
					}
					i++;
				}
			}
			int actid = XFastEnumIntEqualityComparer<ActivityType>.ToInt(ActivityType.BigPrize);
			bool flag5 = !flag && this.list != null;
			if (flag5)
			{
				int j = 0;
				int count = this.list.Count;
				while (j < count)
				{
					uint activityState = XTempActivityDocument.Doc.GetActivityState((uint)actid, this.list[j].taskid);
					bool flag6 = activityState == 1U;
					if (flag6)
					{
						flag = true;
						break;
					}
					j++;
				}
			}
			return flag;
		}

		// Token: 0x06008AC9 RID: 35529 RVA: 0x00127B04 File Offset: 0x00125D04
		private void RefreshAnicent()
		{
			bool flag = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible() && DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_bigPrizeHandler != null && DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_bigPrizeHandler.IsVisible();
			if (flag)
			{
				DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_bigPrizeHandler.RefreshList();
			}
		}

		// Token: 0x06008ACA RID: 35530 RVA: 0x00127B54 File Offset: 0x00125D54
		public void ReqPoint(uint pos)
		{
			RpcC2G_GetAncientTimesAward rpcC2G_GetAncientTimesAward = new RpcC2G_GetAncientTimesAward();
			rpcC2G_GetAncientTimesAward.oArg.pos = pos;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetAncientTimesAward);
		}

		// Token: 0x06008ACB RID: 35531 RVA: 0x00127B84 File Offset: 0x00125D84
		public void ResPoint(uint reward)
		{
			this.reward = (byte)reward;
			this.RecultState();
			this.CheckRed();
			bool flag = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible() && DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_bigPrizeHandler != null && DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_bigPrizeHandler.IsVisible();
			if (flag)
			{
				DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_bigPrizeHandler.RefreshChest();
			}
			bool flag2 = DlgBase<AncientBox, AnicientBoxBahaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<AncientBox, AnicientBoxBahaviour>.singleton.SetVisible(false, true);
			}
		}

		// Token: 0x04002C34 RID: 11316
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XBigPrizeDocument");

		// Token: 0x04002C35 RID: 11317
		private List<SuperActivityTask.RowData> list;

		// Token: 0x04002C36 RID: 11318
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002C37 RID: 11319
		public static AncientTimesTable ancientTable = new AncientTimesTable();

		// Token: 0x04002C38 RID: 11320
		public static AncientTask ancientTask = new AncientTask();

		// Token: 0x04002C39 RID: 11321
		private byte reward = 0;

		// Token: 0x04002C3A RID: 11322
		public bool[] state;

		// Token: 0x04002C3B RID: 11323
		private int itemid = 0;
	}
}
