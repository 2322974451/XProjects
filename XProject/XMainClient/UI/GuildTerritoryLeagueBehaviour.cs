using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class GuildTerritoryLeagueBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.mCheckBox = (base.transform.FindChild("AllSelItem").GetComponent("XUICheckBox") as IXUICheckBox);
			this.mClose = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.mClear = (base.transform.FindChild("Clear").GetComponent("XUIButton") as IXUIButton);
			this.mScrollView = (base.transform.FindChild("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.mWrapContent = (base.transform.FindChild("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		public IXUICheckBox mCheckBox;

		public IXUIButton mClose;

		public IXUIButton mClear;

		public IXUIScrollView mScrollView;

		public IXUIWrapContent mWrapContent;
	}
}
