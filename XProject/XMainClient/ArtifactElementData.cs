using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x020008EE RID: 2286
	internal class ArtifactElementData : IComparable<ArtifactElementData>
	{
		// Token: 0x06008A4B RID: 35403 RVA: 0x00124D1C File Offset: 0x00122F1C
		public int CompareTo(ArtifactElementData other)
		{
			int sortId = this.GetSortId(this.ElementType);
			int sortId2 = this.GetSortId(other.ElementType);
			return sortId - sortId2;
		}

		// Token: 0x06008A4C RID: 35404 RVA: 0x00124D4C File Offset: 0x00122F4C
		private int GetSortId(uint elementType)
		{
			int result;
			switch (elementType)
			{
			case 2121U:
				result = 4;
				break;
			case 2122U:
				result = 8;
				break;
			case 2123U:
				result = 1;
				break;
			case 2124U:
				result = 5;
				break;
			case 2125U:
				result = 3;
				break;
			case 2126U:
				result = 7;
				break;
			case 2127U:
				result = 2;
				break;
			case 2128U:
				result = 6;
				break;
			default:
				result = 0;
				break;
			}
			return result;
		}

		// Token: 0x04002C01 RID: 11265
		public bool Show = false;

		// Token: 0x04002C02 RID: 11266
		public bool Redpoint = false;

		// Token: 0x04002C03 RID: 11267
		public uint ElementType = 0U;

		// Token: 0x04002C04 RID: 11268
		public List<ArtifactSuitData> List = null;
	}
}
