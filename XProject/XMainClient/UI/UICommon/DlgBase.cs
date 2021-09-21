using System;
using UILib;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI.UICommon
{
	// Token: 0x0200192A RID: 6442
	public abstract class DlgBase<TDlgClass, TUIBehaviour> : IXUIDlg, IDlgHandlerMgr where TDlgClass : IXUIDlg, new() where TUIBehaviour : DlgBehaviourBase
	{
		// Token: 0x17003B06 RID: 15110
		// (get) Token: 0x06010E89 RID: 69257 RVA: 0x00449C24 File Offset: 0x00447E24
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

		// Token: 0x17003B07 RID: 15111
		// (get) Token: 0x06010E8A RID: 69258 RVA: 0x00449C94 File Offset: 0x00447E94
		public IXUIBehaviour uiBehaviourInterface
		{
			get
			{
				return this.m_uiBehaviour;
			}
		}

		// Token: 0x17003B08 RID: 15112
		// (get) Token: 0x06010E8B RID: 69259 RVA: 0x00449CB4 File Offset: 0x00447EB4
		public TUIBehaviour uiBehaviour
		{
			get
			{
				return this.m_uiBehaviour;
			}
		}

		// Token: 0x17003B09 RID: 15113
		// (get) Token: 0x06010E8C RID: 69260 RVA: 0x00449CCC File Offset: 0x00447ECC
		public virtual string fileName
		{
			get
			{
				return "";
			}
		}

		// Token: 0x17003B0A RID: 15114
		// (get) Token: 0x06010E8D RID: 69261 RVA: 0x00449CE4 File Offset: 0x00447EE4
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

		// Token: 0x17003B0B RID: 15115
		// (get) Token: 0x06010E8E RID: 69262 RVA: 0x00449D40 File Offset: 0x00447F40
		public virtual int layer
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x17003B0C RID: 15116
		// (get) Token: 0x06010E8F RID: 69263 RVA: 0x00449D54 File Offset: 0x00447F54
		public virtual int group
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17003B0D RID: 15117
		// (get) Token: 0x06010E90 RID: 69264 RVA: 0x00449D68 File Offset: 0x00447F68
		public virtual bool exclusive
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003B0E RID: 15118
		// (get) Token: 0x06010E91 RID: 69265 RVA: 0x00449D7C File Offset: 0x00447F7C
		public virtual bool autoload
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003B0F RID: 15119
		// (get) Token: 0x06010E92 RID: 69266 RVA: 0x00449D90 File Offset: 0x00447F90
		public virtual bool isHideChat
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003B10 RID: 15120
		// (get) Token: 0x06010E93 RID: 69267 RVA: 0x00449DA4 File Offset: 0x00447FA4
		public virtual bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003B11 RID: 15121
		// (get) Token: 0x06010E94 RID: 69268 RVA: 0x00449DB8 File Offset: 0x00447FB8
		public virtual bool pushstack
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003B12 RID: 15122
		// (get) Token: 0x06010E95 RID: 69269 RVA: 0x00449DCC File Offset: 0x00447FCC
		public virtual bool isMainUI
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003B13 RID: 15123
		// (get) Token: 0x06010E96 RID: 69270 RVA: 0x00449DE0 File Offset: 0x00447FE0
		public virtual bool isHideTutorial
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003B14 RID: 15124
		// (get) Token: 0x06010E97 RID: 69271 RVA: 0x00449DF4 File Offset: 0x00447FF4
		public virtual int sysid
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17003B15 RID: 15125
		// (get) Token: 0x06010E98 RID: 69272 RVA: 0x00449E08 File Offset: 0x00448008
		public virtual bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003B16 RID: 15126
		// (get) Token: 0x06010E99 RID: 69273 RVA: 0x00449E1C File Offset: 0x0044801C
		public bool Prepared
		{
			get
			{
				return null != this.m_uiBehaviour;
			}
		}

		// Token: 0x17003B17 RID: 15127
		// (get) Token: 0x06010E9A RID: 69274 RVA: 0x00449E40 File Offset: 0x00448040
		public virtual bool isPopup
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003B18 RID: 15128
		// (get) Token: 0x06010E9B RID: 69275 RVA: 0x00449E54 File Offset: 0x00448054
		public virtual bool needOnTop
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06010E9C RID: 69276 RVA: 0x00449E68 File Offset: 0x00448068
		public DlgBase()
		{
			this._loadUICb = new LoadUIFinishedEventHandler(this.OnLoadUIFinishedEventHandler);
		}

		// Token: 0x06010E9D RID: 69277 RVA: 0x00449EE9 File Offset: 0x004480E9
		public virtual void OnUpdate()
		{
			this.HandlerMgr.OnUpdate();
		}

		// Token: 0x06010E9E RID: 69278 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnPostUpdate()
		{
		}

		// Token: 0x06010E9F RID: 69279 RVA: 0x00449EF8 File Offset: 0x004480F8
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

		// Token: 0x06010EA0 RID: 69280 RVA: 0x00449F84 File Offset: 0x00448184
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

		// Token: 0x06010EA1 RID: 69281 RVA: 0x0044A1A8 File Offset: 0x004483A8
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

		// Token: 0x06010EA2 RID: 69282 RVA: 0x0044A264 File Offset: 0x00448464
		protected void OnShowAnimationFinish(IXUITweenTool tween)
		{
			bool fullscreenui = this.fullscreenui;
			if (fullscreenui)
			{
				XSingleton<XScene>.singleton.GameCamera.UnityCamera.enabled = false;
			}
		}

		// Token: 0x06010EA3 RID: 69283 RVA: 0x0044A294 File Offset: 0x00448494
		protected void OnCloseAnimationFinish(IXUITweenTool tween)
		{
			this.SetVisible(false, true);
			bool flag = this.m_animationOver != null;
			if (flag)
			{
				this.m_animationOver();
			}
		}

		// Token: 0x06010EA4 RID: 69284 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnShow()
		{
		}

		// Token: 0x06010EA5 RID: 69285 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnHide()
		{
		}

		// Token: 0x06010EA6 RID: 69286 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnLoad()
		{
		}

		// Token: 0x06010EA7 RID: 69287 RVA: 0x0044A2C6 File Offset: 0x004484C6
		protected virtual void OnUnload()
		{
			this.UnRegisterEvent();
		}

		// Token: 0x06010EA8 RID: 69288 RVA: 0x0044A2D0 File Offset: 0x004484D0
		public bool IsVisible()
		{
			bool bLoaded = this.m_bLoaded;
			return bLoaded && this.uiBehaviour.IsVisible();
		}

		// Token: 0x06010EA9 RID: 69289 RVA: 0x0044A304 File Offset: 0x00448504
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

		// Token: 0x06010EAA RID: 69290 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void Reset()
		{
		}

		// Token: 0x06010EAB RID: 69291 RVA: 0x0044A364 File Offset: 0x00448564
		public virtual void StackRefresh()
		{
			bool flag = this.HandlerMgr != null;
			if (flag)
			{
				this.HandlerMgr.StackRefresh();
			}
		}

		// Token: 0x06010EAC RID: 69292 RVA: 0x0044A390 File Offset: 0x00448590
		public virtual void LeaveStackTop()
		{
			bool flag = this.HandlerMgr != null;
			if (flag)
			{
				this.HandlerMgr.LeaveStackTop();
			}
		}

		// Token: 0x06010EAD RID: 69293 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnSetVisiblePure(bool bShow)
		{
		}

		// Token: 0x06010EAE RID: 69294 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void Init()
		{
		}

		// Token: 0x06010EAF RID: 69295 RVA: 0x0044A3BC File Offset: 0x004485BC
		private void InnerInit()
		{
			this.m_uiBehaviour.Init();
			Vector3 localPosition = this.uiBehaviour.transform.localPosition;
			localPosition.z = this.m_fDepthZ;
			this.uiBehaviour.transform.localPosition = localPosition;
			this.m_DlgController = this.uiBehaviour.transform.FindChild("DlgController");
		}

		// Token: 0x06010EB0 RID: 69296 RVA: 0x0044A438 File Offset: 0x00448638
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

		// Token: 0x06010EB1 RID: 69297 RVA: 0x0044A490 File Offset: 0x00448690
		public bool IsLoaded()
		{
			return this.m_bLoaded;
		}

		// Token: 0x06010EB2 RID: 69298 RVA: 0x0044A4A8 File Offset: 0x004486A8
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

		// Token: 0x06010EB3 RID: 69299 RVA: 0x0044A5C4 File Offset: 0x004487C4
		public void SetAlpha(float a)
		{
			IXUIPanel ixuipanel = this.uiBehaviour.gameObject.GetComponent("XUIPanel") as IXUIPanel;
			bool flag = ixuipanel != null;
			if (flag)
			{
				ixuipanel.SetAlpha(a);
			}
		}

		// Token: 0x06010EB4 RID: 69300 RVA: 0x0044A604 File Offset: 0x00448804
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

		// Token: 0x06010EB5 RID: 69301 RVA: 0x0044A64C File Offset: 0x0044884C
		public void RegCallBack()
		{
			this.panelCB = (this.uiBehaviour.gameObject.GetComponent("NGUIAssetCallBack") as IXNGUICallback);
			bool flag = this.panelCB != null;
			if (flag)
			{
				this.panelCB.RegisterClickEventHandler(new IXNGUIClickEventHandler(this.OnXNGUIClick));
			}
		}

		// Token: 0x06010EB6 RID: 69302 RVA: 0x0044A6A5 File Offset: 0x004488A5
		public virtual void OnXNGUIClick(GameObject obj, string path)
		{
			XSingleton<XDebug>.singleton.AddLog(obj.name, " ", path, null, null, null, XDebugColor.XDebug_None);
		}

		// Token: 0x06010EB7 RID: 69303 RVA: 0x0044A6C4 File Offset: 0x004488C4
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

		// Token: 0x06010EB8 RID: 69304 RVA: 0x0044A764 File Offset: 0x00448964
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

		// Token: 0x06010EB9 RID: 69305 RVA: 0x0044A85C File Offset: 0x00448A5C
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

		// Token: 0x06010EBA RID: 69306 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void RegisterEvent()
		{
		}

		// Token: 0x06010EBB RID: 69307 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void UnRegisterEvent()
		{
		}

		// Token: 0x06010EBC RID: 69308 RVA: 0x0044A8CC File Offset: 0x00448ACC
		public virtual void SetRelatedDlg(IXUIDlg dlg)
		{
			this.m_RelatedDlg = dlg;
		}

		// Token: 0x06010EBD RID: 69309 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnRelatedShow()
		{
		}

		// Token: 0x06010EBE RID: 69310 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnRelatedHide()
		{
		}

		// Token: 0x06010EBF RID: 69311 RVA: 0x0044A8D8 File Offset: 0x00448AD8
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

		// Token: 0x06010EC0 RID: 69312 RVA: 0x0044A910 File Offset: 0x00448B10
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

		// Token: 0x06010EC1 RID: 69313 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnPopupBlocked()
		{
		}

		// Token: 0x06010EC2 RID: 69314 RVA: 0x0044A948 File Offset: 0x00448B48
		public virtual int[] GetTitanBarItems()
		{
			return null;
		}

		// Token: 0x17003B19 RID: 15129
		// (get) Token: 0x06010EC3 RID: 69315 RVA: 0x0044A95C File Offset: 0x00448B5C
		public DlgHandlerMgr HandlerMgr
		{
			get
			{
				return this.m_DlgHandlerMgr;
			}
		}

		// Token: 0x06010EC4 RID: 69316 RVA: 0x0044A974 File Offset: 0x00448B74
		protected void Alloc3DAvatarPool(string user)
		{
			bool flag = this.m_dummPool < 0;
			if (flag)
			{
				this.m_dummPool = XSingleton<X3DAvatarMgr>.singleton.AllocDummyPool(user, 1);
			}
		}

		// Token: 0x06010EC5 RID: 69317 RVA: 0x0044A9A3 File Offset: 0x00448BA3
		protected void Return3DAvatarPool()
		{
			XSingleton<X3DAvatarMgr>.singleton.ReturnDummyPool(this.m_dummPool);
			this.m_dummPool = -1;
		}

		// Token: 0x06010EC6 RID: 69318 RVA: 0x0044A9C0 File Offset: 0x00448BC0
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

		// Token: 0x06010EC7 RID: 69319 RVA: 0x0044AA24 File Offset: 0x00448C24
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

		// Token: 0x04007C62 RID: 31842
		private LoadUIFinishedEventHandler _loadUICb = null;

		// Token: 0x04007C63 RID: 31843
		protected int m_dummPool = -1;

		// Token: 0x04007C64 RID: 31844
		private IXNGUICallback panelCB = null;

		// Token: 0x04007C65 RID: 31845
		protected TUIBehaviour m_uiBehaviour = default(TUIBehaviour);

		// Token: 0x04007C66 RID: 31846
		private static TDlgClass s_instance = default(TDlgClass);

		// Token: 0x04007C67 RID: 31847
		private static object s_objLock = new object();

		// Token: 0x04007C68 RID: 31848
		private bool m_bVisible = false;

		// Token: 0x04007C69 RID: 31849
		protected bool m_bLoaded = false;

		// Token: 0x04007C6A RID: 31850
		private float m_fDepthZ = 0f;

		// Token: 0x04007C6B RID: 31851
		private bool m_bBindedReverse = false;

		// Token: 0x04007C6C RID: 31852
		private Transform m_DlgController = null;

		// Token: 0x04007C6D RID: 31853
		private bool m_bCacheVisible = false;

		// Token: 0x04007C6E RID: 31854
		private DlgBase<TDlgClass, TUIBehaviour>.OnAnimationOver m_animationOver;

		// Token: 0x04007C6F RID: 31855
		private IXUIDlg m_RelatedDlg;

		// Token: 0x04007C70 RID: 31856
		private DlgHandlerMgr m_DlgHandlerMgr = new DlgHandlerMgr();

		// Token: 0x02001A23 RID: 6691
		// (Invoke) Token: 0x0601115B RID: 69979
		public delegate void OnAnimationOver();
	}
}
