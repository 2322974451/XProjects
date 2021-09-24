

using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class XMentorshipCandidatesView :
      DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>
    {
        public override string fileName => "GameSystem/TeacherPupilInvitation";

        public override int layer => 1;

        public override int group => 1;

        public override bool autoload => true;

        protected override void Init() => this.InitProperties();

        protected override void OnUnload() => base.OnUnload();

        public override void RegisterEvent() => base.RegisterEvent();

        protected override void OnShow()
        {
            base.OnShow();
            this.RefreshTitleAndDownBtn();
            if (XMentorshipDocument.Doc.CurViewType == CandidatesViewType.Application)
            {
                XMentorshipDocument.Doc.SendCandidatesOpReq(EMentorMsgOpType.EMentorMsgOp_Get);
            }
            else
            {
                if (XMentorshipDocument.Doc.CurViewType != CandidatesViewType.Recommend)
                    return;
                if (XMentorshipDocument.Doc.CurRecommendType == CandidatesViewRecommendType.Master)
                    XMentorshipDocument.Doc.SendToGetMyApplyMasterInfo();
                else
                    XMentorshipDocument.Doc.SendToGetMyApplyPupilsInfo();
            }
        }

        private void RefreshTitleAndDownBtn()
        {
            if (XMentorshipDocument.Doc.CurViewType == CandidatesViewType.Application)
            {
                this.uiBehaviour.titleContent.SetText(XSingleton<XStringTable>.singleton.GetString("MentorshipApply"));
                this.uiBehaviour.btnContent.SetText(XSingleton<XStringTable>.singleton.GetString("MentorshipClear"));
            }
            else if (XMentorshipDocument.Doc.CurViewType == CandidatesViewType.Recommend)
            {
                this.uiBehaviour.titleContent.SetText(XSingleton<XStringTable>.singleton.GetString("MentorshipRecommend"));
                this.uiBehaviour.btnContent.SetText(XSingleton<XStringTable>.singleton.GetString("FRIEND_ADDDLG_NO_COUNTDOWN"));
            }
            this.uiBehaviour.ClearBtn.SetEnable(true);
            this.uiBehaviour.btnContent.SetText(XStringDefineProxy.GetString("FRIEND_ADDDLG_NO_COUNTDOWN"));
        }

        protected override void OnHide()
        {
            base.OnHide();
            XMentorshipDocument.Doc.ResetCandidatesView();
        }

        public void RefreshUI()
        {
            this.uiBehaviour.WrapContent.SetContentCount(XMentorshipDocument.Doc.GetCanidatesShowMsgCount());
            this.uiBehaviour.ScrollView.ResetPosition();
        }

        public void RefreshAllVisible() => this.uiBehaviour.WrapContent.RefreshAllVisibleContents();

        public void RefreshCDTimeLabel(int leftTime)
        {
            if (leftTime > 0)
            {
                this.uiBehaviour.ClearBtn.SetEnable(false);
                this.uiBehaviour.btnContent.SetText(string.Format(XStringDefineProxy.GetString("FRIEND_ADDDLG_COUNTDOWN_FMT"), (object)leftTime));
            }
            else
            {
                this.uiBehaviour.ClearBtn.SetEnable(true);
                this.uiBehaviour.btnContent.SetText(XStringDefineProxy.GetString("FRIEND_ADDDLG_NO_COUNTDOWN"));
            }
        }

        private void InitProperties()
        {
            this.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseDialog));
            this.uiBehaviour.ClearBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClearNews));
            this.uiBehaviour.WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.OnWrapContentItemInit));
            this.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentItemUpdate));
        }

        private bool OnClearNews(IXUIButton button)
        {
            if (XMentorshipDocument.Doc.CurViewType == CandidatesViewType.Application)
                XMentorshipDocument.Doc.SendCandidatesOpReq(EMentorMsgOpType.EMentorMsgOpType_Clear);
            else if (XMentorshipDocument.Doc.CurViewType == CandidatesViewType.Recommend)
            {
                if (XMentorshipDocument.Doc.CurRecommendType == CandidatesViewRecommendType.Master)
                    XMentorshipDocument.Doc.SendToGetMyApplyMasterInfo(true);
                else
                    XMentorshipDocument.Doc.SendToGetMyApplyPupilsInfo(true);
            }
            return true;
        }

        private bool OnCloseDialog(IXUIButton button)
        {
            this.SetVisibleWithAnimation(false, (DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.OnAnimationOver)null);
            return true;
        }

        private void OnWrapContentItemUpdate(Transform itemTransform, int index)
        {
            IXUIButton component1 = itemTransform.Find("Accept").GetComponent("XUIButton") as IXUIButton;
            component1.gameObject.SetActive(XMentorshipDocument.Doc.CurViewType == CandidatesViewType.Application);
            IXUIButton component2 = itemTransform.Find("Refuse").GetComponent("XUIButton") as IXUIButton;
            component2.gameObject.SetActive(XMentorshipDocument.Doc.CurViewType == CandidatesViewType.Application);
            IXUIButton component3 = itemTransform.Find("Mentorship").GetComponent("XUIButton") as IXUIButton;
            component3.gameObject.SetActive(XMentorshipDocument.Doc.CurViewType == CandidatesViewType.Recommend);
            MessageShowInfoItem candidateMsgShowInfo = XMentorshipDocument.Doc.GetCandidateMsgShowInfo(index);
            if (candidateMsgShowInfo == null)
                return;
            (itemTransform.Find("level").GetComponent("XUILabel") as IXUILabel).SetText(candidateMsgShowInfo.roleInfo.level.ToString());
            uint titleID = candidateMsgShowInfo.roleInfo.outlook == null || candidateMsgShowInfo.roleInfo.outlook.title == null ? 0U : candidateMsgShowInfo.roleInfo.outlook.title.titleID;
            (itemTransform.Find("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol).InputText = XTitleDocument.GetTitleWithFormat(titleID, candidateMsgShowInfo.roleInfo.name);
            (itemTransform.Find("head").GetComponent("XUISprite") as IXUISprite).spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)candidateMsgShowInfo.roleInfo.type % 10);
            (itemTransform.Find("Profession").GetComponent("XUISprite") as IXUISprite).spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)candidateMsgShowInfo.roleInfo.type % 10);
            (itemTransform.Find("PromiseWords").GetComponent("XUILabel") as IXUILabel).SetText(candidateMsgShowInfo.promiseWords);
            IXUILabel component4 = itemTransform.Find("Mentorship/T").GetComponent("XUILabel") as IXUILabel;
            if (XMentorshipDocument.Doc.CurViewType == CandidatesViewType.Application)
            {
                component1.ID = (ulong)index;
                component2.ID = (ulong)index;
            }
            else
            {
                component3.ID = candidateMsgShowInfo.roleInfo.roleID;
                if (candidateMsgShowInfo.applied)
                {
                    component3.SetEnable(false);
                    component4.SetText(XSingleton<XStringTable>.singleton.GetString("CHAT_SENT"));
                }
                else
                {
                    component3.SetEnable(true);
                    if (XMentorshipDocument.Doc.CurRecommendType == CandidatesViewRecommendType.Master)
                        component4.SetText(XSingleton<XStringTable>.singleton.GetString("MentorshipMaster"));
                    else
                        component4.SetText(XSingleton<XStringTable>.singleton.GetString("MentorshipPupil"));
                }
            }
        }

        private void OnStartPlayAudio(IXUISprite uiSprite)
        {
        }

        private void OnStopSignPlay(object ob)
        {
            IXUISpriteAnimation xuiSpriteAnimation = (IXUISpriteAnimation)ob;
            if (xuiSpriteAnimation == null)
                return;
            xuiSpriteAnimation.SetFrameRate(0);
            xuiSpriteAnimation.Reset();
        }

        private void UpdateOpBtnState(Transform itemTransform)
        {
            (itemTransform.Find("Accept").GetComponent("XUIButton") as IXUIButton).gameObject.SetActive(XMentorshipDocument.Doc.CurViewType == CandidatesViewType.Application);
            (itemTransform.Find("Refuse").GetComponent("XUIButton") as IXUIButton).gameObject.SetActive(XMentorshipDocument.Doc.CurViewType == CandidatesViewType.Application);
            (itemTransform.Find("Mentorship").GetComponent("XUIButton") as IXUIButton).gameObject.SetActive(XMentorshipDocument.Doc.CurViewType == CandidatesViewType.Recommend);
        }

        private void OnPlayPromiseVoice(IXUISprite uiSprite)
        {
        }

        private void OnWrapContentItemInit(Transform itemTransform, int index)
        {
            (itemTransform.Find("Accept").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickAcceptCandidate));
            (itemTransform.Find("Refuse").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickRefuseCandidate));
            (itemTransform.Find("Mentorship").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnMentorshipClicked));
        }

        private bool OnMentorshipClicked(IXUIButton button)
        {
            if (XMentorshipDocument.Doc.CurRecommendType == CandidatesViewRecommendType.Master)
                XMentorshipDocument.Doc.SendMentorRelationOp(MentorRelationOpType.MentorRelationOp_ApplyMaster, button.ID);
            else
                XMentorshipDocument.Doc.SendMentorRelationOp(MentorRelationOpType.MentorRelationOp_ApplyStudent, button.ID);
            return true;
        }

        private bool OnClickRefuseCandidate(IXUIButton button)
        {
            MessageShowInfoItem candidateMsgShowInfo = XMentorshipDocument.Doc.GetCandidateMsgShowInfo((int)button.ID);
            if (candidateMsgShowInfo != null)
                XMentorshipDocument.Doc.SendCandidatesOpReq(EMentorMsgOpType.EMentorMsgOpType_Reject, candidateMsgShowInfo.roleInfo.roleID, candidateMsgShowInfo.msgType);
            return true;
        }

        private bool OnClickAcceptCandidate(IXUIButton button)
        {
            MessageShowInfoItem candidateMsgShowInfo = XMentorshipDocument.Doc.GetCandidateMsgShowInfo((int)button.ID);
            if (candidateMsgShowInfo != null)
                XMentorshipDocument.Doc.SendCandidatesOpReq(EMentorMsgOpType.EMentorMsgOpType_Agree, candidateMsgShowInfo.roleInfo.roleID, candidateMsgShowInfo.msgType);
            return true;
        }
    }
}
