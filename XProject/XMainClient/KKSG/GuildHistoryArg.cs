using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildHistoryArg")]
	[Serializable]
	public class GuildHistoryArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
