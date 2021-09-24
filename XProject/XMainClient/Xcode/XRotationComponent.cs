using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XRotationComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XRotationComponent.uuID;
			}
		}

		public float To
		{
			get
			{
				return this._to;
			}
		}

		public bool Rotating
		{
			get
			{
				return this._rotate;
			}
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Rotation, new XComponent.XEventHandler(this.OnBasicRotate));
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._rotateSpeed = 0f;
			this._machine = this._entity.Machine;
		}

		private bool Permission(XEventArgs e)
		{
			bool flag = !this._machine.State.SyncPredicted;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = XStateMgr.IsUnControlledState(this._machine.Current);
				bool flag3 = this._entity.Skill != null && this._entity.Skill.IsCasting();
				if (flag3)
				{
					result = (e.Token == this._entity.Skill.CurrentSkill.Token || (this._entity.Skill.CurrentSkill.MainCore.CanRotate() && !flag2));
				}
				else
				{
					result = (e.Token == this._machine.ActionToken || !flag2);
				}
			}
			return result;
		}

		private bool OnBasicRotate(XEventArgs e)
		{
			bool flag = this.Permission(e);
			bool result;
			if (flag)
			{
				XRotationEventArgs xrotationEventArgs = e as XRotationEventArgs;
				Vector3 normalized = xrotationEventArgs.TargetDir.normalized;
				normalized.y = 0f;
				bool flag2 = normalized.sqrMagnitude == 0f;
				if (flag2)
				{
					result = false;
				}
				else
				{
					Vector3 forward = this._entity.MoveObj.Forward;
					this._from = XSingleton<XCommon>.singleton.AngleToFloat(forward);
					float num = Vector3.Angle(forward, normalized);
					bool flag3 = XSingleton<XCommon>.singleton.Clockwise(forward, normalized);
					if (flag3)
					{
						this._to = this._from + num;
					}
					else
					{
						this._to = this._from - num;
					}
					this._rotateSpeed = xrotationEventArgs.Palstance;
					this._rotate = true;
					this._last_towards = this._entity.MoveObj.Forward;
					result = true;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		public override void Update(float fDeltaT)
		{
			bool rotate = this._rotate;
			if (rotate)
			{
				bool flag = !XSingleton<XCommon>.singleton.IsEqual(this._from, this._to);
				if (flag)
				{
					this._from += (this._to - this._from) * Mathf.Min(1f, fDeltaT * this._rotateSpeed);
				}
				else
				{
					this._rotate = false;
					this._from = this._to;
				}
				this._entity.MoveObj.Rotation = Quaternion.Euler(0f, this._from, 0f);
			}
		}

		public float Angular()
		{
			bool rotate = this._rotate;
			float result;
			if (rotate)
			{
				float num = Vector3.Angle(this._last_towards, this._entity.MoveObj.Forward);
				bool flag = !XSingleton<XCommon>.singleton.Clockwise(this._last_towards, this._entity.MoveObj.Forward);
				if (flag)
				{
					num = -num;
				}
				this._last_towards = this._entity.MoveObj.Forward;
				result = ((Mathf.Abs(num) > 1f) ? ((float)((num > 0f) ? 1 : -1)) : num);
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		public void Cancel()
		{
			this._rotate = false;
			this._to = XSingleton<XCommon>.singleton.AngleToFloat(this._entity.MoveObj.Forward);
		}

		public float GetMeaningfulFace()
		{
			return (this._rotate && this._rotateSpeed > 0f) ? this._to : XSingleton<XCommon>.singleton.AngleToFloat(this._entity.MoveObj.Forward);
		}

		public Vector3 GetMeaningfulFaceVector3()
		{
			return (this._rotate && this._rotateSpeed > 0f) ? XSingleton<XCommon>.singleton.FloatToAngle(this._to) : this._entity.MoveObj.Forward;
		}

		public Quaternion GetMeaningfulFaceQuaternion()
		{
			return (this._rotate && this._rotateSpeed > 0f) ? XSingleton<XCommon>.singleton.FloatToQuaternion(this._to) : this._entity.MoveObj.Rotation;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Basic_Rotation");

		private XStateMachine _machine = null;

		private bool _rotate = false;

		private float _to = 0f;

		private float _from = 0f;

		private float _rotateSpeed = 0f;

		private Vector3 _last_towards = Vector3.zero;
	}
}
