using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XGuildDailyRefreshTaskBehavior : DlgBehaviourBase
	{

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

		public IXUIScrollView ScrollView;

		public IXUIWrapContent WrapContent;

		public IXUISprite AddSprite;

		public IXUISprite TaskLevelSprite;

		public IXUILabel RefreshTimesLabel;

		public IXUIButton CloseBtn;

		public IXUISprite HelpOtherRefresh;
	}
}
