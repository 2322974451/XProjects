using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XSkillCore
	{

		public XSkillCore(XEntity firer, XSkillData data, uint longid)
		{
			this._firer = firer;
			this._long_id = longid;
			this._id = XSingleton<XCommon>.singleton.XHash(data.Name);
			this._carrier_id = XSingleton<XSkillFactory>.singleton.GetTypeHash(data.TypeToken);
			this._hurt_target = ListPool<ulong>.Get();
			this.SoulRefine(data, false);
		}

		public void SoulRefine(XSkillData newsoul, bool ispvp = false)
		{
			this._notify_at = 0f;
			this._soul = newsoul;
			this._is_pvp_version = ispvp;
			bool flag = this._soul.Warning != null && this._soul.Warning.Count > 0;
			if (flag)
			{
				bool flag2 = this.WarningPosAt == null || this.WarningPosAt.Length != this._soul.Warning.Count;
				if (flag2)
				{
					this.WarningPosAt = new List<XSkillCore.XSkillWarningPackage>[this._soul.Warning.Count];
					for (int i = 0; i < this._soul.Warning.Count; i++)
					{
						this.WarningPosAt[i] = new List<XSkillCore.XSkillWarningPackage>();
					}
				}
			}
			this._offset = 0f;
			bool flag3 = !XSingleton<XGame>.singleton.SyncMode && this._soul.Charge.Count > 0;
			if (flag3)
			{
				bool using_Curve = this._soul.Charge[0].Using_Curve;
				if (using_Curve)
				{
					IXCurve curve = XSingleton<XResourceLoaderMgr>.singleton.GetCurve(this._soul.Charge[0].Curve_Forward);
					this._offset = Mathf.Abs(curve.GetValue(curve.length - 1) - curve.GetValue(0));
				}
				else
				{
					this._offset = Mathf.Abs(this._soul.Charge[0].Offset);
				}
			}
			bool flag4 = this._OnReloaded == null;
			if (flag4)
			{
				this._OnReloaded = new XTimerMgr.ElapsedEventHandler(this.OnReloaded);
			}
			this.InitCoreData(true);
		}

		public bool IsPvPVersion
		{
			get
			{
				return this._is_pvp_version;
			}
		}

		public string TriggerToken
		{
			get
			{
				return this._trigger_token_string;
			}
			set
			{
				this._trigger_token_string = value;
			}
		}

		public uint ID
		{
			get
			{
				return this._id;
			}
		}

		public uint LongID
		{
			get
			{
				return this._long_id;
			}
		}

		public uint Level
		{
			get
			{
				return this._skill_level;
			}
		}

		public int CarrierID
		{
			get
			{
				return this._carrier_id;
			}
		}

		public XSkill Carrier
		{
			get
			{
				return this._carrier;
			}
		}

		public XEntity Firer
		{
			get
			{
				return this._firer;
			}
		}

		public XSkillData Soul
		{
			get
			{
				return this._soul;
			}
		}

		public bool EverFired
		{
			get
			{
				return this._ever_fired;
			}
		}

		public bool HasInitCD
		{
			get
			{
				return this._init_cd > 0f;
			}
		}

		public bool CooledDown
		{
			get
			{
				return !this._is_init_cooling && this._current_running_time > 0;
			}
		}

		public bool Reloading
		{
			get
			{
				return this._is_init_cooling || this._current_running_time < this._totally_running_time;
			}
		}

		public bool ShowRunningTime
		{
			get
			{
				return this._totally_running_time > 1;
			}
		}

		public bool IsOnSyntonic
		{
			get
			{
				return this._is_on_syntonic;
			}
		}

		public int LeftRunningTime
		{
			get
			{
				return this._current_running_time;
			}
		}

		public float Offset
		{
			get
			{
				return this._offset;
			}
		}

		public int PreservedStrength
		{
			get
			{
				return (int)((double)(this._preserved_strength * ((this._soul.Logical == null) ? 0 : this._soul.Logical.PreservedStrength)) * XSingleton<XSkillEffectMgr>.singleton.GetXULIPower(this._firer));
			}
		}

		public float CastRangeUpper
		{
			get
			{
				return this._soul.Cast_Range_Upper;
			}
		}

		public float CastRangeLower
		{
			get
			{
				return this._soul.Cast_Range_Rect ? 0f : this._soul.Cast_Range_Lower;
			}
		}

		public float CastScope
		{
			get
			{
				return this._soul.Cast_Range_Rect ? this._soul.Cast_Scope : (this._soul.Cast_Scope * 0.5f);
			}
		}

		public void Clear()
		{
			this._soul = null;
		}

		public void Uninit()
		{
			bool flag = this._hurt_target != null;
			if (flag)
			{
				ListPool<ulong>.Release(this._hurt_target);
				this._hurt_target = null;
			}
			this.ClearWarningPos();
		}

		public void Recycle(XEntity firer)
		{
			this._firer = firer;
			this._last_lock_and_load_time = 0f;
			this._dynamic_cd_ratio = 1f;
			this._dynamic_cd_delta = 0f;
			this.InitCoreData(true);
			this._current_running_time = this._totally_running_time;
			this._hurt_target = ListPool<ulong>.Get();
			this.ClearWarningPos();
		}

		public bool ExternalCanCast()
		{
			bool flag = this._soul.Script != null && !string.IsNullOrEmpty(this._soul.Script.Start_Name);
			bool result;
			if (flag)
			{
				Type type = Type.GetType("XMainClient." + this._soul.Name);
				MethodInfo method = type.GetMethod("ExternalCanCast");
				result = (method == null || (bool)method.Invoke(null, null));
			}
			else
			{
				result = true;
			}
			return result;
		}

		public void StartCameraPostEffect()
		{
			XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.RadialBlur, true);
		}

		public void EndCameraPostEffect()
		{
			XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.RadialBlur, false);
		}

		public void AddHurtTarget(ulong id, int triggerTime)
		{
			bool flag = !this.Soul.Result[triggerTime].Loop && !this.Soul.Result[triggerTime].LongAttackEffect;
			if (flag)
			{
				bool flag2 = !this.IsHurtEntity(id, triggerTime);
				if (flag2)
				{
					this._hurt_target.Add((ulong)((long)triggerTime));
					this._hurt_target.Add(id);
				}
			}
			bool flag3 = this._hurt_target.Count > XSkillCore.maxHurtCount;
			if (flag3)
			{
				XSkillCore.maxHurtCount = this._hurt_target.Count;
			}
		}

		public bool IsHurtEntity(ulong id, int triggerTime)
		{
			int i = 0;
			int count = this._hurt_target.Count;
			while (i < count)
			{
				ulong num = this._hurt_target[i];
				ulong num2 = this._hurt_target[i + 1];
				bool flag = (int)num == triggerTime && id == num2;
				if (flag)
				{
					return true;
				}
				i += 2;
			}
			return false;
		}

		public bool Fire(XSkill carrier)
		{
			bool demonstrationMode = carrier.DemonstrationMode;
			bool result;
			if (demonstrationMode)
			{
				result = true;
			}
			else
			{
				bool flag = this._soul.OnceOnly && this._ever_fired;
				if (flag)
				{
					result = false;
				}
				else
				{
					bool cooledDown = this.CooledDown;
					if (cooledDown)
					{
						this._carrier = carrier;
						this.OnCdCall(this._current_running_time - 1, false);
						result = true;
					}
					else
					{
						bool syncMode = XSingleton<XGame>.singleton.SyncMode;
						if (syncMode)
						{
							this._carrier = carrier;
							this._ever_fired = true;
							result = true;
						}
						else
						{
							result = false;
						}
					}
				}
			}
			return result;
		}

		public void OnCdCall(int left_running_time, bool syntonic = false)
		{
			this._ever_fired = true;
			bool flag = !this.Reloading;
			this._current_running_time = left_running_time;
			this.CheckRunningTime();
			bool flag2 = flag || syntonic;
			if (flag2)
			{
				this._last_lock_and_load_time = Time.time;
				float coolDown = this.GetCoolDown();
				XSingleton<XTimerMgr>.singleton.KillTimer(this._cd_token);
				this._cd_token = XSingleton<XTimerMgr>.singleton.SetTimer(coolDown, this._OnReloaded, null);
				bool flag3 = this._notify_at > 0f && this._notify_at < coolDown;
				if (flag3)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this._timer_token_skill_notify);
					this._timer_token_skill_notify = XSingleton<XTimerMgr>.singleton.SetTimer(coolDown - this._notify_at, new XTimerMgr.ElapsedEventHandler(this.OnCastNotify), null);
				}
				bool flag4 = !XSingleton<XGame>.singleton.SyncMode && !string.IsNullOrEmpty(this.Soul.Logical.Syntonic_CoolDown_Skill);
				if (flag4)
				{
					this._is_on_syntonic = true;
					XSkillCore skill = this._firer.SkillMgr.GetSkill(XSingleton<XCommon>.singleton.XHash(this.Soul.Logical.Syntonic_CoolDown_Skill));
					bool flag5 = skill != null && skill != this && !skill.IsOnSyntonic;
					if (flag5)
					{
						skill.OnCdCall(0, true);
					}
					this._is_on_syntonic = false;
				}
			}
		}

		public void Execute(XSkill carrier)
		{
			this._carrier = carrier;
			this.ClearHurtTarget();
			this.ClearWarningPos();
		}

		public void BuildRandomWarningPos(List<WarningItemSet> set)
		{
			bool flag = this._soul.Warning != null && this._soul.Warning.Count > 0 && this._soul.Warning.Count == set.Count;
			if (flag)
			{
				bool flag2 = this.WarningRandomAt == null || this.WarningRandomAt.Length != this._soul.Warning.Count;
				if (flag2)
				{
					this.WarningRandomAt = new List<XSkillCore.XWarningRandomPackage>[this._soul.Warning.Count];
					for (int i = 0; i < this._soul.Warning.Count; i++)
					{
						this.WarningRandomAt[i] = new List<XSkillCore.XWarningRandomPackage>();
					}
				}
				for (int j = 0; j < set.Count; j++)
				{
					this.WarningRandomAt[j].Clear();
					for (int k = 0; k < set[j].WarningItem.Count; k++)
					{
						XSkillCore.XWarningRandomPackage xwarningRandomPackage = default(XSkillCore.XWarningRandomPackage);
						xwarningRandomPackage.ID = set[j].WarningItem[k].ID;
						xwarningRandomPackage.Pos = new List<uint>();
						for (int l = 0; l < set[j].WarningItem[k].WarningPos.Count; l++)
						{
							xwarningRandomPackage.Pos.Add(set[j].WarningItem[k].WarningPos[l]);
						}
						this.WarningRandomAt[j].Add(xwarningRandomPackage);
					}
				}
			}
		}

		public void ClearHurtTarget()
		{
			this._hurt_target.Clear();
		}

		public void ClearWarningPos()
		{
			bool flag = this.WarningPosAt == null;
			if (!flag)
			{
				for (int i = 0; i < this._soul.Warning.Count; i++)
				{
					this.WarningPosAt[i].Clear();
				}
			}
		}

		public void Halt()
		{
			this._carrier = null;
		}

		public float GetElapsedCD()
		{
			return this.Reloading ? (Time.time - this._last_lock_and_load_time) : this.GetCoolDown();
		}

		public float GetCoolDown()
		{
			return this.CheckDynamicCD(this.CheckStaticCD());
		}

		public void AccelerateCD(float delta, bool ratio)
		{
			bool reloading = this.Reloading;
			if (reloading)
			{
				if (ratio)
				{
					this._dynamic_cd_delta += (this.GetCoolDown() - this.GetElapsedCD()) * delta;
				}
				else
				{
					this._dynamic_cd_delta += delta;
				}
				this.GetCoolDown();
			}
			else
			{
				this._dynamic_cd_delta = 0f;
			}
		}

		public void ResetStaticCD()
		{
			this._static_cd = XSingleton<XSkillEffectMgr>.singleton.GetSkillCDStaticRatio(this.ID, this._skill_level, this._firer.SkillCasterTypeID, XSingleton<XScene>.singleton.IsPVPScene) * this._soul.CoolDown;
			bool reloading = this.Reloading;
			if (reloading)
			{
				this.GetCoolDown();
			}
		}

		public void AccelerateStaticCD(float delta)
		{
			bool flag = delta < 0f || delta > 1f;
			if (!flag)
			{
				this._static_cd = (1f - delta) * this._static_cd;
				bool reloading = this.Reloading;
				if (reloading)
				{
					this.GetCoolDown();
				}
			}
		}

		private float CheckStaticCD()
		{
			return this._is_init_cooling ? this._init_cd : this._static_cd;
		}

		private float CheckDynamicCD(float static_cd)
		{
			float num = static_cd * XSingleton<XSkillEffectMgr>.singleton.CalcDynamicRatio(1f, this._semi_dynamic_cd_ratio);
			bool reloading = this.Reloading;
			if (reloading)
			{
				float num2 = XSingleton<XSkillEffectMgr>.singleton.CalcDynamicRatio(XSingleton<XSkillEffectMgr>.singleton.CanChangeCD(this.ID, this._skill_level, this._firer.SkillCasterTypeID) ? XSingleton<XSkillEffectMgr>.singleton.GetSkillCDDynamicRatio(this._firer.Attributes) : 1f, this._semi_dynamic_cd_ratio);
				float time = Time.time;
				bool flag = this._dynamic_cd_ratio != num2;
				if (flag)
				{
					float num3 = num2 / this._dynamic_cd_ratio;
					this._last_lock_and_load_time = time - (time - this._last_lock_and_load_time) * num3;
					this._dynamic_cd_ratio = num2;
				}
				num = static_cd * this._dynamic_cd_ratio - this._dynamic_cd_delta;
				bool flag2 = this._last_dynamic_cd != num;
				if (flag2)
				{
					float num4 = num - (time - this._last_lock_and_load_time);
					XSingleton<XTimerMgr>.singleton.KillTimer(this._cd_token);
					bool flag3 = num4 > 0f;
					if (flag3)
					{
						this._cd_token = XSingleton<XTimerMgr>.singleton.SetTimer(num4, this._OnReloaded, null);
					}
					else
					{
						this.CoolDown();
					}
				}
			}
			this._last_dynamic_cd = num;
			return num;
		}

		public float GetTimeScale()
		{
			return (float)XSingleton<XSkillEffectMgr>.singleton.GetAttackSpeedRatio(this._firer.Attributes);
		}

		public float GetRange(int id)
		{
			return this._soul.Result[id].Range;
		}

		public float GetRangeLow(int id)
		{
			return this._soul.Result[id].Low_Range;
		}

		public float GetScope(int id)
		{
			return this._soul.Result[id].Sector_Type ? (this._soul.Result[id].Scope * 0.5f) : this._soul.Result[id].Scope;
		}

		public void CoolDown()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._cd_token);
			this._current_running_time = this._totally_running_time;
			this.OnReloaded(null);
		}

		private void OnReloaded(object o)
		{
			bool is_init_cooling = this._is_init_cooling;
			if (is_init_cooling)
			{
				this._current_running_time = this._totally_running_time;
			}
			this._is_init_cooling = false;
			this._current_running_time++;
			this.CheckRunningTime();
			bool reloading = this.Reloading;
			if (reloading)
			{
				this._last_lock_and_load_time = Time.time;
				float coolDown = this.GetCoolDown();
				XSingleton<XTimerMgr>.singleton.KillTimer(this._cd_token);
				bool flag = coolDown > 0f;
				if (flag)
				{
					this._cd_token = XSingleton<XTimerMgr>.singleton.SetTimer(coolDown, this._OnReloaded, null);
				}
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._timer_token_skill_notify);
				this._dynamic_cd_delta = 0f;
				this._dynamic_cd_ratio = 1f;
			}
		}

		private void OnCastNotify(object o)
		{
			SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(this.ID, this._skill_level, this._firer.SkillCasterTypeID);
			bool flag = skillConfig != null;
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.ShowSkillRemainingCD(skillConfig.ScriptName, this._notify_at);
			}
		}

		public void InitCoreData(bool ctor = false)
		{
			XAttributes attributes = this._firer.Attributes;
			bool flag = attributes == null;
			if (!flag)
			{
				this._skill_level = attributes.SkillLevelInfo.GetSkillLevel(this.ID);
				this._static_cd = XSingleton<XSkillEffectMgr>.singleton.GetSkillCDStaticRatio(this.ID, this._skill_level, this._firer.SkillCasterTypeID, XSingleton<XScene>.singleton.IsPVPScene) * this._soul.CoolDown;
				this._init_cd = XSingleton<XSkillEffectMgr>.singleton.GetSkillInitCDRatio(this.ID, this._skill_level, this._firer.SkillCasterTypeID, XSingleton<XScene>.singleton.IsPVPScene, attributes) * this._soul.CoolDown;
				this._semi_dynamic_cd_ratio = XSingleton<XSkillEffectMgr>.singleton.GetSkillCDSemiDynamicRatio(attributes, this.ID);
				this._preserved_strength = XSingleton<XSkillEffectMgr>.singleton.GetStrengthValue(this.ID, this._skill_level, this._firer.SkillCasterTypeID);
				this._notify_at = XSingleton<XSkillEffectMgr>.singleton.GetRemainingCDNotify(this.ID, this._skill_level, this._firer.SkillCasterTypeID);
				this._totally_running_time = XSingleton<XSkillEffectMgr>.singleton.GetUsageCount(this.ID, this._skill_level, this._firer.SkillCasterTypeID);
				bool flag2 = this._totally_running_time == 0;
				if (flag2)
				{
					this._totally_running_time = 1;
				}
				if (ctor)
				{
					this._current_running_time = this._totally_running_time;
				}
				if (ctor)
				{
					this._ever_fired = false;
				}
				bool reloading = this.Reloading;
				if (reloading)
				{
					this.GetCoolDown();
				}
			}
		}

		private void CheckRunningTime()
		{
			bool flag = this._current_running_time < 0;
			if (flag)
			{
				this._current_running_time = 0;
			}
			else
			{
				bool flag2 = this._current_running_time > this._totally_running_time;
				if (flag2)
				{
					this._current_running_time = this._totally_running_time;
				}
			}
		}

		public void MakeCoolDownAtLaunch()
		{
			bool hasInitCD = this.HasInitCD;
			if (hasInitCD)
			{
				this._current_running_time = 0;
				this._is_init_cooling = true;
				this._last_lock_and_load_time = Time.time;
				XSingleton<XTimerMgr>.singleton.KillTimer(this._cd_token);
				XSingleton<XTimerMgr>.singleton.KillTimer(this._timer_token_skill_notify);
				this._cd_token = XSingleton<XTimerMgr>.singleton.SetTimer(this._init_cd, this._OnReloaded, null);
				bool flag = this._notify_at > 0f && this._notify_at < this._init_cd;
				if (flag)
				{
					this._timer_token_skill_notify = XSingleton<XTimerMgr>.singleton.SetTimer(this._init_cd - this._notify_at, new XTimerMgr.ElapsedEventHandler(this.OnCastNotify), null);
				}
			}
		}

		public bool CanCast(long token)
		{
			bool flag = token > 0L && token == this._firer.Machine.ActionToken;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XStateDefine xstateDefine = this._firer.Machine.State.IsFinished ? this._firer.Machine.Default : this._firer.Machine.Current;
				result = (xstateDefine == XStateDefine.XState_Idle || xstateDefine == XStateDefine.XState_Move || xstateDefine == XStateDefine.XState_Charge);
			}
			return result;
		}

		public bool CanAct(XStateDefine state)
		{
			bool flag = this._carrier == null;
			bool result;
			if (flag)
			{
				bool flag2 = this._soul != null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(this._firer.ToString(), " SkillCore error: without carrier for core name ", this._soul.Name, null, null, null);
				}
				result = true;
			}
			else
			{
				float timeElapsed = this._carrier.TimeElapsed;
				Vector3 position = this._firer.EngineObject.Position;
				bool flag3 = true;
				if (state != XStateDefine.XState_Idle)
				{
					if (state == XStateDefine.XState_Move)
					{
						bool flag4 = XSingleton<XCommon>.singleton.IsLess(timeElapsed, this._soul.Logical.Not_Move_End) && XSingleton<XCommon>.singleton.IsEqualGreater(timeElapsed, this._soul.Logical.Not_Move_At);
						if (flag4)
						{
							flag3 = false;
							bool multipleAttackSupported = this._soul.MultipleAttackSupported;
							if (multipleAttackSupported)
							{
								this._firer.Skill.TagTrigger();
								bool flag5 = this._firer.IsPlayer && XSingleton<XVirtualTab>.singleton.Feeding;
								if (flag5)
								{
									this._carrier.SkillTowardsTo = XSingleton<XVirtualTab>.singleton.Direction;
								}
							}
							else
							{
								this._carrier.Firer.Net.ReportRotateAction((this._firer.IsPlayer && XSingleton<XVirtualTab>.singleton.Feeding) ? XSingleton<XVirtualTab>.singleton.Direction : this._firer.Rotate.GetMeaningfulFaceVector3(), (this._soul.Logical.Rotate_Speed > 0f) ? this._soul.Logical.Rotate_Speed : this._firer.Attributes.RotateSpeed, 0L);
							}
						}
					}
				}
				else
				{
					flag3 = false;
				}
				bool flag6 = flag3;
				if (flag6)
				{
					this._firer.Skill.EndSkill(false, true);
				}
				result = flag3;
			}
			return result;
		}

		public bool CanRotate()
		{
			return this._carrier == null || (XSingleton<XCommon>.singleton.IsLess(this._carrier.TimeElapsed, this._soul.Logical.Rotate_End) && XSingleton<XCommon>.singleton.IsEqualGreater(this._carrier.TimeElapsed, this._soul.Logical.Rotate_At));
		}

		public bool CanMove()
		{
			return this._carrier == null || XSingleton<XCommon>.singleton.IsEqualGreater(this._carrier.TimeElapsed, this._soul.Logical.Not_Move_End) || XSingleton<XCommon>.singleton.IsLess(this._carrier.TimeElapsed, this._soul.Logical.Not_Move_At);
		}

		private static Vector3 ResultPos(Vector3 result_pos, Vector3 logical, float radius)
		{
			Vector3 vector = logical - result_pos;
			vector.y = 0f;
			float num = vector.magnitude;
			vector.Normalize();
			num = ((num > radius) ? (num - radius) : 0f);
			return result_pos + vector * num;
		}

		private bool InnerIsInAttckField(int triggerTime, Vector3 pos, Vector3 forward, Vector3 targetPos, int shift)
		{
			Vector3 vector = targetPos - pos;
			vector.y = 0f;
			float magnitude = vector.magnitude;
			float range = this.GetRange(triggerTime);
			float scope = this.GetScope(triggerTime);
			bool sector_Type = this._soul.Result[triggerTime].Sector_Type;
			bool result;
			if (sector_Type)
			{
				float num = (magnitude == 0f) ? 0f : Vector3.Angle(forward, vector);
				result = (magnitude < range && magnitude >= this.GetRangeLow(triggerTime) && num <= scope);
			}
			else
			{
				Quaternion rotation = XSingleton<XCommon>.singleton.VectorToQuaternion(XSingleton<XCommon>.singleton.HorizontalRotateVetor3(forward, (float)this._soul.Result[triggerTime].None_Sector_Angle_Shift, true));
				bool flag = magnitude > 0f;
				if (flag)
				{
					vector.Normalize();
				}
				float num2 = scope / 2f;
				float num3 = range / 2f;
				this._rect.xMin = -num2;
				this._rect.xMax = num2;
				this._rect.yMin = (this._soul.Result[triggerTime].Rect_HalfEffect ? 0f : (-num3));
				this._rect.yMax = num3;
				result = XSingleton<XCommon>.singleton.IsInRect(magnitude * vector, this._rect, Vector3.zero, rotation);
			}
			return result;
		}

		public bool IsInAttckField(int triggerTime, Vector3 pos, Vector3 forward, XEntity target)
		{
			bool flag = !XEntity.ValideEntity(target);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XEntity xentity = target.IsTransform ? target.Transformer : target;
				this._vOffset.Set(this._soul.Result[triggerTime].Offset_X, 0f, this._soul.Result[triggerTime].Offset_Z);
				pos += this._firer.EngineObject.Rotation * this._vOffset;
				bool huge = xentity.Present.PresentLib.Huge;
				if (huge)
				{
					SeqListRef<float> hugeMonsterColliders = xentity.Present.PresentLib.HugeMonsterColliders;
					for (int i = 0; i < hugeMonsterColliders.Count; i++)
					{
						float radius = hugeMonsterColliders[i, 2] * xentity.Scale;
						bool flag2 = this.InnerIsInAttckField(triggerTime, pos, forward, XSkillCore.ResultPos(pos, xentity.HugeMonsterColliderCenter(i), radius), this._soul.Result[triggerTime].None_Sector_Angle_Shift);
						if (flag2)
						{
							return true;
						}
					}
					result = false;
				}
				else
				{
					result = this.InnerIsInAttckField(triggerTime, pos, forward, XSkillCore.ResultPos(pos, xentity.RadiusCenter, xentity.Radius), this._soul.Result[triggerTime].None_Sector_Angle_Shift);
				}
			}
			return result;
		}

		public bool IsInAttckField(Vector3 pos, Vector3 forward, XEntity target)
		{
			return XEntity.ValideEntity(target) && this.GetAttckWeights(pos, forward, target) > float.MinValue;
		}

		public static XEntity FindTargetAt(Vector3 pos, Vector3 forward, float range, float lower, float scope, XEntity firer, bool sector = true)
		{
			XEntity result = null;
			float num = float.MinValue;
			List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(firer);
			for (int i = 0; i < opponent.Count; i++)
			{
				bool flag = !XEntity.ValideEntity(opponent[i]) || opponent[i].Present.IsShowUp;
				if (!flag)
				{
					float attckWeights = XSkillCore.GetAttckWeights(pos, forward, opponent[i], range, lower, scope, 0, sector);
					bool flag2 = attckWeights > num;
					if (flag2)
					{
						num = attckWeights;
						result = opponent[i];
					}
				}
			}
			return result;
		}

		public XEntity FindTargetAt(Vector3 pos, Vector3 forward)
		{
			pos.x += this._soul.Cast_Offset_X;
			pos.z += this._soul.Cast_Offset_Z;
			return XSkillCore.FindTargetAt(pos, forward, this.CastRangeUpper, this.CastRangeLower, (float)((int)this.CastScope), this._firer, !this._soul.Cast_Range_Rect);
		}

		public bool CanReplacedBy(XSkillCore skill)
		{
			bool flag = (this._soul.Logical.CanReplacedby & 1 << skill.Soul.TypeToken) != 0;
			bool flag2 = !flag;
			if (flag2)
			{
				flag = XSingleton<XCommon>.singleton.IsGreater(this._carrier.TimeElapsed, this._soul.Logical.CanCancelAt);
				bool flag3 = !flag && this._soul.TypeToken == 0;
				if (flag3)
				{
					bool flag4 = this._soul.Ja != null && this._soul.Ja.Count > 0;
					if (flag4)
					{
						XJAComboSkill xjacomboSkill = this._carrier as XJAComboSkill;
						bool flag5 = xjacomboSkill != null && xjacomboSkill.DuringJA;
						if (flag5)
						{
							uint num = XSingleton<XCommon>.singleton.XHash(this._soul.Ja[0].Name);
							flag = (skill.ID == num);
							bool flag6 = !flag;
							if (flag6)
							{
								XSkillCore skill2 = this._firer.SkillMgr.GetSkill(XSingleton<XCommon>.singleton.XHash(this._soul.Ja[0].Name));
								bool flag7 = skill2 != null && skill2.Soul.Logical.Association;
								if (flag7)
								{
									num = XSingleton<XCommon>.singleton.XHash(skill2.Soul.Logical.Association_Skill);
									flag = (skill.ID == num);
								}
							}
						}
					}
				}
			}
			return flag;
		}

		private static float GetAttckWeights(Vector3 pos, Vector3 forward, XEntity target, float upper, float lower, float scope, int scopeshift, bool sector)
		{
			forward = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(forward, (float)scopeshift, true);
			XEntity xentity = target.IsTransform ? target.Transformer : target;
			bool huge = xentity.Present.PresentLib.Huge;
			float result;
			if (huge)
			{
				float num = float.MinValue;
				SeqListRef<float> hugeMonsterColliders = xentity.Present.PresentLib.HugeMonsterColliders;
				for (int i = 0; i < hugeMonsterColliders.Count; i++)
				{
					float radius = hugeMonsterColliders[i, 2] * xentity.Scale;
					float num2 = XSkillCore.InnerGetAttckWeights(pos, forward, target, upper, lower, scope, XSkillCore.ResultPos(pos, xentity.HugeMonsterColliderCenter(i), radius), sector);
					bool flag = num2 > num;
					if (flag)
					{
						num = num2;
					}
				}
				result = num;
			}
			else
			{
				result = XSkillCore.InnerGetAttckWeights(pos, forward, target, upper, lower, scope, XSkillCore.ResultPos(pos, xentity.RadiusCenter, xentity.Radius), sector);
			}
			return result;
		}

		private static float InnerGetAttckWeights(Vector3 pos, Vector3 forward, XEntity target, float upper, float lower, float scope, Vector3 logical, bool sector)
		{
			float num = float.MinValue;
			Vector3 vector = logical - pos;
			vector.y = 0f;
			float magnitude = vector.magnitude;
			vector.Normalize();
			float num2 = (magnitude == 0f) ? 0f : Vector3.Angle(forward, vector);
			bool flag;
			if (sector)
			{
				flag = (XSingleton<XCommon>.singleton.IsLess(magnitude, upper) && XSingleton<XCommon>.singleton.IsEqualGreater(magnitude, lower) && num2 <= scope);
			}
			else
			{
				Quaternion rotation = XSingleton<XCommon>.singleton.VectorToQuaternion(forward);
				bool flag2 = magnitude > 0f;
				if (flag2)
				{
					vector.Normalize();
				}
				float num3 = scope / 2f;
				float num4 = upper / 2f;
				XSkillCore.s_rect.xMin = -num3;
				XSkillCore.s_rect.xMax = num3;
				XSkillCore.s_rect.yMin = -num4;
				XSkillCore.s_rect.yMax = num4;
				flag = XSingleton<XCommon>.singleton.IsInRect(magnitude * vector, XSkillCore.s_rect, Vector3.zero, rotation);
			}
			bool flag3 = flag && target.CanSelected;
			if (flag3)
			{
				num = 0f;
				float num5 = magnitude - lower;
				float num6 = upper - lower;
				float num7 = num6 / ((XSingleton<XOperationData>.singleton.WithinRange == 0f) ? 1f : XSingleton<XOperationData>.singleton.WithinRange);
				int num8 = XSingleton<XCommon>.singleton.IsInteger(num7) ? Mathf.FloorToInt(num7 + 0.05f) : Mathf.CeilToInt(num7);
				float num9 = (float)XSingleton<XOperationData>.singleton.RangeWeight / (float)num8;
				num7 = (float)num8 * (1f - num5 / num6);
				int num10 = XSingleton<XCommon>.singleton.IsInteger(num7) ? Mathf.FloorToInt(num7 + 0.05f) : Mathf.CeilToInt(num7);
				num += (float)num10 * num9;
				num += (1f - num2 / scope) * num9;
				bool flag4 = !target.IsRole && target.Buffs != null && target.Buffs.IsBuffStateOn(XBuffType.XBuffType_Immortal);
				if (flag4)
				{
					num += (float)XSingleton<XOperationData>.singleton.ImmortalWeight;
				}
				bool isBoss = target.IsBoss;
				if (isBoss)
				{
					num += (float)XSingleton<XOperationData>.singleton.BossWeight;
				}
				else
				{
					bool isElite = target.IsElite;
					if (isElite)
					{
						num += (float)XSingleton<XOperationData>.singleton.EliteWeight;
					}
					else
					{
						bool isPuppet = target.IsPuppet;
						if (isPuppet)
						{
							num += (float)XSingleton<XOperationData>.singleton.PupetWeight;
						}
						else
						{
							bool isRole = target.IsRole;
							if (isRole)
							{
								num += (float)XSingleton<XOperationData>.singleton.RoleWeight;
							}
							else
							{
								num += (float)XSingleton<XOperationData>.singleton.EnemyWeight;
							}
						}
					}
				}
			}
			return num;
		}

		private float GetAttckWeights(Vector3 pos, Vector3 forward, XEntity target)
		{
			pos.x += this._soul.Cast_Offset_X;
			pos.z += this._soul.Cast_Offset_Z;
			return XSkillCore.GetAttckWeights(pos, forward, target, this.CastRangeUpper, this.CastRangeLower, (float)((int)this.CastScope), (int)this._soul.Cast_Scope_Shift, !this._soul.Cast_Range_Rect);
		}

		public float GetMultipleDirectionFactor()
		{
			bool flag = !this._carrier.MainCore.Soul.MultipleAttackSupported;
			float result;
			if (flag)
			{
				result = 1f;
			}
			else
			{
				XEntity target = this._carrier.Target;
				Vector3 vector = (target != null) ? XSingleton<XCommon>.singleton.Horizontal(target.EngineObject.Position - this._firer.EngineObject.Position) : this._firer.EngineObject.Forward;
				Vector3 skillTowardsTo = this._carrier.SkillTowardsTo;
				vector.y = 0f;
				bool flag2 = vector.sqrMagnitude == 0f;
				if (flag2)
				{
					vector = Vector3.forward;
				}
				float num = Vector3.Angle(vector, skillTowardsTo);
				num = (XSingleton<XCommon>.singleton.Clockwise(vector, skillTowardsTo) ? num : (360f - num));
				result = num / 360f;
			}
			return result;
		}

		private XSkillData _soul = null;

		private XSkill _carrier = null;

		private XEntity _firer = null;

		private bool _is_pvp_version = false;

		private bool _is_init_cooling = false;

		private bool _is_on_syntonic = false;

		private float _static_cd = 1f;

		private float _init_cd = 1f;

		private uint _skill_level = 0U;

		private uint _id = 0U;

		private uint _long_id = 0U;

		private int _carrier_id = 0;

		private int _totally_running_time = 1;

		private int _current_running_time = 1;

		private uint _cd_token = 0U;

		private uint _timer_token_skill_notify = 0U;

		private bool _ever_fired = false;

		private float _last_lock_and_load_time = 0f;

		private float _offset = 0f;

		private float _notify_at = 0f;

		private float _semi_dynamic_cd_ratio = 0f;

		private float _last_dynamic_cd = 0f;

		private float _dynamic_cd_delta = 0f;

		private float _dynamic_cd_ratio = 1f;

		private int _preserved_strength = 0;

		private string _trigger_token_string = null;

		private List<ulong> _hurt_target;

		private Rect _rect;

		private static Rect s_rect;

		private Vector3 _vOffset = Vector3.zero;

		private XTimerMgr.ElapsedEventHandler _OnReloaded = null;

		public List<XSkillCore.XSkillWarningPackage>[] WarningPosAt = null;

		public List<XSkillCore.XWarningRandomPackage>[] WarningRandomAt = null;

		public static int maxHurtCount = 0;

		public struct XSkillWarningPackage
		{

			public Vector3 WarningAt;

			public ulong WarningTo;
		}

		public struct XWarningRandomPackage
		{

			public ulong ID;

			public List<uint> Pos;
		}
	}
}
