// Decompiled with JetBrains decompiler
// Type: XMainClient.UI.XMainInterface
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using MiniJSON;
using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class XMainInterface : DlgBase<XMainInterface, XMainInterfaceBehaviour>
    {
        private bool _bH1Opened;
        private int _curPPT = 0;
        private XAchievementDocument _achievement_doc = (XAchievementDocument)null;
        private XMainInterfaceDocument _main_doc = (XMainInterfaceDocument)null;
        private IPlatform _platform = (IPlatform)null;
        private SceneType m_curScene;
        private DateTime _fatigePressTime = DateTime.Now;
        private uint _pressToken = 0;
        private uint _fatigeRefreshToken = 0;
        private DateTime _last_power_sound_time = DateTime.Now;
        public XMainInterfaceBriefHandler _TaskNaviHandler;
        public SkyArenaWaitHandler _WaitHandler;
        public HomeHandler _HomeHandler;
        public XYuyinView _yuyinHandler;
        public WeddingSceneHandler _WeddingHandler;
        public YorozuyaHandler _yorozuyaHandler;
        public DanceMotionHandler _DanceMotionHandler;
        public XMainSubstanceHandler _substanceHandler;
        public float DramaDlgCloseTime = 0.0f;
        private int _curExpInd = 0;
        private int _maxExpCount = 4;
        private XTimerMgr.ElapsedEventHandler _refreshFatigeTimeCb = (XTimerMgr.ElapsedEventHandler)null;
        private XTimerMgr.ElapsedEventHandler _showFatigeRecoverTimeCb = (XTimerMgr.ElapsedEventHandler)null;
        private GameCommunityHandler _GameCommunityHandler = (GameCommunityHandler)null;
        private bool _V3SwitchBtnState = false;
        private bool _MenuSwitchBtnState = true;
        private bool _H2SwitchBtnState = true;
        public uint MulActTipsToken;
        private int _MulActTipsCD;
        private XLeftTimeCounter _LevelSealCDCounter = (XLeftTimeCounter)null;
        private bool isLevelSealCountdown = false;
        private float lastPingTime = -60f;
        private float lastDebugUITrigger = -1f;
        public bool fakeShow = true;
        private XFx m_activityFx = (XFx)null;
        private bool m_isFromTime = false;
        private float m_fClickTime = 0.0f;
        private IXUIButton lastSelectV3Button = (IXUIButton)null;

        public XMainInterfaceDocument MainDoc => this._main_doc;

        public bool MenuSwitchBtnState => this._MenuSwitchBtnState;

        public override string fileName => "Hall/HallDlg";

        public override int layer => 1;

        public override bool isMainUI => true;

        public override bool autoload => true;

        public XMainInterface()
        {
            this._refreshFatigeTimeCb = new XTimerMgr.ElapsedEventHandler(this.RefreshFatigeTime);
            this._showFatigeRecoverTimeCb = new XTimerMgr.ElapsedEventHandler(this.ShowFatigeRecoverTime);
        }

        protected override void Init()
        {
            this._platform = XSingleton<XUpdater.XUpdater>.singleton.XPlatform;
            this._curPPT = (int)(XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes).GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
            this._main_doc = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
            this._main_doc.View = this;
            this._achievement_doc = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
            this._achievement_doc.HallMainView = this;
            this.DramaDlgCloseTime = 0.0f;
            DlgHandlerBase.EnsureCreate<XMainInterfaceBriefHandler>(ref this._TaskNaviHandler, this.uiBehaviour.m_TaskNaviFrame.transform);
            this._MulActTipsCD = XSingleton<XGlobalConfig>.singleton.GetInt("MulActivityTipsCD");
            this._V3SwitchBtnState = false;
            this._MenuSwitchBtnState = true;
            this._H2SwitchBtnState = true;
        }

        protected override void OnLoad()
        {
            DlgHandlerBase.EnsureCreate<HomeHandler>(ref this._HomeHandler, this.uiBehaviour.m_HomeGo.transform);
            DlgHandlerBase.EnsureCreate<XYuyinView>(ref this._yuyinHandler, this.uiBehaviour.transform, handlerMgr: ((IDlgHandlerMgr)this));
            DlgHandlerBase.EnsureCreate<WeddingSceneHandler>(ref this._WeddingHandler, this.uiBehaviour.m_HomeGo.transform);
            DlgHandlerBase.EnsureCreate<XMainSubstanceHandler>(ref this._substanceHandler, this.uiBehaviour.m_SysGrid);
            DlgHandlerBase.EnsureCreate<YorozuyaHandler>(ref this._yorozuyaHandler, this.uiBehaviour.transform);
            DlgHandlerBase.EnsureCreate<DanceMotionHandler>(ref this._DanceMotionHandler, this.uiBehaviour.m_DanceMotion, visible: false);
            if (XSingleton<XScene>.singleton.SceneType != SceneType.SKYCITY_WAITING && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_HORSE && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_BATTLEFIELD_READY && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_BIGMELEE_READY)
                return;
            DlgHandlerBase.EnsureCreate<SkyArenaWaitHandler>(ref this._WaitHandler, this.uiBehaviour.m_Canvas, handlerMgr: ((IDlgHandlerMgr)this));
        }

        protected override void OnUnload()
        {
            this._LevelSealCDCounter = (XLeftTimeCounter)null;
            this.m_uiBehaviour.m_txtAvatar.SetTexturePath("");
            DlgHandlerBase.EnsureUnload<BigMeleeRankHandler>(ref XDocuments.GetSpecificDocument<XBigMeleeEntranceDocument>(XBigMeleeEntranceDocument.uuID).RankHandler);
            DlgHandlerBase.EnsureUnload<HomeHandler>(ref this._HomeHandler);
            DlgHandlerBase.EnsureUnload<WeddingSceneHandler>(ref this._WeddingHandler);
            DlgHandlerBase.EnsureUnload<XMainInterfaceBriefHandler>(ref this._TaskNaviHandler);
            DlgHandlerBase.EnsureUnload<SkyArenaWaitHandler>(ref this._WaitHandler);
            DlgHandlerBase.EnsureUnload<XYuyinView>(ref this._yuyinHandler);
            DlgHandlerBase.EnsureUnload<GameCommunityHandler>(ref this._GameCommunityHandler);
            DlgHandlerBase.EnsureUnload<XMainSubstanceHandler>(ref this._substanceHandler);
            DlgHandlerBase.EnsureUnload<YorozuyaHandler>(ref this._yorozuyaHandler);
            DlgHandlerBase.EnsureUnload<DanceMotionHandler>(ref this._DanceMotionHandler);
            this._main_doc.View = (XMainInterface)null;
            XSingleton<XGameSysMgr>.singleton.Reset();
            this._MenuSwitchBtnState = true;
            XSingleton<XTimerMgr>.singleton.KillTimer(this.MulActTipsToken);
            if (this.m_activityFx != null)
            {
                XSingleton<XFxMgr>.singleton.DestroyFx(this.m_activityFx);
                this.m_activityFx = (XFx)null;
            }
            base.OnUnload();
        }

        protected override void OnShow()
        {
            base.OnShow();
            this.lastPingTime = -60f;
            this._SetSceneUI();
            this._main_doc.Present();
            this.lastSelectV3Button = (IXUIButton)null;
            XPlatformAbilityDocument.Doc.QueryQQVipInfo();
            DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.ShowChatDefaultMiniUI();
            if (!DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.IsInited)
                DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.ShowPanel(false);
            DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.Show(true);
            DlgBase<RadioDlg, RadioBehaviour>.singleton.Show(true);
            XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID).ReqFriendsInfo();
            this.RefreshSysAnnounce();
            this.uiBehaviour.m_RecoverTime.SetVisible(false);
            XSingleton<XChatIFlyMgr>.singleton.InitFlyMgr();
            XSingleton<XScreenShotMgr>.singleton.Init();
            this._InitH5();
            this.HandlerYuyin();
            this.RefreshMoneyInfo();
            this.CalMenuSwitchBtnRedPointState();
            this.CalH2SwitchBtnRedPointState();
            this._main_doc.OnLoadWebViewConfig();
            XDanceDocument.Doc.GetAllDanceIDs();
            this.SetActivityEffect(false);
        }

        private void _InitH5()
        {
            foreach (XSysDefine sys in XSingleton<XGameSysMgr>.singleton.SysH5)
                this.RefreshH5ButtonState(sys, false);
            if (this._substanceHandler != null && this._substanceHandler.IsVisible())
                this._substanceHandler.Sort();
            this.ShowLiveCount(XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID).LiveCount);
            this.InitSevenLoginWhenShow();
        }

        protected override void OnSetVisiblePure(bool bShow)
        {
            base.OnSetVisiblePure(bShow);
            if (!bShow)
                return;
            this._InitH5();
            this.RefreshMoneyInfo();
            if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._TaskNaviHandler.TaskHandler.IsVisible())
                DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._TaskNaviHandler.TaskHandler.RefreshData();
        }

        private void HandlerYuyin()
        {
            YuyinIconType type = YuyinIconType.Hall;
            switch (XSingleton<XScene>.singleton.SceneType)
            {
                case SceneType.SCENE_HALL:
                    type = YuyinIconType.Hall;
                    break;
                case SceneType.SCENE_GUILD_HALL:
                    type = YuyinIconType.Guild;
                    break;
                case SceneType.SCENE_FAMILYGARDEN:
                    type = YuyinIconType.HOME;
                    break;
                case SceneType.SCENE_LEISURE:
                    type = YuyinIconType.LEISURE;
                    break;
            }
            if (this._yuyinHandler == null)
                return;
            this._yuyinHandler.Refresh(type);
            if (this._yuyinHandler.m_panel != null && (UnityEngine.Object)this._yuyinHandler.m_panel.gameObject != (UnityEngine.Object)null)
                this._yuyinHandler.m_panel.gameObject.SetActive(this.fakeShow);
        }

        protected override void OnHide()
        {
            base.OnHide();
            DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetVisible(false, true);
            DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.Show(false);
            DlgBase<RadioDlg, RadioBehaviour>.singleton.Show(false);
            this._LevelSealCDCounter = (XLeftTimeCounter)null;
        }

        private void _SetSceneUI()
        {
            this.m_curScene = XSingleton<XScene>.singleton.SceneType;
            this._yorozuyaHandler.SetVisible(false);
            switch (this.m_curScene)
            {
                case SceneType.SCENE_HALL:
                    this.SetHallUi();
                    this._bH1Opened = true;
                    break;
                case SceneType.SCENE_GUILD_HALL:
                    this.SetGuildHallUi();
                    this._bH1Opened = false;
                    break;
                case SceneType.SCENE_FAMILYGARDEN:
                    this.SetHomeUi();
                    this._bH1Opened = true;
                    break;
                case SceneType.SKYCITY_WAITING:
                case SceneType.SCENE_HORSE:
                case SceneType.SCENE_BIGMELEE_READY:
                case SceneType.SCENE_BATTLEFIELD_READY:
                    this.SetWaitingUi();
                    this._bH1Opened = true;
                    break;
                case SceneType.SCENE_WEDDING:
                    this.SetWeddingUI();
                    this._bH1Opened = true;
                    break;
                case SceneType.SCENE_LEISURE:
                    this.SetLeisureUi();
                    this._bH1Opened = true;
                    break;
                default:
                    this.SetHallUi();
                    break;
            }
        }

        private void SetHallUi()
        {
            this._TaskNaviHandler.SetVisible(true);
            this.uiBehaviour.m_SysListH1.SetVisible(true);
            this.uiBehaviour.m_SysListH0.SetVisible(true);
            this.uiBehaviour.m_SysListV1.SetVisible(true);
            this.uiBehaviour.m_SecondMenu.SetActive(true);
            this._substanceHandler.SetVisible(true);
            this.uiBehaviour.m_MenuSwitchBtn.SetVisible(true);
            this._WeddingHandler.SetVisible(false);
            this._HomeHandler.SetVisible(false);
            this.uiBehaviour.m_SysListH3.SetVisible(false);
            this.uiBehaviour.m_ExitGuild.SetVisible(false);
            this.uiBehaviour.m_SysListGuildH1.SetVisible(false);
            this.uiBehaviour.m_SysListGuildV1.SetVisible(false);
            this.uiBehaviour.m_SysListGuildH2.SetVisible(false);
            this.OnMainSysChange();
        }

        private void SetGuildHallUi()
        {
            this._WeddingHandler.SetVisible(false);
            this._HomeHandler.SetVisible(false);
            this._TaskNaviHandler.SetVisible(false);
            this.uiBehaviour.m_SysListH3.SetVisible(false);
            this.uiBehaviour.m_SysListH1.SetVisible(true);
            this.uiBehaviour.m_SysListH0.SetVisible(false);
            this.uiBehaviour.m_SysListV1.SetVisible(false);
            this.uiBehaviour.m_SecondMenu.SetActive(false);
            this._substanceHandler.SetVisible(true);
            this.uiBehaviour.m_MenuSwitchBtn.SetVisible(true);
            this.uiBehaviour.m_ExitGuild.SetVisible(true);
            this.uiBehaviour.m_SysListGuildH1.SetVisible(true);
            this.uiBehaviour.m_SysListGuildV1.SetVisible(true);
            this.uiBehaviour.m_SysListGuildH2.SetVisible(true);
            this.uiBehaviour.m_SysListH0.CloseList();
            this.uiBehaviour.m_SysListH3.CloseList();
            this._ShowGuildMenu();
            this.RefreshV3H1OnOtherScene();
            if (!this._MenuSwitchBtnState)
                return;
            this.OnMenuSwitchBtnClick((IXUISprite)null);
        }

        private void SetWaitingUi()
        {
            this._WeddingHandler.SetVisible(false);
            this._HomeHandler.SetVisible(false);
            this.uiBehaviour.m_SysListH3.SetVisible(false);
            this.uiBehaviour.m_SysListV1.SetVisible(false);
            this.uiBehaviour.m_SecondMenu.SetActive(false);
            this.uiBehaviour.m_ExitGuild.SetVisible(false);
            this._substanceHandler.SetVisible(false);
            this.uiBehaviour.m_SysListGuildH1.SetVisible(false);
            this.uiBehaviour.m_SysListGuildV1.SetVisible(false);
            this.uiBehaviour.m_SysListGuildH2.SetVisible(false);
            XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SKYCITY_WAITING)
                this._TaskNaviHandler.SetVisible(specificDocument.bInTeam);
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HORSE || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BIGMELEE_READY || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BATTLEFIELD_READY)
                this._TaskNaviHandler.SetVisible(false);
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BIGMELEE_READY)
            {
                this.uiBehaviour.m_SysListH1.SetVisible(false);
                this.uiBehaviour.m_SysListH0.SetVisible(false);
                this.uiBehaviour.m_MenuSwitchBtn.SetVisible(false);
            }
            else
            {
                this.uiBehaviour.m_SysListH1.SetVisible(true);
                this.uiBehaviour.m_SysListH0.SetVisible(true);
                this.uiBehaviour.m_MenuSwitchBtn.SetVisible(true);
            }
            this.RefreshV3H1OnOtherScene();
        }

        private void SetHomeUi()
        {
            this._HomeHandler.SetVisible(true);
            this.BottomDownBtns(true);
            this._WeddingHandler.SetVisible(false);
            this._TaskNaviHandler.SetVisible(false);
            this.uiBehaviour.m_ExitGuild.SetVisible(false);
            this.uiBehaviour.m_SysListH0.SetVisible(false);
            this._substanceHandler.SetVisible(false);
            this.uiBehaviour.m_SysListV1.SetVisible(false);
            this.uiBehaviour.m_SecondMenu.SetActive(false);
            this.uiBehaviour.m_SysListGuildH1.SetVisible(false);
            this.uiBehaviour.m_SysListGuildV1.SetVisible(false);
            this.uiBehaviour.m_SysListGuildH2.SetVisible(false);
            if (this._MenuSwitchBtnState)
                this.OnMenuSwitchBtnClick((IXUISprite)null);
            this.OnMainSysChange();
        }

        private void SetWeddingUI()
        {
            this._WeddingHandler.SetVisible(true);
            this.uiBehaviour.m_V3SwitchBtn.SetVisible(true);
            this.uiBehaviour.m_SysListV3.SetVisible(true);
            this._HomeHandler.SetVisible(false);
            this._TaskNaviHandler.SetVisible(false);
            this.uiBehaviour.m_ExitGuild.SetVisible(false);
            this.uiBehaviour.m_SysListV1.SetVisible(false);
            this.uiBehaviour.m_SecondMenu.SetActive(false);
            this._substanceHandler.SetVisible(false);
            this.uiBehaviour.m_SysListGuildH1.SetVisible(false);
            this.uiBehaviour.m_SysListGuildV1.SetVisible(false);
            this.uiBehaviour.m_SysListGuildH2.SetVisible(false);
            this.uiBehaviour.m_SysListH3.SetVisible(false);
            this.uiBehaviour.m_SysListH1.SetVisible(false);
            this.uiBehaviour.m_MenuSwitchBtn.SetVisible(false);
            this.OnMainSysChange();
        }

        private void SetLeisureUi()
        {
            this._yorozuyaHandler.SetVisible(true);
            this._WeddingHandler.SetVisible(false);
            this.uiBehaviour.m_V3SwitchBtn.SetVisible(false);
            this.uiBehaviour.m_SysListV3.SetVisible(false);
            this._HomeHandler.SetVisible(false);
            this._TaskNaviHandler.SetVisible(false);
            this.uiBehaviour.m_ExitGuild.SetVisible(false);
            this.uiBehaviour.m_SysListV1.SetVisible(false);
            this.uiBehaviour.m_SecondMenu.SetActive(false);
            this._substanceHandler.SetVisible(false);
            this.uiBehaviour.m_SysListGuildH1.SetVisible(false);
            this.uiBehaviour.m_SysListGuildV1.SetVisible(false);
            this.uiBehaviour.m_SysListGuildH2.SetVisible(false);
            this.uiBehaviour.m_SysListH3.SetVisible(false);
            this.uiBehaviour.m_SysListH1.SetVisible(false);
            this.uiBehaviour.m_MenuSwitchBtn.SetVisible(false);
        }

        public void BottomDownBtns(bool visible)
        {
            this.uiBehaviour.m_V3SwitchBtn.SetVisible(visible);
            this.uiBehaviour.m_SysListV3.SetVisible(visible);
            this.uiBehaviour.m_SysListH3.SetVisible(visible);
            this.uiBehaviour.m_SysListH1.SetVisible(visible);
            this.uiBehaviour.m_MenuSwitchBtn.SetVisible(visible);
        }

        public override void RegisterEvent()
        {
            this.uiBehaviour.m_MenuSwitchBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMenuSwitchBtnClick));
            this.uiBehaviour.m_H2SwitchBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnH2SwitchBtnClick));
            this.uiBehaviour.m_H2ListTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.CalH2SwitchBtnRedPointState));
            this.uiBehaviour.m_PlayerAvatar.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAvatarClick));
            for (int index = 0; index < this.uiBehaviour.m_SysButtonsMapping.Length; ++index)
                this.uiBehaviour.m_SysButtonsMapping[index]?.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSysIconClicked));
            this.uiBehaviour.m_ExitGuild.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnExitGuildClick));
            this.uiBehaviour.m_V3SwitchBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnV3SwitchBtnClick));
            this.uiBehaviour.m_MotionDance.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnMotionClicked));
            this.uiBehaviour.m_MotionLover.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnMotionClicked));
        }

        public override void OnUpdate()
        {
            if (!XSingleton<XTimerMgr>.singleton.NeedFixedUpdate)
                return;
            base.OnUpdate();
            if (this.isLevelSealCountdown && this._LevelSealCDCounter != null)
                this._LevelSealCDCounter.Update();
            if (this._V3SwitchBtnState)
                this.uiBehaviour.m_TransformLeftTime.Update();
            if ((double)this.lastDebugUITrigger > 0.0)
                this.lastDebugUITrigger -= Time.deltaTime;
            if ((double)this.lastDebugUITrigger <= 0.0 && Input.GetKey(KeyCode.F4))
            {
                DlgBase<DemoUI, DemoUIBehaviour>.singleton.Toggle();
                this.lastDebugUITrigger = 0.05f;
            }
            if (Input.GetKey(KeyCode.BackQuote))
            {
                if (Input.GetKey(KeyCode.Keypad0) || Input.GetKey(KeyCode.Alpha0))
                    XSingleton<XCommand>.singleton.CustomCommand(0);
                if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha1))
                    XSingleton<XCommand>.singleton.CustomCommand(1);
                if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.Alpha2))
                    XSingleton<XCommand>.singleton.CustomCommand(2);
                if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.Alpha3))
                    XSingleton<XCommand>.singleton.CustomCommand(3);
                if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.Alpha4))
                    XSingleton<XCommand>.singleton.CustomCommand(4);
                if (Input.GetKey(KeyCode.Keypad5) || Input.GetKey(KeyCode.Alpha5))
                    XSingleton<XCommand>.singleton.CustomCommand(5);
                if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.Alpha6))
                    XSingleton<XCommand>.singleton.CustomCommand(6);
                if (Input.GetKey(KeyCode.Keypad7) || Input.GetKey(KeyCode.Alpha7))
                    XSingleton<XCommand>.singleton.CustomCommand(7);
                if (Input.GetKey(KeyCode.Keypad8) || Input.GetKey(KeyCode.Alpha8))
                    XSingleton<XCommand>.singleton.CustomCommand(8);
                if (Input.GetKey(KeyCode.Keypad9) || Input.GetKey(KeyCode.Alpha9))
                    XSingleton<XCommand>.singleton.CustomCommand(9);
            }
            this.UpdateRedPointState();
            this.UpdateWifi();
            if ((double)Time.unscaledTime - (double)this.lastPingTime <= 60.0 && (double)this.lastPingTime >= 0.0)
                return;
            this.lastPingTime = Time.unscaledTime;
            this.RefreshPing();
        }

        public void RefreshMoneyInfo(int itemid = 0, bool bAnim = false)
        {
            for (int index = 0; index < this.m_uiBehaviour.m_MoneyList.Count; ++index)
            {
                if (itemid == 0 || this.m_uiBehaviour.m_MoneyList[index].ItemID == itemid)
                {
                    this.m_uiBehaviour.m_MoneyList[index].RefreshValue(bAnim);
                    if ((uint)itemid > 0U)
                        break;
                }
            }
        }

        public void UpdateRedPointState()
        {
        }

        private void UpdateWifi()
        {
            IXUIButton sysButton = this.m_uiBehaviour.GetSysButton(XSysDefine.XSys_Wifi);
            if (sysButton == null)
                return;
            XSingleton<UiUtility>.singleton.UpdateWifi(sysButton, (IXUISprite)null);
        }

        private void _ShowGuildMenu()
        {
            foreach (XSysDefine sys in this.uiBehaviour.m_SysGuild)
                this.uiBehaviour.GetSysButton(sys).SetVisible(true);
            this.OnGuildSysChange();
            this.uiBehaviour.m_SysListGuildH1.SetAnimateSmooth(true);
            this.uiBehaviour.m_SysListGuildV1.SetAnimateSmooth(true);
            this.uiBehaviour.m_SysListGuildH2.SetAnimateSmooth(true);
            this.uiBehaviour.m_SysListGuildH1.Refresh();
            this.uiBehaviour.m_SysListGuildV1.Refresh();
            this.uiBehaviour.m_SysListGuildH2.Refresh();
        }

        public void RefreshSysAnnounce()
        {
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SKYCITY_WAITING || !DlgBase<AnnounceView, AnnounceBehaviour>.singleton.IsVisible())
                return;
            DlgBase<AnnounceView, AnnounceBehaviour>.singleton.RefreshUI();
        }

        public void RefreshWelcomeBackFlow()
        {
            if (!this.MainDoc.BackFlow || XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_HALL)
                return;
            this.OnShowFlowBack();
        }

        public void OnGuildSysChange()
        {
            XGuildDocument specificDocument1 = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
            foreach (XSysDefine sys in this.uiBehaviour.m_SysGuild)
            {
                uint unlockLevel = XGuildDocument.GuildConfig.GetUnlockLevel(sys);
                IXUIButton sysButton = this.uiBehaviour.GetSysButton(sys);
                Transform child = sysButton.gameObject.transform.FindChild("OpenAtLevel");
                IXUILabel xuiLabel = (IXUILabel)null;
                IXUISprite component = sysButton.gameObject.GetComponent("XUISprite") as IXUISprite;
                if ((UnityEngine.Object)child != (UnityEngine.Object)null)
                {
                    xuiLabel = child.GetComponent("XUILabel") as IXUILabel;
                    xuiLabel.SetText(string.Empty);
                }
                if (specificDocument1.bInGuild && specificDocument1.Level >= unlockLevel && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(sys))
                {
                    try
                    {
                        component?.SetColor(Color.white);
                        xuiLabel?.SetVisible(false);
                    }
                    catch (Exception ex)
                    {
                        XSingleton<XDebug>.singleton.AddErrorLog(sysButton.gameObject.name);
                        XSingleton<XDebug>.singleton.AddErrorLog(ex.Message);
                    }
                }
                else
                    xuiLabel?.SetVisible(true);
            }
            foreach (XSysDefine sys in this.uiBehaviour.m_SysGuildNormal)
            {
                this.uiBehaviour.GetSysButton(sys);
                bool bVisible = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(sys);
                switch (sys)
                {
                    case XSysDefine.XSys_GuildCollect:
                    case XSysDefine.XSys_GuildCollectSummon:
                        XGuildCollectDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildCollectDocument>(XGuildCollectDocument.uuID);
                        bVisible = bVisible && specificDocument2.ActivityState;
                        break;
                }
                this.uiBehaviour.GetSysButton(sys).SetVisible(bVisible);
            }
            this.uiBehaviour.m_SysListH2.Refresh();
        }

        public void OnTitanSysChange()
        {
            XPlayerAttributes attributes = XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes;
            bool flag = XSingleton<UIManager>.singleton.IsUIShowed();
            int num = 0;
            for (int index = 0; index < this.uiBehaviour.m_SysH4.Length; ++index)
            {
                XSysDefine sys = this.uiBehaviour.m_SysH4[index];
                bool bVisible = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(sys, attributes);
                if (flag)
                {
                    switch (sys)
                    {
                        case XSysDefine.XSys_Mail:
                        case XSysDefine.XSys_Setting:
                            bVisible = false;
                            break;
                    }
                }
                this.uiBehaviour.GetSysButton(sys).SetVisible(bVisible);
                if (bVisible)
                    ++num;
            }
        }

        public void OnMainSysChange()
        {
            if (!this.IsLoaded())
                return;
            for (int index = 0; index < this.uiBehaviour.m_ListSys.Count; ++index)
            {
                XSysDefine listSy = this.uiBehaviour.m_ListSys[index];
                if (!XSingleton<XGameSysMgr>.singleton.SysH5.Contains(listSy) && !this.uiBehaviour.m_SysGuildNormal.Contains(listSy))
                    this.OnSingleSysChange(listSy, false);
            }
            this.RefreshAllList();
        }

        public void OnSingleSysChange(XSysDefine sys, bool refreshList = true)
        {
            if (!this.IsLoaded() || this.uiBehaviour.GetSysButton(sys) == null)
                return;
            bool bVisible1 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(sys, XSingleton<XAttributeMgr>.singleton.XPlayerData);
            switch (sys)
            {
                case XSysDefine.XSys_Guild:
                    bVisible1 = bVisible1 && this.m_curScene != SceneType.SCENE_GUILD_HALL;
                    break;
                case XSysDefine.XSys_OnlineReward:
                    XOnlineRewardDocument specificDocument1 = XDocuments.GetSpecificDocument<XOnlineRewardDocument>(XOnlineRewardDocument.uuID);
                    bVisible1 = bVisible1 && specificDocument1.CheckOver();
                    break;
                case XSysDefine.XSys_Broadcast:
                    bVisible1 = bVisible1 && XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ && this.IsSupportQgame();
                    break;
                case XSysDefine.XSys_SevenActivity:
                    XSevenLoginDocument specificDocument2 = XDocuments.GetSpecificDocument<XSevenLoginDocument>(XSevenLoginDocument.uuID);
                    bVisible1 = bVisible1 && specificDocument2.bHasAvailableSevenIcon;
                    break;
                case XSysDefine.XSys_Welfare_NiceGirl:
                    bVisible1 = bVisible1 && XWelfareDocument.Doc.ArgentaMainInterfaceState && !XWelfareDocument.Doc.IsNiceGirlTasksFinished();
                    break;
                case XSysDefine.XSys_OperatingActivity:
                    bool bVisible2 = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID).IsShowLevelSealIcon();
                    this.uiBehaviour.m_RemoveSealTip.SetVisible(bVisible2);
                    if (bVisible2)
                    {
                        this.ShowRemoveSealLeftTime(this.uiBehaviour.m_RemoveSealTip, ref this._LevelSealCDCounter, ref this.isLevelSealCountdown);
                        break;
                    }
                    this._LevelSealCDCounter = (XLeftTimeCounter)null;
                    break;
                case XSysDefine.XSys_ThemeActivity:
                    XThemeActivityDocument specificDocument3 = XDocuments.GetSpecificDocument<XThemeActivityDocument>(XThemeActivityDocument.uuID);
                    bVisible1 = bVisible1 && specificDocument3.isHasHallIcon();
                    break;
                case XSysDefine.XSys_Photo:
                    bVisible1 = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("PlatfromAbility")) != 0 && this.m_curScene != SceneType.SCENE_HORSE_RACE && this.m_curScene != SceneType.SCENE_HORSE && this.m_curScene != SceneType.SCENE_HEROBATTLE && this.m_curScene != SceneType.SCENE_BIGMELEE_READY;
                    if (bVisible1)
                    {
                        bVisible1 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Photo);
                        break;
                    }
                    break;
                case XSysDefine.XSys_QuickRide:
                    bVisible1 = bVisible1 && this.m_curScene != SceneType.SCENE_FAMILYGARDEN && this.m_curScene != SceneType.SCENE_GUILD_HALL && this.m_curScene != SceneType.SCENE_WEDDING && this.m_curScene != SceneType.SCENE_LEISURE;
                    break;
                case XSysDefine.XSys_FriendCircle:
                    bVisible1 = bVisible1 && XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat;
                    break;
                case XSysDefine.XSys_QQVIP:
                    bVisible1 = bVisible1 && XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ;
                    break;
                case XSysDefine.XSys_SystemAnnounce:
                    bVisible1 = bVisible1 && this.SetSystemAnnounce();
                    break;
                case XSysDefine.XSys_Platform_StartPrivilege:
                    bVisible1 = bVisible1 && (XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat || XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
                    if (bVisible1)
                    {
                        IXUIButton sysButton = this.uiBehaviour.GetSysButton(XSysDefine.XSys_Platform_StartPrivilege);
                        if (sysButton != null)
                        {
                            Transform transform = sysButton.gameObject.transform.Find("seal");
                            if ((UnityEngine.Object)transform != (UnityEngine.Object)null && transform.gameObject.GetComponent("XUISprite") is IXUISprite component5)
                            {
                                if (XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat)
                                    component5.spriteName = "ptic_04";
                                else if (XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ)
                                    component5.spriteName = "ptic_05";
                            }
                        }
                        break;
                    }
                    break;
            }
            this.uiBehaviour.GetSysButton(sys).SetVisible(bVisible1);
            if (!refreshList)
                return;
            this.RefreshAllList();
        }

        public void RefreshAllList()
        {
            switch (this.m_curScene)
            {
                case SceneType.SCENE_HALL:
                case SceneType.SKYCITY_WAITING:
                case SceneType.SCENE_HORSE:
                case SceneType.SCENE_BIGMELEE_READY:
                case SceneType.SCENE_BATTLEFIELD_READY:
                    this.uiBehaviour.m_SysListH1.Refresh();
                    this.uiBehaviour.m_SysListH0.Refresh();
                    break;
                case SceneType.SCENE_GUILD_HALL:
                    this.uiBehaviour.m_SysListH2.Refresh();
                    this.uiBehaviour.m_SysListH1.Refresh();
                    break;
                case SceneType.SCENE_FAMILYGARDEN:
                    this.uiBehaviour.m_SysListH1.Refresh();
                    this.uiBehaviour.m_SysListH3.Refresh();
                    break;
                case SceneType.SCENE_WEDDING:
                    return;
                case SceneType.SCENE_LEISURE:
                    return;
            }
            this.uiBehaviour.m_SysListV1.Refresh();
            this.uiBehaviour.m_SysListV2.Refresh();
            this.uiBehaviour.m_SysListV3.Refresh();
            this.uiBehaviour.m_SysListH2_1.Refresh();
            this.uiBehaviour.m_SysListH2_2.Refresh();
            this.RefreshListSwitchBtnVisable((IXUIObject)this.uiBehaviour.m_V3SwitchBtn, this.uiBehaviour.m_SysListV3);
            this.RefreshListSwitchBtnVisable((IXUIObject)this.uiBehaviour.m_H2SwitchBtn, this.uiBehaviour.m_SysListH2_1, this.uiBehaviour.m_SysListH2_2);
            this._TaskNaviHandler.OnSysChange();
        }

        public void RefreshH5ButtonState(XSysDefine sys, bool refreshList = true)
        {
            if (!this.IsVisible() || this._substanceHandler == null || !this._substanceHandler.IsVisible())
                return;
            this._substanceHandler.RefreshMainSubStance(sys, refreshList);
        }

        public void FakeShowSelf(bool bShow)
        {
            this.fakeShow = bShow;
            this.uiBehaviour.m_MainMenuGo.SetActive(bShow);
            DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.Show(bShow);
            DlgBase<RadioDlg, RadioBehaviour>.singleton.Show(bShow);
            this.uiBehaviour.m_PING.SetActive(bShow);
            if (this._WaitHandler != null)
                this._WaitHandler.SetVisible(bShow);
            switch (this.m_curScene)
            {
                case SceneType.SCENE_HALL:
                    this.uiBehaviour.m_ExitGuild.SetVisible(false);
                    this.uiBehaviour.m_SecondMenu.SetActive(bShow);
                    this._TaskNaviHandler.SetVisible(bShow);
                    break;
                case SceneType.SCENE_GUILD_HALL:
                    this.uiBehaviour.m_ExitGuild.SetVisible(bShow);
                    this._TaskNaviHandler.SetVisible(false);
                    this.uiBehaviour.m_SecondMenu.SetActive(false);
                    break;
                case SceneType.SCENE_FAMILYGARDEN:
                    if (XHomeCookAndPartyDocument.Doc.CurBanquetState == 0U)
                        this._HomeHandler.SetVisible(bShow);
                    this.uiBehaviour.m_ExitGuild.SetVisible(false);
                    this._TaskNaviHandler.SetVisible(false);
                    this.uiBehaviour.m_SecondMenu.SetActive(false);
                    break;
                case SceneType.SKYCITY_WAITING:
                case SceneType.SCENE_HORSE:
                case SceneType.SCENE_BIGMELEE_READY:
                case SceneType.SCENE_BATTLEFIELD_READY:
                    XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
                    this.uiBehaviour.m_ExitGuild.SetVisible(false);
                    this._TaskNaviHandler.SetVisible(bShow && specificDocument.bInTeam);
                    this.uiBehaviour.m_SecondMenu.SetActive(false);
                    break;
                case SceneType.SCENE_WEDDING:
                case SceneType.SCENE_LEISURE:
                    this.uiBehaviour.m_ExitGuild.SetVisible(false);
                    this._TaskNaviHandler.SetVisible(false);
                    this.uiBehaviour.m_SecondMenu.SetActive(false);
                    break;
                default:
                    this.uiBehaviour.m_SecondMenu.SetActive(bShow);
                    this._TaskNaviHandler.SetVisible(bShow);
                    break;
            }
            this.uiBehaviour.m_AvatarFrame.SetActive(bShow);
            if (this._yuyinHandler != null)
                this._yuyinHandler.m_panel.gameObject.SetActive(bShow);
            DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetFakeHide(!bShow || !this.IsVisible());
            this.RefreshSysAnnounce();
            foreach (XSysDefine sys in XSingleton<XGameSysMgr>.singleton.SysH5)
                this.RefreshH5ButtonState(sys, false);
            if (this._substanceHandler != null && this._substanceHandler.IsVisible())
                this._substanceHandler.Sort();
            this.SetActivityEffect(false);
        }

        public Vector3 GetNewIconFlyPosH1(XSysDefine sys)
        {
            XPlayerAttributes attributes = XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes;
            return XSingleton<XGameUI>.singleton.UIRoot.InverseTransformPoint(DlgBase<XMainInterface, XMainInterfaceBehaviour>.GetChildWorldPos(sys == XSysDefine.XSys_Item_Enhance ? this.uiBehaviour.GetSysButton(XSysDefine.XSys_Item).gameObject.name : this.uiBehaviour.GetSysButton(sys).gameObject.name));
        }

        public void SetActivityEffect(bool isFromTime)
        {
            if (isFromTime && this.m_isFromTime)
                return;
            this.m_isFromTime = isFromTime;
            if (!this.fakeShow)
                return;
            IXUIButton xuiButton = this.uiBehaviour.m_SysButtonsMapping[57];
            if (xuiButton == null)
                return;
            if (this.m_activityFx == null)
                this.m_activityFx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_shuangbeijiangli", xuiButton.gameObject.transform.Find("Icon/Duck"));
            bool enable = XActivityDocument.Doc.MainCityNeedEffect();
            this.m_activityFx.SetActive(enable);
            if (!enable)
                return;
            XFx.SyncRefreshUIRenderQueue(this.m_activityFx);
        }

        public void SetGridAnimateSmooth(bool b)
        {
            this.uiBehaviour.m_SysListH1.SetAnimateSmooth(b);
            this.uiBehaviour.m_SysListH0.SetAnimateSmooth(b);
            this.uiBehaviour.m_SysListV1.SetAnimateSmooth(b);
        }

        public void SetupBaseInfo(XAttributes attr)
        {
            this.SetAvatar(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.Profession)));
            this.SetVip();
            this.SetLevel(attr.Level);
            this.RefreshQQVipInfo();
            this.RefreshGameCenterInfo();
            this.RefreshSelfMemberPrivilegeIcon();
            this.SetPowerpoint(this._curPPT);
            this.SetExp(attr as XPlayerAttributes);
            XFriendsDocument.Doc.SDKQueryFriends();
            ILuaGameInfo luaGameInfo = XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine.luaGameInfo;
            luaGameInfo.exp = (uint)attr.Exp;
            luaGameInfo.maxexp = (uint)attr.MaxExp;
            luaGameInfo.level = attr.Level;
            luaGameInfo.name = attr.Name;
            luaGameInfo.ppt = this._curPPT;
            luaGameInfo.coin = (uint)XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(1);
            luaGameInfo.energy = (uint)XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(6);
            luaGameInfo.dia = (uint)XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(9);
            luaGameInfo.draggon = (uint)XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(7);
        }

        public void SetAvatar(string name)
        {
            (this.uiBehaviour.m_AvatarFrame.transform.FindChild("Avatar").GetComponent("XUISprite") as IXUISprite).spriteName = name;
            this.SetTencentImage();
        }

        public void RefreshQQVipInfo()
        {
            if (!this.IsLoaded())
                return;
            GameObject gameObject1 = this.uiBehaviour.m_AvatarFrame.transform.FindChild("CoverPanel/QQVIP").gameObject;
            GameObject gameObject2 = this.uiBehaviour.m_AvatarFrame.transform.FindChild("CoverPanel/QQSVIP").gameObject;
            QQVipInfoClient qqVipInfo = XPlatformAbilityDocument.Doc.QQVipInfo;
            if (XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_QQVIP) && qqVipInfo != null)
            {
                gameObject1.SetActive(qqVipInfo.is_vip && !qqVipInfo.is_svip);
                gameObject2.SetActive(qqVipInfo.is_svip);
            }
            else
            {
                gameObject1.SetActive(false);
                gameObject2.SetActive(false);
            }
        }

        public void RefreshGameCenterInfo()
        {
            if (!this.IsLoaded() || !this.IsVisible())
                return;
            GameObject gameObject = this.uiBehaviour.m_AvatarFrame.transform.FindChild("CoverPanel/WC").gameObject;
            if (XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Platform_StartPrivilege) && XSingleton<XLoginDocument>.singleton.GetLaunchTypeServerInfo() == StartUpType.StartUp_WX)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);
        }

        public void RefreshSelfMemberPrivilegeIcon()
        {
            if (!this.IsLoaded() || !DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible())
                return;
            (this.uiBehaviour.m_AvatarFrame.transform.FindChild("CoverPanel/Tq").GetComponent("XUISprite") as IXUISprite).SetSprite(XWelfareDocument.GetSelfMemberPrivilegeIconName());
        }

        public void SetTencentImage()
        {
            if (XSingleton<PDatabase>.singleton.playerInfo != null)
            {
                string pictureLarge = XSingleton<PDatabase>.singleton.playerInfo.data.pictureLarge;
                XSingleton<XUICacheImage>.singleton.SetMainIcon(pictureLarge);
                XSingleton<XUICacheImage>.singleton.Load(pictureLarge, this.m_uiBehaviour.m_txtAvatar, (MonoBehaviour)this.m_uiBehaviour);
            }
            else
                XSingleton<XUICacheImage>.singleton.Load(string.Empty, this.m_uiBehaviour.m_txtAvatar, (MonoBehaviour)this.m_uiBehaviour);
            this.SetHeadIcon();
        }

        public void SetHeadIcon() => XSingleton<UiUtility>.singleton.ParseHeadIcon(XDocuments.GetSpecificDocument<XPrerogativeDocument>(XPrerogativeDocument.uuID).PlayerSetid, this.uiBehaviour.m_sprFrame);

        public void SetVip() => XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);

        public void SetLevel(uint lv) => this.uiBehaviour.m_Level.SetText(lv.ToString());

        private void RefreshPing() => XSingleton<UiUtility>.singleton.RefreshPing(this.uiBehaviour.m_lblTime, this.uiBehaviour.m_sliderBattery, this.uiBehaviour.m_lblFree);

        public void SetName(string name)
        {
        }

        public void SetPowerpoint(int value)
        {
            IXUILabel component = this.uiBehaviour.m_PlayerPPT.transform.FindChild("Power").GetComponent("XUILabel") as IXUILabel;
            this._curPPT = value;
            component.SetText(value.ToString());
            DlgBase<PPTDlg, PPTBehaviour>.singleton.ShowPPT(value);
        }

        public void OnPowerpointChanged(int oldValue, int newValue)
        {
        }

        public void SetExp(XPlayerAttributes attr)
        {
        }

        public void RefreshFatigeTime(object obj)
        {
            uint timeLeft = DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.GetTimeLeft(XMainClient.ItemEnum.FATIGUE);
            ulong virtualItemCount = XSingleton<XGame>.singleton.Doc.XBagDoc.GetVirtualItemCount(XMainClient.ItemEnum.FATIGUE);
            ulong num = ulong.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("MaxRecoverFatigue"));
            this.uiBehaviour.m_CurFatige.SetText(string.Format("{0}/{1}", (object)virtualItemCount, (object)num));
            if (virtualItemCount >= num)
            {
                this.uiBehaviour.m_CoverOneTime.SetText("00:00");
                this.uiBehaviour.m_AllCoverTime.SetText("00:00");
                if (this._fatigeRefreshToken <= 0U)
                    return;
                XSingleton<XTimerMgr>.singleton.KillTimer(this._fatigeRefreshToken);
                this._fatigeRefreshToken = 0U;
            }
            else
            {
                this.uiBehaviour.m_CoverOneTime.SetText(DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.FormatTime(timeLeft));
                this.uiBehaviour.m_AllCoverTime.SetText(DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.FormatTime((uint)((ulong)timeLeft + (ulong)(((long)num - (long)virtualItemCount) * 360L))));
                this._fatigeRefreshToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, this._refreshFatigeTimeCb, (object)null);
            }
        }

        public void ShowFatigeRecoverTime(object obj)
        {
            this.uiBehaviour.m_RecoverTime.SetVisible(true);
            this.RefreshFatigeTime((object)null);
        }

        private void OnPressAddFatige(IXUIButton sp, bool state)
        {
            if (state)
            {
                this._fatigePressTime = DateTime.Now;
                this._pressToken = XSingleton<XTimerMgr>.singleton.SetTimer(0.3f, this._showFatigeRecoverTimeCb, (object)null);
            }
            else
            {
                if (!this.uiBehaviour.m_RecoverTime.IsVisible())
                    DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ShowBorad(XMainClient.ItemEnum.FATIGUE);
                else
                    this.uiBehaviour.m_RecoverTime.SetVisible(false);
                if (this._pressToken > 0U)
                {
                    XSingleton<XTimerMgr>.singleton.KillTimer(this._pressToken);
                    this._pressToken = 0U;
                }
                if (this._fatigeRefreshToken > 0U)
                {
                    XSingleton<XTimerMgr>.singleton.KillTimer(this._fatigeRefreshToken);
                    this._fatigeRefreshToken = 0U;
                }
            }
        }

        public void ForceOpenSysIcons(XSysDefine sys)
        {
            this.SetGridAnimateSmooth(false);
            if (this._bH1Opened)
                return;
            this._bH1Opened = true;
            this.OnMainSysChange();
        }

        public void OnSysChange(XSysDefine sys) => this.OnMainSysChange();

        private void OnAvatarClick(IXUISprite go)
        {
            if (!this.IsLoaded())
                return;
            DlgBase<DemoUI, DemoUIBehaviour>.singleton.SetVisible(!DlgBase<DemoUI, DemoUIBehaviour>.singleton.IsVisible(), true);
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BIGMELEE_READY)
                return;
            DlgBase<XOptionsView, XOptionsBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XOptionsView, XOptionsBehaviour>.OnAnimationOver)null);
        }

        private bool _CanClick()
        {
            float time = Time.time;
            if ((double)time - (double)this.m_fClickTime <= 3.0)
                return false;
            this.m_fClickTime = time;
            return true;
        }

        private bool OnExitGuildClick(IXUIButton go)
        {
            if (!this.IsLoaded() || !this._CanClick())
                return true;
            XSingleton<XScene>.singleton.ReqLeaveScene();
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_FAMILYGARDEN)
            {
                HomePlantDocument doc = HomePlantDocument.Doc;
                doc.ClearFarmInfo();
                doc.HomeSprite.ClearInfo();
                doc.GardenId = 0UL;
            }
            return true;
        }

        private void ShowCharSysListFrame()
        {
            XPlayerAttributes attributes = XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes;
            int num = 28;
            for (int index = 0; index < this.uiBehaviour.m_SysChar.Length; ++index)
            {
                bool bVisible = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(this.uiBehaviour.m_SysChar[index], attributes);
                this.uiBehaviour.GetSysButton(this.uiBehaviour.m_SysChar[index]).SetVisible(bVisible);
                if (bVisible)
                    num += 80;
            }
        }

        private bool TryCheckInGuildSystem(XSysDefine sys)
        {
            if (!this.IsLoaded())
            {
                XSingleton<XDebug>.singleton.AddErrorLog("XMainInterface is Dispose!");
                return false;
            }
            if (Array.IndexOf<XSysDefine>(this.uiBehaviour.m_SysGuild, sys) == -1)
                return true;
            XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
            if (!specificDocument.bInGuild)
                return false;
            uint unlockLevel = XGuildDocument.GuildConfig.GetUnlockLevel(sys);
            if (specificDocument.Level < unlockLevel)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_MAZE_NO_GUILD_LEVEL", (object)unlockLevel), "fece00");
                return false;
            }
            if (XSingleton<XGameSysMgr>.singleton.IsSystemOpened(sys))
                return true;
            XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_MAZE_NO_PLAYER_LEVEL", (object)XSingleton<XGameSysMgr>.singleton.GetSystemOpenLevel(sys)), "fece00");
            return false;
        }

        public void OnSysIconClicked(XSysDefine sys) => this.OnSysIconClicked(this.uiBehaviour.GetSysButton(sys));

        public bool OnSysIconClicked(IXUIButton go)
        {
            if (!this.IsLoaded())
                return true;
            XSysDefine id = (XSysDefine)go.ID;
            if ((double)this.DramaDlgCloseTime > 0.0 && (double)Time.time - (double)this.DramaDlgCloseTime < 1.0 || !this.TryCheckInGuildSystem(id))
                return true;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            switch (id)
            {
                case XSysDefine.XSys_Character:
                    this.ShowCharSysListFrame();
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Level:
                    DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.IsTaskMode = false;
                    if (XSingleton<XScene>.singleton.SceneID != 1U)
                    {
                        DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.FadeShow();
                        goto case XSysDefine.XSys_Wifi;
                    }
                    else
                    {
                        this._TaskNaviHandler.NavigateToBattle();
                        goto case XSysDefine.XSys_Wifi;
                    }
                case XSysDefine.XSys_Item:
                    DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Item);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Skill:
                    DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XSkillTreeView, XSkillTreeBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Horse:
                    DlgBase<XPetMainView, XPetMainBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XPetMainView, XPetMainBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Guild:
                    XGuildDocument specificDocument1 = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
                    if (specificDocument1 != null)
                    {
                        specificDocument1.TryShowGuildHallUI();
                        goto case XSysDefine.XSys_Wifi;
                    }
                    else
                        goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Recycle:
                    DlgBase<RecycleSystemDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Recycle);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Auction:
                    DlgBase<AuctionView, AuctionBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<AuctionView, AuctionBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_CardCollect:
                    DlgBase<CardCollectView, CardCollectBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<CardCollectView, CardCollectBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Mail:
                    DlgBase<MailSystemDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Mail_System);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Wifi:
                case XSysDefine.XSys_GuildChallenge:
                    return true;
                case XSysDefine.XSys_Strong:
                    DlgBase<XFpStrengthenView, XFPStrengthenBehaviour>.singleton.ShowContent();
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Reward:
                    DlgBase<RewardSystemDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Reward);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_OnlineReward:
                    DlgBase<XOnlineRewardView, XOnlineRewardBehaviour>.singleton.SetVisible(true, true);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Setting:
                    DlgBase<XOptionsView, XOptionsBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XOptionsView, XOptionsBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Rank:
                    DlgBase<XRankView, XRankBehaviour>.singleton.ShowRank(XSysDefine.XSys_Rank);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_EquipCreate:
                    DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_EquipCreate);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_LevelSeal:
                    DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.Show(XSysDefine.XSys_LevelSeal);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_SuperRisk:
                    DlgBase<SuperRiskDlg, SuperRiskDlgBehaviour>.singleton.Show(true);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Qualifying:
                    DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XQualifyingView, XQualifyingBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Spectate:
                    DlgBase<SpectateView, SpectateBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<SpectateView, SpectateBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_DailyAcitivity:
                    DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_DailyAcitivity);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_ExcellentLive:
                    XSpectateDocument specificDocument2 = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
                    specificDocument2.ClickData = specificDocument2.MainInterfaceData;
                    specificDocument2.SetMainInterfaceBtnFalse();
                    XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("ExcellentLiveTips")), (object)specificDocument2.GetTitle(specificDocument2.ClickData.liveInfo)), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnExcellentLiveClick));
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_MobaAcitivity:
                    DlgBase<MobaActivityDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_MobaAcitivity);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Money:
                    XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Recharge);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Coin:
                    DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase(XMainClient.ItemEnum.GOLD);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Power:
                    DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase();
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GameMall:
                    DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Dragon, MallType.WEEK, 0UL);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Carnival:
                    DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.SetVisibleWithAnimation(true, (DlgBase<CarnivalDlg, CarnivalBehavior>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_OtherPlayerInfo:
                    DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Chat:
                    DlgBase<XChatView, XChatBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XChatView, XChatBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Friends:
                    DlgBase<XFriendsView, XFriendsBehaviour>.singleton.OnShowFriendDlg();
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_PK:
                    DlgBase<XPKInvitationView, XPKInvitationBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XPKInvitationView, XPKInvitationBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Broadcast:
                    this.OnQGameClick(go);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildHall:
                    if (!XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID).bInGuild)
                    {
                        XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_GUILD_NOT_IN_GUILD);
                        goto case XSysDefine.XSys_Wifi;
                    }
                    else
                    {
                        DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XGuildHallView, XGuildHallBehaviour>.OnAnimationOver)null);
                        goto case XSysDefine.XSys_Wifi;
                    }
                case XSysDefine.XSys_GuildRelax:
                    DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildDragon:
                case XSysDefine.XSys_GuildBossMainInterface:
                    DlgBase<XGuildDragonView, XGuildDragonBehaviour>.singleton.ShowGuildBossView();
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildPvp:
                case XSysDefine.XSys_GuildPvpMainInterface:
                    DlgBase<XGuildArenaDlg, TabDlgBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XGuildArenaDlg, TabDlgBehaviour>.OnAnimationOver)null);
                    XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID).bHasAvailableArenaIcon = false;
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildMine:
                case XSysDefine.XSys_GuildMineMainInterface:
                    DlgBase<GuildMineEntranceView, GuildMineEntranceBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<GuildMineEntranceView, GuildMineEntranceBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_CrossGVG:
                    DlgBase<CrossGVGMainView, TabDlgBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<CrossGVGMainView, TabDlgBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Team:
                    DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView();
                    XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_SevenActivity:
                    DlgBase<SevenLoginDlg, SevenLoginBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<SevenLoginDlg, SevenLoginBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Title:
                    DlgBase<TitleDlg, TitleDlgBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<TitleDlg, TitleDlgBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Home:
                case XSysDefine.XSys_Home_Cooking:
                case XSysDefine.XSys_Home_Fishing:
                case XSysDefine.XSys_Home_Feast:
                case XSysDefine.XSys_Home_MyHome:
                    DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(id);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Home_Plant:
                    DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Home);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Pet_Pairs:
                    DlgBase<PairsPetInviteView, PairsPetInviteBehaviour>.singleton.SetVisible(true, true);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_WeekEndNest:
                    DlgBase<WeekEndNestDlg, WeekEndNestBehaviour>.singleton.SetVisible(true, true);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Mall_Home:
                    DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(id);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Rank_WorldBoss:
                    DlgBase<XRankView, XRankBehaviour>.singleton.ShowRank(XSysDefine.XSys_Rank_WorldBoss);
                    XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID).SetMainInterfaceBtnState(false);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_LevelSeal_Tip:
                    XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID).ReqLevelSealButtonClick();
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_MentorshipMsg_Tip:
                    DlgBase<XMentorshipApplicationsView, XMentorshipApplicationBehavior>.singleton.SetVisibleWithAnimation(true, (DlgBase<XMentorshipApplicationsView, XMentorshipApplicationBehavior>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Activity_WorldBoss:
                    DlgBase<XWorldBossView, XWorldBossBehaviour>.singleton.ShowView();
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Activity_CaptainPVP:
                    XDocuments.GetSpecificDocument<XCaptainPVPDocument>(XCaptainPVPDocument.uuID).SetMainInterfaceBtnState(false);
                    XSingleton<UiUtility>.singleton.ShowModalDialog(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("MainInterfaceCaptainPVPTips")), XStringDefineProxy.GetString("BtnTips_EnterNow"), XStringDefineProxy.GetString("BtnTips_Then"), new ButtonClickEventHandler(this.OnCaptainJoin));
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_BigMelee:
                    DlgBase<BigMeleeEntranceView, BigMeleeEntranceBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<BigMeleeEntranceView, BigMeleeEntranceBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_BigMeleeEnd:
                    XBigMeleeEntranceDocument specificDocument3 = XDocuments.GetSpecificDocument<XBigMeleeEntranceDocument>(XBigMeleeEntranceDocument.uuID);
                    DlgHandlerBase.EnsureCreate<BigMeleeRankHandler>(ref specificDocument3.RankHandler, this.uiBehaviour.m_Canvas);
                    specificDocument3.RankHandler.SetType(false);
                    specificDocument3.MainInterfaceStateEnd = false;
                    this.RefreshH5ButtonState(XSysDefine.XSys_BigMeleeEnd);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Battlefield:
                    DlgBase<BattleFieldEntranceView, BattleFieldEntranceBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<BattleFieldEntranceView, BattleFieldEntranceBehaviour>.OnAnimationOver)null);
                    XBattleFieldEntranceDocument.Doc.SetMainInterfaceBtnState(false);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_MulActivity_SkyArena:
                    XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_MulActivity_SkyArena);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_MulActivity_Race:
                    XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_MulActivity_Race);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_MulActivity_WeekendParty:
                    DlgBase<ActivityWeekendPartyView, ActivityWeekendPartyBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<ActivityWeekendPartyView, ActivityWeekendPartyBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_MulActivity_SkyArenaEnd:
                    DlgBase<XRankView, XRankBehaviour>.singleton.ShowRank(XSysDefine.XSys_Rank_SkyArena);
                    XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2M_MulActivityIconSysReq()
                    {
                        Data = {
              id = (uint) XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_MulActivity_SkyArenaEnd)
            }
                    });
                    XSkyArenaEntranceDocument.Doc.MainInterfaceStateEnd = false;
                    this.RefreshH5ButtonState(XSysDefine.XSys_MulActivity_SkyArenaEnd);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Welfare:
                    DlgBase<XWelfareView, XWelfareBehaviour>.singleton.Show();
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Welfare_FirstRechange:
                    DlgBase<XWelfareView, XWelfareBehaviour>.singleton.Show(XSysDefine.XSys_Welfare_FirstRechange);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Welfare_NiceGirl:
                    DlgBase<XWelfareView, XWelfareBehaviour>.singleton.Show(XSysDefine.XSys_Welfare_NiceGirl);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.Xsys_Backflow:
                    DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.SetVisible(true, true);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.Xsys_TaJieHelp:
                    DlgBase<TaJieHelpDlg, TaJieHelpBehaviour>.singleton.SetVisible(true, true);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_OperatingActivity:
                    DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.Show();
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_OldFriendsBack:
                    DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.Show(XSysDefine.XSys_OldFriendsBack);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_NPCFavor:
                    XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_NPCFavor);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GroupRecruitAuthorize:
                    DlgBase<RecruitAuthorizeView, RecruitAuthorizeBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<RecruitAuthorizeView, RecruitAuthorizeBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_ThemeActivity:
                    DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XThemeActivityView, XThemeActivityBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildRelax_VoiceQA:
                    XVoiceQADocument specificDocument4 = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
                    if (specificDocument4.IsVoiceQAIng)
                    {
                        DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.SetVisible(true, true);
                        goto case XSysDefine.XSys_Wifi;
                    }
                    else
                    {
                        XSingleton<UiUtility>.singleton.ShowModalDialog(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("VoiceQA_Enter_Description_" + specificDocument4.TempType.ToString())), XStringDefineProxy.GetString("VoiceQA_Enter_btn1"), XStringDefineProxy.GetString("VoiceQA_Enter_btn2"), new ButtonClickEventHandler(this.OnVoiceQAJoin), new ButtonClickEventHandler(this.OnVoiceQARefuse));
                        goto case XSysDefine.XSys_Wifi;
                    }
                case XSysDefine.XSys_GuildRelax_JokerMatch:
                    XDocuments.GetSpecificDocument<XGuildJockerMatchDocument>(XGuildJockerMatchDocument.uuID).SendReqJokerMatchJoin();
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildBoon_RedPacket:
                    XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID).ReqGetLast();
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildQualifier:
                    if (!XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID).bInGuild)
                    {
                        XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_GUILD_NOT_IN_GUILD);
                        goto case XSysDefine.XSys_Wifi;
                    }
                    else
                    {
                        DlgBase<GuildQualifierDlg, GuildQualifierBehavior>.singleton.SetVisibleWithAnimation(true, (DlgBase<GuildQualifierDlg, GuildQualifierBehavior>.OnAnimationOver)null);
                        goto case XSysDefine.XSys_Wifi;
                    }
                case XSysDefine.XSys_GuildMineMain:
                    DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<GuildMineMainView, GuildMineMainBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildDailyTask:
                    DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.SetVisible(true, true);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildInherit:
                    DlgBase<GuildInheritDlg, GuildInheritBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<GuildInheritDlg, GuildInheritBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_JockerKing:
                    XDocuments.GetSpecificDocument<XJokerKingDocument>(XJokerKingDocument.uuID).JokerKingMatchAdd();
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Team_Invited:
                    DlgBase<XTeamInvitedListView, XTeamInvitedListBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XTeamInvitedListView, XTeamInvitedListBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildDailyRefresh:
                    DlgBase<XGuildDailyRefreshTaskDlg, XGuildDailyRefreshTaskBehavior>.singleton.SetVisible(true, true);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildDailyRequest:
                    DlgBase<XGuildDailyHandleRefreshDlg, XGuildDailyHandleRefreshBehavior>.singleton.SetVisible(true, true);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_IDIP_ZeroReward:
                    XIDIPDocument specificDocument5 = XDocuments.GetSpecificDocument<XIDIPDocument>(XIDIPDocument.uuID);
                    string leftTimeString = specificDocument5.GetLeftTimeString();
                    if (leftTimeString == "0")
                    {
                        specificDocument5.ZeroRewardBtnState = false;
                        this.RefreshH5ButtonState(XSysDefine.XSys_IDIP_ZeroReward);
                        goto case XSysDefine.XSys_Wifi;
                    }
                    else
                    {
                        XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("IDIP_TIPS_ZEROREWARDClick"), (object)leftTimeString), XStringDefineProxy.GetString("COMMON_OK"));
                        goto case XSysDefine.XSys_Wifi;
                    }
                case XSysDefine.XSys_Photo:
                    XDanceDocument.Doc.GetAllDanceIDs();
                    this.RefreshV3BtnSelect(go);
                    DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.SetVisible(true, true);
                    DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.ShowMainView();
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_SpriteSystem:
                    DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_SpriteSystem_Main);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_QuickRide:
                    this.RefreshV3BtnSelect(go);
                    XPetDocument specificDocument6 = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
                    if (XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook.state.type == OutLookStateType.OutLook_RidePetCopilot)
                    {
                        specificDocument6.OnReqOffPetPairRide();
                        goto case XSysDefine.XSys_Wifi;
                    }
                    else
                    {
                        if (specificDocument6.Pets.Count == 0)
                            XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("PET_NONE"), "fece00");
                        else
                            specificDocument6.ReqRecentMount();
                        goto case XSysDefine.XSys_Wifi;
                    }
                case XSysDefine.XSys_Transform:
                    XDocuments.GetSpecificDocument<XTransformDocument>(XTransformDocument.uuID).ReqSwitch();
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GameCommunity:
                    if (this._GameCommunityHandler == null)
                    {
                        this._GameCommunityHandler = DlgHandlerBase.EnsureCreate<GameCommunityHandler>(ref this._GameCommunityHandler, this.uiBehaviour.m_SecondMenu.transform, handlerMgr: ((IDlgHandlerMgr)this));
                        goto case XSysDefine.XSys_Wifi;
                    }
                    else
                    {
                        this._GameCommunityHandler.SetVisible(!this._GameCommunityHandler.IsVisible());
                        goto case XSysDefine.XSys_Wifi;
                    }
                case XSysDefine.XSys_FriendCircle:
                    dictionary["link"] = XSingleton<XGlobalConfig>.singleton.GetValue("FriendsCircleUrl");
                    XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_wx_deeplink", Json.Serialize((object)dictionary));
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_QQVIP:
                    XPlatformAbilityDocument.Doc.ClickRedPointNtf();
                    XPlatformAbilityDocument.Doc.OpenQQVipRechargeH5();
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_SystemAnnounce:
                    DlgBase<AnnounceView, AnnounceBehaviour>.singleton.SetVisible(true, true);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_HeroBattle:
                    XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID).MaininterfaceState = false;
                    this.RefreshH5ButtonState(XSysDefine.XSys_HeroBattle);
                    XSingleton<UiUtility>.singleton.ShowModalDialog(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("MainInterfaceHeroBattlePVPTips")), XStringDefineProxy.GetString("BtnTips_EnterNow"), XStringDefineProxy.GetString("BtnTips_Then"), new ButtonClickEventHandler(this.OnHeroBattleJoin));
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_TeamLeague:
                    XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID).SetMainInterfaceBtnState(false);
                    XSingleton<UiUtility>.singleton.ShowModalDialog(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("MainInterfaceTeamLeagueTips")), XStringDefineProxy.GetString("BtnTips_EnterNow"), XStringDefineProxy.GetString("BtnTips_Then"), new ButtonClickEventHandler(this.OnTeamLeagueJoin));
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildMineEnd:
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_QueryResWar()
                    {
                        oArg = {
              param = QueryResWarEnum.RESWAR_FLOWAWARD
            }
                    });
                    XDocuments.GetSpecificDocument<XGuildMineEntranceDocument>(XGuildMineEntranceDocument.uuID).MainInterfaceStateEnd = false;
                    this.RefreshH5ButtonState(XSysDefine.XSys_GuildMineEnd);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildTerritory:
                    DlgBase<GuildTerritoryMainDlg, GuildTerritoryMainBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<GuildTerritoryMainDlg, GuildTerritoryMainBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildTerritoryIconInterface:
                    XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID).OnClickTerritoryIcon();
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildTerritoryAllianceInterface:
                    DlgBase<GuildTerritoryLeagueDlg, GuildTerritoryLeagueBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<GuildTerritoryLeagueDlg, GuildTerritoryLeagueBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildTerritoryMessageInterface:
                    DlgBase<GuildTerritoryMessageDlg, GuildTerritoryMessageBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<GuildTerritoryMessageDlg, GuildTerritoryMessageBehaviour>.OnAnimationOver)null);
                    XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID).bHavaShowMessageIcon = false;
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Platform_StartPrivilege:
                    DlgBase<XQQWXGameCenterPrivilegeView, XQQWXGameCenterPrivilegeBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XQQWXGameCenterPrivilegeView, XQQWXGameCenterPrivilegeBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_Exchange:
                    DlgBase<RequestDlg, RequestBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<RequestDlg, RequestBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildCollectMainInterface:
                    XDocuments.GetSpecificDocument<XGuildCollectDocument>(XGuildCollectDocument.uuID).SetMainInterfaceBtnState(false);
                    if (XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID).bInGuild)
                    {
                        XSingleton<UiUtility>.singleton.ShowModalDialog(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("GuildCollectJoinTips1")), XStringDefineProxy.GetString("BtnTips_EnterNow"), XStringDefineProxy.GetString("BtnTips_Then"), new ButtonClickEventHandler(this.OnJoinGuildBtnClick));
                        goto case XSysDefine.XSys_Wifi;
                    }
                    else
                    {
                        XSingleton<UiUtility>.singleton.ShowModalDialog(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("GuildCollectJoinTips2")), XStringDefineProxy.GetString("BtnTips_EnterGuild"), XStringDefineProxy.GetString("BtnTips_Then"), new ButtonClickEventHandler(this.OnJoinGuildBtnClick));
                        goto case XSysDefine.XSys_Wifi;
                    }
                case XSysDefine.XSys_GuildCollect:
                    DlgBase<GuildCollectRewardDlg, GuildCollectRewardBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<GuildCollectRewardDlg, GuildCollectRewardBehaviour>.OnAnimationOver)null);
                    goto case XSysDefine.XSys_Wifi;
                case XSysDefine.XSys_GuildCollectSummon:
                    XDocuments.GetSpecificDocument<XGuildCollectDocument>(XGuildCollectDocument.uuID).QuerySummon();
                    goto case XSysDefine.XSys_Wifi;
                default:
                    XSingleton<XDebug>.singleton.AddErrorLog("This system hasn't finished: ", id.ToString());
                    goto case XSysDefine.XSys_Wifi;
            }
        }

        public void SetSystemRedPointState(XSysDefine sys, bool state)
        {
            if (sys == XSysDefine.XSys_GuildDailyTask)
                this._TaskNaviHandler.TaskHandler.RefreshVisibleContents();
            else if (sys == XSysDefine.XSys_GuildWeeklyBountyTask)
            {
                this._TaskNaviHandler.TaskHandler.RefreshVisibleContents();
            }
            else
            {
                IXUIButton sysButton = this.uiBehaviour.GetSysButton(sys);
                if (sysButton == null)
                    return;
                Transform child = sysButton.gameObject.transform.FindChild("RedPoint");
                if (!((UnityEngine.Object)child != (UnityEngine.Object)null))
                    return;
                child.gameObject.SetActive(state);
            }
        }

        public void InitRedPointsWhenShow()
        {
            XGameSysMgr singleton = XSingleton<XGameSysMgr>.singleton;
            for (int index1 = 0; index1 < this.uiBehaviour.m_SysButtonsMapping.Length; ++index1)
            {
                if (this.uiBehaviour.m_SysButtonsMapping[index1] != null)
                {
                    XSysDefine sys = (XSysDefine)index1;
                    List<XSysDefine> childSys = singleton.GetChildSys(sys);
                    for (int index2 = 0; index2 < childSys.Count; ++index2)
                        singleton.RecalculateRedPointState(childSys[index2], false);
                    singleton.UpdateRedPointOnHallUI(sys);
                }
            }
            this.OnGuildSysChange();
        }

        public void InitSevenLoginWhenShow()
        {
            if ((UnityEngine.Object)this.uiBehaviour == (UnityEngine.Object)null || this.uiBehaviour.m_SevenLoginMessage == null)
                return;
            XSevenLoginDocument specificDocument = XDocuments.GetSpecificDocument<XSevenLoginDocument>(XSevenLoginDocument.uuID);
            if (!specificDocument.bHasAvailableSevenIcon)
                return;
            string message = string.Empty;
            string spriteName = string.Empty;
            if (!specificDocument.TryGetHallMessage(out message, out spriteName))
                return;
            this.uiBehaviour.m_SevenLoginMessage.SetText(message);
            this.uiBehaviour.m_SevenLoginSprite.SetSprite(spriteName);
            this.uiBehaviour.m_SevenLoginSprite.MakePixelPerfect();
        }

        public void SetMultiActivityTips(object o = null)
        {
            XActivityDocument doc = XActivityDocument.Doc;
            if (this.uiBehaviour.m_MulActTips.IsVisible() && doc.MainInterfaceTips != null && doc.MainInterfaceTips != "")
            {
                this.uiBehaviour.m_MulActTips.SetText(doc.MainInterfaceTips);
                (this.uiBehaviour.m_MulActTips.gameObject.GetComponent("XUIPlayTween") as IXUITweenTool).PlayTween(true);
            }
            XSingleton<XTimerMgr>.singleton.KillTimer(this.MulActTipsToken);
            this.MulActTipsToken = XSingleton<XTimerMgr>.singleton.SetTimer((float)this._MulActTipsCD, new XTimerMgr.ElapsedEventHandler(this.SetMultiActivityTips), (object)null);
        }

        public void OnVoiceBtnAppear(uint textType)
        {
            XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID).MainInterFaceBtnState = true;
            this.RefreshH5ButtonState(XSysDefine.XSys_GuildRelax_VoiceQA);
        }

        public bool OnVoiceQAJoin(IXUIButton btn)
        {
            XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
            specificDocument.VoiceQAJoinChoose(true, specificDocument.TempType);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            return true;
        }

        public bool OnVoiceQARefuse(IXUIButton btn)
        {
            XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
            specificDocument.VoiceQAJoinChoose(false, specificDocument.TempType);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            return true;
        }

        private bool OnCaptainJoin(IXUIButton btn)
        {
            XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Activity_CaptainPVP);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            return true;
        }

        private bool OnTeamLeagueJoin(IXUIButton btn)
        {
            LeagueBattleTimeState todayState = XFreeTeamVersusLeagueDocument.Doc.TodayState;
            if (todayState == LeagueBattleTimeState.LBTS_CrossElimination || todayState == LeagueBattleTimeState.LBTS_Elimination)
                DlgBase<XTeamLeagueFinalResultView, XTeamLeagueFinalResultBehavior>.singleton.SetVisibleWithAnimation(true, (DlgBase<XTeamLeagueFinalResultView, XTeamLeagueFinalResultBehavior>.OnAnimationOver)null);
            else
                DlgBase<XFreeTeamLeagueMainView, XFreeTeamLeagueMainBehavior>.singleton.SetVisibleWithAnimation(true, (DlgBase<XFreeTeamLeagueMainView, XFreeTeamLeagueMainBehavior>.OnAnimationOver)null);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            return true;
        }

        private bool OnHeroBattleJoin(IXUIButton btn)
        {
            XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_HeroBattle);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            return true;
        }

        private bool OnExcellentLiveClick(IXUIButton btn)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID).MainInterfaceEnterQuery();
            return true;
        }

        private bool OnJoinGuildBtnClick(IXUIButton btn)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            int num = (int)XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID).TryEnterGuildScene();
            return true;
        }

        public void ShowRemoveSealLeftTime(
          IXUILabel label,
          ref XLeftTimeCounter _LevelSealCDCounter,
          ref bool isLevelSealCountdown)
        {
            int leftTime = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID).GetLeftTime();
            if (leftTime >= 86400)
            {
                isLevelSealCountdown = false;
                string strText = string.Format(XSingleton<XStringTable>.singleton.GetString("SEAL_REMOVE_LEFT"), (object)XSingleton<UiUtility>.singleton.TimeAccFormatString(leftTime, 1, 1));
                label.SetText(strText);
            }
            else if (leftTime <= 0)
            {
                isLevelSealCountdown = false;
                string strText = string.Format(XSingleton<XStringTable>.singleton.GetString("SEAL_REMOVE_LEFT"), (object)"00:00");
                label.SetText(strText);
            }
            else
            {
                isLevelSealCountdown = true;
                if (_LevelSealCDCounter == null)
                    _LevelSealCDCounter = new XLeftTimeCounter(label);
                _LevelSealCDCounter.SetLeftTime((float)leftTime);
                _LevelSealCDCounter.SetFormatString(XSingleton<XStringTable>.singleton.GetString("SEAL_REMOVE_LEFT"));
                _LevelSealCDCounter.SetTimeFormat(2, minUnit: 3);
                _LevelSealCDCounter.SetCarry();
            }
        }

        public void PlayGetPartnerEffect() => XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_yh", this.uiBehaviour.transform, Vector3.zero, Vector3.one, follow: true, duration: 3f);

        public void ShowLiveCount(uint count)
        {
            this.uiBehaviour.m_LiveTips.SetActive(count > 0U);
            if (count > 9U)
                this.uiBehaviour.m_LiveCount.SetText("...");
            else
                this.uiBehaviour.m_LiveCount.SetText(count.ToString());
        }

        public bool SetSystemAnnounce()
        {
            SystemAnnounce.RowData sysAnnounceData = XSingleton<XGameSysMgr>.singleton.GetSysAnnounceData(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
            if (sysAnnounceData == null)
                return false;
            IXUIButton sysButton = this.uiBehaviour.GetSysButton(XSysDefine.XSys_SystemAnnounce);
            (sysButton.gameObject.transform.Find("Level").GetComponent("XUILabel") as IXUILabel).SetText(sysAnnounceData.OpenAnnounceLevel.ToString());
            (sysButton.gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite).spriteName = sysAnnounceData.AnnounceIcon;
            IXUISprite component = sysButton.gameObject.transform.Find("Name").GetComponent("XUISprite") as IXUISprite;
            component.spriteName = sysAnnounceData.TextSpriteName;
            component.MakePixelPerfect();
            return true;
        }

        public void SetGetExpAnimation(ulong exp, Vector3 pos)
        {
            if ((UnityEngine.Object)Camera.main == (UnityEngine.Object)null)
                return;
            XSingleton<XDebug>.singleton.AddGreenLog("exp:", exp.ToString());
            int curExpInd = this._curExpInd;
            this._curExpInd = (this._curExpInd + 1) % this._maxExpCount;
            Vector3 worldPoint = XSingleton<XGameUI>.singleton.UICamera.ScreenToWorldPoint(Camera.main.WorldToScreenPoint(pos));
            worldPoint.z = 0.0f;
            this.uiBehaviour.m_ExpValueMgr[curExpInd].gameObject.transform.InverseTransformPoint(worldPoint);
            this.uiBehaviour.m_ExpValueMgr[curExpInd].SetText(string.Format("jy+{0}", (object)exp));
            this.uiBehaviour.m_ExpAnimationMgr[curExpInd].PlayTween(true);
        }

        public Vector3 GetSelectDanceMotionBtnPos() => this.lastSelectV3Button != null ? this.lastSelectV3Button.gameObject.transform.position : Vector3.zero;

        private void RefreshV3BtnSelect(IXUIButton newBtn)
        {
            if (this._DanceMotionHandler != null)
                this._DanceMotionHandler.SetVisible(false);
            if (this.lastSelectV3Button != null)
            {
                Transform child = this.lastSelectV3Button.gameObject.transform.FindChild("Select");
                if ((UnityEngine.Object)child != (UnityEngine.Object)null)
                    child.gameObject.SetActive(false);
            }
            if (newBtn != null)
            {
                Transform child = newBtn.gameObject.transform.FindChild("Select");
                if ((UnityEngine.Object)child != (UnityEngine.Object)null)
                    child.gameObject.SetActive(true);
            }
            this.lastSelectV3Button = newBtn;
        }

        private bool OnMotionClicked(IXUIButton btn)
        {
            if (!this.IsLoaded())
                return true;
            bool flag = false;
            if (this.lastSelectV3Button != null && this.lastSelectV3Button == btn && this._DanceMotionHandler != null && this._DanceMotionHandler.IsVisible())
                flag = true;
            this.RefreshV3BtnSelect(btn);
            if (!flag && this._DanceMotionHandler != null)
            {
                this._DanceMotionHandler.SetVisible(true);
                XDanceDocument.Doc.GetDanceIDs((uint)btn.ID);
            }
            return true;
        }

        public void RefreshMotionPanel(List<DanceMotionData> motions)
        {
            if (this._DanceMotionHandler == null || !this._DanceMotionHandler.IsVisible())
                return;
            this._DanceMotionHandler.RefreshMotionPanel(motions);
        }

        private void OnV3SwitchBtnClick(IXUISprite iSp)
        {
            if (!this.IsLoaded())
                return;
            this._V3SwitchBtnState = !this._V3SwitchBtnState;
            int group = this._V3SwitchBtnState ? 1 : 2;
            this.uiBehaviour.m_V3ListTween.SetTweenGroup(group);
            this.uiBehaviour.m_V3ListTween.PlayTween(true);
            this.uiBehaviour.m_V3SwitchTween.SetTweenGroup(group);
            this.uiBehaviour.m_V3SwitchTween.PlayTween(true);
            if (!this._V3SwitchBtnState)
            {
                if (this._DanceMotionHandler == null)
                    return;
                this._DanceMotionHandler.SetVisible(false);
            }
            else
                XDocuments.GetSpecificDocument<XTransformDocument>(XTransformDocument.uuID).ReqLeftTime();
        }

        private void OnH2SwitchBtnClick(IXUISprite iSp)
        {
            if (!this.IsLoaded())
                return;
            this._H2SwitchBtnState = !this._H2SwitchBtnState;
            if (this._H2SwitchBtnState)
                this.uiBehaviour.m_H2SwitchBtn.gameObject.transform.Find("RedPoint").gameObject.SetActive(false);
            int group = this._H2SwitchBtnState ? 1 : 0;
            this.uiBehaviour.m_H2ListTween.SetTweenGroup(group);
            this.uiBehaviour.m_H2SwitchTween.SetTweenGroup(group);
            this.uiBehaviour.m_H2ListTween.PlayTween(true);
            this.uiBehaviour.m_H2SwitchTween.PlayTween(true);
        }

        public void CalH2SwitchBtnRedPointState(IXUITweenTool o = null)
        {
            if (!this.IsLoaded())
                return;
            GameObject gameObject = this.uiBehaviour.m_H2SwitchBtn.gameObject.transform.Find("RedPoint").gameObject;
            if (this._H2SwitchBtnState)
                gameObject.SetActive(false);
            else
                gameObject.SetActive(this.CalMenuUIRedPoint(XSysDefine.XSys_GameMall) || this.CalMenuUIRedPoint(XSysDefine.XSys_Auction) || this.CalMenuUIRedPoint(XSysDefine.XSys_Reward) || this.CalMenuUIRedPoint(XSysDefine.XSys_Welfare) || this.CalMenuUIRedPoint(XSysDefine.Xsys_Backflow) || this.CalMenuUIRedPoint(XSysDefine.XSys_Strong) || this.CalMenuUIRedPoint(XSysDefine.XSys_Spectate) || this.CalMenuUIRedPoint(XSysDefine.XSys_OperatingActivity) || this.CalMenuUIRedPoint(XSysDefine.XSys_Welfare_FirstRechange) || this.CalMenuUIRedPoint(XSysDefine.XSys_SevenActivity) || this.CalMenuUIRedPoint(XSysDefine.XSys_ThemeActivity) || this.CalMenuUIRedPoint(XSysDefine.XSys_Carnival));
        }

        private void OnMenuSwitchBtnClick(IXUISprite iSp)
        {
            if (!this.IsLoaded())
                return;
            this._MenuSwitchBtnState = !this._MenuSwitchBtnState;
            this.CalMenuSwitchBtnRedPointState();
            int group = this._MenuSwitchBtnState ? 1 : 2;
            this.uiBehaviour.m_MenuSwitchBtnTween.SetTweenGroup(group);
            if (this.m_curScene == SceneType.SCENE_HALL)
            {
                this.uiBehaviour.m_SysListH0Tween.SetTweenGroup(group);
                this.uiBehaviour.m_SysListH0Tween.PlayTween(true);
            }
            else if (this.m_curScene == SceneType.SCENE_GUILD_HALL)
            {
                this.uiBehaviour.m_SysListH2Tween.SetTweenGroup(group);
                this.uiBehaviour.m_SysListH2Tween.PlayTween(true);
            }
            else if (this.m_curScene == SceneType.SCENE_FAMILYGARDEN)
            {
                this.uiBehaviour.m_SysListH3Tween.SetTweenGroup(group);
                this.uiBehaviour.m_SysListH3Tween.PlayTween(true);
            }
            this.uiBehaviour.m_SysListH1Tween.SetTweenGroup(group);
            this.uiBehaviour.m_SysListH1Tween.PlayTween(true);
            this.uiBehaviour.m_MenuSwitchBtnTween.PlayTween(true);
        }

        public void CalMenuSwitchBtnRedPointState()
        {
            if (!this.IsVisible())
                return;
            GameObject gameObject = this.uiBehaviour.m_MenuSwitchBtn.gameObject.transform.Find("RedPoint").gameObject;
            if (this._MenuSwitchBtnState)
            {
                if (this.m_curScene == SceneType.SCENE_HALL)
                {
                    gameObject.SetActive(this.CalMenuUIRedPoint(XSysDefine.XSys_Friends) || this.CalMenuUIRedPoint(XSysDefine.XSys_Home) || this.CalMenuUIRedPoint(XSysDefine.XSys_Rank) || this.CalMenuUIRedPoint(XSysDefine.XSys_CardCollect) || this.CalMenuUIRedPoint(XSysDefine.XSys_NPCFavor));
                }
                else
                {
                    if (this.m_curScene != SceneType.SCENE_GUILD_HALL)
                        return;
                    gameObject.SetActive(this.CalMenuUIRedPoint(XSysDefine.XSys_GuildHall) || this.CalMenuUIRedPoint(XSysDefine.XSys_GuildRelax));
                }
            }
            else
            {
                bool flag = false;
                foreach (XSysDefine sys in this.uiBehaviour.m_SysH1)
                    flag = flag || this.CalMenuUIRedPoint(sys);
                gameObject.SetActive(flag);
            }
        }

        private bool CalMenuUIRedPoint(XSysDefine sys) => XSingleton<XGameSysMgr>.singleton.IsSystemOpened(sys) && XSingleton<XGameSysMgr>.singleton.GetSysRedPointStateConsiderBlock(sys);

        private void RefreshListSwitchBtnVisable(IXUIObject iSp, IXUIList uiList, IXUIList uiList2 = null)
        {
            bool bVisible = false;
            for (int index = 0; index < uiList.gameObject.transform.childCount; ++index)
            {
                if (uiList.gameObject.transform.GetChild(index).gameObject.activeSelf)
                {
                    bVisible = true;
                    break;
                }
            }
            if (uiList2 == null | bVisible)
            {
                iSp.SetVisible(bVisible);
            }
            else
            {
                for (int index = 0; index < uiList2.gameObject.transform.childCount; ++index)
                {
                    if (uiList2.gameObject.transform.GetChild(index).gameObject.activeSelf)
                    {
                        bVisible = true;
                        break;
                    }
                }
                iSp.SetVisible(bVisible);
            }
        }

        private void RefreshV3H1OnOtherScene()
        {
            foreach (XSysDefine sys in this.uiBehaviour.m_SysV3)
                this.OnSingleSysChange(sys, false);
            this.uiBehaviour.m_SysListV3.Refresh();
            foreach (XSysDefine sys in this.uiBehaviour.m_SysH1)
                this.OnSingleSysChange(sys, false);
            this.uiBehaviour.m_SysListH1.Refresh();
        }

        public bool IsSupportQgame()
        {
            bool flag1 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ;
            bool flag2 = SystemInfo.processorType.StartsWith("Intel");
            bool flag3 = SystemInfo.systemMemorySize >= XSingleton<XGlobalConfig>.singleton.GetInt("QGameMemory");
            return ((!(XSingleton<XUpdater.XUpdater>.singleton.XBroadCast.IsBroadState() & flag1) ? 0 : (!flag2 ? 1 : 0)) & (flag3 ? 1 : 0)) != 0;
        }

        private bool OnQGameClick(IXUIButton btn)
        {
            if (DlgBase<ReplaykitDlg, ReplayBehaviour>.singleton.isPlaying)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("Replay_IsPlaying"), "fece00");
                return false;
            }
            if (XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID).roomState == XRadioDocument.BigRoomState.OutRoom)
            {
                XSingleton<XUpdater.XUpdater>.singleton.XBroadCast.EnterHall();
                XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2G_CloseHintNtf()
                {
                    Data = {
            systemid = 80U
          }
                });
            }
            else
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_FM_FORBID1"), "fece00");
            return true;
        }

        public void RefreshGuildCollectTime(int time, int summonTime)
        {
            this.uiBehaviour.m_GuildCollectLeftTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString(time, 2, 3, 4, false, true));
            this.uiBehaviour.m_GuildCollectSummonTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString(summonTime, 2, 3, 4, false, true));
        }

        public void OnShowFlowBack()
        {
            Transform uiRoot = XSingleton<UIManager>.singleton.UIRoot;
            if (!((UnityEngine.Object)uiRoot != (UnityEngine.Object)null))
                return;
            Transform parent = uiRoot.Find("Camera");
            if ((UnityEngine.Object)parent != (UnityEngine.Object)null)
            {
                XFx uiFx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_huanyinghuigu", parent);
                if (uiFx != null)
                {
                    float interval = 1.3f;
                    uiFx.DelayDestroy = interval;
                    XSingleton<XFxMgr>.singleton.DestroyFx(uiFx, false);
                    int num = (int)XSingleton<XTimerMgr>.singleton.SetTimer(interval, (XTimerMgr.ElapsedEventHandler)(param => XSingleton<UiUtility>.singleton.ShowModalDialogWithTitle(XStringDefineProxy.GetString("BackFlowWelcom"), XStringDefineProxy.GetString("BackFlowWelcomCotent"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), (ButtonClickEventHandler)(button =>
                    {
                        this.MainDoc.BackFlow = false;
                        DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
                        XSingleton<XShell>.singleton.Pause = false;
                        return true;
                    }))), (object)null);
                }
            }
        }

        public void SetTransformLeftTime(float time)
        {
            if (!this.IsLoaded())
                return;
            this.uiBehaviour.m_TransformLeftTime.SetLeftTime(time);
        }
    }
}
