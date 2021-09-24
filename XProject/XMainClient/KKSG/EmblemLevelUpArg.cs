using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EmblemLevelUpArg")]
	[Serializable]
	public class EmblemLevelUpArg : IExtensible
	{

		[ProtoMember(1, Name = "EmblemUniqueId", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> EmblemUniqueId
		{
			get
			{
				return this._EmblemUniqueId;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ulong> _EmblemUniqueId = new List<ulong>();

		private IExtension extensionObject;
	}
}
