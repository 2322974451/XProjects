using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C85 RID: 3205
	internal class XQQVipDesBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B518 RID: 46360 RVA: 0x00239DD8 File Offset: 0x00237FD8
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Bg/Tpl");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 6U, false);
			this.m_Detail = (base.transform.Find("Bg/Detail").GetComponent("XUILabel") as IXUILabel);
			this.m_VipDesc = base.transform.Find("Bg/VipDesc");
			this.m_SVipDesc = base.transform.Find("Bg/SVipDesc");
			this.m_VipBtn = (base.transform.Find("Bg/VipDesc/Button").GetComponent("XUIButton") as IXUIButton);
			this.m_SVipBtn = (base.transform.Find("Bg/SVipDesc/Button").GetComponent("XUIButton") as IXUIButton);
			this.m_VipBtnText = (base.transform.Find("Bg/VipDesc/Button/text").GetComponent("XUILabel") as IXUILabel);
			this.m_SVipBtnText = (base.transform.Find("Bg/SVipDesc/Button/text").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0400469B RID: 18075
		public IXUIButton m_Close;

		// Token: 0x0400469C RID: 18076
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400469D RID: 18077
		public IXUILabel m_Detail;

		// Token: 0x0400469E RID: 18078
		public Transform m_VipDesc;

		// Token: 0x0400469F RID: 18079
		public Transform m_SVipDesc;

		// Token: 0x040046A0 RID: 18080
		public IXUILabel m_VipBtnText;

		// Token: 0x040046A1 RID: 18081
		public IXUILabel m_SVipBtnText;

		// Token: 0x040046A2 RID: 18082
		public IXUIButton m_VipBtn;

		// Token: 0x040046A3 RID: 18083
		public IXUIButton m_SVipBtn;
	}
}
