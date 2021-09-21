using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CAE RID: 3246
	internal class XQQWXGameCenterPrivilegeView : DlgBase<XQQWXGameCenterPrivilegeView, XQQWXGameCenterPrivilegeBehaviour>
	{
		// Token: 0x1700324E RID: 12878
		// (get) Token: 0x0600B6B5 RID: 46773 RVA: 0x00243CB4 File Offset: 0x00241EB4
		public override string fileName
		{
			get
			{
				return "GameSystem/PlatformAbility/QQWXGameCenterLaunchDlg";
			}
		}

		// Token: 0x1700324F RID: 12879
		// (get) Token: 0x0600B6B6 RID: 46774 RVA: 0x00243CCC File Offset: 0x00241ECC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B6B7 RID: 46775 RVA: 0x00243CDF File Offset: 0x00241EDF
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClicked));
		}

		// Token: 0x0600B6B8 RID: 46776 RVA: 0x00243D08 File Offset: 0x00241F08
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

		// Token: 0x0600B6B9 RID: 46777 RVA: 0x00243E6C File Offset: 0x0024206C
		private bool OnCloseBtnClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}
	}
}
