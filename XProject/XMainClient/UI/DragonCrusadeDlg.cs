// Decompiled with JetBrains decompiler
// Type: XMainClient.UI.DragonCrusadeDlg
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
    internal class DragonCrusadeDlg : DlgBase<DragonCrusadeDlg, DragonCrusadeBehavior>
    {
        private XDragonCrusadeDocument mDoc = (XDragonCrusadeDocument)null;
        private GameObject goDragonExpedition = (GameObject)null;
        private IXDragonExpedition ixDragonExpedition = (IXDragonExpedition)null;
        private XFx _FxFirework = (XFx)null;
        private const int MAX_RANK = 3;
        public Dictionary<uint, GameObject> listBillBoards = new Dictionary<uint, GameObject>();
        private Vector3 localDefaultScale = new Vector3(-0.02f, 0.02f, 0.02f);
        private System.Action<bool> mSyncDoneCallBack = (System.Action<bool>)null;
        private bool mSyncLoading = false;
        private bool mDoneFinish = false;
        private float intertime = 0.5f;
        private LoadCallBack mDragonExpeditionLoadTask = (LoadCallBack)null;
        private Dictionary<int, XDummy> m_AvatarDummys = new Dictionary<int, XDummy>();

        public override string fileName => "DragonCrusade/DragonCrusadeDlg";

        public override bool hideMainMenu => true;

        public override bool pushstack => true;

        public override bool autoload => true;

        public bool isHallUI => XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;

        public override bool fullscreenui => true;

        public override int sysid => 50;

        protected override void OnLoad()
        {
            base.OnLoad();
            this.mDoc = XSingleton<XGame>.singleton.Doc.GetXComponent(XDragonCrusadeDocument.uuID) as XDragonCrusadeDocument;
            if (this.mDragonExpeditionLoadTask != null)
                return;
            this.mDragonExpeditionLoadTask = new LoadCallBack(this.LoadFinish);
        }

        protected override void Init()
        {
            base.Init();
            this.uiBehaviour.goLoadingTxt.SetText(XStringDefineProxy.GetString("DragonLoadMessage"));
        }

        private void LoadFinish(UnityEngine.Object obj, object cbOjb)
        {
            if (!this.IsLoaded())
                return;
            this.goDragonExpedition = obj as GameObject;
            this.LoadPrefabSyncDone();
        }

        public override void RegisterEvent()
        {
            base.RegisterEvent();
            this.m_uiBehaviour.slideSprite.RegisterSpriteDragEventHandler(new SpriteDragEventHandler(this.OnMonsterDrag));
            this.m_uiBehaviour.slideSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMouseClick));
            this.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
            this.m_uiBehaviour.m_myRankSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRankInfo));
            this.uiBehaviour.m_closed.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
            this.uiBehaviour.m_leftBtn.ID = 1UL;
            this.uiBehaviour.m_rightBtn.ID = 2UL;
        }

        public bool OnHelpClicked(IXUIButton button)
        {
            DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_DragonCrusade);
            return true;
        }

        protected override void OnHide()
        {
            base.OnHide();
            if (this.ixDragonExpedition == null)
                return;
            this.ixDragonExpedition.GetDragonCamera().enabled = false;
        }

        protected override void OnShow()
        {
            base.OnShow();
            this.Alloc3DAvatarPool(nameof(DragonCrusadeDlg));
            if (this.ixDragonExpedition == null)
                return;
            this.ixDragonExpedition.GetDragonCamera().enabled = true;
        }

        protected override void OnUnload()
        {
            this.mDoneFinish = false;
            this.mSyncLoading = false;
            if (this._FxFirework != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._FxFirework);
            this._FxFirework = (XFx)null;
            this.DeleteAvatar();
            this.UnloadPrefab();
            foreach (KeyValuePair<uint, GameObject> listBillBoard in this.listBillBoards)
                XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroy((UnityEngine.Object)listBillBoard.Value);
            this.listBillBoards.Clear();
            base.OnUnload();
        }

        public override void StackRefresh()
        {
            base.StackRefresh();
            this.Alloc3DAvatarPool(nameof(DragonCrusadeDlg));
            if (this.ixDragonExpedition == null)
                return;
            this.ixDragonExpedition.GetDragonCamera().enabled = true;
        }

        public override void OnXNGUIClick(GameObject obj, string path) => base.OnXNGUIClick(obj, path);

        private void LoadPrefab()
        {
        }

        private void UnloadPrefab()
        {
            this.ixDragonExpedition = (IXDragonExpedition)null;
            XResourceLoaderMgr.SafeDestroy(ref this.goDragonExpedition);
        }

        protected void OnMonsterDrag(IXUIButton button, Vector2 delta)
        {
            delta = button.ID != 1UL ? Vector2.one * (float)-Screen.width : Vector2.one * (float)Screen.width;
            if (this.ixDragonExpedition == null)
                return;
            this.ixDragonExpedition.Drag(delta.x);
        }

        protected bool OnMonsterDrag(Vector2 delta)
        {
            if (this.ixDragonExpedition == null)
                return true;
            this.ixDragonExpedition.Drag(delta.x);
            return true;
        }

        protected void OnMouseClick(IXUISprite sp)
        {
            if (this.ixDragonExpedition == null)
                return;
            GameObject gameObject = this.ixDragonExpedition.Click();
            if (!((UnityEngine.Object)gameObject != (UnityEngine.Object)null))
                return;
            this.OnGateInfo(gameObject.name);
        }

        private bool OnClose(IXUIButton btn)
        {
            this.SetVisible(false, true);
            XSingleton<XTutorialHelper>.singleton.DragonCrusadeOpen = false;
            return true;
        }

        private void OnGateInfo(string gatename)
        {
            DlgBase<DragonCrusadeGateDlg, DragonCrusadeGateBehavior>.singleton.SetVisibleWithAnimation(true, (DlgBase<DragonCrusadeGateDlg, DragonCrusadeGateBehavior>.OnAnimationOver)null);
            for (int index = 0; index < XDragonCrusadeDocument._DragonCrusageGateDataInfo.Count; ++index)
            {
                DragonCrusageGateData data = XDragonCrusadeDocument._DragonCrusageGateDataInfo[index];
                if (data.expData.ResName == gatename)
                {
                    DlgBase<DragonCrusadeGateDlg, DragonCrusadeGateBehavior>.singleton.SetVisible(true, true);
                    DlgBase<DragonCrusadeGateDlg, DragonCrusadeGateBehavior>.singleton.FreshInfo(data);
                }
            }
        }

        public void OnRankInfo(IXUISprite uiSprite)
        {
            DlgBase<DragonCrusadeRankDlg, DragonCrusadeRankBehavior>.singleton.SetVisible(true, true);
            DlgBase<DragonCrusadeRankDlg, DragonCrusadeRankBehavior>.singleton.RefreshRankWindow(this.mDoc.oResRank);
        }

        public void RefreshRank(DERankRes oRes)
        {
            for (int index1 = 0; index1 < 3; ++index1)
            {
                Transform transform = this.uiBehaviour.transform.Find("Bg/MyRank/ScrollView/Tpl" + (index1 + 1).ToString());
                IXUILabel component1 = transform.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
                IXUILabel component2 = transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
                IXUILabel component3 = transform.FindChild("Reward").GetComponent("XUILabel") as IXUILabel;
                IXUISprite component4 = transform.transform.FindChild("RankImage").GetComponent("XUISprite") as IXUISprite;
                DERank deRank = index1 < oRes.ranks.Count ? oRes.ranks[index1] : (DERank)null;
                if (deRank != null)
                {
                    component1.SetText("No." + (object)deRank.rank);
                    if (index1 < 3)
                    {
                        component4.SetSprite("N" + (object)(index1 + 1));
                        component4.SetVisible(true);
                        component1.SetVisible(false);
                    }
                    else
                    {
                        component4.SetVisible(false);
                        component1.SetVisible(true);
                    }
                    component2.SetText(deRank.rolename);
                    string empty = string.Empty;
                    for (int index2 = 0; index2 < deRank.reward.Count; ++index2)
                    {
                        ItemBrief itemBrief = deRank.reward[index2];
                        XBagDocument.GetItemConf((int)itemBrief.itemID);
                        empty += itemBrief.itemCount.ToString();
                    }
                    component3.gameObject.SetActive(true);
                    component3.SetText(empty);
                }
                else
                {
                    component4.SetVisible(false);
                    component2.SetText("");
                    component1.SetText("");
                    component3.SetText("");
                    component3.gameObject.SetActive(false);
                }
            }
            bool flag = false;
            for (int index3 = 0; index3 < oRes.ranks.Count; ++index3)
            {
                DERank rank = oRes.ranks[index3];
                if ((long)rank.roleID == (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID)
                {
                    flag = true;
                    this.SetXUILable("Bg/MyRank/My/Rank", rank.rank.ToString());
                    this.SetXUILable("Bg/MyRank/My/Name", XSingleton<XAttributeMgr>.singleton.XPlayerData.Name);
                    string empty = string.Empty;
                    for (int index4 = 0; index4 < rank.reward.Count; ++index4)
                    {
                        ItemBrief itemBrief = rank.reward[index4];
                        XBagDocument.GetItemConf((int)itemBrief.itemID);
                        empty += itemBrief.itemCount.ToString();
                    }
                    this.SetXUILable("Bg/MyRank/My/Reward", empty);
                    if (index3 < 3)
                    {
                        this.uiBehaviour.mMyRank.SetActive(false);
                        break;
                    }
                    break;
                }
            }
            if (flag)
                return;
            this.SetXUILable("Bg/MyRank/My/Rank", "");
            this.SetXUILable("Bg/MyRank/My/Name", "");
            this.SetXUILable("Bg/MyRank/My/Reward", "");
        }

        private void InitData()
        {
            for (int index = 0; index < XDragonCrusadeDocument._DragonCrusageGateDataInfo.Count; ++index)
            {
                DragonCrusageGateData data = XDragonCrusadeDocument._DragonCrusageGateDataInfo[index];
                Transform go1 = this.ixDragonExpedition.GetGO(data.expData.ResName);
                if (!((UnityEngine.Object)go1 == (UnityEngine.Object)null))
                {
                    GameObject gameObject1 = (GameObject)null;
                    if (!this.listBillBoards.TryGetValue(data.SceneID, out gameObject1))
                    {
                        GameObject gameObject2 = this.RefreshGateEnter(data, go1.gameObject);
                        this.listBillBoards.Add(data.SceneID, gameObject2);
                    }
                    if ((int)XDragonCrusadeDocument.SectonChapterMax[data.Chapter] == (int)data.expData.ChapterID[1])
                    {
                        GameObject go2 = new GameObject("Snap");
                        go2.transform.parent = go1.gameObject.transform;
                        int num = data.expData.SnapPos == null ? 0 : (data.expData.SnapPos.Length == 3 ? 1 : 0);
                        go2.transform.localPosition = num == 0 ? new Vector3(0.1f, -0.26f, -0.49f) : new Vector3(data.expData.SnapPos[0], data.expData.SnapPos[1], data.expData.SnapPos[2]);
                        go2.transform.localEulerAngles = new Vector3(0.0f, 20f, 0.0f);
                        go2.transform.localScale = Vector3.one * 1.5f;
                        this.CreateAvatar(XSingleton<XUpdater.XUpdater>.singleton.XPlatform.AddComponent(go2, EComponentType.EUIDummy) as IUIDummy, data);
                    }
                }
            }
        }

        private void UpdateBillBoard()
        {
            foreach (KeyValuePair<uint, GameObject> listBillBoard in this.listBillBoards)
            {
                GameObject gameObject = listBillBoard.Value;
                Vector3 normalized = (gameObject.transform.position - this.ixDragonExpedition.GetDragonCamera().transform.position).normalized;
                gameObject.transform.rotation *= Quaternion.LookRotation(normalized);
            }
        }

        private GameObject RefreshGateEnter(DragonCrusageGateData data, GameObject obj)
        {
            uint sceneId = data.SceneID;
            GameObject fromPrefab = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Billboard/DragonCrusadeBillboard") as GameObject;
            XSingleton<UiUtility>.singleton.AddChild(obj, fromPrefab);
            fromPrefab.name = data.SceneID.ToString() + "_" + data.expData.ResName;
            fromPrefab.transform.localScale = this.localDefaultScale;
            fromPrefab.transform.position = obj.transform.position;
            (fromPrefab.transform.Find("Name").GetComponent("XUILabel") as IXUILabel).SetText(data.sceneData.Comment);
            return fromPrefab;
        }

        public void RefreshProgressFromNet()
        {
            if (!this.mDoneFinish)
                return;
            this.RefreshProgress();
        }

        public void RefreshProgressSync(System.Action<bool> done)
        {
            if (this.ixDragonExpedition != null)
            {
                if (done != null)
                    done(true);
                XSingleton<XTutorialHelper>.singleton.DragonCrusadeOpen = true;
            }
            else
            {
                if (this.mSyncLoading)
                    return;
                this.LoadPrefabSync(done);
            }
        }

        private void LoadPrefabSync(System.Action<bool> done)
        {
            this.uiBehaviour.goLoading.SetActive(true);
            this.mSyncLoading = true;
            this.mDoneFinish = false;
            this.mSyncDoneCallBack = done;
            XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefabAsync("Common/DragonExpedition", this.mDragonExpeditionLoadTask, (object)null);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (!this.mSyncLoading)
                return;
            if (!this.mSyncLoading)
                ;
            if ((double)this.intertime > 0.0)
            {
                this.intertime -= Time.deltaTime;
            }
            else
            {
                this.intertime = 0.5f;
                if (!this.mSyncLoading || !this.mDoneFinish)
                    return;
                if (this.mDragonExpeditionLoadTask != null)
                    this.mDragonExpeditionLoadTask = (LoadCallBack)null;
                this.uiBehaviour.goLoading.SetActive(false);
                this.mSyncLoading = false;
            }
        }

        private void LoadPrefabSyncDone()
        {
            this.ixDragonExpedition = this.goDragonExpedition.GetComponent("XDragonExpedition") as IXDragonExpedition;
            this._FxFirework = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_lzy_gk");
            this.InitData();
            this.RefreshProgress();
            this.mDoneFinish = true;
            if (this.mSyncDoneCallBack != null)
                this.mSyncDoneCallBack(true);
            this.mSyncDoneCallBack = (System.Action<bool>)null;
            if (this.ixDragonExpedition != null)
                this.ixDragonExpedition.GetDragonCamera().enabled = true;
            XSingleton<XTutorialHelper>.singleton.DragonCrusadeOpen = true;
        }

        private void RefreshProgress()
        {
            GameObject gameObject = (GameObject)null;
            for (int index = 0; index < XDragonCrusadeDocument._DragonCrusageGateDataInfo.Count; ++index)
            {
                DragonCrusageGateData dragonCrusageGateData = XDragonCrusadeDocument._DragonCrusageGateDataInfo[index];
                DEProgress deProgress = dragonCrusageGateData.deProgress;
                if (this.listBillBoards.TryGetValue(deProgress.sceneID, out gameObject))
                {
                    Transform child = gameObject.transform.FindChild("StageConquered");
                    Transform transform = gameObject.transform.Find("BossHP");
                    (transform.GetComponent("XUIProgress") as IXUIProgress).value = (float)deProgress.bossavghppercent / 100f;
                    (gameObject.transform.Find("BossHP/Percent").GetComponent("XUILabel") as IXUILabel).SetText(deProgress.bossavghppercent.ToString() + "%");
                    switch (dragonCrusageGateData.deProgress.state)
                    {
                        case DEProgressState.DEPS_FINISH:
                            transform.localScale = Vector3.zero;
                            child.gameObject.SetActive(true);
                            this.ixDragonExpedition.SetLimitPos(dragonCrusageGateData.expData.LimitPos);
                            Renderer component = this.ixDragonExpedition.GetGO(dragonCrusageGateData.expData.ResName).GetComponent<Renderer>();
                            component.material = new Material(component.sharedMaterial)
                            {
                                shader = ShaderManager._transparentGrayMaskRNoLight,
                                renderQueue = 3002
                            };
                            break;
                        case DEProgressState.DEPS_FIGHT:
                            this.ixDragonExpedition.SetLimitPos(dragonCrusageGateData.expData.LimitPos);
                            this._FxFirework.Play(gameObject.transform.position, Quaternion.identity, Vector3.one);
                            transform.localScale = Vector3.one;
                            child.gameObject.SetActive(false);
                            if ((UnityEngine.Object)gameObject.transform.parent != (UnityEngine.Object)null)
                            {
                                this.ixDragonExpedition.Assign(gameObject.transform.parent.localPosition.x);
                                break;
                            }
                            break;
                        case DEProgressState.DEPS_NOTOPEN:
                            child.gameObject.SetActive(false);
                            transform.localScale = Vector3.zero;
                            break;
                    }
                }
                this.SetXUILable("Bg/ChallengeCount/Value", string.Format("{0}/{1}", (object)dragonCrusageGateData.leftcount, (object)dragonCrusageGateData.allcount));
            }
        }

        private void CreateAvatar(IUIDummy snapShot, DragonCrusageGateData data)
        {
            XEntityStatistics.RowData byId = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(data.expData.BossID);
            XEntityPresentation.RowData byPresentId = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byId.PresentID);
            if (this.m_AvatarDummys.ContainsKey((int)data.expData.ChapterID[0]))
                return;
            XDummy commonEntityDummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, byId.PresentID, snapShot, (XDummy)null, 25f);
            commonEntityDummy.Scale = byPresentId.UIAvatarScale;
            commonEntityDummy.EngineObject.SetLocalPRS(Vector3.zero, true, Quaternion.identity, true, Vector3.one * 0.3f, true);
            this.m_AvatarDummys.Add((int)data.expData.ChapterID[0], commonEntityDummy);
        }

        private void DeleteAvatar()
        {
            this.Return3DAvatarPool();
            this.m_AvatarDummys.Clear();
        }

        private class DragonExpeditionLoadTask
        {
            private DragonCrusadeDlg mDlg;

            public DragonExpeditionLoadTask(DragonCrusadeDlg dlg) => this.mDlg = dlg;

            public void LoadFinish(UnityEngine.Object obj)
            {
                if (this.mDlg == null)
                    return;
                this.mDlg.goDragonExpedition = obj as GameObject;
                this.mDlg.LoadPrefabSyncDone();
                this.mDlg = (DragonCrusadeDlg)null;
            }
        }
    }
}
