using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009C2 RID: 2498
	internal class XActivityDocument : XDocComponent
	{
		// Token: 0x17002D94 RID: 11668
		// (get) Token: 0x06009767 RID: 38759 RVA: 0x001703F4 File Offset: 0x0016E5F4
		public override uint ID
		{
			get
			{
				return XActivityDocument.uuID;
			}
		}

		// Token: 0x17002D95 RID: 11669
		// (get) Token: 0x06009768 RID: 38760 RVA: 0x0017040C File Offset: 0x0016E60C
		public static XActivityDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XActivityDocument.uuID) as XActivityDocument;
			}
		}

		// Token: 0x17002D96 RID: 11670
		// (get) Token: 0x06009769 RID: 38761 RVA: 0x00170438 File Offset: 0x0016E638
		public ActivityListTable _ActivityListTable
		{
			get
			{
				return XActivityDocument._activityListTable;
			}
		}

		// Token: 0x0600976A RID: 38762 RVA: 0x00170450 File Offset: 0x0016E650
		public static void Execute(OnLoadedCallback callback = null)
		{
			XActivityDocument.AsyncLoader.AddTask("Table/ActivityList", XActivityDocument._activityListTable, false);
			XActivityDocument.AsyncLoader.AddTask("Table/MultiActivityList", XActivityDocument.m_mulActivityTable, false);
			XActivityDocument.AsyncLoader.AddTask("Table/DoubleActivity", XActivityDocument.m_doubleActivityTab, false);
			XActivityDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600976B RID: 38763 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600976C RID: 38764 RVA: 0x001704AC File Offset: 0x0016E6AC
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this.SendQueryGetMulActInfo();
				this.ReqDayCount();
			}
		}

		// Token: 0x0600976D RID: 38765 RVA: 0x001704E8 File Offset: 0x0016E6E8
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_GuildLevelChanged, new XComponent.XEventHandler(this.OnGuildLevelChanged));
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.OnInGuildStateChanged));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		// Token: 0x0600976E RID: 38766 RVA: 0x00170540 File Offset: 0x0016E740
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.ReqDayCount();
				this.SendQueryGetMulActInfo();
			}
		}

		// Token: 0x0600976F RID: 38767 RVA: 0x00170578 File Offset: 0x0016E778
		public void ReqDayCount()
		{
			this.m_DayCountReqNum = 5;
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.ReqTeamOp(TeamOperate.TEAM_QUERYCOUNT, 0UL, null, TeamMemberType.TMT_NORMAL, null);
			XExpeditionDocument specificDocument2 = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			specificDocument2.GetSingleTowerActivityTop();
			XBossBushDocument specificDocument3 = XDocuments.GetSpecificDocument<XBossBushDocument>(XBossBushDocument.uuID);
			specificDocument3.SendQuery(BossRushReqStatus.BOSSRUSH_REQ_LEFTCOUNT);
			XDragonCrusadeDocument specificDocument4 = XDocuments.GetSpecificDocument<XDragonCrusadeDocument>(XDragonCrusadeDocument.uuID);
			specificDocument4.DEProgressReq();
			XSuperRiskDocument doc = XSuperRiskDocument.Doc;
			bool flag = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_SuperRisk);
			if (flag)
			{
				RiskMapFile.RowData mapIdByIndex = doc.GetMapIdByIndex(0);
				bool flag2 = mapIdByIndex != null && (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= (ulong)((long)mapIdByIndex.NeedLevel);
				if (flag2)
				{
					doc.ReqMapDynamicInfo(doc.CurrentMapID, false, true);
					this.m_DayCountReqNum++;
				}
			}
			XGuildDailyTaskDocument specificDocument5 = XDocuments.GetSpecificDocument<XGuildDailyTaskDocument>(XGuildDailyTaskDocument.uuID);
			specificDocument5.SendGetDailyTaskInfo();
			XGuildWeeklyBountyDocument.Doc.SendGetWeeklyTaskInfo();
			XDragonNestDocument specificDocument6 = XDocuments.GetSpecificDocument<XDragonNestDocument>(XDragonNestDocument.uuID);
			specificDocument6.SendReqDragonNestInfo();
		}

		// Token: 0x06009770 RID: 38768 RVA: 0x00170680 File Offset: 0x0016E880
		public void SendQueryGetMulActInfo()
		{
			RpcC2G_MulActivityReq rpc = new RpcC2G_MulActivityReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009771 RID: 38769 RVA: 0x001706A0 File Offset: 0x0016E8A0
		public void OnGetDayCount()
		{
			bool flag = this.m_DayCountReqNum == 0;
			if (!flag)
			{
				this.m_DayCountReqNum--;
				bool flag2 = this.m_DayCountReqNum == 0;
				if (flag2)
				{
					bool flag3 = this.View != null && this.View.IsVisible();
					if (flag3)
					{
						this.View.RefreshDailyActivity();
					}
					XSingleton<XTutorialHelper>.singleton.ActivityOpen = true;
				}
			}
		}

		// Token: 0x06009772 RID: 38770 RVA: 0x00170710 File Offset: 0x0016E910
		public void SetMulActivityInfo(List<MulActivitInfo> list)
		{
			this.m_mulActivityList.Clear();
			for (int i = 0; i < list.Count; i++)
			{
				MulActivityInfo mulActivityInfo = this.TurnSeverDataToSlientData(list[i]);
				bool flag = mulActivityInfo == null;
				if (!flag)
				{
					this.m_mulActivityList.Add(mulActivityInfo);
				}
			}
			this.m_mulActivityList.Sort(new Comparison<MulActivityInfo>(this.Compare));
			this.CheckEntranceState();
			this.SetTagTips();
			bool flag2 = this.View != null && this.View.IsVisible();
			if (flag2)
			{
				this.View.RefreshMulActivity();
			}
		}

		// Token: 0x06009773 RID: 38771 RVA: 0x001707B8 File Offset: 0x0016E9B8
		public void ChangeActivityState(List<MulActivitInfo> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 0; j < this.m_mulActivityList.Count; j++)
				{
					bool flag = this.m_mulActivityList[j].ID == list[i].id;
					if (flag)
					{
						this.m_mulActivityList[j] = this.TurnSeverDataToSlientData(list[i]);
					}
				}
			}
			this.m_mulActivityList.Sort(new Comparison<MulActivityInfo>(this.Compare));
			this.CheckEntranceState();
			this.SetTagTips();
			bool flag2 = this.View != null && this.View.IsVisible();
			if (flag2)
			{
				this.View.RefreshMulActivity();
			}
		}

		// Token: 0x06009774 RID: 38772 RVA: 0x0017088C File Offset: 0x0016EA8C
		public MulActivityInfo TurnSeverDataToSlientData(MulActivitInfo serverData)
		{
			MulActivityInfo mulActivityInfo = new MulActivityInfo();
			MultiActivityList.RowData byID = XActivityDocument.m_mulActivityTable.GetByID(serverData.id);
			bool flag = byID == null || XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
			MulActivityInfo result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpen(byID.SystemID);
				if (flag2)
				{
					result = null;
				}
				else
				{
					mulActivityInfo.Row = byID;
					mulActivityInfo.isOpenAllDay = (byID.OpenDayTime[0, 0] == 0U && byID.OpenDayTime[0, 1] == 0U);
					mulActivityInfo.ID = serverData.id;
					mulActivityInfo.time = serverData.lefttime;
					mulActivityInfo.timeState = serverData.openstate;
					mulActivityInfo.endTime = (int)serverData.endmin;
					mulActivityInfo.startTime = (int)serverData.beginmin;
					bool flag3 = byID.SystemID == XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_WeekEndNest);
					if (flag3)
					{
						mulActivityInfo.dayjoincount = (int)WeekEndNestDocument.Doc.JoindTimes;
					}
					else
					{
						mulActivityInfo.dayjoincount = serverData.dayjoincount;
					}
					mulActivityInfo.serverOpenWeekLeft = (int)(byID.OpenServerWeek - (uint)this.ServerOpenWeek);
					mulActivityInfo.roleLevel = (uint)XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel(byID.SystemID);
					mulActivityInfo.serverOpenDayLeft = XSingleton<XGameSysMgr>.singleton.GetSysOpenServerDay(byID.SystemID) - this.ServerOpenDay;
					bool flag4 = byID.NeedOpenAgain && serverData.real_open_state == ActOpenState.ActOpenState_NotOpen;
					if (flag4)
					{
						mulActivityInfo.openState = false;
					}
					else
					{
						mulActivityInfo.openState = true;
					}
					XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
					bool flag5 = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < mulActivityInfo.roleLevel || (!specificDocument.bInGuild && byID.GuildLevel != 0U) || (specificDocument.bInGuild && specificDocument.Level < mulActivityInfo.Row.GuildLevel) || mulActivityInfo.serverOpenDayLeft > 0 || mulActivityInfo.serverOpenWeekLeft > 0;
					if (flag5)
					{
						mulActivityInfo.state = MulActivityState.Lock;
					}
					else
					{
						bool flag6 = (byID.DayCountMax != -1 && serverData.dayjoincount >= byID.DayCountMax) || serverData.openstate == MulActivityTimeState.MULACTIVITY_END || serverData.openstate == MulActivityTimeState.MULACTIVITY_UNOPEN_TODAY;
						if (flag6)
						{
							XVoiceQADocument specificDocument2 = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
							bool flag7 = serverData.openstate == MulActivityTimeState.MULACTIVITY_RUNNING && byID.DayCountMax != -1 && serverData.dayjoincount >= byID.DayCountMax && (mulActivityInfo.ID == 4 || mulActivityInfo.ID == 6) && specificDocument2.IsVoiceQAIng;
							if (flag7)
							{
								mulActivityInfo.state = MulActivityState.Open;
								mulActivityInfo.dayjoincount = byID.DayCountMax - 1;
							}
							else
							{
								mulActivityInfo.state = MulActivityState.Grey;
								bool flag8 = serverData.openstate == MulActivityTimeState.MULACTIVITY_UNOPEN_TODAY;
								if (flag8)
								{
									mulActivityInfo.sortWeight = 9;
								}
								else
								{
									bool flag9 = serverData.openstate == MulActivityTimeState.MULACTIVITY_END;
									if (flag9)
									{
										mulActivityInfo.sortWeight = 8;
									}
									else
									{
										mulActivityInfo.sortWeight = 7;
									}
								}
							}
						}
						else
						{
							bool flag10 = serverData.openstate == MulActivityTimeState.MULACTIVITY_RUNNING;
							if (flag10)
							{
								mulActivityInfo.state = MulActivityState.Open;
								mulActivityInfo.sortWeight = (mulActivityInfo.isOpenAllDay ? 2 : 1);
							}
							else
							{
								bool flag11 = serverData.openstate == MulActivityTimeState.MULACTIVITY_BEfOREOPEN;
								if (flag11)
								{
									mulActivityInfo.state = MulActivityState.WillOpen;
								}
								else
								{
									XSingleton<XDebug>.singleton.AddErrorLog("Undefine MulActivity State. MulActivity Name = ", mulActivityInfo.Row.Name, null, null, null, null);
								}
							}
						}
					}
					result = mulActivityInfo;
				}
			}
			return result;
		}

		// Token: 0x06009775 RID: 38773 RVA: 0x00170BC8 File Offset: 0x0016EDC8
		public void SetScrollView(int sysId)
		{
			bool flag = DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton.ActivityHandler != null && DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton.ActivityHandler.IsVisible();
			if (flag)
			{
				DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton.ActivityHandler.SetScrollView(sysId);
			}
		}

		// Token: 0x06009776 RID: 38774 RVA: 0x00170C0C File Offset: 0x0016EE0C
		public void GetLeftDay(int sysID, ref int leftDay)
		{
			leftDay = 0;
			if (sysID == 526)
			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
				dateTime = dateTime.AddSeconds(this.ServerTimeSince1970);
				dateTime = dateTime.ToLocalTime();
				int num = XFastEnumIntEqualityComparer<DayOfWeek>.ToInt(dateTime.DayOfWeek);
				for (int i = 0; i < this.DragonResetTime.Count; i++)
				{
					bool flag = num < this.DragonResetTime[i];
					if (flag)
					{
						leftDay = this.DragonResetTime[i] - num;
						bool flag2 = dateTime.Hour < 5;
						if (flag2)
						{
							leftDay++;
						}
						break;
					}
					bool flag3 = num == this.DragonResetTime[i];
					if (flag3)
					{
						bool flag4 = dateTime.Hour < 5;
						if (flag4)
						{
							leftDay = 1;
							break;
						}
					}
				}
			}
		}

		// Token: 0x17002D97 RID: 11671
		// (get) Token: 0x06009777 RID: 38775 RVA: 0x00170CFC File Offset: 0x0016EEFC
		public List<int> DragonResetTime
		{
			get
			{
				bool flag = this.m_DragonResetTime == null;
				if (flag)
				{
					this.m_DragonResetTime = XSingleton<XGlobalConfig>.singleton.GetIntList("DragonResetWeekDay");
				}
				return this.m_DragonResetTime;
			}
		}

		// Token: 0x06009778 RID: 38776 RVA: 0x00170D38 File Offset: 0x0016EF38
		public void GetCount(int sysID, ref int leftCount, ref int totalCount, ref int canBuyCount)
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			XArenaDocument specificDocument2 = XDocuments.GetSpecificDocument<XArenaDocument>(XArenaDocument.uuID);
			totalCount = 0;
			leftCount = 0;
			canBuyCount = 0;
			if (sysID <= 530)
			{
				if (sysID <= 111)
				{
					switch (sysID)
					{
					case 48:
					{
						XBossBushDocument specificDocument3 = XDocuments.GetSpecificDocument<XBossBushDocument>(XBossBushDocument.uuID);
						leftCount = specificDocument3.leftChanllageCnt;
						totalCount = XSingleton<XGlobalConfig>.singleton.GetInt("BossRushDayCount");
						return;
					}
					case 49:
						leftCount = XSuperRiskDocument.Doc.LeftDiceTime;
						totalCount = XSingleton<XGlobalConfig>.singleton.GetInt("RiskDiceMaxNum");
						return;
					case 50:
					{
						XDragonCrusadeDocument specificDocument4 = XDocuments.GetSpecificDocument<XDragonCrusadeDocument>(XDragonCrusadeDocument.uuID);
						leftCount = specificDocument4.leftChanllageCnt;
						totalCount = XSingleton<XGlobalConfig>.singleton.GetInt("DragonCrusadeMaxNum");
						return;
					}
					default:
						if (sysID == 111)
						{
							leftCount = specificDocument.GetDayCount(TeamLevelType.TeamLevelAbyss, null);
							totalCount = specificDocument.GetDayMaxCount(TeamLevelType.TeamLevelAbyss, null);
							canBuyCount = specificDocument.GetBuyLimit(TeamLevelType.TeamLevelAbyss) - specificDocument.GetBuyCount(TeamLevelType.TeamLevelAbyss);
							canBuyCount = ((canBuyCount > 0) ? canBuyCount : 0);
							return;
						}
						break;
					}
				}
				else
				{
					if (sysID == 520)
					{
						leftCount = specificDocument.GetDayCount(TeamLevelType.TeamLevelNest, null);
						totalCount = specificDocument.GetDayMaxCount(TeamLevelType.TeamLevelNest, null);
						canBuyCount = specificDocument.GetBuyLimit(TeamLevelType.TeamLevelNest) - specificDocument.GetBuyCount(TeamLevelType.TeamLevelNest);
						canBuyCount = ((canBuyCount > 0) ? canBuyCount : 0);
						return;
					}
					switch (sysID)
					{
					case 527:
					case 530:
						leftCount = specificDocument.SingleTowerData.leftcount;
						totalCount = XSingleton<XGlobalConfig>.singleton.GetInt("TowerTeamDayCount");
						return;
					case 529:
						leftCount = specificDocument.GetDayCount(TeamLevelType.TeamLevelGoddessTrial, null);
						totalCount = specificDocument.GetDayMaxCount(TeamLevelType.TeamLevelGoddessTrial, null);
						return;
					}
				}
			}
			else if (sysID <= 886)
			{
				if (sysID == 540)
				{
					leftCount = specificDocument.GetDayCount(TeamLevelType.TeamLevelEndlessAbyss, null);
					totalCount = specificDocument.GetDayMaxCount(TeamLevelType.TeamLevelEndlessAbyss, null);
					return;
				}
				if (sysID == 886)
				{
					XGuildDailyTaskDocument specificDocument5 = XDocuments.GetSpecificDocument<XGuildDailyTaskDocument>(XGuildDailyTaskDocument.uuID);
					totalCount = specificDocument5.GetTaskItemCount();
					leftCount = totalCount - specificDocument5.GetRewardedTaskCount();
					return;
				}
			}
			else
			{
				if (sysID == 890)
				{
					XGuildInheritDocument specificDocument6 = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
					leftCount = (int)(specificDocument6.TeacherCount + specificDocument6.StudentCount);
					totalCount = XSingleton<XGlobalConfig>.singleton.GetInt("GuildInheritTeaLimit") + XSingleton<XGlobalConfig>.singleton.GetInt("GuildInheritStuLimit");
					return;
				}
				if (sysID == 904)
				{
					totalCount = XGuildWeeklyBountyDocument.Doc.CurGuildWeeklyTaskList.Count;
					leftCount = totalCount - XGuildWeeklyBountyDocument.Doc.GetRewardedTaskCount();
					return;
				}
			}
			totalCount = 0;
			leftCount = 0;
			canBuyCount = 0;
		}

		// Token: 0x17002D98 RID: 11672
		// (get) Token: 0x06009779 RID: 38777 RVA: 0x00170FE0 File Offset: 0x0016F1E0
		public List<MulActivityInfo> MulActivityList
		{
			get
			{
				return this.m_mulActivityList;
			}
		}

		// Token: 0x17002D99 RID: 11673
		// (get) Token: 0x0600977A RID: 38778 RVA: 0x00170FF8 File Offset: 0x0016F1F8
		public MultiActivityList MulActivityTable
		{
			get
			{
				return XActivityDocument.m_mulActivityTable;
			}
		}

		// Token: 0x0600977B RID: 38779 RVA: 0x00171010 File Offset: 0x0016F210
		protected bool OnGuildLevelChanged(XEventArgs e)
		{
			this.CheckEntranceState();
			return true;
		}

		// Token: 0x0600977C RID: 38780 RVA: 0x0017102C File Offset: 0x0016F22C
		protected bool OnInGuildStateChanged(XEventArgs e)
		{
			this.CheckEntranceState();
			return true;
		}

		// Token: 0x0600977D RID: 38781 RVA: 0x00171048 File Offset: 0x0016F248
		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			this.CheckEntranceState();
			return true;
		}

		// Token: 0x0600977E RID: 38782 RVA: 0x00171064 File Offset: 0x0016F264
		public void CheckEntranceState()
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			int num = -1;
			for (int i = 0; i < this.m_mulActivityList.Count; i++)
			{
				MulActivityInfo mulActivityInfo = this.m_mulActivityList[i];
				MultiActivityList.RowData byID = XActivityDocument.m_mulActivityTable.GetByID(mulActivityInfo.ID);
				bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < mulActivityInfo.roleLevel || (!specificDocument.bInGuild && byID.GuildLevel != 0U) || (specificDocument.bInGuild && specificDocument.Level < mulActivityInfo.Row.GuildLevel);
				if (!flag)
				{
					bool flag2 = byID.DayCountMax != -1 && mulActivityInfo.dayjoincount >= byID.DayCountMax;
					if (!flag2)
					{
						bool flag3 = mulActivityInfo.timeState == MulActivityTimeState.MULACTIVITY_BEfOREOPEN;
						if (flag3)
						{
							bool flag4 = num == -1;
							if (flag4)
							{
								num = i;
							}
							else
							{
								bool flag5 = mulActivityInfo.startTime < this.m_mulActivityList[num].startTime;
								if (flag5)
								{
									num = i;
								}
							}
						}
					}
				}
			}
			bool flag6 = num == -1;
			if (flag6)
			{
				this.MainInterfaceTips = "";
			}
			else
			{
				this.MainInterfaceTips = string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("MULACT_MAININTERFACE_TIPS")), XSingleton<UiUtility>.singleton.TimeFormatString(this.m_mulActivityList[num].startTime * 60, 3, 3, 3, false, true), this.m_mulActivityList[num].Row.Name);
			}
		}

		// Token: 0x0600977F RID: 38783 RVA: 0x001711F0 File Offset: 0x0016F3F0
		public MultiActivityList.RowData GetMultiActivityTableInfo(XSysDefine sys)
		{
			for (int i = 0; i < XActivityDocument.m_mulActivityTable.Table.Length; i++)
			{
				bool flag = XActivityDocument.m_mulActivityTable.Table[i].SystemID == (int)sys;
				if (flag)
				{
					return XActivityDocument.m_mulActivityTable.Table[i];
				}
			}
			return null;
		}

		// Token: 0x06009780 RID: 38784 RVA: 0x00171248 File Offset: 0x0016F448
		private int Compare(MulActivityInfo x, MulActivityInfo y)
		{
			bool flag = x.ID == y.ID;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				bool flag2 = x.state != y.state;
				if (flag2)
				{
					result = y.state - x.state;
				}
				else
				{
					bool flag3 = x.state == MulActivityState.Grey;
					if (flag3)
					{
						result = x.sortWeight - y.sortWeight;
					}
					else
					{
						bool flag4 = x.state == MulActivityState.Open;
						if (flag4)
						{
							bool flag5 = x.sortWeight != y.sortWeight;
							if (flag5)
							{
								result = x.sortWeight - y.sortWeight;
							}
							else
							{
								result = (int)(x.time - y.time);
							}
						}
						else
						{
							bool flag6 = x.state == MulActivityState.WillOpen;
							if (flag6)
							{
								result = x.startTime - y.startTime;
							}
							else
							{
								result = 0;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06009781 RID: 38785 RVA: 0x00171324 File Offset: 0x0016F524
		private void SetTagTips()
		{
			bool flag = false;
			for (int i = 0; i < this.m_mulActivityList.Count; i++)
			{
				MulActivityInfo mulActivityInfo = this.m_mulActivityList[i];
				bool flag2 = mulActivityInfo == null;
				if (!flag2)
				{
					bool flag3 = mulActivityInfo.state == MulActivityState.Open;
					if (flag3)
					{
						mulActivityInfo.tagType = MulActivityTagType.Opening;
					}
					else
					{
						bool flag4 = mulActivityInfo.state == MulActivityState.WillOpen && !flag;
						if (flag4)
						{
							mulActivityInfo.tagType = MulActivityTagType.WillOpen;
							flag = true;
						}
						else
						{
							mulActivityInfo.tagType = MulActivityTagType.None;
						}
					}
				}
			}
		}

		// Token: 0x06009782 RID: 38786 RVA: 0x001713AC File Offset: 0x0016F5AC
		public bool MainCityNeedEffect()
		{
			bool flag = XActivityDocument.m_doubleActivityTab == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < XActivityDocument.m_doubleActivityTab.Table.Length; i++)
				{
					bool flag2 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpen((int)XActivityDocument.m_doubleActivityTab.Table[i].SystemId);
					if (!flag2)
					{
						bool flag3 = this.ParseData(XActivityDocument.m_doubleActivityTab.Table[i]);
						if (flag3)
						{
							return true;
						}
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06009783 RID: 38787 RVA: 0x00171430 File Offset: 0x0016F630
		public bool IsInnerDropTime(uint sysId)
		{
			bool flag = XActivityDocument.m_doubleActivityTab == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				DoubleActivity.RowData bySystemId = XActivityDocument.m_doubleActivityTab.GetBySystemId(sysId);
				result = this.ParseData(bySystemId);
			}
			return result;
		}

		// Token: 0x06009784 RID: 38788 RVA: 0x00171468 File Offset: 0x0016F668
		private bool ParseData(DoubleActivity.RowData data)
		{
			bool flag = data == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = data.WeekOpenDays != null;
				if (flag2)
				{
					result = this.ParseWeekDays(data.WeekOpenDays);
				}
				else
				{
					bool flag3 = data.TimeSpan != null;
					result = (flag3 && this.ParseTimeSpan(data.TimeSpan));
				}
			}
			return result;
		}

		// Token: 0x06009785 RID: 38789 RVA: 0x001714C0 File Offset: 0x0016F6C0
		private bool ParseWeekDays(uint[] weekOpenDays)
		{
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
			dateTime = dateTime.AddSeconds(this.ServerTimeSince1970);
			dateTime = dateTime.ToLocalTime();
			for (int i = 0; i < weekOpenDays.Length; i++)
			{
				uint num = (weekOpenDays[i] != 7U) ? weekOpenDays[i] : 0U;
				bool flag = num < 0U || num > 6U;
				if (!flag)
				{
					bool flag2 = (ulong)num == (ulong)((long)XFastEnumIntEqualityComparer<DayOfWeek>.ToInt(dateTime.DayOfWeek));
					if (flag2)
					{
						bool flag3 = dateTime.Hour >= 5;
						if (flag3)
						{
							return true;
						}
					}
					num = ((num + 1U > 6U) ? 0U : (num + 1U));
					bool flag4 = (ulong)num == (ulong)((long)XFastEnumIntEqualityComparer<DayOfWeek>.ToInt(dateTime.DayOfWeek));
					if (flag4)
					{
						bool flag5 = dateTime.Hour < 5;
						if (flag5)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06009786 RID: 38790 RVA: 0x001715A8 File Offset: 0x0016F7A8
		private bool ParseTimeSpan(uint[] timeSpan)
		{
			bool flag = timeSpan.Length < 5;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = timeSpan[1] > 12U || timeSpan[1] < 1U;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = timeSpan[2] > 31U || timeSpan[2] < 1U;
					if (flag3)
					{
						result = false;
					}
					else
					{
						bool flag4 = timeSpan[3] > 24U;
						if (flag4)
						{
							result = false;
						}
						else
						{
							DateTime d = new DateTime((int)timeSpan[0], (int)timeSpan[1], (int)timeSpan[2], (int)timeSpan[3], 0, 0);
							DateTime d2 = new DateTime(1970, 1, 1, 0, 0, 0);
							uint num = (uint)(d - d2).TotalSeconds;
							uint num2 = num + timeSpan[4] * 3600U;
							bool flag5 = this.ServerTimeSince1970 >= num && this.ServerTimeSince1970 <= num2;
							result = flag5;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06009787 RID: 38791 RVA: 0x00171684 File Offset: 0x0016F884
		public void OnSystemChanged(List<uint> openIds, List<uint> closeIds)
		{
			bool flag = this.View == null || !this.View.IsVisible();
			if (!flag)
			{
				bool flag2 = false;
				bool flag3 = XActivityDocument._activityListTable != null;
				if (flag3)
				{
					for (int i = 0; i < XActivityDocument._activityListTable.Table.Length; i++)
					{
						uint item = XActivityDocument._activityListTable.Table[i].SysID;
						bool flag4 = openIds.Contains(item) || closeIds.Contains(item);
						if (flag4)
						{
							flag2 = true;
							break;
						}
					}
				}
				bool flag5 = false;
				bool flag6 = XActivityDocument.m_mulActivityTable != null;
				if (flag6)
				{
					for (int j = 0; j < XActivityDocument.m_mulActivityTable.Table.Length; j++)
					{
						uint item = (uint)XActivityDocument.m_mulActivityTable.Table[j].SystemID;
						bool flag7 = openIds.Contains(item) || closeIds.Contains(item);
						if (flag7)
						{
							flag5 = true;
							break;
						}
					}
				}
				bool flag8 = flag2;
				if (flag8)
				{
					this.View.RefreshDailyActivity();
				}
				bool flag9 = flag5;
				if (flag9)
				{
					this.SendQueryGetMulActInfo();
				}
			}
		}

		// Token: 0x040033B4 RID: 13236
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ActivityDocument");

		// Token: 0x040033B5 RID: 13237
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040033B6 RID: 13238
		private static ActivityListTable _activityListTable = new ActivityListTable();

		// Token: 0x040033B7 RID: 13239
		private static DoubleActivity m_doubleActivityTab = new DoubleActivity();

		// Token: 0x040033B8 RID: 13240
		public ActivityHandler View;

		// Token: 0x040033B9 RID: 13241
		public int ServerOpenDay = 10000;

		// Token: 0x040033BA RID: 13242
		public int ServerOpenWeek = 10000;

		// Token: 0x040033BB RID: 13243
		public uint SeverOpenSecond = 10000U;

		// Token: 0x040033BC RID: 13244
		public uint ServerTimeSince1970 = 0U;

		// Token: 0x040033BD RID: 13245
		private int m_DayCountReqNum;

		// Token: 0x040033BE RID: 13246
		private List<int> m_DragonResetTime = null;

		// Token: 0x040033BF RID: 13247
		private List<MulActivityInfo> m_mulActivityList = new List<MulActivityInfo>();

		// Token: 0x040033C0 RID: 13248
		private static MultiActivityList m_mulActivityTable = new MultiActivityList();

		// Token: 0x040033C1 RID: 13249
		public string MainInterfaceTips = "";
	}
}
