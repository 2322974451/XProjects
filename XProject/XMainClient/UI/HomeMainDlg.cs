using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017A3 RID: 6051
	internal class HomeMainDlg : TabDlgBase<HomeMainDlg>
	{
		// Token: 0x1700385D RID: 14429
		// (get) Token: 0x0600FA19 RID: 64025 RVA: 0x0039BEF8 File Offset: 0x0039A0F8
		public override string fileName
		{
			get
			{
				return "Home/HomeMainView";
			}
		}

		// Token: 0x1700385E RID: 14430
		// (get) Token: 0x0600FA1A RID: 64026 RVA: 0x0039BF10 File Offset: 0x0039A110
		protected override bool bHorizontal
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700385F RID: 14431
		// (get) Token: 0x0600FA1B RID: 64027 RVA: 0x0039BF24 File Offset: 0x0039A124
		public override int sysid
		{
			get
			{
				return 150;
			}
		}

		// Token: 0x17003860 RID: 14432
		// (get) Token: 0x0600FA1C RID: 64028 RVA: 0x0039BF3C File Offset: 0x0039A13C
		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003861 RID: 14433
		// (get) Token: 0x0600FA1D RID: 64029 RVA: 0x0039BF50 File Offset: 0x0039A150
		public CookingHandler HomeCookingHandler
		{
			get
			{
				return this.m_cookingHandler;
			}
		}

		// Token: 0x17003862 RID: 14434
		// (get) Token: 0x0600FA1E RID: 64030 RVA: 0x0039BF68 File Offset: 0x0039A168
		public FeastHandler HomeFeastHandler
		{
			get
			{
				return this.m_feastHandler;
			}
		}

		// Token: 0x0600FA1F RID: 64031 RVA: 0x0039BF80 File Offset: 0x0039A180
		protected override void Init()
		{
			this.m_handlersTra = base.uiBehaviour.transform.FindChild("Bg/Handlers");
			base.Init();
		}

		// Token: 0x0600FA20 RID: 64032 RVA: 0x0039BFA5 File Offset: 0x0039A1A5
		protected override void OnShow()
		{
			base.OnShow();
			HomeMainDocument.Doc.ReqGardenOverview();
		}

		// Token: 0x0600FA21 RID: 64033 RVA: 0x0039BFBA File Offset: 0x0039A1BA
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600FA22 RID: 64034 RVA: 0x0039BFC4 File Offset: 0x0039A1C4
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FA23 RID: 64035 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnLoad()
		{
		}

		// Token: 0x0600FA24 RID: 64036 RVA: 0x0039BFCE File Offset: 0x0039A1CE
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<MyHomeHandler>(ref this.m_myHomeHandler);
			DlgHandlerBase.EnsureUnload<HomeFriendHandler>(ref this.m_homeFriendHandler);
			DlgHandlerBase.EnsureUnload<CookingHandler>(ref this.m_cookingHandler);
			DlgHandlerBase.EnsureUnload<FeastHandler>(ref this.m_feastHandler);
			base.OnUnload();
		}

		// Token: 0x0600FA25 RID: 64037 RVA: 0x0039C008 File Offset: 0x0039A208
		public void Show(XSysDefine sys = XSysDefine.XSys_Home_MyHome)
		{
			this.m_curSelectedTab = sys;
		}

		// Token: 0x0600FA26 RID: 64038 RVA: 0x0039C014 File Offset: 0x0039A214
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

		// Token: 0x04006D8D RID: 28045
		private MyHomeHandler m_myHomeHandler;

		// Token: 0x04006D8E RID: 28046
		private HomeFriendHandler m_homeFriendHandler;

		// Token: 0x04006D8F RID: 28047
		private CookingHandler m_cookingHandler;

		// Token: 0x04006D90 RID: 28048
		private FeastHandler m_feastHandler;

		// Token: 0x04006D91 RID: 28049
		private XSysDefine m_curSelectedTab;

		// Token: 0x04006D92 RID: 28050
		private Transform m_handlersTra;
	}
}
