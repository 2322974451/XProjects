using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CEC RID: 3308
	internal class XCharacterCommonMenuBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B939 RID: 47417 RVA: 0x002591BC File Offset: 0x002573BC
		private void Awake()
		{
			Transform transform = base.transform.Find("Bg");
			this.playerView = new XPlayerInfoChildView();
			this.playerView.FindFrom(transform);
			this.m_bgTra = transform;
			this.m_parentTra = transform.FindChild("buttons");
			this.m_bgSpr = (transform.FindChild("Bg").GetComponent("XUISprite") as IXUISprite);
			this.TotalHeight = this.m_bgSpr.spriteHeight;
			this.m_sprFrame = (transform.FindChild("AvatarFrame").GetComponent("XUISprite") as IXUISprite);
			this.btnSendFlower = (transform.Find("send").GetComponent("XUIButton") as IXUIButton);
			this.btnExchange = (transform.Find("CardChange").GetComponent("XUIButton") as IXUIButton);
			this.btnClose = (base.transform.FindChild("BgBlack").GetComponent("XUIButton") as IXUIButton);
			this.m_btntemPool.SetupPool(transform.gameObject, transform.FindChild("BtnTpl").gameObject, 5U, true);
		}

		// Token: 0x040049BE RID: 18878
		public XPlayerInfoChildView playerView;

		// Token: 0x040049BF RID: 18879
		public XUIPool m_btntemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040049C0 RID: 18880
		public Transform m_bgTra;

		// Token: 0x040049C1 RID: 18881
		public Transform m_parentTra;

		// Token: 0x040049C2 RID: 18882
		public IXUISprite m_bgSpr;

		// Token: 0x040049C3 RID: 18883
		public IXUIButton btnSendFlower;

		// Token: 0x040049C4 RID: 18884
		public IXUIButton btnExchange;

		// Token: 0x040049C5 RID: 18885
		public IXUIButton btnClose;

		// Token: 0x040049C6 RID: 18886
		public IXUISprite m_sprFrame;

		// Token: 0x040049C7 RID: 18887
		public int TotalHeight = 0;
	}
}
