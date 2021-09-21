using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000B94 RID: 2964
	internal class CutoverViewBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600A9D4 RID: 43476 RVA: 0x001E49AC File Offset: 0x001E2BAC
		private void Awake()
		{
			this.m_OK = (base.transform.Find("Bg/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_3D = (base.transform.Find("Bg/3D").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_25D = (base.transform.Find("Bg/2.5D").GetComponent("XUICheckBox") as IXUICheckBox);
		}

		// Token: 0x04003EE2 RID: 16098
		public IXUICheckBox m_3D;

		// Token: 0x04003EE3 RID: 16099
		public IXUICheckBox m_25D;

		// Token: 0x04003EE4 RID: 16100
		public IXUIButton m_OK;
	}
}
