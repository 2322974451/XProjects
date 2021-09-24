using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class DragonGuildLivenessBehaviour : DlgBehaviourBase
	{

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

		public ILoopScrollView m_loopScrool;

		public XUIPool m_ActivityItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_ChestPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_RewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUISprite m_closedSpr;

		public XChestProgress m_Progress;

		public IXUILabel m_totalExp;

		public XNumberTween m_TotalExpTween;

		public IXUILabel m_chestTips;
	}
}
