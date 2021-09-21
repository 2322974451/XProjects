using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008B5 RID: 2229
	internal class XCameraSoloComponent : XComponent
	{
		// Token: 0x17002A5C RID: 10844
		// (get) Token: 0x060086E3 RID: 34531 RVA: 0x00112848 File Offset: 0x00110A48
		public override uint ID
		{
			get
			{
				return XCameraSoloComponent.uuID;
			}
		}

		// Token: 0x17002A5D RID: 10845
		// (get) Token: 0x060086E4 RID: 34532 RVA: 0x00112860 File Offset: 0x00110A60
		public XCameraSoloComponent.XCameraSoloState SoloState
		{
			get
			{
				return this._solo_state;
			}
		}

		// Token: 0x17002A5E RID: 10846
		// (get) Token: 0x060086E5 RID: 34533 RVA: 0x00112878 File Offset: 0x00110A78
		public float SoloInitAngle
		{
			get
			{
				return this._init_angle;
			}
		}

		// Token: 0x17002A5F RID: 10847
		// (get) Token: 0x060086E6 RID: 34534 RVA: 0x00112890 File Offset: 0x00110A90
		public XEntity Target
		{
			get
			{
				return this._target;
			}
		}

		// Token: 0x060086E7 RID: 34535 RVA: 0x001128A8 File Offset: 0x00110AA8
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._motion.AutoSync_At_Begin = true;
			this._motion.Coordinate = CameraMotionSpace.World;
			this._motion.Follow_Position = true;
			this._motion.LookAt_Target = false;
			this._motion.At = 0f;
			this._motion.Motion = "Animation/Main_Camera/Main_Camera_Idle";
			this._camera_host = (this._host as XCameraEx);
			this._solo_state = XCameraSoloComponent.XCameraSoloState.Stop;
			this._anchor = XSingleton<XEntityMgr>.singleton.CreateEmpty();
		}

		// Token: 0x060086E8 RID: 34536 RVA: 0x00112936 File Offset: 0x00110B36
		public override void OnDetachFromHost()
		{
			this._camera_host = null;
			base.OnDetachFromHost();
		}

		// Token: 0x060086E9 RID: 34537 RVA: 0x00112947 File Offset: 0x00110B47
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_CameraSolo, new XComponent.XEventHandler(this.OnSolo));
		}

		// Token: 0x060086EA RID: 34538 RVA: 0x00112960 File Offset: 0x00110B60
		protected bool OnSolo(XEventArgs e)
		{
			bool flag = !XCameraEx.OperationH || XSingleton<XOperationData>.singleton.OffSolo;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XCameraSoloEventArgs xcameraSoloEventArgs = e as XCameraSoloEventArgs;
				this._target = xcameraSoloEventArgs.Target;
				bool flag2 = !XEntity.ValideEntity(this._target);
				if (flag2)
				{
					result = true;
				}
				else
				{
					Vector3 position = this._target.EngineObject.Position;
					this._last_location = position;
					this._targetRadius = this._target.Radius;
					this._base_position = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position;
					this._base_position.y = XSingleton<XScene>.singleton.TerrainY(position);
					this._base_direction = XSingleton<XCommon>.singleton.Horizontal(this._target.EngineObject.Position - this._base_position);
					this._base_angle = XSingleton<XCommon>.singleton.AngleToFloat(this._base_direction);
					this._base_location = this._camera_host.CameraTrans.position;
					this._init_angle = this._base_angle;
					this.CalibrateAnchor(this._init_angle);
					this._solo_state = XCameraSoloComponent.XCameraSoloState.Prepared;
					this.Start();
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060086EB RID: 34539 RVA: 0x00112A98 File Offset: 0x00110C98
		public void Start()
		{
			this._first_execute = true;
			XCameraMotionEventArgs @event = XEventPool<XCameraMotionEventArgs>.GetEvent();
			@event.Motion = this._motion;
			@event.Target = this._anchor;
			@event.Trigger = "ToSolo";
			@event.Firer = this._camera_host;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			bool flag = this._target != null && this._target.IsBoss;
			if (flag)
			{
				XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/mapambience/bossnew");
			}
		}

		// Token: 0x060086EC RID: 34540 RVA: 0x00112B19 File Offset: 0x00110D19
		public void Go()
		{
			this._solo_state = XCameraSoloComponent.XCameraSoloState.Triggered;
		}

		// Token: 0x060086ED RID: 34541 RVA: 0x00112B24 File Offset: 0x00110D24
		public override void Update(float fDeltaT)
		{
			XCameraSoloComponent.XCameraSoloState solo_state = this._solo_state;
			if (solo_state != XCameraSoloComponent.XCameraSoloState.Triggered)
			{
				if (solo_state == XCameraSoloComponent.XCameraSoloState.Executing)
				{
					bool flag = XEntity.ValideEntity(this._target);
					if (flag)
					{
						this.Execution(this._target.RadiusCenter, fDeltaT);
						this._last_location = this._target.RadiusCenter;
					}
					else
					{
						bool flag2 = XSingleton<XSceneMgr>.singleton.Is1V1Scene();
						if (flag2)
						{
							this.Execution(this._last_location, fDeltaT);
						}
						else
						{
							this.Stop();
						}
					}
				}
			}
			else
			{
				bool rootReady = this._camera_host.RootReady;
				if (rootReady)
				{
					this._solo_state = XCameraSoloComponent.XCameraSoloState.Executing;
				}
			}
		}

		// Token: 0x060086EE RID: 34542 RVA: 0x00112BC8 File Offset: 0x00110DC8
		private void Execution(Vector3 position, float fDeltaT)
		{
			bool first_execute = this._first_execute;
			if (first_execute)
			{
				this._base_position = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position;
				this._first_execute = false;
			}
			else
			{
				Vector3 vector = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position - this._base_position;
				Vector3 vector2 = Vector3.Project(vector, this._base_direction);
				Vector3 vector3 = Vector3.Project(vector, Vector3.up);
				Vector3 vector4 = Vector3.Project(vector, Vector3.Cross(this._base_direction, Vector3.up));
				float num = (Vector3.Angle(vector2, this._base_direction) > 90f) ? 6f : 3f;
				this._base_position += vector2 * Mathf.Min(1f, num * fDeltaT);
				this._base_position += vector3 * Mathf.Min(1f, 2f * fDeltaT);
				this._base_position += vector4 * Mathf.Min(1f, 2f * fDeltaT);
			}
			Vector3 vector5 = XSingleton<XCommon>.singleton.Horizontal(position - this._base_position);
			float num2 = Vector3.Angle(vector5, this._base_direction);
			bool flag = XSingleton<XCommon>.singleton.Clockwise(this._base_direction, vector5);
			if (flag)
			{
				num2 = -num2;
			}
			this._base_angle += (0f - num2) * Mathf.Min(1f, this.Palstance(position) * fDeltaT);
			this._base_direction = XSingleton<XCommon>.singleton.FloatToAngle(this._base_angle);
			float num3 = XSingleton<XCommon>.singleton.AngleToFloat(this._base_direction);
			this._rotate_y = num3 - this._init_angle;
			this._camera_host.YRotateExBarely(this._rotate_y);
			this.CalibrateAnchor(num3);
		}

		// Token: 0x060086EF RID: 34543 RVA: 0x00112DB0 File Offset: 0x00110FB0
		public override void PostUpdate(float fDeltaT)
		{
			bool flag = this._solo_state == XCameraSoloComponent.XCameraSoloState.Executing;
			if (flag)
			{
				Vector3 eulerAngles = this._camera_host.CameraTrans.rotation.eulerAngles;
				Vector3 vector = Quaternion.Euler(eulerAngles) * Vector3.forward;
				this._camera_host.Offset += (this._camera_host.TargetOffset - this._camera_host.Offset) * Mathf.Min(1f, fDeltaT * 4f);
				this._base_location = this._camera_host.Anchor - vector * this._camera_host.Offset;
			}
		}

		// Token: 0x060086F0 RID: 34544 RVA: 0x00112E60 File Offset: 0x00111060
		private float Palstance(Vector3 targetPosition)
		{
			Vector3 vector = targetPosition - this._base_position;
			vector.y = 0f;
			float num = vector.magnitude - this._targetRadius - XSingleton<XEntityMgr>.singleton.Player.Radius;
			float num2 = 2f;
			float num3 = 4f;
			return (num > num3) ? num2 : ((num > 0f) ? (Mathf.Sin(num / num3 * 1.5707964f) * num2) : 0f);
		}

		// Token: 0x060086F1 RID: 34545 RVA: 0x00112EE2 File Offset: 0x001110E2
		private void CalibrateAnchor(float y)
		{
			this._anchor.EngineObject.Position = this._base_position;
			this._anchor.EngineObject.Rotation = Quaternion.Euler(0f, y, 0f);
		}

		// Token: 0x060086F2 RID: 34546 RVA: 0x00112F20 File Offset: 0x00111120
		public void Stop()
		{
			bool flag = this._camera_host == null || this._solo_state == XCameraSoloComponent.XCameraSoloState.Stop;
			if (!flag)
			{
				this._target = null;
				this._solo_state = XCameraSoloComponent.XCameraSoloState.Stop;
				XCameraMotionEndEventArgs @event = XEventPool<XCameraMotionEndEventArgs>.GetEvent();
				@event.Firer = this._camera_host;
				@event.Target = this._anchor;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				this._camera_host.AdjustRoot();
				this._camera_host.TargetOffset = this._camera_host.DefaultOffset;
			}
		}

		// Token: 0x04002A5C RID: 10844
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Camera_Solo_Effect");

		// Token: 0x04002A5D RID: 10845
		private XCameraEx _camera_host = null;

		// Token: 0x04002A5E RID: 10846
		private XCameraMotionData _motion = new XCameraMotionData();

		// Token: 0x04002A5F RID: 10847
		private XEmpty _anchor = null;

		// Token: 0x04002A60 RID: 10848
		private XEntity _target = null;

		// Token: 0x04002A61 RID: 10849
		private float _rotate_y = 0f;

		// Token: 0x04002A62 RID: 10850
		private float _init_angle = 0f;

		// Token: 0x04002A63 RID: 10851
		private float _base_angle = 0f;

		// Token: 0x04002A64 RID: 10852
		private float _targetRadius = 0f;

		// Token: 0x04002A65 RID: 10853
		private bool _first_execute = false;

		// Token: 0x04002A66 RID: 10854
		private Vector3 _base_direction = Vector3.forward;

		// Token: 0x04002A67 RID: 10855
		private Vector3 _base_position = Vector3.zero;

		// Token: 0x04002A68 RID: 10856
		private Vector3 _base_location = Vector3.zero;

		// Token: 0x04002A69 RID: 10857
		private Vector3 _last_location = Vector3.zero;

		// Token: 0x04002A6A RID: 10858
		private XCameraSoloComponent.XCameraSoloState _solo_state = XCameraSoloComponent.XCameraSoloState.Stop;

		// Token: 0x02001952 RID: 6482
		public enum XCameraSoloState
		{
			// Token: 0x04007D91 RID: 32145
			Prepared,
			// Token: 0x04007D92 RID: 32146
			Triggered,
			// Token: 0x04007D93 RID: 32147
			Executing,
			// Token: 0x04007D94 RID: 32148
			Stop
		}
	}
}
