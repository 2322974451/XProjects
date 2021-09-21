using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x0200187A RID: 6266
	internal class XCommonHelpTipBehaviour : DlgBehaviourBase
	{
		// Token: 0x060104EC RID: 66796 RVA: 0x003F2400 File Offset: 0x003F0600
		private void Awake()
		{
			this.m_Title = (base.transform.Find("Title").GetComponent("XUILabel") as IXUILabel);
			this.m_ScrollView = (base.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_Content = (base.transform.Find("ScrollView/Content").GetComponent("XUILabel") as IXUILabel);
			this.m_Close = (base.transform.Find("Btn").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x0400754D RID: 30029
		public IXUILabel m_Title;

		// Token: 0x0400754E RID: 30030
		public IXUIScrollView m_ScrollView;

		// Token: 0x0400754F RID: 30031
		public IXUILabel m_Content;

		// Token: 0x04007550 RID: 30032
		public IXUIButton m_Close;
	}
}
