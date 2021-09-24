

using KKSG;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class DungeonSelect : DlgBase<DungeonSelect, DungeonSelectBehaviour>
    {
        private bool _isShowBossAvatar = true;
        private int _HardModeNeedLevel = 0;
        private uint _SelectDifficult = 0;
        private int _SelectedChapter = 0;
        private uint _SelectScene = 0;
        private bool _bAutoSelect = false;
        private bool _bAutoSelectChapterId = true;
        private GameObject _MainFrame;
        private GameObject _LeftFrame;
        private GameObject _RightFrame;
        private bool m_bLevelIsMoving = false;
        private int _ChapterRank;
        private int _ChapterTotalRank;
        private const float LEVEL_FRAME_OFFSET = 1136f;
        private uint _FirstNoRankScene = 0;
        private Dictionary<uint, GameObject> SceneDic = new Dictionary<uint, GameObject>();
        private uint _SceneRemainTime = 9999;
        public bool IsTaskMode = false;
        private float m_fSweepBtnCoolTime = 0.5f;
        private float m_fGoBattleCoolTime = 5f;
        private float m_fLastClickBtnTime = 0.0f;
        private DungeonSelect.FrameCache main;
        private DungeonSelect.FrameCache left;
        private DungeonSelect.FrameCache right;
        private XDummy bossDummy = (XDummy)null;
        private XWelfareDocument _welfareDoc;
        private GameObject m_goLevelUpGo;
        private XFx m_fx;
        private XFx m_fx1;
        private string m_effectPath = string.Empty;
        private string m_effectPath1 = string.Empty;

        private bool _bLevelIsMoving
        {
            get => this.m_bLevelIsMoving;
            set
            {
                if ((Object)this.uiBehaviour.m_hardBox != (Object)null)
                    this.uiBehaviour.m_hardBox.enabled = !value;
                if ((Object)this.uiBehaviour.m_normalBox != (Object)null)
                    this.uiBehaviour.m_normalBox.enabled = !value;
                this.m_bLevelIsMoving = value;
            }
        }

        public string EffectPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.m_effectPath))
                    this.m_effectPath = XSingleton<XGlobalConfig>.singleton.GetValue("DungeonSelectRoleEffectPath");
                return this.m_effectPath;
            }
        }

        public string EffectPath1
        {
            get
            {
                if (string.IsNullOrEmpty(this.m_effectPath1))
                    this.m_effectPath1 = XSingleton<XGlobalConfig>.singleton.GetValue("DungeonSelectRoleEffectPath1");
                return this.m_effectPath1;
            }
        }

        public override string fileName => "Hall/DungeonSelect";

        public override int layer => 1;

        public override bool pushstack => true;

        public override bool autoload => true;

        public override bool fullscreenui => true;

        public override bool hideMainMenu => true;

        protected override void Init()
        {
            XLevelDocument xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument;
            this._welfareDoc = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
            if (this._SelectedChapter == 0)
                this._SelectedChapter = XSingleton<XStageProgress>.singleton.GetPlayerLastChapter(this._SelectDifficult);
            OpenSystemTable.RowData sysData = XSingleton<XGameSysMgr>.singleton.GetSysData(XSysDefineMgr.GetTypeInt(XSysDefine.XSys_Level_Elite));
            if (sysData != null)
            {
                this._HardModeNeedLevel = sysData.PlayerLevel;
            }
            else
            {
                this._HardModeNeedLevel = 1;
                XSingleton<XDebug>.singleton.AddErrorLog("_sysData is nill");
            }
        }

        public GameObject GetGoLevelUpInfo() => this.m_goLevelUpGo;

        public void FadeShow()
        {
            if (this.IsVisible())
                return;
            XAutoFade.FadeOut2In(0.5f, 0.5f);
            int num = (int)XSingleton<XTimerMgr>.singleton.SetTimer(0.484f, new XTimerMgr.ElapsedEventHandler(this.InnerShow), (object)null);
        }

        private void InnerShow(object o)
        {
            this.SetVisible(true, true);
            XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID).ResetNavi();
        }

        protected override void OnShow()
        {
            base.OnShow();
            this.uiBehaviour.m_SceneDetail.SetActive(false);
            this.Alloc3DAvatarPool(nameof(DungeonSelect));
            XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID).OnTopUIRefreshed((IXUIDlg)this);
            XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
            if (this.IsTaskMode)
            {
                int naviScene = (int)specificDocument.NaviScene;
                if ((uint)naviScene > 0U)
                {
                    this.SetAutoSelectScene(naviScene, 0, 0U);
                    this._bAutoSelect = false;
                    this._bAutoSelectChapterId = true;
                }
                this.IsTaskMode = false;
            }
            if (DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.IsVisible())
                DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.OnCloseClicked((IXUIButton)null);
            if (DlgBase<XCharacterCommonMenuView, XCharacterCommonMenuBehaviour>.singleton.IsVisible())
                DlgBase<XCharacterCommonMenuView, XCharacterCommonMenuBehaviour>.singleton.SetVisible(false, true);
            if (DlgBase<XOptionsView, XOptionsBehaviour>.singleton.IsVisible())
                DlgBase<XOptionsView, XOptionsBehaviour>.singleton.SetVisible(false, true);
            if (DlgBase<XFlowerSendView, XFlowerSendBehaviour>.singleton.IsVisible())
                DlgBase<XFlowerSendView, XFlowerSendBehaviour>.singleton.SetVisible(false, true);
            if (DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.IsLoaded() && DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.IsVisible())
                DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.SetVisible(false, true);
            bool flag = this._SelectDifficult == 0U;
            this.uiBehaviour.m_cbNormal.ForceSetFlag(false);
            this.uiBehaviour.m_cbHard.ForceSetFlag(false);
            if (this._bAutoSelect)
            {
                this.OnSwitchDifficult(flag ? this.uiBehaviour.m_Normal : this.uiBehaviour.m_Hard);
            }
            else
            {
                this.uiBehaviour.m_cbNormal.bChecked = flag;
                this.uiBehaviour.m_cbHard.bChecked = !flag;
                this.SetupChapterImage();
            }
            XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID).ReqTeamOp(TeamOperate.TEAM_QUERYCOUNT);
            XDocuments.GetSpecificDocument<XDailyActivitiesDocument>(XDailyActivitiesDocument.uuID).QueryDailyActivityData();
        }

        private void ResetTexture(GameObject frame)
        {
            if (!((Object)frame != (Object)null))
                return;
            Transform child = frame.transform.FindChild("BG");
            if ((Object)child != (Object)null)
                (child.GetComponent("XUITexture") as IXUITexture).SetTexturePath("");
        }

        protected override void OnHide()
        {
            base.OnHide();
            this.main.Clear();
            this.left.Clear();
            this.right.Clear();
            this.Return3DAvatarPool();
            this.bossDummy = (XDummy)null;
            XSingleton<XInput>.singleton.Freezed = false;
            this.ResetTexture(this._MainFrame);
            this.ResetTexture(this._LeftFrame);
            this.ResetTexture(this._RightFrame);
            this._bLevelIsMoving = false;
            this.uiBehaviour.m_LevelTween.StopTween();
            this.uiBehaviour.m_LevelTween.ResetTweenByGroup(true, 1);
            this.uiBehaviour.m_cbHard.ForceSetFlag(false);
            this.uiBehaviour.m_cbNormal.ForceSetFlag(false);
        }

        protected override void OnUnload()
        {
            XSingleton<X3DAvatarMgr>.singleton.OnUIUnloadMainDummy(this.main.snapShot);
            this.Return3DAvatarPool();
            this.bossDummy = (XDummy)null;
            if (this.m_fx != null)
            {
                XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fx);
                this.m_fx = (XFx)null;
            }
            if (this.m_fx1 != null)
            {
                XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fx1);
                this.m_fx1 = (XFx)null;
            }
            base.OnUnload();
        }

        public override void RegisterEvent()
        {
            this.uiBehaviour.m_Normal.ID = 0UL;
            this.uiBehaviour.m_Hard.ID = 1UL;
            this.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
            this.uiBehaviour.m_Normal.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSwitchDifficult));
            this.uiBehaviour.m_Hard.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSwitchDifficult));
            this.uiBehaviour.m_LevelBg.RegisterSpriteDragEventHandler(new SpriteDragEventHandler(this.OnLevelBgDrag));
            this.uiBehaviour.m_SceneClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDetailClose));
            this.uiBehaviour.m_SceneQuick1.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnQuickClicked));
            this.uiBehaviour.m_SceneQuick10.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnQuickClicked));
            this.uiBehaviour.m_SceneGoBattle.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoBattleBtnClicked));
            this.uiBehaviour.m_SceneSoloBattle.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSoloBattleClicked));
            this.uiBehaviour.m_SceneTeamBattle.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTeamBattleClicked));
            this.uiBehaviour.m_ShopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShopBtnClick));
            this.uiBehaviour.m_Left.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnMoveLeft));
            this.uiBehaviour.m_Right.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnMoveRight));
            this.uiBehaviour.m_BoxFrameBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChapterBoxBgClick));
            this.uiBehaviour.m_BtnAddHardLeftCount0.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnAddHardCountClicked));
            this.uiBehaviour.m_BtnAddHardLeftCount1.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnAddHardCountClicked));
            this.uiBehaviour.m_PrerogativeBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMemberPrivilegeClicked));
            this.uiBehaviour.m_addTicketSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickAddTicketBtn));
        }

        private void OnMemberPrivilegeClicked(IXUISprite btn) => DlgBase<XWelfareView, XWelfareBehaviour>.singleton.CheckActiveMemberPrivilege(MemberPrivilege.KingdomPrivilege_Adventurer);

        private void OnClickAddTicketBtn(IXUISprite spr) => XSingleton<UiUtility>.singleton.ShowItemAccess(XSingleton<XGlobalConfig>.singleton.GetInt("SweepTicketId"), (AccessCallback)null);

        protected void OnSwitchDifficult(IXUISprite sp)
        {
            if (this._bLevelIsMoving)
                return;
            uint id = (uint)sp.ID;
            bool flag = this._IsHardModeEnable();
            if (1U == id)
            {
                if (!flag)
                {
                    this.uiBehaviour.m_cbHard.bChecked = false;
                    this.uiBehaviour.m_cbNormal.bChecked = true;
                    XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DUNGEONSELECT_HARDMODE_LEVEL_LIMIT_FMT", (object)this._HardModeNeedLevel), "fece00");
                    return;
                }
            }
            else if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Level_Normal))
                return;
            this.uiBehaviour.m_cbHard.bChecked = 1U == id;
            this.uiBehaviour.m_cbNormal.bChecked = 1U != id;
            if (this._bAutoSelectChapterId)
                this._SelectedChapter = XSingleton<XStageProgress>.singleton.GetPlayerLocationChapter(id);
            else
                this._bAutoSelectChapterId = true;
            this._SelectDifficult = id;
            this.SetupChapterImage();
            XSingleton<XDebug>.singleton.AddGreenLog(nameof(OnSwitchDifficult));
        }

        private bool _IsHardModeEnable()
        {
            if (XSingleton<XAttributeMgr>.singleton.XPlayerData != null)
                return (long)this._HardModeNeedLevel <= (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
            XSingleton<XDebug>.singleton.AddGreenLog("XAttributeMgr.singleton.XPlayerData is null");
            return false;
        }

        public void AutoShowLastChapter(uint difficult, bool showDetailFrame = true)
        {
            if (1U == difficult && !this._IsHardModeEnable())
                difficult = 0U;
            this._SelectDifficult = difficult;
            this._SelectedChapter = XSingleton<XStageProgress>.singleton.GetPlayerLocationChapter(this._SelectDifficult);
            this._SelectScene = XSingleton<XStageProgress>.singleton.GetPlayerLastSceneInChapter(this._SelectedChapter);
            if (this._SelectDifficult == 0U)
                this.OnSwitchDifficult(this.uiBehaviour.m_Normal);
            else
                this.OnSwitchDifficult(this.uiBehaviour.m_Hard);
            if (!(this._SelectScene > 0U & showDetailFrame))
                return;
            this._SetupDetailFrame(this._SelectScene);
        }

        protected bool OnQuickClicked(IXUIButton button)
        {
            if (this.SetButtonCool(this.m_fSweepBtnCoolTime))
                return true;
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Level_Swap))
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SWAP_NOT_OPEN"), "fece00");
                return true;
            }
            if (this._SelectDifficult == 1U)
            {
                XMainInterfaceDocument xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(XMainInterfaceDocument.uuID) as XMainInterfaceDocument;
                SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this._SelectScene);
                if (sceneData != null && xcomponent != null && xcomponent.GetPlayerPPT() < sceneData.SweepNeedPPT)
                {
                    XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SWEEPPPT_NOTENOUGH"), "fece00");
                    return true;
                }
                if (XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(87) <= 0UL)
                {
                    XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SWEEPTICKETS_NOTENOUGH"), "fece00");
                    return true;
                }
                XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
                int expIdBySceneId = specificDocument.GetExpIDBySceneID(this._SelectScene);
                if (!specificDocument.CheckCountAndBuy(expIdBySceneId, sceneData))
                    return true;
            }
            if (this.OnLackPower() || this._SelectScene <= 0U)
                return true;
            XSweepDocument specificDocument1 = XDocuments.GetSpecificDocument<XSweepDocument>(XSweepDocument.uuID);
            if (button.gameObject.name == "Quick1")
                specificDocument1.StartSweep(this._SelectScene, 1U);
            else if (button.gameObject.name == "Quick10")
            {
                if (this._SelectDifficult == 0U)
                    specificDocument1.StartSweep(this._SelectScene, 10U);
                else if (this._SelectDifficult == 1U)
                    specificDocument1.StartSweep(this._SelectScene, 5U);
            }
            return true;
        }

        private bool SetButtonCool(float time)
        {
            if ((double)(Time.realtimeSinceStartup - this.m_fLastClickBtnTime) < (double)time)
                return true;
            this.m_fLastClickBtnTime = Time.realtimeSinceStartup;
            return false;
        }

        protected bool OnCloseClicked(IXUIButton button)
        {
            if (this._bLevelIsMoving)
            {
                XSingleton<XDebug>.singleton.AddLog("isMoving!!!!");
                return true;
            }
            this.SetVisible(false, true);
            return true;
        }

        protected bool OnResetClicked(IXUIButton button)
        {
            int index1 = 0;
            XLevelDocument xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument;
            if (xcomponent.SceneBuyCount.ContainsKey(this._SelectScene))
                index1 = (int)xcomponent.SceneBuyCount[this._SelectScene];
            List<uint> toRelease = ListPool<uint>.Get();
            string[] strArray = XSingleton<XGlobalConfig>.singleton.GetValue("BuyStageCountCost").Split(XGlobalConfig.ListSeparator);
            for (uint index2 = 0; (long)index2 < (long)strArray.Length; ++index2)
                toRelease.Add(uint.Parse(strArray[(int)index2]));
            if (index1 >= toRelease.Count)
                index1 = toRelease.Count - 1;
            uint num = toRelease[index1];
            XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("RESET_LEVEL"), (object)num), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._ResetScene));
            ListPool<uint>.Release(toRelease);
            return true;
        }

        protected bool _ResetScene(IXUIButton button)
        {
            (XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument).ResetScene((int)this._SelectScene);
            XSingleton<UiUtility>.singleton.CloseModalDlg();
            return true;
        }

        public void OnResetSucc() => this._SetupDetailFrame(this._SelectScene);

        public bool OnGoBattleBtnClicked(IXUIButton go)
        {
            if (this._SelectScene > 0U && !this.OnLackPower())
            {
                SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this._SelectScene);
                if (sceneData == null)
                {
                    XSingleton<XDebug>.singleton.AddErrorLog("sceneData is null");
                    return true;
                }
                float num = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SceneGotoPower"));
                if (XSingleton<PPTCheckMgr>.singleton.CheckMyPPT(Mathf.FloorToInt((float)sceneData.RecommendPower * num)))
                {
                    this.GoBattle((IXUIButton)null);
                }
                else
                {
                    this.uiBehaviour.m_SceneDetail.gameObject.SetActive(false);
                    XSingleton<PPTCheckMgr>.singleton.ShowPPTNotEnoughDlg(0UL, new ButtonClickEventHandler(this.GoBattle));
                }
            }
            return true;
        }

        public bool OnSoloBattleClicked(IXUIButton go)
        {
            if (this._SelectDifficult == 1U)
            {
                SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this._SelectScene);
                if (sceneData == null)
                {
                    XSingleton<XDebug>.singleton.AddErrorLog("sceneData is null");
                    return true;
                }
                float num = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SceneGotoPower"));
                if (XSingleton<PPTCheckMgr>.singleton.CheckMyPPT(Mathf.FloorToInt((float)sceneData.RecommendPower * num)))
                {
                    this.OnRealSoloBattleClicked((IXUIButton)null);
                }
                else
                {
                    this.uiBehaviour.m_SceneDetail.gameObject.SetActive(false);
                    XSingleton<PPTCheckMgr>.singleton.ShowPPTNotEnoughDlg(0UL, new ButtonClickEventHandler(this.OnRealSoloBattleClicked));
                }
            }
            return true;
        }

        public bool OnRealSoloBattleClicked(IXUIButton go)
        {
            if (this.OnLackPower() || !XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID).bInTeam)
                return true;
            XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_TEAM_ALREADY_INTEAM"), "fece00");
            return true;
        }

        public bool OnTeamBattleClicked(IXUIButton go)
        {
            if (this._SelectDifficult == 1U)
            {
                SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this._SelectScene);
                float num = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SceneGotoPower"));
                if (sceneData != null)
                {
                    if (XSingleton<PPTCheckMgr>.singleton.CheckMyPPT(Mathf.FloorToInt((float)sceneData.RecommendPower * num)))
                    {
                        this.OnRealTeamBattleClicked((IXUIButton)null);
                    }
                    else
                    {
                        this.uiBehaviour.m_SceneDetail.gameObject.SetActive(false);
                        XSingleton<PPTCheckMgr>.singleton.ShowPPTNotEnoughDlg(0UL, new ButtonClickEventHandler(this.OnRealTeamBattleClicked));
                    }
                }
            }
            return true;
        }

        public bool OnRealTeamBattleClicked(IXUIButton go)
        {
            XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
            XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID).SetAndMatch(specificDocument.GetExpIDBySceneID(this._SelectScene));
            return true;
        }

        private bool OnLackPower() => this.OnLackPower(1);

        private bool OnLackPower(int times)
        {
            if (XSingleton<UiUtility>.singleton.CanEnterBattleScene(this._SelectScene, times))
                return false;
            if (XSingleton<UiUtility>.singleton.IsMaxBuyPowerCnt())
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_SCENE_NOFATIGUE"), "fece00");
            else
                DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ShowBorad(XMainClient.ItemEnum.FATIGUE);
            return true;
        }

        protected bool GoBattle(IXUIButton go)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            if (XTeamDocument.GoSingleBattleBeforeNeed(new ButtonClickEventHandler(this.GoBattle), go) || this.SetButtonCool(this.m_fGoBattleCoolTime))
                return true;
            XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2G_EnterSceneReq()
            {
                Data = {
          sceneID = this._SelectScene
        }
            });
            return true;
        }

        public void SetAutoSelectScene(int sceneid, int chapterid, uint diff)
        {
            this._bAutoSelectChapterId = false;
            if (sceneid == 0)
            {
                this._SelectDifficult = diff;
                this._SelectedChapter = chapterid;
                this._SelectScene = 0U;
                if (this._SelectedChapter == 0)
                    this._SelectedChapter = XSingleton<XStageProgress>.singleton.GetPlayerLocationChapter(this._SelectDifficult);
                this._bAutoSelect = true;
            }
            else
            {
                this._SelectScene = (uint)sceneid;
                this._SelectedChapter = XSingleton<XSceneMgr>.singleton.GetSceneChapter(sceneid);
                this._SelectDifficult = (uint)XSingleton<XSceneMgr>.singleton.GetSceneDifficult(sceneid);
                this._bAutoSelect = true;
            }
        }

        public void SelectChapter(int chapterid, uint diff)
        {
            this._SelectScene = 0U;
            this._SelectedChapter = chapterid;
            this._SelectDifficult = diff;
            this.FadeShow();
        }

        protected GameObject GetLevelFrame() => this.uiBehaviour.m_SceneFramePool.FetchGameObject();

        protected void SetupChapterBaseImage(int chapter, uint difficult, GameObject frame)
        {
            XLevelDocument xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument;
            XChapter.RowData chapter1 = XSingleton<XSceneMgr>.singleton.GetChapter(chapter);
            IXUILabel component1 = frame.transform.FindChild("Title").GetComponent("XUILabel") as IXUILabel;
            if (chapter1 != null)
                component1.SetText(chapter1.Comment);
            Transform child1 = frame.transform.FindChild("me");
            IXUISprite component2 = frame.transform.FindChild("me/me/me").GetComponent("XUISprite") as IXUISprite;
            component2.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetSuperRiskAvatar(XSingleton<XEntityMgr>.singleton.Player.BasicTypeID);
            component2.MakePixelPerfect();
            child1.gameObject.SetActive(false);
            Transform child2 = frame.transform.FindChild("BG");
            if ((Object)child2 != (Object)null)
            {
                IXUITexture component3 = child2.GetComponent("XUITexture") as IXUITexture;
                if (chapter1 != null)
                    component3.SetTexturePath("atlas/UI/Hall/LevelBg/" + chapter1.Pic);
            }
            List<uint> uintList = ListPool<uint>.Get();
            XSingleton<XSceneMgr>.singleton.GetSceneListByChapter(chapter, uintList);
            if (uintList.Count == 0)
            {
                ListPool<uint>.Release(uintList);
            }
            else
            {
                uintList.Sort();
                if (difficult == 0U)
                {
                    this.uiBehaviour.m_NormalBg.SetActive(true);
                    this.uiBehaviour.m_HardBg.SetActive(false);
                    this.uiBehaviour.m_HardLeftCountGo0.SetActive(false);
                    this.uiBehaviour.m_ShopBtn.SetVisible(false);
                }
                else
                {
                    this.uiBehaviour.m_PrerogativeSpr.SetGrey(this._welfareDoc.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Adventurer));
                    this.uiBehaviour.m_PrerogativeSpr.SetSprite(this._welfareDoc.GetMemberPrivilegeIcon(MemberPrivilege.KingdomPrivilege_Adventurer));
                    this.uiBehaviour.m_PrerogativeLab.SetEnabled(this._welfareDoc.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Adventurer));
                    this.uiBehaviour.m_PrerogativeLab.SetText(string.Format(XStringDefineProxy.GetString("Prerogative_Abyss"), (object)this._welfareDoc.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Adventurer).AbyssCount));
                    this.uiBehaviour.m_NormalBg.SetActive(false);
                    this.uiBehaviour.m_HardBg.SetActive(true);
                    this.uiBehaviour.m_HardLeftCountGo0.SetActive(true);
                    this.uiBehaviour.m_ShopBtn.SetVisible(true);
                }
                bool flag = false;
                GameObject gameObject1 = (GameObject)null;
                Transform child3 = frame.transform.FindChild("Levels");
                XSingleton<X3DAvatarMgr>.singleton.ClearDummy(this.m_dummPool);
                this.bossDummy = (XDummy)null;
                if ((Object)frame == (Object)this._MainFrame)
                    this._isShowBossAvatar = true;
                for (int index = 0; index < uintList.Count; ++index)
                {
                    uint num = uintList[index];
                    SceneTable.RowData sceneData1 = XSingleton<XSceneMgr>.singleton.GetSceneData(num);
                    int rank = XSingleton<XStageProgress>.singleton.GetRank(sceneData1.id);
                    if (rank == -1)
                        rank = 0;
                    if (sceneData1 != null)
                    {
                        GameObject gameObject2 = this.uiBehaviour.m_ScenePool.FetchGameObject();
                        gameObject2.name = sceneData1.id.ToString();
                        gameObject2.transform.parent = child3;
                        if (sceneData1.UIPos != null)
                            gameObject2.transform.localPosition = new Vector3((float)sceneData1.UIPos[0], (float)sceneData1.UIPos[1], 600f);
                        else
                            XSingleton<XDebug>.singleton.AddErrorLog("'uipos' is null,To the plotter(ce hua) Find a solution,please,sceneId = " + num.ToString());
                        gameObject2.transform.localScale = Vector3.one;
                        this.SceneDic[num] = gameObject2;
                        IXUISprite component4 = gameObject2.transform.FindChild("SprBtn").GetComponent("XUISprite") as IXUISprite;
                        component4.ID = (ulong)(uint)sceneData1.id;
                        component4.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSceneSelected));
                        IXUISprite component5 = gameObject2.transform.FindChild("LevelPic").GetComponent("XUISprite") as IXUISprite;
                        IXUISprite component6 = gameObject2.transform.FindChild("Star1").GetComponent("XUISprite") as IXUISprite;
                        IXUISprite component7 = gameObject2.transform.FindChild("Star2").GetComponent("XUISprite") as IXUISprite;
                        IXUISprite component8 = gameObject2.transform.FindChild("Star3").GetComponent("XUISprite") as IXUISprite;
                        GameObject gameObject3 = gameObject2.transform.FindChild("TaskHint").gameObject;
                        gameObject2.transform.FindChild("Snapshot");
                        IXUISprite component9 = gameObject2.transform.FindChild("Box").GetComponent("XUISprite") as IXUISprite;
                        IXUILabel component10 = gameObject2.transform.FindChild("Hint").GetComponent("XUILabel") as IXUILabel;
                        IXUILabel component11 = gameObject2.transform.FindChild("Hint/GoLevelup").GetComponent("XUILabel") as IXUILabel;
                        IXUISprite component12 = gameObject2.transform.FindChild("BoxFx").GetComponent("XUISprite") as IXUISprite;
                        component9.gameObject.SetActive(false);
                        component10.gameObject.SetActive(false);
                        component12.gameObject.SetActive(false);
                        XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
                        gameObject3.SetActive(specificDocument.GetSceneTaskState(num).Count > 0);
                        if (difficult == 0U)
                            component5.SetSprite("gk_0");
                        else
                            component5.SetSprite("gk_1");
                        component6.gameObject.SetActive(true);
                        component6.spriteName = "gk_3";
                        component7.gameObject.SetActive(true);
                        component7.spriteName = "gk_3";
                        component8.gameObject.SetActive(true);
                        component8.spriteName = "gk_3";
                        if (rank >= 1)
                            component6.spriteName = "gk_4";
                        if (rank >= 2)
                            component7.spriteName = "gk_4";
                        if (rank >= 3)
                            component8.spriteName = "gk_4";
                        if (rank == 0)
                        {
                            component6.gameObject.SetActive(false);
                            component7.gameObject.SetActive(false);
                            component8.gameObject.SetActive(false);
                        }
                        component5.SetGrey(!flag);
                        if (rank <= 0)
                        {
                            SceneRefuseReason sceneRefuseReason = SceneRefuseReason.Invalid;
                            if (!flag)
                            {
                                sceneRefuseReason = xcomponent.CanLevelOpen(num);
                                component5.SetGrey(true);
                                child1.localPosition = gameObject2.transform.localPosition;
                                gameObject1 = child1.gameObject;
                                if (index == uintList.Count - 1)
                                    this._isShowBossAvatar = false;
                                if (sceneRefuseReason != SceneRefuseReason.Admit)
                                {
                                    component10.gameObject.SetActive(true);
                                    if (sceneRefuseReason == SceneRefuseReason.PreTask_Notfinish)
                                    {
                                        component11.SetText(XStringDefineProxy.GetString("LEVEL_GO_TASK"));
                                        component10.SetText(string.Format(XStringDefineProxy.GetString("LEVEl_REQUIRE_TASK")));
                                        component11.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnGoLevelupClick));
                                    }
                                    else if (sceneRefuseReason == SceneRefuseReason.PreScene_Notfinish)
                                    {
                                        component11.SetText(XStringDefineProxy.GetString("LEVEL_GO_SCENE"));
                                        SceneTable.RowData sceneData2 = XSingleton<XSceneMgr>.singleton.GetSceneData((uint)xcomponent.GetUnFinishedPreSceneID(sceneData1));
                                        if (sceneData2 != null)
                                            component10.SetText(string.Format(XStringDefineProxy.GetString("LEVEL_REQUIRE_PRELEVEL"), (object)sceneData2.Comment));
                                        component11.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnGoLevelupClick));
                                    }
                                    else if (SceneRefuseReason.ReachLimitTimes == sceneRefuseReason)
                                    {
                                        component11.SetText(XStringDefineProxy.GetString("LEVEL_REACH_LIMIT_TIMES"));
                                        component10.SetText(XStringDefineProxy.GetString("LEVEL_REACH_LIMIT_TIMES"));
                                        component11.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnGoLevelupClick));
                                    }
                                    else
                                    {
                                        component11.SetText(XStringDefineProxy.GetString("LEVEL_GO_UP"));
                                        component10.SetText(string.Format(XStringDefineProxy.GetString("LEVEL_REQUIRE_LEVEL"), (object)sceneData1.RequiredLevel));
                                        this.m_goLevelUpGo = component10.gameObject;
                                        XSingleton<XDebug>.singleton.AddGreenLog("get farme");
                                    }
                                    component11.ID = (ulong)(uint)sceneData1.id;
                                }
                            }
                            if (sceneRefuseReason == SceneRefuseReason.Admit)
                            {
                                child1.localPosition = gameObject2.transform.localPosition;
                                gameObject1 = child1.gameObject;
                            }
                            flag = true;
                        }
                        else
                        {
                            child1.localPosition = gameObject2.transform.localPosition;
                            gameObject1 = child1.gameObject;
                        }
                        if (sceneData1.SceneChest != 0 && sceneData1.BoxUIPos != null && sceneData1.BoxUIPos.Length == 2)
                        {
                            GameObject level = this.uiBehaviour.m_ScenePool.FetchGameObject();
                            level.name = "chest" + (object)num;
                            level.transform.parent = child3;
                            level.transform.localPosition = new Vector3((float)sceneData1.BoxUIPos[0], (float)sceneData1.BoxUIPos[1], 600f);
                            level.transform.localScale = Vector3.one;
                            this.SetupLevelChest(level, num, sceneData1.SceneChest, rank);
                        }
                    }
                }
                ListPool<uint>.Release(uintList);
                if ((Object)frame == (Object)this._MainFrame)
                    this.main.fx = gameObject1;
                else if ((Object)frame == (Object)this._LeftFrame)
                {
                    this.left.fx = gameObject1;
                }
                else
                {
                    if (!((Object)frame == (Object)this._RightFrame))
                        return;
                    this.right.fx = gameObject1;
                }
            }
        }

        protected void OnGoLevelupClick(IXUILabel go)
        {
            uint id = (uint)go.ID;
            XLevelDocument xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument;
            switch (xcomponent.CanLevelOpen(id))
            {
                case SceneRefuseReason.PreTask_Notfinish:
                    XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
                    XTaskInfo mainTask = specificDocument.TaskRecord.MainTask;
                    if (mainTask == null)
                        break;
                    uint sceneId = XTaskDocument.GetSceneID(ref mainTask.TableData.PassScene);
                    if (mainTask.Status == TaskStatus.TaskStatus_Taked && sceneId > 0U)
                    {
                        this._SelectedChapter = XSingleton<XSceneMgr>.singleton.GetSceneChapter((int)sceneId);
                        this._SelectDifficult = (uint)XSingleton<XSceneMgr>.singleton.GetSceneDifficult((int)sceneId);
                        this._SelectScene = sceneId;
                        this._SetupDetailFrame(sceneId);
                    }
                    else
                    {
                        this.SetVisible(false, true);
                        specificDocument.DoTask(mainTask.ID);
                    }
                    break;
                case SceneRefuseReason.PreScene_Notfinish:
                    SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(id);
                    if (sceneData == null)
                    {
                        XSingleton<XDebug>.singleton.AddGreenLog("scenedata is null");
                        break;
                    }
                    int finishedPreSceneId = xcomponent.GetUnFinishedPreSceneID(sceneData);
                    if (XSingleton<XStageProgress>.singleton.GetRank(finishedPreSceneId) > 0 || xcomponent.CanLevelOpen((uint)finishedPreSceneId) == SceneRefuseReason.Admit)
                    {
                        this._SelectScene = (uint)finishedPreSceneId;
                        int sceneChapter = XSingleton<XSceneMgr>.singleton.GetSceneChapter(finishedPreSceneId);
                        int sceneDifficult = XSingleton<XSceneMgr>.singleton.GetSceneDifficult(finishedPreSceneId);
                        if (sceneChapter != this._SelectedChapter || (long)sceneDifficult != (long)this._SelectDifficult)
                        {
                            this.uiBehaviour.m_cbNormal.ForceSetFlag(false);
                            this.uiBehaviour.m_cbHard.ForceSetFlag(false);
                            if (sceneDifficult == 0)
                            {
                                this.uiBehaviour.m_cbNormal.bChecked = true;
                                this.OnSwitchDifficult(this.uiBehaviour.m_Normal);
                            }
                            else
                            {
                                this.uiBehaviour.m_cbHard.bChecked = true;
                                this.OnSwitchDifficult(this.uiBehaviour.m_Hard);
                            }
                            this._SelectDifficult = (uint)sceneDifficult;
                            this._SelectedChapter = sceneChapter;
                        }
                        this._SetupDetailFrame((uint)finishedPreSceneId);
                        break;
                    }
                    int sceneChapter1 = XSingleton<XSceneMgr>.singleton.GetSceneChapter(finishedPreSceneId);
                    int sceneDifficult1 = XSingleton<XSceneMgr>.singleton.GetSceneDifficult(finishedPreSceneId);
                    if (sceneChapter1 != this._SelectedChapter || (long)sceneDifficult1 != (long)this._SelectDifficult)
                    {
                        IXUICheckBox component1 = this.uiBehaviour.m_Normal.gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
                        IXUICheckBox component2 = this.uiBehaviour.m_Hard.gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
                        component1.bChecked = false;
                        component2.bChecked = false;
                        if (sceneDifficult1 == 0)
                        {
                            component1.bChecked = true;
                            this.OnSwitchDifficult(this.uiBehaviour.m_Normal);
                        }
                        else
                        {
                            component2.bChecked = true;
                            this.OnSwitchDifficult(this.uiBehaviour.m_Hard);
                        }
                        this._SelectDifficult = (uint)sceneDifficult1;
                        this._SelectedChapter = sceneChapter1;
                    }
                    break;
            }
        }

        protected void SetupBossAvatar(int chapter, uint difficult, GameObject frame)
        {
            if (this.bossDummy != null)
                XSingleton<X3DAvatarMgr>.singleton.EnableCommonDummy(this.bossDummy, (IUIDummy)null, false);
            List<uint> uintList = ListPool<uint>.Get();
            XSingleton<XSceneMgr>.singleton.GetSceneListByChapter(chapter, uintList);
            if (uintList.Count == 0)
            {
                ListPool<uint>.Release(uintList);
            }
            else
            {
                uintList.Sort();
                if (uintList.Count == 0)
                    return;
                uint sceneID = uintList[uintList.Count - 1];
                if (!this._isShowBossAvatar)
                    return;
                int rank = XSingleton<XStageProgress>.singleton.GetRank((int)sceneID);
                if (rank >= 0)
                {
                    ListPool<uint>.Release(uintList);
                }
                else
                {
                    if (rank < 0 && uintList.Count > 1)
                    {
                        if (uintList.Count < 2)
                            return;
                        XLevelDocument xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument;
                        if (XSingleton<XStageProgress>.singleton.GetRank((int)uintList[uintList.Count - 2]) > 0 && xcomponent.CanLevelOpen(sceneID) == SceneRefuseReason.Admit)
                        {
                            ListPool<uint>.Release(uintList);
                            return;
                        }
                    }
                    ListPool<uint>.Release(uintList);
                    Transform child1 = frame.transform.FindChild("Levels");
                    Transform child2 = child1.GetChild(child1.childCount - 1);
                    if (child2.gameObject.name.StartsWith("chest"))
                        child2 = child1.GetChild(child1.childCount - 2);
                    IUIDummy component = child2.FindChild("Snapshot").GetComponent("UIDummy") as IUIDummy;
                    Vector3 localPosition = component.transform.localPosition;
                    localPosition.z = -100f;
                    component.transform.localPosition = localPosition;
                    XChapter.RowData chapter1 = XSingleton<XSceneMgr>.singleton.GetChapter(chapter);
                    if (chapter1 != null)
                    {
                        XEntityStatistics.RowData byId = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID((uint)chapter1.BossID);
                        if (byId == null)
                            return;
                        this.bossDummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, byId.PresentID, component, this.bossDummy);
                    }
                    else
                        XSingleton<XDebug>.singleton.AddErrorLog(string.Format("error chapterId = {0}", (object)chapter));
                }
            }
        }

        public void SetupChapterImage()
        {
            this.uiBehaviour.m_ScenePool.ReturnAll(true);
            this.uiBehaviour.m_SceneFramePool.ReturnAll();
            this.SceneDic.Clear();
            this._MainFrame = (GameObject)null;
            this._LeftFrame = (GameObject)null;
            this._RightFrame = (GameObject)null;
            this._bLevelIsMoving = false;
            this._MainFrame = this.GetLevelFrame();
            this.uiBehaviour.m_LevelTween.gameObject.transform.FindChild("LevelFramePanel").localPosition = Vector3.zero;
            this._MainFrame.transform.localPosition = Vector3.zero;
            this._MainFrame.name = string.Format("chapter{0}", (object)this._SelectedChapter);
            this._ChapterRank = 0;
            this._ChapterTotalRank = 0;
            this._FirstNoRankScene = 0U;
            this.SetupChapterBaseImage(this._SelectedChapter, this._SelectDifficult, this._MainFrame);
            this.SetupChapterExInfo();
            if (!this._bAutoSelect)
                return;
            if (this._SelectScene > 0U)
                this._SetupDetailFrame(this._SelectScene);
            this._bAutoSelect = false;
        }

        protected void SetupLeftChapterImage()
        {
            int previousChapter = XSingleton<XSceneMgr>.singleton.GetPreviousChapter(this._SelectedChapter);
            if (previousChapter == 0)
                return;
            if ((Object)this._LeftFrame == (Object)null)
                this._LeftFrame = this.GetLevelFrame();
            if ((Object)this._LeftFrame == (Object)null)
                XSingleton<XDebug>.singleton.AddGreenLog("SetupLeftChapterImage,_LeftFrame is null!");
            else if ((Object)this._MainFrame == (Object)null)
            {
                XSingleton<XDebug>.singleton.AddGreenLog("SetupLeftChapterImage,_MainFrame is null!");
            }
            else
            {
                this._LeftFrame.transform.localPosition = this._MainFrame.transform.localPosition + new Vector3(-1136f, 0.0f);
                this._LeftFrame.name = "chapter" + (object)previousChapter;
                this.SetupChapterBaseImage(previousChapter, this._SelectDifficult, this._LeftFrame);
            }
        }

        protected void SetupRightChapterImage()
        {
            int nextChapter = XSingleton<XSceneMgr>.singleton.GetNextChapter(this._SelectedChapter);
            if (nextChapter == this._SelectedChapter)
                return;
            int playerLastChapter = XSingleton<XStageProgress>.singleton.GetPlayerLastChapter(this._SelectDifficult);
            if (nextChapter > playerLastChapter)
                return;
            if ((Object)this._RightFrame == (Object)null)
                this._RightFrame = this.GetLevelFrame();
            if ((Object)this._RightFrame == (Object)null)
                XSingleton<XDebug>.singleton.AddGreenLog("SetupRightChapterImage,_RightFrame is null!");
            else if ((Object)this._MainFrame == (Object)null)
            {
                XSingleton<XDebug>.singleton.AddGreenLog("SetupRightChapterImage,_MainFrame is null!");
            }
            else
            {
                this._RightFrame.transform.localPosition = this._MainFrame.transform.localPosition + new Vector3(1136f, 0.0f, 0.0f);
                this._RightFrame.name = "chapter" + (object)nextChapter;
                this.SetupChapterBaseImage(nextChapter, this._SelectDifficult, this._RightFrame);
            }
        }

        protected void SetupLevelChest(GameObject level, uint sceneID, int dropID, int rank)
        {
            IXUISprite component1 = level.transform.FindChild("LevelPic").GetComponent("XUISprite") as IXUISprite;
            IXUISprite component2 = level.transform.FindChild("Star1").GetComponent("XUISprite") as IXUISprite;
            IXUISprite component3 = level.transform.FindChild("Star2").GetComponent("XUISprite") as IXUISprite;
            IXUISprite component4 = level.transform.FindChild("Star3").GetComponent("XUISprite") as IXUISprite;
            GameObject gameObject = level.transform.FindChild("TaskHint").gameObject;
            IXUISprite component5 = level.transform.FindChild("Box").GetComponent("XUISprite") as IXUISprite;
            IXUISprite component6 = level.transform.FindChild("BoxFx").GetComponent("XUISprite") as IXUISprite;
            IXUILabel component7 = level.transform.FindChild("Hint").GetComponent("XUILabel") as IXUILabel;
            IXUISprite component8 = level.transform.FindChild("SprBtn").GetComponent("XUISprite") as IXUISprite;
            component8.SetGrey(rank > 0);
            component8.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSceneChestClicked));
            component8.ID = (ulong)sceneID;
            component6.gameObject.SetActive(false);
            if (this._SelectDifficult == 0U)
                component1.SetSprite("gk_0");
            else
                component1.SetSprite("gk_1");
            component2.gameObject.SetActive(false);
            component3.gameObject.SetActive(false);
            component4.gameObject.SetActive(false);
            gameObject.gameObject.SetActive(false);
            component7.gameObject.SetActive(false);
            component5.gameObject.SetActive(true);
            component5.ID = (ulong)sceneID;
        }

        public void SetupChangeChapterUI()
        {
            XLevelDocument xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument;
            int previousChapter = XSingleton<XSceneMgr>.singleton.GetPreviousChapter(this._SelectedChapter);
            if (previousChapter > 0)
            {
                this.uiBehaviour.m_Left.gameObject.SetActive(true);
                GameObject gameObject = this.uiBehaviour.m_Left.gameObject.transform.FindChild("RedPoint").gameObject;
                if (xcomponent.HasChapterRedpoint(previousChapter))
                    gameObject.SetActive(true);
                else
                    gameObject.SetActive(false);
            }
            else
                this.uiBehaviour.m_Left.gameObject.SetActive(false);
            int nextChapter = XSingleton<XSceneMgr>.singleton.GetNextChapter(this._SelectedChapter);
            int playerLastChapter = XSingleton<XStageProgress>.singleton.GetPlayerLastChapter(this._SelectDifficult);
            if (nextChapter != this._SelectedChapter && playerLastChapter >= nextChapter)
            {
                this.uiBehaviour.m_Right.gameObject.SetActive(true);
                GameObject gameObject = this.uiBehaviour.m_Right.gameObject.transform.FindChild("RedPoint").gameObject;
                if (xcomponent.HasChapterRedpoint(nextChapter))
                    gameObject.SetActive(true);
                else
                    gameObject.SetActive(false);
            }
            else
                this.uiBehaviour.m_Right.gameObject.SetActive(false);
            if (this._SelectDifficult == 0U)
            {
                this.uiBehaviour.m_NormalRedpoint.SetActive(false);
                this.uiBehaviour.m_HardRedpoint.SetActive(xcomponent.HasDifficultAllChapterRedpoint(1));
            }
            else
            {
                this.uiBehaviour.m_HardRedpoint.SetActive(false);
                this.uiBehaviour.m_NormalRedpoint.SetActive(xcomponent.HasDifficultAllChapterRedpoint(0));
            }
        }

        public override void StackRefresh()
        {
            base.StackRefresh();
            this.Alloc3DAvatarPool(nameof(DungeonSelect));
            this.SetupPlayerAvatar();
            this.SetupBossAvatar(this._SelectedChapter, this._SelectDifficult, this._MainFrame);
            this.RefreshHardLeftCount();
        }

        public void SetupPlayerAvatar()
        {
            if (!((Object)this.main.fx != (Object)null))
                return;
            this.main.fx.SetActive(true);
            if (this.main.fx.transform.FindChild("me").GetComponent("XUIPlayTween") is IXUITweenTool component)
            {
                component.StopTween();
                component.ResetTween(true);
                component.PlayTween(true);
            }
        }

        public void UpdateSceneEnterTime()
        {
            if (!this.uiBehaviour.m_SceneDetail.activeInHierarchy)
                return;
            this._SetupDetailFrame(this._SelectScene);
            this.RefreshHardLeftCount();
        }

        public void UpdateSceneBox()
        {
            XLevelDocument xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument;
            Transform child1 = this._MainFrame.transform.FindChild("Levels");
            int childCount = child1.childCount;
            for (int index = 0; index < childCount; ++index)
            {
                Transform child2 = child1.GetChild(index);
                if (child2.gameObject.name.StartsWith("chest"))
                {
                    IXUISprite component1 = child2.FindChild("LevelPic").GetComponent("XUISprite") as IXUISprite;
                    IXUISprite component2 = child2.FindChild("Box").GetComponent("XUISprite") as IXUISprite;
                    IXUISprite component3 = child2.FindChild("BoxFx").GetComponent("XUISprite") as IXUISprite;
                    IXUITweenTool component4 = child2.FindChild("Box").GetComponent("XUIPlayTween") as IXUITweenTool;
                    uint id = (uint)component2.ID;
                    SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(id);
                    if (sceneData != null && sceneData.SceneChest > 0)
                    {
                        component2.gameObject.SetActive(true);
                        if (xcomponent.SceneBox.Contains(id))
                        {
                            component2.spriteName = "xz01_1";
                            component2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSceneChestClicked));
                            component3.gameObject.SetActive(false);
                            component1.SetEnabled(true);
                            component4.ResetTween(true);
                        }
                        else
                        {
                            component2.spriteName = "xz01_0";
                            component2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSceneChestClicked));
                            if (XSingleton<XStageProgress>.singleton.GetRank((int)id) <= 0)
                            {
                                component3.gameObject.SetActive(false);
                                component1.SetEnabled(false);
                                component4.ResetTween(true);
                            }
                            else
                            {
                                component3.gameObject.SetActive(true);
                                component1.SetEnabled(true);
                                component4.PlayTween(true);
                            }
                        }
                    }
                }
            }
            this.SetupChangeChapterUI();
        }

        protected void OnSceneChestClicked(IXUISprite sp)
        {
            this.uiBehaviour.m_BoxFrame.SetActive(true);
            this.uiBehaviour.m_BoxFetch.ID = sp.ID;
            SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData((uint)sp.ID);
            if (sceneData == null)
            {
                XSingleton<XDebug>.singleton.AddGreenLog("OnSceneChestClicked sceneData is null");
            }
            else
            {
                XLevelDocument xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument;
                this.uiBehaviour.m_BoxRedPoint.SetActive(false);
                this.uiBehaviour.m_BoxChest.SetActive(true);
                this.uiBehaviour.m_BoxStar.gameObject.SetActive(false);
                if (XSingleton<XStageProgress>.singleton.GetRank((int)sp.ID) <= 0)
                {
                    this.uiBehaviour.m_BoxFetch.SetEnable(false);
                    this.uiBehaviour.m_BoxFetch.SetCaption(XStringDefineProxy.GetString("SRS_FETCH"));
                }
                else if (xcomponent.SceneBox.Contains((uint)sceneData.id))
                {
                    this.uiBehaviour.m_BoxFetch.SetEnable(false);
                    this.uiBehaviour.m_BoxFetch.SetCaption(XStringDefineProxy.GetString("SRS_FETCHED"));
                }
                else
                {
                    this.uiBehaviour.m_BoxFetch.SetEnable(true);
                    this.uiBehaviour.m_BoxRedPoint.SetActive(true);
                    this.uiBehaviour.m_BoxFetch.SetCaption(XStringDefineProxy.GetString("SRS_FETCH"));
                }
                this.SetupBoxReward(sceneData.SceneChest);
                this.uiBehaviour.m_BoxFetch.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSceneChestBoxFetch));
            }
        }

        protected void ReturnLevelFrameToPool(GameObject frame)
        {
            if ((Object)frame == (Object)null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("ReturnLevelFrameToPool frame is null");
            }
            else
            {
                List<GameObject> gameObjectList = new List<GameObject>();
                Transform child = frame.transform.FindChild("Levels");
                if ((Object)child == (Object)null)
                    return;
                for (int index = 0; index < child.childCount; ++index)
                    gameObjectList.Add(child.GetChild(index).gameObject);
                for (int index = 0; index < gameObjectList.Count; ++index)
                    this.uiBehaviour.m_ScenePool.ReturnInstance(gameObjectList[index], true);
                this.uiBehaviour.m_SceneFramePool.ReturnInstance(frame);
            }
        }

        protected bool OnLevelBgDrag(Vector2 delta)
        {
            if ((double)delta.x > 0.0)
                this.OnMoveLeft((IXUIButton)null);
            else
                this.OnMoveRight((IXUIButton)null);
            return true;
        }

        protected bool OnMoveLeft(IXUIButton go)
        {
            if (this._bLevelIsMoving)
                return true;
            int previousChapter = XSingleton<XSceneMgr>.singleton.GetPreviousChapter(this._SelectedChapter);
            if (previousChapter > 0)
            {
                this._SelectedChapter = previousChapter;
                Vector3 localPosition = this.uiBehaviour.m_LevelTween.gameObject.transform.FindChild("LevelFramePanel").localPosition;
                Vector3 to = localPosition + new Vector3(1136f, 0.0f);
                if (this.uiBehaviour.m_LevelTween != null)
                    this._bLevelIsMoving = true;
                this.uiBehaviour.m_LevelTween.ResetTweenByGroup(true);
                this.uiBehaviour.m_LevelTween.SetPositionTweenPos(1, localPosition, to);
                this.uiBehaviour.m_LevelTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnMoveLeftOver));
                this.uiBehaviour.m_LevelTween.PlayTween(true);
                XSingleton<XDebug>.singleton.AddLog("MoveLeft-->> _bLevelIsMoving =" + this._bLevelIsMoving.ToString());
            }
            return true;
        }

        protected void OnMoveLeftOver(IXUITweenTool tween)
        {
            this._bLevelIsMoving = false;
            this.ReturnLevelFrameToPool(this._MainFrame);
            if ((Object)this._RightFrame != (Object)null)
                this.ReturnLevelFrameToPool(this._RightFrame);
            this._RightFrame = (GameObject)null;
            this._MainFrame = this._LeftFrame;
            this._LeftFrame = (GameObject)null;
            this.main.Copy(ref this.left);
            this.left.Clear();
            this.right.Clear();
            this.SetupChapterExInfo();
            XSingleton<XDebug>.singleton.AddLog("MoveLeftOver..... _bLevelIsMoving =" + this._bLevelIsMoving.ToString());
        }

        protected bool OnMoveRight(IXUIButton go)
        {
            if (this._bLevelIsMoving)
                return true;
            int nextChapter = XSingleton<XSceneMgr>.singleton.GetNextChapter(this._SelectedChapter);
            int playerLastChapter = XSingleton<XStageProgress>.singleton.GetPlayerLastChapter(this._SelectDifficult);
            if (nextChapter != this._SelectedChapter && playerLastChapter >= nextChapter)
            {
                this._SelectedChapter = nextChapter;
                Vector3 localPosition = this.uiBehaviour.m_LevelTween.gameObject.transform.FindChild("LevelFramePanel").localPosition;
                Vector3 to = localPosition + new Vector3(-1136f, 0.0f);
                if (this.uiBehaviour.m_LevelTween != null)
                    this._bLevelIsMoving = true;
                this.uiBehaviour.m_LevelTween.ResetTweenByGroup(true);
                this.uiBehaviour.m_LevelTween.SetPositionTweenPos(1, localPosition, to);
                this.uiBehaviour.m_LevelTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnMoveRightOver));
                this.uiBehaviour.m_LevelTween.PlayTween(true);
                XSingleton<XDebug>.singleton.AddLog("MoveRight-->> _bLevelIsMoving =" + this._bLevelIsMoving.ToString());
            }
            return true;
        }

        protected void OnMoveRightOver(IXUITweenTool tween)
        {
            this._bLevelIsMoving = false;
            this.ReturnLevelFrameToPool(this._MainFrame);
            if ((Object)this._LeftFrame != (Object)null)
                this.ReturnLevelFrameToPool(this._LeftFrame);
            this._LeftFrame = (GameObject)null;
            this._MainFrame = this._RightFrame;
            this._RightFrame = (GameObject)null;
            this.main.Copy(ref this.right);
            this.left.Clear();
            this.right.Clear();
            this.SetupChapterExInfo();
            XSingleton<XDebug>.singleton.AddLog("MoveRightOver..... _bLevelIsMoving =" + this._bLevelIsMoving.ToString());
        }

        protected void SetupChapterExInfo()
        {
            if ((Object)this._MainFrame == (Object)null)
            {
                this._bLevelIsMoving = false;
                XSingleton<XDebug>.singleton.AddGreenLog("SetupChapterExInfo,_MainFrame is null!");
            }
            else
            {
                this.PlayEffect(ref this.m_fx, this.EffectPath, this._MainFrame.transform.FindChild("me/Effect"));
                this.PlayEffect(ref this.m_fx1, this.EffectPath1, this._MainFrame.transform.FindChild("me/Effect/Effect"));
                this.SetupLeftChapterImage();
                this.SetupRightChapterImage();
                this.SetupPlayerAvatar();
                this.SetupBossAvatar(this._SelectedChapter, this._SelectDifficult, this._MainFrame);
                this.SetupChapterBoxProgress();
                this.SetupChangeChapterUI();
                this.UpdateSceneEnterTime();
                this.UpdateSceneBox();
            }
        }

        private void PlayEffect(ref XFx fx, string path, Transform parent)
        {
            if (fx == null)
                fx = XSingleton<XFxMgr>.singleton.CreateFx(path);
            else
                fx.SetActive(true);
            fx.Play(parent, Vector3.zero, Vector3.one, follow: true);
        }

        public void SetupChapterBoxProgress()
        {
            List<uint> uintList = ListPool<uint>.Get();
            XSingleton<XSceneMgr>.singleton.GetSceneListByChapter(this._SelectedChapter, uintList);
            if (uintList.Count == 0)
            {
                ListPool<uint>.Release(uintList);
            }
            else
            {
                uintList.Sort();
                this._ChapterTotalRank = this._ChapterRank = 0;
                this._FirstNoRankScene = 0U;
                for (int index = 0; index < uintList.Count; ++index)
                {
                    uint sceneID = uintList[index];
                    SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(sceneID);
                    int num = 0;
                    if (sceneData != null)
                        num = XSingleton<XStageProgress>.singleton.GetRank(sceneData.id);
                    if (num == -1)
                        num = 0;
                    if (sceneData != null)
                    {
                        this._ChapterTotalRank += 3;
                        this._ChapterRank += num;
                    }
                    if (num <= 0 && this._FirstNoRankScene == 0U)
                        this._FirstNoRankScene = sceneID;
                }
                ListPool<uint>.Release(uintList);
                this.uiBehaviour.m_Rank.SetText(this._ChapterRank.ToString() + "/" + (object)this._ChapterTotalRank);
                this.uiBehaviour.m_RankProgress.value = (float)this._ChapterRank / (float)this._ChapterTotalRank;
                XChapter.RowData chapter = XSingleton<XSceneMgr>.singleton.GetChapter(this._SelectedChapter);
                if (chapter == null)
                {
                    XSingleton<XDebug>.singleton.AddErrorLog("SetupChapterBoxProgress chData is null");
                }
                else
                {
                    int num1 = 390;
                    this.uiBehaviour.m_RankBox.FakeReturnAll();
                    for (int index = 0; index < chapter.Drop.Count; ++index)
                    {
                        int num2 = chapter.Drop[index, 0];
                        GameObject gameObject = this.uiBehaviour.m_RankBox.FetchGameObject();
                        gameObject.transform.localPosition = this.uiBehaviour.m_RankBox.TplPos + new Vector3((float)(num1 * num2 / this._ChapterTotalRank), 0.0f);
                        IXUISprite component1 = gameObject.GetComponent("XUISprite") as IXUISprite;
                        IXUISprite component2 = gameObject.transform.FindChild("Box").GetComponent("XUISprite") as IXUISprite;
                        IXUILabel component3 = gameObject.transform.FindChild("Star").GetComponent("XUILabel") as IXUILabel;
                        IXUITweenTool component4 = gameObject.transform.FindChild("Box").GetComponent("XUIPlayTween") as IXUITweenTool;
                        IXUISprite component5 = gameObject.transform.FindChild("Fx").GetComponent("XUISprite") as IXUISprite;
                        component3.SetText(num2.ToString());
                        component2.ID = (ulong)index;
                        component2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChapterBoxClicked));
                        component1.ID = (ulong)index;
                        component1.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChapterBoxClicked));
                        if (this._ChapterRank >= num2)
                        {
                            if (XSingleton<XStageProgress>.singleton.HasChapterBoxFetched(this._SelectedChapter, index))
                            {
                                component2.spriteName = "xz02_1";
                                component5.SetAlpha(0.0f);
                                component4.ResetTween(true);
                            }
                            else
                            {
                                component2.spriteName = "xz02_0";
                                component5.SetAlpha(1f);
                                component4.PlayTween(true);
                            }
                        }
                        else
                        {
                            component2.spriteName = "xz02_0";
                            component5.SetAlpha(0.0f);
                            component4.ResetTween(true);
                        }
                    }
                    this.uiBehaviour.m_RankBox.ActualReturnAll();
                }
            }
        }

        protected void OnChapterBoxClicked(IXUISprite sp)
        {
            if (this._bLevelIsMoving)
                return;
            this.uiBehaviour.m_BoxFrame.SetActive(true);
            int id = (int)sp.ID;
            this.uiBehaviour.m_BoxFetch.ID = sp.ID;
            this.uiBehaviour.m_BoxRedPoint.SetActive(false);
            XChapter.RowData chapter = XSingleton<XSceneMgr>.singleton.GetChapter(this._SelectedChapter);
            if (chapter == null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("OnChapterBoxClicked chdata is null");
            }
            else
            {
                this.uiBehaviour.m_BoxChest.SetActive(false);
                this.uiBehaviour.m_BoxStar.gameObject.SetActive(true);
                this.uiBehaviour.m_BoxStar.SetText(chapter.Drop[id, 0].ToString() + "/" + (object)this._ChapterTotalRank);
                if (this._ChapterRank < chapter.Drop[id, 0])
                {
                    this.uiBehaviour.m_BoxFetch.SetEnable(false);
                    this.uiBehaviour.m_BoxFetch.SetCaption(XStringDefineProxy.GetString("SRS_FETCH"));
                }
                else if (XSingleton<XStageProgress>.singleton.HasChapterBoxFetched(this._SelectedChapter, id))
                {
                    this.uiBehaviour.m_BoxFetch.SetEnable(false);
                    this.uiBehaviour.m_BoxFetch.SetCaption(XStringDefineProxy.GetString("SRS_FETCHED"));
                }
                else
                {
                    this.uiBehaviour.m_BoxFetch.SetEnable(true);
                    this.uiBehaviour.m_BoxRedPoint.SetActive(true);
                    this.uiBehaviour.m_BoxFetch.SetCaption(XStringDefineProxy.GetString("SRS_FETCH"));
                }
                this.SetupBoxReward(chapter.Drop[id, 1]);
                this.uiBehaviour.m_BoxFetch.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnChapterBoxFetch));
            }
        }

        protected void SetupBoxReward(int dropID)
        {
            this.uiBehaviour.m_BoxRewardPool.ReturnAll();
            List<XDropData> dropData = (XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument).GetDropData(dropID);
            if (dropData == null)
                return;
            int num = (dropData.Count + 1) / 2 - 1;
            Vector3 vector3 = new Vector3((float)((int)((double)((dropData.Count + 1) % 2) * (double)this.uiBehaviour.m_BoxRewardPool.TplPos.x) - num * this.uiBehaviour.m_BoxRewardPool.TplWidth), this.uiBehaviour.m_BoxRewardPool.TplPos.y);
            for (int index = 0; index < dropData.Count; ++index)
            {
                XDropData xdropData = dropData[index];
                GameObject go = this.uiBehaviour.m_BoxRewardPool.FetchGameObject();
                go.transform.localPosition = vector3 + new Vector3((float)(index * this.uiBehaviour.m_BoxRewardPool.TplWidth), 0.0f);
                XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(go, xdropData.itemID, xdropData.count);
                IXUISprite component = go.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
                component.ID = (ulong)xdropData.itemID;
                component.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
            }
        }

        protected void OnChapterBoxBgClick(IXUISprite sp) => this.uiBehaviour.m_BoxFrame.SetActive(false);

        protected bool OnChapterBoxFetch(IXUIButton go)
        {
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_FetchChapterChest()
            {
                oArg = {
          chapterID = this._SelectedChapter,
          chestID = (int) go.ID
        }
            });
            return true;
        }

        protected bool OnSceneChestBoxFetch(IXUIButton go)
        {
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_OpenSceneChest()
            {
                oArg = {
          sceneID = (uint) go.ID
        }
            });
            return true;
        }

        public void OnFetchSceneChestSucc()
        {
            this.uiBehaviour.m_BoxFrame.SetActive(false);
            this.UpdateSceneBox();
        }

        public void OnFetchChapterBoxSucc()
        {
            this.uiBehaviour.m_BoxFrame.SetActive(false);
            (XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument).RefreshRedPoint();
            this.SetupChapterBoxProgress();
        }

        protected void _SetupDetailFrame(uint sceneID)
        {
            XLevelDocument xcomponent1 = XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument;
            XMainInterfaceDocument xcomponent2 = XSingleton<XGame>.singleton.Doc.GetXComponent(XMainInterfaceDocument.uuID) as XMainInterfaceDocument;
            this.uiBehaviour.m_SceneDetail.gameObject.SetActive(true);
            this._SceneRemainTime = 9999U;
            SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(sceneID);
            int rank = XSingleton<XStageProgress>.singleton.GetRank((int)sceneID);
            uint sceneDifficult = (uint)XSingleton<XSceneMgr>.singleton.GetSceneDifficult((int)sceneID);
            if (sceneData == null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("_SetupDetailFrame sceneData is null");
            }
            else
            {
                this.uiBehaviour.m_SceneRecommendHint.SetVisible(0 < sceneData.RecommendHint.Length);
                this.uiBehaviour.m_SceneRecommendHint.SetText(string.Format("       {0}", (object)sceneData.RecommendHint));
                if (sceneDifficult == 0U)
                {
                    this.uiBehaviour.m_SceneNormal.SetActive(true);
                    this.uiBehaviour.m_SceneHard.SetActive(false);
                    this.uiBehaviour.m_HardLeftCountGo1.SetActive(false);
                    this.uiBehaviour.m_SceneSoloBattle.gameObject.SetActive(false);
                    this.uiBehaviour.m_SceneTeamBattle.gameObject.SetActive(false);
                    this.uiBehaviour.m_SceneGoBattle.gameObject.SetActive(true);
                }
                else
                {
                    this.uiBehaviour.m_SceneNormal.SetActive(false);
                    this.uiBehaviour.m_SceneHard.SetActive(true);
                    this.uiBehaviour.m_HardLeftCountGo1.SetActive(true);
                    this.uiBehaviour.m_SceneGoBattle.gameObject.SetActive(false);
                    if (rank <= 0)
                    {
                        this.uiBehaviour.m_SceneSoloBattle.gameObject.SetActive(false);
                        this.uiBehaviour.m_SceneTeamBattle.gameObject.SetActive(true);
                        this.uiBehaviour.m_SceneTeamBattle.gameObject.transform.localPosition = this.uiBehaviour.m_SceneGoBattle.gameObject.transform.localPosition;
                    }
                    else
                    {
                        this.uiBehaviour.m_SceneSoloBattle.gameObject.SetActive(false);
                        this.uiBehaviour.m_SceneTeamBattle.gameObject.SetActive(true);
                        this.uiBehaviour.m_SceneTeamBattle.gameObject.transform.localPosition = this.uiBehaviour.m_SceneTeamBattlePos;
                    }
                }
                this.uiBehaviour.m_SceneName.SetText(sceneData.Comment);
                int index1 = -1;
                for (int index2 = 0; index2 < XLevelRewardDocument.Table.Table.Length; ++index2)
                {
                    if ((int)XLevelRewardDocument.Table.Table[index2].scendid == (int)sceneID)
                    {
                        index1 = index2;
                        break;
                    }
                }
                if (index1 >= 0)
                {
                    this.uiBehaviour.m_SceneStarCond[1].SetText(LevelRewardGerenalHandler.GetReqText(XLevelRewardDocument.Table.Table[index1], 1));
                    this.uiBehaviour.m_SceneStarCond[2].SetText(LevelRewardGerenalHandler.GetReqText(XLevelRewardDocument.Table.Table[index1], 2));
                }
                for (int index3 = 0; index3 < 3; ++index3)
                {
                    if (XSingleton<XStageProgress>.singleton.GetRankDetail((int)sceneID, index3))
                        this.uiBehaviour.m_SceneStar[index3].SetColor(Color.white);
                    else
                        this.uiBehaviour.m_SceneStar[index3].SetColor(Color.grey);
                }
                this.uiBehaviour.m_SceneDropPool.ReturnAll();
                Vector3 tplPos = this.uiBehaviour.m_SceneDropPool.TplPos;
                int tplWidth = this.uiBehaviour.m_SceneDropPool.TplWidth;
                int tplHeight = this.uiBehaviour.m_SceneDropPool.TplHeight;
                if (XSingleton<XAttributeMgr>.singleton.XPlayerData != null)
                    this.uiBehaviour.m_DropExpLab.SetText(((int)(xcomponent1.GetExpAddition((int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level) * (double)sceneData.Exp)).ToString());
                if (sceneData.Money == 0)
                {
                    this.uiBehaviour.m_DropExpLab1.gameObject.transform.parent.gameObject.SetActive(false);
                }
                else
                {
                    this.uiBehaviour.m_DropExpLab1.gameObject.transform.parent.gameObject.SetActive(true);
                    this.uiBehaviour.m_DropExpLab1.SetText(sceneData.Money.ToString());
                }
                int a = sceneData.ViewableDropList != null ? sceneData.ViewableDropList.Length : 0;
                int b = 6;
                int num1 = Mathf.Max(a, b);
                for (int index4 = 0; index4 < num1; ++index4)
                {
                    int num2 = index4;
                    GameObject gameObject1 = this.uiBehaviour.m_SceneDropPool.FetchGameObject();
                    gameObject1.name = index4.ToString();
                    gameObject1.transform.localPosition = tplPos + new Vector3((float)(tplWidth * num2), 0.0f, 0.0f);
                    gameObject1.transform.localScale = Vector3.one;
                    GameObject gameObject2 = gameObject1.transform.FindChild("Item").gameObject;
                    if (index4 >= a && index4 < b)
                    {
                        gameObject2.SetActive(false);
                    }
                    else
                    {
                        gameObject2.SetActive(true);
                        XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, sceneData.ViewableDropList[index4]);
                        IXUISprite component = gameObject2.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
                        component.ID = (ulong)(uint)sceneData.ViewableDropList[index4];
                        component.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItemIcon));
                    }
                }
                int playerPpt = xcomponent2.GetPlayerPPT();
                string difficulty = XLevelDocument.GetDifficulty(playerPpt, sceneData.RecommendPower);
                this.uiBehaviour.m_SceneHint.SetText(difficulty);
                this.uiBehaviour.m_SceneRecommendPPT.SetText(string.Format("{0}{1}[-]", (object)difficulty.Substring(0, 8), (object)sceneData.RecommendPower));
                this.uiBehaviour.m_SceneMyPPT.SetText(playerPpt.ToString());
                if (this._SelectDifficult == 1U)
                {
                    string str = playerPpt < sceneData.SweepNeedPPT ? "[e30000]" : "[9ce500]";
                    if (XSingleton<XAttributeMgr>.singleton.XPlayerData != null)
                    {
                        if ((long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (long)XSingleton<XGlobalConfig>.singleton.GetInt("SweepPPTLevelLimit"))
                        {
                            this.uiBehaviour.m_SweepPPT.gameObject.SetActive(false);
                            this.uiBehaviour.m_SweepPPTName.SetActive(false);
                        }
                        else
                        {
                            this.uiBehaviour.m_SweepPPT.gameObject.SetActive(true);
                            this.uiBehaviour.m_SweepPPT.SetText(string.Format("{0}{1}[-]", (object)str, (object)sceneData.SweepNeedPPT));
                            this.uiBehaviour.m_SweepPPTName.SetActive(true);
                            this.uiBehaviour.m_SweepTicketLab.SetText(XBagDocument.BagDoc.GetItemCount(XSingleton<XGlobalConfig>.singleton.GetInt("SweepTicketId")).ToString());
                        }
                    }
                    this.uiBehaviour.m_SceneQuick10Lab.SetText(string.Format(XStringDefineProxy.GetString("SWEEP_TITLE"), (object)5));
                }
                else
                {
                    this.uiBehaviour.m_SweepPPT.SetText("");
                    this.uiBehaviour.m_SweepPPTName.SetActive(false);
                    this.uiBehaviour.m_SceneQuick10Lab.SetText(string.Format(XStringDefineProxy.GetString("SWEEP_TITLE"), (object)10));
                }
                uint key = sceneData.DayLimitGroupID;
                if (key == 0U)
                    key = sceneID;
                uint num3 = 0;
                if (xcomponent1.SceneDayEnter.TryGetValue(key, out num3))
                {
                    this._SceneRemainTime = (uint)sceneData.DayLimit - num3;
                    if ((long)sceneData.DayLimit - (long)num3 == 0L)
                    {
                        this.uiBehaviour.m_SceneQuick1.gameObject.SetActive(false);
                        this.uiBehaviour.m_SceneQuick10.gameObject.SetActive(false);
                    }
                    else
                    {
                        this.uiBehaviour.m_SceneQuick1.gameObject.SetActive(true);
                        this.uiBehaviour.m_SceneQuick10.gameObject.SetActive(true);
                    }
                }
                else
                {
                    this.uiBehaviour.m_SceneQuick1.gameObject.SetActive(true);
                    this.uiBehaviour.m_SceneQuick10.gameObject.SetActive(true);
                }
                if (rank < 3)
                {
                    this.uiBehaviour.m_SceneQuick1.gameObject.SetActive(false);
                    this.uiBehaviour.m_SceneQuick10.gameObject.SetActive(false);
                    this.uiBehaviour.m_SweepTicketGo.SetActive(false);
                    this.uiBehaviour.m_SceneFirstSSS.SetActive(true);
                    string str = "";
                    for (int index5 = 0; index5 < sceneData.FirstSSS.Count; ++index5)
                        str += XLabelSymbolHelper.FormatCostWithIcon((int)sceneData.FirstSSS[index5, 1], (XMainClient.ItemEnum)sceneData.FirstSSS[index5, 0]);
                    this.uiBehaviour.m_SceneFirstSSSReward.InputText = str;
                }
                else
                {
                    if (this._SelectDifficult == 0U)
                    {
                        this.uiBehaviour.m_SceneQuick1.gameObject.SetActive(true);
                        this.uiBehaviour.m_SceneQuick10.gameObject.SetActive(true);
                        this.uiBehaviour.m_SweepTicketGo.SetActive(false);
                    }
                    else if (XSingleton<XAttributeMgr>.singleton.XPlayerData != null)
                    {
                        if ((long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (long)XSingleton<XGlobalConfig>.singleton.GetInt("SweepPPTLevelLimit"))
                        {
                            this.uiBehaviour.m_SceneQuick1.gameObject.SetActive(false);
                            this.uiBehaviour.m_SceneQuick10.gameObject.SetActive(false);
                            this.uiBehaviour.m_SweepTicketGo.SetActive(false);
                        }
                        else
                        {
                            this.uiBehaviour.m_SceneQuick1.gameObject.SetActive(true);
                            this.uiBehaviour.m_SceneQuick10.gameObject.SetActive(true);
                            this.uiBehaviour.m_SweepTicketGo.SetActive(true);
                        }
                    }
                    this.uiBehaviour.m_SceneFirstSSS.SetActive(false);
                }
                this.uiBehaviour.m_Cost.InputText = XLabelSymbolHelper.FormatCostWithIcon(sceneData.FatigueCost[0, 1], XMainClient.ItemEnum.FATIGUE);
                this.uiBehaviour.m_SceneSoloBattleCost.InputText = XLabelSymbolHelper.FormatCostWithIcon(sceneData.FatigueCost[0, 1], XMainClient.ItemEnum.FATIGUE);
                this.uiBehaviour.m_SceneTeamBattleCost.InputText = XLabelSymbolHelper.FormatCostWithIcon(sceneData.FatigueCost[0, 1], XMainClient.ItemEnum.FATIGUE);
            }
        }

        private void OnClickItemIcon(IXUISprite spr) => XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(XBagDocument.MakeXItem((int)spr.ID), spr, false);

        private void OnSceneSelected(IXUISprite sp)
        {
            XLevelDocument xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument;
            this._SelectScene = (uint)sp.ID;
            if (this._FirstNoRankScene > 0U)
            {
                if ((int)this._SelectScene == (int)this._FirstNoRankScene)
                {
                    SceneTable.RowData sceneData1 = XSingleton<XSceneMgr>.singleton.GetSceneData(this._SelectScene);
                    if (sceneData1 == null)
                    {
                        XSingleton<XDebug>.singleton.AddErrorLog("OnSceneSelected sceneData is null");
                        return;
                    }
                    switch (xcomponent.CanLevelOpen(this._SelectScene))
                    {
                        case SceneRefuseReason.PreTask_Notfinish:
                            this.uiBehaviour.m_MainHintText.SetText(string.Format(XStringDefineProxy.GetString("LEVEl_REQUIRE_TASK"), (object)sceneData1.RequiredLevel));
                            this.uiBehaviour.m_MainHint.PlayTween(true);
                            return;
                        case SceneRefuseReason.PreScene_Notfinish:
                            SceneTable.RowData sceneData2 = XSingleton<XSceneMgr>.singleton.GetSceneData((uint)xcomponent.GetUnFinishedPreSceneID(sceneData1));
                            if (sceneData2 != null)
                                this.uiBehaviour.m_MainHintText.SetText(string.Format(XStringDefineProxy.GetString("LEVEL_REQUIRE_PRELEVEL"), (object)sceneData2.Comment));
                            this.uiBehaviour.m_MainHint.PlayTween(true);
                            return;
                        case SceneRefuseReason.ReachLimitTimes:
                            this.uiBehaviour.m_MainHintText.SetText(XStringDefineProxy.GetString("LEVEL_REACH_LIMIT_TIMES"));
                            this.uiBehaviour.m_MainHint.PlayTween(false);
                            return;
                        case SceneRefuseReason.Level_NotEnough:
                            this.uiBehaviour.m_MainHintText.SetText(string.Format(XStringDefineProxy.GetString("LEVEL_REQUIRE_LEVEL"), (object)sceneData1.RequiredLevel));
                            this.uiBehaviour.m_MainHint.PlayTween(true);
                            return;
                    }
                }
                if (this._SelectScene > this._FirstNoRankScene)
                {
                    this.uiBehaviour.m_MainHintText.SetText(string.Format(XStringDefineProxy.GetString("LEVEL_REQUIRE_DEFAULT")));
                    this.uiBehaviour.m_MainHint.PlayTween(true);
                    return;
                }
            }
            this._SetupDetailFrame(this._SelectScene);
        }

        public void OnPlayerLevelUp()
        {
            if (!this.IsVisible())
                return;
            this.SetupChapterImage();
        }

        public void OnGotSweepRes()
        {
            if (!this.IsVisible())
                return;
            this.SetupChapterImage();
        }

        public bool OnDetailClose(IXUIButton go)
        {
            this.uiBehaviour.m_SceneDetail.SetActive(false);
            return true;
        }

        public void RefreshHardLeftCount()
        {
            XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
            int dayCount = specificDocument.GetDayCount(TeamLevelType.TeamLevelAbyss);
            int dayMaxCount = specificDocument.GetDayMaxCount(TeamLevelType.TeamLevelAbyss);
            this.uiBehaviour.m_HardLeftCount1.SetText(string.Format("{0}/{1}", (object)dayCount, (object)dayMaxCount));
            if (this._welfareDoc.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Adventurer))
            {
                int num1 = 0;
                PayMemberTable.RowData memberPrivilegeConfig = this._welfareDoc.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Adventurer);
                if (memberPrivilegeConfig != null)
                    num1 = memberPrivilegeConfig.AbyssCount;
                int num2 = 0;
                if (this._welfareDoc.PayMemberPrivilege != null)
                    num2 = this._welfareDoc.PayMemberPrivilege.usedAbyssCount;
                if (num2 >= num1)
                {
                    this.uiBehaviour.m_HardLeftCount0.SetText(string.Format("{0}/{1}", (object)dayCount, (object)dayMaxCount));
                    this.uiBehaviour.m_HardLeftCount1.SetText(string.Format("{0}/{1}", (object)dayCount, (object)dayMaxCount));
                }
                else
                {
                    this.uiBehaviour.m_HardLeftCount0.SetText(string.Format("[ffb400][c]{0}[/c][-]/{1}", (object)dayCount, (object)dayMaxCount));
                    this.uiBehaviour.m_HardLeftCount1.SetText(string.Format("[ffb400][c]{0}[/c][-]/{1}", (object)dayCount, (object)dayMaxCount));
                }
            }
            else
            {
                this.uiBehaviour.m_HardLeftCount0.SetText(string.Format("{0}/{1}", (object)dayCount, (object)dayMaxCount));
                this.uiBehaviour.m_HardLeftCount1.SetText(string.Format("{0}/{1}", (object)dayCount, (object)dayMaxCount));
            }
        }

        private void _OnAddHardCountClicked(IXUISprite iSp) => DlgBase<XBuyCountView, XBuyCountBehaviour>.singleton.ActiveShow(TeamLevelType.TeamLevelAbyss);

        private bool OnShopBtnClick(IXUIButton btn)
        {
            SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("AbyssTeamShopLevel", true);
            List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("AbyssTeamShopType");
            int num = 0;
            if (XSingleton<XAttributeMgr>.singleton.XPlayerData != null)
                num = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
            for (int index = 0; index < (int)sequenceList.Count; ++index)
            {
                if (num >= sequenceList[index, 0] && num <= sequenceList[index, 1])
                {
                    XSysDefine xsysDefine = (XSysDefine)(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Mall_MystShop) + intList[index]);
                    if (XSingleton<XGameSysMgr>.singleton.IsSystemOpened(xsysDefine))
                    {
                        DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(xsysDefine);
                        return true;
                    }
                    int sysOpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(xsysDefine));
                    XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("SHOP_OPEN_LEVEL"), (object)sysOpenLevel), "fece00");
                    return false;
                }
            }
            XSingleton<XDebug>.singleton.AddErrorLog("Can't find player level state from golbalconfig by AbyssTeamShop. level = ", num.ToString());
            return true;
        }

        private struct FrameCache
        {
            public IUIDummy snapShot;
            public GameObject fx;

            public void Clear()
            {
                this.snapShot = (IUIDummy)null;
                this.fx = (GameObject)null;
            }

            public void Copy(ref DungeonSelect.FrameCache fc)
            {
                this.snapShot = fc.snapShot;
                if ((Object)this.fx != (Object)null)
                    this.fx.SetActive(false);
                this.fx = fc.fx;
            }
        }
    }
}
