using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001704 RID: 5892
	internal class ActivityTeamTowerSingleDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F312 RID: 62226 RVA: 0x00361708 File Offset: 0x0035F908
		private void Awake()
		{
			this.m_Help = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.mCurrentTime = (base.transform.FindChild("Bg/times").GetComponent("XUILabel") as IXUILabel);
			this.mSweepBtn = (base.transform.FindChild("Bg/SweepBtn").GetComponent("XUIButton") as IXUIButton);
			this.mResetBtn = (base.transform.FindChild("Bg/Reset").GetComponent("XUIButton") as IXUIButton);
			this.mSweepLabel = (base.transform.FindChild("Bg/SweepInfo").GetComponent("XUILabel") as IXUILabel);
			this.mSweepFrame = (base.transform.FindChild("Bg/SweepFrame").GetComponent("XUISprite") as IXUISprite);
			this.mResetCount = (base.transform.FindChild("Bg/Reset/Number/Num").GetComponent("XUILabel") as IXUILabel);
			this.mResetSprite = (base.transform.FindChild("Bg/Reset/Number").GetComponent("XUISprite") as IXUISprite);
			this.mStage = (base.transform.FindChild("Bg/Stagepanel/Stage").GetComponent("XUILabel") as IXUILabel);
			this.mResetNum = (base.transform.FindChild("Bg/times").GetComponent("XUILabel") as IXUILabel);
			this.mMainClose = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.mRank = (base.transform.FindChild("Bg/Rank").GetComponent("XUIButton") as IXUIButton);
			this.mGoBattle = (base.transform.FindChild("Bg/GoBattle").GetComponent("XUIButton") as IXUIButton);
			this.mScroll = (base.transform.FindChild("Bg/Tower").GetComponent("XUIScrollView") as IXUIScrollView);
			this.mDemandFP = (base.transform.FindChild("Bg/Stagepanel/Reward/fp").GetComponent("XUILabel") as IXUILabel);
			this.mSweepedLevel = (base.transform.FindChild("Bg/SweepFrame/SweepLevel").GetComponent("XUILabel") as IXUILabel);
			this.mSweepEstimateTime = (base.transform.FindChild("Bg/SweepFrame/SweepTime").GetComponent("XUILabel") as IXUILabel);
			this.mSingleDoSweep = (base.transform.FindChild("Bg/SweepFrame/SweepBtnNow").GetComponent("XUIButton") as IXUIButton);
			this.mDoubleSweep = (base.transform.FindChild("Bg/SweepFrame/SweepBtnNormal").GetComponent("XUIButton") as IXUIButton);
			this.mDoubleDoSweep = (base.transform.FindChild("Bg/SweepFrame/SweepBtnQuick").GetComponent("XUIButton") as IXUIButton);
			this.mCloseSweep = (base.transform.FindChild("Bg/SweepFrame/Close").GetComponent("XUIButton") as IXUIButton);
			this.mBackClick = (base.transform.FindChild("Bg/SweepFrame/backclick").GetComponent("XUIButton") as IXUIButton);
			this.mSingleMoneySign = (base.transform.FindChild("Bg/SweepFrame/SweepBtnNow/moneysign").GetComponent("XUISprite") as IXUISprite);
			this.mSingleMoneyNum = (base.transform.FindChild("Bg/SweepFrame/SweepBtnNow/moneynum").GetComponent("XUILabel") as IXUILabel);
			this.mDoubleMoneySign = (base.transform.FindChild("Bg/SweepFrame/SweepBtnQuick/moneysign").GetComponent("XUISprite") as IXUISprite);
			this.mDoubleMoneyNum = (base.transform.FindChild("Bg/SweepFrame/SweepBtnQuick/moneynum").GetComponent("XUILabel") as IXUILabel);
			this.mRewardPool.SetupPool(base.transform.FindChild("Bg/SweepFrame/Grid").gameObject, base.transform.FindChild("Bg/SweepFrame/Grid/ItemTpl").gameObject, 2U, false);
			this.mTowerPool.SetupPool(base.transform.FindChild("Bg/Tower").gameObject, base.transform.FindChild("Bg/Tower/Towerrepeat").gameObject, 5U, false);
			this.mMainRewardPool.SetupPool(base.transform.FindChild("Bg/Stagepanel").gameObject, base.transform.FindChild("Bg/Stagepanel/Item").gameObject, 2U, false);
			this.mSweepResult = (base.transform.FindChild("Bg/SweepResult").GetComponent("XUISprite") as IXUISprite);
			this.mRewardLevel = (base.transform.FindChild("Bg/SweepResult/Result").GetComponent("XUILabel") as IXUILabel);
			this.mRewardAlpha = (base.transform.FindChild("Bg/SweepResult/Buff/Time").GetComponent("XUILabel") as IXUILabel);
			this.mRewardFreeTime = (base.transform.FindChild("Bg/SweepResult/Refresh/Time").GetComponent("XUILabel") as IXUILabel);
			this.mRewardRefresh = (base.transform.FindChild("Bg/SweepResult/Refresh").GetComponent("XUIButton") as IXUIButton);
			this.mRewardGet = (base.transform.FindChild("Bg/SweepResult/GetReward").GetComponent("XUIButton") as IXUIButton);
			this.mRewardFx = (base.transform.FindChild("Bg/SweepResult/Buff/Fx").GetComponent("XUISprite") as IXUISprite);
			this.mRewardMoneyNum = (base.transform.FindChild("Bg/SweepResult/Refresh/moneynum").GetComponent("XUILabel") as IXUILabel);
			this.mRewardMoneySign = (base.transform.FindChild("Bg/SweepResult/Refresh/moneynum/moneysign").GetComponent("XUISprite") as IXUISprite);
			this.mRewardFreeLabel = (base.transform.FindChild("Bg/SweepResult/Refresh/moneyfree").GetComponent("XUILabel") as IXUILabel);
			this.mRewardFramePool.SetupPool(base.transform.FindChild("Bg/SweepResult").gameObject, base.transform.FindChild("Bg/SweepResult/Item").gameObject, 2U, false);
			Transform transform = base.transform.FindChild("Bg/SweepResult/Buff/Time/UI_heianshendian/UI_heianshendian/kuosan_00");
			this.mEffect = base.transform.FindChild("Bg/SweepResult/Buff/Time/UI_heianshendian/UI_heianshendian").gameObject;
			this.mFirstPassBtn = (base.transform.FindChild("Bg/FirstBlood").GetComponent("XUIButton") as IXUIButton);
			this.mFirstPassRedPoint = (base.transform.FindChild("Bg/FirstBlood/RedPoint").GetComponent("XUISprite") as IXUISprite);
			this.mFirstPassLevel = (base.transform.FindChild("Bg/FirstBlood/StageNum/Num").GetComponent("XUILabel") as IXUILabel);
			this.mFirstPassPanel = (base.transform.FindChild("Bg/FirstReward").GetComponent("XUISprite") as IXUISprite);
			this.mFirstPassGetReward = (base.transform.FindChild("Bg/FirstReward/GetReward/BtnReward").GetComponent("XUIButton") as IXUIButton);
			this.mFirstPassCheckReward = (base.transform.FindChild("Bg/FirstReward/CheckReward/BtnReward").GetComponent("XUIButton") as IXUIButton);
			this.mFIrstPassCheck = (base.transform.FindChild("Bg/FirstReward/CheckReward").GetComponent("XUISprite") as IXUISprite);
			this.mFirstPassGet = (base.transform.FindChild("Bg/FirstReward/GetReward").GetComponent("XUISprite") as IXUISprite);
			this.mFirstPassPlsThrough = (base.transform.FindChild("Bg/FirstReward/CheckReward/Result").GetComponent("XUILabel") as IXUILabel);
			this.mFirstPassCongraThrough = (base.transform.FindChild("Bg/FirstReward/GetReward/Result").GetComponent("XUILabel") as IXUILabel);
			this.mFirstPassBackClick = (base.transform.FindChild("Bg/FirstReward/backclick").GetComponent("XUISprite") as IXUISprite);
			this.mFirstPassPlayTween = (base.transform.FindChild("Bg/FirstBlood/Box").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.mFirstPassReward.SetupPool(base.transform.FindChild("Bg/FirstReward").gameObject, base.transform.FindChild("Bg/FirstReward/Item").gameObject, 3U, false);
		}

		// Token: 0x0600F313 RID: 62227 RVA: 0x00361F50 File Offset: 0x00360150
		private void OnApplicationPause(bool pause)
		{
			XSingleton<XDebug>.singleton.AddLog("OnApplicationPause:", pause.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			specificDocument.OnAppPaused();
		}

		// Token: 0x04006833 RID: 26675
		public IXUILabel mStage;

		// Token: 0x04006834 RID: 26676
		public IXUILabel mResetNum;

		// Token: 0x04006835 RID: 26677
		public IXUILabel mCurrentTime;

		// Token: 0x04006836 RID: 26678
		public IXUIButton mMainClose;

		// Token: 0x04006837 RID: 26679
		public IXUIButton m_Help;

		// Token: 0x04006838 RID: 26680
		public IXUIButton mRank;

		// Token: 0x04006839 RID: 26681
		public IXUIButton mGoBattle;

		// Token: 0x0400683A RID: 26682
		public IXUILabel mDemandFP;

		// Token: 0x0400683B RID: 26683
		public IXUIButton mSweepBtn;

		// Token: 0x0400683C RID: 26684
		public IXUIButton mResetBtn;

		// Token: 0x0400683D RID: 26685
		public IXUILabel mSweepLabel;

		// Token: 0x0400683E RID: 26686
		public IXUIButton mBackClick;

		// Token: 0x0400683F RID: 26687
		public IXUISprite mSweepResult;

		// Token: 0x04006840 RID: 26688
		public IXUIScrollView mScroll;

		// Token: 0x04006841 RID: 26689
		public IXUILabel mResetCount;

		// Token: 0x04006842 RID: 26690
		public IXUISprite mResetSprite;

		// Token: 0x04006843 RID: 26691
		public IXUISprite mSweepFrame;

		// Token: 0x04006844 RID: 26692
		public IXUILabel mSweepedLevel;

		// Token: 0x04006845 RID: 26693
		public IXUILabel mSweepEstimateTime;

		// Token: 0x04006846 RID: 26694
		public IXUIButton mSingleDoSweep;

		// Token: 0x04006847 RID: 26695
		public IXUIButton mDoubleSweep;

		// Token: 0x04006848 RID: 26696
		public IXUIButton mDoubleDoSweep;

		// Token: 0x04006849 RID: 26697
		public IXUIButton mCloseSweep;

		// Token: 0x0400684A RID: 26698
		public IXUISprite mSingleMoneySign;

		// Token: 0x0400684B RID: 26699
		public IXUILabel mSingleMoneyNum;

		// Token: 0x0400684C RID: 26700
		public IXUISprite mDoubleMoneySign;

		// Token: 0x0400684D RID: 26701
		public IXUILabel mDoubleMoneyNum;

		// Token: 0x0400684E RID: 26702
		public XUIPool mRewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400684F RID: 26703
		public XUIPool mMainRewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006850 RID: 26704
		public XUIPool mTowerPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006851 RID: 26705
		public IXUILabel mRewardLevel;

		// Token: 0x04006852 RID: 26706
		public IXUILabel mRewardAlpha;

		// Token: 0x04006853 RID: 26707
		public IXUILabel mRewardFreeTime;

		// Token: 0x04006854 RID: 26708
		public IXUIButton mRewardRefresh;

		// Token: 0x04006855 RID: 26709
		public IXUIButton mRewardGet;

		// Token: 0x04006856 RID: 26710
		public IXUISprite mRewardFx;

		// Token: 0x04006857 RID: 26711
		public IXUILabel mRewardMoneyNum;

		// Token: 0x04006858 RID: 26712
		public IXUISprite mRewardMoneySign;

		// Token: 0x04006859 RID: 26713
		public IXUILabel mRewardFreeLabel;

		// Token: 0x0400685A RID: 26714
		public GameObject mEffect;

		// Token: 0x0400685B RID: 26715
		public IXUIButton mFirstPassBtn;

		// Token: 0x0400685C RID: 26716
		public IXUISprite mFirstPassRedPoint;

		// Token: 0x0400685D RID: 26717
		public IXUILabel mFirstPassLevel;

		// Token: 0x0400685E RID: 26718
		public IXUISprite mFirstPassPanel;

		// Token: 0x0400685F RID: 26719
		public IXUIButton mFirstPassGetReward;

		// Token: 0x04006860 RID: 26720
		public IXUISprite mFIrstPassCheck;

		// Token: 0x04006861 RID: 26721
		public IXUIButton mFirstPassCheckReward;

		// Token: 0x04006862 RID: 26722
		public IXUISprite mFirstPassGet;

		// Token: 0x04006863 RID: 26723
		public IXUILabel mFirstPassPlsThrough;

		// Token: 0x04006864 RID: 26724
		public IXUILabel mFirstPassCongraThrough;

		// Token: 0x04006865 RID: 26725
		public IXUISprite mFirstPassBackClick;

		// Token: 0x04006866 RID: 26726
		public IXUITweenTool mFirstPassPlayTween;

		// Token: 0x04006867 RID: 26727
		public XUIPool mRewardFramePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006868 RID: 26728
		public XUIPool mFirstPassReward = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
