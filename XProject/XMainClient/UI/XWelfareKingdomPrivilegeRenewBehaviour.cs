using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XWelfareKingdomPrivilegeRenewBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Title = (base.transform.Find("Title").GetComponent("XUILabel") as IXUILabel);
			this.m_Name = (base.transform.Find("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_Close = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Icon = (base.transform.Find("Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_Time = (base.transform.Find("Time").GetComponent("XUILabel") as IXUILabel);
			this.m_Price = (base.transform.Find("Price").GetComponent("XUILabel") as IXUILabel);
			this.m_Buy = (base.transform.Find("OK").GetComponent("XUIButton") as IXUIButton);
			this.m_RenewSucTip = (base.transform.Find("RenewSuc").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUILabel m_Title;

		public IXUILabel m_Name;

		public IXUIButton m_Close;

		public IXUITexture m_Icon;

		public IXUILabel m_Time;

		public IXUILabel m_Price;

		public IXUIButton m_Buy;

		public IXUILabel m_RenewSucTip;
	}
}
