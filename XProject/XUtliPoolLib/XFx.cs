using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020001B0 RID: 432
	public class XFx : IRenderObject
	{
		// Token: 0x0600097D RID: 2429 RVA: 0x000311D0 File Offset: 0x0002F3D0
		public XFx()
		{
			this.loadCb = new LoadCallBack(this.LoadFinish);
			bool flag = XFx.loadCallbacks == null;
			if (flag)
			{
				XFx.loadCallbacks = new FxLoadCallback[]
				{
					new FxLoadCallback(XFx.SyncActive),
					new FxLoadCallback(XFx.SyncPlay),
					new FxLoadCallback(XFx.SyncLayer),
					new FxLoadCallback(XFx.SyncRenderQueue),
					new FxLoadCallback(XFx.SyncRefreshUIRenderQueue),
					new FxLoadCallback(XFx.SyncParent)
				};
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x00031360 File Offset: 0x0002F560
		public bool IsLoaded
		{
			get
			{
				return this.m_LoadStatus == 1;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600097F RID: 2431 RVA: 0x0003137C File Offset: 0x0002F57C
		// (set) Token: 0x06000980 RID: 2432 RVA: 0x000313B0 File Offset: 0x0002F5B0
		public Vector3 Position
		{
			get
			{
				return (this.m_TransformCache != null) ? this.m_TransformCache.position : this._pos;
			}
			set
			{
				this._pos = value;
				bool flag = this.m_TransformCache != null;
				if (flag)
				{
					this.m_TransformCache.position = value;
				}
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000981 RID: 2433 RVA: 0x000313E4 File Offset: 0x0002F5E4
		// (set) Token: 0x06000982 RID: 2434 RVA: 0x00031418 File Offset: 0x0002F618
		public Quaternion Rotation
		{
			get
			{
				return (this.m_TransformCache != null) ? this.m_TransformCache.rotation : this._rot;
			}
			set
			{
				this._rot = value;
				bool flag = this.m_TransformCache != null;
				if (flag)
				{
					this.m_TransformCache.rotation = value;
				}
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000983 RID: 2435 RVA: 0x0003144C File Offset: 0x0002F64C
		// (set) Token: 0x06000984 RID: 2436 RVA: 0x00031490 File Offset: 0x0002F690
		public Vector3 Forward
		{
			get
			{
				bool flag = this.m_TransformCache != null;
				Vector3 result;
				if (flag)
				{
					result = this.m_TransformCache.forward;
				}
				else
				{
					result = this._rot * Vector3.forward;
				}
				return result;
			}
			set
			{
				this._rot = Quaternion.LookRotation(value);
				bool flag = this.m_TransformCache != null;
				if (flag)
				{
					this.m_TransformCache.forward = value;
				}
			}
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x000314CC File Offset: 0x0002F6CC
		public static int GetGlobalFxID()
		{
			XFx.globalFxID++;
			bool flag = XFx.globalFxID > 1000000;
			if (flag)
			{
				XFx.globalFxID = 0;
			}
			return XFx.globalFxID;
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x00031508 File Offset: 0x0002F708
		public static XFx CreateXFx(string location, LoadCallBack loadFinish, bool async = true)
		{
			XFx xfx = CommonObjectPool<XFx>.Get();
			xfx._instanceID = XFx.GetGlobalFxID();
			xfx.FxName = location;
			xfx.loadFinish = loadFinish;
			bool flag = string.IsNullOrEmpty(location) || location.EndsWith("empty");
			if (flag)
			{
				xfx.LoadFinish(null, null);
			}
			else
			{
				bool flag2 = XSingleton<XResourceLoaderMgr>.singleton.DelayLoad && async;
				if (flag2)
				{
					xfx.LoadAsync(location);
				}
				else
				{
					xfx.Load(location);
				}
			}
			return xfx;
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x0003158C File Offset: 0x0002F78C
		public static void DestroyXFx(XFx fx, bool stop = true)
		{
			bool flag = fx._instanceID >= 0;
			if (flag)
			{
				if (stop)
				{
					fx.Stop();
				}
				fx.Reset();
				CommonObjectPool<XFx>.Release(fx);
			}
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x000315C8 File Offset: 0x0002F7C8
		public void Reset()
		{
			bool flag = this.callback != null;
			if (flag)
			{
				this.callback(this);
			}
			this._instanceID = -1;
			this.FxName = "";
			this.m_TransformCache = null;
			this.DelayDestroy = -1f;
			bool flag2 = this.Token > 0U;
			if (flag2)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this.Token);
			}
			this.Token = 0U;
			this._animation = null;
			this._animator = null;
			this._particles.Clear();
			this._projectors.Clear();
			bool flag3 = this._meshs != null;
			if (flag3)
			{
				this._meshs.Clear();
				ListPool<MeshRenderer>.Release(this._meshs);
				this._meshs = null;
			}
			this._weaponTail = null;
			this._trail = null;
			this._parent = null;
			this._parentXgo = null;
			this._startSize = 1f;
			this._startProjectorSize = 1f;
			this._pos = XResourceLoaderMgr.Far_Far_Away;
			this._rot = Quaternion.identity;
			this._scale = Vector3.one;
			this._offset = Vector3.zero;
			this._speed_ratio = 0f;
			this._follow = false;
			this._sticky = false;
			this._transName = "";
			this._translate = 0f;
			this._layer = -1;
			this._renderQueue = -1;
			this._enable = true;
			this.m_LoadFinishCbFlag = 0;
			this.m_LoadStatus = 0;
			bool flag4 = this.loadTask != null;
			if (flag4)
			{
				this.loadTask.CancelLoad(this.loadCb);
				this.loadTask = null;
			}
			this.callback = null;
			XResourceLoaderMgr.SafeDestroy(ref this.m_GameObject, true);
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0003177C File Offset: 0x0002F97C
		private void LoadAsync(string location)
		{
			this.loadTask = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefabAsync(location, this.loadCb, null, true);
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				this.loadTask = null;
			}
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x000317B8 File Offset: 0x0002F9B8
		private void Load(string location)
		{
			GameObject obj = XSingleton<XResourceLoaderMgr>.singleton.CreateFromAsset<GameObject>(location, ".prefab", true, false);
			this.LoadFinish(obj, null);
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x000317E4 File Offset: 0x0002F9E4
		private bool PreProcessFx(GameObject go, int qualityLayer)
		{
			int num = 1 << go.layer;
			bool flag = (num & qualityLayer) == 0;
			bool result;
			if (flag)
			{
				bool activeSelf = go.activeSelf;
				if (activeSelf)
				{
					go.SetActive(false);
				}
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x00031828 File Offset: 0x0002FA28
		private void LoadFinish(UnityEngine.Object obj, object cbOjb)
		{
			this.m_GameObject = (obj as GameObject);
			this.m_LoadStatus = 1;
			bool flag = this.m_GameObject != null;
			if (flag)
			{
				this.m_TransformCache = this.m_GameObject.transform;
				this._animation = this.m_TransformCache.GetComponentInChildren<Animation>();
				this._animator = this.m_TransformCache.GetComponentInChildren<Animator>();
				bool flag2 = this._animator != null;
				if (flag2)
				{
					this._animator.enabled = true;
				}
				bool flag3 = this._animation != null;
				if (flag3)
				{
					this._animation.enabled = true;
				}
				this._particles.Clear();
				this._projectors.Clear();
				List<Component> list = ListPool<Component>.Get();
				this.m_TransformCache.GetComponentsInChildren<Component>(true, list);
				for (int i = 0; i < list.Count; i++)
				{
					Component component = list[i];
					bool flag4 = component is ParticleSystem;
					if (flag4)
					{
						ParticleSystem particleSystem = component as ParticleSystem;
						bool flag5 = XFxMgr.MaxParticelCount > 0;
						if (flag5)
						{
							ParticleSystem.MainModule main = particleSystem.main;
							bool flag6 = main.maxParticles > XFxMgr.MaxParticelCount;
							if (flag6)
							{
								main.maxParticles = XFxMgr.MaxParticelCount;
							}
						}
						bool flag7 = this.PreProcessFx(particleSystem.gameObject, XSingleton<XFxMgr>.singleton.CameraLayerMask);
						if (flag7)
						{
							this._particles.Add(particleSystem);
						}
					}
					else
					{
						bool flag8 = component is Projector;
						if (flag8)
						{
							Projector projector = component as Projector;
							bool flag9 = this.PreProcessFx(projector.gameObject, XSingleton<XFxMgr>.singleton.CameraLayerMask);
							if (flag9)
							{
								this._projectors.Add(projector);
							}
						}
						else
						{
							bool flag10 = component is IWeaponTail;
							if (flag10)
							{
								this._weaponTail = (component as IWeaponTail);
							}
							else
							{
								bool flag11 = component is TrailRenderer;
								if (flag11)
								{
									this._trail = (component as TrailRenderer);
								}
							}
						}
					}
				}
				ListPool<Component>.Release(list);
				bool flag12 = this.loadFinish != null;
				if (flag12)
				{
					this.loadFinish(this.m_GameObject, this);
				}
				for (int j = 0; j < XFx.loadCallbacks.Length; j++)
				{
					bool flag13 = this.IsCbFlag(j);
					if (flag13)
					{
						FxLoadCallback fxLoadCallback = XFx.loadCallbacks[j];
						fxLoadCallback(this);
					}
				}
				this.m_LoadFinishCbFlag = 0;
			}
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x00031AA8 File Offset: 0x0002FCA8
		private void SetCbFlag(XFx.ECallbackCmd cmd, bool add)
		{
			int num = XFastEnumIntEqualityComparer<XFx.ECallbackCmd>.ToInt(cmd);
			if (add)
			{
				this.m_LoadFinishCbFlag |= num;
			}
			else
			{
				this.m_LoadFinishCbFlag &= ~num;
			}
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00031AE8 File Offset: 0x0002FCE8
		private bool IsCbFlag(int index)
		{
			int num = 1 << index;
			return (this.m_LoadFinishCbFlag & num) != 0;
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x00031B0C File Offset: 0x0002FD0C
		private static void _ParentLoad(XGameObject gameObject, object o, int commandID)
		{
			XFx xfx = o as XFx;
			bool flag = xfx._instanceID == commandID;
			if (flag)
			{
				xfx.RealPlay();
			}
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x00031B38 File Offset: 0x0002FD38
		private static void SyncPlay(XFx fx)
		{
			bool flag = fx._parentXgo != null;
			if (flag)
			{
				fx._parentXgo.CallCommand(XFx._parentLoadCb, fx, fx._instanceID, false);
			}
			else
			{
				fx.RealPlay();
			}
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x00031B7C File Offset: 0x0002FD7C
		private static void SyncLayer(XFx fx)
		{
			bool flag = fx._layer >= 0;
			if (flag)
			{
				for (int i = 0; i < fx._particles.Count; i++)
				{
					ParticleSystem particleSystem = fx._particles[i];
					bool flag2 = particleSystem != null;
					if (flag2)
					{
						particleSystem.gameObject.layer = fx._layer;
					}
				}
				for (int j = 0; j < fx._projectors.Count; j++)
				{
					Projector projector = fx._projectors[j];
					projector.gameObject.layer = fx._layer;
				}
				bool flag3 = fx._meshs != null;
				if (flag3)
				{
					for (int k = 0; k < fx._meshs.Count; k++)
					{
						MeshRenderer meshRenderer = fx._meshs[k];
						bool flag4 = meshRenderer != null;
						if (flag4)
						{
							meshRenderer.gameObject.layer = fx._layer;
						}
					}
				}
			}
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x00031C90 File Offset: 0x0002FE90
		private static void SyncRenderQueue(XFx fx)
		{
			bool flag = fx._renderQueue > 0;
			if (flag)
			{
				for (int i = 0; i < fx._particles.Count; i++)
				{
					ParticleSystem particleSystem = fx._particles[i];
					Renderer component = particleSystem.GetComponent<Renderer>();
					bool flag2 = component != null && component.sharedMaterial != null;
					if (flag2)
					{
						component.material.renderQueue = fx._renderQueue;
					}
				}
				bool flag3 = fx._meshs != null;
				if (flag3)
				{
					for (int j = 0; j < fx._meshs.Count; j++)
					{
						MeshRenderer meshRenderer = fx._meshs[j];
						bool flag4 = meshRenderer != null && meshRenderer.sharedMaterial != null;
						if (flag4)
						{
							meshRenderer.material.renderQueue = fx._renderQueue;
						}
					}
				}
			}
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x00031D8C File Offset: 0x0002FF8C
		public static void SyncRefreshUIRenderQueue(XFx fx)
		{
			bool flag = fx.m_GameObject != null;
			if (flag)
			{
				for (int i = 0; i < fx._particles.Count; i++)
				{
					IControlParticle controlParticle = fx._particles[i].gameObject.GetComponent("ControlParticle") as IControlParticle;
					bool flag2 = controlParticle != null;
					if (flag2)
					{
						controlParticle.RefreshRenderQueue(true);
					}
				}
			}
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x00031E00 File Offset: 0x00030000
		private static void SyncActive(XFx fx)
		{
			bool flag = fx.m_GameObject != null;
			if (flag)
			{
				fx.m_GameObject.SetActive(fx._enable);
			}
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x00031E34 File Offset: 0x00030034
		private static void SyncParent(XFx fx)
		{
			bool flag = fx.m_TransformCache != null;
			if (flag)
			{
				fx.m_TransformCache.parent = fx._parent;
				fx.m_TransformCache.localPosition = fx._pos;
				fx.m_TransformCache.localRotation = fx._rot;
				fx.m_TransformCache.localScale = fx._scale;
			}
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x00031E9C File Offset: 0x0003009C
		private void SetTransform()
		{
			bool flag = this.m_TransformCache != null;
			if (flag)
			{
				bool flag2 = this._parent == null;
				if (flag2)
				{
					this.m_TransformCache.position = this._pos;
					this.m_TransformCache.rotation = this._rot;
					this.m_TransformCache.localScale = this._scale;
				}
				else
				{
					bool follow = this._follow;
					if (follow)
					{
						this.m_TransformCache.parent = this._parent;
						this.m_TransformCache.localPosition = Vector3.zero;
						this.m_TransformCache.localRotation = Quaternion.identity;
						this.m_TransformCache.localScale = this._scale;
						this.m_TransformCache.localPosition += this._parent.rotation * this._offset;
					}
					else
					{
						this.m_TransformCache.position = this._parent.position + this._parent.rotation * this._offset;
						this.m_TransformCache.rotation = this._parent.rotation;
						this.m_TransformCache.localScale = this._scale;
					}
					bool flag3 = Mathf.Abs(this._translate) > 0.001f;
					if (flag3)
					{
						this.m_TransformCache.Translate(Vector3.up * this._translate);
						this._translate = 0f;
					}
				}
			}
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0003202C File Offset: 0x0003022C
		private void RealPlay()
		{
			bool flag = this._parent == null && this._parentXgo != null;
			if (flag)
			{
				this._parent = this._parentXgo.Find("");
				bool flag2 = this._parent != null && !string.IsNullOrEmpty(this._transName);
				if (flag2)
				{
					Transform transform = this._parent.Find(this._transName);
					bool flag3 = transform == null;
					if (flag3)
					{
						int num = this._transName.LastIndexOf("/");
						bool flag4 = num >= 0;
						if (flag4)
						{
							string text = this._transName.Substring(num + 1);
							transform = this._parent.Find(text);
							bool flag5 = transform != null;
							if (flag5)
							{
								this._parent = transform;
							}
						}
					}
					else
					{
						this._parent = transform;
					}
				}
			}
			this.SetTransform();
			bool enable = this._enable;
			if (enable)
			{
				bool flag6 = this.m_GameObject != null && !this.m_GameObject.activeSelf;
				if (flag6)
				{
					this.m_GameObject.SetActive(true);
				}
				bool flag7 = this._animation != null;
				if (flag7)
				{
					this._animation.enabled = true;
					this._animation.Play();
					this._animState = this._animation[this._animation.name];
					bool flag8 = this._animState != null;
					if (flag8)
					{
						bool flag9 = this._speed_ratio > 0f;
						if (flag9)
						{
							this._animState.speed = 1f / this._speed_ratio;
						}
						else
						{
							this._animState.speed = 0f;
						}
					}
				}
				bool flag10 = this._animator != null;
				if (flag10)
				{
					this._animator.enabled = true;
					bool flag11 = this._speed_ratio > 0f;
					if (flag11)
					{
						this._animator.speed = 1f / this._speed_ratio;
					}
					else
					{
						this._animator.speed = 0f;
					}
					bool flag12 = this._animator.runtimeAnimatorController != null;
					if (flag12)
					{
						this._animator.Play(this._animator.runtimeAnimatorController.name, 0, 0f);
					}
				}
				bool flag13 = this._particles != null;
				if (flag13)
				{
					this._startSize = this._scale.x;
					for (int i = 0; i < this._particles.Count; i++)
					{
						ParticleSystem particleSystem = this._particles[i];
						ParticleSystem.MainModule main = particleSystem.main;
						bool flag14 = this._speed_ratio > 0f;
						if (flag14)
						{
							main.simulationSpeed = 1f / this._speed_ratio;
						}
						else
						{
							main.simulationSpeed = 0f;
						}
						bool flag15 = this._startSize > 0f;
						if (flag15)
						{
							ParticleSystem.MinMaxCurve startSize = main.startSize;
							ParticleSystem.MinMaxCurve startSizeZ = main.startSizeZ;
							startSize.constantMin = this._startSize * startSizeZ.constantMin;
							startSize.constantMax = this._startSize * startSizeZ.constantMax;
						}
						particleSystem.time = 0f;
						particleSystem.Play(false);
					}
				}
				bool flag16 = this._projectors != null;
				if (flag16)
				{
					this._startProjectorSize = 1f;
					float aspectRatio = 1f;
					bool flag17 = this._scale.z > 0f;
					if (flag17)
					{
						aspectRatio = this._scale.x / this._scale.z;
						this._startProjectorSize = this._scale.z;
					}
					for (int j = 0; j < this._projectors.Count; j++)
					{
						Projector projector = this._projectors[j];
						projector.enabled = true;
						projector.aspectRatio = aspectRatio;
						projector.orthographicSize *= this._startProjectorSize;
					}
				}
				bool flag18 = this._weaponTail != null;
				if (flag18)
				{
					this._weaponTail.Activate();
				}
				bool flag19 = this._trail != null;
				if (flag19)
				{
					this._trail.enabled = true;
				}
				this.StickToGround();
			}
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x000324AC File Offset: 0x000306AC
		private void ReqPlay()
		{
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				XFx.SyncPlay(this);
			}
			else
			{
				this.SetCbFlag(XFx.ECallbackCmd.ESyncPlay, true);
			}
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x000324DC File Offset: 0x000306DC
		public void Play(Vector3 position, Quaternion rotation, Vector3 scale, float speed_ratio = 1f)
		{
			this._parent = null;
			this._parentXgo = null;
			this._pos = position;
			this._rot = rotation;
			this._scale = scale;
			this._offset = Vector3.zero;
			this._speed_ratio = speed_ratio;
			this._follow = false;
			this._sticky = false;
			this._transName = "";
			this._translate = 0f;
			this.ReqPlay();
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0003254C File Offset: 0x0003074C
		public void Play(Transform parent, Vector3 offset, Vector3 scale, float speed_ratio = 1f, bool follow = false, bool sticky = false)
		{
			this._parent = parent;
			this._parentXgo = null;
			this._pos = Vector3.zero;
			this._rot = Quaternion.identity;
			this._scale = scale;
			this._offset = offset;
			this._speed_ratio = speed_ratio;
			this._follow = follow;
			this._sticky = sticky;
			this._transName = "";
			this._translate = 0f;
			this.ReqPlay();
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x000325C4 File Offset: 0x000307C4
		public void Play(XGameObject parent, Vector3 offset, Vector3 scale, float speed_ratio = 1f, bool follow = false, bool sticky = false, string transName = "", float translate = 0f)
		{
			this._parent = null;
			this._parentXgo = parent;
			this._pos = Vector3.zero;
			this._rot = Quaternion.identity;
			this._scale = scale;
			this._offset = offset;
			this._speed_ratio = speed_ratio;
			this._follow = follow;
			this._sticky = sticky;
			this._transName = transName;
			this._translate = translate;
			this.ReqPlay();
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x00032633 File Offset: 0x00030833
		public void Play()
		{
			this.ReqPlay();
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x00032640 File Offset: 0x00030840
		public void SetParent(Transform parent)
		{
			this._parent = parent;
			this._parentXgo = null;
			this._pos = Vector3.zero;
			this._rot = Quaternion.identity;
			this._scale = Vector3.one;
			this._offset = Vector3.zero;
			this._speed_ratio = 1f;
			this._follow = false;
			this._sticky = false;
			this._transName = "";
			this._translate = 0f;
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x000326B8 File Offset: 0x000308B8
		public void SetParent(Transform parent, Vector3 position, Quaternion rotation, Vector3 scale)
		{
			this._parent = parent;
			this._pos = position;
			this._rot = rotation;
			this._scale = scale;
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				XFx.SyncParent(this);
			}
			else
			{
				this.SetCbFlag(XFx.ECallbackCmd.ESyncParent, true);
			}
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x00032704 File Offset: 0x00030904
		public void Stop()
		{
			bool flag = this.m_GameObject != null && this.m_GameObject.transform != null;
			if (flag)
			{
				this.m_GameObject.transform.localScale = Vector3.one;
			}
			bool flag2 = this._animation != null;
			if (flag2)
			{
				this._animation.Stop();
				this._animation.enabled = false;
			}
			bool flag3 = this._animator != null;
			if (flag3)
			{
				this._animator.speed = 1f;
				this._animator.enabled = false;
			}
			bool flag4 = this._particles != null;
			if (flag4)
			{
				for (int i = 0; i < this._particles.Count; i++)
				{
					ParticleSystem particleSystem = this._particles[i];
					bool flag5 = particleSystem != null;
					if (flag5)
					{
						particleSystem.Stop(false);
						particleSystem.Clear(false);
					}
				}
			}
			bool flag6 = this._projectors != null;
			if (flag6)
			{
				for (int j = 0; j < this._projectors.Count; j++)
				{
					Projector projector = this._projectors[j];
					bool flag7 = projector != null;
					if (flag7)
					{
						projector.enabled = false;
						bool flag8 = this._startProjectorSize > 0f;
						if (flag8)
						{
							projector.orthographicSize /= this._startProjectorSize;
						}
					}
				}
			}
			bool flag9 = this._weaponTail != null;
			if (flag9)
			{
				this._weaponTail.Deactivate();
			}
			bool flag10 = this._trail != null;
			if (flag10)
			{
				this._trail.enabled = false;
			}
			this._startSize = 1f;
			this._startProjectorSize = 1f;
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x000328E8 File Offset: 0x00030AE8
		public void StickToGround()
		{
			bool flag = this.m_GameObject == null || this.m_GameObject.transform.parent == null || !this._sticky;
			if (!flag)
			{
				Vector3 zero = Vector3.zero;
				float num = 0f;
				Vector3 position = this.m_GameObject.transform.parent.position;
				float y = this.m_GameObject.transform.parent.localScale.y;
				bool flag2 = XCurrentGrid.grid.TryGetHeight(position, out num);
				if (flag2)
				{
					zero.y = (num - position.y) / y + 0.025f;
				}
				this.m_GameObject.transform.localPosition = zero;
			}
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x000329AC File Offset: 0x00030BAC
		public void SetUIWidget(GameObject go)
		{
			bool flag = this.m_GameObject != null;
			if (flag)
			{
				for (int i = 0; i < this._particles.Count; i++)
				{
					IControlParticle controlParticle = this._particles[i].gameObject.GetComponent("ControlParticle") as IControlParticle;
					bool flag2 = controlParticle != null;
					if (flag2)
					{
						controlParticle.SetWidget(go);
					}
				}
			}
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x00032A20 File Offset: 0x00030C20
		public void SetActive(bool enable)
		{
			bool flag = this._enable != enable;
			if (flag)
			{
				this._enable = enable;
				bool isLoaded = this.IsLoaded;
				if (isLoaded)
				{
					XFx.SyncActive(this);
				}
				else
				{
					this.SetCbFlag(XFx.ECallbackCmd.ESyncActive, true);
				}
			}
		}

		// Token: 0x170000BF RID: 191
		// (set) Token: 0x060009A3 RID: 2467 RVA: 0x00003284 File Offset: 0x00001484
		public int InstanceID
		{
			set
			{
			}
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x00032A68 File Offset: 0x00030C68
		public bool IsSameObj(int id)
		{
			return this._instanceID == id;
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x00003284 File Offset: 0x00001484
		public void SetShader(int type)
		{
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x00003284 File Offset: 0x00001484
		public void ResetShader()
		{
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x00003284 File Offset: 0x00001484
		public void SetColor(byte r, byte g, byte b, byte a)
		{
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x00003284 File Offset: 0x00001484
		public void SetColor(Color32 c)
		{
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x00003284 File Offset: 0x00001484
		public void Update()
		{
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x00032A84 File Offset: 0x00030C84
		public void SetRenderLayer(int layer)
		{
			bool flag = this._layer != layer;
			if (flag)
			{
				this._layer = layer;
				bool isLoaded = this.IsLoaded;
				if (isLoaded)
				{
					XFx.SyncLayer(this);
				}
				else
				{
					this.SetCbFlag(XFx.ECallbackCmd.ESyncLayer, true);
				}
			}
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x00003284 File Offset: 0x00001484
		public void Clean()
		{
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x00032ACC File Offset: 0x00030CCC
		public void SetRenderQueue(int renderQueue)
		{
			bool flag = this._renderQueue != renderQueue;
			if (flag)
			{
				this._renderQueue = renderQueue;
				bool isLoaded = this.IsLoaded;
				if (isLoaded)
				{
					XFx.SyncRenderQueue(this);
				}
				else
				{
					this.SetCbFlag(XFx.ECallbackCmd.ESyncRenderQueue, true);
				}
			}
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x00032B14 File Offset: 0x00030D14
		public void RefreshUIRenderQueue()
		{
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				XFx.SyncRefreshUIRenderQueue(this);
			}
			else
			{
				this.SetCbFlag(XFx.ECallbackCmd.ESyncRefreshRenderQueue, true);
			}
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x00032B44 File Offset: 0x00030D44
		public static void ProcessMesh(UnityEngine.Object obj, object cbOjb)
		{
			GameObject gameObject = obj as GameObject;
			bool flag = gameObject != null;
			if (flag)
			{
				XFx xfx = cbOjb as XFx;
				List<Component> list = ListPool<Component>.Get();
				gameObject.GetComponentsInChildren<Component>(true, list);
				for (int i = 0; i < list.Count; i++)
				{
					Component component = list[i];
					bool flag2 = component is MeshRenderer;
					if (flag2)
					{
						bool flag3 = xfx._meshs == null;
						if (flag3)
						{
							xfx._meshs = ListPool<MeshRenderer>.Get();
						}
						xfx._meshs.Add(component as MeshRenderer);
					}
				}
				ListPool<Component>.Release(list);
			}
		}

		// Token: 0x04000439 RID: 1081
		public static int globalFxID = 0;

		// Token: 0x0400043A RID: 1082
		public int _instanceID = -1;

		// Token: 0x0400043B RID: 1083
		public string FxName = "";

		// Token: 0x0400043C RID: 1084
		private GameObject m_GameObject = null;

		// Token: 0x0400043D RID: 1085
		private Transform m_TransformCache = null;

		// Token: 0x0400043E RID: 1086
		private Animation _animation = null;

		// Token: 0x0400043F RID: 1087
		private AnimationState _animState = null;

		// Token: 0x04000440 RID: 1088
		private Animator _animator = null;

		// Token: 0x04000441 RID: 1089
		private List<ParticleSystem> _particles = new List<ParticleSystem>();

		// Token: 0x04000442 RID: 1090
		private List<Projector> _projectors = new List<Projector>();

		// Token: 0x04000443 RID: 1091
		private List<MeshRenderer> _meshs = null;

		// Token: 0x04000444 RID: 1092
		private IWeaponTail _weaponTail = null;

		// Token: 0x04000445 RID: 1093
		private TrailRenderer _trail = null;

		// Token: 0x04000446 RID: 1094
		private float _startSize = 1f;

		// Token: 0x04000447 RID: 1095
		private float _startProjectorSize = 1f;

		// Token: 0x04000448 RID: 1096
		public float DelayDestroy = -1f;

		// Token: 0x04000449 RID: 1097
		public uint Token = 0U;

		// Token: 0x0400044A RID: 1098
		private Transform _parent = null;

		// Token: 0x0400044B RID: 1099
		private XGameObject _parentXgo = null;

		// Token: 0x0400044C RID: 1100
		private float _speed_ratio = 0f;

		// Token: 0x0400044D RID: 1101
		private Vector3 _pos;

		// Token: 0x0400044E RID: 1102
		private Quaternion _rot;

		// Token: 0x0400044F RID: 1103
		private Vector3 _scale;

		// Token: 0x04000450 RID: 1104
		private Vector3 _offset;

		// Token: 0x04000451 RID: 1105
		private bool _follow;

		// Token: 0x04000452 RID: 1106
		private bool _sticky;

		// Token: 0x04000453 RID: 1107
		private string _transName = "";

		// Token: 0x04000454 RID: 1108
		private float _translate = 0f;

		// Token: 0x04000455 RID: 1109
		private int _layer = -1;

		// Token: 0x04000456 RID: 1110
		private int _renderQueue = -1;

		// Token: 0x04000457 RID: 1111
		private bool _enable = true;

		// Token: 0x04000458 RID: 1112
		private int m_LoadFinishCbFlag = 0;

		// Token: 0x04000459 RID: 1113
		private short m_LoadStatus = 0;

		// Token: 0x0400045A RID: 1114
		private LoadAsyncTask loadTask = null;

		// Token: 0x0400045B RID: 1115
		private LoadCallBack loadCb = null;

		// Token: 0x0400045C RID: 1116
		public LoadCallBack loadFinish = null;

		// Token: 0x0400045D RID: 1117
		public OnFxDestroyed callback = null;

		// Token: 0x0400045E RID: 1118
		private static CommandCallback _parentLoadCb = new CommandCallback(XFx._ParentLoad);

		// Token: 0x0400045F RID: 1119
		private static FxLoadCallback[] loadCallbacks = null;

		// Token: 0x04000460 RID: 1120
		public static LoadCallBack _ProcessMesh = new LoadCallBack(XFx.ProcessMesh);

		// Token: 0x02000395 RID: 917
		private enum ECallbackCmd
		{
			// Token: 0x04000FDB RID: 4059
			ESyncActive = 1,
			// Token: 0x04000FDC RID: 4060
			ESyncPlay,
			// Token: 0x04000FDD RID: 4061
			ESyncLayer = 4,
			// Token: 0x04000FDE RID: 4062
			ESyncRenderQueue = 8,
			// Token: 0x04000FDF RID: 4063
			ESyncRefreshRenderQueue = 16,
			// Token: 0x04000FE0 RID: 4064
			ESyncParent = 32
		}
	}
}
