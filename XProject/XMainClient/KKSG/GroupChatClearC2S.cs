using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GroupChatClearC2S")]
	[Serializable]
	public class GroupChatClearC2S : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
