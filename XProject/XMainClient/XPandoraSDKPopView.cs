using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPandoraSDKPopView : DlgBase<XPandoraSDKPopView, XPandoraSDKPopViewBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Hall/PandoraSDKPopDlg";
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

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool isHideTutorial
		{
			get
			{
				return true;
			}
		}

		public override bool isPopup
		{
			get
			{
				return true;
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			bool flag = XSingleton<XScene>.singleton.GameCamera != null && XSingleton<XScene>.singleton.GameCamera.UnityCamera != null && !XSingleton<XScene>.singleton.GameCamera.UnityCamera.enabled;
			if (flag)
			{
				XSingleton<XScene>.singleton.GameCamera.UnityCamera.enabled = true;
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnUnload()
		{
			XSingleton<XDebug>.singleton.AddLog("XPandoraSDKPopView OnUnload", null, null, null, null, null, XDebugColor.XDebug_None);
			base.OnUnload();
		}

		private void OnCloseClicked(IXUISprite btn)
		{
			XSingleton<XDebug>.singleton.AddLog("XPandoraSDKPopView OnCloseClicked", null, null, null, null, null, XDebugColor.XDebug_None);
			this.SetVisible(false, true);
		}
	}
}
