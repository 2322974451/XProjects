using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetPartnerShopRecordArg")]
	[Serializable]
	public class GetPartnerShopRecordArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
