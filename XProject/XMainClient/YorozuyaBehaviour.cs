using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E93 RID: 3731
	internal class YorozuyaBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C72B RID: 50987 RVA: 0x002C30A8 File Offset: 0x002C12A8
		private void Awake()
		{
			this.m_closedBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_parentTra = base.transform.Find("Bg/Panel");
			this.m_itemPool.SetupPool(base.transform.Find("Bg").gameObject, base.transform.Find("Bg/Panel/Tpl").gameObject, 2U, true);
		}

		// Token: 0x04005783 RID: 22403
		public IXUIButton m_closedBtn;

		// Token: 0x04005784 RID: 22404
		public Transform m_parentTra;

		// Token: 0x04005785 RID: 22405
		public XUIPool m_itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
