using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReqPlatFriendRankListArg")]
	[Serializable]
	public class ReqPlatFriendRankListArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
