using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020018DA RID: 6362
	internal class WeddingEnterApplyBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010948 RID: 67912 RVA: 0x00415D20 File Offset: 0x00413F20
		private void Awake()
		{
			this.m_ToggleEnter = (base.transform.FindChild("Bg/ToggleEnter").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_ToggleApply = (base.transform.FindChild("Bg/ToggleApply").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_ToggleEnter.ID = 0UL;
			this.m_ToggleApply.ID = 1UL;
			this.m_ScrollView = (base.transform.FindChild("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_EmptyList = (base.transform.FindChild("Bg/Empty").GetComponent("XUILabel") as IXUILabel);
			this.m_EmptyList2 = (base.transform.FindChild("Bg/Empty2").GetComponent("XUILabel") as IXUILabel);
			this.m_GoApplyTab = (base.transform.FindChild("Bg/GoApply").GetComponent("XUIButton") as IXUIButton);
			this.m_Title = (base.transform.FindChild("Bg/Title").GetComponent("XUILabel") as IXUILabel);
			this.m_ClosedSpr = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x04007855 RID: 30805
		public IXUICheckBox m_ToggleEnter;

		// Token: 0x04007856 RID: 30806
		public IXUICheckBox m_ToggleApply;

		// Token: 0x04007857 RID: 30807
		public IXUIScrollView m_ScrollView;

		// Token: 0x04007858 RID: 30808
		public IXUIWrapContent m_WrapContent;

		// Token: 0x04007859 RID: 30809
		public IXUILabel m_EmptyList;

		// Token: 0x0400785A RID: 30810
		public IXUILabel m_EmptyList2;

		// Token: 0x0400785B RID: 30811
		public IXUIButton m_GoApplyTab;

		// Token: 0x0400785C RID: 30812
		public IXUIButton m_ClosedSpr;

		// Token: 0x0400785D RID: 30813
		public IXUILabel m_Title;
	}
}
