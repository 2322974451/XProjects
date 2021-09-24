using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class SelectNumFrameBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_itemGo = base.transform.FindChild("ItemTpl").gameObject;
			this.m_closespr = (base.transform.FindChild("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_sureBtn = (base.transform.FindChild("SureBtn").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Free");
			this.m_SinglePriceOperate = new AuctionNumberOperate(transform.gameObject, new Vector3(-265f, 72f, 0f));
		}

		public GameObject m_itemGo;

		public IXUISprite m_closespr;

		public IXUIButton m_sureBtn;

		public AuctionNumberOperate m_SinglePriceOperate;
	}
}
