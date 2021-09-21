using System;

namespace XMainClient
{
	// Token: 0x02000F1D RID: 3869
	internal class XTuple<T1, T2, T3>
	{
		// Token: 0x0600CCFC RID: 52476 RVA: 0x002F3D6D File Offset: 0x002F1F6D
		public XTuple(T1 t1, T2 t2, T3 t3)
		{
			this.Item1 = t1;
			this.Item2 = t2;
			this.Item3 = t3;
		}

		// Token: 0x0600CCFD RID: 52477 RVA: 0x0000311A File Offset: 0x0000131A
		public XTuple()
		{
		}

		// Token: 0x04005B26 RID: 23334
		public T1 Item1;

		// Token: 0x04005B27 RID: 23335
		public T2 Item2;

		// Token: 0x04005B28 RID: 23336
		public T3 Item3;
	}
}
