using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class AuctionBehaviour : DlgBehaviourBase
	{

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

		public Transform m_framesTransform;

		public IXUIButton m_Close;

		public IXUICheckBox m_BuyFrameCheckBox;

		public IXUICheckBox m_SellFrameCheckBox;

		public IXUICheckBox m_GuildAucFrameCheckBox;

		public GameObject m_GuildAucRedPoint;

		public IXUIButton m_Help;
	}
}
