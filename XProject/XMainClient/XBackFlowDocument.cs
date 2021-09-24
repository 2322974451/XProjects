using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBackFlowDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XBackFlowDocument.uuID;
			}
		}

		public static BackflowShop BackflowShopTable
		{
			get
			{
				return XBackFlowDocument._backflowShopTable;
			}
		}

		public static XBackFlowDocument Doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XBackFlowDocument>(XBackFlowDocument.uuID);
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XBackFlowDocument.AsyncLoader.AddTask("Table/BackflowActivity", XBackFlowDocument._backflowActivity, false);
			XBackFlowDocument.AsyncLoader.AddTask("Table/BackFlowShop", XBackFlowDocument._backflowShopTable, false);
			XBackFlowDocument.AsyncLoader.AddTask("Table/WorldLevelExpBuff", XBackFlowDocument._worldLevelTable, false);
			XBackFlowDocument.AsyncLoader.Execute(callback);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ActivityTaskUpdate, new XComponent.XEventHandler(this.OnActivityUpdate));
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.FirstShowBackFlowDlg = false;
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = this.FirstShowBackFlowDlg && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.SetVisible(true, true);
			}
		}

		public List<uint> GetBackflowDataByTypeAndWorldLevel(uint type)
		{
			List<uint> list = new List<uint>();
			BackflowActivity.RowData[] table = XBackFlowDocument._backflowActivity.Table;
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = table[i].Type == type && table[i].WorldLevel[0] <= this._curWorldLevel && table[i].WorldLevel[1] >= this._curWorldLevel;
				if (flag)
				{
					list.Add(table[i].Point);
				}
			}
			return list;
		}

		public BackFlowShopData BackflowShopData
		{
			get
			{
				return this._backflowShopData;
			}
		}

		public uint ShopLeftTime
		{
			get
			{
				return this._shopLeftTime;
			}
		}

		public List<uint> RewardedTargetIDList
		{
			get
			{
				return this._rewardedTargetIDList;
			}
		}

		public uint TargetPoint
		{
			get
			{
				return this._point;
			}
			set
			{
				this._point = value;
			}
		}

		public List<ZoneRoleInfo> ServerRoleList
		{
			get
			{
				return this._serverRoleList;
			}
		}

		public ulong SelectedRoleID
		{
			get
			{
				return this._SelectedRoleID;
			}
		}

		public bool CanSelectRole
		{
			get
			{
				return this._hasSelectRole;
			}
		}

		public bool IsPayReturnOpen
		{
			get
			{
				return this._isPayReturnOpen;
			}
		}

		public uint TotalPay
		{
			get
			{
				return this._totalPay;
			}
		}

		public uint DragonLeftTimes
		{
			get
			{
				return this._dragonLeftTimes;
			}
		}

		public uint NestLeftTimes
		{
			get
			{
				return this._nestLeftTimes;
			}
		}

		public uint GetBannerTaskID()
		{
			BackFlowData backFlowData = null;
			SpActivity activityRecord = XTempActivityDocument.Doc.ActivityRecord;
			for (int i = 0; i < activityRecord.spActivity.Count; i++)
			{
				bool flag = activityRecord.spActivity[i].actid == 5U;
				if (flag)
				{
					backFlowData = activityRecord.spActivity[i].backflow;
					break;
				}
			}
			bool flag2 = backFlowData != null;
			if (flag2)
			{
				uint sealType = XLevelSealDocument.Doc.SealType;
				BackflowActivity.RowData[] table = XBackFlowDocument._backflowActivity.Table;
				for (int j = 0; j < table.Length; j++)
				{
					bool flag3 = table[j].Type == 3U && table[j].WorldLevel[0] <= backFlowData.worldlevel && table[j].WorldLevel[1] >= backFlowData.worldlevel;
					if (flag3)
					{
						return table[j].TaskId;
					}
				}
			}
			return 0U;
		}

		public void AttachPandoraRedPoint(int sysID)
		{
			int sys = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.Xsys_Backflow);
			bool flag = sysID != 0;
			if (flag)
			{
				XSingleton<XGameSysMgr>.singleton.AttachSysRedPointRelative(sys, sysID, false);
			}
		}

		public uint GetLevelUpDegree()
		{
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			uint result = level;
			WorldLevelExpBuff.RowData[] table = XBackFlowDocument._worldLevelTable.Table;
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = table[i].WorldLevel == this._curWorldLevel && level >= table[i].Level[0] && level <= table[i].Level[1];
				if (flag)
				{
					result = table[i].BackflowLevel;
					break;
				}
			}
			return result;
		}

		public void InitBackflowData()
		{
			this._backflowTaskList.Clear();
			SpActivity activityRecord = XTempActivityDocument.Doc.ActivityRecord;
			bool flag = activityRecord != null;
			if (flag)
			{
				for (int i = 0; i < activityRecord.spActivity.Count; i++)
				{
					bool flag2 = activityRecord.spActivity[i].actid == 5U;
					if (flag2)
					{
						List<SpActivityTask> task = activityRecord.spActivity[i].task;
						for (int j = 0; j < task.Count; j++)
						{
							for (int k = 0; k < XBackFlowDocument._backflowActivity.Table.Length; k++)
							{
								bool flag3 = XBackFlowDocument._backflowActivity.Table[k].TaskId == task[j].taskid && XBackFlowDocument._backflowActivity.Table[k].Type == 2U;
								if (flag3)
								{
									this._backflowTaskList.Add(task[j]);
								}
							}
						}
						BackFlowData backflow = activityRecord.spActivity[i].backflow;
						bool flag4 = backflow != null;
						if (flag4)
						{
							this._point = backflow.point;
							this._rewardedTargetIDList = backflow.alreadyGet;
						}
					}
				}
				this._backflowTaskList.Sort(new Comparison<SpActivityTask>(this.SortBackFlowTaskList));
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.Xsys_Backflow, true);
			}
		}

		public List<uint> GetServerList()
		{
			return new List<uint>(this._serverIDToRoleList.Keys);
		}

		public List<SpActivityTask> GetBackflowTaskList()
		{
			return this._backflowTaskList;
		}

		public void StopRefreshLeftTime()
		{
			bool flag = this._leftTimeToken > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._leftTimeToken);
			}
			this._leftTimeToken = 0U;
		}

		public List<ulong> GetRoleListByServerid(uint serverID)
		{
			bool flag = this._serverIDToRoleList.ContainsKey(serverID);
			List<ulong> result;
			if (flag)
			{
				result = this._serverIDToRoleList[serverID];
			}
			else
			{
				result = new List<ulong>();
			}
			return result;
		}

		public void StartRefreshLeftTime()
		{
			bool flag = this._leftTimeToken > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._leftTimeToken);
			}
			this._leftTimeToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.MinusBackFlowLeftTime), 1);
		}

		public void SendBackFlowActivityOperation(BackFlowActOp v, uint itemID = 0U)
		{
			RpcC2G_BackFlowActivityOperation rpcC2G_BackFlowActivityOperation = new RpcC2G_BackFlowActivityOperation();
			rpcC2G_BackFlowActivityOperation.oArg.arg = itemID;
			rpcC2G_BackFlowActivityOperation.oArg.type = v;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_BackFlowActivityOperation);
		}

		public void OnGetBackFlowOperation(BackFlowActivityOperationArg oArg, BackFlowActivityOperationRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				bool flag2 = oRes.errorcode == ErrorCode.ERR_BACKFLOWSHOP_SHOPCLOSE;
				if (flag2)
				{
					bool flag3 = DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.IsVisible();
					if (flag3)
					{
						DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.RefreshTabs(XSysDefine.XSys_None);
					}
				}
			}
			else
			{
				bool flag4 = oArg.type == BackFlowActOp.BackFlowAct_TreasureData;
				if (flag4)
				{
					this._point = oRes.point;
					this._rewardedTargetIDList = oRes.alreadyGet;
					this._dragonLeftTimes = oRes.leftSmallDragonCount;
					this._nestLeftTimes = oRes.leftNestCount;
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.Xsys_Backflow_Target, true);
				}
				bool flag5 = oArg.type == BackFlowActOp.BackFlowAct_GetTreasure;
				if (flag5)
				{
					this._point = oRes.point;
					this._rewardedTargetIDList = oRes.alreadyGet;
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.Xsys_Backflow_Target, true);
					bool flag6 = DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.IsVisible();
					if (flag6)
					{
						DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.RefreshTabRedPoint(XSysDefine.Xsys_Backflow_Target, this.GetRedPointState(XSysDefine.Xsys_Backflow_Target));
					}
				}
				bool flag7 = oArg.type == BackFlowActOp.BackFlowAct_ShopData || oArg.type == BackFlowActOp.BackFlowAct_ShopUpdate || oArg.type == BackFlowActOp.BackFlowAct_ShopBuy;
				if (flag7)
				{
					this._backflowShopData = oRes.shop;
					this._shopLeftTime = oRes.shopLeftTime;
				}
				this._backflowLeftTime = oRes.activityLeftTime;
				bool flag8 = DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.IsVisible();
				if (flag8)
				{
					DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.RefreshHandler();
					this.StartRefreshLeftTime();
				}
			}
		}

		public void OnGetReward(GetSpActivityRewardArg oArg, GetSpActivityRewardRes oRes)
		{
			bool flag = oArg.taskid == this.GetBannerTaskID();
			if (flag)
			{
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.Xsys_Backflow_LavishGift, true);
				bool flag2 = DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.RefreshHandler();
					DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.RefreshTabRedPoint(XSysDefine.Xsys_Backflow_LavishGift, this.GetRedPointState(XSysDefine.Xsys_Backflow_LavishGift));
				}
			}
		}

		public void SendToGetNewZoneBenefit()
		{
			RpcC2G_GetNewZoneBenefit rpc = new RpcC2G_GetNewZoneBenefit();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetNewZoneBenefit(GetNewZoneBenefitRes oRes)
		{
			this._serverRoleList = oRes.roles;
			this._SelectedRoleID = oRes.select_roleid;
			this._hasSelectRole = oRes.has_select;
			this._isPayReturnOpen = oRes.is_open;
			this._totalPay = oRes.total_paycnt;
			this._serverIDToRoleList.Clear();
			for (int i = 0; i < this._serverRoleList.Count; i++)
			{
				uint serverid = this._serverRoleList[i].serverid;
				bool flag = !this._serverIDToRoleList.ContainsKey(serverid);
				if (flag)
				{
					this._serverIDToRoleList.Add(serverid, new List<ulong>());
				}
				bool flag2 = this._serverRoleList[i].roleid > 0UL;
				if (flag2)
				{
					this._serverIDToRoleList[serverid].Add(this._serverRoleList[i].roleid);
				}
			}
			bool flag3 = DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.IsVisible();
			if (flag3)
			{
				DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.RefreshHandler();
			}
		}

		public void SendToSelectRoleServer(ulong selectRoleID)
		{
			this._userSelectedRoleID = selectRoleID;
			RpcC2G_SelectChargeBackRole rpcC2G_SelectChargeBackRole = new RpcC2G_SelectChargeBackRole();
			rpcC2G_SelectChargeBackRole.oArg.roleid = selectRoleID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SelectChargeBackRole);
		}

		public void OnGetSelectRoleReply()
		{
			this._SelectedRoleID = this._userSelectedRoleID;
			this._userSelectedRoleID = 0UL;
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("BackFlowSelectRoleSuccess"), "fece00");
			bool flag = DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.RefreshHandler();
			}
		}

		public bool GetRedPointState(XSysDefine xSysDefine)
		{
			switch (xSysDefine)
			{
			case XSysDefine.Xsys_Backflow_LavishGift:
			{
				uint bannerTaskID = this.GetBannerTaskID();
				bool flag = bannerTaskID > 0U;
				if (flag)
				{
					SpActivityTask activityTaskInfo = XTempActivityDocument.Doc.GetActivityTaskInfo(5U, bannerTaskID);
					bool flag2 = activityTaskInfo != null;
					if (flag2)
					{
						bool flag3 = activityTaskInfo.state == 1U;
						if (flag3)
						{
							return true;
						}
					}
				}
				return false;
			}
			case XSysDefine.Xsys_Backflow_NewServerReward:
				return false;
			case XSysDefine.Xsys_Backflow_LevelUp:
				return false;
			case XSysDefine.Xsys_Backflow_Task:
				for (int i = 0; i < this._backflowTaskList.Count; i++)
				{
					bool flag4 = this._backflowTaskList[i].state == 1U;
					if (flag4)
					{
						return true;
					}
				}
				return false;
			case XSysDefine.Xsys_Backflow_Target:
			{
				SeqList<int> sequence3List = XSingleton<XGlobalConfig>.singleton.GetSequence3List("BackFlowTreasure", true);
				for (int j = 0; j < (int)sequence3List.Count; j++)
				{
					int num = sequence3List[j, 0];
					bool flag5 = !this._rewardedTargetIDList.Contains((uint)j) && (ulong)this._point >= (ulong)((long)num);
					if (flag5)
					{
						return true;
					}
				}
				return false;
			}
			case XSysDefine.Xsys_Backflow_Privilege:
				return false;
			}
			return false;
		}

		public void OnGetWorldLevelNotify(PtcG2C_WorldLevelNtf2Client roPtc)
		{
			this._curWorldLevel = roPtc.Data.worldLevel;
		}

		public void ShowBackFlowDlg()
		{
			this.FirstShowBackFlowDlg = true;
		}

		private bool OnActivityUpdate(XEventArgs e)
		{
			XActivityTaskUpdatedArgs xactivityTaskUpdatedArgs = e as XActivityTaskUpdatedArgs;
			bool flag = xactivityTaskUpdatedArgs != null;
			if (flag)
			{
				bool flag2 = xactivityTaskUpdatedArgs.xActID == 5U;
				if (flag2)
				{
					for (int i = 0; i < this._backflowTaskList.Count; i++)
					{
						bool flag3 = this._backflowTaskList[i].taskid == xactivityTaskUpdatedArgs.xTaskID;
						if (flag3)
						{
							this._backflowTaskList[i].progress = xactivityTaskUpdatedArgs.xProgress;
							this._backflowTaskList[i].state = xactivityTaskUpdatedArgs.xState;
							this._backflowTaskList.Sort(new Comparison<SpActivityTask>(this.SortBackFlowTaskList));
							XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.Xsys_Backflow_Task, true);
							bool flag4 = DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.IsVisible();
							if (flag4)
							{
								DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.RefreshHandler();
								DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.RefreshTabRedPoint(XSysDefine.Xsys_Backflow_Task, this.GetRedPointState(XSysDefine.Xsys_Backflow_Task));
							}
							break;
						}
					}
				}
			}
			return true;
		}

		private int SortBackFlowTaskList(SpActivityTask x, SpActivityTask y)
		{
			bool flag = x.state == 1U && y.state != 1U;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				bool flag2 = x.state != 1U && y.state == 1U;
				if (flag2)
				{
					result = 1;
				}
				else
				{
					bool flag3 = x.state != y.state;
					if (flag3)
					{
						result = (int)(x.state - y.state);
					}
					else
					{
						result = (int)(x.taskid - y.taskid);
					}
				}
			}
			return result;
		}

		private void MinusBackFlowLeftTime(object param)
		{
			bool flag = this._backflowLeftTime > 0U;
			if (flag)
			{
				this._backflowLeftTime -= 1U;
			}
			this.StopRefreshLeftTime();
			this._leftTimeToken = XSingleton<XTimerMgr>.singleton.SetTimer(5f, new XTimerMgr.ElapsedEventHandler(this.MinusBackFlowLeftTime), null);
			bool flag2 = DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.RefreshLeftTime(this._backflowLeftTime);
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XBackFlowDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static BackflowActivity _backflowActivity = new BackflowActivity();

		private static BackflowShop _backflowShopTable = new BackflowShop();

		private static WorldLevelExpBuff _worldLevelTable = new WorldLevelExpBuff();

		private List<SpActivityTask> _backflowTaskList = new List<SpActivityTask>();

		private List<uint> _rewardedTargetIDList = new List<uint>();

		private uint _point;

		private BackFlowShopData _backflowShopData = null;

		private List<ZoneRoleInfo> _serverRoleList = new List<ZoneRoleInfo>();

		private uint _shopLeftTime = 0U;

		private uint _backflowLeftTime = 0U;

		private uint _leftTimeToken = 0U;

		private ulong _SelectedRoleID = 0UL;

		private Dictionary<uint, List<ulong>> _serverIDToRoleList = new Dictionary<uint, List<ulong>>();

		private ulong _userSelectedRoleID = 0UL;

		private uint _curWorldLevel;

		public bool FirstShowBackFlowDlg = false;

		private bool _hasSelectRole = true;

		private uint _totalPay = 0U;

		private uint _dragonLeftTimes = 1U;

		private uint _nestLeftTimes = 0U;

		private bool _isPayReturnOpen = false;
	}
}
