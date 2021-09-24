using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDailyActivitiesDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XDailyActivitiesDocument.uuID;
			}
		}

		public XDailyActivitiesView View
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

		public List<XDailyActivity> ActivityList
		{
			get
			{
				return this._ActivityList;
			}
		}

		public uint CurrentExp
		{
			get
			{
				return this._CurrentExp;
			}
		}

		public uint WeekExp
		{
			get
			{
				return this._WeekExp;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XDailyActivitiesDocument.AsyncLoader.AddTask("Table/ActivityChest", XDailyActivitiesDocument._ChestReader, false);
			XDailyActivitiesDocument.AsyncLoader.AddTask("Table/Activity", XDailyActivitiesDocument._ActivityReader, false);
			XDailyActivitiesDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._ActivityList.Clear();
			this.ChestExps = XSingleton<XGlobalConfig>.singleton.GetUIntList("ActivityChestExp");
			this.SpriteName = XSingleton<XGlobalConfig>.singleton.GetStringList("ActivityChestSpriteName");
			this.ChestCount = this.ChestExps.Count;
			this.MaxExp = this.ChestExps[this.ChestExps.Count - 1];
			this.WeekExps = XSingleton<XGlobalConfig>.singleton.GetUIntList("ActivityChestExpWeekly");
		}

		public void QueryDailyActivityData()
		{
			RpcC2G_GetActivityInfo rpc = new RpcC2G_GetActivityInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void GetDailyActivityData(ActivityRecord data)
		{
			this._ChestsInfo = data.ChestGetInfo;
			this._CurrentExp = data.ActivityAllValue;
			this._WeekExp = data.activityWeekValue;
			this._ActivityList.Clear();
			for (int i = 0; i < data.ActivityId.Count; i++)
			{
				ActivityTable.RowData activityBasicInfo = this.GetActivityBasicInfo(data.ActivityId[i]);
				XDailyActivity xdailyActivity = new XDailyActivity();
				xdailyActivity.id = data.ActivityId[i];
				xdailyActivity.currentCount = data.FinishCount[i];
				xdailyActivity.requiredCount = data.NeedFinishCount[i];
				xdailyActivity.finish = (xdailyActivity.currentCount == xdailyActivity.requiredCount);
				xdailyActivity.random = (activityBasicInfo.random > 0U);
				xdailyActivity.sysID = activityBasicInfo.id;
				this._ActivityList.Add(xdailyActivity);
			}
			this._ActivityList.Sort(new Comparison<XDailyActivity>(XDailyActivitiesDocument.CompareActivityList));
			bool flag = this.View != null && this.View.active;
			if (flag)
			{
				this.View.RefreshPage();
			}
			bool flag2 = DlgBase<XBriefLevelupView, XBriefLevelupBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<XBriefLevelupView, XBriefLevelupBehaviour>.singleton.FillContent();
			}
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Reward_Activity, true);
		}

		private static int CompareActivityList(XDailyActivity act1, XDailyActivity act2)
		{
			bool flag = act1.finish != act2.finish;
			int result;
			if (flag)
			{
				result = (act1.finish ? 1 : -1);
			}
			else
			{
				bool flag2 = act1.random != act2.random;
				if (flag2)
				{
					result = (act1.random ? -1 : 1);
				}
				else
				{
					result = 0;
				}
			}
			return result;
		}

		public bool IsFinishedAllActivity()
		{
			for (int i = 0; i < this._ActivityList.Count; i++)
			{
				bool flag = !this._ActivityList[i].finish;
				if (flag)
				{
					return false;
				}
			}
			return true;
		}

		public int GetTotalActivityNum()
		{
			return this._ActivityList.Count;
		}

		public int GetFinishedActivityNum()
		{
			int num = 0;
			for (int i = 0; i < this._ActivityList.Count; i++)
			{
				bool flag = !this._ActivityList[i].finish;
				if (flag)
				{
					num++;
				}
			}
			return num;
		}

		public ActivityTable.RowData GetActivityBasicInfo(uint sortid)
		{
			for (int i = 0; i < XDailyActivitiesDocument._ActivityReader.Table.Length; i++)
			{
				bool flag = sortid == XDailyActivitiesDocument._ActivityReader.Table[i].sortid;
				if (flag)
				{
					return XDailyActivitiesDocument._ActivityReader.Table[i];
				}
			}
			return null;
		}

		public void DealWithBuyReply()
		{
			bool flag = DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton._livenessActivityHandler != null && DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton._livenessActivityHandler.IsVisible();
			if (flag)
			{
				DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton._livenessActivityHandler.InitView(false);
			}
		}

		public void GetChestReward(uint chestid)
		{
			uint num = chestid + 1U;
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			for (int i = 0; i < XDailyActivitiesDocument._ChestReader.Table.Length; i++)
			{
				ActivityChestTable.RowData rowData = XDailyActivitiesDocument._ChestReader.Table[i];
				bool flag = rowData.chest != num;
				if (!flag)
				{
					bool flag2 = rowData.level[0] <= level && rowData.level[1] >= level;
					if (flag2)
					{
						this.Reward = rowData.viewabledrop;
						return;
					}
				}
			}
			XSingleton<XDebug>.singleton.AddErrorLog("Can't Find This Player's ActivityChest,chest id = ", num.ToString(), "  level = ", level.ToString(), null, null);
		}

		public bool IsChestOpend(uint index)
		{
			uint num = 1U << (int)index;
			return (this._ChestsInfo & num) > 0U;
		}

		public void ReqFetchChest(uint id)
		{
			RpcC2G_GetActivityChest rpcC2G_GetActivityChest = new RpcC2G_GetActivityChest();
			rpcC2G_GetActivityChest.oArg.ChestIndex = id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetActivityChest);
		}

		public void OnFetchChest(uint chestID, uint chestInfo, List<uint> itemID, List<uint> itemCount)
		{
			this._ChestsInfo = chestInfo;
			bool flag = this.View != null && this.View.active;
			if (flag)
			{
				this.View.OnChestFetched(chestID);
			}
			this.SeverRedPointNotify = 0;
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Reward_Activity, true);
		}

		public bool HasCanFetchReward()
		{
			bool flag = this.SeverRedPointNotify != 0;
			bool result;
			if (flag)
			{
				bool flag2 = this.SeverRedPointNotify > 0;
				if (flag2)
				{
					this.SeverRedPointNotify = 0;
					result = true;
				}
				else
				{
					this.SeverRedPointNotify = 0;
					result = false;
				}
			}
			else
			{
				for (int i = 0; i < this.ChestCount; i++)
				{
					bool flag3 = !this.IsChestOpend((uint)i) && this.CurrentExp >= this.ChestExps[i];
					if (flag3)
					{
						return true;
					}
				}
				for (int j = 0; j < this.WeekExps.Count; j++)
				{
					bool flag4 = !this.IsChestOpend((uint)(this.ChestCount + j)) && this.WeekExp >= this.WeekExps[j];
					if (flag4)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		public uint FindNeed2ShowReward()
		{
			bool flag = this.CurrentExp >= this.MaxExp;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				for (int i = 0; i < this.ChestCount; i++)
				{
					bool flag2 = !this.IsChestOpend((uint)i);
					if (flag2)
					{
						return (uint)i;
					}
				}
				result = 0U;
			}
			return result;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton._livenessActivityHandler != null && DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton._livenessActivityHandler.IsVisible();
			if (flag)
			{
				this.QueryDailyActivityData();
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("DailyActivitiesDocument");

		private XDailyActivitiesView _view = null;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static ActivityChestTable _ChestReader = new ActivityChestTable();

		private static ActivityTable _ActivityReader = new ActivityTable();

		private List<XDailyActivity> _ActivityList = new List<XDailyActivity>();

		public uint _CurrentExp = 0U;

		public uint _WeekExp = 0U;

		private uint _ChestsInfo = 0U;

		public List<uint> ChestExps = new List<uint>();

		public List<uint> WeekExps = new List<uint>();

		public List<string> SpriteName = new List<string>();

		public SeqListRef<uint> Reward = default(SeqListRef<uint>);

		public int ChestCount;

		public uint MaxExp;

		public int SeverRedPointNotify = 0;
	}
}
