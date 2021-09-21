using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001760 RID: 5984
	internal class GuildInheritBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F722 RID: 63266 RVA: 0x00383060 File Offset: 0x00381260
		private void Awake()
		{
			this.Close = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.ScrollView = (base.transform.FindChild("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.WrapContent = (base.transform.FindChild("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.OverLook = (base.transform.FindChild("OverLook").GetComponent("XUIButton") as IXUIButton);
			this.NotAccept = (base.transform.FindChild("NotAccept").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x04006B75 RID: 27509
		public IXUIButton Close;

		// Token: 0x04006B76 RID: 27510
		public IXUIScrollView ScrollView;

		// Token: 0x04006B77 RID: 27511
		public IXUIWrapContent WrapContent;

		// Token: 0x04006B78 RID: 27512
		public IXUIButton OverLook;

		// Token: 0x04006B79 RID: 27513
		public IXUIButton NotAccept;
	}
}
