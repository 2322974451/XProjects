using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarRankSimpleInfo")]
	[Serializable]
	public class ResWarRankSimpleInfo : IExtensible
	{

		[ProtoMember(1, Name = "rank", DataFormat = DataFormat.Default)]
		public List<ResWarRank> rank
		{
			get
			{
				return this._rank;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ResWarRank> _rank = new List<ResWarRank>();

		private IExtension extensionObject;
	}
}
