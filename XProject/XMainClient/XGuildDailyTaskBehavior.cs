using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildDailyTaskBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.SubmmitBtn = (base.transform.Find("Submmit").GetComponent("XUIButton") as IXUIButton);
			this.CloseBtn = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.CurrentRewardsGrid = base.transform.Find("Rewards/BaseRewards");
			this.AdditionalRewardsGrid = base.transform.Find("Rewards/AllRewards");
			this.RewardPool.SetupPool(null, base.transform.Find("Rewards/Tpl").gameObject, 2U, false);
			this.timeLabel = (base.transform.Find("TimesDec2/Times").GetComponent("XUILabel") as IXUILabel);
			this.taskTimeLabel = (base.transform.Find("TimesDec/Times").GetComponent("XUILabel") as IXUILabel);
			this.taskNumLabel = (base.transform.Find("BaseInfo/Num").GetComponent("XUILabel") as IXUILabel);
			this.TalkLabel = (base.transform.Find("Talk").GetComponent("XUILabel") as IXUILabel);
			this.TaskContent = (base.transform.Find("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.RefreshTaskBtn = (base.transform.Find("Refresh").GetComponent("XUIButton") as IXUIButton);
			this.RefreshRecordRoot = base.transform.Find("LogPanel");
			this.TaskLevelSprite = (base.transform.Find("TaskLevel").GetComponent("XUISprite") as IXUISprite);
			this.RefreshLogBtn = (base.transform.Find("RefreshLogBtn").GetComponent("XUIButton") as IXUIButton);
			this.RefreshLogWrapContent = (this.RefreshRecordRoot.Find("LogMenu/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.RefreshLogScrollView = (this.RefreshRecordRoot.Find("LogMenu/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.RefreshCloseBtn = (this.RefreshRecordRoot.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.TipButton = (base.transform.Find("Help").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIButton CompleteTaskBtn = null;

		public Transform CurrentRewardsGrid = null;

		public Transform AdditionalRewardsGrid = null;

		public IXUIButton SubmmitBtn = null;

		public IXUIButton CloseBtn = null;

		public XUIPool RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel timeLabel;

		public IXUILabel taskTimeLabel;

		public IXUILabel taskNumLabel;

		public IXUIWrapContent TaskContent;

		public IXUIButton RefreshTaskBtn;

		public Transform RefreshRecordRoot;

		public IXUISprite TaskLevelSprite;

		public IXUIButton RefreshLogBtn;

		public IXUIWrapContent RefreshLogWrapContent;

		public IXUIScrollView RefreshLogScrollView;

		public IXUIButton RefreshCloseBtn;

		public IXUILabel TalkLabel;

		public IXUIButton TipButton;
	}
}
