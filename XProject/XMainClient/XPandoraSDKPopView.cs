using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C61 RID: 3169
	internal class XPandoraSDKPopView : DlgBase<XPandoraSDKPopView, XPandoraSDKPopViewBehaviour>
	{
		// Token: 0x170031B5 RID: 12725
		// (get) Token: 0x0600B37C RID: 45948 RVA: 0x0022F1C0 File Offset: 0x0022D3C0
		public override string fileName
		{
			get
			{
				return "Hall/PandoraSDKPopDlg";
			}
		}

		// Token: 0x170031B6 RID: 12726
		// (get) Token: 0x0600B37D RID: 45949 RVA: 0x0022F1D8 File Offset: 0x0022D3D8
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170031B7 RID: 12727
		// (get) Token: 0x0600B37E RID: 45950 RVA: 0x0022F1EC File Offset: 0x0022D3EC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170031B8 RID: 12728
		// (get) Token: 0x0600B37F RID: 45951 RVA: 0x0022F200 File Offset: 0x0022D400
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170031B9 RID: 12729
		// (get) Token: 0x0600B380 RID: 45952 RVA: 0x0022F214 File Offset: 0x0022D414
		public override bool isHideTutorial
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170031BA RID: 12730
		// (get) Token: 0x0600B381 RID: 45953 RVA: 0x0022F228 File Offset: 0x0022D428
		public override bool isPopup
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B382 RID: 45954 RVA: 0x0022F23B File Offset: 0x0022D43B
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600B383 RID: 45955 RVA: 0x0022F248 File Offset: 0x0022D448
		public override void StackRefresh()
		{
			base.StackRefresh();
			bool flag = XSingleton<XScene>.singleton.GameCamera != null && XSingleton<XScene>.singleton.GameCamera.UnityCamera != null && !XSingleton<XScene>.singleton.GameCamera.UnityCamera.enabled;
			if (flag)
			{
				XSingleton<XScene>.singleton.GameCamera.UnityCamera.enabled = true;
			}
		}

		// Token: 0x0600B384 RID: 45956 RVA: 0x0022F2B6 File Offset: 0x0022D4B6
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600B385 RID: 45957 RVA: 0x0022F2DD File Offset: 0x0022D4DD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B386 RID: 45958 RVA: 0x0022F2E7 File Offset: 0x0022D4E7
		protected override void OnUnload()
		{
			XSingleton<XDebug>.singleton.AddLog("XPandoraSDKPopView OnUnload", null, null, null, null, null, XDebugColor.XDebug_None);
			base.OnUnload();
		}

		// Token: 0x0600B387 RID: 45959 RVA: 0x0022F307 File Offset: 0x0022D507
		private void OnCloseClicked(IXUISprite btn)
		{
			XSingleton<XDebug>.singleton.AddLog("XPandoraSDKPopView OnCloseClicked", null, null, null, null, null, XDebugColor.XDebug_None);
			this.SetVisible(false, true);
		}
	}
}
