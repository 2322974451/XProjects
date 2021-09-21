using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000A60 RID: 2656
	internal class XShowSameQualityItemsBehavior : DlgBehaviourBase
	{
		// Token: 0x0600A125 RID: 41253 RVA: 0x001B2DF4 File Offset: 0x001B0FF4
		private void Awake()
		{
			this.OkBtn = (base.transform.Find("task/OK").GetComponent("XUIButton") as IXUIButton);
			this.TaskStr = (base.transform.Find("task/OK/TaskStr").GetComponent("XUILabel") as IXUILabel);
			this.TipStr = (base.transform.Find("task/Tip").GetComponent("XUILabel") as IXUILabel);
			this.progressLabel = (base.transform.Find("task/Tnum").GetComponent("XUILabel") as IXUILabel);
			this.ScrollView = (base.transform.Find("ItemsFrame").GetComponent("XUIScrollView") as IXUIScrollView);
			this.WrapContent = (base.transform.Find("ItemsFrame/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.CloseBtn = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x040039EF RID: 14831
		public IXUIButton OkBtn = null;

		// Token: 0x040039F0 RID: 14832
		public IXUILabel TaskStr;

		// Token: 0x040039F1 RID: 14833
		public IXUILabel TipStr;

		// Token: 0x040039F2 RID: 14834
		public IXUIScrollView ScrollView;

		// Token: 0x040039F3 RID: 14835
		public IXUIWrapContent WrapContent;

		// Token: 0x040039F4 RID: 14836
		public IXUILabel progressLabel;

		// Token: 0x040039F5 RID: 14837
		public IXUIButton CloseBtn;
	}
}
