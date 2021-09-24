

using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class XPetMainView : DlgBase<XPetMainView, XPetMainBehaviour>
    {
        private XPetDocument doc;
        private XFoodSelectorHandler m_FoodSelectorHandler;
        private PairsPetSetHandler m_setHandler;
        public XDummy m_Dummy;
        private XPetSkillHandler m_SkillHandler;
        public PetExpTransferHandler ExpTransferHandler;
        public PetSkillLearnHandler SkillLearnHandler;
        public static readonly uint STAR_MAX = 10;
        public static readonly uint ATTRIBUTE_NUM_MAX = 10;
        private uint _RefreshDataTimerID = 0;
        private uint _PlayActionTimerID = 0;
        private uint _PlayBubbleTimerID = 0;
        private XPetMainView.PetStatus _PetStatus;
        public XFx _LevelUpFx;
        private XFx _MoodUpFx;
        private XFx _EatUpFx;
        private XFx _GetFx;

        public XFoodSelectorHandler FoodSelectorHandler => this.m_FoodSelectorHandler;

        public XPetSkillHandler SkillHandler => this.m_SkillHandler;

        public override string fileName => "GameSystem/PetMainDlg";

        public override int layer => 1;

        public override int group => 1;

        public override bool autoload => true;

        public override bool hideMainMenu => true;

        public override bool fullscreenui => true;

        public override bool pushstack => true;

        protected override void Init()
        {
            this.doc = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
            this.doc.View = this;
            DlgHandlerBase.EnsureCreate<XFoodSelectorHandler>(ref this.m_FoodSelectorHandler, this.uiBehaviour.m_FeedFrame);
            DlgHandlerBase.EnsureCreate<XPetSkillHandler>(ref this.m_SkillHandler, this.uiBehaviour.m_SkillFrame);
            DlgHandlerBase.EnsureCreate<PetExpTransferHandler>(ref this.ExpTransferHandler, this.uiBehaviour.m_Bg, false, (IDlgHandlerMgr)this);
            DlgHandlerBase.EnsureCreate<PetSkillLearnHandler>(ref this.SkillLearnHandler, this.uiBehaviour.m_Bg, false);
            DlgHandlerBase.EnsureCreate<PairsPetSetHandler>(ref this.m_setHandler, this.uiBehaviour.m_Bg, false);
        }

        protected override void OnShow()
        {
            base.OnShow();
            this.Alloc3DAvatarPool(nameof(XPetMainView));
            this.InitShow();
            this.m_FoodSelectorHandler.ShowBag(false);
            this.doc.Select(this.doc.DefaultPet, true);
        }

        public override void StackRefresh()
        {
            base.StackRefresh();
            this.Alloc3DAvatarPool(nameof(XPetMainView));
            this.RefreshPetModel();
            this.m_FoodSelectorHandler.ShowBag(false);
        }

        private void InitShow()
        {
            this.doc.ClearPetAnimation();
            XSingleton<XTimerMgr>.singleton.KillTimer(this._RefreshDataTimerID);
            XSingleton<XTimerMgr>.singleton.KillTimer(this._PlayActionTimerID);
            XSingleton<XTimerMgr>.singleton.KillTimer(this._PlayBubbleTimerID);
        }

        public void UnloadFx(XFx fx)
        {
            if (fx == null)
                return;
            XSingleton<XFxMgr>.singleton.DestroyFx(fx);
            fx = (XFx)null;
        }

        private void UnloadShow()
        {
            this.doc.ClearPetAnimation();
            XSingleton<XTimerMgr>.singleton.KillTimer(this._RefreshDataTimerID);
            XSingleton<XTimerMgr>.singleton.KillTimer(this._PlayActionTimerID);
            XSingleton<XTimerMgr>.singleton.KillTimer(this._PlayBubbleTimerID);
            this._RefreshDataTimerID = 0U;
            this._PlayActionTimerID = 0U;
            this._PlayBubbleTimerID = 0U;
            this.UnloadFx(this._LevelUpFx);
            this.UnloadFx(this._MoodUpFx);
            this.UnloadFx(this._EatUpFx);
            this.UnloadFx(this._GetFx);
            if (this.uiBehaviour.m_PetSnapshot != null)
                this.uiBehaviour.m_PetSnapshot.RefreshRenderQueue = (RefreshRenderQueueCb)null;
            this.Return3DAvatarPool();
        }

        protected override void OnHide()
        {
            this.UnloadShow();
            this.doc.HasNewPet = false;
            base.OnHide();
        }

        protected override void OnUnload()
        {
            this.UnloadShow();
            this.doc.View = (XPetMainView)null;
            this.doc = (XPetDocument)null;
            DlgHandlerBase.EnsureUnload<PetSkillLearnHandler>(ref this.SkillLearnHandler);
            DlgHandlerBase.EnsureUnload<PetExpTransferHandler>(ref this.ExpTransferHandler);
            DlgHandlerBase.EnsureUnload<XFoodSelectorHandler>(ref this.m_FoodSelectorHandler);
            DlgHandlerBase.EnsureUnload<XPetSkillHandler>(ref this.m_SkillHandler);
            DlgHandlerBase.EnsureUnload<PairsPetSetHandler>(ref this.m_setHandler);
            base.OnUnload();
        }

        public override void RegisterEvent()
        {
            this.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
            this.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
            this.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._OnPetListItemUpdated));
            this.uiBehaviour.m_BtnMount.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnMountClicked));
            this.uiBehaviour.m_BtnSkillLearn.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnSkillLearnClicked));
            this.uiBehaviour.m_Activation.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnActivationClicked));
            this.uiBehaviour.m_Throw.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnThrowClicked));
            this.uiBehaviour.m_ExpTransfer.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnExpTransferClicked));
            this.uiBehaviour.m_TravelSet.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnTravelSetClicked));
            this.uiBehaviour.m_MoodClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnMoodCloseClick));
            this.uiBehaviour.m_FullDegreeClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnFullDegreeCloseClick));
            this.uiBehaviour.m_FullDegreeSp.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnShowFullDegreeTip));
            this.uiBehaviour.m_MoodIcon.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnShowMoodTip));
            this.uiBehaviour.m_Caress.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCaressClick));
            this.uiBehaviour.m_GoGetPet.ID = ulong.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("PetGoBuyPet"));
            this.uiBehaviour.m_GoGetPet.RegisterLabelClickEventHandler(new LabelClickEventHandler(this._OnGoClick));
            this.uiBehaviour.m_GoGetFeed.ID = ulong.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("PetGoBuyFeed"));
            this.uiBehaviour.m_GoGetFeed.RegisterLabelClickEventHandler(new LabelClickEventHandler(this._OnGoClick));
            this.uiBehaviour.m_PrivilegeBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMemberPrivilegeClicked));
        }

        private void OnMemberPrivilegeClicked(IXUISprite btn) => DlgBase<XWelfareView, XWelfareBehaviour>.singleton.CheckActiveMemberPrivilege(MemberPrivilege.KingdomPrivilege_Adventurer);

        public bool OnHelpClicked(IXUIButton button)
        {
            DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Horse);
            return true;
        }

        private void _OnGoClick(IXUILabel go) => XSingleton<XGameSysMgr>.singleton.OpenSystem((XSysDefine)go.ID);

        private bool _OnCloseBtnClick(IXUIButton go)
        {
            this.SetVisibleWithAnimation(false, (DlgBase<XPetMainView, XPetMainBehaviour>.OnAnimationOver)null);
            return true;
        }

        private void _OnShowFullDegreeTip(IXUISprite iSp)
        {
            if (this.uiBehaviour.m_FullDegreeTip.gameObject.activeSelf)
            {
                this.uiBehaviour.m_FullDegreeTip.gameObject.SetActive(false);
            }
            else
            {
                this.uiBehaviour.m_FullDegreeTip.gameObject.SetActive(true);
                this.uiBehaviour.m_MoodTip.gameObject.SetActive(false);
                this.uiBehaviour.m_FullDegreeLabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("PET_FULL_DEGREE_TIP")));
            }
        }

        private void _OnShowMoodTip(IXUISprite iSp)
        {
            if (this.uiBehaviour.m_MoodTip.gameObject.activeSelf)
            {
                this.uiBehaviour.m_MoodTip.gameObject.SetActive(false);
            }
            else
            {
                this.uiBehaviour.m_MoodTip.gameObject.SetActive(true);
                this.uiBehaviour.m_FullDegreeTip.gameObject.SetActive(false);
                this.uiBehaviour.m_MoodLabel.SetText(this.doc.GetPetMoodTip(this.doc.CurSelectedPet.Mood).tips);
                XSingleton<XDebug>.singleton.AddLog("Mood:" + (object)this.doc.CurSelectedPet.Mood);
            }
        }

        private void _OnMoodCloseClick(IXUISprite iSp) => this.uiBehaviour.m_MoodTip.gameObject.SetActive(false);

        private void _OnFullDegreeCloseClick(IXUISprite iSp) => this.uiBehaviour.m_FullDegreeTip.gameObject.SetActive(false);

        private void _OnCaressClick(IXUISprite iSp) => this.doc.ReqPetTouch();

        public void RefreshPage(bool bResetPosition = true)
        {
            this.RefreshList(bResetPosition);
            this.RefreshContent();
        }

        public void RefreshContent()
        {
            XPet curSelectedPet = this.doc.CurSelectedPet;
            if (curSelectedPet == null)
            {
                this.uiBehaviour.m_ContentFrame.SetActive(false);
            }
            else
            {
                this.uiBehaviour.m_ContentFrame.SetActive(true);
                this.RefreshBaseInfo();
                this.RefreshAttribute();
                this.RefreshExp();
                this.RefreshFullDegree();
                this.RefreshMood();
                this.RefreshPrivilege();
                this.uiBehaviour.m_FeedRedPoint.gameObject.SetActive(this.doc.HasRedPoint && (long)curSelectedPet.UID == (long)this.doc.CurFightUID);
            }
            this.m_SkillHandler.Refresh(curSelectedPet);
        }

        public void RefreshPrivilege() => this.uiBehaviour.m_ExpPrivilegeSp.gameObject.SetActive(false);

        public void RefreshPetModel()
        {
            if (this.doc.CurSelectedPet == null)
                return;
            XSingleton<XTimerMgr>.singleton.KillTimer(this._PlayActionTimerID);
            this.m_Dummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, XPetDocument.GetPresentID(this.doc.CurSelectedPet.ID), this.m_uiBehaviour.m_PetSnapshot, this.m_Dummy);
            this.PetActionChange(XPetActionFile.IDLE, this.doc.CurSelectedPet.ID, this.m_Dummy, true);
        }

        public void PlayPetLevelUpFx(Transform t, bool follow = false)
        {
            if (!DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible())
                return;
            Vector3 scale = new Vector3(t.localScale.x / 300f, t.localScale.y / 300f, t.localScale.z / 300f);
            if (this._LevelUpFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._LevelUpFx);
            this._LevelUpFx = XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/Roles/Lzg_Ty/P_level_up_02", t, Vector3.zero, scale, follow: follow, duration: 5f);
        }

        public void PlayPetMoodUpFx()
        {
            if (!DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible())
                return;
            if (this._MoodUpFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._MoodUpFx);
            this._MoodUpFx = XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/VehicleFX/Vehicle_weiyang", this.uiBehaviour.m_Fx, Vector3.zero, Vector3.one, duration: 5f);
        }

        public void PlayPetEatUpFx()
        {
            if (!DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible())
                return;
            if (this._EatUpFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._EatUpFx);
            this._EatUpFx = XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/VehicleFX/Vehicle_weiyang_Clip01", this.uiBehaviour.m_Fx, Vector3.zero, Vector3.one, duration: 5f);
        }

        public void PlayPetGetFx()
        {
            if (!DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible())
                return;
            if (this._GetFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._GetFx);
            this._GetFx = XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_yh", this.uiBehaviour.m_Fx, Vector3.zero, Vector3.one, follow: true, duration: 5f);
            XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_Gethorse");
        }

        public void SetPetSex(IXUISprite sp, PetSex sex)
        {
            switch (sex)
            {
                case PetSex.Boy:
                    sp.SetSprite("zq_Gender1");
                    break;
                case PetSex.Girl:
                    sp.SetSprite("zq_Gender0");
                    break;
                default:
                    XSingleton<XDebug>.singleton.AddErrorLog("Pet Sex is Null");
                    break;
            }
            sp.MakePixelPerfect();
        }

        public void RefreshBaseInfo()
        {
            XPet curSelectedPet = this.doc.CurSelectedPet;
            if (curSelectedPet == null)
                return;
            this.SetPetSex(this.uiBehaviour.m_Sex, curSelectedPet.Sex);
            this.uiBehaviour.m_Name.SetText(curSelectedPet.Name);
            this.uiBehaviour.m_PPT.SetText(curSelectedPet.PPT.ToString());
            this.uiBehaviour.m_Level.SetText(string.Format("Lv.{0}", (object)curSelectedPet.showLevel.ToString()));
            this.uiBehaviour.m_ActivationSelected.SetActive((long)this.doc.CurFightUID == (long)curSelectedPet.UID);
            this.uiBehaviour.m_ActivationLabel.SetText((long)this.doc.CurFightUID == (long)curSelectedPet.UID ? XSingleton<XStringTable>.singleton.GetString("ACTIVATED") : XSingleton<XStringTable>.singleton.GetString("ACTIVATION"));
            this.uiBehaviour.m_BtnMountLabel.SetText((long)this.doc.CurMount == (long)curSelectedPet.UID ? XSingleton<XStringTable>.singleton.GetString("PET_DOWN") : XSingleton<XStringTable>.singleton.GetString("PET_RIDE"));
        }

        private void RefreshAttribute()
        {
            XPet curSelectedPet = this.doc.CurSelectedPet;
            if (curSelectedPet == null)
                return;
            PetInfoTable.RowData petInfo = XPetDocument.GetPetInfo(curSelectedPet.ID);
            BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)petInfo.SpeedBuff, 1);
            if (buffData == null)
                XSingleton<XDebug>.singleton.AddErrorLog("Buff No Find!\nSp BuffId:" + (object)petInfo.SpeedBuff);
            if (1201 != (int)buffData.BuffChangeAttribute[0, 0])
                XSingleton<XDebug>.singleton.AddErrorLog("Buff No Find XAttr_RUN_SPEED_Percent.\nSp BuffId:" + (object)petInfo.SpeedBuff);
            this.uiBehaviour.m_SpeedUp.SetText(string.Format("{0}%", (object)(buffData.BuffChangeAttribute[0, 1] + 100f).ToString()));
            PetLevelTable.RowData petLevel1 = XPetDocument.GetPetLevel(curSelectedPet);
            PetLevelTable.RowData petLevel2 = XPetDocument.GetPetLevel(curSelectedPet.ID, curSelectedPet.Level + 1);
            this.uiBehaviour.m_AttributePool.ReturnAll();
            for (int index = 0; (long)index < (long)XPetMainView.ATTRIBUTE_NUM_MAX; ++index)
            {
                if (index < petLevel1.PetsAttributes.Count)
                {
                    GameObject gameObject = this.uiBehaviour.m_AttributePool.FetchGameObject();
                    int spriteHeight = (gameObject.transform.GetComponent("XUISprite") as IXUISprite).spriteHeight;
                    IXUILabel component1 = gameObject.transform.Find("AttributeName").GetComponent("XUILabel") as IXUILabel;
                    IXUILabel component2 = gameObject.transform.Find("AttributeName/AttributeVal").GetComponent("XUILabel") as IXUILabel;
                    IXUILabel component3 = gameObject.transform.Find("AttributeName/GrowUp").GetComponent("XUILabel") as IXUILabel;
                    gameObject.transform.localPosition = new Vector3(0.0f, (float)(-spriteHeight * index), 0.0f);
                    string attrStr = XAttributeCommon.GetAttrStr((int)petLevel1.PetsAttributes[index, 0]);
                    component1.SetText(attrStr);
                    uint attrValue = 0;
                    for (int level = 1; level <= curSelectedPet.Level; ++level)
                    {
                        PetLevelTable.RowData petLevel3 = XPetDocument.GetPetLevel(curSelectedPet.ID, level);
                        attrValue += petLevel3.PetsAttributes[index, 1];
                    }
                    component2.SetText(XAttributeCommon.GetAttrValueStr(petLevel1.PetsAttributes[index, 0], attrValue, false));
                    if (petLevel2 != null)
                        component3.SetText(string.Format("+{0}", (object)petLevel2.PetsAttributes[index, 1].ToString()));
                    else
                        component3.SetText("");
                }
            }
        }

        public void RefreshExp()
        {
            XPet curSelectedPet = this.doc.CurSelectedPet;
            if (curSelectedPet == null)
                return;
            if (this.doc.IsMaxLevel(curSelectedPet.ID, curSelectedPet.showLevel))
            {
                this.uiBehaviour.m_Exp.SetText(XSingleton<XStringTable>.singleton.GetString("PET_LEVEL_MAX_TIP"));
                this.uiBehaviour.m_ExpBar.value = 0.0f;
                this.uiBehaviour.m_ExpBarLevel.SetText(string.Format("Lv.{0}", (object)curSelectedPet.showLevel.ToString()));
                this.doc.InPlayExpUp = false;
            }
            else
            {
                int curExp;
                int totalExp;
                this.doc.GetExpInfo(curSelectedPet, out curExp, out totalExp);
                this.uiBehaviour.m_Exp.SetText(string.Format("{0}/{1}", (object)curExp, (object)totalExp));
                this.uiBehaviour.m_ExpBar.value = Math.Min((float)curExp / (float)totalExp, 1f);
                this.uiBehaviour.m_ExpBarLevel.SetText(string.Format("Lv.{0}", (object)curSelectedPet.showLevel.ToString()));
            }
        }

        public void RefreshFullDegree()
        {
            XPet curSelectedPet = this.doc.CurSelectedPet;
            if (curSelectedPet == null)
                return;
            uint maxHungry = XPetDocument.GetPetInfo(curSelectedPet.ID).maxHungry;
            if (maxHungry == 0U)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("FullDegreeMAX = 0");
            }
            else
            {
                this.uiBehaviour.m_FullDegree.SetText(string.Format("{0}%", (object)curSelectedPet.showFullDegree));
                this.uiBehaviour.m_FullDegreeBar.value = (float)curSelectedPet.showFullDegree / (float)maxHungry;
                this.uiBehaviour.m_FullDegreeColor.SetColor((long)curSelectedPet.showFullDegree < (long)int.Parse(this.doc.ColorLevel[0]) ? ((long)curSelectedPet.showFullDegree < (long)int.Parse(this.doc.ColorLevel[1]) ? new Color(0.8941177f, 0.2666667f, 0.2666667f) : new Color(1f, 0.4705882f, 0.1215686f)) : new Color(0.6784314f, 0.8392157f, 0.09019608f));
            }
        }

        public void RefreshMood()
        {
            XPet curSelectedPet = this.doc.CurSelectedPet;
            if (curSelectedPet == null)
                return;
            PetMoodTipsTable.RowData petMoodTip = this.doc.GetPetMoodTip(curSelectedPet.Mood);
            if (petMoodTip == null)
                return;
            this.uiBehaviour.m_MoodLevel.SetText(petMoodTip.tip);
            this.uiBehaviour.m_MoodIcon.SetSprite(petMoodTip.icon);
        }

        public void RefreshList(bool bResetPosition = true)
        {
            this.uiBehaviour.m_WrapContent.SetContentCount(Math.Min(this.doc.PetCountMax, (int)this.doc.PetSeat + 1));
            if (bResetPosition)
                this.uiBehaviour.m_PetListScrollView.ResetPosition();
            else
                this.uiBehaviour.m_WrapContent.RefreshAllVisibleContents();
        }

        public void SetTravelSetBtnStatus()
        {
            if (this.doc.CurSelectedPet == null)
                return;
            PetInfoTable.RowData petInfo = XPetDocument.GetPetInfo(this.doc.CurSelectedPet.ID);
            this.uiBehaviour.m_TravelSet.gameObject.SetActive(petInfo != null && petInfo.PetType == 1U);
        }

        private void _OnPetListItemUpdated(Transform t, int index)
        {
            if (index < 0)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("index:" + (object)index);
            }
            else
            {
                List<XPet> pets = this.doc.Pets;
                IXUILabel component1 = t.Find("Level").GetComponent("XUILabel") as IXUILabel;
                IXUISprite component2 = t.Find("Item/PetIcon").GetComponent("XUISprite") as IXUISprite;
                IXUISprite component3 = t.Find("Item/Quality").GetComponent("XUISprite") as IXUISprite;
                GameObject gameObject1 = t.Find("Mount").gameObject;
                GameObject gameObject2 = t.Find("Fight").gameObject;
                IXUISprite component4 = t.Find("Unlock").GetComponent("XUISprite") as IXUISprite;
                GameObject gameObject3 = t.Find("New").gameObject;
                GameObject gameObject4 = t.Find("Selected").gameObject;
                GameObject gameObject5 = t.Find("Item").gameObject;
                GameObject gameObject6 = t.Find("RedPoint").gameObject;
                gameObject3.SetActive(false);
                gameObject6.SetActive(false);
                if (index >= pets.Count)
                {
                    component1.SetText("");
                    gameObject5.SetActive(false);
                    gameObject1.SetActive(false);
                    gameObject2.SetActive(false);
                    gameObject4.SetActive(false);
                    if ((long)index >= (long)this.doc.PetSeat)
                    {
                        component4.gameObject.SetActive(true);
                        component4.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnUnlockClicked));
                    }
                    else
                        component4.gameObject.SetActive(false);
                }
                else
                {
                    if (this.doc.HasNewPet && index == pets.Count - 1)
                        gameObject3.SetActive(true);
                    XPet xpet = pets[index];
                    gameObject5.SetActive(true);
                    component1.SetText("Lv." + (object)xpet.showLevel);
                    gameObject4.SetActive(index == this.doc.CurSelectedIndex);
                    gameObject1.SetActive((long)xpet.UID == (long)this.doc.CurMount);
                    gameObject2.SetActive((long)xpet.UID == (long)this.doc.CurFightUID);
                    component4.gameObject.SetActive(false);
                    gameObject6.SetActive((long)xpet.UID == (long)this.doc.CurFightUID && this.doc.HasRedPoint);
                    PetInfoTable.RowData petInfo = XPetDocument.GetPetInfo(xpet.ID);
                    if (petInfo != null)
                        component2.SetSprite(petInfo.icon, petInfo.Atlas);
                    component3.SetSprite(XSingleton<UiUtility>.singleton.GetItemQualityFrame((int)petInfo.quality, 0));
                    component2.ID = (ulong)index;
                    component2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnPetClicked));
                }
            }
        }

        private void _OnUnlockClicked(IXUISprite iSp)
        {
            if ((long)this.doc.PetSeat < (long)this.doc.PetSeatBuy.Length)
                XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("PET_SEAT_BUY"), (object)this.doc.PetSeatBuy[(int)this.doc.PetSeat]), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._BuySeat));
            else
                XSingleton<XDebug>.singleton.AddErrorLog("PetSeat:" + (object)this.doc.PetSeat + "\nPetSeatMAX" + (object)this.doc.PetSeatBuy.Length);
        }

        private bool _BuySeat(IXUIButton btn)
        {
            this.doc.ReqBuySeat();
            XSingleton<UiUtility>.singleton.CloseModalDlg();
            return true;
        }

        private void _OnPetClicked(IXUISprite iSp) => this.doc.Select((int)iSp.ID);

        private bool _OnMountClicked(IXUIButton btn)
        {
            this.doc.ReqMount();
            return true;
        }

        private bool _OnSkillLearnClicked(IXUIButton btn)
        {
            this.SkillLearnHandler.SetVisible(true);
            return true;
        }

        private bool _OnActivationClicked(IXUIButton btn)
        {
            this.doc.ReqFight();
            return true;
        }

        public override void LeaveStackTop()
        {
            base.LeaveStackTop();
            this.Return3DAvatarPool();
        }

        private bool _OnThrowClicked(IXUIButton btn)
        {
            XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("PET_THROW")), (object)this.doc.CurSelectedPet.Name), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._PetThrow));
            return true;
        }

        private bool _OnExpTransferClicked(IXUIButton btn)
        {
            if (this.doc.Pets.Count < 2)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PET_TRANSFER_NOT_ENOUGH_TIP"), "fece00");
                return false;
            }
            if (this.doc.CurSelectedPet == null)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PET_NO_SELECT"), "fece00");
                return false;
            }
            this.ExpTransferHandler.SetVisible(true);
            return true;
        }

        private bool _OnTravelSetClicked(IXUIButton btn)
        {
            if (this.m_setHandler != null)
                this.m_setHandler.SetVisible(true);
            return true;
        }

        private bool _PetThrow(IXUIButton btn)
        {
            this.doc.ReqRelease();
            XSingleton<UiUtility>.singleton.CloseModalDlg();
            return true;
        }

        private void AutoRefresh(object param)
        {
            if (!this.IsVisible() || this.doc.CurSelectedPet == null)
                return;
            if (!this.doc.InPlayExpUp)
                this.doc.ReqPetInfo();
            this._RefreshDataTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(30f, new XTimerMgr.ElapsedEventHandler(this.AutoRefresh), (object)null);
            this.doc.PlayRandAction();
        }

        public void RefreshAutoRefresh()
        {
            XSingleton<XTimerMgr>.singleton.KillTimer(this._RefreshDataTimerID);
            if (!this.IsVisible() || this.doc.CurSelectedPet == null)
                return;
            if (!this.doc.InPlayExpUp)
                this.doc.ReqPetInfo();
            this._RefreshDataTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(10f, new XTimerMgr.ElapsedEventHandler(this.AutoRefresh), (object)null);
        }

        private void RefreshAction(object param)
        {
            if (!DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible())
                return;
            this.uiBehaviour.m_Talk.gameObject.SetActive(false);
            this.doc.PlayIdleAction();
        }

        private void CloseBubble(object param)
        {
            if (!DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible())
                return;
            this.uiBehaviour.m_Talk.gameObject.SetActive(false);
        }

        public void PetActionChange(XPetActionFile Action, uint petID, XDummy m_Dummy, bool init = false)
        {
            if (m_Dummy == null)
                return;
            PetBubble.RowData petBubble = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID).GetPetBubble(Action, petID);
            string seFile = petBubble.SEFile;
            if (!string.IsNullOrEmpty(seFile))
                XSingleton<XAudioMgr>.singleton.PlayUISound(seFile);
            string actionFile = petBubble.ActionFile;
            float length = m_Dummy.SetAnimationGetLength(actionFile);
            XSingleton<XDebug>.singleton.AddLog("Pet Action:" + (object)Action);
            if (Action == XPetActionFile.IDLE)
            {
                this._PetStatus = XPetMainView.PetStatus.IDLE;
                this.PlayActionTime(length);
            }
            if (Action == XPetActionFile.IDLE_PEOPLE)
            {
                this._PetStatus = XPetMainView.PetStatus.IDLE_PEOPLE;
                this.PlayActionTime(length);
            }
            if (Action == XPetActionFile.EAT && this._PetStatus != XPetMainView.PetStatus.EAT)
            {
                this._PetStatus = XPetMainView.PetStatus.EAT;
                this.PlayActionTime(length);
                this.PlayBubble(petBubble);
            }
            if (Action == XPetActionFile.CARESS && this._PetStatus != XPetMainView.PetStatus.CARESS)
            {
                this._PetStatus = XPetMainView.PetStatus.CARESS;
                this.PlayActionTime(length);
                this.PlayBubble(petBubble);
            }
            if ((Action == XPetActionFile.LOSE || Action == XPetActionFile.HAPPY || Action == XPetActionFile.SLEEP || Action == XPetActionFile.HUNGER) && this._PetStatus == XPetMainView.PetStatus.IDLE)
            {
                this._PetStatus = XPetMainView.PetStatus.Rand;
                this.PlayActionTime(length);
                this.PlayBubble(petBubble);
            }
        }

        private void PlayActionTime(float length)
        {
            XSingleton<XTimerMgr>.singleton.KillTimer(this._PlayActionTimerID);
            if ((double)length <= 0.0)
                return;
            this._PlayActionTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(length, new XTimerMgr.ElapsedEventHandler(this.RefreshAction), (object)null);
        }

        private void PlayBubble(PetBubble.RowData petBubbleData)
        {
            string strText = this.doc.RandomPlayBubble(petBubbleData.Bubble);
            if (string.IsNullOrEmpty(strText))
                return;
            this.uiBehaviour.m_Talk.gameObject.SetActive(true);
            this.uiBehaviour.m_TalkLabel.SetText(strText);
            XSingleton<XTimerMgr>.singleton.KillTimer(this._PlayBubbleTimerID);
            this._PlayBubbleTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(petBubbleData.BubbleTime, new XTimerMgr.ElapsedEventHandler(this.CloseBubble), (object)null);
        }

        private enum PetStatus
        {
            IDLE,
            IDLE_PEOPLE,
            Rand,
            EAT,
            CARESS,
        }
    }
}
