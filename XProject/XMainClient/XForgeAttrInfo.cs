using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000DDE RID: 3550
	internal struct XForgeAttrInfo
	{
		// Token: 0x0600C0C5 RID: 49349 RVA: 0x0028D410 File Offset: 0x0028B610
		public void Init()
		{
			this.bPreview = false;
			this.UnSavedAttrid = 0U;
			this.UnSavedAttrValue = 0U;
			bool flag = this.ForgeAttr == null;
			if (flag)
			{
				this.ForgeAttr = new List<XItemChangeAttr>();
			}
			else
			{
				this.ForgeAttr.Clear();
			}
		}

		// Token: 0x040050F1 RID: 20721
		public bool bPreview;

		// Token: 0x040050F2 RID: 20722
		public uint UnSavedAttrid;

		// Token: 0x040050F3 RID: 20723
		public uint UnSavedAttrValue;

		// Token: 0x040050F4 RID: 20724
		public List<XItemChangeAttr> ForgeAttr;
	}
}
