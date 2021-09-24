using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDragonGuildShopArg")]
	[Serializable]
	public class GetDragonGuildShopArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
