using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017EA RID: 6122
	internal class WeeknestBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600FDC0 RID: 64960 RVA: 0x003B8C38 File Offset: 0x003B6E38
		private void Awake()
		{
			this.m_rankTra = base.transform.FindChild("Rank");
			this.m_closedBtn = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Main/Tittles");
			this.m_tittleLab = (transform.FindChild("Tittle1").GetComponent("XUILabel") as IXUILabel);
			this.m_timesLab = (transform.FindChild("Times").GetComponent("XUILabel") as IXUILabel);
			transform = base.transform.FindChild("Main/Btns");
			this.m_rankBtn = (transform.FindChild("RankBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_goBattleBtn = (transform.FindChild("GoBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_bgTexture = (base.transform.FindChild("Main/P").GetComponent("XUITexture") as IXUITexture);
			transform = base.transform.FindChild("Main/Items");
			this.m_itemsGo = transform.gameObject;
			this.m_ItemPool.SetupPool(transform.gameObject, transform.FindChild("Item").gameObject, 2U, false);
			this.m_tipsLab = (transform.FindChild("t").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04006FFE RID: 28670
		public IXUILabel m_tittleLab;

		// Token: 0x04006FFF RID: 28671
		public IXUILabel m_timesLab;

		// Token: 0x04007000 RID: 28672
		public IXUILabel m_tipsLab;

		// Token: 0x04007001 RID: 28673
		public IXUIButton m_rankBtn;

		// Token: 0x04007002 RID: 28674
		public IXUIButton m_goBattleBtn;

		// Token: 0x04007003 RID: 28675
		public IXUIButton m_closedBtn;

		// Token: 0x04007004 RID: 28676
		public IXUITexture m_bgTexture;

		// Token: 0x04007005 RID: 28677
		public GameObject m_itemsGo;

		// Token: 0x04007006 RID: 28678
		public Transform m_rankTra;

		// Token: 0x04007007 RID: 28679
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
