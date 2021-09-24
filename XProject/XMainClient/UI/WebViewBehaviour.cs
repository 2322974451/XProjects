using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class WebViewBehaviour : DlgBehaviourBase
	{

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

		public IXUIButton mCloseBtn;

		public IXUIButton mBackBtn;

		public IXUIButton mCollect;

		public IXUICheckBox mCheckLive;

		public IXUICheckBox mCheckVideo;

		public IXUILabel mTryAgain;

		public IXUILabel mTryAgainTip;

		public IXUILabel mVideoTitle;

		public IXUISprite mLoading;

		public IXUISprite mChoiceSp;

		public IXUISprite mRedPoint;

		public IXUISprite mNetWorkStaus;

		public IXUISprite mNetWorkWifi;
	}
}
