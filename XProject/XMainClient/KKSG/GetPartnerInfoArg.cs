using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetPartnerInfoArg")]
	[Serializable]
	public class GetPartnerInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
