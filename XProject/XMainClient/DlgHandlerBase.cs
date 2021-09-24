using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	public abstract class DlgHandlerBase : IDlgHandlerMgr
	{

		public bool bLoaded
		{
			get
			{
				return this.m_bLoaded;
			}
		}

		public DlgHandlerBase()
		{
			this.m_DlgHandlerMgr = new DlgHandlerMgr();
		}

		protected virtual string FileName
		{
			get
			{
				return string.Empty;
			}
		}

		public virtual bool has3DAvatar
		{
			get
			{
				return false;
			}
		}

		protected virtual Vector3 OffSet
		{
			get
			{
				return Vector3.zero;
			}
		}

		protected virtual Transform parent
		{
			get
			{
				return (this.m_parent == null && this.m_gameObject != null) ? this.m_gameObject.transform.parent : this.m_parent;
			}
			set
			{
				this.m_parent = value;
				bool flag = this.m_gameObject != null;
				if (flag)
				{
					this.m_gameObject.transform.parent = this.m_parent;
				}
			}
		}

		public virtual void OnUpdate()
		{
			this.HandlerMgr.OnUpdate();
		}

		public virtual void OnUnload()
		{
		}

		public void UnLoad()
		{
			bool flag = !this.m_bLoaded;
			if (!flag)
			{
				this.UnRegisterEvent();
				ILuaEngine xluaEngine = XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine;
				xluaEngine.hotfixMgr.TryFixHandler(HotfixMode.UNLOAD, this.luaFileName, this.m_gameObject);
				this.OnUnload();
				this.m_loadUIAsynHandler = null;
				this.m_handlerState = DlgHandlerBase.HandlerState.Dispose;
				bool bDelayInited = this.m_bDelayInited;
				if (bDelayInited)
				{
					this._OnDelayUnload();
					this.m_bDelayInited = false;
				}
				bool flag2 = this.m_DlgHandlerMgr != null;
				if (flag2)
				{
					this.m_DlgHandlerMgr.Unload();
					this.m_DlgHandlerMgr = null;
				}
				bool isLoad = this.m_isLoad;
				if (isLoad)
				{
					XResourceLoaderMgr.SafeDestroy(ref this.m_gameObject, false);
					this.m_isLoad = false;
				}
				this.m_bLoaded = false;
			}
		}

		protected string luaFileName
		{
			get
			{
				return base.GetType().Name;
			}
		}

		public bool IsVisible()
		{
			return this.active;
		}

		public bool activeSelf
		{
			get
			{
				return this.m_bLoaded && this.m_gameObject != null && this.m_gameObject.activeSelf;
			}
		}

		public virtual bool active
		{
			get
			{
				return this.m_bLoaded && this.m_gameObject != null && this.m_gameObject.activeInHierarchy;
			}
		}

		public void SetVisible(bool bvisible)
		{
			this.m_visible = bvisible;
			if (bvisible)
			{
				this.Show();
			}
			else
			{
				this.ExcuteHide();
			}
		}

		public GameObject PanelObject
		{
			get
			{
				return this.m_gameObject;
			}
			set
			{
				bool flag = value != null && (this.m_gameObject == null || this.m_handlerState == DlgHandlerBase.HandlerState.Setup || this.m_handlerState == DlgHandlerBase.HandlerState.Error);
				if (flag)
				{
					this.m_gameObject = value;
					this.m_transform = this.m_gameObject.transform;
					this.m_parent = this.m_gameObject.transform.parent;
					this.m_gameObject.SetActive(true);
					this.Loaded();
				}
				else
				{
					bool flag2 = value == null;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("GameObject is NULL!", null, null, null, null, null);
					}
					else
					{
						XSingleton<XDebug>.singleton.AddErrorLog("GameObject is exist!", null, null, null, null, null);
					}
				}
			}
		}

		public Transform transform
		{
			get
			{
				return this.m_transform;
			}
		}

		public DlgHandlerMgr HandlerMgr
		{
			get
			{
				return this.m_DlgHandlerMgr;
			}
		}

		protected virtual void Init()
		{
		}

		public virtual void RegisterEvent()
		{
		}

		public virtual void UnRegisterEvent()
		{
		}

		protected virtual void OnShow()
		{
		}

		protected virtual void OnHide()
		{
		}

		public Component FindInChild(string ComponentName, string behaivorPath = "")
		{
			Transform transform = this.FindChild(behaivorPath);
			bool flag = transform == null;
			Component result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = transform.GetComponent(ComponentName);
			}
			return result;
		}

		public Transform FindChild(string behaivorPath = "")
		{
			return (this.m_transform == null) ? null : this.m_transform.FindChild(behaivorPath);
		}

		private void Show()
		{
			bool flag = this.m_handlerState == DlgHandlerBase.HandlerState.Setup;
			if (flag)
			{
				this.Load();
			}
			else
			{
				bool flag2 = this.m_handlerState == DlgHandlerBase.HandlerState.Inited || this.m_handlerState == DlgHandlerBase.HandlerState.Hide;
				if (flag2)
				{
					this.ExcuteShow();
				}
			}
		}

		private void Load()
		{
			this.m_handlerState = DlgHandlerBase.HandlerState.Loading;
			bool flag = !string.IsNullOrEmpty(this.FileName);
			if (flag)
			{
				this.m_isLoad = true;
				bool flag2 = this.m_loadUIAsynHandler == null;
				if (flag2)
				{
					this.m_loadUIAsynHandler = new LoadUIFinishedEventHandler(this.LoadUIFinish);
				}
				XSingleton<UIManager>.singleton.LoadUI(this.FileName, this.m_loadUIAsynHandler);
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Handler FileName is Empty!", null, null, null, null, null);
			}
		}

		private void LoadUIFinish(string location)
		{
			this.m_gameObject = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/" + location, true, false) as GameObject);
			bool flag = this.m_gameObject != null;
			if (flag)
			{
				this.m_handlerState = DlgHandlerBase.HandlerState.Loaded;
				this.m_transform = this.m_gameObject.transform;
				this.m_gameObject.name = this.m_gameObject.name.Replace("(Clone)", "");
				this.m_gameObject.transform.parent = this.m_parent;
				this.m_gameObject.transform.localPosition = this.OffSet;
				this.m_gameObject.transform.localScale = Vector3.one;
				this.m_gameObject.SetActive(true);
				this.Loaded();
				this.ExcuteShow();
				this.m_bLoaded = true;
			}
			else
			{
				this.m_handlerState = DlgHandlerBase.HandlerState.Error;
				XSingleton<XDebug>.singleton.AddErrorLog(XSingleton<XCommon>.singleton.StringCombine(location, " load error!"), null, null, null, null, null);
			}
		}

		private void ExcuteShow()
		{
			bool visible = this.m_visible;
			if (visible)
			{
				bool flag = this.m_handlerState == DlgHandlerBase.HandlerState.Inited || this.m_handlerState == DlgHandlerBase.HandlerState.Hide;
				if (flag)
				{
					bool flag2 = this.m_gameObject == null;
					if (!flag2)
					{
						this.m_gameObject.SetActive(true);
						this.m_handlerState = DlgHandlerBase.HandlerState.Show;
						bool flag3 = !this.m_bDelayInited;
						if (flag3)
						{
							this._DelayInit();
							this.m_bDelayInited = true;
						}
						this.RegisterEvent();
						ILuaEngine xluaEngine = XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine;
						bool flag4 = !xluaEngine.hotfixMgr.TryFixHandler(HotfixMode.BEFORE, this.luaFileName, this.m_gameObject);
						if (flag4)
						{
							this.OnShow();
							xluaEngine.hotfixMgr.TryFixHandler(HotfixMode.AFTER, this.luaFileName, this.m_gameObject);
						}
					}
				}
			}
			else
			{
				this.ExcuteHide();
			}
		}

		private void Loaded()
		{
			this.Initialize();
		}

		private void Initialize()
		{
			this.Init();
			this.m_bLoaded = true;
			this.m_handlerState = DlgHandlerBase.HandlerState.Inited;
		}

		private void ExcuteHide()
		{
			bool flag = this.m_handlerState == DlgHandlerBase.HandlerState.Show || this.m_handlerState == DlgHandlerBase.HandlerState.Inited;
			if (flag)
			{
				bool flag2 = this.m_gameObject == null;
				if (!flag2)
				{
					this.m_gameObject.SetActive(false);
					bool flag3 = this.m_handlerState == DlgHandlerBase.HandlerState.Show;
					if (flag3)
					{
						ILuaEngine xluaEngine = XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine;
						xluaEngine.hotfixMgr.TryFixHandler(HotfixMode.HIDE, this.luaFileName, this.m_gameObject);
						this.UnRegisterEvent();
						this.OnHide();
					}
					this.m_handlerState = DlgHandlerBase.HandlerState.Hide;
				}
			}
		}

		protected virtual void _OnDelayUnload()
		{
			this.m_bDelayInited = false;
		}

		protected virtual void _DelayInit()
		{
		}

		public virtual void StackRefresh()
		{
			bool flag = this.m_DlgHandlerMgr != null;
			if (flag)
			{
				this.m_DlgHandlerMgr.StackRefresh();
			}
		}

		public virtual void LeaveStackTop()
		{
			bool flag = this.m_DlgHandlerMgr != null;
			if (flag)
			{
				this.m_DlgHandlerMgr.LeaveStackTop();
			}
		}

		public virtual void RefreshData()
		{
		}

		protected void Alloc3DAvatarPool(string user, int maxCount = 1)
		{
			bool flag = this.m_dummPool < 0;
			if (flag)
			{
				this.m_dummPool = XSingleton<X3DAvatarMgr>.singleton.AllocDummyPool(user, maxCount);
			}
		}

		protected void Return3DAvatarPool()
		{
			XSingleton<X3DAvatarMgr>.singleton.ReturnDummyPool(this.m_dummPool);
			this.m_dummPool = -1;
		}

		public static T EnsureCreate<T>(ref T handler, Transform parent, bool visible = true, IDlgHandlerMgr handlerMgr = null) where T : DlgHandlerBase, new()
		{
			bool flag = parent == null;
			if (flag)
			{
				parent = XSingleton<UIManager>.singleton.UIRoot;
			}
			bool flag2 = handler == null;
			if (flag2)
			{
				handler = Activator.CreateInstance<T>();
				handler.parent = parent;
				handler.SetVisible(visible);
				bool flag3 = handlerMgr != null;
				if (flag3)
				{
					handlerMgr.HandlerMgr.Add(handler);
					handler.m_ParentHandlerMgr = handlerMgr.HandlerMgr;
				}
			}
			else
			{
				handler.parent = parent;
				handler.SetVisible(visible);
			}
			return handler;
		}

		public static T EnsureCreate<T>(ref T handler, GameObject panelObject, IDlgHandlerMgr parent = null, bool visible = true) where T : DlgHandlerBase, new()
		{
			bool flag = handler == null;
			if (flag)
			{
				handler = DlgHandlerBase.Create<T>(panelObject, parent, visible);
			}
			else
			{
				handler.SetVisible(visible);
			}
			return handler;
		}

		public static T Create<T>(GameObject panelObject, IDlgHandlerMgr parent, bool visible = true) where T : DlgHandlerBase, new()
		{
			T t = Activator.CreateInstance<T>();
			t.PanelObject = panelObject;
			t.m_bLoaded = true;
			t.SetVisible(visible);
			bool flag = parent != null;
			if (flag)
			{
				parent.HandlerMgr.Add(t);
				t.m_ParentHandlerMgr = parent.HandlerMgr;
			}
			return t;
		}

		public static void EnsureUnload<T>(ref T handler) where T : DlgHandlerBase
		{
			bool flag = handler != null && handler.m_bLoaded;
			if (flag)
			{
				handler.UnLoad();
				handler.m_bLoaded = false;
				bool flag2 = handler.m_ParentHandlerMgr != null;
				if (flag2)
				{
					handler.m_ParentHandlerMgr.Remove(handler);
				}
			}
			handler = default(T);
		}

		protected DlgHandlerBase.HandlerState m_handlerState = DlgHandlerBase.HandlerState.Setup;

		private LoadUIFinishedEventHandler m_loadUIAsynHandler;

		private bool m_bLoaded = false;

		private Transform m_parent;

		private GameObject m_gameObject;

		private Transform m_transform;

		private bool m_visible = false;

		private bool m_isLoad = false;

		protected bool m_bDelayInited = false;

		protected int m_dummPool = -1;

		private DlgHandlerMgr m_DlgHandlerMgr = null;

		protected DlgHandlerMgr m_ParentHandlerMgr = null;

		public enum HandlerState
		{

			Setup,

			Loading,

			Loaded,

			Inited,

			Show,

			Hide,

			Dispose,

			Error
		}
	}
}
