using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x0200098A RID: 2442
	public class EquipSuitMenuData : IComparable<EquipSuitMenuData>
	{
		// Token: 0x060092AC RID: 37548 RVA: 0x00153A78 File Offset: 0x00151C78
		public int CompareTo(EquipSuitMenuData _other)
		{
			return _other.quality - this.quality;
		}

		// Token: 0x04003133 RID: 12595
		public bool show;

		// Token: 0x04003134 RID: 12596
		public bool redpoint;

		// Token: 0x04003135 RID: 12597
		public int quality;

		// Token: 0x04003136 RID: 12598
		public List<EquipSuitMenuDataItem> list;
	}
}
