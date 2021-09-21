using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000DDD RID: 3549
	internal struct XRandAttrInfo
	{
		// Token: 0x0600C0C4 RID: 49348 RVA: 0x0028D3D0 File Offset: 0x0028B5D0
		public void Init()
		{
			this.bPreview = false;
			bool flag = this.RandAttr == null;
			if (flag)
			{
				this.RandAttr = new List<XItemChangeAttr>();
			}
			else
			{
				this.RandAttr.Clear();
			}
		}

		// Token: 0x040050EF RID: 20719
		public bool bPreview;

		// Token: 0x040050F0 RID: 20720
		public List<XItemChangeAttr> RandAttr;
	}
}
