using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x0200171C RID: 5916
	internal class AuctionPurchaseBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F466 RID: 62566 RVA: 0x0036E3D4 File Offset: 0x0036C5D4
		private void Awake()
		{
			this.m_ItemTpl = base.transform.FindChild("Bg/ItemTpl").gameObject;
			this.m_SinglePrice = (base.transform.FindChild("Bg/Price/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_HavCoin = (base.transform.FindChild("Bg/Have/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_TotalPrice = (base.transform.FindChild("Bg/TotalPrice/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_CurCountOperate = new AuctionNumberOperate(base.transform.FindChild("Bg/Free").gameObject, new Vector3(-94f, 104f, 0f));
			this.m_Ok = (base.transform.FindChild("Bg/Ok").GetComponent("XUIButton") as IXUIButton);
			this.m_maskSprite = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x04006952 RID: 26962
		public GameObject m_ItemTpl;

		// Token: 0x04006953 RID: 26963
		public IXUILabel m_SinglePrice;

		// Token: 0x04006954 RID: 26964
		public IXUILabel m_HavCoin;

		// Token: 0x04006955 RID: 26965
		public IXUILabel m_TotalPrice;

		// Token: 0x04006956 RID: 26966
		public AuctionNumberOperate m_CurCountOperate;

		// Token: 0x04006957 RID: 26967
		public IXUIButton m_Ok;

		// Token: 0x04006958 RID: 26968
		public IXUIButton m_maskSprite;
	}
}
