using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x020008BF RID: 2239
	internal class ArtifactSuitLevel
	{
		// Token: 0x04002AAA RID: 10922
		public bool IsDefultSelect = false;

		// Token: 0x04002AAB RID: 10923
		public uint SuitLevel = 0U;

		// Token: 0x04002AAC RID: 10924
		public int DefultNum = 0;

		// Token: 0x04002AAD RID: 10925
		public HashSet<uint> SuitIdList = new HashSet<uint>();
	}
}
