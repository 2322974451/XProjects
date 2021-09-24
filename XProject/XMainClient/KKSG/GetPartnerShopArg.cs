using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetPartnerShopArg")]
	[Serializable]
	public class GetPartnerShopArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
