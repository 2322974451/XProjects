using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class GuildTerritoryDeclareBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.mAllianceScrollView = (base.transform.FindChild("Alliance").GetComponent("XUIScrollView") as IXUIScrollView);
			this.mAllianceWrapContent = (base.transform.FindChild("Alliance/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.mSprite = (base.transform.FindChild("Sprite").GetComponent("XUISprite") as IXUISprite);
			this.mClose = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.mMessage = (base.transform.FindChild("Message").GetComponent("XUILabel") as IXUILabel);
			this.mTerritoryName = (base.transform.FindChild("TerritoryName").GetComponent("XUILabel") as IXUILabel);
			this.mTerritoryGuildName = (base.transform.FindChild("TerritoryGuildName").GetComponent("XUILabel") as IXUILabel);
			this.mTerritoryLevel = (base.transform.FindChild("TerritoryLevel").GetComponent("XUILabel") as IXUILabel);
			this.mTerritoryCount = (base.transform.FindChild("TerritoryCount").GetComponent("XUILabel") as IXUILabel);
			this.mTerritoryDeclare = (base.transform.FindChild("Declare").GetComponent("XUIButton") as IXUIButton);
			this.mTerritoryJoin = (base.transform.FindChild("Join").GetComponent("XUIButton") as IXUIButton);
			this.mTerritoryMessage = (base.transform.FindChild("TerritoryMessage").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUIButton mClose;

		public IXUISprite mSprite;

		public IXUIScrollView mAllianceScrollView;

		public IXUIWrapContent mAllianceWrapContent;

		public IXUILabel mMessage;

		public IXUILabel mTerritoryName;

		public IXUILabel mTerritoryGuildName;

		public IXUILabel mTerritoryCount;

		public IXUILabel mTerritoryLevel;

		public IXUIButton mTerritoryDeclare;

		public IXUIButton mTerritoryJoin;

		public IXUILabel mTerritoryMessage;
	}
}
