using System;
using UILib;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FirstPassGhjcHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "OperatingActivity/FirstPassGhjc";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_btnGo = (base.transform.Find("BtnGo").GetComponent("XUIButton") as IXUIButton);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnGo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		private bool OnBtnClick(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Team, 0UL);
			return true;
		}

		public IXUIButton m_btnGo;
	}
}
