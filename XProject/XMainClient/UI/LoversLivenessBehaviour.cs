using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018D7 RID: 6359
	internal class LoversLivenessBehaviour : DlgBehaviourBase
	{
		// Token: 0x0601092C RID: 67884 RVA: 0x00415294 File Offset: 0x00413494
		private void Awake()
		{
			Transform transform = base.transform.Find("Bg/RightView/ActivityTpl");
			this.m_ActivityItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			this.m_closedSpr = (base.transform.FindChild("Bg/Close").GetComponent("XUISprite") as IXUISprite);
			this.m_Progress = new XChestProgress(base.transform.FindChild("Bg/UpView/Progress").GetComponent("XUIProgress") as IXUIProgress);
			transform = base.transform.FindChild("Bg/UpView/Progress/Chests/Chest");
			this.m_ChestPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			transform = base.transform.FindChild("Bg/LeftView/Item");
			this.m_RewardItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_totalExp = (base.transform.FindChild("Bg/UpView/CurrentExp").GetComponent("XUILabel") as IXUILabel);
			this.m_TotalExpTween = XNumberTween.Create(this.m_totalExp);
			this.m_TotalExpTween.SetNumberWithTween(0UL, "", false, true);
			this.m_chestTips = (base.transform.FindChild("Bg/LeftView/BigChest/Tips/Exp").GetComponent("XUILabel") as IXUILabel);
			this.m_loopScrool = (base.transform.FindChild("Bg/RightView").GetComponent("LoopScrollView") as ILoopScrollView);
			this.m_ChestPool.ReturnAll(false);
			this.m_Name = (base.transform.FindChild("Bg/UpView/CurrentExp/T").GetComponent("XUILabel") as IXUILabel);
			this.m_Tip = (base.transform.FindChild("Bg/Bg/Label").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04007841 RID: 30785
		public ILoopScrollView m_loopScrool;

		// Token: 0x04007842 RID: 30786
		public XUIPool m_ActivityItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007843 RID: 30787
		public XUIPool m_ChestPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007844 RID: 30788
		public XUIPool m_RewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007845 RID: 30789
		public IXUISprite m_closedSpr;

		// Token: 0x04007846 RID: 30790
		public XChestProgress m_Progress;

		// Token: 0x04007847 RID: 30791
		public IXUILabel m_totalExp;

		// Token: 0x04007848 RID: 30792
		public XNumberTween m_TotalExpTween;

		// Token: 0x04007849 RID: 30793
		public IXUILabel m_chestTips;

		// Token: 0x0400784A RID: 30794
		public IXUILabel m_Name;

		// Token: 0x0400784B RID: 30795
		public IXUILabel m_Tip;
	}
}
