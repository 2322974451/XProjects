using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020018DC RID: 6364
	internal class XWeddingCostBehavior : DlgBehaviourBase
	{
		// Token: 0x0601095E RID: 67934 RVA: 0x00416784 File Offset: 0x00414984
		private void Awake()
		{
			this.DrawItem = base.transform.Find("ItemTpl").gameObject;
			this.TipLabel = (base.transform.Find("Tip").GetComponent("XUILabel") as IXUILabel);
			this.SecondTitle = (base.transform.Find("Bg/Tip").GetComponent("XUILabel") as IXUILabel);
			this.TitleLabel = (base.transform.Find("Title").GetComponent("XUILabel") as IXUILabel);
			this.CostTip = (base.transform.Find("CostTip").GetComponent("XUILabel") as IXUILabel);
			this.NumLabel = (base.transform.Find("TipNum").GetComponent("XUILabel") as IXUILabel);
			this.Close = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.OkBtn = (base.transform.Find("SureBtn").GetComponent("XUIButton") as IXUIButton);
			this.Cancel = (base.transform.Find("Cancel").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x04007863 RID: 30819
		public GameObject DrawItem = null;

		// Token: 0x04007864 RID: 30820
		public IXUILabel TitleLabel = null;

		// Token: 0x04007865 RID: 30821
		public IXUILabel SecondTitle = null;

		// Token: 0x04007866 RID: 30822
		public IXUILabel TipLabel = null;

		// Token: 0x04007867 RID: 30823
		public IXUILabel CostTip = null;

		// Token: 0x04007868 RID: 30824
		public IXUILabel NumLabel = null;

		// Token: 0x04007869 RID: 30825
		public IXUIButton Close;

		// Token: 0x0400786A RID: 30826
		public IXUIButton OkBtn;

		// Token: 0x0400786B RID: 30827
		public IXUIButton Cancel;
	}
}
