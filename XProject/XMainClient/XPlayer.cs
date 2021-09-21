// Decompiled with JetBrains decompiler
// Type: XMainClient.XPlayer
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
    internal sealed class XPlayer : XRole
    {
        private XLocateTargetComponent _located_target = (XLocateTargetComponent)null;
        private XRole _watch_to = (XRole)null;
        private IXPlayerAction _action = (IXPlayerAction)null;
        private bool _correct_me = false;
        public static int PlayerLayer = LayerMask.NameToLayer("Player");

        public XRole WatchTo => this._watch_to == null || this._watch_to.Deprecated ? (XRole)null : this._watch_to;

        public XLocateTargetComponent TargetLocated => this._located_target;

        public bool IsCorrectingMe => this._correct_me;

        public uint[] SkillSlot => this.Skill != null && this.Skill.IsSkillReplaced ? this.Skill.ReplacedSlot : this.Attributes.skillSlot;

        public override bool Initilize(int flag)
        {
            base.Initilize(flag);
            this._xobject.Tag = "Player";
            this._eEntity_Type |= XEntity.EnitityType.Entity_Player;
            this._layer = XPlayer.PlayerLayer;
            this._using_cc_move = true;
            this._client_predicted = true;
            this._action = XSingleton<XInterfaceMgr>.singleton.AttachInterface<IXPlayerAction>(1U, (IXPlayerAction)new XPlayerAction());
            XSingleton<XInterfaceMgr>.singleton.AttachInterface<IAssociatedCamera>(XSingleton<XCommon>.singleton.XHash("IAssociatedCamera"), (IAssociatedCamera)new XAssociatedCamera());
            if (!XSingleton<XScene>.singleton.bSpectator)
            {
                XSingleton<XComponentMgr>.singleton.CreateComponent((XObject)this, XActionGeneratorComponent.uuID);
                if (XSingleton<XSceneMgr>.singleton.SceneCanNavi(XSingleton<XScene>.singleton.SceneID))
                    this._nav = XSingleton<XComponentMgr>.singleton.CreateComponent((XObject)this, XNavigationComponent.uuID) as XNavigationComponent;
                if (XSingleton<XSceneMgr>.singleton.CanAutoPlay(XSingleton<XScene>.singleton.SceneID) && this._xobject.IsNotEmptyObject)
                {
                    if (this._ai == null)
                        this._ai = XSingleton<XComponentMgr>.singleton.CreateComponent((XObject)this, XAIComponent.uuID) as XAIComponent;
                    if (this._nav == null)
                        this._nav = XSingleton<XComponentMgr>.singleton.CreateComponent((XObject)this, XNavigationComponent.uuID) as XNavigationComponent;
                }
            }
            if (XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall && (double)XSingleton<XSceneMgr>.singleton.SpecifiedTargetLocatedRange(XSingleton<XScene>.singleton.SceneID) != 0.0)
                this._located_target = XSingleton<XComponentMgr>.singleton.CreateComponent((XObject)this, XLocateTargetComponent.uuID) as XLocateTargetComponent;
            return true;
        }

        public void UpdatePlayerAttr(XPlayerAttributes attr) => this._attr = (XAttributes)attr;

        public override void OnCreated()
        {
            XSingleton<XEntityMgr>.singleton.Player = this;
            if (this.Attributes.SkillLevelInfo != null)
                this.Attributes.SkillLevelInfo.RefreshSelfLinkedLevels((XEntity)this);
            base.OnCreated();
        }

        public override void OnDestroy()
        {
            XSingleton<XEntityMgr>.singleton.Player = (XPlayer)null;
            XSingleton<XInterfaceMgr>.singleton.DetachInterface(1U);
            XSingleton<XInterfaceMgr>.singleton.DetachInterface(XSingleton<XCommon>.singleton.XHash("IAssociatedCamera"));
            this._action = (IXPlayerAction)null;
            this._watch_to = (XRole)null;
            base.OnDestroy();
        }

        public override void Dying() => base.Dying();

        public override void Revive()
        {
            base.Revive();
            XSingleton<XLevelStatistics>.singleton.OnPlayerRevive();
        }

        public void PreUpdate() => this._action.RefreshPosition();

        public void WatchIt(XRole role)
        {
            this._watch_to = role;
            this._net.Pause = true;
            XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID).ChangeSpectator(role);
            XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID).ChangeSpectator(role);
            this.UpdateWatcher();
            XCameraSoloComponent solo = XSingleton<XScene>.singleton.GameCamera.Solo;
            if (solo == null)
                return;
            solo.Stop();
            XSingleton<XScene>.singleton.GameCamera.TrySolo();
        }

        public override void OnTransform(uint to)
        {
            base.OnTransform(to);
            XDocuments.GetSpecificDocument<XBattleSkillDocument>(XBattleSkillDocument.uuID)?.ResetAll(XSingleton<XScene>.singleton.SceneReady && this.IsTransform, true);
        }

        public override void UpdateWatcher()
        {
            if (!XSingleton<XScene>.singleton.bSpectator || this._watch_to == null)
                return;
            if (this._watch_to.Deprecated)
            {
                this._watch_to = (XRole)null;
            }
            else
            {
                this.MoveObj.Position = this._watch_to.MoveObj.Position;
                this.MoveObj.Rotation = this._watch_to.MoveObj.Rotation;
            }
        }

        protected override void PositionTo(Vector3 pos)
        {
            base.PositionTo(pos);
            this._correct_me = false;
            this._action.RefreshPosition();
        }

        public override void CorrectMe(Vector3 pos, Vector3 face, bool reconnected = false, bool fade = false)
        {
            XSingleton<XActionSender>.singleton.Empty();
            if (XSingleton<XScene>.singleton.bSpectator && XSingleton<XScene>.singleton.bSceneServerReady)
                return;
            this._correct_me = true;
            base.CorrectMe(pos, face, reconnected, fade);
        }

        public void OnGamePause(bool pause)
        {
            if (!pause)
                return;
            XSingleton<XVirtualTab>.singleton.Cancel();
            this.Net.ReportMoveAction(Vector3.zero);
            XSingleton<XActionSender>.singleton.Flush(true);
            XSingleton<XDebug>.singleton.AddLog("Player to BackGround.");
        }

        public XPlayerAttributes PlayerAttributes => this.Attributes as XPlayerAttributes;

        protected override void Move()
        {
            if (XSingleton<XScene>.singleton.bSpectator)
            {
                this.UpdateWatcher();
            }
            else
            {
                Vector3 hitNormal = XSingleton<XScene>.singleton.GameCamera.Collision.HitNormal;
                hitNormal.y = 0.0f;
                Vector3 movement = this._movement;
                movement.y = 0.0f;
                if ((double)hitNormal.sqrMagnitude > 0.0 && (double)movement.sqrMagnitude > 0.0 && (double)Vector3.Angle(movement, hitNormal) > 90.0)
                {
                    this.EdgeDetection(this.EngineObject.Forward, ref movement);
                    if ((double)Vector3.SqrMagnitude(XSingleton<XScene>.singleton.GameCamera.CameraTrans.position - this.EngineObject.Position) < 1.0)
                        this.ProjectNormal(hitNormal, ref movement);
                    this._movement.x = movement.x;
                    this._movement.z = movement.z;
                }
                base.Move();
                this.MoveLateUpdate();
            }
        }

        private void MoveLateUpdate()
        {
            if (XSingleton<XGame>.singleton.SyncMode && !XStateMgr.IsUnBattleState(this.Machine.Current))
                return;
            List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent((XEntity)this);
            for (int index1 = 0; index1 < opponent.Count; ++index1)
            {
                Vector3 position = this.MoveObj.Position;
                if (!opponent[index1].IsRole && (!opponent[index1].IsPuppet && !opponent[index1].IsSubstance || XEntity.ValideEntity(opponent[index1])) && (opponent[index1].Skill == null || !opponent[index1].Skill.IsCasting() || !opponent[index1].Skill.CurrentSkill.MainCore.Soul.IgnoreCollision) && opponent[index1].Attributes is XOthersAttributes attributes2 && attributes2.Blocked && (double)opponent[index1].MoveObj.Position.y <= (double)position.y + (double)this.Height)
                {
                    if (opponent[index1].Present != null && opponent[index1].Present.PresentLib.Huge)
                    {
                        SeqListRef<float> monsterColliders = opponent[index1].Present.PresentLib.HugeMonsterColliders;
                        for (int index2 = 0; index2 < monsterColliders.Count; ++index2)
                        {
                            float num = monsterColliders[index2, 2] * opponent[index1].Scale;
                            this.A(position, opponent[index1].HugeMonsterColliderCenter(index2), this.Radius + num);
                        }
                    }
                    else
                        this.A(position, opponent[index1].RadiusCenter, this.Radius + opponent[index1].Radius);
                }
            }
        }

        private void A(Vector3 me, Vector3 it, float r)
        {
            Vector3 v = me - it;
            v.y = 0.0f;
            if ((double)v.sqrMagnitude - (double)r * (double)r >= -1.0 / 1000.0)
                return;
            Vector3 vector3_1 = XSingleton<XCommon>.singleton.Horizontal(v);
            Vector3 vector3_2 = it + vector3_1 * r;
            float y = vector3_2.y;
            if (XSingleton<XScene>.singleton.TryGetTerrainY(vector3_2, out y) && (double)y >= 0.0 && XSingleton<XScene>.singleton.CheckDynamicBlock(this.MoveObj.Position, vector3_2))
            {
                if (this.StandOn)
                {
                    vector3_2.y = y + 0.25f;
                    this.MoveObj.Position = vector3_2;
                    int num = (int)this.MoveObj.Move(Vector3.down);
                }
                else
                {
                    vector3_2.y = me.y;
                    this.MoveObj.Position = vector3_2;
                }
            }
        }

        private bool EdgeDetection(Vector3 forward, ref Vector3 move)
        {
            RaycastHit hit;
            if (!this.RayDetection(forward, out hit))
                return false;
            this.ProjectNormal(hit.normal, ref move);
            return true;
        }

        private void ProjectNormal(Vector3 normal, ref Vector3 move)
        {
            Vector3 forward = Vector3.forward;
            Vector3 normal1 = normal;
            Vector3.OrthoNormalize(ref normal1, ref forward);
            move = Vector3.Project(move, forward);
        }

        private bool RayDetection(Vector3 ray, out RaycastHit hit)
        {
            int layerMask = 513;
            Vector3 position = this.EngineObject.Position;
            position.y += this.Height;
            return Physics.Raycast(position, ray, out hit, 1f, layerMask);
        }

        public override bool CastFakeShadow() => true;
    }
}
