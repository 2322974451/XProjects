using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class ArtifactElementData : IComparable<ArtifactElementData>
	{

		public int CompareTo(ArtifactElementData other)
		{
			int sortId = this.GetSortId(this.ElementType);
			int sortId2 = this.GetSortId(other.ElementType);
			return sortId - sortId2;
		}

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

		public bool Show = false;

		public bool Redpoint = false;

		public uint ElementType = 0U;

		public List<ArtifactSuitData> List = null;
	}
}
