using System;

namespace XMainClient
{
	// Token: 0x02000F1E RID: 3870
	internal class XTuple<T1, T2, T3, T4>
	{
		// Token: 0x0600CCFE RID: 52478 RVA: 0x002F3D8C File Offset: 0x002F1F8C
		public XTuple(T1 t1, T2 t2, T3 t3, T4 t4)
		{
			this.Item1 = t1;
			this.Item2 = t2;
			this.Item3 = t3;
			this.Item4 = t4;
		}

		// Token: 0x0600CCFF RID: 52479 RVA: 0x0000311A File Offset: 0x0000131A
		public XTuple()
		{
		}

		// Token: 0x04005B29 RID: 23337
		public T1 Item1;

		// Token: 0x04005B2A RID: 23338
		public T2 Item2;

		// Token: 0x04005B2B RID: 23339
		public T3 Item3;

		// Token: 0x04005B2C RID: 23340
		public T4 Item4;
	}
}
