using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200170C RID: 5900
	internal class MobaActivityDlg : TabDlgBase<MobaActivityDlg>
	{
		// Token: 0x17003792 RID: 14226
		// (get) Token: 0x0600F398 RID: 62360 RVA: 0x003663AC File Offset: 0x003645AC
		public override string fileName
		{
			get
			{
				return "GameSystem/DailyActivity/MobaActivityDlg";
			}
		}

		// Token: 0x17003793 RID: 14227
		// (get) Token: 0x0600F399 RID: 62361 RVA: 0x003663C4 File Offset: 0x003645C4
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003794 RID: 14228
		// (get) Token: 0x0600F39A RID: 62362 RVA: 0x003663D8 File Offset: 0x003645D8
		protected override bool bHorizontal
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600F39B RID: 62363 RVA: 0x003663EB File Offset: 0x003645EB
		protected override void Init()
		{
			base.Init();
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_MobaAcitivity);
		}

		// Token: 0x0600F39C RID: 62364 RVA: 0x003663FE File Offset: 0x003645FE
		protected override void OnLoad()
		{
			base.OnLoad();
			this.parent = base.uiBehaviour.transform.FindChild("Bg");
		}

		// Token: 0x0600F39D RID: 62365 RVA: 0x00366423 File Offset: 0x00364623
		protected override void OnUnload()
		{
			base.OnUnload();
			DlgHandlerBase.EnsureUnload<PVPActivityDlg>(ref this._PVPActivityView);
		}

		// Token: 0x0600F39E RID: 62366 RVA: 0x0036643C File Offset: 0x0036463C
		public override void SetupHandlers(XSysDefine sys)
		{
			XSysDefine xsysDefine = sys;
			if (xsysDefine != XSysDefine.XSys_PVPAcitivity)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("System has not finished:", sys.ToString(), null, null, null, null);
			}
			else
			{
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<PVPActivityDlg>(ref this._PVPActivityView, this.parent, true, this));
			}
		}

		// Token: 0x0600F39F RID: 62367 RVA: 0x00366494 File Offset: 0x00364694
		public void ShowSubSystem(XSysDefine sys)
		{
			bool flag = !base.IsLoaded();
			if (flag)
			{
				base.Load();
			}
			base.ShowSubGamsSystem(sys);
		}

		// Token: 0x04006895 RID: 26773
		public PVPActivityDlg _PVPActivityView;

		// Token: 0x04006896 RID: 26774
		private Transform parent;
	}
}
