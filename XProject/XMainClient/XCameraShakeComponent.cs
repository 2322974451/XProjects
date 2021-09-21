using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008B4 RID: 2228
	internal class XCameraShakeComponent : XComponent
	{
		// Token: 0x17002A5B RID: 10843
		// (get) Token: 0x060086DA RID: 34522 RVA: 0x00112320 File Offset: 0x00110520
		public override uint ID
		{
			get
			{
				return XCameraShakeComponent.uuID;
			}
		}

		// Token: 0x060086DB RID: 34523 RVA: 0x00112337 File Offset: 0x00110537
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_CameraShake, new XComponent.XEventHandler(this.OnBasicShake));
		}

		// Token: 0x060086DC RID: 34524 RVA: 0x0011234F File Offset: 0x0011054F
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._camera = (host as XCameraEx);
			this._fov = this._camera.InitFOV;
		}

		// Token: 0x060086DD RID: 34525 RVA: 0x00112378 File Offset: 0x00110578
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

		// Token: 0x060086DE RID: 34526 RVA: 0x0011251C File Offset: 0x0011071C
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

		// Token: 0x060086DF RID: 34527 RVA: 0x00112652 File Offset: 0x00110852
		private void StopShake()
		{
			this._args = null;
			this._timeEscaped = 0f;
			this._shake = false;
			this._camera.FovBack();
		}

		// Token: 0x060086E0 RID: 34528 RVA: 0x0011267C File Offset: 0x0011087C
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

		// Token: 0x04002A4F RID: 10831
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Camera_Basic_Shake");

		// Token: 0x04002A50 RID: 10832
		private XCameraEffectData _args;

		// Token: 0x04002A51 RID: 10833
		private XCameraEx _camera = null;

		// Token: 0x04002A52 RID: 10834
		private float _timeEscaped = 0f;

		// Token: 0x04002A53 RID: 10835
		private float _timeInterval = 0f;

		// Token: 0x04002A54 RID: 10836
		private float _fov = 0f;

		// Token: 0x04002A55 RID: 10837
		private float _time_scale = 1f;

		// Token: 0x04002A56 RID: 10838
		private bool _shake = false;

		// Token: 0x04002A57 RID: 10839
		private Vector3 x = Vector3.right;

		// Token: 0x04002A58 RID: 10840
		private Vector3 y = Vector3.up;

		// Token: 0x04002A59 RID: 10841
		private Vector3 z = Vector3.forward;

		// Token: 0x04002A5A RID: 10842
		private bool _random = false;

		// Token: 0x04002A5B RID: 10843
		private int _rfactor = 1;
	}
}
