using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGuildWageRewardArg")]
	[Serializable]
	public class GetGuildWageRewardArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
