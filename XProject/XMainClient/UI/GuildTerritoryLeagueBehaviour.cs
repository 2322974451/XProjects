using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001773 RID: 6003
	internal class GuildTerritoryLeagueBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F7DB RID: 63451 RVA: 0x00388994 File Offset: 0x00386B94
		private void Awake()
		{
			this.mCheckBox = (base.transform.FindChild("AllSelItem").GetComponent("XUICheckBox") as IXUICheckBox);
			this.mClose = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.mClear = (base.transform.FindChild("Clear").GetComponent("XUIButton") as IXUIButton);
			this.mScrollView = (base.transform.FindChild("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.mWrapContent = (base.transform.FindChild("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		// Token: 0x04006C12 RID: 27666
		public IXUICheckBox mCheckBox;

		// Token: 0x04006C13 RID: 27667
		public IXUIButton mClose;

		// Token: 0x04006C14 RID: 27668
		public IXUIButton mClear;

		// Token: 0x04006C15 RID: 27669
		public IXUIScrollView mScrollView;

		// Token: 0x04006C16 RID: 27670
		public IXUIWrapContent mWrapContent;
	}
}
