using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BC8 RID: 3016
	internal class BroadcastBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600AC26 RID: 44070 RVA: 0x001FA278 File Offset: 0x001F8478
		private void Awake()
		{
			this.m_btnBarrage = (base.transform.Find("Bg/Btn_EndBarrage").GetComponent("XUIButton") as IXUIButton);
			this.m_btnCamera = (base.transform.Find("Bg/Btn_Camera").GetComponent("XUIButton") as IXUIButton);
			this.m_lblCamera = (base.transform.Find("Bg/Btn_Camera/T").GetComponent("XUILabel") as IXUILabel);
			this.m_btnClose = (base.transform.Find("Bg/Btn_Close").GetComponent("XUIButton") as IXUIButton);
			this.m_btnShare = (base.transform.Find("Bg/Btn_Share").GetComponent("XUIButton") as IXUIButton);
			this.loopScrool = (base.transform.FindChild("Bg/Barrages").GetComponent("LoopScrollView") as ILoopScrollView);
		}

		// Token: 0x040040C3 RID: 16579
		public ILoopScrollView loopScrool;

		// Token: 0x040040C4 RID: 16580
		public IXUIButton m_btnBarrage;

		// Token: 0x040040C5 RID: 16581
		public IXUIButton m_btnCamera;

		// Token: 0x040040C6 RID: 16582
		public IXUILabel m_lblCamera;

		// Token: 0x040040C7 RID: 16583
		public IXUIButton m_btnClose;

		// Token: 0x040040C8 RID: 16584
		public IXUIButton m_btnShare;
	}
}
