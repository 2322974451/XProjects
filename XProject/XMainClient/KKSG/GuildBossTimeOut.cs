using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildBossTimeOut")]
	[Serializable]
	public class GuildBossTimeOut : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
