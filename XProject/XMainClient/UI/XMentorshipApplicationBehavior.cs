using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020017C5 RID: 6085
	internal class XMentorshipApplicationBehavior : DlgBehaviourBase
	{
		// Token: 0x0600FC1E RID: 64542 RVA: 0x003ABC68 File Offset: 0x003A9E68
		private void Awake()
		{
			this.WrapContent = (base.transform.Find("Bg/List/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.scrollView = (this.WrapContent.gameObject.transform.parent.GetComponent("XUIScrollView") as IXUIScrollView);
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.ClearBtn = (base.transform.Find("Bg/Clear").GetComponent("XUIButton") as IXUIButton);
			this.OneShotBtn = (base.transform.Find("Bg/OneShotAccept").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x04006ED8 RID: 28376
		public IXUIWrapContent WrapContent = null;

		// Token: 0x04006ED9 RID: 28377
		public IXUIButton CloseBtn;

		// Token: 0x04006EDA RID: 28378
		public IXUIButton ClearBtn;

		// Token: 0x04006EDB RID: 28379
		public IXUIScrollView scrollView;

		// Token: 0x04006EDC RID: 28380
		public IXUIButton OneShotBtn;
	}
}
