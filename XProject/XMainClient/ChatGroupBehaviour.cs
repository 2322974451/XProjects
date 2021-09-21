using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BD1 RID: 3025
	internal class ChatGroupBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600ACE8 RID: 44264 RVA: 0x00200080 File Offset: 0x001FE280
		private void Awake()
		{
			this.m_wrap = (base.transform.FindChild("Bg/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_sprClose = (base.transform.Find("Bg/Close").GetComponent("XUISprite") as IXUISprite);
			this.m_add = (base.transform.FindChild("Bg/tabs/tab1/template/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_rm = (base.transform.FindChild("Bg/tabs/tab2/template/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
		}

		// Token: 0x0400410A RID: 16650
		public IXUISprite m_sprClose;

		// Token: 0x0400410B RID: 16651
		public IXUIWrapContent m_wrap;

		// Token: 0x0400410C RID: 16652
		public IXUICheckBox m_add;

		// Token: 0x0400410D RID: 16653
		public IXUICheckBox m_rm;
	}
}
