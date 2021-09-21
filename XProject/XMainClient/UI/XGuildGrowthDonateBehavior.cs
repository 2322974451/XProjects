using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020016F9 RID: 5881
	internal class XGuildGrowthDonateBehavior : DlgBehaviourBase
	{
		// Token: 0x0600F2A3 RID: 62115 RVA: 0x0035D1F4 File Offset: 0x0035B3F4
		private void Awake()
		{
			this.RecordDlg = base.transform.Find("RecordDlg").gameObject;
			this.RecordDlgScrollView = (base.transform.Find("RecordDlg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.RecordWrapContent = (base.transform.Find("RecordDlg/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.ScrollView = (base.transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.WrapContent = (base.transform.Find("Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.CloseBtn = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.RecordBtn = (base.transform.Find("RecordBtn").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x040067F4 RID: 26612
		public GameObject RecordDlg;

		// Token: 0x040067F5 RID: 26613
		public IXUIScrollView ScrollView;

		// Token: 0x040067F6 RID: 26614
		public IXUIWrapContent WrapContent;

		// Token: 0x040067F7 RID: 26615
		public IXUIButton CloseBtn;

		// Token: 0x040067F8 RID: 26616
		public IXUIButton RecordBtn;

		// Token: 0x040067F9 RID: 26617
		public IXUIScrollView RecordDlgScrollView;

		// Token: 0x040067FA RID: 26618
		public IXUIWrapContent RecordWrapContent;
	}
}
