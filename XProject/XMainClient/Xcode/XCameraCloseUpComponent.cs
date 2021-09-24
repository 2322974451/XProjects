using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCameraCloseUpComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XCameraCloseUpComponent.uuID;
			}
		}

		public bool Execute
		{
			get
			{
				return this._execute;
			}
		}

		public bool Ending
		{
			get
			{
				return this._ending;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._camera_host = (this._host as XCameraEx);
		}

		public override void OnDetachFromHost()
		{
			this._execute = false;
			this._camera_host = null;
			base.OnDetachFromHost();
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_CameraCloseUp, new XComponent.XEventHandler(this.OnCloseUp));
			base.RegisterEvent(XEventDefine.XEvent_CameraCloseUpEnd, new XComponent.XEventHandler(this.OnCloseUpEnd));
		}

		protected bool OnCloseUp(XEventArgs e)
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player == null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XComponent xcomponent = this._camera_host.GetXComponent(XCameraCollisonComponent.uuID);
				bool flag2 = xcomponent != null;
				if (flag2)
				{
					xcomponent.Enabled = false;
				}
				this._return_with_collision = (Mathf.Abs(this._camera_host.Offset - this._camera_host.TargetOffset) > 0.1f);
				XCameraCloseUpEventArgs xcameraCloseUpEventArgs = e as XCameraCloseUpEventArgs;
				this._Half_V_Fov = 0.017453292f * (this._camera_host.UnityCamera.fieldOfView * 0.5f);
				float num = (float)XSingleton<XGameUI>.singleton.Base_UI_Width / (float)XSingleton<XGameUI>.singleton.Base_UI_Height;
				this._Half_H_Fov = (float)Math.Atan(Math.Tan((double)this._Half_V_Fov) * (double)num);
				this._execute = true;
				this._anchor = this._camera_host.Anchor;
				this._target = xcameraCloseUpEventArgs.Target;
				this._pre_x = this._camera_host.Root_R_X;
				this._pre_y = this._camera_host.Root_R_Y;
				Vector3 vector = (this._target == null) ? XSingleton<XEntityMgr>.singleton.Player.EngineObject.Forward : XSingleton<XCommon>.singleton.Horizontal(this._target.EngineObject.Position - XSingleton<XEntityMgr>.singleton.Player.MoveObj.Position);
				XCameraActionEventArgs @event = XEventPool<XCameraActionEventArgs>.GetEvent();
				@event.XRotate = this.TargetX();
				@event.YRotate = this.ForwardY(vector);
				@event.Dis = this.TargetH();
				@event.Firer = XSingleton<XScene>.singleton.GameCamera;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				XSingleton<XEntityMgr>.singleton.Player.Net.ReportRotateAction(vector);
				this._ending = false;
				this._reachend = false;
				result = true;
			}
			return result;
		}

		protected bool OnCloseUpEnd(XEventArgs e)
		{
			XCameraActionEventArgs @event = XEventPool<XCameraActionEventArgs>.GetEvent();
			@event.XRotate = ((this._pre_x < this._camera_host.Root_R_X_Default) ? this._camera_host.Root_R_X_Default : this._pre_x);
			@event.YRotate = this._pre_y;
			@event.Dis = this._camera_host.TargetOffset;
			@event.Firer = XSingleton<XScene>.singleton.GameCamera;
			@event.Finish = new XCameraActionEventArgs.FinishHandler(this.Interrupt);
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			this._gap = this._camera_host.Anchor - this._anchor;
			this._ending = true;
			this._reachend = false;
			bool return_with_collision = this._return_with_collision;
			if (return_with_collision)
			{
				XComponent xcomponent = this._camera_host.GetXComponent(XCameraCollisonComponent.uuID);
				bool flag = xcomponent != null;
				if (flag)
				{
					xcomponent.Enabled = true;
				}
			}
			return true;
		}

		protected void Interrupt()
		{
			this._reachend = true;
		}

		public void Stop(object o)
		{
			this._execute = false;
			XComponent xcomponent = this._camera_host.GetXComponent(XCameraCollisonComponent.uuID);
			bool flag = xcomponent != null;
			if (flag)
			{
				xcomponent.Enabled = true;
			}
		}

		public void CloseUpdate(float fDeltaT)
		{
			bool execute = this._execute;
			if (execute)
			{
				Vector3 vector = Vector3.zero;
				bool ending = this._ending;
				if (ending)
				{
					vector = this._camera_host.Anchor;
				}
				else
				{
					bool flag = this._target is XNpc && (this._target as XNpc).NPCType == 2U;
					if (flag)
					{
						vector = this._target.EngineObject.Position;
						vector.y += XSingleton<XEntityMgr>.singleton.Player.Height * 0.5f;
						Vector3 vector2 = XSingleton<XCommon>.singleton.Horizontal(Vector3.Cross(Vector3.up, XSingleton<XEntityMgr>.singleton.Player.Rotate.GetMeaningfulFaceVector3()));
						vector += vector2 * 0.5f;
					}
					else
					{
						vector = XSingleton<XEntityMgr>.singleton.Player.MoveObj.Position;
						vector.y += XSingleton<XEntityMgr>.singleton.Player.Height * 0.5f;
						Vector3 vector3 = XSingleton<XCommon>.singleton.Horizontal(Vector3.Cross(Vector3.up, XSingleton<XEntityMgr>.singleton.Player.Rotate.GetMeaningfulFaceVector3()));
						vector += vector3 * Mathf.Tan(this._Half_H_Fov * 0.4f) * this._dis;
					}
				}
				bool ending2 = this._ending;
				if (ending2)
				{
					this._gap += (Vector3.zero - this._gap) * Mathf.Min(1f, fDeltaT * 4f);
					this._anchor = vector - this._gap;
				}
				else
				{
					this._anchor += (vector - this._anchor) * Mathf.Min(1f, fDeltaT * 4f);
				}
				this._camera_host.CameraTrans.LookAt(this._anchor);
				this._camera_host.CameraTrans.position = this._anchor - this._camera_host.CameraTrans.forward * this._camera_host.Offset;
				bool flag2 = this._ending && this._reachend && (vector - this._anchor).magnitude < 0.01f;
				if (flag2)
				{
					this.Stop(null);
				}
			}
		}

		private float ForwardY(Vector3 v)
		{
			v = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(v, -45f, true);
			return XSingleton<XCommon>.singleton.AngleToFloat(v);
		}

		private float TargetH()
		{
			bool flag = this._target is XNpc && (this._target as XNpc).NPCType == 2U;
			if (flag)
			{
				this._dis = 3f;
			}
			else
			{
				this._dis = XSingleton<XEntityMgr>.singleton.Player.Height * 0.5f / 0.9f / Mathf.Tan(this._Half_V_Fov);
			}
			return this._dis;
		}

		private float TargetX()
		{
			bool flag = this._target is XNpc && (this._target as XNpc).NPCType == 2U;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				result = -20f;
			}
			return result;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Camera_CloseUp_Component");

		private XCameraEx _camera_host = null;

		private XCameraMotionData _motion = new XCameraMotionData();

		private Vector3 _anchor = Vector3.zero;

		private XEntity _target = null;

		private float _Half_V_Fov = 0f;

		private float _Half_H_Fov = 0f;

		private float _dis = 0f;

		private float _pre_x = 0f;

		private float _pre_y = 0f;

		private bool _ending = false;

		private bool _execute = false;

		private bool _reachend = false;

		private Vector3 _gap = Vector3.zero;

		private bool _return_with_collision = false;
	}
}
