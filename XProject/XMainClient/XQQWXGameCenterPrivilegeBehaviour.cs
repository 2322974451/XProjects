using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000CAD RID: 3245
	internal class XQQWXGameCenterPrivilegeBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B6B3 RID: 46771 RVA: 0x00243BB4 File Offset: 0x00241DB4
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Title = (base.transform.Find("Bg/Title").GetComponent("XUILabel") as IXUILabel);
			this.m_Privilege1 = (base.transform.Find("Bg/P1").GetComponent("XUILabel") as IXUILabel);
			this.m_Privilege2 = (base.transform.Find("Bg/P2").GetComponent("XUILabel") as IXUILabel);
			this.m_Privilege3 = (base.transform.Find("Bg/P3").GetComponent("XUILabel") as IXUILabel);
			this.m_QQIcon = base.transform.Find("Bg/P1/qq").gameObject;
			this.m_WXIcon = base.transform.Find("Bg/P1/wc").gameObject;
		}

		// Token: 0x0400477D RID: 18301
		public IXUIButton m_Close;

		// Token: 0x0400477E RID: 18302
		public IXUILabel m_Title;

		// Token: 0x0400477F RID: 18303
		public IXUILabel m_Privilege1;

		// Token: 0x04004780 RID: 18304
		public IXUILabel m_Privilege2;

		// Token: 0x04004781 RID: 18305
		public IXUILabel m_Privilege3;

		// Token: 0x04004782 RID: 18306
		public GameObject m_QQIcon;

		// Token: 0x04004783 RID: 18307
		public GameObject m_WXIcon;
	}
}
