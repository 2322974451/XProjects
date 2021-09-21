using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200179C RID: 6044
	internal class HomeFishingBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F9B5 RID: 63925 RVA: 0x00397C64 File Offset: 0x00395E64
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

		// Token: 0x04006D3C RID: 27964
		public IXUIButton m_Close;

		// Token: 0x04006D3D RID: 27965
		public GameObject m_InFishingFrame;

		// Token: 0x04006D3E RID: 27966
		public GameObject m_NotFishingFrame;

		// Token: 0x04006D3F RID: 27967
		public IXUIButton m_StartFishingBtn;

		// Token: 0x04006D40 RID: 27968
		public IXUIButton m_SweepBtn;

		// Token: 0x04006D41 RID: 27969
		public IXUIButton m_FishLevelBtn;

		// Token: 0x04006D42 RID: 27970
		public IXUILabel m_FishLevelNum;

		// Token: 0x04006D43 RID: 27971
		public IXUIProgress m_FishExpValue;

		// Token: 0x04006D44 RID: 27972
		public IXUILabel m_StoshNum;

		// Token: 0x04006D45 RID: 27973
		public IXUIButton m_HomeMainBtn;

		// Token: 0x04006D46 RID: 27974
		public IXUIButton m_HomeShopBtn;

		// Token: 0x04006D47 RID: 27975
		public IXUIButton m_HomeCookingBtn;

		// Token: 0x04006D48 RID: 27976
		public GameObject m_FishingTips;

		// Token: 0x04006D49 RID: 27977
		public GameObject m_NoFishTips;

		// Token: 0x04006D4A RID: 27978
		public GameObject m_NoStosh;

		// Token: 0x04006D4B RID: 27979
		public GameObject m_HighQualityFx;

		// Token: 0x04006D4C RID: 27980
		public GameObject m_LowQualityFx;

		// Token: 0x04006D4D RID: 27981
		public IXUIScrollView m_ItemScrollView;

		// Token: 0x04006D4E RID: 27982
		public XUIPool m_FishPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006D4F RID: 27983
		public GameObject m_FishLevelFrame;

		// Token: 0x04006D50 RID: 27984
		public IXUILabel m_LevelFrameLevel;

		// Token: 0x04006D51 RID: 27985
		public IXUILabel m_LevelFrameExp;

		// Token: 0x04006D52 RID: 27986
		public IXUIProgress m_LevelFrameExpBar;

		// Token: 0x04006D53 RID: 27987
		public IXUIScrollView m_FishLevelScrollView;

		// Token: 0x04006D54 RID: 27988
		public IXUIButton m_LevelFrameCloseBtn;

		// Token: 0x04006D55 RID: 27989
		public XUIPool m_FishLevelPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006D56 RID: 27990
		public XUIPool m_LevelItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
