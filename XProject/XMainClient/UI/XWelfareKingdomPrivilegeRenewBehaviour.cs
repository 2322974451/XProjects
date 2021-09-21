using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020018E6 RID: 6374
	internal class XWelfareKingdomPrivilegeRenewBehaviour : DlgBehaviourBase
	{
		// Token: 0x060109AC RID: 68012 RVA: 0x00418B14 File Offset: 0x00416D14
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

		// Token: 0x04007898 RID: 30872
		public IXUILabel m_Title;

		// Token: 0x04007899 RID: 30873
		public IXUILabel m_Name;

		// Token: 0x0400789A RID: 30874
		public IXUIButton m_Close;

		// Token: 0x0400789B RID: 30875
		public IXUITexture m_Icon;

		// Token: 0x0400789C RID: 30876
		public IXUILabel m_Time;

		// Token: 0x0400789D RID: 30877
		public IXUILabel m_Price;

		// Token: 0x0400789E RID: 30878
		public IXUIButton m_Buy;

		// Token: 0x0400789F RID: 30879
		public IXUILabel m_RenewSucTip;
	}
}
