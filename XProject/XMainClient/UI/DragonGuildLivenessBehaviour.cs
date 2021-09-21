using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016D7 RID: 5847
	internal class DragonGuildLivenessBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F12A RID: 61738 RVA: 0x00353020 File Offset: 0x00351220
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
		}

		// Token: 0x040066FD RID: 26365
		public ILoopScrollView m_loopScrool;

		// Token: 0x040066FE RID: 26366
		public XUIPool m_ActivityItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040066FF RID: 26367
		public XUIPool m_ChestPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006700 RID: 26368
		public XUIPool m_RewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006701 RID: 26369
		public IXUISprite m_closedSpr;

		// Token: 0x04006702 RID: 26370
		public XChestProgress m_Progress;

		// Token: 0x04006703 RID: 26371
		public IXUILabel m_totalExp;

		// Token: 0x04006704 RID: 26372
		public XNumberTween m_TotalExpTween;

		// Token: 0x04006705 RID: 26373
		public IXUILabel m_chestTips;
	}
}
