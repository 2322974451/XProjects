using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BE2 RID: 3042
	internal class ReplayBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600AD57 RID: 44375 RVA: 0x00201FCC File Offset: 0x002001CC
		private void Awake()
		{
			this.m_btn_camera = (base.transform.Find("SysGridV3/SysCDanceBtn2").GetComponent("XUIButton") as IXUIButton);
			this.m_btn_mic = (base.transform.Find("SysGridV3/SysCDanceBtn3").GetComponent("XUIButton") as IXUIButton);
			this.m_btn_stop = (base.transform.Find("SysGridV3/SysCDanceBtn1").GetComponent("XUIButton") as IXUIButton);
			this.m_btn_switch = (base.transform.Find("SysGridV3/SysEPhoto").GetComponent("XUIButton") as IXUIButton);
			this.m_spr_disable_camera = (this.m_btn_camera.gameObject.transform.FindChild("off").GetComponent("XUISprite") as IXUISprite);
			this.m_spr_disable_mic = (this.m_btn_mic.gameObject.transform.FindChild("off").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x04004148 RID: 16712
		public IXUIButton m_btn_camera;

		// Token: 0x04004149 RID: 16713
		public IXUISprite m_spr_disable_camera;

		// Token: 0x0400414A RID: 16714
		public IXUIButton m_btn_mic;

		// Token: 0x0400414B RID: 16715
		public IXUISprite m_spr_disable_mic;

		// Token: 0x0400414C RID: 16716
		public IXUIButton m_btn_stop;

		// Token: 0x0400414D RID: 16717
		public IXUIButton m_btn_switch;
	}
}
