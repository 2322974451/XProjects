using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGuildPartyReceiveInfoArg")]
	[Serializable]
	public class GetGuildPartyReceiveInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
