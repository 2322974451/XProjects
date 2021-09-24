

using KKSG;
using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.GameSystem;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XSkillTreeView : DlgBase<XSkillTreeView, XSkillTreeBehaviour>
    {
        public SkillDlgPromoteHandler _skillDlgPromoteHandler;
        private GameObject _LastSelect = (GameObject)null;
        private GameObject _CurrentSkillSprite = (GameObject)null;
        private List<GameObject> _TabRedPointList = new List<GameObject>();
        private bool _SwitchFrameState = true;
        public bool IsPromoteHandlerShow = false;
        public int LastSelectPromote;
        private XSkillTreeDocument _doc = (XSkillTreeDocument)null;
        private List<IXUICheckBox> _icbList = new List<IXUICheckBox>();
        public RenderTexture skillPreView;
        private float _skillPageSwitchSignTime = 0.0f;
        private XFx _FxFirework;
        private int[] MI = new int[5] { 1, 10, 100, 1000, 10000 };
        public static readonly int AwakeIndex = 3;

        public override string fileName => "GameSystem/SkillTree";

        public override int layer => 1;

        public override bool pushstack => true;

        public override bool fullscreenui => true;

        public override bool hideMainMenu => true;

        public override bool autoload => true;

        protected override void Init()
        {
            base.Init();
            this._doc = XDocuments.GetSpecificDocument<XSkillTreeDocument>(XSkillTreeDocument.uuID);
            this._doc.CurrentSkillID = this._doc.UNSELECT;
            this._SwitchFrameState = true;
            this.SetupTabs();
            this.uiBehaviour.m_FreeResetSkillTip.SetText(string.Format(XStringDefineProxy.GetString("SKILL_RESETFREE_TIPS"), (object)XSingleton<XGlobalConfig>.singleton.GetInt("FreeResetSkillLevel")));
            this._skillDlgPromoteHandler = DlgHandlerBase.EnsureCreate<SkillDlgPromoteHandler>(ref this._skillDlgPromoteHandler, this.uiBehaviour.m_TransferFrame, visible: false);
        }

        public override void RegisterEvent()
        {
            base.RegisterEvent();
            this.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
            this.uiBehaviour.m_ResetSkillBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnResetSkillPointClicked));
            this.uiBehaviour.m_ResetProBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnResetProfClicked));
            this.uiBehaviour.m_SwitchSkillPageBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSwitchSkillPageBtnClick));
            this.uiBehaviour.m_CatchBackBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.TurnSwitchFrameState));
            this.uiBehaviour.m_ChooseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.TurnSwitchFrameState));
            this.uiBehaviour.m_SkillPlayBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnPlaySkillClicked));
            this.uiBehaviour.m_LearnBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSkillLevelUpClicked));
            for (int index = 0; index < XSkillTreeDocument.SkillSlotCount; ++index)
                this.uiBehaviour.m_SkillSlotList[index].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSetupSkillClicked));
        }

        public void SetupTabs()
        {
            uint typeId = XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID;
            uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
            this.uiBehaviour.m_Tabs.ReturnAll();
            Vector3 tplPos = this.uiBehaviour.m_Tabs.TplPos;
            bool flag = true;
            this._icbList.Clear();
            this._TabRedPointList.Clear();
            for (int index = 0; index < this._doc.TRANSFERNUM; ++index)
            {
                uint num = typeId % 10U;
                typeId /= 10U;
                string str1;
                if (num == 0U)
                {
                    if (index == XSkillTreeView.AwakeIndex)
                    {
                        str1 = XStringDefineProxy.GetString("SKILL_TREE_TAB_AWAKE");
                    }
                    else
                    {
                        string str2 = index == 1 ? XStringDefineProxy.GetString("ONE") : XStringDefineProxy.GetString("TWO");
                        string str3 = level >= this._doc.TransferLimit[index] ? "" : XLabelSymbolHelper.FormatImage("common/Lcommon", "l_lock_00");
                        str1 = string.Format(XStringDefineProxy.GetString("SKILL_TREE_TAB"), (object)str3, (object)this._doc.TransferLimit[index], (object)str2);
                    }
                }
                else
                    str1 = XSingleton<XProfessionSkillMgr>.singleton.GetProfName((int)XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID % this.MI[index + 1]);
                GameObject gameObject = this.uiBehaviour.m_Tabs.FetchGameObject();
                gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(this.uiBehaviour.m_Tabs.TplHeight * index));
                this._TabRedPointList.Add(gameObject.transform.Find("RedPoint").gameObject);
                (gameObject.transform.Find("TextLabel").GetComponent("XUILabelSymbol") as IXUILabelSymbol).InputText = str1;
                (gameObject.transform.Find("SelectedTextLabel").GetComponent("XUILabelSymbol") as IXUILabelSymbol).InputText = str1;
                IXUICheckBox component1 = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
                IXUISprite component2 = gameObject.transform.Find("Lock").GetComponent("XUISprite") as IXUISprite;
                this._icbList.Add(component1);
                component1.ID = (ulong)index;
                if (flag)
                {
                    gameObject.GetComponent<BoxCollider>().enabled = true;
                    component1.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClick));
                    component2.RegisterSpriteClickEventHandler((SpriteClickEventHandler)null);
                }
                else
                {
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    component1.RegisterOnCheckEventHandler((CheckBoxOnCheckEventHandler)null);
                    component2.ID = (ulong)this._doc.TransferLimit[index - 1];
                    component2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnUnableCheckBoxClick));
                }
                if (num == 0U)
                    flag = false;
            }
        }

        protected override void OnShow()
        {
            base.OnShow();
            XSingleton<XCombatEffectManager>.singleton.ArrangeEffectData();
            this._doc.CreateSkillBlackHouse();
            if ((UnityEngine.Object)this.skillPreView == (UnityEngine.Object)null)
            {
                this.skillPreView = new RenderTexture(369, 208, 1, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
                this.skillPreView.name = "SkillPreview";
                this.skillPreView.autoGenerateMips = false;
                this.skillPreView.Create();
            }
            this.uiBehaviour.m_Snapshot.SetRuntimeTex((Texture)this.skillPreView);
            this._doc.SetSkillPreviewTexture(this.skillPreView);
            this.SetUVRectangle();
            this._icbList[this.LastSelectPromote].bChecked = true;
            this.OnTabClick(this._icbList[this.LastSelectPromote]);
            if (!this._SwitchFrameState)
                this.TurnSwitchFrameState((IXUIButton)null);
            this.CalAllTabRedPoint();
        }

        protected override void OnHide()
        {
            this._doc.DelDummy();
            if ((UnityEngine.Object)this._doc.BlackHouseCamera != (UnityEngine.Object)null)
                this._doc.BlackHouseCamera.enabled = false;
            this.LastSelectPromote = 0;
            this._skillDlgPromoteHandler.SetVisible(false);
            this._doc.SetSkillPreviewTexture((RenderTexture)null);
            if ((UnityEngine.Object)this.skillPreView != (UnityEngine.Object)null)
            {
                this.uiBehaviour.m_Snapshot.SetRuntimeTex((Texture)null);
                this.skillPreView = (RenderTexture)null;
            }
            this.DestroyFx(this._FxFirework);
            this._FxFirework = (XFx)null;
            this.uiBehaviour.m_LevelUpFx.SetActive(false);
            base.OnHide();
        }

        public override void LeaveStackTop()
        {
            base.LeaveStackTop();
            this.uiBehaviour.m_LevelUpFx.SetActive(false);
        }

        protected override void OnUnload()
        {
            XSingleton<XSkillPreViewMgr>.singleton.SkillShowEnd(this._doc.Dummy);
            if ((UnityEngine.Object)this._doc.BlackHouseCamera != (UnityEngine.Object)null)
                this._doc.BlackHouseCamera.enabled = false;
            this._doc.SetSkillPreviewTexture((RenderTexture)null);
            if ((UnityEngine.Object)this.skillPreView != (UnityEngine.Object)null)
            {
                this.skillPreView.Release();
                this.skillPreView = (RenderTexture)null;
            }
            this.LastSelectPromote = 0;
            this._LastSelect = (GameObject)null;
            DlgHandlerBase.EnsureUnload<SkillDlgPromoteHandler>(ref this._skillDlgPromoteHandler);
            this.DestroyFx(this._FxFirework);
            this._FxFirework = (XFx)null;
            base.OnUnload();
        }

        public void CalAllTabRedPoint()
        {
            for (int Promote = 0; Promote < this._doc.TRANSFERNUM; ++Promote)
                this.CalTabRedPoint(Promote);
        }

        private void CalTabRedPoint(int Promote)
        {
            if ((int)XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID / this.MI[Promote] == 0)
            {
                this._TabRedPointList[Promote].SetActive(false);
            }
            else
            {
                List<uint> profSkillId = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID((int)XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID % this.MI[Promote + 1]);
                for (int index = 0; index < profSkillId.Count; ++index)
                {
                    uint skillOriginalLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(profSkillId[index]);
                    XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillId[index], skillOriginalLevel);
                    if (this._doc.CheckRedPoint(profSkillId[index]))
                    {
                        this._TabRedPointList[Promote].SetActive(true);
                        return;
                    }
                }
                this._TabRedPointList[Promote].SetActive(false);
            }
        }

        private bool OnTabClick(IXUICheckBox icb)
        {
            if (!icb.bChecked)
                return true;
            if ((UnityEngine.Object)this._LastSelect != (UnityEngine.Object)null)
                this._LastSelect.SetActive(false);
            this.Refresh((int)icb.ID, true);
            return true;
        }

        private bool OnCloseClicked(IXUIButton button)
        {
            this.SetVisibleWithAnimation(false, (DlgBase<XSkillTreeView, XSkillTreeBehaviour>.OnAnimationOver)null);
            return true;
        }

        public void Refresh(int Promote, bool resetCurrentSkill = false, bool resetPosition = true)
        {
            this.LastSelectPromote = Promote;
            this._icbList[Promote].bChecked = true;
            if ((uint)((int)XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID / this.MI[Promote] % 10) > 0U)
            {
                if (resetCurrentSkill)
                    this._doc.CurrentSkillID = this._doc.UNSELECT;
                this.ShowSkillTreeFrame(Promote);
            }
            else
                this.ShowTransferFrame(Promote);
            this.SetOtherInfo(Promote == XSkillTreeView.AwakeIndex);
            if (!resetPosition)
                return;
            this.uiBehaviour.m_SkillTreeScrollView.ResetPosition();
        }

        public void ShowSkillTreeFrame(int Promote)
        {
            this.IsPromoteHandlerShow = false;
            this._skillDlgPromoteHandler.SetVisible(false);
            this.SetupSkillFrame(Promote);
        }

        private void ShowTransferFrame(int Promote)
        {
            this.IsPromoteHandlerShow = true;
            this._skillDlgPromoteHandler.IsShowAwake = Promote == XSkillTreeView.AwakeIndex;
            this._skillDlgPromoteHandler.CurrStage = Promote;
            this._skillDlgPromoteHandler.SetVisible(true);
        }

        private void OnPlaySkillClicked(IXUISprite sp)
        {
            this.uiBehaviour.m_SkillPlayBtn.SetVisible(false);
            XSingleton<XSkillPreViewMgr>.singleton.ShowSkill(this._doc.Dummy, this._doc.CurrentSkillID);
        }

        private bool OnSkillLevelUpClicked(IXUIButton button)
        {
            this._doc.SendSkillLevelup();
            return true;
        }

        public void SetupSkillFrame(int Promote)
        {
            if (!this.IsVisible())
                return;
            int profID = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID % this.MI[Promote + 1];
            this.uiBehaviour.m_SkillPool.ReturnAll();
            this.uiBehaviour.m_ArrowPool.ReturnAll();
            List<uint> profSkillId = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(profID);
            List<SkillTreeSortItem> skillTreeSortItemList = new List<SkillTreeSortItem>();
            for (int index = 0; index < profSkillId.Count; ++index)
            {
                SkillTreeSortItem skillTreeSortItem = new SkillTreeSortItem();
                skillTreeSortItem.skillID = profSkillId[index];
                SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillId[index], 0U);
                skillTreeSortItem.x = (int)skillConfig.XPostion;
                skillTreeSortItem.y = (int)skillConfig.YPostion;
                skillTreeSortItemList.Add(skillTreeSortItem);
            }
            skillTreeSortItemList.Sort(new Comparison<SkillTreeSortItem>(this.Compare));
            int num = 0;
            for (int index = 0; index < skillTreeSortItemList.Count; ++index)
            {
                GameObject go = this.uiBehaviour.m_SkillPool.FetchGameObject();
                go.name = string.Format("Skill{0}", (object)++num);
                this.SetupSkill(go, skillTreeSortItemList[index].skillID);
            }
        }

        private void SetOtherInfo(bool isAwake = false)
        {
            this.uiBehaviour.m_FreeResetSkillTip.SetVisible((long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (long)XSingleton<XGlobalConfig>.singleton.GetInt("FreeResetSkillLevel"));
            int skillPointCount = (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetSkillPointCount();
            this.uiBehaviour.m_UseSkillPoint.SetText(string.Format("{0}/{1}", (object)skillPointCount, (object)this._doc.TotalSkillPoint));
            this.uiBehaviour.m_UseAwakeSkillPoint.SetText(string.Format("{0}/{1}", (object)(int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetSkillPointCount(true), (object)this._doc.TotalAwakeSkillPoint));
            this.uiBehaviour.m_LeftSkillPoint.SetText(skillPointCount.ToString());
            this.uiBehaviour.m_ResetProBtn.SetEnabled(XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID > 10U);
            this.uiBehaviour.m_ResetSkillBtn.SetEnabled((isAwake ? this._doc.TotalAwakeSkillPoint : this._doc.TotalSkillPoint) - (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetSkillPointCount(isAwake) != 1);
            this.uiBehaviour.m_SwitchSkillPageBtn.SetGrey((long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= (long)this._doc.SkillPageOpenLevel);
            this.uiBehaviour.m_SkillPageText.SetEnabled((long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= (long)this._doc.SkillPageOpenLevel);
            this.uiBehaviour.m_SkillPageText.SetText(XStringDefineProxy.GetString(string.Format("SkillPage{0}", (object)(uint)(1 - (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillPageIndex))));
        }

        protected void SetupSkill(GameObject go, uint skillID)
        {
            uint skillOriginalLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(skillID);
            SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skillID, skillOriginalLevel);
            SkillList.RowData rowData = (SkillList.RowData)null;
            if (skillConfig.PreSkill != null && skillConfig.PreSkill != "")
                rowData = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(XSingleton<XSkillEffectMgr>.singleton.GetSkillID(skillConfig.PreSkill), 0U);
            int skillMaxLevel = XSingleton<XSkillEffectMgr>.singleton.GetSkillMaxLevel(skillID);
            SkillTypeEnum skillType = (SkillTypeEnum)skillConfig.SkillType;
            IXUISprite component1 = go.GetComponent("XUISprite") as IXUISprite;
            IXUISprite component2 = go.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
            IXUISprite component3 = go.transform.Find("Icon/P").GetComponent("XUISprite") as IXUISprite;
            IXUILabel component4 = go.transform.Find("Text").GetComponent("XUILabel") as IXUILabel;
            IXUISprite component5 = go.transform.FindChild("Tip").GetComponent("XUISprite") as IXUISprite;
            IXUILabel component6 = go.transform.FindChild("LockTip").GetComponent("XUILabel") as IXUILabel;
            IXUISprite component7 = go.transform.FindChild("Lock").GetComponent("XUISprite") as IXUISprite;
            GameObject gameObject1 = go.transform.Find("Select").gameObject;
            component1.ID = (ulong)skillID;
            component1.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSkillClicked));
            if ((int)this._doc.CurrentSkillID == (int)this._doc.UNSELECT || (int)this._doc.CurrentSkillID == (int)skillID)
            {
                gameObject1.SetActive(true);
                this._doc.CurrentSkillID = skillID;
                this.OnSkillClicked(component1);
                this._LastSelect = gameObject1;
            }
            else
                gameObject1.SetActive(false);
            Transform child1 = go.transform.FindChild("CanLearn");
            Transform child2 = go.transform.FindChild("RedPoint");
            child1.gameObject.SetActive(false);
            child2.gameObject.SetActive(false);
            if ((skillType == SkillTypeEnum.Skill_Normal || skillType == SkillTypeEnum.Skill_Big || skillType == SkillTypeEnum.Skill_Buff) && this._doc.SkillIsEquip(skillID))
                component5.SetVisible(true);
            else
                component5.SetVisible(false);
            go.transform.localPosition = new Vector3(this.uiBehaviour.m_SkillPool.TplPos.x + (float)(((int)skillConfig.XPostion - 1) * this.uiBehaviour.m_SkillPool.TplWidth), (float)skillConfig.YPostion);
            component2.SetSprite(skillConfig.Icon, skillConfig.Atlas);
            component6.SetVisible(this._doc.CheckPreSkillLevel(skillID) != 0 && !this._doc.CanSkillLevelUp(skillID, skillOriginalLevel) && skillOriginalLevel == 0U);
            component4.SetVisible(this._doc.CheckPreSkillLevel(skillID) != 0 && this._doc.CanSkillLevelUp(skillID, skillOriginalLevel) || skillOriginalLevel > 0U);
            component4.SetText(skillOriginalLevel.ToString() + "/" + (object)skillMaxLevel);
            if (skillOriginalLevel == 0U && !this._doc.CanSkillLevelUp(skillID, skillOriginalLevel))
            {
                component6.SetText(string.Format(XStringDefineProxy.GetString(XStringDefine.SKILL_LEARN), (object)skillConfig.UpReqRoleLevel[0]));
            }
            else
            {
                bool flag1 = this._doc.CheckFx(skillID);
                bool flag2 = this._doc.CheckRedPoint(skillID);
                bool flag3 = this._doc.CheckNew(skillID);
                IXUISprite component8 = child2.transform.FindChild("Fx").GetComponent("XUISprite") as IXUISprite;
                IXUISprite component9 = child2.transform.FindChild("Fx1").GetComponent("XUISprite") as IXUISprite;
                component8.SetVisible(false);
                component9.SetVisible(false);
                if (flag3)
                {
                    child2.gameObject.SetActive(true);
                    component8.SetVisible(true);
                }
                if (flag1 && !flag2)
                    child1.gameObject.SetActive(true);
                if (flag2)
                {
                    child2.gameObject.SetActive(true);
                    component9.SetVisible(true);
                }
            }
            switch (skillType)
            {
                case SkillTypeEnum.Skill_Big:
                    component3.SetSprite("JN_dk_0");
                    break;
                case SkillTypeEnum.Skill_Buff:
                    component3.SetSprite("JN_dk_buff");
                    break;
                default:
                    component3.SetSprite("JN_dk");
                    break;
            }
            if (rowData != null)
            {
                Vector3 localPosition = go.transform.localPosition;
                Vector3 vector3_1 = new Vector3(this.uiBehaviour.m_SkillPool.TplPos.x + (float)(((int)rowData.XPostion - 1) * this.uiBehaviour.m_SkillPool.TplWidth), (float)rowData.YPostion);
                Vector3 vector3_2 = (localPosition + vector3_1) / 2f;
                GameObject gameObject2 = this.uiBehaviour.m_ArrowPool.FetchGameObject();
                IXUISprite component10 = gameObject2.GetComponent("XUISprite") as IXUISprite;
                if ((int)skillConfig.XPostion == (int)rowData.XPostion || (int)skillConfig.YPostion == (int)rowData.YPostion)
                {
                    if ((int)skillConfig.XPostion == (int)rowData.XPostion)
                    {
                        component10.SetSprite("SkillTree_3");
                        component10.spriteHeight = (int)((double)((int)rowData.YPostion - (int)skillConfig.YPostion) - (double)component2.spriteHeight * 1.5);
                        component10.spriteWidth = this.uiBehaviour.m_ArrowPool.TplWidth;
                        gameObject2.transform.localPosition = vector3_2;
                        gameObject2.transform.localScale = new Vector3(1f, 1f);
                        gameObject2.transform.localRotation = Quaternion.identity;
                    }
                    else
                    {
                        component10.SetSprite("SkillTree_3");
                        int num = (int)skillConfig.XPostion < (int)rowData.XPostion ? 1 : -1;
                        component10.spriteHeight = (int)((double)(((int)rowData.XPostion - (int)skillConfig.XPostion) * (num * this.uiBehaviour.m_SkillPool.TplWidth)) - (double)component2.spriteWidth * 1.5);
                        component10.spriteWidth = this.uiBehaviour.m_ArrowPool.TplWidth;
                        gameObject2.transform.localPosition = vector3_2;
                        gameObject2.transform.localScale = new Vector3(1f, 1f);
                        gameObject2.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, (float)(-num * 90));
                    }
                }
                else
                {
                    component10.SetSprite("SkillTree_4");
                    component10.spriteHeight = (int)Math.Abs(localPosition.y - vector3_1.y) - component2.spriteHeight / 2;
                    component10.spriteWidth = (int)Math.Abs(localPosition.x - vector3_1.x) - component2.spriteWidth / 2;
                    int num = (int)skillConfig.XPostion < (int)rowData.XPostion ? 1 : -1;
                    gameObject2.transform.localPosition = vector3_2 + new Vector3((float)(component2.spriteWidth / 2 * -num), (float)(component2.spriteHeight / 2));
                    gameObject2.transform.localScale = new Vector3((float)num, 1f);
                    gameObject2.transform.localRotation = Quaternion.identity;
                }
            }
            component2.SetEnabled(skillOriginalLevel > 0U);
            component3.SetEnabled(skillOriginalLevel > 0U);
            component7.SetVisible(skillOriginalLevel == 0U);
            component7.SetEnabled(skillOriginalLevel > 0U);
            component2.ID = (ulong)skillID;
        }

        private void OnSkillClicked(IXUISprite sp)
        {
            this._doc.CurrentSkillID = (uint)sp.ID;
            if ((UnityEngine.Object)this._LastSelect != (UnityEngine.Object)null)
                this._LastSelect.SetActive(false);
            this._LastSelect = sp.gameObject.transform.Find("Select").gameObject;
            this._LastSelect.SetActive(true);
            this._CurrentSkillSprite = sp.gameObject.transform.FindChild("RedPoint").gameObject;
            this.SetupDetail();
        }

        private void OnSetupSkillClicked(IXUISprite sp)
        {
            uint currentSkillId = this._doc.CurrentSkillID;
            uint id = (uint)sp.ID;
            uint skillSlotUnLockLevel = this._doc.GetSkillSlotUnLockLevel((int)sp.ID);
            if (skillSlotUnLockLevel > XSingleton<XAttributeMgr>.singleton.XPlayerData.Level)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("OpenSkillAtLevel", (object)skillSlotUnLockLevel), "fece00");
                this.SetupBaseSkill();
            }
            else
                this._doc.SendBindSkill(currentSkillId, id);
        }

        private bool TurnSwitchFrameState(IXUIButton btn)
        {
            this._SwitchFrameState = !this._SwitchFrameState;
            this.SetupDetail();
            int group = this._SwitchFrameState ? 1 : 0;
            this.uiBehaviour.m_DetailFrameTween.StopTweenByGroup(1 - group);
            this.uiBehaviour.m_CatchFrameTween.StopTweenByGroup(1 - group);
            this.uiBehaviour.m_DetailFrameTween.SetTweenGroup(group);
            this.uiBehaviour.m_CatchFrameTween.SetTweenGroup(group);
            this.uiBehaviour.m_DetailFrameTween.PlayTween(true);
            this.uiBehaviour.m_CatchFrameTween.PlayTween(true);
            return true;
        }

        public void SetupDetail(bool resetSnap = true)
        {
            uint skillOriginalLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(this._doc.CurrentSkillID);
            SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(this._doc.CurrentSkillID, skillOriginalLevel);
            if (skillConfig == null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Can't find Current Skill, SkillID = ", this._doc.CurrentSkillID.ToString());
            }
            else
            {
                SkillTypeEnum skillType = (SkillTypeEnum)skillConfig.SkillType;
                bool bVisible1 = false;
                bool bVisible2 = false;
                bool bVisible3 = (long)skillOriginalLevel < (long)XSingleton<XSkillEffectMgr>.singleton.GetSkillMaxLevel(this._doc.CurrentSkillID);
                if (skillType == SkillTypeEnum.Skill_Normal || skillType == SkillTypeEnum.Skill_Big || skillType == SkillTypeEnum.Skill_Help || skillType == SkillTypeEnum.Skill_Buff)
                    bVisible1 = true;
                if (skillOriginalLevel > 0U && !this._doc.IsExSkill(skillConfig) && (skillType == SkillTypeEnum.Skill_Normal || skillType == SkillTypeEnum.Skill_Big || skillType == SkillTypeEnum.Skill_Buff))
                    bVisible2 = true;
                if ((int)this._doc.CurrentSkillID != (int)this._doc.UNSELECT)
                    this.uiBehaviour.m_SkillLearnRedPoint.gameObject.SetActive(this._doc.CheckRedPoint(this._doc.CurrentSkillID));
                else
                    this.uiBehaviour.m_SkillLearnRedPoint.gameObject.SetActive(false);
                if (resetSnap)
                {
                    XSingleton<XSkillPreViewMgr>.singleton.SkillShowEnd(this._doc.Dummy);
                    XSingleton<XSkillPreViewMgr>.singleton.SkillShowBegin(this._doc.Dummy, this._doc.BlackHouseCamera);
                }
                this.uiBehaviour.m_NonPreView.SetActive(!bVisible1);
                this.uiBehaviour.m_Snapshot.SetVisible(bVisible1);
                this.uiBehaviour.m_SkillPlayBtn.SetVisible(bVisible1);
                this.uiBehaviour.m_ChooseBtn.SetVisible(bVisible2);
                if (bVisible2)
                {
                    Vector3 localPosition = this.uiBehaviour.m_ChooseBtn.gameObject.transform.localPosition;
                    if (bVisible3)
                        this.uiBehaviour.m_ChooseBtn.gameObject.transform.localPosition = new Vector3(96f, localPosition.y);
                    else
                        this.uiBehaviour.m_ChooseBtn.gameObject.transform.localPosition = new Vector3(0.0f, localPosition.y);
                }
                if (!bVisible2 && !this._SwitchFrameState)
                    this.TurnSwitchFrameState((IXUIButton)null);
                this.uiBehaviour.m_LearnBtn.SetVisible(bVisible3);
                if (bVisible3)
                {
                    Vector3 localPosition = this.uiBehaviour.m_LearnBtn.gameObject.transform.localPosition;
                    if (bVisible2)
                        this.uiBehaviour.m_LearnBtn.gameObject.transform.localPosition = new Vector3(-96f, localPosition.y);
                    else
                        this.uiBehaviour.m_LearnBtn.gameObject.transform.localPosition = new Vector3(0.0f, localPosition.y);
                }
                IXUISprite component1 = this.uiBehaviour.m_LearnBtn.gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
                ItemList.RowData itemConf = XBagDocument.GetItemConf(skillConfig.IsAwake ? XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.AWAKE_SKILL_POINT) : XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.SKILL_POINT));
                if (itemConf != null && itemConf.ItemAtlas1.Length != 0 && (uint)itemConf.ItemIcon1.Length > 0U)
                    component1.SetSprite(itemConf.ItemIcon1[0], itemConf.ItemAtlas1[0]);
                (this.uiBehaviour.m_LearnBtn.gameObject.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel).SetText(XStringDefineProxy.GetString(skillOriginalLevel == 0U ? "LEARN" : "UPGRADE"));
                IXUILabel component2 = this.uiBehaviour.m_LearnBtn.gameObject.transform.FindChild("Cost").GetComponent("XUILabel") as IXUILabel;
                if (skillConfig.LevelupCost == null)
                    component2.SetText("0");
                else if ((long)skillOriginalLevel < (long)skillConfig.LevelupCost.Length)
                    component2.SetText(skillConfig.LevelupCost[(int)skillOriginalLevel].ToString());
                else
                    component2.SetText(skillConfig.LevelupCost[skillConfig.LevelupCost.Length - 1].ToString());
                this.uiBehaviour.m_LearnBtn.SetGrey(this._doc.CheckLevelUpButton(this._doc.CurrentSkillID));
                this.SetupDetailMsg(this._doc.CurrentSkillID, skillOriginalLevel, skillConfig);
                this.SetupBaseSkill();
            }
        }

        private void SetupBaseSkill()
        {
            SkillList.RowData skillConfig1 = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(this._doc.CurrentSkillID, 0U);
            SkillTypeEnum skillType = (SkillTypeEnum)skillConfig1.SkillType;
            bool isAwake = skillConfig1.IsAwake;
            for (int slotid = 0; slotid < XSkillTreeDocument.SkillSlotCount; ++slotid)
            {
                if (slotid != 0 && slotid != 1)
                {
                    if (slotid == XSkillTreeDocument.AwakeSkillSlot)
                        this.uiBehaviour.m_SkillSlotList[slotid].gameObject.SetActive(this._doc.IsAwakeSkillSlotOpen && this._doc.IsSelfAwaked);
                    uint skillHash = 0;
                    if (slotid < XSingleton<XAttributeMgr>.singleton.XPlayerData.skillSlot.Length)
                        skillHash = XSingleton<XAttributeMgr>.singleton.XPlayerData.skillSlot[slotid];
                    SkillTypeEnum skillSlotType = this._doc.GetSkillSlotType(slotid);
                    IXUISprite component1 = this.uiBehaviour.m_SkillSlotList[slotid].gameObject.transform.Find("Light").GetComponent("XUISprite") as IXUISprite;
                    IXUISprite component2 = this.uiBehaviour.m_SkillSlotList[slotid].gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
                    IXUISprite component3 = this.uiBehaviour.m_SkillSlotList[slotid].gameObject.transform.Find("Lock").GetComponent("XUISprite") as IXUISprite;
                    BoxCollider component4 = this.uiBehaviour.m_SkillSlotList[slotid].gameObject.GetComponent("BoxCollider") as BoxCollider;
                    if (skillConfig1.ExSkillScript == "")
                    {
                        component1.SetVisible((int)skillHash == (int)this._doc.CurrentSkillID);
                    }
                    else
                    {
                        uint skillId = XSingleton<XSkillEffectMgr>.singleton.GetSkillID(skillConfig1.ExSkillScript);
                        component1.SetVisible((int)skillHash == (int)this._doc.CurrentSkillID || (int)skillHash == (int)skillId);
                    }
                    if (skillSlotType == skillType)
                    {
                        this.uiBehaviour.m_SkillSlotList[slotid].SetAlpha(1f);
                        component4.enabled = true;
                    }
                    else
                    {
                        this.uiBehaviour.m_SkillSlotList[slotid].SetAlpha(0.5f);
                        component4.enabled = false;
                    }
                    component3.SetAlpha(this._doc.GetSkillSlotUnLockLevel(slotid) > XSingleton<XAttributeMgr>.singleton.XPlayerData.Level ? 1f : 0.0f);
                    if (skillSlotType == SkillTypeEnum.Skill_Buff && this._doc.GetSkillSlotUnLockLevel(XFastEnumIntEqualityComparer<XSkillSlot>.ToInt(XSkillSlot.Skill_1_Buff)) > XSingleton<XAttributeMgr>.singleton.XPlayerData.Level)
                        this.uiBehaviour.m_SkillSlotList[slotid].SetAlpha(0.0f);
                    if (skillHash > 0U)
                    {
                        uint skillOriginalLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(skillHash);
                        SkillList.RowData skillConfig2 = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skillHash, skillOriginalLevel);
                        component2.SetSprite(skillConfig2.Icon, skillConfig2.Atlas);
                    }
                    else
                        component2.spriteName = "EmptySkill";
                }
            }
        }

        private void SetupDetailMsg(uint skillID, uint skillLevel, SkillList.RowData data)
        {
            SkillTypeEnum skillType = (SkillTypeEnum)data.SkillType;
            string strText1 = string.Format("{0}({1}/{2})", (object)data.ScriptName, (object)skillLevel, (object)XSingleton<XSkillEffectMgr>.singleton.GetSkillMaxLevel(skillID));
            this.uiBehaviour.m_SkillName_L.SetText(strText1);
            this.uiBehaviour.m_SkillName_S.SetText(strText1);
            string strText2;
            switch (skillType)
            {
                case SkillTypeEnum.Skill_Big:
                    strText2 = XStringDefineProxy.GetString("SPECIAL_SKILL");
                    break;
                case SkillTypeEnum.Skill_SceneBuff:
                    strText2 = XStringDefineProxy.GetString("SCENEBUFF_SKILL");
                    break;
                case SkillTypeEnum.Skill_Help:
                    strText2 = XStringDefineProxy.GetString("SUPPORT_SKILL");
                    break;
                case SkillTypeEnum.Skill_Buff:
                    strText2 = XStringDefineProxy.GetString("BUFF_SKILL");
                    break;
                case SkillTypeEnum.Skill_Awake:
                    strText2 = XStringDefineProxy.GetString("AWAKE_SKILL");
                    break;
                default:
                    strText2 = XStringDefineProxy.GetString("NORMAL_SKILL");
                    break;
            }
            this.uiBehaviour.m_SkillType_L.SetText(strText2);
            this.uiBehaviour.m_SkillType_S.SetText(strText2);
            this.uiBehaviour.m_ChooseTips.SetText(string.Format(XStringDefineProxy.GetString("SKILL_CHOOSE_TIPS"), (object)strText2));
            this.uiBehaviour.m_SkillCostText.SetText((data.CostMP[0] + data.CostMP[1] * (float)skillLevel).ToString());
            this.uiBehaviour.m_SkillAttrText.SetText(XSkillTreeDocument.GetSkillAttrStr((int)data.Element));
            if (skillType != SkillTypeEnum.Skill_SceneBuff)
                this.uiBehaviour.m_SkillCDText.SetText(string.Format("{0}s", (object)Math.Round((double)XSkillMgr.GetCD((XEntity)this._doc.Player, data.SkillScript) + 0.01, 1)));
            else
                this.uiBehaviour.m_SkillCDText.SetText(XStringDefineProxy.GetString("NONE"));
            this.uiBehaviour.m_SkillDetail_L.SetText(data.CurrentLevelDescription);
            this.uiBehaviour.m_SkillDetail_S.SetText(data.CurrentLevelDescription);
            this.uiBehaviour.m_SkillDetailScrollView_S.SetPosition(0.0f);
            uint preSkill = XSingleton<XSkillEffectMgr>.singleton.GetPreSkill(skillID, 0U);
            uint num = 0;
            if (preSkill > 0U)
                num = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(preSkill);
            float Ratio;
            float Fixed;
            XSingleton<XSkillEffectMgr>.singleton.GetSkillDescriptValue(skillID, preSkill == 0U ? skillLevel : num, XSingleton<XGame>.singleton.Doc.XBagDoc.EmblemBag, out Ratio, out Fixed);
            this.uiBehaviour.m_SkillCurrDesc.SetText(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(data.NextLevelDescription), (object)Math.Round((double)Ratio * 100.0 + 0.01, 1), (object)Math.Round((double)Fixed + 0.01, 1)));
            this.uiBehaviour.m_SkillPreSkillPointTips.SetVisible(false);
            if (num == 0U)
                ++num;
            XSingleton<XSkillEffectMgr>.singleton.GetSkillDescriptValue(skillID, preSkill == 0U ? skillLevel + 1U : num, XSingleton<XGame>.singleton.Doc.XBagDoc.EmblemBag, out Ratio, out Fixed);
            this.uiBehaviour.m_SkillNextDesc.SetText(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(data.NextLevelDescription), (object)Math.Round((double)Ratio * 100.0 + 0.01, 1), (object)Math.Round((double)Fixed + 0.01, 1)));
            if (this._doc.CanSkillLevelUp(skillID, skillLevel))
            {
                this.uiBehaviour.m_SkillNextReq.SetText("");
            }
            else
            {
                SkillLevelupRequest levelupRequest = XSingleton<XSkillEffectMgr>.singleton.GetLevelupRequest(skillID, skillLevel);
                this.uiBehaviour.m_SkillNextReq.SetText(string.Format("{0}({1})", (object)string.Format(XStringDefineProxy.GetString(XStringDefine.ITEM_REQUIRE_LEVEL), (object)levelupRequest.Level), (object)string.Format(XStringDefineProxy.GetString("LEFT_LEVEL"), (object)((long)levelupRequest.Level - (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level))));
            }
            this.uiBehaviour.m_SuperIndureAttack.SetText(data.SuperIndureAttack);
            this.uiBehaviour.m_SuperIndureDenfense.SetText(data.SuperIndureDefense);
            if (skillLevel == 0U)
            {
                this.uiBehaviour.m_SkillCurrDesc.SetText(XStringDefineProxy.GetString("NOT_LEARN"));
                bool isAwake = data.IsAwake;
                if ((isAwake ? this._doc.TotalAwakeSkillPoint : this._doc.TotalSkillPoint) - (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetSkillPointCount(isAwake) < (int)data.PreSkillPoint)
                {
                    this.uiBehaviour.m_SkillPreSkillPointTips.SetVisible(true);
                    this.uiBehaviour.m_SkillPreSkillPointTips.SetText(string.Format(XStringDefineProxy.GetString("SKILLTREE_PRESKILLPOINT_TIPS"), (object)data.PreSkillPoint));
                }
                else
                    this.uiBehaviour.m_SkillPreSkillPointTips.SetVisible(false);
            }
            else if ((long)skillLevel == (long)XSingleton<XSkillEffectMgr>.singleton.GetSkillMaxLevel(skillID))
            {
                this.uiBehaviour.m_SkillNextDesc.SetText(XStringDefineProxy.GetString("SkillLevelMaxTips"));
                this.uiBehaviour.m_SkillNextReq.SetText("");
            }
            this.uiBehaviour.m_SkillDetailScrollView.ResetPosition();
        }

        private void OnResetSkillPointClicked(IXUISprite sp)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton._bHasGrey = false;
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
            int num = XSingleton<XGlobalConfig>.singleton.GetInt("SkillResetCost");
            if ((long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (long)XSingleton<XGlobalConfig>.singleton.GetInt("FreeResetSkillLevel"))
                num = 0;
            if ((uint)num > 0U)
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString(XStringDefine.SKILL_RESET_SP)), (object)num, (object)XLabelSymbolHelper.FormatSmallIcon(7)), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL));
            else
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(string.Format(XStringDefineProxy.GetString("FREE_RESET_SKILL_POINT"), (object)XSingleton<XGlobalConfig>.singleton.GetInt("FreeResetSkillLevel")), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL));
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnResetSpConfirmed));
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetTweenTargetAndPlay(DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.gameObject);
        }

        private bool OnResetSpConfirmed(IXUIButton go)
        {
            this._doc.SendResetSkill();
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            return true;
        }

        private void OnResetProfClicked(IXUISprite sp)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton._bHasGrey = false;
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(string.Format("{0}{1}", (object)string.Format(XStringDefineProxy.GetString(XStringDefine.SKILL_RESET_PROF), (object)XSingleton<XGlobalConfig>.singleton.GetInt("SkillResetProfession")), (object)XLabelSymbolHelper.FormatSmallIcon(7)), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL));
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnResetProfConfirmed));
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetTweenTargetAndPlay(DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.gameObject);
        }

        private bool OnResetProfConfirmed(IXUIButton go)
        {
            this._doc.SendResetProf();
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            return true;
        }

        private void OnSwitchSkillPageBtnClick(IXUISprite iSp)
        {
            if ((long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (long)this._doc.SkillPageOpenLevel)
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SkillPageOpenTips"), "fece00");
            else if ((double)Time.time - (double)this._skillPageSwitchSignTime < 2.0)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SkillPageSwitchTooOften"), "fece00");
            }
            else
            {
                this._skillPageSwitchSignTime = Time.time;
                this._doc.QuerySwitchSkillPage();
            }
        }

        public void OnSkillLevelUp(int x, int y)
        {
            if (!this.IsVisible())
                return;
            this.uiBehaviour.m_LevelUpFx.gameObject.transform.localPosition = new Vector3(this.uiBehaviour.m_SkillPool.TplPos.x + (float)((x - 1) * this.uiBehaviour.m_SkillPool.TplWidth), (float)y);
            this.uiBehaviour.m_LevelUpFx.SetActive(false);
            this.uiBehaviour.m_LevelUpFx.SetActive(true);
        }

        public void SetLearnSkillButtonState(bool state)
        {
            if (!DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.IsVisible())
                return;
            this.uiBehaviour.m_LearnBtn.SetEnable(state);
        }

        public void CreateAndPlayFxFxFirework()
        {
            XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/zhuanzhi");
            this.DestroyFx(this._FxFirework);
            this._FxFirework = (XFx)null;
            this._FxFirework = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_zzcg");
            this._FxFirework.Play(this.uiBehaviour.m_FxFirework, Vector3.zero, Vector3.one, follow: true);
        }

        public void DestroyFx(XFx fx)
        {
            if (fx == null)
                return;
            XSingleton<XFxMgr>.singleton.DestroyFx(fx);
        }

        private void OnUnableCheckBoxClick(IXUISprite iSp) => XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("CHANGEPROF_PRETIPS"), (object)iSp.ID), "fece00");

        private int Compare(SkillTreeSortItem x, SkillTreeSortItem y)
        {
            if ((int)x.skillID == (int)y.skillID)
                return 0;
            return x.y != y.y ? y.y - x.y : x.x - y.x;
        }

        public void SetUVRectangle()
        {
            Rect rect = this._doc.BlackHouseCamera.rect;
            rect.y = (float)(((double)rect.y * 208.0 + 1.0) / 208.0);
            rect.height = (float)(((double)rect.height * 208.0 - 2.0) / 208.0);
            this.uiBehaviour.m_Snapshot.SetUVRect(rect);
        }
    }
}
