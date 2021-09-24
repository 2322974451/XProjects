

using KKSG;
using System.Collections.Generic;
using System.IO;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class ScreenShotShareView : DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>
    {
        private XScreenShotShareDocument _doc = (XScreenShotShareDocument)null;
        private int _share_count = 0;
        private uint _dance_timer_token = 0;
        private uint _check_pic_token = 0;
        private XFx _playing_fx = (XFx)null;
        private float _max_dist = 9f;
        private float _min_dist = 3f;
        private HashSet<uint> _check_index = new HashSet<uint>();
        private List<GameObject> _mode_go = new List<GameObject>();
        private List<GameObject> _mode_effectgo = new List<GameObject>();
        private string _saved_file_path = "";
        private int _dance_num = 0;
        private XFx fx;

        public override string fileName => "Common/Share";

        public override int layer => 1;

        public override bool autoload => true;

        public override bool hideMainMenu => true;

        public override int group => 1;

        protected override void Init()
        {
            this._doc = XDocuments.GetSpecificDocument<XScreenShotShareDocument>(XScreenShotShareDocument.uuID);
            this._doc.ScreenShotView = this;
            string[] strArray = XSingleton<XGlobalConfig>.singleton.GetValue("CameraValue").Split('|');
            this._min_dist = float.Parse(strArray[0]);
            this._max_dist = float.Parse(strArray[1]);
            this.fx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_Share", this.uiBehaviour.mEffectParent);
            this.InitLeftMenu();
        }

        public override void RegisterEvent()
        {
            this.uiBehaviour.mQQBtn1.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnQQShareSession));
            this.uiBehaviour.mQQBtn2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnQQShareQZone));
            this.uiBehaviour.mWeChatBtn1.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnWeChatShareSession));
            this.uiBehaviour.mWeChatBtn2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnWeChatShareTimeLine));
            this.uiBehaviour.mClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
            this.uiBehaviour.mDoScreenShot.RegisterClickEventHandler(new ButtonClickEventHandler(this.CaptureScreenShot));
            this.uiBehaviour.mReqShareBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ReqShare));
            this.uiBehaviour.mSnapShotAgain.RegisterClickEventHandler(new ButtonClickEventHandler(this.ReScreenShot));
            this.uiBehaviour.mQQBackClick.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseShare));
            this.uiBehaviour.mWeChatBackClick.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseShare));
            this.uiBehaviour.mSnapRoot.RegisterSpriteDragEventHandler(new SpriteDragEventHandler(this.OnCharacterWindowDrag));
            this.uiBehaviour.mReqSave.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSavePic));
            this.uiBehaviour.mModeSp.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnShowMode));
            this.uiBehaviour.mDanceSp.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnShowAnim));
            this.uiBehaviour.mEffectsSp.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnShowFx));
            this.uiBehaviour.mEffectsMore.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnShowMoreFx));
            this.uiBehaviour.mUnlockBack.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHideUnlock));
            this.uiBehaviour.mZoomSlider.RegisterValueChangeEventHandler(new SliderValueChangeEventHandler(this.OnZoomSliderChanged));
            this.uiBehaviour.mModeBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBg));
            this.uiBehaviour.mDanceBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBg));
            this.uiBehaviour.mEffectBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBg));
            base.RegisterEvent();
        }

        protected override void OnShow()
        {
            this.ShowCaptureFrame();
            switch (XSingleton<XScene>.singleton.SceneType)
            {
                case SceneType.SCENE_FAMILYGARDEN:
                    if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._HomeHandler != null)
                    {
                        DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._HomeHandler.SetVisible(false);
                        break;
                    }
                    break;
                case SceneType.SCENE_WEDDING:
                    if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler != null)
                    {
                        DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.SetVisible(false);
                        break;
                    }
                    break;
                case SceneType.SCENE_LEISURE:
                    if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._yorozuyaHandler != null)
                    {
                        DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._yorozuyaHandler.SetVisible(false);
                        break;
                    }
                    break;
            }
            this.OnReqEffect();
            this.uiBehaviour.mDoScreenShot.SetAudioClip("Audio/UI/Cam_photo");
            this.uiBehaviour.mZoomSlider.Value = (float)(((double)XSingleton<XScene>.singleton.GameCamera.TargetOffset - (double)this._min_dist) / ((double)this._max_dist - (double)this._min_dist));
            this.InitDance();
            XSingleton<PDatabase>.singleton.shareCallbackType = ShareCallBackType.WeekShare;
        }

        protected override void OnHide()
        {
            if (DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsLoaded() && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible())
                DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.StackRefresh();
            switch (XSingleton<XScene>.singleton.SceneType)
            {
                case SceneType.SCENE_FAMILYGARDEN:
                    if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._HomeHandler != null)
                    {
                        DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._HomeHandler.SetVisible(true);
                        break;
                    }
                    break;
                case SceneType.SCENE_WEDDING:
                    if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler != null)
                    {
                        DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.SetVisible(true);
                        break;
                    }
                    break;
                case SceneType.SCENE_LEISURE:
                    if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._yorozuyaHandler != null)
                    {
                        DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._yorozuyaHandler.SetVisible(true);
                        break;
                    }
                    break;
            }
            XSingleton<XTimerMgr>.singleton.KillTimer(this._dance_timer_token);
            this._dance_timer_token = 0U;
            XSingleton<XTimerMgr>.singleton.KillTimer(this._check_pic_token);
            this._check_pic_token = 0U;
            this.OnResetEntityRender();
            this.OnStopPlayingFX();
            for (int index = 0; index < this._mode_go.Count; ++index)
                (this._mode_go[index].transform.FindChild("option1/Normal").GetComponent("XUICheckBox") as IXUICheckBox).bChecked = true;
            for (int index = 0; index < this._mode_effectgo.Count; ++index)
                (this._mode_effectgo[index].transform.FindChild("Normal").GetComponent("XUICheckBox") as IXUICheckBox).bChecked = false;
            XSingleton<XScene>.singleton.GameCamera.TargetOffset = XSingleton<XScene>.singleton.GameCamera.DefaultOffset;
            XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.GausBlur, false);
            this.uiBehaviour.mCaptureTexture.SetRuntimeTex((Texture)null);
        }

        protected override void OnUnload()
        {
            if (this.fx == null)
                return;
            XSingleton<XFxMgr>.singleton.DestroyFx(this.fx);
            this.fx = (XFx)null;
        }

        public override void StackRefresh()
        {
            base.StackRefresh();
            XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, this.uiBehaviour.mSnapShot);
        }

        public void ShowMainView()
        {
            this.uiBehaviour.mCharFrame.SetActive(false);
            this.uiBehaviour.mUnlockFrame.SetVisible(false);
            this.uiBehaviour.mModeSelect.SetVisible(false);
            this.uiBehaviour.mDanceSelect.SetVisible(false);
            this.uiBehaviour.mEffectsSelect.SetVisible(false);
        }

        public void ShowCharView()
        {
            this.uiBehaviour.mCharFrame.SetActive(true);
            this.uiBehaviour.mUnlockFrame.SetVisible(false);
            this.uiBehaviour.mModeSelect.SetVisible(false);
            this.uiBehaviour.mDanceSelect.SetVisible(false);
            this.uiBehaviour.mEffectsSelect.SetVisible(false);
            XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, this.uiBehaviour.mSnapShot);
        }

        private void ShowCaptureFrame()
        {
            this.uiBehaviour.mCaptureTexture.SetRuntimeTex((Texture)null);
            this.uiBehaviour.mDoScreenShot.SetVisible(true);
            this.uiBehaviour.mKacha.SetVisible(false);
            this.uiBehaviour.mShareFrame.SetActive(false);
            this.uiBehaviour.mClose.SetVisible(true);
            this.uiBehaviour.mScaleDoing.SetActive(true);
            this.uiBehaviour.mLogo.SetActive(false);
            XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.GausBlur, false);
            this.uiBehaviour.mSnapRoot.transform.localPosition = new Vector3(this.uiBehaviour.mSnapRoot.transform.localPosition.x, this.uiBehaviour.mSnapRoot.transform.localPosition.y, 0.0f);
        }

        public void IOS3DTouchScreenShot()
        {
            this.uiBehaviour.mDoScreenShot.SetVisible(false);
            this.uiBehaviour.mClose.SetVisible(false);
            this.uiBehaviour.mScaleDoing.SetActive(false);
            this.uiBehaviour.mModeSp.SetVisible(false);
            this.uiBehaviour.mDanceSp.SetVisible(false);
            this.uiBehaviour.mEffectsSp.SetVisible(false);
            this.uiBehaviour.mZoom.SetActive(false);
            this.uiBehaviour.mZoom.SetActive(true);
            this.uiBehaviour.mLogo.SetActive(true);
            if (XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ)
            {
                this.uiBehaviour.mLogoQQ.SetActive(true);
                this.uiBehaviour.mLogoWC.SetActive(false);
            }
            else
            {
                this.uiBehaviour.mLogoQQ.SetActive(false);
                this.uiBehaviour.mLogoWC.SetActive(true);
            }
            this.uiBehaviour.mPlayerName.SetText(XSingleton<XAttributeMgr>.singleton.XPlayerData.Name);
            this.uiBehaviour.mServerName.SetText(XSingleton<XClientNetwork>.singleton.Server);
            DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(false);
            int num1 = (int)XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(XSingleton<XScreenShotMgr>.singleton.CaptureScreenshot), (object)null);
            int num2 = (int)XSingleton<XTimerMgr>.singleton.SetTimer(0.2f, new XTimerMgr.ElapsedEventHandler(this.PlayScreenFx), (object)null);
        }

        public bool CaptureScreenShot(IXUIButton btn)
        {
            this.uiBehaviour.mDoScreenShot.SetVisible(false);
            this.uiBehaviour.mClose.SetVisible(false);
            this.uiBehaviour.mScaleDoing.SetActive(false);
            this.uiBehaviour.mModeSp.SetVisible(false);
            this.uiBehaviour.mDanceSp.SetVisible(false);
            this.uiBehaviour.mEffectsSp.SetVisible(false);
            this.uiBehaviour.mZoom.SetActive(false);
            this.uiBehaviour.mLogo.SetActive(true);
            if (XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ)
            {
                this.uiBehaviour.mLogoQQ.SetActive(true);
                this.uiBehaviour.mLogoWC.SetActive(false);
            }
            else
            {
                this.uiBehaviour.mLogoQQ.SetActive(false);
                this.uiBehaviour.mLogoWC.SetActive(true);
            }
            this.uiBehaviour.mPlayerName.SetText(XSingleton<XAttributeMgr>.singleton.XPlayerData.Name);
            this.uiBehaviour.mServerName.SetText(XSingleton<XClientNetwork>.singleton.Server);
            DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(false);
            XSingleton<XScreenShotMgr>.singleton.CaptureScreenshot((object)null);
            int num = (int)XSingleton<XTimerMgr>.singleton.SetTimer(0.2f, new XTimerMgr.ElapsedEventHandler(this.PlayScreenFx), (object)null);
            return true;
        }

        public bool ReqShare(IXUIButton btn)
        {
            if (XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ)
            {
                if (!XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CheckStatus("QQ_Installed", ""))
                {
                    XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ERR_QQ_NOT_INSTALLED"), "fece00");
                    return false;
                }
                this.uiBehaviour.mQQFrame.SetVisible(true);
                this.uiBehaviour.mWeChatFrame.SetVisible(false);
                this.uiBehaviour.mQQPlayTween.SetTweenGroup(0);
                this.uiBehaviour.mQQPlayTween.ResetTweenByGroup(true);
                this.uiBehaviour.mQQPlayTween.PlayTween(true);
            }
            else if (XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat)
            {
                if (!XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CheckStatus("Weixin_Installed", ""))
                {
                    XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ERR_WECHAT_NOT_INSTALLED"), "fece00");
                    return false;
                }
                this.uiBehaviour.mQQFrame.SetVisible(false);
                this.uiBehaviour.mWeChatFrame.SetVisible(true);
                this.uiBehaviour.mWCPlayTween.SetTweenGroup(0);
                this.uiBehaviour.mWCPlayTween.ResetTweenByGroup(true);
                this.uiBehaviour.mWCPlayTween.PlayTween(true);
            }
            return true;
        }

        public bool ReScreenShot(IXUIButton btn)
        {
            this.ShowCaptureFrame();
            return true;
        }

        private void PlayScreenFx(object obj)
        {
            this.uiBehaviour.mKacha.SetVisible(true);
            this.uiBehaviour.mPlayTween.SetTweenGroup(0);
            this.uiBehaviour.mPlayTween.ResetTweenByGroup(true);
            this.uiBehaviour.mPlayTween.PlayTween(true);
            int num = (int)XSingleton<XTimerMgr>.singleton.SetTimer(0.4f, new XTimerMgr.ElapsedEventHandler(this.ShowShare), (object)null);
            this.uiBehaviour.mSnapRoot.transform.localPosition = new Vector3(this.uiBehaviour.mSnapRoot.transform.localPosition.x, this.uiBehaviour.mSnapRoot.transform.localPosition.y, 1000f);
            this._share_count = 0;
        }

        private void ShowShare(object obj)
        {
            if (!this.IsVisible())
                return;
            if (!File.Exists(XSingleton<XScreenShotMgr>.singleton.FilePath))
            {
                this.uiBehaviour.mSnapRoot.transform.localPosition = new Vector3(this.uiBehaviour.mSnapRoot.transform.localPosition.x, this.uiBehaviour.mSnapRoot.transform.localPosition.y, 0.0f);
                ++this._share_count;
                if (this._share_count > 30)
                {
                    XSingleton<UiUtility>.singleton.ShowSystemTip("Failed", "fece00");
                }
                else
                {
                    int num = (int)XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.ShowShare), (object)null);
                }
            }
            else
            {
                this.uiBehaviour.mSnapRoot.transform.localPosition = new Vector3(this.uiBehaviour.mSnapRoot.transform.localPosition.x, this.uiBehaviour.mSnapRoot.transform.localPosition.y, 1000f);
                this.uiBehaviour.mShareFrame.SetActive(true);
                this.uiBehaviour.mDoScreenShot.SetVisible(false);
                this.uiBehaviour.mQQFrame.SetVisible(false);
                this.uiBehaviour.mWeChatFrame.SetVisible(false);
                this.uiBehaviour.mModeSp.SetVisible(true);
                this.uiBehaviour.mDanceSp.SetVisible(true);
                this.uiBehaviour.mEffectsSp.SetVisible(true);
                this.uiBehaviour.mZoom.SetActive(true);
                this.uiBehaviour.mLogo.SetActive(false);
                this.uiBehaviour.mReqShareBtn.SetVisible(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Photo_Share));
                DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(true);
                this.OnStopPlayingFX();
                XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.GausBlur, true);
                this.uiBehaviour.mPicFramePlayTween.SetTweenGroup(0);
                this.uiBehaviour.mPicFramePlayTween.ResetTweenByGroup(true);
                this.uiBehaviour.mPicFramePlayTween.PlayTween(true);
                XSingleton<XDebug>.singleton.AddLog("The screen file path: ", XSingleton<XScreenShotMgr>.singleton.FilePath);
                XSingleton<XDebug>.singleton.AddLog("File exist: ", File.Exists(XSingleton<XScreenShotMgr>.singleton.FilePath).ToString());
                switch (Application.platform)
                {
                    case RuntimePlatform.IPhonePlayer:
                    case RuntimePlatform.Android:
                        byte[] data1 = File.ReadAllBytes(XSingleton<XScreenShotMgr>.singleton.FilePath);
                        Texture2D texture2D1 = new Texture2D(2, 2);
                        bool flag = texture2D1.LoadImage(data1);
                        if (flag)
                        {
                            this.uiBehaviour.mCaptureTexture.SetRuntimeTex((Texture)texture2D1);
                            int width = texture2D1.width;
                            int height = texture2D1.height;
                            if (width > 600)
                                break;
                            this.ShowCaptureFrame();
                            break;
                        }
                        if (!flag)
                            this.ShowCaptureFrame();
                        break;
                    default:
                        byte[] data2 = File.ReadAllBytes(XSingleton<XScreenShotMgr>.singleton.FilePath);
                        if (data2 == null)
                            break;
                        Texture2D texture2D2 = new Texture2D(2, 2);
                        texture2D2.LoadImage(data2);
                        this.uiBehaviour.mCaptureTexture.SetRuntimeTex((Texture)texture2D2);
                        break;
                }
            }
        }

        public bool OnQQShareSession(IXUIButton btn)
        {
            XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.MainCityShare);
            XSingleton<XScreenShotMgr>.singleton.ShareScreen(true);
            return true;
        }

        public bool OnQQShareQZone(IXUIButton btn)
        {
            XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.MainCityShare);
            XSingleton<XScreenShotMgr>.singleton.ShareScreen(false);
            return true;
        }

        public bool OnWeChatShareSession(IXUIButton btn)
        {
            XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.MainCityShare);
            XSingleton<XScreenShotMgr>.singleton.ShareScreen(true);
            return true;
        }

        public bool OnWeChatShareTimeLine(IXUIButton btn)
        {
            XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.MainCityShare);
            XSingleton<XScreenShotMgr>.singleton.ShareScreen(false);
            return true;
        }

        public bool OnClose(IXUIButton btn)
        {
            this.SetVisible(false, true);
            return true;
        }

        public void OnCloseShare(IXUISprite sp)
        {
            this.uiBehaviour.mQQFrame.SetVisible(false);
            this.uiBehaviour.mWeChatFrame.SetVisible(false);
        }

        private bool OnDance(IXUIButton btn)
        {
            float length = XSingleton<X3DAvatarMgr>.singleton.SetMainAnimationGetLength(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.Dance);
            XSingleton<XTimerMgr>.singleton.KillTimer(this._dance_timer_token);
            int num = XSingleton<XGlobalConfig>.singleton.GetInt("DanceLoopCount");
            this._dance_timer_token = XSingleton<XTimerMgr>.singleton.SetTimer(length * (float)num, new XTimerMgr.ElapsedEventHandler(this.OnFinishDance), (object)null);
            return true;
        }

        private void OnFinishDance(object obj) => XSingleton<X3DAvatarMgr>.singleton.SetMainAnimation(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.Idle);

        protected bool OnCharacterWindowDrag(Vector2 delta)
        {
            XSingleton<X3DAvatarMgr>.singleton.RotateMain((float)(-(double)delta.x / 2.0));
            return true;
        }

        private void OnShowMode(IXUISprite sp)
        {
            if (this.uiBehaviour.mModeSelect.IsVisible())
                this.uiBehaviour.mModeSelect.SetVisible(false);
            else
                this.uiBehaviour.mModeSelect.SetVisible(true);
            this.uiBehaviour.mDanceSelect.SetVisible(false);
            this.uiBehaviour.mEffectsSelect.SetVisible(false);
        }

        private void OnShowAnim(IXUISprite sp)
        {
            if (this._dance_num == 0)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ERR_NO_DANCE_ANIM"), "fece00");
            }
            else
            {
                this.uiBehaviour.mModeSelect.SetVisible(false);
                if (this.uiBehaviour.mDanceSelect.IsVisible())
                    this.uiBehaviour.mDanceSelect.SetVisible(false);
                else
                    this.uiBehaviour.mDanceSelect.SetVisible(true);
                this.uiBehaviour.mEffectsSelect.SetVisible(false);
            }
        }

        private void OnShowFx(IXUISprite sp)
        {
            this.uiBehaviour.mModeSelect.SetVisible(false);
            this.uiBehaviour.mDanceSelect.SetVisible(false);
            if (this.uiBehaviour.mEffectsSelect.IsVisible())
                this.uiBehaviour.mEffectsSelect.SetVisible(false);
            else
                this.uiBehaviour.mEffectsSelect.SetVisible(true);
        }

        private void OnShowMoreFx(IXUISprite sp)
        {
            this.uiBehaviour.mEffectsSelect.SetVisible(false);
            if (this.uiBehaviour.mUnlockFrame.IsVisible())
                return;
            if (this.OnShowMoreFxFrame() > 0)
                this.uiBehaviour.mUnlockFrame.SetVisible(true);
            else
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ERR_NO_MORE_EFFECTS"), "fece00");
        }

        private int OnShowMoreFxFrame()
        {
            this.OnStopPlayingFX();
            this.uiBehaviour.mEffectListPool.ReturnAll();
            uint index1 = 0;
            int num = 0;
            for (int index2 = 0; index2 < this._doc.EffectAllListId.Count; ++index2)
            {
                if (!this._doc.EffectListId.Contains(this._doc.EffectAllListId[index2]))
                {
                    if (index1 == 0U)
                        index1 = this._doc.EffectAllListId[index2];
                    List<PhotographEffectCfg.RowData> rowDataById = this._doc.GetRowDataById(this._doc.EffectAllListId[index2]);
                    GameObject gameObject = this.uiBehaviour.mEffectListPool.FetchGameObject();
                    gameObject.transform.localPosition = new Vector3(this.uiBehaviour.mEffectListPool.TplPos.x, this.uiBehaviour.mEffectListPool.TplPos.y - (float)(num * this.uiBehaviour.mEffectListPool.TplHeight), this.uiBehaviour.mEffectListPool.TplPos.z);
                    (gameObject.transform.FindChild("t").GetComponent("XUILabel") as IXUILabel).SetText(rowDataById[0].EffectName);
                    (gameObject.transform.FindChild("t2").GetComponent("XUILabel") as IXUILabel).SetText(rowDataById[0].EffectName);
                    IXUICheckBox component = gameObject.transform.GetComponent("XUICheckBox") as IXUICheckBox;
                    component.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSelectEffect));
                    component.ID = (ulong)this._doc.EffectAllListId[index2];
                    if (num == 0)
                    {
                        component.bChecked = true;
                        this.OnSetEffect((int)this._doc.EffectAllListId[index2]);
                    }
                    else
                        component.bChecked = false;
                    ++num;
                }
            }
            this.OnInitUnlockInfo(index1);
            return num;
        }

        private void OnInitUnlockInfo(uint index)
        {
            List<PhotographEffectCfg.RowData> rowDataById = this._doc.GetRowDataById(index);
            this.uiBehaviour.mConditionPool.ReturnAll();
            for (int index1 = 0; index1 < rowDataById.Count; ++index1)
            {
                bool flag = false;
                GameObject gameObject = this.uiBehaviour.mConditionPool.FetchGameObject();
                gameObject.transform.localPosition = new Vector3(this.uiBehaviour.mConditionPool.TplPos.x, this.uiBehaviour.mConditionPool.TplPos.y - (float)(index1 * this.uiBehaviour.mConditionPool.TplHeight), this.uiBehaviour.mConditionPool.TplPos.z);
                IXUILabel component1 = gameObject.transform.FindChild("condition1").GetComponent("XUILabel") as IXUILabel;
                IXUILabel component2 = gameObject.transform.FindChild("Label").GetComponent("XUILabel") as IXUILabel;
                IXUISprite component3 = gameObject.transform.FindChild("ok").GetComponent("XUISprite") as IXUISprite;
                uint num1 = rowDataById[index1].Condition[0, 0];
                uint num2 = rowDataById[index1].Condition[0, 1];
                switch (num1)
                {
                    case 1:
                        if (this._doc.CharmVal >= num2)
                        {
                            flag = true;
                            break;
                        }
                        break;
                    case 2:
                        if (XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.Level >= num2)
                        {
                            flag = true;
                            break;
                        }
                        break;
                    case 3:
                        if ((double)XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID).TotalPay >= (double)num2)
                        {
                            flag = true;
                            break;
                        }
                        break;
                    case 4:
                        if (XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID).IsOwnMemberPrivilege((MemberPrivilege)num2))
                        {
                            flag = true;
                            break;
                        }
                        break;
                }
                component1.SetText(rowDataById[index1].ConditionDesc);
                component2.SetText(rowDataById[index1].desc);
                component2.ID = (ulong)rowDataById[index1].SystemID;
                component2.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnEnterSystemUnlock));
                if (flag)
                {
                    component3.SetVisible(true);
                    component2.SetVisible(false);
                }
                else
                {
                    component3.SetVisible(false);
                    component2.SetVisible(true);
                }
            }
        }

        private void OnStopPlayingFX()
        {
            if (this._playing_fx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._playing_fx);
            this._playing_fx = (XFx)null;
        }

        private void OnEnterSystemUnlock(IXUILabel lb)
        {
            this.SetVisible(false, true);
            XSingleton<XGameSysMgr>.singleton.OpenSystem((XSysDefine)lb.ID);
        }

        private void OnHideUnlock(IXUISprite sp)
        {
            this.uiBehaviour.mUnlockFrame.SetVisible(false);
            this.OnStopPlayingFX();
        }

        public bool OnModeChanged(IXUICheckBox box)
        {
            if (!box.bChecked)
            {
                if (this._check_index.Contains((uint)box.ID))
                    this._check_index.Remove((uint)box.ID);
            }
            else if (!this._check_index.Contains((uint)box.ID))
                this._check_index.Add((uint)box.ID);
            this.OnRefreshPlayerRender();
            return true;
        }

        public bool OnAnimChanged(IXUICheckBox box)
        {
            if (!box.bChecked)
                return false;
            XDanceDocument.Doc.ReqStartJustDance((uint)box.ID);
            return true;
        }

        public bool OnEffectChanged(IXUICheckBox box)
        {
            this.OnStopPlayingFX();
            if (!box.bChecked)
                return false;
            Transform transform = XSingleton<UIManager>.singleton.UIRoot.Find("Camera").transform;
            this._playing_fx = XSingleton<XFxMgr>.singleton.CreateAndPlay(this._doc.GetRowDataById((uint)box.ID)[0].EffectRoute, transform, Vector3.zero, Vector3.one, follow: true, duration: 3600f);
            return true;
        }

        private void OnSetEffect(int index)
        {
            this.OnInitUnlockInfo((uint)index);
            this.OnStopPlayingFX();
            this._playing_fx = XSingleton<XFxMgr>.singleton.CreateUIFx(this._doc.GetRowDataById((uint)index)[0].EffectRoute, this.uiBehaviour.mUnlockEffectWindow.transform, new Vector3(0.25f, 0.25f, 0.25f));
        }

        public bool OnSelectEffect(IXUICheckBox box)
        {
            if (!box.bChecked)
                return false;
            this.OnSetEffect((int)box.ID);
            return true;
        }

        public bool OnSavePic(IXUIButton btn)
        {
            if (this._saved_file_path == XSingleton<XScreenShotMgr>.singleton.FilePath)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CAMERA_SAVED_ERR"), "fece00");
                return false;
            }
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    this._saved_file_path = XSingleton<XScreenShotMgr>.singleton.FilePath;
                    XSingleton<XScreenShotMgr>.singleton.SaveScreenshotPic(this._saved_file_path);
                    break;
                case RuntimePlatform.Android:
                    string str = Application.persistentDataPath + "/../../../../DCIM/Camera";
                    if (!Directory.Exists(str))
                        Directory.CreateDirectory(str);
                    File.Copy(XSingleton<XScreenShotMgr>.singleton.FilePath, str + "/" + XSingleton<XScreenShotMgr>.singleton.FileName);
                    XSingleton<XScreenShotMgr>.singleton.RefreshPhotoView(str);
                    break;
            }
            XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CAMERA_SAVED"), "fece00");
            this._saved_file_path = XSingleton<XScreenShotMgr>.singleton.FilePath;
            return true;
        }

        public void OnAnimStart(IXUISprite sp)
        {
        }

        public void OnClickBg(IXUISprite sp)
        {
            if (sp.ID == 1UL)
                this.uiBehaviour.mModeSelect.SetVisible(false);
            else if (sp.ID == 2UL)
            {
                this.uiBehaviour.mDanceSelect.SetVisible(false);
            }
            else
            {
                if (sp.ID != 3UL)
                    return;
                this.uiBehaviour.mEffectsSelect.SetVisible(false);
            }
        }

        public bool OnZoomSliderChanged(float val)
        {
            XSingleton<XScene>.singleton.GameCamera.TargetOffset = this._min_dist + (this._max_dist - this._min_dist) * val;
            return true;
        }

        public bool CanRenderOtherPalyers() => !this.IsLoaded() || !this.IsVisible() || this._check_index.Contains(1U);

        private void OnRefreshPlayerRender()
        {
            bool flag = this._check_index.Contains(0U);
            if (XSingleton<XEntityMgr>.singleton.Player != null)
            {
                XSingleton<XScene>.singleton.GameCamera.SetCameraLayer(XPlayer.PlayerLayer, flag);
                XSingleton<XCustomShadowMgr>.singleton.SetCullLayer(flag);
                XBillboardShowCtrlEventArgs showCtrlEventArgs = XEventPool<XBillboardShowCtrlEventArgs>.GetEvent();
                showCtrlEventArgs.show = flag;
                showCtrlEventArgs.Firer = (XObject)XSingleton<XEntityMgr>.singleton.Player;
                showCtrlEventArgs.type = BillBoardHideType.Photo;
                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)showCtrlEventArgs);
            }
            bool add1 = this._check_index.Contains(2U);
            XSingleton<XScene>.singleton.GameCamera.SetCameraLayer(XNpc.NpcLayer, add1);
            List<uint> npcs = XSingleton<XEntityMgr>.singleton.GetNpcs(XSingleton<XScene>.singleton.SceneID);
            if (npcs != null)
            {
                for (int index = 0; index < npcs.Count; ++index)
                {
                    XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc(npcs[index]);
                    if (npc != null)
                    {
                        XBillboardShowCtrlEventArgs showCtrlEventArgs = XEventPool<XBillboardShowCtrlEventArgs>.GetEvent();
                        showCtrlEventArgs.show = add1;
                        showCtrlEventArgs.Firer = (XObject)npc;
                        showCtrlEventArgs.type = BillBoardHideType.Photo;
                        XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)showCtrlEventArgs);
                    }
                }
            }
            bool add2 = this._check_index.Contains(1U);
            XSingleton<XScene>.singleton.GameCamera.SetCameraLayer(XRole.RoleLayer, add2);
            List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly((XEntity)XSingleton<XEntityMgr>.singleton.Player);
            if (ally == null)
                return;
            for (int index = 0; index < ally.Count; ++index)
            {
                if (ally[index] != null && ally[index].IsRole && !ally[index].IsPlayer)
                {
                    XBillboardShowCtrlEventArgs showCtrlEventArgs = XEventPool<XBillboardShowCtrlEventArgs>.GetEvent();
                    showCtrlEventArgs.show = add2;
                    showCtrlEventArgs.Firer = (XObject)ally[index];
                    showCtrlEventArgs.type = BillBoardHideType.Photo;
                    XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)showCtrlEventArgs);
                }
            }
        }

        private void OnResetEntityRender()
        {
            XSingleton<XScene>.singleton.GameCamera.SetCameraLayer(XPlayer.PlayerLayer, true);
            XBillboardShowCtrlEventArgs showCtrlEventArgs1 = XEventPool<XBillboardShowCtrlEventArgs>.GetEvent();
            showCtrlEventArgs1.show = true;
            showCtrlEventArgs1.type = BillBoardHideType.Photo;
            showCtrlEventArgs1.Firer = (XObject)XSingleton<XEntityMgr>.singleton.Player;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)showCtrlEventArgs1);
            XSingleton<XScene>.singleton.GameCamera.SetCameraLayer(XNpc.NpcLayer, true);
            List<uint> npcs = XSingleton<XEntityMgr>.singleton.GetNpcs(XSingleton<XScene>.singleton.SceneID);
            if (npcs != null)
            {
                for (int index = 0; index < npcs.Count; ++index)
                {
                    XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc(npcs[index]);
                    if (npc != null)
                    {
                        XBillboardShowCtrlEventArgs showCtrlEventArgs2 = XEventPool<XBillboardShowCtrlEventArgs>.GetEvent();
                        showCtrlEventArgs2.show = true;
                        showCtrlEventArgs2.Firer = (XObject)npc;
                        showCtrlEventArgs2.type = BillBoardHideType.Photo;
                        XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)showCtrlEventArgs2);
                    }
                }
            }
            XSingleton<XScene>.singleton.GameCamera.SetCameraLayer(XRole.RoleLayer, true);
            List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly((XEntity)XSingleton<XEntityMgr>.singleton.Player);
            for (int index = 0; index < ally.Count; ++index)
            {
                if (ally[index].IsRole && !ally[index].IsPlayer)
                {
                    XBillboardShowCtrlEventArgs showCtrlEventArgs3 = XEventPool<XBillboardShowCtrlEventArgs>.GetEvent();
                    showCtrlEventArgs3.show = true;
                    showCtrlEventArgs3.Firer = (XObject)ally[index];
                    showCtrlEventArgs3.type = BillBoardHideType.Photo;
                    XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)showCtrlEventArgs3);
                }
            }
        }

        private void OnReqEffect() => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_PhotographEffect());

        public void OnRefreshEffects()
        {
            this.uiBehaviour.mEffectPool.ReturnAll();
            this._mode_effectgo.Clear();
            this.uiBehaviour.mEffectsBack.spriteHeight = this.uiBehaviour.mEffectPool.TplHeight * this._doc.EffectListId.Count + 60;
            int num1 = this._doc.EffectListId.Count % 2 == 0 ? this.uiBehaviour.mEffectPool.TplHeight / 2 : 0;
            for (int index = 0; index < this._doc.EffectListId.Count; ++index)
            {
                List<PhotographEffectCfg.RowData> rowDataById = this._doc.GetRowDataById(this._doc.EffectListId[index]);
                int num2 = index % 2 == 0 ? 1 : -1;
                GameObject gameObject = this.uiBehaviour.mEffectPool.FetchGameObject();
                this._mode_effectgo.Add(gameObject);
                gameObject.transform.localPosition = new Vector3(this.uiBehaviour.mEffectPool.TplPos.x, this.uiBehaviour.mEffectPool.TplPos.y + (float)(num2 * ((index + 1) / 2) * this.uiBehaviour.mEffectPool.TplHeight) + (float)num1, this.uiBehaviour.mEffectPool.TplPos.z);
                (gameObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel).SetText(rowDataById[0].EffectName);
                IXUICheckBox component = gameObject.transform.FindChild("Normal").GetComponent("XUICheckBox") as IXUICheckBox;
                component.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnEffectChanged));
                component.ID = (ulong)this._doc.EffectListId[index];
                component.bChecked = false;
            }
            this.uiBehaviour.mEffectsMore.transform.localPosition = new Vector3(this.uiBehaviour.mEffectsMore.transform.localPosition.x, this.uiBehaviour.mEffectPool.TplPos.y - (float)((this._doc.EffectListId.Count + 1) * this.uiBehaviour.mEffectPool.TplHeight / 2), this.uiBehaviour.mEffectsMore.transform.localPosition.z);
            if (this._doc.EffectAllListId.Count == this._doc.EffectListId.Count)
                this.uiBehaviour.mEffectsRedpoint.SetVisible(false);
            else
                this.uiBehaviour.mEffectsRedpoint.SetVisible(true);
        }

        private void InitLeftMenu()
        {
            this.uiBehaviour.mModePool.ReturnAll();
            string[] strArray = XSingleton<XGlobalConfig>.singleton.GetValue("PhotoShowName").Split('|');
            this._mode_go.Clear();
            this.uiBehaviour.mModeBack.spriteHeight = this.uiBehaviour.mModePool.TplHeight * strArray.Length;
            for (int index = 0; index < strArray.Length; ++index)
            {
                GameObject gameObject = this.uiBehaviour.mModePool.FetchGameObject();
                int num1 = index % 2 == 0 ? 1 : -1;
                int num2 = this.uiBehaviour.mModePool.TplHeight / 2;
                gameObject.transform.localPosition = new Vector3(this.uiBehaviour.mModePool.TplPos.x, this.uiBehaviour.mModePool.TplPos.y + (float)(num1 * ((index + 1) / 2) * this.uiBehaviour.mModePool.TplHeight), this.uiBehaviour.mModePool.TplPos.z);
                (gameObject.transform.FindChild("option1/Name").GetComponent("XUILabel") as IXUILabel).SetText(strArray[index]);
                IXUICheckBox component = gameObject.transform.FindChild("option1/Normal").GetComponent("XUICheckBox") as IXUICheckBox;
                component.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnModeChanged));
                component.ID = (ulong)index;
                component.bChecked = true;
                this._check_index.Add((uint)index);
                this._mode_go.Add(gameObject);
            }
            this.OnRefreshEffects();
        }

        private void InitDance()
        {
            this.uiBehaviour.mDancePool.FakeReturnAll();
            this._dance_num = 0;
            int num1 = 0;
            for (int index = 0; index < XDanceDocument.Doc.SelfConfigData.Count; ++index)
            {
                DanceConfig.RowData danceConfig = XDanceDocument.GetDanceConfig(XDanceDocument.Doc.SelfConfigData[index].motionID);
                if (danceConfig != null && XDanceDocument.Doc.IsUnlock(XDanceDocument.Doc.SelfConfigData[index].valid, danceConfig.Condition))
                    ++this._dance_num;
            }
            float num2 = this._dance_num > 8 ? 8.5f : (float)this._dance_num;
            this.uiBehaviour.mDanceBack.spriteHeight = (int)((double)this.uiBehaviour.mModePool.TplHeight * (double)num2) + 30;
            this.uiBehaviour.mDanceBackSV.SetSize((float)this.uiBehaviour.mDanceBack.spriteWidth, (float)this.uiBehaviour.mModePool.TplHeight * num2);
            for (int index = 0; index < XDanceDocument.Doc.SelfConfigData.Count; ++index)
            {
                DanceConfig.RowData danceConfig = XDanceDocument.GetDanceConfig(XDanceDocument.Doc.SelfConfigData[index].motionID);
                if (danceConfig != null && XDanceDocument.Doc.IsUnlock(XDanceDocument.Doc.SelfConfigData[index].valid, danceConfig.Condition))
                {
                    GameObject gameObject = this.uiBehaviour.mDancePool.FetchGameObject();
                    gameObject.transform.parent = this.uiBehaviour.mDanceBackList.gameObject.transform;
                    (gameObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel).SetText(danceConfig.MotionName);
                    IXUICheckBox component = gameObject.transform.FindChild("Normal").GetComponent("XUICheckBox") as IXUICheckBox;
                    component.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnAnimChanged));
                    component.ID = (ulong)danceConfig.MotionID;
                    ++num1;
                }
            }
            this.uiBehaviour.mDancePool.ActualReturnAll();
            this.uiBehaviour.mDanceBackList.Refresh();
        }

        public bool IsInReadyScreenShowView() => this.IsLoaded() && this.IsVisible() && this.uiBehaviour.mDoScreenShot.IsVisible();
    }
}
