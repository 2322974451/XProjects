using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009E9 RID: 2537
	internal class XDailyActivitiesDocument : XDocComponent
	{
		// Token: 0x17002E29 RID: 11817
		// (get) Token: 0x06009B14 RID: 39700 RVA: 0x0018A3AC File Offset: 0x001885AC
		public override uint ID
		{
			get
			{
				return XDailyActivitiesDocument.uuID;
			}
		}

		// Token: 0x17002E2A RID: 11818
		// (get) Token: 0x06009B15 RID: 39701 RVA: 0x0018A3C4 File Offset: 0x001885C4
		// (set) Token: 0x06009B16 RID: 39702 RVA: 0x0018A3DC File Offset: 0x001885DC
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

		// Token: 0x17002E2B RID: 11819
		// (get) Token: 0x06009B17 RID: 39703 RVA: 0x0018A3E8 File Offset: 0x001885E8
		public List<XDailyActivity> ActivityList
		{
			get
			{
				return this._ActivityList;
			}
		}

		// Token: 0x17002E2C RID: 11820
		// (get) Token: 0x06009B18 RID: 39704 RVA: 0x0018A400 File Offset: 0x00188600
		public uint CurrentExp
		{
			get
			{
				return this._CurrentExp;
			}
		}

		// Token: 0x17002E2D RID: 11821
		// (get) Token: 0x06009B19 RID: 39705 RVA: 0x0018A418 File Offset: 0x00188618
		public uint WeekExp
		{
			get
			{
				return this._WeekExp;
			}
		}

		// Token: 0x06009B1A RID: 39706 RVA: 0x0018A430 File Offset: 0x00188630
		public static void Execute(OnLoadedCallback callback = null)
		{
			XDailyActivitiesDocument.AsyncLoader.AddTask("Table/ActivityChest", XDailyActivitiesDocument._ChestReader, false);
			XDailyActivitiesDocument.AsyncLoader.AddTask("Table/Activity", XDailyActivitiesDocument._ActivityReader, false);
			XDailyActivitiesDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009B1B RID: 39707 RVA: 0x0018A46C File Offset: 0x0018866C
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

		// Token: 0x06009B1C RID: 39708 RVA: 0x0018A4FC File Offset: 0x001886FC
		public void QueryDailyActivityData()
		{
			RpcC2G_GetActivityInfo rpc = new RpcC2G_GetActivityInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009B1D RID: 39709 RVA: 0x0018A51C File Offset: 0x0018871C
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

		// Token: 0x06009B1E RID: 39710 RVA: 0x0018A674 File Offset: 0x00188874
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

		// Token: 0x06009B1F RID: 39711 RVA: 0x0018A6D4 File Offset: 0x001888D4
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

		// Token: 0x06009B20 RID: 39712 RVA: 0x0018A720 File Offset: 0x00188920
		public int GetTotalActivityNum()
		{
			return this._ActivityList.Count;
		}

		// Token: 0x06009B21 RID: 39713 RVA: 0x0018A740 File Offset: 0x00188940
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

		// Token: 0x06009B22 RID: 39714 RVA: 0x0018A790 File Offset: 0x00188990
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

		// Token: 0x06009B23 RID: 39715 RVA: 0x0018A7E8 File Offset: 0x001889E8
		public void DealWithBuyReply()
		{
			bool flag = DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton._livenessActivityHandler != null && DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton._livenessActivityHandler.IsVisible();
			if (flag)
			{
				DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton._livenessActivityHandler.InitView(false);
			}
		}

		// Token: 0x06009B24 RID: 39716 RVA: 0x0018A82C File Offset: 0x00188A2C
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

		// Token: 0x06009B25 RID: 39717 RVA: 0x0018A8F0 File Offset: 0x00188AF0
		public bool IsChestOpend(uint index)
		{
			uint num = 1U << (int)index;
			return (this._ChestsInfo & num) > 0U;
		}

		// Token: 0x06009B26 RID: 39718 RVA: 0x0018A914 File Offset: 0x00188B14
		public void ReqFetchChest(uint id)
		{
			RpcC2G_GetActivityChest rpcC2G_GetActivityChest = new RpcC2G_GetActivityChest();
			rpcC2G_GetActivityChest.oArg.ChestIndex = id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetActivityChest);
		}

		// Token: 0x06009B27 RID: 39719 RVA: 0x0018A944 File Offset: 0x00188B44
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

		// Token: 0x06009B28 RID: 39720 RVA: 0x0018A998 File Offset: 0x00188B98
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

		// Token: 0x06009B29 RID: 39721 RVA: 0x0018AA84 File Offset: 0x00188C84
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

		// Token: 0x06009B2A RID: 39722 RVA: 0x0018AADC File Offset: 0x00188CDC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton._livenessActivityHandler != null && DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton._livenessActivityHandler.IsVisible();
			if (flag)
			{
				this.QueryDailyActivityData();
			}
		}

		// Token: 0x0400358A RID: 13706
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("DailyActivitiesDocument");

		// Token: 0x0400358B RID: 13707
		private XDailyActivitiesView _view = null;

		// Token: 0x0400358C RID: 13708
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x0400358D RID: 13709
		private static ActivityChestTable _ChestReader = new ActivityChestTable();

		// Token: 0x0400358E RID: 13710
		private static ActivityTable _ActivityReader = new ActivityTable();

		// Token: 0x0400358F RID: 13711
		private List<XDailyActivity> _ActivityList = new List<XDailyActivity>();

		// Token: 0x04003590 RID: 13712
		public uint _CurrentExp = 0U;

		// Token: 0x04003591 RID: 13713
		public uint _WeekExp = 0U;

		// Token: 0x04003592 RID: 13714
		private uint _ChestsInfo = 0U;

		// Token: 0x04003593 RID: 13715
		public List<uint> ChestExps = new List<uint>();

		// Token: 0x04003594 RID: 13716
		public List<uint> WeekExps = new List<uint>();

		// Token: 0x04003595 RID: 13717
		public List<string> SpriteName = new List<string>();

		// Token: 0x04003596 RID: 13718
		public SeqListRef<uint> Reward = default(SeqListRef<uint>);

		// Token: 0x04003597 RID: 13719
		public int ChestCount;

		// Token: 0x04003598 RID: 13720
		public uint MaxExp;

		// Token: 0x04003599 RID: 13721
		public int SeverRedPointNotify = 0;
	}
}
