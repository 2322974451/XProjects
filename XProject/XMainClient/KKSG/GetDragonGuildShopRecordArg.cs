using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDragonGuildShopRecordArg")]
	[Serializable]
	public class GetDragonGuildShopRecordArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
