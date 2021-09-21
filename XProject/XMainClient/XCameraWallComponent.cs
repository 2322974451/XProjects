using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008B7 RID: 2231
	internal class XCameraWallComponent : XComponent
	{
		// Token: 0x17002A61 RID: 10849
		// (get) Token: 0x060086FB RID: 34555 RVA: 0x00113380 File Offset: 0x00111580
		public override uint ID
		{
			get
			{
				return XCameraWallComponent.uuID;
			}
		}

		// Token: 0x17002A62 RID: 10850
		// (get) Token: 0x060086FC RID: 34556 RVA: 0x00113398 File Offset: 0x00111598
		public float TargetX
		{
			get
			{
				return this._target_x;
			}
		}

		// Token: 0x17002A63 RID: 10851
		// (get) Token: 0x060086FD RID: 34557 RVA: 0x001133B0 File Offset: 0x001115B0
		// (set) Token: 0x060086FE RID: 34558 RVA: 0x001133C8 File Offset: 0x001115C8
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

		// Token: 0x17002A64 RID: 10852
		// (get) Token: 0x060086FF RID: 34559 RVA: 0x001133D4 File Offset: 0x001115D4
		// (set) Token: 0x06008700 RID: 34560 RVA: 0x001133EC File Offset: 0x001115EC
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

		// Token: 0x06008701 RID: 34561 RVA: 0x001133F6 File Offset: 0x001115F6
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._camera_host = (this._host as XCameraEx);
		}

		// Token: 0x06008702 RID: 34562 RVA: 0x00113412 File Offset: 0x00111612
		public override void OnDetachFromHost()
		{
			this._camera_host = null;
			base.OnDetachFromHost();
		}

		// Token: 0x06008703 RID: 34563 RVA: 0x00113424 File Offset: 0x00111624
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

		// Token: 0x06008704 RID: 34564 RVA: 0x00113503 File Offset: 0x00111703
		public void EndEffect()
		{
			this._update = false;
		}

		// Token: 0x06008705 RID: 34565 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void VerticalEffect(float shift)
		{
		}

		// Token: 0x06008706 RID: 34566 RVA: 0x00113510 File Offset: 0x00111710
		public override void Update(float fDeltaT)
		{
			this.xRotate(fDeltaT);
			bool update = this._update;
			if (update)
			{
				this.yRotate();
			}
		}

		// Token: 0x06008707 RID: 34567 RVA: 0x00113538 File Offset: 0x00111738
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

		// Token: 0x06008708 RID: 34568 RVA: 0x0011368C File Offset: 0x0011188C
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

		// Token: 0x04002A6F RID: 10863
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Camera_Wall_Component");

		// Token: 0x04002A70 RID: 10864
		private XCameraEx _camera_host = null;

		// Token: 0x04002A71 RID: 10865
		private bool _corner_positive = true;

		// Token: 0x04002A72 RID: 10866
		private Vector3 _corner_intersection = Vector3.zero;

		// Token: 0x04002A73 RID: 10867
		private Vector3 _corner_dir = Vector3.forward;

		// Token: 0x04002A74 RID: 10868
		private AnimationCurve _corner_curve = null;

		// Token: 0x04002A75 RID: 10869
		private float _corner_sector = 0f;

		// Token: 0x04002A76 RID: 10870
		private float _in = 0f;

		// Token: 0x04002A77 RID: 10871
		private float _out = 0f;

		// Token: 0x04002A78 RID: 10872
		private float _corner_base_percentage = 0f;

		// Token: 0x04002A79 RID: 10873
		private bool _update = false;

		// Token: 0x04002A7A RID: 10874
		private float _target_x = 0f;

		// Token: 0x04002A7B RID: 10875
		private float _target_y = 0f;

		// Token: 0x04002A7C RID: 10876
		private bool _x_trigger = false;
	}
}
