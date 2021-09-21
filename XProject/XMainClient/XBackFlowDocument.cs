using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008F2 RID: 2290
	internal class XBackFlowDocument : XDocComponent
	{
		// Token: 0x17002B11 RID: 11025
		// (get) Token: 0x06008A71 RID: 35441 RVA: 0x00125D00 File Offset: 0x00123F00
		public override uint ID
		{
			get
			{
				return XBackFlowDocument.uuID;
			}
		}

		// Token: 0x17002B12 RID: 11026
		// (get) Token: 0x06008A72 RID: 35442 RVA: 0x00125D18 File Offset: 0x00123F18
		public static BackflowShop BackflowShopTable
		{
			get
			{
				return XBackFlowDocument._backflowShopTable;
			}
		}

		// Token: 0x17002B13 RID: 11027
		// (get) Token: 0x06008A73 RID: 35443 RVA: 0x00125D30 File Offset: 0x00123F30
		public static XBackFlowDocument Doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XBackFlowDocument>(XBackFlowDocument.uuID);
			}
		}

		// Token: 0x06008A74 RID: 35444 RVA: 0x00125D4C File Offset: 0x00123F4C
		public static void Execute(OnLoadedCallback callback = null)
		{
			XBackFlowDocument.AsyncLoader.AddTask("Table/BackflowActivity", XBackFlowDocument._backflowActivity, false);
			XBackFlowDocument.AsyncLoader.AddTask("Table/BackFlowShop", XBackFlowDocument._backflowShopTable, false);
			XBackFlowDocument.AsyncLoader.AddTask("Table/WorldLevelExpBuff", XBackFlowDocument._worldLevelTable, false);
			XBackFlowDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008A75 RID: 35445 RVA: 0x00125DA8 File Offset: 0x00123FA8
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ActivityTaskUpdate, new XComponent.XEventHandler(this.OnActivityUpdate));
		}

		// Token: 0x06008A76 RID: 35446 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008A77 RID: 35447 RVA: 0x00125DCA File Offset: 0x00123FCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.FirstShowBackFlowDlg = false;
		}

		// Token: 0x06008A78 RID: 35448 RVA: 0x00125DDC File Offset: 0x00123FDC
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = this.FirstShowBackFlowDlg && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.SetVisible(true, true);
			}
		}

		// Token: 0x06008A79 RID: 35449 RVA: 0x00125E24 File Offset: 0x00124024
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

		// Token: 0x17002B14 RID: 11028
		// (get) Token: 0x06008A7A RID: 35450 RVA: 0x00125EB0 File Offset: 0x001240B0
		public BackFlowShopData BackflowShopData
		{
			get
			{
				return this._backflowShopData;
			}
		}

		// Token: 0x17002B15 RID: 11029
		// (get) Token: 0x06008A7B RID: 35451 RVA: 0x00125EC8 File Offset: 0x001240C8
		public uint ShopLeftTime
		{
			get
			{
				return this._shopLeftTime;
			}
		}

		// Token: 0x17002B16 RID: 11030
		// (get) Token: 0x06008A7C RID: 35452 RVA: 0x00125EE0 File Offset: 0x001240E0
		public List<uint> RewardedTargetIDList
		{
			get
			{
				return this._rewardedTargetIDList;
			}
		}

		// Token: 0x17002B17 RID: 11031
		// (get) Token: 0x06008A7D RID: 35453 RVA: 0x00125EF8 File Offset: 0x001240F8
		// (set) Token: 0x06008A7E RID: 35454 RVA: 0x00125F10 File Offset: 0x00124110
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

		// Token: 0x17002B18 RID: 11032
		// (get) Token: 0x06008A7F RID: 35455 RVA: 0x00125F1C File Offset: 0x0012411C
		public List<ZoneRoleInfo> ServerRoleList
		{
			get
			{
				return this._serverRoleList;
			}
		}

		// Token: 0x17002B19 RID: 11033
		// (get) Token: 0x06008A80 RID: 35456 RVA: 0x00125F34 File Offset: 0x00124134
		public ulong SelectedRoleID
		{
			get
			{
				return this._SelectedRoleID;
			}
		}

		// Token: 0x17002B1A RID: 11034
		// (get) Token: 0x06008A81 RID: 35457 RVA: 0x00125F4C File Offset: 0x0012414C
		public bool CanSelectRole
		{
			get
			{
				return this._hasSelectRole;
			}
		}

		// Token: 0x17002B1B RID: 11035
		// (get) Token: 0x06008A82 RID: 35458 RVA: 0x00125F64 File Offset: 0x00124164
		public bool IsPayReturnOpen
		{
			get
			{
				return this._isPayReturnOpen;
			}
		}

		// Token: 0x17002B1C RID: 11036
		// (get) Token: 0x06008A83 RID: 35459 RVA: 0x00125F7C File Offset: 0x0012417C
		public uint TotalPay
		{
			get
			{
				return this._totalPay;
			}
		}

		// Token: 0x17002B1D RID: 11037
		// (get) Token: 0x06008A84 RID: 35460 RVA: 0x00125F94 File Offset: 0x00124194
		public uint DragonLeftTimes
		{
			get
			{
				return this._dragonLeftTimes;
			}
		}

		// Token: 0x17002B1E RID: 11038
		// (get) Token: 0x06008A85 RID: 35461 RVA: 0x00125FAC File Offset: 0x001241AC
		public uint NestLeftTimes
		{
			get
			{
				return this._nestLeftTimes;
			}
		}

		// Token: 0x06008A86 RID: 35462 RVA: 0x00125FC4 File Offset: 0x001241C4
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

		// Token: 0x06008A87 RID: 35463 RVA: 0x001260CC File Offset: 0x001242CC
		public void AttachPandoraRedPoint(int sysID)
		{
			int sys = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.Xsys_Backflow);
			bool flag = sysID != 0;
			if (flag)
			{
				XSingleton<XGameSysMgr>.singleton.AttachSysRedPointRelative(sys, sysID, false);
			}
		}

		// Token: 0x06008A88 RID: 35464 RVA: 0x001260FC File Offset: 0x001242FC
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

		// Token: 0x06008A89 RID: 35465 RVA: 0x00126190 File Offset: 0x00124390
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

		// Token: 0x06008A8A RID: 35466 RVA: 0x00126318 File Offset: 0x00124518
		public List<uint> GetServerList()
		{
			return new List<uint>(this._serverIDToRoleList.Keys);
		}

		// Token: 0x06008A8B RID: 35467 RVA: 0x0012633C File Offset: 0x0012453C
		public List<SpActivityTask> GetBackflowTaskList()
		{
			return this._backflowTaskList;
		}

		// Token: 0x06008A8C RID: 35468 RVA: 0x00126354 File Offset: 0x00124554
		public void StopRefreshLeftTime()
		{
			bool flag = this._leftTimeToken > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._leftTimeToken);
			}
			this._leftTimeToken = 0U;
		}

		// Token: 0x06008A8D RID: 35469 RVA: 0x00126388 File Offset: 0x00124588
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

		// Token: 0x06008A8E RID: 35470 RVA: 0x001263C0 File Offset: 0x001245C0
		public void StartRefreshLeftTime()
		{
			bool flag = this._leftTimeToken > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._leftTimeToken);
			}
			this._leftTimeToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.MinusBackFlowLeftTime), 1);
		}

		// Token: 0x06008A8F RID: 35471 RVA: 0x00126414 File Offset: 0x00124614
		public void SendBackFlowActivityOperation(BackFlowActOp v, uint itemID = 0U)
		{
			RpcC2G_BackFlowActivityOperation rpcC2G_BackFlowActivityOperation = new RpcC2G_BackFlowActivityOperation();
			rpcC2G_BackFlowActivityOperation.oArg.arg = itemID;
			rpcC2G_BackFlowActivityOperation.oArg.type = v;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_BackFlowActivityOperation);
		}

		// Token: 0x06008A90 RID: 35472 RVA: 0x00126450 File Offset: 0x00124650
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

		// Token: 0x06008A91 RID: 35473 RVA: 0x001265DC File Offset: 0x001247DC
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

		// Token: 0x06008A92 RID: 35474 RVA: 0x00126648 File Offset: 0x00124848
		public void SendToGetNewZoneBenefit()
		{
			RpcC2G_GetNewZoneBenefit rpc = new RpcC2G_GetNewZoneBenefit();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008A93 RID: 35475 RVA: 0x00126668 File Offset: 0x00124868
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

		// Token: 0x06008A94 RID: 35476 RVA: 0x00126770 File Offset: 0x00124970
		public void SendToSelectRoleServer(ulong selectRoleID)
		{
			this._userSelectedRoleID = selectRoleID;
			RpcC2G_SelectChargeBackRole rpcC2G_SelectChargeBackRole = new RpcC2G_SelectChargeBackRole();
			rpcC2G_SelectChargeBackRole.oArg.roleid = selectRoleID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SelectChargeBackRole);
		}

		// Token: 0x06008A95 RID: 35477 RVA: 0x001267A4 File Offset: 0x001249A4
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

		// Token: 0x06008A96 RID: 35478 RVA: 0x00126800 File Offset: 0x00124A00
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

		// Token: 0x06008A97 RID: 35479 RVA: 0x0012695C File Offset: 0x00124B5C
		public void OnGetWorldLevelNotify(PtcG2C_WorldLevelNtf2Client roPtc)
		{
			this._curWorldLevel = roPtc.Data.worldLevel;
		}

		// Token: 0x06008A98 RID: 35480 RVA: 0x00126970 File Offset: 0x00124B70
		public void ShowBackFlowDlg()
		{
			this.FirstShowBackFlowDlg = true;
		}

		// Token: 0x06008A99 RID: 35481 RVA: 0x0012697C File Offset: 0x00124B7C
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

		// Token: 0x06008A9A RID: 35482 RVA: 0x00126A94 File Offset: 0x00124C94
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

		// Token: 0x06008A9B RID: 35483 RVA: 0x00126B18 File Offset: 0x00124D18
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

		// Token: 0x04002C14 RID: 11284
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XBackFlowDocument");

		// Token: 0x04002C15 RID: 11285
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002C16 RID: 11286
		public static BackflowActivity _backflowActivity = new BackflowActivity();

		// Token: 0x04002C17 RID: 11287
		private static BackflowShop _backflowShopTable = new BackflowShop();

		// Token: 0x04002C18 RID: 11288
		private static WorldLevelExpBuff _worldLevelTable = new WorldLevelExpBuff();

		// Token: 0x04002C19 RID: 11289
		private List<SpActivityTask> _backflowTaskList = new List<SpActivityTask>();

		// Token: 0x04002C1A RID: 11290
		private List<uint> _rewardedTargetIDList = new List<uint>();

		// Token: 0x04002C1B RID: 11291
		private uint _point;

		// Token: 0x04002C1C RID: 11292
		private BackFlowShopData _backflowShopData = null;

		// Token: 0x04002C1D RID: 11293
		private List<ZoneRoleInfo> _serverRoleList = new List<ZoneRoleInfo>();

		// Token: 0x04002C1E RID: 11294
		private uint _shopLeftTime = 0U;

		// Token: 0x04002C1F RID: 11295
		private uint _backflowLeftTime = 0U;

		// Token: 0x04002C20 RID: 11296
		private uint _leftTimeToken = 0U;

		// Token: 0x04002C21 RID: 11297
		private ulong _SelectedRoleID = 0UL;

		// Token: 0x04002C22 RID: 11298
		private Dictionary<uint, List<ulong>> _serverIDToRoleList = new Dictionary<uint, List<ulong>>();

		// Token: 0x04002C23 RID: 11299
		private ulong _userSelectedRoleID = 0UL;

		// Token: 0x04002C24 RID: 11300
		private uint _curWorldLevel;

		// Token: 0x04002C25 RID: 11301
		public bool FirstShowBackFlowDlg = false;

		// Token: 0x04002C26 RID: 11302
		private bool _hasSelectRole = true;

		// Token: 0x04002C27 RID: 11303
		private uint _totalPay = 0U;

		// Token: 0x04002C28 RID: 11304
		private uint _dragonLeftTimes = 1U;

		// Token: 0x04002C29 RID: 11305
		private uint _nestLeftTimes = 0U;

		// Token: 0x04002C2A RID: 11306
		private bool _isPayReturnOpen = false;
	}
}
