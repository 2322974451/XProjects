

using KKSG;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class Process_RpcC2G_DoEnterScene
    {
        private static uint _runstate = 0;

        public static uint runstate => Process_RpcC2G_DoEnterScene._runstate;

        public static void OnReply(DoEnterSceneArg oArg, DoEnterSceneRes oRes)
        {
            if (oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("RpcC2G_DoEnterScene ERR_INVALID_REQUEST!");
            }
            else
            {
                if (!XSingleton<XScene>.singleton.bSceneLoadedRpcSend)
                    return;
                XSingleton<XScene>.singleton.bSceneServerReady = true;
                XSingleton<XScene>.singleton.bSceneLoadedRpcSend = false;
                XSingleton<XDebug>.singleton.AddLog("Enter scene ", XSingleton<XScene>.singleton.SceneID.ToString());
                if (oRes.errorcode == ErrorCode.ERR_DOENTERSCENE_FAILED)
                {
                    XSingleton<XDebug>.singleton.AddLog("ERR_DOENTERSCENE_FAILED");
                }
                else
                {
                    Process_RpcC2G_DoEnterScene._runstate = oRes.scenestate.runstate;
                    Vector3 pos = new Vector3(oRes.pos.x, oRes.pos.y, oRes.pos.z);
                    XSingleton<XCommon>.singleton.FloatToAngle(oRes.face);
                    Vector3 angle = XSingleton<XCommon>.singleton.FloatToAngle(oRes.initface);
                    XSingleton<XEntityMgr>.singleton.Player.Attributes.OnFightGroupChange(XSingleton<XGame>.singleton.SyncModeValue != 0 ? oRes.fightgroup : 1U);
                    XSingleton<XEntityMgr>.singleton.Player.Attributes.AppearAt = pos;
                    XSingleton<XEntityMgr>.singleton.Player.Net.CorrectNet(pos, angle, 0U);
                    XBattleDocument.MiniMapSetRotation(oRes.initface);
                    GameObject gameObject1 = GameObject.Find("Scene/BattlePoint");
                    XSingleton<XScene>.singleton.BattleTargetPoint = (Object)gameObject1 != (Object)null ? gameObject1.transform.position : Vector3.zero;
                    GameObject gameObject2 = GameObject.Find("Scene/NestPoint");
                    XSingleton<XScene>.singleton.NestTargetPoint = (Object)gameObject2 != (Object)null ? gameObject2.transform.position : Vector3.zero;
                    XSingleton<XScene>.singleton.GameCamera.Root_R_Y_Default = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Rotation.eulerAngles.y;
                    XSingleton<XScene>.singleton.GameCamera.Root_R_Y = XSingleton<XScene>.singleton.GameCamera.Root_R_Y_Default;
                    if (XSingleton<XScene>.singleton.GameCamera.Wall != null)
                        XSingleton<XScene>.singleton.GameCamera.Wall.TargetY = XSingleton<XScene>.singleton.GameCamera.Root_R_Y_Default;
                    if (XSingleton<XScene>.singleton.bSpectator)
                    {
                        XSingleton<XEntityMgr>.singleton.Puppets((XEntity)XSingleton<XEntityMgr>.singleton.Player, true, true);
                        XSingleton<XInput>.singleton.Freezed = true;
                        XSingleton<XEntityMgr>.singleton.Player.Attributes.OnFightGroupChange(2U);
                    }
                    else
                    {
                        if (XSingleton<XEntityMgr>.singleton.Player.Nav != null)
                            XSingleton<XEntityMgr>.singleton.Player.Nav.Active();
                        if (XSingleton<XEntityMgr>.singleton.Player.AI != null)
                            XSingleton<XEntityMgr>.singleton.Player.AI.Active();
                        if (((long)oRes.specialstate & (long)(1 << XFastEnumIntEqualityComparer<UnitSpecialState>.ToInt(UnitSpecialState.Unit_Puppet))) > 0L | ((long)oRes.specialstate & (long)(1 << XFastEnumIntEqualityComparer<UnitSpecialState>.ToInt(UnitSpecialState.Unit_Invisible))) > 0L)
                            XSingleton<XEntityMgr>.singleton.Player.UpdateSpecialStateFromServer(oRes.specialstate, uint.MaxValue);
                        else
                            XSingleton<XEntityMgr>.singleton.Player.Present.ShowUp();
                    }
                    if (XSingleton<XScene>.singleton.bSpectator)
                        XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID).IsCrossServerBattle = oRes.is_cross;
                    else
                        XDocuments.GetSpecificDocument<XBattleDocument>(XBattleDocument.uuID).IsCrossServerBattle = oRes.is_cross;
                    for (int index = 0; index < XSingleton<XGame>.singleton.Doc.Components.Count; ++index)
                        (XSingleton<XGame>.singleton.Doc.Components[index] as XDocComponent).OnEnterSceneFinally();
                    XOutlookHelper.SetStatusState(XSingleton<XEntityMgr>.singleton.Player.Attributes, (XEntity)XSingleton<XEntityMgr>.singleton.Player, oRes.state, true);
                    XSingleton<XScene>.singleton.SceneStarted = oRes.scenestate.isready;
                    if (!XSingleton<XScene>.singleton.SceneStarted && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible())
                    {
                        DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_PromptFrame.gameObject.SetActive(true);
                        DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLoadingPrompt((List<string>)null);
                    }
                    if (XSingleton<XScene>.singleton.bSpectator && oRes.iswatchend)
                        DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.ShowBackToMainCityTips();
                    XSingleton<XLevelFinishMgr>.singleton.LevelRewardToken = oRes.battlestamp;
                    if (XSingleton<XScene>.singleton.IsViewGridScene)
                        XSingleton<XEntityMgr>.singleton.Player.Net.SetHallSequence();
                    if (XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World)
                        XSingleton<XEntityMgr>.singleton.Player.Attributes.SecurityStatistics.OnStart();
                    XSingleton<XReconnection>.singleton.SetLoginReconnectFlag(oRes.lrdata != null);
                    if (oRes.lrdata != null)
                        XSingleton<XReconnection>.singleton.StartLoginReconnectSync(oRes.lrdata, oRes.otherunits);
                    else
                        XSingleton<XReconnection>.singleton.StartEnterSceneSync(oRes.otherunits);
                }
            }
        }

        public static void OnTimeout(DoEnterSceneArg oArg)
        {
        }
    }
}
