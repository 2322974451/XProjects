using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020018E3 RID: 6371
	internal class XWelfareKingdomPrivilegeDetailBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010997 RID: 67991 RVA: 0x00417E50 File Offset: 0x00416050
		private void Awake()
		{
			this.m_Title = (base.transform.Find("Title").GetComponent("XUILabel") as IXUILabel);
			this.m_ScrollView = (base.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_Content = (base.transform.Find("ScrollView/Content").GetComponent("XUILabel") as IXUILabel);
			this.m_Close = (base.transform.Find("Btn").GetComponent("XUIButton") as IXUIButton);
			this.m_Icon = (base.transform.Find("Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_Name = (base.transform.Find("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_Notice = (base.transform.Find("Notice").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0400788C RID: 30860
		public IXUILabel m_Title;

		// Token: 0x0400788D RID: 30861
		public IXUIScrollView m_ScrollView;

		// Token: 0x0400788E RID: 30862
		public IXUILabel m_Content;

		// Token: 0x0400788F RID: 30863
		public IXUIButton m_Close;

		// Token: 0x04007890 RID: 30864
		public IXUITexture m_Icon;

		// Token: 0x04007891 RID: 30865
		public IXUILabel m_Name;

		// Token: 0x04007892 RID: 30866
		public IXUILabel m_Notice;
	}
}
