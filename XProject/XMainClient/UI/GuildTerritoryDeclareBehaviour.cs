using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001771 RID: 6001
	internal class GuildTerritoryDeclareBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F7C6 RID: 63430 RVA: 0x00387B20 File Offset: 0x00385D20
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

		// Token: 0x04006C02 RID: 27650
		public IXUIButton mClose;

		// Token: 0x04006C03 RID: 27651
		public IXUISprite mSprite;

		// Token: 0x04006C04 RID: 27652
		public IXUIScrollView mAllianceScrollView;

		// Token: 0x04006C05 RID: 27653
		public IXUIWrapContent mAllianceWrapContent;

		// Token: 0x04006C06 RID: 27654
		public IXUILabel mMessage;

		// Token: 0x04006C07 RID: 27655
		public IXUILabel mTerritoryName;

		// Token: 0x04006C08 RID: 27656
		public IXUILabel mTerritoryGuildName;

		// Token: 0x04006C09 RID: 27657
		public IXUILabel mTerritoryCount;

		// Token: 0x04006C0A RID: 27658
		public IXUILabel mTerritoryLevel;

		// Token: 0x04006C0B RID: 27659
		public IXUIButton mTerritoryDeclare;

		// Token: 0x04006C0C RID: 27660
		public IXUIButton mTerritoryJoin;

		// Token: 0x04006C0D RID: 27661
		public IXUILabel mTerritoryMessage;
	}
}
