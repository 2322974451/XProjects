using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class DungeonShareView : DlgBase<DungeonShareView, DungeonShareBehavior>
	{

		public override string fileName
		{
			get
			{
				return "Battle/DungeonShareDlg";
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnUnload()
		{
			this.ResetTimer();
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

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

		private void ResetTimer()
		{
			bool flag = this._token > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
			}
			this._token = 0U;
		}

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

		private bool OnclickQQZoneShare(IXUIButton button)
		{
			XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.DungeonShare);
			XSingleton<XScreenShotMgr>.singleton.ShareScreen(false);
			this.SetVisible(false, true);
			return true;
		}

		private bool OnclickQQSpecialShare(IXUIButton button)
		{
			XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.DungeonShare);
			XSingleton<XScreenShotMgr>.singleton.ShareScreen(true);
			this.SetVisible(false, true);
			return true;
		}

		private bool OnclickWcZoneShare(IXUIButton button)
		{
			XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.DungeonShare);
			XSingleton<XScreenShotMgr>.singleton.ShareScreen(false);
			this.SetVisible(false, true);
			return true;
		}

		private bool OnclickWcSpecialShare(IXUIButton button)
		{
			XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.DungeonShare);
			XSingleton<XScreenShotMgr>.singleton.ShareScreen(true);
			this.SetVisible(false, true);
			return true;
		}

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

		private void RefreshPlatformShareBtnState()
		{
			base.uiBehaviour._QQShare.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
			base.uiBehaviour._QQ_ZoneTarget.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
			base.uiBehaviour._QQ_specialTarget.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
			base.uiBehaviour._wechatShare.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
			base.uiBehaviour._wechat_SpecialTarget.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
			base.uiBehaviour._wechat_ZoneTarget.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
		}

		private void ResetPlatformShareBtnState()
		{
			base.uiBehaviour._logoQQ.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
			base.uiBehaviour._logoWechat.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
			base.uiBehaviour._wechatShare.gameObject.SetActive(false);
			base.uiBehaviour._QQShare.gameObject.SetActive(false);
		}

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

		private void RefreshPersonalInfo()
		{
			base.uiBehaviour._nameLabel.SetText(XSingleton<XAttributeMgr>.singleton.XPlayerData.Name);
			base.uiBehaviour._serverLabel.SetText(XSingleton<XClientNetwork>.singleton.Server);
		}

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

		private void ResetData()
		{
			XAchievementDocument specificDocument = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
			specificDocument.FirstPassSceneID = 0U;
			XScreenShotShareDocument specificDocument2 = XDocuments.GetSpecificDocument<XScreenShotShareDocument>(XScreenShotShareDocument.uuID);
			specificDocument2.SpriteID = 0U;
			specificDocument2.CurShareBgType = ShareBgType.NoneType;
		}

		public void RefreshShareResult(string result)
		{
		}

		private uint _token;

		private bool _hideMaqueeView = false;
	}
}
