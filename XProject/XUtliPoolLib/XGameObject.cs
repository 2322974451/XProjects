using System;
using System.Collections.Generic;
using UnityEngine;
using XUpdater;

namespace XUtliPoolLib
{
	// Token: 0x020001F1 RID: 497
	public class XGameObject : XEngineObject
	{
		// Token: 0x06000B5D RID: 2909 RVA: 0x0003B04C File Offset: 0x0003924C
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

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000B5E RID: 2910 RVA: 0x0003B1FC File Offset: 0x000393FC
		// (set) Token: 0x06000B5F RID: 2911 RVA: 0x0003B214 File Offset: 0x00039414
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

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000B60 RID: 2912 RVA: 0x0003B228 File Offset: 0x00039428
		// (set) Token: 0x06000B61 RID: 2913 RVA: 0x0003B260 File Offset: 0x00039460
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

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000B62 RID: 2914 RVA: 0x0003B290 File Offset: 0x00039490
		// (set) Token: 0x06000B63 RID: 2915 RVA: 0x0003B2A8 File Offset: 0x000394A8
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

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000B64 RID: 2916 RVA: 0x0003B2BC File Offset: 0x000394BC
		// (set) Token: 0x06000B65 RID: 2917 RVA: 0x0003B2D4 File Offset: 0x000394D4
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

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000B66 RID: 2918 RVA: 0x0003B2E8 File Offset: 0x000394E8
		// (set) Token: 0x06000B67 RID: 2919 RVA: 0x0003B300 File Offset: 0x00039500
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

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000B68 RID: 2920 RVA: 0x0003B314 File Offset: 0x00039514
		// (set) Token: 0x06000B69 RID: 2921 RVA: 0x0003B32C File Offset: 0x0003952C
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

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000B6A RID: 2922 RVA: 0x0003B340 File Offset: 0x00039540
		// (set) Token: 0x06000B6B RID: 2923 RVA: 0x0003B358 File Offset: 0x00039558
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

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000B6C RID: 2924 RVA: 0x0003B36C File Offset: 0x0003956C
		// (set) Token: 0x06000B6D RID: 2925 RVA: 0x0003B384 File Offset: 0x00039584
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

		// Token: 0x170000DA RID: 218
		// (set) Token: 0x06000B6E RID: 2926 RVA: 0x0003B395 File Offset: 0x00039595
		public bool UpdateWhenOffscreen
		{
			set
			{
				this.m_UpdateWhenOffscreen = value;
				this.AppendUpdateWhenOffscreen();
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000B6F RID: 2927 RVA: 0x0003B3A8 File Offset: 0x000395A8
		// (set) Token: 0x06000B70 RID: 2928 RVA: 0x0003B3CA File Offset: 0x000395CA
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

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000B71 RID: 2929 RVA: 0x0003B3E0 File Offset: 0x000395E0
		// (set) Token: 0x06000B72 RID: 2930 RVA: 0x0003B402 File Offset: 0x00039602
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

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000B73 RID: 2931 RVA: 0x0003B420 File Offset: 0x00039620
		// (set) Token: 0x06000B74 RID: 2932 RVA: 0x0003B442 File Offset: 0x00039642
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

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000B75 RID: 2933 RVA: 0x0003B460 File Offset: 0x00039660
		// (set) Token: 0x06000B76 RID: 2934 RVA: 0x0003B478 File Offset: 0x00039678
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

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000B77 RID: 2935 RVA: 0x0003B48C File Offset: 0x0003968C
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

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000B78 RID: 2936 RVA: 0x0003B4E4 File Offset: 0x000396E4
		public XAnimator Ator
		{
			get
			{
				return this.m_Ator;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000B79 RID: 2937 RVA: 0x0003B4FC File Offset: 0x000396FC
		// (set) Token: 0x06000B7A RID: 2938 RVA: 0x0003B514 File Offset: 0x00039714
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

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000B7B RID: 2939 RVA: 0x0003B520 File Offset: 0x00039720
		// (set) Token: 0x06000B7C RID: 2940 RVA: 0x0003B538 File Offset: 0x00039738
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

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000B7D RID: 2941 RVA: 0x0003B574 File Offset: 0x00039774
		public bool IsValid
		{
			get
			{
				return this.m_Valid;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000B7E RID: 2942 RVA: 0x0003B58C File Offset: 0x0003978C
		public bool IsVisible
		{
			get
			{
				bool flag = this.m_SkinMeshRenderCache != null;
				return flag && this.m_SkinMeshRenderCache.isVisible;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000B7F RID: 2943 RVA: 0x0003B5C0 File Offset: 0x000397C0
		public bool IsNotEmptyObject
		{
			get
			{
				return !string.IsNullOrEmpty(this.m_Location);
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000B80 RID: 2944 RVA: 0x0003B5E0 File Offset: 0x000397E0
		public bool HasSkin
		{
			get
			{
				return this.m_SkinMeshRenderCache != null;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000B81 RID: 2945 RVA: 0x0003B600 File Offset: 0x00039800
		public SkinnedMeshRenderer SMR
		{
			get
			{
				return this.m_SkinMeshRenderCache;
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000B82 RID: 2946 RVA: 0x0003B618 File Offset: 0x00039818
		public bool IsLoaded
		{
			get
			{
				return this.m_LoadStatus == 1;
			}
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x0003B634 File Offset: 0x00039834
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

		// Token: 0x06000B84 RID: 2948 RVA: 0x0003B804 File Offset: 0x00039A04
		public void LoadAsync(string location, bool usePool)
		{
			this.loadTask = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefabAsync(location, this.loadCb, null, usePool);
			bool isLoaded = this.IsLoaded;
			if (isLoaded)
			{
				this.loadTask = null;
			}
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x0003B840 File Offset: 0x00039A40
		public void Load(string location, bool usePool)
		{
			GameObject obj = XSingleton<XResourceLoaderMgr>.singleton.CreateFromAsset<GameObject>(location, ".prefab", usePool, false);
			this.LoadFinish(obj, null);
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x0003B86C File Offset: 0x00039A6C
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

		// Token: 0x06000B87 RID: 2951 RVA: 0x0003B9F4 File Offset: 0x00039BF4
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

		// Token: 0x06000B88 RID: 2952 RVA: 0x0003BA34 File Offset: 0x00039C34
		private bool IsCbFlag(int index)
		{
			int num = 1 << index;
			return (this.m_LoadFinishCbFlag & num) != 0;
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x0003BA58 File Offset: 0x00039C58
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

		// Token: 0x06000B8A RID: 2954 RVA: 0x0003BA94 File Offset: 0x00039C94
		public static XGameObject CreateXGameObject(string location, Vector3 position, Quaternion rotation, bool async = true, bool usePool = true)
		{
			XGameObject xgameObject = XGameObject.CreateXGameObject(location, async, usePool);
			xgameObject.Position = position;
			xgameObject.Rotation = rotation;
			return xgameObject;
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x0003BAC4 File Offset: 0x00039CC4
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

		// Token: 0x06000B8C RID: 2956 RVA: 0x0003BB78 File Offset: 0x00039D78
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

		// Token: 0x06000B8D RID: 2957 RVA: 0x0003BC0C File Offset: 0x00039E0C
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

		// Token: 0x06000B8E RID: 2958 RVA: 0x0003BC60 File Offset: 0x00039E60
		private static void SyncPosition(XGameObject gameObject)
		{
			Transform trans = gameObject.Trans;
			bool flag = trans != null;
			if (flag)
			{
				trans.position = gameObject.m_Position;
			}
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x0003BC90 File Offset: 0x00039E90
		private static void SyncRotation(XGameObject gameObject)
		{
			Transform trans = gameObject.Trans;
			bool flag = trans != null;
			if (flag)
			{
				trans.rotation = gameObject.m_Rotation;
			}
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x0003BCC0 File Offset: 0x00039EC0
		private static void SyncScale(XGameObject gameObject)
		{
			Transform trans = gameObject.Trans;
			bool flag = trans != null;
			if (flag)
			{
				trans.localScale = gameObject.m_Scale;
			}
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x0003BCF0 File Offset: 0x00039EF0
		private static void SyncLayer(XGameObject gameObject)
		{
			bool flag = gameObject.m_GameObject != null;
			if (flag)
			{
				gameObject.m_GameObject.layer = gameObject.m_Layer;
			}
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x0003BD24 File Offset: 0x00039F24
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

		// Token: 0x06000B93 RID: 2963 RVA: 0x0003BD88 File Offset: 0x00039F88
		private static void SyncCCEnable(XGameObject gameObject)
		{
			bool flag = gameObject.m_ccCache != null;
			if (flag)
			{
				gameObject.m_ccCache.enabled = gameObject.m_EnableCC;
			}
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x0003BDBC File Offset: 0x00039FBC
		private static void SyncBCEnable(XGameObject gameObject)
		{
			bool flag = gameObject.m_bcCache != null;
			if (flag)
			{
				gameObject.m_bcCache.enabled = gameObject.m_EnableBC;
			}
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x0003BDF0 File Offset: 0x00039FF0
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

		// Token: 0x06000B96 RID: 2966 RVA: 0x0003BE6C File Offset: 0x0003A06C
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

		// Token: 0x06000B97 RID: 2967 RVA: 0x0003BF40 File Offset: 0x0003A140
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

		// Token: 0x06000B98 RID: 2968 RVA: 0x0003BF80 File Offset: 0x0003A180
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

		// Token: 0x06000B99 RID: 2969 RVA: 0x0003BFDC File Offset: 0x0003A1DC
		private static void SyncSetParentTrans(XGameObject gameObject, object obj, int commandID)
		{
			bool flag = gameObject.Trans != null;
			if (flag)
			{
				gameObject.Trans.parent = (obj as Transform);
			}
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x0003C010 File Offset: 0x0003A210
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

		// Token: 0x06000B9B RID: 2971 RVA: 0x0003C0B0 File Offset: 0x0003A2B0
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

		// Token: 0x06000B9C RID: 2972 RVA: 0x0003C120 File Offset: 0x0003A320
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

		// Token: 0x06000B9D RID: 2973 RVA: 0x0003C150 File Offset: 0x0003A350
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

		// Token: 0x06000B9E RID: 2974 RVA: 0x0003C180 File Offset: 0x0003A380
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

		// Token: 0x06000B9F RID: 2975 RVA: 0x0003C1B0 File Offset: 0x0003A3B0
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

		// Token: 0x06000BA0 RID: 2976 RVA: 0x0003C1E0 File Offset: 0x0003A3E0
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

		// Token: 0x06000BA1 RID: 2977 RVA: 0x0003C214 File Offset: 0x0003A414
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

		// Token: 0x06000BA2 RID: 2978 RVA: 0x0003C244 File Offset: 0x0003A444
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

		// Token: 0x06000BA3 RID: 2979 RVA: 0x0003C274 File Offset: 0x0003A474
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

		// Token: 0x06000BA4 RID: 2980 RVA: 0x0003C2A4 File Offset: 0x0003A4A4
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

		// Token: 0x06000BA5 RID: 2981 RVA: 0x0003C2D8 File Offset: 0x0003A4D8
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

		// Token: 0x06000BA6 RID: 2982 RVA: 0x0003C37C File Offset: 0x0003A57C
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

		// Token: 0x06000BA7 RID: 2983 RVA: 0x0003C43C File Offset: 0x0003A63C
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

		// Token: 0x06000BA8 RID: 2984 RVA: 0x0003C4C0 File Offset: 0x0003A6C0
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

		// Token: 0x06000BA9 RID: 2985 RVA: 0x0003C534 File Offset: 0x0003A734
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

		// Token: 0x06000BAA RID: 2986 RVA: 0x0003C57C File Offset: 0x0003A77C
		public GameObject Get()
		{
			return this.m_GameObject;
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x0003C594 File Offset: 0x0003A794
		public void Rotate(Vector3 axis, float degree)
		{
			bool flag = this.Trans != null;
			if (flag)
			{
				this.Trans.Rotate(axis, degree);
			}
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x0003C5C4 File Offset: 0x0003A7C4
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

		// Token: 0x06000BAD RID: 2989 RVA: 0x0003C614 File Offset: 0x0003A814
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

		// Token: 0x06000BAE RID: 2990 RVA: 0x0003C75C File Offset: 0x0003A95C
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

		// Token: 0x06000BAF RID: 2991 RVA: 0x0003C7A4 File Offset: 0x0003A9A4
		public void SyncPos()
		{
			bool flag = this.Trans != null;
			if (flag)
			{
				this.m_Position = this.Trans.position;
			}
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x0003C7D8 File Offset: 0x0003A9D8
		public void GetRender(List<Renderer> render)
		{
			bool flag = this.m_GameObject != null;
			if (flag)
			{
				this.m_GameObject.GetComponentsInChildren<Renderer>(render);
			}
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x0003C808 File Offset: 0x0003AA08
		public void SyncPhysicBox(Vector3 center, Vector3 size)
		{
			bool flag = this.m_EnableBC && this.m_bcCache != null;
			if (flag)
			{
				this.m_bcCache.center = center;
				this.m_bcCache.size = size;
			}
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0003C850 File Offset: 0x0003AA50
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

		// Token: 0x06000BB3 RID: 2995 RVA: 0x0003C93F File Offset: 0x0003AB3F
		public void TransformPhysic(XGameObject src)
		{
			src.CallCommand(XGameObject._setPhysicTransformCb, this, -1, false);
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x0003C951 File Offset: 0x0003AB51
		public void ClearTransformPhysic()
		{
			this.m_ccCache = null;
			this.m_bcCache = null;
			this.m_TransformCache = ((this.m_GameObject == null) ? null : this.m_GameObject.transform);
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x0003C984 File Offset: 0x0003AB84
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

		// Token: 0x06000BB6 RID: 2998 RVA: 0x0003CA0E File Offset: 0x0003AC0E
		public void SetRenderLayer(int layer)
		{
			this.m_Layer = layer;
			this.CallCommand(XGameObject._setRenderLayerCb, this, -1, false);
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x0003CA28 File Offset: 0x0003AC28
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

		// Token: 0x06000BB8 RID: 3000 RVA: 0x0003CA84 File Offset: 0x0003AC84
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

		// Token: 0x06000BB9 RID: 3001 RVA: 0x0003CAC4 File Offset: 0x0003ACC4
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

		// Token: 0x04000592 RID: 1426
		private bool m_Valid = false;

		// Token: 0x04000593 RID: 1427
		private Vector3 m_Position = XResourceLoaderMgr.Far_Far_Away;

		// Token: 0x04000594 RID: 1428
		private Quaternion m_Rotation = Quaternion.identity;

		// Token: 0x04000595 RID: 1429
		private Vector3 m_Scale = Vector3.one;

		// Token: 0x04000596 RID: 1430
		private bool m_EnableCC = false;

		// Token: 0x04000597 RID: 1431
		private bool m_EnableBC = false;

		// Token: 0x04000598 RID: 1432
		private float m_CCStepOffset = 0f;

		// Token: 0x04000599 RID: 1433
		private bool m_UpdateWhenOffscreen = false;

		// Token: 0x0400059A RID: 1434
		private bool m_EnableRender = true;

		// Token: 0x0400059B RID: 1435
		private string m_TagFilter = "";

		// Token: 0x0400059C RID: 1436
		private string m_Tag = "Untagged";

		// Token: 0x0400059D RID: 1437
		private int m_Layer = 0;

		// Token: 0x0400059E RID: 1438
		private ulong m_UID = 0UL;

		// Token: 0x0400059F RID: 1439
		private string m_Name = "";

		// Token: 0x040005A0 RID: 1440
		private Transform m_TransformCache = null;

		// Token: 0x040005A1 RID: 1441
		private SkinnedMeshRenderer m_SkinMeshRenderCache = null;

		// Token: 0x040005A2 RID: 1442
		private CharacterController m_ccCache = null;

		// Token: 0x040005A3 RID: 1443
		private BoxCollider m_bcCache = null;

		// Token: 0x040005A4 RID: 1444
		public int objID = -1;

		// Token: 0x040005A5 RID: 1445
		public static int globalObjID = 0;

		// Token: 0x040005A6 RID: 1446
		public static string EmptyObject = "";

		// Token: 0x040005A7 RID: 1447
		private XAnimator m_Ator = null;

		// Token: 0x040005A8 RID: 1448
		private short m_UpdateFrame = 0;

		// Token: 0x040005A9 RID: 1449
		private LoadAsyncTask loadTask = null;

		// Token: 0x040005AA RID: 1450
		private LoadCallBack loadCb = null;

		// Token: 0x040005AB RID: 1451
		private XEngineCommand afterLoadCommand = null;

		// Token: 0x040005AC RID: 1452
		private short m_LoadStatus = 0;

		// Token: 0x040005AD RID: 1453
		private int m_LoadFinishCbFlag = 0;

		// Token: 0x040005AE RID: 1454
		private static CommandCallback SyncSyncSetParentTransCmd = new CommandCallback(XGameObject.SyncSetParentTrans);

		// Token: 0x040005AF RID: 1455
		private static CommandCallback SyncLocalPRSCmd = new CommandCallback(XGameObject.SyncLocalPRS);

		// Token: 0x040005B0 RID: 1456
		private static LoadCallback[] loadCallbacks = null;

		// Token: 0x040005B1 RID: 1457
		private static CommandCallback _setPhysicTransformCb = new CommandCallback(XGameObject._SetPhysicTransform);

		// Token: 0x040005B2 RID: 1458
		private static CommandCallback _setRenderLayerCb = new CommandCallback(XGameObject._SetRenderLayer);

		// Token: 0x040005B3 RID: 1459
		public static int delayFrameCount = 100;

		// Token: 0x020003A5 RID: 933
		private enum ECallbackCmd
		{
			// Token: 0x0400104C RID: 4172
			ESyncPosition = 1,
			// Token: 0x0400104D RID: 4173
			ESyncRotation,
			// Token: 0x0400104E RID: 4174
			ESyncScale = 4,
			// Token: 0x0400104F RID: 4175
			ESyncLayer = 8,
			// Token: 0x04001050 RID: 4176
			ESyncCCEnable = 16,
			// Token: 0x04001051 RID: 4177
			ESyncBCEnable = 32,
			// Token: 0x04001052 RID: 4178
			ESyncUpdateWhenOffscreen = 64,
			// Token: 0x04001053 RID: 4179
			ESyncActive = 128,
			// Token: 0x04001054 RID: 4180
			ESyncTag = 256,
			// Token: 0x04001055 RID: 4181
			ESyncCCStepOffset = 512
		}
	}
}
