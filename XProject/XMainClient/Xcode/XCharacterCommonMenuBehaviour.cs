using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCharacterCommonMenuBehaviour : DlgBehaviourBase
	{

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

		public XPlayerInfoChildView playerView;

		public XUIPool m_btntemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public Transform m_bgTra;

		public Transform m_parentTra;

		public IXUISprite m_bgSpr;

		public IXUIButton btnSendFlower;

		public IXUIButton btnExchange;

		public IXUIButton btnClose;

		public IXUISprite m_sprFrame;

		public int TotalHeight = 0;
	}
}
