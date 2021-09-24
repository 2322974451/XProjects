using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class ArtifactSuitData : IComparable<ArtifactSuitData>
	{

		public int CompareTo(ArtifactSuitData other)
		{
			return (int)(other.Level - this.Level);
		}

		public bool Show = false;

		public bool Redpoint = false;

		public uint Level = 0U;

		public ArtifactSuit SuitData;

		public List<ArtifactSingleData> SuitItemList;
	}
}
