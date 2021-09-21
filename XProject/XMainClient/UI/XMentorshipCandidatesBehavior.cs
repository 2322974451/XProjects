using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020017C7 RID: 6087
	internal class XMentorshipCandidatesBehavior : DlgBehaviourBase
	{
		// Token: 0x0600FC35 RID: 64565 RVA: 0x003AC5B4 File Offset: 0x003AA7B4
		private void Awake()
		{
			this.WrapContent = (base.transform.Find("Bg/List/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.ScrollView = (this.WrapContent.gameObject.transform.parent.GetComponent("XUIScrollView") as IXUIScrollView);
			this.ClearBtn = (base.transform.Find("Bg/ClearOrSwap").GetComponent("XUIButton") as IXUIButton);
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.titleContent = (base.transform.Find("Bg/Title/content").GetComponent("XUILabel") as IXUILabel);
			this.btnContent = (base.transform.Find("Bg/ClearOrSwap/Type").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04006EDD RID: 28381
		public IXUIWrapContent WrapContent = null;

		// Token: 0x04006EDE RID: 28382
		public IXUIScrollView ScrollView = null;

		// Token: 0x04006EDF RID: 28383
		public IXUIButton ClearBtn;

		// Token: 0x04006EE0 RID: 28384
		public IXUIButton CloseBtn;

		// Token: 0x04006EE1 RID: 28385
		public IXUILabel titleContent;

		// Token: 0x04006EE2 RID: 28386
		public IXUILabel btnContent;
	}
}
