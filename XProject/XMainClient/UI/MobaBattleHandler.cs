

using KKSG;
using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class MobaBattleHandler : DlgHandlerBase
    {
        private XMobaBattleDocument _doc = (XMobaBattleDocument)null;
        private IXUISprite m_SkillTips;
        private IXUILabel m_SkillName;
        private IXUILabel m_SkillAttr;
        private IXUILabel m_SkillMP;
        private IXUILabel m_SkillCD;
        private IXUILabel m_SkillDesc;
        private IXUILabel m_BlueKill;
        private IXUILabel m_RedKill;
        private IXUILabel m_BlueLevel;
        private IXUILabel m_RedLevel;
        private IXUILabel m_MyKill;
        private IXUILabel m_MyDead;
        private IXUILabel m_MyAssist;
        private GameObject m_AdditionFrame;
        private IXUISprite[] m_AdditionBtn = new IXUISprite[3];
        private IXUISprite m_DetailBtn;
        private GameObject m_DetailFrame;
        private IXUIButton m_DetailCloseBtn;
        private XUIPool m_RedPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
        private XUIPool m_BluePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
        private List<IXUILabel> _labelList = new List<IXUILabel>();
        private List<ulong> _uidList = new List<ulong>();
        private float _refreshSignTime;
        private IXUILabel m_ReviveLeftTime;
        private bool _OnDeath;
        private uint _additionCloseDelayToken;
        private XFx _addFx;
        private XFx _boardFx;
        private XFx _moveFx;
        private int _curExpInd = 0;
        private static readonly int EXPMAXCOUT = 8;
        private XUIPool m_ExpPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
        private MobaBattleHandler.MobaExp[] m_ExpList = new MobaBattleHandler.MobaExp[MobaBattleHandler.EXPMAXCOUT];
        private IXUISprite m_AttrShowBtn;
        public MapSignalHandler m_MapSignalHandler;
        private MobaHeadCondition m_headCondition;

        protected override string FileName => "Battle/MobaBattleHandler";

        protected override void Init()
        {
            base.Init();
            this._doc = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
            this.m_SkillTips = this.transform.FindChild("SkillTips").GetComponent("XUISprite") as IXUISprite;
            this.m_SkillName = this.m_SkillTips.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
            this.m_SkillAttr = this.m_SkillTips.transform.FindChild("Attr").GetComponent("XUILabel") as IXUILabel;
            this.m_SkillMP = this.m_SkillTips.transform.FindChild("MP").GetComponent("XUILabel") as IXUILabel;
            this.m_SkillCD = this.m_SkillTips.transform.FindChild("CD").GetComponent("XUILabel") as IXUILabel;
            this.m_SkillDesc = this.m_SkillTips.transform.FindChild("Desc").GetComponent("XUILabel") as IXUILabel;
            this.m_SkillTips.SetVisible(false);
            this.m_BlueKill = this.transform.FindChild("ScoreBoard/BlueKill").GetComponent("XUILabel") as IXUILabel;
            this.m_RedKill = this.transform.FindChild("ScoreBoard/RedKill").GetComponent("XUILabel") as IXUILabel;
            this.m_BlueLevel = this.transform.FindChild("ScoreBoard/BlueLevel/Num").GetComponent("XUILabel") as IXUILabel;
            this.m_RedLevel = this.transform.FindChild("ScoreBoard/RedLevel/Num").GetComponent("XUILabel") as IXUILabel;
            this.m_MyKill = this.transform.FindChild("ScoreBoard/MyScore/Kill").GetComponent("XUILabel") as IXUILabel;
            this.m_MyDead = this.transform.FindChild("ScoreBoard/MyScore/Dead").GetComponent("XUILabel") as IXUILabel;
            this.m_MyAssist = this.transform.FindChild("ScoreBoard/MyScore/Assist").GetComponent("XUILabel") as IXUILabel;
            this.m_AdditionFrame = this.transform.FindChild("Addition").gameObject;
            for (int index = 0; index < 3; ++index)
            {
                this.m_AdditionBtn[index] = this.m_AdditionFrame.transform.FindChild("ADD" + index.ToString()).GetComponent("XUISprite") as IXUISprite;
                this.m_AdditionBtn[index].ID = (ulong)index;
            }
            this.m_DetailBtn = this.transform.FindChild("ScoreBoard/DetailBtn").GetComponent("XUISprite") as IXUISprite;
            this.m_DetailFrame = this.transform.FindChild("DetailFrame").gameObject;
            this.m_DetailCloseBtn = this.m_DetailFrame.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton;
            Transform child1 = this.m_DetailFrame.transform.FindChild("BlueTeam/BlueTpl");
            this.m_BluePool.SetupPool(child1.parent.gameObject, child1.gameObject, 4U, false);
            Transform child2 = this.m_DetailFrame.transform.FindChild("RedTeam/RedTpl");
            this.m_RedPool.SetupPool(child2.parent.gameObject, child2.gameObject, 4U, false);
            this.m_DetailFrame.SetActive(false);
            this.m_ReviveLeftTime = this.transform.FindChild("ReviveLeftTime").GetComponent("XUILabel") as IXUILabel;
            this.m_ReviveLeftTime.SetVisible(false);
            this._OnDeath = false;
            this._curExpInd = 0;
            Transform child3 = this.transform.FindChild("ExpMgr/Tpl");
            this.m_ExpPool.SetupPool(child3.parent.gameObject, child3.gameObject, (uint)MobaBattleHandler.EXPMAXCOUT, false);
            for (int index = 0; index < MobaBattleHandler.EXPMAXCOUT; ++index)
            {
                GameObject go = this.m_ExpPool.FetchGameObject();
                this.m_ExpList[index] = new MobaBattleHandler.MobaExp(go);
            }
            this.m_AttrShowBtn = this.transform.FindChild("AttrShowBtn").GetComponent("XUISprite") as IXUISprite;
            DlgHandlerBase.EnsureCreate<MobaHeadCondition>(ref this.m_headCondition, this.transform.Find("condition").gameObject, (IDlgHandlerMgr)this);
            DlgHandlerBase.EnsureCreate<MapSignalHandler>(ref this.m_MapSignalHandler, this.transform.FindChild("MapSignalHandler").gameObject, (IDlgHandlerMgr)this);
        }

        public override void RegisterEvent()
        {
            base.RegisterEvent();
            for (int index = 0; index < 3; ++index)
                this.m_AdditionBtn[index].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAdditionBtnClick));
            this.m_DetailBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnShowDetailBtnClick));
            this.m_DetailCloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseDetailBtnClick));
            this.m_SkillTips.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSkillTipsCloseClick));
            this.m_AttrShowBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAttrShowBtnClick));
        }

        public override void OnUnload()
        {
            if (this._addFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._addFx);
            if (this._boardFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._boardFx);
            if (this._moveFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._moveFx);
            XSingleton<XTimerMgr>.singleton.KillTimer(this._additionCloseDelayToken);
            DlgHandlerBase.EnsureUnload<MobaHeadCondition>(ref this.m_headCondition);
            DlgHandlerBase.EnsureUnload<MapSignalHandler>(ref this.m_MapSignalHandler);
            base.OnUnload();
        }

        protected override void OnShow() => base.OnShow();

        public void RefreshMyScore()
        {
            if (this._doc.MyData == null)
                return;
            this.m_MyKill.SetText(this._doc.MyData.kill.ToString());
            this.m_MyDead.SetText(this._doc.MyData.dead.ToString());
            this.m_MyAssist.SetText(this._doc.MyData.assist.ToString());
        }

        public void RefreshBattleMsg()
        {
            this.m_BlueKill.SetText(this._doc.MyTeamkill.ToString());
            this.m_BlueLevel.SetText(this._doc.MyTeamLevel.ToString());
            this.m_RedKill.SetText(this._doc.OtherTeamKill.ToString());
            this.m_RedLevel.SetText(this._doc.OtherTeamLevel.ToString());
        }

        public void OnAdditionBtnClick(IXUISprite iSp) => this._doc.QueryAdditionLevelUp((int)iSp.ID);

        public void OnShowDetailBtnClick(IXUISprite iSp)
        {
            this.m_DetailFrame.SetActive(true);
            this.SetupDetailMsg();
        }

        public bool OnCloseDetailBtnClick(IXUIButton btn)
        {
            this.m_DetailFrame.SetActive(false);
            return true;
        }

        public void SetGetExpAnimation(uint exp, uint posxz)
        {
            Vector3 pos = new Vector3((float)(posxz >> 16) / 100f, 0.0f, (float)(posxz & (uint)ushort.MaxValue) / 100f);
            int curExpInd = this._curExpInd;
            this._curExpInd = (this._curExpInd + 1) % MobaBattleHandler.EXPMAXCOUT;
            this.m_ExpList[this._curExpInd].SetExp(pos, (int)exp);
        }

        public void SetupDetailMsg()
        {
            if (!this.m_DetailFrame.activeInHierarchy)
                return;
            this.m_BluePool.FakeReturnAll();
            this.m_RedPool.FakeReturnAll();
            this._labelList.Clear();
            this._uidList.Clear();
            int num1 = 0;
            int num2 = 0;
            if (this._doc.MyData == null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("show detail msg error. mydata is null.");
            }
            else
            {
                MobaMemberData data = this._doc.MyData;
                int index = num1;
                int num3 = index + 1;
                this.SetupSingleDetail(data, true, index);
                int i = 0;
                for (int count = this._doc.MobaData.BufferValues.Count; i < count; ++i)
                {
                    if ((long)this._doc.MobaData.BufferValues[i].uid != (long)this._doc.MyData.uid)
                    {
                        if ((int)this._doc.MobaData.BufferValues[i].teamID == (int)this._doc.MyData.teamID)
                            this.SetupSingleDetail(this._doc.MobaData.BufferValues[i], true, num3++);
                        else
                            this.SetupSingleDetail(this._doc.MobaData.BufferValues[i], false, num2++);
                    }
                }
                this.m_BluePool.ActualReturnAll();
                this.m_RedPool.ActualReturnAll();
            }
        }

        public void SetupSingleDetail(MobaMemberData data, bool isBlue, int index)
        {
            GameObject gameObject1 = isBlue ? this.m_BluePool.FetchGameObject() : this.m_RedPool.FetchGameObject();
            OverWatchTable.RowData dataByHeroId = XHeroBattleDocument.GetDataByHeroID(data.heroID);
            gameObject1.transform.localPosition = new Vector3(this.m_BluePool.TplPos.x, this.m_BluePool.TplPos.y - (float)(this.m_BluePool.TplHeight * index));
            this._uidList.Add(data.uid);
            this._labelList.Add(gameObject1.transform.FindChild("TIME").GetComponent("XUILabel") as IXUILabel);
            IXUISprite component = gameObject1.transform.FindChild("HeroIcon").GetComponent("XUISprite") as IXUISprite;
            GameObject gameObject2 = gameObject1.transform.FindChild("UnSelect").gameObject;
            if (dataByHeroId == null)
            {
                component.SetVisible(false);
                gameObject2.SetActive(true);
            }
            else
            {
                component.SetVisible(true);
                gameObject2.SetActive(false);
                component.SetSprite(dataByHeroId.Icon, dataByHeroId.IconAtlas);
            }
          (gameObject1.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel).SetText(data.name);
            (gameObject1.transform.FindChild("HeroName").GetComponent("XUILabel") as IXUILabel).SetText(dataByHeroId == null ? "" : dataByHeroId.Name);
            (gameObject1.transform.FindChild("AttackLevel").GetComponent("XUILabel") as IXUILabel).SetText(string.Format(XStringDefineProxy.GetString("LEVEL"), (object)data.attackLevel));
            (gameObject1.transform.FindChild("DefenseLevel").GetComponent("XUILabel") as IXUILabel).SetText(string.Format(XStringDefineProxy.GetString("LEVEL"), (object)data.defenseLevel));
            (gameObject1.transform.FindChild("Kill").GetComponent("XUILabel") as IXUILabel).SetText(data.kill.ToString());
            (gameObject1.transform.FindChild("Dead").GetComponent("XUILabel") as IXUILabel).SetText(data.dead.ToString());
            (gameObject1.transform.FindChild("Assist").GetComponent("XUILabel") as IXUILabel).SetText(data.assist.ToString());
            gameObject1.transform.FindChild("Me").gameObject.SetActive(data.isMy);
        }

        public void SetAdditionFrameState(bool state)
        {
            if (state == this.m_AdditionFrame.activeSelf)
                return;
            if (state)
            {
                this.m_AdditionFrame.SetActive(state);
            }
            else
            {
                XSingleton<XTimerMgr>.singleton.KillTimer(this._additionCloseDelayToken);
                this._additionCloseDelayToken = XSingleton<XTimerMgr>.singleton.SetTimer(0.15f, new XTimerMgr.ElapsedEventHandler(this.DelayCloseAdditionFrame), (object)null);
            }
        }

        public void DelayCloseAdditionFrame(object o = null) => this.m_AdditionFrame.SetActive(false);

        public void ShowAdditionFx(int index)
        {
            if (this._addFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._addFx);
            if (this._boardFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._boardFx);
            if (this._moveFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._moveFx);
            Transform child = this.transform.FindChild(string.Format("AddFx{0}", (object)index));
            Transform transform = this.m_BlueLevel.gameObject.transform;
            this._addFx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_yxxg_xishou", child);
            this._boardFx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_yxxg_fangkai", transform);
            this._moveFx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_yxxg_guocheng", child);
            this._addFx.Play();
            this._boardFx.Play();
            Vector3 to = transform.position - child.position;
            float z = Vector3.Angle(Vector3.right, to);
            if ((double)to.y < 0.0)
                z = -z;
            this._moveFx.Play(child.transform.position, Quaternion.Euler(0.0f, 0.0f, z), Vector3.one);
        }

        public void OnSkillTipsCloseClick(IXUISprite iSp) => this.m_SkillTips.SetVisible(false);

        public void ShowSkillTips(bool state, uint skillID, int skillLevel)
        {
            if (XSingleton<XEntityMgr>.singleton.Player == null)
                return;
            this.m_SkillTips.SetVisible(state);
            if (!state)
                return;
            SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skillID, (uint)skillLevel, XSingleton<XEntityMgr>.singleton.Player.SkillCasterTypeID);
            if (skillConfig == null)
            {
                XSingleton<XDebug>.singleton.AddLog("moba skill tips can't find skillconfig, skillID = ", skillID.ToString());
                this.m_SkillTips.SetVisible(false);
            }
            else
            {
                this.m_SkillName.SetText(skillConfig.ScriptName);
                this.m_SkillAttr.SetText(XSkillTreeDocument.GetSkillAttrStr((int)skillConfig.Element));
                this.m_SkillMP.SetText((skillConfig.CostMP[0] + skillConfig.CostMP[1] * (float)skillLevel).ToString());
                this.m_SkillCD.SetText(XSingleton<XEntityMgr>.singleton.Player == null || !XEntity.ValideEntity(XSingleton<XEntityMgr>.singleton.Player.Transformer) ? "0s" : string.Format("{0}s", (object)Math.Round((double)XSkillMgr.GetCD(XSingleton<XEntityMgr>.singleton.Player.Transformer, skillConfig.SkillScript, (uint)skillLevel) + 0.01, 1)));
                this.m_SkillDesc.SetText(skillConfig.CurrentLevelDescription);
            }
        }

        public void SetOnDeath()
        {
            this._OnDeath = true;
            this.m_ReviveLeftTime.SetVisible(true);
        }

        public void OnAttrShowBtnClick(IXUISprite isp)
        {
            DlgBase<DemoUI, DemoUIBehaviour>.singleton.SetVisible(!DlgBase<DemoUI, DemoUIBehaviour>.singleton.IsVisible(), true);
            if (this._doc.MyData == null)
                return;
            DlgBase<HeroAttrDlg, HeroAttrBehaviour>.singleton.ShowByType(SceneType.SCENE_MOBA, this._doc.MyData.heroID);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if ((UnityEngine.Object)Camera.main != (UnityEngine.Object)null)
            {
                for (int index = 0; index < MobaBattleHandler.EXPMAXCOUT; ++index)
                {
                    if (this.m_ExpList[index].state && (double)Time.realtimeSinceStartup > (double)this.m_ExpList[index].vaildTime)
                    {
                        this.m_ExpList[index].state = false;
                        this.m_ExpList[index].m_Go.SetActive(false);
                    }
                }
            }
            if ((double)Time.realtimeSinceStartup - (double)this._refreshSignTime < 1.0)
                return;
            if (this.m_DetailFrame.activeInHierarchy)
            {
                this._refreshSignTime = Time.realtimeSinceStartup;
                for (int index = 0; index < this._uidList.Count; ++index)
                {
                    MobaMemberData mobaMemberData;
                    if (!this._doc.MobaData.TryGetValue(this._uidList[index], out mobaMemberData))
                        XSingleton<XDebug>.singleton.AddErrorLog("can't update label because not find data by uid = ", this._uidList[index].ToString());
                    else if ((double)mobaMemberData.reviveTime <= 0.0)
                    {
                        this._labelList[index].SetVisible(false);
                    }
                    else
                    {
                        this._labelList[index].SetVisible(true);
                        this._labelList[index].SetText(mobaMemberData.reviveTime.ToString());
                    }
                }
            }
            if (!this._OnDeath || this._doc.MyData == null)
                return;
            this._refreshSignTime = Time.realtimeSinceStartup;
            if ((double)this._doc.MyData.reviveTime <= 0.0)
            {
                this._OnDeath = false;
                this.m_ReviveLeftTime.SetVisible(false);
            }
            else
                this.m_ReviveLeftTime.SetText(this._doc.MyData.reviveTime.ToString());
        }

        private class MobaExp
        {
            public GameObject m_Go;
            public IXUILabel m_Label;
            public IXUITweenTool m_PlayTween;
            public IUI3DFollow m_3DFollow;
            public bool state = false;
            public float vaildTime;

            public MobaExp(GameObject go)
            {
                this.m_Go = go;
                this.m_3DFollow = go.GetComponent("UI3DFollow") as IUI3DFollow;
                this.m_Label = go.transform.GetChild(0).GetComponent("XUILabel") as IXUILabel;
                this.m_PlayTween = this.m_Label.gameObject.GetComponent("XUIPlayTween") as IXUITweenTool;
                go.SetActive(false);
            }

            public void SetExp(Vector3 pos, int exp)
            {
                this.m_Go.SetActive(true);
                this.state = true;
                this.m_3DFollow.SetPos(pos);
                this.m_Label.SetText(string.Format("jy+{0}", (object)exp));
                this.m_PlayTween.PlayTween(true);
                this.vaildTime = Time.realtimeSinceStartup + 1f;
            }
        }
    }
}
