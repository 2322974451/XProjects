using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildPartySummonSpiritArg")]
	[Serializable]
	public class GuildPartySummonSpiritArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
