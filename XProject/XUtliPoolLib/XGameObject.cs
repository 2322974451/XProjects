using System;
using System.Collections.Generic;
using UnityEngine;
using XUpdater;

namespace XUtliPoolLib
{

	public class XGameObject : XEngineObject
	{

		public XGameObject()
		{
			this.loadCb = new LoadCallBack(this.LoadFinish);
			bool flag = XGameObject.loadCallbacks == null;
			if (flag)
			{
				XGameObject.loadCallbacks = new LoadCallback[]
				{
					new LoadCallback(XGameObject.SyncPosition),
					new LoadCallback(XGameObject.SyncRotation),
					new LoadCallback(XGameObject.SyncScale),
					new LoadCallback(XGameObject.SyncLayer),
					new LoadCallback(XGameObject.SyncCCEnable),
					new LoadCallback(XGameObject.SyncBCEnable),
					new LoadCallback(XGameObject.SyncUpdateWhenOffscreen),
					new LoadCallback(XGameObject.SyncActive),
					new LoadCallback(XGameObject.SyncTag),
					new LoadCallback(XGameObject.SyncCCOffset)
				};
			}
		}

		public Vector3 Position
		{
			get
			{
				return this.m_Position;
			}
			set
			{
				this.m_Position = value;
				this.AppendPositionCommand();
			}
		}

		public Vector3 LocalEulerAngles
		{
			get
			{
				bool flag = this.Trans != null;
				Vector3 result;
				if (flag)
				{
					result = this.Trans.localEulerAngles;
				}
				else
				{
					result = Vector3.zero;
				}
				return result;
			}
			set
			{
				bool flag = this.Trans != null;
				if (flag)
				{
					this.Trans.localEulerAngles = value;
				}
			}
		}

		public Quaternion Rotation
		{
			get
			{
				return this.m_Rotation;
			}
			set
			{
				this.m_Rotation = value;
				this.AppendRotationCommand();
			}
		}

		public Vector3 LocalScale
		{
			get
			{
				return this.m_Scale;
			}
			set
			{
				this.m_Scale = value;
				this.AppendScaleCommand();
			}
		}

		public int Layer
		{
			get
			{
				return this.m_Layer;
			}
			set
			{
				this.m_Layer = value;
				this.AppendLayerCommand();
			}
		}

		public float CCStepOffset
		{
			get
			{
				return this.m_CCStepOffset;
			}
			set
			{
				this.m_CCStepOffset = value;
				this.AppendCCStepOffsetCommand();
			}
		}

		public bool EnableCC
		{
			get
			{
				return this.m_EnableCC;
			}
			set
			{
				this.m_EnableCC = value;
				this.AppendEnableCCCommand();
			}
		}

		public bool EnableBC
		{
			get
			{
				return this.m_EnableBC;
			}
			set
			{
				this.m_EnableBC = value;
				this.AppendEnableBCommand();
			}
		}

		public bool UpdateWhenOffscreen
		{
			set
			{
				this.m_UpdateWhenOffscreen = value;
				this.AppendUpdateWhenOffscreen();
			}
		}

		public Vector3 Forward
		{
			get
			{
				return this.m_Rotation * Vector3.forward;
			}
			set
			{
				this.m_Rotation = Quaternion.LookRotation(value);
				this.AppendRotationCommand();
			}
		}

		public Vector3 Up
		{
			get
			{
				return this.m_Rotation * Vector3.up;
			}
			set
			{
				this.m_Rotation = Quaternion.FromToRotation(Vector3.up, value);
				this.AppendRotationCommand();
			}
		}

		public Vector3 Right
		{
			get
			{
				return this.m_Rotation * Vector3.right;
			}
			set
			{
				this.m_Rotation = Quaternion.FromToRotation(Vector3.right, value);
				this.AppendRotationCommand();
			}
		}

		public string Tag
		{
			get
			{
				return this.m_Tag;
			}
			set
			{
				this.m_Tag = value;
				this.AppendTagCommand();
			}
		}

		private Transform Trans
		{
			get
			{
				bool isLoaded = this.IsLoaded;
				if (isLoaded)
				{
					bool flag = this.m_GameObject != null && this.m_TransformCache == null;
					if (flag)
					{
						this.m_TransformCache = this.m_GameObject.transform;
					}
				}
				return this.m_TransformCache;
			}
		}

		public XAnimator Ator
		{
			get
			{
				return this.m_Ator;
			}
		}

		public ulong UID
		{
			get
			{
				return this.m_UID;
			}
			set
			{
				this.m_UID = value;
			}
		}

		public string Name
		{
			get
			{
				return this.m_Name;
			}
			set
			{
				this.m_Name = value;
				bool flag = this.m_GameObject != null;
				if (flag)
				{
					this.m_GameObject.name = this.m_Name;
				}
			}
		}

		public bool IsValid
		{
			get
			{
				return this.m_Valid;
			}
		}

		public bool IsVisible
		{
			get
			{
				bool flag = this.m_SkinMeshRenderCache != null;
				return flag && this.m_SkinMeshRenderCache.isVisible;
			}
		}

		public bool IsNotEmptyObject
		{
			get
			{
				return !string.IsNullOrEmpty(this.m_Location);
			}
		}

		public bool HasSkin
		{
			get
			{
				return this.m_SkinMeshRenderCache != null;
			}
		}

		public SkinnedMeshRenderer SMR
		{
			get
			{
				return this.m_SkinMeshRenderCache;
			}
		}

		public bool IsLoaded
		{
			get
			{
				return this.m_LoadStatus == 1;
			}
		}

		public void Reset()
		{
			this.m_Position = XResourceLoaderMgr.Far_Far_Away;
			this.m_Rotation = Quaternion.identity;
			this.m_Scale = Vector3.one;
			this.m_EnableCC = false;
			this.m_EnableBC = false;
			this.m_Tag = "Untagged";
			this.m_Layer = 0;
			this.m_UID = 0UL;
			this.m_Name = "";
			this.m_TransformCache = null;
			this.m_SkinMeshRenderCache = null;
			this.objID = -1;
			bool flag = this.afterLoadCommand != null;
			if (flag)
			{
				XSingleton<XEngineCommandMgr>.singleton.ReturnCommand(this.afterLoadCommand);
				this.afterLoadCommand = null;
			}
			bool flag2 = this.m_ccCache != null;
			if (flag2)
			{
				this.m_ccCache.enabled = false;
				this.m_ccCache = null;
			}
			bool flag3 = this.m_bcCache != null;
			if (flag3)
			{
				this.m_bcCache.enabled = false;
				this.m_bcCache = null;
			}
			this.m_LoadStatus = 0;
			bool flag4 = this.loadTask != null;
			if (flag4)
			{
				this.loadTask.CancelLoad(this.loadCb);
				this.loadTask = null;
			}
			this.m_LoadFinishCbFlag = 0;
			bool flag5 = this.m_Ator != null;
			if (flag5)
			{
				this.m_Ator.Reset();
				CommonObjectPool<XAnimator>.Release(this.m_Ator);
				this.m_Ator = null;
			}
			this.m_UpdateFrame = 0;
			bool flag6 = string.IsNullOrEmpty(this.m_Location);
			if (flag6)
			{
				XSingleton<XEngineCommandMgr>.singleton.ReturnGameObject(this.m_GameObject);
				this.m_GameObject = null;
			}
			else
			{
				bool flag7 = this.m_GameObject != null;
				if (flag7)
				{
					this.m_GameObject.name = this.m_Location;
				}
				XResourceLoaderMgr.SafeDestroy(ref this.m_GameObject, true);
			}
			this.m_Location = "";
			this.m_Parent = null;
			this.m_Valid = false;
		}

		public void LoadAsync(string location, bool usePool)
		{
			this.loadTask = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefabAsync(location, this.loadCb, null, usePool);
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				this.loadTask = null;
			}
		}

		public void Load(string location, bool usePool)
		{
			GameObject obj = XSingleton<XResourceLoaderMgr>.singleton.CreateFromAsset<GameObject>(location, ".prefab", usePool, false);
			this.LoadFinish(obj, null);
		}

		private void LoadFinish(UnityEngine.Object obj, object cbOjb)
		{
			this.m_GameObject = (obj as GameObject);
			this.m_LoadStatus = 1;
			bool flag = this.m_GameObject != null;
			if (flag)
			{
				this.m_ccCache = this.m_GameObject.GetComponent<CharacterController>();
				this.m_bcCache = this.m_GameObject.GetComponent<BoxCollider>();
				this.m_SkinMeshRenderCache = this.m_GameObject.GetComponentInChildren<SkinnedMeshRenderer>();
				bool flag2 = !string.IsNullOrEmpty(this.m_Name);
				if (flag2)
				{
					this.m_GameObject.name = this.m_Name;
				}
				bool flag3 = this.m_Ator != null;
				if (flag3)
				{
					this.m_UpdateFrame = 0;
					this.m_Ator.Init(this.m_GameObject);
				}
				bool flag4 = this.afterLoadCommand != null;
				if (flag4)
				{
					bool flag5 = this.afterLoadCommand.IsValid();
					if (flag5)
					{
						this.afterLoadCommand.Execute();
					}
					XSingleton<XEngineCommandMgr>.singleton.ReturnCommand(this.afterLoadCommand);
					this.afterLoadCommand = null;
				}
			}
			for (int i = 0; i < XGameObject.loadCallbacks.Length; i++)
			{
				bool flag6 = this.IsCbFlag(i);
				if (flag6)
				{
					LoadCallback loadCallback = XGameObject.loadCallbacks[i];
					loadCallback(this);
				}
			}
			this.m_LoadFinishCbFlag = 0;
			bool flag7 = this.m_GameObject != null;
			if (flag7)
			{
				bool flag8 = this.m_Layer != this.m_GameObject.layer;
				if (flag8)
				{
					this.m_Layer = this.m_GameObject.layer;
				}
			}
		}

		private void SetCbFlag(XGameObject.ECallbackCmd cmd, bool add)
		{
			int num = XFastEnumIntEqualityComparer<XGameObject.ECallbackCmd>.ToInt(cmd);
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

		public static int GetGlobalObjID()
		{
			XGameObject.globalObjID++;
			bool flag = XGameObject.globalObjID > 1000000;
			if (flag)
			{
				XGameObject.globalObjID = 0;
			}
			return XGameObject.globalObjID;
		}

		public static XGameObject CreateXGameObject(string location, Vector3 position, Quaternion rotation, bool async = true, bool usePool = true)
		{
			XGameObject xgameObject = XGameObject.CreateXGameObject(location, async, usePool);
			xgameObject.Position = position;
			xgameObject.Rotation = rotation;
			return xgameObject;
		}

		public static XGameObject CreateXGameObject(string location, bool async = true, bool usePool = true)
		{
			XGameObject xgameObject = CommonObjectPool<XGameObject>.Get();
			xgameObject.m_Valid = true;
			xgameObject.objID = XGameObject.GetGlobalObjID();
			xgameObject.m_Location = location;
			bool debug = XEngineCommand.debug;
			if (debug)
			{
				XSingleton<XDebug>.singleton.AddWarningLog2("[EngineCommand] CreateXGameObject {0} ID {1}", new object[]
				{
					location,
					xgameObject.objID
				});
			}
			bool flag = string.IsNullOrEmpty(location);
			if (flag)
			{
				GameObject gameObject = XSingleton<XEngineCommandMgr>.singleton.GetGameObject();
				xgameObject.LoadFinish(gameObject, null);
			}
			else
			{
				bool flag2 = XSingleton<XResourceLoaderMgr>.singleton.DelayLoad && async;
				if (flag2)
				{
					xgameObject.LoadAsync(location, usePool);
				}
				else
				{
					xgameObject.Load(location, usePool);
				}
			}
			return xgameObject;
		}

		public static XGameObject CloneXGameObject(XGameObject xgo, bool async = true)
		{
			XGameObject xgameObject = CommonObjectPool<XGameObject>.Get();
			xgameObject.m_Valid = true;
			xgameObject.objID = XGameObject.GetGlobalObjID();
			xgameObject.m_Location = xgo.m_Location;
			bool flag = string.IsNullOrEmpty(xgo.m_Location);
			if (flag)
			{
				GameObject gameObject = XSingleton<XEngineCommandMgr>.singleton.GetGameObject();
				xgameObject.LoadFinish(gameObject, null);
			}
			else
			{
				bool flag2 = XSingleton<XResourceLoaderMgr>.singleton.DelayLoad && async;
				if (flag2)
				{
					xgameObject.LoadAsync(xgo.m_Location, true);
				}
				else
				{
					xgameObject.Load(xgo.m_Location, true);
				}
			}
			return xgameObject;
		}

		public static void DestroyXGameObject(XGameObject gameObject)
		{
			bool debug = XEngineCommand.debug;
			if (debug)
			{
				XSingleton<XDebug>.singleton.AddWarningLog2("[EngineCommand] DestroyXGameObject {0} ID {1}", new object[]
				{
					gameObject.m_Location,
					gameObject.objID
				});
			}
			gameObject.Reset();
			CommonObjectPool<XGameObject>.Release(gameObject);
		}

		private static void SyncPosition(XGameObject gameObject)
		{
			Transform trans = gameObject.Trans;
			bool flag = trans != null;
			if (flag)
			{
				trans.position = gameObject.m_Position;
			}
		}

		private static void SyncRotation(XGameObject gameObject)
		{
			Transform trans = gameObject.Trans;
			bool flag = trans != null;
			if (flag)
			{
				trans.rotation = gameObject.m_Rotation;
			}
		}

		private static void SyncScale(XGameObject gameObject)
		{
			Transform trans = gameObject.Trans;
			bool flag = trans != null;
			if (flag)
			{
				trans.localScale = gameObject.m_Scale;
			}
		}

		private static void SyncLayer(XGameObject gameObject)
		{
			bool flag = gameObject.m_GameObject != null;
			if (flag)
			{
				gameObject.m_GameObject.layer = gameObject.m_Layer;
			}
		}

		private static void SyncCCOffset(XGameObject gameObject)
		{
			bool flag = gameObject.m_ccCache != null;
			if (flag)
			{
				bool flag2 = gameObject.m_CCStepOffset >= gameObject.m_ccCache.height;
				if (flag2)
				{
					gameObject.m_ccCache.height = gameObject.m_CCStepOffset + 0.1f;
				}
				gameObject.m_ccCache.stepOffset = gameObject.m_CCStepOffset;
			}
		}

		private static void SyncCCEnable(XGameObject gameObject)
		{
			bool flag = gameObject.m_ccCache != null;
			if (flag)
			{
				gameObject.m_ccCache.enabled = gameObject.m_EnableCC;
			}
		}

		private static void SyncBCEnable(XGameObject gameObject)
		{
			bool flag = gameObject.m_bcCache != null;
			if (flag)
			{
				gameObject.m_bcCache.enabled = gameObject.m_EnableBC;
			}
		}

		private static void SyncUpdateWhenOffscreen(XGameObject gameObject)
		{
			bool flag = gameObject.m_GameObject != null;
			if (flag)
			{
				XCommon.tmpSkinRender.Clear();
				gameObject.m_GameObject.GetComponentsInChildren<SkinnedMeshRenderer>(XCommon.tmpSkinRender);
				int count = XCommon.tmpSkinRender.Count;
				for (int i = 0; i < count; i++)
				{
					XCommon.tmpSkinRender[i].updateWhenOffscreen = gameObject.m_UpdateWhenOffscreen;
				}
				XCommon.tmpSkinRender.Clear();
			}
		}

		private static void SyncActive(XGameObject gameObject)
		{
			bool flag = gameObject.m_GameObject != null;
			if (flag)
			{
				bool isLoaded = gameObject.IsLoaded;
				if (isLoaded)
				{
					XCommon.tmpRender.Clear();
					gameObject.m_GameObject.GetComponentsInChildren<Renderer>(XCommon.tmpRender);
					int count = XCommon.tmpRender.Count;
					for (int i = 0; i < count; i++)
					{
						Renderer renderer = XCommon.tmpRender[i];
						bool flag2 = renderer.sharedMaterial != null && (gameObject.m_TagFilter == "" || renderer.tag.StartsWith(gameObject.m_TagFilter));
						if (flag2)
						{
							renderer.enabled = gameObject.m_EnableRender;
						}
					}
					XCommon.tmpRender.Clear();
				}
			}
		}

		private static void SyncTag(XGameObject gameObject)
		{
			bool flag = gameObject.m_GameObject != null;
			if (flag)
			{
				bool isLoaded = gameObject.IsLoaded;
				if (isLoaded)
				{
					gameObject.m_GameObject.tag = gameObject.Tag;
				}
			}
		}

		public void SyncSetParent(XGameObject parent)
		{
			bool flag = parent != null;
			if (flag)
			{
				this.m_Parent = parent.m_GameObject;
			}
			else
			{
				this.m_Parent = null;
			}
			bool flag2 = this.Trans != null;
			if (flag2)
			{
				this.Trans.parent = ((parent != null) ? parent.Trans : null);
			}
		}

		private static void SyncSetParentTrans(XGameObject gameObject, object obj, int commandID)
		{
			bool flag = gameObject.Trans != null;
			if (flag)
			{
				gameObject.Trans.parent = (obj as Transform);
			}
		}

		private static void SyncLocalPRS(XGameObject gameObject, object obj, int commandID)
		{
			XLocalPRSAsyncData xlocalPRSAsyncData = obj as XLocalPRSAsyncData;
			bool flag = gameObject.Trans != null && xlocalPRSAsyncData != null;
			if (flag)
			{
				bool flag2 = (xlocalPRSAsyncData.mask & 1) > 0;
				if (flag2)
				{
					gameObject.Trans.localPosition = xlocalPRSAsyncData.localPos;
					gameObject.SyncPos();
				}
				bool flag3 = (xlocalPRSAsyncData.mask & 2) > 0;
				if (flag3)
				{
					gameObject.Trans.localRotation = xlocalPRSAsyncData.localRotation;
				}
				bool flag4 = (xlocalPRSAsyncData.mask & 3) > 0;
				if (flag4)
				{
					gameObject.Trans.localScale = xlocalPRSAsyncData.localScale;
				}
			}
		}

		public XAnimator InitAnim()
		{
			bool flag = this.m_Ator == null;
			XAnimator ator;
			if (flag)
			{
				this.m_Ator = CommonObjectPool<XAnimator>.Get();
				this.m_Ator.xGameObject = this;
				bool isLoaded = this.IsLoaded;
				if (isLoaded)
				{
					this.m_UpdateFrame = 0;
					this.m_Ator.Init(this.m_GameObject);
				}
				ator = this.m_Ator;
			}
			else
			{
				ator = this.m_Ator;
			}
			return ator;
		}

		private void AppendPositionCommand()
		{
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				XGameObject.SyncPosition(this);
			}
			else
			{
				this.SetCbFlag(XGameObject.ECallbackCmd.ESyncPosition, true);
			}
		}

		private void AppendRotationCommand()
		{
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				XGameObject.SyncRotation(this);
			}
			else
			{
				this.SetCbFlag(XGameObject.ECallbackCmd.ESyncRotation, true);
			}
		}

		private void AppendScaleCommand()
		{
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				XGameObject.SyncScale(this);
			}
			else
			{
				this.SetCbFlag(XGameObject.ECallbackCmd.ESyncScale, true);
			}
		}

		private void AppendLayerCommand()
		{
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				XGameObject.SyncLayer(this);
			}
			else
			{
				this.SetCbFlag(XGameObject.ECallbackCmd.ESyncLayer, true);
			}
		}

		private void AppendCCStepOffsetCommand()
		{
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				XGameObject.SyncCCOffset(this);
			}
			else
			{
				this.SetCbFlag(XGameObject.ECallbackCmd.ESyncCCStepOffset, true);
			}
		}

		private void AppendEnableCCCommand()
		{
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				XGameObject.SyncCCEnable(this);
			}
			else
			{
				this.SetCbFlag(XGameObject.ECallbackCmd.ESyncCCEnable, true);
			}
		}

		private void AppendEnableBCommand()
		{
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				XGameObject.SyncBCEnable(this);
			}
			else
			{
				this.SetCbFlag(XGameObject.ECallbackCmd.ESyncBCEnable, true);
			}
		}

		private void AppendUpdateWhenOffscreen()
		{
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				XGameObject.SyncUpdateWhenOffscreen(this);
			}
			else
			{
				this.SetCbFlag(XGameObject.ECallbackCmd.ESyncUpdateWhenOffscreen, true);
			}
		}

		private void AppendTagCommand()
		{
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				XGameObject.SyncTag(this);
			}
			else
			{
				this.SetCbFlag(XGameObject.ECallbackCmd.ESyncTag, true);
			}
		}

		public bool TestVisibleWithFrustum(Plane[] planes, bool fully)
		{
			bool flag = this.m_SkinMeshRenderCache == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				Bounds bounds = this.m_SkinMeshRenderCache.bounds;
				if (fully)
				{
					for (int i = 0; i < planes.Length; i++)
					{
						bool flag2 = planes[i].GetDistanceToPoint(bounds.min) < 0f || planes[i].GetDistanceToPoint(bounds.max) < 0f;
						if (flag2)
						{
							return false;
						}
					}
					result = true;
				}
				else
				{
					result = GeometryUtility.TestPlanesAABB(planes, bounds);
				}
			}
			return result;
		}

		public void CallCommand(CommandCallback cb, object obj, int commandID = -1, bool executeAfterLoad = false)
		{
			bool flag = cb != null;
			if (flag)
			{
				bool isLoaded = this.IsLoaded;
				if (isLoaded)
				{
					cb(this, obj, commandID);
				}
				else
				{
					XEngineCommand xengineCommand = XSingleton<XEngineCommandMgr>.singleton.CreateCommand(XCallCommand.handler, this, commandID);
					XObjAsyncData objAsyncData = XSingleton<XEngineCommandMgr>.singleton.GetObjAsyncData();
					objAsyncData.commandCb = cb;
					objAsyncData.data = obj;
					xengineCommand.data = objAsyncData;
					xengineCommand.debugHandler = XCallCommand.debugHandler;
					if (executeAfterLoad)
					{
						bool flag2 = this.afterLoadCommand != null;
						if (flag2)
						{
							XSingleton<XEngineCommandMgr>.singleton.ReturnCommand(this.afterLoadCommand);
							this.afterLoadCommand = null;
						}
						this.afterLoadCommand = xengineCommand;
					}
					else
					{
						XSingleton<XEngineCommandMgr>.singleton.AppendCommand(xengineCommand);
					}
				}
			}
		}

		public void SetParent(XGameObject parent)
		{
			bool flag = this.IsLoaded && (parent == null || parent.IsLoaded);
			if (flag)
			{
				this.SyncSetParent(parent);
			}
			else
			{
				XEngineCommand xengineCommand = XSingleton<XEngineCommandMgr>.singleton.CreateCommand(XSetParentCommand.handler, this, -1);
				XObjAsyncData objAsyncData = XSingleton<XEngineCommandMgr>.singleton.GetObjAsyncData();
				objAsyncData.data = parent;
				xengineCommand.data = objAsyncData;
				xengineCommand.canExecute = XSetParentCommand.canExecute;
				xengineCommand.debugHandler = XSetParentCommand.debugHandler;
				XSingleton<XEngineCommandMgr>.singleton.AppendCommand(xengineCommand);
			}
		}

		public void SetParentTrans(Transform parent)
		{
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				XGameObject.SyncSetParentTrans(this, parent, -1);
			}
			else
			{
				XEngineCommand xengineCommand = XSingleton<XEngineCommandMgr>.singleton.CreateCommand(XCallCommand.handler, this, -1);
				XObjAsyncData objAsyncData = XSingleton<XEngineCommandMgr>.singleton.GetObjAsyncData();
				objAsyncData.commandCb = XGameObject.SyncSyncSetParentTransCmd;
				objAsyncData.data = parent;
				xengineCommand.data = objAsyncData;
				xengineCommand.debugHandler = XCallCommand.debugHandler;
				XSingleton<XEngineCommandMgr>.singleton.AppendCommand(xengineCommand);
			}
		}

		public Transform Find(string name)
		{
			bool flag = this.Trans != null && !string.IsNullOrEmpty(name);
			Transform result;
			if (flag)
			{
				result = this.Trans.Find(name);
			}
			else
			{
				result = this.Trans;
			}
			return result;
		}

		public GameObject Get()
		{
			return this.m_GameObject;
		}

		public void Rotate(Vector3 axis, float degree)
		{
			bool flag = this.Trans != null;
			if (flag)
			{
				this.Trans.Rotate(axis, degree);
			}
		}

		public void SetActive(bool enable, string tagFilter = "")
		{
			this.m_EnableRender = enable;
			this.m_TagFilter = tagFilter;
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				this.SetCbFlag(XGameObject.ECallbackCmd.ESyncActive, false);
				XGameObject.SyncActive(this);
			}
			else
			{
				this.SetCbFlag(XGameObject.ECallbackCmd.ESyncActive, true);
			}
		}

		public void SetLocalPRS(Vector3 pos, bool setPos, Quaternion rot, bool setRot, Vector3 scale, bool setScale)
		{
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				bool flag = this.Trans != null;
				if (flag)
				{
					if (setPos)
					{
						this.Trans.localPosition = pos;
						this.SyncPos();
					}
					if (setRot)
					{
						this.Trans.localRotation = rot;
					}
					if (setScale)
					{
						this.Trans.localScale = scale;
					}
				}
			}
			else
			{
				XEngineCommand xengineCommand = XSingleton<XEngineCommandMgr>.singleton.CreateCommand(XCallCommand.handler, this, -1);
				XObjAsyncData objAsyncData = XSingleton<XEngineCommandMgr>.singleton.GetObjAsyncData();
				objAsyncData.commandCb = XGameObject.SyncLocalPRSCmd;
				XLocalPRSAsyncData xlocalPRSAsyncData = CommonObjectPool<XLocalPRSAsyncData>.Get();
				xlocalPRSAsyncData.localPos = pos;
				if (setPos)
				{
					XLocalPRSAsyncData xlocalPRSAsyncData2 = xlocalPRSAsyncData;
					xlocalPRSAsyncData2.mask += 1;
				}
				xlocalPRSAsyncData.localRotation = rot;
				if (setRot)
				{
					XLocalPRSAsyncData xlocalPRSAsyncData3 = xlocalPRSAsyncData;
					xlocalPRSAsyncData3.mask += 2;
				}
				xlocalPRSAsyncData.localScale = scale;
				if (setScale)
				{
					XLocalPRSAsyncData xlocalPRSAsyncData4 = xlocalPRSAsyncData;
					xlocalPRSAsyncData4.mask += 4;
				}
				objAsyncData.data = xlocalPRSAsyncData;
				objAsyncData.resetCb = new ResetCallback(xlocalPRSAsyncData.Reset);
				xengineCommand.data = objAsyncData;
				xengineCommand.debugHandler = XCallCommand.debugHandler;
				XSingleton<XEngineCommandMgr>.singleton.AppendCommand(xengineCommand);
			}
		}

		public CollisionFlags Move(Vector3 motion)
		{
			bool flag = this.m_EnableCC && this.m_ccCache != null;
			CollisionFlags result;
			if (flag)
			{
				CollisionFlags collisionFlags = this.m_ccCache.Move(motion);
				this.SyncPos();
				result = collisionFlags;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public void SyncPos()
		{
			bool flag = this.Trans != null;
			if (flag)
			{
				this.m_Position = this.Trans.position;
			}
		}

		public void GetRender(List<Renderer> render)
		{
			bool flag = this.m_GameObject != null;
			if (flag)
			{
				this.m_GameObject.GetComponentsInChildren<Renderer>(render);
			}
		}

		public void SyncPhysicBox(Vector3 center, Vector3 size)
		{
			bool flag = this.m_EnableBC && this.m_bcCache != null;
			if (flag)
			{
				this.m_bcCache.center = center;
				this.m_bcCache.size = size;
			}
		}

		private static void _SetPhysicTransform(XGameObject gameObject, object obj, int commandID)
		{
			XGameObject xgameObject = obj as XGameObject;
			bool flag = xgameObject.m_EnableCC && xgameObject.m_ccCache == null;
			if (flag)
			{
				xgameObject.m_ccCache = gameObject.m_ccCache;
				bool flag2 = xgameObject.m_ccCache != null;
				if (flag2)
				{
					xgameObject.m_ccCache.enabled = true;
				}
				bool flag3 = xgameObject.m_bcCache != null;
				if (flag3)
				{
					xgameObject.m_bcCache.enabled = false;
				}
			}
			else
			{
				bool flag4 = xgameObject.m_EnableBC && xgameObject.m_bcCache == null;
				if (flag4)
				{
					xgameObject.m_bcCache = gameObject.m_bcCache;
					bool flag5 = xgameObject.m_bcCache != null;
					if (flag5)
					{
						xgameObject.m_bcCache.enabled = true;
					}
					bool flag6 = xgameObject.m_ccCache != null;
					if (flag6)
					{
						xgameObject.m_ccCache.enabled = false;
					}
				}
			}
			xgameObject.m_TransformCache = gameObject.Trans;
		}

		public void TransformPhysic(XGameObject src)
		{
			src.CallCommand(XGameObject._setPhysicTransformCb, this, -1, false);
		}

		public void ClearTransformPhysic()
		{
			this.m_ccCache = null;
			this.m_bcCache = null;
			this.m_TransformCache = ((this.m_GameObject == null) ? null : this.m_GameObject.transform);
		}

		private static void _SetRenderLayer(XGameObject gameObject, object obj, int commandID)
		{
			bool flag = gameObject != null && gameObject.m_GameObject != null;
			if (flag)
			{
				XCommon.tmpRender.Clear();
				gameObject.m_GameObject.GetComponentsInChildren<Renderer>(XCommon.tmpRender);
				int count = XCommon.tmpRender.Count;
				for (int i = 0; i < count; i++)
				{
					Renderer renderer = XCommon.tmpRender[i];
					renderer.gameObject.layer = gameObject.Layer;
				}
				XCommon.tmpRender.Clear();
			}
		}

		public void SetRenderLayer(int layer)
		{
			this.m_Layer = layer;
			this.CallCommand(XGameObject._setRenderLayerCb, this, -1, false);
		}

		public T AddComponent<T>() where T : Component
		{
			bool flag = this.m_GameObject != null;
			T result;
			if (flag)
			{
				T t = this.m_GameObject.GetComponent<T>();
				bool flag2 = t == null;
				if (flag2)
				{
					t = this.m_GameObject.AddComponent<T>();
				}
				result = t;
			}
			else
			{
				result = default(T);
			}
			return result;
		}

		public Component AddComponent(EComponentType componentType)
		{
			bool flag = this.m_GameObject != null;
			Component result;
			if (flag)
			{
				Component component = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.AddComponent(this.m_GameObject, componentType);
				result = component;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public void Update()
		{
			this.SyncPos();
			bool flag = this.m_Ator != null && this.m_Ator.IsLoaded;
			if (flag)
			{
				bool flag2 = (int)this.m_UpdateFrame < XGameObject.delayFrameCount;
				if (flag2)
				{
					this.m_UpdateFrame += 1;
				}
				else
				{
					bool flag3 = (int)this.m_UpdateFrame == XGameObject.delayFrameCount;
					if (flag3)
					{
						this.m_UpdateFrame += 1;
						XAnimator.Update(this.m_Ator);
					}
				}
			}
		}

		private bool m_Valid = false;

		private Vector3 m_Position = XResourceLoaderMgr.Far_Far_Away;

		private Quaternion m_Rotation = Quaternion.identity;

		private Vector3 m_Scale = Vector3.one;

		private bool m_EnableCC = false;

		private bool m_EnableBC = false;

		private float m_CCStepOffset = 0f;

		private bool m_UpdateWhenOffscreen = false;

		private bool m_EnableRender = true;

		private string m_TagFilter = "";

		private string m_Tag = "Untagged";

		private int m_Layer = 0;

		private ulong m_UID = 0UL;

		private string m_Name = "";

		private Transform m_TransformCache = null;

		private SkinnedMeshRenderer m_SkinMeshRenderCache = null;

		private CharacterController m_ccCache = null;

		private BoxCollider m_bcCache = null;

		public int objID = -1;

		public static int globalObjID = 0;

		public static string EmptyObject = "";

		private XAnimator m_Ator = null;

		private short m_UpdateFrame = 0;

		private LoadAsyncTask loadTask = null;

		private LoadCallBack loadCb = null;

		private XEngineCommand afterLoadCommand = null;

		private short m_LoadStatus = 0;

		private int m_LoadFinishCbFlag = 0;

		private static CommandCallback SyncSyncSetParentTransCmd = new CommandCallback(XGameObject.SyncSetParentTrans);

		private static CommandCallback SyncLocalPRSCmd = new CommandCallback(XGameObject.SyncLocalPRS);

		private static LoadCallback[] loadCallbacks = null;

		private static CommandCallback _setPhysicTransformCb = new CommandCallback(XGameObject._SetPhysicTransform);

		private static CommandCallback _setRenderLayerCb = new CommandCallback(XGameObject._SetRenderLayer);

		public static int delayFrameCount = 100;

		private enum ECallbackCmd
		{

			ESyncPosition = 1,

			ESyncRotation,

			ESyncScale = 4,

			ESyncLayer = 8,

			ESyncCCEnable = 16,

			ESyncBCEnable = 32,

			ESyncUpdateWhenOffscreen = 64,

			ESyncActive = 128,

			ESyncTag = 256,

			ESyncCCStepOffset = 512
		}
	}
}
