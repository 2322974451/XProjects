using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BDF RID: 3039
	internal class RadioBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600AD41 RID: 44353 RVA: 0x00201838 File Offset: 0x001FFA38
		private void Awake()
		{
			this.m_lblMicro = (base.transform.Find("Hoster").GetComponent("XUILabel") as IXUILabel);
			this.m_btnRadio = (base.transform.Find("Btn").GetComponent("XUIButton") as IXUIButton);
			this.m_sprPlay = (base.transform.Find("Btn/Play").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x04004140 RID: 16704
		public IXUILabel m_lblMicro;

		// Token: 0x04004141 RID: 16705
		public IXUIButton m_btnRadio;

		// Token: 0x04004142 RID: 16706
		public IXUISprite m_sprPlay;
	}
}
