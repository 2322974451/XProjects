

using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class XMentorshipApplicationsView :
      DlgBase<XMentorshipApplicationsView, XMentorshipApplicationBehavior>
    {
        public override string fileName => "GameSystem/Teachermessage";

        public override int layer => 1;

        public override int group => 1;

        public override bool autoload => true;

        protected override void Init() => this.InitProperties();

        protected override void OnUnload() => base.OnUnload();

        public override void RegisterEvent() => base.RegisterEvent();

        protected override void OnShow()
        {
            base.OnShow();
            XMentorshipDocument.Doc.SendCandidatesOpReq(EMentorMsgOpType.EMentorMsgOp_Get);
            this.uiBehaviour.OneShotBtn.gameObject.SetActive(false);
        }

        public void RefreshUI()
        {
            this.uiBehaviour.WrapContent.SetContentCount(XMentorshipDocument.Doc.GetBeenApplyMsgCount());
            this.uiBehaviour.scrollView.ResetPosition();
            this.uiBehaviour.OneShotBtn.gameObject.SetActive(XMentorshipDocument.Doc.GetBeenApplyReportsMsgCount() > 0);
        }

        private void InitProperties()
        {
            this.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseView));
            this.uiBehaviour.ClearBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClearNews));
            this.uiBehaviour.WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.OnWrapContentItemInit));
            this.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentItemUpdate));
            this.uiBehaviour.OneShotBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShotAcceptReports));
        }

        private bool OnShotAcceptReports(IXUIButton button)
        {
            XMentorshipDocument.Doc.SendCandidatesOpReq(EMentorMsgOpType.EMentorMsgOpType_Agree, type: MentorMsgApplyType.MentorMsgApplyReportTask, isAll: true);
            return true;
        }

        private bool OnClearNews(IXUIButton button)
        {
            XMentorshipDocument.Doc.SendCandidatesOpReq(EMentorMsgOpType.EMentorMsgOpType_Clear);
            return true;
        }

        private bool OnCloseView(IXUIButton button)
        {
            this.SetVisibleWithAnimation(false, (DlgBase<XMentorshipApplicationsView, XMentorshipApplicationBehavior>.OnAnimationOver)null);
            return true;
        }

        private void OnWrapContentItemUpdate(Transform itemTransform, int index)
        {
            MentorBeenApplyedInfo applyInfoByIndex = XMentorshipDocument.Doc.GetBeenApplyInfoByIndex(index);
            if (applyInfoByIndex == null)
                return;
            (itemTransform.Find("level").GetComponent("XUILabel") as IXUILabel).SetText(applyInfoByIndex.roleInfo.level.ToString());
            (itemTransform.Find("head").GetComponent("XUISprite") as IXUISprite).spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)applyInfoByIndex.roleInfo.type % 10);
            XFriendData friendDataById = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetFriendDataById(applyInfoByIndex.roleInfo.roleID);
            IXUISprite component1 = itemTransform.Find("Profession").GetComponent("XUISprite") as IXUISprite;
            IXUILabelSymbol component2 = itemTransform.Find("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
            IXUILabel component3 = itemTransform.Find("Name").GetComponent("XUILabel") as IXUILabel;
            component1.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)applyInfoByIndex.roleInfo.type % 10));
            if (friendDataById != null)
            {
                component2.InputText = XSingleton<XCommon>.singleton.StringCombine(XTitleDocument.GetTitleWithFormat(friendDataById.titleID, friendDataById.name), XWelfareDocument.GetMemberPrivilegeIconString(friendDataById.paymemberid), XRechargeDocument.GetVIPIconString(friendDataById.viplevel));
            }
            else
            {
                component2.InputText = "";
                component3.SetText(applyInfoByIndex.roleInfo.name);
            }
            IXUILabel component4 = itemTransform.Find("MsgType").GetComponent("XUILabel") as IXUILabel;
            switch (applyInfoByIndex.applyType)
            {
                case MentorMsgApplyType.MentorMsgApplyMaster:
                    component4.SetText(XSingleton<XStringTable>.singleton.GetString("MentorMsgApplyMaster"));
                    break;
                case MentorMsgApplyType.MentorMsgApplyStudent:
                    component4.SetText(XSingleton<XStringTable>.singleton.GetString("MentorMsgApplyStudent"));
                    break;
                case MentorMsgApplyType.MentorMsgApplyInherit:
                    component4.SetText(XSingleton<XStringTable>.singleton.GetString("MentorMsgApplyInherit"));
                    break;
                case MentorMsgApplyType.MentorMsgApplyReportTask:
                    MentorTaskTable.RowData taskInfoByTaskId = XMentorshipDocument.Doc.GetTableTaskInfoByTaskID((uint)applyInfoByIndex.reportTaskID);
                    if (taskInfoByTaskId != null)
                    {
                        component4.SetText(taskInfoByTaskId.TaskName);
                        break;
                    }
                    component4.SetText(XSingleton<XStringTable>.singleton.GetString("MentorPupilToReport"));
                    break;
                case MentorMsgApplyType.MentorMsgApplyBreak:
                    component4.SetText(XSingleton<XStringTable>.singleton.GetString("MentorMsgApplyBreak"));
                    break;
            }
            IXUIButton component5 = itemTransform.Find("RefuseBtn").GetComponent("XUIButton") as IXUIButton;
            component5.gameObject.SetActive(applyInfoByIndex.applyType == MentorMsgApplyType.MentorMsgApplyStudent || applyInfoByIndex.applyType == MentorMsgApplyType.MentorMsgApplyMaster);
            component5.ID = (ulong)index;
            IXUIButton component6 = itemTransform.Find("AcceptBtn").GetComponent("XUIButton") as IXUIButton;
            component6.gameObject.SetActive(applyInfoByIndex.applyType == MentorMsgApplyType.MentorMsgApplyStudent || applyInfoByIndex.applyType == MentorMsgApplyType.MentorMsgApplyMaster);
            component6.ID = (ulong)index;
            bool flag = applyInfoByIndex.applyType == MentorMsgApplyType.MentorMsgApplyInherit || applyInfoByIndex.applyType == MentorMsgApplyType.MentorMsgApplyReportTask || applyInfoByIndex.applyType == MentorMsgApplyType.MentorMsgApplyBreak;
            Transform transform = itemTransform.Find("OneBtn");
            transform.gameObject.SetActive(flag);
            if (flag)
            {
                IXUIButton component7 = transform.GetComponent("XUIButton") as IXUIButton;
                IXUILabel component8 = itemTransform.Find("OneBtn/opStr").GetComponent("XUILabel") as IXUILabel;
                if (applyInfoByIndex.applyType == MentorMsgApplyType.MentorMsgApplyReportTask)
                {
                    component7.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickToAgreeReport));
                    component8.SetText(XSingleton<XStringTable>.singleton.GetString("AcceptReport"));
                    component7.ID = (ulong)index;
                }
                else if (applyInfoByIndex.applyType == MentorMsgApplyType.MentorMsgApplyInherit)
                {
                    component7.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickToInherit));
                    component8.SetText(XSingleton<XStringTable>.singleton.GetString("ToAccept"));
                    component7.ID = (ulong)index;
                }
                else if (applyInfoByIndex.applyType == MentorMsgApplyType.MentorMsgApplyBreak)
                {
                    component7.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickToBreak));
                    component8.SetText(XSingleton<XStringTable>.singleton.GetString("ToConfirm"));
                    component7.ID = (ulong)index;
                }
            }
        }

        private bool OnClickToBreak(IXUIButton button)
        {
            MentorBeenApplyedInfo applyInfoByIndex = XMentorshipDocument.Doc.GetBeenApplyInfoByIndex((int)button.ID);
            if (applyInfoByIndex != null)
                XMentorshipDocument.Doc.SendCandidatesOpReq(EMentorMsgOpType.EMentorMsgOpType_Agree, applyInfoByIndex.roleInfo.roleID, applyInfoByIndex.applyType);
            return true;
        }

        private bool OnClickToInherit(IXUIButton button)
        {
            MentorBeenApplyedInfo applyInfoByIndex = XMentorshipDocument.Doc.GetBeenApplyInfoByIndex((int)button.ID);
            if (applyInfoByIndex != null)
                XMentorshipDocument.Doc.SendCandidatesOpReq(EMentorMsgOpType.EMentorMsgOpType_Agree, applyInfoByIndex.roleInfo.roleID, applyInfoByIndex.applyType);
            return true;
        }

        private void OnWrapContentItemInit(Transform itemTransform, int index)
        {
            (itemTransform.Find("RefuseBtn").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefuseApply));
            (itemTransform.Find("AcceptBtn").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAcceptApply));
        }

        private bool OnClickToAgreeReport(IXUIButton button)
        {
            MentorBeenApplyedInfo applyInfoByIndex = XMentorshipDocument.Doc.GetBeenApplyInfoByIndex((int)button.ID);
            if (applyInfoByIndex != null)
                XMentorshipDocument.Doc.SendCandidatesOpReq(EMentorMsgOpType.EMentorMsgOpType_Agree, applyInfoByIndex.roleInfo.roleID, applyInfoByIndex.applyType, applyInfoByIndex.reportTaskID);
            return true;
        }

        private bool OnAcceptApply(IXUIButton button)
        {
            MentorBeenApplyedInfo applyInfoByIndex = XMentorshipDocument.Doc.GetBeenApplyInfoByIndex((int)button.ID);
            if (applyInfoByIndex != null)
                XMentorshipDocument.Doc.SendCandidatesOpReq(EMentorMsgOpType.EMentorMsgOpType_Agree, applyInfoByIndex.roleInfo.roleID, applyInfoByIndex.applyType);
            return true;
        }

        private bool OnRefuseApply(IXUIButton button)
        {
            MentorBeenApplyedInfo applyInfoByIndex = XMentorshipDocument.Doc.GetBeenApplyInfoByIndex((int)button.ID);
            if (applyInfoByIndex != null)
                XMentorshipDocument.Doc.SendCandidatesOpReq(EMentorMsgOpType.EMentorMsgOpType_Reject, applyInfoByIndex.roleInfo.roleID, applyInfoByIndex.applyType);
            return true;
        }
    }
}
