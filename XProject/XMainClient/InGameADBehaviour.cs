using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C6D RID: 3181
	internal class InGameADBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B409 RID: 46089 RVA: 0x00231D60 File Offset: 0x0022FF60
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Tex = (base.transform.FindChild("Tex").GetComponent("XUITexture") as IXUITexture);
			this.m_BtnGo = (base.transform.FindChild("BtnGo").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x040045CD RID: 17869
		public IXUIButton m_Close;

		// Token: 0x040045CE RID: 17870
		public IXUITexture m_Tex;

		// Token: 0x040045CF RID: 17871
		public IXUISprite m_BtnGo;
	}
}
