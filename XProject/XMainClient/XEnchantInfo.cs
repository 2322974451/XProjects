using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000DE5 RID: 3557
	internal struct XEnchantInfo
	{
		// Token: 0x170033DE RID: 13278
		// (get) Token: 0x0600C0DE RID: 49374 RVA: 0x0028DAA0 File Offset: 0x0028BCA0
		public bool bHasEnchant
		{
			get
			{
				return this.AttrList != null && this.AttrList.Count != 0;
			}
		}

		// Token: 0x0600C0DF RID: 49375 RVA: 0x0028DACC File Offset: 0x0028BCCC
		public void Init()
		{
			bool flag = this.AttrList == null;
			if (flag)
			{
				this.AttrList = new List<XItemChangeAttr>();
			}
			else
			{
				this.AttrList.Clear();
			}
			bool flag2 = this.EnchantIDList == null;
			if (flag2)
			{
				this.EnchantIDList = new List<uint>();
			}
			else
			{
				this.EnchantIDList.Clear();
			}
			this.EnchantItemID = 0;
		}

		// Token: 0x0400510B RID: 20747
		public List<XItemChangeAttr> AttrList;

		// Token: 0x0400510C RID: 20748
		public int EnchantItemID;

		// Token: 0x0400510D RID: 20749
		public uint ChooseAttr;

		// Token: 0x0400510E RID: 20750
		public List<uint> EnchantIDList;
	}
}
