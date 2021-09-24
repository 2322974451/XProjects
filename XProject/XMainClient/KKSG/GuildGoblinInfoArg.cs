using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildGoblinInfoArg")]
	[Serializable]
	public class GuildGoblinInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
