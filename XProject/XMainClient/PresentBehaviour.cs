using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C02 RID: 3074
	internal class PresentBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600AEC2 RID: 44738 RVA: 0x0020EB48 File Offset: 0x0020CD48
		private void Awake()
		{
			this.m_btnPay = (base.transform.Find("OK").GetComponent("XUIButton") as IXUIButton);
			this.m_btnCancel = (base.transform.Find("Cancel").GetComponent("XUIButton") as IXUIButton);
			this.m_input = (base.transform.Find("item2/input").GetComponent("XUIInput") as IXUIInput);
			this.m_icon = base.transform.Find("item2").gameObject;
			this.m_lblPrice = (base.transform.Find("item2/Price").GetComponent("XUILabel") as IXUILabel);
			this.m_lblTitle = (base.transform.Find("item2/Title").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04004271 RID: 17009
		public IXUIButton m_btnPay;

		// Token: 0x04004272 RID: 17010
		public IXUIButton m_btnCancel;

		// Token: 0x04004273 RID: 17011
		public IXUIInput m_input;

		// Token: 0x04004274 RID: 17012
		public GameObject m_icon;

		// Token: 0x04004275 RID: 17013
		public IXUILabel m_lblPrice;

		// Token: 0x04004276 RID: 17014
		public IXUILabel m_lblTitle;
	}
}
