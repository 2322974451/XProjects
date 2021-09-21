using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000B90 RID: 2960
	internal class AuctionBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600A9B1 RID: 43441 RVA: 0x001E4124 File Offset: 0x001E2324
		private void Awake()
		{
			this.m_Help = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_framesTransform = base.transform.FindChild("Bg/frames");
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BuyFrameCheckBox = (base.transform.Find("Bg/Tabs/Buy").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_SellFrameCheckBox = (base.transform.Find("Bg/Tabs/Sell").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_GuildAucFrameCheckBox = (base.transform.Find("Bg/Tabs/GuildAuc").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_GuildAucRedPoint = base.transform.Find("Bg/Tabs/GuildAuc/RedPoint").gameObject;
		}

		// Token: 0x04003EC6 RID: 16070
		public Transform m_framesTransform;

		// Token: 0x04003EC7 RID: 16071
		public IXUIButton m_Close;

		// Token: 0x04003EC8 RID: 16072
		public IXUICheckBox m_BuyFrameCheckBox;

		// Token: 0x04003EC9 RID: 16073
		public IXUICheckBox m_SellFrameCheckBox;

		// Token: 0x04003ECA RID: 16074
		public IXUICheckBox m_GuildAucFrameCheckBox;

		// Token: 0x04003ECB RID: 16075
		public GameObject m_GuildAucRedPoint;

		// Token: 0x04003ECC RID: 16076
		public IXUIButton m_Help;
	}
}
