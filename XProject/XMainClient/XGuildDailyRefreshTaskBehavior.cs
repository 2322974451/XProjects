using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000A57 RID: 2647
	internal class XGuildDailyRefreshTaskBehavior : DlgBehaviourBase
	{
		// Token: 0x0600A0AA RID: 41130 RVA: 0x001AEE8C File Offset: 0x001AD08C
		private void Awake()
		{
			this.ScrollView = (base.transform.Find("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.WrapContent = (base.transform.Find("Bg/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.AddSprite = (base.transform.Find("Bg/RefreshTimes/BtnAdd").GetComponent("XUISprite") as IXUISprite);
			this.RefreshTimesLabel = (base.transform.Find("Bg/RefreshTimes").GetComponent("XUILabel") as IXUILabel);
			this.TaskLevelSprite = (base.transform.Find("Bg/TaskLevel").GetComponent("XUISprite") as IXUISprite);
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.HelpOtherRefresh = (base.transform.Find("Bg/BtnHelpGuild").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x0400399D RID: 14749
		public IXUIScrollView ScrollView;

		// Token: 0x0400399E RID: 14750
		public IXUIWrapContent WrapContent;

		// Token: 0x0400399F RID: 14751
		public IXUISprite AddSprite;

		// Token: 0x040039A0 RID: 14752
		public IXUISprite TaskLevelSprite;

		// Token: 0x040039A1 RID: 14753
		public IXUILabel RefreshTimesLabel;

		// Token: 0x040039A2 RID: 14754
		public IXUIButton CloseBtn;

		// Token: 0x040039A3 RID: 14755
		public IXUISprite HelpOtherRefresh;
	}
}
