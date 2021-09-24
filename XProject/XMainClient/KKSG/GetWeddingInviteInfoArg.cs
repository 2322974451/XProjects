using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetWeddingInviteInfoArg")]
	[Serializable]
	public class GetWeddingInviteInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
