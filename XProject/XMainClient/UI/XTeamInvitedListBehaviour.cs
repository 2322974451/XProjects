using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001865 RID: 6245
	internal class XTeamInvitedListBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010420 RID: 66592 RVA: 0x003EE884 File Offset: 0x003ECA84
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Bg2/Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Bg");
			this.m_BtnIgnore = (transform.FindChild("BtnIgnore").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnDeny = (transform.FindChild("BtnDeny").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (transform.FindChild("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (transform.FindChild("Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_NoInvitation = transform.Find("NoInvitation").gameObject;
		}

		// Token: 0x040074DF RID: 29919
		public IXUIButton m_Close = null;

		// Token: 0x040074E0 RID: 29920
		public IXUIButton m_BtnIgnore;

		// Token: 0x040074E1 RID: 29921
		public IXUIButton m_BtnDeny;

		// Token: 0x040074E2 RID: 29922
		public IXUIScrollView m_ScrollView;

		// Token: 0x040074E3 RID: 29923
		public IXUIWrapContent m_WrapContent;

		// Token: 0x040074E4 RID: 29924
		public GameObject m_NoInvitation;
	}
}
