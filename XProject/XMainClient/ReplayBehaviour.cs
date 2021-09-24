using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class ReplayBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_btn_camera = (base.transform.Find("SysGridV3/SysCDanceBtn2").GetComponent("XUIButton") as IXUIButton);
			this.m_btn_mic = (base.transform.Find("SysGridV3/SysCDanceBtn3").GetComponent("XUIButton") as IXUIButton);
			this.m_btn_stop = (base.transform.Find("SysGridV3/SysCDanceBtn1").GetComponent("XUIButton") as IXUIButton);
			this.m_btn_switch = (base.transform.Find("SysGridV3/SysEPhoto").GetComponent("XUIButton") as IXUIButton);
			this.m_spr_disable_camera = (this.m_btn_camera.gameObject.transform.FindChild("off").GetComponent("XUISprite") as IXUISprite);
			this.m_spr_disable_mic = (this.m_btn_mic.gameObject.transform.FindChild("off").GetComponent("XUISprite") as IXUISprite);
		}

		public IXUIButton m_btn_camera;

		public IXUISprite m_spr_disable_camera;

		public IXUIButton m_btn_mic;

		public IXUISprite m_spr_disable_mic;

		public IXUIButton m_btn_stop;

		public IXUIButton m_btn_switch;
	}
}
