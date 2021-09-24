using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XPurchaseBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_QuickBuyDiamond = (base.transform.Find("bg/BuyFrame/Btn/UseDiamond").GetComponent("XUIButton") as IXUIButton);
			this.m_QuickBuyDiamond10 = (base.transform.Find("bg/BuyFrame/Btn/UseDiamond10").GetComponent("XUIButton") as IXUIButton);
			this.m_QuickBuyDragonCoin = (base.transform.Find("bg/BuyFrame/Btn/UseDragonCoin").GetComponent("XUIButton") as IXUIButton);
			this.m_QuickBuyCost = (base.transform.Find("bg/BuyFrame/num2").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_QuitBtn = (base.transform.Find("backclick").GetComponent("XUIButton") as IXUIButton);
			this.m_Tips = (base.transform.Find("bg/BuyFrame/tips").GetComponent("XUILabel") as IXUILabel);
			this.m_Title = (base.transform.Find("bg/BuyFrame/title").GetComponent("XUILabel") as IXUILabel);
			this.m_BuyNumLeft = (base.transform.Find("bg/BuyFrame/timesleft").GetComponent("XUILabel") as IXUILabel);
			this.m_BuyNumLeft.gameObject.SetActive(false);
			this.m_BuyNum = (base.transform.Find("bg/BuyFrame/num1").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_BuyNumError = (base.transform.Find("bg/BuyFrame/error").GetComponent("XUILabel") as IXUILabel);
			this.m_Time = (base.transform.Find("bg/BuyFrame/time").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUIButton m_QuitBtn;

		public IXUILabel m_Title;

		public IXUILabel m_BuyNumLeft;

		public IXUILabel m_BuyNumError;

		public IXUILabelSymbol m_BuyNum;

		public IXUILabel m_Time;

		public IXUILabel m_Tips;

		public IXUIButton m_QuickBuyDiamond;

		public IXUIButton m_QuickBuyDiamond10;

		public IXUIButton m_QuickBuyDragonCoin;

		public IXUILabelSymbol m_QuickBuyCost;
	}
}
