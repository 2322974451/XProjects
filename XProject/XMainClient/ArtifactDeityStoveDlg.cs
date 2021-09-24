using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ArtifactDeityStoveDlg : TabDlgBase<ArtifactDeityStoveDlg>
	{

		public override string fileName
		{
			get
			{
				return "ItemNew/ArtifactDeityStoveDlg";
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
				return 370;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		public override bool pushstack
		{
			get
			{
				return false;
			}
		}

		protected override void Init()
		{
			this.m_doc = ArtifactDeityStoveDocument.Doc;
			this.m_handlersTra = base.uiBehaviour.transform.FindChild("Bg/Handlers");
			this.m_closedBtn = (base.uiBehaviour.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_helpBtn = (base.uiBehaviour.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			base.Init();
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClosed));
			this.m_helpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickHelp));
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<ArtifactItemsHandler>(ref this.m_itemsHandler);
			DlgHandlerBase.EnsureUnload<ArtifactComposeHandler>(ref this.m_composeHandler);
			DlgHandlerBase.EnsureUnload<ArtifactRecastHandler>(ref this.m_recasetHandler);
			DlgHandlerBase.EnsureUnload<ArtifactFuseHandler>(ref this.m_fuseHandler);
			DlgHandlerBase.EnsureUnload<ArtifactInscriptionHandler>(ref this.m_inscriptionHandler);
			DlgHandlerBase.EnsureUnload<ArtifactRefinedHandler>(ref this.m_refinedHandler);
			base.OnUnload();
		}

		public override void SetupHandlers(XSysDefine sys)
		{
			this.m_doc.SysType = sys;
			this.m_doc.ResetSelection(false);
			switch (sys)
			{
			case XSysDefine.XSys_Artifact_Comepose:
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<ArtifactComposeHandler>(ref this.m_composeHandler, this.m_handlersTra, true, this));
				goto IL_106;
			case XSysDefine.XSys_Artifact_Recast:
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<ArtifactRecastHandler>(ref this.m_recasetHandler, this.m_handlersTra, true, this));
				goto IL_106;
			case XSysDefine.XSys_Artifact_Fuse:
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<ArtifactFuseHandler>(ref this.m_fuseHandler, this.m_handlersTra, true, this));
				goto IL_106;
			case XSysDefine.XSys_Artifact_Inscription:
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<ArtifactInscriptionHandler>(ref this.m_inscriptionHandler, this.m_handlersTra, true, this));
				goto IL_106;
			case XSysDefine.XSys_Artifact_Refined:
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<ArtifactRefinedHandler>(ref this.m_refinedHandler, this.m_handlersTra, true, this));
				goto IL_106;
			}
			XSingleton<XDebug>.singleton.AddErrorLog("System has not finished:", sys.ToString(), null, null, null, null);
			return;
			IL_106:
			base._AddActiveHandler(DlgHandlerBase.EnsureCreate<ArtifactItemsHandler>(ref this.m_itemsHandler, this.m_handlersTra, true, this));
		}

		private bool OnClickClosed(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		private bool OnClickHelp(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Artifact_Comepose);
			return true;
		}

		private ArtifactDeityStoveDocument m_doc;

		private IXUIButton m_closedBtn;

		private IXUIButton m_helpBtn;

		private Transform m_handlersTra;

		private ArtifactItemsHandler m_itemsHandler;

		private ArtifactComposeHandler m_composeHandler;

		private ArtifactRecastHandler m_recasetHandler;

		private ArtifactFuseHandler m_fuseHandler;

		private ArtifactInscriptionHandler m_inscriptionHandler;

		private ArtifactRefinedHandler m_refinedHandler;
	}
}
