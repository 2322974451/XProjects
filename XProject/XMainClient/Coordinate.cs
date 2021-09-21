using System;

namespace XMainClient
{
	// Token: 0x02000B20 RID: 2848
	internal struct Coordinate
	{
		// Token: 0x0600A74D RID: 42829 RVA: 0x001D916D File Offset: 0x001D736D
		public Coordinate(int _x, int _y)
		{
			this.x = _x;
			this.y = _y;
		}

		// Token: 0x04003DC9 RID: 15817
		public static Coordinate Invalid = new Coordinate(-100, -100);

		// Token: 0x04003DCA RID: 15818
		public int x;

		// Token: 0x04003DCB RID: 15819
		public int y;
	}
}
