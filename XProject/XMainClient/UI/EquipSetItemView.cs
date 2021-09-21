using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x02001823 RID: 6179
	internal class EquipSetItemView : EquipSetItemBaseView
	{
		// Token: 0x060100B9 RID: 65721 RVA: 0x003D2434 File Offset: 0x003D0634
		public override void FindFrom(Transform t)
		{
			bool flag = null != t;
			if (flag)
			{
				base.FindFrom(t);
				this.goItem1 = t.Find("Item1").gameObject;
				this.lbItemCount1 = (this.goItem1.transform.Find("FCount").GetComponent("XUILabel") as IXUILabel);
				this.goItem2 = t.Find("Item2").gameObject;
				this.lbItemCount2 = (this.goItem2.transform.Find("FCount").GetComponent("XUILabel") as IXUILabel);
				this.goItem3 = t.Find("Item3").gameObject;
				this.lbItemCount3 = (this.goItem3.transform.Find("FCount").GetComponent("XUILabel") as IXUILabel);
				this.goItem4 = t.Find("Item4").gameObject;
				this.lbItemCount4 = (this.goItem4.transform.Find("FCount").GetComponent("XUILabel") as IXUILabel);
				this.btnCreate = (t.Find("Create").GetComponent("XUIButton") as IXUIButton);
				this.lbCost = (this.btnCreate.gameObject.transform.Find("V").GetComponent("XUILabel") as IXUILabel);
				this.goRedpoint = this.btnCreate.gameObject.transform.Find("RedPoint").gameObject;
			}
		}

		// Token: 0x04007235 RID: 29237
		public GameObject goItem1;

		// Token: 0x04007236 RID: 29238
		public GameObject goItem2;

		// Token: 0x04007237 RID: 29239
		public GameObject goItem3;

		// Token: 0x04007238 RID: 29240
		public GameObject goItem4;

		// Token: 0x04007239 RID: 29241
		public IXUILabel lbItemCount1;

		// Token: 0x0400723A RID: 29242
		public IXUILabel lbItemCount2;

		// Token: 0x0400723B RID: 29243
		public IXUILabel lbItemCount3;

		// Token: 0x0400723C RID: 29244
		public IXUILabel lbItemCount4;

		// Token: 0x0400723D RID: 29245
		public IXUIButton btnCreate;

		// Token: 0x0400723E RID: 29246
		public IXUILabel lbCost;

		// Token: 0x0400723F RID: 29247
		public GameObject goRedpoint;
	}
}
