using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGuildBonusSendListArg")]
	[Serializable]
	public class GetGuildBonusSendListArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
