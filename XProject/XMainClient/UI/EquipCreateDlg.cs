using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EquipCreateDlg : TabDlgBase<EquipCreateDlg>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/EquipCreateDlg";
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
			this.m_Help = (base.uiBehaviour.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_EquipCreate);
		}

		protected override bool bHorizontal
		{
			get
			{
				return false;
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			this.equipSetFrame = base.uiBehaviour.transform.Find("Bg/EquipSetFrame").gameObject;
			this.emblemSetFrame = base.uiBehaviour.transform.Find("Bg/EmblemSetFrame").gameObject;
			this.equipSetCreateFrame = base.uiBehaviour.transform.Find("Bg/EquipSetCreateFrame").gameObject;
			this.equipSetCreateConfirmFrame = base.uiBehaviour.transform.Find("Bg/EquipSetCreateConfirmFrame").gameObject;
			this.m_artifactSetFrame = base.uiBehaviour.transform.Find("Bg/ArtifactSetFrame").gameObject;
			DlgHandlerBase.EnsureCreate<EquipSetHandler>(ref this.equipSetHandler, this.equipSetFrame, null, false);
			DlgHandlerBase.EnsureCreate<EmblemSetHandler>(ref this.emblemSetHandler, this.emblemSetFrame, null, false);
			DlgHandlerBase.EnsureCreate<EquipSetCreateHandler>(ref this.equipSetCreateHandler, this.equipSetCreateFrame, null, false);
			DlgHandlerBase.EnsureCreate<EquipSetCreateConfirmHandler>(ref this.equipSetCreateConfirmHandler, this.equipSetCreateConfirmFrame, null, false);
			DlgHandlerBase.EnsureCreate<ArtifactSetHandler>(ref this.m_artifactSetHandler, this.m_artifactSetFrame, null, false);
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<EquipSetCreateHandler>(ref this.equipSetCreateHandler);
			this.equipSetCreateFrame = null;
			DlgHandlerBase.EnsureUnload<EquipSetCreateConfirmHandler>(ref this.equipSetCreateConfirmHandler);
			this.equipSetCreateConfirmFrame = null;
			DlgHandlerBase.EnsureUnload<EquipSetHandler>(ref this.equipSetHandler);
			this.equipSetFrame = null;
			DlgHandlerBase.EnsureUnload<EmblemSetHandler>(ref this.emblemSetHandler);
			this.emblemSetFrame = null;
			DlgHandlerBase.EnsureUnload<ArtifactSetHandler>(ref this.m_artifactSetHandler);
			this.m_artifactSetFrame = null;
			base.OnUnload();
		}

		public override void SetupRedpointEx()
		{
			base.SetupRedpointEx();
		}

		public override void StackRefresh()
		{
			for (int i = 0; i < this.m_ActiveHandlers.Count; i++)
			{
				bool flag = this.m_ActiveHandlers[i] != null;
				if (flag)
				{
					this.m_ActiveHandlers[i].StackRefresh();
				}
			}
			base.StackRefresh();
		}

		public override void SetupHandlers(XSysDefine sys)
		{
			switch (sys)
			{
			case XSysDefine.XSys_EquipCreate_EquipSet:
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<EquipSetHandler>(ref this.equipSetHandler, this.equipSetFrame, this, true));
				break;
			case XSysDefine.XSys_EquipCreate_EmblemSet:
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<EmblemSetHandler>(ref this.emblemSetHandler, this.emblemSetFrame, this, true));
				break;
			case XSysDefine.XSys_EquipCreate_ArtifactSet:
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<ArtifactSetHandler>(ref this.m_artifactSetHandler, this.m_artifactSetFrame, this, true));
				break;
			default:
				XSingleton<XDebug>.singleton.AddErrorLog("System has not finished:", sys.ToString(), null, null, null, null);
				break;
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_EquipCreate);
			return true;
		}

		public EquipSetHandler equipSetHandler;

		private GameObject equipSetFrame;

		public EmblemSetHandler emblemSetHandler;

		private GameObject emblemSetFrame;

		public EquipSetCreateHandler equipSetCreateHandler;

		private GameObject equipSetCreateFrame;

		public EquipSetCreateConfirmHandler equipSetCreateConfirmHandler;

		private GameObject equipSetCreateConfirmFrame;

		public ArtifactSetHandler m_artifactSetHandler;

		private GameObject m_artifactSetFrame;

		public IXUIButton m_Help;
	}
}
