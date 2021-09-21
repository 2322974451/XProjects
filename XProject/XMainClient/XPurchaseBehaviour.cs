using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000E4C RID: 3660
	internal class XPurchaseBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C45A RID: 50266 RVA: 0x002ADABC File Offset: 0x002ABCBC
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

		// Token: 0x0400556D RID: 21869
		public IXUIButton m_QuitBtn;

		// Token: 0x0400556E RID: 21870
		public IXUILabel m_Title;

		// Token: 0x0400556F RID: 21871
		public IXUILabel m_BuyNumLeft;

		// Token: 0x04005570 RID: 21872
		public IXUILabel m_BuyNumError;

		// Token: 0x04005571 RID: 21873
		public IXUILabelSymbol m_BuyNum;

		// Token: 0x04005572 RID: 21874
		public IXUILabel m_Time;

		// Token: 0x04005573 RID: 21875
		public IXUILabel m_Tips;

		// Token: 0x04005574 RID: 21876
		public IXUIButton m_QuickBuyDiamond;

		// Token: 0x04005575 RID: 21877
		public IXUIButton m_QuickBuyDiamond10;

		// Token: 0x04005576 RID: 21878
		public IXUIButton m_QuickBuyDragonCoin;

		// Token: 0x04005577 RID: 21879
		public IXUILabelSymbol m_QuickBuyCost;
	}
}
