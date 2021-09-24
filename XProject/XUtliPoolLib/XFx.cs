using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{

	public class XFx : IRenderObject
	{

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

		public bool IsLoaded
		{
			get
			{
				return this.m_LoadStatus == 1;
			}
		}

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

		private void LoadAsync(string location)
		{
			this.loadTask = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefabAsync(location, this.loadCb, null, true);
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				this.loadTask = null;
			}
		}

		private void Load(string location)
		{
			GameObject obj = XSingleton<XResourceLoaderMgr>.singleton.CreateFromAsset<GameObject>(location, ".prefab", true, false);
			this.LoadFinish(obj, null);
		}

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

		private bool IsCbFlag(int index)
		{
			int num = 1 << index;
			return (this.m_LoadFinishCbFlag & num) != 0;
		}

		private static void _ParentLoad(XGameObject gameObject, object o, int commandID)
		{
			XFx xfx = o as XFx;
			bool flag = xfx._instanceID == commandID;
			if (flag)
			{
				xfx.RealPlay();
			}
		}

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

		private static void SyncActive(XFx fx)
		{
			bool flag = fx.m_GameObject != null;
			if (flag)
			{
				fx.m_GameObject.SetActive(fx._enable);
			}
		}

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

		public void Play()
		{
			this.ReqPlay();
		}

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

		public int InstanceID
		{
			set
			{
			}
		}

		public bool IsSameObj(int id)
		{
			return this._instanceID == id;
		}

		public void SetShader(int type)
		{
		}

		public void ResetShader()
		{
		}

		public void SetColor(byte r, byte g, byte b, byte a)
		{
		}

		public void SetColor(Color32 c)
		{
		}

		public void Update()
		{
		}

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

		public void Clean()
		{
		}

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

		public static int globalFxID = 0;

		public int _instanceID = -1;

		public string FxName = "";

		private GameObject m_GameObject = null;

		private Transform m_TransformCache = null;

		private Animation _animation = null;

		private AnimationState _animState = null;

		private Animator _animator = null;

		private List<ParticleSystem> _particles = new List<ParticleSystem>();

		private List<Projector> _projectors = new List<Projector>();

		private List<MeshRenderer> _meshs = null;

		private IWeaponTail _weaponTail = null;

		private TrailRenderer _trail = null;

		private float _startSize = 1f;

		private float _startProjectorSize = 1f;

		public float DelayDestroy = -1f;

		public uint Token = 0U;

		private Transform _parent = null;

		private XGameObject _parentXgo = null;

		private float _speed_ratio = 0f;

		private Vector3 _pos;

		private Quaternion _rot;

		private Vector3 _scale;

		private Vector3 _offset;

		private bool _follow;

		private bool _sticky;

		private string _transName = "";

		private float _translate = 0f;

		private int _layer = -1;

		private int _renderQueue = -1;

		private bool _enable = true;

		private int m_LoadFinishCbFlag = 0;

		private short m_LoadStatus = 0;

		private LoadAsyncTask loadTask = null;

		private LoadCallBack loadCb = null;

		public LoadCallBack loadFinish = null;

		public OnFxDestroyed callback = null;

		private static CommandCallback _parentLoadCb = new CommandCallback(XFx._ParentLoad);

		private static FxLoadCallback[] loadCallbacks = null;

		public static LoadCallBack _ProcessMesh = new LoadCallBack(XFx.ProcessMesh);

		private enum ECallbackCmd
		{

			ESyncActive = 1,

			ESyncPlay,

			ESyncLayer = 4,

			ESyncRenderQueue = 8,

			ESyncRefreshRenderQueue = 16,

			ESyncParent = 32
		}
	}
}
