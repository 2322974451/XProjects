using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XCameraEx : XObject
	{

		public XCameraSoloComponent Solo
		{
			get
			{
				return this._solo;
			}
		}

		public XCameraMotionComponent Motion
		{
			get
			{
				return this._motion;
			}
		}

		public XCameraCollisonComponent Collision
		{
			get
			{
				return this._collision;
			}
		}

		public XCameraIntellectiveFollow Tail
		{
			get
			{
				return this._tail;
			}
		}

		public XCameraCloseUpComponent CloseUp
		{
			get
			{
				return this._closeup;
			}
		}

		public XCameraVAdjustComponent VAdjust
		{
			get
			{
				return this._adjust;
			}
		}

		public XCameraWallComponent Wall
		{
			get
			{
				return this._wall;
			}
		}

		public Camera UnityCamera
		{
			get
			{
				return this._camera;
			}
		}

		public bool IsCloseUp
		{
			get
			{
				bool flag = this._closeup != null;
				return flag && this._closeup.Execute && !this._closeup.Ending;
			}
		}

		public bool IsDuringCloseUp
		{
			get
			{
				bool flag = this._closeup != null;
				return flag && this._closeup.Execute;
			}
		}

		public float Offset
		{
			get
			{
				return this._dis;
			}
			set
			{
				this._dis = value;
			}
		}

		public float TargetOffset
		{
			get
			{
				return this._tdis;
			}
			set
			{
				this._tdis = value;
			}
		}

		public float DefaultOffset
		{
			get
			{
				return this._default_dis;
			}
			set
			{
				this._default_dis = value;
			}
		}

		public float Root_R_X_Default
		{
			get
			{
				return this._idle_root_rotation_x_default;
			}
			set
			{
				this._idle_root_rotation_x_default = value;
			}
		}

		public float Root_R_Y_Default
		{
			get
			{
				return this._idle_root_rotation_y_default;
			}
			set
			{
				this._idle_root_rotation_y_default = value;
			}
		}

		public float Root_R_X_Target
		{
			get
			{
				return this._idle_root_rotation_x_target;
			}
			set
			{
				this._idle_root_rotation_x_target = value;
			}
		}

		public float Root_R_X
		{
			get
			{
				return this._idle_root_rotation_x;
			}
			set
			{
				this._idle_root_rotation_x = value;
			}
		}

		public float Root_R_Y
		{
			get
			{
				return this._idle_root_rotation_y;
			}
			set
			{
				this._idle_root_rotation_y = value;
			}
		}

		public float Root_R_Y_Target
		{
			get
			{
				return this._idle_root_rotation_y_target;
			}
			set
			{
				this._idle_root_rotation_y_target = value;
			}
		}

		public float InitFOV
		{
			get
			{
				return this._field_of_view;
			}
		}

		public XCameraMotionData ActiveMotion
		{
			get
			{
				return this._active_motion;
			}
			set
			{
				this._active_motion = value;
			}
		}

		public Animator Ator
		{
			get
			{
				return this._ator;
			}
		}

		public Transform CameraTrans
		{
			get
			{
				return this._cameraTransform;
			}
		}

		public Vector3 Position
		{
			get
			{
				return this._cameraTransform.position;
			}
		}

		public Quaternion Rotaton
		{
			get
			{
				return this._cameraTransform.rotation;
			}
		}

		public XEntity Target
		{
			get
			{
				return (this._active_target == null || this._active_target.Deprecated) ? null : this._active_target;
			}
			set
			{
				this._active_target = value;
			}
		}

		public bool IsLookAt
		{
			get
			{
				return this._active_motion.LookAt_Target;
			}
		}

		public bool RootReady
		{
			get
			{
				return this._root_pos_inited;
			}
			set
			{
				this._root_pos_inited = value;
			}
		}

		public Vector3 Anchor
		{
			get
			{
				return (this.Target != null) ? (this.Target.MoveObj.Position + this._dummyObject.transform.position) : Vector3.zero;
			}
		}

		public Vector3 ProxyCameraPos
		{
			get
			{
				return this._dummyCamera_pos;
			}
		}

		public Vector3 ProxyCameraRot
		{
			get
			{
				return this._dummyCamera_rot;
			}
		}

		public float ProxyIdleXRot
		{
			get
			{
				return this._idle_root_basic_x;
			}
		}

		public bool PreInstall(GameObject camera, bool bHall = false)
		{
			bool inited = this._inited;
			bool result;
			if (inited)
			{
				result = true;
			}
			else
			{
				this._cameraObject = camera;
				bool flag = null != this._cameraObject;
				if (flag)
				{
					this._init_idle_root_basic_x = false;
					this._camera = this._cameraObject.GetComponent<Camera>();
					this._camera.enabled = true;
					this._cameraTransform = this._cameraObject.transform;
					bool flag2 = this._dummyObject == null;
					if (flag2)
					{
						this._dummyObject = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("Prefabs/DummyCamera", true, false) as GameObject);
						this._dummyObject.name = "Dummy Camera";
					}
					this._dummyCamera = this._dummyObject.transform.GetChild(0);
					this._ator = this._dummyObject.GetComponent<Animator>();
					bool flag3 = this._overrideController == null;
					if (flag3)
					{
						this._overrideController = new AnimatorOverrideController();
					}
					this._overrideController.runtimeAnimatorController = this._ator.runtimeAnimatorController;
					this._ator.runtimeAnimatorController = this._overrideController;
					this._dummyObject.SetActive(true);
					this.FixedRatio();
					this._added_component.Clear();
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		public bool Installed()
		{
			bool inited = this._inited;
			bool result;
			if (inited)
			{
				result = true;
			}
			else
			{
				this._solo = (base.GetXComponent(XCameraSoloComponent.uuID) as XCameraSoloComponent);
				this._motion = (base.GetXComponent(XCameraMotionComponent.uuID) as XCameraMotionComponent);
				this._collision = (base.GetXComponent(XCameraCollisonComponent.uuID) as XCameraCollisonComponent);
				this._tail = (base.GetXComponent(XCameraIntellectiveFollow.uuID) as XCameraIntellectiveFollow);
				this._adjust = (base.GetXComponent(XCameraVAdjustComponent.uuID) as XCameraVAdjustComponent);
				this._wall = (base.GetXComponent(XCameraWallComponent.uuID) as XCameraWallComponent);
				this._closeup = (base.GetXComponent(XCameraCloseUpComponent.uuID) as XCameraCloseUpComponent);
				this.Motion.Attached();
				this._root_pos_inited = false;
				this._dis = (this._tdis = this._default_dis);
				this._inited = true;
				this._field_of_view = this._cameraObject.GetComponent<Camera>().fieldOfView;
				result = true;
			}
			return result;
		}

		public override void Uninitilize()
		{
			bool flag = !this._inited;
			if (!flag)
			{
				XResourceLoaderMgr.SafeDestroy(ref this._dummyObject, false);
				this._active_target = null;
				this.SolidCancel();
				this._camera = null;
				this._cameraTransform = null;
				this._inited = false;
				this._solo = null;
				this._motion = null;
				this._collision = null;
				this._tail = null;
				this._adjust = null;
				this._wall = null;
				this._closeup = null;
				base.Uninitilize();
				this._overrideController = null;
			}
		}

		private void FixedRatio()
		{
			float num = (float)(XSingleton<XGameUI>.singleton.Base_UI_Width + 2) / (float)XSingleton<XGameUI>.singleton.Base_UI_Height;
			float num2 = (float)Screen.width / (float)Screen.height;
			float num3 = num2 / num;
			bool flag = num3 < 1f;
			if (flag)
			{
				Rect rect = this._camera.rect;
				rect.width = 1f;
				rect.height = num3;
				rect.x = 0f;
				rect.y = (1f - num3) / 2f;
				this._camera.rect = rect;
			}
			else
			{
				float num4 = 1f / num3;
				Rect rect2 = this._camera.rect;
				rect2.width = num4;
				rect2.height = 1f;
				rect2.x = (1f - num4) / 2f;
				rect2.y = 0f;
				this._camera.rect = rect2;
			}
		}

		public bool IsVisibleFromCamera(XEntity entity, bool fully)
		{
			Plane[] planes = GeometryUtility.CalculateFrustumPlanes(this._camera);
			return entity.EngineObject.TestVisibleWithFrustum(planes, fully);
		}

		public void Damp()
		{
			this._damp = true;
			this._elapsed = 0f;
		}

		public void AddComponent<T>() where T : Component
		{
			Type typeFromHandle = typeof(T);
			bool flag = !this._added_component.Contains(typeFromHandle);
			if (flag)
			{
				this._camera.gameObject.AddComponent<T>();
				this._added_component.Add(typeFromHandle);
			}
		}

		public void OverrideAnimClip(string motion, AnimationClip clip)
		{
			bool flag = clip != null;
			if (flag)
			{
				bool flag2 = this._overrideController[motion] != clip;
				if (flag2)
				{
					this._overrideController[motion] = clip;
				}
			}
			else
			{
				this._overrideController[motion] = null;
			}
		}

		public void SyncTarget()
		{
			this._q_self_r = ((this.Target == null) ? Quaternion.identity : this.Target.MoveObj.Rotation);
			this._v_self_p = ((this.Target == null) ? Vector3.zero : this.Target.MoveObj.Position);
		}

		public void LookAtTarget()
		{
			bool flag = this.Target != null;
			if (flag)
			{
				this._cameraTransform.LookAt(this.Target.MoveObj.Position + ((this._dummyObject == null) ? Vector3.zero : this._dummyObject.transform.position));
			}
		}

		public void ReCaleRoot(bool OnSolo = false)
		{
			bool flag = this._active_motion.MotionType == CameraMotionType.CameraBased;
			if (flag)
			{
				if (OnSolo)
				{
					this._idle_root_rotation = Quaternion.Euler(this._idle_root_rotation_x, this._idle_root_rotation.eulerAngles.y, 0f);
				}
				else
				{
					this._idle_root_rotation = Quaternion.Euler(this._idle_root_rotation_x, this._idle_root_rotation_y, 0f);
				}
				this._root_pos = this._idle_root_rotation * this._dummyCamera.position;
			}
		}

		public void AdjustRoot()
		{
			this._idle_root_rotation_x = this._idle_root_rotation.eulerAngles.x;
			this._idle_root_rotation_y = this.CameraTrans.rotation.eulerAngles.y;
		}

		public void XRotate(float addation)
		{
			bool flag = this.Target is XPlayer && addation != 0f;
			if (flag)
			{
				this._idle_root_rotation_x += addation;
				float num = this._idle_root_basic_x + this._idle_root_rotation_x;
				bool flag2 = num > XCameraEx.MaxV;
				if (flag2)
				{
					this._idle_root_rotation_x = XCameraEx.MaxV - this._idle_root_basic_x;
				}
				else
				{
					bool flag3 = num < XCameraEx.MinV;
					if (flag3)
					{
						this._idle_root_rotation_x = XCameraEx.MinV - this._idle_root_basic_x;
					}
				}
				this.ReCaleRoot(false);
			}
		}

		public void YRotate(float addation)
		{
			bool flag = this.Target is XPlayer && addation != 0f;
			if (flag)
			{
				this._idle_root_rotation_y += addation;
				this.ReCaleRoot(false);
			}
		}

		public void XRotateEx(float x)
		{
			bool flag = this.Target is XPlayer;
			if (flag)
			{
				this._idle_root_rotation_x = x;
				x = this._idle_root_basic_x + this._idle_root_rotation_x;
				bool flag2 = x > XCameraEx.MaxV;
				if (flag2)
				{
					this._idle_root_rotation_x = XCameraEx.MaxV - this._idle_root_basic_x;
				}
				else
				{
					bool flag3 = x < XCameraEx.MinV;
					if (flag3)
					{
						this._idle_root_rotation_x = XCameraEx.MinV - this._idle_root_basic_x;
					}
				}
				this.ReCaleRoot(false);
			}
		}

		public void YRotateEx(float y)
		{
			bool flag = this.Target is XPlayer;
			if (flag)
			{
				this._idle_root_rotation_y = y;
				this.ReCaleRoot(false);
			}
		}

		public void XRotateExBarely(float addation)
		{
			bool flag = this._active_motion.MotionType == CameraMotionType.CameraBased && (this.Target is XPlayer || this.Target is XEmpty);
			if (flag)
			{
				this._idle_root_rotation_x += addation;
				float num = this._idle_root_basic_x + this._idle_root_rotation_x;
				bool flag2 = num > XCameraEx.MaxV;
				if (flag2)
				{
					this._idle_root_rotation_x = XCameraEx.MaxV - this._idle_root_basic_x;
				}
				else
				{
					bool flag3 = num < XCameraEx.MinV;
					if (flag3)
					{
						this._idle_root_rotation_x = XCameraEx.MinV - this._idle_root_basic_x;
					}
				}
				this._idle_root_rotation = Quaternion.Euler(this._idle_root_rotation_x, this._idle_root_rotation.eulerAngles.y, 0f);
				this._root_pos = this._idle_root_rotation * this._dummyCamera.position;
			}
		}

		public void YRotateExBarely(float y)
		{
			bool flag = this._active_motion.MotionType == CameraMotionType.CameraBased;
			if (flag)
			{
				this._idle_root_rotation = Quaternion.Euler(this._idle_root_rotation.eulerAngles.x, y, 0f);
				this._root_pos = this._idle_root_rotation * this._dummyCamera.position;
			}
		}

		public override void PostUpdate(float fDeltaT)
		{
			bool flag = this.Tail != null && XOperationData.Is3DMode();
			if (flag)
			{
				this.Tail.TailUpdate(fDeltaT);
			}
			bool flag2 = !this._root_pos_inited;
			if (flag2)
			{
				Vector3 vector = Vector3.Cross(this._dummyCamera.forward, this._dummyCamera.up);
				this._dummyCamera_quat = Quaternion.LookRotation(vector, this._dummyCamera.up);
				this._dummyCamera_rot = this._dummyCamera_quat.eulerAngles;
				bool flag3 = !this._init_idle_root_basic_x;
				if (flag3)
				{
					this._idle_root_basic_x = this._dummyCamera_rot.x;
					this._basic_dis = (this._dummyCamera.position - this._dummyObject.transform.position).magnitude;
				}
				bool autoSync_At_Begin = this._active_motion.AutoSync_At_Begin;
				if (autoSync_At_Begin)
				{
					this.SyncTarget();
				}
				CameraMotionType motionType = this._active_motion.MotionType;
				if (motionType != CameraMotionType.AnchorBased)
				{
					if (motionType == CameraMotionType.CameraBased)
					{
						this._idle_root_rotation = ((this.Target is XPlayer) ? Quaternion.Euler(this._idle_root_rotation_x, this._idle_root_rotation_y, 0f) : ((this.Target is XEmpty && !XCameraEx.OperationV) ? Quaternion.Euler(this._idle_root_rotation_x, 0f, 0f) : Quaternion.identity));
					}
				}
				else
				{
					this._idle_root_rotation = Quaternion.identity;
				}
				this._root_pos = this._idle_root_rotation * this._dummyCamera.position;
				this._root_pos_inited = true;
				this._init_idle_root_basic_x = true;
			}
			this.InnerUpdateEx();
			base.PostUpdate(fDeltaT);
			bool flag4 = this._closeup != null;
			if (flag4)
			{
				this._closeup.CloseUpdate(fDeltaT);
			}
			bool flag5 = this._motion != null;
			if (flag5)
			{
				this._motion.MotionUpdate(fDeltaT);
			}
		}

		public bool BackToPlayer()
		{
			bool operationH = XCameraEx.OperationH;
			bool result;
			if (operationH)
			{
				XSingleton<XScene>.singleton.GameCamera.Root_R_Y_Default = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Rotation.eulerAngles.y;
				XSingleton<XScene>.singleton.GameCamera.Root_R_Y = XSingleton<XScene>.singleton.GameCamera.Root_R_Y_Default;
				bool flag = XSingleton<XScene>.singleton.GameCamera.Wall != null;
				if (flag)
				{
					XSingleton<XScene>.singleton.GameCamera.Wall.TargetY = XSingleton<XScene>.singleton.GameCamera.Root_R_Y_Default;
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public void FovBack()
		{
			bool flag = XSingleton<XCutScene>.singleton.IsPlaying && XSingleton<XEntityMgr>.singleton.Boss != null;
			if (flag)
			{
				uint fov = (XSingleton<XEntityMgr>.singleton.Boss.Attributes as XOthersAttributes).Fov;
				bool flag2 = fov > 0U;
				if (flag2)
				{
					float num = Mathf.Tan(0.017453292f * this._field_of_view * 0.5f) * this.TargetOffset;
					this.TargetOffset = num / Mathf.Tan(0.017453292f * fov * 0.5f);
					this.DefaultOffset = this.TargetOffset;
					this._field_of_view = fov;
				}
			}
			this._cameraObject.GetComponent<Camera>().fieldOfView = this._field_of_view;
		}

		public void SolidBlack()
		{
			this._camera.clearFlags = (CameraClearFlags)2;
			this._camera.backgroundColor = Color.black;
			this._camera.cullingMask = 7106048;
		}

		public void SolidCancel()
		{
			bool flag = this._camera == null;
			if (!flag)
			{
				this._camera.clearFlags = (CameraClearFlags)1;
				XQualitySetting.XSetting currentQualitySetting = XQualitySetting.GetCurrentQualitySetting();
				this._camera.cullingMask = -1;
				this._camera.cullingMask &= ~(XQualitySetting._QualityHighLayerOffset | XQualitySetting._QualityNormalLayerOffset);
				this._camera.cullingMask |= currentQualitySetting._CullMask;
				this._camera.cullingMask &= ~XQualitySetting._InvisiblityLayerOffset;
				this._camera.cullingMask &= ~XQualitySetting._UILayerOffset;
			}
		}

		public void TrySolo()
		{
			bool flag = this._solo == null || XSingleton<XEntityMgr>.singleton.Player == null;
			if (!flag)
			{
				bool flag2 = !XEntity.ValideEntity(this._solo.Target);
				if (flag2)
				{
					this._solo.Stop();
				}
				bool flag3 = this._solo.SoloState == XCameraSoloComponent.XCameraSoloState.Stop;
				if (flag3)
				{
					XEntity xentity = null;
					List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XScene>.singleton.bSpectator ? XSingleton<XEntityMgr>.singleton.Player.WatchTo : XSingleton<XEntityMgr>.singleton.Player);
					for (int i = 0; i < opponent.Count; i++)
					{
						bool flag4 = XSingleton<XSceneMgr>.singleton.Is1V1Scene();
						if (flag4)
						{
							bool flag5 = opponent[i].IsRole && XEntity.ValideEntity(opponent[i]);
							if (flag5)
							{
								xentity = opponent[i];
								break;
							}
						}
						else
						{
							bool soloShow = opponent[i].Attributes.SoloShow;
							if (soloShow)
							{
								xentity = opponent[i];
								break;
							}
						}
					}
					bool flag6 = xentity != null;
					if (flag6)
					{
						XCameraSoloEventArgs @event = XEventPool<XCameraSoloEventArgs>.GetEvent();
						@event.Target = xentity;
						@event.Firer = this;
						XSingleton<XEventMgr>.singleton.FireEvent(@event);
					}
				}
			}
		}

		public void SetSightType()
		{
			float num = XSingleton<XOperationData>.singleton.CameraAngle;
			float cameraDistance = XSingleton<XOperationData>.singleton.CameraDistance;
			XCameraEx.OperationH = XSingleton<XOperationData>.singleton.AllowHorizontal;
			XCameraEx.OperationV = XSingleton<XOperationData>.singleton.AllowVertical;
			XCameraEx.MaxV = XSingleton<XOperationData>.singleton.MaxVertical;
			XCameraEx.MinV = XSingleton<XOperationData>.singleton.MinVertical;
			bool flag = XCameraEx.MaxV < XCameraEx.MinV;
			if (flag)
			{
				XCameraEx.MaxV = XCameraEx.MinV;
			}
			bool flag2 = num > XCameraEx.MaxV;
			if (flag2)
			{
				num = XCameraEx.MaxV;
			}
			bool flag3 = num < XCameraEx.MinV;
			if (flag3)
			{
				num = XCameraEx.MinV;
			}
			bool flag4 = false;
			bool flag5 = !XCameraEx.OperationH || XSingleton<XOperationData>.singleton.OffSolo;
			if (flag5)
			{
				bool flag6 = this._solo != null && this._solo.SoloState != XCameraSoloComponent.XCameraSoloState.Stop;
				if (flag6)
				{
					flag4 = true;
					this._solo.Stop();
					this.Target = XSingleton<XEntityMgr>.singleton.Player;
				}
			}
			bool flag7 = this._adjust != null;
			if (flag7)
			{
				this._adjust.Enabled = (XOperationData.Is3DMode() && !XCameraEx.OperationV);
			}
			bool flag8 = this._wall != null && !XCameraEx.OperationH;
			if (flag8)
			{
				this.YRotate(this._wall.TargetY - this.Root_R_Y);
			}
			this.Root_R_X_Default = num - this._idle_root_basic_x;
			this.Root_R_X_Target = this.Root_R_X_Default;
			this.DefaultOffset = cameraDistance;
			this.TargetOffset = cameraDistance;
			this.Root_R_X = this.Root_R_X_Target;
			bool flag9 = XCameraEx.OperationH && !XSingleton<XOperationData>.singleton.OffSolo;
			if (flag9)
			{
				this.TrySolo();
			}
			bool flag10 = !flag4;
			if (flag10)
			{
				this.ReCaleRoot(this._solo != null && this._solo.SoloState == XCameraSoloComponent.XCameraSoloState.Executing);
			}
		}

		private void InnerPosition()
		{
			Vector3 vector = this._dummyCamera.position;
			bool flag = this._active_motion.MotionType == CameraMotionType.CameraBased && (this.Target is XPlayer || this.Target is XEmpty);
			if (flag)
			{
				Vector3 vector2 = this._dummyCamera.position - this._dummyObject.transform.position;
				float num = vector2.magnitude;
				vector2.Normalize();
				bool flag2 = vector2.z > 0f;
				if (flag2)
				{
					num = -num;
					vector2 = -vector2;
				}
				float num2 = num - this._basic_dis;
				float num3 = this.TargetOffset + num2;
				bool flag3 = num3 <= 0f;
				if (flag3)
				{
					num3 = 0.1f;
				}
				vector = this._dummyObject.transform.position + num3 * vector2;
			}
			this._dummyCamera_pos = this._idle_root_rotation * (vector - this._dummyObject.transform.position) + this._dummyObject.transform.position;
			bool damp = this._damp;
			if (damp)
			{
				this._damp_dir = this._dummyCamera_pos - this._last_dummyCamera_pos;
				bool flag4 = this._elapsed == 0f;
				if (flag4)
				{
					this._damp_delta = this._damp_dir.magnitude;
				}
				this._damp_dir.Normalize();
				bool flag5 = this._elapsed > this._damp_factor;
				if (flag5)
				{
					this._elapsed = this._damp_factor;
					this._damp = false;
				}
				this._dummyCamera_pos -= this._damp_dir * (this._damp_delta * ((this._damp_factor - this._elapsed) / this._damp_factor));
				this._elapsed += Time.deltaTime;
			}
			this._last_dummyCamera_pos = this._dummyCamera_pos;
		}

		private void InnerUpdateEx()
		{
			this.InnerPosition();
			Quaternion quaternion = Quaternion.identity;
			bool flag = this.Target != null;
			if (flag)
			{
				quaternion = this.Target.MoveObj.Rotation;
			}
			bool flag2 = this._active_motion.MotionType == CameraMotionType.AnchorBased && this.Target != null;
			if (flag2)
			{
				this._q_self_r = quaternion;
			}
			Quaternion quaternion2 = (this.Target == null) ? Quaternion.identity : quaternion;
			Vector3 vector = (this.Target == null) ? Vector3.zero : this.Target.MoveObj.Position;
			Vector3 vector2 = Vector3.Cross(this._dummyCamera.forward, this._dummyCamera.up);
			this._dummyCamera_quat = Quaternion.LookRotation(vector2, this._dummyCamera.up);
			this._dummyCamera_rot = this._dummyCamera_quat.eulerAngles;
			Vector3 vector3 = this._dummyCamera_pos - this._root_pos;
			Vector3 vector4 = (this._active_motion.AutoSync_At_Begin ? this._q_self_r : Quaternion.identity) * this._root_pos;
			vector3 = (this._active_motion.AutoSync_At_Begin ? this._q_self_r : Quaternion.identity) * vector3;
			bool flag3 = !this._active_motion.LookAt_Target;
			if (flag3)
			{
				this._cameraTransform.rotation = (this._active_motion.AutoSync_At_Begin ? this._q_self_r : Quaternion.identity) * this._idle_root_rotation * this._dummyCamera_quat;
			}
			vector4 += (this._active_motion.Follow_Position ? vector : (this._active_motion.AutoSync_At_Begin ? this._v_self_p : Vector3.zero));
			CameraMotionSpace coordinate = this._active_motion.Coordinate;
			if (coordinate != CameraMotionSpace.World)
			{
				if (coordinate == CameraMotionSpace.Self)
				{
					vector4 += (this._active_motion.Follow_Position ? Quaternion.identity : quaternion2) * vector3;
				}
			}
			else
			{
				vector4 += vector3;
			}
			this._cameraTransform.position = vector4;
			bool lookAt_Target = this._active_motion.LookAt_Target;
			if (lookAt_Target)
			{
				this.LookAtTarget();
			}
		}

		public void SetCameraLayer(int layer, bool add)
		{
			if (add)
			{
				this._camera.cullingMask |= 1 << layer;
			}
			else
			{
				this._camera.cullingMask &= ~(1 << layer);
			}
		}

		public void SetCameraLayer(int layermask)
		{
			this._camera.cullingMask = layermask;
		}

		public int GetCameraLayer()
		{
			return this._camera.cullingMask;
		}

		public void SetSolidBlack(bool enabled)
		{
			if (enabled)
			{
				this._camera.clearFlags = (CameraClearFlags)2;
				this._camera.backgroundColor = Color.black;
			}
			else
			{
				this._camera.clearFlags = (CameraClearFlags)1;
			}
		}

		public void SetReplaceCameraShader(Shader shader)
		{
			bool flag = shader != null && this._camera != null;
			if (flag)
			{
				this._camera.SetReplacementShader(shader, "RenderType");
			}
		}

		public static bool OperationV = true;

		public static bool OperationH = true;

		public static float MaxV = 80f;

		public static float MinV = -80f;

		private float _dis = 0f;

		private float _tdis = 0f;

		private float _basic_dis = 4.2f;

		private float _default_dis = 4.2f;

		private GameObject _cameraObject = null;

		private GameObject _dummyObject = null;

		private Transform _dummyCamera = null;

		private Transform _cameraTransform = null;

		private Animator _ator = null;

		private AnimatorOverrideController _overrideController;

		private List<Type> _added_component = new List<Type>();

		private Camera _camera = null;

		private bool _inited = false;

		private float _elapsed = 0f;

		private bool _damp = false;

		private float _damp_delta = 0f;

		private Vector3 _damp_dir = Vector3.zero;

		private bool _root_pos_inited = false;

		private Vector3 _root_pos = Vector3.zero;

		private Quaternion _idle_root_rotation = Quaternion.identity;

		private float _idle_root_basic_x = 0f;

		private bool _init_idle_root_basic_x = false;

		private float _idle_root_rotation_x_default = 0f;

		private float _idle_root_rotation_x_target = 0f;

		private float _idle_root_rotation_x = 0f;

		private float _idle_root_rotation_y = 0f;

		private float _idle_root_rotation_y_default = 0f;

		private float _idle_root_rotation_y_target = 0f;

		private Vector3 _last_dummyCamera_pos = Vector3.zero;

		private Vector3 _dummyCamera_pos = Vector3.zero;

		private Vector3 _dummyCamera_rot = Vector3.forward;

		private Quaternion _dummyCamera_quat = Quaternion.identity;

		private Vector3 _v_self_p = Vector3.zero;

		private Quaternion _q_self_r = Quaternion.identity;

		private readonly float _damp_factor = 0.3f;

		private XCameraMotionData _active_motion = new XCameraMotionData();

		private XEntity _active_target = null;

		private float _field_of_view = 45f;

		private XCameraSoloComponent _solo = null;

		private XCameraMotionComponent _motion = null;

		private XCameraCollisonComponent _collision = null;

		private XCameraIntellectiveFollow _tail = null;

		private XCameraVAdjustComponent _adjust = null;

		private XCameraWallComponent _wall = null;

		private XCameraCloseUpComponent _closeup = null;

		public enum XStatus
		{

			None,

			Idle,

			Solo,

			Effect
		}
	}
}
