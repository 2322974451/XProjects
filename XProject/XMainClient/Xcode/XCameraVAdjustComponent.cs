using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCameraVAdjustComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XCameraVAdjustComponent.uuID;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._camera_host = (this._host as XCameraEx);
			base.Enabled = (XOperationData.Is3DMode() && !XCameraEx.OperationV);
		}

		public override void OnDetachFromHost()
		{
			this._player = null;
			base.OnDetachFromHost();
		}

		public override void Update(float fDeltaT)
		{
			bool flag = this._player == null;
			if (flag)
			{
				this._player = XSingleton<XEntityMgr>.singleton.Player;
			}
			float num = this._camera_host.Root_R_X_Default + this._camera_host.ProxyIdleXRot;
			float num2 = this._camera_host.DefaultOffset;
			float num3 = this._camera_host.Root_R_X + this._camera_host.ProxyIdleXRot;
			num3 = (float)((int)num3 % 360) + (num3 - (float)((int)num3));
			XEntity xentity = (this._player.TargetLocated == null) ? null : this._player.TargetLocated.Target;
			bool flag2 = xentity != null;
			if (flag2)
			{
				Vector3 vector = this._player.EngineObject.Position - this._camera_host.CameraTrans.position;
				vector.y = 0f;
				Vector3 vector2 = xentity.EngineObject.Position - this._player.EngineObject.Position;
				vector2.y = 0f;
				bool flag3 = Vector3.Angle(vector, vector2) > 120f;
				if (!flag3)
				{
					Vector3 position = xentity.EngineObject.Position;
					position.y += xentity.Height + 0.2f;
					Vector3 vector3 = position - this._camera_host.Position;
					Vector3 vector4 = Vector3.ProjectOnPlane(vector3, Vector3.up);
					float num4 = Vector3.Angle(vector4, vector3);
					bool flag4 = vector3.y < 0f;
					if (flag4)
					{
						num4 = -num4;
					}
					float num5 = this._camera_host.UnityCamera.fieldOfView * 0.5f;
					float num6 = num5 - num3;
					bool flag5 = num4 > num6;
					if (flag5)
					{
						num = 0f;
						num2 = 7f;
					}
					else
					{
						num = ((num6 - num4 > 1f) ? num : num3);
						num2 = ((num6 - num4 > 1f) ? this._camera_host.DefaultOffset : this._camera_host.TargetOffset);
					}
				}
			}
			float num7 = (num - num3) * Mathf.Min(1f, fDeltaT * 0.1f);
			bool flag6 = Mathf.Abs(num7) > XCommon.XEps;
			if (flag6)
			{
				this._camera_host.XRotateExBarely(num7);
			}
			bool flag7 = Mathf.Abs(num2 - this._camera_host.TargetOffset) > XCommon.XEps;
			if (flag7)
			{
				this._camera_host.TargetOffset += (num2 - this._camera_host.TargetOffset) * Mathf.Min(1f, fDeltaT * 2f);
			}
			this._target = xentity;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Camera_Vertical_Adjustment");

		private XCameraEx _camera_host = null;

		private XEntity _target = null;

		private XPlayer _player = null;
	}
}
