using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008B3 RID: 2227
	internal sealed class XCameraEx : XObject
	{
		// Token: 0x17002A3B RID: 10811
		// (get) Token: 0x0600868C RID: 34444 RVA: 0x00110754 File Offset: 0x0010E954
		public XCameraSoloComponent Solo
		{
			get
			{
				return this._solo;
			}
		}

		// Token: 0x17002A3C RID: 10812
		// (get) Token: 0x0600868D RID: 34445 RVA: 0x0011076C File Offset: 0x0010E96C
		public XCameraMotionComponent Motion
		{
			get
			{
				return this._motion;
			}
		}

		// Token: 0x17002A3D RID: 10813
		// (get) Token: 0x0600868E RID: 34446 RVA: 0x00110784 File Offset: 0x0010E984
		public XCameraCollisonComponent Collision
		{
			get
			{
				return this._collision;
			}
		}

		// Token: 0x17002A3E RID: 10814
		// (get) Token: 0x0600868F RID: 34447 RVA: 0x0011079C File Offset: 0x0010E99C
		public XCameraIntellectiveFollow Tail
		{
			get
			{
				return this._tail;
			}
		}

		// Token: 0x17002A3F RID: 10815
		// (get) Token: 0x06008690 RID: 34448 RVA: 0x001107B4 File Offset: 0x0010E9B4
		public XCameraCloseUpComponent CloseUp
		{
			get
			{
				return this._closeup;
			}
		}

		// Token: 0x17002A40 RID: 10816
		// (get) Token: 0x06008691 RID: 34449 RVA: 0x001107CC File Offset: 0x0010E9CC
		public XCameraVAdjustComponent VAdjust
		{
			get
			{
				return this._adjust;
			}
		}

		// Token: 0x17002A41 RID: 10817
		// (get) Token: 0x06008692 RID: 34450 RVA: 0x001107E4 File Offset: 0x0010E9E4
		public XCameraWallComponent Wall
		{
			get
			{
				return this._wall;
			}
		}

		// Token: 0x17002A42 RID: 10818
		// (get) Token: 0x06008693 RID: 34451 RVA: 0x001107FC File Offset: 0x0010E9FC
		public Camera UnityCamera
		{
			get
			{
				return this._camera;
			}
		}

		// Token: 0x17002A43 RID: 10819
		// (get) Token: 0x06008694 RID: 34452 RVA: 0x00110814 File Offset: 0x0010EA14
		public bool IsCloseUp
		{
			get
			{
				bool flag = this._closeup != null;
				return flag && this._closeup.Execute && !this._closeup.Ending;
			}
		}

		// Token: 0x17002A44 RID: 10820
		// (get) Token: 0x06008695 RID: 34453 RVA: 0x00110858 File Offset: 0x0010EA58
		public bool IsDuringCloseUp
		{
			get
			{
				bool flag = this._closeup != null;
				return flag && this._closeup.Execute;
			}
		}

		// Token: 0x17002A45 RID: 10821
		// (get) Token: 0x06008696 RID: 34454 RVA: 0x00110888 File Offset: 0x0010EA88
		// (set) Token: 0x06008697 RID: 34455 RVA: 0x001108A0 File Offset: 0x0010EAA0
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

		// Token: 0x17002A46 RID: 10822
		// (get) Token: 0x06008698 RID: 34456 RVA: 0x001108AC File Offset: 0x0010EAAC
		// (set) Token: 0x06008699 RID: 34457 RVA: 0x001108C4 File Offset: 0x0010EAC4
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

		// Token: 0x17002A47 RID: 10823
		// (get) Token: 0x0600869A RID: 34458 RVA: 0x001108D0 File Offset: 0x0010EAD0
		// (set) Token: 0x0600869B RID: 34459 RVA: 0x001108E8 File Offset: 0x0010EAE8
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

		// Token: 0x17002A48 RID: 10824
		// (get) Token: 0x0600869C RID: 34460 RVA: 0x001108F4 File Offset: 0x0010EAF4
		// (set) Token: 0x0600869D RID: 34461 RVA: 0x0011090C File Offset: 0x0010EB0C
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

		// Token: 0x17002A49 RID: 10825
		// (get) Token: 0x0600869E RID: 34462 RVA: 0x00110918 File Offset: 0x0010EB18
		// (set) Token: 0x0600869F RID: 34463 RVA: 0x00110930 File Offset: 0x0010EB30
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

		// Token: 0x17002A4A RID: 10826
		// (get) Token: 0x060086A0 RID: 34464 RVA: 0x0011093C File Offset: 0x0010EB3C
		// (set) Token: 0x060086A1 RID: 34465 RVA: 0x00110954 File Offset: 0x0010EB54
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

		// Token: 0x17002A4B RID: 10827
		// (get) Token: 0x060086A2 RID: 34466 RVA: 0x00110960 File Offset: 0x0010EB60
		// (set) Token: 0x060086A3 RID: 34467 RVA: 0x00110978 File Offset: 0x0010EB78
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

		// Token: 0x17002A4C RID: 10828
		// (get) Token: 0x060086A4 RID: 34468 RVA: 0x00110984 File Offset: 0x0010EB84
		// (set) Token: 0x060086A5 RID: 34469 RVA: 0x0011099C File Offset: 0x0010EB9C
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

		// Token: 0x17002A4D RID: 10829
		// (get) Token: 0x060086A6 RID: 34470 RVA: 0x001109A8 File Offset: 0x0010EBA8
		// (set) Token: 0x060086A7 RID: 34471 RVA: 0x001109C0 File Offset: 0x0010EBC0
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

		// Token: 0x17002A4E RID: 10830
		// (get) Token: 0x060086A8 RID: 34472 RVA: 0x001109CC File Offset: 0x0010EBCC
		public float InitFOV
		{
			get
			{
				return this._field_of_view;
			}
		}

		// Token: 0x17002A4F RID: 10831
		// (get) Token: 0x060086A9 RID: 34473 RVA: 0x001109E4 File Offset: 0x0010EBE4
		// (set) Token: 0x060086AA RID: 34474 RVA: 0x001109FC File Offset: 0x0010EBFC
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

		// Token: 0x17002A50 RID: 10832
		// (get) Token: 0x060086AB RID: 34475 RVA: 0x00110A08 File Offset: 0x0010EC08
		public Animator Ator
		{
			get
			{
				return this._ator;
			}
		}

		// Token: 0x17002A51 RID: 10833
		// (get) Token: 0x060086AC RID: 34476 RVA: 0x00110A20 File Offset: 0x0010EC20
		public Transform CameraTrans
		{
			get
			{
				return this._cameraTransform;
			}
		}

		// Token: 0x17002A52 RID: 10834
		// (get) Token: 0x060086AD RID: 34477 RVA: 0x00110A38 File Offset: 0x0010EC38
		public Vector3 Position
		{
			get
			{
				return this._cameraTransform.position;
			}
		}

		// Token: 0x17002A53 RID: 10835
		// (get) Token: 0x060086AE RID: 34478 RVA: 0x00110A58 File Offset: 0x0010EC58
		public Quaternion Rotaton
		{
			get
			{
				return this._cameraTransform.rotation;
			}
		}

		// Token: 0x17002A54 RID: 10836
		// (get) Token: 0x060086AF RID: 34479 RVA: 0x00110A78 File Offset: 0x0010EC78
		// (set) Token: 0x060086B0 RID: 34480 RVA: 0x00110AA8 File Offset: 0x0010ECA8
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

		// Token: 0x17002A55 RID: 10837
		// (get) Token: 0x060086B1 RID: 34481 RVA: 0x00110AB4 File Offset: 0x0010ECB4
		public bool IsLookAt
		{
			get
			{
				return this._active_motion.LookAt_Target;
			}
		}

		// Token: 0x17002A56 RID: 10838
		// (get) Token: 0x060086B2 RID: 34482 RVA: 0x00110AD4 File Offset: 0x0010ECD4
		// (set) Token: 0x060086B3 RID: 34483 RVA: 0x00110AEC File Offset: 0x0010ECEC
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

		// Token: 0x17002A57 RID: 10839
		// (get) Token: 0x060086B4 RID: 34484 RVA: 0x00110AF8 File Offset: 0x0010ECF8
		public Vector3 Anchor
		{
			get
			{
				return (this.Target != null) ? (this.Target.MoveObj.Position + this._dummyObject.transform.position) : Vector3.zero;
			}
		}

		// Token: 0x17002A58 RID: 10840
		// (get) Token: 0x060086B5 RID: 34485 RVA: 0x00110B40 File Offset: 0x0010ED40
		public Vector3 ProxyCameraPos
		{
			get
			{
				return this._dummyCamera_pos;
			}
		}

		// Token: 0x17002A59 RID: 10841
		// (get) Token: 0x060086B6 RID: 34486 RVA: 0x00110B58 File Offset: 0x0010ED58
		public Vector3 ProxyCameraRot
		{
			get
			{
				return this._dummyCamera_rot;
			}
		}

		// Token: 0x17002A5A RID: 10842
		// (get) Token: 0x060086B7 RID: 34487 RVA: 0x00110B70 File Offset: 0x0010ED70
		public float ProxyIdleXRot
		{
			get
			{
				return this._idle_root_basic_x;
			}
		}

		// Token: 0x060086B8 RID: 34488 RVA: 0x00110B88 File Offset: 0x0010ED88
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

		// Token: 0x060086B9 RID: 34489 RVA: 0x00110CD0 File Offset: 0x0010EED0
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

		// Token: 0x060086BA RID: 34490 RVA: 0x00110DD4 File Offset: 0x0010EFD4
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

		// Token: 0x060086BB RID: 34491 RVA: 0x00110E60 File Offset: 0x0010F060
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

		// Token: 0x060086BC RID: 34492 RVA: 0x00110F60 File Offset: 0x0010F160
		public bool IsVisibleFromCamera(XEntity entity, bool fully)
		{
			Plane[] planes = GeometryUtility.CalculateFrustumPlanes(this._camera);
			return entity.EngineObject.TestVisibleWithFrustum(planes, fully);
		}

		// Token: 0x060086BD RID: 34493 RVA: 0x00110F8B File Offset: 0x0010F18B
		public void Damp()
		{
			this._damp = true;
			this._elapsed = 0f;
		}

		// Token: 0x060086BE RID: 34494 RVA: 0x00110FA0 File Offset: 0x0010F1A0
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

		// Token: 0x060086BF RID: 34495 RVA: 0x00110FEC File Offset: 0x0010F1EC
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

		// Token: 0x060086C0 RID: 34496 RVA: 0x00111040 File Offset: 0x0010F240
		public void SyncTarget()
		{
			this._q_self_r = ((this.Target == null) ? Quaternion.identity : this.Target.MoveObj.Rotation);
			this._v_self_p = ((this.Target == null) ? Vector3.zero : this.Target.MoveObj.Position);
		}

		// Token: 0x060086C1 RID: 34497 RVA: 0x00111098 File Offset: 0x0010F298
		public void LookAtTarget()
		{
			bool flag = this.Target != null;
			if (flag)
			{
				this._cameraTransform.LookAt(this.Target.MoveObj.Position + ((this._dummyObject == null) ? Vector3.zero : this._dummyObject.transform.position));
			}
		}

		// Token: 0x060086C2 RID: 34498 RVA: 0x001110FC File Offset: 0x0010F2FC
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

		// Token: 0x060086C3 RID: 34499 RVA: 0x00111188 File Offset: 0x0010F388
		public void AdjustRoot()
		{
			this._idle_root_rotation_x = this._idle_root_rotation.eulerAngles.x;
			this._idle_root_rotation_y = this.CameraTrans.rotation.eulerAngles.y;
		}

		// Token: 0x060086C4 RID: 34500 RVA: 0x001111CC File Offset: 0x0010F3CC
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

		// Token: 0x060086C5 RID: 34501 RVA: 0x00111260 File Offset: 0x0010F460
		public void YRotate(float addation)
		{
			bool flag = this.Target is XPlayer && addation != 0f;
			if (flag)
			{
				this._idle_root_rotation_y += addation;
				this.ReCaleRoot(false);
			}
		}

		// Token: 0x060086C6 RID: 34502 RVA: 0x001112A8 File Offset: 0x0010F4A8
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

		// Token: 0x060086C7 RID: 34503 RVA: 0x00111328 File Offset: 0x0010F528
		public void YRotateEx(float y)
		{
			bool flag = this.Target is XPlayer;
			if (flag)
			{
				this._idle_root_rotation_y = y;
				this.ReCaleRoot(false);
			}
		}

		// Token: 0x060086C8 RID: 34504 RVA: 0x0011135C File Offset: 0x0010F55C
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

		// Token: 0x060086C9 RID: 34505 RVA: 0x00111440 File Offset: 0x0010F640
		public void YRotateExBarely(float y)
		{
			bool flag = this._active_motion.MotionType == CameraMotionType.CameraBased;
			if (flag)
			{
				this._idle_root_rotation = Quaternion.Euler(this._idle_root_rotation.eulerAngles.x, y, 0f);
				this._root_pos = this._idle_root_rotation * this._dummyCamera.position;
			}
		}

		// Token: 0x060086CA RID: 34506 RVA: 0x001114A0 File Offset: 0x0010F6A0
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

		// Token: 0x060086CB RID: 34507 RVA: 0x00111684 File Offset: 0x0010F884
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

		// Token: 0x060086CC RID: 34508 RVA: 0x00111734 File Offset: 0x0010F934
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

		// Token: 0x060086CD RID: 34509 RVA: 0x001117F1 File Offset: 0x0010F9F1
		public void SolidBlack()
		{
			this._camera.clearFlags = (CameraClearFlags)2;
			this._camera.backgroundColor = Color.black;
			this._camera.cullingMask = 7106048;
		}

		// Token: 0x060086CE RID: 34510 RVA: 0x00111824 File Offset: 0x0010FA24
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

		// Token: 0x060086CF RID: 34511 RVA: 0x001118D4 File Offset: 0x0010FAD4
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

		// Token: 0x060086D0 RID: 34512 RVA: 0x00111A34 File Offset: 0x0010FC34
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

		// Token: 0x060086D1 RID: 34513 RVA: 0x00111C20 File Offset: 0x0010FE20
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

		// Token: 0x060086D2 RID: 34514 RVA: 0x00111E20 File Offset: 0x00110020
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

		// Token: 0x060086D3 RID: 34515 RVA: 0x00112050 File Offset: 0x00110250
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

		// Token: 0x060086D4 RID: 34516 RVA: 0x0011209C File Offset: 0x0011029C
		public void SetCameraLayer(int layermask)
		{
			this._camera.cullingMask = layermask;
		}

		// Token: 0x060086D5 RID: 34517 RVA: 0x001120AC File Offset: 0x001102AC
		public int GetCameraLayer()
		{
			return this._camera.cullingMask;
		}

		// Token: 0x060086D6 RID: 34518 RVA: 0x001120CC File Offset: 0x001102CC
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

		// Token: 0x060086D7 RID: 34519 RVA: 0x00112110 File Offset: 0x00110310
		public void SetReplaceCameraShader(Shader shader)
		{
			bool flag = shader != null && this._camera != null;
			if (flag)
			{
				this._camera.SetReplacementShader(shader, "RenderType");
			}
		}

		// Token: 0x04002A1E RID: 10782
		public static bool OperationV = true;

		// Token: 0x04002A1F RID: 10783
		public static bool OperationH = true;

		// Token: 0x04002A20 RID: 10784
		public static float MaxV = 80f;

		// Token: 0x04002A21 RID: 10785
		public static float MinV = -80f;

		// Token: 0x04002A22 RID: 10786
		private float _dis = 0f;

		// Token: 0x04002A23 RID: 10787
		private float _tdis = 0f;

		// Token: 0x04002A24 RID: 10788
		private float _basic_dis = 4.2f;

		// Token: 0x04002A25 RID: 10789
		private float _default_dis = 4.2f;

		// Token: 0x04002A26 RID: 10790
		private GameObject _cameraObject = null;

		// Token: 0x04002A27 RID: 10791
		private GameObject _dummyObject = null;

		// Token: 0x04002A28 RID: 10792
		private Transform _dummyCamera = null;

		// Token: 0x04002A29 RID: 10793
		private Transform _cameraTransform = null;

		// Token: 0x04002A2A RID: 10794
		private Animator _ator = null;

		// Token: 0x04002A2B RID: 10795
		private AnimatorOverrideController _overrideController;

		// Token: 0x04002A2C RID: 10796
		private List<Type> _added_component = new List<Type>();

		// Token: 0x04002A2D RID: 10797
		private Camera _camera = null;

		// Token: 0x04002A2E RID: 10798
		private bool _inited = false;

		// Token: 0x04002A2F RID: 10799
		private float _elapsed = 0f;

		// Token: 0x04002A30 RID: 10800
		private bool _damp = false;

		// Token: 0x04002A31 RID: 10801
		private float _damp_delta = 0f;

		// Token: 0x04002A32 RID: 10802
		private Vector3 _damp_dir = Vector3.zero;

		// Token: 0x04002A33 RID: 10803
		private bool _root_pos_inited = false;

		// Token: 0x04002A34 RID: 10804
		private Vector3 _root_pos = Vector3.zero;

		// Token: 0x04002A35 RID: 10805
		private Quaternion _idle_root_rotation = Quaternion.identity;

		// Token: 0x04002A36 RID: 10806
		private float _idle_root_basic_x = 0f;

		// Token: 0x04002A37 RID: 10807
		private bool _init_idle_root_basic_x = false;

		// Token: 0x04002A38 RID: 10808
		private float _idle_root_rotation_x_default = 0f;

		// Token: 0x04002A39 RID: 10809
		private float _idle_root_rotation_x_target = 0f;

		// Token: 0x04002A3A RID: 10810
		private float _idle_root_rotation_x = 0f;

		// Token: 0x04002A3B RID: 10811
		private float _idle_root_rotation_y = 0f;

		// Token: 0x04002A3C RID: 10812
		private float _idle_root_rotation_y_default = 0f;

		// Token: 0x04002A3D RID: 10813
		private float _idle_root_rotation_y_target = 0f;

		// Token: 0x04002A3E RID: 10814
		private Vector3 _last_dummyCamera_pos = Vector3.zero;

		// Token: 0x04002A3F RID: 10815
		private Vector3 _dummyCamera_pos = Vector3.zero;

		// Token: 0x04002A40 RID: 10816
		private Vector3 _dummyCamera_rot = Vector3.forward;

		// Token: 0x04002A41 RID: 10817
		private Quaternion _dummyCamera_quat = Quaternion.identity;

		// Token: 0x04002A42 RID: 10818
		private Vector3 _v_self_p = Vector3.zero;

		// Token: 0x04002A43 RID: 10819
		private Quaternion _q_self_r = Quaternion.identity;

		// Token: 0x04002A44 RID: 10820
		private readonly float _damp_factor = 0.3f;

		// Token: 0x04002A45 RID: 10821
		private XCameraMotionData _active_motion = new XCameraMotionData();

		// Token: 0x04002A46 RID: 10822
		private XEntity _active_target = null;

		// Token: 0x04002A47 RID: 10823
		private float _field_of_view = 45f;

		// Token: 0x04002A48 RID: 10824
		private XCameraSoloComponent _solo = null;

		// Token: 0x04002A49 RID: 10825
		private XCameraMotionComponent _motion = null;

		// Token: 0x04002A4A RID: 10826
		private XCameraCollisonComponent _collision = null;

		// Token: 0x04002A4B RID: 10827
		private XCameraIntellectiveFollow _tail = null;

		// Token: 0x04002A4C RID: 10828
		private XCameraVAdjustComponent _adjust = null;

		// Token: 0x04002A4D RID: 10829
		private XCameraWallComponent _wall = null;

		// Token: 0x04002A4E RID: 10830
		private XCameraCloseUpComponent _closeup = null;

		// Token: 0x02001951 RID: 6481
		public enum XStatus
		{
			// Token: 0x04007D8C RID: 32140
			None,
			// Token: 0x04007D8D RID: 32141
			Idle,
			// Token: 0x04007D8E RID: 32142
			Solo,
			// Token: 0x04007D8F RID: 32143
			Effect
		}
	}
}
