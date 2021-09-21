using System;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017E9 RID: 6121
	internal class PandoraSDKHandler : DlgHandlerBase
	{
		// Token: 0x170038BC RID: 14524
		// (get) Token: 0x0600FDB7 RID: 64951 RVA: 0x003B8B68 File Offset: 0x003B6D68
		protected override string FileName
		{
			get
			{
				return "OperatingActivity/PandoraFrame";
			}
		}

		// Token: 0x0600FDB8 RID: 64952 RVA: 0x00226F6F File Offset: 0x0022516F
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x0600FDB9 RID: 64953 RVA: 0x003B8B7F File Offset: 0x003B6D7F
		protected override void OnShow()
		{
			base.OnShow();
			this.ShowPandoraTab();
		}

		// Token: 0x0600FDBA RID: 64954 RVA: 0x003B8B90 File Offset: 0x003B6D90
		protected override void OnHide()
		{
			base.OnHide();
			this.HidePandoraTab();
		}

		// Token: 0x0600FDBB RID: 64955 RVA: 0x003B8BA4 File Offset: 0x003B6DA4
		private void ShowPandoraTab()
		{
			bool flag = this.currSys == XSysDefine.XSys_None;
			if (!flag)
			{
				int sysID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this.currSys);
				XSingleton<XPandoraSDKDocument>.singleton.ShowPandoraTab(sysID, true, base.PanelObject);
			}
		}

		// Token: 0x0600FDBC RID: 64956 RVA: 0x003B8BE0 File Offset: 0x003B6DE0
		private void HidePandoraTab()
		{
			bool flag = this.currSys == XSysDefine.XSys_None;
			if (!flag)
			{
				int sysID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this.currSys);
				XSingleton<XPandoraSDKDocument>.singleton.ShowPandoraTab(sysID, false, base.PanelObject);
			}
		}

		// Token: 0x0600FDBD RID: 64957 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600FDBE RID: 64958 RVA: 0x003B8C1C File Offset: 0x003B6E1C
		public void SetCurrSys(XSysDefine sys)
		{
			this.currSys = sys;
		}

		// Token: 0x04006FFD RID: 28669
		private XSysDefine currSys = XSysDefine.XSys_None;
	}
}
