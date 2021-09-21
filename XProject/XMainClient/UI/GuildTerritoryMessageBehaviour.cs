using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001778 RID: 6008
	internal class GuildTerritoryMessageBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F7FE RID: 63486 RVA: 0x00389754 File Offset: 0x00387954
		private void Awake()
		{
			this.mClose = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.mScrollView = (base.transform.FindChild("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.mNameLabel = (base.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			this.mWrapContent = (base.transform.FindChild("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		// Token: 0x04006C31 RID: 27697
		public IXUIButton mClose;

		// Token: 0x04006C32 RID: 27698
		public IXUIScrollView mScrollView;

		// Token: 0x04006C33 RID: 27699
		public IXUIWrapContent mWrapContent;

		// Token: 0x04006C34 RID: 27700
		public IXUILabel mNameLabel;
	}
}
