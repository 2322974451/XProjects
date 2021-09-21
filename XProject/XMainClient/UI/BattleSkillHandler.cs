// Decompiled with JetBrains decompiler
// Type: XMainClient.UI.BattleSkillHandler
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class BattleSkillHandler : DlgHandlerBase
    {
        private BattleSkillHandler.XSkillButton[] m_buttons = (BattleSkillHandler.XSkillButton[])null;
        private XBattleSkillDocument _doc = (XBattleSkillDocument)null;
        private XSkillTreeDocument _skill_doc = (XSkillTreeDocument)null;
        public float LastAttackTime = 0.0f;
        private bool bNormalAttackPressed = false;
        private XTimerMgr.ElapsedEventHandler _DestroyShowSkillFx = (XTimerMgr.ElapsedEventHandler)null;
        private IXGameSirControl m_sirControl;
        private List<string[]> mSkillSets;
        private int mSkillSize = 0;
        private XFx _addFx;
        private XFx _skillFx;
        private XFx _moveFx;
        private int _showSkillNum;
        private uint _fxDelayToken;
        private uint _fxDelayDelToken;
        private XUIPool m_LevelPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
        private float _pressTime;
        private List<string>[] skillSet = new List<string>[10];

        public bool IsAwakeSlotSettingOn
        {
            get
            {
                XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
                return specificDocument == null || (uint)specificDocument.GetValue(XOptionsDefine.OD_Awake_Slot) > 0U;
            }
        }

        public BattleSkillHandler() => this._DestroyShowSkillFx = new XTimerMgr.ElapsedEventHandler(this.DestroyShowSkillFx);

        protected override void Init()
        {
            base.Init();
            this._showSkillNum = 0;
            Transform child = this.PanelObject.transform.FindChild("LevelTpl");
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_CRAZYBOMB)
                this.m_LevelPool.SetupPool(child.parent.gameObject, child.gameObject, 16U, false);
            else
                child.gameObject.SetActive(false);
            this.m_buttons = new BattleSkillHandler.XSkillButton[(int)XBattleSkillDocument.Total_skill_slot];
            for (int idx = 0; (long)idx < (long)XBattleSkillDocument.Total_skill_slot; ++idx)
                this.m_buttons[idx] = new BattleSkillHandler.XSkillButton(this.PanelObject, idx);
            this.m_sirControl = XSingleton<XUpdater.XUpdater>.singleton.GameSirControl;
            this._doc = XDocuments.GetSpecificDocument<XBattleSkillDocument>(XBattleSkillDocument.uuID);
            this._doc.BattleView = this;
            this._doc.Init();
            this._skill_doc = XDocuments.GetSpecificDocument<XSkillTreeDocument>(XSkillTreeDocument.uuID);
            this.mSkillSets = new List<string[]>();
            string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("GameSirKeyCodes", XGlobalConfig.ListSeparator);
            if (andSeparateValue == null || andSeparateValue.Length == 0)
            {
                this.mSkillSize = 0;
            }
            else
            {
                this.mSkillSize = andSeparateValue.Length;
                for (int index = 0; index < this.mSkillSize; ++index)
                    this.mSkillSets.Add(andSeparateValue[index].Split(XGlobalConfig.SequenceSeparator));
            }
        }

        public override void RegisterEvent()
        {
            base.RegisterEvent();
            for (int index = 0; (long)index < (long)XBattleSkillDocument.Total_skill_slot; ++index)
            {
                this.m_buttons[index].m_skill.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnSkillCast));
                if (this.m_buttons[index].m_add != null)
                {
                    this.m_buttons[index].m_add.ID = (ulong)index;
                    this.m_buttons[index].m_add.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddClick));
                    this.m_buttons[index].m_add.RegisterSpritePressEventHandler(new SpritePressEventHandler(this.OnAddPress));
                }
                if (this.m_buttons[index].m_lock != null)
                {
                    this.m_buttons[index].m_lock.ID = (ulong)index;
                    this.m_buttons[index].m_lock.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnLockClick));
                }
            }
            this.m_buttons[0].m_skill.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnAttackPressed));
        }

        public override void OnUnload()
        {
            if (this._addFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._addFx);
            if (this._skillFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._skillFx);
            if (this._moveFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._moveFx);
            this._doc.BattleView = (BattleSkillHandler)null;
            XSingleton<XTimerMgr>.singleton.KillTimer(this._fxDelayToken);
            XSingleton<XTimerMgr>.singleton.KillTimer(this._fxDelayDelToken);
            base.OnUnload();
        }

        protected override void OnShow()
        {
            base.OnShow();
            this.bNormalAttackPressed = false;
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE)
                return;
            this.ResetSkill();
        }

        public void SetButtonNum(int num)
        {
            if (this._showSkillNum == num)
                return;
            this._showSkillNum = num;
            int index1 = 0;
            if ((uint)num > 0U)
                index1 = 5 - num;
            for (int index2 = 2; index2 <= 5 && index2 < this.m_buttons.Length; ++index2)
                (this.m_buttons[index2].m_skill.gameObject.GetComponent("PositionGroup") as IXPositionGroup).SetGroup(index1);
        }

        public void SetupSkillMobaLevel()
        {
            if (XSingleton<XEntityMgr>.singleton.Player == null || XSingleton<XEntityMgr>.singleton.Player.Transformer == null)
                return;
            this.m_LevelPool.ReturnAll(true);
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA)
            {
                for (int index1 = 2; index1 <= 5; ++index1)
                {
                    if (index1 < XSingleton<XEntityMgr>.singleton.Player.SkillSlot.Length && index1 < this.m_buttons.Length)
                    {
                        int skillMaxLevel = XSingleton<XSkillEffectMgr>.singleton.GetSkillMaxLevel(XSingleton<XEntityMgr>.singleton.Player.SkillSlot[index1], XSingleton<XEntityMgr>.singleton.Player.SkillCasterTypeID);
                        if (skillMaxLevel > 1)
                        {
                            Transform child = this.m_buttons[index1].m_skillLevel.gameObject.transform.FindChild("p");
                            for (int index2 = 0; index2 < skillMaxLevel; ++index2)
                            {
                                float f = (float)((double)index2 * 2.0 * 3.14159274101257) / (float)skillMaxLevel;
                                GameObject gameObject = this.m_LevelPool.FetchGameObject();
                                gameObject.transform.parent = child;
                                gameObject.transform.localScale = Vector3.one;
                                gameObject.transform.localPosition = new Vector3(Mathf.Sin(f) * 40f, Mathf.Cos(f) * 40f);
                                gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, (float)(-(double)f * 57.2957801818848));
                            }
                            this.m_buttons[index1].m_skillMaxLevel = skillMaxLevel;
                        }
                    }
                }
            }
            else
            {
                int skillMaxLevel = XSingleton<XSkillEffectMgr>.singleton.GetSkillMaxLevel(XSingleton<XEntityMgr>.singleton.Player.SkillSlot[0], XSingleton<XEntityMgr>.singleton.Player.SkillCasterTypeID);
                Transform child = this.m_buttons[0].m_skillLevel.gameObject.transform.FindChild("p");
                for (int index = 0; index < skillMaxLevel; ++index)
                {
                    float f = (float)((double)index * 2.0 * 3.14159274101257) / (float)skillMaxLevel;
                    GameObject gameObject = this.m_LevelPool.FetchGameObject();
                    gameObject.transform.parent = child;
                    gameObject.transform.localScale = Vector3.one;
                    gameObject.transform.localPosition = new Vector3(Mathf.Sin(f) * 64f, Mathf.Cos(f) * 64f);
                    gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, (float)(-(double)f * 57.2957801818848));
                }
                this.m_buttons[0].m_skillMaxLevel = skillMaxLevel;
                this.SetMobaSkillLevel(0, false);
            }
        }

        private void _SetAttackGlow(bool bActive)
        {
        }

        public void ResetPressState()
        {
            this.bNormalAttackPressed = false;
            this.m_buttons[0].m_skill.ResetState();
            this._SetAttackGlow(false);
        }

        public void BindSkill(int idx, uint skill, bool rebind = false)
        {
            if ((long)idx >= (long)XBattleSkillDocument.Total_skill_slot || !rebind && (int)skill == (int)this.m_buttons[idx].m_skillId)
            {
                if (skill != 0U || this.m_buttons[idx].m_lock == null)
                    return;
                uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
                uint skillSlotUnLockLevel = this._skill_doc.GetSkillSlotUnLockLevel(idx);
                this.m_buttons[idx].SetButton(this._ShouldShowButton(skill, idx));
                if (level < skillSlotUnLockLevel)
                    this.m_buttons[idx].m_lock.gameObject.SetActive(true);
                else
                    this.m_buttons[idx].m_lock.gameObject.SetActive(false);
            }
            else
            {
                if (!this.m_buttons[idx].Active)
                    return;
                if (skill > 0U)
                {
                    uint skillLevel = XSingleton<XEntityMgr>.singleton.Player.Skill.IsSkillReplaced ? 1U : XSingleton<XEntityMgr>.singleton.Player.Attributes.SkillLevelInfo.GetSkillLevel(skill);
                    SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skill, skillLevel, XSingleton<XEntityMgr>.singleton.Player.SkillCasterTypeID);
                    if (skillConfig != null)
                    {
                        this.m_buttons[idx].m_skillCost = XSingleton<XEntityMgr>.singleton.Player.SkillMgr.GetMPCost(skill);
                        this.m_buttons[idx].m_skillId = skill;
                        this.m_buttons[idx].m_skillIcon.SetSprite(skillConfig.Icon, skillConfig.Atlas);
                        if (this.m_buttons[idx].m_lock == null)
                            return;
                        this.m_buttons[idx].m_lock.gameObject.SetActive(false);
                    }
                    else
                    {
                        this.m_buttons[idx].m_skillId = 0U;
                        this.m_buttons[idx].m_skillIcon.spriteName = "";
                        this.m_buttons[idx].SetButtonStatus(false);
                    }
                }
                else
                {
                    this.m_buttons[idx].m_skillId = 0U;
                    this.m_buttons[idx].m_skillIcon.spriteName = "";
                    this.m_buttons[idx].SetButtonStatus(false);
                }
            }
        }

        public void OnSetOptionsValue()
        {
            SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
            int awakeSkillSlot = XSkillTreeDocument.AwakeSkillSlot;
            if (awakeSkillSlot >= this.m_buttons.Length || awakeSkillSlot >= XSingleton<XEntityMgr>.singleton.Player.SkillSlot.Length)
                return;
            this.m_buttons[awakeSkillSlot].SetButton(sceneData.ShowSkill && this._ShouldShowButton(XSingleton<XEntityMgr>.singleton.Player.SkillSlot[awakeSkillSlot], awakeSkillSlot));
        }

        private bool IsAwakeSkillSlotNeedOpen() => this._skill_doc.IsAwakeSkillSlotOpen && this._skill_doc.IsSelfAwaked && this.IsAwakeSlotSettingOn;

        private bool _ShouldShowButton(uint skillID, int idx)
        {
            if (idx == XSkillTreeDocument.AwakeSkillSlot && !this.IsAwakeSkillSlotNeedOpen())
                return false;
            if (skillID > 0U)
                return true;
            return !XSingleton<XEntityMgr>.singleton.Player.IsTransform && !XSingleton<XEntityMgr>.singleton.Player.Skill.IsSkillReplaced && (this._skill_doc.GetSkillSlotType(idx) != SkillTypeEnum.Skill_Buff || this._skill_doc.GetSkillSlotUnLockLevel(XFastEnumIntEqualityComparer<XSkillSlot>.ToInt(XSkillSlot.Skill_1_Buff)) <= XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
        }

        public void ResetSkill(bool showfx = false, bool rebind = false)
        {
            for (int idx = 0; (long)idx < (long)XBattleSkillDocument.Total_skill_slot; ++idx)
            {
                this.ResetSkill(idx, rebind);
                if (showfx && this.m_buttons[idx].m_skillId > 0U)
                    this.PlayShowSkillFx(idx);
                this.m_buttons[idx].SetButton(this._ShouldShowButton(this.m_buttons[idx].m_skillId, idx));
            }
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_CRAZYBOMB)
            {
                DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.SetupSkillMobaLevel();
                for (int slot = 0; (long)slot < (long)XBattleSkillDocument.Total_skill_slot; ++slot)
                {
                    uint num;
                    if (XBattleSkillDocument.SkillLevelDict.TryGetValue(this.m_buttons[slot].m_skillId, out num))
                    {
                        XBattleSkillDocument.SkillLevel[slot] = (int)num;
                        DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.SetMobaSkillLevel(slot, false);
                    }
                }
                if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA)
                    DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.RefreshAddBtn();
            }
            SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
            if (!sceneData.ShowSkill)
            {
                for (int index = 1; (long)index < (long)XBattleSkillDocument.Total_skill_slot; ++index)
                    this.m_buttons[index].SetButton(false);
            }
            if (sceneData.ShowNormalAttack)
                return;
            this.m_buttons[0].SetButton(false);
        }

        public void ResetSkill(int idx, bool rebind = false)
        {
            if (idx < XSingleton<XEntityMgr>.singleton.Player.SkillSlot.Length)
            {
                this.BindSkill(idx, XSingleton<XEntityMgr>.singleton.Player.SkillSlot[idx], rebind);
                this.m_buttons[idx].SetButtonHighlight(false);
                this.m_buttons[idx].SetButtonInRange(false);
            }
            else
                XSingleton<XDebug>.singleton.AddErrorLog("skill slot ", idx.ToString(), "missing...");
        }

        public void CoolDownSkillAll()
        {
            for (int idx = 0; (long)idx < (long)XBattleSkillDocument.Total_skill_slot; ++idx)
            {
                if (this.m_buttons[idx].m_skillId > 0U)
                {
                    XSingleton<XEntityMgr>.singleton.Player.SkillMgr.GetSkill(this.m_buttons[idx].m_skillId)?.CoolDown();
                    this.PlayShowSkillFx(idx);
                }
            }
        }

        public void MakeCoolDownAtLaunch()
        {
            for (int index = 0; (long)index < (long)XBattleSkillDocument.Total_skill_slot; ++index)
            {
                if (this.m_buttons[index].m_skillId > 0U)
                    XSingleton<XEntityMgr>.singleton.Player.SkillMgr.GetSkill(this.m_buttons[index].m_skillId)?.MakeCoolDownAtLaunch();
            }
        }

        public void DisableSkill(int idx)
        {
            this.BindSkill(idx, 0U);
            this.m_buttons[idx].Active = false;
            this.m_buttons[idx].SetButton(false);
        }

        public void ShowSkillSlot(int index)
        {
        }

        public void EnableSkill(int idx)
        {
            this.m_buttons[idx].Active = true;
            this.m_buttons[idx].SetButton(true);
            if (idx < XSingleton<XEntityMgr>.singleton.Player.SkillSlot.Length)
            {
                this.BindSkill(idx, XSingleton<XEntityMgr>.singleton.Player.SkillSlot[idx]);
                this.PlayShowSkillFx(idx);
            }
            else
                XSingleton<XDebug>.singleton.AddErrorLog("skill slot ", idx.ToString(), "missing...");
        }

        public void AlwaysHot(int idx, bool isHot)
        {
            this.m_buttons[idx].AlwaysHot = isHot;
            this.m_buttons[idx].SetButtonStatus(true);
        }

        public void OnDeath()
        {
            this.bNormalAttackPressed = false;
            this.m_buttons[0].m_skill.ResetState();
            this._SetAttackGlow(false);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (this.bNormalAttackPressed)
                this.CastNormalAttack();
            if (!DlgBase<DemoUI, DemoUIBehaviour>.singleton.IsMainUIVisible())
                this.UpdateKeyBoard();
            this.UpdateGameSirControl();
            this.UpdateSkillInfo();
        }

        protected void DestroyShowSkillFx(object o) => XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroy((Object)(o as GameObject));

        public void OnAttackPressed(bool state) => this.OnAttackPressed((IXUIButton)null, state);

        private void OnAttackPressed(IXUIButton go, bool state)
        {
            this.bNormalAttackPressed = state;
            if (!state)
                return;
            this._doc.OnSlotClicked(0);
        }

        private void CastNormalAttack() => this.ImpCast(0);

        private void OnSkillCast(IXUIButton go, bool state)
        {
            if (!state)
                return;
            this._doc.OnSlotClicked((int)go.ID);
            this.ImpCast((int)go.ID);
        }

        private void OnLockClick(IXUISprite sp)
        {
            uint skillSlotUnLockLevel = this._skill_doc.GetSkillSlotUnLockLevel((int)sp.ID);
            int num = (int)XSingleton<UiUtility>.singleton.ShowSystemNoticeTip(string.Format(XStringDefineProxy.GetString("OpenSkillAtLevel"), (object)skillSlotUnLockLevel));
        }

        public void OnAddClick(IXUISprite sp)
        {
            if ((double)this._pressTime > 1.0 || (int)sp.ID >= this.m_buttons.Length)
                return;
            XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
            if (!this.IsSkillCanLevelUp((int)sp.ID))
                return;
            specificDocument.QuerySkillLevelUp(this.m_buttons[(int)sp.ID].m_skillId);
        }

        public void SetMobaSkillLevel(int slot, bool isLevelUp)
        {
            if (isLevelUp && this.m_buttons[slot].m_add != null)
            {
                if (this._addFx != null)
                    XSingleton<XFxMgr>.singleton.DestroyFx(this._addFx);
                if (this._skillFx != null)
                    XSingleton<XFxMgr>.singleton.DestroyFx(this._skillFx);
                if (this._moveFx != null)
                    XSingleton<XFxMgr>.singleton.DestroyFx(this._moveFx);
                Transform transform = this.m_buttons[slot].m_skillIcon.transform;
                Transform child = this.m_buttons[slot].m_add.transform.parent.FindChild("Fx");
                this._addFx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_yxxg_jiahao", child);
                this._skillFx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_yxxg_jinenglan", transform);
                this._moveFx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_yxxg_feixing", child);
                this._addFx.Play();
                this._skillFx.Play();
                Vector3 to = transform.position - child.position;
                float z = Vector3.Angle(Vector3.right, to);
                if ((double)to.y < 0.0)
                    z = -z;
                this._moveFx.Play(child.transform.position, Quaternion.Euler(0.0f, 0.0f, z), Vector3.one);
            }
            this.m_buttons[slot].SetSkillLevel(XBattleSkillDocument.SkillLevel[slot]);
        }

        public void DelayRefreshAddBtn()
        {
            XSingleton<XTimerMgr>.singleton.KillTimer(this._fxDelayToken);
            this._fxDelayToken = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.RefreshAddBtn), (object)null);
            XSingleton<XTimerMgr>.singleton.KillTimer(this._fxDelayDelToken);
            this._fxDelayDelToken = XSingleton<XTimerMgr>.singleton.SetTimer(2f, new XTimerMgr.ElapsedEventHandler(this.DelayRefreshFx), (object)null);
        }

        public void DelayRefreshFx(object o = null)
        {
            if (this._addFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._addFx);
            if (this._skillFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._skillFx);
            if (this._moveFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._moveFx);
            this._addFx = (XFx)null;
            this._skillFx = (XFx)null;
            this._moveFx = (XFx)null;
        }

        public void RefreshAddBtn(object o = null)
        {
            if (XBattleSkillDocument.Total_skill_slot <= 5U || XSingleton<XEntityMgr>.singleton.Player == null || !XEntity.ValideEntity(XSingleton<XEntityMgr>.singleton.Player.Transformer))
                return;
            int skillPoint = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID).SkillPoint;
            for (int index = 2; index <= 5; ++index)
                this.m_buttons[index].m_add.SetVisible(this.IsSkillCanLevelUp(index));
        }

        public bool IsSkillCanLevelUp(int index)
        {
            if (XBattleSkillDocument.Total_skill_slot <= 5U || XSingleton<XEntityMgr>.singleton.Player == null)
                return false;
            XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
            if (specificDocument.SkillPoint == 0)
                return false;
            int skillMaxLevel = XSingleton<XSkillEffectMgr>.singleton.GetSkillMaxLevel(this.m_buttons[index].m_skillId, XSingleton<XEntityMgr>.singleton.Player.SkillCasterTypeID);
            if (XBattleSkillDocument.SkillLevel[index] >= skillMaxLevel)
                return false;
            SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(this.m_buttons[index].m_skillId, (uint)(XBattleSkillDocument.SkillLevel[index] + 1), XSingleton<XEntityMgr>.singleton.Player.SkillCasterTypeID);
            return skillConfig != null && XBattleSkillDocument.SkillLevel[index] < skillConfig.UpReqRoleLevel.Length && (int)skillConfig.UpReqRoleLevel[XBattleSkillDocument.SkillLevel[index]] <= specificDocument.MyLevel();
        }

        public bool OnAddPress(IXUISprite sp, bool state)
        {
            if ((int)sp.ID >= this.m_buttons.Length)
                return false;
            this._pressTime = !state ? Time.time - this._pressTime : Time.time;
            if (DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler != null)
                DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler.ShowSkillTips(state, this.m_buttons[(int)sp.ID].m_skillId, XBattleSkillDocument.SkillLevel[(int)sp.ID] + 1);
            return true;
        }

        private void ImpCast(int idx)
        {
            if (this.m_buttons[idx].m_skillId == 0U || !this.m_buttons[idx].Enabled || !this.m_buttons[idx].Visible)
                return;
            uint skill = this._doc.NextJASkillBaseOnCurrent();
            if ((int)skill == (int)this.m_buttons[idx].m_skillId)
            {
                if (this._doc.IsInQTEChain(skill))
                    this._doc.CastSkill(this.m_buttons[idx]);
                else if (XSingleton<XGame>.singleton.SyncMode)
                    this._doc.FireSkillEvent(idx);
                else
                    this.LastAttackTime = Time.time;
            }
            else
                this._doc.CastSkill(this.m_buttons[idx]);
        }

        protected void UpdateSkillInfo()
        {
            if (XSingleton<XEntityMgr>.singleton.Player == null)
                return;
            int attr = (int)XSingleton<XEntityMgr>.singleton.Player.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentMP_Basic);
            for (int slot = 0; (long)slot < (long)XBattleSkillDocument.Total_skill_slot; ++slot)
            {
                XSkillCore xskillCore = this._doc.HasReplaced(this.m_buttons[slot].m_skillId);
                if (xskillCore != null)
                {
                    if (xskillCore.ShowRunningTime)
                    {
                        if (this.m_buttons[slot].m_Times != null)
                        {
                            bool flag = (uint)xskillCore.LeftRunningTime > 0U;
                            if (this.m_buttons[slot].m_TimesVis != flag)
                            {
                                this.m_buttons[slot].m_TimesVis = flag;
                                this.m_buttons[slot].m_Times.gameObject.transform.localPosition = flag ? new Vector3(24f, -30f) : XGameUI.Far_Far_Away;
                            }
                            this.m_buttons[slot].m_Times.SetText(xskillCore.LeftRunningTime.ToString());
                        }
                    }
                    else if (this.m_buttons[slot].m_Times != null && this.m_buttons[slot].m_TimesVis)
                    {
                        this.m_buttons[slot].m_TimesVis = false;
                        this.m_buttons[slot].m_Times.gameObject.transform.localPosition = XGameUI.Far_Far_Away;
                    }
                    if (xskillCore.Reloading)
                    {
                        float coolDown = xskillCore.GetCoolDown();
                        float elapsedCd = xskillCore.GetElapsedCD();
                        float num1 = (double)coolDown > 0.0 ? (float)(1.0 - (double)elapsedCd / (double)coolDown) : 0.0f;
                        bool flag = slot > 0 || !XSingleton<XEntityMgr>.singleton.Player.SkillMgr.IsPhysicalAttack(xskillCore.ID);
                        this.m_buttons[slot].m_skillCD.value = flag ? num1 : 0.0f;
                        if (xskillCore.CooledDown)
                        {
                            this.m_buttons[slot].SetCDText(false);
                        }
                        else
                        {
                            this.m_buttons[slot].SetCDText(true);
                            float num2 = coolDown - elapsedCd;
                            if ((double)num2 >= 1.0)
                            {
                                int i = (int)((double)coolDown - (double)elapsedCd + 0.5);
                                if (this.m_buttons[slot].m_skillCDText.HasIdentityChanged(i))
                                {
                                    string strText = flag ? i.ToString() : "";
                                    this.m_buttons[slot].m_skillCDText.SetText(strText);
                                    this.m_buttons[slot].m_skillCDText.SetIdentity(i);
                                }
                            }
                            else
                            {
                                int i = (int)((double)num2 * 10.0);
                                if (this.m_buttons[slot].m_skillCDText.HasIdentityChanged(i))
                                {
                                    string strText = flag ? num2.ToString("F1") : "";
                                    this.m_buttons[slot].m_skillCDText.SetText(strText);
                                    this.m_buttons[slot].m_skillCDText.SetIdentity(i);
                                }
                            }
                        }
                    }
                    else
                    {
                        this.m_buttons[slot].SetCDText(false);
                        this.m_buttons[slot].m_skillCD.value = 0.0f;
                    }
                    if (this._doc.CanCast(xskillCore.ID, slot))
                    {
                        this.m_buttons[slot].SetButtonStatus(true);
                        this.m_buttons[slot].SetNoMP((double)attr < (double)this.m_buttons[slot].m_skillCost);
                        if (slot > 1)
                            this.m_buttons[slot].SetButtonInRange(xskillCore.CooledDown && this._doc.CanFind(xskillCore.ID));
                    }
                    else if (this.m_buttons[slot].AlwaysHot)
                    {
                        this.m_buttons[slot].SetButtonStatus(true);
                    }
                    else
                    {
                        if (slot > 1)
                            this.m_buttons[slot].SetButtonInRange(false);
                        this.m_buttons[slot].SetButtonStatus(false);
                    }
                }
                else
                {
                    this.m_buttons[slot].m_skillCD.value = 0.0f;
                    this.m_buttons[slot].SetCDText(false);
                    this.m_buttons[slot].SetButtonStatus(false);
                }
            }
        }

        public void UpdateQTESkill(int idx, uint skill)
        {
            if (skill <= 0U)
                return;
            this.BindSkill(idx, skill);
            if (!XSingleton<XEntityMgr>.singleton.Player.QTE.IsInIgnorePresentState())
                this.m_buttons[idx].SetButtonHighlight(true);
        }

        private void PlayShowSkillFx(int idx)
        {
            this.m_buttons[idx].SetButtonStatus(true);
            GameObject fromPrefab = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/ShowSkillFx") as GameObject;
            Transform transform = this.m_buttons[idx].m_skill.gameObject.transform.Find("icon");
            if ((Object)transform == (Object)null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Skill Icon No Find");
            }
            else
            {
                XSingleton<UiUtility>.singleton.AddChild(transform.gameObject, fromPrefab);
                (fromPrefab.GetComponent("XUISprite") as IXUISprite).ResetAnimationAndPlay();
                int num = (int)XSingleton<XTimerMgr>.singleton.SetTimer(5f, this._DestroyShowSkillFx, (object)fromPrefab);
            }
        }

        private bool ExcuteSkill(int index, string[] skillNames)
        {
            if (skillNames == null || skillNames.Length == 0)
                return false;
            bool flag = true;
            int index1 = 0;
            for (int length = skillNames.Length; index1 < length; ++index1)
            {
                flag = flag && this.m_sirControl.GetButton(skillNames[index1]);
                if (!flag)
                    break;
            }
            if (flag)
            {
                if (index == 0)
                    this.CastNormalAttack();
                else
                    this.ImpCast(index);
            }
            return flag;
        }

        private void UpdateGameSirControl()
        {
            if (!this.IsVisible() || this.m_sirControl == null || !this.m_sirControl.IsConnected() || this.mSkillSets == null || this.mSkillSize == 0)
                return;
            for (int index = 0; index < this.mSkillSize; ++index)
                this.ExcuteSkill(index, this.mSkillSets[index]);
        }

        public void UpdateKeyBoard()
        {
            if (!this.IsVisible())
                return;
            if (Input.GetKeyDown(KeyCode.H))
                this.CastNormalAttack();
            if (Input.GetKeyDown(KeyCode.Space))
                this.ImpCast(1);
            if (Input.GetKeyDown(KeyCode.J))
                this.ImpCast(2);
            if (Input.GetKeyDown(KeyCode.K))
                this.ImpCast(3);
            if (Input.GetKeyDown(KeyCode.L))
                this.ImpCast(4);
            if (Input.GetKeyDown(KeyCode.Semicolon))
                this.ImpCast(5);
            if (Input.GetKeyDown(KeyCode.U))
                this.ImpCast(6);
            if (Input.GetKeyDown(KeyCode.O))
                this.ImpCast(7);
            if (Input.GetKeyDown(KeyCode.P))
                this.ImpCast(8);
            if (!Input.GetKeyDown(KeyCode.I))
                return;
            this.ImpCast(9);
        }

        public struct XSkillButton
        {
            public bool Active;
            public bool AlwaysHot;
            public IXUIButton m_skill;
            public IXUISprite m_skillIcon;
            public IXUIProgress m_skillCD;
            public IXUITweenTool m_skillCDOver;
            public GameObject m_skillNoMp;
            public IXUILabel m_skillCDText;
            public float m_skillCost;
            public uint m_skillId;
            public GameObject m_skillHighlight;
            public IXUISprite m_lock;
            public IXUISprite m_add;
            public IXUISprite m_skillLevel;
            public int m_skillMaxLevel;
            public bool m_TimesVis;
            public IXUILabel m_Times;
            private bool m_enabled;
            private bool m_visible;
            private Vector3 m_OriginPos;
            private Vector3 m_CDOverOriginPos;

            public bool Visible => this.m_visible;

            public bool Enabled => this.m_enabled;

            public XSkillButton(GameObject panelObject, int idx)
            {
                this.AlwaysHot = false;
                this.Active = true;
                this.m_visible = true;
                this.m_TimesVis = false;
                Transform child1 = panelObject.transform.FindChild("Skill" + (object)idx + "/Bg");
                this.m_OriginPos = child1.transform.localPosition;
                this.m_skill = child1.GetComponent("XUIButton") as IXUIButton;
                this.m_skill.ID = (ulong)idx;
                if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA && idx >= 2 && idx <= 5)
                {
                    Transform child2 = child1.transform.parent.FindChild("Addsp");
                    child2.gameObject.SetActive(true);
                    this.m_add = child2.GetComponent("XUISprite") as IXUISprite;
                    child2.gameObject.SetActive(false);
                    Transform child3 = child1.transform.FindChild("level");
                    child3.gameObject.SetActive(true);
                    this.m_skillLevel = child3.GetComponent("XUISprite") as IXUISprite;
                    this.m_skillLevel.SetFillAmount(0.0f);
                }
                else if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_CRAZYBOMB & idx == 0)
                {
                    this.m_add = (IXUISprite)null;
                    Transform child4 = child1.transform.FindChild("level");
                    child4.gameObject.SetActive(true);
                    this.m_skillLevel = child4.GetComponent("XUISprite") as IXUISprite;
                    this.m_skillLevel.SetFillAmount(0.0f);
                    child1.transform.FindChild("icon/p").gameObject.SetActive(false);
                }
                else if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_SURVIVE && idx == 0)
                {
                    this.m_add = (IXUISprite)null;
                    this.m_skillLevel = (IXUISprite)null;
                    Transform child5 = child1.transform.FindChild("icon");
                    Transform child6 = child1.transform.FindChild("ChickenDinnerIcon");
                    child6.gameObject.SetActive(true);
                    child6.localPosition = XGameUI.Far_Far_Away;
                    IXUISprite component1 = child5.GetComponent("XUISprite") as IXUISprite;
                    IXUISprite component2 = child6.GetComponent("XUISprite") as IXUISprite;
                    component1.spriteWidth = component2.spriteWidth;
                    component1.spriteHeight = component2.spriteHeight;
                    child5.rotation = child6.rotation;
                }
                else
                {
                    this.m_add = (IXUISprite)null;
                    this.m_skillLevel = (IXUISprite)null;
                }
                this.m_skillMaxLevel = 0;
                if (idx >= 2 && idx <= 6 || idx == XSkillTreeDocument.AwakeSkillSlot)
                {
                    this.m_Times = child1.transform.FindChild("icon/Times").GetComponent("XUILabel") as IXUILabel;
                    this.m_Times.gameObject.transform.localPosition = XGameUI.Far_Far_Away;
                }
                else
                    this.m_Times = (IXUILabel)null;
                this.m_skillIcon = child1.transform.FindChild("icon").GetComponent("XUISprite") as IXUISprite;
                this.m_skillCD = this.m_skillIcon.gameObject.GetComponent("XUIProgress") as IXUIProgress;
                this.m_skillCDOver = this.m_skillIcon.transform.FindChild("cdover").GetComponent("XUIPlayTween") as IXUITweenTool;
                this.m_CDOverOriginPos = this.m_skillCDOver.gameObject.transform.localPosition;
                this.m_skillCDOver.gameObject.transform.localPosition = XGameUI.Far_Far_Away;
                this.m_skillCDText = this.m_skillIcon.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
                this.m_skillNoMp = this.m_skillIcon.transform.FindChild("nomp").gameObject;
                this.m_skillHighlight = child1.transform.FindChild("highlight").gameObject;
                this.m_skillHighlight.transform.localPosition = XGameUI.Far_Far_Away;
                this.m_lock = (IXUISprite)null;
                Transform child7 = child1.transform.FindChild("lock");
                if ((Object)child7 != (Object)null)
                {
                    this.m_lock = child7.GetComponent("XUISprite") as IXUISprite;
                    this.m_lock.gameObject.SetActive(false);
                }
                this.m_skillCost = 0.0f;
                this.m_skillId = 0U;
                this.m_enabled = true;
            }

            public void SetButtonStatus(bool enable)
            {
                if (this.m_enabled != enable)
                {
                    if (enable)
                    {
                        this.m_skill.SetEnable(true);
                    }
                    else
                    {
                        this.m_skillNoMp.transform.localPosition = XGameUI.Far_Far_Away;
                        this.m_skill.SetEnable(false, this.m_skill.ID == 0UL);
                    }
                }
                this.m_enabled = enable;
            }

            public void SetButtonHighlight(bool enable) => this.m_skillHighlight.transform.localPosition = enable ? Vector3.zero : XGameUI.Far_Far_Away;

            public void SetButtonInRange(bool enable)
            {
            }

            public void SetButton(bool active)
            {
                this.m_visible = active;
                this.m_skill.SetVisible(active);
            }

            public void SetCDText(bool active) => this.m_skillCDText.gameObject.transform.localPosition = active ? Vector3.zero : XGameUI.Far_Far_Away;

            public void SetCDOver(bool active)
            {
            }

            public void SetNoMP(bool active) => this.m_skillNoMp.gameObject.transform.localPosition = active ? Vector3.zero : XGameUI.Far_Far_Away;

            private void _OnCDOverFinished(IXUITweenTool tween) => this.SetCDOver(false);

            public void SetSkillLevel(int level)
            {
                if (this.m_skillLevel == null)
                    return;
                this.m_skillLevel.SetFillAmount((float)level * 1f / (float)this.m_skillMaxLevel);
            }
        }
    }
}
