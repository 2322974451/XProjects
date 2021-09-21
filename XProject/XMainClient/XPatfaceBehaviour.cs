using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000B8C RID: 2956
	internal class XPatfaceBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600A999 RID: 43417 RVA: 0x001E3D8C File Offset: 0x001E1F8C
		private void Awake()
		{
			this.m_OK = (base.transform.Find("Bg/Ok").GetComponent("XUIButton") as IXUIButton);
			this.m_Pic = (base.transform.Find("Bg/Texture").GetComponent("XUITexture") as IXUITexture);
		}

		// Token: 0x04003EC0 RID: 16064
		public IXUIButton m_OK;

		// Token: 0x04003EC1 RID: 16065
		public IXUITexture m_Pic;
	}
}
