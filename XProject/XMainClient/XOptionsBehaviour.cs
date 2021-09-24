using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XOptionsBehaviour : DlgBehaviourBase
	{

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

		public IXUIButton m_close;

		public IXUILabelSymbol m_Account;

		public IXUILabel m_Server;

		public IXUILabel m_UID;

		public IXUILabel m_ExpNum;

		public IXUILabel m_Level;

		public IXUILabel m_AchievementLabel;

		public IXUILabelSymbol m_Designation;

		public IXUILabel m_Identity;

		public IXUILabel m_GuildName;

		public IXUILabel m_SameScreenNum;

		public IXUILabel m_SameScreenMinT;

		public IXUILabel m_SameScreenMaxT;

		public IXUISprite m_GuildIcon;

		public IXUISprite m_Tq;

		public IXUISprite m_MilitaryIcon;

		public IXUILabel m_MilitaryName;

		public IXUIScrollView m_SettingPanelScrollView;

		public IXUISprite m_Portrait;

		public IXUITexture m_PortraitTex;

		public IXUISprite m_Wechat;

		public IXUISprite m_Guest;

		public IXUILabelSymbol m_Title;

		public IXUIButton m_Changename;

		public IXUIButton m_TitleBtn;

		public IXUIButton m_DesignationBtn;

		public IXUIButton m_AchievementBtn;

		public IXUIButton m_VipBtn;

		public IXUIButton m_PersonalCareerBtn;

		public IXUIButton m_SwitchAccount;

		public IXUIButton m_SwitchChar;

		public IXUIButton m_GameSirBtn;

		public IXUIButton m_CustomerService;

		public IXUIButton m_ServiceTerms;

		public IXUIButton m_ServiceAgreement;

		public IXUIButton m_PrivacyTerms;

		public IXUIProgress m_ExpBar;

		public IXUIProgress m_SameScreenBar;

		public IXUICheckBox m_InfoTab;

		public IXUICheckBox m_OptionTab;

		public IXUICheckBox m_PushTab;

		public IXUICheckBox m_CameraTab;

		public IXUICheckBox m_GameSound;

		public IXUIProgress m_SoundBar;

		public IXUICheckBox m_GameMusic;

		public IXUIProgress m_MusicBar;

		public IXUICheckBox m_GameVoice;

		public IXUIProgress m_VoiceBar;

		public IXUICheckBox m_GameVolume;

		public IXUICheckBox m_RadioWifi;

		public IXUICheckBox m_RadioTeam;

		public IXUICheckBox m_RadioPrivate;

		public IXUICheckBox m_RadioPublic;

		public IXUICheckBox m_RadioWorld;

		public IXUICheckBox m_RadioAutoPlay;

		public Transform m_Quality;

		public IXUICheckBox m_SuperHighPress;

		public IXUICheckBox m_HighPress;

		public IXUICheckBox m_MidPress;

		public IXUICheckBox m_LowPress;

		public Transform m_Quality2;

		public IXUICheckBox m_HighPress2;

		public IXUICheckBox m_MidPress2;

		public IXUICheckBox m_LowPress2;

		public IXUICheckBox m_Flowerrain;

		public IXUICheckBox m_Radio;

		public IXUICheckBox m_3DTouch;

		public Transform m_ResolutionPanel;

		public IXUICheckBox m_Smooth;

		public IXUICheckBox m_ResolutionHigh;

		public IXUICheckBox m_ResolutionNormal;

		public IXUICheckBox m_ResolutionLow;

		public IXUIWrapContent m_PushWrapContent;

		public IXUIWrapContent m_PushWrapContent2;

		public Transform m_UserInfoPanel;

		public Transform m_SettingPanel;

		public Transform m_PushPanel;

		public GameObject m_BattlePanel;

		public Transform m_VoicePanel;

		public Transform m_DisplayPanel;

		public Transform m_SameScreenNumPanel;

		public Transform m_BasePanel;

		public IXUIButton m_QQOpenVipBtn;

		public GameObject m_QQVipIcon;

		public GameObject m_QQSVipIcon;

		public IXUISprite m_WXGameCenter;

		public IXUISprite m_QQGameCenter;

		public IXUIButton m_PrerogativeBtn;
	}
}
