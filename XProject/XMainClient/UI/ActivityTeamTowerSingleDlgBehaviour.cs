using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ActivityTeamTowerSingleDlgBehaviour : DlgBehaviourBase
	{

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

		private void OnApplicationPause(bool pause)
		{
			XSingleton<XDebug>.singleton.AddLog("OnApplicationPause:", pause.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			specificDocument.OnAppPaused();
		}

		public IXUILabel mStage;

		public IXUILabel mResetNum;

		public IXUILabel mCurrentTime;

		public IXUIButton mMainClose;

		public IXUIButton m_Help;

		public IXUIButton mRank;

		public IXUIButton mGoBattle;

		public IXUILabel mDemandFP;

		public IXUIButton mSweepBtn;

		public IXUIButton mResetBtn;

		public IXUILabel mSweepLabel;

		public IXUIButton mBackClick;

		public IXUISprite mSweepResult;

		public IXUIScrollView mScroll;

		public IXUILabel mResetCount;

		public IXUISprite mResetSprite;

		public IXUISprite mSweepFrame;

		public IXUILabel mSweepedLevel;

		public IXUILabel mSweepEstimateTime;

		public IXUIButton mSingleDoSweep;

		public IXUIButton mDoubleSweep;

		public IXUIButton mDoubleDoSweep;

		public IXUIButton mCloseSweep;

		public IXUISprite mSingleMoneySign;

		public IXUILabel mSingleMoneyNum;

		public IXUISprite mDoubleMoneySign;

		public IXUILabel mDoubleMoneyNum;

		public XUIPool mRewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool mMainRewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool mTowerPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel mRewardLevel;

		public IXUILabel mRewardAlpha;

		public IXUILabel mRewardFreeTime;

		public IXUIButton mRewardRefresh;

		public IXUIButton mRewardGet;

		public IXUISprite mRewardFx;

		public IXUILabel mRewardMoneyNum;

		public IXUISprite mRewardMoneySign;

		public IXUILabel mRewardFreeLabel;

		public GameObject mEffect;

		public IXUIButton mFirstPassBtn;

		public IXUISprite mFirstPassRedPoint;

		public IXUILabel mFirstPassLevel;

		public IXUISprite mFirstPassPanel;

		public IXUIButton mFirstPassGetReward;

		public IXUISprite mFIrstPassCheck;

		public IXUIButton mFirstPassCheckReward;

		public IXUISprite mFirstPassGet;

		public IXUILabel mFirstPassPlsThrough;

		public IXUILabel mFirstPassCongraThrough;

		public IXUISprite mFirstPassBackClick;

		public IXUITweenTool mFirstPassPlayTween;

		public XUIPool mRewardFramePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool mFirstPassReward = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
