using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XMentorshipCandidatesBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.WrapContent = (base.transform.Find("Bg/List/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.ScrollView = (this.WrapContent.gameObject.transform.parent.GetComponent("XUIScrollView") as IXUIScrollView);
			this.ClearBtn = (base.transform.Find("Bg/ClearOrSwap").GetComponent("XUIButton") as IXUIButton);
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.titleContent = (base.transform.Find("Bg/Title/content").GetComponent("XUILabel") as IXUILabel);
			this.btnContent = (base.transform.Find("Bg/ClearOrSwap/Type").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUIWrapContent WrapContent = null;

		public IXUIScrollView ScrollView = null;

		public IXUIButton ClearBtn;

		public IXUIButton CloseBtn;

		public IXUILabel titleContent;

		public IXUILabel btnContent;
	}
}
