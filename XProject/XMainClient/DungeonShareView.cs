using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C92 RID: 3218
	internal class DungeonShareView : DlgBase<DungeonShareView, DungeonShareBehavior>
	{
		// Token: 0x17003229 RID: 12841
		// (get) Token: 0x0600B5C3 RID: 46531 RVA: 0x0023F768 File Offset: 0x0023D968
		public override string fileName
		{
			get
			{
				return "Battle/DungeonShareDlg";
			}
		}

		// Token: 0x1700322A RID: 12842
		// (get) Token: 0x0600B5C4 RID: 46532 RVA: 0x0023F780 File Offset: 0x0023D980
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700322B RID: 12843
		// (get) Token: 0x0600B5C5 RID: 46533 RVA: 0x0023F794 File Offset: 0x0023D994
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B5C6 RID: 46534 RVA: 0x0023F7A7 File Offset: 0x0023D9A7
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600B5C7 RID: 46535 RVA: 0x0023F7B1 File Offset: 0x0023D9B1
		protected override void OnUnload()
		{
			this.ResetTimer();
			base.OnUnload();
		}

		// Token: 0x0600B5C8 RID: 46536 RVA: 0x0023F7C2 File Offset: 0x0023D9C2
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		// Token: 0x0600B5C9 RID: 46537 RVA: 0x0023F7D4 File Offset: 0x0023D9D4
		protected override void OnHide()
		{
			this.ResetTimer();
			XScreenShotShareDocument specificDocument = XDocuments.GetSpecificDocument<XScreenShotShareDocument>(XScreenShotShareDocument.uuID);
			specificDocument.SpriteID = 0U;
			specificDocument.CurShareBgType = ShareBgType.NoneType;
			bool flag = this._hideMaqueeView && DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				this._hideMaqueeView = false;
				DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetAlpha(1f);
			}
			base.OnHide();
		}

		// Token: 0x0600B5CA RID: 46538 RVA: 0x0023F83C File Offset: 0x0023DA3C
		private void ResetTimer()
		{
			bool flag = this._token > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
			}
			this._token = 0U;
		}

		// Token: 0x0600B5CB RID: 46539 RVA: 0x0023F870 File Offset: 0x0023DA70
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour._shareBtn.SetAlpha(1f);
			base.uiBehaviour._closeBtn.gameObject.SetActive(true);
			base.uiBehaviour._firstLabel.gameObject.SetActive(true);
			this.ResetPlatformShareBtnState();
			this.RefreshShareContent();
			this.RefreshPersonalInfo();
		}

		// Token: 0x0600B5CC RID: 46540 RVA: 0x0023F8E0 File Offset: 0x0023DAE0
		private void InitProperties()
		{
			base.uiBehaviour._shareBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickShareBtn));
			base.uiBehaviour._wechat_SpecialTarget.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnclickWcSpecialShare));
			base.uiBehaviour._wechat_ZoneTarget.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnclickWcZoneShare));
			base.uiBehaviour._QQ_specialTarget.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnclickQQSpecialShare));
			base.uiBehaviour._QQ_ZoneTarget.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnclickQQZoneShare));
			base.uiBehaviour._closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnclickClose));
			base.uiBehaviour._noteLabel.SetText("");
		}

		// Token: 0x0600B5CD RID: 46541 RVA: 0x0023F9B4 File Offset: 0x0023DBB4
		private bool OnclickClose(IXUIButton button)
		{
			this.ResetData();
			this.SetVisibleWithAnimation(false, null);
			bool flag = DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.RefreshTopUI();
			}
			return true;
		}

		// Token: 0x0600B5CE RID: 46542 RVA: 0x0023F9F0 File Offset: 0x0023DBF0
		private bool OnclickQQZoneShare(IXUIButton button)
		{
			XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.DungeonShare);
			XSingleton<XScreenShotMgr>.singleton.ShareScreen(false);
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600B5CF RID: 46543 RVA: 0x0023FA28 File Offset: 0x0023DC28
		private bool OnclickQQSpecialShare(IXUIButton button)
		{
			XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.DungeonShare);
			XSingleton<XScreenShotMgr>.singleton.ShareScreen(true);
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600B5D0 RID: 46544 RVA: 0x0023FA60 File Offset: 0x0023DC60
		private bool OnclickWcZoneShare(IXUIButton button)
		{
			XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.DungeonShare);
			XSingleton<XScreenShotMgr>.singleton.ShareScreen(false);
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600B5D1 RID: 46545 RVA: 0x0023FA98 File Offset: 0x0023DC98
		private bool OnclickWcSpecialShare(IXUIButton button)
		{
			XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.DungeonShare);
			XSingleton<XScreenShotMgr>.singleton.ShareScreen(true);
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600B5D2 RID: 46546 RVA: 0x0023FAD0 File Offset: 0x0023DCD0
		private bool OnClickShareBtn(IXUIButton button)
		{
			bool flag = XSingleton<UiUtility>.singleton.CheckPlatfomStatus();
			if (flag)
			{
				base.uiBehaviour._wechatShare.gameObject.SetActive(false);
				base.uiBehaviour._QQShare.gameObject.SetActive(false);
				base.uiBehaviour._shareBtn.SetAlpha(0f);
				base.uiBehaviour._closeBtn.gameObject.SetActive(false);
				bool flag2 = DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetAlpha(0f);
					this._hideMaqueeView = true;
				}
				base.uiBehaviour._firstLabel.gameObject.SetActive(false);
				this._token = XSingleton<XTimerMgr>.singleton.SetTimer(0.2f, new XTimerMgr.ElapsedEventHandler(this.ResetShareBtn), null);
				XSingleton<XScreenShotMgr>.singleton.CaptureScreenshot(null);
			}
			return true;
		}

		// Token: 0x0600B5D3 RID: 46547 RVA: 0x0023FBC0 File Offset: 0x0023DDC0
		private void ResetShareBtn(object param)
		{
			base.uiBehaviour._shareBtn.SetAlpha(1f);
			base.uiBehaviour._closeBtn.gameObject.SetActive(true);
			base.uiBehaviour._firstLabel.gameObject.SetActive(true);
			bool flag = this._hideMaqueeView && DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				this._hideMaqueeView = false;
				DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetAlpha(1f);
			}
			this.RefreshPlatformShareBtnState();
			this._token = 0U;
		}

		// Token: 0x0600B5D4 RID: 46548 RVA: 0x0023FC54 File Offset: 0x0023DE54
		private void RefreshPlatformShareBtnState()
		{
			base.uiBehaviour._QQShare.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
			base.uiBehaviour._QQ_ZoneTarget.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
			base.uiBehaviour._QQ_specialTarget.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
			base.uiBehaviour._wechatShare.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
			base.uiBehaviour._wechat_SpecialTarget.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
			base.uiBehaviour._wechat_ZoneTarget.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
		}

		// Token: 0x0600B5D5 RID: 46549 RVA: 0x0023FD34 File Offset: 0x0023DF34
		private void ResetPlatformShareBtnState()
		{
			base.uiBehaviour._logoQQ.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
			base.uiBehaviour._logoWechat.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
			base.uiBehaviour._wechatShare.gameObject.SetActive(false);
			base.uiBehaviour._QQShare.gameObject.SetActive(false);
		}

		// Token: 0x0600B5D6 RID: 46550 RVA: 0x0023FDB8 File Offset: 0x0023DFB8
		private void RefreshSharePlatform()
		{
			bool flag = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ;
			if (flag)
			{
				base.uiBehaviour._QQShare.gameObject.SetActive(true);
				base.uiBehaviour._logoQQ.gameObject.SetActive(true);
				base.uiBehaviour._logoWechat.gameObject.SetActive(false);
				base.uiBehaviour._wechatShare.gameObject.SetActive(false);
			}
			else
			{
				bool flag2 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat;
				if (flag2)
				{
					base.uiBehaviour._wechatShare.gameObject.SetActive(true);
					base.uiBehaviour._logoWechat.gameObject.SetActive(true);
					base.uiBehaviour._logoQQ.gameObject.SetActive(false);
					base.uiBehaviour._QQShare.gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x0600B5D7 RID: 46551 RVA: 0x0023FEA6 File Offset: 0x0023E0A6
		private void RefreshPersonalInfo()
		{
			base.uiBehaviour._nameLabel.SetText(XSingleton<XAttributeMgr>.singleton.XPlayerData.Name);
			base.uiBehaviour._serverLabel.SetText(XSingleton<XClientNetwork>.singleton.Server);
		}

		// Token: 0x0600B5D8 RID: 46552 RVA: 0x0023FEE4 File Offset: 0x0023E0E4
		private void RefreshShareContent()
		{
			XScreenShotShareDocument specificDocument = XDocuments.GetSpecificDocument<XScreenShotShareDocument>(XScreenShotShareDocument.uuID);
			XTuple<string, string> shareBgTexturePath = specificDocument.GetShareBgTexturePath();
			bool flag = !string.IsNullOrEmpty(shareBgTexturePath.Item1);
			if (flag)
			{
				base.uiBehaviour._bgTexture.SetTexturePath("atlas/UI/common/Pic/" + shareBgTexturePath.Item1);
			}
			XAchievementDocument specificDocument2 = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
			bool flag2 = specificDocument2.FirstPassSceneID != 0U && specificDocument.CurShareBgType == ShareBgType.DungeonType;
			if (flag2)
			{
				base.uiBehaviour._bgText.gameObject.SetActive(true);
				base.uiBehaviour._bgText.SetSprite(shareBgTexturePath.Item2);
				base.uiBehaviour._firstLabel.gameObject.SetActive(true);
			}
			else
			{
				base.uiBehaviour._bgText.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600B5D9 RID: 46553 RVA: 0x0023FFC0 File Offset: 0x0023E1C0
		private void ResetData()
		{
			XAchievementDocument specificDocument = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
			specificDocument.FirstPassSceneID = 0U;
			XScreenShotShareDocument specificDocument2 = XDocuments.GetSpecificDocument<XScreenShotShareDocument>(XScreenShotShareDocument.uuID);
			specificDocument2.SpriteID = 0U;
			specificDocument2.CurShareBgType = ShareBgType.NoneType;
		}

		// Token: 0x0600B5DA RID: 46554 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void RefreshShareResult(string result)
		{
		}

		// Token: 0x0400473A RID: 18234
		private uint _token;

		// Token: 0x0400473B RID: 18235
		private bool _hideMaqueeView = false;
	}
}
