using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020018AF RID: 6319
	internal class XGuildViewBehaviour : DlgBehaviourBase
	{
		// Token: 0x0601077F RID: 67455 RVA: 0x0040815C File Offset: 0x0040635C
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnApply = (base.transform.FindChild("Bg/BtnApply").GetComponent("XUIButton") as IXUIButton);
			this.m_Annoucement = (base.transform.FindChild("Bg/Bg3/Announcement").GetComponent("XUILabel") as IXUILabel);
			this.m_Annoucement.SetText("");
			this.m_BasicInfoDisplay.Init(base.transform.FindChild("Bg/BasicInfo/Content"), true);
			this.m_ScrollView = (base.transform.FindChild("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		// Token: 0x04007706 RID: 30470
		public IXUIButton m_Close = null;

		// Token: 0x04007707 RID: 30471
		public IXUIButton m_BtnApply;

		// Token: 0x04007708 RID: 30472
		public IXUILabel m_Annoucement;

		// Token: 0x04007709 RID: 30473
		public IXUIWrapContent m_WrapContent;

		// Token: 0x0400770A RID: 30474
		public IXUIScrollView m_ScrollView;

		// Token: 0x0400770B RID: 30475
		public XGuildBasicInfoDisplay m_BasicInfoDisplay = new XGuildBasicInfoDisplay();
	}
}
