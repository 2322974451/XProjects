using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C04 RID: 3076
	internal class XGuildDailyTaskBehavior : DlgBehaviourBase
	{
		// Token: 0x0600AED7 RID: 44759 RVA: 0x0020F278 File Offset: 0x0020D478
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

		// Token: 0x0400427A RID: 17018
		public IXUIButton CompleteTaskBtn = null;

		// Token: 0x0400427B RID: 17019
		public Transform CurrentRewardsGrid = null;

		// Token: 0x0400427C RID: 17020
		public Transform AdditionalRewardsGrid = null;

		// Token: 0x0400427D RID: 17021
		public IXUIButton SubmmitBtn = null;

		// Token: 0x0400427E RID: 17022
		public IXUIButton CloseBtn = null;

		// Token: 0x0400427F RID: 17023
		public XUIPool RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004280 RID: 17024
		public IXUILabel timeLabel;

		// Token: 0x04004281 RID: 17025
		public IXUILabel taskTimeLabel;

		// Token: 0x04004282 RID: 17026
		public IXUILabel taskNumLabel;

		// Token: 0x04004283 RID: 17027
		public IXUIWrapContent TaskContent;

		// Token: 0x04004284 RID: 17028
		public IXUIButton RefreshTaskBtn;

		// Token: 0x04004285 RID: 17029
		public Transform RefreshRecordRoot;

		// Token: 0x04004286 RID: 17030
		public IXUISprite TaskLevelSprite;

		// Token: 0x04004287 RID: 17031
		public IXUIButton RefreshLogBtn;

		// Token: 0x04004288 RID: 17032
		public IXUIWrapContent RefreshLogWrapContent;

		// Token: 0x04004289 RID: 17033
		public IXUIScrollView RefreshLogScrollView;

		// Token: 0x0400428A RID: 17034
		public IXUIButton RefreshCloseBtn;

		// Token: 0x0400428B RID: 17035
		public IXUILabel TalkLabel;

		// Token: 0x0400428C RID: 17036
		public IXUIButton TipButton;
	}
}
