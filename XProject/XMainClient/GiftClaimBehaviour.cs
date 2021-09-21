using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BFF RID: 3071
	internal class GiftClaimBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600AEAD RID: 44717 RVA: 0x0020E50C File Offset: 0x0020C70C
		private void Awake()
		{
			this.m_transRcv = base.transform.Find("recv");
			this.m_lblName = (base.transform.Find("recv/name").GetComponent("XUILabel") as IXUILabel);
			this.m_btnOpen = (base.transform.Find("recv/ok").GetComponent("XUIButton") as IXUIButton);
			this.m_transOpen = base.transform.Find("open");
			this.m_lblTitle = (base.transform.Find("open/name").GetComponent("XUILabel") as IXUILabel);
			this.m_lblDetail = (base.transform.Find("open/desc").GetComponent("XUILabel") as IXUILabel);
			this.m_btnThanks = (base.transform.Find("open/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_objTpl = base.transform.Find("open/items/tmp").gameObject;
		}

		// Token: 0x0400425F RID: 16991
		public Transform m_transRcv;

		// Token: 0x04004260 RID: 16992
		public IXUILabel m_lblName;

		// Token: 0x04004261 RID: 16993
		public IXUIButton m_btnOpen;

		// Token: 0x04004262 RID: 16994
		public Transform m_transOpen;

		// Token: 0x04004263 RID: 16995
		public IXUILabel m_lblTitle;

		// Token: 0x04004264 RID: 16996
		public IXUILabel m_lblDetail;

		// Token: 0x04004265 RID: 16997
		public IXUIButton m_btnThanks;

		// Token: 0x04004266 RID: 16998
		public GameObject m_objTpl;
	}
}
