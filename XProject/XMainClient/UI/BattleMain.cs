

using KKSG;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class BattleMain : DlgBase<BattleMain, BattleMainBehaviour>
    {
        public static uint _pool_size = 5;
        private float NoticeTime = 0.0f;
        private static Color32 _hp_green = new Color32((byte)110, (byte)174, (byte)0, byte.MaxValue);
        private static Color32 _hp_yellow = new Color32((byte)196, (byte)180, (byte)32, byte.MaxValue);
        private static Color32 _hp_red = new Color32((byte)196, (byte)57, (byte)18, byte.MaxValue);
        private static float _fYellow = 0.0f;
        private static float _fRed = 0.0f;
        private bool _can_auto_play = false;
        private Vector2 m_DragDistance = Vector2.zero;
        private bool m_CancelRecord = false;
        private bool m_IsRecording = false;
        private uint m_ChatLabelCd = 0;
        public ProfressionTrialsHandler ProfTrialsHandler;
        public BattleShowInfoHandler m_BattleShowInfoHandler = (BattleShowInfoHandler)null;
        private BattleCaptainPVPHandler m_BattleCaptainPVPHandler = (BattleCaptainPVPHandler)null;
        private GuildMinePVPBattleHandler m_GuildMinePVPBattleHandler = (GuildMinePVPBattleHandler)null;
        private GuildMinePVPInfoHandler m_GuildMinePVPInfoHandler = (GuildMinePVPInfoHandler)null;
        private SkyArenaBattleHandler m_SkyArenaBattleHandler = (SkyArenaBattleHandler)null;
        private SkyArenaInfoHandler m_SkyArenaInfoHandler = (SkyArenaInfoHandler)null;
        private AbyssPartyBattleHandler m_AbyssPartyBattleHandler = (AbyssPartyBattleHandler)null;
        public BigMeleeBattleHandler m_BigMeleeBattleHandler = (BigMeleeBattleHandler)null;
        public BattleFieldBattleHandler m_BattleFieldBattleHandler = (BattleFieldBattleHandler)null;
        private XOptionsBattleHandler m_XOptionBattleHandler = (XOptionsBattleHandler)null;
        private RaceBattleHandler m_RaceBattleHandler = (RaceBattleHandler)null;
        public GuildMiniReportHandler m_miniReportHandler = (GuildMiniReportHandler)null;
        public BattleRiftHandler m_riftHandler = (BattleRiftHandler)null;
        public GuildBattleMiniRankHandler m_miniRankHandler = (GuildBattleMiniRankHandler)null;
        public HeroBattleSkillHandler m_HeroBattleSkillHandler = (HeroBattleSkillHandler)null;
        public HeroBattleHandler m_HeroBattleHandler = (HeroBattleHandler)null;
        public MobaBattleHandler m_MobaBattleHandler = (MobaBattleHandler)null;
        public WeekendPartyHandler m_WeekendPartyHandler = (WeekendPartyHandler)null;
        public BattleStatisticsHandler m_BattleStatisticsHandler = (BattleStatisticsHandler)null;
        private BattleDpsHandler m_DpsHandler = (BattleDpsHandler)null;
        private SceneType sceneType;
        private XLeftTimeCounter leftTimeCounter;
        public XLeftTimeCounter timeConnter;
        private List<string> _notice_collection = new List<string>();
        private float _notice_duration = 0.0f;
        private float _notice_pertime = 1f;
        private List<ComboBuff> _combo_buff_list = new List<ComboBuff>();
        private int _combo_buff_to_add = -1;
        private int _combo_buff_added = -1;
        private XBattleDocument _doc;
        private XApolloDocument apolloDoc;
        private uint time_token = 0;
        public bool SpectateInfoIsShow;
        private XEntity _strength_preseved_entity = (XEntity)null;
        private float _total_strength_preseved = 1f;
        private float _current_strength_preseved = 0.0f;
        private float _last_check_time = 0.0f;
        private XTimerMgr.ElapsedEventHandler _showSingleNoticeCb = (XTimerMgr.ElapsedEventHandler)null;
        private XTimerMgr.ElapsedEventHandler _endBigNoticeCb = (XTimerMgr.ElapsedEventHandler)null;
        private XTimerMgr.ElapsedEventHandler _endBigNoticeCmdCb = (XTimerMgr.ElapsedEventHandler)null;
        private XTimerMgr.ElapsedEventHandler _onSwitchToTeamChatCb = (XTimerMgr.ElapsedEventHandler)null;
        private XTimerMgr.ElapsedEventHandler _hideBattleChatUICb = (XTimerMgr.ElapsedEventHandler)null;
        private XSwitchSight m_SwitchSight;
        private int _maxHP = 0;
        private int _currentHP = 0;
        private int _maxMP = 0;
        private int _currentMP = 0;
        public XYuyinView _yuyinHandler;
        private int type;
        private float lastPingTime = -60f;
        private float lastDebugUITrigger = -1f;
        private GameObject _big_notice = (GameObject)null;
        private uint _big_notice_timer_token = 0;

        public BattleSkillHandler SkillHandler => (Object)this.uiBehaviour == (Object)null ? (BattleSkillHandler)null : this.uiBehaviour.m_SkillHandler;

        public BattleIndicateHandler IndicateHandler => (Object)this.uiBehaviour == (Object)null ? (BattleIndicateHandler)null : this.uiBehaviour.m_IndicateHandler;

        public XTeamMonitorHandler TeamMonitor => (Object)this.uiBehaviour == (Object)null ? (XTeamMonitorHandler)null : this.uiBehaviour.m_TeamMonitor;

        public XBattleEnemyInfoHandler EnemyInfoHandler => (Object)this.uiBehaviour == (Object)null ? (XBattleEnemyInfoHandler)null : this.uiBehaviour.m_EnemyInfoHandler;

        public BattleTargetHandler BattleTargetHandler => (Object)this.uiBehaviour == (Object)null ? (BattleTargetHandler)null : this.uiBehaviour.m_BattleTargetHandler;

        public XBattleTeamTowerHandler TeamTowerHandler => (Object)this.uiBehaviour == (Object)null ? (XBattleTeamTowerHandler)null : this.uiBehaviour.m_TeamTowerHandler;

        public IXUILabel WarTimeLabel => (Object)this.uiBehaviour == (Object)null ? (IXUILabel)null : this.uiBehaviour.m_WarTime;

        public IXUILabel LeftTimeLabel => (Object)this.uiBehaviour == (Object)null ? (IXUILabel)null : this.uiBehaviour.m_LeftTime;

        public BattleDpsHandler DpsHandler => this.m_DpsHandler;

        private float _strength_preseved_precent
        {
            get
            {
                if ((double)this._current_strength_preseved > (double)this._total_strength_preseved)
                    this._total_strength_preseved = this._current_strength_preseved;
                return this._current_strength_preseved / this._total_strength_preseved;
            }
        }

        public override string fileName => "Battle/BattleDlg";

        public override int layer => 1;

        public override bool isMainUI => true;

        public BattleMain()
        {
            this._showSingleNoticeCb = new XTimerMgr.ElapsedEventHandler(this.ShowSingleNotice);
            this._endBigNoticeCb = new XTimerMgr.ElapsedEventHandler(this.EndBigNotice);
            this._endBigNoticeCmdCb = new XTimerMgr.ElapsedEventHandler(this.EndBigNoticeCmd);
            this._onSwitchToTeamChatCb = new XTimerMgr.ElapsedEventHandler(this.OnSwitchToTeamChat);
            this._hideBattleChatUICb = new XTimerMgr.ElapsedEventHandler(this.HideBattleChatUI);
            BattleMain._fYellow = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HP_Yellow"));
            BattleMain._fRed = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HP_Red"));
        }

        protected override void Init()
        {
            this._doc = XDocuments.GetSpecificDocument<XBattleDocument>(XBattleDocument.uuID);
            this.apolloDoc = XDocuments.GetSpecificDocument<XApolloDocument>(XApolloDocument.uuID);
            this._doc.BattleMainView = this;
            if (XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.Attributes != null)
                this._doc.FakeTeamAdd((XEntity)XSingleton<XEntityMgr>.singleton.Player);
            this.leftTimeCounter = new XLeftTimeCounter(this.uiBehaviour.m_LeftTime, true);
            this.timeConnter = new XLeftTimeCounter(this.uiBehaviour.m_WarTime);
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HORSE_RACE || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_HORSERACING)
            {
                (this.uiBehaviour.m_PingFrame.GetComponent("PositionGroup") as IXPositionGroup).SetGroup(1);
                this.uiBehaviour.m_RoleInfo.gameObject.SetActive(false);
            }
            string[] strArray = XSingleton<XGlobalConfig>.singleton.GetValue("ComboBuff").Split(XGlobalConfig.AllSeparators);
            for (int index = 0; index < strArray.Length; index += 3)
            {
                ComboBuff comboBuff = new ComboBuff();
                comboBuff.combo = int.Parse(strArray[index]);
                comboBuff.buffID = int.Parse(strArray[index + 1]);
                comboBuff.buffLevel = int.Parse(strArray[index + 2]);
                BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData(comboBuff.buffID, comboBuff.buffLevel);
                if (buffData != null)
                    comboBuff.buffName = buffData.BuffName;
                else
                    XSingleton<XDebug>.singleton.AddErrorLog(string.Format("ComboBuff: Buff data not found: [{0} {1}]", (object)comboBuff.buffID, (object)comboBuff.buffLevel));
                this._combo_buff_list.Add(comboBuff);
            }
            this.SetupHandler();
        }

        private void SetupHandler()
        {
            switch (XSingleton<XScene>.singleton.SceneType)
            {
                case SceneType.SCENE_PVP:
                    DlgHandlerBase.EnsureCreate<BattleCaptainPVPHandler>(ref this.m_BattleCaptainPVPHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
                    break;
                case SceneType.SKYCITY_FIGHTING:
                    DlgHandlerBase.EnsureCreate<SkyArenaBattleHandler>(ref this.m_SkyArenaBattleHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
                    DlgHandlerBase.EnsureCreate<SkyArenaInfoHandler>(ref this.m_SkyArenaInfoHandler, this.uiBehaviour.m_canvas);
                    break;
                case SceneType.SCENE_PROF_TRIALS:
                    DlgHandlerBase.EnsureCreate<ProfressionTrialsHandler>(ref this.ProfTrialsHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
                    break;
                case SceneType.SCENE_RESWAR_PVP:
                    DlgHandlerBase.EnsureCreate<GuildMinePVPBattleHandler>(ref this.m_GuildMinePVPBattleHandler, this.uiBehaviour.m_canvas);
                    DlgHandlerBase.EnsureCreate<GuildMinePVPInfoHandler>(ref this.m_GuildMinePVPInfoHandler, this.uiBehaviour.m_canvas);
                    break;
                case SceneType.SCENE_HORSE_RACE:
                case SceneType.SCENE_WEEKEND4V4_HORSERACING:
                    DlgHandlerBase.EnsureCreate<RaceBattleHandler>(ref this.m_RaceBattleHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
                    DlgHandlerBase.EnsureCreate<BattleShowInfoHandler>(ref this.m_BattleShowInfoHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
                    break;
                case SceneType.SCENE_HEROBATTLE:
                    DlgHandlerBase.EnsureCreate<HeroBattleSkillHandler>(ref this.m_HeroBattleSkillHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
                    DlgHandlerBase.EnsureCreate<HeroBattleHandler>(ref this.m_HeroBattleHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
                    this.m_HeroBattleSkillHandler.HandlerType = 0;
                    break;
                case SceneType.SCENE_CASTLE_WAIT:
                case SceneType.SCENE_CASTLE_FIGHT:
                    DlgHandlerBase.EnsureCreate<GuildBattleMiniRankHandler>(ref this.m_miniRankHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
                    DlgHandlerBase.EnsureCreate<GuildMiniReportHandler>(ref this.m_miniReportHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
                    break;
                case SceneType.SCENE_ABYSS_PARTY:
                    DlgHandlerBase.EnsureCreate<AbyssPartyBattleHandler>(ref this.m_AbyssPartyBattleHandler, this.uiBehaviour.m_canvas);
                    break;
                case SceneType.SCENE_MOBA:
                    DlgHandlerBase.EnsureCreate<HeroBattleSkillHandler>(ref this.m_HeroBattleSkillHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
                    DlgHandlerBase.EnsureCreate<MobaBattleHandler>(ref this.m_MobaBattleHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
                    this.m_HeroBattleSkillHandler.HandlerType = 2;
                    break;
                case SceneType.SCENE_WEEKEND4V4_MONSTERFIGHT:
                case SceneType.SCENE_WEEKEND4V4_GHOSTACTION:
                case SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE:
                case SceneType.SCENE_WEEKEND4V4_CRAZYBOMB:
                case SceneType.SCENE_WEEKEND4V4_DUCK:
                    DlgHandlerBase.EnsureCreate<WeekendPartyHandler>(ref this.m_WeekendPartyHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
                    break;
                case SceneType.SCENE_BIGMELEE_FIGHT:
                    DlgHandlerBase.EnsureCreate<BigMeleeBattleHandler>(ref this.m_BigMeleeBattleHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
                    break;
                case SceneType.SCENE_BATTLEFIELD_FIGHT:
                    DlgHandlerBase.EnsureCreate<BattleFieldBattleHandler>(ref this.m_BattleFieldBattleHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
                    break;
                case SceneType.SCENE_RIFT:
                    DlgHandlerBase.EnsureCreate<BattleRiftHandler>(ref this.m_riftHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
                    break;
            }
            if (!XHeroBattleDocument.LoadSkillHandler)
                return;
            DlgHandlerBase.EnsureCreate<HeroBattleSkillHandler>(ref this.m_HeroBattleSkillHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
            this.m_HeroBattleSkillHandler.HandlerType = 1;
        }

        public override void RegisterEvent()
        {
            this.uiBehaviour.m_avatar.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAvatarClick));
            this.uiBehaviour.m_pause.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPauseClick));
            this.uiBehaviour.m_AutoPlay.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAutoPlay));
            this.uiBehaviour.m_CancelAuto.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAutoPlay));
            this.uiBehaviour.m_AutoPlayTip.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAutoPlayTip));
            this.uiBehaviour.m_HorseRide.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHorseRideClicked));
            this.m_SwitchSight = new XSwitchSight(new ButtonClickEventHandler(this.OnSightSelectClick), this.uiBehaviour.m_25D, this.uiBehaviour.m_3D, this.uiBehaviour.m_3DFree);
            this.uiBehaviour.m_BtnDamageStatistics.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBattleStatisticsClick));
            this.uiBehaviour.m_Sight.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSightClick));
        }

        protected override void OnShow()
        {
            base.OnShow();
            XPlayerAttributes attributes1 = XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes;
            this.uiBehaviour.m_SightSelect.gameObject.SetActive(false);
            DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.Show(true);
            DlgBase<RadioBattleDlg, RadioBattleBahaviour>.singleton.Show(true);
            this.uiBehaviour.m_objBossRush.SetActive(XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BOSSRUSH);
            this.lastPingTime = -60f;
            this._combo_buff_to_add = -1;
            this._combo_buff_added = -1;
            this.uiBehaviour.m_avatar.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.Profession));
            this.SetTencentImage();
            this.uiBehaviour.m_Level.SetText(string.Format("{0}", (object)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level));
            this.uiBehaviour.m_Name.SetText(XSingleton<XEntityMgr>.singleton.Player.Name);
            XTeamDocument specificDocument1 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
            this.SpectateInfoIsShow = false;
            XSpectateSceneDocument specificDocument2 = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
            this.uiBehaviour.m_SpectateInfo.transform.localPosition = Vector3.one * (float)XGameUI._far_far_away;
            specificDocument2.GetTargetNum(true);
            this.OnSpectateMessageChange(0, 0);
            this.uiBehaviour.m_TeamLeader.SetActive(specificDocument1.bIsLeader);
            this.uiBehaviour.m_AutoPlayBorad.SetVisible(false);
            this.uiBehaviour.m_AutoPlayCancelBoard.SetVisible(false);
            this.uiBehaviour.m_SkillHandler.SetVisible(true);
            this.uiBehaviour.m_IndicateHandler.SetVisible(true);
            this.uiBehaviour.m_lblKill.SetVisible(false);
            this.uiBehaviour.m_SceneName.SetText(XSingleton<XScene>.singleton.SceneData.Comment);
            SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
            if (sceneData.TimeCounter == null || sceneData.TimeCounter.Length < 1)
                this.SetTimeRecord();
            else if (sceneData.TimeCounter[0] == (short)1)
            {
                if (sceneData.TimeCounter.Length > 2)
                    this.SetLeftTime((uint)sceneData.TimeCounter[1], (int)sceneData.TimeCounter[2]);
                else
                    this.SetLeftTime((uint)sceneData.TimeCounter[1]);
            }
            DlgHandlerBase.EnsureCreate<BattleDpsHandler>(ref this.m_DpsHandler, this.uiBehaviour.m_DpsPanel, (IDlgHandlerMgr)this, XDocuments.GetSpecificDocument<XCombatStatisticsDocument>(XCombatStatisticsDocument.uuID).bShowDps);
            bool bVisible = false;
            SeqListRef<int> winCondition = sceneData.WinCondition;
            for (int index = 0; index < winCondition.Count; ++index)
            {
                if (winCondition[index, 0] == 8)
                    bVisible = true;
            }
            this.uiBehaviour.m_lblKill.SetVisible(bVisible);
            this.UpdateKill(0);
            this.sceneType = (SceneType)sceneData.type;
            switch (this.sceneType)
            {
                case SceneType.SCENE_WORLDBOSS:
                case SceneType.SCENE_GUILD_BOSS:
                    this.uiBehaviour.m_WorldBossHandler.SetVisible(true);
                    break;
                case SceneType.SCENE_PK:
                    XQualifyingDocument specificDocument3 = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
                    if (specificDocument3.PkInfoList.Count > 0)
                    {
                        this.SetEnemyRoleInfo(specificDocument3.PkInfoList[0].brief.roleName, specificDocument3.PkInfoList[0].brief.roleLevel);
                        break;
                    }
                    break;
                case SceneType.SCENE_TOWER:
                    this.uiBehaviour.m_TeamTowerHandler.SetVisible(true);
                    break;
                case SceneType.SCENE_GODDESS:
                case SceneType.SCENE_ENDLESSABYSS:
                    this.GetTeamLeftTimes();
                    break;
                case SceneType.SCENE_INVFIGHT:
                    XPKInvitationDocument specificDocument4 = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
                    if (specificDocument4.PKInfoList.Count > 0)
                    {
                        this.SetEnemyRoleInfo(specificDocument4.PKInfoList[0].roleName, specificDocument4.PKInfoList[0].roleLevel);
                        break;
                    }
                    break;
                case SceneType.SCENE_CASTLE_WAIT:
                    this.uiBehaviour.m_SkillHandler.SetVisible(false);
                    break;
            }
            this.SetWinConditionTips();
            this.SetBattleExplainTips();
            XPlayerAttributes attributes2 = XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes;
            bool flag1 = XSingleton<XSceneMgr>.singleton.CanAutoPlay(XSingleton<XScene>.singleton.SceneID);
            bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("AutoPlayUnlockLevel"));
            this.uiBehaviour.m_AutoPlayContent.SetActive(flag1);
            if (flag1)
            {
                this._can_auto_play = true;
                if (flag2)
                {
                    this.uiBehaviour.m_AutoPlayBorad.SetVisible(true);
                    this.uiBehaviour.m_AutoPlay.SetEnable(false);
                    this.uiBehaviour.m_AutoPlayLock.SetVisible(true);
                }
                else
                {
                    if (this.sceneType == SceneType.SCENE_GODDESS)
                        this.uiBehaviour.m_AutoPlayCancelBoard.SetVisible(true);
                    else if (attributes2.AutoPlayOn)
                        this.uiBehaviour.m_AutoPlayCancelBoard.SetVisible(true);
                    else
                        this.uiBehaviour.m_AutoPlayBorad.SetVisible(true);
                    this.uiBehaviour.m_AutoPlayLock.SetVisible(false);
                    this.uiBehaviour.m_AutoPlay.SetEnable(true);
                }
            }
            else
            {
                this._can_auto_play = false;
                attributes2.AutoPlayOn = false;
            }
            switch (this.sceneType)
            {
                case SceneType.SCENE_ARENA:
                case SceneType.SCENE_PK:
                case SceneType.SCENE_INVFIGHT:
                    this.EnemyInfoHandler.InitRole();
                    break;
                default:
                    this.EnemyInfoHandler.InitBoss();
                    break;
            }
            XTeamDocument specificDocument5 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PVP)
                this.TeamMonitor.InitWhenShowMainUIByBloodList(XDocuments.GetSpecificDocument<XBattleCaptainPVPDocument>(XBattleCaptainPVPDocument.uuID).TeamBlood);
            else if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE)
                this.TeamMonitor.InitWhenShowMainUIByBloodList(XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID).TeamBlood);
            else if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_CRAZYBOMB || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_GHOSTACTION || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_HORSERACING || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_MONSTERFIGHT || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_DUCK)
                this.TeamMonitor.InitWhenShowMainUIByBloodList(XDocuments.GetSpecificDocument<XWeekendPartyDocument>(XWeekendPartyDocument.uuID).TeamBlood);
            else
                this.TeamMonitor.InitWhenShowMainUIByTeam(specificDocument5.MyTeam);
            if (XSingleton<XScene>.singleton.SceneID != 100U && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_CALLBACK && (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= (long)int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("ShowChatLevelBattle")))
                DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.ShowChatMiniUI(new ShowSettingArgs()
                {
                    position = 2,
                    showsettings = false,
                    enablebackclick = true,
                    enabledrag = false
                });
            this.uiBehaviour.m_StrengthPresevedBar.SetVisible(this._doc.ShowStrengthPresevedBar);
            this.RefreshYuyin();
            this.InitView();
            if (this.apolloDoc != null)
                this.apolloDoc.RequestJoinRoom();
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SKYCITY_FIGHTING || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BIGMELEE_FIGHT)
                this.uiBehaviour.m_SkyAreanStage.gameObject.SetActive(true);
            else
                this.uiBehaviour.m_SkyAreanStage.gameObject.SetActive(false);
            if ((long)XSingleton<XScene>.singleton.SceneID == (long)int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("GuildCampHorseSceneID")))
                this.uiBehaviour.m_HorseRide.gameObject.SetActive(true);
            else
                this.uiBehaviour.m_HorseRide.gameObject.SetActive(false);
            this.uiBehaviour.m_GuildMineBuff.gameObject.SetActive(false);
            this.uiBehaviour.m_pauseGroup.SetGroup(XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA ? 1 : 0);
            this.uiBehaviour.m_3D25D.gameObject.SetActive(XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_MOBA);
            this.uiBehaviour.m_BtnDamageStatistics.SetVisible(sceneData.ShowBattleStatistics);
            this.uiBehaviour.m_Menu.Refresh();
        }

        private void InitView() => this.SetView(XSingleton<XOperationData>.singleton.OperationMode);

        public void SetView(XOperationMode mode)
        {
            if ((Object)this.uiBehaviour == (Object)null || this.uiBehaviour.m_SightPic == null || this.uiBehaviour.m_SelectPic == null || (Object)this.uiBehaviour.m_SightSelect == (Object)null)
                return;
            switch (mode)
            {
                case XOperationMode.X25D:
                    this.uiBehaviour.m_SightPic.SetSprite("l_zdicon_1_1");
                    this.uiBehaviour.m_SelectPic.SetSprite("l_zdicon_1_1");
                    break;
                case XOperationMode.X3D:
                    this.uiBehaviour.m_SightPic.SetSprite("l_zdicon_1_0");
                    this.uiBehaviour.m_SelectPic.SetSprite("l_zdicon_1_0");
                    break;
                case XOperationMode.X3D_Free:
                    this.uiBehaviour.m_SightPic.SetSprite("l_zdicon_1_2");
                    this.uiBehaviour.m_SelectPic.SetSprite("l_zdicon_1_2");
                    break;
            }
            this.uiBehaviour.m_SightPic.MakePixelPerfect();
            this.uiBehaviour.m_SelectPic.MakePixelPerfect();
            this.uiBehaviour.m_SightSelect.gameObject.SetActive(false);
        }

        private void SetStartAutoPlay() => this.SetAutoPlay(true);

        private void GetTeamLeftTimes() => XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID).ReqTeamOp(TeamOperate.TEAM_QUERYCOUNT);

        private void SetWinConditionTips()
        {
            SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
            if (sceneData == null || string.IsNullOrEmpty(sceneData.WinConditionTips))
            {
                this.uiBehaviour.m_winConditionTips.SetVisible(false);
            }
            else
            {
                this.uiBehaviour.m_winConditionTips.SetVisible(true);
                this.uiBehaviour.m_winConditionTips.SetText(sceneData.WinConditionTips.Replace("/n", "\n"));
            }
        }

        private void SetBattleExplainTips()
        {
            SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
            if (sceneData == null || string.IsNullOrEmpty(sceneData.BattleExplainTips))
            {
                this.uiBehaviour.m_BattleExplainTips.SetVisible(false);
            }
            else
            {
                this.uiBehaviour.m_BattleExplainTips.SetVisible(true);
                this.uiBehaviour.m_BattleExplainTips.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(sceneData.BattleExplainTips));
            }
        }

        public void SetTeamLeftTimes()
        {
            this.uiBehaviour.m_leftTimes.SetVisible(true);
            XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
            SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
            if (sceneData.type == (byte)20)
            {
                int dayCount = specificDocument.GetDayCount(TeamLevelType.TeamLevelGoddessTrial);
                int dayMaxCount = specificDocument.GetDayMaxCount(TeamLevelType.TeamLevelGoddessTrial);
                this.uiBehaviour.m_leftTimes.SetText(string.Format("{0}({1}/{2})", (object)XStringDefineProxy.GetString("GODDESS_NAME"), (object)(dayMaxCount - dayCount), (object)dayMaxCount));
            }
            else if (sceneData.type == (byte)23)
            {
                int dayCount = specificDocument.GetDayCount(TeamLevelType.TeamLevelEndlessAbyss);
                int dayMaxCount = specificDocument.GetDayMaxCount(TeamLevelType.TeamLevelEndlessAbyss);
                this.uiBehaviour.m_leftTimes.SetText(string.Format("{0}({1}/{2})", (object)XStringDefineProxy.GetString("EndlessAbyss"), (object)(dayMaxCount - dayCount), (object)dayMaxCount));
            }
            else
                this.uiBehaviour.m_leftTimes.SetVisible(false);
        }

        protected override void OnLoad()
        {
            this._maxHP = 0;
            this._currentHP = 0;
            this._maxMP = 0;
            this._currentMP = 0;
            base.OnLoad();
            DlgHandlerBase.EnsureCreate<XYuyinView>(ref this._yuyinHandler, this.uiBehaviour.transform, handlerMgr: ((IDlgHandlerMgr)this));
        }

        protected override void OnHide()
        {
            this.uiBehaviour.m_SkillHandler.SetVisible(false);
            if (DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.IsLoaded())
                DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetVisible(false, true);
            if (DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.IsLoaded())
                DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.Show(false);
            if (DlgBase<RadioBattleDlg, RadioBattleBahaviour>.singleton.IsLoaded())
                DlgBase<RadioBattleDlg, RadioBattleBahaviour>.singleton.Show(false);
            if (DlgBase<XChatView, XChatBehaviour>.singleton.IsLoaded())
                DlgBase<XChatView, XChatBehaviour>.singleton.SetVisible(false, true);
            this._maxHP = 0;
            this._currentHP = 0;
            this._maxMP = 0;
            this._currentMP = 0;
            base.OnHide();
        }

        protected override void OnUnload()
        {
            this.m_uiBehaviour.m_txtHead.SetTexturePath("");
            DlgHandlerBase.EnsureUnload<BattleShowInfoHandler>(ref this.m_BattleShowInfoHandler);
            DlgHandlerBase.EnsureUnload<BattleCaptainPVPHandler>(ref this.m_BattleCaptainPVPHandler);
            DlgHandlerBase.EnsureUnload<GuildMinePVPBattleHandler>(ref this.m_GuildMinePVPBattleHandler);
            DlgHandlerBase.EnsureUnload<GuildMinePVPInfoHandler>(ref this.m_GuildMinePVPInfoHandler);
            DlgHandlerBase.EnsureUnload<SkyArenaBattleHandler>(ref this.m_SkyArenaBattleHandler);
            DlgHandlerBase.EnsureUnload<SkyArenaInfoHandler>(ref this.m_SkyArenaInfoHandler);
            DlgHandlerBase.EnsureUnload<AbyssPartyBattleHandler>(ref this.m_AbyssPartyBattleHandler);
            DlgHandlerBase.EnsureUnload<BigMeleeBattleHandler>(ref this.m_BigMeleeBattleHandler);
            DlgHandlerBase.EnsureUnload<BattleFieldBattleHandler>(ref this.m_BattleFieldBattleHandler);
            DlgHandlerBase.EnsureUnload<XOptionsBattleHandler>(ref this.m_XOptionBattleHandler);
            DlgHandlerBase.EnsureUnload<RaceBattleHandler>(ref this.m_RaceBattleHandler);
            DlgHandlerBase.EnsureUnload<BattleWorldBossHandler>(ref this.uiBehaviour.m_WorldBossHandler);
            DlgHandlerBase.EnsureUnload<BattleSkillHandler>(ref this.uiBehaviour.m_SkillHandler);
            DlgHandlerBase.EnsureUnload<BattleIndicateHandler>(ref this.uiBehaviour.m_IndicateHandler);
            DlgHandlerBase.EnsureUnload<XTeamMonitorHandler>(ref this.uiBehaviour.m_TeamMonitor);
            DlgHandlerBase.EnsureUnload<XBattleEnemyInfoHandler>(ref this.uiBehaviour.m_EnemyInfoHandler);
            DlgHandlerBase.EnsureUnload<XBuffMonitorHandler>(ref this.uiBehaviour.m_PlayerBuffMonitorHandler);
            DlgHandlerBase.EnsureUnload<ProfressionTrialsHandler>(ref this.ProfTrialsHandler);
            DlgHandlerBase.EnsureUnload<BattleDpsHandler>(ref this.m_DpsHandler);
            DlgHandlerBase.EnsureUnload<XYuyinView>(ref this._yuyinHandler);
            DlgHandlerBase.EnsureUnload<HeroBattleSkillHandler>(ref this.m_HeroBattleSkillHandler);
            DlgHandlerBase.EnsureUnload<HeroBattleHandler>(ref this.m_HeroBattleHandler);
            DlgHandlerBase.EnsureUnload<MobaBattleHandler>(ref this.m_MobaBattleHandler);
            DlgHandlerBase.EnsureUnload<GuildMiniReportHandler>(ref this.m_miniReportHandler);
            DlgHandlerBase.EnsureUnload<GuildBattleMiniRankHandler>(ref this.m_miniRankHandler);
            DlgHandlerBase.EnsureUnload<BattleRiftHandler>(ref this.m_riftHandler);
            DlgHandlerBase.EnsureUnload<WeekendPartyHandler>(ref this.m_WeekendPartyHandler);
            DlgHandlerBase.EnsureUnload<BattleStatisticsHandler>(ref this.m_BattleStatisticsHandler);
            this._doc.BattleMainView = (BattleMain)null;
            if (this.apolloDoc != null)
                this.apolloDoc.QuitRoom();
            this.ClearBigNotice();
            base.OnUnload();
        }

        private void RefreshYuyin()
        {
            this.type = XFastEnumIntEqualityComparer<SceneType>.ToInt(XSingleton<XScene>.singleton.SceneType);
            if (this._yuyinHandler == null)
                return;
            this._yuyinHandler.Refresh(this.type);
        }

        public void RefreshYuyin(ulong uid)
        {
            if (this._yuyinHandler == null)
                return;
            this._yuyinHandler.Refresh(this.type);
        }

        private void SetEnemyRoleInfo(string name, uint level)
        {
        }

        private bool OnTailToBackClick(IXUIButton go)
        {
            XSingleton<XScene>.singleton.GameCamera.Tail.TailToBack();
            return true;
        }

        private bool OnPauseClick(IXUIButton go)
        {
            if (!this.IsLoaded())
                return true;
            SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
            if (sceneData != null && sceneData.CanPause)
                XSingleton<XShell>.singleton.Pause = true;
            if (this.m_XOptionBattleHandler == null && (Object)this.uiBehaviour != (Object)null)
                DlgHandlerBase.EnsureCreate<XOptionsBattleHandler>(ref this.m_XOptionBattleHandler, this.uiBehaviour.m_canvas, handlerMgr: ((IDlgHandlerMgr)this));
            if (this.m_XOptionBattleHandler != null && !this.m_XOptionBattleHandler.IsVisible())
                this.m_XOptionBattleHandler.ShowUI();
            this.sceneType = XSingleton<XScene>.singleton.SceneType;
            return true;
        }

        private void OnAvatarClick(IXUISprite go)
        {
            if (!this.IsLoaded())
                return;
            DlgBase<DemoUI, DemoUIBehaviour>.singleton.SetVisible(!DlgBase<DemoUI, DemoUIBehaviour>.singleton.IsVisible(), true);
        }

        public void SetTencentImage()
        {
            if (XSingleton<PDatabase>.singleton.playerInfo != null)
                XSingleton<XUICacheImage>.singleton.Load(XSingleton<PDatabase>.singleton.playerInfo.data.pictureLarge, this.m_uiBehaviour.m_txtHead, (MonoBehaviour)this.m_uiBehaviour);
            else
                XSingleton<XUICacheImage>.singleton.Load(string.Empty, this.m_uiBehaviour.m_txtHead, (MonoBehaviour)this.m_uiBehaviour);
            XSingleton<UiUtility>.singleton.ParseHeadIcon(XDocuments.GetSpecificDocument<XPrerogativeDocument>(XPrerogativeDocument.uuID).PlayerSetid, this.uiBehaviour.m_sprFrame);
        }

        private bool OnBussrushPauseClick(IXUIButton btn)
        {
            XSingleton<XScene>.singleton.ReqLeaveScene();
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            return true;
        }

        public void ShowBossrushQuit()
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(XStringDefineProxy.GetString("BOSSRUSH_QUIT"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"));
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnBussrushPauseClick));
        }

        private void UpdatePlayerInfo()
        {
            XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
            if (xplayerData == null)
                return;
            int attr1 = (int)xplayerData.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
            int num1 = (int)xplayerData.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
            int attr2 = (int)xplayerData.GetAttr(XAttributeDefine.XAttr_MaxMP_Total);
            int attr3 = (int)xplayerData.GetAttr(XAttributeDefine.XAttr_CurrentMP_Basic);
            if (num1 < 0)
                num1 = 0;
            float num2 = (float)num1 / (float)attr1;
            this.uiBehaviour.m_Hpbar.SetFillAmount(num2);
            this.uiBehaviour.m_Mpbar.SetFillAmount((float)attr3 / (float)attr2);
            if (this._currentHP != num1 || this._maxHP != attr1)
            {
                this.uiBehaviour.m_HpText.SetText(string.Format("{0}/{1}", (object)num1, (object)attr1));
                this._currentHP = num1;
                this._maxHP = attr1;
            }
            if (this._currentMP != attr3 || this._maxMP != attr2)
            {
                this.uiBehaviour.m_MpText.SetText(string.Format("{0}/{1}", (object)attr3, (object)attr2));
                this._currentMP = attr3;
                this._maxMP = attr2;
            }
            bool bLowHP;
            BattleMain.GetHPColor(num2, out Color _, out bLowHP);
            this.uiBehaviour.m_LowHP.SetActive(bLowHP);
        }

        public static void GetHPColor(float hpPercent, out Color color, out bool bLowHP)
        {
            if ((double)hpPercent > (double)BattleMain._fYellow)
            {
                color = (Color)BattleMain._hp_green;
                bLowHP = false;
            }
            else if ((double)hpPercent <= (double)BattleMain._fYellow && (double)hpPercent > (double)BattleMain._fRed)
            {
                color = (Color)BattleMain._hp_yellow;
                bLowHP = false;
            }
            else
            {
                color = (Color)BattleMain._hp_red;
                bLowHP = true;
            }
        }

        public void OnPlayerBuffChange() => this.uiBehaviour.m_PlayerBuffMonitorHandler.OnBuffChanged(XSingleton<XEntityMgr>.singleton.Player.Buffs.GetUIBuffList());

        public override void OnUpdate()
        {
            this.uiBehaviour.m_SkillHandler.OnUpdate();
            if (!XSingleton<XTimerMgr>.singleton.NeedFixedUpdate)
                return;
            base.OnUpdate();
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
            this.UpdatePlayerInfo();
            this.UpdateWifi();
            if ((double)Time.unscaledTime - (double)this.lastPingTime > 60.0 || (double)this.lastPingTime < 0.0)
            {
                this.RefreshPing();
                this.lastPingTime = Time.unscaledTime;
            }
            this.uiBehaviour.m_IndicateHandler.OnUpdate();
            if ((double)Time.time - (double)this._last_check_time > 5.0)
            {
                this._last_check_time = Time.time;
                this._doc.SendCheckTime();
            }
            this.UpdateTime();
            this.UpdateLeftTime();
            if ((double)this.NoticeTime > 0.0 && (double)Time.time - (double)this.NoticeTime > (double)this._notice_duration)
            {
                this.uiBehaviour.m_NoticeFrame.transform.localPosition = XGameUI.Far_Far_Away;
                this.NoticeTime = 0.0f;
            }
            if (this.uiBehaviour.m_WorldBossHandler.active)
                this.uiBehaviour.m_WorldBossHandler.OnUpdate();
            IXGameSirControl gameSirControl = XSingleton<XUpdater.XUpdater>.singleton.GameSirControl;
            if (gameSirControl != null && gameSirControl.IsConnected() && gameSirControl.GetButton(XGameSirKeyCode.BTN_THUMBR))
            {
                XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
                int num1 = specificDocument.GetValue(XOptionsDefine.OD_VIEW) + 1;
                int num2 = XFastEnumIntEqualityComparer<XOperationMode>.ToInt(XOperationMode.X3D_Free);
                if (num1 > num2)
                    num1 = XFastEnumIntEqualityComparer<XOperationMode>.ToInt(XOperationMode.X25D);
                specificDocument.SetValue(XOptionsDefine.OD_VIEW, num1);
                specificDocument.SetBattleOptionValue();
                this.SetView((XOperationMode)num1);
            }
            this.TeamMonitor.OnUpdate();
            this.EnemyInfoHandler.OnUpdate();
            this.uiBehaviour.m_PlayerBuffMonitorHandler.OnUpdate();
            if (this._combo_buff_to_add > this._combo_buff_added && XSingleton<XEntityMgr>.singleton.Player.Buffs.GetBuffByID(this._combo_buff_list[this._combo_buff_to_add].buffID) != null)
            {
                this._combo_buff_added = this._combo_buff_to_add;
                this._combo_buff_to_add = -1;
            }
            if (this._combo_buff_added >= 0)
            {
                ComboBuff comboBuff = this._combo_buff_list[this._combo_buff_added];
                XBuff buffById = XSingleton<XEntityMgr>.singleton.Player.Buffs.GetBuffByID(comboBuff.buffID);
                if (buffById != null)
                {
                    float leftTime = buffById.GetLeftTime();
                    Color comboQuality = this.GetComboQuality(this._combo_buff_added + 1);
                    this.uiBehaviour.m_ComboBuffName.SetText(comboBuff.buffName);
                    this.uiBehaviour.m_ComboBuffName.SetColor(comboQuality);
                    this.uiBehaviour.m_ComboBuffTime.gameObject.SetActive(true);
                    if ((double)leftTime != -1.0)
                        this.uiBehaviour.m_ComboBuffTime.value = leftTime / buffById.Duration;
                    else
                        this.uiBehaviour.m_ComboBuffTime.value = 1f;
                }
                else
                {
                    this._combo_buff_added = -1;
                    this.uiBehaviour.m_ComboBuffTime.gameObject.SetActive(false);
                }
            }
            else
                this.uiBehaviour.m_ComboBuffTime.gameObject.SetActive(false);
            if (!this.uiBehaviour.m_StrengthPresevedBar.IsVisible())
                return;
            this.RefreshStrengthPresevedBar();
        }

        protected Color GetComboQuality(int quality)
        {
            switch (quality)
            {
                case 1:
                    return (Color)new Color32((byte)0, byte.MaxValue, (byte)18, byte.MaxValue);
                case 2:
                    return (Color)new Color32((byte)0, (byte)228, byte.MaxValue, byte.MaxValue);
                case 3:
                    return (Color)new Color32(byte.MaxValue, (byte)180, (byte)0, byte.MaxValue);
                case 4:
                    return (Color)new Color32((byte)252, (byte)0, byte.MaxValue, byte.MaxValue);
                default:
                    return (Color)new Color32((byte)252, (byte)0, byte.MaxValue, byte.MaxValue);
            }
        }

        private void UpdateWifi() => XSingleton<UiUtility>.singleton.UpdateWifi((IXUIButton)null, this.m_uiBehaviour.m_sprwifi);

        private void RefreshPing() => XSingleton<UiUtility>.singleton.RefreshPing(this.uiBehaviour.m_lblTime, this.uiBehaviour.m_sliderBattery, this.uiBehaviour.m_lblfree);

        public void RefreshBossRush()
        {
            if (!(XSingleton<XGame>.singleton.Doc.GetXComponent(XBossBushDocument.uuID) is XBossBushDocument xcomponent) || XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_BOSSRUSH)
                return;
            this.m_uiBehaviour.m_sprBuff1.SetSprite(xcomponent.bossBuff1Row.icon);
            this.m_uiBehaviour.m_sprBuff2.SetSprite(xcomponent.bossBuff2Row.icon);
            this.m_uiBehaviour.m_lblBuff1.SetText(xcomponent.bossBuff1Row.Comment);
            this.m_uiBehaviour.m_lblBuff2.SetText(xcomponent.bossBuff2Row.Comment);
            int quality1 = xcomponent.bossBuff1Row.Quality;
            int quality2 = xcomponent.bossBuff2Row.Quality;
            string text1 = XSingleton<XGlobalConfig>.singleton.GetValue("Quality" + (object)quality1 + "Color");
            string text2 = XSingleton<XGlobalConfig>.singleton.GetValue("Quality" + (object)quality2 + "Color");
            this.m_uiBehaviour.m_sprBuff1.SetColor(XSingleton<UiUtility>.singleton.ParseColor(text1, 0));
            this.m_uiBehaviour.m_sprBuff2.SetColor(XSingleton<UiUtility>.singleton.ParseColor(text2, 0));
            this.m_uiBehaviour.m_lblBuff1.SetColor(XSingleton<UiUtility>.singleton.ParseColor(text1, 0));
            this.m_uiBehaviour.m_lblBuff2.SetColor(XSingleton<UiUtility>.singleton.ParseColor(text2, 0));
            this.uiBehaviour.m_lblTitle.SetText(XStringDefineProxy.GetString("BOSSRUSH_FIGHT", (object)xcomponent.respData.currank) + "  " + DlgBase<BossRushDlg, BossRushBehavior>.singleton.bossName);
            this.uiBehaviour.m_rwdpool.ReturnAll();
            for (int index = 0; index < xcomponent.bossRushRow.reward.Count; ++index)
            {
                uint num1 = xcomponent.bossRushRow.reward[index, 0];
                uint num2 = xcomponent.bossRushRow.reward[index, 1];
                GameObject go = this.uiBehaviour.m_rwdpool.FetchGameObject();
                XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(go, (int)num1, (int)((double)num2 * (double)xcomponent.rwdRate));
                go.transform.localPosition = index >= 2 ? new Vector3((float)(10 + 100 * (index - 2)), -100f, 0.0f) : new Vector3((float)(10 + 100 * index), 0.0f, 0.0f);
            }
            this.uiBehaviour.m_sprBossbg.spriteHeight = xcomponent.bossRushRow.reward.Count > 2 ? 207 : 137;
        }

        public void UpdateKill(int cnt)
        {
            if (!this.IsVisible())
                return;
            XStringDefineProxy.GetString("SMALLMONSTER_KILL");
            this.uiBehaviour.m_lblKill.SetText(string.Format(XStringDefineProxy.GetString("SMALLMONSTER_KILL"), (object)cnt));
        }

        public void OnComboChange(uint combo)
        {
            if (combo > 0U)
            {
                this.m_uiBehaviour.m_ComboFrame.transform.localPosition = Vector3.zero;
                this.m_uiBehaviour.m_ComboText.SetText(combo.ToString());
                this.m_uiBehaviour.m_ComboBgTween.PlayTween(true);
                if (XSingleton<XScene>.singleton.SceneData.HasComboBuff)
                {
                    int index1 = -1;
                    if ((long)combo < (long)this._combo_buff_list[0].combo)
                        index1 = -1;
                    else if ((long)combo > (long)this._combo_buff_list[this._combo_buff_list.Count - 1].combo)
                    {
                        index1 = -1;
                    }
                    else
                    {
                        for (int index2 = 0; index2 < this._combo_buff_list.Count - 1; ++index2)
                        {
                            if ((long)combo == (long)this._combo_buff_list[index2].combo)
                            {
                                index1 = index2;
                                break;
                            }
                        }
                    }
                    if (index1 >= 0 && index1 <= this._combo_buff_list.Count - 1)
                    {
                        XBuffAddEventArgs xbuffAddEventArgs = XEventPool<XBuffAddEventArgs>.GetEvent();
                        xbuffAddEventArgs.xBuffDesc.BuffID = this._combo_buff_list[index1].buffID;
                        xbuffAddEventArgs.xBuffDesc.BuffLevel = this._combo_buff_list[index1].buffLevel;
                        xbuffAddEventArgs.Firer = (XObject)XSingleton<XEntityMgr>.singleton.Player;
                        xbuffAddEventArgs.xBuffDesc.CasterID = XSingleton<XEntityMgr>.singleton.Player.ID;
                        XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xbuffAddEventArgs);
                        this._combo_buff_to_add = index1;
                    }
                    else
                        this.uiBehaviour.m_ComboBuffTime.gameObject.SetActive(false);
                }
                else
                    this.uiBehaviour.m_ComboBuffTime.gameObject.SetActive(false);
            }
            else
                this.m_uiBehaviour.m_ComboFrame.transform.localPosition = Vector3.one * (float)XGameUI._far_far_away;
        }

        public void ShowNotice(string text, float duration, float pertime = 1f)
        {
            this._notice_collection.Clear();
            foreach (string str in text.Split(XGlobalConfig.ListSeparator))
                this._notice_collection.Add(str);
            this._notice_duration = duration;
            this._notice_pertime = pertime;
            if (this.time_token > 0U)
            {
                XSingleton<XTimerMgr>.singleton.KillTimer(this.time_token);
                this.time_token = 0U;
            }
            if (this._notice_collection.Count <= 0)
                return;
            this.ShowSingleNotice((object)0);
        }

        protected void ShowSingleNotice(object o)
        {
            int index = (int)o;
            if (index >= this._notice_collection.Count)
                return;
            this.uiBehaviour.m_Notice.SetText(this._notice_collection[index]);
            this.uiBehaviour.m_NoticeFrame.transform.localPosition = this.uiBehaviour.m_NoticePos;
            this.NoticeTime = Time.time;
            this.time_token = XSingleton<XTimerMgr>.singleton.SetTimer(this._notice_pertime, this._showSingleNoticeCb, (object)(index + 1));
            if (index == this._notice_collection.Count - 1)
                this._notice_collection.Clear();
        }

        public void StopNotice()
        {
            if (this.time_token > 0U)
            {
                XSingleton<XTimerMgr>.singleton.KillTimer(this.time_token);
                this.time_token = 0U;
            }
            this.uiBehaviour.m_NoticeFrame.transform.localPosition = XGameUI.Far_Far_Away;
        }

        public void ShowSkillRemainingCD(string skillName, float time) => this.ShowBigNotice(XStringDefineProxy.GetString("SkillRemainingCD", (object)skillName, (object)time.ToString()), false);

        public void ShowBigNotice(string text, bool bCmd)
        {
            if (!this.IsVisible())
                return;
            XSingleton<XTimerMgr>.singleton.KillTimer(this._big_notice_timer_token);
            if ((Object)this._big_notice == (Object)null)
            {
                this._big_notice = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/TutorialButtomText") as GameObject;
                this._big_notice.transform.parent = this.uiBehaviour.transform;
                this._big_notice.transform.localPosition = Vector3.zero;
                this._big_notice.transform.localScale = Vector3.one;
            }
          (this._big_notice.transform.FindChild("TutorialText").GetComponent("XUILabel") as IXUILabel).SetText(text);
            (this._big_notice.GetComponent("XUIPlayTween") as IXUITweenTool).PlayTween(true);
            if (bCmd)
                this._big_notice_timer_token = XSingleton<XTimerMgr>.singleton.SetTimer(5f, this._endBigNoticeCmdCb, (object)null);
            else
                this._big_notice_timer_token = XSingleton<XTimerMgr>.singleton.SetTimer(3f, this._endBigNoticeCb, (object)null);
        }

        protected void EndBigNotice(object o)
        {
            if ((Object)this._big_notice != (Object)null)
                XResourceLoaderMgr.SafeDestroy(ref this._big_notice);
            this._big_notice_timer_token = 0U;
        }

        protected void EndBigNoticeCmd(object o)
        {
            if ((Object)this._big_notice != (Object)null)
            {
                XResourceLoaderMgr.SafeDestroy(ref this._big_notice);
                XSingleton<XLevelScriptMgr>.singleton.ExecuteNextCmd();
            }
            this._big_notice_timer_token = 0U;
        }

        protected void ClearBigNotice()
        {
            if ((Object)this._big_notice != (Object)null)
                XResourceLoaderMgr.SafeDestroy(ref this._big_notice);
            XSingleton<XTimerMgr>.singleton.KillTimer(this._big_notice_timer_token);
            this._big_notice_timer_token = 0U;
        }

        public void ShowAutoReviveFrame(int time, uint cost, uint costType)
        {
            if (this.uiBehaviour.m_WorldBossHandler == null || !this.uiBehaviour.m_WorldBossHandler.active)
                return;
            this.uiBehaviour.m_WorldBossHandler.SetAutoRevive(time, cost, costType);
        }

        public void OnPlayerRevive()
        {
            if (this.uiBehaviour.m_WorldBossHandler != null && this.uiBehaviour.m_WorldBossHandler.active)
                this.uiBehaviour.m_WorldBossHandler.HideAutoRevive();
            this.uiBehaviour.m_LowHP.SetActive(false);
        }

        public float GetLeftTime() => this.leftTimeCounter.GetFloatLeftTime();

        public void HideLeftTime()
        {
            this.timeConnter.SetLeftTime(0.0f);
            this.leftTimeCounter.SetLeftTime(0.0f);
            this.uiBehaviour.m_LeftTime.SetVisible(false);
            this.uiBehaviour.m_WarTime.SetVisible(false);
        }

        public void SetLeftTime(uint seconds, int noticeTime = -1)
        {
            this.uiBehaviour.m_LeftTime.SetVisible(true);
            this.leftTimeCounter.SetLeftTime((float)seconds, noticeTime);
            this.uiBehaviour.m_WarTime.SetVisible(false);
        }

        public void SetTimeRecord()
        {
            this.uiBehaviour.m_WarTime.SetVisible(true);
            this.timeConnter.SetForward(1);
            this.timeConnter.SetLeftTime(0.01f);
            this.uiBehaviour.m_LeftTime.SetVisible(false);
        }

        public void ResetLeftTime(int seconds)
        {
            SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
            if (sceneData.TimeCounter == null || sceneData.TimeCounter.Length < 1)
                this.timeConnter.SetLeftTime((float)seconds);
            else if (sceneData.TimeCounter[0] == (short)1)
                this.leftTimeCounter.SetLeftTime((float)((int)sceneData.TimeCounter[1] - seconds));
        }

        private void UpdateLeftTime()
        {
            if (!XSingleton<XScene>.singleton.SceneStarted)
                return;
            this.leftTimeCounter.Update();
        }

        private void UpdateTime()
        {
            if (!XSingleton<XScene>.singleton.SceneStarted)
                return;
            this.timeConnter.Update();
        }

        public void OnSwitchToTeamChat(object obj) => DlgBase<XChatView, XChatBehaviour>.singleton.SelectChatTeam();

        public void OnVoiceButtonDrag(IXUIButton sp, Vector2 delta)
        {
            this.m_DragDistance += delta;
            if ((double)this.m_DragDistance.magnitude >= 100.0)
                this.m_CancelRecord = true;
            else
                this.m_CancelRecord = false;
        }

        public void OnVoiceButton(IXUIButton sp, bool state)
        {
            if (state)
            {
                XSingleton<XDebug>.singleton.AddLog("Press down");
                this.m_DragDistance = Vector2.zero;
                this.m_IsRecording = true;
                if (XChatDocument.UseApollo)
                    XSingleton<XChatApolloMgr>.singleton.StartRecord();
                else
                    XSingleton<XChatIFlyMgr>.singleton.StartRecord();
            }
            else
            {
                XSingleton<XDebug>.singleton.AddLog("Press up");
                this.m_IsRecording = false;
                DlgBase<XChatView, XChatBehaviour>.singleton.SetActiveChannel(ChatChannelType.Team);
                if (XChatDocument.UseApollo)
                    XSingleton<XChatApolloMgr>.singleton.StopRecord(this.m_CancelRecord);
                else
                    XSingleton<XChatIFlyMgr>.singleton.StopRecord(this.m_CancelRecord);
            }
        }

        public void OnStopVoiceRecord()
        {
            if (!this.m_IsRecording)
                return;
            DlgBase<XChatView, XChatBehaviour>.singleton.SetActiveChannel(ChatChannelType.Team);
            if (XChatDocument.UseApollo)
                XSingleton<XChatApolloMgr>.singleton.StopRecord(this.m_CancelRecord);
            else
                XSingleton<XChatIFlyMgr>.singleton.StopRecord(this.m_CancelRecord);
            this.m_IsRecording = false;
        }

        public bool OnCommandBtnClick(IXUIButton btn) => true;

        public bool OnAutoPlay(IXUIButton sp) => !this.IsLoaded() || this.SetAutoPlay(sp.ID == 1UL);

        private bool OnHorseRideClicked(IXUIButton btn)
        {
            if (!this.IsLoaded())
                return true;
            XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID).ReqRecentMount();
            return true;
        }

        private bool SetAutoPlay(bool isAuto)
        {
            XPlayerAttributes attributes = XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes;
            attributes.AutoPlayOn = isAuto;
            if (XSingleton<XEntityMgr>.singleton.Player.AI != null && !XSingleton<XScene>.singleton.bSpectator)
            {
                XAIEnableAI xaiEnableAi = XEventPool<XAIEnableAI>.GetEvent();
                xaiEnableAi.Firer = (XObject)XSingleton<XEntityMgr>.singleton.Player;
                xaiEnableAi.Enable = isAuto;
                xaiEnableAi.Puppet = false;
                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xaiEnableAi);
            }
            if (attributes.AutoPlayOn)
            {
                this.uiBehaviour.m_AutoPlayBorad.SetVisible(false);
                this.uiBehaviour.m_AutoPlayCancelBoard.SetVisible(true);
                int num = (int)XSingleton<UiUtility>.singleton.ShowSystemNoticeTip(XStringDefineProxy.GetString("AutoPlayNotice"));
            }
            else
            {
                this.uiBehaviour.m_AutoPlayBorad.SetVisible(true);
                this.uiBehaviour.m_AutoPlayCancelBoard.SetVisible(false);
            }
            return true;
        }

        private void OnAutoPlayTip(IXUISprite go)
        {
            if (!this.IsLoaded())
                return;
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_ARENA)
            {
                int num1 = (int)XSingleton<UiUtility>.singleton.ShowSystemNoticeTip(XStringDefineProxy.GetString("ArenaAutoFight"));
            }
            else
            {
                int num2 = (int)XSingleton<UiUtility>.singleton.ShowSystemNoticeTip(string.Format(XStringDefineProxy.GetString("AutoFightOpenLevel"), (object)XSingleton<XGlobalConfig>.singleton.GetValue("AutoPlayUnlockLevel")));
            }
        }

        private bool OnBattleStatisticsClick(IXUIButton btn)
        {
            if ((Object)this.uiBehaviour == (Object)null)
                return true;
            DlgHandlerBase.EnsureCreate<BattleStatisticsHandler>(ref this.m_BattleStatisticsHandler, this.uiBehaviour.m_canvas.transform, this.m_BattleStatisticsHandler == null || !this.m_BattleStatisticsHandler.IsVisible(), (IDlgHandlerMgr)this);
            return true;
        }

        public void ShowBattleVoice(ChatVoiceInfo info)
        {
            if (!this.IsVisible())
                return;
            this.m_ChatLabelCd = XSingleton<XTimerMgr>.singleton.SetTimer((float)info.voiceTime + 2f, this._hideBattleChatUICb, (object)info);
        }

        public void HideBattleChatUI(object info) => this.m_ChatLabelCd = 0U;

        public void ShowCountDownFrame(bool status)
        {
            if (!this.IsVisible())
                return;
            this.uiBehaviour.m_CountDownFrame.gameObject.SetActive(true);
            this.uiBehaviour.m_CountDownTimeFrame.gameObject.SetActive(status);
            this.uiBehaviour.m_CountDownBeginFrame.gameObject.SetActive(!status);
            (this.uiBehaviour.m_CountDownTimeFrame.gameObject.GetComponent("XUIPlayTween") as IXUITweenTool).PlayTween(status);
            (this.uiBehaviour.m_CountDownBeginFrame.gameObject.GetComponent("XUIPlayTween") as IXUITweenTool).PlayTween(!status);
        }

        public void SetAutoPlayUI(bool isInAutoPlay)
        {
            if (!this._can_auto_play)
                return;
            this.SetAutoPlay(isInAutoPlay);
        }

        public void OnPlaySuperarmorFx(XEntity enemy, bool bBroken)
        {
            for (int index = 0; index < this.EnemyInfoHandler.EnemyList.Count; ++index)
            {
                if (this.EnemyInfoHandler.EnemyList[index].Entity == enemy)
                {
                    this.EnemyInfoHandler.EnemyList[index].SetSuperArmorState(bBroken);
                    break;
                }
            }
        }

        public void OnStopSuperarmorFx(XEntity enemy)
        {
            for (int index = 0; index < this.EnemyInfoHandler.EnemyList.Count; ++index)
            {
                if (this.EnemyInfoHandler.EnemyList[index].Entity == enemy)
                {
                    this.EnemyInfoHandler.EnemyList[index].StopSuperArmorFx();
                    break;
                }
            }
        }

        public void OnProjectDamage(ProjectDamageResult damage, XEntity entity)
        {
            for (int index = 0; index < this.EnemyInfoHandler.EnemyList.Count; ++index)
            {
                if (this.EnemyInfoHandler.EnemyList[index].Entity == entity)
                {
                    if ((long)damage.Caster != (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID)
                        break;
                    this.EnemyInfoHandler.EnemyList[index].OnBeHit(damage);
                    break;
                }
            }
        }

        public void SetupSpeedFx(XEntity enemy, bool enable, Color c)
        {
            for (int index = 0; index < this.EnemyInfoHandler.EnemyList.Count; ++index)
            {
                if (this.EnemyInfoHandler.EnemyList[index].Entity == enemy)
                {
                    IXUISprite superArmorSpeedFx = this.EnemyInfoHandler.EnemyList[index].m_uiSuperArmorSpeedFx;
                    superArmorSpeedFx.gameObject.SetActive(enable);
                    superArmorSpeedFx.SetColor(c);
                    break;
                }
            }
        }

        public void ShowStrengthPresevedBar(XEntity entity)
        {
            this.uiBehaviour.m_StrengthPresevedBar.SetVisible(true);
            this._strength_preseved_entity = entity;
            this._total_strength_preseved = (float)this._strength_preseved_entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentXULI_Basic);
            this._current_strength_preseved = this._total_strength_preseved;
            this.RefreshStrengthPresevedBar();
        }

        public void HideStrengthPresevedBar()
        {
            this.uiBehaviour.m_StrengthPresevedBar.SetVisible(false);
            this._strength_preseved_entity = (XEntity)null;
            this._total_strength_preseved = 1f;
            this._current_strength_preseved = 0.0f;
        }

        public void RefreshStrengthPresevedBar()
        {
            if (this._strength_preseved_entity != null && this._strength_preseved_entity.Attributes != null)
                this._current_strength_preseved = (float)this._strength_preseved_entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentXULI_Basic);
            if (!((Object)this.uiBehaviour != (Object)null) || this.uiBehaviour.m_StrengthPresevedBar == null)
                return;
            this.uiBehaviour.m_StrengthPresevedBar.value = this._strength_preseved_precent;
        }

        public void SetTargetTabVisable(bool status)
        {
        }

        public void OnTargetTabClick(IXUISprite sp)
        {
        }

        public bool OnSightSelectClick(IXUIButton sp)
        {
            if (!this.IsLoaded())
                return true;
            this.SetView((XOperationMode)sp.ID);
            return true;
        }

        public bool OnSightClick(IXUIButton sp)
        {
            if (!this.IsLoaded())
                return true;
            if ((Object)this.uiBehaviour == (Object)null || (Object)this.uiBehaviour.m_SightSelect == (Object)null)
                return false;
            if (this.uiBehaviour.m_SightSelect.gameObject.activeSelf)
                this.uiBehaviour.m_SightSelect.gameObject.SetActive(false);
            else
                this.uiBehaviour.m_SightSelect.gameObject.SetActive(true);
            return true;
        }

        public void OnSpectateMessageChange(int watchNum, int commendNum)
        {
            XSpectateSceneDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
            if (this.SpectateInfoIsShow)
            {
                this.uiBehaviour.m_WatchNum.SetText(watchNum.ToString());
                this.uiBehaviour.m_CommendNum.SetText(commendNum.ToString());
            }
            else if (watchNum >= specificDocument.WatchTarget || commendNum >= specificDocument.CommendTarget)
            {
                XSingleton<XDebug>.singleton.AddLog("watchNum and commendNum are enough now.");
                this.SpectateInfoIsShow = true;
                this.uiBehaviour.m_SpectateInfo.transform.localPosition = Vector3.zero;
                this.uiBehaviour.m_WatchNum.SetText(watchNum.ToString());
                this.uiBehaviour.m_CommendNum.SetText(commendNum.ToString());
            }
        }

        public void ShowGuildMineBuff(ResWarBuffRes data)
        {
            if (data == null || !this.IsLoaded() || XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_RESWAR_PVE)
                return;
            GuildMineralBufflist.RowData mineBuffData = XGuildMineMainDocument.GetMineBuffData(data.buffid);
            if (mineBuffData == null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("buffid:" + (object)data.buffid);
            }
            else
            {
                uint num = mineBuffData.Quality - 1U;
                this.uiBehaviour.m_GuildMineBuff.gameObject.SetActive(true);
                this.uiBehaviour.m_GuildMineBuff.SetSprite(mineBuffData.icon);
                this.uiBehaviour.m_GuildMineBuffText.SetText(mineBuffData.ratestring);
                if ((long)num >= (long)DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.BossColor.Length)
                {
                    XSingleton<XDebug>.singleton.AddErrorLog("bossMineBuffIndex:" + (object)num + "\nBossColor:" + (object)DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.BossColor.Length);
                    num = 0U;
                }
                if ((long)num < (long)DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.BossColor.Length)
                {
                    this.uiBehaviour.m_GuildMineBuff.SetColor(XSingleton<UiUtility>.singleton.ParseColor(DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.BossColor[(int)num], 0));
                    this.uiBehaviour.m_GuildMineBuffText.SetColor(XSingleton<UiUtility>.singleton.ParseColor(DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.BossColor[(int)num], 0));
                }
            }
        }

        public void SetLoadingPrompt(List<string> otherPalyerName, bool canAutoClose = false)
        {
            if (!this.IsLoaded() || XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.World || !XSingleton<XGame>.singleton.SyncMode)
                return;
            if (otherPalyerName == null || otherPalyerName.Count == 0)
            {
                this.m_uiBehaviour.m_PromptLabel.SetText(XStringDefineProxy.GetString("WAIT_FOR_OTHERS"));
                if (!canAutoClose || !this.m_uiBehaviour.m_PromptFrame.gameObject.activeSelf)
                    return;
                this.m_uiBehaviour.m_PromptFrame.gameObject.SetActive(false);
            }
            else
                this.m_uiBehaviour.m_PromptLabel.SetText(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("WAIT_OTHER_PLAYER_PVP")), (object)otherPalyerName.Count, (object)otherPalyerName[0]));
        }
    }
}
