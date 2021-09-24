using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetPartnerDetailInfoArg")]
	[Serializable]
	public class GetPartnerDetailInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
