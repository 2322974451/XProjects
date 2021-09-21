using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000A55 RID: 2645
	internal class XGuildDailyHandleRefreshBehavior : DlgBehaviourBase
	{
		// Token: 0x0600A098 RID: 41112 RVA: 0x001AE910 File Offset: 0x001ACB10
		private void Awake()
		{
			this.ScrollView = (base.transform.Find("Bg/List").GetComponent("XUIScrollView") as IXUIScrollView);
			this.WrapContent = (base.transform.Find("Bg/List/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.HelpTimesLabel = (base.transform.Find("Bg/TimesDec/Times").GetComponent("XUILabel") as IXUILabel);
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.FreeTimeLabel = (base.transform.Find("Bg/T").GetComponent("XUILabel") as IXUILabel);
			this.TaskLucky = (base.transform.Find("Bg/TaskLevel/Lucky").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04003997 RID: 14743
		public IXUIScrollView ScrollView;

		// Token: 0x04003998 RID: 14744
		public IXUIWrapContent WrapContent;

		// Token: 0x04003999 RID: 14745
		public IXUILabel HelpTimesLabel;

		// Token: 0x0400399A RID: 14746
		public IXUIButton CloseBtn;

		// Token: 0x0400399B RID: 14747
		public IXUILabel FreeTimeLabel;

		// Token: 0x0400399C RID: 14748
		public IXUILabel TaskLucky;
	}
}
