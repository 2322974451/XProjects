using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016D4 RID: 5844
	internal class CompeteNestBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F10C RID: 61708 RVA: 0x003526C8 File Offset: 0x003508C8
		private void Awake()
		{
			this.m_rankTra = base.transform.FindChild("Rank");
			this.m_closedBtn = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Main/Tittles");
			this.m_tittleLab = (transform.FindChild("Tittle1").GetComponent("XUILabel") as IXUILabel);
			this.m_timesLab = (base.transform.FindChild("Main/Right/Times").GetComponent("XUILabel") as IXUILabel);
			transform = base.transform.FindChild("Main");
			this.m_bgTexture = (transform.FindChild("P").GetComponent("XUITexture") as IXUITexture);
			this.m_rankBtn = (transform.FindChild("RankBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_goBattleBtn = (transform.FindChild("Right/BtnStartTeam").GetComponent("XUIButton") as IXUIButton);
			this.m_claimBtn = (transform.FindChild("Right/BtnStartSingle").GetComponent("XUIButton") as IXUIButton);
			this.m_claimredpoint = transform.FindChild("Right/BtnStartSingle/RedPoint");
			transform = base.transform.FindChild("Main/ListPanel");
			this.m_itemsGo = transform.gameObject;
			this.m_ItemPool.SetupPool(transform.gameObject, transform.FindChild("Grid/ItemTpl").gameObject, 2U, false);
			this.m_tipsLab = (base.transform.FindChild("Main/t").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x040066EA RID: 26346
		public IXUITexture m_bgTexture;

		// Token: 0x040066EB RID: 26347
		public IXUILabel m_tittleLab;

		// Token: 0x040066EC RID: 26348
		public IXUILabel m_timesLab;

		// Token: 0x040066ED RID: 26349
		public IXUILabel m_tipsLab;

		// Token: 0x040066EE RID: 26350
		public IXUIButton m_rankBtn;

		// Token: 0x040066EF RID: 26351
		public IXUIButton m_goBattleBtn;

		// Token: 0x040066F0 RID: 26352
		public IXUIButton m_closedBtn;

		// Token: 0x040066F1 RID: 26353
		public IXUIButton m_claimBtn;

		// Token: 0x040066F2 RID: 26354
		public Transform m_claimredpoint;

		// Token: 0x040066F3 RID: 26355
		public GameObject m_itemsGo;

		// Token: 0x040066F4 RID: 26356
		public Transform m_rankTra;

		// Token: 0x040066F5 RID: 26357
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
