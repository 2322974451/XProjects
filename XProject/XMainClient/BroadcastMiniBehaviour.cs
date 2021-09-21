using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BCD RID: 3021
	internal class BroadcastMiniBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600AC3F RID: 44095 RVA: 0x001FAB05 File Offset: 0x001F8D05
		private void Awake()
		{
			this.m_btn = (base.transform.Find("Btn").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x040040D8 RID: 16600
		public IXUIButton m_btn;
	}
}
