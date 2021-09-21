using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C43 RID: 3139
	internal class ArtifactDeityStoveDlg : TabDlgBase<ArtifactDeityStoveDlg>
	{
		// Token: 0x17003172 RID: 12658
		// (get) Token: 0x0600B200 RID: 45568 RVA: 0x00224438 File Offset: 0x00222638
		public override string fileName
		{
			get
			{
				return "ItemNew/ArtifactDeityStoveDlg";
			}
		}

		// Token: 0x17003173 RID: 12659
		// (get) Token: 0x0600B201 RID: 45569 RVA: 0x00224450 File Offset: 0x00222650
		protected override bool bHorizontal
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003174 RID: 12660
		// (get) Token: 0x0600B202 RID: 45570 RVA: 0x00224464 File Offset: 0x00222664
		public override int sysid
		{
			get
			{
				return 370;
			}
		}

		// Token: 0x17003175 RID: 12661
		// (get) Token: 0x0600B203 RID: 45571 RVA: 0x0022447C File Offset: 0x0022267C
		public override bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003176 RID: 12662
		// (get) Token: 0x0600B204 RID: 45572 RVA: 0x00224490 File Offset: 0x00222690
		public override bool pushstack
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600B205 RID: 45573 RVA: 0x002244A4 File Offset: 0x002226A4
		protected override void Init()
		{
			this.m_doc = ArtifactDeityStoveDocument.Doc;
			this.m_handlersTra = base.uiBehaviour.transform.FindChild("Bg/Handlers");
			this.m_closedBtn = (base.uiBehaviour.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_helpBtn = (base.uiBehaviour.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			base.Init();
		}

		// Token: 0x0600B206 RID: 45574 RVA: 0x00224533 File Offset: 0x00222733
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600B207 RID: 45575 RVA: 0x0022453D File Offset: 0x0022273D
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B208 RID: 45576 RVA: 0x00224547 File Offset: 0x00222747
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClosed));
			this.m_helpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickHelp));
		}

		// Token: 0x0600B209 RID: 45577 RVA: 0x00224581 File Offset: 0x00222781
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600B20A RID: 45578 RVA: 0x0022458B File Offset: 0x0022278B
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600B20B RID: 45579 RVA: 0x00224598 File Offset: 0x00222798
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

		// Token: 0x0600B20C RID: 45580 RVA: 0x002245F8 File Offset: 0x002227F8
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

		// Token: 0x0600B20D RID: 45581 RVA: 0x00224728 File Offset: 0x00222928
		private bool OnClickClosed(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600B20E RID: 45582 RVA: 0x00224744 File Offset: 0x00222944
		private bool OnClickHelp(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Artifact_Comepose);
			return true;
		}

		// Token: 0x0400448E RID: 17550
		private ArtifactDeityStoveDocument m_doc;

		// Token: 0x0400448F RID: 17551
		private IXUIButton m_closedBtn;

		// Token: 0x04004490 RID: 17552
		private IXUIButton m_helpBtn;

		// Token: 0x04004491 RID: 17553
		private Transform m_handlersTra;

		// Token: 0x04004492 RID: 17554
		private ArtifactItemsHandler m_itemsHandler;

		// Token: 0x04004493 RID: 17555
		private ArtifactComposeHandler m_composeHandler;

		// Token: 0x04004494 RID: 17556
		private ArtifactRecastHandler m_recasetHandler;

		// Token: 0x04004495 RID: 17557
		private ArtifactFuseHandler m_fuseHandler;

		// Token: 0x04004496 RID: 17558
		private ArtifactInscriptionHandler m_inscriptionHandler;

		// Token: 0x04004497 RID: 17559
		private ArtifactRefinedHandler m_refinedHandler;
	}
}
