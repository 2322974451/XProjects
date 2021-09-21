using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000E56 RID: 3670
	internal class XShowGetAchivementTipBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C4C3 RID: 50371 RVA: 0x002B18F4 File Offset: 0x002AFAF4
		private void Awake()
		{
			this.m_AchivementName = (base.transform.FindChild("Bg/Label1").GetComponent("XUILabel") as IXUILabel);
			this.m_AchivementText = (base.transform.FindChild("Bg/Label2").GetComponent("XUILabel") as IXUILabel);
			this.m_Bg = base.transform.FindChild("Bg").gameObject;
			this.m_AchivementName2 = (base.transform.FindChild("Bg1/Label1").GetComponent("XUILabel") as IXUILabel);
			this.m_AchivementText2 = (base.transform.FindChild("Bg1/Label2").GetComponent("XUILabel") as IXUILabel);
			this.m_Bg2 = base.transform.FindChild("Bg1").gameObject;
			this.m_Bg2.SetActive(false);
		}

		// Token: 0x040055CD RID: 21965
		public GameObject m_Bg;

		// Token: 0x040055CE RID: 21966
		public IXUILabel m_AchivementName;

		// Token: 0x040055CF RID: 21967
		public IXUILabel m_AchivementText;

		// Token: 0x040055D0 RID: 21968
		public GameObject m_Bg2;

		// Token: 0x040055D1 RID: 21969
		public IXUILabel m_AchivementName2;

		// Token: 0x040055D2 RID: 21970
		public IXUILabel m_AchivementText2;
	}
}
