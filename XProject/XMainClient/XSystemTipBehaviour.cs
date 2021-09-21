using System;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E5E RID: 3678
	internal class XSystemTipBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C515 RID: 50453 RVA: 0x002B5948 File Offset: 0x002B3B48
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/TipTpl");
			this.m_TipPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
		}

		// Token: 0x04005620 RID: 22048
		public XUIPool m_TipPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
