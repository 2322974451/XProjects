using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C58 RID: 3160
	internal class FirstPassRewardBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B31F RID: 45855 RVA: 0x0022C5F8 File Offset: 0x0022A7F8
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_itemParentGo = base.transform.FindChild("Panel/List").gameObject;
			Transform transform = this.m_itemParentGo.transform.FindChild("Tpl");
			this.m_ItemPool1.SetupPool(this.m_itemParentGo, transform.gameObject, 5U, false);
			this.m_ItemPool2.SetupPool(transform.gameObject, this.m_itemParentGo.transform.FindChild("Item").gameObject, 4U, false);
		}

		// Token: 0x04004542 RID: 17730
		public IXUIButton m_Close;

		// Token: 0x04004543 RID: 17731
		public GameObject m_itemParentGo;

		// Token: 0x04004544 RID: 17732
		public XUIPool m_ItemPool1 = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004545 RID: 17733
		public XUIPool m_ItemPool2 = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
