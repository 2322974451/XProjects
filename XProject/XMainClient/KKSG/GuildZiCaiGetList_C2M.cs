using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildZiCaiGetList_C2M")]
	[Serializable]
	public class GuildZiCaiGetList_C2M : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
