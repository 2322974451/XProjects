using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200180C RID: 6156
	internal class ScreenShotShareBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600FF37 RID: 65335 RVA: 0x003C25B4 File Offset: 0x003C07B4
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

		// Token: 0x040070CD RID: 28877
		public GameObject mCharFrame;

		// Token: 0x040070CE RID: 28878
		public IXUITweenTool mQQPlayTween;

		// Token: 0x040070CF RID: 28879
		public IXUITweenTool mWCPlayTween;

		// Token: 0x040070D0 RID: 28880
		public IXUISprite mQQFrame;

		// Token: 0x040070D1 RID: 28881
		public IXUISprite mWeChatFrame;

		// Token: 0x040070D2 RID: 28882
		public IXUIButton mQQBtn1;

		// Token: 0x040070D3 RID: 28883
		public IXUIButton mQQBtn2;

		// Token: 0x040070D4 RID: 28884
		public IXUIButton mWeChatBtn1;

		// Token: 0x040070D5 RID: 28885
		public IXUIButton mWeChatBtn2;

		// Token: 0x040070D6 RID: 28886
		public IXUIButton mDoScreenShot;

		// Token: 0x040070D7 RID: 28887
		public IUIDummy mSnapShot;

		// Token: 0x040070D8 RID: 28888
		public IXUIButton mClose;

		// Token: 0x040070D9 RID: 28889
		public GameObject mShareFrame;

		// Token: 0x040070DA RID: 28890
		public IXUISprite mKacha;

		// Token: 0x040070DB RID: 28891
		public IXUISprite mKachaFrame;

		// Token: 0x040070DC RID: 28892
		public IXUIButton mReqShareBtn;

		// Token: 0x040070DD RID: 28893
		public IXUIButton mSnapShotAgain;

		// Token: 0x040070DE RID: 28894
		public IXUITweenTool mPlayTween;

		// Token: 0x040070DF RID: 28895
		public IXUITweenTool mPicFramePlayTween;

		// Token: 0x040070E0 RID: 28896
		public IXUITexture mCaptureTexture;

		// Token: 0x040070E1 RID: 28897
		public GameObject mScaleDoing;

		// Token: 0x040070E2 RID: 28898
		public IXUISprite mSnapRoot;

		// Token: 0x040070E3 RID: 28899
		public IXUISprite mQQBackClick;

		// Token: 0x040070E4 RID: 28900
		public IXUISprite mWeChatBackClick;

		// Token: 0x040070E5 RID: 28901
		public IXUIButton mReqSave;

		// Token: 0x040070E6 RID: 28902
		public IXUISprite mModeSp;

		// Token: 0x040070E7 RID: 28903
		public IXUISprite mModeSelect;

		// Token: 0x040070E8 RID: 28904
		public IXUISprite mModeBack;

		// Token: 0x040070E9 RID: 28905
		public IXUISprite mDanceSp;

		// Token: 0x040070EA RID: 28906
		public IXUISprite mDanceSelect;

		// Token: 0x040070EB RID: 28907
		public IXUISprite mDanceBack;

		// Token: 0x040070EC RID: 28908
		public IXUIPanel mDanceBackSV;

		// Token: 0x040070ED RID: 28909
		public IXUIList mDanceBackList;

		// Token: 0x040070EE RID: 28910
		public IXUISprite mEffectsSp;

		// Token: 0x040070EF RID: 28911
		public IXUISprite mEffectsSelect;

		// Token: 0x040070F0 RID: 28912
		public IXUISprite mEffectsBack;

		// Token: 0x040070F1 RID: 28913
		public IXUISprite mEffectsMore;

		// Token: 0x040070F2 RID: 28914
		public IXUISprite mEffectsRedpoint;

		// Token: 0x040070F3 RID: 28915
		public IXUISprite mUnlockFrame;

		// Token: 0x040070F4 RID: 28916
		public IXUISprite mUnlockCondition;

		// Token: 0x040070F5 RID: 28917
		public IXUISprite mUnlockOption;

		// Token: 0x040070F6 RID: 28918
		public IXUISprite mUnlockBack;

		// Token: 0x040070F7 RID: 28919
		public IXUISprite mUnlockEffectWindow;

		// Token: 0x040070F8 RID: 28920
		public Transform mEffectParent;

		// Token: 0x040070F9 RID: 28921
		public IXUISlider mZoomSlider;

		// Token: 0x040070FA RID: 28922
		public GameObject mZoom;

		// Token: 0x040070FB RID: 28923
		public IXUISprite mThumb;

		// Token: 0x040070FC RID: 28924
		public GameObject mLogo;

		// Token: 0x040070FD RID: 28925
		public GameObject mLogoQQ;

		// Token: 0x040070FE RID: 28926
		public GameObject mLogoWC;

		// Token: 0x040070FF RID: 28927
		public IXUILabel mPlayerName;

		// Token: 0x04007100 RID: 28928
		public IXUILabel mServerName;

		// Token: 0x04007101 RID: 28929
		public IXUISprite mModeBg;

		// Token: 0x04007102 RID: 28930
		public IXUISprite mDanceBg;

		// Token: 0x04007103 RID: 28931
		public IXUISprite mEffectBg;

		// Token: 0x04007104 RID: 28932
		public XUIPool mModePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007105 RID: 28933
		public XUIPool mDancePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007106 RID: 28934
		public XUIPool mEffectPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007107 RID: 28935
		public XUIPool mEffectListPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007108 RID: 28936
		public XUIPool mConditionPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
