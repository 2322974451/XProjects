using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildZiCaiDonateHistory_C2M")]
	[Serializable]
	public class GuildZiCaiDonateHistory_C2M : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
