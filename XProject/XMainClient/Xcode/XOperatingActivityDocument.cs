using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XOperatingActivityDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XOperatingActivityDocument.uuID;
			}
		}

		public static OperatingActivity OperatingActivityTable
		{
			get
			{
				return XOperatingActivityDocument.m_OperatingActivityTable;
			}
		}

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

		public static XOperatingActivityDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XOperatingActivityDocument.uuID) as XOperatingActivityDocument;
			}
		}

		public XOperatingActivityView View { get; set; }

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

		private bool HolidayRedPoint
		{
			get
			{
				return this._holiday_data.LeftCount > 0U;
			}
		}

		public void RequestGetLuckyTurntableData()
		{
			RpcC2G_GetLuckyActivityInfo rpc = new RpcC2G_GetLuckyActivityInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void RequestBuyLuckyTurntable()
		{
			RpcC2G_BuyDraw rpc = new RpcC2G_BuyDraw();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void RequestUseLuckyTurntable()
		{
			RpcC2G_LotteryDraw rpc = new RpcC2G_LotteryDraw();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public static void Execute(OnLoadedCallback callback = null)
		{
			XOperatingActivityDocument.AsyncLoader.AddTask("Table/OperatingActivity", XOperatingActivityDocument.m_OperatingActivityTable, false);
			XOperatingActivityDocument.AsyncLoader.AddTask("Table/festivalscenelist", XOperatingActivityDocument.m_FestivalTable, false);
			XOperatingActivityDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ActivityTaskUpdate, new XComponent.XEventHandler(this.OnSealUpdate));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			this.DetachPandoraSDKRedPoint();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.SendQueryHolidayData();
		}

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

		public void RefreshRedPoints()
		{
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_OperatingActivity, true);
			bool flag = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.RefreshRedpoint();
			}
		}

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

		public void InitSealData()
		{
			this._staticSealDatas = XTempActivityDocument.Doc.GetDataByActivityType(this.curSealActid);
		}

		public void SealOffsetDayUpdate()
		{
			this.CurSealActID = XTempActivityDocument.Doc.GetCrushingSealActid();
			DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.UpdateSealTime();
		}

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

		public void CancleLevelRedDot(XSysDefine define)
		{
			bool flag = this.m_levelRedDotDic.ContainsKey(define);
			if (flag)
			{
				this.m_levelRedDotDic[define] = false;
			}
			this.RefreshRedPoints();
		}

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

		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			XPlayerLevelChangedEventArgs xplayerLevelChangedEventArgs = arg as XPlayerLevelChangedEventArgs;
			this.RefeshLevelRedDot(xplayerLevelChangedEventArgs.level);
			return true;
		}

		public FestScene.RowData GetFestivalData(uint id)
		{
			return XOperatingActivityDocument.m_FestivalTable.GetByid(id);
		}

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

		public bool CheckFestivalIsOpen(uint sceneid)
		{
			return this._holiday_data.SceneID == sceneid;
		}

		public uint GetFestivalLeftTime()
		{
			return this._holiday_data.LeftTime;
		}

		public uint GetFestivalLeftCount()
		{
			return this._holiday_data.LeftCount;
		}

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

		public void SendQueryHolidayData()
		{
			RpcC2G_GetHolidayStageInfo rpc = new RpcC2G_GetHolidayStageInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void AttachPandoraRedPoint(int sysID)
		{
			int sys = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_OperatingActivity);
			bool flag = sysID != 0;
			if (flag)
			{
				XSingleton<XGameSysMgr>.singleton.AttachSysRedPointRelative(sys, sysID, false);
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XOperatingActivityDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static OperatingActivity m_OperatingActivityTable = new OperatingActivity();

		private static FestScene m_FestivalTable = new FestScene();

		public HistoryMaxStruct HisMaxLevel = new HistoryMaxStruct();

		public Dictionary<int, FrozenSealState> _forzenStates = new Dictionary<int, FrozenSealState>();

		private HashSet<uint> m_systemIds;

		protected List<SuperActivityTask.RowData> _staticSealDatas = new List<SuperActivityTask.RowData>();

		protected uint curSealActid = 0U;

		private XOperatingActivityDocument.HolidayData _holiday_data;

		public XOperatingActivityDocument.LuckyTurntableInfo m_LuckyTurntableData = new XOperatingActivityDocument.LuckyTurntableInfo();

		private Dictionary<XSysDefine, bool> m_levelRedDotDic = new Dictionary<XSysDefine, bool>();

		private struct HolidayData
		{

			public void Init()
			{
				this.HolidayID = 0U;
				this.LeftCount = 0U;
				this.LeftTime = 0U;
				this.SceneID = 0U;
			}

			public uint HolidayID;

			public uint LeftCount;

			public uint LeftTime;

			public uint SceneID;
		}

		public class LuckyTurntableItem
		{

			public int ItemID;

			public int ItemCount;

			public bool HasReceived;
		}

		public class LuckyTurntableInfo
		{

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

			public int CurrencyType;

			public uint Price;

			public bool IsPay;

			public List<XOperatingActivityDocument.LuckyTurntableItem> Items = new List<XOperatingActivityDocument.LuckyTurntableItem>();

			public bool CanBuy;
		}
	}
}
