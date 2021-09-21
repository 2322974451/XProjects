// Decompiled with JetBrains decompiler
// Type: XMainClient.XMentorshipPupilsHandler
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XMentorshipPupilsHandler : DlgHandlerBase
    {
        private IXUILabel _pupilCondition;
        private IXUILabel _masterCondition;
        private Transform _noMentorship;
        private Transform _hasMentorship;
        private Transform _setting;
        private Transform _pupilRewards;
        private Transform _gongKuTaskItemTrans;
        private IXUIScrollView _scrollView;
        private IXUIWrapContent _reportWrapContent;
        private IXUILabel _footPrintLabel;
        private IXUICheckBox _footPrintCheck;
        private IXUIInput _PromiseContentInput;
        private bool _isCancelRecord;
        private Vector2 _dragDistance;
        private ulong _currentRoleID = 0;
        private IXUIButton _reportBtn;

        protected override string FileName => "GameSystem/TeacherPupil";

        protected override void Init()
        {
            base.Init();
            this.InitProperties();
        }

        public override void RegisterEvent() => base.RegisterEvent();

        protected override void OnShow()
        {
            base.OnShow();
            this._currentRoleID = 0UL;
            XMentorshipDocument.Doc.SendMentorshipInfoReq();
        }

        protected override void OnHide() => base.OnHide();

        public override void OnUnload()
        {
            this._currentRoleID = 0UL;
            base.OnUnload();
        }

        public void RefreshUI()
        {
            MyMentorship myMentorShip = XMentorshipDocument.Doc.GetMyMentorShip();
            this.InitItemsShowOrNot(myMentorShip);
            switch (myMentorShip)
            {
                case MyMentorship.None:
                    this.UpdateNoneRelationUI();
                    break;
                case MyMentorship.Mentorship_Pupil:
                    this.UpdatePupilUI();
                    break;
                case MyMentorship.Mentorship_Master:
                    this.UpdateMasterUI();
                    break;
            }
        }

        public void OnSettingOk()
        {
            this._setting.gameObject.SetActive(false);
            this.UpdateMentorshipPromise();
        }

        public void RefreshTaskItems()
        {
            this._reportWrapContent.RefreshAllVisibleContents();
            this.RefreshRelationRightViewByRoleID();
            this.RefreshRedPoint();
        }

        public void UpdateInheritTaskItem()
        {
            MentorRelationInfo targetInfoByRoleId = XMentorshipDocument.Doc.GetRelationTargetInfoByRoleID(this._currentRoleID);
            if (targetInfoByRoleId == null)
                return;
            this.RefreshRedPoint();
            IXUIButton component1 = this._gongKuTaskItemTrans.Find("Operation").GetComponent("XUIButton") as IXUIButton;
            component1.ID = this._currentRoleID;
            IXUILabel component2 = this._gongKuTaskItemTrans.Find("Operation/GetLabel").GetComponent("XUILabel") as IXUILabel;
            IXUILabel component3 = this._gongKuTaskItemTrans.Find("Rewards").GetComponent("XUILabel") as IXUILabel;
            IXUISprite component4 = this._gongKuTaskItemTrans.Find("Rewards/Icon").GetComponent("XUISprite") as IXUISprite;
            SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("TeacherInheritRewards", true);
            component3.SetText(sequenceList[0, 1] == 0 ? "" : sequenceList[0, 1].ToString());
            ItemList.RowData itemConf = XBagDocument.GetItemConf(sequenceList[0, 0]);
            component4.SetSprite(itemConf.ItemIcon1[0]);
            Transform transform = this._gongKuTaskItemTrans.Find("Operation/RedPoint");
            transform.gameObject.SetActive(false);
            component1.SetEnable(true);
            switch (targetInfoByRoleId.inheritStatus)
            {
                case EMentorTaskStatus.EMentorTask_CanReport:
                    component2.SetText(XSingleton<XStringTable>.singleton.GetString("InheritMentor"));
                    break;
                case EMentorTaskStatus.EMentorTask_AlreadyReport:
                    if ((long)targetInfoByRoleId.inheritApplyRoleID != (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID)
                    {
                        component2.SetText(XSingleton<XStringTable>.singleton.GetString("ToAccept"));
                        transform.gameObject.SetActive(true);
                        break;
                    }
                    component1.SetEnable(false);
                    component2.SetText(XSingleton<XStringTable>.singleton.GetString("CHAT_SENT"));
                    break;
                default:
                    component2.SetText(XSingleton<XStringTable>.singleton.GetString("InheritFinishMentor"));
                    component1.SetEnable(false);
                    break;
            }
        }

        public void RefreshRedPoint()
        {
            int relationIndexByRoleId = XMentorshipDocument.Doc.GetRelationIndexByRoleID(this._currentRoleID);
            if (relationIndexByRoleId < 0)
                return;
            this._hasMentorship.Find("Pupil" + (object)(relationIndexByRoleId + 1) + "/RedPoint").gameObject.SetActive(XMentorshipDocument.Doc.GetOneRedStausByIndex(relationIndexByRoleId));
            if (XMentorshipDocument.Doc.GetMyMentorShip() == MyMentorship.Mentorship_Pupil)
            {
                bool flag = !XMentorshipDocument.Doc.IsAllReported(this._currentRoleID);
                this._reportBtn.gameObject.transform.Find("RedPoint").gameObject.SetActive(flag);
            }
        }

        private void InitProperties()
        {
            this.InitStateTransProperties();
            this.InitNoMentorshipProperties();
            this.InitHasMentorShipProperties();
            this.InitSettingProperties();
            this.InitPupilRewardsProperties();
        }

        private void InitPupilRewardsProperties() => (this._pupilRewards.Find("Close").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosePupilRewards));

        private bool OnClosePupilRewards(IXUIButton button)
        {
            this._pupilRewards.gameObject.SetActive(false);
            return true;
        }

        private void InitSettingProperties()
        {
            this._footPrintCheck = this._setting.Find("CheckMentorship").GetComponent("XUICheckBox") as IXUICheckBox;
            this._footPrintCheck.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnLeaveFootPrintToggle));
            (this._setting.Find("ok").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnConfirmSetting));
            (this._setting.Find("Close").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseSettingDialog));
            this._footPrintLabel = this._footPrintCheck.gameObject.transform.Find("Mentorship").GetComponent("XUILabel") as IXUILabel;
            this._PromiseContentInput = this._setting.Find("PromiseContentBg").GetComponent("XUIInput") as IXUIInput;
        }

        private bool OnConfirmSetting(IXUIButton button)
        {
            if (this._footPrintCheck.bChecked ^ !XMentorshipDocument.Doc.LeaveFootprint || !this._PromiseContentInput.GetText().Equals(XMentorshipDocument.Doc.MentorshipApplyWords))
                XMentorshipDocument.Doc.SendUpdateMentorshopSetting(this._PromiseContentInput.GetText(), this._footPrintCheck.bChecked);
            else
                this._setting.gameObject.SetActive(false);
            return true;
        }

        private void OnDragPressBtn(IXUIButton button, Vector2 delta)
        {
            this._dragDistance += delta;
            this._isCancelRecord = (double)this._dragDistance.magnitude >= 100.0;
        }

        private bool OnCloseSettingDialog(IXUIButton button)
        {
            this._setting.gameObject.SetActive(false);
            return true;
        }

        private bool OnLeaveFootPrintToggle(IXUICheckBox iXUICheckBox)
        {
            XMentorshipDocument.Doc.LeaveFootprint = iXUICheckBox.bChecked;
            return true;
        }

        private void InitHasMentorShipProperties()
        {
            (this._hasMentorship.Find("MentorshipMall").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickMallBtn));
            (this._hasMentorship.Find("RewardsRules").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickRewardsBtn));
            (this._hasMentorship.Find("PrivateChat").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickPrivateChatBtn));
            this._reportBtn = this._hasMentorship.Find("AllReport").GetComponent("XUIButton") as IXUIButton;
            this._reportBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickAllReportBtn));
            (this._hasMentorship.Find("AddMentorship/Add").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickAddMentorShipBtn));
            (this._hasMentorship.Find("CurrentMentorInstruction/NextStep").GetComponent("XUISprite") as IXUISprite).RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickNextStep));
            (this._noMentorship.Find("NextStep").GetComponent("XUISprite") as IXUISprite).RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickNextStep));
            this._reportWrapContent = this._hasMentorship.Find("MentorshipTask/ScrollPanel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent;
            this._scrollView = this._hasMentorship.Find("MentorshipTask/ScrollPanel").GetComponent("XUIScrollView") as IXUIScrollView;
            this._reportWrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.ReportWrapContentInit));
            this._reportWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.ReportWrapContentUpdate));
        }

        private void ReportWrapContentUpdate(Transform itemTransform, int index)
        {
            MyMentorship myMentorShip = XMentorshipDocument.Doc.GetMyMentorShip();
            MentorshipTaskInfo mentorshipTaskInfo = myMentorShip != MyMentorship.Mentorship_Pupil ? XMentorshipDocument.Doc.GetTaskInfoWithIndexAndRoleID(index, this._currentRoleID) : XMentorshipDocument.Doc.GetMyMentorshipTaskInfoByIndex(index);
            if (mentorshipTaskInfo == null)
                return;
            MentorTaskTable.RowData taskInfoByTaskId = XMentorshipDocument.Doc.GetTableTaskInfoByTaskID((uint)mentorshipTaskInfo.taskID);
            if (taskInfoByTaskId != null)
            {
                (itemTransform.Find("taskDes").GetComponent("XUILabel") as IXUILabel).SetText(taskInfoByTaskId.TaskName);
                IXUILabel component1 = itemTransform.Find("Rewards").GetComponent("XUILabel") as IXUILabel;
                IXUISprite component2 = itemTransform.Find("Rewards/Icon").GetComponent("XUISprite") as IXUISprite;
                if (myMentorShip == MyMentorship.Mentorship_Master)
                {
                    if (taskInfoByTaskId.MasterReward.count > (byte)0)
                    {
                        component1.SetText(taskInfoByTaskId.MasterReward[0, 1].ToString());
                        ItemList.RowData itemConf = XBagDocument.GetItemConf(taskInfoByTaskId.MasterReward[0, 0]);
                        component2.SetSprite(itemConf.ItemIcon1[0]);
                    }
                }
                else if (taskInfoByTaskId.StudentReward.count > (byte)0)
                {
                    component1.SetText(taskInfoByTaskId.StudentReward[0, 1].ToString());
                    ItemList.RowData itemConf = XBagDocument.GetItemConf(taskInfoByTaskId.StudentReward[0, 0]);
                    component2.SetSprite(itemConf.ItemIcon1[0]);
                }
                IXUILabel component3 = itemTransform.Find("Progress").GetComponent("XUILabel") as IXUILabel;
                component3.gameObject.SetActive(false);
                bool flag = taskInfoByTaskId.TaskType == 3U || taskInfoByTaskId.TaskType == 29U;
                int num1 = flag ? 1 : taskInfoByTaskId.TaskVar[1];
                int num2 = mentorshipTaskInfo.completeProgress;
                if (flag)
                    num2 = mentorshipTaskInfo.completeTime == 0 ? 0 : 1;
                component3.SetText(num2.ToString() + "/" + (object)num1);
                IXUIButton component4 = itemTransform.Find("Operation").GetComponent("XUIButton") as IXUIButton;
                component4.ID = (ulong)mentorshipTaskInfo.taskID;
                Transform transform = component4.gameObject.transform.Find("RedPoint");
                transform.gameObject.SetActive(false);
                IXUILabel component5 = component4.gameObject.transform.Find("GetLabel").GetComponent("XUILabel") as IXUILabel;
                component4.gameObject.SetActive(true);
                component4.SetEnable(true);
                EMentorTaskStatus ementorTaskStatus = EMentorTaskStatus.EMentorTask_UnComplete;
                for (int index1 = 0; index1 < mentorshipTaskInfo.taskStatusList.Count; ++index1)
                {
                    MentorshipTaskStatus taskStatus = mentorshipTaskInfo.taskStatusList[index1];
                    if ((long)taskStatus.roleID == (long)this._currentRoleID)
                    {
                        ementorTaskStatus = (EMentorTaskStatus)taskStatus.status;
                        break;
                    }
                }
                switch (ementorTaskStatus)
                {
                    case EMentorTaskStatus.EMentorTask_UnComplete:
                        component4.gameObject.SetActive(false);
                        component3.gameObject.SetActive(true);
                        break;
                    case EMentorTaskStatus.EMentorTask_CanReport:
                        if (myMentorShip == MyMentorship.Mentorship_Pupil)
                        {
                            transform.gameObject.SetActive(true);
                            component5.SetText(XSingleton<XStringTable>.singleton.GetString("Report"));
                            break;
                        }
                        component4.gameObject.SetActive(false);
                        component3.gameObject.SetActive(true);
                        break;
                    case EMentorTaskStatus.EMentorTask_AlreadyReport:
                        if (myMentorShip == MyMentorship.Mentorship_Pupil)
                        {
                            component5.SetText(XSingleton<XStringTable>.singleton.GetString("Reported"));
                            component4.SetEnable(false);
                            break;
                        }
                        transform.gameObject.SetActive(true);
                        component5.SetText(XSingleton<XStringTable>.singleton.GetString("ToConfirm"));
                        break;
                    default:
                        component5.SetText(XSingleton<XStringTable>.singleton.GetString("Completed"));
                        component4.SetEnable(false);
                        break;
                }
            }
        }

        private void ReportWrapContentInit(Transform itemTransform, int index) => (itemTransform.Find("Operation").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickOperation));

        private bool OnClickOperation(IXUIButton button)
        {
            if (XMentorshipDocument.Doc.GetMyMentorShip() == MyMentorship.Mentorship_Master)
                XMentorshipDocument.Doc.SendCandidatesOpReq(EMentorMsgOpType.EMentorMsgOpType_Agree, this._currentRoleID, MentorMsgApplyType.MentorMsgApplyReportTask, (int)button.ID);
            else
                XMentorshipDocument.Doc.SendMentorRelationOp(MentorRelationOpType.MentorRelationOp_ReportTask, this._currentRoleID, (int)button.ID);
            return true;
        }

        private bool OnClickAllReportBtn(IXUIButton button)
        {
            if (!XMentorshipDocument.Doc.IsAllReported(this._currentRoleID))
                XMentorshipDocument.Doc.SendMentorRelationOp(MentorRelationOpType.MentorRelationOp_ReportAllTask, this._currentRoleID);
            else
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CompleteTaskToReport"), "fece00");
            return true;
        }

        private bool OnClickPrivateChatBtn(IXUIButton button)
        {
            XFriendData friendDataById = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetFriendDataById(this._currentRoleID);
            if (friendDataById != null)
                DlgBase<XChatView, XChatBehaviour>.singleton.PrivateChatTo(new ChatFriendData()
                {
                    name = friendDataById.name,
                    roleid = friendDataById.roleid,
                    powerpoint = friendDataById.powerpoint,
                    profession = friendDataById.profession,
                    viplevel = friendDataById.viplevel,
                    isfriend = true,
                    msgtime = DateTime.Now,
                    setid = friendDataById.setid
                });
            return true;
        }

        private void InitNoMentorshipProperties()
        {
            (this._noMentorship.Find("MentorshipMall").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickMallBtn));
            (this._noMentorship.Find("RewarsRules").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickRewardsBtn));
            (this._noMentorship.Find("Setting").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickSettingBtn));
            (this._noMentorship.Find("Bg/Pupil/PupilBg").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnToGetPupils));
            (this._noMentorship.Find("Bg/Master/MasterBg").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnToGetMaster));
            this._pupilCondition = this._noMentorship.Find("Bg/Pupil/PupilCondition").GetComponent("XUILabel") as IXUILabel;
            this._masterCondition = this._noMentorship.Find("Bg/Master/MasterCondition").GetComponent("XUILabel") as IXUILabel;
        }

        private bool OnToGetMaster(IXUIButton button)
        {
            if (XMentorshipDocument.Doc.GetMyPossibleMentorship() == MyMentorship.Mentorship_Pupil)
            {
                XMentorshipDocument.Doc.SetCandidatesViewVisible(CandidatesViewType.Recommend, CandidatesViewRecommendType.Master);
                XMentorshipDocument.Doc.SendToGetMyApplyMasterInfo();
            }
            else
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CantApplyMaster"), "fece00");
            return true;
        }

        private bool OnToGetPupils(IXUIButton button)
        {
            if (XMentorshipDocument.Doc.GetMyPossibleMentorship() == MyMentorship.Mentorship_Master)
            {
                XMentorshipDocument.Doc.SetCandidatesViewVisible(CandidatesViewType.Recommend, CandidatesViewRecommendType.Pupil);
                XMentorshipDocument.Doc.SendToGetMyApplyPupilsInfo();
            }
            else
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CantApplyPupil"), "fece00");
            return true;
        }

        private bool OnClickSettingBtn(IXUIButton button)
        {
            this._setting.gameObject.SetActive(true);
            return true;
        }

        private bool OnClickRewardsBtn(IXUIButton button)
        {
            this._pupilRewards.gameObject.SetActive(true);
            this.UpdatePupilRewardsDialog();
            return true;
        }

        private void UpdatePupilRewardsDialog()
        {
            (this._pupilRewards.Find("Normal/Base").GetComponent("XUILabel") as IXUILabel).SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("CompletMentorTask"), (object)XSingleton<XGlobalConfig>.singleton.GetInt("Mentor_NormalComplete"), (object)("<" + (object)XSingleton<XGlobalConfig>.singleton.GetInt("Mentor_PerfectComplete"))));
            (this._pupilRewards.Find("Perfect/More").GetComponent("XUILabel") as IXUILabel).SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("CompletMentorTask"), (object)XSingleton<XGlobalConfig>.singleton.GetInt("Mentor_PerfectComplete"), (object)""));
            MentorCompleteRewardTable mentorCompleteReward = XMentorshipDocument.MentorCompleteReward;
            MentorCompleteRewardTable.RowData byType1 = mentorCompleteReward.GetByType(1);
            SeqListRef<int> seqListRef = XMentorshipDocument.Doc.GetMyMentorShip() == MyMentorship.Mentorship_Master ? byType1.MasterReward : byType1.StudentReward;
            Transform transform1 = this._pupilRewards.Find("Normal/PupilRewards");
            Transform transform2 = this._pupilRewards.Find("Normal/MasterRewards");
            XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform1.gameObject, seqListRef[0, 0], seqListRef[0, 1]);
            IXUISprite component1 = transform1.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
            component1.ID = (ulong)seqListRef[0, 0];
            component1.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
            XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform2.gameObject, seqListRef[1, 0], seqListRef[1, 1]);
            IXUISprite component2 = transform2.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
            component2.ID = (ulong)seqListRef[1, 0];
            component2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
            MentorCompleteRewardTable.RowData byType2 = mentorCompleteReward.GetByType(2);
            seqListRef = XMentorshipDocument.Doc.GetMyMentorShip() == MyMentorship.Mentorship_Master ? byType2.MasterReward : byType2.StudentReward;
            Transform transform3 = this._pupilRewards.Find("Perfect/PupilRewards");
            Transform transform4 = this._pupilRewards.Find("Perfect/MasterRewards");
            XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform3.gameObject, seqListRef[0, 0], seqListRef[0, 1]);
            IXUISprite component3 = transform3.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
            component3.ID = (ulong)seqListRef[0, 0];
            component3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
            XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform4.gameObject, seqListRef[1, 0], seqListRef[1, 1]);
            IXUISprite component4 = transform4.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
            component4.ID = (ulong)seqListRef[1, 0];
            component4.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
        }

        private bool OnClickMallBtn(IXUIButton button)
        {
            DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Mentorship);
            return true;
        }

        private bool OnClickApplyNewsBtn(IXUIButton button)
        {
            XMentorshipDocument.Doc.SetCandidatesViewVisible(CandidatesViewType.Application);
            return true;
        }

        private void InitStateTransProperties()
        {
            this._noMentorship = this.transform.Find("NoMentorship");
            this._hasMentorship = this.transform.Find("HasMentorship");
            this._setting = this.transform.Find("ReName");
            this._pupilRewards = this.transform.Find("Pupilreward");
            this._gongKuTaskItemTrans = this._hasMentorship.Find("MentorshipTask/Gongku");
            this._noMentorship.gameObject.SetActive(true);
            this._hasMentorship.gameObject.SetActive(true);
            this._setting.gameObject.SetActive(true);
            this._pupilRewards.gameObject.SetActive(true);
            (this._gongKuTaskItemTrans.Find("Operation").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickToInherit));
        }

        private bool OnClickToInherit(IXUIButton button)
        {
            MentorRelationInfo targetInfoByRoleId = XMentorshipDocument.Doc.GetRelationTargetInfoByRoleID(this._currentRoleID);
            if (targetInfoByRoleId == null)
                return false;
            if ((long)targetInfoByRoleId.inheritApplyRoleID == (long)this._currentRoleID)
                XMentorshipDocument.Doc.SendCandidatesOpReq(EMentorMsgOpType.EMentorMsgOpType_Agree, this._currentRoleID, MentorMsgApplyType.MentorMsgApplyInherit);
            else
                XMentorshipDocument.Doc.SendMentorRelationOp(MentorRelationOpType.MentorRelationOp_Inherit, this._currentRoleID);
            return true;
        }

        private void InitItemsShowOrNot(MyMentorship relation)
        {
            this._pupilRewards.gameObject.SetActive(false);
            this._setting.gameObject.SetActive(false);
            this._noMentorship.gameObject.SetActive(relation == MyMentorship.None);
            this._hasMentorship.gameObject.SetActive(relation == MyMentorship.Mentorship_Pupil || relation == MyMentorship.Mentorship_Master);
            this._PromiseContentInput.SetText(XMentorshipDocument.Doc.MentorshipApplyWords);
            this._footPrintCheck.bChecked = !XMentorshipDocument.Doc.LeaveFootprint;
        }

        private void UpdateMasterUI()
        {
            this.UpdateTargetsLeftUI();
            this.UpdateDefaultSelectRole();
        }

        private void UpdateMasterRightUI()
        {
            this._reportBtn.gameObject.SetActive(false);
            this._reportWrapContent.SetContentCount(XMentorshipDocument.Doc.GetMyPupilTaskTotalNumber(this._currentRoleID));
            this._scrollView.ResetPosition();
            this.UpdateInheritTaskItem();
        }

        private void UpdatePupilUI()
        {
            this.UpdateTargetsLeftUI();
            this.UpdateDefaultSelectRole();
            this.UpdatePupilRightUI();
        }

        private void UpdateDefaultSelectRole()
        {
            if (this._currentRoleID == 0UL)
            {
                this.RefreshDefaultOneRelation();
            }
            else
            {
                int relationIndexByRoleId = XMentorshipDocument.Doc.GetRelationIndexByRoleID(this._currentRoleID);
                if (relationIndexByRoleId >= 0)
                {
                    IXUICheckBox component = this._hasMentorship.Find("Pupil" + (object)(relationIndexByRoleId + 1)).GetComponent("XUICheckBox") as IXUICheckBox;
                    if (component.bChecked)
                        this.OnToggleRelationTarget(component);
                    else
                        component.ForceSetFlag(true);
                }
                else
                    this.RefreshDefaultOneRelation();
            }
        }

        private void RefreshDefaultOneRelation()
        {
            if (XMentorshipDocument.Doc.GetRelationTargetsCount() <= 0)
                return;
            this._currentRoleID = XMentorshipDocument.Doc.GetRelationTargetInfo(0).roleInfo.roleID;
            IXUICheckBox component = this._hasMentorship.Find("Pupil1").GetComponent("XUICheckBox") as IXUICheckBox;
            if (component.bChecked)
                this.OnToggleRelationTarget(component);
            else
                component.ForceSetFlag(true);
        }

        private void UpdatePupilRightUI()
        {
            this._reportBtn.gameObject.SetActive(true);
            this._reportWrapContent.SetContentCount(XMentorshipDocument.Doc.GetMyMentorshipTaskCount());
            this._scrollView.ResetPosition();
            this.UpdateInheritTaskItem();
        }

        private void UpdateTargetsLeftUI()
        {
            this.UpdateMentorshipPromise();
            int relationTargetsCount = XMentorshipDocument.Doc.GetRelationTargetsCount();
            if (relationTargetsCount <= 0)
                return;
            this.UpdatePupilsItem(this._hasMentorship.Find("Pupil1"), XMentorshipDocument.Doc.GetRelationTargetInfo(0).roleInfo);
            Transform transform1 = this._hasMentorship.Find("Pupil2");
            Transform transform2 = this._hasMentorship.Find("AddMentorship");
            if (relationTargetsCount > 1)
            {
                transform1.gameObject.SetActive(true);
                transform2.gameObject.SetActive(false);
                this.UpdatePupilsItem(transform1, XMentorshipDocument.Doc.GetRelationTargetInfo(1).roleInfo);
            }
            else
            {
                transform2.gameObject.SetActive(true);
                transform1.gameObject.SetActive(false);
            }
        }

        private void UpdateMentorshipPromise()
        {
            Transform transform = this._hasMentorship.Find("MentorshipPromise");
            IXUILabel component1 = transform.Find("title").GetComponent("XUILabel") as IXUILabel;
            IXUILabel component2 = transform.Find("Promise").GetComponent("XUILabel") as IXUILabel;
            if (XMentorshipDocument.Doc.GetMyMentorShip() == MyMentorship.Mentorship_Pupil)
                component1.SetText(XSingleton<XStringTable>.singleton.GetString("MaterPromiseTitle"));
            else
                component1.SetText(XSingleton<XStringTable>.singleton.GetString("PupilPromiseTitle"));
            component2.SetText(XMentorshipDocument.Doc.MentorshipApplyWords);
            (transform.Find("Setting").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickSettingBtn));
        }

        private bool OnClickAddMentorShipBtn(IXUIButton button)
        {
            switch (XMentorshipDocument.Doc.GetMyMentorShip())
            {
                case MyMentorship.Mentorship_Pupil:
                    XMentorshipDocument.Doc.SetCandidatesViewVisible(CandidatesViewType.Recommend, CandidatesViewRecommendType.Master);
                    break;
                case MyMentorship.Mentorship_Master:
                    XMentorshipDocument.Doc.SetCandidatesViewVisible(CandidatesViewType.Recommend, CandidatesViewRecommendType.Pupil);
                    break;
            }
            return true;
        }

        private bool OnClickPlayVoiceBtn(IXUIButton button) => true;

        private void OnStopSignPlay(object ob)
        {
            IXUISpriteAnimation xuiSpriteAnimation = (IXUISpriteAnimation)ob;
            if (xuiSpriteAnimation == null)
                return;
            xuiSpriteAnimation.SetFrameRate(0);
            xuiSpriteAnimation.Reset();
        }

        private void UpdatePupilsItem(Transform item, RoleBriefInfo info)
        {
            (item.Find("level").GetComponent("XUILabel") as IXUILabel).SetText(info.level.ToString());
            (item.Find("head/p").GetComponent("XUISprite") as IXUISprite).spriteName = XMentorshipDocument.Doc.GetMyMentorShip() == MyMentorship.Mentorship_Master ? "bs_1" : "bs_0";
            (item.Find("head").GetComponent("XUISprite") as IXUISprite).spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)info.type % 10);
            XFriendData friendDataById = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetFriendDataById(info.roleID);
            IXUILabelSymbol component1 = item.Find("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
            IXUILabel component2 = item.Find("Name").GetComponent("XUILabel") as IXUILabel;
            (item.Find("ProfIcon").GetComponent("XUISprite") as IXUISprite).SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)info.type % 10));
            if (friendDataById != null)
            {
                component2.SetText("");
                component1.InputText = XSingleton<XCommon>.singleton.StringCombine(XTitleDocument.GetTitleWithFormat(friendDataById.titleID, friendDataById.name), XWelfareDocument.GetMemberPrivilegeIconString(friendDataById.paymemberid), XRechargeDocument.GetVIPIconString(friendDataById.viplevel));
            }
            else
            {
                component1.InputText = "";
                component2.SetText(info.name);
            }
            IXUICheckBox component3 = item.GetComponent("XUICheckBox") as IXUICheckBox;
            component3.ID = info.roleID;
            component3.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnToggleRelationTarget));
            Transform transform = item.Find("RedPoint");
            if (XMentorshipDocument.Doc.GetMyMentorShip() == MyMentorship.Mentorship_Pupil)
                transform.gameObject.SetActive(!XMentorshipDocument.Doc.IsAllReported(info.roleID));
            else
                transform.gameObject.SetActive(!XMentorshipDocument.Doc.IsAllAgreed(info.roleID));
        }

        private bool OnToggleRelationTarget(IXUICheckBox iXUICheckBox)
        {
            if (iXUICheckBox.bChecked)
            {
                this._currentRoleID = iXUICheckBox.ID;
                if (XMentorshipDocument.Doc.GetMyMentorShip() == MyMentorship.Mentorship_Master)
                    this.UpdateMasterRightUI();
                else
                    this.UpdatePupilRightUI();
                this.RefreshRelationRightViewByRoleID();
                this.RefreshRedPoint();
            }
            return true;
        }

        private void RefreshRelationRightViewByRoleID()
        {
            ulong currentRoleId = this._currentRoleID;
            string str = XMentorshipDocument.Doc.GetMyMentorShip() != MyMentorship.Mentorship_Master ? XSingleton<XStringTable>.singleton.GetString("HasMaster") : XSingleton<XStringTable>.singleton.GetString("HasPupil");
            int relationTargetsCount = XMentorshipDocument.Doc.GetRelationTargetsCount();
            (this._hasMentorship.Find("CurrentMentorInstruction").GetComponent("XUILabel") as IXUILabel).SetText(str + relationTargetsCount.ToString() + "/" + (object)XMentorshipDocument.Doc.MaxRelationCount);
            IXUILabel component = this._hasMentorship.Find("MentorshipTask/ConditionBg/ConditonsLabel").GetComponent("XUILabel") as IXUILabel;
            int num = XMentorshipDocument.Doc.GetRelationPassedDays(this._currentRoleID, MentorRelationStatus.MentorRelationIn) + 1;
            int completedTaskCount = XMentorshipDocument.Doc.GetCompletedTaskCount(this._currentRoleID);
            component.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("MentorOverConditions"), (object)(completedTaskCount.ToString() + "/" + (object)XSingleton<XGlobalConfig>.singleton.GetInt("Mentor_NormalComplete")), (object)(num.ToString() + "/" + (object)XSingleton<XGlobalConfig>.singleton.GetInt("Mentor_NormalCompleteDay"))));
        }

        private void UpdateNoneRelationUI()
        {
            this.RefreshAcceptPupilConditions();
            this.RefreshApplyMasterConditions();
        }

        private void RefreshApplyMasterConditions()
        {
            LevelSealTypeTable.RowData levelSealType = XLevelSealDocument.GetLevelSealType(XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID).GetSealType());
            int num = levelSealType == null ? 30 : levelSealType.ApplyStudentLevel;
            this._pupilCondition.SetText(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("ToBeMasterCondition")), (object)num));
        }

        private void RefreshAcceptPupilConditions() => this._masterCondition.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("ToBePupilConditon")));

        private void OnClickNextStep(IXUISprite uiSprite) => DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Mentorship);
    }
}
