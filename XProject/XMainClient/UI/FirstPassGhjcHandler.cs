using System;
using UILib;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017DD RID: 6109
	internal class FirstPassGhjcHandler : DlgHandlerBase
	{
		// Token: 0x170038B1 RID: 14513
		// (get) Token: 0x0600FD2C RID: 64812 RVA: 0x003B440C File Offset: 0x003B260C
		protected override string FileName
		{
			get
			{
				return "OperatingActivity/FirstPassGhjc";
			}
		}

		// Token: 0x0600FD2D RID: 64813 RVA: 0x003B4423 File Offset: 0x003B2623
		protected override void Init()
		{
			base.Init();
			this.m_btnGo = (base.transform.Find("BtnGo").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x0600FD2E RID: 64814 RVA: 0x003B4452 File Offset: 0x003B2652
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnGo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnClick));
		}

		// Token: 0x0600FD2F RID: 64815 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600FD30 RID: 64816 RVA: 0x003B4474 File Offset: 0x003B2674
		private bool OnBtnClick(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Team, 0UL);
			return true;
		}

		// Token: 0x04006F7A RID: 28538
		public IXUIButton m_btnGo;
	}
}
