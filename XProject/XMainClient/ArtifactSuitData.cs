using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x020008ED RID: 2285
	internal class ArtifactSuitData : IComparable<ArtifactSuitData>
	{
		// Token: 0x06008A49 RID: 35401 RVA: 0x00124CDC File Offset: 0x00122EDC
		public int CompareTo(ArtifactSuitData other)
		{
			return (int)(other.Level - this.Level);
		}

		// Token: 0x04002BFC RID: 11260
		public bool Show = false;

		// Token: 0x04002BFD RID: 11261
		public bool Redpoint = false;

		// Token: 0x04002BFE RID: 11262
		public uint Level = 0U;

		// Token: 0x04002BFF RID: 11263
		public ArtifactSuit SuitData;

		// Token: 0x04002C00 RID: 11264
		public List<ArtifactSingleData> SuitItemList;
	}
}
