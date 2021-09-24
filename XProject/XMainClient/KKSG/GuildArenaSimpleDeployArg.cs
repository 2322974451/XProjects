using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildArenaSimpleDeployArg")]
	[Serializable]
	public class GuildArenaSimpleDeployArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
