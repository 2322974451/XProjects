

using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XBullet
    {
        private ulong _id = 0;
        private ulong _extra_id = 0;
        private bool _active = true;
        private bool _effectual = true;
        private bool _pingpong = false;
        private bool _hit_triggered = false;
        private int _tail_results = 0;
        private uint _tail_results_token = 0;
        private float _elapsed = 0.0f;
        private XFx _bullet = (XFx)null;
        private XBulletCore _data;
        private Vector3 _origin = Vector3.zero;
        private SmallBuffer<XBullet.XBulletTarget> _hurt_target;
        private IXFmod _iFmod;

        public XBulletCore BulletCore => this._data;

        public ulong ID => this._id;

        public ulong ExtraID
        {
            get => this._extra_id;
            set => this._extra_id = value;
        }

        public XBullet(ulong id, XBulletCore data) => this.Init(id, data);

        public void Deny() => this._effectual = false;

        private void LoadFinish(Object obj, object cbOjb)
        {
            if (this._iFmod != null)
            {
                this._iFmod.Destroy();
                XSingleton<XUpdater.XUpdater>.singleton.XPlatform.ReturnClass(EClassType.ERuntimeFMOD, (object)this._iFmod);
                this._iFmod = (IXFmod)null;
            }
            if (string.IsNullOrEmpty(this._data.Result.LongAttackData.Audio))
                return;
            this._iFmod = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CreateClass(EClassType.ERuntimeFMOD) as IXFmod;
            Rigidbody rigidbody = (Rigidbody)null;
            GameObject go = obj as GameObject;
            if ((Object)go != (Object)null)
                rigidbody = go.GetComponent<Rigidbody>();
            if (this._iFmod != null)
            {
                this._iFmod.Init(go, rigidbody);
                XSingleton<XAudioMgr>.singleton.PlaySound(this._iFmod, AudioChannel.Motion, this._data.Result.LongAttackData.Audio);
            }
        }

        private XFx FilterFx(string path)
        {
            if (string.IsNullOrEmpty(path))
                return XSingleton<XFxMgr>.singleton.CreateFx("", new LoadCallBack(this.LoadFinish));
            if (!XSingleton<XScene>.singleton.FilterFx || this._data.Firer != null && (this._data.Firer.IsPlayer || this._data.Firer.IsBoss || this._data.Firer is XDummy) || this._data.Target != null && this._data.Target.IsPlayer)
                return XSingleton<XFxMgr>.singleton.CreateFx(path);
            Vector3 position = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position;
            Vector3 origin = this._data.BulletRay.origin;
            float num1 = XFxMgr.FilterFxDis4;
            float num2 = (float)(((double)origin.x - (double)position.x) * ((double)origin.x - (double)position.x) + ((double)origin.z - (double)position.z) * ((double)origin.z - (double)position.z));
            if (this._data.Result != null && this._data.Result.LongAttackData != null)
                num1 = this._data.Result.LongAttackData.Velocity * this._data.Result.LongAttackData.Runningtime;
            return (double)num2 < (double)XFxMgr.FilterFxDis4 || (double)num2 < (double)num1 * (double)num1 ? XSingleton<XFxMgr>.singleton.CreateFx(this._data.Prefab, new LoadCallBack(this.LoadFinish)) : XSingleton<XFxMgr>.singleton.CreateFx("", new LoadCallBack(this.LoadFinish));
        }

        public void Init(ulong id, XBulletCore data)
        {
            this._id = id;
            this._extra_id = 0UL;
            this._active = true;
            this._effectual = true;
            this._tail_results = 0;
            this._pingpong = false;
            this._hit_triggered = false;
            this._elapsed = 0.0f;
            this._data = data;
            this._origin = Vector3.zero;
            this._bullet = this.FilterFx(XSingleton<XGlobalConfig>.singleton.PreFilterPrefab(this._data.Prefab));
            this._bullet.Play(this._data.BulletRay.origin, (double)this._data.Velocity > 0.0 ? Quaternion.LookRotation(this._data.BulletRay.direction) : Quaternion.LookRotation(this._data.Firer.EngineObject.Forward), Vector3.one);
            this._hurt_target.debugName = "XBullet._hurt_target";
            XSingleton<XBulletMgr>.singleton.GetSmallBuffer(ref this._hurt_target, 4);
        }

        private void OnRefined(object o)
        {
            ulong num = (ulong)o;
            int index = 0;
            for (int count = this._hurt_target.Count; index < count; ++index)
            {
                XBullet.XBulletTarget xbulletTarget = this._hurt_target[index];
                if ((long)xbulletTarget.TargetID == (long)num && xbulletTarget.HurtCount < this._data.Result.LongAttackData.Refine_Count)
                {
                    xbulletTarget.Hurtable = true;
                    this._hurt_target[index] = xbulletTarget;
                    break;
                }
            }
        }

        private void OnRefined()
        {
            int index = 0;
            for (int count = this._hurt_target.Count; index < count; ++index)
            {
                XBullet.XBulletTarget xbulletTarget = this._hurt_target[index];
                xbulletTarget.Hurtable = true;
                xbulletTarget.HurtCount = 0;
                XSingleton<XTimerMgr>.singleton.KillTimer(xbulletTarget.TimerToken);
                this._hurt_target[index] = xbulletTarget;
            }
        }

        private void OnPingPong()
        {
            this._pingpong = true;
            if (!this._data.Result.LongAttackData.AutoRefine_at_Half)
                return;
            this.OnRefined();
        }

        public void Expire()
        {
            this._active = false;
            if ((uint)this._tail_results <= 0U)
                return;
            XSingleton<XTimerMgr>.singleton.KillTimer(this._tail_results_token);
            this._tail_results = this._data.Result.LongAttackData.TriggerAtEnd_Count;
        }

        public bool IsExpired()
        {
            if (!this._effectual || !this._data.Demonstration && !XEntity.ValideEntity(this._data.Firer))
                return true;
            if ((uint)this._tail_results > 0U)
                return this._tail_results >= this._data.Result.LongAttackData.TriggerAtEnd_Count;
            if (this._data.Result.LongAttackData.IsPingPong && !this._pingpong && XSingleton<XCommon>.singleton.IsGreater(this._elapsed, this._data.Life))
                this.OnPingPong();
            bool flag = !this._active || !this._pingpong && XSingleton<XCommon>.singleton.IsGreater(this._elapsed, this._data.Life);
            if (this._data.Result.LongAttackData.TriggerAtEnd_Count <= 0 || !flag)
                return flag;
            this._active = false;
            this.OnTailResult((object)null);
            return false;
        }

        private void OnTailResult(object o)
        {
            if (o == null)
            {
                this._tail_results = 0;
                this.FakeDestroyBulletObject();
            }
            if (this._tail_results >= this._data.Result.LongAttackData.TriggerAtEnd_Count)
                return;
            ++this._tail_results;
            this.TailResult(this._tail_results == 1);
            XSingleton<XTimerMgr>.singleton.KillTimer(this._tail_results_token);
            this._tail_results_token = XSingleton<XTimerMgr>.singleton.SetTimer(this._data.Result.LongAttackData.TriggerAtEnd_Cycle, new XTimerMgr.ElapsedEventHandler(this.OnTailResult), (object)this);
        }

        public bool IsHurtEntity(ulong id)
        {
            int index = 0;
            for (int count = this._hurt_target.Count; index < count; ++index)
            {
                XBullet.XBulletTarget xbulletTarget = this._hurt_target[index];
                if ((long)xbulletTarget.TargetID == (long)id)
                    return !xbulletTarget.Hurtable;
            }
            return false;
        }

        private void TailResult(bool present)
        {
            if (this._data.Result.LongAttackData.TriggerAtEnd)
            {
                if (this._data.Warning)
                    this._bullet.Position = this._data.WarningPos;
                if (!this._data.Demonstration && !XSingleton<XGame>.singleton.SyncMode)
                    this.Result((XEntity)null, this._data.Result.LongAttackData.TriggerAtEnd_Count == 0);
            }
            if (!present)
                return;
            if (!string.IsNullOrEmpty(this._data.Result.LongAttackData.End_Fx))
            {
                Vector3 position = this._bullet.Position;
                float y = 0.0f;
                if (this._data.Demonstration || XSingleton<XScene>.singleton.TryGetTerrainY(position, out y))
                {
                    XFx fx = XSingleton<XFxMgr>.singleton.CreateFx(this._data.Result.LongAttackData.End_Fx);
                    fx.DelayDestroy = this._data.Result.LongAttackData.EndFx_LifeTime;
                    Quaternion rotation = this._bullet.Rotation;
                    if (this._data.Result.LongAttackData.EndFx_Ground)
                    {
                        position.y = this._data.Demonstration ? this._bullet.Position.y : y;
                        rotation = this._data.Demonstration ? Quaternion.identity : XSingleton<XCommon>.singleton.RotateToGround(position, this._bullet.Forward);
                    }
                    fx.Play(position, rotation, Vector3.one);
                    XSingleton<XBulletMgr>.singleton.LogEndFx(fx);
                    XSingleton<XFxMgr>.singleton.DestroyFx(fx, false);
                }
            }
            if (string.IsNullOrEmpty(this._data.Result.LongAttackData.End_Audio))
                return;
            XSingleton<XAudioMgr>.singleton.PlaySound((XObject)this._data.Firer, AudioChannel.Motion, this._data.Result.LongAttackData.End_Audio, this._bullet.Position);
        }

        private void FakeDestroyBulletObject()
        {
            if (this._bullet == null)
                return;
            Vector3 position = this._bullet.Position;
            Quaternion rotation = this._bullet.Rotation;
            if (this._iFmod != null)
            {
                XSingleton<XAudioMgr>.singleton.StopSound(this._iFmod);
                this._iFmod.Destroy();
                XSingleton<XUpdater.XUpdater>.singleton.XPlatform.ReturnClass(EClassType.ERuntimeFMOD, (object)this._iFmod);
                this._iFmod = (IXFmod)null;
            }
            XSingleton<XFxMgr>.singleton.DestroyFx(this._bullet);
            this._bullet = (XFx)null;
            this._bullet = XSingleton<XFxMgr>.singleton.CreateFx("");
            this._bullet.Position = position;
            this._bullet.Rotation = rotation;
            this._bullet.SetActive(true);
        }

        public void Destroy(bool leave = false)
        {
            XSingleton<XTimerMgr>.singleton.KillTimer(this._tail_results_token);
            if (!leave && this._data.Result.LongAttackData.TriggerAtEnd_Count == 0 && (this._data.Demonstration || XEntity.ValideEntity(this._data.Firer)))
                this.TailResult(true);
            if (this._bullet != null)
            {
                if (this._iFmod != null)
                {
                    XSingleton<XAudioMgr>.singleton.StopSound(this._iFmod);
                    this._iFmod.Destroy();
                    XSingleton<XUpdater.XUpdater>.singleton.XPlatform.ReturnClass(EClassType.ERuntimeFMOD, (object)this._iFmod);
                    this._iFmod = (IXFmod)null;
                }
                XSingleton<XFxMgr>.singleton.DestroyFx(this._bullet);
                this._bullet = (XFx)null;
            }
            if ((double)this._data.Result.LongAttackData.Refine_Cycle > 0.0)
            {
                int index = 0;
                for (int count = this._hurt_target.Count; index < count; ++index)
                    XSingleton<XTimerMgr>.singleton.KillTimer(this._hurt_target[index].TimerToken);
            }
            XSingleton<XBulletMgr>.singleton.ReturnSmallBuffer(ref this._hurt_target);
        }

        public void OnResult(XEntity target)
        {
            if (XEntity.ValideEntity(target))
            {
                XBullet.XBulletTarget xbulletTarget;
                xbulletTarget.HurtCount = 0;
                xbulletTarget.TimerToken = 0U;
                xbulletTarget.TargetID = 0UL;
                int index1 = -1;
                int index2 = 0;
                for (int count = this._hurt_target.Count; index2 < count; ++index2)
                {
                    xbulletTarget = this._hurt_target[index2];
                    if ((long)xbulletTarget.TargetID == (long)target.ID)
                    {
                        index1 = index2;
                        break;
                    }
                }
                if (index1 < 0)
                {
                    xbulletTarget = new XBullet.XBulletTarget();
                    xbulletTarget.TargetID = target.ID;
                    index1 = this._hurt_target.Count;
                    this._hurt_target.Add(xbulletTarget);
                }
                XSingleton<XTimerMgr>.singleton.KillTimer(xbulletTarget.TimerToken);
                xbulletTarget.Hurtable = false;
                ++xbulletTarget.HurtCount;
                xbulletTarget.TimerToken = (double)this._data.Result.LongAttackData.Refine_Cycle > 0.0 ? XSingleton<XTimerMgr>.singleton.SetTimer(this._data.Result.LongAttackData.Refine_Cycle, new XTimerMgr.ElapsedEventHandler(this.OnRefined), (object)target.ID) : 0U;
                this._hurt_target[index1] = xbulletTarget;
                if (this._data.TriggerMove && XEntity.ValideEntity(this._data.Firer))
                {
                    Vector3 vector3 = (this._data.Firer.EngineObject.Position - target.EngineObject.Position).normalized * target.RealEntity.Radius;
                    this._data.Firer.CorrectMe(target.EngineObject.Position + vector3, this._data.Firer.EngineObject.Forward);
                }
            }
            if (!this._data.Result.LongAttackData.TriggerOnce)
                return;
            this.OnOnceTriggered();
        }

        private void OnOnceTriggered()
        {
            if (!this._data.Result.LongAttackData.TriggerOnce)
                return;
            if (this._data.Result.LongAttackData.IsPingPong)
                this.OnPingPong();
            else
                this._active = false;
        }

        private void Result(XEntity target, bool cycle = true)
        {
            if (this._data.Demonstration)
                return;
            if (target == null)
                XSkill.SkillResult(this, this._bullet.Forward, this._bullet.Position, cycle);
            else if (!this._data.Result.Attack_Only_Target || target == this._data.Target)
            {
                if (XSingleton<XGame>.singleton.SyncMode)
                {
                    if (this._data.Result.LongAttackData.TriggerOnce)
                        this.OnOnceTriggered();
                }
                else
                {
                    Vector3 hitdir = target.EngineObject.Position - this._origin;
                    hitdir.y = 0.0f;
                    hitdir.Normalize();
                    XSkill.SkillResult(this._data.Token, this._data.Firer, this._data.SkillCore, this, this._data.Sequnce, this._data.ResultID, this._data.ResultTime, hitdir, target);
                }
                if (this._data.Result.LongAttackData.TriggerOnce)
                    this._hit_triggered = true;
            }
        }

        public void Update(float fDeltaT)
        {
            if (!this._active)
                return;
            this._elapsed += fDeltaT;
            float num = 0.0f;
            Vector3 vector3_1 = Vector3.forward;
            switch (this._data.Result.LongAttackData.Type)
            {
                case XResultBulletType.Sphere:
                case XResultBulletType.Plane:
                    num = ((double)this._elapsed <= (double)this._data.Running || (double)this._elapsed >= (double)this._data.Life ? this._data.Velocity : 0.0f) * fDeltaT;
                    vector3_1 = this._bullet.Forward;
                    break;
                case XResultBulletType.Satellite:
                    if ((double)this._elapsed - (double)fDeltaT <= (double)XCommon.XEps)
                    {
                        Vector3 vector3_2 = this._data.Firer.EngineObject.Position + this._data.BulletRay.direction * this._data.Result.LongAttackData.RingRadius;
                        vector3_2.y = this._bullet.Position.y;
                        this._bullet.Position = vector3_2;
                        num = 0.0f;
                        vector3_1 = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(this._data.Firer.MoveObj.Forward, (double)this._data.Result.LongAttackData.Palstance < 0.0 ? -90f : 90f);
                        break;
                    }
                    Vector3 vector3_3 = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(this._data.BulletRay.direction, this._data.Result.LongAttackData.Palstance * (this._elapsed - fDeltaT)) * this._data.Result.LongAttackData.RingRadius;
                    Vector3 vector3_4 = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(this._data.BulletRay.direction, this._data.Result.LongAttackData.Palstance * this._elapsed) * this._data.Result.LongAttackData.RingRadius;
                    this._bullet.Forward = XSingleton<XCommon>.singleton.Horizontal(vector3_4 - vector3_3);
                    Vector3 vector3_5 = vector3_4 + this._data.Firer.EngineObject.Position - this._bullet.Position;
                    vector3_5.y = 0.0f;
                    num = vector3_5.magnitude;
                    vector3_1 = vector3_5.normalized;
                    break;
                case XResultBulletType.Ring:
                    Vector3 position1 = this._data.Firer.EngineObject.Position;
                    position1.y = this._bullet.Position.y;
                    this._bullet.Position = position1;
                    break;
            }
            if (this._data.Result.LongAttackData.IsPingPong && this._pingpong)
            {
                if (!this._data.Demonstration && !XEntity.ValideEntity(this._data.Firer))
                {
                    this._active = false;
                    return;
                }
                Vector3 vector3_6 = this._data.Firer.EngineObject.Position - this._bullet.Position;
                vector3_6.y = 0.0f;
                if ((double)num * (double)num >= (double)vector3_6.sqrMagnitude)
                {
                    this._active = false;
                    return;
                }
                vector3_1 = vector3_6.normalized;
            }
            else if (this._data.Result.LongAttackData.Follow && XEntity.ValideEntity(this._data.Target))
                vector3_1 = XSingleton<XCommon>.singleton.Horizontal(this._data.Target.EngineObject.Position - this._bullet.Position);
            if (this._data.Result.LongAttackData.Type != XResultBulletType.Satellite)
                this._bullet.Forward = vector3_1;
            Vector3 move = vector3_1 * num;
            this._origin = this._bullet.Position;
            this._bullet.Position += move;
            if (this._data.Demonstration)
                return;
            float y = 0.0f;
            if (!XSingleton<XScene>.singleton.TryGetTerrainY(this._bullet.Position, out y))
            {
                if (this._data.Result.LongAttackData.IsPingPong)
                    this.OnPingPong();
                else
                    this._active = false;
            }
            else if (this._data.Result.LongAttackData.StaticCollider && (double)y < 0.0)
            {
                if (this._data.Result.LongAttackData.IsPingPong)
                    this.OnPingPong();
                else
                    this._active = false;
            }
            else if (this._data.Result.LongAttackData.DynamicCollider && !XSingleton<XScene>.singleton.CheckDynamicBlock(this._origin, this._bullet.Position))
            {
                if (this._data.Result.LongAttackData.IsPingPong)
                    this.OnPingPong();
                else
                    this._active = false;
            }
            else
            {
                if (!this._data.HasTarget)
                {
                    if (this._data.FlyWithTerrain)
                    {
                        Vector3 position2 = this._bullet.Position;
                        position2.y = y + this._data.InitHeight;
                        this._bullet.Position = position2;
                    }
                    else if ((double)Mathf.Abs(this._bullet.Position.y - y) < 0.200000002980232 || (double)y < 0.0)
                    {
                        this._active = false;
                        if (string.IsNullOrEmpty(this._data.Result.LongAttackData.HitGround_Fx))
                            return;
                        XFx fx = XSingleton<XFxMgr>.singleton.CreateFx(this._data.Result.LongAttackData.HitGround_Fx);
                        fx.DelayDestroy = this._data.Result.LongAttackData.HitGroundFx_LifeTime;
                        Quaternion rotation = this._bullet.Rotation;
                        Quaternion ground = XSingleton<XCommon>.singleton.RotateToGround(this._bullet.Position, this._bullet.Forward);
                        fx.Play(this._bullet.Position, ground, Vector3.one);
                        XSingleton<XFxMgr>.singleton.DestroyFx(fx, false);
                        return;
                    }
                    move = this._bullet.Position - this._origin;
                }
                if (XSingleton<XGame>.singleton.SyncMode)
                    return;
                if (this._data.Result.LongAttackData.Manipulation)
                {
                    List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(this._data.Firer);
                    Vector3 position3 = this._bullet.Position;
                    for (int index = 0; index < opponent.Count; ++index)
                    {
                        XEntity e = opponent[index];
                        if (XEntity.ValideEntity(e))
                        {
                            Vector3 vector3_7 = position3 - e.EngineObject.Position;
                            vector3_7.y = 0.0f;
                            if ((double)vector3_7.magnitude < (double)this._data.Result.LongAttackData.ManipulationRadius)
                            {
                                float b = this._data.Result.LongAttackData.ManipulationForce * fDeltaT;
                                e.ApplyMove(vector3_7.normalized * Mathf.Min(vector3_7.magnitude, b));
                            }
                        }
                    }
                }
                if (this._hit_triggered || !this._data.Result.LongAttackData.WithCollision)
                    return;
                switch (this._data.Result.LongAttackData.Type)
                {
                    case XResultBulletType.Sphere:
                    case XResultBulletType.Satellite:
                        float hlen = new Vector3(move.x, 0.0f, move.z).magnitude * 0.5f;
                        vector3_1.y = 0.0f;
                        float rotation1 = (double)vector3_1.sqrMagnitude == 0.0 ? 0.0f : Vector3.Angle(Vector3.right, vector3_1);
                        if ((double)rotation1 > 0.0 && XSingleton<XCommon>.singleton.Clockwise(Vector3.right, vector3_1))
                            rotation1 = -rotation1;
                        XBullet.BulletCollideUnit(this._data.Firer, new Vector3(this._origin.x + vector3_1.x * hlen, 0.0f, this._origin.z + vector3_1.z * hlen), hlen, rotation1, this._data.Radius, this);
                        break;
                    case XResultBulletType.Plane:
                        XBullet.PlaneBulletCollideUnit(this._data.Firer, this._origin, move, this._data.Radius, this);
                        break;
                    case XResultBulletType.Ring:
                        float ir = (XSingleton<XCommon>.singleton.IsGreater(this._elapsed, this._data.Life) ? 0.0f : (this._data.Result.LongAttackData.RingFull ? (XSingleton<XCommon>.singleton.IsGreater(this._elapsed, this._data.Life * 0.5f) ? this._data.Life - this._elapsed : this._elapsed) : this._elapsed)) * this._data.Result.LongAttackData.RingVelocity;
                        float or = ir + this._data.Result.LongAttackData.RingRadius;
                        XBullet.RingBulletCollideUnit(this._data.Firer, ir, or, this);
                        break;
                }
            }
        }

        private static void RingBulletCollideUnit(XEntity firer, float ir, float or, XBullet bullet)
        {
            Vector3 position = firer.EngineObject.Position;
            List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(firer);
            for (int index1 = 0; index1 < opponent.Count; ++index1)
            {
                if (XEntity.ValideEntity(opponent[index1]))
                {
                    bool flag = false;
                    if (opponent[index1].Present != null && opponent[index1].Present.PresentLib.Huge)
                    {
                        SeqListRef<float> monsterColliders = opponent[index1].Present.PresentLib.HugeMonsterColliders;
                        for (int index2 = 0; index2 < monsterColliders.Count; ++index2)
                        {
                            float num = monsterColliders[index2, 2] * opponent[index1].Scale;
                            Vector3 vector3 = opponent[index1].HugeMonsterColliderCenter(index2) - position;
                            vector3.y = 0.0f;
                            float sqrMagnitude = vector3.sqrMagnitude;
                            flag = (double)sqrMagnitude > (double)ir * (double)ir && (double)sqrMagnitude < (double)or * (double)or;
                            if (flag)
                                break;
                        }
                    }
                    else
                    {
                        Vector3 vector3 = opponent[index1].RadiusCenter - position;
                        vector3.y = 0.0f;
                        float sqrMagnitude = vector3.sqrMagnitude;
                        flag = (double)sqrMagnitude > (double)ir * (double)ir && (double)sqrMagnitude < (double)or * (double)or;
                    }
                    if (flag)
                        bullet.Result(opponent[index1]);
                    if (bullet.IsExpired())
                        break;
                }
            }
        }

        private static void PlaneBulletCollideUnit(
          XEntity firer,
          Vector3 origin,
          Vector3 move,
          float r,
          XBullet bullet)
        {
            Vector3 vector3 = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(move, 90f);
            Vector3 q1 = origin + vector3 * r;
            Vector3 q2 = origin - vector3 * r;
            List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(firer);
            for (int index1 = 0; index1 < opponent.Count; ++index1)
            {
                if (XEntity.ValideEntity(opponent[index1]))
                {
                    bool flag = false;
                    if (opponent[index1].Present != null && opponent[index1].Present.PresentLib.Huge)
                    {
                        SeqListRef<float> monsterColliders = opponent[index1].Present.PresentLib.HugeMonsterColliders;
                        for (int index2 = 0; index2 < monsterColliders.Count; ++index2)
                        {
                            float num = monsterColliders[index2, 2] * opponent[index1].Scale;
                            Vector3 p1 = opponent[index1].HugeMonsterColliderCenter(index2);
                            flag = XSingleton<XCommon>.singleton.IsLineSegmentCross(p1, p1 - move, q1, q2);
                            if (flag)
                                break;
                        }
                    }
                    else
                    {
                        Vector3 radiusCenter = opponent[index1].RadiusCenter;
                        flag = XSingleton<XCommon>.singleton.IsLineSegmentCross(radiusCenter, radiusCenter - move, q1, q2);
                    }
                    if (flag)
                        bullet.Result(opponent[index1]);
                    if (bullet.IsExpired())
                        break;
                }
            }
        }

        private static void BulletCollideUnit(
          XEntity firer,
          Vector3 rectcenter,
          float hlen,
          float rotation,
          float r,
          XBullet bullet)
        {
            List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(firer);
            for (int index1 = 0; index1 < opponent.Count; ++index1)
            {
                if (XEntity.ValideEntity(opponent[index1]))
                {
                    bool flag = false;
                    if (opponent[index1].Present != null && opponent[index1].Present.PresentLib.Huge)
                    {
                        SeqListRef<float> monsterColliders = opponent[index1].Present.PresentLib.HugeMonsterColliders;
                        for (int index2 = 0; index2 < monsterColliders.Count; ++index2)
                        {
                            float r1 = monsterColliders[index2, 2] * opponent[index1].Scale;
                            Vector3 c = opponent[index1].HugeMonsterColliderCenter(index2) - rectcenter;
                            c.y = 0.0f;
                            flag = XSingleton<XCommon>.singleton.IsRectCycleCross(hlen, r, c, r1);
                            if (!flag)
                            {
                                float num = r1;
                                flag = (double)c.magnitude - (double)num < (double)r;
                            }
                            if (flag)
                                break;
                        }
                    }
                    else
                    {
                        Vector3 vector3 = opponent[index1].RadiusCenter;
                        vector3 -= rectcenter;
                        vector3.y = 0.0f;
                        vector3 = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(vector3, rotation, false);
                        flag = XSingleton<XCommon>.singleton.IsRectCycleCross(hlen, r, vector3, opponent[index1].Radius);
                        if (!flag)
                        {
                            float radius = opponent[index1].Radius;
                            flag = (double)vector3.magnitude - (double)radius < (double)r;
                        }
                    }
                    if (flag)
                        bullet.Result(opponent[index1]);
                    if (bullet.IsExpired())
                        break;
                }
            }
        }

        public struct XBulletTarget
        {
            public ulong TargetID;
            public uint TimerToken;
            public bool Hurtable;
            public int HurtCount;
        }
    }
}
