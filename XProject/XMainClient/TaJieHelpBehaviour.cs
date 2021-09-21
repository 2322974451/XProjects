using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000CA3 RID: 3235
	internal class TaJieHelpBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B63E RID: 46654 RVA: 0x00241B94 File Offset: 0x0023FD94
		private void Awake()
		{
			this.m_parentGo = base.gameObject;
			this.m_closedBtn = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_wrapContent = (base.transform.FindChild("Bg/detail/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		// Token: 0x04004751 RID: 18257
		public GameObject m_parentGo;

		// Token: 0x04004752 RID: 18258
		public IXUIButton m_closedBtn;

		// Token: 0x04004753 RID: 18259
		public IXUIWrapContent m_wrapContent;
	}
}
