using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C53 RID: 3155
	internal class AnicientBoxBahaviour : DlgBehaviourBase
	{
		// Token: 0x0600B2ED RID: 45805 RVA: 0x0022B50C File Offset: 0x0022970C
		private void Awake()
		{
			this.itemTpl = base.transform.Find("bg/ItemList/ItemTpl").gameObject;
			this.itemTpl.SetActive(false);
			this.m_title = (base.transform.Find("bg/title").GetComponent("XUILabel") as IXUILabel);
			this.m_point = (base.transform.Find("bg/tips").GetComponent("XUILabel") as IXUILabel);
			this.m_btnClaim = (base.transform.Find("bg/Bt").GetComponent("XUIButton") as IXUIButton);
			this.m_rwdpool.SetupPool(this.itemTpl.transform.parent.gameObject, this.itemTpl, 2U, false);
			this.m_black = (base.transform.Find("backclick").GetComponent("XUISprite") as IXUISprite);
			this.m_sprRed = (base.transform.Find("bg/Bt/redpoint").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x04004521 RID: 17697
		public IXUILabel m_title;

		// Token: 0x04004522 RID: 17698
		public IXUILabel m_point;

		// Token: 0x04004523 RID: 17699
		public GameObject itemTpl;

		// Token: 0x04004524 RID: 17700
		public IXUIButton m_btnClaim;

		// Token: 0x04004525 RID: 17701
		public XUIPool m_rwdpool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004526 RID: 17702
		public IXUISprite m_black;

		// Token: 0x04004527 RID: 17703
		public IXUISprite m_sprRed;
	}
}
