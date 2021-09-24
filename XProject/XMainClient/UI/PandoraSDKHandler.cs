using System;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class PandoraSDKHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "OperatingActivity/PandoraFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ShowPandoraTab();
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.HidePandoraTab();
		}

		private void ShowPandoraTab()
		{
			bool flag = this.currSys == XSysDefine.XSys_None;
			if (!flag)
			{
				int sysID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this.currSys);
				XSingleton<XPandoraSDKDocument>.singleton.ShowPandoraTab(sysID, true, base.PanelObject);
			}
		}

		private void HidePandoraTab()
		{
			bool flag = this.currSys == XSysDefine.XSys_None;
			if (!flag)
			{
				int sysID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this.currSys);
				XSingleton<XPandoraSDKDocument>.singleton.ShowPandoraTab(sysID, false, base.PanelObject);
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		public void SetCurrSys(XSysDefine sys)
		{
			this.currSys = sys;
		}

		private XSysDefine currSys = XSysDefine.XSys_None;
	}
}
