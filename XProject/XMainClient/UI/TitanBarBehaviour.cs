using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017AA RID: 6058
	internal class TitanBarBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600FA74 RID: 64116 RVA: 0x0039E4C4 File Offset: 0x0039C6C4
		private void Awake()
		{
			Transform transform = base.transform.Find("TitanFrame/ItemTpl");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
		}

		// Token: 0x04006DC5 RID: 28101
		public List<XTitanItem> m_ItemList = new List<XTitanItem>();

		// Token: 0x04006DC6 RID: 28102
		public List<GameObject> m_ItemGoList = new List<GameObject>();

		// Token: 0x04006DC7 RID: 28103
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
