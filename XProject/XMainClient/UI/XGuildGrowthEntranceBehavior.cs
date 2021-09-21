using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020016FA RID: 5882
	internal class XGuildGrowthEntranceBehavior : DlgBehaviourBase
	{
		// Token: 0x0600F2A5 RID: 62117 RVA: 0x0035D2FC File Offset: 0x0035B4FC
		private void Awake()
		{
			this.BuilderBtn = (base.transform.Find("Bg/Rukou0/BuilderBtn").GetComponent("XUIButton") as IXUIButton);
			this.LabBtn = (base.transform.Find("Bg/Rukou1/LabBtn").GetComponent("XUIButton") as IXUIButton);
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x040067FB RID: 26619
		public IXUIButton BuilderBtn;

		// Token: 0x040067FC RID: 26620
		public IXUIButton LabBtn;

		// Token: 0x040067FD RID: 26621
		public IXUIButton CloseBtn;
	}
}
