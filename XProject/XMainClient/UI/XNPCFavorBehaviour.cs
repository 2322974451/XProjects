using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020017D1 RID: 6097
	internal class XNPCFavorBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600FC8F RID: 64655 RVA: 0x003AEE50 File Offset: 0x003AD050
		private void Awake()
		{
			this.m_effect = base.transform.FindChild("Effect");
			this.m_Help = (base.transform.FindChild("Help").GetComponent("XUIButton") as IXUIButton);
			this.m_Close = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_handlersTra = base.transform.FindChild("Handler");
			this.m_SendTimesLabel = (base.transform.FindChild("Time").GetComponent("XUILabel") as IXUILabel);
			this.m_AddBtn = (base.transform.FindChild("Time/Add").GetComponent("XUIButton") as IXUIButton);
			this.m_SendTimesBtn = (base.transform.FindChild("Time/tq/p").GetComponent("XUISprite") as IXUISprite);
			this.m_PrivilegeSpr = (base.transform.FindChild("Time/tq").GetComponent("XUISprite") as IXUISprite);
			this.m_Tab0 = (base.transform.Find("Tabs/TabTpl0/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Tab1 = (base.transform.Find("Tabs/TabTpl1/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Tab2 = (base.transform.Find("Tabs/TabTpl2/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Tab0_Redpoint = base.transform.Find("Tabs/TabTpl0/Bg/RedPoint").gameObject;
			this.m_Tab1_Redpoint = base.transform.Find("Tabs/TabTpl1/Bg/RedPoint").gameObject;
			this.m_Tab2_Redpoint = base.transform.Find("Tabs/TabTpl2/Bg/RedPoint").gameObject;
		}

		// Token: 0x04006F03 RID: 28419
		public Transform m_effect;

		// Token: 0x04006F04 RID: 28420
		public IXUIButton m_Help;

		// Token: 0x04006F05 RID: 28421
		public IXUIButton m_Close;

		// Token: 0x04006F06 RID: 28422
		public Transform m_handlersTra;

		// Token: 0x04006F07 RID: 28423
		public IXUILabel m_SendTimesLabel;

		// Token: 0x04006F08 RID: 28424
		public IXUIButton m_AddBtn;

		// Token: 0x04006F09 RID: 28425
		public IXUISprite m_PrivilegeSpr;

		// Token: 0x04006F0A RID: 28426
		public IXUISprite m_SendTimesBtn;

		// Token: 0x04006F0B RID: 28427
		public IXUICheckBox m_Tab0;

		// Token: 0x04006F0C RID: 28428
		public IXUICheckBox m_Tab1;

		// Token: 0x04006F0D RID: 28429
		public IXUICheckBox m_Tab2;

		// Token: 0x04006F0E RID: 28430
		public GameObject m_Tab0_Redpoint;

		// Token: 0x04006F0F RID: 28431
		public GameObject m_Tab1_Redpoint;

		// Token: 0x04006F10 RID: 28432
		public GameObject m_Tab2_Redpoint;
	}
}
