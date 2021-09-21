using System;
using UnityEngine;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001843 RID: 6211
	internal class MailSystemDlg : TabDlgBase<MailSystemDlg>
	{
		// Token: 0x1700394F RID: 14671
		// (get) Token: 0x06010227 RID: 66087 RVA: 0x003DC944 File Offset: 0x003DAB44
		public override string fileName
		{
			get
			{
				return "GameSystem/MailDlg";
			}
		}

		// Token: 0x17003950 RID: 14672
		// (get) Token: 0x06010228 RID: 66088 RVA: 0x003DC95C File Offset: 0x003DAB5C
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06010229 RID: 66089 RVA: 0x003DC96F File Offset: 0x003DAB6F
		protected override void Init()
		{
			base.Init();
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_Mail);
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XMailDocument.uuID) as XMailDocument);
		}

		// Token: 0x0601022A RID: 66090 RVA: 0x003DC9A4 File Offset: 0x003DABA4
		protected override void OnLoad()
		{
			base.OnLoad();
			this.tabTpl = base.uiBehaviour.transform.FindChild("Bg/Tabs/TabTpl");
			this.m_tabcontrol.SetTabTpl(this.tabTpl);
			this.m_systemFramePanel = base.uiBehaviour.transform.FindChild("Bg/SystemFrame").gameObject;
			this.m_systemFramePanel.SetActive(true);
			this.m_playerFramePanel = base.uiBehaviour.transform.FindChild("Bg/PlayerFrame").gameObject;
			this.m_playerFramePanel.SetActive(false);
			this.m_contentFramePanel = base.uiBehaviour.transform.FindChild("Bg/ContentFrame").gameObject;
			this.m_contentFramePanel.SetActive(true);
		}

		// Token: 0x0601022B RID: 66091 RVA: 0x003DCA6D File Offset: 0x003DAC6D
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XSystemMailView>(ref this._systemFrameView);
			DlgHandlerBase.EnsureUnload<XPlayerMailView>(ref this._playerFrameView);
			DlgHandlerBase.EnsureUnload<XContentMailView>(ref this._contMailView);
			base.OnUnload();
		}

		// Token: 0x0601022C RID: 66092 RVA: 0x003DCA9C File Offset: 0x003DAC9C
		public override void SetupHandlers(XSysDefine sys)
		{
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XMailDocument.uuID) as XMailDocument);
			base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XContentMailView>(ref this._contMailView, this.m_contentFramePanel, null, true));
			XSysDefine xsysDefine = sys;
			if (xsysDefine != XSysDefine.XSys_Mail_System)
			{
				if (xsysDefine != XSysDefine.XSys_Mail_Player)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("System has not finished:", sys.ToString(), null, null, null, null);
				}
				else
				{
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XPlayerMailView>(ref this._playerFrameView, this.m_playerFramePanel, this, true));
				}
			}
			else
			{
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XSystemMailView>(ref this._systemFrameView, this.m_systemFramePanel, this, true));
			}
		}

		// Token: 0x04007327 RID: 29479
		public XSystemMailView _systemFrameView;

		// Token: 0x04007328 RID: 29480
		public XPlayerMailView _playerFrameView;

		// Token: 0x04007329 RID: 29481
		public XContentMailView _contMailView;

		// Token: 0x0400732A RID: 29482
		private XMailDocument _doc = null;

		// Token: 0x0400732B RID: 29483
		public GameObject m_systemFramePanel;

		// Token: 0x0400732C RID: 29484
		public GameObject m_playerFramePanel;

		// Token: 0x0400732D RID: 29485
		public GameObject m_contentFramePanel;

		// Token: 0x0400732E RID: 29486
		public Transform tabTpl;

		// Token: 0x0400732F RID: 29487
		public XUITabControl m_tabcontrol = new XUITabControl();
	}
}
