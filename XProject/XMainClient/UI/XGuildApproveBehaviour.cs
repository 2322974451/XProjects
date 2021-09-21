using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020018AA RID: 6314
	internal class XGuildApproveBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010744 RID: 67396 RVA: 0x004068E0 File Offset: 0x00404AE0
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

		// Token: 0x040076DB RID: 30427
		public IXUIButton m_Close = null;

		// Token: 0x040076DC RID: 30428
		public IXUIButton m_BtnOneKeyCancel;

		// Token: 0x040076DD RID: 30429
		public IXUIButton m_BtnSetting;

		// Token: 0x040076DE RID: 30430
		public IXUIButton m_BtnSendMessage;

		// Token: 0x040076DF RID: 30431
		public IXUILabel m_RequiredPPT;

		// Token: 0x040076E0 RID: 30432
		public IXUILabel m_NeedApprove;

		// Token: 0x040076E1 RID: 30433
		public IXUILabel m_MemberCount;

		// Token: 0x040076E2 RID: 30434
		public IXUIWrapContent m_WrapContent;

		// Token: 0x040076E3 RID: 30435
		public IXUIScrollView m_ScrollView;

		// Token: 0x040076E4 RID: 30436
		public GameObject m_SettingPanel;
	}
}
