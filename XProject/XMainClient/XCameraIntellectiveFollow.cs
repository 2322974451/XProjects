using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCameraIntellectiveFollow : XComponent
	{

		public override uint ID
		{
			get
			{
				return XCameraIntellectiveFollow.uuID;
			}
		}

		public float TailSpeed
		{
			get
			{
				return (float)XSingleton<XOperationData>.singleton.TailCameraSpeed;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._camera_host = (this._host as XCameraEx);
		}

		public override void OnDetachFromHost()
		{
			this._camera_host = null;
			base.OnDetachFromHost();
		}

		public void TailToBack()
		{
			this._tail_to_back = true;
			this._tail_back = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Rotation.eulerAngles.y;
			float root_R_Y = XSingleton<XScene>.singleton.GameCamera.Root_R_Y;
			while (Mathf.Abs(root_R_Y - this._tail_back) > 180f)
			{
				this._tail_back += (float)((root_R_Y > this._tail_back) ? 360 : -360);
			}
		}

		public void TailUpdate(float fDeltaT)
		{
			bool flag = (this._camera_host.Solo != null && this._camera_host.Solo.SoloState != XCameraSoloComponent.XCameraSoloState.Stop) || XSingleton<XCutScene>.singleton.IsPlaying;
			if (!flag)
			{
				float move_follow_speed_target = this._move_follow_speed_target;
				bool tail_to_back = this._tail_to_back;
				if (tail_to_back)
				{
					float num = (this._tail_back - XSingleton<XScene>.singleton.GameCamera.Root_R_Y) * Mathf.Min(1f, fDeltaT * 10f);
					this._camera_host.YRotate(num);
					bool flag2 = Mathf.Abs(num) < 0.1f;
					if (flag2)
					{
						this._tail_to_back = false;
					}
				}
				else
				{
					bool flag3 = XSingleton<XEntityMgr>.singleton.Player.Skill.IsCasting();
					if (flag3)
					{
						XSkill currentSkill = XSingleton<XEntityMgr>.singleton.Player.Skill.CurrentSkill;
						Vector3 vector = XSingleton<XEntityMgr>.singleton.Player.Rotate.GetMeaningfulFaceVector3();
						Vector3 vector2 = XSingleton<XCommon>.singleton.Horizontal(this._camera_host.CameraTrans.forward);
						XEntity target = currentSkill.Target;
						bool flag4 = target != null;
						if (flag4)
						{
							vector = target.EngineObject.Position - XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position;
							vector.y = 0f;
							vector.Normalize();
							bool flag5 = vector.sqrMagnitude == 0f;
							if (flag5)
							{
								return;
							}
						}
						bool flag6 = Vector3.Angle(vector, vector2) < (float)(XSingleton<XOperationData>.singleton.CameraAdjustScope >> 1) || XSingleton<XGlobalConfig>.singleton.CameraAdjustScopeExceptSkills.Contains(currentSkill.MainCore.ID);
						if (flag6)
						{
							this._move_follow_speed_basic = (float)XSingleton<XOperationData>.singleton.TailCameraSpeed * XSingleton<XEntityMgr>.singleton.Player.Skill.CurrentSkill.MainCore.Soul.CameraTurnBack * fDeltaT;
							float num2 = Mathf.Sin(0.017453292f * Vector3.Angle(vector, vector2) * 0.5f);
							this._move_follow_speed_target = this._move_follow_speed_basic * num2;
							bool flag7 = XSingleton<XCommon>.singleton.Clockwise(vector, vector2);
							if (flag7)
							{
								this._move_follow_speed_target *= -1f;
							}
							bool flag8 = move_follow_speed_target * this._move_follow_speed_target < 0f;
							if (flag8)
							{
								this._move_follow_speed = 0f;
							}
							this._move_follow_speed += (this._move_follow_speed_target - this._move_follow_speed) * Mathf.Min(1f, fDeltaT * 10f);
							this._camera_host.YRotate(this._move_follow_speed);
						}
					}
					else
					{
						this._move_follow_speed_basic = (float)XSingleton<XOperationData>.singleton.TailCameraSpeed * fDeltaT;
						bool flag9 = XSingleton<XEntityMgr>.singleton.Player.Machine.Current == XStateDefine.XState_Move && XSingleton<XEntityMgr>.singleton.Player.Machine.State.Speed > 0f;
						if (flag9)
						{
							Vector3 meaningfulFaceVector = XSingleton<XEntityMgr>.singleton.Player.Rotate.GetMeaningfulFaceVector3();
							Vector3 vector3 = XSingleton<XCommon>.singleton.Horizontal(this._camera_host.CameraTrans.forward);
							float num3 = Vector3.Angle(meaningfulFaceVector, vector3);
							float num4 = Mathf.Sin(0.017453292f * num3);
							this._move_follow_speed_target = this._move_follow_speed_basic * num4;
							bool flag10 = Math.Abs(this._move_follow_speed_target) > XCommon.XEps;
							if (flag10)
							{
								bool reverse = this._reverse;
								if (reverse)
								{
									bool flag11 = !XSingleton<XCommon>.singleton.Clockwise(meaningfulFaceVector, vector3);
									if (flag11)
									{
										this._move_follow_speed_target *= -1f;
									}
								}
								else
								{
									bool flag12 = XSingleton<XCommon>.singleton.Clockwise(meaningfulFaceVector, vector3);
									if (flag12)
									{
										this._move_follow_speed_target *= -1f;
									}
								}
								bool flag13 = move_follow_speed_target * this._move_follow_speed_target < 0f;
								if (flag13)
								{
									this._move_follow_speed = -this._move_follow_speed;
								}
							}
							else
							{
								this._move_follow_speed_target = 0f;
							}
							this._move_follow_speed += (this._move_follow_speed_target - this._move_follow_speed) * Mathf.Min(1f, fDeltaT * 5f);
							this._camera_host.YRotate(this._move_follow_speed);
						}
						else
						{
							this._move_follow_speed += (0f - this._move_follow_speed) * Mathf.Min(1f, fDeltaT * 15f);
							this._camera_host.YRotate(this._move_follow_speed);
							this._reverse = false;
						}
					}
				}
			}
		}

		private bool CalcReversion()
		{
			XEntity xentity = (XSingleton<XEntityMgr>.singleton.Player.TargetLocated == null) ? null : XSingleton<XEntityMgr>.singleton.Player.TargetLocated.Target;
			return XEntity.ValideEntity(xentity) && !xentity.IsPuppet && XSingleton<XScene>.singleton.GameCamera.IsVisibleFromCamera(xentity, true);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Camera_IntellectiveFollow_Component");

		private XCameraEx _camera_host = null;

		private float _move_follow_speed_basic = 0f;

		private float _move_follow_speed_target = 0f;

		private float _move_follow_speed = 0f;

		private bool _tail_to_back = false;

		private float _tail_back = 0f;

		private bool _reverse = false;
	}
}
