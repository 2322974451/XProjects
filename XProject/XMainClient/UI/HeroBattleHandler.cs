

using KKSG;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class HeroBattleHandler : DlgHandlerBase
    {
        private XHeroBattleDocument _doc = (XHeroBattleDocument)null;
        private XHeroBattleSkillDocument _skillDoc = (XHeroBattleSkillDocument)null;
        private List<HeroBattleTeam> m_Team = new List<HeroBattleTeam>();
        private GameObject m_Death;
        private IXUILabel m_ReviveLeftTime;
        private Transform m_ProgressTs;
        private IXUILabel m_ProgressTips;
        private Transform m_ProgressTipsTs;
        private IXUIProgress m_Progress;
        private Transform m_AddTimeTs;
        private IXUIProgress m_AddTimeProgress;
        private IXUIButton m_ChangeHeroBtn;
        private IXUILabel m_KillText;
        private IXUILabel m_DeadText;
        private IXUILabel m_AssitText;
        private Transform m_AncientParent;
        private IXUILabel m_AncientPercent;
        private IXUIProgress m_AncientSlider;
        private IXUISprite[] m_AncientSkill = new IXUISprite[3];
        private bool _isAncientFull;
        private IXUISprite m_AttrShowBtn;
        private IXUISprite m_AncientTipsBtn;
        private IXUISprite m_AncientTipsCloseBtn;
        private IXUILabel m_AncientTips;
        private uint m_AncientTipsCloseToken;
        private Color blueColor;
        private Color redColor;
        private XFx _Fx;
        private XFx _OccupantFx;
        private XFx _EndFx;
        private uint _MiniMapFxToken;
        private uint _CurrentOccupant;
        private bool _InCircleMyself;
        private bool _IsInFight;
        private uint _ProgressTeam;
        private bool _InAddTime;
        private float _AddTimePerTurn;
        private float _SignTime;
        private bool _OnDeath;
        private float _ReviveTime;
        private float _ReviveSignTime;
        private float _LootProgress;
        private bool _HaveEnd;
        private XFx[] _skillFx = new XFx[3];
        private XFx _barFx;
        public MapSignalHandler m_MapSignalHandler;

        protected override string FileName => "Battle/HeroBattleHandler";

        protected override void Init()
        {
            base.Init();
            this._doc = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
            this._skillDoc = XDocuments.GetSpecificDocument<XHeroBattleSkillDocument>(XHeroBattleSkillDocument.uuID);
            this._doc._HeroBattleHandler = this;
            this.m_Death = this.transform.Find("Death").gameObject;
            this.m_Death.transform.localPosition = XGameUI.Far_Far_Away;
            this.m_ReviveLeftTime = this.m_Death.transform.Find("LeftTime").GetComponent("XUILabel") as IXUILabel;
            this.m_ChangeHeroBtn = this.m_Death.gameObject.transform.Find("ChangeHeroBtn").GetComponent("XUIButton") as IXUIButton;
            this.m_ProgressTs = this.transform.Find("Progress");
            this.m_ProgressTipsTs = this.transform.Find("TextTs");
            this.m_ProgressTs.localPosition = XGameUI.Far_Far_Away;
            this.m_ProgressTipsTs.localPosition = XGameUI.Far_Far_Away;
            this.m_Progress = this.m_ProgressTs.Find("ProgressBar").GetComponent("XUIProgress") as IXUIProgress;
            this.m_AddTimeTs = this.transform.Find("AddTime");
            this.m_AddTimeTs.localPosition = XGameUI.Far_Far_Away;
            this.m_AddTimeProgress = this.m_AddTimeTs.Find("AddtimeBar").GetComponent("XUIProgress") as IXUIProgress;
            this.m_ProgressTips = this.transform.Find("TextTs/Text").GetComponent("XUILabel") as IXUILabel;
            this.m_ProgressTips.SetText(XStringDefineProxy.GetString("HeroBattleLoot"));
            this.transform.Find("Score").gameObject.SetActive(!XSingleton<XScene>.singleton.bSpectator);
            this.m_KillText = this.transform.Find("Score/kill").GetComponent("XUILabel") as IXUILabel;
            this.m_DeadText = this.transform.Find("Score/dead").GetComponent("XUILabel") as IXUILabel;
            this.m_AssitText = this.transform.Find("Score/help").GetComponent("XUILabel") as IXUILabel;
            this.m_AttrShowBtn = this.transform.Find("AttrShowBtn").GetComponent("XUISprite") as IXUISprite;
            this.m_AncientParent = this.transform.Find("AncientBarParent");
            this.m_AncientPercent = this.transform.Find("AncientBarParent/AncientSkillBar/Num").GetComponent("XUILabel") as IXUILabel;
            this.m_AncientSlider = this.transform.Find("AncientBarParent/AncientSkillBar").GetComponent("XUIProgress") as IXUIProgress;
            for (int index = 0; index < 3; ++index)
            {
                this.m_AncientSkill[index] = this.transform.Find(string.Format("AncientSkill/Skill{0}", (object)index)).GetComponent("XUISprite") as IXUISprite;
                this.m_AncientSkill[index].ID = (ulong)index + 1UL;
                this.m_AncientSkill[index].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAncientSkillClick));
                this.m_AncientSkill[index].SetVisible(false);
            }
            this._isAncientFull = false;
            this.SetAncientPercent(0.0f);
            this.m_AncientTipsBtn = this.transform.Find("AncientBarParent/AncientSkillBar/Foreground").GetComponent("XUISprite") as IXUISprite;
            this.m_AncientTips = this.transform.Find("AncientTips/Desc").GetComponent("XUILabel") as IXUILabel;
            this.m_AncientTipsCloseBtn = this.transform.Find("AncientTips/Close").GetComponent("XUISprite") as IXUISprite;
            this.m_AncientTips.gameObject.transform.parent.gameObject.SetActive(false);
            this.m_Team.Clear();
            HeroBattleTeam heroBattleTeam1 = new HeroBattleTeam(this.transform.Find("Scoreboard/BlueTeam"));
            HeroBattleTeam heroBattleTeam2 = new HeroBattleTeam(this.transform.Find("Scoreboard/RedTeam"));
            this.m_Team.Add(heroBattleTeam1);
            this.m_Team.Add(heroBattleTeam2);
            List<int> intList1 = XSingleton<XGlobalConfig>.singleton.GetIntList("HeroBattleBlueColor");
            this.blueColor = new Color((float)intList1[0] / (float)byte.MaxValue, (float)intList1[1] / (float)byte.MaxValue, (float)intList1[2] / (float)byte.MaxValue);
            List<int> intList2 = XSingleton<XGlobalConfig>.singleton.GetIntList("HeroBattleRedColor");
            this.redColor = new Color((float)intList2[0] / (float)byte.MaxValue, (float)intList2[1] / (float)byte.MaxValue, (float)intList2[2] / (float)byte.MaxValue);
            this._AddTimePerTurn = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HeroBattleOverTime"));
            this._ReviveTime = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HeroBattleReviveTime"));
            this._CurrentOccupant = 0U;
            this._InCircleMyself = false;
            this._IsInFight = false;
            this._ProgressTeam = 0U;
            this._LootProgress = 0.0f;
            this._MiniMapFxToken = 0U;
            this._InAddTime = false;
            this._OnDeath = false;
            this._HaveEnd = false;
            this.SetFx(0U);
            if (XSingleton<XScene>.singleton.bSpectator)
            {
                this.m_AncientSlider.SetVisible(false);
                this.transform.FindChild("MapSignalHandler").gameObject.SetActive(false);
                this.m_AttrShowBtn.SetVisible(false);
            }
            else
                DlgHandlerBase.EnsureCreate<MapSignalHandler>(ref this.m_MapSignalHandler, this.transform.FindChild("MapSignalHandler").gameObject, (IDlgHandlerMgr)this);
        }

        public override void RegisterEvent()
        {
            base.RegisterEvent();
            this.m_ChangeHeroBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnChangeHeroBtnClick));
            this.m_AttrShowBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAttrShowBtnClick));
            this.m_AncientTipsBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAncientTipsBtnClick));
            this.m_AncientTipsCloseBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAncientCloseBtnClick));
        }

        public void OnAttrShowBtnClick(IXUISprite isp)
        {
            if (XSingleton<XAttributeMgr>.singleton.XPlayerData == null)
                return;
            uint heroID = 0;
            this._doc.heroIDIndex.TryGetValue(XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, out heroID);
            if (heroID <= 0U)
                return;
            DlgBase<HeroAttrDlg, HeroAttrBehaviour>.singleton.ShowByType(SceneType.SCENE_HEROBATTLE, heroID);
        }

        public override void OnUnload()
        {
            this._doc._HeroBattleHandler = (HeroBattleHandler)null;
            XSingleton<XTimerMgr>.singleton.KillTimer(this.m_AncientTipsCloseToken);
            if (this._Fx != null)
            {
                XSingleton<XFxMgr>.singleton.DestroyFx(this._Fx);
                this._Fx = (XFx)null;
            }
            if (this._OccupantFx != null)
            {
                XSingleton<XFxMgr>.singleton.DestroyFx(this._OccupantFx);
                this._OccupantFx = (XFx)null;
            }
            if (this._EndFx != null)
            {
                XSingleton<XFxMgr>.singleton.DestroyFx(this._EndFx);
                this._EndFx = (XFx)null;
            }
            if (this._barFx != null)
            {
                XSingleton<XFxMgr>.singleton.DestroyFx(this._barFx);
                this._barFx = (XFx)null;
            }
            for (int index = 0; index < this._skillFx.Length; ++index)
            {
                if (this._skillFx[index] != null)
                {
                    XSingleton<XFxMgr>.singleton.DestroyFx(this._skillFx[index]);
                    this._skillFx[index] = (XFx)null;
                }
            }
            if (XSingleton<XScene>.singleton.bSpectator)
                XSpectateSceneDocument.DelMiniMapFx(this._MiniMapFxToken);
            else
                XBattleDocument.DelMiniMapFx(this._MiniMapFxToken);
            if (this.m_MapSignalHandler != null)
                DlgHandlerBase.EnsureUnload<MapSignalHandler>(ref this.m_MapSignalHandler);
            base.OnUnload();
        }

        protected override void OnShow() => base.OnShow();

        public void SetTeamData(HeroBattleTeamMsg data)
        {
            int index = (int)this._doc.MyTeam == (int)data.teamdata[0].teamid ? 0 : 1;
            this.m_Team[0].Score = data.teamdata[index].point;
            this.m_Team[1].Score = data.teamdata[1 - index].point;
            if (this._HaveEnd || data.teamdata[0].point != 100U && data.teamdata[1].point != 100U)
                return;
            this._HaveEnd = true;
            if (data.teamdata[0].point == 100U)
                this.SetResultFx((int)data.teamdata[0].teamid == (int)this._doc.MyTeam);
            else
                this.SetResultFx((int)data.teamdata[1].teamid == (int)this._doc.MyTeam);
        }

        public void SetResultFx(bool isWinMySelf)
        {
            HeroBattleMapCenter.RowData bySceneId = this._doc.HeroBattleMapReader.GetBySceneID(XSingleton<XScene>.singleton.SceneID);
            if (bySceneId == null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Can't find hero battle map data by sceneID = ", XSingleton<XScene>.singleton.SceneID.ToString());
            }
            else
            {
                Vector3 position = new Vector3(bySceneId.Center[0], bySceneId.Center[1], bySceneId.Center[2]);
                if (this._EndFx != null)
                    XSingleton<XFxMgr>.singleton.DestroyFx(this._EndFx);
                this._EndFx = !isWinMySelf ? XSingleton<XFxMgr>.singleton.CreateFx(bySceneId.OccWinFx[1]) : XSingleton<XFxMgr>.singleton.CreateFx(bySceneId.OccWinFx[0]);
                this._EndFx.Play(position, Quaternion.identity, Vector3.one);
            }
        }

        public void SetProgressData(HeroBattleSyncData data)
        {
            if (this._IsInFight != data.isInFight)
            {
                this.m_ProgressTips.SetText(XStringDefineProxy.GetString(data.isInFight ? "HeroBattleInFight" : "HeroBattleLoot"));
                this._IsInFight = data.isInFight;
            }
            if ((int)this._CurrentOccupant != (int)data.occupant)
            {
                int index = (int)this._doc.MyTeam == (int)data.occupant ? 0 : 1;
                this.m_Team[index].SetOccupantState(true);
                this.m_Team[1 - index].SetOccupantState(false);
                this._CurrentOccupant = data.occupant;
                this.SetFx(this._CurrentOccupant);
            }
            int index1 = (int)this._doc.MyTeam == (int)data.lootTeam ? 0 : 1;
            if ((int)this._ProgressTeam != (int)data.lootTeam)
            {
                if (data.lootTeam > 0U)
                {
                    this.m_Progress.SetForegroundColor(index1 == 0 ? this.blueColor : this.redColor);
                    this.m_Team[(int)this._ProgressTeam == (int)this._doc.MyTeam ? 0 : 1].SetOccupyValue(0.0f);
                }
                else
                {
                    this.m_Team[(int)this._ProgressTeam == (int)this._doc.MyTeam ? 0 : 1].SetOccupyValue(0.0f);
                    this.m_ProgressTs.localPosition = XGameUI.Far_Far_Away;
                    this.m_ProgressTipsTs.localPosition = XGameUI.Far_Far_Away;
                }
                this._ProgressTeam = data.lootTeam;
            }
            if (this._ProgressTeam > 0U)
            {
                this.m_Team[index1].SetOccupyValue(data.lootProgress / 100f);
                this.m_Progress.value = data.lootProgress / 100f;
                this._LootProgress = data.lootProgress;
            }
            this.m_ProgressTs.localPosition = !this._InCircleMyself || this._ProgressTeam == 0U || (double)this._LootProgress <= 0.5 ? XGameUI.Far_Far_Away : Vector3.zero;
            this.m_ProgressTipsTs.localPosition = this._IsInFight || this._InCircleMyself && this._ProgressTeam != 0U ? Vector3.zero : XGameUI.Far_Far_Away;
        }

        public void SetInCircleData(HeroBattleInCircle data)
        {
            bool flag = false;
            if (XSingleton<XScene>.singleton.bSpectator)
            {
                flag = true;
            }
            else
            {
                for (int index = 0; index < data.roleInCircle.Count; ++index)
                {
                    if ((long)data.roleInCircle[index] == (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID)
                        flag = true;
                }
            }
            if (this._InCircleMyself != flag)
            {
                this._InCircleMyself = flag;
                this.m_ProgressTs.localPosition = !this._InCircleMyself || this._ProgressTeam == 0U || (double)this._LootProgress <= 0.5 ? XGameUI.Far_Far_Away : Vector3.zero;
            }
            this.m_ProgressTipsTs.localPosition = this._IsInFight || this._InCircleMyself && this._ProgressTeam != 0U ? Vector3.zero : XGameUI.Far_Far_Away;
        }

        public void StartAddTime(int time)
        {
            this._InAddTime = (uint)time > 0U;
            this._AddTimePerTurn = (float)time / 1000f;
            this.m_AddTimeTs.localPosition = this._InAddTime ? Vector3.zero : XGameUI.Far_Far_Away;
            this._SignTime = Time.realtimeSinceStartup;
        }

        public void RefreshScoreBoard(uint kill, uint dead, uint assit)
        {
            this.m_KillText.SetText(kill.ToString());
            this.m_DeadText.SetText(dead.ToString());
            this.m_AssitText.SetText(assit.ToString());
        }

        public void SetFx(uint occupant)
        {
            HeroBattleMapCenter.RowData bySceneId = this._doc.HeroBattleMapReader.GetBySceneID(XSingleton<XScene>.singleton.SceneID);
            if (bySceneId == null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Can't find hero battle map data by sceneID = ", XSingleton<XScene>.singleton.SceneID.ToString());
            }
            else
            {
                Vector3 vector3 = new Vector3(bySceneId.Center[0], bySceneId.Center[1], bySceneId.Center[2]);
                Vector3 scale = new Vector3(bySceneId.Param[0] * bySceneId.ClientFxScalse, 1f, (bySceneId.CenterType == 1U ? bySceneId.Param[0] : bySceneId.Param[1]) * bySceneId.ClientFxScalse);
                if (this._Fx != null)
                {
                    XSingleton<XFxMgr>.singleton.DestroyFx(this._Fx);
                    this._Fx = (XFx)null;
                }
                if (XSingleton<XScene>.singleton.bSpectator)
                    XSpectateSceneDocument.DelMiniMapFx(this._MiniMapFxToken);
                else
                    XBattleDocument.DelMiniMapFx(this._MiniMapFxToken);
                if (occupant == 0U)
                {
                    this._Fx = XSingleton<XFxMgr>.singleton.CreateFx(bySceneId.OccupantFx[0]);
                    this._MiniMapFxToken = !XSingleton<XScene>.singleton.bSpectator ? XBattleDocument.AddMiniMapFx(vector3, bySceneId.MiniMapFx[0]) : XSpectateSceneDocument.AddMiniMapFx(vector3, bySceneId.MiniMapFx[0]);
                }
                else if ((int)occupant == (int)this._doc.MyTeam)
                {
                    this._Fx = XSingleton<XFxMgr>.singleton.CreateFx(bySceneId.OccupantFx[1]);
                    this._MiniMapFxToken = !XSingleton<XScene>.singleton.bSpectator ? XBattleDocument.AddMiniMapFx(vector3, bySceneId.MiniMapFx[1]) : XSpectateSceneDocument.AddMiniMapFx(vector3, bySceneId.MiniMapFx[1]);
                }
                else
                {
                    this._Fx = XSingleton<XFxMgr>.singleton.CreateFx(bySceneId.OccupantFx[2]);
                    this._MiniMapFxToken = !XSingleton<XScene>.singleton.bSpectator ? XBattleDocument.AddMiniMapFx(vector3, bySceneId.MiniMapFx[2]) : XSpectateSceneDocument.AddMiniMapFx(vector3, bySceneId.MiniMapFx[2]);
                }
                this._Fx.Play(vector3, Quaternion.identity, scale);
                if (occupant <= 0U)
                    return;
                if (this._OccupantFx != null)
                    XSingleton<XFxMgr>.singleton.DestroyFx(this._OccupantFx);
                this._OccupantFx = (int)occupant != (int)this._doc.MyTeam ? XSingleton<XFxMgr>.singleton.CreateFx(bySceneId.OccSuccessFx[1]) : XSingleton<XFxMgr>.singleton.CreateFx(bySceneId.OccSuccessFx[0]);
                this._OccupantFx.Play(vector3, Quaternion.identity, scale);
            }
        }

        private bool OnChangeHeroBtnClick(IXUIButton btn)
        {
            if (this._skillDoc.m_HeroBattleSkillHandler != null)
            {
                this._skillDoc.m_HeroBattleSkillHandler.SetVisible(true);
                this._skillDoc.m_HeroBattleSkillHandler.RefreshTab();
            }
            return true;
        }

        public void SetDeathGoState(bool state) => this.m_Death.gameObject.transform.localPosition = state ? Vector3.zero : XGameUI.Far_Far_Away;

        public void SetReviveLeftTime()
        {
            this._OnDeath = true;
            this._ReviveSignTime = Time.realtimeSinceStartup;
        }

        public override void OnUpdate()
        {
            if (this._InAddTime)
            {
                float num = Time.realtimeSinceStartup - this._SignTime;
                this.m_AddTimeProgress.value = (float)(1.0 - (double)num / (double)this._AddTimePerTurn);
                if ((double)num > (double)this._AddTimePerTurn)
                {
                    this._InAddTime = false;
                    this.m_AddTimeTs.localPosition = XGameUI.Far_Far_Away;
                }
            }
            if (!this._OnDeath)
                return;
            float num1 = Time.realtimeSinceStartup - this._ReviveSignTime;
            this.m_ReviveLeftTime.SetText(((int)((double)this._ReviveTime - (double)num1)).ToString());
            if ((double)this._ReviveTime - (double)num1 < 0.0)
                this._OnDeath = false;
        }

        private void PlayShowSkillFx()
        {
            if (this._barFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._barFx);
            this._barFx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_yxxg_jindutiao", this.m_AncientParent);
            for (int index = 0; index < 3; ++index)
            {
                if (this._skillFx[index] != null)
                    XSingleton<XFxMgr>.singleton.DestroyFx(this._skillFx[index]);
                switch (index)
                {
                    case 0:
                        this._skillFx[index] = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_yxxg_tubiao_hong", this.m_AncientSkill[index].transform);
                        break;
                    case 1:
                        this._skillFx[index] = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_yxxg_tubiao_lan", this.m_AncientSkill[index].transform);
                        break;
                    case 2:
                        this._skillFx[index] = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_yxxg_tubiao_lu", this.m_AncientSkill[index].transform);
                        break;
                }
            }
        }

        protected void DestroyShowSkillFx(object o) => XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroy((Object)(o as GameObject));

        private void OnAncientSkillClick(IXUISprite iSp) => this._doc.QueryUseAncientSkill((int)iSp.ID);

        public void SetAncientPercent(float percent)
        {
            if ((double)percent > 99.9899978637695)
                percent = 100f;
            bool bVisible = (double)percent == 100.0;
            if (bVisible != this._isAncientFull)
            {
                for (int index = 0; index < 3; ++index)
                    this.m_AncientSkill[index].SetVisible(bVisible);
                this.m_AncientSlider.SetVisible(!bVisible);
                if (bVisible)
                    this.PlayShowSkillFx();
                this._isAncientFull = bVisible;
                if (bVisible)
                    this.OnAncientCloseBtnClick((IXUISprite)null);
            }
            this.m_AncientSlider.value = percent / 100f;
            this.m_AncientPercent.SetText(string.Format("{0}%", (object)(int)((double)percent + 0.490000009536743)));
        }

        public void OnAncientTipsBtnClick(IXUISprite iSp)
        {
            this.m_AncientTips.gameObject.transform.parent.gameObject.SetActive(true);
            this.m_AncientTips.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("HeroBattleAncientTips")));
            this.m_AncientTipsCloseToken = XSingleton<XTimerMgr>.singleton.SetTimer(5f, new XTimerMgr.ElapsedEventHandler(this.AutoClose), (object)null);
        }

        public void AutoClose(object o = null) => this.OnAncientCloseBtnClick((IXUISprite)null);

        public void OnAncientCloseBtnClick(IXUISprite iSp)
        {
            this.m_AncientTips.gameObject.transform.parent.gameObject.SetActive(false);
            XSingleton<XTimerMgr>.singleton.KillTimer(this.m_AncientTipsCloseToken);
        }
    }
}
