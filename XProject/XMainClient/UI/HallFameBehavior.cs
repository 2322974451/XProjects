using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200177C RID: 6012
	internal class HallFameBehavior : DlgBehaviourBase
	{
		// Token: 0x0600F818 RID: 63512 RVA: 0x0038A118 File Offset: 0x00388318
		private void Awake()
		{
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.RankBtn = (base.transform.Find("Bg/RankList").GetComponent("XUIButton") as IXUIButton);
			this.ShareBtn = (base.transform.Find("Bg/BtnShare").GetComponent("XUIButton") as IXUIButton);
			this.SupportBtn = (base.transform.Find("Bg/Support").GetComponent("XUIButton") as IXUIButton);
			this.HelpBtn = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.DateSeasonLabel = (base.transform.Find("Bg/date").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.Find("Bg/Tabs/TabTpl");
			this.TabPool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			this.RoleList = base.transform.Find("Bg/RoleList");
			this.RoleDetail = base.transform.Find("Bg/RoleDetail");
			this.RecentEmpty = this.RoleDetail.Find("HistoryRecord/Emport");
			this.CurrentEmpty = this.RoleDetail.Find("Empty");
			this.EffectWidget = base.transform.Find("Bg/EffectWidget").gameObject;
		}

		// Token: 0x04006C40 RID: 27712
		public IXUIButton CloseBtn;

		// Token: 0x04006C41 RID: 27713
		public IXUIButton RankBtn;

		// Token: 0x04006C42 RID: 27714
		public IXUIButton ShareBtn;

		// Token: 0x04006C43 RID: 27715
		public IXUIButton SupportBtn;

		// Token: 0x04006C44 RID: 27716
		public IXUIButton HelpBtn;

		// Token: 0x04006C45 RID: 27717
		public IXUILabel DateSeasonLabel;

		// Token: 0x04006C46 RID: 27718
		public XUIPool TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006C47 RID: 27719
		public Transform RoleList;

		// Token: 0x04006C48 RID: 27720
		public Transform RoleDetail;

		// Token: 0x04006C49 RID: 27721
		public Transform RecentEmpty;

		// Token: 0x04006C4A RID: 27722
		public Transform CurrentEmpty;

		// Token: 0x04006C4B RID: 27723
		public GameObject EffectWidget;
	}
}
