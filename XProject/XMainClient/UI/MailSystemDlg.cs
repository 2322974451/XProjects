using System;
using UnityEngine;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class MailSystemDlg : TabDlgBase<MailSystemDlg>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/MailDlg";
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		protected override void Init()
		{
			base.Init();
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_Mail);
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XMailDocument.uuID) as XMailDocument);
		}

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

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XSystemMailView>(ref this._systemFrameView);
			DlgHandlerBase.EnsureUnload<XPlayerMailView>(ref this._playerFrameView);
			DlgHandlerBase.EnsureUnload<XContentMailView>(ref this._contMailView);
			base.OnUnload();
		}

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

		public XSystemMailView _systemFrameView;

		public XPlayerMailView _playerFrameView;

		public XContentMailView _contMailView;

		private XMailDocument _doc = null;

		public GameObject m_systemFramePanel;

		public GameObject m_playerFramePanel;

		public GameObject m_contentFramePanel;

		public Transform tabTpl;

		public XUITabControl m_tabcontrol = new XUITabControl();
	}
}
