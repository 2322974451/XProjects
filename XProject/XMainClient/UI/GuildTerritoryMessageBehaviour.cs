using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class GuildTerritoryMessageBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.mClose = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.mScrollView = (base.transform.FindChild("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.mNameLabel = (base.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			this.mWrapContent = (base.transform.FindChild("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		public IXUIButton mClose;

		public IXUIScrollView mScrollView;

		public IXUIWrapContent mWrapContent;

		public IXUILabel mNameLabel;
	}
}
