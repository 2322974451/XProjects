using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000A25 RID: 2597
	internal class CapacityBehaviour : DlgBehaviourBase
	{
		// Token: 0x06009EAF RID: 40623 RVA: 0x001A25A8 File Offset: 0x001A07A8
		private void Awake()
		{
			this.m_closeSpr = (base.transform.Find("Bg/Black").GetComponent("XUISprite") as IXUISprite);
			this.m_checkBox = (base.transform.Find("ItemBlock").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_lable = (base.transform.Find("Bg/Tip").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04003870 RID: 14448
		public IXUISprite m_closeSpr;

		// Token: 0x04003871 RID: 14449
		public IXUICheckBox m_checkBox;

		// Token: 0x04003872 RID: 14450
		public IXUILabel m_lable;
	}
}
