using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x0200178F RID: 6031
	internal class WebViewBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F8E5 RID: 63717 RVA: 0x00390068 File Offset: 0x0038E268
		private void Awake()
		{
			this.mCloseBtn = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.mCloseBtn.ID = 1UL;
			this.mBackBtn = (base.transform.FindChild("Bg/Return").GetComponent("XUIButton") as IXUIButton);
			this.mBackBtn.ID = 2UL;
			this.mCollect = (base.transform.FindChild("Bg/Collect").GetComponent("XUIButton") as IXUIButton);
			this.mCheckLive = (base.transform.FindChild("Bg/TabTpl/tab1/template/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
			this.mCheckLive.ID = 1UL;
			this.mCheckVideo = (base.transform.FindChild("Bg/TabTpl/tab2/template/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
			this.mCheckVideo.ID = 2UL;
			this.mTryAgain = (base.transform.FindChild("Bg/Tip/Again").GetComponent("XUILabel") as IXUILabel);
			this.mTryAgainTip = (base.transform.FindChild("Bg/Tip").GetComponent("XUILabel") as IXUILabel);
			this.mVideoTitle = (base.transform.FindChild("Bg/Title").GetComponent("XUILabel") as IXUILabel);
			this.mChoiceSp = (base.transform.FindChild("Bg/TabTpl").GetComponent("XUISprite") as IXUISprite);
			this.mRedPoint = (base.transform.FindChild("Bg/Collect/RedPoint").GetComponent("XUISprite") as IXUISprite);
			this.mNetWorkStaus = (base.transform.FindChild("Bg/Sys4G").GetComponent("XUISprite") as IXUISprite);
			this.mNetWorkWifi = (base.transform.FindChild("Bg/SysWifi").GetComponent("XUISprite") as IXUISprite);
			this.mLoading = (base.transform.FindChild("Bg/loading").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x04006C96 RID: 27798
		public IXUIButton mCloseBtn;

		// Token: 0x04006C97 RID: 27799
		public IXUIButton mBackBtn;

		// Token: 0x04006C98 RID: 27800
		public IXUIButton mCollect;

		// Token: 0x04006C99 RID: 27801
		public IXUICheckBox mCheckLive;

		// Token: 0x04006C9A RID: 27802
		public IXUICheckBox mCheckVideo;

		// Token: 0x04006C9B RID: 27803
		public IXUILabel mTryAgain;

		// Token: 0x04006C9C RID: 27804
		public IXUILabel mTryAgainTip;

		// Token: 0x04006C9D RID: 27805
		public IXUILabel mVideoTitle;

		// Token: 0x04006C9E RID: 27806
		public IXUISprite mLoading;

		// Token: 0x04006C9F RID: 27807
		public IXUISprite mChoiceSp;

		// Token: 0x04006CA0 RID: 27808
		public IXUISprite mRedPoint;

		// Token: 0x04006CA1 RID: 27809
		public IXUISprite mNetWorkStaus;

		// Token: 0x04006CA2 RID: 27810
		public IXUISprite mNetWorkWifi;
	}
}
