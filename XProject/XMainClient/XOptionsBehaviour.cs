using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000EFB RID: 3835
	internal class XOptionsBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600CB7C RID: 52092 RVA: 0x002E6C8C File Offset: 0x002E4E8C
		private void Awake()
		{
			this.m_close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.Find("Bg/Tabs");
			this.m_InfoTab = (transform.Find("InfoTab").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_OptionTab = (transform.Find("OptionTab").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_PushTab = (transform.Find("PushTab").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_CameraTab = (transform.Find("CameraTab").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_UserInfoPanel = base.transform.Find("Bg/UserInfoPanel");
			Transform transform2 = this.m_UserInfoPanel;
			Transform transform3 = transform2.Find("BaseInfo");
			this.m_Account = (transform3.Find("Username").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_Changename = (transform3.Find("Changename").GetComponent("XUIButton") as IXUIButton);
			this.m_UID = (transform3.Find("UID").GetComponent("XUILabel") as IXUILabel);
			this.m_Portrait = (transform3.Find("Portrait").GetComponent("XUISprite") as IXUISprite);
			this.m_PortraitTex = (transform3.Find("Portrait/Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_Wechat = (transform3.Find("Wechat").GetComponent("XUISprite") as IXUISprite);
			this.m_Guest = (transform3.Find("Guest").GetComponent("XUISprite") as IXUISprite);
			transform3 = transform2.Find("UserInfo");
			this.m_ExpNum = (transform3.Find("Exp/ExpNum").GetComponent("XUILabel") as IXUILabel);
			this.m_Level = (transform3.Find("Exp/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_ExpBar = (transform3.Find("Exp/ExpBar").GetComponent("XUIProgress") as IXUIProgress);
			this.m_TitleBtn = (transform3.Find("Rank/RankBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_Title = (transform3.Find("Rank/RankPic").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_TitleBtn.gameObject.SetActive(false);
			this.m_DesignationBtn = (transform3.Find("Title/TitleBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_Designation = (transform3.Find("Title/TitleLabel").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_DesignationBtn.gameObject.SetActive(false);
			this.m_AchievementBtn = (transform3.Find("Achievement/AchievementBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_AchievementLabel = (transform3.Find("Achievement/AchievementLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_AchievementBtn.gameObject.SetActive(false);
			this.m_MilitaryIcon = (transform3.Find("Military/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_MilitaryName = (transform3.Find("Military/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_Identity = (transform3.Find("Guild/Identity").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildName = (transform3.Find("Guild/GuildName").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildIcon = (transform3.Find("Guild/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_Server = (transform2.Find("Server").GetComponent("XUILabel") as IXUILabel);
			this.m_ServiceTerms = (transform2.Find("Link/ServiceTerms").GetComponent("XUIButton") as IXUIButton);
			this.m_ServiceAgreement = (transform2.Find("Link/ServiceAgreement").GetComponent("XUIButton") as IXUIButton);
			this.m_PrivacyTerms = (transform2.Find("Link/PrivacyTerms").GetComponent("XUIButton") as IXUIButton);
			this.m_SwitchChar = (transform2.Find("BottomButtons/SwitchChar").GetComponent("XUIButton") as IXUIButton);
			this.m_SwitchAccount = (transform2.Find("BottomButtons/SwitchAccount").GetComponent("XUIButton") as IXUIButton);
			this.m_VipBtn = (transform2.Find("BottomButtons/VipBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_PersonalCareerBtn = (transform2.Find("BottomButtons/PersonalCareerBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_CustomerService = (base.transform.Find("Bg/CustomerService").GetComponent("XUIButton") as IXUIButton);
			this.m_SettingPanel = base.transform.Find("Bg/SettingPanel");
			transform2 = this.m_SettingPanel;
			this.m_SettingPanelScrollView = (transform2.GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_BasePanel = transform2.Find("BasePanel");
			this.m_GameSound = (this.m_BasePanel.Find("GameSound").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_SoundBar = (this.m_BasePanel.Find("GameSound/Slider").GetComponent("XUIProgress") as IXUIProgress);
			this.m_GameMusic = (this.m_BasePanel.Find("GameMusic").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_MusicBar = (this.m_BasePanel.Find("GameMusic/Slider").GetComponent("XUIProgress") as IXUIProgress);
			this.m_GameVoice = (this.m_BasePanel.Find("GameVoice").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_VoiceBar = (this.m_BasePanel.Find("GameVoice/Slider").GetComponent("XUIProgress") as IXUIProgress);
			this.m_Flowerrain = (this.m_BasePanel.Find("Flowerrain").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Radio = (this.m_BasePanel.Find("Radio").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_3DTouch = (this.m_BasePanel.Find("3DTouch").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_GameSirBtn = (this.m_BasePanel.Find("GameSir").GetComponent("XUIButton") as IXUIButton);
			this.m_DisplayPanel = transform2.Find("DisplayPanel");
			this.m_Quality = this.m_DisplayPanel.Find("Quality");
			this.m_SuperHighPress = (this.m_Quality.Find("BtnSuperHighPress").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_HighPress = (this.m_Quality.Find("BtnHighPress").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_MidPress = (this.m_Quality.Find("BtnMidPress").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_LowPress = (this.m_Quality.Find("BtnLowPress").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Quality2 = this.m_DisplayPanel.Find("Quality2");
			this.m_HighPress2 = (this.m_Quality2.Find("BtnHighPress").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_MidPress2 = (this.m_Quality2.Find("BtnMidPress").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_LowPress2 = (this.m_Quality2.Find("BtnLowPress").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_SameScreenNumPanel = transform2.Find("SameScreenNumPanel");
			this.m_SameScreenNum = (this.m_SameScreenNumPanel.Find("Thumb/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_SameScreenBar = (this.m_SameScreenNumPanel.Find("Bar").GetComponent("XUIProgress") as IXUIProgress);
			this.m_SameScreenMinT = (this.m_SameScreenNumPanel.Find("MinT").GetComponent("XUILabel") as IXUILabel);
			this.m_SameScreenMaxT = (this.m_SameScreenNumPanel.Find("MaxT").GetComponent("XUILabel") as IXUILabel);
			this.m_VoicePanel = transform2.Find("VoicePanel");
			this.m_GameVolume = (this.m_VoicePanel.Find("GameVolume").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_RadioWifi = (this.m_VoicePanel.Find("RadioWifi").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_RadioTeam = (this.m_VoicePanel.Find("RadioTeam").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_RadioPrivate = (this.m_VoicePanel.Find("RadioPrivate").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_RadioPublic = (this.m_VoicePanel.Find("RadioPublic").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_RadioWorld = (this.m_VoicePanel.Find("RadioWorld").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_RadioAutoPlay = (this.m_VoicePanel.Find("RadioAutoPlay").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_ResolutionPanel = transform2.Find("ResolutionPanel");
			this.m_Smooth = (this.m_ResolutionPanel.Find("Smooth").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_ResolutionHigh = (this.m_ResolutionPanel.Find("Resolution/Original").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_ResolutionNormal = (this.m_ResolutionPanel.Find("Resolution/Normal").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_ResolutionLow = (this.m_ResolutionPanel.Find("Resolution/Fast").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_BattlePanel = base.transform.Find("Bg/BattlePanel").gameObject;
			this.m_PushPanel = base.transform.Find("Bg/PushPanel");
			this.m_PushWrapContent = (this.m_PushPanel.Find("Scroll1/wrapcontent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_PushWrapContent2 = (this.m_PushPanel.Find("Scroll2/wrapcontent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_QQOpenVipBtn = (this.m_UserInfoPanel.FindChild("BottomButtons/QQVipBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_QQVipIcon = this.m_UserInfoPanel.FindChild("BaseInfo/QQVIP").gameObject;
			this.m_QQSVipIcon = this.m_UserInfoPanel.FindChild("BaseInfo/QQSVIP").gameObject;
			this.m_WXGameCenter = (this.m_UserInfoPanel.FindChild("BaseInfo/Wechat").GetComponent("XUISprite") as IXUISprite);
			this.m_QQGameCenter = (this.m_UserInfoPanel.FindChild("BottomButtons/QQ").GetComponent("XUISprite") as IXUISprite);
			this.m_Tq = (this.m_UserInfoPanel.FindChild("BaseInfo/Tq").GetComponent("XUISprite") as IXUISprite);
			this.m_PrerogativeBtn = (this.m_UserInfoPanel.FindChild("BottomButtons/PrerogativeBtn").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x04005A09 RID: 23049
		public IXUIButton m_close;

		// Token: 0x04005A0A RID: 23050
		public IXUILabelSymbol m_Account;

		// Token: 0x04005A0B RID: 23051
		public IXUILabel m_Server;

		// Token: 0x04005A0C RID: 23052
		public IXUILabel m_UID;

		// Token: 0x04005A0D RID: 23053
		public IXUILabel m_ExpNum;

		// Token: 0x04005A0E RID: 23054
		public IXUILabel m_Level;

		// Token: 0x04005A0F RID: 23055
		public IXUILabel m_AchievementLabel;

		// Token: 0x04005A10 RID: 23056
		public IXUILabelSymbol m_Designation;

		// Token: 0x04005A11 RID: 23057
		public IXUILabel m_Identity;

		// Token: 0x04005A12 RID: 23058
		public IXUILabel m_GuildName;

		// Token: 0x04005A13 RID: 23059
		public IXUILabel m_SameScreenNum;

		// Token: 0x04005A14 RID: 23060
		public IXUILabel m_SameScreenMinT;

		// Token: 0x04005A15 RID: 23061
		public IXUILabel m_SameScreenMaxT;

		// Token: 0x04005A16 RID: 23062
		public IXUISprite m_GuildIcon;

		// Token: 0x04005A17 RID: 23063
		public IXUISprite m_Tq;

		// Token: 0x04005A18 RID: 23064
		public IXUISprite m_MilitaryIcon;

		// Token: 0x04005A19 RID: 23065
		public IXUILabel m_MilitaryName;

		// Token: 0x04005A1A RID: 23066
		public IXUIScrollView m_SettingPanelScrollView;

		// Token: 0x04005A1B RID: 23067
		public IXUISprite m_Portrait;

		// Token: 0x04005A1C RID: 23068
		public IXUITexture m_PortraitTex;

		// Token: 0x04005A1D RID: 23069
		public IXUISprite m_Wechat;

		// Token: 0x04005A1E RID: 23070
		public IXUISprite m_Guest;

		// Token: 0x04005A1F RID: 23071
		public IXUILabelSymbol m_Title;

		// Token: 0x04005A20 RID: 23072
		public IXUIButton m_Changename;

		// Token: 0x04005A21 RID: 23073
		public IXUIButton m_TitleBtn;

		// Token: 0x04005A22 RID: 23074
		public IXUIButton m_DesignationBtn;

		// Token: 0x04005A23 RID: 23075
		public IXUIButton m_AchievementBtn;

		// Token: 0x04005A24 RID: 23076
		public IXUIButton m_VipBtn;

		// Token: 0x04005A25 RID: 23077
		public IXUIButton m_PersonalCareerBtn;

		// Token: 0x04005A26 RID: 23078
		public IXUIButton m_SwitchAccount;

		// Token: 0x04005A27 RID: 23079
		public IXUIButton m_SwitchChar;

		// Token: 0x04005A28 RID: 23080
		public IXUIButton m_GameSirBtn;

		// Token: 0x04005A29 RID: 23081
		public IXUIButton m_CustomerService;

		// Token: 0x04005A2A RID: 23082
		public IXUIButton m_ServiceTerms;

		// Token: 0x04005A2B RID: 23083
		public IXUIButton m_ServiceAgreement;

		// Token: 0x04005A2C RID: 23084
		public IXUIButton m_PrivacyTerms;

		// Token: 0x04005A2D RID: 23085
		public IXUIProgress m_ExpBar;

		// Token: 0x04005A2E RID: 23086
		public IXUIProgress m_SameScreenBar;

		// Token: 0x04005A2F RID: 23087
		public IXUICheckBox m_InfoTab;

		// Token: 0x04005A30 RID: 23088
		public IXUICheckBox m_OptionTab;

		// Token: 0x04005A31 RID: 23089
		public IXUICheckBox m_PushTab;

		// Token: 0x04005A32 RID: 23090
		public IXUICheckBox m_CameraTab;

		// Token: 0x04005A33 RID: 23091
		public IXUICheckBox m_GameSound;

		// Token: 0x04005A34 RID: 23092
		public IXUIProgress m_SoundBar;

		// Token: 0x04005A35 RID: 23093
		public IXUICheckBox m_GameMusic;

		// Token: 0x04005A36 RID: 23094
		public IXUIProgress m_MusicBar;

		// Token: 0x04005A37 RID: 23095
		public IXUICheckBox m_GameVoice;

		// Token: 0x04005A38 RID: 23096
		public IXUIProgress m_VoiceBar;

		// Token: 0x04005A39 RID: 23097
		public IXUICheckBox m_GameVolume;

		// Token: 0x04005A3A RID: 23098
		public IXUICheckBox m_RadioWifi;

		// Token: 0x04005A3B RID: 23099
		public IXUICheckBox m_RadioTeam;

		// Token: 0x04005A3C RID: 23100
		public IXUICheckBox m_RadioPrivate;

		// Token: 0x04005A3D RID: 23101
		public IXUICheckBox m_RadioPublic;

		// Token: 0x04005A3E RID: 23102
		public IXUICheckBox m_RadioWorld;

		// Token: 0x04005A3F RID: 23103
		public IXUICheckBox m_RadioAutoPlay;

		// Token: 0x04005A40 RID: 23104
		public Transform m_Quality;

		// Token: 0x04005A41 RID: 23105
		public IXUICheckBox m_SuperHighPress;

		// Token: 0x04005A42 RID: 23106
		public IXUICheckBox m_HighPress;

		// Token: 0x04005A43 RID: 23107
		public IXUICheckBox m_MidPress;

		// Token: 0x04005A44 RID: 23108
		public IXUICheckBox m_LowPress;

		// Token: 0x04005A45 RID: 23109
		public Transform m_Quality2;

		// Token: 0x04005A46 RID: 23110
		public IXUICheckBox m_HighPress2;

		// Token: 0x04005A47 RID: 23111
		public IXUICheckBox m_MidPress2;

		// Token: 0x04005A48 RID: 23112
		public IXUICheckBox m_LowPress2;

		// Token: 0x04005A49 RID: 23113
		public IXUICheckBox m_Flowerrain;

		// Token: 0x04005A4A RID: 23114
		public IXUICheckBox m_Radio;

		// Token: 0x04005A4B RID: 23115
		public IXUICheckBox m_3DTouch;

		// Token: 0x04005A4C RID: 23116
		public Transform m_ResolutionPanel;

		// Token: 0x04005A4D RID: 23117
		public IXUICheckBox m_Smooth;

		// Token: 0x04005A4E RID: 23118
		public IXUICheckBox m_ResolutionHigh;

		// Token: 0x04005A4F RID: 23119
		public IXUICheckBox m_ResolutionNormal;

		// Token: 0x04005A50 RID: 23120
		public IXUICheckBox m_ResolutionLow;

		// Token: 0x04005A51 RID: 23121
		public IXUIWrapContent m_PushWrapContent;

		// Token: 0x04005A52 RID: 23122
		public IXUIWrapContent m_PushWrapContent2;

		// Token: 0x04005A53 RID: 23123
		public Transform m_UserInfoPanel;

		// Token: 0x04005A54 RID: 23124
		public Transform m_SettingPanel;

		// Token: 0x04005A55 RID: 23125
		public Transform m_PushPanel;

		// Token: 0x04005A56 RID: 23126
		public GameObject m_BattlePanel;

		// Token: 0x04005A57 RID: 23127
		public Transform m_VoicePanel;

		// Token: 0x04005A58 RID: 23128
		public Transform m_DisplayPanel;

		// Token: 0x04005A59 RID: 23129
		public Transform m_SameScreenNumPanel;

		// Token: 0x04005A5A RID: 23130
		public Transform m_BasePanel;

		// Token: 0x04005A5B RID: 23131
		public IXUIButton m_QQOpenVipBtn;

		// Token: 0x04005A5C RID: 23132
		public GameObject m_QQVipIcon;

		// Token: 0x04005A5D RID: 23133
		public GameObject m_QQSVipIcon;

		// Token: 0x04005A5E RID: 23134
		public IXUISprite m_WXGameCenter;

		// Token: 0x04005A5F RID: 23135
		public IXUISprite m_QQGameCenter;

		// Token: 0x04005A60 RID: 23136
		public IXUIButton m_PrerogativeBtn;
	}
}
