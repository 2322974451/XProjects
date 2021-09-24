using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ScreenShotShareBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.mCharFrame = base.transform.FindChild("CharacterFrame").gameObject;
			this.mShareFrame = base.transform.FindChild("Bg/sharebutton").gameObject;
			this.mQQFrame = (base.transform.FindChild("Bg/sharebutton/QQ").GetComponent("XUISprite") as IXUISprite);
			this.mQQPlayTween = (base.transform.FindChild("Bg/sharebutton/QQ").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.mWCPlayTween = (base.transform.FindChild("Bg/sharebutton/Wc").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.mWeChatFrame = (base.transform.FindChild("Bg/sharebutton/Wc").GetComponent("XUISprite") as IXUISprite);
			this.mQQBtn1 = (base.transform.FindChild("Bg/sharebutton/QQ/QQ1").GetComponent("XUIButton") as IXUIButton);
			this.mQQBtn2 = (base.transform.FindChild("Bg/sharebutton/QQ/QQ2").GetComponent("XUIButton") as IXUIButton);
			this.mWeChatBtn1 = (base.transform.FindChild("Bg/sharebutton/Wc/Wc1").GetComponent("XUIButton") as IXUIButton);
			this.mWeChatBtn2 = (base.transform.FindChild("Bg/sharebutton/Wc/Wc2").GetComponent("XUIButton") as IXUIButton);
			this.mDoScreenShot = (base.transform.FindChild("Bg/kacha/Ok").GetComponent("XUIButton") as IXUIButton);
			this.mSnapShot = (base.transform.FindChild("CharacterFrame/SnapRoot/Snapshot").GetComponent("UIDummy") as IUIDummy);
			this.mKachaFrame = (base.transform.FindChild("Bg/kacha").GetComponent("XUISprite") as IXUISprite);
			this.mClose = (base.transform.FindChild("Bg/kacha/Close").GetComponent("XUIButton") as IXUIButton);
			this.mKacha = (base.transform.FindChild("Bg/kacha/kacha").GetComponent("XUISprite") as IXUISprite);
			this.mReqShareBtn = (base.transform.FindChild("Bg/sharebutton/SwitchAccount").GetComponent("XUIButton") as IXUIButton);
			this.mSnapShotAgain = (base.transform.FindChild("Bg/sharebutton/Again").GetComponent("XUIButton") as IXUIButton);
			this.mPlayTween = (base.transform.FindChild("Bg/kacha/kacha").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.mPicFramePlayTween = (base.transform.FindChild("Bg/sharebutton").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.mCaptureTexture = (base.transform.FindChild("Bg/sharebutton").GetComponent("XUITexture") as IXUITexture);
			this.mScaleDoing = base.transform.FindChild("Bg/kacha/Ok/doing").gameObject;
			this.mSnapRoot = (base.transform.FindChild("CharacterFrame/SnapRoot").GetComponent("XUISprite") as IXUISprite);
			this.mQQBackClick = (base.transform.FindChild("Bg/sharebutton/QQ/back").GetComponent("XUISprite") as IXUISprite);
			this.mWeChatBackClick = (base.transform.FindChild("Bg/sharebutton/Wc/back").GetComponent("XUISprite") as IXUISprite);
			this.mReqSave = (base.transform.FindChild("Bg/sharebutton/Save").GetComponent("XUIButton") as IXUIButton);
			this.mEffectParent = base.transform.FindChild("CharacterFrame/effect");
			this.mModeSp = (base.transform.FindChild("Bg/kacha/Mode").GetComponent("XUISprite") as IXUISprite);
			this.mModeSelect = (base.transform.FindChild("Bg/kacha/Mode/Select").GetComponent("XUISprite") as IXUISprite);
			this.mModeBack = (base.transform.FindChild("Bg/kacha/Mode/Select/bar").GetComponent("XUISprite") as IXUISprite);
			this.mDanceSp = (base.transform.FindChild("Bg/kacha/Dance").GetComponent("XUISprite") as IXUISprite);
			this.mDanceSelect = (base.transform.FindChild("Bg/kacha/Dance/Select").GetComponent("XUISprite") as IXUISprite);
			this.mDanceBack = (base.transform.FindChild("Bg/kacha/Dance/Select/bar").GetComponent("XUISprite") as IXUISprite);
			this.mDanceBackSV = (base.transform.FindChild("Bg/kacha/Dance/Select/option").GetComponent("XUIPanel") as IXUIPanel);
			this.mDanceBackList = (base.transform.FindChild("Bg/kacha/Dance/Select/option/grid").GetComponent("XUIList") as IXUIList);
			this.mEffectsSp = (base.transform.FindChild("Bg/kacha/Effects").GetComponent("XUISprite") as IXUISprite);
			this.mEffectsSelect = (base.transform.FindChild("Bg/kacha/Effects/Select").GetComponent("XUISprite") as IXUISprite);
			this.mEffectsBack = (base.transform.FindChild("Bg/kacha/Effects/Select/bar").GetComponent("XUISprite") as IXUISprite);
			this.mEffectsMore = (base.transform.FindChild("Bg/kacha/Effects/Select/option/more").GetComponent("XUISprite") as IXUISprite);
			this.mEffectsRedpoint = (base.transform.FindChild("Bg/kacha/Effects/Select/option/more/redpoint").GetComponent("XUISprite") as IXUISprite);
			this.mUnlockFrame = (base.transform.FindChild("Bg/kacha/unlock").GetComponent("XUISprite") as IXUISprite);
			this.mUnlockOption = (base.transform.FindChild("Bg/kacha/unlock/unlock/option1").GetComponent("XUISprite") as IXUISprite);
			this.mUnlockCondition = (base.transform.FindChild("Bg/kacha/unlock/condition/condition1").GetComponent("XUISprite") as IXUISprite);
			this.mUnlockBack = (base.transform.FindChild("Bg/kacha/unlock/back").GetComponent("XUISprite") as IXUISprite);
			this.mUnlockEffectWindow = (base.transform.FindChild("Bg/kacha/unlock/window").GetComponent("XUISprite") as IXUISprite);
			this.mZoomSlider = (base.transform.FindChild("Bg/kacha/bar/bar").GetComponent("XUISlider") as IXUISlider);
			this.mThumb = (base.transform.FindChild("Bg/kacha/Mode").GetComponent("XUISprite") as IXUISprite);
			this.mZoom = base.transform.FindChild("Bg/kacha/bar").gameObject;
			this.mLogo = base.transform.FindChild("Bg/kacha/Logo").gameObject;
			this.mLogoQQ = base.transform.FindChild("Bg/kacha/Logo/LogoQQ").gameObject;
			this.mLogoWC = base.transform.FindChild("Bg/kacha/Logo/LogoWC").gameObject;
			this.mPlayerName = (base.transform.FindChild("Bg/kacha/Logo/label/name").GetComponent("XUILabel") as IXUILabel);
			this.mServerName = (base.transform.FindChild("Bg/kacha/Logo/label/fuwuqi").GetComponent("XUILabel") as IXUILabel);
			this.mModeBg = (base.transform.FindChild("Bg/kacha/Mode/Select/bg").GetComponent("XUISprite") as IXUISprite);
			this.mModeBg.ID = 1UL;
			this.mDanceBg = (base.transform.FindChild("Bg/kacha/Dance/Select/bg").GetComponent("XUISprite") as IXUISprite);
			this.mDanceBg.ID = 2UL;
			this.mEffectBg = (base.transform.FindChild("Bg/kacha/Effects/Select/bg").GetComponent("XUISprite") as IXUISprite);
			this.mEffectBg.ID = 3UL;
			this.mModePool.SetupPool(this.mModeSelect.gameObject, this.mModeSelect.transform.FindChild("option").gameObject, 5U, false);
			this.mDancePool.SetupPool(this.mDanceBackList.gameObject, this.mDanceBackList.gameObject.transform.FindChild("option1").gameObject, 5U, false);
			this.mEffectPool.SetupPool(this.mEffectsSelect.transform.FindChild("option").gameObject, this.mEffectsSelect.transform.FindChild("option/option1").gameObject, 5U, false);
			this.mEffectListPool.SetupPool(this.mUnlockOption.parent.gameObject, this.mUnlockOption.gameObject, 5U, false);
			this.mConditionPool.SetupPool(this.mUnlockCondition.parent.gameObject, this.mUnlockCondition.gameObject, 5U, false);
		}

		public GameObject mCharFrame;

		public IXUITweenTool mQQPlayTween;

		public IXUITweenTool mWCPlayTween;

		public IXUISprite mQQFrame;

		public IXUISprite mWeChatFrame;

		public IXUIButton mQQBtn1;

		public IXUIButton mQQBtn2;

		public IXUIButton mWeChatBtn1;

		public IXUIButton mWeChatBtn2;

		public IXUIButton mDoScreenShot;

		public IUIDummy mSnapShot;

		public IXUIButton mClose;

		public GameObject mShareFrame;

		public IXUISprite mKacha;

		public IXUISprite mKachaFrame;

		public IXUIButton mReqShareBtn;

		public IXUIButton mSnapShotAgain;

		public IXUITweenTool mPlayTween;

		public IXUITweenTool mPicFramePlayTween;

		public IXUITexture mCaptureTexture;

		public GameObject mScaleDoing;

		public IXUISprite mSnapRoot;

		public IXUISprite mQQBackClick;

		public IXUISprite mWeChatBackClick;

		public IXUIButton mReqSave;

		public IXUISprite mModeSp;

		public IXUISprite mModeSelect;

		public IXUISprite mModeBack;

		public IXUISprite mDanceSp;

		public IXUISprite mDanceSelect;

		public IXUISprite mDanceBack;

		public IXUIPanel mDanceBackSV;

		public IXUIList mDanceBackList;

		public IXUISprite mEffectsSp;

		public IXUISprite mEffectsSelect;

		public IXUISprite mEffectsBack;

		public IXUISprite mEffectsMore;

		public IXUISprite mEffectsRedpoint;

		public IXUISprite mUnlockFrame;

		public IXUISprite mUnlockCondition;

		public IXUISprite mUnlockOption;

		public IXUISprite mUnlockBack;

		public IXUISprite mUnlockEffectWindow;

		public Transform mEffectParent;

		public IXUISlider mZoomSlider;

		public GameObject mZoom;

		public IXUISprite mThumb;

		public GameObject mLogo;

		public GameObject mLogoQQ;

		public GameObject mLogoWC;

		public IXUILabel mPlayerName;

		public IXUILabel mServerName;

		public IXUISprite mModeBg;

		public IXUISprite mDanceBg;

		public IXUISprite mEffectBg;

		public XUIPool mModePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool mDancePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool mEffectPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool mEffectListPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool mConditionPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
