using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAncientDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XAncientDocument.uuID;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XAncientDocument.AsyncLoader.AddTask("Table/AncientTimesTable", XAncientDocument.ancientTable, false);
			XAncientDocument.AsyncLoader.AddTask("Table/AncientTask", XAncientDocument.ancientTask, false);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ActivityTaskUpdate, new XComponent.XEventHandler(this.OnTaskChange));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnAddVirtualItem));
		}

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

		public bool PointEnough(int pos)
		{
			SeqRef<uint> nPoints = XAncientDocument.ancientTable.Table[pos].nPoints;
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(this.itemid);
			return itemCount >= (ulong)nPoints[1];
		}

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

		public void ReqClaim(uint taskid)
		{
			int actid = XFastEnumIntEqualityComparer<ActivityType>.ToInt(ActivityType.BigPrize);
			RpcC2G_GetSpActivityReward rpcC2G_GetSpActivityReward = new RpcC2G_GetSpActivityReward();
			rpcC2G_GetSpActivityReward.oArg.taskid = taskid;
			rpcC2G_GetSpActivityReward.oArg.actid = (uint)actid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetSpActivityReward);
		}

		public void ResClaim()
		{
			this.RefreshAnicent();
			this.CheckRed();
		}

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

		private void RefreshAnicent()
		{
			bool flag = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible() && DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_bigPrizeHandler != null && DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_bigPrizeHandler.IsVisible();
			if (flag)
			{
				DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_bigPrizeHandler.RefreshList();
			}
		}

		public void ReqPoint(uint pos)
		{
			RpcC2G_GetAncientTimesAward rpcC2G_GetAncientTimesAward = new RpcC2G_GetAncientTimesAward();
			rpcC2G_GetAncientTimesAward.oArg.pos = pos;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetAncientTimesAward);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XBigPrizeDocument");

		private List<SuperActivityTask.RowData> list;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static AncientTimesTable ancientTable = new AncientTimesTable();

		public static AncientTask ancientTask = new AncientTask();

		private byte reward = 0;

		public bool[] state;

		private int itemid = 0;
	}
}
