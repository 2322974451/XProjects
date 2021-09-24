using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NoticeGuildWageReward")]
	[Serializable]
	public class NoticeGuildWageReward : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
