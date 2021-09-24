using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCameraMotionComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XCameraMotionComponent.uuID;
			}
		}

		public XCameraEx.XStatus Status
		{
			get
			{
				return this._status;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._camera_host = (this._host as XCameraEx);
			this._status = XCameraEx.XStatus.None;
			this._to_damp = false;
		}

		public override void Attached()
		{
			this._idle_motion.Follow_Position = true;
			this._idle_motion.Coordinate = CameraMotionSpace.World;
			this._idle_motion.AutoSync_At_Begin = false;
			this._idle_motion.LookAt_Target = (XSingleton<XEntityMgr>.singleton.Player != null);
			this._idle_motion.Motion = null;
			this._camera_host.ActiveMotion = (this._idle_motion.Clone() as XCameraMotionData);
		}

		public override void OnDetachFromHost()
		{
			this._camera_host.OverrideAnimClip("CameraEffect", null);
			XResourceLoaderMgr.SafeDestroyShareResource("", ref this._motionClip);
			this._camera_host = null;
			base.OnDetachFromHost();
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_CameraMotion, new XComponent.XEventHandler(this.OnMotion));
			base.RegisterEvent(XEventDefine.XEvent_CameraMotionEnd, new XComponent.XEventHandler(this.OnEndMotion));
		}

		protected bool OnMotion(XEventArgs e)
		{
			XCameraMotionEventArgs xcameraMotionEventArgs = e as XCameraMotionEventArgs;
			bool flag = xcameraMotionEventArgs.Trigger == "ToEffect";
			if (flag)
			{
				XResourceLoaderMgr.SafeGetAnimationClip(xcameraMotionEventArgs.Motion.Motion, ref this._motionClip);
				bool flag2 = this._motionClip != null;
				if (!flag2)
				{
					return false;
				}
				this._camera_host.OverrideAnimClip("CameraEffect", this._motionClip.clip);
			}
			this._trigger = xcameraMotionEventArgs.Trigger;
			this._proxy_motion = xcameraMotionEventArgs.Motion;
			this._to_damp = (this._camera_host.Target != null && xcameraMotionEventArgs.Target != null);
			this._proxy_target = xcameraMotionEventArgs.Target;
			return true;
		}

		protected bool OnEndMotion(XEventArgs e)
		{
			XCameraMotionEndEventArgs xcameraMotionEndEventArgs = e as XCameraMotionEndEventArgs;
			bool flag = this._proxy_target != xcameraMotionEndEventArgs.Target || this._status == XCameraEx.XStatus.Idle;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._trigger = "ToIdle";
				this._cutscene_end = xcameraMotionEndEventArgs.CutSceneEnd;
				this._proxy_motion = this._idle_motion;
				this._to_damp = (this._camera_host.Target != null);
				this._proxy_target = ((this._camera_host == XSingleton<XScene>.singleton.GameCamera) ? XSingleton<XEntityMgr>.singleton.Player : xcameraMotionEndEventArgs.Target);
				result = true;
			}
			return result;
		}

		public void MotionUpdate(float fDeltaT)
		{
			bool flag = this._trigger != null && !this._camera_host.Ator.IsInTransition(0);
			if (flag)
			{
				string trigger = this._trigger;
				if (!(trigger == "ToIdle"))
				{
					if (!(trigger == "ToEffect"))
					{
						if (trigger == "ToSolo")
						{
							this._status = XCameraEx.XStatus.Solo;
						}
					}
					else
					{
						this._status = XCameraEx.XStatus.Effect;
					}
				}
				else
				{
					this._status = XCameraEx.XStatus.Idle;
				}
				bool flag2 = this._camera_host.Solo != null && this._camera_host.Solo.SoloState == XCameraSoloComponent.XCameraSoloState.Executing;
				if (flag2)
				{
					this._proxy_target = this._camera_host.Target;
					this._camera_host.ActiveMotion.AutoSync_At_Begin = true;
				}
				else
				{
					bool flag3 = this._camera_host.Solo != null && this._camera_host.Solo.SoloState == XCameraSoloComponent.XCameraSoloState.Prepared;
					if (flag3)
					{
						this._camera_host.Solo.Go();
					}
					this._camera_host.ActiveMotion = (this._proxy_motion.Clone() as XCameraMotionData);
					this._camera_host.Target = this._proxy_target;
					this._camera_host.RootReady = false;
				}
				bool cutscene_end = this._cutscene_end;
				if (cutscene_end)
				{
					bool flag4 = XSingleton<XScene>.singleton.GameCamera.Collision != null;
					if (flag4)
					{
						XSingleton<XScene>.singleton.GameCamera.Collision.Enabled = true;
					}
					bool flag5 = XSingleton<XScene>.singleton.GameCamera.VAdjust != null;
					if (flag5)
					{
						XSingleton<XScene>.singleton.GameCamera.VAdjust.Enabled = (XOperationData.Is3DMode() && !XCameraEx.OperationV);
					}
					this._cutscene_end = false;
				}
				this._camera_host.Ator.SetTrigger(this._trigger);
				this._trigger = null;
				bool to_damp = this._to_damp;
				if (to_damp)
				{
					this._to_damp = false;
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Camera_Motion");

		private XCameraEx _camera_host = null;

		private string _trigger = null;

		private XCameraMotionData _proxy_motion = null;

		private XCameraMotionData _idle_motion = new XCameraMotionData();

		private XCameraEx.XStatus _status = XCameraEx.XStatus.None;

		private XEntity _proxy_target = null;

		private bool _to_damp = false;

		private bool _cutscene_end = false;

		private XAnimationClip _motionClip = null;
	}
}
