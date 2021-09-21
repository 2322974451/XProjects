using System;

namespace XMainClient
{
	// Token: 0x02000F1F RID: 3871
	internal class XLFUItem<T> : IComparable<XLFUItem<T>>
	{
		// Token: 0x170035A4 RID: 13732
		// (get) Token: 0x0600CD00 RID: 52480 RVA: 0x002F3DB4 File Offset: 0x002F1FB4
		// (set) Token: 0x0600CD01 RID: 52481 RVA: 0x002F3DCF File Offset: 0x002F1FCF
		public bool bCanPop
		{
			get
			{
				return this.canPop < 0;
			}
			set
			{
				this.canPop = (value ? -1 : 1);
			}
		}

		// Token: 0x0600CD02 RID: 52482 RVA: 0x002F3DE0 File Offset: 0x002F1FE0
		public int CompareTo(XLFUItem<T> other)
		{
			bool flag = this.canPop == other.canPop;
			int result;
			if (flag)
			{
				result = this.frequent.CompareTo(other.frequent);
			}
			else
			{
				result = this.canPop.CompareTo(other.canPop);
			}
			return result;
		}

		// Token: 0x04005B2D RID: 23341
		public T data;

		// Token: 0x04005B2E RID: 23342
		public uint frequent = 0U;

		// Token: 0x04005B2F RID: 23343
		public int index;

		// Token: 0x04005B30 RID: 23344
		private int canPop;
	}
}
