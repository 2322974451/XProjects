using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008B2 RID: 2226
	internal class XCameraMotionComponent : XComponent
	{
		// Token: 0x17002A39 RID: 10809
		// (get) Token: 0x06008681 RID: 34433 RVA: 0x00110260 File Offset: 0x0010E460
		public override uint ID
		{
			get
			{
				return XCameraMotionComponent.uuID;
			}
		}

		// Token: 0x17002A3A RID: 10810
		// (get) Token: 0x06008682 RID: 34434 RVA: 0x00110278 File Offset: 0x0010E478
		public XCameraEx.XStatus Status
		{
			get
			{
				return this._status;
			}
		}

		// Token: 0x06008683 RID: 34435 RVA: 0x00110290 File Offset: 0x0010E490
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._camera_host = (this._host as XCameraEx);
			this._status = XCameraEx.XStatus.None;
			this._to_damp = false;
		}

		// Token: 0x06008684 RID: 34436 RVA: 0x001102BC File Offset: 0x0010E4BC
		public override void Attached()
		{
			this._idle_motion.Follow_Position = true;
			this._idle_motion.Coordinate = CameraMotionSpace.World;
			this._idle_motion.AutoSync_At_Begin = false;
			this._idle_motion.LookAt_Target = (XSingleton<XEntityMgr>.singleton.Player != null);
			this._idle_motion.Motion = null;
			this._camera_host.ActiveMotion = (this._idle_motion.Clone() as XCameraMotionData);
		}

		// Token: 0x06008685 RID: 34437 RVA: 0x0011032E File Offset: 0x0010E52E
		public override void OnDetachFromHost()
		{
			this._camera_host.OverrideAnimClip("CameraEffect", null);
			XResourceLoaderMgr.SafeDestroyShareResource("", ref this._motionClip);
			this._camera_host = null;
			base.OnDetachFromHost();
		}

		// Token: 0x06008686 RID: 34438 RVA: 0x00110362 File Offset: 0x0010E562
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_CameraMotion, new XComponent.XEventHandler(this.OnMotion));
			base.RegisterEvent(XEventDefine.XEvent_CameraMotionEnd, new XComponent.XEventHandler(this.OnEndMotion));
		}

		// Token: 0x06008687 RID: 34439 RVA: 0x00110390 File Offset: 0x0010E590
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

		// Token: 0x06008688 RID: 34440 RVA: 0x0011044C File Offset: 0x0010E64C
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

		// Token: 0x06008689 RID: 34441 RVA: 0x001104EC File Offset: 0x0010E6EC
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

		// Token: 0x04002A14 RID: 10772
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Camera_Motion");

		// Token: 0x04002A15 RID: 10773
		private XCameraEx _camera_host = null;

		// Token: 0x04002A16 RID: 10774
		private string _trigger = null;

		// Token: 0x04002A17 RID: 10775
		private XCameraMotionData _proxy_motion = null;

		// Token: 0x04002A18 RID: 10776
		private XCameraMotionData _idle_motion = new XCameraMotionData();

		// Token: 0x04002A19 RID: 10777
		private XCameraEx.XStatus _status = XCameraEx.XStatus.None;

		// Token: 0x04002A1A RID: 10778
		private XEntity _proxy_target = null;

		// Token: 0x04002A1B RID: 10779
		private bool _to_damp = false;

		// Token: 0x04002A1C RID: 10780
		private bool _cutscene_end = false;

		// Token: 0x04002A1D RID: 10781
		private XAnimationClip _motionClip = null;
	}
}
