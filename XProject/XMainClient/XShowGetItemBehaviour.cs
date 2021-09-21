using System;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E47 RID: 3655
	internal class XShowGetItemBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C443 RID: 50243 RVA: 0x002ACC40 File Offset: 0x002AAE40
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/TipTpl");
			this.m_ShowItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this.m_Bg = base.transform.FindChild("Bg");
		}

		// Token: 0x0400554A RID: 21834
		public XUIPool m_ShowItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400554B RID: 21835
		public Transform m_Bg = null;
	}
}
