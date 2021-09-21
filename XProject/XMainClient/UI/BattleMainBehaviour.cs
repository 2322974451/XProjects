using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018F8 RID: 6392
	internal class BattleMainBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010AD8 RID: 68312 RVA: 0x00425F24 File Offset: 0x00424124
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

		// Token: 0x04007984 RID: 31108
		public IXUISprite m_GuildMineBuff;

		// Token: 0x04007985 RID: 31109
		public IXUILabel m_GuildMineBuffText;

		// Token: 0x04007986 RID: 31110
		public IXUIButton m_HorseRide;

		// Token: 0x04007987 RID: 31111
		public Transform m_canvas;

		// Token: 0x04007988 RID: 31112
		public Transform m_RoleInfo;

		// Token: 0x04007989 RID: 31113
		public Transform m_PingFrame;

		// Token: 0x0400798A RID: 31114
		public IXUISprite m_Hpbar = null;

		// Token: 0x0400798B RID: 31115
		public IXUISprite m_Mpbar = null;

		// Token: 0x0400798C RID: 31116
		public IXUILabel m_HpText;

		// Token: 0x0400798D RID: 31117
		public IXUILabel m_MpText;

		// Token: 0x0400798E RID: 31118
		public IXUISprite m_HpBackdrop;

		// Token: 0x0400798F RID: 31119
		public IXUISprite m_avatar = null;

		// Token: 0x04007990 RID: 31120
		public IXUISprite m_sprFrame = null;

		// Token: 0x04007991 RID: 31121
		public IXUITexture m_txtHead = null;

		// Token: 0x04007992 RID: 31122
		public IXUILabel m_Level = null;

		// Token: 0x04007993 RID: 31123
		public IXUILabel m_Name = null;

		// Token: 0x04007994 RID: 31124
		public GameObject m_TeamLeader = null;

		// Token: 0x04007995 RID: 31125
		public IXUISlider m_sliderBattery;

		// Token: 0x04007996 RID: 31126
		public IXUILabel m_lblTime;

		// Token: 0x04007997 RID: 31127
		public IXUILabel m_lblfree;

		// Token: 0x04007998 RID: 31128
		public GameObject m_avatarGO = null;

		// Token: 0x04007999 RID: 31129
		public IXUILabel m_leftTimes = null;

		// Token: 0x0400799A RID: 31130
		public IXUILabel m_winConditionTips = null;

		// Token: 0x0400799B RID: 31131
		public IXUILabel m_BattleExplainTips = null;

		// Token: 0x0400799C RID: 31132
		public IXUIButton m_pause = null;

		// Token: 0x0400799D RID: 31133
		public IXPositionGroup m_pauseGroup = null;

		// Token: 0x0400799E RID: 31134
		public IXUISprite m_sprwifi;

		// Token: 0x0400799F RID: 31135
		public GameObject m_ComboFrame = null;

		// Token: 0x040079A0 RID: 31136
		public IXUILabel m_ComboText = null;

		// Token: 0x040079A1 RID: 31137
		public IXUITweenTool m_ComboTextTween = null;

		// Token: 0x040079A2 RID: 31138
		public IXUITweenTool m_ComboBgTween = null;

		// Token: 0x040079A3 RID: 31139
		public IXUIProgress m_ComboBuffTime = null;

		// Token: 0x040079A4 RID: 31140
		public IXUILabel m_ComboBuffName = null;

		// Token: 0x040079A5 RID: 31141
		public BattleSkillHandler m_SkillHandler;

		// Token: 0x040079A6 RID: 31142
		public BattleTargetHandler m_BattleTargetHandler;

		// Token: 0x040079A7 RID: 31143
		public GameObject m_NoticeFrame = null;

		// Token: 0x040079A8 RID: 31144
		public IXUILabel m_Notice = null;

		// Token: 0x040079A9 RID: 31145
		public Vector3 m_NoticePos;

		// Token: 0x040079AA RID: 31146
		public Transform m_PromptFrame;

		// Token: 0x040079AB RID: 31147
		public IXUILabel m_PromptLabel;

		// Token: 0x040079AC RID: 31148
		public BattleIndicateHandler m_IndicateHandler;

		// Token: 0x040079AD RID: 31149
		public IXUILabel m_LeftTime = null;

		// Token: 0x040079AE RID: 31150
		public BattleWorldBossHandler m_WorldBossHandler;

		// Token: 0x040079AF RID: 31151
		public XTeamMonitorHandler m_TeamMonitor;

		// Token: 0x040079B0 RID: 31152
		public XBattleEnemyInfoHandler m_EnemyInfoHandler;

		// Token: 0x040079B1 RID: 31153
		public XBattleTeamTowerHandler m_TeamTowerHandler;

		// Token: 0x040079B2 RID: 31154
		public XBuffMonitorHandler m_PlayerBuffMonitorHandler;

		// Token: 0x040079B3 RID: 31155
		public GameObject m_DpsPanel;

		// Token: 0x040079B4 RID: 31156
		public GameObject m_LowHP;

		// Token: 0x040079B5 RID: 31157
		public IXUISprite m_AutoPlayBorad;

		// Token: 0x040079B6 RID: 31158
		public IXUISprite m_AutoPlayCancelBoard;

		// Token: 0x040079B7 RID: 31159
		public IXUIButton m_AutoPlay;

		// Token: 0x040079B8 RID: 31160
		public IXUIButton m_CancelAuto;

		// Token: 0x040079B9 RID: 31161
		public IXUILabel m_AutoPlayLock;

		// Token: 0x040079BA RID: 31162
		public IXUISprite m_AutoPlayTip;

		// Token: 0x040079BB RID: 31163
		public IXUILabel m_lblKill;

		// Token: 0x040079BC RID: 31164
		public IXUILabel m_WarTime;

		// Token: 0x040079BD RID: 31165
		public IXUILabel m_SceneName;

		// Token: 0x040079BE RID: 31166
		public Transform m_CountDownFrame;

		// Token: 0x040079BF RID: 31167
		public Transform m_CountDownBeginFrame;

		// Token: 0x040079C0 RID: 31168
		public Transform m_CountDownTimeFrame;

		// Token: 0x040079C1 RID: 31169
		public IXUIProgress m_StrengthPresevedBar;

		// Token: 0x040079C2 RID: 31170
		public Transform m_3D25D;

		// Token: 0x040079C3 RID: 31171
		public Transform m_SightSelect;

		// Token: 0x040079C4 RID: 31172
		public IXUIButton m_25D;

		// Token: 0x040079C5 RID: 31173
		public IXUIButton m_3D;

		// Token: 0x040079C6 RID: 31174
		public IXUIButton m_3DFree;

		// Token: 0x040079C7 RID: 31175
		public IXUIButton m_Sight;

		// Token: 0x040079C8 RID: 31176
		public IXUISprite m_SightPic;

		// Token: 0x040079C9 RID: 31177
		public IXUISprite m_SelectPic;

		// Token: 0x040079CA RID: 31178
		public GameObject m_objBossRush;

		// Token: 0x040079CB RID: 31179
		public IXUISprite m_sprBuff1;

		// Token: 0x040079CC RID: 31180
		public IXUILabel m_lblBuff1;

		// Token: 0x040079CD RID: 31181
		public IXUISprite m_sprBuff2;

		// Token: 0x040079CE RID: 31182
		public IXUILabel m_lblBuff2;

		// Token: 0x040079CF RID: 31183
		public IXUILabel m_lblTitle;

		// Token: 0x040079D0 RID: 31184
		public GameObject m_objRwd;

		// Token: 0x040079D1 RID: 31185
		public IXUISprite m_sprBossbg;

		// Token: 0x040079D2 RID: 31186
		public XUIPool m_rwdpool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040079D3 RID: 31187
		public GameObject m_SpectateInfo;

		// Token: 0x040079D4 RID: 31188
		public IXUILabel m_WatchNum;

		// Token: 0x040079D5 RID: 31189
		public IXUILabel m_CommendNum;

		// Token: 0x040079D6 RID: 31190
		public IXUILabel m_SkyAreanStage;

		// Token: 0x040079D7 RID: 31191
		public IXUISimpleList m_Menu;

		// Token: 0x040079D8 RID: 31192
		public GameObject m_AutoPlayContent;

		// Token: 0x040079D9 RID: 31193
		public IXUIButton m_BtnDamageStatistics;
	}
}
