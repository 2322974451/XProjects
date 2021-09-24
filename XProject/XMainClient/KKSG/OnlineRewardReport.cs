using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OnlineRewardReport")]
	[Serializable]
	public class OnlineRewardReport : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
