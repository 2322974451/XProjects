using System;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016D0 RID: 5840
	internal class XBackFlowPandoraSDKHandler : DlgHandlerBase
	{
		// Token: 0x1700373C RID: 14140
		// (get) Token: 0x0600F0E5 RID: 61669 RVA: 0x0035182C File Offset: 0x0034FA2C
		protected override string FileName
		{
			get
			{
				return "Hall/BfPandoraSDKHandler";
			}
		}

		// Token: 0x0600F0E6 RID: 61670 RVA: 0x00226F6F File Offset: 0x0022516F
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x0600F0E7 RID: 61671 RVA: 0x00351843 File Offset: 0x0034FA43
		protected override void OnShow()
		{
			base.OnShow();
			this.ShowPandoraTab();
		}

		// Token: 0x0600F0E8 RID: 61672 RVA: 0x00351854 File Offset: 0x0034FA54
		protected override void OnHide()
		{
			base.OnHide();
			this.HidePandoraTab();
		}

		// Token: 0x0600F0E9 RID: 61673 RVA: 0x00351868 File Offset: 0x0034FA68
		private void ShowPandoraTab()
		{
			bool flag = this.currSys == XSysDefine.XSys_None;
			if (!flag)
			{
				int sysID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this.currSys);
				XSingleton<XPandoraSDKDocument>.singleton.ShowPandoraTab(sysID, true, base.PanelObject);
			}
		}

		// Token: 0x0600F0EA RID: 61674 RVA: 0x003518A4 File Offset: 0x0034FAA4
		private void HidePandoraTab()
		{
			bool flag = this.currSys == XSysDefine.XSys_None;
			if (!flag)
			{
				int sysID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this.currSys);
				XSingleton<XPandoraSDKDocument>.singleton.ShowPandoraTab(sysID, false, base.PanelObject);
			}
		}

		// Token: 0x0600F0EB RID: 61675 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600F0EC RID: 61676 RVA: 0x003518E0 File Offset: 0x0034FAE0
		public void SetCurrSys(XSysDefine sys)
		{
			this.currSys = sys;
		}

		// Token: 0x040066CD RID: 26317
		private XSysDefine currSys = XSysDefine.XSys_None;
	}
}
