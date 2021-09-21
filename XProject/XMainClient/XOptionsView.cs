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
	// Token: 0x02000EFD RID: 3837
	internal class XOptionsView : DlgBase<XOptionsView, XOptionsBehaviour>
	{
		// Token: 0x1700357C RID: 13692
		// (get) Token: 0x0600CB7E RID: 52094 RVA: 0x002E7840 File Offset: 0x002E5A40
		public OptionsTab CurrentTab
		{
			get
			{
				return this.m_CurrentTab;
			}
		}

		// Token: 0x1700357D RID: 13693
		// (get) Token: 0x0600CB7F RID: 52095 RVA: 0x002E7858 File Offset: 0x002E5A58
		public override string fileName
		{
			get
			{
				return "GameSystem/SettingDlg";
			}
		}

		// Token: 0x1700357E RID: 13694
		// (get) Token: 0x0600CB80 RID: 52096 RVA: 0x002E7870 File Offset: 0x002E5A70
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700357F RID: 13695
		// (get) Token: 0x0600CB81 RID: 52097 RVA: 0x002E7884 File Offset: 0x002E5A84
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003580 RID: 13696
		// (get) Token: 0x0600CB82 RID: 52098 RVA: 0x002E7898 File Offset: 0x002E5A98
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003581 RID: 13697
		// (get) Token: 0x0600CB83 RID: 52099 RVA: 0x002E78AC File Offset: 0x002E5AAC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003582 RID: 13698
		// (get) Token: 0x0600CB84 RID: 52100 RVA: 0x002E78C0 File Offset: 0x002E5AC0
		public override bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003583 RID: 13699
		// (get) Token: 0x0600CB85 RID: 52101 RVA: 0x002E78D4 File Offset: 0x002E5AD4
		public override bool pushstack
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600CB86 RID: 52102 RVA: 0x002E78E8 File Offset: 0x002E5AE8
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			this._doc.View = this;
			base.uiBehaviour.m_PushWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.PushItemUpdate1));
			base.uiBehaviour.m_PushWrapContent2.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.PushItemUpdate2));
			DlgHandlerBase.EnsureCreate<XOptionsBattleDetailHandler>(ref this.m_DetailHandler, base.uiBehaviour.m_BattlePanel, null, true);
		}

		// Token: 0x0600CB87 RID: 52103 RVA: 0x002E7968 File Offset: 0x002E5B68
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

		// Token: 0x0600CB88 RID: 52104 RVA: 0x002E8134 File Offset: 0x002E6334
		private bool OpenGameSirClick(IXUIButton btn)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("ClickGameSirClick", null, null, null, null, null);
			DlgBase<XGameSirView, XGameSirBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x0600CB89 RID: 52105 RVA: 0x002E816C File Offset: 0x002E636C
		private bool OnPrerogativeBtnClicked(IXUIButton btn)
		{
			DlgBase<XOptionsView, XOptionsBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			DlgBase<PrerogativeDlg, PrerogativeDlgBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x0600CB8A RID: 52106 RVA: 0x002E819C File Offset: 0x002E639C
		private bool OnQQOpenVipBtnClicked(IXUIButton btn)
		{
			DlgBase<XOptionsView, XOptionsBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			XPlatformAbilityDocument.Doc.OpenQQVipRechargeH5();
			return true;
		}

		// Token: 0x0600CB8B RID: 52107 RVA: 0x002E81C7 File Offset: 0x002E63C7
		private void OnQQGameCenterClicked(IXUISprite btn)
		{
			DlgBase<XOptionsView, XOptionsBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			DlgBase<XQQWXGameCenterPrivilegeView, XQQWXGameCenterPrivilegeBehaviour>.singleton.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x0600CB8C RID: 52108 RVA: 0x002E81C7 File Offset: 0x002E63C7
		private void OnWXGameCenterClicked(IXUISprite btn)
		{
			DlgBase<XOptionsView, XOptionsBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			DlgBase<XQQWXGameCenterPrivilegeView, XQQWXGameCenterPrivilegeBehaviour>.singleton.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x0600CB8D RID: 52109 RVA: 0x002E81E4 File Offset: 0x002E63E4
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

		// Token: 0x0600CB8E RID: 52110 RVA: 0x002E82B0 File Offset: 0x002E64B0
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

		// Token: 0x0600CB8F RID: 52111 RVA: 0x002E836C File Offset: 0x002E656C
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XOptionsBattleDetailHandler>(ref this.m_DetailHandler);
			this._doc.View = null;
			base.OnUnload();
		}

		// Token: 0x0600CB90 RID: 52112 RVA: 0x002E8390 File Offset: 0x002E6590
		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600CB91 RID: 52113 RVA: 0x002E83AC File Offset: 0x002E65AC
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

		// Token: 0x0600CB92 RID: 52114 RVA: 0x002E83D8 File Offset: 0x002E65D8
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

		// Token: 0x0600CB93 RID: 52115 RVA: 0x002E8404 File Offset: 0x002E6604
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

		// Token: 0x0600CB94 RID: 52116 RVA: 0x002E8430 File Offset: 0x002E6630
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

		// Token: 0x0600CB95 RID: 52117 RVA: 0x002E845C File Offset: 0x002E665C
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

		// Token: 0x0600CB96 RID: 52118 RVA: 0x002E8488 File Offset: 0x002E6688
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

		// Token: 0x0600CB97 RID: 52119 RVA: 0x002E84B4 File Offset: 0x002E66B4
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

		// Token: 0x0600CB98 RID: 52120 RVA: 0x002E84E0 File Offset: 0x002E66E0
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

		// Token: 0x0600CB99 RID: 52121 RVA: 0x002E850C File Offset: 0x002E670C
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

		// Token: 0x0600CB9A RID: 52122 RVA: 0x002E85C0 File Offset: 0x002E67C0
		private void CloseAllPanel()
		{
			base.uiBehaviour.m_UserInfoPanel.gameObject.SetActive(false);
			base.uiBehaviour.m_SettingPanel.gameObject.SetActive(false);
			base.uiBehaviour.m_PushPanel.gameObject.SetActive(false);
			this.m_DetailHandler.CloseUI();
		}

		// Token: 0x0600CB9B RID: 52123 RVA: 0x002E8620 File Offset: 0x002E6820
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

		// Token: 0x0600CB9C RID: 52124 RVA: 0x002E8AC8 File Offset: 0x002E6CC8
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

		// Token: 0x0600CB9D RID: 52125 RVA: 0x002E8CA0 File Offset: 0x002E6EA0
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

		// Token: 0x0600CB9E RID: 52126 RVA: 0x002E8D8C File Offset: 0x002E6F8C
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

		// Token: 0x0600CB9F RID: 52127 RVA: 0x002E920F File Offset: 0x002E740F
		public void ShowCameraPanel()
		{
			base.uiBehaviour.m_CameraTab.bChecked = true;
			this.CloseAllPanel();
			this.m_DetailHandler.ShowUI(OptionsBattleTab.CameraTab);
		}

		// Token: 0x0600CBA0 RID: 52128 RVA: 0x002E9238 File Offset: 0x002E7438
		public void ShowPushPanel()
		{
			base.uiBehaviour.m_PushTab.bChecked = true;
			this.CloseAllPanel();
			base.uiBehaviour.m_PushPanel.gameObject.SetActive(true);
			base.uiBehaviour.m_PushWrapContent.SetContentCount(XOptionsDocument._pushSetting1.Count, false);
			base.uiBehaviour.m_PushWrapContent2.SetContentCount(XOptionsDocument._pushSetting2.Count, false);
		}

		// Token: 0x0600CBA1 RID: 52129 RVA: 0x002E92B0 File Offset: 0x002E74B0
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

		// Token: 0x0600CBA2 RID: 52130 RVA: 0x002E93DC File Offset: 0x002E75DC
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

		// Token: 0x0600CBA3 RID: 52131 RVA: 0x002E9484 File Offset: 0x002E7684
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

		// Token: 0x0600CBA4 RID: 52132 RVA: 0x002E94F8 File Offset: 0x002E76F8
		public bool _ChangeNameClicked(IXUIButton btn)
		{
			DlgBase<RenameDlg, RenameBehaviour>.singleton.ShowRenameSystem(XRenameDocument.RenameType.PLAYER_NAME_COST);
			return true;
		}

		// Token: 0x0600CBA5 RID: 52133 RVA: 0x002E9517 File Offset: 0x002E7717
		public void ShowBasePanel()
		{
			this.ShowSettingPanel();
			base.uiBehaviour.m_SettingPanelScrollView.SetPosition(0f);
		}

		// Token: 0x0600CBA6 RID: 52134 RVA: 0x002E9517 File Offset: 0x002E7717
		public void ShowNotifyPanel()
		{
			this.ShowSettingPanel();
			base.uiBehaviour.m_SettingPanelScrollView.SetPosition(0f);
		}

		// Token: 0x0600CBA7 RID: 52135 RVA: 0x002E9537 File Offset: 0x002E7737
		public void ShowVoicePanel()
		{
			this.ShowSettingPanel();
			base.uiBehaviour.m_SettingPanelScrollView.SetPosition(1f);
		}

		// Token: 0x0600CBA8 RID: 52136 RVA: 0x002E9517 File Offset: 0x002E7717
		public void ShowDisplayPanel()
		{
			this.ShowSettingPanel();
			base.uiBehaviour.m_SettingPanelScrollView.SetPosition(0f);
		}

		// Token: 0x0600CBA9 RID: 52137 RVA: 0x002E9557 File Offset: 0x002E7757
		private void LoignType()
		{
			base.uiBehaviour.m_Wechat.gameObject.SetActive(false);
			base.uiBehaviour.m_Guest.gameObject.SetActive(false);
		}

		// Token: 0x0600CBAA RID: 52138 RVA: 0x002E9588 File Offset: 0x002E7788
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

		// Token: 0x0600CBAB RID: 52139 RVA: 0x002E96C8 File Offset: 0x002E78C8
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

		// Token: 0x0600CBAC RID: 52140 RVA: 0x002E9708 File Offset: 0x002E7908
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

		// Token: 0x0600CBAD RID: 52141 RVA: 0x002E974C File Offset: 0x002E794C
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

		// Token: 0x0600CBAE RID: 52142 RVA: 0x002E9790 File Offset: 0x002E7990
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

		// Token: 0x0600CBAF RID: 52143 RVA: 0x002E97D8 File Offset: 0x002E79D8
		private bool _SwitchCharClicked(IXUIButton iButton)
		{
			this._doc.ReqSwitchChar();
			return true;
		}

		// Token: 0x0600CBB0 RID: 52144 RVA: 0x002E97F8 File Offset: 0x002E79F8
		private bool _SwitchAccountClicked(IXUIButton iButton)
		{
			this._doc.ReqSwitchAccount();
			return true;
		}

		// Token: 0x0600CBB1 RID: 52145 RVA: 0x002E9818 File Offset: 0x002E7A18
		private bool _CustomerServiceClicked(IXUIButton iButton)
		{
			this._doc.OpenCustomerService();
			return true;
		}

		// Token: 0x0600CBB2 RID: 52146 RVA: 0x002E9838 File Offset: 0x002E7A38
		private bool _GameAnnouncementClicked(IXUIButton iButton)
		{
			return true;
		}

		// Token: 0x0600CBB3 RID: 52147 RVA: 0x002E984C File Offset: 0x002E7A4C
		private bool _GameGuideClicked(IXUIButton iButton)
		{
			this._doc.OpenURL(XSingleton<XGlobalConfig>.singleton.GetValue("GameGuide"));
			return true;
		}

		// Token: 0x0600CBB4 RID: 52148 RVA: 0x002E987C File Offset: 0x002E7A7C
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

		// Token: 0x0600CBB5 RID: 52149 RVA: 0x002E9954 File Offset: 0x002E7B54
		private bool _FeedbackClicked(IXUIButton iButton)
		{
			this._doc.OpenURL(XSingleton<XGlobalConfig>.singleton.GetValue("Feedback"));
			return true;
		}

		// Token: 0x0600CBB6 RID: 52150 RVA: 0x002E9984 File Offset: 0x002E7B84
		private bool _ServiceTermsClicked(IXUIButton iButton)
		{
			this._doc.OpenURL(XSingleton<XGlobalConfig>.singleton.GetValue("ServiceTerms"));
			return true;
		}

		// Token: 0x0600CBB7 RID: 52151 RVA: 0x002E99B4 File Offset: 0x002E7BB4
		private bool _ServiceAgreementClicked(IXUIButton iButton)
		{
			this._doc.OpenURL(XSingleton<XGlobalConfig>.singleton.GetValue("ServiceAgreement"));
			return true;
		}

		// Token: 0x0600CBB8 RID: 52152 RVA: 0x002E99E4 File Offset: 0x002E7BE4
		private bool _PrivacyTermsClicked(IXUIButton iButton)
		{
			this._doc.OpenURL(XSingleton<XGlobalConfig>.singleton.GetValue("PrivacyTerms"));
			return true;
		}

		// Token: 0x0600CBB9 RID: 52153 RVA: 0x002E9A14 File Offset: 0x002E7C14
		private bool _VipBtnClicked(IXUIButton iButton)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_VIP, 0UL);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600CBBA RID: 52154 RVA: 0x002E9A40 File Offset: 0x002E7C40
		private bool _PersonalCareerBtnClicked(IXUIButton iButton)
		{
			this.SetVisibleWithAnimation(false, null);
			DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x0600CBBB RID: 52155 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void _OnWechatPrivilegeClicked(IXUISprite iSp)
		{
		}

		// Token: 0x0600CBBC RID: 52156 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void _OnQQPrivilegeClicked(IXUISprite iSp)
		{
		}

		// Token: 0x0600CBBD RID: 52157 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void _OnGuestPrivilegeClicked(IXUISprite iSp)
		{
		}

		// Token: 0x0600CBBE RID: 52158 RVA: 0x002E9A6C File Offset: 0x002E7C6C
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

		// Token: 0x0600CBBF RID: 52159 RVA: 0x002E9ACC File Offset: 0x002E7CCC
		private bool _TitleBtnClicked(IXUIButton iButton)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Design_Designation, 0UL);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600CBC0 RID: 52160 RVA: 0x002E9AFC File Offset: 0x002E7CFC
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

		// Token: 0x0600CBC1 RID: 52161 RVA: 0x002E9B60 File Offset: 0x002E7D60
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

		// Token: 0x0600CBC2 RID: 52162 RVA: 0x002E9BD4 File Offset: 0x002E7DD4
		private string DealEmptyString(string str)
		{
			bool flag = string.IsNullOrEmpty(str);
			if (flag)
			{
				str = XSingleton<XStringTable>.singleton.GetString("NONE");
			}
			return str;
		}

		// Token: 0x0600CBC3 RID: 52163 RVA: 0x002E9C04 File Offset: 0x002E7E04
		public void SetAchievementLabel()
		{
			XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
			base.uiBehaviour.m_AchievementLabel.SetText(string.Format("{0}/{1}", specificDocument.achieveSurveyInfo.achievePoint, specificDocument.achieveSurveyInfo.maxAchievePoint));
		}

		// Token: 0x04005A6A RID: 23146
		private XOptionsDocument _doc = null;

		// Token: 0x04005A6B RID: 23147
		public Action OnOptionClose;

		// Token: 0x04005A6C RID: 23148
		private OptionsTab m_CurrentTab;

		// Token: 0x04005A6D RID: 23149
		private bool _bDirty = false;

		// Token: 0x04005A6E RID: 23150
		public OptionsTab prefabTab = OptionsTab.InfoTab;

		// Token: 0x04005A6F RID: 23151
		private XOptionsBattleDetailHandler m_DetailHandler;
	}
}
