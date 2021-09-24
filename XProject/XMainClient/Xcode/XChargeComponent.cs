using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XChargeComponent : XActionStateComponent<XChargeEventArgs>
	{

		public override uint ID
		{
			get
			{
				return XChargeComponent.uuID;
			}
		}

		public override float Speed
		{
			get
			{
				return this._step_speed;
			}
		}

		public override bool IsUsingCurve
		{
			get
			{
				return !base.IsFinished && this._using_curve;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._selfState = XStateDefine.XState_Charge;
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Charge, new XComponent.XEventHandler(base.OnActionEvent));
		}

		public override void OnRejected(XStateDefine current)
		{
		}

		protected override void ActionUpdate(float deltaTime)
		{
			bool flag = XSingleton<XCommon>.singleton.IsLess(this._timeElapsed, this._timeSpan);
			if (flag)
			{
				Vector3 vector = Vector3.zero;
				float num = 0f;
				this.Calibration();
				bool using_curve = this._using_curve;
				if (using_curve)
				{
					this.GetCurveMove(ref vector, ref num, deltaTime);
					bool flag2 = this._control_towards && this._entity.IsPlayer && XSingleton<XVirtualTab>.singleton.Feeding;
					if (flag2)
					{
						vector += this._step_dir * (this._velocity * deltaTime);
					}
				}
				else
				{
					this.GetNormalMove(ref vector, ref num, deltaTime);
				}
				bool flag3 = this._timeElapsed > this._timeSpan;
				if (flag3)
				{
					this._timeElapsed = this._timeSpan;
					base.Finish();
				}
				num -= ((this._land_time > 0f) ? (deltaTime * (this._height_drop / this._land_time)) : this._height_drop);
				bool flag4 = this._using_up && this._timeElapsed <= this._land_time;
				if (flag4)
				{
					this._gravity_disabled = true;
					this._entity.DisableGravity();
				}
				else
				{
					this._gravity_disabled = false;
				}
				bool flag5 = this._land_time == 0f && this._entity.Fly != null;
				if (flag5)
				{
					this._height_drop = 0f;
				}
				bool flag6 = this._entity.Skill.IsCasting() && this._entity.Skill.CurrentSkill.MainCore.Soul.MultipleAttackSupported;
				if (flag6)
				{
					this.CalibrateByMultipleDirection(ref vector, this._entity.Skill.CurrentSkill.MainCore);
				}
				bool flag7 = this._entity.Buffs != null && this._entity.Buffs.IsBuffStateOn(XBuffType.XBuffType_LockFoot);
				if (flag7)
				{
					vector = Vector3.zero;
				}
				bool flag8 = this._distance - 0.5f < vector.magnitude;
				if (flag8)
				{
					vector.Set(0f, vector.y, 0f);
				}
				bool isDummy = this._entity.IsDummy;
				if (isDummy)
				{
					vector.Set(0f, vector.y, 0f);
				}
				this._entity.ApplyMove(vector.x, num, vector.z);
			}
			else
			{
				bool gravity_disabled = this._gravity_disabled;
				if (gravity_disabled)
				{
					this._entity.DisableGravity();
				}
			}
		}

		public override bool ShouldBePresent
		{
			get
			{
				return true;
			}
		}

		protected override void Cancel(XStateDefine next)
		{
			this._timeElapsed = 0f;
			this._rticalV = 0f;
			this._gravity = 0f;
			this._step_speed = 0f;
			this._curve_forward = null;
			this._curve_side = null;
			this._using_curve = false;
			bool gravity_disabled = this._gravity_disabled;
			if (gravity_disabled)
			{
				this._entity.DisableGravity();
			}
		}

		protected override bool OnGetEvent(XChargeEventArgs e, XStateDefine last)
		{
			this._gravity_disabled = false;
			this._using_curve = e.Data.Using_Curve;
			this._using_up = e.Data.Using_Up;
			this._control_towards = e.Data.Control_Towards;
			this._land_time = 0f;
			this._time_scale = e.TimeScale;
			this._aim_to_target = e.AimedTarget;
			this._rotation_speed = (e.Data.AimTarget ? 0f : e.Data.Rotation_Speed);
			bool using_curve = this._using_curve;
			if (using_curve)
			{
				IXCurve curve = XSingleton<XResourceLoaderMgr>.singleton.GetCurve(e.Data.Curve_Forward);
				this._curve_forward = curve;
				this._curve_side = XSingleton<XResourceLoaderMgr>.singleton.GetCurve(e.Data.Curve_Side);
				this._timeSpan = this._curve_forward.GetTime(this._curve_forward.length - 1) * this._time_scale;
				bool using_up = this._using_up;
				if (using_up)
				{
					IXCurve curve2 = XSingleton<XResourceLoaderMgr>.singleton.GetCurve(e.Data.Curve_Up);
					this._curve_up = curve2;
					this._land_time = curve2.GetLandValue() * this._time_scale;
					bool flag = this._land_time > 0f;
					if (flag)
					{
						this._gravity_disabled = true;
						this._entity.DisableGravity();
					}
				}
				this._offset = (this._curve_forward.GetValue(this._curve_forward.length - 1) - this._curve_forward.GetValue(0)) * this._entity.Scale;
				this._velocity = e.Data.Velocity;
			}
			else
			{
				this._timeSpan = e.TimeSpan * this._time_scale;
				this._offset = e.Data.Offset;
				this._velocity = 0f;
			}
			this._begin_at = this._entity.MoveObj.Position;
			this._standon_atend = e.Data.StandOnAtEnd;
			this.Calibration();
			this.HeightDrop();
			this._height = e.Height * this._entity.Scale;
			this._timeElapsed = e.TimeGone * this._time_scale;
			return true;
		}

		protected override void Begin()
		{
			bool using_curve = this._using_curve;
			if (using_curve)
			{
				this._last_offset_forward = 0f;
				this._last_offset_side = 0f;
				this._last_offset_up = 0f;
			}
			else
			{
				this._step_speed = this._offset / this._timeSpan;
				this._rticalV = this._height * 4f / this._timeSpan;
				this._gravity = this._rticalV / this._timeSpan * 2f;
			}
		}

		private void Calibration()
		{
			bool flag = XEntity.ValideEntity(this._aim_to_target);
			if (flag)
			{
				Vector3 vector = this._aim_to_target.MoveObj.Position - this._entity.MoveObj.Position;
				this._distance = vector.magnitude;
				this._entity.Net.ReportRotateAction(vector.normalized, this._entity.Attributes.RotateSpeed, this._entity.Skill.IsCasting() ? this._entity.Skill.CurrentSkill.Token : 0L);
			}
			else
			{
				this._distance = float.PositiveInfinity;
				this._aim_to_target = null;
			}
			this._step_dir = (this._entity.Skill.IsCasting() ? (this._control_towards ? this.GetControlTowards() : this._entity.Skill.CurrentSkill.SkillTowardsTo) : this._entity.Rotate.GetMeaningfulFaceVector3());
			this._curve_step_dir = (this._entity.Skill.IsCasting() ? this._entity.Skill.CurrentSkill.SkillTowardsTo : this._entity.Rotate.GetMeaningfulFaceVector3());
		}

		private Vector3 GetControlTowards()
		{
			bool flag = this._entity.IsPlayer && XSingleton<XVirtualTab>.singleton.Feeding;
			Vector3 result;
			if (flag)
			{
				result = XSingleton<XVirtualTab>.singleton.Direction;
			}
			else
			{
				result = this._entity.Skill.CurrentSkill.SkillTowardsTo;
			}
			return result;
		}

		private void HeightDrop()
		{
			bool standon_atend = this._standon_atend;
			if (standon_atend)
			{
				Vector3 pos = this._begin_at + this._offset * this._step_dir;
				float num = 0f;
				bool flag = XSingleton<XScene>.singleton.TryGetTerrainY(pos, out num);
				if (flag)
				{
					this._height_drop = ((this._entity.Fly != null) ? 0f : (this._entity.MoveObj.Position.y - num));
					bool flag2 = this._height_drop < 0f;
					if (flag2)
					{
						this._height_drop = 0f;
					}
				}
				else
				{
					this._height_drop = 0f;
				}
			}
			else
			{
				this._height_drop = 0f;
			}
		}

		private void GetNormalMove(ref Vector3 delta, ref float h, float deltaTime)
		{
			float num = this._rticalV - this._gravity * this._timeElapsed;
			this._timeElapsed += deltaTime;
			float num2 = this._rticalV - this._gravity * this._timeElapsed;
			delta = this._step_speed * deltaTime * this._step_dir;
			h = (num + num2) / 2f * deltaTime;
			bool flag = this._rotation_speed != 0f && !XSingleton<XGame>.singleton.SyncMode;
			if (flag)
			{
				this._entity.MoveObj.Forward = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(this._entity.MoveObj.Forward, this._rotation_speed * deltaTime, true);
				bool flag2 = this._entity.Rotate != null;
				if (flag2)
				{
					this._entity.Rotate.Cancel();
				}
			}
		}

		private void GetCurveMove(ref Vector3 delta, ref float h, float deltaTime)
		{
			this._timeElapsed += deltaTime;
			float num = this._curve_forward.Evaluate(this._timeElapsed / this._time_scale) * this._entity.Scale;
			float num2 = num - this._last_offset_forward;
			this._last_offset_forward = num;
			float num3 = this._curve_side.Evaluate(this._timeElapsed / this._time_scale) * this._entity.Scale;
			float num4 = num3 - this._last_offset_side;
			this._last_offset_side = num3;
			bool using_up = this._using_up;
			if (using_up)
			{
				float num5 = this._curve_up.Evaluate(this._timeElapsed / this._time_scale) * this._entity.Scale;
				h = num5 - this._last_offset_up;
				this._last_offset_up = num5;
			}
			Vector3 vector = num2 * this._curve_step_dir;
			Vector3 vector2 = XSingleton<XCommon>.singleton.Horizontal(Vector3.Cross(Vector3.up, this._entity.MoveObj.Forward));
			Vector3 vector3 = num4 * vector2;
			delta = vector + vector3;
			delta.y = 0f;
		}

		private void CalibrateByMultipleDirection(ref Vector3 delta, XSkillCore core)
		{
			float multipleDirectionFactor = core.GetMultipleDirectionFactor();
			bool flag = multipleDirectionFactor > 0.25f && multipleDirectionFactor < 0.75f;
			if (flag)
			{
				float num = 1f - core.Soul.BackTowardsDecline;
				float num2 = (multipleDirectionFactor - 0.25f) / 0.5f * 3.1415927f;
				delta = delta.magnitude * (1f - Mathf.Sin(num2) * num) * delta.normalized;
			}
		}

		public override string PresentCommand
		{
			get
			{
				bool flag = this._entity.Skill.IsCasting() && this._entity.Skill.CurrentSkill.MainCore.Soul.Logical.Association && this._entity.Skill.CurrentSkill.MainCore.Soul.Logical.MoveType;
				string result;
				if (flag)
				{
					result = "ToMove";
				}
				else
				{
					result = "ToStand";
				}
				return result;
			}
		}

		public override string PresentName
		{
			get
			{
				bool flag = this._entity.Skill.IsCasting() && this._entity.Skill.CurrentSkill.MainCore.Soul.Logical.Association && this._entity.Skill.CurrentSkill.MainCore.Soul.Logical.MoveType;
				string result;
				if (flag)
				{
					result = "Move";
				}
				else
				{
					result = "Stand";
				}
				return result;
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Charge_Move");

		private float _time_scale = 1f;

		private bool _gravity_disabled = false;

		private bool _standon_atend = true;

		private float _timeElapsed = 0f;

		private float _timeSpan = 0f;

		private float _land_time = 0f;

		private float _height = 0f;

		private float _gravity = 0f;

		private float _rticalV = 0f;

		private float _rotation_speed = 0f;

		private float _step_speed = 0f;

		private float _offset = 0f;

		private float _distance = 0f;

		private float _velocity = 0f;

		private float _height_drop = 0f;

		private XEntity _aim_to_target = null;

		private Vector3 _begin_at = Vector3.zero;

		private Vector3 _step_dir = Vector3.zero;

		private Vector3 _curve_step_dir = Vector3.zero;

		private IXCurve _curve_forward = null;

		private IXCurve _curve_side = null;

		private IXCurve _curve_up = null;

		private bool _using_curve = false;

		private bool _using_up = false;

		private bool _control_towards = false;

		private float _last_offset_forward = 0f;

		private float _last_offset_side = 0f;

		private float _last_offset_up = 0f;
	}
}
