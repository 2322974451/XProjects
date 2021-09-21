using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000908 RID: 2312
	internal class XDragonGuildTpl
	{
		// Token: 0x04002CC9 RID: 11465
		public uint id;

		// Token: 0x04002CCA RID: 11466
		public string title;

		// Token: 0x04002CCB RID: 11467
		public string desc;

		// Token: 0x04002CCC RID: 11468
		public uint exp;

		// Token: 0x04002CCD RID: 11469
		public uint type;

		// Token: 0x04002CCE RID: 11470
		public SeqListRef<uint> item;

		// Token: 0x04002CCF RID: 11471
		public int state;

		// Token: 0x04002CD0 RID: 11472
		public uint finishCount;

		// Token: 0x04002CD1 RID: 11473
		public uint doingCount;

		// Token: 0x04002CD2 RID: 11474
		public uint lefttime;
	}
}
