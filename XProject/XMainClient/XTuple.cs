using System;

namespace XMainClient
{
	// Token: 0x02000F1C RID: 3868
	internal class XTuple<T1, T2>
	{
		// Token: 0x0600CCFA RID: 52474 RVA: 0x002F3D55 File Offset: 0x002F1F55
		public XTuple(T1 t1, T2 t2)
		{
			this.Item1 = t1;
			this.Item2 = t2;
		}

		// Token: 0x0600CCFB RID: 52475 RVA: 0x0000311A File Offset: 0x0000131A
		public XTuple()
		{
		}

		// Token: 0x04005B24 RID: 23332
		public T1 Item1;

		// Token: 0x04005B25 RID: 23333
		public T2 Item2;
	}
}
