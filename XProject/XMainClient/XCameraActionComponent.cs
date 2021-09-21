using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008AD RID: 2221
	internal class XCameraActionComponent : XComponent
	{
		// Token: 0x17002A31 RID: 10801
		// (get) Token: 0x06008650 RID: 34384 RVA: 0x0010E5F0 File Offset: 0x0010C7F0
		public override uint ID
		{
			get
			{
				return XCameraActionComponent.uuID;
			}
		}

		// Token: 0x06008651 RID: 34385 RVA: 0x0010E607 File Offset: 0x0010C807
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._camera_host = (host as XCameraEx);
			this._world_stage = (XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World);
		}

		// Token: 0x06008652 RID: 34386 RVA: 0x0010E636 File Offset: 0x0010C836
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			this._camera_host = null;
		}

		// Token: 0x06008653 RID: 34387 RVA: 0x0010E647 File Offset: 0x0010C847
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_CameraAction, new XComponent.XEventHandler(this.OnAction));
		}

		// Token: 0x06008654 RID: 34388 RVA: 0x0010E660 File Offset: 0x0010C860
		protected bool OnAction(XEventArgs e)
		{
			XCameraActionEventArgs xcameraActionEventArgs = e as XCameraActionEventArgs;
			bool flag = this._handler != null;
			if (flag)
			{
				this._handler();
				this._handler = null;
			}
			this._tx = xcameraActionEventArgs.XRotate;
			this._ty = xcameraActionEventArgs.YRotate;
			this._manual_x = this._camera_host.Root_R_X;
			this._manual_y = XSingleton<XCommon>.singleton.AngleNormalize(this._ty, this._camera_host.Root_R_Y);
			this._dis = ((xcameraActionEventArgs.Dis > 0f) ? xcameraActionEventArgs.Dis : this._camera_host.TargetOffset);
			this._handler = xcameraActionEventArgs.Finish;
			this._auto = false;
			return true;
		}

		// Token: 0x06008655 RID: 34389 RVA: 0x0010E720 File Offset: 0x0010C920
		public override void Update(float fDeltaT)
		{
			bool flag = base.Enabled && XSingleton<XGesture>.singleton.Working && !this._camera_host.IsDuringCloseUp;
			if (flag)
			{
				bool began = this._began;
				if (began)
				{
					this._tx = 0f;
					this._auto_x = 0f;
					this._ty = 0f;
					this._auto_y = 0f;
				}
				else
				{
					bool operationH = XCameraEx.OperationH;
					if (operationH)
					{
						this._tx = (XSingleton<XGesture>.singleton.GesturePosition.x - this._last_pos.x) * (this._world_stage ? XSingleton<XOperationData>.singleton.ManualCameraSpeedXInBattle : XSingleton<XOperationData>.singleton.ManualCameraSpeedXInHall);
					}
					bool operationV = XCameraEx.OperationV;
					if (operationV)
					{
						this._ty = (XSingleton<XGesture>.singleton.GesturePosition.y - this._last_pos.y) * (this._world_stage ? XSingleton<XOperationData>.singleton.ManualCameraSpeedYInBattle : XSingleton<XOperationData>.singleton.ManualCameraSpeedYInHall);
					}
				}
				this._last_pos = XSingleton<XGesture>.singleton.GesturePosition;
				this._began = false;
				this._auto = true;
			}
			else
			{
				this._began = true;
				bool auto = this._auto;
				if (auto)
				{
					this._tx = 0f;
					this._ty = 0f;
				}
			}
			bool auto2 = this._auto;
			if (auto2)
			{
				this._auto_x += (this._tx - this._auto_x) * Mathf.Min(1f, fDeltaT * (this._world_stage ? XSingleton<XOperationData>.singleton.ManualCameraDampXInBattle : XSingleton<XOperationData>.singleton.ManualCameraDampXInHall));
				this._auto_y += (this._ty - this._auto_y) * Mathf.Min(1f, fDeltaT * (this._world_stage ? XSingleton<XOperationData>.singleton.ManualCameraDampYInBattle : XSingleton<XOperationData>.singleton.ManualCameraDampYInHall));
				bool flag2 = this._auto_y != 0f;
				if (flag2)
				{
					this._camera_host.XRotate(-this._auto_y);
				}
				bool flag3 = this._auto_x != 0f;
				if (flag3)
				{
					this._camera_host.YRotate(this._auto_x);
				}
			}
			else
			{
				this._manual_x += (this._tx - this._manual_x) * Mathf.Min(1f, fDeltaT * XSingleton<XGlobalConfig>.singleton.CloseUpCameraSpeed);
				this._manual_y += (this._ty - this._manual_y) * Mathf.Min(1f, fDeltaT * XSingleton<XGlobalConfig>.singleton.CloseUpCameraSpeed);
				this._camera_host.XRotateEx(this._manual_x);
				this._camera_host.YRotateEx(this._manual_y);
				this._camera_host.Offset += (this._dis - this._camera_host.Offset) * Mathf.Min(1f, fDeltaT * XSingleton<XGlobalConfig>.singleton.CloseUpCameraSpeed);
				bool flag4 = Mathf.Abs(this._tx - this._manual_x) < 1f && Mathf.Abs(this._ty - this._manual_y) < 1f && this._handler != null;
				if (flag4)
				{
					this._handler();
					this._handler = null;
				}
			}
		}

		// Token: 0x040029E1 RID: 10721
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Camera_Common_Action");

		// Token: 0x040029E2 RID: 10722
		private XCameraEx _camera_host = null;

		// Token: 0x040029E3 RID: 10723
		private Vector3 _last_pos = Vector3.zero;

		// Token: 0x040029E4 RID: 10724
		private bool _began = false;

		// Token: 0x040029E5 RID: 10725
		private float _auto_x = 0f;

		// Token: 0x040029E6 RID: 10726
		private float _auto_y = 0f;

		// Token: 0x040029E7 RID: 10727
		private float _manual_x = 0f;

		// Token: 0x040029E8 RID: 10728
		private float _manual_y = 0f;

		// Token: 0x040029E9 RID: 10729
		private float _dis = 0f;

		// Token: 0x040029EA RID: 10730
		private float _tx = 0f;

		// Token: 0x040029EB RID: 10731
		private float _ty = 0f;

		// Token: 0x040029EC RID: 10732
		private bool _auto = true;

		// Token: 0x040029ED RID: 10733
		private bool _world_stage = false;

		// Token: 0x040029EE RID: 10734
		private XCameraActionEventArgs.FinishHandler _handler = null;
	}
}
