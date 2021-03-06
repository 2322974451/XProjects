using System;
using System.Collections.Generic;
using System.Text;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XOptionsView : DlgBase<XOptionsView, XOptionsBehaviour>
	{

		public OptionsTab CurrentTab
		{
			get
			{
				return this.m_CurrentTab;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/SettingDlg";
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
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
				return false;
			}
		}

		public override bool pushstack
		{
			get
			{
				return false;
			}
		}

		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			this._doc.View = this;
			base.uiBehaviour.m_PushWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.PushItemUpdate1));
			base.uiBehaviour.m_PushWrapContent2.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.PushItemUpdate2));
			DlgHandlerBase.EnsureCreate<XOptionsBattleDetailHandler>(ref this.m_DetailHandler, base.uiBehaviour.m_BattlePanel, null, true);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_InfoTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnInfoCheckBoxClicked));
			base.uiBehaviour.m_OptionTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnOptionCheckBoxClicked));
			base.uiBehaviour.m_PushTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnPushCheckboxClicked));
			base.uiBehaviour.m_CameraTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnCameraCheckboxClicked));
			base.uiBehaviour.m_VipBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this._VipBtnClicked));
			base.uiBehaviour.m_PersonalCareerBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this._PersonalCareerBtnClicked));
			base.uiBehaviour.m_Wechat.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnWechatPrivilegeClicked));
			base.uiBehaviour.m_Guest.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnGuestPrivilegeClicked));
			base.uiBehaviour.m_TitleBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this._RankBtnClicked));
			base.uiBehaviour.m_DesignationBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this._TitleBtnClicked));
			base.uiBehaviour.m_AchievementBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this._AchievementBtnClicked));
			base.uiBehaviour.m_SwitchAccount.RegisterClickEventHandler(new ButtonClickEventHandler(this._SwitchAccountClicked));
			base.uiBehaviour.m_SwitchChar.RegisterClickEventHandler(new ButtonClickEventHandler(this._SwitchCharClicked));
			base.uiBehaviour.m_CustomerService.RegisterClickEventHandler(new ButtonClickEventHandler(this._CustomerServiceClicked));
			base.uiBehaviour.m_ServiceTerms.RegisterClickEventHandler(new ButtonClickEventHandler(this._ServiceTermsClicked));
			base.uiBehaviour.m_ServiceAgreement.RegisterClickEventHandler(new ButtonClickEventHandler(this._ServiceAgreementClicked));
			base.uiBehaviour.m_PrivacyTerms.RegisterClickEventHandler(new ButtonClickEventHandler(this._PrivacyTermsClicked));
			base.uiBehaviour.m_Changename.RegisterClickEventHandler(new ButtonClickEventHandler(this._ChangeNameClicked));
			base.uiBehaviour.m_GameSound.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOptionsDefine>.ToInt(XOptionsDefine.OD_SOUND));
			base.uiBehaviour.m_GameSound.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._SingleCheckBoxChanged));
			base.uiBehaviour.m_GameMusic.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOptionsDefine>.ToInt(XOptionsDefine.OD_MUSIC));
			base.uiBehaviour.m_GameMusic.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._SingleCheckBoxChanged));
			base.uiBehaviour.m_GameVoice.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOptionsDefine>.ToInt(XOptionsDefine.OD_VOICE));
			base.uiBehaviour.m_GameVoice.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._SingleCheckBoxChanged));
			base.uiBehaviour.m_GameVolume.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOptionsDefine>.ToInt(XOptionsDefine.OD_VOLUME));
			base.uiBehaviour.m_GameVolume.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._SingleCheckBoxChanged));
			base.uiBehaviour.m_RadioWifi.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOptionsDefine>.ToInt(XOptionsDefine.OD_RADIO_WIFI));
			base.uiBehaviour.m_RadioWifi.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._SingleCheckBoxChanged));
			base.uiBehaviour.m_RadioTeam.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOptionsDefine>.ToInt(XOptionsDefine.OD_RADIO_TEAM));
			base.uiBehaviour.m_RadioTeam.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._SingleCheckBoxChanged));
			base.uiBehaviour.m_RadioPrivate.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOptionsDefine>.ToInt(XOptionsDefine.OD_RADIO_PRIVATE));
			base.uiBehaviour.m_RadioPrivate.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._SingleCheckBoxChanged));
			base.uiBehaviour.m_RadioPublic.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOptionsDefine>.ToInt(XOptionsDefine.OD_RADIO_PUBLIC));
			base.uiBehaviour.m_RadioPublic.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._SingleCheckBoxChanged));
			base.uiBehaviour.m_RadioWorld.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOptionsDefine>.ToInt(XOptionsDefine.OD_RADIO_WORLD));
			base.uiBehaviour.m_RadioWorld.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._SingleCheckBoxChanged));
			base.uiBehaviour.m_RadioAutoPlay.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOptionsDefine>.ToInt(XOptionsDefine.OD_RADIO_AUTO_PALY));
			base.uiBehaviour.m_RadioAutoPlay.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._SingleCheckBoxChanged));
			base.uiBehaviour.m_GameSirBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OpenGameSirClick));
			base.uiBehaviour.m_Smooth.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOptionsDefine>.ToInt(XOptionsDefine.OD_SMOOTH));
			base.uiBehaviour.m_Smooth.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._SingleCheckBoxChanged));
			base.uiBehaviour.m_ResolutionHigh.ID = (ulong)((long)XFastEnumIntEqualityComparer<XQualitySetting.EResolution>.ToInt(XQualitySetting.EResolution.EHeigh));
			base.uiBehaviour.m_ResolutionHigh.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._ResolutionCheckBoxChanged));
			base.uiBehaviour.m_ResolutionNormal.ID = (ulong)((long)XFastEnumIntEqualityComparer<XQualitySetting.EResolution>.ToInt(XQualitySetting.EResolution.ENormal));
			base.uiBehaviour.m_ResolutionNormal.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._ResolutionCheckBoxChanged));
			base.uiBehaviour.m_ResolutionLow.ID = (ulong)((long)XFastEnumIntEqualityComparer<XQualitySetting.EResolution>.ToInt(XQualitySetting.EResolution.ELow));
			base.uiBehaviour.m_ResolutionLow.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._ResolutionCheckBoxChanged));
			base.uiBehaviour.m_LowPress.ID = (ulong)((long)XFastEnumIntEqualityComparer<XQualitySetting.ESetting>.ToInt(XQualitySetting.ESetting.ELow));
			base.uiBehaviour.m_LowPress.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._QualityCheckBoxChanged));
			base.uiBehaviour.m_MidPress.ID = (ulong)((long)XFastEnumIntEqualityComparer<XQualitySetting.ESetting>.ToInt(XQualitySetting.ESetting.ENormal));
			base.uiBehaviour.m_MidPress.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._QualityCheckBoxChanged));
			base.uiBehaviour.m_HighPress.ID = (ulong)((long)XFastEnumIntEqualityComparer<XQualitySetting.ESetting>.ToInt(XQualitySetting.ESetting.EHeigh));
			base.uiBehaviour.m_HighPress.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._QualityCheckBoxChanged));
			base.uiBehaviour.m_SuperHighPress.ID = (ulong)((long)XFastEnumIntEqualityComparer<XQualitySetting.ESetting>.ToInt(XQualitySetting.ESetting.EVeryHeigh));
			base.uiBehaviour.m_SuperHighPress.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._QualityCheckBoxChanged));
			base.uiBehaviour.m_LowPress2.ID = (ulong)((long)XFastEnumIntEqualityComparer<XQualitySetting.ESetting>.ToInt(XQualitySetting.ESetting.ELow));
			base.uiBehaviour.m_LowPress2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._QualityCheckBoxChanged));
			base.uiBehaviour.m_MidPress2.ID = (ulong)((long)XFastEnumIntEqualityComparer<XQualitySetting.ESetting>.ToInt(XQualitySetting.ESetting.ENormal));
			base.uiBehaviour.m_MidPress2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._QualityCheckBoxChanged));
			base.uiBehaviour.m_HighPress2.ID = (ulong)((long)XFastEnumIntEqualityComparer<XQualitySetting.ESetting>.ToInt(XQualitySetting.ESetting.EHeigh));
			base.uiBehaviour.m_HighPress2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._QualityCheckBoxChanged));
			base.uiBehaviour.m_Flowerrain.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOptionsDefine>.ToInt(XOptionsDefine.OD_FLOWERRAIN));
			base.uiBehaviour.m_Flowerrain.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._SingleCheckBoxChanged));
			base.uiBehaviour.m_3DTouch.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOptionsDefine>.ToInt(XOptionsDefine.OD_3D_TOUCH));
			base.uiBehaviour.m_3DTouch.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._SingleCheckBoxChanged));
			base.uiBehaviour.m_Radio.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOptionsDefine>.ToInt(XOptionsDefine.OD_RADIO));
			base.uiBehaviour.m_Radio.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._SingleCheckBoxChanged));
			base.uiBehaviour.m_QQOpenVipBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnQQOpenVipBtnClicked));
			base.uiBehaviour.m_QQGameCenter.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnQQGameCenterClicked));
			base.uiBehaviour.m_WXGameCenter.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnWXGameCenterClicked));
			base.uiBehaviour.m_PrerogativeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPrerogativeBtnClicked));
		}

		private bool OpenGameSirClick(IXUIButton btn)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("ClickGameSirClick", null, null, null, null, null);
			DlgBase<XGameSirView, XGameSirBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		private bool OnPrerogativeBtnClicked(IXUIButton btn)
		{
			DlgBase<XOptionsView, XOptionsBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			DlgBase<PrerogativeDlg, PrerogativeDlgBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		private bool OnQQOpenVipBtnClicked(IXUIButton btn)
		{
			DlgBase<XOptionsView, XOptionsBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			XPlatformAbilityDocument.Doc.OpenQQVipRechargeH5();
			return true;
		}

		private void OnQQGameCenterClicked(IXUISprite btn)
		{
			DlgBase<XOptionsView, XOptionsBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			DlgBase<XQQWXGameCenterPrivilegeView, XQQWXGameCenterPrivilegeBehaviour>.singleton.SetVisibleWithAnimation(true, null);
		}

		private void OnWXGameCenterClicked(IXUISprite btn)
		{
			DlgBase<XOptionsView, XOptionsBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			DlgBase<XQQWXGameCenterPrivilegeView, XQQWXGameCenterPrivilegeBehaviour>.singleton.SetVisibleWithAnimation(true, null);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.OnTabChanged(this.prefabTab);
			this.m_uiBehaviour.m_VipBtn.SetVisible(false);
			this.m_uiBehaviour.m_PersonalCareerBtn.SetVisible(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Personal_Career));
			this.m_uiBehaviour.m_Quality.gameObject.SetActive(XQualitySetting.SupportHighEffect());
			this.m_uiBehaviour.m_Quality2.gameObject.SetActive(!XQualitySetting.SupportHighEffect());
			this.m_uiBehaviour.m_GameSirBtn.SetVisible(XSingleton<XUpdater.XUpdater>.singleton.GameSirControl != null && XSingleton<XUpdater.XUpdater>.singleton.GameSirControl.IsOpen);
			this._bDirty = false;
			XPlatformAbilityDocument.Doc.QueryQQVipInfo();
		}

		protected override void OnHide()
		{
			this.m_DetailHandler.SaveOption();
			bool bDirty = this._bDirty;
			if (bDirty)
			{
				this._doc.SaveSetting();
				this._bDirty = false;
			}
			bool flag = this.m_DetailHandler.bDirty || XSingleton<XOperationData>.singleton.OperationMode != (XOperationMode)this._doc.GetValue(XOptionsDefine.OD_VIEW);
			if (flag)
			{
				this._doc.SetBattleOptionValue();
				this.m_DetailHandler.bDirty = false;
			}
			this.m_uiBehaviour.m_PortraitTex.SetTexturePath("");
			bool flag2 = this.OnOptionClose != null;
			if (flag2)
			{
				this.OnOptionClose();
			}
			base.OnHide();
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XOptionsBattleDetailHandler>(ref this.m_DetailHandler);
			this._doc.View = null;
			base.OnUnload();
		}

		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnInfoCheckBoxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.OnTabChanged(OptionsTab.InfoTab);
				result = true;
			}
			return result;
		}

		private bool OnOptionCheckBoxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.OnTabChanged(OptionsTab.OptionTab);
				result = true;
			}
			return result;
		}

		private bool OnSystemCheckBoxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.OnTabChanged(OptionsTab.BaseTab);
				result = true;
			}
			return result;
		}

		private bool OnNotifyCheckBoxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.OnTabChanged(OptionsTab.NotifyTab);
				result = true;
			}
			return result;
		}

		private bool OnVoiceCheckBoxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.OnTabChanged(OptionsTab.VoiceTab);
				result = true;
			}
			return result;
		}

		private bool OnDisplayCheckBoxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.OnTabChanged(OptionsTab.DisplayTab);
				result = true;
			}
			return result;
		}

		public bool OnPushCheckboxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.OnTabChanged(OptionsTab.PushTab);
				result = true;
			}
			return result;
		}

		public bool OnCameraCheckboxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.OnTabChanged(OptionsTab.CameraTab);
				result = true;
			}
			return result;
		}

		public void OnTabChanged(OptionsTab handler)
		{
			bool flag = this.m_CurrentTab == OptionsTab.CameraTab;
			if (flag)
			{
				this.m_DetailHandler.SaveOption();
			}
			this.m_CurrentTab = handler;
			this.prefabTab = this.m_CurrentTab;
			switch (this.m_CurrentTab)
			{
			case OptionsTab.InfoTab:
				this.ShowUserInfoPanel();
				break;
			case OptionsTab.OptionTab:
				this.ShowSettingPanel();
				break;
			case OptionsTab.BaseTab:
				this.ShowBasePanel();
				break;
			case OptionsTab.NotifyTab:
				this.ShowNotifyPanel();
				break;
			case OptionsTab.VoiceTab:
				this.ShowVoicePanel();
				break;
			case OptionsTab.DisplayTab:
				this.ShowDisplayPanel();
				break;
			case OptionsTab.PushTab:
				this.ShowPushPanel();
				break;
			case OptionsTab.CameraTab:
				this.ShowCameraPanel();
				break;
			}
		}

		private void CloseAllPanel()
		{
			base.uiBehaviour.m_UserInfoPanel.gameObject.SetActive(false);
			base.uiBehaviour.m_SettingPanel.gameObject.SetActive(false);
			base.uiBehaviour.m_PushPanel.gameObject.SetActive(false);
			this.m_DetailHandler.CloseUI();
		}

		public void ShowUserInfoPanel()
		{
			base.uiBehaviour.m_InfoTab.bChecked = true;
			this.CloseAllPanel();
			base.uiBehaviour.m_UserInfoPanel.gameObject.SetActive(true);
			bool flag = XSingleton<XClientNetwork>.singleton.AccountType == LoginType.LGOIN_WECHAT_PF && XSingleton<PDatabase>.singleton.playerInfo != null && XSingleton<PDatabase>.singleton.playerInfo.data.nickName != null;
			if (flag)
			{
				bool flag2 = XSingleton<PDatabase>.singleton.playerInfo.data.nickName.Length <= 8;
				if (flag2)
				{
					base.uiBehaviour.m_Account.InputText = XSingleton<PDatabase>.singleton.playerInfo.data.nickName;
				}
				else
				{
					string arg = XSingleton<PDatabase>.singleton.playerInfo.data.nickName.Substring(0, 6);
					base.uiBehaviour.m_Account.InputText = string.Format("{0}...", arg);
				}
			}
			else
			{
				base.uiBehaviour.m_Account.InputText = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
			}
			base.uiBehaviour.m_Tq.SetSprite(XWelfareDocument.GetSelfMemberPrivilegeIconName());
			base.uiBehaviour.m_UID.SetText(string.Format("UID {0}", XSingleton<XAttributeMgr>.singleton.XPlayerData.ShortId.ToString()));
			base.uiBehaviour.m_Server.SetText(XSingleton<XClientNetwork>.singleton.Server);
			int profID = XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.Profession);
			base.uiBehaviour.m_Portrait.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(profID));
			bool flag3 = XSingleton<PDatabase>.singleton.playerInfo != null;
			if (flag3)
			{
				string pictureLarge = XSingleton<PDatabase>.singleton.playerInfo.data.pictureLarge;
				XSingleton<XUICacheImage>.singleton.Load(pictureLarge, this.m_uiBehaviour.m_PortraitTex, this.m_uiBehaviour);
			}
			else
			{
				XSingleton<XUICacheImage>.singleton.Load(string.Empty, this.m_uiBehaviour.m_PortraitTex, this.m_uiBehaviour);
			}
			this.LoignType();
			base.uiBehaviour.m_Level.SetText(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level.ToString());
			ulong exp = XSingleton<XAttributeMgr>.singleton.XPlayerData.Exp;
			ulong maxExp = XSingleton<XAttributeMgr>.singleton.XPlayerData.MaxExp;
			base.uiBehaviour.m_ExpNum.SetText(string.Format("{0}/{1}", exp, maxExp));
			base.uiBehaviour.m_ExpBar.value = exp / maxExp;
			uint titleID = XSingleton<XAttributeMgr>.singleton.XPlayerData.TitleID;
			base.uiBehaviour.m_Title.InputText = ((titleID == 0U) ? XSingleton<XStringTable>.singleton.GetString("NONE") : XTitleDocument.GetTitleWithFormat(titleID, ""));
			XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
			base.uiBehaviour.m_Designation.InputText = specificDocument.GetMyCoverDesignation();
			bool flag4 = specificDocument.achieveSurveyInfo == null;
			if (flag4)
			{
				specificDocument.FetchAchieveSurvey();
				base.uiBehaviour.m_AchievementLabel.SetText(string.Format("", new object[0]));
			}
			else
			{
				this.SetAchievementLabel();
			}
			XGuildDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool bInGuild = specificDocument2.bInGuild;
			if (bInGuild)
			{
				base.uiBehaviour.m_GuildIcon.SetSprite(XGuildDocument.GetPortraitName(specificDocument2.BasicData.portraitIndex), "Social/Guild", false);
			}
			else
			{
				base.uiBehaviour.m_GuildIcon.SetSprite("Role_icon_gh", "GameSystem/SysCommon", false);
			}
			string text = this.DealEmptyString(specificDocument2.BasicData.guildName);
			base.uiBehaviour.m_GuildName.SetText(text);
			text = this.DealEmptyString(XGuildDocument.GuildPP.GetPositionName(specificDocument2.Position, false));
			base.uiBehaviour.m_Identity.SetText(string.Format("{0} {1}", XSingleton<XStringTable>.singleton.GetString("OPTION_IDENTITY"), text));
			this.ShowQQVipInfo();
			this.ShowQQWXGameCenterLaunchInfo();
			XMilitaryRankDocument specificDocument3 = XDocuments.GetSpecificDocument<XMilitaryRankDocument>(XMilitaryRankDocument.uuID);
			MilitaryRankByExploit.RowData byMilitaryRank = specificDocument3.MilitaryReader.GetByMilitaryRank(specificDocument3.MyMilitaryRecord.military_rank);
			bool flag5 = byMilitaryRank != null;
			if (flag5)
			{
				base.uiBehaviour.m_MilitaryIcon.spriteName = byMilitaryRank.Icon;
				base.uiBehaviour.m_MilitaryName.SetText(byMilitaryRank.Name);
			}
		}

		public void ShowQQVipInfo()
		{
			QQVipInfoClient qqvipInfo = XPlatformAbilityDocument.Doc.QQVipInfo;
			bool flag = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_QQVIP);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("[XOptionsView] FunctionId_QQVip open", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			bool flag2 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_QQVIP) && qqvipInfo != null;
			if (flag2)
			{
				bool flag3 = Application.platform == (RuntimePlatform)11;
				if (flag3)
				{
					base.uiBehaviour.m_QQOpenVipBtn.SetVisible(true);
					IXUILabel ixuilabel = base.uiBehaviour.m_QQOpenVipBtn.gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel;
					bool flag4 = !qqvipInfo.is_vip;
					if (flag4)
					{
						ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString("QQVIP_OPEN_QQVIP"));
					}
					else
					{
						bool flag5 = qqvipInfo.is_vip && !qqvipInfo.is_svip;
						if (flag5)
						{
							ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString("QQVIP_OPEN_SVIP"));
						}
						else
						{
							bool is_svip = qqvipInfo.is_svip;
							if (is_svip)
							{
								ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString("QQVIP_RENEW_SVIP"));
							}
						}
					}
				}
				else
				{
					base.uiBehaviour.m_QQOpenVipBtn.SetVisible(false);
				}
				base.uiBehaviour.m_QQVipIcon.SetActive(qqvipInfo.is_vip && !qqvipInfo.is_svip);
				base.uiBehaviour.m_QQSVipIcon.SetActive(qqvipInfo.is_svip);
			}
			else
			{
				base.uiBehaviour.m_QQVipIcon.SetActive(false);
				base.uiBehaviour.m_QQSVipIcon.SetActive(false);
				base.uiBehaviour.m_QQOpenVipBtn.SetVisible(false);
			}
		}

		public void ShowQQWXGameCenterLaunchInfo()
		{
			bool flag = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Platform_StartPrivilege);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("[XOptionsView] FunctionId_StartPrivilege open", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			StartUpType launchTypeServerInfo = XSingleton<XLoginDocument>.singleton.GetLaunchTypeServerInfo();
			bool flag2 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Platform_StartPrivilege) && launchTypeServerInfo == StartUpType.StartUp_QQ;
			if (flag2)
			{
				base.uiBehaviour.m_QQGameCenter.SetVisible(true);
			}
			else
			{
				base.uiBehaviour.m_QQGameCenter.SetVisible(false);
			}
			bool flag3 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Platform_StartPrivilege) && launchTypeServerInfo == StartUpType.StartUp_WX;
			if (flag3)
			{
				base.uiBehaviour.m_WXGameCenter.SetVisible(true);
			}
			else
			{
				base.uiBehaviour.m_WXGameCenter.SetVisible(false);
			}
		}

		public void ShowSettingPanel()
		{
			base.uiBehaviour.m_OptionTab.bChecked = true;
			this.CloseAllPanel();
			base.uiBehaviour.m_SettingPanel.gameObject.SetActive(true);
			base.uiBehaviour.m_GameSound.bChecked = Convert.ToBoolean(this._doc.GetValue(XOptionsDefine.OD_SOUND));
			base.uiBehaviour.m_GameMusic.bChecked = Convert.ToBoolean(this._doc.GetValue(XOptionsDefine.OD_MUSIC));
			base.uiBehaviour.m_GameVoice.bChecked = Convert.ToBoolean(this._doc.GetValue(XOptionsDefine.OD_VOICE));
			base.uiBehaviour.m_Flowerrain.bChecked = Convert.ToBoolean(this._doc.GetValue(XOptionsDefine.OD_FLOWERRAIN));
			base.uiBehaviour.m_Radio.bChecked = Convert.ToBoolean(this._doc.GetValue(XOptionsDefine.OD_RADIO));
			base.uiBehaviour.m_3DTouch.bChecked = Convert.ToBoolean(this._doc.GetValue(XOptionsDefine.OD_3D_TOUCH));
			base.uiBehaviour.m_3DTouch.gameObject.SetActive(this._doc.IsShow3DTouch());
			base.uiBehaviour.m_GameVolume.bChecked = Convert.ToBoolean(this._doc.GetValue(XOptionsDefine.OD_VOLUME));
			base.uiBehaviour.m_RadioWifi.bChecked = Convert.ToBoolean(this._doc.GetValue(XOptionsDefine.OD_RADIO_WIFI));
			base.uiBehaviour.m_RadioTeam.bChecked = Convert.ToBoolean(this._doc.GetValue(XOptionsDefine.OD_RADIO_TEAM));
			base.uiBehaviour.m_RadioPrivate.bChecked = Convert.ToBoolean(this._doc.GetValue(XOptionsDefine.OD_RADIO_PRIVATE));
			base.uiBehaviour.m_RadioPublic.bChecked = Convert.ToBoolean(this._doc.GetValue(XOptionsDefine.OD_RADIO_PUBLIC));
			base.uiBehaviour.m_RadioWorld.bChecked = Convert.ToBoolean(this._doc.GetValue(XOptionsDefine.OD_RADIO_WORLD));
			base.uiBehaviour.m_RadioAutoPlay.bChecked = Convert.ToBoolean(this._doc.GetValue(XOptionsDefine.OD_RADIO_AUTO_PALY));
			base.uiBehaviour.m_Smooth.bChecked = Convert.ToBoolean(this._doc.GetValue(XOptionsDefine.OD_SMOOTH));
			int value = this._doc.GetValue(XOptionsDefine.OD_RESOLUTION);
			XQualitySetting.EResolution eresolution = (XQualitySetting.EResolution)value;
			bool flag = eresolution == XQualitySetting.EResolution.EHeigh;
			if (flag)
			{
				base.uiBehaviour.m_ResolutionHigh.bChecked = true;
			}
			else
			{
				bool flag2 = eresolution == XQualitySetting.EResolution.ENormal;
				if (flag2)
				{
					base.uiBehaviour.m_ResolutionNormal.bChecked = true;
				}
				else
				{
					bool flag3 = eresolution == XQualitySetting.EResolution.ELow;
					if (flag3)
					{
						base.uiBehaviour.m_ResolutionLow.bChecked = true;
					}
					else
					{
						base.uiBehaviour.m_ResolutionHigh.bChecked = true;
					}
				}
			}
			int value2 = this._doc.GetValue(XOptionsDefine.OD_QUALITY);
			XQualitySetting.ESetting esetting = (XQualitySetting.ESetting)value2;
			bool flag4 = esetting == XQualitySetting.ESetting.ELow;
			if (flag4)
			{
				base.uiBehaviour.m_LowPress.bChecked = true;
				base.uiBehaviour.m_LowPress2.bChecked = true;
			}
			else
			{
				bool flag5 = esetting == XQualitySetting.ESetting.ENormal;
				if (flag5)
				{
					base.uiBehaviour.m_MidPress.bChecked = true;
					base.uiBehaviour.m_MidPress2.bChecked = true;
				}
				else
				{
					bool flag6 = esetting == XQualitySetting.ESetting.EHeigh;
					if (flag6)
					{
						base.uiBehaviour.m_HighPress.bChecked = true;
						base.uiBehaviour.m_HighPress2.bChecked = true;
					}
					else
					{
						bool flag7 = esetting == XQualitySetting.ESetting.EVeryHeigh;
						if (flag7)
						{
							base.uiBehaviour.m_SuperHighPress.bChecked = true;
						}
						else
						{
							base.uiBehaviour.m_HighPress.bChecked = true;
						}
					}
				}
			}
			int num;
			int num2;
			XQualitySetting.GetDefalutVisibleRoleCount(out num, out num2);
			base.uiBehaviour.m_SameScreenMinT.SetText(num.ToString());
			base.uiBehaviour.m_SameScreenMaxT.SetText(num2.ToString());
			base.uiBehaviour.m_SameScreenBar.value = Mathf.InverseLerp(0f, (float)XQualitySetting.veryHighLevel, (float)this._doc.GetValue(XOptionsDefine.OD_SAMESCREENNUM));
			base.uiBehaviour.m_SoundBar.value = Mathf.Clamp01((float)this._doc.GetValue(XOptionsDefine.BA_SOUND) / 100f);
			base.uiBehaviour.m_MusicBar.value = Mathf.Clamp01((float)this._doc.GetValue(XOptionsDefine.BA_MUSIC) / 100f);
			base.uiBehaviour.m_VoiceBar.value = Mathf.Clamp01((float)this._doc.GetValue(XOptionsDefine.BA_VOICE) / 100f);
		}

		public void ShowCameraPanel()
		{
			base.uiBehaviour.m_CameraTab.bChecked = true;
			this.CloseAllPanel();
			this.m_DetailHandler.ShowUI(OptionsBattleTab.CameraTab);
		}

		public void ShowPushPanel()
		{
			base.uiBehaviour.m_PushTab.bChecked = true;
			this.CloseAllPanel();
			base.uiBehaviour.m_PushPanel.gameObject.SetActive(true);
			base.uiBehaviour.m_PushWrapContent.SetContentCount(XOptionsDocument._pushSetting1.Count, false);
			base.uiBehaviour.m_PushWrapContent2.SetContentCount(XOptionsDocument._pushSetting2.Count, false);
		}

		private void PushItemUpdate1(Transform t, int index)
		{
			IXUILabel ixuilabel = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = t.Find("Date").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = t.Find("Time").GetComponent("XUILabel") as IXUILabel;
			IXUICheckBox ixuicheckBox = t.Find("toggle").GetComponent("XUICheckBox") as IXUICheckBox;
			List<PushSetting.RowData> pushSetting = XOptionsDocument._pushSetting1;
			bool flag = index < pushSetting.Count;
			if (flag)
			{
				PushSetting.RowData rowData = pushSetting[index];
				ixuilabel.SetText(rowData.ConfigName);
				ixuilabel2.SetText(string.IsNullOrEmpty(rowData.WeekDay) ? string.Empty : XStringDefineProxy.GetString(rowData.WeekDay.ToString()));
				ixuilabel3.SetText(rowData.Time);
				ixuicheckBox.bChecked = Convert.ToBoolean(this._doc.GetPushValue(rowData.ConfigKey));
				ixuicheckBox.ID = (ulong)rowData.Type;
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnPushToggleClick));
			}
		}

		public void PushItemUpdate2(Transform t, int index)
		{
			IXUILabel ixuilabel = t.Find("Label").GetComponent("XUILabel") as IXUILabel;
			IXUICheckBox ixuicheckBox = t.GetComponent("XUICheckBox") as IXUICheckBox;
			List<PushSetting.RowData> pushSetting = XOptionsDocument._pushSetting2;
			bool flag = index < pushSetting.Count;
			if (flag)
			{
				PushSetting.RowData rowData = pushSetting[index];
				ixuilabel.SetText(rowData.ConfigName);
				ixuicheckBox.bChecked = Convert.ToBoolean(this._doc.GetPushValue(rowData.ConfigKey));
				ixuicheckBox.ID = (ulong)rowData.Type;
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnPushToggleClick));
			}
		}

		private bool OnPushToggleClick(IXUICheckBox box)
		{
			PushSetting.RowData[] table = XOptionsDocument._pushSettingTable.Table;
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = (ulong)table[i].Type == box.ID;
				if (flag)
				{
					this._doc.SavePushValue(table[i].ConfigKey, box.bChecked ? 1 : 0);
					this._bDirty = true;
				}
			}
			return true;
		}

		public bool _ChangeNameClicked(IXUIButton btn)
		{
			DlgBase<RenameDlg, RenameBehaviour>.singleton.ShowRenameSystem(XRenameDocument.RenameType.PLAYER_NAME_COST);
			return true;
		}

		public void ShowBasePanel()
		{
			this.ShowSettingPanel();
			base.uiBehaviour.m_SettingPanelScrollView.SetPosition(0f);
		}

		public void ShowNotifyPanel()
		{
			this.ShowSettingPanel();
			base.uiBehaviour.m_SettingPanelScrollView.SetPosition(0f);
		}

		public void ShowVoicePanel()
		{
			this.ShowSettingPanel();
			base.uiBehaviour.m_SettingPanelScrollView.SetPosition(1f);
		}

		public void ShowDisplayPanel()
		{
			this.ShowSettingPanel();
			base.uiBehaviour.m_SettingPanelScrollView.SetPosition(0f);
		}

		private void LoignType()
		{
			base.uiBehaviour.m_Wechat.gameObject.SetActive(false);
			base.uiBehaviour.m_Guest.gameObject.SetActive(false);
		}

		public void SetVolume(int value)
		{
			bool bChecked = value == 1;
			base.uiBehaviour.m_RadioWifi.bChecked = bChecked;
			base.uiBehaviour.m_RadioTeam.bChecked = bChecked;
			base.uiBehaviour.m_RadioPrivate.bChecked = bChecked;
			base.uiBehaviour.m_RadioPublic.bChecked = bChecked;
			base.uiBehaviour.m_RadioWorld.bChecked = bChecked;
			base.uiBehaviour.m_RadioAutoPlay.bChecked = bChecked;
			bool flag = this._doc.SetValue(XOptionsDefine.OD_RADIO_WIFI, value, false);
			if (flag)
			{
				this._bDirty = true;
			}
			bool flag2 = this._doc.SetValue(XOptionsDefine.OD_RADIO_TEAM, value, false);
			if (flag2)
			{
				this._bDirty = true;
			}
			bool flag3 = this._doc.SetValue(XOptionsDefine.OD_RADIO_CAMP, value, false);
			if (flag3)
			{
				this._bDirty = true;
			}
			bool flag4 = this._doc.SetValue(XOptionsDefine.OD_RADIO_PRIVATE, value, false);
			if (flag4)
			{
				this._bDirty = true;
			}
			bool flag5 = this._doc.SetValue(XOptionsDefine.OD_RADIO_PUBLIC, value, false);
			if (flag5)
			{
				this._bDirty = true;
			}
			bool flag6 = this._doc.SetValue(XOptionsDefine.OD_RADIO_WORLD, value, false);
			if (flag6)
			{
				this._bDirty = true;
			}
			bool flag7 = this._doc.SetValue(XOptionsDefine.OD_RADIO_AUTO_PALY, value, false);
			if (flag7)
			{
				this._bDirty = true;
			}
		}

		private bool _SingleCheckBoxChanged(IXUICheckBox iXUICheckBox)
		{
			XOptionsDefine option = (XOptionsDefine)iXUICheckBox.ID;
			bool flag = this._doc.SetValue(option, Convert.ToInt32(iXUICheckBox.bChecked), false);
			if (flag)
			{
				this._bDirty = true;
			}
			return true;
		}

		private bool _ResolutionCheckBoxChanged(IXUICheckBox iXUICheckBox)
		{
			bool flag = !iXUICheckBox.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this._doc.SetValue(XOptionsDefine.OD_RESOLUTION, (int)iXUICheckBox.ID, false);
				if (flag2)
				{
					this._bDirty = true;
				}
				result = true;
			}
			return result;
		}

		private bool _QualityCheckBoxChanged(IXUICheckBox iXUICheckBox)
		{
			bool flag = !iXUICheckBox.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this._doc.SetValue(XOptionsDefine.OD_QUALITY, (int)iXUICheckBox.ID, false);
				if (flag2)
				{
					this._bDirty = true;
				}
				result = true;
			}
			return result;
		}

		private bool _ViewCheckBoxChanged(IXUICheckBox iXUICheckBox)
		{
			bool flag = !iXUICheckBox.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this._doc.SetValue(XOptionsDefine.OD_VIEW, (int)iXUICheckBox.ID, false);
				if (flag2)
				{
					this._bDirty = true;
				}
				result = true;
			}
			return result;
		}

		private bool _SwitchCharClicked(IXUIButton iButton)
		{
			this._doc.ReqSwitchChar();
			return true;
		}

		private bool _SwitchAccountClicked(IXUIButton iButton)
		{
			this._doc.ReqSwitchAccount();
			return true;
		}

		private bool _CustomerServiceClicked(IXUIButton iButton)
		{
			this._doc.OpenCustomerService();
			return true;
		}

		private bool _GameAnnouncementClicked(IXUIButton iButton)
		{
			return true;
		}

		private bool _GameGuideClicked(IXUIButton iButton)
		{
			this._doc.OpenURL(XSingleton<XGlobalConfig>.singleton.GetValue("GameGuide"));
			return true;
		}

		private bool _GameForumClicked(IXUIButton iButton)
		{
			string openID = XSingleton<XClientNetwork>.singleton.OpenID;
			string openKey = XSingleton<XClientNetwork>.singleton.OpenKey;
			string appId = XSingleton<XClientNetwork>.singleton.AppId;
			string areaId = XSingleton<XClientNetwork>.singleton.AreaId;
			bool flag = openID == null || openKey == null || appId == null || areaId == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				byte[] bytes = Encoding.Default.GetBytes(string.Concat(new string[]
				{
					openID,
					",",
					openKey,
					",",
					appId,
					",",
					areaId
				}));
				string arg = Convert.ToBase64String(bytes);
				string url = string.Format(XSingleton<XGlobalConfig>.singleton.GetValue("Feedback"), arg, openID, areaId);
				this._doc.OpenURL(url);
				result = true;
			}
			return result;
		}

		private bool _FeedbackClicked(IXUIButton iButton)
		{
			this._doc.OpenURL(XSingleton<XGlobalConfig>.singleton.GetValue("Feedback"));
			return true;
		}

		private bool _ServiceTermsClicked(IXUIButton iButton)
		{
			this._doc.OpenURL(XSingleton<XGlobalConfig>.singleton.GetValue("ServiceTerms"));
			return true;
		}

		private bool _ServiceAgreementClicked(IXUIButton iButton)
		{
			this._doc.OpenURL(XSingleton<XGlobalConfig>.singleton.GetValue("ServiceAgreement"));
			return true;
		}

		private bool _PrivacyTermsClicked(IXUIButton iButton)
		{
			this._doc.OpenURL(XSingleton<XGlobalConfig>.singleton.GetValue("PrivacyTerms"));
			return true;
		}

		private bool _VipBtnClicked(IXUIButton iButton)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_VIP, 0UL);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool _PersonalCareerBtnClicked(IXUIButton iButton)
		{
			this.SetVisibleWithAnimation(false, null);
			DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		private void _OnWechatPrivilegeClicked(IXUISprite iSp)
		{
		}

		private void _OnQQPrivilegeClicked(IXUISprite iSp)
		{
		}

		private void _OnGuestPrivilegeClicked(IXUISprite iSp)
		{
		}

		private bool _RankBtnClicked(IXUIButton iButton)
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Title);
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TITLE_NOOPEN"), "fece00");
			}
			else
			{
				XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Title, 0UL);
				this.SetVisibleWithAnimation(false, null);
			}
			return true;
		}

		private bool _TitleBtnClicked(IXUIButton iButton)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Design_Designation, 0UL);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool _AchievementBtnClicked(IXUIButton iButton)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SKYCITY_WAITING;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("NO_CAN_ENTER"), "fece00");
				result = false;
			}
			else
			{
				XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Design_Achieve, 0UL);
				this.SetVisibleWithAnimation(false, null);
				result = true;
			}
			return result;
		}

		public void SameScreenNumChange(float value)
		{
			int num;
			int num2;
			XQualitySetting.GetDefalutVisibleRoleCount(out num, out num2);
			int value2 = (int)(Mathf.Lerp(0f, (float)XQualitySetting.veryHighLevel, value) + 0.001f);
			int num3 = (int)(Mathf.Lerp((float)num, (float)num2, value) + 0.001f);
			base.uiBehaviour.m_SameScreenNum.SetText(num3.ToString());
			this._doc.SetValue(XOptionsDefine.OD_SAMESCREENNUM, value2, false);
			this._bDirty = true;
		}

		private string DealEmptyString(string str)
		{
			bool flag = string.IsNullOrEmpty(str);
			if (flag)
			{
				str = XSingleton<XStringTable>.singleton.GetString("NONE");
			}
			return str;
		}

		public void SetAchievementLabel()
		{
			XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
			base.uiBehaviour.m_AchievementLabel.SetText(string.Format("{0}/{1}", specificDocument.achieveSurveyInfo.achievePoint, specificDocument.achieveSurveyInfo.maxAchievePoint));
		}

		private XOptionsDocument _doc = null;

		public Action OnOptionClose;

		private OptionsTab m_CurrentTab;

		private bool _bDirty = false;

		public OptionsTab prefabTab = OptionsTab.InfoTab;

		private XOptionsBattleDetailHandler m_DetailHandler;
	}
}
