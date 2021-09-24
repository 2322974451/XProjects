using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class GuildInheritBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.Close = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.ScrollView = (base.transform.FindChild("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.WrapContent = (base.transform.FindChild("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.OverLook = (base.transform.FindChild("OverLook").GetComponent("XUIButton") as IXUIButton);
			this.NotAccept = (base.transform.FindChild("NotAccept").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIButton Close;

		public IXUIScrollView ScrollView;

		public IXUIWrapContent WrapContent;

		public IXUIButton OverLook;

		public IXUIButton NotAccept;
	}
}
