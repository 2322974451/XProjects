using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCameraActionComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XCameraActionComponent.uuID;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._camera_host = (host as XCameraEx);
			this._world_stage = (XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World);
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			this._camera_host = null;
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_CameraAction, new XComponent.XEventHandler(this.OnAction));
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Camera_Common_Action");

		private XCameraEx _camera_host = null;

		private Vector3 _last_pos = Vector3.zero;

		private bool _began = false;

		private float _auto_x = 0f;

		private float _auto_y = 0f;

		private float _manual_x = 0f;

		private float _manual_y = 0f;

		private float _dis = 0f;

		private float _tx = 0f;

		private float _ty = 0f;

		private bool _auto = true;

		private bool _world_stage = false;

		private XCameraActionEventArgs.FinishHandler _handler = null;
	}
}
