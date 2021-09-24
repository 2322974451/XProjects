using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GroupChatApplyNtf")]
	[Serializable]
	public class GroupChatApplyNtf : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
