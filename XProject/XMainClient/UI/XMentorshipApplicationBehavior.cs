using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XMentorshipApplicationBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.WrapContent = (base.transform.Find("Bg/List/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.scrollView = (this.WrapContent.gameObject.transform.parent.GetComponent("XUIScrollView") as IXUIScrollView);
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.ClearBtn = (base.transform.Find("Bg/Clear").GetComponent("XUIButton") as IXUIButton);
			this.OneShotBtn = (base.transform.Find("Bg/OneShotAccept").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIWrapContent WrapContent = null;

		public IXUIButton CloseBtn;

		public IXUIButton ClearBtn;

		public IXUIScrollView scrollView;

		public IXUIButton OneShotBtn;
	}
}
