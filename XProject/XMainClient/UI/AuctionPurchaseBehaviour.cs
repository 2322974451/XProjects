using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class AuctionPurchaseBehaviour : DlgBehaviourBase
	{

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

		public GameObject m_ItemTpl;

		public IXUILabel m_SinglePrice;

		public IXUILabel m_HavCoin;

		public IXUILabel m_TotalPrice;

		public AuctionNumberOperate m_CurCountOperate;

		public IXUIButton m_Ok;

		public IXUIButton m_maskSprite;
	}
}
