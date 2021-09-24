using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class BattleMainBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_canvas = base.transform.FindChild("_canvas");
			this.m_RoleInfo = base.transform.FindChild("_canvas/Bg/Bg");
			this.m_PingFrame = base.transform.FindChild("_canvas/Bg/PING");
			this.m_leftTimes = (base.transform.FindChild("_canvas/LeftTimes").GetComponent("XUILabel") as IXUILabel);
			this.m_leftTimes.SetVisible(false);
			this.m_winConditionTips = (base.transform.FindChild("_canvas/BattleWinTips").GetComponent("XUILabel") as IXUILabel);
			this.m_winConditionTips.SetVisible(false);
			this.m_BattleExplainTips = (base.transform.FindChild("_canvas/BattleExplainTips").GetComponent("XUILabel") as IXUILabel);
			Transform transform = this.m_RoleInfo.FindChild("HpBar");
			this.m_Hpbar = (transform.FindChild("BackDrop").GetComponent("XUISprite") as IXUISprite);
			this.m_HpBackdrop = this.m_Hpbar;
			Transform transform2 = this.m_RoleInfo.FindChild("MpBar");
			this.m_Mpbar = (transform2.FindChild("BackDrop").GetComponent("XUISprite") as IXUISprite);
			this.m_HpText = (this.m_RoleInfo.FindChild("HpText").GetComponent("XUILabel") as IXUILabel);
			this.m_MpText = (this.m_RoleInfo.FindChild("MpText").GetComponent("XUILabel") as IXUILabel);
			this.m_sliderBattery = (this.m_PingFrame.FindChild("Battery").GetComponent("XUISlider") as IXUISlider);
			this.m_lblTime = (this.m_PingFrame.FindChild("TIME").GetComponent("XUILabel") as IXUILabel);
			this.m_lblfree = (this.m_PingFrame.FindChild("T2").GetComponent("XUILabel") as IXUILabel);
			Transform transform3 = this.m_RoleInfo.FindChild("Avatar");
			this.m_avatar = (transform3.GetComponent("XUISprite") as IXUISprite);
			this.m_sprFrame = (transform3.FindChild("AvatarFrame").GetComponent("XUISprite") as IXUISprite);
			this.m_txtHead = (this.m_RoleInfo.Find("HeadPanel/Head").GetComponent("XUITexture") as IXUITexture);
			this.m_Level = (this.m_RoleInfo.FindChild("CoverPanel/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_Name = (this.m_RoleInfo.FindChild("PlayerName").GetComponent("XUILabel") as IXUILabel);
			this.m_TeamLeader = this.m_RoleInfo.FindChild("CoverPanel/TeamLeader").gameObject;
			Transform transform4 = base.transform.FindChild("_canvas/Pause");
			this.m_pause = (transform4.GetComponent("XUIButton") as IXUIButton);
			this.m_pauseGroup = (transform4.GetComponent("PositionGroup") as IXPositionGroup);
			this.m_sprwifi = (this.m_PingFrame.FindChild("SysWifi").GetComponent("XUISprite") as IXUISprite);
			DlgHandlerBase.EnsureCreate<BattleIndicateHandler>(ref this.m_IndicateHandler, base.transform.Find("_canvas/Indicate").gameObject, null, false);
			this.m_lblKill = (base.transform.FindChild("_canvas/KillFrame/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_ComboFrame = base.transform.FindChild("_canvas/ComboFrame/Frame").gameObject;
			Transform transform5 = base.transform.FindChild("_canvas/ComboFrame/Frame/Combo/ComboText");
			this.m_ComboText = (transform5.GetComponent("XUILabel") as IXUILabel);
			this.m_ComboTextTween = (transform5.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_ComboBgTween = (base.transform.FindChild("_canvas/ComboFrame/Frame/Combo").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_ComboFrame.transform.localPosition = Vector3.one * (float)XGameUI._far_far_away;
			this.m_ComboBuffTime = (base.transform.FindChild("_canvas/ComboFrame/BuffArmor").GetComponent("XUIProgress") as IXUIProgress);
			this.m_ComboBuffName = (base.transform.FindChild("_canvas/ComboFrame/BuffArmor/Buff").GetComponent("XUILabel") as IXUILabel);
			this.m_ComboBuffTime.gameObject.SetActive(false);
			this.m_PromptFrame = base.transform.FindChild("_canvas/PromptFrame");
			this.m_PromptLabel = (base.transform.FindChild("_canvas/PromptFrame/Notice").GetComponent("XUILabel") as IXUILabel);
			this.m_PromptFrame.gameObject.SetActive(false);
			this.m_NoticeFrame = base.transform.FindChild("_canvas/NoticeFrame").gameObject;
			transform5 = base.transform.FindChild("_canvas/NoticeFrame/Notice");
			this.m_NoticePos = this.m_NoticeFrame.transform.localPosition;
			this.m_Notice = (transform5.GetComponent("XUILabel") as IXUILabel);
			this.m_NoticeFrame.transform.localPosition = XGameUI.Far_Far_Away;
			this.m_LowHP = base.transform.FindChild("_canvas/LowHPNotice").gameObject;
			this.m_LowHP.SetActive(false);
			this.m_LeftTime = (base.transform.FindChild("_canvas/LeftTime").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftTime.SetVisible(false);
			this.m_WarTime = (base.transform.Find("_canvas/WarTime").GetComponent("XUILabel") as IXUILabel);
			this.m_WarTime.SetVisible(false);
			this.m_SceneName = (base.transform.Find("_canvas/Indicate/Bg/Name").GetComponent("XUILabel") as IXUILabel);
			DlgHandlerBase.EnsureCreate<BattleWorldBossHandler>(ref this.m_WorldBossHandler, base.transform.FindChild("_canvas/WorldBossFrame").gameObject, null, false);
			DlgHandlerBase.EnsureCreate<BattleSkillHandler>(ref this.m_SkillHandler, base.transform.FindChild("_canvas/SkillFrame").gameObject, null, false);
			DlgHandlerBase.EnsureCreate<XTeamMonitorHandler>(ref this.m_TeamMonitor, base.transform.FindChild("_canvas/TeamFrame").gameObject, null, false);
			DlgHandlerBase.EnsureCreate<XBattleEnemyInfoHandler>(ref this.m_EnemyInfoHandler, base.transform.FindChild("_canvas/EnemyInfoFrame").gameObject, null, true);
			DlgHandlerBase.EnsureCreate<BattleTargetHandler>(ref this.m_BattleTargetHandler, base.transform.FindChild("_canvas/BattleTaget").gameObject, null, true);
			DlgHandlerBase.EnsureCreate<XBattleTeamTowerHandler>(ref this.m_TeamTowerHandler, base.transform.FindChild("_canvas/TeamTower").gameObject, null, false);
			DlgHandlerBase.EnsureCreate<XBuffMonitorHandler>(ref this.m_PlayerBuffMonitorHandler, this.m_RoleInfo.FindChild("BuffFrame").gameObject, null, true);
			this.m_PlayerBuffMonitorHandler.InitMonitor(XSingleton<XGlobalConfig>.singleton.BuffMaxDisplayCountPlayer, true, true);
			this.m_AutoPlay = (base.transform.FindChild("_canvas/Menu/AutoPlayContent/AutoPlayBoard/AutoPlay").GetComponent("XUIButton") as IXUIButton);
			this.m_AutoPlay.ID = 1UL;
			this.m_AutoPlayBorad = (base.transform.FindChild("_canvas/Menu/AutoPlayContent/AutoPlayBoard").GetComponent("XUISprite") as IXUISprite);
			this.m_AutoPlayCancelBoard = (base.transform.FindChild("_canvas/Menu/AutoPlayContent/AutoPlayCancel").GetComponent("XUISprite") as IXUISprite);
			this.m_AutoPlayTip = (base.transform.FindChild("_canvas/Menu/AutoPlayContent/AutoPlayBoard/Content/Lock").GetComponent("XUISprite") as IXUISprite);
			this.m_CancelAuto = (base.transform.FindChild("_canvas/Menu/AutoPlayContent/AutoPlayCancel/AutoPlay").GetComponent("XUIButton") as IXUIButton);
			this.m_CancelAuto.ID = 0UL;
			this.m_AutoPlayLock = (base.transform.FindChild("_canvas/Menu/AutoPlayContent/AutoPlayBoard/Content").GetComponent("XUILabel") as IXUILabel);
			this.m_CountDownFrame = base.transform.FindChild("_canvas/CountDownFrame");
			this.m_CountDownBeginFrame = this.m_CountDownFrame.FindChild("Begin");
			this.m_CountDownTimeFrame = this.m_CountDownFrame.FindChild("Time");
			this.m_CountDownFrame.gameObject.SetActive(false);
			this.m_StrengthPresevedBar = (base.transform.Find("_canvas/ChargeBar").GetComponent("XUIProgress") as IXUIProgress);
			this.m_3D25D = base.transform.FindChild("_canvas/3D25D");
			this.m_SightSelect = base.transform.FindChild("_canvas/3D25D/Select");
			this.m_25D = (base.transform.FindChild("_canvas/3D25D/Select/25D").GetComponent("XUIButton") as IXUIButton);
			this.m_3D = (base.transform.FindChild("_canvas/3D25D/Select/3D").GetComponent("XUIButton") as IXUIButton);
			this.m_3DFree = (base.transform.FindChild("_canvas/3D25D/Select/3DFree").GetComponent("XUIButton") as IXUIButton);
			this.m_Sight = (base.transform.FindChild("_canvas/3D25D/Sight").GetComponent("XUIButton") as IXUIButton);
			this.m_SightPic = (base.transform.FindChild("_canvas/3D25D/Sight/Content").GetComponent("XUISprite") as IXUISprite);
			this.m_SelectPic = (base.transform.FindChild("_canvas/3D25D/Select/Content").GetComponent("XUISprite") as IXUISprite);
			this.m_objBossRush = base.transform.Find("_canvas/BossRushReward").gameObject;
			this.m_sprBossbg = (this.m_objBossRush.transform.GetComponent("XUISprite") as IXUISprite);
			this.m_sprBuff1 = (base.transform.FindChild("_canvas/BossRushReward/BuffIcon").GetComponent("XUISprite") as IXUISprite);
			this.m_lblBuff1 = (this.m_sprBuff1.gameObject.transform.Find("T2").GetComponent("XUILabel") as IXUILabel);
			this.m_sprBuff2 = (base.transform.FindChild("_canvas/BossRushReward/BuffIcon2").GetComponent("XUISprite") as IXUISprite);
			this.m_lblBuff2 = (this.m_sprBuff2.gameObject.transform.Find("T2").GetComponent("XUILabel") as IXUILabel);
			this.m_lblTitle = (base.transform.FindChild("_canvas/BossRushReward/name").GetComponent("XUILabel") as IXUILabel);
			this.m_objRwd = base.transform.FindChild("_canvas/BossRushReward/ItemList/Item").gameObject;
			this.m_rwdpool.SetupPool(this.m_objRwd.transform.parent.gameObject, this.m_objRwd, 2U, true);
			this.m_SpectateInfo = base.transform.Find("_canvas/Spectate").gameObject;
			this.m_WatchNum = (this.m_SpectateInfo.transform.Find("WatchNum").GetComponent("XUILabel") as IXUILabel);
			this.m_CommendNum = (this.m_SpectateInfo.transform.Find("CommendNum").GetComponent("XUILabel") as IXUILabel);
			this.m_DpsPanel = base.transform.Find("_canvas/Adlet").gameObject;
			this.m_SkyAreanStage = (base.transform.Find("_canvas/SkyAreanStage").GetComponent("XUILabel") as IXUILabel);
			this.m_HorseRide = (base.transform.Find("_canvas/LeftButton/HorseRide").GetComponent("XUIButton") as IXUIButton);
			this.m_GuildMineBuff = (base.transform.Find("_canvas/GuildMineBuff").GetComponent("XUISprite") as IXUISprite);
			this.m_GuildMineBuffText = (base.transform.Find("_canvas/GuildMineBuff/T").GetComponent("XUILabel") as IXUILabel);
			this.m_Menu = (base.transform.Find("_canvas/Menu").GetComponent("XUISimpleList") as IXUISimpleList);
			this.m_AutoPlayContent = this.m_Menu.gameObject.transform.Find("AutoPlayContent").gameObject;
			this.m_BtnDamageStatistics = (this.m_Menu.gameObject.transform.Find("BtnDamageStatistics").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUISprite m_GuildMineBuff;

		public IXUILabel m_GuildMineBuffText;

		public IXUIButton m_HorseRide;

		public Transform m_canvas;

		public Transform m_RoleInfo;

		public Transform m_PingFrame;

		public IXUISprite m_Hpbar = null;

		public IXUISprite m_Mpbar = null;

		public IXUILabel m_HpText;

		public IXUILabel m_MpText;

		public IXUISprite m_HpBackdrop;

		public IXUISprite m_avatar = null;

		public IXUISprite m_sprFrame = null;

		public IXUITexture m_txtHead = null;

		public IXUILabel m_Level = null;

		public IXUILabel m_Name = null;

		public GameObject m_TeamLeader = null;

		public IXUISlider m_sliderBattery;

		public IXUILabel m_lblTime;

		public IXUILabel m_lblfree;

		public GameObject m_avatarGO = null;

		public IXUILabel m_leftTimes = null;

		public IXUILabel m_winConditionTips = null;

		public IXUILabel m_BattleExplainTips = null;

		public IXUIButton m_pause = null;

		public IXPositionGroup m_pauseGroup = null;

		public IXUISprite m_sprwifi;

		public GameObject m_ComboFrame = null;

		public IXUILabel m_ComboText = null;

		public IXUITweenTool m_ComboTextTween = null;

		public IXUITweenTool m_ComboBgTween = null;

		public IXUIProgress m_ComboBuffTime = null;

		public IXUILabel m_ComboBuffName = null;

		public BattleSkillHandler m_SkillHandler;

		public BattleTargetHandler m_BattleTargetHandler;

		public GameObject m_NoticeFrame = null;

		public IXUILabel m_Notice = null;

		public Vector3 m_NoticePos;

		public Transform m_PromptFrame;

		public IXUILabel m_PromptLabel;

		public BattleIndicateHandler m_IndicateHandler;

		public IXUILabel m_LeftTime = null;

		public BattleWorldBossHandler m_WorldBossHandler;

		public XTeamMonitorHandler m_TeamMonitor;

		public XBattleEnemyInfoHandler m_EnemyInfoHandler;

		public XBattleTeamTowerHandler m_TeamTowerHandler;

		public XBuffMonitorHandler m_PlayerBuffMonitorHandler;

		public GameObject m_DpsPanel;

		public GameObject m_LowHP;

		public IXUISprite m_AutoPlayBorad;

		public IXUISprite m_AutoPlayCancelBoard;

		public IXUIButton m_AutoPlay;

		public IXUIButton m_CancelAuto;

		public IXUILabel m_AutoPlayLock;

		public IXUISprite m_AutoPlayTip;

		public IXUILabel m_lblKill;

		public IXUILabel m_WarTime;

		public IXUILabel m_SceneName;

		public Transform m_CountDownFrame;

		public Transform m_CountDownBeginFrame;

		public Transform m_CountDownTimeFrame;

		public IXUIProgress m_StrengthPresevedBar;

		public Transform m_3D25D;

		public Transform m_SightSelect;

		public IXUIButton m_25D;

		public IXUIButton m_3D;

		public IXUIButton m_3DFree;

		public IXUIButton m_Sight;

		public IXUISprite m_SightPic;

		public IXUISprite m_SelectPic;

		public GameObject m_objBossRush;

		public IXUISprite m_sprBuff1;

		public IXUILabel m_lblBuff1;

		public IXUISprite m_sprBuff2;

		public IXUILabel m_lblBuff2;

		public IXUILabel m_lblTitle;

		public GameObject m_objRwd;

		public IXUISprite m_sprBossbg;

		public XUIPool m_rwdpool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public GameObject m_SpectateInfo;

		public IXUILabel m_WatchNum;

		public IXUILabel m_CommendNum;

		public IXUILabel m_SkyAreanStage;

		public IXUISimpleList m_Menu;

		public GameObject m_AutoPlayContent;

		public IXUIButton m_BtnDamageStatistics;
	}
}
