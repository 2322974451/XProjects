using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F2F RID: 3887
	internal sealed class XRotationComponent : XComponent
	{
		// Token: 0x170035ED RID: 13805
		// (get) Token: 0x0600CE12 RID: 52754 RVA: 0x002FAFB0 File Offset: 0x002F91B0
		public override uint ID
		{
			get
			{
				return XRotationComponent.uuID;
			}
		}

		// Token: 0x170035EE RID: 13806
		// (get) Token: 0x0600CE13 RID: 52755 RVA: 0x002FAFC8 File Offset: 0x002F91C8
		public float To
		{
			get
			{
				return this._to;
			}
		}

		// Token: 0x170035EF RID: 13807
		// (get) Token: 0x0600CE14 RID: 52756 RVA: 0x002FAFE0 File Offset: 0x002F91E0
		public bool Rotating
		{
			get
			{
				return this._rotate;
			}
		}

		// Token: 0x0600CE15 RID: 52757 RVA: 0x002FAFF8 File Offset: 0x002F91F8
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Rotation, new XComponent.XEventHandler(this.OnBasicRotate));
		}

		// Token: 0x0600CE16 RID: 52758 RVA: 0x002FB010 File Offset: 0x002F9210
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._rotateSpeed = 0f;
			this._machine = this._entity.Machine;
		}

		// Token: 0x0600CE17 RID: 52759 RVA: 0x002FB038 File Offset: 0x002F9238
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

		// Token: 0x0600CE18 RID: 52760 RVA: 0x002FB100 File Offset: 0x002F9300
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

		// Token: 0x0600CE19 RID: 52761 RVA: 0x002FB1F0 File Offset: 0x002F93F0
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

		// Token: 0x0600CE1A RID: 52762 RVA: 0x002FB298 File Offset: 0x002F9498
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

		// Token: 0x0600CE1B RID: 52763 RVA: 0x002FB336 File Offset: 0x002F9536
		public void Cancel()
		{
			this._rotate = false;
			this._to = XSingleton<XCommon>.singleton.AngleToFloat(this._entity.MoveObj.Forward);
		}

		// Token: 0x0600CE1C RID: 52764 RVA: 0x002FB360 File Offset: 0x002F9560
		public float GetMeaningfulFace()
		{
			return (this._rotate && this._rotateSpeed > 0f) ? this._to : XSingleton<XCommon>.singleton.AngleToFloat(this._entity.MoveObj.Forward);
		}

		// Token: 0x0600CE1D RID: 52765 RVA: 0x002FB3AC File Offset: 0x002F95AC
		public Vector3 GetMeaningfulFaceVector3()
		{
			return (this._rotate && this._rotateSpeed > 0f) ? XSingleton<XCommon>.singleton.FloatToAngle(this._to) : this._entity.MoveObj.Forward;
		}

		// Token: 0x0600CE1E RID: 52766 RVA: 0x002FB3F8 File Offset: 0x002F95F8
		public Quaternion GetMeaningfulFaceQuaternion()
		{
			return (this._rotate && this._rotateSpeed > 0f) ? XSingleton<XCommon>.singleton.FloatToQuaternion(this._to) : this._entity.MoveObj.Rotation;
		}

		// Token: 0x04005BD7 RID: 23511
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Basic_Rotation");

		// Token: 0x04005BD8 RID: 23512
		private XStateMachine _machine = null;

		// Token: 0x04005BD9 RID: 23513
		private bool _rotate = false;

		// Token: 0x04005BDA RID: 23514
		private float _to = 0f;

		// Token: 0x04005BDB RID: 23515
		private float _from = 0f;

		// Token: 0x04005BDC RID: 23516
		private float _rotateSpeed = 0f;

		// Token: 0x04005BDD RID: 23517
		private Vector3 _last_towards = Vector3.zero;
	}
}
