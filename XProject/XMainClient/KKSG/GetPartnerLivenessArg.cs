using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetPartnerLivenessArg")]
	[Serializable]
	public class GetPartnerLivenessArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
