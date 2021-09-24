using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GroupChatLeaderReviewListC2S")]
	[Serializable]
	public class GroupChatLeaderReviewListC2S : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
