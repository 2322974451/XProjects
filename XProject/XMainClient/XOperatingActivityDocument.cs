using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CFA RID: 3322
	internal class XOperatingActivityDocument : XDocComponent
	{
		// Token: 0x170032A9 RID: 12969
		// (get) Token: 0x0600B9C0 RID: 47552 RVA: 0x0025C940 File Offset: 0x0025AB40
		public override uint ID
		{
			get
			{
				return XOperatingActivityDocument.uuID;
			}
		}

		// Token: 0x170032AA RID: 12970
		// (get) Token: 0x0600B9C1 RID: 47553 RVA: 0x0025C958 File Offset: 0x0025AB58
		public static OperatingActivity OperatingActivityTable
		{
			get
			{
				return XOperatingActivityDocument.m_OperatingActivityTable;
			}
		}

		// Token: 0x170032AB RID: 12971
		// (get) Token: 0x0600B9C2 RID: 47554 RVA: 0x0025C970 File Offset: 0x0025AB70
		public List<SuperActivityTask.RowData> SealDatas
		{
			get
			{
				bool flag = this._staticSealDatas.Count == 0 && this.CurSealActID > 0U;
				if (flag)
				{
					this.InitSealData();
				}
				return this._staticSealDatas;
			}
		}

		// Token: 0x170032AC RID: 12972
		// (get) Token: 0x0600B9C3 RID: 47555 RVA: 0x0025C9AC File Offset: 0x0025ABAC
		// (set) Token: 0x0600B9C4 RID: 47556 RVA: 0x0025C9C4 File Offset: 0x0025ABC4
		public uint CurSealActID
		{
			get
			{
				return this.curSealActid;
			}
			set
			{
				this.curSealActid = value;
				bool flag = this.curSealActid == 0U;
				if (flag)
				{
					DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.UpdateTab();
				}
				else
				{
					this.InitSealData();
				}
			}
		}

		// Token: 0x170032AD RID: 12973
		// (get) Token: 0x0600B9C5 RID: 47557 RVA: 0x0025C9FC File Offset: 0x0025ABFC
		public static XOperatingActivityDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XOperatingActivityDocument.uuID) as XOperatingActivityDocument;
			}
		}

		// Token: 0x170032AE RID: 12974
		// (get) Token: 0x0600B9C6 RID: 47558 RVA: 0x0025CA27 File Offset: 0x0025AC27
		// (set) Token: 0x0600B9C7 RID: 47559 RVA: 0x0025CA2F File Offset: 0x0025AC2F
		public XOperatingActivityView View { get; set; }

		// Token: 0x170032AF RID: 12975
		// (get) Token: 0x0600B9C8 RID: 47560 RVA: 0x0025CA38 File Offset: 0x0025AC38
		public HashSet<uint> systemIds
		{
			get
			{
				bool flag = this.m_systemIds == null || this.m_systemIds.Count == 0;
				if (flag)
				{
					this.m_systemIds = new HashSet<uint>();
					for (int i = 0; i < XOperatingActivityDocument.m_OperatingActivityTable.Table.Length; i++)
					{
						bool flag2 = XOperatingActivityDocument.m_OperatingActivityTable.Table[i] != null;
						if (flag2)
						{
							this.m_systemIds.Add(XOperatingActivityDocument.m_OperatingActivityTable.Table[i].SysID);
						}
					}
				}
				return this.m_systemIds;
			}
		}

		// Token: 0x170032B0 RID: 12976
		// (get) Token: 0x0600B9C9 RID: 47561 RVA: 0x0025CACC File Offset: 0x0025ACCC
		private bool HolidayRedPoint
		{
			get
			{
				return this._holiday_data.LeftCount > 0U;
			}
		}

		// Token: 0x0600B9CA RID: 47562 RVA: 0x0025CAEC File Offset: 0x0025ACEC
		public void RequestGetLuckyTurntableData()
		{
			RpcC2G_GetLuckyActivityInfo rpc = new RpcC2G_GetLuckyActivityInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B9CB RID: 47563 RVA: 0x0025CB0C File Offset: 0x0025AD0C
		public void OnReceiveGetLuckyTurntableData(GetLuckyActivityInfoRes res)
		{
			this.m_LuckyTurntableData.CurrencyType = (int)res.currencytype;
			this.m_LuckyTurntableData.Price = res.price;
			this.m_LuckyTurntableData.IsPay = res.ispay;
			this.m_LuckyTurntableData.RefreshItems(res.itemrecord);
			bool flag = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_luckyTurntableFrameHandler != null;
				if (flag2)
				{
					DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_luckyTurntableFrameHandler.RefeshInfo();
				}
			}
		}

		// Token: 0x0600B9CC RID: 47564 RVA: 0x0025CB94 File Offset: 0x0025AD94
		public void RequestBuyLuckyTurntable()
		{
			RpcC2G_BuyDraw rpc = new RpcC2G_BuyDraw();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B9CD RID: 47565 RVA: 0x0025CBB4 File Offset: 0x0025ADB4
		public void OnReceiveBuyLuckyTurntable()
		{
			this.m_LuckyTurntableData.IsPay = true;
			bool flag = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_luckyTurntableFrameHandler != null;
				if (flag2)
				{
					DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_luckyTurntableFrameHandler.OnBuy();
				}
			}
		}

		// Token: 0x0600B9CE RID: 47566 RVA: 0x0025CC04 File Offset: 0x0025AE04
		public void RequestUseLuckyTurntable()
		{
			RpcC2G_LotteryDraw rpc = new RpcC2G_LotteryDraw();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B9CF RID: 47567 RVA: 0x0025CC24 File Offset: 0x0025AE24
		public void OnReceiveUseLuckyTurntable(LotteryDrawRes res)
		{
			this.m_LuckyTurntableData.CurrencyType = (int)res.currencytype;
			this.m_LuckyTurntableData.Price = res.price;
			this.m_LuckyTurntableData.IsPay = false;
			this.m_LuckyTurntableData.RefreshItems(res.itemrecord);
			int index = (int)res.index;
			bool flag = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_luckyTurntableFrameHandler != null;
				if (flag2)
				{
					DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_luckyTurntableFrameHandler.OnGetIndex(index);
				}
			}
		}

		// Token: 0x0600B9D0 RID: 47568 RVA: 0x0025CCAD File Offset: 0x0025AEAD
		public static void Execute(OnLoadedCallback callback = null)
		{
			XOperatingActivityDocument.AsyncLoader.AddTask("Table/OperatingActivity", XOperatingActivityDocument.m_OperatingActivityTable, false);
			XOperatingActivityDocument.AsyncLoader.AddTask("Table/festivalscenelist", XOperatingActivityDocument.m_FestivalTable, false);
			XOperatingActivityDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600B9D1 RID: 47569 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600B9D2 RID: 47570 RVA: 0x0025CCE8 File Offset: 0x0025AEE8
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ActivityTaskUpdate, new XComponent.XEventHandler(this.OnSealUpdate));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		// Token: 0x0600B9D3 RID: 47571 RVA: 0x0025CD22 File Offset: 0x0025AF22
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			this.DetachPandoraSDKRedPoint();
		}

		// Token: 0x0600B9D4 RID: 47572 RVA: 0x0025CD33 File Offset: 0x0025AF33
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.SendQueryHolidayData();
		}

		// Token: 0x0600B9D5 RID: 47573 RVA: 0x0025CD40 File Offset: 0x0025AF40
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			this.SendQueryHolidayData();
			this.HisMaxLevel.Replace();
			bool flag = XSingleton<XSceneMgr>.singleton.GetSceneType(XSingleton<XScene>.singleton.SceneID) == SceneType.SCENE_HALL;
			if (flag)
			{
				this.RefreshRedPoints();
			}
		}

		// Token: 0x0600B9D6 RID: 47574 RVA: 0x0025CD8C File Offset: 0x0025AF8C
		public bool SysIsOpen(XSysDefine sys)
		{
			bool result;
			if (sys != XSysDefine.XSys_LevelSeal)
			{
				result = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(sys);
			}
			else
			{
				result = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID).IsShowLevelSealIcon();
			}
			return result;
		}

		// Token: 0x0600B9D7 RID: 47575 RVA: 0x0025CDCC File Offset: 0x0025AFCC
		public bool IsHadRedDot()
		{
			bool flag = false;
			foreach (KeyValuePair<XSysDefine, bool> keyValuePair in this.m_levelRedDotDic)
			{
				flag |= keyValuePair.Value;
			}
			XAnnouncementDocument specificDocument = XDocuments.GetSpecificDocument<XAnnouncementDocument>(XAnnouncementDocument.uuID);
			flag |= XSingleton<XGameSysMgr>.singleton.GetSysRedPointState(XSysDefine.XSys_LuckyTurntable);
			return ((FirstPassDocument.Doc.IsHadOutRedDot | this.IsFrozenSealHadRedDot()) || flag) | specificDocument.RedPoint | this.HolidayRedPoint | XCampDuelDocument.Doc.IsRedPoint();
		}

		// Token: 0x0600B9D8 RID: 47576 RVA: 0x0025CE78 File Offset: 0x0025B078
		public bool IsFrozenSealHadRedDot()
		{
			foreach (SuperActivityTask.RowData rowData in this.SealDatas)
			{
				bool flag = XTempActivityDocument.Doc.GetActivityState(this.curSealActid, rowData.taskid) == 1U;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B9D9 RID: 47577 RVA: 0x0025CEF0 File Offset: 0x0025B0F0
		public void RefreshRedPoints()
		{
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_OperatingActivity, true);
			bool flag = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.RefreshRedpoint();
			}
		}

		// Token: 0x0600B9DA RID: 47578 RVA: 0x0025CF28 File Offset: 0x0025B128
		public void OnSystemChanged(List<uint> openIds, List<uint> closeIds)
		{
			bool flag = !DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				int num = 0;
				bool flag2 = this.systemIds != null;
				if (flag2)
				{
					for (int i = 0; i < openIds.Count; i++)
					{
						bool flag3 = this.systemIds.Contains(openIds[i]);
						if (flag3)
						{
							num = 1;
							break;
						}
					}
					for (int j = 0; j < closeIds.Count; j++)
					{
						bool flag4 = this.systemIds.Contains(closeIds[j]);
						if (flag4)
						{
							bool flag5 = num == 1;
							if (flag5)
							{
								num = 3;
							}
							else
							{
								num = 2;
							}
							break;
						}
					}
				}
				bool flag6 = num == 0;
				if (!flag6)
				{
					bool flag7 = num == 1;
					if (flag7)
					{
						DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.RefreshUI(null);
					}
					else
					{
						DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.RefreshUI(closeIds);
					}
				}
			}
		}

		// Token: 0x0600B9DB RID: 47579 RVA: 0x0025D010 File Offset: 0x0025B210
		public bool GetTabRedDotState(XSysDefine sys)
		{
			bool flag = false;
			bool result;
			if (sys != XSysDefine.XSys_FirstPass)
			{
				switch (sys)
				{
				case XSysDefine.XSys_CrushingSeal:
					this.m_levelRedDotDic.TryGetValue(sys, out flag);
					return this.IsFrozenSealHadRedDot() || flag;
				case XSysDefine.XSys_WeekNest:
				case (XSysDefine)608:
					break;
				case XSysDefine.XSys_Holiday:
					return this.HolidayRedPoint;
				case XSysDefine.XSys_Announcement:
				{
					XAnnouncementDocument specificDocument = XDocuments.GetSpecificDocument<XAnnouncementDocument>(XAnnouncementDocument.uuID);
					return specificDocument.RedPoint;
				}
				default:
					if (sys == XSysDefine.XSys_CampDuel)
					{
						return XCampDuelDocument.Doc.IsRedPoint();
					}
					break;
				}
				this.m_levelRedDotDic.TryGetValue(sys, out flag);
				result = (flag | XSingleton<XGameSysMgr>.singleton.GetSysRedPointState(sys));
			}
			else
			{
				this.m_levelRedDotDic.TryGetValue(sys, out flag);
				result = (FirstPassDocument.Doc.IsHadOutRedDot || flag);
			}
			return result;
		}

		// Token: 0x0600B9DC RID: 47580 RVA: 0x0025D0E0 File Offset: 0x0025B2E0
		public void InitSealData()
		{
			this._staticSealDatas = XTempActivityDocument.Doc.GetDataByActivityType(this.curSealActid);
		}

		// Token: 0x0600B9DD RID: 47581 RVA: 0x0025D0F9 File Offset: 0x0025B2F9
		public void SealOffsetDayUpdate()
		{
			this.CurSealActID = XTempActivityDocument.Doc.GetCrushingSealActid();
			DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.UpdateSealTime();
		}

		// Token: 0x0600B9DE RID: 47582 RVA: 0x0025D118 File Offset: 0x0025B318
		public void RefeshLevelRedDot(uint curLevel)
		{
			bool flag = this.HisMaxLevel.PreLevel >= curLevel;
			if (!flag)
			{
				this.HisMaxLevel.PreLevel = curLevel;
				for (int i = 0; i < XOperatingActivityDocument.OperatingActivityTable.Table.Length; i++)
				{
					OperatingActivity.RowData rowData = XOperatingActivityDocument.OperatingActivityTable.Table[i];
					int sysOpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel((int)rowData.SysID);
					bool flag2 = (ulong)curLevel == (ulong)((long)sysOpenLevel);
					if (flag2)
					{
						bool flag3 = this.m_levelRedDotDic.ContainsKey((XSysDefine)rowData.SysID);
						if (flag3)
						{
							this.m_levelRedDotDic[(XSysDefine)rowData.SysID] = true;
						}
						else
						{
							this.m_levelRedDotDic.Add((XSysDefine)rowData.SysID, true);
						}
					}
					else
					{
						bool flag4 = !this.m_levelRedDotDic.ContainsKey((XSysDefine)rowData.SysID);
						if (flag4)
						{
							this.m_levelRedDotDic.Add((XSysDefine)rowData.SysID, false);
						}
					}
				}
				this.RefreshRedPoints();
			}
		}

		// Token: 0x0600B9DF RID: 47583 RVA: 0x0025D214 File Offset: 0x0025B414
		public void CancleLevelRedDot(XSysDefine define)
		{
			bool flag = this.m_levelRedDotDic.ContainsKey(define);
			if (flag)
			{
				this.m_levelRedDotDic[define] = false;
			}
			this.RefreshRedPoints();
		}

		// Token: 0x0600B9E0 RID: 47584 RVA: 0x0025D248 File Offset: 0x0025B448
		protected bool OnSealUpdate(XEventArgs e)
		{
			XActivityTaskUpdatedArgs xactivityTaskUpdatedArgs = e as XActivityTaskUpdatedArgs;
			for (int i = 0; i < this.SealDatas.Count; i++)
			{
				bool flag = this.SealDatas[i].taskid == xactivityTaskUpdatedArgs.xTaskID;
				if (flag)
				{
					DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.OnFsTaskStateUpdated(xactivityTaskUpdatedArgs.xTaskID, (ActivityTaskState)xactivityTaskUpdatedArgs.xState);
					this.RefreshRedPoints();
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B9E1 RID: 47585 RVA: 0x0025D2C0 File Offset: 0x0025B4C0
		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			XPlayerLevelChangedEventArgs xplayerLevelChangedEventArgs = arg as XPlayerLevelChangedEventArgs;
			this.RefeshLevelRedDot(xplayerLevelChangedEventArgs.level);
			return true;
		}

		// Token: 0x0600B9E2 RID: 47586 RVA: 0x0025D2E8 File Offset: 0x0025B4E8
		public FestScene.RowData GetFestivalData(uint id)
		{
			return XOperatingActivityDocument.m_FestivalTable.GetByid(id);
		}

		// Token: 0x0600B9E3 RID: 47587 RVA: 0x0025D308 File Offset: 0x0025B508
		public void EnterHolidayLevel()
		{
			bool flag = this._holiday_data.HolidayID == 0U;
			if (!flag)
			{
				SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this._holiday_data.SceneID);
				bool flag2 = sceneData != null;
				if (flag2)
				{
					bool flag3 = sceneData.syncMode == 0;
					if (flag3)
					{
						bool flag4 = XTeamDocument.GoSingleBattleBeforeNeed(new EventDelegate(this.EnterHolidayLevel));
						if (!flag4)
						{
							PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
							ptcC2G_EnterSceneReq.Data.sceneID = this._holiday_data.SceneID;
							XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
						}
					}
					else
					{
						XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
						XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
						int expIDBySceneID = specificDocument.GetExpIDBySceneID(this._holiday_data.SceneID);
						specificDocument2.SetAndMatch(expIDBySceneID);
					}
				}
			}
		}

		// Token: 0x0600B9E4 RID: 47588 RVA: 0x0025D3E0 File Offset: 0x0025B5E0
		public bool CheckFestivalIsOpen(uint sceneid)
		{
			return this._holiday_data.SceneID == sceneid;
		}

		// Token: 0x0600B9E5 RID: 47589 RVA: 0x0025D400 File Offset: 0x0025B600
		public uint GetFestivalLeftTime()
		{
			return this._holiday_data.LeftTime;
		}

		// Token: 0x0600B9E6 RID: 47590 RVA: 0x0025D420 File Offset: 0x0025B620
		public uint GetFestivalLeftCount()
		{
			return this._holiday_data.LeftCount;
		}

		// Token: 0x0600B9E7 RID: 47591 RVA: 0x0025D440 File Offset: 0x0025B640
		public string GetFestivalPicPath()
		{
			FestScene.RowData festivalData = this.GetFestivalData(this._holiday_data.HolidayID);
			bool flag = festivalData == null;
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = festivalData.PicPath;
			}
			return result;
		}

		// Token: 0x0600B9E8 RID: 47592 RVA: 0x0025D478 File Offset: 0x0025B678
		public uint[] GetFestivalRewardList()
		{
			FestScene.RowData festivalData = this.GetFestivalData(this._holiday_data.HolidayID);
			bool flag = festivalData == null;
			uint[] result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = festivalData.RewardList;
			}
			return result;
		}

		// Token: 0x0600B9E9 RID: 47593 RVA: 0x0025D4B0 File Offset: 0x0025B6B0
		public void SendQueryHolidayData()
		{
			RpcC2G_GetHolidayStageInfo rpc = new RpcC2G_GetHolidayStageInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B9EA RID: 47594 RVA: 0x0025D4D0 File Offset: 0x0025B6D0
		public void SetHolidayData(GetHolidayStageInfoRes data)
		{
			this._holiday_data = default(XOperatingActivityDocument.HolidayData);
			this._holiday_data.HolidayID = data.holidayid;
			this._holiday_data.LeftCount = data.havetimes;
			this._holiday_data.LeftTime = data.lasttime;
			this._holiday_data.SceneID = data.sceneid;
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Holiday, true);
			this.RefreshRedPoints();
			bool flag = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_HolidayHandler != null;
				if (flag2)
				{
					DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_HolidayHandler.Refresh();
				}
			}
		}

		// Token: 0x0600B9EB RID: 47595 RVA: 0x0025D57C File Offset: 0x0025B77C
		private void DetachPandoraSDKRedPoint()
		{
			List<ActivityTabInfo> pandoraSDKTabListInfo = XSingleton<XPandoraSDKDocument>.singleton.GetPandoraSDKTabListInfo("action");
			bool flag = pandoraSDKTabListInfo != null;
			if (flag)
			{
				for (int i = 0; i < pandoraSDKTabListInfo.Count; i++)
				{
					XSingleton<XGameSysMgr>.singleton.DetachSysRedPointRelative(pandoraSDKTabListInfo[i].sysID);
				}
			}
		}

		// Token: 0x0600B9EC RID: 47596 RVA: 0x0025D5D4 File Offset: 0x0025B7D4
		public void AttachPandoraRedPoint(int sysID)
		{
			int sys = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_OperatingActivity);
			bool flag = sysID != 0;
			if (flag)
			{
				XSingleton<XGameSysMgr>.singleton.AttachSysRedPointRelative(sys, sysID, false);
			}
		}

		// Token: 0x04004A46 RID: 19014
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XOperatingActivityDocument");

		// Token: 0x04004A47 RID: 19015
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04004A48 RID: 19016
		private static OperatingActivity m_OperatingActivityTable = new OperatingActivity();

		// Token: 0x04004A49 RID: 19017
		private static FestScene m_FestivalTable = new FestScene();

		// Token: 0x04004A4A RID: 19018
		public HistoryMaxStruct HisMaxLevel = new HistoryMaxStruct();

		// Token: 0x04004A4B RID: 19019
		public Dictionary<int, FrozenSealState> _forzenStates = new Dictionary<int, FrozenSealState>();

		// Token: 0x04004A4D RID: 19021
		private HashSet<uint> m_systemIds;

		// Token: 0x04004A4E RID: 19022
		protected List<SuperActivityTask.RowData> _staticSealDatas = new List<SuperActivityTask.RowData>();

		// Token: 0x04004A4F RID: 19023
		protected uint curSealActid = 0U;

		// Token: 0x04004A50 RID: 19024
		private XOperatingActivityDocument.HolidayData _holiday_data;

		// Token: 0x04004A51 RID: 19025
		public XOperatingActivityDocument.LuckyTurntableInfo m_LuckyTurntableData = new XOperatingActivityDocument.LuckyTurntableInfo();

		// Token: 0x04004A52 RID: 19026
		private Dictionary<XSysDefine, bool> m_levelRedDotDic = new Dictionary<XSysDefine, bool>();

		// Token: 0x020019B4 RID: 6580
		private struct HolidayData
		{
			// Token: 0x06011059 RID: 69721 RVA: 0x00454799 File Offset: 0x00452999
			public void Init()
			{
				this.HolidayID = 0U;
				this.LeftCount = 0U;
				this.LeftTime = 0U;
				this.SceneID = 0U;
			}

			// Token: 0x04007F9A RID: 32666
			public uint HolidayID;

			// Token: 0x04007F9B RID: 32667
			public uint LeftCount;

			// Token: 0x04007F9C RID: 32668
			public uint LeftTime;

			// Token: 0x04007F9D RID: 32669
			public uint SceneID;
		}

		// Token: 0x020019B5 RID: 6581
		public class LuckyTurntableItem
		{
			// Token: 0x04007F9E RID: 32670
			public int ItemID;

			// Token: 0x04007F9F RID: 32671
			public int ItemCount;

			// Token: 0x04007FA0 RID: 32672
			public bool HasReceived;
		}

		// Token: 0x020019B6 RID: 6582
		public class LuckyTurntableInfo
		{
			// Token: 0x0601105B RID: 69723 RVA: 0x004547B8 File Offset: 0x004529B8
			public void RefreshItems(List<ItemRecord> records)
			{
				bool flag = this.Items.Count != records.Count;
				if (flag)
				{
					this.Items.Clear();
					for (int i = records.Count; i > 0; i--)
					{
						this.Items.Add(new XOperatingActivityDocument.LuckyTurntableItem());
					}
				}
				this.CanBuy = false;
				for (int j = 0; j < records.Count; j++)
				{
					XOperatingActivityDocument.LuckyTurntableItem luckyTurntableItem = this.Items[j];
					ItemRecord itemRecord = records[j];
					luckyTurntableItem.ItemID = (int)itemRecord.itemID;
					luckyTurntableItem.ItemCount = (int)itemRecord.itemCount;
					luckyTurntableItem.HasReceived = itemRecord.isreceive;
					bool flag2 = !luckyTurntableItem.HasReceived;
					if (flag2)
					{
						this.CanBuy = true;
					}
				}
			}

			// Token: 0x04007FA1 RID: 32673
			public int CurrencyType;

			// Token: 0x04007FA2 RID: 32674
			public uint Price;

			// Token: 0x04007FA3 RID: 32675
			public bool IsPay;

			// Token: 0x04007FA4 RID: 32676
			public List<XOperatingActivityDocument.LuckyTurntableItem> Items = new List<XOperatingActivityDocument.LuckyTurntableItem>();

			// Token: 0x04007FA5 RID: 32677
			public bool CanBuy;
		}
	}
}
