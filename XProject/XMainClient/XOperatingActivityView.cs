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
	// Token: 0x02000CFB RID: 3323
	internal class XOperatingActivityView : DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>
	{
		// Token: 0x170032B1 RID: 12977
		// (get) Token: 0x0600B9EF RID: 47599 RVA: 0x0025D68C File Offset: 0x0025B88C
		private XOperatingActivityDocument m_doc
		{
			get
			{
				return XOperatingActivityDocument.Doc;
			}
		}

		// Token: 0x170032B2 RID: 12978
		// (get) Token: 0x0600B9F0 RID: 47600 RVA: 0x0025D6A4 File Offset: 0x0025B8A4
		public override string fileName
		{
			get
			{
				return "OperatingActivity/OperatingActivityDlg";
			}
		}

		// Token: 0x170032B3 RID: 12979
		// (get) Token: 0x0600B9F1 RID: 47601 RVA: 0x0025D6BC File Offset: 0x0025B8BC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170032B4 RID: 12980
		// (get) Token: 0x0600B9F2 RID: 47602 RVA: 0x0025D6D0 File Offset: 0x0025B8D0
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170032B5 RID: 12981
		// (get) Token: 0x0600B9F3 RID: 47603 RVA: 0x0025D6E4 File Offset: 0x0025B8E4
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170032B6 RID: 12982
		// (get) Token: 0x0600B9F4 RID: 47604 RVA: 0x0025D6F8 File Offset: 0x0025B8F8
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B9F5 RID: 47605 RVA: 0x0025D70B File Offset: 0x0025B90B
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600B9F6 RID: 47606 RVA: 0x0025D715 File Offset: 0x0025B915
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600B9F7 RID: 47607 RVA: 0x0025D73C File Offset: 0x0025B93C
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

		// Token: 0x0600B9F8 RID: 47608 RVA: 0x0025D831 File Offset: 0x0025BA31
		protected override void Init()
		{
			base.Init();
			this.m_doc.View = this;
		}

		// Token: 0x0600B9F9 RID: 47609 RVA: 0x0025D848 File Offset: 0x0025BA48
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

		// Token: 0x0600B9FA RID: 47610 RVA: 0x0025D8F0 File Offset: 0x0025BAF0
		protected override void OnShow()
		{
			base.OnShow();
			this.InitTabs(this.m_selectSys);
		}

		// Token: 0x0600B9FB RID: 47611 RVA: 0x0025D908 File Offset: 0x0025BB08
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

		// Token: 0x0600B9FC RID: 47612 RVA: 0x0025D940 File Offset: 0x0025BB40
		public void Refresh()
		{
			bool flag = this.m_CurrHandler != null;
			if (flag)
			{
				this.m_CurrHandler.RefreshData();
			}
		}

		// Token: 0x0600B9FD RID: 47613 RVA: 0x0025D968 File Offset: 0x0025BB68
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

		// Token: 0x0600B9FE RID: 47614 RVA: 0x0025D9D4 File Offset: 0x0025BBD4
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

		// Token: 0x0600B9FF RID: 47615 RVA: 0x0025DA08 File Offset: 0x0025BC08
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

		// Token: 0x0600BA00 RID: 47616 RVA: 0x0025DD74 File Offset: 0x0025BF74
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

		// Token: 0x0600BA01 RID: 47617 RVA: 0x0025DE44 File Offset: 0x0025C044
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

		// Token: 0x0600BA02 RID: 47618 RVA: 0x0025DF00 File Offset: 0x0025C100
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

		// Token: 0x0600BA03 RID: 47619 RVA: 0x0025DFA0 File Offset: 0x0025C1A0
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

		// Token: 0x0600BA04 RID: 47620 RVA: 0x0025E27C File Offset: 0x0025C47C
		public bool OnTabClicked(IXUICheckBox checkbox)
		{
			bool flag = !checkbox.bChecked;
			return !flag && this.RefreshUi((XSysDefine)checkbox.ID);
		}

		// Token: 0x0600BA05 RID: 47621 RVA: 0x0025E2AC File Offset: 0x0025C4AC
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

		// Token: 0x0600BA06 RID: 47622 RVA: 0x0025E300 File Offset: 0x0025C500
		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600BA07 RID: 47623 RVA: 0x0025E31C File Offset: 0x0025C51C
		public void OnFsTaskStateUpdated(uint taskId, ActivityTaskState state)
		{
			bool flag = this.m_firstpassFsHandler != null && this.m_firstpassFsHandler.IsVisible();
			if (flag)
			{
				this.m_firstpassFsHandler.RefreshItemWithTaskidAndState(taskId, state);
			}
		}

		// Token: 0x0600BA08 RID: 47624 RVA: 0x0025E354 File Offset: 0x0025C554
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

		// Token: 0x0600BA09 RID: 47625 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void UpdateTab()
		{
		}

		// Token: 0x0600BA0A RID: 47626 RVA: 0x0025E3E0 File Offset: 0x0025C5E0
		public void UpdateSealTime()
		{
			bool flag = this.m_firstpassFsHandler != null && this.m_firstpassFsHandler.IsVisible();
			if (flag)
			{
				this.m_firstpassFsHandler.UpdateTime();
			}
		}

		// Token: 0x04004A53 RID: 19027
		private XSysDefine m_selectSys = XSysDefine.XSys_None;

		// Token: 0x04004A54 RID: 19028
		private bool m_isDebug;

		// Token: 0x04004A55 RID: 19029
		private DlgHandlerBase m_CurrHandler;

		// Token: 0x04004A56 RID: 19030
		public AnnouncementHandler m_AnnouncementHandler;

		// Token: 0x04004A57 RID: 19031
		public HolidayHandler m_HolidayHandler;

		// Token: 0x04004A58 RID: 19032
		private XCampDuelMainHandler m_CampDuelMainHandler;

		// Token: 0x04004A59 RID: 19033
		private FirstPassMainHandler m_FirstPassMainHandler;

		// Token: 0x04004A5A RID: 19034
		private FirstPassMwcxHandler m_firstpassMwcxHandler;

		// Token: 0x04004A5B RID: 19035
		private FirstPassGhjcHandler m_firstpassGhjcHandler;

		// Token: 0x04004A5C RID: 19036
		private FirstPassGuindRankHandler m_firstpassGuildRankHandler;

		// Token: 0x04004A5D RID: 19037
		private FrozenSealHandler m_firstpassFsHandler;

		// Token: 0x04004A5E RID: 19038
		private FlowerActivityHandler m_flowerActivityHandler;

		// Token: 0x04004A5F RID: 19039
		public XLevelSealView m_LevelSealHandler;

		// Token: 0x04004A60 RID: 19040
		public OldFriendsReplayHandler m_oldFriendsBackHandler;

		// Token: 0x04004A61 RID: 19041
		private PandoraSDKHandler m_pandoraSDKHandler;

		// Token: 0x04004A62 RID: 19042
		public AncientHandler m_bigPrizeHandler;

		// Token: 0x04004A63 RID: 19043
		public LuckyTurntableFrameHandler m_luckyTurntableFrameHandler;

		// Token: 0x04004A64 RID: 19044
		private Dictionary<XSysDefine, IXUICheckBox> m_TabsDic = new Dictionary<XSysDefine, IXUICheckBox>();

		// Token: 0x04004A65 RID: 19045
		private XFx _FxFirework;
	}
}
