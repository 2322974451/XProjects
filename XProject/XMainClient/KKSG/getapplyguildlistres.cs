using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "getapplyguildlistres")]
	[Serializable]
	public class getapplyguildlistres : IExtensible
	{

		[ProtoMember(1, Name = "guildlist", DataFormat = DataFormat.Default)]
		public List<Integralunit> guildlist
		{
			get
			{
				return this._guildlist;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<Integralunit> _guildlist = new List<Integralunit>();

		private IExtension extensionObject;
	}
}
