using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001821 RID: 6177
	internal class EquipCreateDlg : TabDlgBase<EquipCreateDlg>
	{
		// Token: 0x1700391A RID: 14618
		// (get) Token: 0x060100A6 RID: 65702 RVA: 0x003D1ACC File Offset: 0x003CFCCC
		public override string fileName
		{
			get
			{
				return "GameSystem/EquipCreateDlg";
			}
		}

		// Token: 0x1700391B RID: 14619
		// (get) Token: 0x060100A7 RID: 65703 RVA: 0x003D1AE4 File Offset: 0x003CFCE4
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x060100A8 RID: 65704 RVA: 0x003D1AF7 File Offset: 0x003CFCF7
		protected override void Init()
		{
			base.Init();
			this.m_Help = (base.uiBehaviour.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_EquipCreate);
		}

		// Token: 0x1700391C RID: 14620
		// (get) Token: 0x060100A9 RID: 65705 RVA: 0x003D1B34 File Offset: 0x003CFD34
		protected override bool bHorizontal
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060100AA RID: 65706 RVA: 0x003D1B48 File Offset: 0x003CFD48
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

		// Token: 0x060100AB RID: 65707 RVA: 0x003D1C64 File Offset: 0x003CFE64
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

		// Token: 0x060100AC RID: 65708 RVA: 0x003D1CD8 File Offset: 0x003CFED8
		public override void SetupRedpointEx()
		{
			base.SetupRedpointEx();
		}

		// Token: 0x060100AD RID: 65709 RVA: 0x003D1CE4 File Offset: 0x003CFEE4
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

		// Token: 0x060100AE RID: 65710 RVA: 0x003D1D3C File Offset: 0x003CFF3C
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

		// Token: 0x060100AF RID: 65711 RVA: 0x003D1DDD File Offset: 0x003CFFDD
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		// Token: 0x060100B0 RID: 65712 RVA: 0x003D1E00 File Offset: 0x003D0000
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_EquipCreate);
			return true;
		}

		// Token: 0x04007221 RID: 29217
		public EquipSetHandler equipSetHandler;

		// Token: 0x04007222 RID: 29218
		private GameObject equipSetFrame;

		// Token: 0x04007223 RID: 29219
		public EmblemSetHandler emblemSetHandler;

		// Token: 0x04007224 RID: 29220
		private GameObject emblemSetFrame;

		// Token: 0x04007225 RID: 29221
		public EquipSetCreateHandler equipSetCreateHandler;

		// Token: 0x04007226 RID: 29222
		private GameObject equipSetCreateFrame;

		// Token: 0x04007227 RID: 29223
		public EquipSetCreateConfirmHandler equipSetCreateConfirmHandler;

		// Token: 0x04007228 RID: 29224
		private GameObject equipSetCreateConfirmFrame;

		// Token: 0x04007229 RID: 29225
		public ArtifactSetHandler m_artifactSetHandler;

		// Token: 0x0400722A RID: 29226
		private GameObject m_artifactSetFrame;

		// Token: 0x0400722B RID: 29227
		public IXUIButton m_Help;
	}
}
