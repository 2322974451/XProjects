using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HomeFishingBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/InFishingFrame/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_InFishingFrame = base.transform.Find("Bg/InFishingFrame").gameObject;
			this.m_NotFishingFrame = base.transform.Find("Bg/NotFishingFrame").gameObject;
			this.m_StartFishingBtn = (this.m_NotFishingFrame.transform.Find("StartFishingBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_SweepBtn = (this.m_NotFishingFrame.transform.Find("SweepBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_FishLevelBtn = (this.m_InFishingFrame.transform.Find("Level").GetComponent("XUIButton") as IXUIButton);
			this.m_FishLevelNum = (this.m_FishLevelBtn.gameObject.transform.Find("Num").GetComponent("XUILabel") as IXUILabel);
			this.m_FishExpValue = (this.m_InFishingFrame.transform.Find("Exp").GetComponent("XUIProgress") as IXUIProgress);
			this.m_StoshNum = (this.m_InFishingFrame.transform.Find("Stosh/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_HomeMainBtn = (this.m_InFishingFrame.transform.Find("HomeMainBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_HomeShopBtn = (this.m_InFishingFrame.transform.Find("HomeShopBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_HomeCookingBtn = (this.m_InFishingFrame.transform.Find("HomeCookingBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_FishingTips = this.m_InFishingFrame.transform.Find("Auto").gameObject;
			this.m_NoFishTips = this.m_InFishingFrame.transform.Find("Items/Tips").gameObject;
			this.m_NoStosh = this.m_InFishingFrame.transform.Find("Stosh/red").gameObject;
			this.m_HighQualityFx = this.m_InFishingFrame.transform.Find("Items/UI_jy_dy_pzkL").gameObject;
			this.m_LowQualityFx = this.m_InFishingFrame.transform.Find("Items/UI_jy_dy_pzk").gameObject;
			this.m_ItemScrollView = (this.m_InFishingFrame.transform.Find("Items/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform = this.m_InFishingFrame.transform.Find("Items/ScrollView/Tpl");
			this.m_FishPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			this.m_FishLevelFrame = base.transform.Find("Bg/InFishingFrame/FishingLevelFrame").gameObject;
			this.m_LevelFrameCloseBtn = (this.m_FishLevelFrame.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_LevelFrameLevel = (this.m_FishLevelFrame.transform.Find("Info/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_LevelFrameExp = (this.m_FishLevelFrame.transform.Find("Info/Exp").GetComponent("XUILabel") as IXUILabel);
			this.m_LevelFrameExpBar = (this.m_FishLevelFrame.transform.Find("Info/Bar").GetComponent("XUIProgress") as IXUIProgress);
			this.m_FishLevelScrollView = (this.m_FishLevelFrame.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			transform = this.m_FishLevelFrame.transform.Find("ScrollView/Tpl");
			this.m_FishLevelPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			transform = this.m_FishLevelFrame.transform.Find("ScrollView/Item");
			this.m_LevelItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
		}

		public IXUIButton m_Close;

		public GameObject m_InFishingFrame;

		public GameObject m_NotFishingFrame;

		public IXUIButton m_StartFishingBtn;

		public IXUIButton m_SweepBtn;

		public IXUIButton m_FishLevelBtn;

		public IXUILabel m_FishLevelNum;

		public IXUIProgress m_FishExpValue;

		public IXUILabel m_StoshNum;

		public IXUIButton m_HomeMainBtn;

		public IXUIButton m_HomeShopBtn;

		public IXUIButton m_HomeCookingBtn;

		public GameObject m_FishingTips;

		public GameObject m_NoFishTips;

		public GameObject m_NoStosh;

		public GameObject m_HighQualityFx;

		public GameObject m_LowQualityFx;

		public IXUIScrollView m_ItemScrollView;

		public XUIPool m_FishPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public GameObject m_FishLevelFrame;

		public IXUILabel m_LevelFrameLevel;

		public IXUILabel m_LevelFrameExp;

		public IXUIProgress m_LevelFrameExpBar;

		public IXUIScrollView m_FishLevelScrollView;

		public IXUIButton m_LevelFrameCloseBtn;

		public XUIPool m_FishLevelPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_LevelItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
