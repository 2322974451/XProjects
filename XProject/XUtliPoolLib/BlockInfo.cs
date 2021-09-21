using System;

namespace XUtliPoolLib
{
	// Token: 0x0200018C RID: 396
	public struct BlockInfo
	{
		// Token: 0x06000898 RID: 2200 RVA: 0x0002E514 File Offset: 0x0002C714
		public BlockInfo(int s, int c)
		{
			this.size = s;
			this.count = c;
		}

		// Token: 0x040003E0 RID: 992
		public int size;

		// Token: 0x040003E1 RID: 993
		public int count;
	}
}
