using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCameraSoloComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XCameraSoloComponent.uuID;
			}
		}

		public XCameraSoloComponent.XCameraSoloState SoloState
		{
			get
			{
				return this._solo_state;
			}
		}

		public float SoloInitAngle
		{
			get
			{
				return this._init_angle;
			}
		}

		public XEntity Target
		{
			get
			{
				return this._target;
			}
		}

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

		public override void OnDetachFromHost()
		{
			this._camera_host = null;
			base.OnDetachFromHost();
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_CameraSolo, new XComponent.XEventHandler(this.OnSolo));
		}

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

		public void Go()
		{
			this._solo_state = XCameraSoloComponent.XCameraSoloState.Triggered;
		}

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

		private float Palstance(Vector3 targetPosition)
		{
			Vector3 vector = targetPosition - this._base_position;
			vector.y = 0f;
			float num = vector.magnitude - this._targetRadius - XSingleton<XEntityMgr>.singleton.Player.Radius;
			float num2 = 2f;
			float num3 = 4f;
			return (num > num3) ? num2 : ((num > 0f) ? (Mathf.Sin(num / num3 * 1.5707964f) * num2) : 0f);
		}

		private void CalibrateAnchor(float y)
		{
			this._anchor.EngineObject.Position = this._base_position;
			this._anchor.EngineObject.Rotation = Quaternion.Euler(0f, y, 0f);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Camera_Solo_Effect");

		private XCameraEx _camera_host = null;

		private XCameraMotionData _motion = new XCameraMotionData();

		private XEmpty _anchor = null;

		private XEntity _target = null;

		private float _rotate_y = 0f;

		private float _init_angle = 0f;

		private float _base_angle = 0f;

		private float _targetRadius = 0f;

		private bool _first_execute = false;

		private Vector3 _base_direction = Vector3.forward;

		private Vector3 _base_position = Vector3.zero;

		private Vector3 _base_location = Vector3.zero;

		private Vector3 _last_location = Vector3.zero;

		private XCameraSoloComponent.XCameraSoloState _solo_state = XCameraSoloComponent.XCameraSoloState.Stop;

		public enum XCameraSoloState
		{

			Prepared,

			Triggered,

			Executing,

			Stop
		}
	}
}
