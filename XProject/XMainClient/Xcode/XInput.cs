

using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XInput : XSingleton<XInput>
    {
        private GameObject _45hide = (GameObject)null;
        private XEntity _last_enemy = (XEntity)null;
        private XEntity _last_npc = (XEntity)null;
        private XEntity _last_role = (XEntity)null;
        private XEntity _last_dummy = (XEntity)null;
        private Vector3 _last_move_point = Vector3.zero;
        private Vector3 _last_ground_point = Vector3.zero;
        private float _last_move_at = 0.0f;
        private float _last_entity_at = 0.0f;
        private RaycastHit _hit;
        private int _freeze_count = 0;
        private bool _hasMove = false;
        private bool _hasEnemy = false;
        private bool _hasNpc = false;
        private bool _hasRole = false;
        private bool _hasDummy = false;
        private bool _ally_fx_shield = false;
        private bool _mob_shield = false;
        private bool _my_fx_shield = false;
        private XTableAsyncLoader _async_loader = (XTableAsyncLoader)null;
        private XOperationTable _reader = new XOperationTable();

        public override bool Init()
        {
            if (this._async_loader == null)
            {
                this._async_loader = new XTableAsyncLoader();
                this._async_loader.AddTask("Table/XOperation", (CVSReader)this._reader);
                this._async_loader.Execute();
            }
            return this._async_loader.IsDone;
        }

        public override void Uninit() => this._async_loader = (XTableAsyncLoader)null;

        public void UnFreezed()
        {
            if (!this.Freezed)
                return;
            this._freeze_count = 1;
            this.Freezed = false;
        }

        public bool Freezed
        {
            get => XSingleton<XGesture>.singleton.Freezed && XSingleton<XVirtualTab>.singleton.Freezed;
            set
            {
                if (XSingleton<XScene>.singleton.bSpectator || value)
                {
                    if (this._freeze_count == 0)
                    {
                        XSingleton<XGesture>.singleton.Freezed = true;
                        XSingleton<XVirtualTab>.singleton.Freezed = true;
                        XSingleton<XActionSender>.singleton.Empty();
                    }
                    ++this._freeze_count;
                    if (!(XSingleton<XGame>.singleton.CurrentStage is XConcreteStage))
                        return;
                    XSingleton<XDebug>.singleton.AddLog("Freeze++: ", this._freeze_count.ToString());
                }
                else
                {
                    --this._freeze_count;
                    if (this._freeze_count == 0)
                    {
                        XSingleton<XGesture>.singleton.Freezed = false;
                        XSingleton<XVirtualTab>.singleton.Freezed = false;
                    }
                    else if (this._freeze_count < 0)
                        this._freeze_count = 0;
                    if (XSingleton<XGame>.singleton.CurrentStage is XConcreteStage)
                        XSingleton<XDebug>.singleton.AddLog("Freeze--: ", this._freeze_count.ToString());
                }
            }
        }

        public bool HasMove => this._hasMove;

        public bool HasEnemy => this._hasEnemy;

        public bool HasNpc => this._hasNpc;

        public bool HasRole => this._hasRole;

        public bool HasDummy => this._hasDummy;

        public float LastMoveAt => this._last_move_at;

        public float LastEntityAt => this._last_entity_at;

        public XEntity LastEnemy => this._last_enemy;

        public XEntity LastNpc
        {
            get => this._last_npc;
            set
            {
                this._last_npc = value;
                this._hasNpc = this._last_npc != null;
            }
        }

        public XEntity LastRole => this._last_role;

        public XEntity LastDummy => this._last_dummy;

        public Vector3 LastMovePoint => this._last_move_point;

        public Vector3 LastGroundPoint => this._last_ground_point;

        public bool IsFxShield => this._ally_fx_shield;

        public bool IsMyFxShield => this._my_fx_shield;

        public void OnEnterScene()
        {
            this._45hide = (GameObject)null;
            this._freeze_count = 0;
            XSingleton<XVirtualTab>.singleton.OnEnterScene();
            XSingleton<XGesture>.singleton.OnEnterScene();
            XSingleton<XGyroscope>.singleton.OnEnterScene();
            this.UpdateShieldOperation();
            this.UnFreezed();
        }

        public void OnLeaveScene() => this._last_npc = (XEntity)null;

        public void UpdateShieldOperation()
        {
            XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
            if (specificDocument == null)
                return;
            this._ally_fx_shield = (uint)specificDocument.GetValue(XOptionsDefine.OD_Shield_Skill_Fx) > 0U;
            this._mob_shield = (uint)specificDocument.GetValue(XOptionsDefine.OD_Shield_Summon) > 0U;
            this._my_fx_shield = (uint)specificDocument.GetValue(XOptionsDefine.OD_Shield_My_Skill_Fx) > 0U;
            if (XSingleton<XEntityMgr>.singleton.Player != null)
            {
                List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly((XEntity)XSingleton<XEntityMgr>.singleton.Player);
                for (int index1 = 0; index1 < ally.Count; ++index1)
                {
                    if (ally[index1].Skill != null && ally[index1].Skill.SkillMobs != null)
                    {
                        for (int index2 = 0; index2 < ally[index1].Skill.SkillMobs.Count; ++index2)
                            ally[index1].Skill.SkillMobs[index2].MobShield = this.MobShield(ally[index1].Skill.SkillMobs[index2]);
                    }
                }
            }
        }

        public void UpdateDefaultCameraOperationByScene()
        {
            SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
            XOperationTable.RowData rowData = (XOperationTable.RowData)null;
            switch (XSingleton<XOperationData>.singleton.OperationMode)
            {
                case XOperationMode.X25D:
                    rowData = this._reader.GetByID((int)sceneData.OperationSettings[1]);
                    break;
                case XOperationMode.X3D:
                case XOperationMode.X3D_Free:
                    rowData = this._reader.GetByID((int)sceneData.OperationSettings[0]);
                    break;
            }
            if (rowData == null)
                return;
            XSingleton<XOperationData>.singleton.CameraAngle = rowData.Angle;
            XSingleton<XOperationData>.singleton.CameraDistance = rowData.Distance;
            XSingleton<XOperationData>.singleton.AllowVertical = rowData.Vertical;
            XSingleton<XOperationData>.singleton.AllowHorizontal = rowData.Horizontal;
            XSingleton<XOperationData>.singleton.MaxVertical = rowData.MaxV;
            XSingleton<XOperationData>.singleton.MinVertical = rowData.MinV;
            XSingleton<XOperationData>.singleton.OffSolo = rowData.OffSolo;
        }

        public bool FxShield(XEntity e) => this._ally_fx_shield && e != null && !e.IsPlayer && XSingleton<XEntityMgr>.singleton.IsAlly(e) || this._my_fx_shield && e != null && e.IsPlayer;

        public bool MobShield(XEntity e) => this._mob_shield && e != null && e.MobbedBy != null && !e.MobbedBy.IsPlayer && e.MobShieldable && XSingleton<XEntityMgr>.singleton.IsAlly(e);

        public bool UpdateOperationMode()
        {
            if (XSingleton<XCutScene>.singleton.IsPlaying)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Cannot change operation mode during cut-scene playing!");
                return false;
            }
            if (!(XSingleton<XGame>.singleton.CurrentStage is XConcreteStage))
                return false;
            this.InnerOperationModeUpdate();
            return true;
        }

        private void InnerOperationModeUpdate()
        {
            XSingleton<XGyroscope>.singleton.Cancel();
            XSingleton<XGesture>.singleton.Cancel();
            switch (XSingleton<XOperationData>.singleton.OperationMode)
            {
                case XOperationMode.X25D:
                    if ((Object)this._45hide == (Object)null)
                        this._45hide = GameObject.Find("Scene/45hide");
                    if ((Object)this._45hide != (Object)null && this._45hide.activeSelf)
                    {
                        this._45hide.SetActive(false);
                        break;
                    }
                    break;
                case XOperationMode.X3D:
                case XOperationMode.X3D_Free:
                    if ((Object)this._45hide == (Object)null)
                        this._45hide = GameObject.Find("Scene/45hide");
                    if ((Object)this._45hide != (Object)null && !this._45hide.activeSelf)
                    {
                        this._45hide.SetActive(true);
                        break;
                    }
                    break;
            }
            XSingleton<XScene>.singleton.GameCamera.SetSightType();
        }

        private XEntity HitOnEnemy() => (XEntity)null;

        private XEntity HitOnRole()
        {
            if (!XSingleton<XGesture>.singleton.OneUpTouch || XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall || !((Object)XSingleton<XScene>.singleton.GameCamera.UnityCamera != (Object)null) || !Physics.SphereCast(XSingleton<XScene>.singleton.GameCamera.UnityCamera.ScreenPointToRay(XSingleton<XGesture>.singleton.TouchPosition), 0.1f, out this._hit, float.PositiveInfinity, 1 << LayerMask.NameToLayer("Role")))
                return (XEntity)null;
            string s = this._hit.collider.gameObject.name.StartsWith("mount_") ? this._hit.collider.gameObject.name.Substring(6) : this._hit.collider.gameObject.name;
            ulong result = 0;
            if (!ulong.TryParse(s, out result))
                return (XEntity)null;
            XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(result);
            return entity == null || !entity.IsRole || entity.IsPlayer ? (XEntity)null : entity;
        }

        private XEntity HitOnDummy()
        {
            if (!XSingleton<XGesture>.singleton.OneUpTouch || XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall || !((Object)XSingleton<XScene>.singleton.GameCamera.UnityCamera != (Object)null) || !Physics.SphereCast(XSingleton<XScene>.singleton.GameCamera.UnityCamera.ScreenPointToRay(XSingleton<XGesture>.singleton.TouchPosition), 0.1f, out this._hit, float.PositiveInfinity, 1 << LayerMask.NameToLayer("Dummy")))
                return (XEntity)null;
            ulong result = 0;
            if (!ulong.TryParse(this._hit.collider.gameObject.name, out result))
                return (XEntity)null;
            XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(result);
            return entityConsiderDeath == null || !entityConsiderDeath.IsDummy ? (XEntity)null : entityConsiderDeath;
        }

        private XEntity HitOnNpc()
        {
            if (!XSingleton<XGesture>.singleton.OneUpTouch || XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall || !((Object)XSingleton<XScene>.singleton.GameCamera.UnityCamera != (Object)null) || !Physics.SphereCast(XSingleton<XScene>.singleton.GameCamera.UnityCamera.ScreenPointToRay(XSingleton<XGesture>.singleton.TouchPosition), 0.1f, out this._hit, float.PositiveInfinity, 1 << LayerMask.NameToLayer("Npc")))
                return (XEntity)null;
            ulong result = 0;
            if (!ulong.TryParse(this._hit.collider.gameObject.name, out result))
                return (XEntity)null;
            XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(result);
            return entity == null || !entity.IsNpc ? (XEntity)null : entity;
        }

        private Vector3 HitOnGround() => Vector3.zero;

        public void Update()
        {
            Vector3 zero = Vector3.zero;
            this._hasMove = false;
            this._hasEnemy = false;
            this._hasNpc = false;
            this._hasRole = false;
            this._hasDummy = false;
            XSingleton<XTouch>.singleton.Update();
            if (!XSingleton<XGesture>.singleton.Gestured)
                return;
            XEntity xentity1 = this.HitOnEnemy();
            this._hasEnemy = xentity1 != null;
            XEntity xentity2 = this.HitOnNpc();
            this._hasNpc = xentity2 != null;
            if (!this._hasEnemy && !this._hasNpc)
            {
                XEntity xentity3 = this.HitOnRole();
                this._hasRole = xentity3 != null;
                this._last_role = this._hasRole ? xentity3 : (XEntity)null;
                if (!this._hasRole)
                {
                    XEntity xentity4 = this.HitOnDummy();
                    this._hasDummy = xentity4 != null;
                    this._last_dummy = this._hasDummy ? xentity4 : (XEntity)null;
                    if (!this._hasDummy)
                    {
                        Vector3 vector3 = this.HitOnGround();
                        bool flag = vector3 != Vector3.zero;
                        if (XSingleton<XGesture>.singleton.OneTouch)
                        {
                            this._hasMove = flag;
                            if (this._hasMove)
                            {
                                this._last_move_point = vector3;
                                this._last_move_at = Time.time;
                            }
                        }
                        if (flag)
                            this._last_ground_point = vector3;
                    }
                }
            }
            else
            {
                this._last_enemy = xentity1;
                this._last_npc = xentity2;
                this._last_entity_at = Time.time;
            }
        }
    }
}
