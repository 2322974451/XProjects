using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HomeMainDlg : TabDlgBase<HomeMainDlg>
	{

		public override string fileName
		{
			get
			{
				return "Home/HomeMainView";
			}
		}

		protected override bool bHorizontal
		{
			get
			{
				return true;
			}
		}

		public override int sysid
		{
			get
			{
				return 150;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		public CookingHandler HomeCookingHandler
		{
			get
			{
				return this.m_cookingHandler;
			}
		}

		public FeastHandler HomeFeastHandler
		{
			get
			{
				return this.m_feastHandler;
			}
		}

		protected override void Init()
		{
			this.m_handlersTra = base.uiBehaviour.transform.FindChild("Bg/Handlers");
			base.Init();
		}

		protected override void OnShow()
		{
			base.OnShow();
			HomeMainDocument.Doc.ReqGardenOverview();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		protected override void OnLoad()
		{
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<MyHomeHandler>(ref this.m_myHomeHandler);
			DlgHandlerBase.EnsureUnload<HomeFriendHandler>(ref this.m_homeFriendHandler);
			DlgHandlerBase.EnsureUnload<CookingHandler>(ref this.m_cookingHandler);
			DlgHandlerBase.EnsureUnload<FeastHandler>(ref this.m_feastHandler);
			base.OnUnload();
		}

		public void Show(XSysDefine sys = XSysDefine.XSys_Home_MyHome)
		{
			this.m_curSelectedTab = sys;
		}

		public override void SetupHandlers(XSysDefine sys)
		{
			switch (sys)
			{
			case XSysDefine.XSys_Home_Cooking:
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<CookingHandler>(ref this.m_cookingHandler, this.m_handlersTra, true, this));
				return;
			case XSysDefine.XSys_Home_Feast:
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<FeastHandler>(ref this.m_feastHandler, this.m_handlersTra, true, this));
				return;
			case XSysDefine.XSys_Home_MyHome:
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<MyHomeHandler>(ref this.m_myHomeHandler, this.m_handlersTra, true, this));
				return;
			case XSysDefine.XSys_Home_HomeFriends:
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<HomeFriendHandler>(ref this.m_homeFriendHandler, this.m_handlersTra, true, this));
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog("System has not finished:", sys.ToString(), null, null, null, null);
		}

		private MyHomeHandler m_myHomeHandler;

		private HomeFriendHandler m_homeFriendHandler;

		private CookingHandler m_cookingHandler;

		private FeastHandler m_feastHandler;

		private XSysDefine m_curSelectedTab;

		private Transform m_handlersTra;
	}
}
