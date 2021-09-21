using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x0200179E RID: 6046
	internal class HomePlantBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F9D0 RID: 63952 RVA: 0x00399266 File Offset: 0x00397466
		private void Awake()
		{
			this.m_closedSpr = (base.transform.FindChild("Bg/Close").GetComponent("XUISprite") as IXUISprite);
			this.m_handlerTra = base.transform.FindChild("Bg/SeedHandler");
		}

		// Token: 0x04006D5D RID: 27997
		public IXUISprite m_closedSpr;

		// Token: 0x04006D5E RID: 27998
		public Transform m_handlerTra;
	}
}
