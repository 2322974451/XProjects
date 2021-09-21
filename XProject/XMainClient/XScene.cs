// Decompiled with JetBrains decompiler
// Type: XMainClient.XScene
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using ProtoBuf;
using System.Collections.Generic;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
    internal sealed class XScene : XSingleton<XScene>
    {
        private XSceneLoader _loader = (XSceneLoader)null;
        private XSceneTransfer _transfer = (XSceneTransfer)null;
        private int _next_sync_mode = 0;
        private bool _next_is_spectator = false;
        private string _scene_file = (string)null;
        private uint _scene_id = 0;
        private ErrorCode _error = ErrorCode.ERR_SUCCESS;
        private string _error_addtional = (string)null;
        private SceneCfg _scene_cfg = (SceneCfg)null;
        public SceneType _scene_type = SceneType.SCENE_LOGIN;
        private SceneTable.RowData _scene_data = (SceneTable.RowData)null;
        private XEntity _story_dirver = (XEntity)null;
        private bool _bSceneEntered = false;
        private bool _bIsSpectator = false;
        private bool _bStarted = false;
        public bool bSceneServerReady = false;
        public bool bSceneLoadedRpcSend = false;
        private Terrain _terrain = (Terrain)null;
        public Vector3 BattleTargetPoint;
        public Vector3 NestTargetPoint;
        private bool m_IsMustTransform = false;
        private XCameraEx _camera = new XCameraEx();

        public override bool Init()
        {
            this._loader = XUpdater.XUpdater.XGameRoot.AddComponent<XSceneLoader>();
            this._transfer = XUpdater.XUpdater.XGameRoot.AddComponent<XSceneTransfer>();
            return true;
        }

        public override void Uninit()
        {
            this._loader = (XSceneLoader)null;
            this._transfer = (XSceneTransfer)null;
        }

        public bool bSpectator => this._bIsSpectator;

        public bool FilterFx => !this._bIsSpectator && XFxMgr.FilterFarFx && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World;

        public bool SceneReady => this._bSceneEntered;

        public bool SceneStarted
        {
            get => this._bStarted;
            set
            {
                if (this._bStarted == value)
                    return;
                this._bStarted = value;
                if (!this._bStarted)
                    return;
                this.OnSceneStarted();
            }
        }

        public XEntity Dirver
        {
            get => this._story_dirver;
            set => this._story_dirver = value;
        }

        public Camera AssociatedCamera { get; set; }

        public bool IsMustTransform
        {
            get => this._scene_type == SceneType.SCENE_MOBA || this._scene_type == SceneType.SCENE_HEROBATTLE || this.m_IsMustTransform;
            set => this.m_IsMustTransform = value;
        }

        public bool IsMobaScene => this._scene_type == SceneType.SCENE_MOBA || this._scene_type == SceneType.SCENE_HEROBATTLE;

        public bool CanFadeOnCreate => this._scene_type != SceneType.SCENE_MOBA && this._scene_type != SceneType.SCENE_HEROBATTLE;

        public bool IsViewGridScene { get; set; }

        public SceneType SceneType => this._scene_type;

        public uint SceneID => this._scene_id;

        public SceneTable.RowData SceneData => this._scene_data;

        public XCameraEx GameCamera => this._camera;

        public bool IsPVPScene => this.SceneData == null || this.SceneData.CombatType == (byte)1;

        public Terrain CurrentTerrain
        {
            get => this._terrain;
            set => this._terrain = value;
        }

        public SceneCfg SceneEntranceConfig => this._scene_cfg;

        public ErrorCode Error
        {
            get => this._error;
            set => this._error = value;
        }

        public string ErrorAddtional
        {
            get => this._error_addtional;
            set => this._error_addtional = value;
        }

        public bool TryGetTerrainY(Vector3 pos, out float y) => XCurrentGrid.grid.TryGetHeight(pos, out y);

        public bool IsWalkable(Vector3 pos)
        {
            float y = 0.0f;
            return XCurrentGrid.grid.TryGetHeight(pos, out y) && (double)y >= 0.0;
        }

        public bool IsWalkable(Vector3 pos, out float y)
        {
            if (!XCurrentGrid.grid.TryGetHeight(pos, out y) || (double)y < 0.0 || !((Object)this._terrain != (Object)null))
                return false;
            float num = this._terrain.SampleHeight(pos);
            if ((double)y - (double)num < 0.0500000007450581)
                y = num;
            return true;
        }

        public float TerrainY(Vector3 pos)
        {
            float num = 0.0f;
            if ((Object)this._terrain != (Object)null)
                num = this._terrain.SampleHeight(pos);
            if (XCurrentGrid.grid != null)
            {
                float height = XCurrentGrid.grid.GetHeight(pos);
                if ((double)height - (double)num > 0.0500000007450581)
                    num = height;
            }
            return num;
        }

        public void PauseBGM() => XSingleton<XAudioMgr>.singleton.PauseBGM();

        public void ResumeBGM() => XSingleton<XAudioMgr>.singleton.ResumeBGM();

        public bool TurnToTransfer(uint sceneid) => this._scene_file == XSingleton<XSceneMgr>.singleton.GetUnitySceneFile(sceneid);

        public void UntriggerScene() => this._bSceneEntered = false;

        public void StoreSceneConfig(SceneCfg config) => this._scene_cfg = Serializer.DeepClone<SceneCfg>(config);

        public void SceneEnterTo(SceneCfg config, bool fromserver = true)
        {
            uint sceneId = config.SceneID;
            SceneType sceneType = XSingleton<XSceneMgr>.singleton.GetSceneType(sceneId);
            this._next_sync_mode = config.SyncMode;
            this._next_is_spectator = config.isWatcher;
            if (XSingleton<XSceneMgr>.singleton.GetSceneType(config.SceneID) == SceneType.SCENE_BOSSRUSH)
            {
                XSingleton<XLevelSpawnMgr>.singleton.GetSpawnerBySceneID(config.SceneID);
                XSingleton<XLevelSpawnMgr>.singleton.MonsterIDs.Clear();
                XSingleton<XLevelSpawnMgr>.singleton.MonsterIDs.Add(XDocuments.GetSpecificDocument<XBossBushDocument>(XBossBushDocument.uuID).entityRow.ID);
            }
            else
                XSingleton<XLevelSpawnMgr>.singleton.CacheServerMonsterID(config.preloadEnemyIDs);
            if (config.SyncMode == 2)
                XSingleton<XLevelSpawnMgr>.singleton.CacheServerMonster(config.enemyWaves);
            switch (sceneType)
            {
                case SceneType.SCENE_HALL:
                    if (fromserver)
                    {
                        if (XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.SelectChar)
                        {
                            XSingleton<XGame>.singleton.CurrentStage.Play();
                            this.StoreSceneConfig(config);
                            break;
                        }
                        XSingleton<XGame>.singleton.SwitchTo(EXStage.Hall, sceneId);
                        break;
                    }
                    XSingleton<XGame>.singleton.SwitchTo(EXStage.Hall, sceneId);
                    break;
                case SceneType.SCENE_BATTLE:
                    if (fromserver)
                    {
                        if (XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.SelectChar)
                        {
                            XSingleton<XGame>.singleton.CurrentStage.Play();
                            this.StoreSceneConfig(config);
                            break;
                        }
                        XSingleton<XGame>.singleton.SwitchTo(EXStage.World, sceneId);
                        break;
                    }
                    XSingleton<XGame>.singleton.SwitchTo(EXStage.World, sceneId);
                    break;
                case SceneType.SCENE_NEST:
                case SceneType.SCENE_ARENA:
                case SceneType.SCENE_WORLDBOSS:
                case SceneType.SCENE_BOSSRUSH:
                case SceneType.SCENE_GUILD_BOSS:
                case SceneType.SCENE_PK:
                case SceneType.SCENE_ABYSSS:
                case SceneType.SCENE_TOWER:
                case SceneType.SCENE_PVP:
                case SceneType.SCENE_DRAGON:
                case SceneType.SCENE_GMF:
                case SceneType.SCENE_GODDESS:
                case SceneType.SCENE_DRAGON_EXP:
                case SceneType.SCENE_RISK:
                case SceneType.SCENE_ENDLESSABYSS:
                case SceneType.SKYCITY_FIGHTING:
                case SceneType.SCENE_PROF_TRIALS:
                case SceneType.SCENE_GPR:
                case SceneType.SCENE_RESWAR_PVP:
                case SceneType.SCENE_RESWAR_PVE:
                case SceneType.SCENE_GUILD_CAMP:
                case SceneType.SCENE_AIRSHIP:
                case SceneType.SCENE_WEEK_NEST:
                case SceneType.SCENE_HORSE_RACE:
                case SceneType.SCENE_HEROBATTLE:
                case SceneType.SCENE_INVFIGHT:
                case SceneType.SCENE_CASTLE_WAIT:
                case SceneType.SCENE_CASTLE_FIGHT:
                case SceneType.SCENE_LEAGUE_BATTLE:
                case SceneType.SCENE_ACTIVITY_ONE:
                case SceneType.SCENE_ACTIVITY_TWO:
                case SceneType.SCENE_ACTIVITY_THREE:
                case SceneType.SCENE_ABYSS_PARTY:
                case SceneType.SCENE_CUSTOMPK:
                case SceneType.SCENE_PKTWO:
                case SceneType.SCENE_MOBA:
                case SceneType.SCENE_WEEKEND4V4_MONSTERFIGHT:
                case SceneType.SCENE_WEEKEND4V4_GHOSTACTION:
                case SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE:
                case SceneType.SCENE_WEEKEND4V4_CRAZYBOMB:
                case SceneType.SCENE_WEEKEND4V4_HORSERACING:
                case SceneType.SCENE_CUSTOMPKTWO:
                case SceneType.SCENE_WEEKEND4V4_DUCK:
                case SceneType.SCENE_BIGMELEE_FIGHT:
                case SceneType.SCENE_CALLBACK:
                case SceneType.SCENE_BIOHELL:
                case SceneType.SCENE_DUCK:
                case SceneType.SCENE_COUPLE:
                case SceneType.SCENE_BATTLEFIELD_FIGHT:
                case SceneType.SCENE_COMPETEDRAGON:
                case SceneType.SCENE_SURVIVE:
                case SceneType.SCENE_GCF:
                case SceneType.SCENE_GUILD_WILD_HUNT:
                case SceneType.SCENE_AWAKE:
                    XSingleton<XGame>.singleton.SwitchTo(EXStage.World, sceneId);
                    break;
                case SceneType.SCENE_GUILD_HALL:
                case SceneType.SCENE_FAMILYGARDEN:
                case SceneType.SKYCITY_WAITING:
                case SceneType.SCENE_HORSE:
                case SceneType.SCENE_BIGMELEE_READY:
                case SceneType.SCENE_WEDDING:
                case SceneType.SCENE_BATTLEFIELD_READY:
                case SceneType.SCENE_LEISURE:
                    XSingleton<XGame>.singleton.SwitchTo(EXStage.Hall, sceneId);
                    break;
                case SceneType.SCENE_RIFT:
                    XRiftDocument specificDocument = XDocuments.GetSpecificDocument<XRiftDocument>(XRiftDocument.uuID);
                    if (specificDocument != null)
                        specificDocument.stop_timer = false;
                    XSingleton<XGame>.singleton.SwitchTo(EXStage.World, sceneId);
                    break;
                default:
                    XSingleton<XDebug>.singleton.AddErrorLog("can't process enter scene type: ", sceneType.ToString());
                    break;
            }
            XSingleton<XLevelDoodadMgr>.singleton.CacheDoodad(config.doodads);
        }

        public void SceneEnterTo(bool fromserver = true)
        {
            this.SceneEnterTo(this._scene_cfg, fromserver);
            this._scene_cfg = (SceneCfg)null;
        }

        public void LoadSceneAsync(uint sceneid, EXStage eStage, bool prograss, bool transfer)
        {
            this._scene_file = XSingleton<XSceneMgr>.singleton.GetUnitySceneFile(sceneid);
            if (!string.IsNullOrEmpty(this._scene_file))
            {
                this._bSceneEntered = false;
                this.bSceneServerReady = false;
                this.bSceneLoadedRpcSend = false;
                XSingleton<XEventMgr>.singleton.Clear();
                XEquipDocument.CurrentVisibleRole = 0;
                XDummy.visibleDummyCount = 0;
                Shader.SetGlobalVector("uirim", new Vector4(1f, 1f, 1f, 0.0f));
                if (transfer)
                    this._transfer.TransferScene(sceneid);
                else
                    this._loader.LoadScene(this._scene_file, eStage, prograss, sceneid, this._scene_id);
            }
            else
                XSingleton<XDebug>.singleton.AddErrorLog("No scene file found with id ", sceneid.ToString());
        }

        public void OnSceneBeginLoad(uint sceneid)
        {
            this._bStarted = false;
            this._scene_id = sceneid;
            XFileLog.SceneID = sceneid;
            this._scene_type = XSingleton<XSceneMgr>.singleton.GetSceneType(this._scene_id);
            this._scene_data = XSingleton<XSceneMgr>.singleton.GetSceneData(this._scene_id);
            XSingleton<XGame>.singleton.SyncModeValue = this._next_sync_mode;
            this._bIsSpectator = this._next_is_spectator;
            if (this._scene_type != SceneType.SCENE_HALL)
                XQualitySetting.EnterScene();
            else
                XQualitySetting.EnterHall();
            this.IsViewGridScene = XSingleton<XGlobalConfig>.singleton.ViewGridScene.Contains(XFastEnumIntEqualityComparer<SceneType>.ToInt(this._scene_type));
        }

        public void OnSceneLoaded(uint sceneid)
        {
            this._next_sync_mode = 0;
            this._next_is_spectator = false;
            XSingleton<XSkillFactory>.singleton.OnSceneLoaded();
            XSingleton<XLevelSpawnMgr>.singleton.OnSceneLoaded(sceneid);
            XFightGroupDocument.OnSceneLoaded();
        }

        public void OnEnterScene(uint sceneid, bool transfer)
        {
            this._story_dirver = (XEntity)XSingleton<XEntityMgr>.singleton.Player;
            XSingleton<XStageProgress>.singleton.OnEnterScene();
            XSingleton<XPostEffectMgr>.singleton.OnEnterScene(sceneid);
            XQualitySetting.PostSetting();
        }

        public void TriggerScene()
        {
            this._bSceneEntered = true;
            XSingleton<XLevelSpawnMgr>.singleton.CreateRobot(this._scene_id);
            if ((uint)XSingleton<XSceneMgr>.singleton.GetSceneConfigFile(this._scene_id).Length <= 0U)
                return;
            XSingleton<XLevelSpawnMgr>.singleton.InitGlobalAI(this._scene_id);
        }

        public void OnSceneStarted()
        {
            for (int index = 0; index < XSingleton<XGame>.singleton.Doc.Components.Count; ++index)
                (XSingleton<XGame>.singleton.Doc.Components[index] as XDocComponent).OnSceneStarted();
        }

        public void OnLeaveScene(bool transfer)
        {
            this._story_dirver = (XEntity)null;
            this._bStarted = false;
            XSingleton<XShell>.singleton.TimeMagicBack();
            XSingleton<XTutorialMgr>.singleton.OnLeaveScene();
            XSingleton<XCutScene>.singleton.OnLeaveScene();
            XSingleton<XAudioMgr>.singleton.OnLeaveScene();
            XSingleton<XGameSysMgr>.singleton.OnLeaveScene(transfer);
            this._camera.Uninitilize();
            XSingleton<XFxMgr>.singleton.OnLeaveScene();
            XSingleton<XTimerMgr>.singleton.KillTimerAll();
            XSingleton<XLevelSpawnMgr>.singleton.UnInitGlobalAI();
            XHUDComponent.ResetCurrentCount();
            if (!transfer)
                XSingleton<XCustomShadowMgr>.singleton.Clear();
            ShadowMapInfo.ClearShadowRes();
            XSyncDebug.OnLeaveScene();
        }

        public void PreUpdate(float fDeltaT)
        {
            if (!this._bSceneEntered)
                return;
            XSingleton<XLevelScriptMgr>.singleton.Update();
            if (XSingleton<XEntityMgr>.singleton.Player != null)
                XSingleton<XEntityMgr>.singleton.Player.PreUpdate();
        }

        public void Update(float fDeltaT)
        {
            if (!this._bSceneEntered)
                return;
            XSingleton<XBulletMgr>.singleton.Update(fDeltaT);
            XSingleton<XEntityMgr>.singleton.Update(fDeltaT);
            XSingleton<XLevelFinishMgr>.singleton.Update(fDeltaT);
            XSingleton<XLevelDoodadMgr>.singleton.Update();
            this._camera.Update(fDeltaT);
            XSingleton<XLevelStatistics>.singleton.Update();
            if (!XSingleton<XGame>.singleton.SyncMode)
                XSingleton<XLevelSpawnMgr>.singleton.Update(fDeltaT);
            if (XSingleton<XTutorialMgr>.singleton.NeedTutorail)
                XSingleton<XTutorialMgr>.singleton.Update();
        }

        public void PostUpdate(float fDeltaT)
        {
            if (!this._bSceneEntered)
                return;
            this._camera.PostUpdate(fDeltaT);
            XSingleton<XEntityMgr>.singleton.PostUpdate(fDeltaT);
            XSingleton<XFxMgr>.singleton.PostUpdate();
            XQualitySetting.Update();
        }

        public void FixedUpdate()
        {
            if (!this._bSceneEntered)
                return;
            XSingleton<XEntityMgr>.singleton.FixedUpdate();
            this._camera.FixedUpdate();
        }

        public bool CheckDynamicBlock(Vector3 from, Vector3 to)
        {
            List<XLevelInfo> levelScriptInfos = XSingleton<XLevelScriptMgr>.singleton.GetLevelScriptInfos();
            for (int index = 0; index < levelScriptInfos.Count; ++index)
            {
                if (levelScriptInfos[index].enable)
                {
                    float num = levelScriptInfos[index].width / 2f;
                    Vector3 vector3_1 = new Vector3(levelScriptInfos[index].x, 0.0f, levelScriptInfos[index].z);
                    Vector3 vector3_2 = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(XSingleton<XCommon>.singleton.FloatToAngle(levelScriptInfos[index].face), 90f);
                    if (XSingleton<XCommon>.singleton.IsLineSegmentCross(from, to, vector3_1 + num * vector3_2, vector3_1 - num * vector3_2) && (double)levelScriptInfos[index].height > (double)from.y)
                        return false;
                }
            }
            return true;
        }

        public void ReqLeaveScene()
        {
            XStaticSecurityStatistics.OnEnd();
            XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2G_LeaveSceneReq());
        }

        public void RefreshScenMustTransform()
        {
            this.m_IsMustTransform = false;
            List<int> intList = ListPool<int>.Get();
            XSingleton<XGlobalConfig>.singleton.GetIntList("TransformSceneID", intList);
            for (int index = 0; index < intList.Count; ++index)
            {
                if ((long)this._scene_id == (long)intList[index])
                {
                    this.m_IsMustTransform = true;
                    break;
                }
            }
            ListPool<int>.Release(intList);
        }
    }
}
