// Decompiled with JetBrains decompiler
// Type: XMainClient.XSceneLoader
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    public sealed class XSceneLoader : MonoBehaviour
    {
        private AsyncOperation _op = (AsyncOperation)null;
        private XSceneLoader.AsyncSceneBuildRequest _asbr = (XSceneLoader.AsyncSceneBuildRequest)null;
        private uint _loading_scene_id = 0;
        private EXStage _loading_scene_stage = EXStage.Null;
        private bool _enabled = false;
        private bool _prograss = true;
        private float _sub_progress = 0.0f;
        private float _current_progress = 0.0f;
        private float _target_progress = 0.0f;
        private bool _DelayLoadCache = true;
        private bool _LoadingSpectateScene = false;

        public void LoadScene(
          string scene,
          EXStage eStage,
          bool prograss,
          uint nextsceneid,
          uint currentsceneid)
        {
            XSingleton<XGame>.singleton.notLoadScene = false;
            XSingleton<XGame>.singleton.networkRun = false;
            XSingleton<XTimerMgr>.singleton.update = false;
            this._loading_scene_id = nextsceneid;
            this._loading_scene_stage = eStage;
            this._prograss = prograss;
            XSingleton<XClientNetwork>.singleton.Clear();
            ObjectPoolCache.Clear();
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.ClearClass();
            if (XSingleton<XGlobalConfig>.singleton.GetSettingEnum(ESettingConfig.EClearBundle))
                XSingleton<XUpdater.XUpdater>.singleton.Clear();
            XSingleton<XDebug>.singleton.BeginRecord();
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.MarkLevelEnd();
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.MarkLoadlevel(scene);
            XQualitySetting.SwitchScene();
            XSingleton<XGameUI>.singleton.m_uiTool.PreLoad(false);
            XSingleton<XGameUI>.singleton.m_uiTool.ReleaseAllDrawCall();
            XSingleton<XResourceLoaderMgr>.singleton.CallUnloadCallback();
            XSingleton<XResourceLoaderMgr>.singleton.ReleasePool();
            this._DelayLoadCache = XSingleton<XResourceLoaderMgr>.singleton.DelayLoad;
            XSingleton<XResourceLoaderMgr>.singleton.DelayLoad = false;
            XSpectateDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
            this._LoadingSpectateScene = specificDocument.IsLoadingSpectateScene;
            if (SceneType.SCENE_PK != XSingleton<XSceneMgr>.singleton.GetSceneType(nextsceneid) && SceneType.SCENE_INVFIGHT != XSingleton<XSceneMgr>.singleton.GetSceneType(nextsceneid) && SceneType.SCENE_LEAGUE_BATTLE != XSingleton<XSceneMgr>.singleton.GetSceneType(nextsceneid))
            {
                DlgBase<LoadingDlg, LoadingDlgBehaviour>.singleton.Load();
                if (specificDocument.IsLoadingSpectateScene)
                {
                    specificDocument.IsLoadingSpectateScene = false;
                    string[] strArray = XSingleton<XGlobalConfig>.singleton.GetValue("Spectate_Tips").Split(XGlobalConfig.ListSeparator);
                    int index = UnityEngine.Random.Range(0, strArray.Length);
                    DlgBase<LoadingDlg, LoadingDlgBehaviour>.singleton.SetLoadingTip(strArray[index]);
                }
                else
                {
                    string sceneLoadingTips;
                    if (currentsceneid != 1U)
                    {
                        switch (nextsceneid)
                        {
                            case 1:
                                sceneLoadingTips = XSingleton<XSceneMgr>.singleton.GetSceneLoadingTips(false, currentsceneid);
                                break;
                            case 3:
                                sceneLoadingTips = XSingleton<XSceneMgr>.singleton.GetSceneLoadingTips(false, 2U);
                                break;
                            case 100:
                                sceneLoadingTips = XSingleton<XSceneMgr>.singleton.GetSceneLoadingTips(true, nextsceneid);
                                break;
                            default:
                                sceneLoadingTips = XSingleton<XSceneMgr>.singleton.GetSceneLoadingTips(true, nextsceneid);
                                break;
                        }
                    }
                    else
                        sceneLoadingTips = XSingleton<XSceneMgr>.singleton.GetSceneLoadingTips(true, nextsceneid);
                    DlgBase<LoadingDlg, LoadingDlgBehaviour>.singleton.SetLoadingTip(sceneLoadingTips);
                }
                string pic = nextsceneid != 100U && nextsceneid != 21U && nextsceneid != 22U ? XSingleton<XSceneMgr>.singleton.GetSceneLoadingPic(nextsceneid) : this.GetMyProfessionLoadingPic();
                if (string.IsNullOrEmpty(pic))
                    prograss = false;
                else
                    DlgBase<LoadingDlg, LoadingDlgBehaviour>.singleton.SetLoadingPic(pic);
                DlgBase<LoadingDlg, LoadingDlgBehaviour>.singleton.SetVisible(prograss, true);
                DlgBase<LoadingDlg, LoadingDlgBehaviour>.singleton.SetLoadingProgress(0.0f);
            }
            Application.backgroundLoadingPriority = ThreadPriority.High;
            this.StartCoroutine(this.LoadLevelWithProgress(scene));
            XSingleton<XScene>.singleton.OnSceneBeginLoad(this._loading_scene_id);
        }

        private IEnumerator LoadLevelWithProgress(string scene)
        {
            this.enabled = true;
            this._enabled = true;
            this._current_progress = 0.0f;
            this._target_progress = 0.0f;
            this.DisplayPrograss(XSceneLoader.LoadingPhase.Scene_Downlaod, 1f);
            yield return (object)null;
            if (SceneType.SCENE_PK == XSingleton<XScene>.singleton.SceneType || SceneType.SCENE_INVFIGHT == XSingleton<XScene>.singleton.SceneType)
                DlgBase<XPkLoadingView, XPkLoadingBehaviour>.singleton.ShowPkLoading(XSingleton<XScene>.singleton.SceneType);
            else if (SceneType.SCENE_LEAGUE_BATTLE == XSingleton<XScene>.singleton.SceneType)
                DlgBase<XTeamLeagueLoadingView, XTeamLeagueLoadingBehaviour>.singleton.ShowPkLoading();
            else if (SceneType.SCENE_PKTWO == XSingleton<XScene>.singleton.SceneType)
                DlgBase<XMultiPkLoadingView, XMultiPkLoadingBehaviour>.singleton.ShowPkLoading();
            XSingleton<XGameUI>.singleton.m_uiTool.EnableUILoadingUpdate(true);
            yield return (object)null;
            this.DisplayPrograss(XSceneLoader.LoadingPhase.Scene_Load, 0.0f);
            if ((UnityEngine.Object)XSingleton<XUpdater.XUpdater>.singleton.ABManager != (UnityEngine.Object)null)
                XSingleton<XUpdater.XUpdater>.singleton.ABManager.UnloadUnusedBundle(true);
            this._op = SceneManager.LoadSceneAsync("empty");
            while (!this._op.isDone)
                yield return (object)null;
            this._op = Resources.UnloadUnusedAssets();
            while (!this._op.isDone)
                yield return (object)null;
            XSingleton<XResourceLoaderMgr>.singleton.LoadABScene(XSingleton<XSceneMgr>.singleton.GetScenePath(this._loading_scene_id));
            this._op = SceneManager.LoadSceneAsync(scene);
            while (!this._op.isDone)
                yield return (object)null;
            XSingleton<XResourceLoaderMgr>.singleton.DelayLoad = this._DelayLoadCache;
            XQualitySetting.PostSceneLoad();
            this.DisplayPrograss(XSceneLoader.LoadingPhase.Scene_Load, 1f);
            XSingleton<XDebug>.singleton.AddLog("-------------scene ready & begin load other res-------------");
            yield return (object)null;
            this._asbr = this.SceneBuildAsync(this._loading_scene_id);
            yield return (object)null;
            while (this._asbr.Pedometer.MoveNext())
            {
                this.DisplayPrograss(XSceneLoader.LoadingPhase.Scene_Build, this._asbr.Progress);
                yield return (object)null;
            }
            this._asbr = (XSceneLoader.AsyncSceneBuildRequest)null;
            if (this._prograss)
            {
                if (XStage.IsConcreteStage(this._loading_scene_stage))
                {
                    XSingleton<XScene>.singleton.RefreshScenMustTransform();
                    this.CreatePlayer();
                    this.DisplayPrograss(XSceneLoader.LoadingPhase.Scene_Doc, 0.3f);
                    yield return (object)null;
                    IEnumerator iter = this.DocPreload(this._loading_scene_id);
                    while (iter.MoveNext())
                    {
                        this.DisplayPrograss(XSceneLoader.LoadingPhase.Scene_Doc, (float)(0.300000011920929 + 0.400000005960464 * (double)this._sub_progress));
                        yield return (object)null;
                    }
                    iter = (IEnumerator)null;
                }
                XSingleton<XGame>.singleton.OnEnterScene(this._loading_scene_id);
                this.DisplayPrograss(XSceneLoader.LoadingPhase.Scene_Doc, 0.9f);
                if (this._loading_scene_id == 100U)
                {
                    uint idx = XSingleton<XEntityMgr>.singleton.Player.BasicTypeID - 1U;
                    uint id = XSingleton<XGlobalConfig>.singleton.NewbieLevelRoleID[(int)idx];
                    XEntityStatistics.RowData raw = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(id);
                    XSingleton<XEntityMgr>.singleton.Player.OnTransform(raw.ID);
                    yield return (object)null;
                    raw = (XEntityStatistics.RowData)null;
                }
                this.DisplayPrograss(XSceneLoader.LoadingPhase.Scene_Doc, 1f);
                yield return (object)null;
                this._target_progress = 0.9f;
                if (this._prograss && (double)this._current_progress < 0.889999985694885)
                    yield return (object)null;
                this._enabled = false;
                DlgBase<LoadingDlg, LoadingDlgBehaviour>.singleton.SetLoadingProgress(1f);
                yield return (object)null;
                if (XStage.IsConcreteStage(this._loading_scene_stage))
                {
                    RpcC2G_DoEnterScene DoEnterSceneRpc = new RpcC2G_DoEnterScene();
                    DoEnterSceneRpc.oArg.sceneid = XSingleton<XScene>.singleton.SceneID;
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)DoEnterSceneRpc);
                    XSingleton<XScene>.singleton.bSceneLoadedRpcSend = true;
                    DoEnterSceneRpc = (RpcC2G_DoEnterScene)null;
                }
            }
            else
                XSingleton<XGame>.singleton.OnEnterScene(this._loading_scene_id);
            if (XStage.IsConcreteStage(this._loading_scene_stage))
            {
                yield return (object)null;
            }
            else
            {
                XSingleton<XScene>.singleton.bSceneServerReady = XSingleton<XScene>.singleton.Error == ErrorCode.ERR_SUCCESS;
                yield return (object)null;
            }
            int waitTime = 1;
            XSingleton<XGame>.singleton.networkRun = true;
            while (!XSingleton<XScene>.singleton.bSceneServerReady)
            {
                ++waitTime;
                if ((uint)XSingleton<XScene>.singleton.Error > 0U)
                {
                    if (string.IsNullOrEmpty(XSingleton<XScene>.singleton.ErrorAddtional))
                        XSingleton<UiUtility>.singleton.OnFatalErrorClosed(XSingleton<XScene>.singleton.Error);
                    else
                        XSingleton<UiUtility>.singleton.OnFatalErrorClosed(string.Format(XStringDefineProxy.GetString(XSingleton<XScene>.singleton.Error), (object)XSingleton<XScene>.singleton.ErrorAddtional));
                    XSingleton<XScene>.singleton.Error = ErrorCode.ERR_SUCCESS;
                    XSingleton<XScene>.singleton.ErrorAddtional = (string)null;
                    XSingleton<XClientNetwork>.singleton.CloseOnServerErrorNtf = false;
                    break;
                }
                if (XSingleton<XScene>.singleton.SceneEntranceConfig != null)
                {
                    this._prograss = false;
                    XSingleton<XScene>.singleton.TriggerScene();
                    break;
                }
                yield return (object)null;
            }
            if (XSingleton<XScene>.singleton.bSceneServerReady)
            {
                this.PlayBGM(this._loading_scene_id);
                XAutoFade.MakeBlack(true);
                this._prograss = false;
                yield return (object)null;
                DlgBase<LoadingDlg, LoadingDlgBehaviour>.singleton.HideSelf(false);
                XSingleton<XScene>.singleton.TriggerScene();
                yield return (object)null;
                XAutoFade.FadeIn(1f, true);
            }
            this._op = (AsyncOperation)null;
            if (XSingleton<XScene>.singleton.SceneEntranceConfig != null)
                XSingleton<XScene>.singleton.SceneEnterTo();
            XSingleton<XGame>.singleton.notLoadScene = true;
            XSingleton<XGame>.singleton.switchScene = false;
            XSingleton<XTimerMgr>.singleton.update = true;
            Application.backgroundLoadingPriority = ThreadPriority.Normal;
            if (XSingleton<XGlobalConfig>.singleton.GetSettingEnum(ESettingConfig.ESceneUnloadResource))
                Resources.UnloadUnusedAssets();
            if (this._loading_scene_id == 1U)
                GC.Collect();
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.MarkLoadlevelCompleted();
        }

        private void Update()
        {
            if (!this._enabled || !this._prograss)
                return;
            this._current_progress += Mathf.Abs(this._target_progress - this._current_progress) * 0.5f;
            DlgBase<LoadingDlg, LoadingDlgBehaviour>.singleton.SetLoadingProgress(this._current_progress);
        }

        private void DisplayPrograss(XSceneLoader.LoadingPhase phase, float progress)
        {
            if (!this._prograss)
                return;
            switch (phase)
            {
                case XSceneLoader.LoadingPhase.Scene_Downlaod:
                    this._target_progress = progress * 0.1f;
                    break;
                case XSceneLoader.LoadingPhase.Scene_Load:
                    this._target_progress = (float)((double)progress * 0.200000002980232 + 0.100000001490116);
                    break;
                case XSceneLoader.LoadingPhase.Scene_Build:
                    this._target_progress = (float)((double)progress * 0.400000005960464 + 0.300000011920929);
                    break;
                case XSceneLoader.LoadingPhase.Scene_Doc:
                    this._target_progress = (float)((double)progress * 0.200000002980232 + 0.699999988079071);
                    break;
            }
        }

        private XSceneLoader.AsyncSceneBuildRequest SceneBuildAsync(uint sceneID) => new XSceneLoader.AsyncSceneBuildRequest()
        {
            Pedometer = this.Preloader(sceneID)
        };

        private IEnumerator Preloader(uint sceneID)
        {
            IEnumerator ietr = (IEnumerator)null;
            this._asbr.Progress = 0.0f;
            yield return (object)null;
            XSingleton<XScene>.singleton.OnSceneLoaded(sceneID);
            this._asbr.Progress = 0.05f;
            yield return (object)null;
            ietr = this.PreLoadSceneMonster(sceneID);
            while (ietr.MoveNext())
            {
                this._asbr.Progress = (float)(0.0500000007450581 + (double)this._sub_progress * 0.75);
                yield return (object)null;
            }
            ietr = this.PreLoadSceneRes(sceneID);
            while (ietr.MoveNext())
            {
                this._asbr.Progress = (float)(0.800000011920929 + (double)this._sub_progress * 0.100000001490116);
                yield return (object)null;
            }
            ietr = this.PlaceSceneNpc(sceneID);
            while (ietr.MoveNext())
            {
                this._asbr.Progress = (float)(0.899999976158142 + (double)this._sub_progress * 0.100000001490116);
                yield return (object)null;
            }
            this._asbr.Progress = 1f;
        }

        private void CreatePlayer()
        {
            this._sub_progress = 0.0f;
            XSingleton<XDebug>.singleton.AddLog("Preload Player");
            XSingleton<XEntityMgr>.singleton.Add((XEntity)XSingleton<XEntityMgr>.singleton.CreatePlayer(Vector3.zero, Quaternion.identity, false, XSingleton<XScene>.singleton.IsMustTransform || this._LoadingSpectateScene));
            this._LoadingSpectateScene = false;
        }

        private IEnumerator PlaceSceneNpc(uint sceneID)
        {
            this._sub_progress = 0.0f;
            List<uint> npcList = XSingleton<XEntityMgr>.singleton.GetNpcs(sceneID);
            if (npcList != null && npcList.Count > 0)
            {
                int step = 0;
                XTaskDocument taskDoc = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
                for (int i = 0; i < npcList.Count; ++i)
                {
                    ++step;
                    if (taskDoc.ShouldNpcExist(npcList[i]))
                    {
                        XSingleton<XEntityMgr>.singleton.CreateNpc(npcList[i], true);
                        this._sub_progress = (float)step / (float)npcList.Count;
                    }
                }
                taskDoc = (XTaskDocument)null;
            }
            this._sub_progress = 1f;
            yield return (object)null;
        }

        private IEnumerator PreLoadSceneMonster(uint sceneID)
        {
            this._sub_progress = 0.0f;
            List<uint> prefabs = new List<uint>();
            XLevelSpawnInfo spawner = XSingleton<XLevelSpawnMgr>.singleton.GetSpawnerBySceneID(sceneID);
            if (spawner != null)
            {
                Dictionary<int, int> preloadInfo = new Dictionary<int, int>();
                foreach (KeyValuePair<int, int> keyValuePair1 in spawner._preloadInfo)
                {
                    KeyValuePair<int, int> keyValuePair = keyValuePair1;
                    if (keyValuePair.Key != 0)
                    {
                        preloadInfo.Add(keyValuePair.Key, keyValuePair.Value);
                        keyValuePair = new KeyValuePair<int, int>();
                    }
                }
                if (!XSingleton<XLevelSpawnMgr>.singleton.ForcePreloadOneWave)
                {
                    for (int i = 0; i < XSingleton<XLevelSpawnMgr>.singleton.MonsterIDs.Count && preloadInfo.Count < XSingleton<XLevelSpawnMgr>.singleton.MaxPreloadCount; ++i)
                    {
                        if (XSingleton<XLevelSpawnMgr>.singleton.MonsterIDs[i] != 0U && !preloadInfo.ContainsKey((int)XSingleton<XLevelSpawnMgr>.singleton.MonsterIDs[i]))
                            preloadInfo.Add((int)XSingleton<XLevelSpawnMgr>.singleton.MonsterIDs[i], 1);
                    }
                }
                int step = 0;
                float progress = 0.0f;
                foreach (KeyValuePair<int, int> keyValuePair2 in preloadInfo)
                {
                    KeyValuePair<int, int> keyValuePair = keyValuePair2;
                    ++step;
                    progress = (float)((double)step / (double)preloadInfo.Count * 0.899999976158142);
                    uint enemyID = (uint)keyValuePair.Key;
                    XEntityStatistics.RowData data = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(enemyID);
                    if (data == null)
                    {
                        XSingleton<XDebug>.singleton.AddErrorLog("Cant find statistic id: ", enemyID.ToString());
                    }
                    else
                    {
                        XEntityPresentation.RowData presentData = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(data.PresentID);
                        if (presentData == null)
                        {
                            XSingleton<XDebug>.singleton.AddErrorLog("Cant find present id ", data.PresentID.ToString(), " while statistic id = ", data.ID.ToString());
                        }
                        else
                        {
                            string prefab = presentData.Prefab;
                            if (!prefabs.Contains(data.PresentID))
                            {
                                string location = "Prefabs/" + prefab;
                                float diff = progress - this._sub_progress;
                                XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(location, 1, ECreateHideType.DisableAnim);
                                this._sub_progress += diff * 0.2f;
                                XSingleton<XDebug>.singleton.AddLog("Preload ", prefab, " with pid ", data.PresentID.ToString());
                                XSingleton<XEntityMgr>.singleton.PreloadTemp(data.PresentID, enemyID, (EntitySpecies)data.Type);
                                this._sub_progress += diff * 0.7f;
                                prefabs.Add(data.PresentID);
                                location = (string)null;
                            }
                            this._sub_progress = progress;
                            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
                                yield return (object)null;
                            data = (XEntityStatistics.RowData)null;
                            presentData = (XEntityPresentation.RowData)null;
                            prefab = (string)null;
                            keyValuePair = new KeyValuePair<int, int>();
                        }
                    }
                }
                this._sub_progress = 0.9f;
                XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(XCombatHUDMgr.HUD_NORMAL, 10, ECreateHideType.NotHide);
                XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(XCombatHUDMgr.HUD_CRITICAL, 5, ECreateHideType.NotHide);
                XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(XCombatHUDMgr.HUD_PLAYER, 5, ECreateHideType.NotHide);
                this._sub_progress = 1f;
                preloadInfo = (Dictionary<int, int>)null;
            }
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL)
            {
                XBillBoardDocument.PreLoad(16);
                XSingleton<XGameUI>.singleton.m_uiTool.PreLoad(true);
            }
            else if (XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_LOGIN)
                XSingleton<XGameUI>.singleton.m_uiTool.PreLoad(true);
            yield return (object)null;
            this._sub_progress = 1f;
        }

        private IEnumerator PreLoadSceneRes(uint sceneID)
        {
            this._sub_progress = 0.0f;
            if (sceneID > 3U)
            {
                PreloadAnimationList.RowData[] Anims = XSingleton<XSceneMgr>.singleton.AnimReader.Table;
                int step = 0;
                int i = 0;
                for (int imax = Anims.Length; i < imax; ++i)
                {
                    this._sub_progress = (float)(0.5 + (double)step / ((double)Anims.Length * 2.0));
                    PreloadAnimationList.RowData rowData = Anims[i];
                    if (rowData.SceneID == 0 || (long)rowData.SceneID == (long)sceneID)
                    {
                        ++step;
                        XSingleton<XResourceLoaderMgr>.singleton.GetXAnimation(rowData.AnimName, preload: true);
                        yield return (object)null;
                    }
                    rowData = (PreloadAnimationList.RowData)null;
                }
                Anims = (PreloadAnimationList.RowData[])null;
            }
            this._sub_progress = 1f;
        }

        private void PlayBGM(uint sceneid) => XSingleton<XAudioMgr>.singleton.PlayBGM(XSingleton<XSceneMgr>.singleton.GetSceneBGM(sceneid));

        private IEnumerator DocPreload(uint sceneid)
        {
            this._sub_progress = 0.0f;
            for (int i = 0; i < XSingleton<XGame>.singleton.Doc.Components.Count; ++i)
            {
                XSingleton<XGame>.singleton.Doc.Components[i].OnEnterScene();
                this._sub_progress = (float)i / (float)XSingleton<XGame>.singleton.Doc.Components.Count;
            }
            yield return (object)null;
            this._sub_progress = 1f;
        }

        private string GetMyProfessionLoadingPic()
        {
            uint num = XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID % 10U;
            string[] strArray = XSingleton<XGlobalConfig>.singleton.GetValue("ProfessionLoadingPic").Split(XGlobalConfig.AllSeparators);
            if ((uint)(strArray.Length % 2) > 0U)
                return "";
            for (int index = 0; index < strArray.Length; index += 2)
            {
                if ((int)uint.Parse(strArray[index]) == (int)num)
                    return strArray[index + 1];
            }
            return "";
        }

        private enum LoadingPhase
        {
            Scene_Downlaod,
            Scene_Load,
            Scene_Build,
            Scene_Doc,
        }

        private class AsyncSceneBuildRequest
        {
            public float Progress = 1f;
            public IEnumerator Pedometer = (IEnumerator)null;
        }
    }
}
