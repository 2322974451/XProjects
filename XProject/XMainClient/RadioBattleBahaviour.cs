using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BE0 RID: 3040
	internal class RadioBattleBahaviour : DlgBehaviourBase
	{
		// Token: 0x0600AD43 RID: 44355 RVA: 0x002018B8 File Offset: 0x001FFAB8
		private void Awake()
		{
			this.m_btnOpen = (base.transform.Find("Select/Play").GetComponent("XUIButton") as IXUIButton);
			this.m_btnClose = (base.transform.Find("Select/Pause").GetComponent("XUIButton") as IXUIButton);
			this.m_btnRadio = (base.transform.Find("Radio").GetComponent("XUIButton") as IXUIButton);
			this.m_objSelect = base.transform.Find("Select").gameObject;
		}

		// Token: 0x04004143 RID: 16707
		public IXUIButton m_btnOpen;

		// Token: 0x04004144 RID: 16708
		public IXUIButton m_btnClose;

		// Token: 0x04004145 RID: 16709
		public IXUIButton m_btnRadio;

		// Token: 0x04004146 RID: 16710
		public GameObject m_objSelect;
	}
}
