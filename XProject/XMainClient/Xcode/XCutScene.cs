

using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XCutScene : XSingleton<XCutScene>
    {
        public Dictionary<uint, XActor> _common_actors = new Dictionary<uint, XActor>();
        private List<XFx> _common_fx = new List<XFx>();
        private bool _cut_scene = false;
        private bool _exclusive = true;
        private List<uint> _eventToken = new List<uint>();
        private List<XActor> _actors = (List<XActor>)null;
        protected List<XFx> _fx = new List<XFx>();
        private XCutSceneData _cut_scene_data = (XCutSceneData)null;
        private XCameraMotionData _camera = new XCameraMotionData();
        private XEntity _target = (XEntity)null;
        private uint _token = 0;
        private string _name = (string)null;
        private XTimerMgr.ElapsedEventHandler _startCb = (XTimerMgr.ElapsedEventHandler)null;
        private XTimerMgr.ElapsedEventHandler _endCb = (XTimerMgr.ElapsedEventHandler)null;
        private XTimerMgr.ElapsedEventHandler _actorOnStageCb = (XTimerMgr.ElapsedEventHandler)null;
        private XTimerMgr.ElapsedEventHandler _playerOnStageCb = (XTimerMgr.ElapsedEventHandler)null;
        private XTimerMgr.ElapsedEventHandler _fxCb = (XTimerMgr.ElapsedEventHandler)null;
        private XTimerMgr.ElapsedEventHandler _audioCb = (XTimerMgr.ElapsedEventHandler)null;
        private XTimerMgr.ElapsedEventHandler _subTitleCb = (XTimerMgr.ElapsedEventHandler)null;
        private XTimerMgr.ElapsedEventHandler _slashCb = (XTimerMgr.ElapsedEventHandler)null;
        private XTimerMgr.ElapsedEventHandler _endShowCb = (XTimerMgr.ElapsedEventHandler)null;
        private XTimerMgr.ElapsedEventHandler _endSubTitleCb = (XTimerMgr.ElapsedEventHandler)null;
        private CommandCallback _findFxTransCb = (CommandCallback)null;
        private bool _bFadeAtEnd = true;
        private float farClipPlaneBackUP = 150f;

        public bool IsPlaying => this._cut_scene;

        public bool IsExcludeNewBorn
        {
            get => this._exclusive;
            set => this._exclusive = value;
        }

        public float Length => this.IsPlaying ? this._cut_scene_data.Length : 0.0f;

        public string Name => this._name;

        public Vector3 EndWithPos { get; set; }

        public float EndWithDir { get; set; }

        public uint GeneralMonsterID { get; set; }

        public XCutScene()
        {
            this._camera.AutoSync_At_Begin = false;
            this._camera.Coordinate = CameraMotionSpace.World;
            this._camera.Follow_Position = false;
            this._camera.LookAt_Target = false;
            this._camera.At = 0.0f;
            this._camera.MotionType = CameraMotionType.AnchorBased;
            this._startCb = new XTimerMgr.ElapsedEventHandler(this.InnerStart);
            this._endCb = new XTimerMgr.ElapsedEventHandler(this.InnerEnd);
            this._actorOnStageCb = new XTimerMgr.ElapsedEventHandler(this.ActorOnStage);
            this._playerOnStageCb = new XTimerMgr.ElapsedEventHandler(this.PlayerOnStage);
            this._fxCb = new XTimerMgr.ElapsedEventHandler(this.Fx);
            this._audioCb = new XTimerMgr.ElapsedEventHandler(this.Audio);
            this._subTitleCb = new XTimerMgr.ElapsedEventHandler(this.SubTitle);
            this._slashCb = new XTimerMgr.ElapsedEventHandler(this.Slash);
            this._endShowCb = new XTimerMgr.ElapsedEventHandler(this.EndShow);
            this._endSubTitleCb = new XTimerMgr.ElapsedEventHandler(this.EndSubTitle);
            this._findFxTransCb = new CommandCallback(this.AttachFx);
        }

        public void Start(string cutname, bool bFadeOut = true, bool bFadeAtEnd = true)
        {
            if (this._cut_scene)
                XSingleton<XCutScene>.singleton.Stop(true);
            this._bFadeAtEnd = bFadeAtEnd;
            this._actors = new List<XActor>();
            XSingleton<XAudioMgr>.singleton.StopSoundForCutscene();
            XSingleton<XOperationRecord>.singleton.DoScriptRecord(cutname);
            XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.BlackWhite, false);
            this._cut_scene = true;
            this._name = cutname;
            this._cut_scene_data = XSingleton<XResourceLoaderMgr>.singleton.GetData<XCutSceneData>(this._name, ".txt");
            XBillBoardDocument.SetAllBillBoardState(BillBoardHideType.CutScene, false);
            if (XSingleton<XGame>.singleton.CurrentStage is XConcreteStage)
                XSingleton<XGameUI>.singleton.ShowBlock(true);
            if (this._cut_scene_data.OverrideBGM)
                XSingleton<XScene>.singleton.PauseBGM();
            if (DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded())
                DlgBase<BattleMain, BattleMainBehaviour>.singleton.OnStopVoiceRecord();
            if (DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded())
                DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.OnStopVoiceRecord();
            XSingleton<XShell>.singleton.TimeMagicBack();
            XSingleton<XAIGeneralMgr>.singleton.EnablePlayerAI(false);
            List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly((XEntity)XSingleton<XEntityMgr>.singleton.Player);
            for (int index = 0; index < ally.Count; ++index)
            {
                if (ally[index] != XSingleton<XEntityMgr>.singleton.Player)
                {
                    XAIEnableAI xaiEnableAi = XEventPool<XAIEnableAI>.GetEvent();
                    xaiEnableAi.Firer = (XObject)ally[index];
                    xaiEnableAi.Enable = false;
                    XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xaiEnableAi);
                }
            }
            if (string.IsNullOrEmpty(this._cut_scene_data.CameraClip))
            {
                XAutoFade.FadeOut2In(1f, 2.5f);
                this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer(1f, this._endCb, (object)null));
            }
            else if (bFadeOut)
            {
                XAutoFade.FadeOut2In(0.5f, 0.5f);
                this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, this._startCb, (object)null));
            }
            else
                this.InnerStart((object)this);
        }

        public void Stop(bool bImmdiately = false)
        {
            if (!this.IsPlaying)
                return;
            for (int index = 0; index < this._eventToken.Count; ++index)
                XSingleton<XTimerMgr>.singleton.KillTimer(this._eventToken[index]);
            this._eventToken.Clear();
            if (bImmdiately)
                this.InnerEnd((object)null);
            else
                this.EndShow((object)null);
        }

        public void ClearCommon()
        {
            for (int index = 0; index < this._common_fx.Count; ++index)
            {
                if (this._common_fx[index] != null)
                    XSingleton<XFxMgr>.singleton.DestroyFx(this._common_fx[index]);
            }
            this._common_fx.Clear();
            foreach (XObject xobject in this._common_actors.Values)
                xobject.Uninitilize();
            this._common_actors.Clear();
        }

        public void OnLeaveScene()
        {
            if (!this.IsPlaying)
                return;
            this.Stop(true);
            XAutoFade.FastFadeIn();
        }

        public void AddedTimerToken(uint token) => this._eventToken.Add(token);

        private void InnerStart(object o)
        {
            XSingleton<XInput>.singleton.Freezed = true;
            if (o == null)
                XAutoFade.MakeBlack();
            this.farClipPlaneBackUP = XSingleton<XScene>.singleton.GameCamera.UnityCamera.farClipPlane;
            XSingleton<XScene>.singleton.GameCamera.UnityCamera.farClipPlane = 150f;
            XSingleton<XScene>.singleton.GameCamera.UnityCamera.fieldOfView = this._cut_scene_data.FieldOfView;
            this._camera.Motion = this._cut_scene_data.CameraClip;
            this._camera.Follow_Position = this._cut_scene_data.GeneralShow;
            this._camera.AutoSync_At_Begin = this._cut_scene_data.GeneralShow;
            if (XSingleton<XScene>.singleton.GameCamera.CloseUp != null)
                XSingleton<XScene>.singleton.GameCamera.CloseUp.Stop((object)null);
            if (XSingleton<XScene>.singleton.GameCamera.Collision != null)
                XSingleton<XScene>.singleton.GameCamera.Collision.Enabled = false;
            if (XSingleton<XScene>.singleton.GameCamera.VAdjust != null)
                XSingleton<XScene>.singleton.GameCamera.VAdjust.Enabled = false;
            if (XSingleton<XScene>.singleton.GameCamera.Solo != null)
                XSingleton<XScene>.singleton.GameCamera.Solo.Stop();
            foreach (XActorDataClip actor in this._cut_scene_data.Actors)
                this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer((float)((double)actor.TimeLineAt / 30.0 - 0.0160000007599592), this._actorOnStageCb, (object)actor));
            if (this._cut_scene_data.GeneralShow)
            {
                if (XSingleton<XEntityMgr>.singleton.Boss != null)
                    this._target = (XEntity)XSingleton<XEntityMgr>.singleton.Boss;
                else if (this.GeneralMonsterID > 0U)
                {
                    Vector3 zero = Vector3.zero;
                    float face = 0.0f;
                    if (XSingleton<XLevelSpawnMgr>.singleton.QueryMonsterStaticInfo(this.GeneralMonsterID, ref zero, ref face))
                        this._target = (XEntity)XSingleton<XEntityMgr>.singleton.CreateDummy(this.GeneralMonsterID, zero, XSingleton<XCommon>.singleton.FloatToQuaternion(face));
                    else
                        XSingleton<XDebug>.singleton.AddErrorLog("QueryMonsterStaticInfo failed with id ", this.GeneralMonsterID.ToString(), " in cutscene ", this._cut_scene_data.Name);
                }
                else
                    XSingleton<XDebug>.singleton.AddErrorLog("Missing Boss id in general cutscene script with name ", this._cut_scene_data.Name);
            }
            XCameraMotionEventArgs xcameraMotionEventArgs = XEventPool<XCameraMotionEventArgs>.GetEvent();
            xcameraMotionEventArgs.Motion = this._camera;
            xcameraMotionEventArgs.Target = this._target;
            xcameraMotionEventArgs.Trigger = this._cut_scene_data.Trigger;
            xcameraMotionEventArgs.Firer = (XObject)XSingleton<XScene>.singleton.GameCamera;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xcameraMotionEventArgs);
            if (!this._cut_scene_data.GeneralShow)
            {
                foreach (XPlayerDataClip xplayerDataClip in this._cut_scene_data.Player)
                    this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer((float)((double)xplayerDataClip.TimeLineAt / 30.0 - 0.0160000007599592), this._playerOnStageCb, (object)xplayerDataClip));
                foreach (XFxDataClip xfxDataClip in this._cut_scene_data.Fxs)
                    this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer(xfxDataClip.TimeLineAt / 30f, this._fxCb, (object)xfxDataClip));
            }
            foreach (XAudioDataClip audio in this._cut_scene_data.Audios)
                this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer(audio.TimeLineAt / 30f, this._audioCb, (object)audio));
            if (this._cut_scene_data.Mourningborder)
            {
                DlgBase<CutSceneUI, CutSceneUIBehaviour>.singleton.SetVisible(true, true);
                foreach (XSubTitleDataClip xsubTitleDataClip in this._cut_scene_data.SubTitle)
                    this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer(xsubTitleDataClip.TimeLineAt / 30f, this._subTitleCb, (object)xsubTitleDataClip));
                foreach (XSlashDataClip xslashDataClip in this._cut_scene_data.Slash)
                    this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer(xslashDataClip.TimeLineAt / 30f, new XTimerMgr.ElapsedEventHandler(this.Slash), (object)xslashDataClip));
            }
            else if (XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.World)
                ;
            if (this._cut_scene_data.AutoEnd)
                this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer((float)(((double)this._cut_scene_data.TotalFrame - 30.0) / 30.0), this._endShowCb, (object)null));
            this.Reflection();
            XSingleton<XEntityMgr>.singleton.Dummilize(this._cut_scene_data.TypeMask);
            if ((double)this.EndWithPos.sqrMagnitude <= 0.100000001490116)
                return;
            this.CorrectToEndPos();
        }

        public void Reflection()
        {
            if (this._cut_scene_data == null || string.IsNullOrEmpty(this._cut_scene_data.Script))
                return;
            XSingleton<ScriptCode>.singleton.ExecuteCutScene(this._cut_scene_data.Script, this._actors);
        }

        private void ActorOnStage(object o)
        {
            XActorDataClip xactorDataClip = o as XActorDataClip;
            XActor xactor = (XActor)null;
            if (!string.IsNullOrEmpty(xactorDataClip.Tag))
            {
                int result = 0;
                if (int.TryParse(xactorDataClip.Tag, out result) && result > XGame.RoleCount)
                    return;
            }
            Vector3 pos = new Vector3(xactorDataClip.AppearX, xactorDataClip.AppearY, xactorDataClip.AppearZ);
            if (xactorDataClip.bUsingID && xactorDataClip.bToCommonPool)
            {
                if (!this._common_actors.TryGetValue((uint)xactorDataClip.StatisticsID, out xactor))
                {
                    xactor = xactorDataClip.bUsingID ? new XActor((uint)xactorDataClip.StatisticsID, pos, xactorDataClip.Clip) : new XActor(xactorDataClip.Prefab, pos, Quaternion.identity, xactorDataClip.Clip);
                    xactor.Initilize(0);
                    if (!string.IsNullOrEmpty(xactorDataClip.Tag))
                        xactor.EngineObject.Tag = xactorDataClip.Tag;
                    this._common_actors.Add((uint)xactorDataClip.StatisticsID, xactor);
                }
                else
                    xactor.PlayAnimation(xactorDataClip.Clip);
            }
            else
            {
                xactor = xactorDataClip.bUsingID ? new XActor((uint)xactorDataClip.StatisticsID, pos, xactorDataClip.Clip) : new XActor(xactorDataClip.Prefab, pos, Quaternion.identity, xactorDataClip.Clip);
                xactor.Initilize(0);
            }
            this._actors.Add(xactor);
            this.Reflection();
        }

        private void PlayerOnStage(object o)
        {
            XPlayerDataClip xplayerDataClip = o as XPlayerDataClip;
            Vector3 pos = new Vector3(xplayerDataClip.AppearX, xplayerDataClip.AppearY, xplayerDataClip.AppearZ);
            XActor xactor;
            switch (XSingleton<XEntityMgr>.singleton.Player.BasicTypeID)
            {
                case 1:
                    xactor = new XActor(pos, xplayerDataClip.Clip1);
                    break;
                case 2:
                    xactor = new XActor(pos, xplayerDataClip.Clip2);
                    break;
                case 3:
                    xactor = new XActor(pos, xplayerDataClip.Clip3);
                    break;
                case 4:
                    xactor = new XActor(pos, xplayerDataClip.Clip4);
                    break;
                case 5:
                    xactor = new XActor(pos, xplayerDataClip.Clip5);
                    break;
                case 6:
                    xactor = new XActor(pos, xplayerDataClip.Clip6);
                    break;
                case 7:
                    xactor = new XActor(pos, xplayerDataClip.Clip7);
                    break;
                default:
                    xactor = new XActor(pos, (string)null);
                    break;
            }
            xactor.Initilize(0);
            this._actors.Add(xactor);
            this.Reflection();
        }

        private void AttachFx(XGameObject go, object o, int commandID)
        {
            XFxDataClip xfxDataClip = o as XFxDataClip;
            XFx fx = XSingleton<XFxMgr>.singleton.CreateFx(xfxDataClip.Fx, async: false);
            fx.DelayDestroy = xfxDataClip.Destroy_Delay;
            Transform parent = go?.Find(xfxDataClip.Bone);
            if ((Object)parent != (Object)null)
            {
                fx.Play(parent, Vector3.zero, xfxDataClip.Scale * Vector3.one, follow: xfxDataClip.Follow);
                if (this._common_actors.ContainsValue(this._actors[xfxDataClip.BindIdx]))
                    this._common_fx.Add(fx);
            }
            else
                fx.Play(new Vector3(xfxDataClip.AppearX, xfxDataClip.AppearY, xfxDataClip.AppearZ), XSingleton<XCommon>.singleton.FloatToQuaternion(xfxDataClip.Face), Vector3.one);
            this._fx.Add(fx);
        }

        private void Fx(object o)
        {
            XFxDataClip xfxDataClip = o as XFxDataClip;
            if (xfxDataClip.BindIdx >= 0)
                this._actors[xfxDataClip.BindIdx].EngineObject.CallCommand(this._findFxTransCb, o);
            else
                this.AttachFx((XGameObject)null, o, -1);
        }

        private void Audio(object o)
        {
            XAudioDataClip xaudioDataClip = o as XAudioDataClip;
            if (xaudioDataClip.BindIdx < 0)
                XSingleton<XAudioMgr>.singleton.PlayUISound(xaudioDataClip.Clip, channel: xaudioDataClip.Channel);
            else if (XSingleton<XEntityMgr>.singleton.Player != null)
                XSingleton<XAudioMgr>.singleton.PlaySound((XObject)this._actors[xaudioDataClip.BindIdx], xaudioDataClip.Channel, xaudioDataClip.Clip, false, new XAudioExParam("PlayerClass", (float)XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.BasicTypeID));
            else
                XSingleton<XAudioMgr>.singleton.PlaySound((XObject)this._actors[xaudioDataClip.BindIdx], xaudioDataClip.Channel, xaudioDataClip.Clip);
        }

        private void SubTitle(object o)
        {
            XSubTitleDataClip xsubTitleDataClip = o as XSubTitleDataClip;
            DlgBase<CutSceneUI, CutSceneUIBehaviour>.singleton.SetText(xsubTitleDataClip.Context);
            XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
            this._token = XSingleton<XTimerMgr>.singleton.SetTimer(xsubTitleDataClip.Duration / 30f, this._endSubTitleCb, (object)null);
        }

        private void Slash(object o)
        {
            XSlashDataClip xslashDataClip = o as XSlashDataClip;
            if (this._cut_scene_data.GeneralShow)
            {
                string name = "";
                if (this._target != null && (this._target.IsDummy || XEntity.ValideEntity(this._target)))
                {
                    XEntityStatistics.RowData byId = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._target.TypeID);
                    if (byId != null)
                        name = byId.Name;
                }
                DlgBase<CutSceneUI, CutSceneUIBehaviour>.singleton.SetIntroText(true, name, xslashDataClip.Discription, xslashDataClip.AnchorX, xslashDataClip.AnchorY);
            }
            else
                DlgBase<CutSceneUI, CutSceneUIBehaviour>.singleton.SetIntroText(true, xslashDataClip.Name, xslashDataClip.Discription, xslashDataClip.AnchorX, xslashDataClip.AnchorY);
            this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer(xslashDataClip.Duration, new XTimerMgr.ElapsedEventHandler(this.EndSlash), (object)null));
        }

        private void EndShow(object o)
        {
            if (this._bFadeAtEnd)
                XAutoFade.FadeOut2In(1f, 1f);
            this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer(0.984f, this._endCb, (object)null));
        }

        private void EndSlash(object o) => DlgBase<CutSceneUI, CutSceneUIBehaviour>.singleton.SetIntroText(false, "", "", 0.0f, 0.0f);

        private void EndSubTitle(object o) => DlgBase<CutSceneUI, CutSceneUIBehaviour>.singleton.SetText("");

        private void InnerEnd(object o)
        {
            if (this._cut_scene_data.OverrideBGM)
                XSingleton<XScene>.singleton.ResumeBGM();
            XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
            for (int index = 0; index < this._eventToken.Count; ++index)
                XSingleton<XTimerMgr>.singleton.KillTimer(this._eventToken[index]);
            this._eventToken.Clear();
            XBillBoardDocument.SetAllBillBoardState(BillBoardHideType.CutScene, true);
            for (int index = 0; index < this._fx.Count; ++index)
            {
                if (!this._common_fx.Contains(this._fx[index]))
                    XSingleton<XFxMgr>.singleton.DestroyFx(this._fx[index]);
            }
            this._fx.Clear();
            for (int index = 0; index < this._actors.Count; ++index)
            {
                if (!this._common_actors.ContainsValue(this._actors[index]))
                    this._actors[index].Uninitilize();
            }
            this._actors.Clear();
            this._actors = (List<XActor>)null;
            XSingleton<XScene>.singleton.GameCamera.FovBack();
            this._cut_scene = false;
            this._name = (string)null;
            XSingleton<XEntityMgr>.singleton.Dedummilize();
            this.Reflection();
            if (this._cut_scene_data.Mourningborder)
            {
                this.EndSubTitle((object)null);
                DlgBase<CutSceneUI, CutSceneUIBehaviour>.singleton.SetVisible(false, true);
                XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.BlackWhite, XSingleton<XEntityMgr>.singleton.Player.IsDead);
            }
            if (!string.IsNullOrEmpty(this._cut_scene_data.CameraClip))
            {
                XCameraMotionEndEventArgs motionEndEventArgs = XEventPool<XCameraMotionEndEventArgs>.GetEvent();
                motionEndEventArgs.Target = this._target;
                motionEndEventArgs.Firer = (XObject)XSingleton<XScene>.singleton.GameCamera;
                motionEndEventArgs.CutSceneEnd = true;
                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)motionEndEventArgs);
            }
            if (this._target != null && this._target.IsDummy)
                XSingleton<XEntityMgr>.singleton.DestroyImmediate(this._target);
            this._target = (XEntity)null;
            XSingleton<XInput>.singleton.Freezed = false;
            if (XSingleton<XGame>.singleton.CurrentStage is XConcreteStage)
                XSingleton<XGameUI>.singleton.ShowBlock(false);
            if (XSingleton<XEntityMgr>.singleton.Player != null && !XSingleton<XLevelFinishMgr>.singleton.IsCurrentLevelFinished)
            {
                XSingleton<XAIGeneralMgr>.singleton.EnablePlayerAI(true);
                List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly((XEntity)XSingleton<XEntityMgr>.singleton.Player);
                for (int index = 0; index < ally.Count; ++index)
                {
                    if (ally[index] != XSingleton<XEntityMgr>.singleton.Player)
                    {
                        XAIEnableAI xaiEnableAi = XEventPool<XAIEnableAI>.GetEvent();
                        xaiEnableAi.Firer = (XObject)ally[index];
                        xaiEnableAi.Enable = true;
                        XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xaiEnableAi);
                    }
                }
            }
            XSingleton<XScene>.singleton.GameCamera.TrySolo();
            this.EndWithPos = Vector3.zero;
            this.GeneralMonsterID = 0U;
            XSingleton<XScene>.singleton.GameCamera.UnityCamera.farClipPlane = this.farClipPlaneBackUP;
            if (!XSingleton<XGame>.singleton.SyncMode && !XOperationData.Is3DMode() && XEntity.ValideEntity((XEntity)XSingleton<XEntityMgr>.singleton.Player))
                XSingleton<XScene>.singleton.GameCamera.Root_R_Y = XSingleton<XCommon>.singleton.AngleToFloat(XSingleton<XEntityMgr>.singleton.Player.MoveObj.Forward);
            if (!DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible())
                return;
            DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshWelcomeBackFlow();
        }

        private void CorrectToEndPos()
        {
            if (XSingleton<XGame>.singleton.SyncMode)
                return;
            List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly((XEntity)XSingleton<XEntityMgr>.singleton.Player);
            for (int index = 0; index < ally.Count; ++index)
            {
                if (ally[index].IsRole || ally[index].MobbedBy != null && ally[index].MobbedBy.IsRole && ally[index].Attributes != null && (double)ally[index].Attributes.RunSpeed > 0.0)
                {
                    XOnEntityTransferEventArgs transferEventArgs = XEventPool<XOnEntityTransferEventArgs>.GetEvent();
                    transferEventArgs.Firer = (XObject)ally[index];
                    XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)transferEventArgs);
                    ally[index].CorrectMe(this.EndWithPos, XSingleton<XCommon>.singleton.FloatToAngle(this.EndWithDir));
                }
            }
        }
    }
}
