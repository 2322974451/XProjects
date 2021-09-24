using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCameraShakeComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XCameraShakeComponent.uuID;
			}
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_CameraShake, new XComponent.XEventHandler(this.OnBasicShake));
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._camera = (host as XCameraEx);
			this._fov = this._camera.InitFOV;
		}

		private bool OnBasicShake(XEventArgs e)
		{
			bool flag = this._camera != null;
			if (flag)
			{
				XCameraShakeEventArgs xcameraShakeEventArgs = e as XCameraShakeEventArgs;
				bool flag2 = xcameraShakeEventArgs.Effect == null;
				if (flag2)
				{
					this.StopShake();
					return true;
				}
				this._time_scale = xcameraShakeEventArgs.TimeScale;
				this._args = xcameraShakeEventArgs.Effect;
				this._timeEscaped = 0f;
				this._timeInterval = 0f;
				this._fov = this._camera.InitFOV;
				this._shake = true;
				switch (this._args.Coordinate)
				{
				case CameraMotionSpace.World:
					this.x = Vector3.right;
					this.y = Vector3.up;
					this.z = Vector3.forward;
					break;
				case CameraMotionSpace.Self:
					this.x = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Right;
					this.y = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Up;
					this.z = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Forward;
					break;
				case CameraMotionSpace.Camera:
					this.x = XSingleton<XScene>.singleton.GameCamera.UnityCamera.transform.right;
					this.y = XSingleton<XScene>.singleton.GameCamera.UnityCamera.transform.up;
					this.z = XSingleton<XScene>.singleton.GameCamera.UnityCamera.transform.forward;
					break;
				}
				this._random = this._args.Random;
			}
			this._rfactor = 1;
			return true;
		}

		public override void PostUpdate(float fDeltaT)
		{
			bool flag = this._camera != null && this._shake;
			if (flag)
			{
				this._timeEscaped += fDeltaT;
				this._timeInterval += fDeltaT;
				bool flag2 = XSingleton<XCommon>.singleton.IsGreater(this._timeEscaped, this._args.Time * this._time_scale);
				if (flag2)
				{
					this.StopShake();
				}
				else
				{
					bool flag3 = XSingleton<XCommon>.singleton.IsGreater(this._timeInterval, 1f / this._args.Frequency * this._time_scale);
					if (flag3)
					{
						this._rfactor = -this._rfactor;
						this._camera.CameraTrans.position += this.Shake();
						this._camera.UnityCamera.fieldOfView = this._fov + (this._random ? Random.Range(-this._args.FovAmp, this._args.FovAmp) : (this._args.FovAmp * (float)this._rfactor));
						this._timeInterval = 0f;
					}
				}
			}
		}

		private void StopShake()
		{
			this._args = null;
			this._timeEscaped = 0f;
			this._shake = false;
			this._camera.FovBack();
		}

		private Vector3 Shake()
		{
			float num = this._random ? Random.Range(-this._args.AmplitudeX, this._args.AmplitudeX) : (this._args.AmplitudeX * (float)this._rfactor);
			float num2 = this._random ? Random.Range(-this._args.AmplitudeY, this._args.AmplitudeY) : (this._args.AmplitudeY * (float)this._rfactor);
			float num3 = this._random ? Random.Range(-this._args.AmplitudeZ, this._args.AmplitudeZ) : (this._args.AmplitudeZ * (float)this._rfactor);
			Vector3 vector = Vector3.zero;
			bool shakeX = this._args.ShakeX;
			if (shakeX)
			{
				vector += this.x * num;
			}
			bool shakeY = this._args.ShakeY;
			if (shakeY)
			{
				vector += this.y * num2;
			}
			bool shakeZ = this._args.ShakeZ;
			if (shakeZ)
			{
				vector += this.z * num3;
			}
			return vector;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Camera_Basic_Shake");

		private XCameraEffectData _args;

		private XCameraEx _camera = null;

		private float _timeEscaped = 0f;

		private float _timeInterval = 0f;

		private float _fov = 0f;

		private float _time_scale = 1f;

		private bool _shake = false;

		private Vector3 x = Vector3.right;

		private Vector3 y = Vector3.up;

		private Vector3 z = Vector3.forward;

		private bool _random = false;

		private int _rfactor = 1;
	}
}
