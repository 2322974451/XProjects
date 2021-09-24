using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XGuildDailyHandleRefreshBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.ScrollView = (base.transform.Find("Bg/List").GetComponent("XUIScrollView") as IXUIScrollView);
			this.WrapContent = (base.transform.Find("Bg/List/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.HelpTimesLabel = (base.transform.Find("Bg/TimesDec/Times").GetComponent("XUILabel") as IXUILabel);
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.FreeTimeLabel = (base.transform.Find("Bg/T").GetComponent("XUILabel") as IXUILabel);
			this.TaskLucky = (base.transform.Find("Bg/TaskLevel/Lucky").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUIScrollView ScrollView;

		public IXUIWrapContent WrapContent;

		public IXUILabel HelpTimesLabel;

		public IXUIButton CloseBtn;

		public IXUILabel FreeTimeLabel;

		public IXUILabel TaskLucky;
	}
}
