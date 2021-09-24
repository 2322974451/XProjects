using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PvpHistory")]
	[Serializable]
	public class PvpHistory : IExtensible
	{

		[ProtoMember(1, Name = "recs", DataFormat = DataFormat.Default)]
		public List<PvpOneRec> recs
		{
			get
			{
				return this._recs;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<PvpOneRec> _recs = new List<PvpOneRec>();

		private IExtension extensionObject;
	}
}
