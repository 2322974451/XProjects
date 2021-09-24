using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XOperatingActivityView : DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>
	{

		private XOperatingActivityDocument m_doc
		{
			get
			{
				return XOperatingActivityDocument.Doc;
			}
		}

		public override string fileName
		{
			get
			{
				return "OperatingActivity/OperatingActivityDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XCampDuelMainHandler>(ref this.m_CampDuelMainHandler);
			DlgHandlerBase.EnsureUnload<FirstPassMainHandler>(ref this.m_FirstPassMainHandler);
			DlgHandlerBase.EnsureUnload<FirstPassMwcxHandler>(ref this.m_firstpassMwcxHandler);
			DlgHandlerBase.EnsureUnload<FirstPassGhjcHandler>(ref this.m_firstpassGhjcHandler);
			DlgHandlerBase.EnsureUnload<FirstPassGuindRankHandler>(ref this.m_firstpassGuildRankHandler);
			DlgHandlerBase.EnsureUnload<FrozenSealHandler>(ref this.m_firstpassFsHandler);
			DlgHandlerBase.EnsureUnload<FlowerActivityHandler>(ref this.m_flowerActivityHandler);
			DlgHandlerBase.EnsureUnload<XLevelSealView>(ref this.m_LevelSealHandler);
			DlgHandlerBase.EnsureUnload<HolidayHandler>(ref this.m_HolidayHandler);
			DlgHandlerBase.EnsureUnload<AnnouncementHandler>(ref this.m_AnnouncementHandler);
			DlgHandlerBase.EnsureUnload<PandoraSDKHandler>(ref this.m_pandoraSDKHandler);
			DlgHandlerBase.EnsureUnload<OldFriendsReplayHandler>(ref this.m_oldFriendsBackHandler);
			DlgHandlerBase.EnsureUnload<LuckyTurntableFrameHandler>(ref this.m_luckyTurntableFrameHandler);
			DlgHandlerBase.EnsureUnload<AncientHandler>(ref this.m_bigPrizeHandler);
			bool flag = this._FxFirework != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._FxFirework, true);
				this._FxFirework = null;
			}
			XSingleton<XPandoraSDKDocument>.singleton.ClosePandoraTabPanel("action");
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
			this.m_doc.View = this;
		}

		protected override void OnHide()
		{
			base.OnHide();
			bool flag = this.m_TabsDic != null;
			if (flag)
			{
				foreach (KeyValuePair<XSysDefine, IXUICheckBox> keyValuePair in this.m_TabsDic)
				{
					bool flag2 = keyValuePair.Value != null;
					if (flag2)
					{
						keyValuePair.Value.ForceSetFlag(false);
					}
				}
			}
			bool flag3 = this.m_CurrHandler != null;
			if (flag3)
			{
				this.m_CurrHandler.SetVisible(false);
			}
			this.m_selectSys = XSysDefine.XSys_None;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.InitTabs(this.m_selectSys);
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			bool flag = this.m_CurrHandler != null;
			if (flag)
			{
				this.m_CurrHandler.StackRefresh();
			}
			this.RefreshRedpoint();
		}

		public void Refresh()
		{
			bool flag = this.m_CurrHandler != null;
			if (flag)
			{
				this.m_CurrHandler.RefreshData();
			}
		}

		public void RefreshUI(List<uint> removeIds = null)
		{
			bool flag = removeIds != null;
			if (flag)
			{
				bool flag2 = removeIds.Contains((uint)XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this.m_selectSys));
				if (flag2)
				{
					this.m_selectSys = XSysDefine.XSys_None;
				}
			}
			this.InitTabs(this.m_selectSys);
			ILuaEngine xluaEngine = XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine;
			xluaEngine.hotfixMgr.TryFixRefresh(HotfixMode.AFTER, base.luaFileName, base.uiBehaviour.gameObject);
		}

		public void Show(XSysDefine sys = XSysDefine.XSys_None, bool isDebug = false)
		{
			bool flag = base.IsVisible();
			if (!flag)
			{
				this.m_selectSys = sys;
				this.m_isDebug = isDebug;
				this.SetVisibleWithAnimation(true, null);
			}
		}

		private void InitTabs(XSysDefine system)
		{
			this.m_TabsDic.Clear();
			List<XSysDefine> list = new List<XSysDefine>();
			base.uiBehaviour.m_TabPool.FakeReturnAll();
			int num = 0;
			int i = 0;
			while (i < XOperatingActivityDocument.OperatingActivityTable.Table.Length)
			{
				OperatingActivity.RowData rowData = XOperatingActivityDocument.OperatingActivityTable.Table[i];
				XSysDefine sysID = (XSysDefine)rowData.SysID;
				bool flag = this.m_doc.SysIsOpen(sysID) || this.m_isDebug;
				if (flag)
				{
					bool isPandoraTab = rowData.IsPandoraTab;
					if (!isPandoraTab)
					{
						list.Add(sysID);
						GameObject gameObject = base.uiBehaviour.m_TabPool.FetchGameObject(false);
						gameObject.transform.parent = base.uiBehaviour.m_tabParent;
						gameObject.transform.localScale = Vector3.one;
						gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)base.uiBehaviour.m_TabPool.TplHeight * num), 0f);
						IXUICheckBox ixuicheckBox = gameObject.transform.FindChild("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
						ixuicheckBox.ID = (ulong)rowData.SysID;
						this.InitTabInfo(ixuicheckBox.gameObject, rowData.TabName, rowData.TabIcon);
						ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClicked));
						ixuicheckBox.ForceSetFlag(false);
						this.m_TabsDic.Add(sysID, ixuicheckBox);
						num++;
					}
				}
				IL_16C:
				i++;
				continue;
				goto IL_16C;
			}
			bool flag2 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PandoraSDK);
			if (flag2)
			{
				List<ActivityTabInfo> pandoraSDKTabListInfo = XSingleton<XPandoraSDKDocument>.singleton.GetPandoraSDKTabListInfo("action");
				bool flag3 = pandoraSDKTabListInfo != null;
				if (flag3)
				{
					for (int j = 0; j < pandoraSDKTabListInfo.Count; j++)
					{
						bool flag4 = !pandoraSDKTabListInfo[j].tabShow;
						if (!flag4)
						{
							bool flag5 = this.m_doc.SysIsOpen((XSysDefine)pandoraSDKTabListInfo[j].sysID);
							if (flag5)
							{
								list.Add((XSysDefine)pandoraSDKTabListInfo[j].sysID);
								GameObject gameObject = base.uiBehaviour.m_TabPool.FetchGameObject(false);
								gameObject.transform.parent = base.uiBehaviour.m_tabParent;
								gameObject.transform.localScale = Vector3.one;
								gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)base.uiBehaviour.m_TabPool.TplHeight * num), 0f);
								IXUICheckBox ixuicheckBox2 = gameObject.transform.FindChild("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
								ixuicheckBox2.ID = (ulong)((long)pandoraSDKTabListInfo[j].sysID);
								ixuicheckBox2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClicked));
								ixuicheckBox2.ForceSetFlag(false);
								this.InitTabInfo(ixuicheckBox2.gameObject, pandoraSDKTabListInfo[j].tabName, "GiftBag19");
								this.m_TabsDic.Add((XSysDefine)pandoraSDKTabListInfo[j].sysID, ixuicheckBox2);
								num++;
							}
						}
					}
				}
			}
			base.uiBehaviour.m_TabPool.ActualReturnAll(false);
			this.SelectDefaultTab(list, system);
			this.RefreshRedpoint();
		}

		private void InitTabInfo(GameObject tab, string tabName, string tabIcon)
		{
			IXUILabel ixuilabel = tab.transform.Find("TextLabel").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = tab.transform.Find("SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
			GameObject gameObject = tab.transform.Find("RedPoint").gameObject;
			IXUISprite ixuisprite = tab.transform.Find("P/P").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = tab.transform.Find("Selected/P").GetComponent("XUISprite") as IXUISprite;
			ixuilabel.SetText(tabName);
			ixuilabel2.SetText(tabName);
			gameObject.SetActive(false);
			ixuisprite.SetSprite(tabIcon);
			ixuisprite2.SetSprite(tabIcon);
		}

		private void SelectDefaultTab(List<XSysDefine> listOpen, XSysDefine sys)
		{
			bool flag = this.m_TabsDic.ContainsKey(sys);
			if (flag)
			{
				this.m_TabsDic[sys].bChecked = true;
			}
			else
			{
				bool flag2 = sys == XSysDefine.XSys_None;
				if (flag2)
				{
					for (int i = 0; i < listOpen.Count; i++)
					{
						bool flag3 = !this.m_doc.GetTabRedDotState(listOpen[i]);
						if (!flag3)
						{
							this.m_TabsDic[listOpen[i]].bChecked = true;
							return;
						}
					}
				}
				bool flag4 = listOpen.Count > 0;
				if (flag4)
				{
					this.m_TabsDic[listOpen[0]].bChecked = true;
				}
			}
		}

		public void RefreshRedpoint()
		{
			foreach (KeyValuePair<XSysDefine, IXUICheckBox> keyValuePair in this.m_TabsDic)
			{
				bool flag = keyValuePair.Value.IsVisible();
				if (flag)
				{
					GameObject gameObject = keyValuePair.Value.gameObject.transform.Find("RedPoint").gameObject;
					gameObject.SetActive(this.m_doc.GetTabRedDotState(keyValuePair.Key));
				}
			}
		}

		private void SetupHandlers(XSysDefine sys)
		{
			this.m_selectSys = sys;
			bool flag = XSingleton<XPandoraSDKDocument>.singleton.IsPandoraSDKTab(sys, "action");
			if (flag)
			{
				this.m_CurrHandler = DlgHandlerBase.EnsureCreate<PandoraSDKHandler>(ref this.m_pandoraSDKHandler, base.uiBehaviour.m_rightTra, false, this);
				bool flag2 = this.m_pandoraSDKHandler != null;
				if (flag2)
				{
					this.m_pandoraSDKHandler.SetCurrSys(sys);
				}
			}
			else
			{
				this.m_doc.CancleLevelRedDot(sys);
				XSysDefine xsysDefine = sys;
				if (xsysDefine <= XSysDefine.XSys_Shanggu)
				{
					if (xsysDefine == XSysDefine.XSys_LevelSeal)
					{
						this.m_CurrHandler = DlgHandlerBase.EnsureCreate<XLevelSealView>(ref this.m_LevelSealHandler, base.uiBehaviour.m_rightTra, false, this);
						return;
					}
					if (xsysDefine == XSysDefine.XSys_Shanggu)
					{
						this.m_CurrHandler = DlgHandlerBase.EnsureCreate<AncientHandler>(ref this.m_bigPrizeHandler, base.uiBehaviour.m_rightTra, false, this);
						return;
					}
				}
				else
				{
					switch (xsysDefine)
					{
					case XSysDefine.XSys_FirstPass:
						this.m_CurrHandler = DlgHandlerBase.EnsureCreate<FirstPassMainHandler>(ref this.m_FirstPassMainHandler, base.uiBehaviour.m_rightTra, false, this);
						return;
					case XSysDefine.XSys_MWCX:
						this.m_CurrHandler = DlgHandlerBase.EnsureCreate<FirstPassMwcxHandler>(ref this.m_firstpassMwcxHandler, base.uiBehaviour.m_rightTra, false, this);
						return;
					case XSysDefine.XSys_GHJC:
						this.m_CurrHandler = DlgHandlerBase.EnsureCreate<FirstPassGhjcHandler>(ref this.m_firstpassGhjcHandler, base.uiBehaviour.m_rightTra, false, this);
						return;
					case XSysDefine.XSys_GuildRank:
						this.m_CurrHandler = DlgHandlerBase.EnsureCreate<FirstPassGuindRankHandler>(ref this.m_firstpassGuildRankHandler, base.uiBehaviour.m_rightTra, false, this);
						return;
					case XSysDefine.XSys_Flower_Activity:
						this.m_CurrHandler = DlgHandlerBase.EnsureCreate<FlowerActivityHandler>(ref this.m_flowerActivityHandler, base.uiBehaviour.m_rightTra, false, this);
						return;
					case XSysDefine.XSys_CrushingSeal:
						this.m_CurrHandler = DlgHandlerBase.EnsureCreate<FrozenSealHandler>(ref this.m_firstpassFsHandler, base.uiBehaviour.m_rightTra, false, this);
						return;
					case XSysDefine.XSys_WeekNest:
					case (XSysDefine)608:
					case XSysDefine.XSys_Patface:
					case XSysDefine.XSys_PandoraSDK:
						break;
					case XSysDefine.XSys_Holiday:
						this.m_CurrHandler = DlgHandlerBase.EnsureCreate<HolidayHandler>(ref this.m_HolidayHandler, base.uiBehaviour.m_rightTra, false, this);
						return;
					case XSysDefine.XSys_Announcement:
						this.m_CurrHandler = DlgHandlerBase.EnsureCreate<AnnouncementHandler>(ref this.m_AnnouncementHandler, base.uiBehaviour.m_rightTra, false, this);
						return;
					case XSysDefine.XSys_OldFriendsBack:
						this.m_CurrHandler = DlgHandlerBase.EnsureCreate<OldFriendsReplayHandler>(ref this.m_oldFriendsBackHandler, base.uiBehaviour.m_rightTra, false, this);
						return;
					case XSysDefine.XSys_CampDuel:
						this.m_CurrHandler = DlgHandlerBase.EnsureCreate<XCampDuelMainHandler>(ref this.m_CampDuelMainHandler, base.uiBehaviour.m_rightTra, false, this);
						return;
					default:
						if (xsysDefine == XSysDefine.XSys_LuckyTurntable)
						{
							this.m_CurrHandler = DlgHandlerBase.EnsureCreate<LuckyTurntableFrameHandler>(ref this.m_luckyTurntableFrameHandler, base.uiBehaviour.m_rightTra, false, this);
							return;
						}
						break;
					}
				}
				this.m_CurrHandler = null;
				XSingleton<XDebug>.singleton.AddLog("System may be implemented in lua:", sys.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		public bool OnTabClicked(IXUICheckBox checkbox)
		{
			bool flag = !checkbox.bChecked;
			return !flag && this.RefreshUi((XSysDefine)checkbox.ID);
		}

		private bool RefreshUi(XSysDefine sys)
		{
			bool flag = this.m_CurrHandler != null;
			if (flag)
			{
				this.m_CurrHandler.SetVisible(false);
			}
			this.SetupHandlers(sys);
			bool flag2 = this.m_CurrHandler != null;
			if (flag2)
			{
				this.m_CurrHandler.SetVisible(true);
			}
			return true;
		}

		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		public void OnFsTaskStateUpdated(uint taskId, ActivityTaskState state)
		{
			bool flag = this.m_firstpassFsHandler != null && this.m_firstpassFsHandler.IsVisible();
			if (flag)
			{
				this.m_firstpassFsHandler.RefreshItemWithTaskidAndState(taskId, state);
			}
		}

		public void PlayCrushingSealFx()
		{
			XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/zhuanzhi", true, AudioChannel.Action);
			bool flag = this._FxFirework != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._FxFirework, true);
			}
			this._FxFirework = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_yh", null, true);
			this._FxFirework.Play(DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.uiBehaviour.m_FxFirework.transform, Vector3.zero, Vector3.one, 1f, true, false);
		}

		public void UpdateTab()
		{
		}

		public void UpdateSealTime()
		{
			bool flag = this.m_firstpassFsHandler != null && this.m_firstpassFsHandler.IsVisible();
			if (flag)
			{
				this.m_firstpassFsHandler.UpdateTime();
			}
		}

		private XSysDefine m_selectSys = XSysDefine.XSys_None;

		private bool m_isDebug;

		private DlgHandlerBase m_CurrHandler;

		public AnnouncementHandler m_AnnouncementHandler;

		public HolidayHandler m_HolidayHandler;

		private XCampDuelMainHandler m_CampDuelMainHandler;

		private FirstPassMainHandler m_FirstPassMainHandler;

		private FirstPassMwcxHandler m_firstpassMwcxHandler;

		private FirstPassGhjcHandler m_firstpassGhjcHandler;

		private FirstPassGuindRankHandler m_firstpassGuildRankHandler;

		private FrozenSealHandler m_firstpassFsHandler;

		private FlowerActivityHandler m_flowerActivityHandler;

		public XLevelSealView m_LevelSealHandler;

		public OldFriendsReplayHandler m_oldFriendsBackHandler;

		private PandoraSDKHandler m_pandoraSDKHandler;

		public AncientHandler m_bigPrizeHandler;

		public LuckyTurntableFrameHandler m_luckyTurntableFrameHandler;

		private Dictionary<XSysDefine, IXUICheckBox> m_TabsDic = new Dictionary<XSysDefine, IXUICheckBox>();

		private XFx _FxFirework;
	}
}
