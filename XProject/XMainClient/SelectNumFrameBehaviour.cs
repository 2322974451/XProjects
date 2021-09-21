using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C6F RID: 3183
	internal class SelectNumFrameBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B418 RID: 46104 RVA: 0x00231F54 File Offset: 0x00230154
		private void Awake()
		{
			this.m_itemGo = base.transform.FindChild("ItemTpl").gameObject;
			this.m_closespr = (base.transform.FindChild("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_sureBtn = (base.transform.FindChild("SureBtn").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Free");
			this.m_SinglePriceOperate = new AuctionNumberOperate(transform.gameObject, new Vector3(-265f, 72f, 0f));
		}

		// Token: 0x040045D0 RID: 17872
		public GameObject m_itemGo;

		// Token: 0x040045D1 RID: 17873
		public IXUISprite m_closespr;

		// Token: 0x040045D2 RID: 17874
		public IXUIButton m_sureBtn;

		// Token: 0x040045D3 RID: 17875
		public AuctionNumberOperate m_SinglePriceOperate;
	}
}
