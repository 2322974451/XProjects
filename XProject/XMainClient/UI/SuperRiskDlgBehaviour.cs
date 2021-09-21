using System;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001816 RID: 6166
	internal class SuperRiskDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600FFD4 RID: 65492 RVA: 0x003C897D File Offset: 0x003C6B7D
		private void Awake()
		{
			this.m_SelectMapPanel = base.transform.Find("Bg/SelectMap").gameObject;
			this.m_RiskMapPanel = base.transform.Find("Bg/RiskMap").gameObject;
		}

		// Token: 0x04007154 RID: 29012
		public GameObject m_SelectMapPanel;

		// Token: 0x04007155 RID: 29013
		public GameObject m_RiskMapPanel;
	}
}
