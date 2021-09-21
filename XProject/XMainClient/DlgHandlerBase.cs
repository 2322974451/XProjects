using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F12 RID: 3858
	public abstract class DlgHandlerBase : IDlgHandlerMgr
	{
		// Token: 0x17003598 RID: 13720
		// (get) Token: 0x0600CCAE RID: 52398 RVA: 0x002F2C34 File Offset: 0x002F0E34
		public bool bLoaded
		{
			get
			{
				return this.m_bLoaded;
			}
		}

		// Token: 0x0600CCAF RID: 52399 RVA: 0x002F2C4C File Offset: 0x002F0E4C
		public DlgHandlerBase()
		{
			this.m_DlgHandlerMgr = new DlgHandlerMgr();
		}

		// Token: 0x17003599 RID: 13721
		// (get) Token: 0x0600CCB0 RID: 52400 RVA: 0x002F2CA4 File Offset: 0x002F0EA4
		protected virtual string FileName
		{
			get
			{
				return string.Empty;
			}
		}

		// Token: 0x1700359A RID: 13722
		// (get) Token: 0x0600CCB1 RID: 52401 RVA: 0x002F2CBC File Offset: 0x002F0EBC
		public virtual bool has3DAvatar
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700359B RID: 13723
		// (get) Token: 0x0600CCB2 RID: 52402 RVA: 0x002F2CD0 File Offset: 0x002F0ED0
		protected virtual Vector3 OffSet
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x1700359C RID: 13724
		// (get) Token: 0x0600CCB3 RID: 52403 RVA: 0x002F2CE8 File Offset: 0x002F0EE8
		// (set) Token: 0x0600CCB4 RID: 52404 RVA: 0x002F2D30 File Offset: 0x002F0F30
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

		// Token: 0x0600CCB5 RID: 52405 RVA: 0x002F2D6C File Offset: 0x002F0F6C
		public virtual void OnUpdate()
		{
			this.HandlerMgr.OnUpdate();
		}

		// Token: 0x0600CCB6 RID: 52406 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnUnload()
		{
		}

		// Token: 0x0600CCB7 RID: 52407 RVA: 0x002F2D7C File Offset: 0x002F0F7C
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

		// Token: 0x1700359D RID: 13725
		// (get) Token: 0x0600CCB8 RID: 52408 RVA: 0x002F2E44 File Offset: 0x002F1044
		protected string luaFileName
		{
			get
			{
				return base.GetType().Name;
			}
		}

		// Token: 0x0600CCB9 RID: 52409 RVA: 0x002F2E64 File Offset: 0x002F1064
		public bool IsVisible()
		{
			return this.active;
		}

		// Token: 0x1700359E RID: 13726
		// (get) Token: 0x0600CCBA RID: 52410 RVA: 0x002F2E7C File Offset: 0x002F107C
		public bool activeSelf
		{
			get
			{
				return this.m_bLoaded && this.m_gameObject != null && this.m_gameObject.activeSelf;
			}
		}

		// Token: 0x1700359F RID: 13727
		// (get) Token: 0x0600CCBB RID: 52411 RVA: 0x002F2EB4 File Offset: 0x002F10B4
		public virtual bool active
		{
			get
			{
				return this.m_bLoaded && this.m_gameObject != null && this.m_gameObject.activeInHierarchy;
			}
		}

		// Token: 0x0600CCBC RID: 52412 RVA: 0x002F2EEC File Offset: 0x002F10EC
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

		// Token: 0x170035A0 RID: 13728
		// (get) Token: 0x0600CCBD RID: 52413 RVA: 0x002F2F18 File Offset: 0x002F1118
		// (set) Token: 0x0600CCBE RID: 52414 RVA: 0x002F2F30 File Offset: 0x002F1130
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

		// Token: 0x170035A1 RID: 13729
		// (get) Token: 0x0600CCBF RID: 52415 RVA: 0x002F2FF0 File Offset: 0x002F11F0
		public Transform transform
		{
			get
			{
				return this.m_transform;
			}
		}

		// Token: 0x170035A2 RID: 13730
		// (get) Token: 0x0600CCC0 RID: 52416 RVA: 0x002F3008 File Offset: 0x002F1208
		public DlgHandlerMgr HandlerMgr
		{
			get
			{
				return this.m_DlgHandlerMgr;
			}
		}

		// Token: 0x0600CCC1 RID: 52417 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void Init()
		{
		}

		// Token: 0x0600CCC2 RID: 52418 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void RegisterEvent()
		{
		}

		// Token: 0x0600CCC3 RID: 52419 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void UnRegisterEvent()
		{
		}

		// Token: 0x0600CCC4 RID: 52420 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnShow()
		{
		}

		// Token: 0x0600CCC5 RID: 52421 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnHide()
		{
		}

		// Token: 0x0600CCC6 RID: 52422 RVA: 0x002F3020 File Offset: 0x002F1220
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

		// Token: 0x0600CCC7 RID: 52423 RVA: 0x002F3050 File Offset: 0x002F1250
		public Transform FindChild(string behaivorPath = "")
		{
			return (this.m_transform == null) ? null : this.m_transform.FindChild(behaivorPath);
		}

		// Token: 0x0600CCC8 RID: 52424 RVA: 0x002F3080 File Offset: 0x002F1280
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

		// Token: 0x0600CCC9 RID: 52425 RVA: 0x002F30C8 File Offset: 0x002F12C8
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

		// Token: 0x0600CCCA RID: 52426 RVA: 0x002F3148 File Offset: 0x002F1348
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

		// Token: 0x0600CCCB RID: 52427 RVA: 0x002F325C File Offset: 0x002F145C
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

		// Token: 0x0600CCCC RID: 52428 RVA: 0x002F333F File Offset: 0x002F153F
		private void Loaded()
		{
			this.Initialize();
		}

		// Token: 0x0600CCCD RID: 52429 RVA: 0x002F3349 File Offset: 0x002F1549
		private void Initialize()
		{
			this.Init();
			this.m_bLoaded = true;
			this.m_handlerState = DlgHandlerBase.HandlerState.Inited;
		}

		// Token: 0x0600CCCE RID: 52430 RVA: 0x002F3364 File Offset: 0x002F1564
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

		// Token: 0x0600CCCF RID: 52431 RVA: 0x002F33F4 File Offset: 0x002F15F4
		protected virtual void _OnDelayUnload()
		{
			this.m_bDelayInited = false;
		}

		// Token: 0x0600CCD0 RID: 52432 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void _DelayInit()
		{
		}

		// Token: 0x0600CCD1 RID: 52433 RVA: 0x002F3400 File Offset: 0x002F1600
		public virtual void StackRefresh()
		{
			bool flag = this.m_DlgHandlerMgr != null;
			if (flag)
			{
				this.m_DlgHandlerMgr.StackRefresh();
			}
		}

		// Token: 0x0600CCD2 RID: 52434 RVA: 0x002F342C File Offset: 0x002F162C
		public virtual void LeaveStackTop()
		{
			bool flag = this.m_DlgHandlerMgr != null;
			if (flag)
			{
				this.m_DlgHandlerMgr.LeaveStackTop();
			}
		}

		// Token: 0x0600CCD3 RID: 52435 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void RefreshData()
		{
		}

		// Token: 0x0600CCD4 RID: 52436 RVA: 0x002F3458 File Offset: 0x002F1658
		protected void Alloc3DAvatarPool(string user, int maxCount = 1)
		{
			bool flag = this.m_dummPool < 0;
			if (flag)
			{
				this.m_dummPool = XSingleton<X3DAvatarMgr>.singleton.AllocDummyPool(user, maxCount);
			}
		}

		// Token: 0x0600CCD5 RID: 52437 RVA: 0x002F3487 File Offset: 0x002F1687
		protected void Return3DAvatarPool()
		{
			XSingleton<X3DAvatarMgr>.singleton.ReturnDummyPool(this.m_dummPool);
			this.m_dummPool = -1;
		}

		// Token: 0x0600CCD6 RID: 52438 RVA: 0x002F34A4 File Offset: 0x002F16A4
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

		// Token: 0x0600CCD7 RID: 52439 RVA: 0x002F3568 File Offset: 0x002F1768
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

		// Token: 0x0600CCD8 RID: 52440 RVA: 0x002F35B0 File Offset: 0x002F17B0
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

		// Token: 0x0600CCD9 RID: 52441 RVA: 0x002F361C File Offset: 0x002F181C
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

		// Token: 0x04005B0C RID: 23308
		protected DlgHandlerBase.HandlerState m_handlerState = DlgHandlerBase.HandlerState.Setup;

		// Token: 0x04005B0D RID: 23309
		private LoadUIFinishedEventHandler m_loadUIAsynHandler;

		// Token: 0x04005B0E RID: 23310
		private bool m_bLoaded = false;

		// Token: 0x04005B0F RID: 23311
		private Transform m_parent;

		// Token: 0x04005B10 RID: 23312
		private GameObject m_gameObject;

		// Token: 0x04005B11 RID: 23313
		private Transform m_transform;

		// Token: 0x04005B12 RID: 23314
		private bool m_visible = false;

		// Token: 0x04005B13 RID: 23315
		private bool m_isLoad = false;

		// Token: 0x04005B14 RID: 23316
		protected bool m_bDelayInited = false;

		// Token: 0x04005B15 RID: 23317
		protected int m_dummPool = -1;

		// Token: 0x04005B16 RID: 23318
		private DlgHandlerMgr m_DlgHandlerMgr = null;

		// Token: 0x04005B17 RID: 23319
		protected DlgHandlerMgr m_ParentHandlerMgr = null;

		// Token: 0x020019ED RID: 6637
		public enum HandlerState
		{
			// Token: 0x0400809E RID: 32926
			Setup,
			// Token: 0x0400809F RID: 32927
			Loading,
			// Token: 0x040080A0 RID: 32928
			Loaded,
			// Token: 0x040080A1 RID: 32929
			Inited,
			// Token: 0x040080A2 RID: 32930
			Show,
			// Token: 0x040080A3 RID: 32931
			Hide,
			// Token: 0x040080A4 RID: 32932
			Dispose,
			// Token: 0x040080A5 RID: 32933
			Error
		}
	}
}
