using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class GuildTerritoryMainBehaviour : DlgBehaviourBase
	{

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

		public IXUIButton mClose;

		public IXUIButton mMessage;

		public IXUILabel mContent;

		public IXUIButton mHelp;

		public IXUIButton mRwd;

		public IXUIScrollView mScrollView;

		public IXUIWrapContent mWrapContent;

		public IXUILabel mTerritoryName;

		public IXUILabel mTerritoryTarget;

		public Transform mTerritoryTransform;

		public Transform mCrossGVG;

		public IXUILabel mCrossGVGDescribe;
	}
}
