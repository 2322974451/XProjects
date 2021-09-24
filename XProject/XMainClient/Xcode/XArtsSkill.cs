

using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XArtsSkill : XSkill
    {
        private SmallBuffer<object> _fx;
        protected SmallBuffer<object> _combined_fx;
        private Vector3 _warning_face = Vector3.forward;
        private Vector3 _warning_pos = Vector3.zero;
        protected bool _end_solo_effect = false;
        protected bool _set_camera_effect = false;
        protected bool _combined_set_camera_effect = false;
        protected bool _set_camera_shake = false;
        protected bool _combined_set_camera_shake = false;
        protected bool _set_not_selected = false;
        protected bool _combined_set_not_selected = false;
        public static uint _move_mob_id = 99999999;
        private SmallBuffer<object> _mob_unit;

        public override int SkillType => 1;

        public override string AnimClipName => this._data.ClipName;

        public override void Initialize(XEntity firer)
        {
            base.Initialize(firer);
            this._fx.debugName = "XArtsSkill._fx";
            this._combined_fx.debugName = "XArtsSkill._combined_fx";
            this._mob_unit.debugName = "XArtsSkill._mob_unit";
            XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._fx, 16);
            XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._mob_unit, 16);
            XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._combined_fx, 16);
        }

        public override void Uninitialize()
        {
            base.Uninitialize();
            XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this._fx);
            XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this._mob_unit);
            XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this._combined_fx);
        }

        protected override bool InnerProcessTimer(object param, int id)
        {
            if (!base.InnerProcessTimer(param, id))
            {
                switch (id)
                {
                    case 2:
                        this.OnResult(param);
                        return true;
                    case 3:
                        this.QTEOn(param);
                        return true;
                    case 4:
                        this.QTEOff(param);
                        return true;
                    case 5:
                        this.PreservedSAt(param);
                        return true;
                    case 6:
                        this.PreservedSEnd(param);
                        return true;
                    case 7:
                        this.NotSelected(param);
                        return true;
                    case 8:
                        this.ExString(param);
                        return true;
                    case 9:
                        this.Manipulate(param);
                        return true;
                    case 10:
                        this.Mob(param);
                        return true;
                    case 11:
                        this.CastChain(param);
                        return true;
                    case 12:
                        this.Fx(param);
                        return true;
                    case 13:
                        this.Audio(param);
                        return true;
                    case 14:
                        this.Warning(param);
                        return true;
                    case 15:
                        this.Charge(param);
                        return true;
                    case 16:
                        this.Shake(param);
                        return true;
                    case 17:
                        this.CameraMotion(param);
                        return true;
                    case 18:
                        this.CameraPostEffect(param);
                        return true;
                    case 19:
                        this.SolidBlack(param);
                        return true;
                    case 20:
                        this.LoopResults(param);
                        return true;
                    case 21:
                        this.GroupResults(param);
                        return true;
                    case 22:
                        this.KillManipulate(param);
                        return true;
                    case 23:
                        this.KillFx(param);
                        return true;
                    case 24:
                        this.EndCameraPostEffect(param);
                        return true;
                }
            }
            return false;
        }

        protected override void Start()
        {
            base.Start();
            this._set_camera_effect = false;
            this._set_camera_shake = false;
            this._set_not_selected = false;
            if (this._data.NeedTarget)
            {
                this.FocusTarget(this._target);
                if (this._firer.IsPlayer)
                    this.Manual();
            }
            this.FireEvents();
        }

        protected virtual void FireEvents()
        {
            if (this._data.Result != null)
            {
                for (int index = 0; index < this._data.Result.Count; ++index)
                {
                    if (this._data.Result[index].LongAttackEffect || !XSingleton<XGame>.singleton.SyncMode || !this._demonstration)
                    {
                        this._data.Result[index].Token = index;
                        this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Result[index].At * this._time_scale, this._TimerCallback, (object)this._data.Result[index], XArtsSkill.EArtsSkillTimerCb.EOnResult), true);
                    }
                }
            }
            if (this._data.Charge != null)
            {
                for (int index = 0; index < this._data.Charge.Count; ++index)
                    this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>((this._data.Charge[index].Using_Curve ? 0.0f : this._data.Charge[index].At) * this._time_scale, this._TimerCallback, (object)this._data.Charge[index], XArtsSkill.EArtsSkillTimerCb.ECharge), true);
            }
            if (!this._demonstration && this._data.Logical != null)
            {
                if (this._data.Logical.QTEData != null)
                {
                    for (int index = 0; index < this._data.Logical.QTEData.Count; ++index)
                    {
                        if (this._firer.QTE != null && (uint)this._data.Logical.QTEData[index].QTE > 0U)
                        {
                            this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Logical.QTEData[index].At * this._time_scale, this._TimerCallback, (object)this._data.Logical.QTEData[index].QTE, XArtsSkill.EArtsSkillTimerCb.EQTEOn), true);
                            this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Logical.QTEData[index].End * this._time_scale, this._TimerCallback, (object)this._data.Logical.QTEData[index].QTE, XArtsSkill.EArtsSkillTimerCb.EQTEOff), true);
                        }
                    }
                }
                if (this._core.PreservedStrength > 0)
                {
                    this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Logical.PreservedAt * this._time_scale, this._TimerCallback, (object)this._core.PreservedStrength, XArtsSkill.EArtsSkillTimerCb.EPreservedSAt), true);
                    this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Logical.PreservedEndAt * this._time_scale, this._TimerCallback, (object)null, XArtsSkill.EArtsSkillTimerCb.EPreservedSEnd), true);
                }
            }
            if (!XSingleton<XGame>.singleton.SyncMode || this._demonstration)
            {
                if (!this._demonstration)
                {
                    if (this._data.Logical != null && !string.IsNullOrEmpty(this._data.Logical.Exstring))
                        this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Logical.Exstring_At * this._time_scale, this._TimerCallback, (object)this._data.Logical.Exstring, XArtsSkill.EArtsSkillTimerCb.EExString), true);
                    if (this._data.Manipulation != null)
                    {
                        for (int index = 0; index < this._data.Manipulation.Count; ++index)
                            this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Manipulation[index].At * this._time_scale, this._TimerCallback, (object)this._data.Manipulation[index], XArtsSkill.EArtsSkillTimerCb.EManipulate), true);
                    }
                    if (this._data.Chain != null && this._data.Chain.TemplateID > 0 && !string.IsNullOrEmpty(this._data.Chain.Name))
                        this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Chain.At * this._time_scale, this._TimerCallback, (object)this._data.Chain, XArtsSkill.EArtsSkillTimerCb.ECastChain), true);
                }
                if (this._data.Mob != null)
                {
                    for (int index = 0; index < this._data.Mob.Count; ++index)
                    {
                        if (this._data.Mob[index].TemplateID > 0)
                            this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Mob[index].At * this._time_scale, this._TimerCallback, (object)this._data.Mob[index], XArtsSkill.EArtsSkillTimerCb.EMob), true);
                    }
                }
            }
            if (this._data.Logical != null && (double)this._data.Logical.Not_Selected_End > 0.0)
            {
                this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Logical.Not_Selected_At * this._time_scale, this._TimerCallback, (object)this._core, XArtsSkill.EArtsSkillTimerCb.ENotSelected), true);
                this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Logical.Not_Selected_End * this._time_scale, this._TimerCallback, (object)null, XArtsSkill.EArtsSkillTimerCb.ENotSelected), true);
            }
            if (this._data.Fx != null && this._firer.IsVisible && !this._firer.MobShield)
            {
                bool flag = !XSingleton<XInput>.singleton.FxShield(this._firer);
                for (int index = 0; index < this._data.Fx.Count; ++index)
                {
                    if (!this._data.Fx[index].Shield | flag)
                        this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Fx[index].At * this._time_scale, this._TimerCallback, (object)this._data.Fx[index], XArtsSkill.EArtsSkillTimerCb.EFx), false);
                }
            }
            if (this._data.Audio != null && !this._firer.MobShield)
            {
                for (int index = 0; index < this._data.Audio.Count; ++index)
                    this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Audio[index].At * this._time_scale, this._TimerCallback, (object)this._data.Audio[index], XArtsSkill.EArtsSkillTimerCb.EAudio), false);
            }
            if (this._data.Warning != null)
            {
                for (int index = 0; index < this._data.Warning.Count; ++index)
                    this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Warning[index].At * this._time_scale, this._TimerCallback, (object)this._data.Warning[index], XArtsSkill.EArtsSkillTimerCb.EWarning), false);
            }
            if (this._demonstration || this._firer.IsPlayer || this._firer.IsBoss)
            {
                if (this._data.CameraEffect != null)
                {
                    for (int index = 0; index < this._data.CameraEffect.Count; ++index)
                        this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.CameraEffect[index].At * this._time_scale, this._TimerCallback, (object)this._data.CameraEffect[index], XArtsSkill.EArtsSkillTimerCb.EShake), false);
                }
                if (this._demonstration || this._firer.IsPlayer)
                {
                    if (this._data.CameraMotion != null && !string.IsNullOrEmpty(this._data.CameraMotion.Motion3D))
                        this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.CameraMotion.At * this._time_scale, this._TimerCallback, (object)this._core, XArtsSkill.EArtsSkillTimerCb.ECameraMotion), false);
                    if (this._data.CameraPostEffect != null)
                    {
                        if (!this._demonstration && !string.IsNullOrEmpty(this._data.CameraPostEffect.Effect))
                        {
                            this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.CameraPostEffect.At * this._time_scale, this._TimerCallback, (object)this._core, XArtsSkill.EArtsSkillTimerCb.ECameraPostEffect), false);
                            this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.CameraPostEffect.End * this._time_scale, this._TimerCallback, (object)this._core, XArtsSkill.EArtsSkillTimerCb.EEndCameraPostEffect), false);
                        }
                        if (!this._demonstration && this._data.CameraPostEffect.SolidBlack)
                        {
                            this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.CameraPostEffect.Solid_At * this._time_scale, this._TimerCallback, (object)this._core, XArtsSkill.EArtsSkillTimerCb.ESolidBlack), false);
                            this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.CameraPostEffect.Solid_End * this._time_scale, this._TimerCallback, (object)null, XArtsSkill.EArtsSkillTimerCb.ESolidBlack), false);
                        }
                    }
                }
            }
            if (!this._data.Logical.SuppressPlayer || this._demonstration)
                return;
            XSingleton<XEntityMgr>.singleton.DummilizePlayer();
        }

        protected override void Stop(bool cleanUp)
        {
            if (this._set_camera_effect)
            {
                XCameraMotionEndEventArgs motionEndEventArgs = XEventPool<XCameraMotionEndEventArgs>.GetEvent();
                motionEndEventArgs.Target = this._firer;
                motionEndEventArgs.Firer = (XObject)this._affect_camera;
                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)motionEndEventArgs);
                this._affect_camera.Ator.speed = 1f;
                if (this._firer.IsPlayer && this._end_solo_effect)
                    XSingleton<XScene>.singleton.GameCamera.TrySolo();
            }
            this._end_solo_effect = false;
            this._set_camera_effect = false;
            if (this._set_camera_shake)
            {
                XCameraShakeEventArgs xcameraShakeEventArgs = XEventPool<XCameraShakeEventArgs>.GetEvent();
                xcameraShakeEventArgs.Effect = (XCameraEffectData)null;
                xcameraShakeEventArgs.Firer = (XObject)this._affect_camera;
                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xcameraShakeEventArgs);
            }
            this._set_camera_shake = false;
            if (this._core == this.MainCore)
            {
                if (this._data.Logical != null && this._data.Logical.QTEData != null && (uint)this._data.Logical.QTEData.Count > 0U)
                    this.QTEOff((object)null);
                if (this._demonstration)
                {
                    XAttackShowEndArgs xattackShowEndArgs = XEventPool<XAttackShowEndArgs>.GetEvent();
                    xattackShowEndArgs.Firer = (XObject)this._firer;
                    xattackShowEndArgs.ForceQuit = false;
                    XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xattackShowEndArgs);
                }
            }
            for (int index = 0; index < this._fx.Count; ++index)
            {
                if (this._fx[index] is XFx fx1)
                    XSingleton<XFxMgr>.singleton.DestroyFx(fx1, cleanUp);
            }
            if (this._data.Manipulation != null && this._data.Manipulation.Count > 0)
            {
                XManipulationOffEventArgs xmanipulationOffEventArgs = XEventPool<XManipulationOffEventArgs>.GetEvent();
                xmanipulationOffEventArgs.DenyToken = 0L;
                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xmanipulationOffEventArgs);
            }
            if (this._data.Logical != null && this._core.PreservedStrength > 0)
                this.PreservedSEnd((object)null);
            if (this._mob_unit.Count > 0)
            {
                for (int index = 0; index < this._mob_unit.Count; ++index)
                {
                    XEntity x = this._mob_unit[index] as XEntity;
                    if (x.LifewithinMobbedSkill)
                        XSingleton<XEntityMgr>.singleton.DestroyEntity(x);
                }
            }
            this._mob_unit.Clear();
            XSingleton<XAudioMgr>.singleton.StopSound((XObject)this._firer, AudioChannel.Skill);
            if (this._data.Logical != null && this._data.Logical.SuppressPlayer && !this._demonstration)
                XSingleton<XEntityMgr>.singleton.DedummilizePlayer();
            if (this._data.CameraPostEffect != null)
            {
                if (!this._demonstration && !string.IsNullOrEmpty(this._data.CameraPostEffect.Effect))
                    this._core.EndCameraPostEffect();
                if (!this._demonstration && this._data.CameraPostEffect.SolidBlack)
                    this._affect_camera.SolidCancel();
            }
            this._fx.Clear();
            if (this._set_not_selected)
                this._firer.CanSelected = true;
            this._set_not_selected = false;
        }

        protected override bool Present() => !XSingleton<XCommon>.singleton.IsGreater(this._timeElapsed, this.MainCore.Soul.Time * this._time_scale);

        protected override void Result(XResultData data)
        {
            if (data.Loop)
                this.LoopResults((object)(data.Index << 16));
            else if (data.Group)
                this.GroupResults((object)(data.Index << 16));
            else if (data.LongAttackEffect)
                this.Project(data);
            else
                XSkill.SkillResult(this._token, this._firer, this._core, data.Index, this.MainCore.ID, data.Token, this._firer.Rotate.GetMeaningfulFaceVector3(), this._firer.EngineObject.Position);
        }

        private void Project(XResultData param, int additional = 0, int loop = 0, int group = 0)
        {
            if (param.LongAttackData == null)
                return;
            if (param.Attack_All)
            {
                List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(this._firer);
                for (int index = 0; index < opponent.Count; ++index)
                {
                    if (XEntity.ValideEntity(opponent[index]) && (opponent[index].MobbedBy == null || param.Mobs_Inclusived))
                        XSingleton<XBulletMgr>.singleton.ShootBullet(this.GenerateBullet(param, opponent[index], additional, loop, group, extrainfo: true));
                }
            }
            else if (param.Warning)
            {
                for (int wid = 0; wid < this._core.WarningPosAt[param.Warning_Idx].Count; ++wid)
                    XSingleton<XBulletMgr>.singleton.ShootBullet(this.GenerateBullet(param, (XEntity)null, additional, loop, group, wid, true));
            }
            else if (param.LongAttackData.Reinforce)
            {
                if (loop == 0 && group == 0)
                {
                    List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(this._firer);
                    for (int index = 0; index < opponent.Count; ++index)
                    {
                        if (XEntity.ValideEntity(opponent[index]) && opponent[index].Buffs != null && opponent[index].Buffs.IsBuffStateOn(XBuffType.XBuffType_Mark))
                            XSingleton<XBulletMgr>.singleton.ShootBullet(this.GenerateBullet(param, opponent[index], additional, 0, 0, extrainfo: true));
                    }
                }
            }
            else
                XSingleton<XBulletMgr>.singleton.ShootBullet(this.GenerateBullet(param, this.Target, additional, loop, group));
        }

        private void LoopResults(object param)
        {
            int num1 = (int)param;
            int num2 = num1 >> 16;
            int loop = num1 & (int)ushort.MaxValue;
            if (!this._data.Result[num2].Loop || (double)this._data.Result[num2].Cycle <= 0.0 || loop >= this._data.Result[num2].Loop_Count)
                return;
            if (this._data.Result[num2].Group)
                this.GroupResults((object)(num2 << 16 | loop << 8 | 0));
            else if (this._data.Result[num2].LongAttackEffect)
                this.Project(this._data.Result[num2], loop: loop);
            else
                XSkill.SkillResult(this._token, this._firer, this._core, num2, this.MainCore.ID, this._data.Result[num2].Token, this._firer.EngineObject.Forward, this._firer.EngineObject.Position);
            if (!this._demonstration && !XEntity.ValideEntity(this._firer))
                return;
            int num3 = loop + 1;
            if (num3 >= this._data.Result[num2].Loop_Count)
                return;
            int num4 = num2 << 16 | num3;
            this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Result[num2].Cycle * this._time_scale, this._TimerCallback, (object)num4, XArtsSkill.EArtsSkillTimerCb.ELoopResults), true);
        }

        private void GroupResults(object param)
        {
            int num1 = (int)param;
            int num2 = num1 >> 16;
            int group = num1 & (int)byte.MaxValue;
            int loop = (num1 & 65280) >> 8;
            if (!this._data.Result[num2].Group || group >= this._data.Result[num2].Group_Count)
                return;
            Vector3 forward = this._firer.EngineObject.Forward;
            int num3 = this._data.Result[num2].Deviation_Angle + this._data.Result[num2].Angle_Step * group;
            int additional = this._data.Result[num2].Clockwise ? num3 : -num3;
            if (this._data.Result[num2].LongAttackEffect)
                this.Project(this._data.Result[num2], additional, loop, group);
            else
                XSkill.SkillResult(this._token, this._firer, this._core, num2, this.MainCore.ID, this._data.Result[num2].Token, XSingleton<XCommon>.singleton.HorizontalRotateVetor3(forward, (float)additional), this._firer.EngineObject.Position);
            if (!this._demonstration && !XEntity.ValideEntity(this._firer))
                return;
            int num4 = group + 1;
            if (num4 >= this._data.Result[num2].Group_Count)
                return;
            int num5 = num2 << 16 | loop << 8 | num4;
            this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Result[num2].Time_Step * this._time_scale, this._TimerCallback, (object)num5, XArtsSkill.EArtsSkillTimerCb.EGroupResults), true);
        }

        protected void Charge(object o) => this.ChargeTo((o as XChargeData).Index);

        protected void QTEOn(object o)
        {
            if (this._firer.Destroying || this._firer.QTE == null)
                return;
            XSkillQTEEventArgs xskillQteEventArgs = XEventPool<XSkillQTEEventArgs>.GetEvent();
            xskillQteEventArgs.Firer = (XObject)this._firer;
            xskillQteEventArgs.State = o != null ? (uint)(int)o : 0U;
            xskillQteEventArgs.On = true;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xskillQteEventArgs);
        }

        protected void QTEOff(object o)
        {
            if (this._firer.Destroying || this._firer.QTE == null)
                return;
            XSkillQTEEventArgs xskillQteEventArgs = XEventPool<XSkillQTEEventArgs>.GetEvent();
            xskillQteEventArgs.Firer = (XObject)this._firer;
            xskillQteEventArgs.State = o != null ? (uint)(int)o : 0U;
            xskillQteEventArgs.On = false;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xskillQteEventArgs);
        }

        protected void ChargeTo(int o)
        {
            int num1 = o;
            int index = num1 & (int)byte.MaxValue;
            float num2 = (float)(num1 >> 16) / 1000f;
            XChargeEventArgs xchargeEventArgs = XEventPool<XChargeEventArgs>.GetEvent();
            xchargeEventArgs.Token = this._token;
            xchargeEventArgs.Data = this._data.Charge[index];
            xchargeEventArgs.TimeGone = num2;
            xchargeEventArgs.TimeScale = this._time_scale;
            xchargeEventArgs.AimedTarget = xchargeEventArgs.Data.AimTarget ? this.Target : (XEntity)null;
            xchargeEventArgs.TimeSpan = this._data.Charge[index].End - (this._data.Charge[index].Using_Curve ? 0.0f : this._data.Charge[index].At);
            xchargeEventArgs.Firer = (XObject)this._firer;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xchargeEventArgs);
        }

        protected void Audio(object o)
        {
            XAudioData xaudioData = o as XAudioData;
            XSingleton<XAudioMgr>.singleton.PlaySound((XObject)this._firer, xaudioData.Channel, xaudioData.Clip);
        }

        protected void PreservedSAt(object o)
        {
            int num = (int)o;
            XStrengthPresevationOnArgs presevationOnArgs = XEventPool<XStrengthPresevationOnArgs>.GetEvent();
            presevationOnArgs.Host = this._firer;
            presevationOnArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)presevationOnArgs);
            XAttrChangeEventArgs xattrChangeEventArgs = XEventPool<XAttrChangeEventArgs>.GetEvent();
            xattrChangeEventArgs.AttrKey = XAttributeDefine.XAttr_CurrentXULI_Basic;
            xattrChangeEventArgs.DeltaValue = (double)num - this._firer.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentXULI_Basic);
            xattrChangeEventArgs.Firer = (XObject)this._firer;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xattrChangeEventArgs);
        }

        protected void PreservedSEnd(object o)
        {
            XStrengthPresevationOffArgs presevationOffArgs = XEventPool<XStrengthPresevationOffArgs>.GetEvent();
            presevationOffArgs.Host = this._firer;
            presevationOffArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)presevationOffArgs);
        }

        protected void ExString(object o) => XSingleton<XLevelScriptMgr>.singleton.SetExternalString(o as string, false);

        protected void Manipulate(object o)
        {
            XManipulationData xmanipulationData = o as XManipulationData;
            XManipulationOnEventArgs xmanipulationOnEventArgs = XEventPool<XManipulationOnEventArgs>.GetEvent();
            xmanipulationOnEventArgs.data = xmanipulationData;
            xmanipulationOnEventArgs.Firer = (XObject)this._firer;
            long token = xmanipulationOnEventArgs.Token;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xmanipulationOnEventArgs);
            this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>((xmanipulationData.End - xmanipulationData.At) * this._time_scale, this._TimerCallback, (object)token, XArtsSkill.EArtsSkillTimerCb.EKillManipulate), true);
        }

        protected void MoveMob()
        {
            XMoveMobEventArgs xmoveMobEventArgs = XEventPool<XMoveMobEventArgs>.GetEvent();
            xmoveMobEventArgs.Firer = (XObject)this._firer;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xmoveMobEventArgs);
        }

        protected void Mob(object o)
        {
            XMobUnitData xmobUnitData = o as XMobUnitData;
            if ((long)xmobUnitData.TemplateID == (long)XArtsSkill._move_mob_id)
            {
                this.MoveMob();
            }
            else
            {
                Vector3 vector3 = this._firer.EngineObject.Position + this._firer.EngineObject.Rotation * new Vector3(xmobUnitData.Offset_At_X, xmobUnitData.Offset_At_Y, xmobUnitData.Offset_At_Z);
                if (!this._demonstration)
                {
                    float y = 0.0f;
                    if (!XSingleton<XScene>.singleton.TryGetTerrainY(vector3, out y) || (double)y < 0.0)
                        vector3 = this._firer.EngineObject.Position;
                }
                XEntity xentity = this._demonstration ? (XEntity)XSingleton<XEntityMgr>.singleton.CreateDummy((uint)xmobUnitData.TemplateID, vector3, this._firer.EngineObject.Rotation) : XSingleton<XEntityMgr>.singleton.CreateEntityByCaller(this._firer, (uint)xmobUnitData.TemplateID, vector3, this._firer.EngineObject.Rotation, true, this._firer.Attributes.FightGroup);
                if (xentity == null)
                    return;
                if (xentity.IsDummy)
                {
                    xentity.LifewithinMobbedSkill = true;
                    xentity.MobShield = false;
                }
                else
                {
                    xentity.MobShieldable = xmobUnitData.Shield;
                    xentity.MobShield = XSingleton<XInput>.singleton.MobShield(xentity);
                    xentity.LifewithinMobbedSkill = xmobUnitData.LifewithinSkill;
                }
                if (this._firer.Skill.AddSkillMob(xentity))
                {
                    if (!xentity.IsDummy)
                    {
                        XSingleton<XSkillEffectMgr>.singleton.SetMobProperty(xentity, this._firer, this._core.ID);
                        if (this._firer.IsBoss)
                            XSecurityAIInfo.TryGetStatistics(this._firer)?.OnExternalCallMonster();
                    }
                    this._mob_unit.Add((object)xentity);
                }
            }
        }

        protected void CastChain(object o)
        {
            if (this._firer.Skill.SkillMobs == null)
                return;
            XCastChain xcastChain = o as XCastChain;
            for (int index = 0; index < this._firer.Skill.SkillMobs.Count; ++index)
            {
                if ((long)this._firer.Skill.SkillMobs[index].TypeID == (long)xcastChain.TemplateID && XEntity.ValideEntity(this._firer.Skill.SkillMobs[index]))
                {
                    XAttackEventArgs xattackEventArgs = XEventPool<XAttackEventArgs>.GetEvent();
                    xattackEventArgs.Identify = XSingleton<XCommon>.singleton.XHash(xcastChain.Name);
                    xattackEventArgs.Firer = (XObject)this._firer.Skill.SkillMobs[index];
                    xattackEventArgs.Target = (XEntity)null;
                    XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xattackEventArgs);
                }
            }
        }

        private XFx FilterFx(Vector3 pos, string path)
        {
            if (string.IsNullOrEmpty(path))
                return (XFx)null;
            if (!XSingleton<XScene>.singleton.FilterFx || this._firer == null || this._firer.IsPlayer || this._firer.IsBoss || this._firer is XDummy)
                return XSingleton<XFxMgr>.singleton.CreateFx(path);
            Vector3 position = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position;
            return ((double)pos.x - (double)position.x) * ((double)pos.x - (double)position.x) + ((double)pos.z - (double)position.z) * ((double)pos.z - (double)position.z) < (double)XFxMgr.FilterFxDis4 ? XSingleton<XFxMgr>.singleton.CreateFx(path) : (XFx)null;
        }

        protected void Fx(object o)
        {
            XFxData xfxData = o as XFxData;
            Vector3 offset = Vector3.zero;
            XGameObject parent = this._firer.IsTransform ? this._firer.Transformer.EngineObject : this._firer.EngineObject;
            switch (xfxData.Type)
            {
                case SkillFxType.FirerBased:
                    offset = new Vector3(xfxData.OffsetX, xfxData.OffsetY, xfxData.OffsetZ);
                    parent = this._firer.IsTransform ? this._firer.Transformer.EngineObject : this._firer.EngineObject;
                    break;
                case SkillFxType.TargetBased:
                    if (this._data.NeedTarget && this.HasValidTarget())
                    {
                        offset = new Vector3(xfxData.Target_OffsetX, xfxData.Target_OffsetY, xfxData.Target_OffsetZ);
                        parent = this.Target.IsTransform ? this.Target.Transformer.EngineObject : this.Target.EngineObject;
                        break;
                    }
                    offset = new Vector3(xfxData.OffsetX, xfxData.OffsetY, xfxData.OffsetZ);
                    parent = this._firer.IsTransform ? this._firer.Transformer.EngineObject : this._firer.EngineObject;
                    break;
            }
            XFx fx;
            if (!this._demonstration && xfxData.StickToGround)
            {
                offset.y = 0.0f;
                Vector3 vector3 = parent.Position + parent.Rotation * offset;
                vector3.y = XSingleton<XScene>.singleton.TerrainY(vector3);
                Quaternion ground = XSingleton<XCommon>.singleton.RotateToGround(vector3, parent.Forward);
                fx = this.FilterFx(vector3, xfxData.Fx);
                if (fx == null)
                    return;
                fx.DelayDestroy = xfxData.Destroy_Delay * this._time_scale;
                fx.Play(vector3, ground, new Vector3(xfxData.ScaleX, xfxData.ScaleY, xfxData.ScaleZ), this._time_scale);
            }
            else
            {
                fx = this.FilterFx(parent.Position, xfxData.Fx);
                if (fx == null)
                    return;
                fx.DelayDestroy = xfxData.Destroy_Delay * this._time_scale;
                fx.Play(parent, offset, new Vector3(xfxData.ScaleX, xfxData.ScaleY, xfxData.ScaleZ), this._time_scale, xfxData.Follow, transName: xfxData.Bone);
            }
            this.RegisterFx(fx, ((double)xfxData.End <= 0.0 || (double)xfxData.End >= (xfxData.Combined ? (double)this.MainCore.Soul.Time : (double)this._core.Soul.Time) ? -1f : xfxData.End - xfxData.At) * this._time_scale, xfxData.Combined);
        }

        protected void Warning(object o)
        {
            XWarningData xwarningData = o as XWarningData;
            this._core.WarningPosAt[xwarningData.Index].Clear();
            if (xwarningData.RandomWarningPos || xwarningData.Type == XWarningType.Warning_Multiple)
            {
                ulong num1 = 0;
                List<XSkillCore.XWarningRandomPackage> xwarningRandomPackageList = this._core.WarningRandomAt[xwarningData.Index];
                for (int index1 = 0; index1 < xwarningRandomPackageList.Count; ++index1)
                {
                    XEntity xentity = xwarningRandomPackageList[index1].ID == 0UL ? this.Target : XSingleton<XEntityMgr>.singleton.GetEntity(xwarningRandomPackageList[index1].ID);
                    for (int index2 = 0; index2 < xwarningRandomPackageList[index1].Pos.Count; ++index2)
                    {
                        ++num1;
                        if (xentity != null)
                        {
                            uint po = xwarningRandomPackageList[index1].Pos[index2];
                            float num2 = (float)(po & (uint)ushort.MaxValue) / 10f;
                            uint num3 = po >> 16;
                            XSkillCore.XSkillWarningPackage xskillWarningPackage = new XSkillCore.XSkillWarningPackage();
                            Vector3 vector3 = num2 * XSingleton<XCommon>.singleton.HorizontalRotateVetor3(Vector3.forward, (float)num3);
                            float x = xentity.EngineObject.Position.x + vector3.x;
                            float z = xentity.EngineObject.Position.z + vector3.z;
                            float y = 0.0f;
                            if (!XSingleton<XScene>.singleton.TryGetTerrainY(new Vector3(x, y, z), out y) || (double)y < 0.0)
                                y = xentity.EngineObject.Position.y;
                            xskillWarningPackage.WarningAt = new Vector3(x, y, z);
                            xskillWarningPackage.WarningTo = num1;
                            this._core.WarningPosAt[xwarningData.Index].Add(xskillWarningPackage);
                            XFx fx = this.FilterFx(xskillWarningPackage.WarningAt, xwarningData.Fx);
                            if (fx != null)
                            {
                                fx.Play(xskillWarningPackage.WarningAt, this._demonstration ? Quaternion.identity : XSingleton<XCommon>.singleton.RotateToGround(xskillWarningPackage.WarningAt, Vector3.forward), xwarningData.Scale * Vector3.one, this._time_scale);
                                if (fx != null)
                                    this.RegisterFx(fx, xwarningData.FxDuration * this._time_scale, false);
                            }
                        }
                    }
                }
            }
            else
            {
                switch (xwarningData.Type)
                {
                    case XWarningType.Warning_None:
                        XSkillCore.XSkillWarningPackage xskillWarningPackage1 = new XSkillCore.XSkillWarningPackage();
                        Vector3 vector3_1 = this._firer.EngineObject.Rotation * new Vector3(xwarningData.OffsetX, xwarningData.OffsetY, xwarningData.OffsetZ);
                        float x1 = this._firer.EngineObject.Position.x + vector3_1.x;
                        float z1 = this._firer.EngineObject.Position.z + vector3_1.z;
                        float y1 = 0.0f;
                        if (!this._demonstration && !XSingleton<XScene>.singleton.TryGetTerrainY(new Vector3(x1, y1, z1), out y1) || (double)y1 < 0.0)
                            y1 = this._firer.EngineObject.Position.y;
                        y1 = this._demonstration ? this._firer.EngineObject.Position.y : y1 + vector3_1.y;
                        xskillWarningPackage1.WarningAt = new Vector3(x1, y1, z1);
                        xskillWarningPackage1.WarningTo = 0UL;
                        this._core.WarningPosAt[xwarningData.Index].Add(xskillWarningPackage1);
                        XFx fx1 = this.FilterFx(xskillWarningPackage1.WarningAt, xwarningData.Fx);
                        if (fx1 != null)
                        {
                            fx1.Play(xskillWarningPackage1.WarningAt, this._demonstration ? Quaternion.identity : XSingleton<XCommon>.singleton.RotateToGround(xskillWarningPackage1.WarningAt, Vector3.forward), xwarningData.Scale * Vector3.one, this._time_scale);
                            if (fx1 != null)
                                this.RegisterFx(fx1, xwarningData.FxDuration * this._time_scale, false);
                            break;
                        }
                        break;
                    case XWarningType.Warning_Target:
                        XSkillCore.XSkillWarningPackage xskillWarningPackage2 = new XSkillCore.XSkillWarningPackage();
                        if (this.HasValidTarget())
                        {
                            xskillWarningPackage2.WarningAt = new Vector3(this.Target.EngineObject.Position.x, XSingleton<XScene>.singleton.TerrainY(this.Target.EngineObject.Position), this.Target.EngineObject.Position.z);
                            xskillWarningPackage2.WarningTo = this.Target.ID;
                            this._core.WarningPosAt[xwarningData.Index].Add(xskillWarningPackage2);
                        }
                        else
                        {
                            Vector3 vector3_2 = this._firer.EngineObject.Rotation * new Vector3(xwarningData.OffsetX, xwarningData.OffsetY, xwarningData.OffsetZ);
                            float x2 = this._firer.EngineObject.Position.x + vector3_2.x;
                            float z2 = this._firer.EngineObject.Position.z + vector3_2.z;
                            float y2 = 0.0f;
                            if (!this._demonstration && !XSingleton<XScene>.singleton.TryGetTerrainY(new Vector3(x2, y2, z2), out y2) || (double)y2 < 0.0)
                                y2 = this._firer.EngineObject.Position.y;
                            y2 = this._demonstration ? this._firer.EngineObject.Position.y : y2 + vector3_2.y;
                            xskillWarningPackage2.WarningAt = new Vector3(x2, y2, z2);
                            xskillWarningPackage2.WarningTo = 0UL;
                            this._core.WarningPosAt[xwarningData.Index].Add(xskillWarningPackage2);
                        }
                        XFx fx2 = this.FilterFx(xskillWarningPackage2.WarningAt, xwarningData.Fx);
                        if (fx2 != null)
                        {
                            fx2.Play(xskillWarningPackage2.WarningAt, this._demonstration ? Quaternion.identity : XSingleton<XCommon>.singleton.RotateToGround(xskillWarningPackage2.WarningAt, Vector3.forward), xwarningData.Scale * Vector3.one, this._time_scale);
                            if (fx2 != null)
                                this.RegisterFx(fx2, xwarningData.FxDuration * this._time_scale, false);
                            break;
                        }
                        break;
                    case XWarningType.Warning_All:
                        List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(this._firer);
                        for (int index = 0; index < opponent.Count; ++index)
                        {
                            if (XEntity.ValideEntity(opponent[index]) && (opponent[index].MobbedBy == null || xwarningData.Mobs_Inclusived))
                            {
                                XSkillCore.XSkillWarningPackage xskillWarningPackage3 = new XSkillCore.XSkillWarningPackage()
                                {
                                    WarningAt = opponent[index].EngineObject.Position
                                };
                                xskillWarningPackage3.WarningAt.y = XSingleton<XScene>.singleton.TerrainY(opponent[index].EngineObject.Position);
                                xskillWarningPackage3.WarningTo = opponent[index].ID;
                                this._core.WarningPosAt[xwarningData.Index].Add(xskillWarningPackage3);
                                XFx fx3 = this.FilterFx(xskillWarningPackage3.WarningAt, xwarningData.Fx);
                                if (fx3 != null)
                                {
                                    fx3.Play(xskillWarningPackage3.WarningAt, XSingleton<XCommon>.singleton.RotateToGround(xskillWarningPackage3.WarningAt, Vector3.forward), xwarningData.Scale * Vector3.one, this._time_scale);
                                    this.RegisterFx(fx3, xwarningData.FxDuration * this._time_scale, false);
                                }
                            }
                        }
                        break;
                }
            }
        }

        protected void CameraMotion(object o)
        {
            if (XSingleton<XLevelFinishMgr>.singleton.IsCurrentLevelFinished)
                return;
            XSkillCore xskillCore = o as XSkillCore;
            this._affect_camera.Ator.speed = this.TimeScale;
            XCameraMotionEventArgs xcameraMotionEventArgs = XEventPool<XCameraMotionEventArgs>.GetEvent();
            xcameraMotionEventArgs.Motion = xskillCore.Soul.CameraMotion.Clone() as XCameraMotionData;
            xcameraMotionEventArgs.Motion.Follow_Position = true;
            xcameraMotionEventArgs.Motion.Coordinate = CameraMotionSpace.World;
            switch (XSingleton<XOperationData>.singleton.OperationMode)
            {
                case XOperationMode.X25D:
                    xcameraMotionEventArgs.Motion.MotionType = string.IsNullOrEmpty(xcameraMotionEventArgs.Motion.Motion2_5D) ? xcameraMotionEventArgs.Motion.Motion3DType : xcameraMotionEventArgs.Motion.Motion2_5DType;
                    xcameraMotionEventArgs.Motion.Motion = string.IsNullOrEmpty(xcameraMotionEventArgs.Motion.Motion2_5D) ? xcameraMotionEventArgs.Motion.Motion3D : xcameraMotionEventArgs.Motion.Motion2_5D;
                    break;
                case XOperationMode.X3D:
                case XOperationMode.X3D_Free:
                    xcameraMotionEventArgs.Motion.MotionType = xcameraMotionEventArgs.Motion.Motion3DType;
                    xcameraMotionEventArgs.Motion.Motion = xcameraMotionEventArgs.Motion.Motion3D;
                    break;
            }
            switch (xcameraMotionEventArgs.Motion.MotionType)
            {
                case CameraMotionType.AnchorBased:
                    xcameraMotionEventArgs.Motion.AutoSync_At_Begin = true;
                    xcameraMotionEventArgs.Motion.LookAt_Target = false;
                    if (XSingleton<XScene>.singleton.GameCamera.Solo != null)
                    {
                        XSingleton<XScene>.singleton.GameCamera.Solo.Stop();
                        this._end_solo_effect = true;
                        break;
                    }
                    break;
                case CameraMotionType.CameraBased:
                    xcameraMotionEventArgs.Motion.AutoSync_At_Begin = false;
                    break;
            }
            xcameraMotionEventArgs.Target = this._firer;
            xcameraMotionEventArgs.Trigger = "ToEffect";
            xcameraMotionEventArgs.Firer = (XObject)this._affect_camera;
            if (xskillCore != this._core)
                this._combined_set_camera_effect = XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xcameraMotionEventArgs);
            else
                this._set_camera_effect = XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xcameraMotionEventArgs);
        }

        protected void CameraPostEffect(object o) => (o as XSkillCore).StartCameraPostEffect();

        protected void EndCameraPostEffect(object o) => (o as XSkillCore).EndCameraPostEffect();

        protected void NotSelected(object o)
        {
            this._firer.CanSelected = o == null;
            if (this._firer.CanSelected)
                return;
            if (o as XSkillCore == this.MainCore)
                this._combined_set_not_selected = true;
            else
                this._set_not_selected = true;
        }

        protected void Shake(object o)
        {
            XCameraEffectData xcameraEffectData = o as XCameraEffectData;
            XCameraShakeEventArgs xcameraShakeEventArgs = XEventPool<XCameraShakeEventArgs>.GetEvent();
            xcameraShakeEventArgs.Effect = xcameraEffectData;
            xcameraShakeEventArgs.TimeScale = this._time_scale;
            xcameraShakeEventArgs.Firer = (XObject)this._affect_camera;
            if (xcameraEffectData.Combined)
                this._combined_set_camera_shake = XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xcameraShakeEventArgs);
            else
                this._set_camera_shake = XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xcameraShakeEventArgs);
        }

        protected void SolidBlack(object o)
        {
            if (o == null)
                this._affect_camera.SolidCancel();
            else
                this._affect_camera.SolidBlack();
        }

        private void KillManipulate(object o)
        {
            XManipulationOffEventArgs xmanipulationOffEventArgs = XEventPool<XManipulationOffEventArgs>.GetEvent();
            xmanipulationOffEventArgs.DenyToken = (long)o;
            xmanipulationOffEventArgs.Firer = (XObject)this._firer;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xmanipulationOffEventArgs);
        }

        private void KillFx(object o)
        {
            XFx fx = o as XFx;
            this._fx.Remove((object)fx);
            this._combined_fx.Remove((object)fx);
            XSingleton<XFxMgr>.singleton.DestroyFx(fx, false);
        }

        private XBullet GenerateBullet(
          XResultData data,
          XEntity target,
          int additional,
          int loop,
          int group,
          int wid = -1,
          bool extrainfo = false)
        {
            ulong bulletid = this._firer.Net == null ? (ulong)XSingleton<XCommon>.singleton.UniqueToken : (ulong)((long)loop << 56 | (long)group << 48 | (long)this.GetCombinedId() << 40 | (long)data.Index << 32) | (ulong)(uint)this._token;
            int diviation = data.LongAttackData.FireAngle + additional;
            XBullet bullet = XSingleton<XBulletMgr>.singleton.CreateBullet(bulletid, this._token, this._firer, target, this._core, data, this.MainCore.ID, diviation, this._demonstration, wid);
            if (extrainfo)
                bullet.ExtraID = XEntity.ValideEntity(target) ? target.ID : this._core.WarningPosAt[data.Warning_Idx][wid].WarningTo;
            return bullet;
        }

        private void RegisterFx(XFx fx, float duration, bool combined)
        {
            if (combined)
            {
                this._combined_fx.Add((object)fx);
                if ((double)duration <= 0.0)
                    return;
                (this as XCombinedSkill).AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(duration, this._TimerCallback, (object)fx, XArtsSkill.EArtsSkillTimerCb.EKillFx));
            }
            else
            {
                this._fx.Add((object)fx);
                if ((double)duration > 0.0)
                    this.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(duration, this._TimerCallback, (object)fx, XArtsSkill.EArtsSkillTimerCb.EKillFx), false);
            }
        }

        protected enum EArtsSkillTimerCb
        {
            EOnResult = 2,
            EQTEOn = 3,
            EQTEOff = 4,
            EPreservedSAt = 5,
            EPreservedSEnd = 6,
            ENotSelected = 7,
            EExString = 8,
            EManipulate = 9,
            EMob = 10, 
            ECastChain = 11, 
            EFx = 12, 
            EAudio = 13, 
            EWarning = 14, 
            ECharge = 15, 
            EShake = 16, 
            ECameraMotion = 17, 
            ECameraPostEffect = 18, 
            ESolidBlack = 19, 
            ELoopResults = 20, 
            EGroupResults = 21, 
            EKillManipulate = 22, 
            EKillFx = 23, 
            EEndCameraPostEffect = 24, 
            EArtsSkillNum = 25, 
        }
    }
}
