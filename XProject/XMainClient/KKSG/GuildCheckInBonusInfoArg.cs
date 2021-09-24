using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildCheckInBonusInfoArg")]
	[Serializable]
	public class GuildCheckInBonusInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
