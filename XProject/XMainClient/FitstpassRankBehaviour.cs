using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C59 RID: 3161
	internal class FitstpassRankBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B321 RID: 45857 RVA: 0x0022C6D8 File Offset: 0x0022A8D8
		private void Awake()
		{
			this.m_needHideTittleGo = base.transform.FindChild("Top/T4").gameObject;
			this.m_tittleLab = (base.transform.FindChild("Tittle").GetComponent("XUILabel") as IXUILabel);
			this.m_tittleLab.SetText(string.Empty);
			this.m_closeBtn = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Panel");
			this.m_wrapContent = (transform.FindChild("FourNameList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_tipsGo = base.transform.FindChild("Tips").gameObject;
		}

		// Token: 0x04004546 RID: 17734
		public IXUIButton m_closeBtn;

		// Token: 0x04004547 RID: 17735
		public IXUIWrapContent m_wrapContent;

		// Token: 0x04004548 RID: 17736
		public IXUILabel m_tittleLab;

		// Token: 0x04004549 RID: 17737
		public GameObject m_needHideTittleGo;

		// Token: 0x0400454A RID: 17738
		public GameObject m_tipsGo;
	}
}
