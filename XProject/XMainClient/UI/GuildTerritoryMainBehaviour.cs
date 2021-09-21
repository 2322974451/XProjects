using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001775 RID: 6005
	internal class GuildTerritoryMainBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F7E9 RID: 63465 RVA: 0x00388D84 File Offset: 0x00386F84
		private void Awake()
		{
			this.mClose = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.mMessage = (base.transform.FindChild("Bg/OK").GetComponent("XUIButton") as IXUIButton);
			this.mContent = (base.transform.FindChild("Bg/Message").GetComponent("XUILabel") as IXUILabel);
			this.mScrollView = (base.transform.FindChild("Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.mWrapContent = (base.transform.FindChild("Bg/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.mHelp = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.mRwd = (base.transform.FindChild("Bg/Rwd").GetComponent("XUIButton") as IXUIButton);
			this.mTerritoryName = (base.transform.FindChild("Bg/Name").GetComponent("XUILabel") as IXUILabel);
			this.mTerritoryTarget = (base.transform.FindChild("Bg/Target").GetComponent("XUILabel") as IXUILabel);
			this.mTerritoryTransform = base.transform.FindChild("Bg/Territories");
			this.mCrossGVG = base.transform.FindChild("Bg/CrossGVG");
			this.mCrossGVGDescribe = (base.transform.FindChild("Bg/CrossGVG/Describe").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04006C18 RID: 27672
		public IXUIButton mClose;

		// Token: 0x04006C19 RID: 27673
		public IXUIButton mMessage;

		// Token: 0x04006C1A RID: 27674
		public IXUILabel mContent;

		// Token: 0x04006C1B RID: 27675
		public IXUIButton mHelp;

		// Token: 0x04006C1C RID: 27676
		public IXUIButton mRwd;

		// Token: 0x04006C1D RID: 27677
		public IXUIScrollView mScrollView;

		// Token: 0x04006C1E RID: 27678
		public IXUIWrapContent mWrapContent;

		// Token: 0x04006C1F RID: 27679
		public IXUILabel mTerritoryName;

		// Token: 0x04006C20 RID: 27680
		public IXUILabel mTerritoryTarget;

		// Token: 0x04006C21 RID: 27681
		public Transform mTerritoryTransform;

		// Token: 0x04006C22 RID: 27682
		public Transform mCrossGVG;

		// Token: 0x04006C23 RID: 27683
		public IXUILabel mCrossGVGDescribe;
	}
}
