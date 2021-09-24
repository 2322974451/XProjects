using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCameraWallComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XCameraWallComponent.uuID;
			}
		}

		public float TargetX
		{
			get
			{
				return this._target_x;
			}
		}

		public float TargetY
		{
			get
			{
				return this._target_y;
			}
			set
			{
				this._target_y = value;
			}
		}

		public bool XTriggered
		{
			get
			{
				return this._x_trigger;
			}
			set
			{
				this._x_trigger = value;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._camera_host = (this._host as XCameraEx);
		}

		public override void OnDetachFromHost()
		{
			this._camera_host = null;
			base.OnDetachFromHost();
		}

		public void Effect(AnimationCurve curve, Vector3 intersection, Vector3 cornerdir, float sector, float inDegree, float outDegree, bool positive)
		{
			bool flag = this._camera_host.Target == null || !this._camera_host.Target.IsPlayer;
			if (!flag)
			{
				this._update = true;
				this._corner_intersection = intersection;
				this._corner_dir = cornerdir;
				this._corner_dir.y = 0f;
				this._corner_dir.Normalize();
				this._corner_curve = curve;
				this._corner_sector = sector;
				this._corner_positive = positive;
				Vector3 vector = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position - this._corner_intersection;
				vector.y = 0f;
				vector.Normalize();
				this._corner_base_percentage = Vector3.Angle(this._corner_dir, vector) / this._corner_sector;
				this._in = inDegree;
				this._out = outDegree;
			}
		}

		public void EndEffect()
		{
			this._update = false;
		}

		public void VerticalEffect(float shift)
		{
		}

		public override void Update(float fDeltaT)
		{
			this.xRotate(fDeltaT);
			bool update = this._update;
			if (update)
			{
				this.yRotate();
			}
		}

		private void yRotate()
		{
			Vector3 vector = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position - this._corner_intersection;
			vector.y = 0f;
			float num = Vector3.Angle(this._corner_dir, vector) / this._corner_sector;
			float num2 = this._corner_positive ? num : (1f - num);
			float num3 = this._corner_base_percentage * (this._corner_positive ? (1f - num2) : num2);
			float num4 = this._corner_curve.Evaluate(this._corner_positive ? (num2 - num3) : (num2 + num3));
			float num5 = (num4 - this._corner_curve[0].value) / (this._corner_curve[this._corner_curve.length - 1].value - this._corner_curve[0].value);
			this._target_y = this._in + (this._out - this._in) * (this._corner_positive ? num5 : (1f - num5));
			bool flag = !XCameraEx.OperationH && !XSingleton<XCutScene>.singleton.IsPlaying;
			if (flag)
			{
				this._camera_host.YRotate(this._target_y - this._camera_host.Root_R_Y);
			}
		}

		private void xRotate(float fDeltaT)
		{
			bool x_trigger = this._x_trigger;
			if (x_trigger)
			{
				float num = (this._target_x - this._camera_host.Root_R_X) * Mathf.Min(1f, fDeltaT);
				bool flag = Mathf.Abs(num) > 0.01f;
				if (flag)
				{
					this._camera_host.XRotate(num);
				}
				else
				{
					this._x_trigger = false;
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Camera_Wall_Component");

		private XCameraEx _camera_host = null;

		private bool _corner_positive = true;

		private Vector3 _corner_intersection = Vector3.zero;

		private Vector3 _corner_dir = Vector3.forward;

		private AnimationCurve _corner_curve = null;

		private float _corner_sector = 0f;

		private float _in = 0f;

		private float _out = 0f;

		private float _corner_base_percentage = 0f;

		private bool _update = false;

		private float _target_x = 0f;

		private float _target_y = 0f;

		private bool _x_trigger = false;
	}
}
