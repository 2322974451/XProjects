using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class MobaActivityDlg : TabDlgBase<MobaActivityDlg>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/DailyActivity/MobaActivityDlg";
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		protected override bool bHorizontal
		{
			get
			{
				return false;
			}
		}

		protected override void Init()
		{
			base.Init();
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_MobaAcitivity);
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			this.parent = base.uiBehaviour.transform.FindChild("Bg");
		}

		protected override void OnUnload()
		{
			base.OnUnload();
			DlgHandlerBase.EnsureUnload<PVPActivityDlg>(ref this._PVPActivityView);
		}

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

		public void ShowSubSystem(XSysDefine sys)
		{
			bool flag = !base.IsLoaded();
			if (flag)
			{
				base.Load();
			}
			base.ShowSubGamsSystem(sys);
		}

		public PVPActivityDlg _PVPActivityView;

		private Transform parent;
	}
}
