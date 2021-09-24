using System;
using UILib;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI.UICommon
{

	public abstract class DlgBase<TDlgClass, TUIBehaviour> : IXUIDlg, IDlgHandlerMgr where TDlgClass : IXUIDlg, new() where TUIBehaviour : DlgBehaviourBase
	{

		public static TDlgClass singleton
		{
			get
			{
				bool flag = DlgBase<TDlgClass, TUIBehaviour>.s_instance == null;
				if (flag)
				{
					object obj = DlgBase<TDlgClass, TUIBehaviour>.s_objLock;
					lock (obj)
					{
						bool flag2 = DlgBase<TDlgClass, TUIBehaviour>.s_instance == null;
						if (flag2)
						{
							DlgBase<TDlgClass, TUIBehaviour>.s_instance = Activator.CreateInstance<TDlgClass>();
						}
					}
				}
				return DlgBase<TDlgClass, TUIBehaviour>.s_instance;
			}
		}

		public IXUIBehaviour uiBehaviourInterface
		{
			get
			{
				return this.m_uiBehaviour;
			}
		}

		public TUIBehaviour uiBehaviour
		{
			get
			{
				return this.m_uiBehaviour;
			}
		}

		public virtual string fileName
		{
			get
			{
				return "";
			}
		}

		public string luaFileName
		{
			get
			{
				bool flag = this.fileName.Length > 1 && this.fileName.Contains("/");
				string result;
				if (flag)
				{
					result = this.fileName.Substring(this.fileName.LastIndexOf('/') + 1);
				}
				else
				{
					result = this.fileName;
				}
				return result;
			}
		}

		public virtual int layer
		{
			get
			{
				return 2;
			}
		}

		public virtual int group
		{
			get
			{
				return 0;
			}
		}

		public virtual bool exclusive
		{
			get
			{
				return false;
			}
		}

		public virtual bool autoload
		{
			get
			{
				return false;
			}
		}

		public virtual bool isHideChat
		{
			get
			{
				return true;
			}
		}

		public virtual bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		public virtual bool pushstack
		{
			get
			{
				return false;
			}
		}

		public virtual bool isMainUI
		{
			get
			{
				return false;
			}
		}

		public virtual bool isHideTutorial
		{
			get
			{
				return false;
			}
		}

		public virtual int sysid
		{
			get
			{
				return 0;
			}
		}

		public virtual bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		public bool Prepared
		{
			get
			{
				return null != this.m_uiBehaviour;
			}
		}

		public virtual bool isPopup
		{
			get
			{
				return false;
			}
		}

		public virtual bool needOnTop
		{
			get
			{
				return false;
			}
		}

		public DlgBase()
		{
			this._loadUICb = new LoadUIFinishedEventHandler(this.OnLoadUIFinishedEventHandler);
		}

		public virtual void OnUpdate()
		{
			this.HandlerMgr.OnUpdate();
		}

		public virtual void OnPostUpdate()
		{
		}

		public void SetVisiblePure(bool bVisible)
		{
			bool flag = !this.m_bLoaded && this.autoload;
			if (flag)
			{
				this.Load();
			}
			else
			{
				bool flag2 = !this.m_bLoaded && !this.autoload;
				if (flag2)
				{
					return;
				}
			}
			this.uiBehaviour.SetVisible(bVisible);
			this.m_bVisible = bVisible;
			this.OnSetVisiblePure(bVisible);
			bool flag3 = this.m_RelatedDlg != null;
			if (flag3)
			{
				this.m_RelatedDlg.SetRelatedVisible(this.m_bVisible);
			}
		}

		public virtual void SetVisible(bool bIsVisible, bool bEnableAuto = true)
		{
			bool bLoaded = this.m_bLoaded;
			if (!bLoaded)
			{
				bool flag = this.autoload && bEnableAuto;
				if (!flag)
				{
					return;
				}
				this.Load();
			}
			bool flag2 = bIsVisible && !this._CanShow();
			if (!flag2)
			{
				bool prepared = this.Prepared;
				if (prepared)
				{
					bool flag3 = this.m_bVisible != bIsVisible;
					if (flag3)
					{
						this.uiBehaviour.SetVisible(bIsVisible);
						this.m_bVisible = bIsVisible;
						if (bIsVisible)
						{
							XSingleton<UIManager>.singleton.OnDlgShow(DlgBase<TDlgClass, TUIBehaviour>.s_instance);
							ILuaEngine xluaEngine = XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine;
							bool flag4 = !xluaEngine.hotfixMgr.TryFixRefresh(HotfixMode.BEFORE, this.luaFileName, this.uiBehaviour.gameObject);
							if (flag4)
							{
								this.OnShow();
								xluaEngine.hotfixMgr.TryFixRefresh(HotfixMode.AFTER, this.luaFileName, this.uiBehaviour.gameObject);
							}
							bool flag5 = this.fullscreenui && XSingleton<XScene>.singleton.GameCamera != null && XSingleton<XScene>.singleton.GameCamera.UnityCamera != null;
							if (flag5)
							{
								XSingleton<XScene>.singleton.GameCamera.UnityCamera.enabled = false;
							}
						}
						else
						{
							this.OnHide();
							XSingleton<UIManager>.singleton.OnDlgHide(DlgBase<TDlgClass, TUIBehaviour>.s_instance);
							ILuaEngine xluaEngine2 = XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine;
							xluaEngine2.hotfixMgr.TryFixRefresh(HotfixMode.HIDE, this.luaFileName, this.uiBehaviour.gameObject);
							bool flag6 = XSingleton<UIManager>.singleton.GetFullScreenUICount() == 0 && XSingleton<XScene>.singleton.GameCamera != null && XSingleton<XScene>.singleton.GameCamera.UnityCamera != null;
							if (flag6)
							{
								XSingleton<XScene>.singleton.GameCamera.UnityCamera.enabled = true;
							}
						}
						bool flag7 = this.m_RelatedDlg != null;
						if (flag7)
						{
							this.m_RelatedDlg.SetVisible(this.m_bVisible, true);
						}
					}
				}
			}
		}

		public virtual void SetVisibleWithAnimation(bool bVisible, DlgBase<TDlgClass, TUIBehaviour>.OnAnimationOver AnimationOverDelegate)
		{
			bool flag = !this.m_bLoaded;
			if (flag)
			{
				this.Load();
			}
			bool flag2 = bVisible && !this._CanShow();
			if (!flag2)
			{
				int fullScreenUICount = XSingleton<UIManager>.singleton.GetFullScreenUICount();
				bool flag3 = (bVisible && fullScreenUICount > 0) || (!bVisible && ((this.fullscreenui && fullScreenUICount > 1) || (!this.fullscreenui && fullScreenUICount > 0)));
				if (flag3)
				{
					this.SetVisible(bVisible, true);
					bool flag4 = AnimationOverDelegate != null;
					if (flag4)
					{
						AnimationOverDelegate();
					}
				}
				else
				{
					this.SetVisible(bVisible, true);
					this.m_bCacheVisible = bVisible;
					this.m_animationOver = AnimationOverDelegate;
					bool flag5 = AnimationOverDelegate != null;
					if (flag5)
					{
						AnimationOverDelegate();
					}
				}
			}
		}

		protected void OnShowAnimationFinish(IXUITweenTool tween)
		{
			bool fullscreenui = this.fullscreenui;
			if (fullscreenui)
			{
				XSingleton<XScene>.singleton.GameCamera.UnityCamera.enabled = false;
			}
		}

		protected void OnCloseAnimationFinish(IXUITweenTool tween)
		{
			this.SetVisible(false, true);
			bool flag = this.m_animationOver != null;
			if (flag)
			{
				this.m_animationOver();
			}
		}

		protected virtual void OnShow()
		{
		}

		protected virtual void OnHide()
		{
		}

		protected virtual void OnLoad()
		{
		}

		protected virtual void OnUnload()
		{
			this.UnRegisterEvent();
		}

		public bool IsVisible()
		{
			bool bLoaded = this.m_bLoaded;
			return bLoaded && this.uiBehaviour.IsVisible();
		}

		public void SetDepthZ(int nDepthZ)
		{
			this.m_fDepthZ = (float)(nDepthZ * 10);
			bool prepared = this.Prepared;
			if (prepared)
			{
				Vector3 localPosition = this.uiBehaviour.transform.localPosition;
				localPosition.z = this.m_fDepthZ;
				this.uiBehaviour.transform.localPosition = localPosition;
			}
		}

		public virtual void Reset()
		{
		}

		public virtual void StackRefresh()
		{
			bool flag = this.HandlerMgr != null;
			if (flag)
			{
				this.HandlerMgr.StackRefresh();
			}
		}

		public virtual void LeaveStackTop()
		{
			bool flag = this.HandlerMgr != null;
			if (flag)
			{
				this.HandlerMgr.LeaveStackTop();
			}
		}

		protected virtual void OnSetVisiblePure(bool bShow)
		{
		}

		protected virtual void Init()
		{
		}

		private void InnerInit()
		{
			this.m_uiBehaviour.Init();
			Vector3 localPosition = this.uiBehaviour.transform.localPosition;
			localPosition.z = this.m_fDepthZ;
			this.uiBehaviour.transform.localPosition = localPosition;
			this.m_DlgController = this.uiBehaviour.transform.FindChild("DlgController");
		}

		public void Load()
		{
			bool flag = !this.m_bLoaded;
			if (flag)
			{
				this.m_bLoaded = true;
				XSingleton<UIManager>.singleton.LoadUI(this.fileName, this._loadUICb);
				XSingleton<UIManager>.singleton.AddDlg(DlgBase<TDlgClass, TUIBehaviour>.s_instance);
				this.OnLoad();
			}
		}

		public bool IsLoaded()
		{
			return this.m_bLoaded;
		}

		public void UnLoad(bool bTransfer = false)
		{
			bool bLoaded = this.m_bLoaded;
			if (bLoaded)
			{
				if (bTransfer)
				{
					this.SetVisible(false, false);
				}
				else
				{
					ILuaEngine xluaEngine = XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine;
					xluaEngine.hotfixMgr.TryFixRefresh(HotfixMode.UNLOAD, this.luaFileName, this.uiBehaviour.gameObject);
					this.OnUnload();
					this.HandlerMgr.Unload();
					XSingleton<UIManager>.singleton.RemoveDlg(DlgBase<TDlgClass, TUIBehaviour>.s_instance);
					XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroy(this.uiBehaviour.gameObject, false, true);
					this.m_uiBehaviour = default(TUIBehaviour);
					this.m_uiBehaviour = default(TUIBehaviour);
					this.m_bLoaded = false;
					bool flag = !XSingleton<XGame>.singleton.switchScene;
					if (flag)
					{
						bool flag2 = XSingleton<UIManager>.singleton.unloadUICount >= 10;
						if (flag2)
						{
							Resources.UnloadUnusedAssets();
							XSingleton<UIManager>.singleton.unloadUICount = 0;
						}
						else
						{
							XSingleton<UIManager>.singleton.unloadUICount++;
						}
					}
				}
			}
		}

		public void SetAlpha(float a)
		{
			IXUIPanel ixuipanel = this.uiBehaviour.gameObject.GetComponent("XUIPanel") as IXUIPanel;
			bool flag = ixuipanel != null;
			if (flag)
			{
				ixuipanel.SetAlpha(a);
			}
		}

		public float GetAlpha()
		{
			IXUIPanel ixuipanel = this.uiBehaviour.gameObject.GetComponent("XUIPanel") as IXUIPanel;
			bool flag = ixuipanel != null;
			float result;
			if (flag)
			{
				result = ixuipanel.GetAlpha();
			}
			else
			{
				result = 1f;
			}
			return result;
		}

		public void RegCallBack()
		{
			this.panelCB = (this.uiBehaviour.gameObject.GetComponent("NGUIAssetCallBack") as IXNGUICallback);
			bool flag = this.panelCB != null;
			if (flag)
			{
				this.panelCB.RegisterClickEventHandler(new IXNGUIClickEventHandler(this.OnXNGUIClick));
			}
		}

		public virtual void OnXNGUIClick(GameObject obj, string path)
		{
			XSingleton<XDebug>.singleton.AddLog(obj.name, " ", path, null, null, null, XDebugColor.XDebug_None);
		}

		protected GameObject SetXUILable(string name, string content)
		{
			bool flag = this.uiBehaviour.transform == null;
			GameObject result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = string.IsNullOrEmpty(content);
				if (flag2)
				{
					content = string.Empty;
				}
				IXUILabel ixuilabel = this.uiBehaviour.transform.FindChild(name).GetComponent("XUILabel") as IXUILabel;
				bool flag3 = ixuilabel == null;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("SetXUILable ", name, " ", content, null, null);
					result = null;
				}
				else
				{
					ixuilabel.SetText(content);
					result = ixuilabel.gameObject;
				}
			}
			return result;
		}

		private void OnLoadUIFinishedEventHandler(string location)
		{
			GameObject gameObject = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/" + location, true, false) as GameObject;
			bool flag = null != gameObject;
			if (flag)
			{
				gameObject.transform.parent = XSingleton<UIManager>.singleton.UIRoot;
				gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
				gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
				this.m_uiBehaviour = gameObject.AddComponent<TUIBehaviour>();
				this.m_uiBehaviour.uiDlgInterface = this;
				bool flag2 = !this.m_bBindedReverse;
				if (flag2)
				{
					this.Init();
					this.InnerInit();
					this.RegisterEvent();
					this.RegCallBack();
					this.uiBehaviour.SetVisible(false);
					this.m_bVisible = false;
				}
			}
		}

		public bool BindReverse(IXUIBehaviour iXUIBehaviour)
		{
			TUIBehaviour tuibehaviour = iXUIBehaviour as TUIBehaviour;
			bool flag = null == tuibehaviour;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.m_bLoaded = true;
				this.m_uiBehaviour = tuibehaviour;
				this.m_uiBehaviour.uiDlgInterface = this;
				this.RegisterEvent();
				this.InnerInit();
				this.Init();
				this.m_bBindedReverse = true;
				result = true;
			}
			return result;
		}

		public virtual void RegisterEvent()
		{
		}

		protected virtual void UnRegisterEvent()
		{
		}

		public virtual void SetRelatedDlg(IXUIDlg dlg)
		{
			this.m_RelatedDlg = dlg;
		}

		protected virtual void OnRelatedShow()
		{
		}

		protected virtual void OnRelatedHide()
		{
		}

		public void SetRelatedVisible(bool bVisible)
		{
			bool bLoaded = this.m_bLoaded;
			if (bLoaded)
			{
				this.SetVisiblePure(bVisible);
				if (bVisible)
				{
					this.OnRelatedShow();
				}
				else
				{
					this.OnRelatedHide();
				}
			}
		}

		private bool _CanShow()
		{
			bool flag = this.isPopup && XSingleton<XTutorialMgr>.singleton.InTutorial;
			bool result;
			if (flag)
			{
				this.OnPopupBlocked();
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		protected virtual void OnPopupBlocked()
		{
		}

		public virtual int[] GetTitanBarItems()
		{
			return null;
		}

		public DlgHandlerMgr HandlerMgr
		{
			get
			{
				return this.m_DlgHandlerMgr;
			}
		}

		protected void Alloc3DAvatarPool(string user)
		{
			bool flag = this.m_dummPool < 0;
			if (flag)
			{
				this.m_dummPool = XSingleton<X3DAvatarMgr>.singleton.AllocDummyPool(user, 1);
			}
		}

		protected void Return3DAvatarPool()
		{
			XSingleton<X3DAvatarMgr>.singleton.ReturnDummyPool(this.m_dummPool);
			this.m_dummPool = -1;
		}

		public static Transform FindChildRecursively(string childName)
		{
			TDlgClass singleton = DlgBase<TDlgClass, TUIBehaviour>.singleton;
			TUIBehaviour tuibehaviour = singleton.uiBehaviourInterface as TUIBehaviour;
			bool flag = !tuibehaviour.IsVisible();
			Transform result;
			if (flag)
			{
				result = null;
			}
			else
			{
				Transform transform = XSingleton<XCommon>.singleton.FindChildRecursively(tuibehaviour.transform, childName);
				result = transform;
			}
			return result;
		}

		public static Vector3 GetChildWorldPos(string childName)
		{
			TDlgClass singleton = DlgBase<TDlgClass, TUIBehaviour>.singleton;
			TUIBehaviour tuibehaviour = singleton.uiBehaviourInterface as TUIBehaviour;
			bool flag = !tuibehaviour.IsVisible();
			Vector3 result;
			if (flag)
			{
				result = Vector3.zero;
			}
			else
			{
				Transform transform = XSingleton<XCommon>.singleton.FindChildRecursively(tuibehaviour.transform, childName);
				bool flag2 = transform != null;
				if (flag2)
				{
					result = transform.position;
				}
				else
				{
					result = Vector3.zero;
				}
			}
			return result;
		}

		private LoadUIFinishedEventHandler _loadUICb = null;

		protected int m_dummPool = -1;

		private IXNGUICallback panelCB = null;

		protected TUIBehaviour m_uiBehaviour = default(TUIBehaviour);

		private static TDlgClass s_instance = default(TDlgClass);

		private static object s_objLock = new object();

		private bool m_bVisible = false;

		protected bool m_bLoaded = false;

		private float m_fDepthZ = 0f;

		private bool m_bBindedReverse = false;

		private Transform m_DlgController = null;

		private bool m_bCacheVisible = false;

		private DlgBase<TDlgClass, TUIBehaviour>.OnAnimationOver m_animationOver;

		private IXUIDlg m_RelatedDlg;

		private DlgHandlerMgr m_DlgHandlerMgr = new DlgHandlerMgr();

		public delegate void OnAnimationOver();
	}
}
