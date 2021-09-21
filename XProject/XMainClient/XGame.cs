// Decompiled with JetBrains decompiler
// Type: XMainClient.XGame
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using ProtoBuf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
    public class XGame : XSingleton<XGame>
    {
        public static int RoleCount;
        private XStage _stage = (XStage)null;
        private XStage _old_stage = (XStage)null;
        private List<XBaseSingleton> _singletons = (List<XBaseSingleton>)null;
        private XDocuments _doc = (XDocuments)null;
        private int _nSyncMode = 0;
        private bool _show_build_log = true;
        private int _fps_count = 0;
        private float _fps = (float)XShell.TargetFrame;
        private float _fpsAvg = (float)XShell.TargetFrame;
        private float _fps_interval = 0.16667f;
        private bool _calc_fps = true;
        private float _fps_real_time = 0.0f;
        private int _fpsCalcCount = 0;
        private float _fpsAcc = 0.0f;
        private bool _isgmaccount = false;
        private ulong _player_id = 0;
        private int _millisecondsToWait = 0;
        private float _lastExitClickTime = 0.0f;
        private XTimerMgr.ElapsedEventHandler _fpsHandler = (XTimerMgr.ElapsedEventHandler)null;
        private XTimerMgr.ElapsedEventHandler _innerSwitchCb = (XTimerMgr.ElapsedEventHandler)null;
        public bool notLoadScene = true;
        public bool networkRun = true;
        public bool switchScene = false;
        public static bool EditorMode = false;

        public bool IsGMAccount
        {
            get => this._isgmaccount;
            set => this._isgmaccount = value;
        }

        public bool ShowBuildLog
        {
            get => this._show_build_log;
            set => this._show_build_log = value;
        }

        public ulong PlayerID
        {
            get => this._player_id;
            set => this._player_id = value;
        }

        public bool CalcFps => this._calc_fps;

        public float Fps => this._fps;

        public float FpsAvg => this._fpsAvg;

        public XStage CurrentStage => this._stage;

        public bool StageReady => this._stage != null && this._stage.IsEntered;

        internal XDocuments Doc => this._doc;

        public int SyncModeValue
        {
            get => this._nSyncMode;
            set
            {
                this._nSyncMode = value;
                Physics.IgnoreLayerCollision(10, 10, this.SyncMode);
                Physics.IgnoreLayerCollision(21, 13, this.SyncMode);
            }
        }

        public bool SyncMode => this._nSyncMode == 1;

        public XGame()
        {
            this._singletons = new List<XBaseSingleton>();
            this._singletons.Add((XBaseSingleton)XSingleton<BufferPoolMgr>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<ScriptCode>.singleton);
            XSingleton<XStringTable>.singleton.Uninit();
            this._singletons.Add((XBaseSingleton)XSingleton<XStringTable>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XInput>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XServerTimeMgr>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XGlobalConfig>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XGameUI>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XSceneMgr>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XBuffTemplateManager>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XAudioMgr>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XSkillEffectMgr>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XPostEffectMgr>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XLevelFinishMgr>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XCombat>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XProfessionSkillMgr>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XGameSysMgr>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XOperationRecord>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XLevelDoodadMgr>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XTutorialMgr>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XEntityMgr>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XScene>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XForbidWordMgr>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XSkillFactory>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XCutScene>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XBulletMgr>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XAttributeMgr>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XEventMgr>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XPowerPointCalculator>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<UIManager>.singleton);
            this._singletons.Add((XBaseSingleton)XSingleton<XLevelSpawnMgr>.singleton);
            this._fpsHandler = new XTimerMgr.ElapsedEventHandler(this.CalculateFPS);
            this._innerSwitchCb = new XTimerMgr.ElapsedEventHandler(this.InnerSwitch);
            this._doc = new XDocuments();
        }

        public IEnumerator Awake()
        {
            XLinkTimeStamp.FetchBuildDateTime();
            this.TriggerFps();
            PtcRegister.RegistProtocol();
            XSingleton<XResourceLoaderMgr>.singleton.LoadServerCurve("Table/Curve");
            XSingleton<XClientNetwork>.singleton.Initialize();
            CVSReader.Init();
            int i = 0;
            for (i = 0; i < this._singletons.Count; ++i)
            {
                int tryCount = 0;
                while (!this._singletons[i].Init())
                {
                    ++tryCount;
                    if (tryCount % 1000 == 0)
                        Thread.Sleep(1);
                }
            }
            GC.Collect();
            i = 0;
            XBagDocument.Execute(new OnLoadedCallback(XBagDocument.OnTableLoaded));
            while (!XBagDocument.AsyncLoader.IsDone)
            {
                if (++i % 1000 == 0)
                    Thread.Sleep(1);
            }
            this._doc.CtorLoad();
            this._doc.Initilize(0);
            Serializer.SetMultiThread(XSingleton<XGlobalConfig>.singleton.GetSettingEnum(ESettingConfig.EMultiThreadProtoBuf));
            Serializer.SetSkipProtoIgnore(XSingleton<XGlobalConfig>.singleton.GetSettingEnum(ESettingConfig.ESkipProtoIgnore));
            XAutoFade.MakeBlack(true);
            XOptionsDocument optDoc = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
            if (optDoc != null)
            {
                int value = optDoc.GetValue(XOptionsDefine.OD_SMOOTH);
                XSingleton<XGameUI>.singleton.SetUIOptOption(false, value == 1, false, false);
            }
            if (XSingleton<XGlobalConfig>.singleton.GetSettingEnum(ESettingConfig.EApm))
                XSingleton<XUpdater.XUpdater>.singleton.XPlatform.InitApm();
            XResourceLoaderMgr.UseCurveTable = XSingleton<XGlobalConfig>.singleton.GetSettingEnum(ESettingConfig.ELoadCurveTable);
            XSingleton<XResourceLoaderMgr>.singleton.DelayLoad = XSingleton<XGlobalConfig>.singleton.GetSettingEnum(ESettingConfig.EDelayLoad);
            XFxMgr.FilterFarFx = XSingleton<XGlobalConfig>.singleton.GetSettingEnum(ESettingConfig.EFilterFarFx);
            yield return (object)null;
        }

        public override bool Init()
        {
            XQualitySetting.InitResolution();
            Application.targetFrameRate = Application.platform != RuntimePlatform.WindowsEditor && Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsPlayer ? XShell.TargetFrame : 60;
            XAutoFade.FadeIn(0.0f, true);
            this.SwitchTo(EXStage.Login, 3U);
            return true;
        }

        public override void Uninit()
        {
            this.SwitchTo(EXStage.Null, 0U);
            this._doc.Uninitilize();
            for (int index = this._singletons.Count - 1; index >= 0; --index)
                this._singletons[index].Uninit();
            XSingleton<XClientNetwork>.singleton.Close();
            XSingleton<XInterfaceMgr>.singleton.Uninit();
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetNativePlugin()?.CloseHooks();
        }

        public void UpdateNetwork()
        {
            if (!this.networkRun)
                return;
            XSingleton<XClientNetwork>.singleton.Update();
        }

        public void PreUpdate(float fDeltaT)
        {
            if (!this.StageReady || !this.notLoadScene)
                return;
            XSingleton<XInput>.singleton.Update();
            this._stage.PreUpdate(fDeltaT);
        }

        public void Update(float fDeltaT)
        {
            if (this.StageReady && this.notLoadScene)
            {
                this._stage.Update(fDeltaT);
                this._doc.Update(fDeltaT);
                XSingleton<UIManager>.singleton.Update(fDeltaT);
            }
            if (this._calc_fps)
                ++this._fps_count;
            if (!Input.GetKey(KeyCode.F3))
                return;
            XSingleton<X3DTouchMgr>.singleton.OnProcess3DTouch();
        }

        private void CheckExit()
        {
            if (!Input.GetKeyDown(KeyCode.Escape))
                return;
            if ((double)Time.time - (double)this._lastExitClickTime < (double)float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("DoubleClickExitTime")))
                Application.Quit();
            XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("EXIT_GAME_TIP"), "fece00");
            this._lastExitClickTime = Time.time;
        }

        public void PostUpdate(float fDeltaT)
        {
            if (!this.StageReady || !this.notLoadScene)
                return;
            this._stage.PostUpdate(fDeltaT);
            this._doc.PostUpdate(fDeltaT);
            XSingleton<UIManager>.singleton.PostUpdate(fDeltaT);
        }

        public void SwitchTo(EXStage eStage, uint sceneID)
        {
            if ((int)sceneID == (int)XSingleton<XScene>.singleton.SceneID && this.CurrentStage.Stage == eStage && sceneID != 3U && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_TOWER)
                XSingleton<XDebug>.singleton.AddLog("switch to the same scene id ", sceneID.ToString(), " with same stage.");
            if (eStage == EXStage.Null || sceneID == 0U)
            {
                this._old_stage = this._stage;
                this._old_stage.OnLeaveStage(EXStage.Null);
                this._old_stage.OnLeaveScene(false);
                XSingleton<XScene>.singleton.OnLeaveScene(false);
                this._old_stage = (XStage)null;
            }
            else
            {
                uint num1 = (uint)(XFastEnumIntEqualityComparer<EXStage>.ToInt(eStage) << 24) | sceneID;
                if (this._stage == null || (int)sceneID != (int)XSingleton<XScene>.singleton.SceneID || XSingleton<XSceneMgr>.singleton.GetSceneSwitchToSelf(sceneID))
                    XSingleton<XScene>.singleton.UntriggerScene();
                if ((eStage == EXStage.World || eStage == EXStage.Hall) && XSingleton<XScene>.singleton.TurnToTransfer(sceneID))
                {
                    XAutoFade.FadeOut(0.5f);
                    int num2 = (int)XSingleton<XTimerMgr>.singleton.SetTimer(1f, this._innerSwitchCb, (object)(uint)((int)num1 | int.MinValue));
                }
                else
                {
                    float sceneDelayTransfer = XSingleton<XSceneMgr>.singleton.GetSceneDelayTransfer(sceneID);
                    if ((double)sceneDelayTransfer > 0.0)
                    {
                        XAutoFade.FadeOut(sceneDelayTransfer);
                        int num3 = (int)XSingleton<XTimerMgr>.singleton.SetTimer(sceneDelayTransfer + 0.03f, this._innerSwitchCb, (object)num1);
                    }
                    else
                        this.InnerSwitch((object)num1);
                }
            }
        }

        public XStage CreateSpecifiecStage(EXStage eStage)
        {
            switch (eStage)
            {
                case EXStage.Login:
                    return (XStage)XStage.CreateSpecificStage<XLoginStage>();
                case EXStage.SelectChar:
                    return (XStage)XStage.CreateSpecificStage<XSelectcharStage>();
                case EXStage.World:
                    return (XStage)XStage.CreateSpecificStage<XWorldStage>();
                case EXStage.Hall:
                    return (XStage)XStage.CreateSpecificStage<XHallStage>();
                default:
                    return (XStage)null;
            }
        }

        public void TriggerFps()
        {
            if (!this._calc_fps)
                return;
            int num = (int)XSingleton<XTimerMgr>.singleton.SetGlobalTimer(this._fps_interval, this._fpsHandler, (object)null);
        }

        private void InnerSwitch(object o)
        {
            this.switchScene = true;
            uint num1 = (uint)o;
            bool transfer = num1 >> 31 > 0U;
            uint num2 = num1 & 16777215U;
            EXStage eStage = (EXStage)(num1 >> 24 & (uint)sbyte.MaxValue);
            if (transfer)
                XAutoFade.MakeBlack();
            if (XSingleton<XScene>.singleton.SceneID == 100U)
                XAutoFade.FadeIn(0.2f);
            this._old_stage = this._stage;
            this._stage = this._old_stage == null || eStage != this._old_stage.Stage ? this.CreateSpecifiecStage(eStage) : this._old_stage;
            if (this._old_stage != null)
            {
                this._old_stage.OnLeaveStage(this._stage.Stage);
                if ((int)num2 != (int)XSingleton<XScene>.singleton.SceneID || XSingleton<XSceneMgr>.singleton.GetSceneSwitchToSelf(num2))
                {
                    XSingleton<XGameUI>.singleton.m_uiTool.EnableUILoadingUpdate(false);
                    this._old_stage.OnLeaveScene(transfer);
                    if (XSingleton<XScene>.singleton.SceneID > 0U)
                        XSingleton<XScene>.singleton.OnLeaveScene(transfer);
                    XSingleton<XScene>.singleton.LoadSceneAsync(num2, eStage, !transfer, transfer);
                }
                else
                {
                    this.OnEnterStage();
                    this.switchScene = false;
                }
            }
            else
                XSingleton<XScene>.singleton.LoadSceneAsync(num2, eStage, true, false);
        }

        private void LockFps(int goal)
        {
            if ((double)(1f / (float)goal - Time.smoothDeltaTime) > 0.0)
                ++this._millisecondsToWait;
            else
                --this._millisecondsToWait;
            Thread.Sleep((int)Mathf.Clamp((float)this._millisecondsToWait, 0.0f, (float)(1.0 / (double)goal * 1000.0)));
        }

        private void CalculateFPS(object o)
        {
            float realtimeSinceStartup = Time.realtimeSinceStartup;
            this._fps = (float)this._fps_count / (realtimeSinceStartup - this._fps_real_time);
            ++this._fpsCalcCount;
            this._fpsAcc += this._fps;
            if (this._fpsCalcCount >= 20)
            {
                this._fpsAvg = this._fpsAcc / (float)this._fpsCalcCount;
                this._fpsCalcCount = 0;
                this._fpsAcc = 0.0f;
            }
            if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.MainDoc != null)
            {
                if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.MainDoc.GetFpsState == XMainInterfaceDocument.GetFps.start)
                {
                    DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.MainDoc.FpsStartTime = realtimeSinceStartup;
                    DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.MainDoc.PeakFps = this._fps;
                    DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.MainDoc.FpsCount = this._fps_count;
                    DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.MainDoc.GetFpsState = XMainInterfaceDocument.GetFps.running;
                }
                else if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.MainDoc.GetFpsState == XMainInterfaceDocument.GetFps.running)
                {
                    DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.MainDoc.PeakFps = Math.Max(this._fps, DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.MainDoc.PeakFps);
                    DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.MainDoc.FpsCount += this._fps_count;
                }
            }
            this._fps_real_time = realtimeSinceStartup;
            this._fps_count = 0;
            int num = (int)XSingleton<XTimerMgr>.singleton.SetGlobalTimer(this._fps_interval, this._fpsHandler, (object)null);
        }

        private void OnEnterStage() => this._stage.OnEnterStage(this._old_stage != null ? this._old_stage.Stage : EXStage.Null);

        public void OnEnterScene(uint sceneid, bool bTransfer = false)
        {
            bool bHall = XSingleton<XSceneMgr>.singleton.GetSceneType(sceneid) == SceneType.SCENE_HALL || XSingleton<XSceneMgr>.singleton.GetSceneType(sceneid) == SceneType.SCENE_GUILD_HALL || XSingleton<XSceneMgr>.singleton.GetSceneType(sceneid) == SceneType.SCENE_LEISURE;
            XSingleton<XScene>.singleton.GameCamera.PreInstall(GameObject.Find("Main Camera"), bHall);
            XSingleton<XScene>.singleton.OnEnterScene(sceneid, bTransfer);
            this._stage.OnEnterScene(sceneid, bTransfer);
            XSingleton<XScene>.singleton.GameCamera.Installed();
            XSingleton<XScene>.singleton.AssociatedCamera = XSingleton<XScene>.singleton.GameCamera.UnityCamera;
            XSingleton<XAIGeneralMgr>.singleton.InitAIMgr();
            this.OnEnterStage();
        }

        public string GetSyncModeString()
        {
            if (this._nSyncMode == 0)
                return " Solo Mode ";
            if (this._nSyncMode == 1)
                return " OnLine Mode ";
            return this._nSyncMode == 2 ? " Mixed Mode " : "Unknown";
        }

        public static void SetVisible(GameObject go, int layer)
        {
            go.layer = layer;
            for (int index = 0; index < go.transform.childCount; ++index)
                XGame.SetVisible(go.transform.GetChild(index).gameObject, layer);
        }
    }
}
