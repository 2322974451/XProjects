using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XQQWXGameCenterPrivilegeView : DlgBase<XQQWXGameCenterPrivilegeView, XQQWXGameCenterPrivilegeBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/PlatformAbility/QQWXGameCenterLaunchDlg";
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
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			string[] array = null;
			bool flag = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ;
			if (flag)
			{
				base.uiBehaviour.m_Title.SetText(XSingleton<XStringTable>.singleton.GetString("GAMECENTER_QQ_TITLE"));
				array = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("QQGameCenterLevelReward", XGlobalConfig.SequenceSeparator);
			}
			else
			{
				bool flag2 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat;
				if (flag2)
				{
					base.uiBehaviour.m_Title.SetText(XSingleton<XStringTable>.singleton.GetString("GAMECENTER_WX_TITLE"));
					array = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("WXGameCenterLevelReward", XGlobalConfig.SequenceSeparator);
				}
			}
			int num = (array != null && array.Length == 2) ? int.Parse(array[1]) : 0;
			base.uiBehaviour.m_Privilege1.SetText(XSingleton<XStringTable>.singleton.GetString("GAMECENTER_P1"));
			base.uiBehaviour.m_Privilege2.SetText(XSingleton<XStringTable>.singleton.GetString("GAMECENTER_P2"));
			base.uiBehaviour.m_Privilege3.SetText(XStringDefineProxy.GetString("GAMECENTER_P3", new object[]
			{
				num
			}));
			base.uiBehaviour.m_QQIcon.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
			base.uiBehaviour.m_WXIcon.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
		}

		private bool OnCloseBtnClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}
	}
}
