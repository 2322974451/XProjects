using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000DE3 RID: 3555
	internal struct XEnhanceInfo
	{
		// Token: 0x0600C0DC RID: 49372 RVA: 0x0028DA4C File Offset: 0x0028BC4C
		public void Init()
		{
			bool flag = this.EnhanceAttr == null;
			if (flag)
			{
				this.EnhanceAttr = new List<XItemChangeAttr>();
			}
			else
			{
				this.EnhanceAttr.Clear();
			}
			this.EnhanceLevel = 0U;
			this.EnhanceTimes = 0U;
		}

		// Token: 0x04005106 RID: 20742
		public uint EnhanceLevel;

		// Token: 0x04005107 RID: 20743
		public uint EnhanceTimes;

		// Token: 0x04005108 RID: 20744
		public List<XItemChangeAttr> EnhanceAttr;
	}
}
