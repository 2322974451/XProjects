using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000A4B RID: 2635
	internal class XDragonGuildApproveBehaviour : DlgBehaviourBase
	{
		// Token: 0x06009FDA RID: 40922 RVA: 0x001A8E68 File Offset: 0x001A7068
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnOneKeyCancel = (base.transform.FindChild("Bg/BtnOneKeyCancel").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnSetting = (base.transform.FindChild("Bg/BtnSetting").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnSendMessage = (base.transform.FindChild("Bg/BtnSendMessage").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_RequiredPPT = (base.transform.FindChild("Bg/PPTRequirement").GetComponent("XUILabel") as IXUILabel);
			this.m_NeedApprove = (base.transform.FindChild("Bg/NeedApprove").GetComponent("XUILabel") as IXUILabel);
			this.m_MemberCount = (base.transform.FindChild("Bg/MemberCount").GetComponent("XUILabel") as IXUILabel);
			this.m_SettingPanel = base.transform.FindChild("Bg/SettingPanel").gameObject;
		}

		// Token: 0x04003927 RID: 14631
		public IXUIButton m_Close = null;

		// Token: 0x04003928 RID: 14632
		public IXUIButton m_BtnOneKeyCancel;

		// Token: 0x04003929 RID: 14633
		public IXUIButton m_BtnSetting;

		// Token: 0x0400392A RID: 14634
		public IXUIButton m_BtnSendMessage;

		// Token: 0x0400392B RID: 14635
		public IXUILabel m_RequiredPPT;

		// Token: 0x0400392C RID: 14636
		public IXUILabel m_NeedApprove;

		// Token: 0x0400392D RID: 14637
		public IXUILabel m_MemberCount;

		// Token: 0x0400392E RID: 14638
		public IXUIWrapContent m_WrapContent;

		// Token: 0x0400392F RID: 14639
		public IXUIScrollView m_ScrollView;

		// Token: 0x04003930 RID: 14640
		public GameObject m_SettingPanel;
	}
}
