using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C56 RID: 3158
	internal class AnicentTaskBhaviour : DlgBehaviourBase
	{
		// Token: 0x0600B309 RID: 45833 RVA: 0x0022BD7C File Offset: 0x00229F7C
		private void Awake()
		{
			this.boxTpl = base.transform.Find("Bg/TaskTitle/option1").gameObject;
			this.m_content = (base.transform.Find("Bg/condition/condition1").GetComponent("XUILabel") as IXUILabel);
			this.m_time = (base.transform.Find("Bg/condition/Time").GetComponent("XUILabel") as IXUILabel);
			this.itemTpl = base.transform.Find("Bg/condition/ItemList/ItemTpl").gameObject;
			this.itemTpl.SetActive(false);
			this.m_btnClose = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_tabpool.SetupPool(this.boxTpl.transform.parent.gameObject, this.boxTpl, 2U, false);
			this.m_rwdpool.SetupPool(this.itemTpl.transform.parent.gameObject, this.itemTpl, 2U, false);
		}

		// Token: 0x04004529 RID: 17705
		public GameObject boxTpl;

		// Token: 0x0400452A RID: 17706
		public GameObject itemTpl;

		// Token: 0x0400452B RID: 17707
		public IXUILabel m_time;

		// Token: 0x0400452C RID: 17708
		public IXUILabel m_content;

		// Token: 0x0400452D RID: 17709
		public XUIPool m_tabpool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400452E RID: 17710
		public XUIPool m_rwdpool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400452F RID: 17711
		public IXUIButton m_btnClose;
	}
}
