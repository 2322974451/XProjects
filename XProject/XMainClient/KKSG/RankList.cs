using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RankList")]
	[Serializable]
	public class RankList : IExtensible
	{

		[ProtoMember(1, Name = "RankData", DataFormat = DataFormat.Default)]
		public List<RankData> RankData
		{
			get
			{
				return this._RankData;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<RankData> _RankData = new List<RankData>();

		private IExtension extensionObject;
	}
}
