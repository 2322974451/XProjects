using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008B1 RID: 2225
	internal class XCameraIntellectiveFollow : XComponent
	{
		// Token: 0x17002A37 RID: 10807
		// (get) Token: 0x06008678 RID: 34424 RVA: 0x0010FC10 File Offset: 0x0010DE10
		public override uint ID
		{
			get
			{
				return XCameraIntellectiveFollow.uuID;
			}
		}

		// Token: 0x17002A38 RID: 10808
		// (get) Token: 0x06008679 RID: 34425 RVA: 0x0010FC28 File Offset: 0x0010DE28
		public float TailSpeed
		{
			get
			{
				return (float)XSingleton<XOperationData>.singleton.TailCameraSpeed;
			}
		}

		// Token: 0x0600867A RID: 34426 RVA: 0x0010FC45 File Offset: 0x0010DE45
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._camera_host = (this._host as XCameraEx);
		}

		// Token: 0x0600867B RID: 34427 RVA: 0x0010FC61 File Offset: 0x0010DE61
		public override void OnDetachFromHost()
		{
			this._camera_host = null;
			base.OnDetachFromHost();
		}

		// Token: 0x0600867C RID: 34428 RVA: 0x0010FC74 File Offset: 0x0010DE74
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

		// Token: 0x0600867D RID: 34429 RVA: 0x0010FD00 File Offset: 0x0010DF00
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

		// Token: 0x0600867E RID: 34430 RVA: 0x00110194 File Offset: 0x0010E394
		private bool CalcReversion()
		{
			XEntity xentity = (XSingleton<XEntityMgr>.singleton.Player.TargetLocated == null) ? null : XSingleton<XEntityMgr>.singleton.Player.TargetLocated.Target;
			return XEntity.ValideEntity(xentity) && !xentity.IsPuppet && XSingleton<XScene>.singleton.GameCamera.IsVisibleFromCamera(xentity, true);
		}

		// Token: 0x04002A0C RID: 10764
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Camera_IntellectiveFollow_Component");

		// Token: 0x04002A0D RID: 10765
		private XCameraEx _camera_host = null;

		// Token: 0x04002A0E RID: 10766
		private float _move_follow_speed_basic = 0f;

		// Token: 0x04002A0F RID: 10767
		private float _move_follow_speed_target = 0f;

		// Token: 0x04002A10 RID: 10768
		private float _move_follow_speed = 0f;

		// Token: 0x04002A11 RID: 10769
		private bool _tail_to_back = false;

		// Token: 0x04002A12 RID: 10770
		private float _tail_back = 0f;

		// Token: 0x04002A13 RID: 10771
		private bool _reverse = false;
	}
}
