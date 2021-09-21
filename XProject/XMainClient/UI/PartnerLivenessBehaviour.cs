using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017F0 RID: 6128
	internal class PartnerLivenessBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600FE12 RID: 65042 RVA: 0x003BA9C8 File Offset: 0x003B8BC8
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

		// Token: 0x0400702A RID: 28714
		public ILoopScrollView m_loopScrool;

		// Token: 0x0400702B RID: 28715
		public XUIPool m_ActivityItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400702C RID: 28716
		public XUIPool m_ChestPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400702D RID: 28717
		public XUIPool m_RewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400702E RID: 28718
		public IXUISprite m_closedSpr;

		// Token: 0x0400702F RID: 28719
		public XChestProgress m_Progress;

		// Token: 0x04007030 RID: 28720
		public IXUILabel m_totalExp;

		// Token: 0x04007031 RID: 28721
		public XNumberTween m_TotalExpTween;

		// Token: 0x04007032 RID: 28722
		public IXUILabel m_chestTips;

		// Token: 0x04007033 RID: 28723
		public IXUILabel m_Name;

		// Token: 0x04007034 RID: 28724
		public IXUILabel m_Tip;
	}
}
