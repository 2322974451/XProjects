using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetPayRewardArg")]
	[Serializable]
	public class GetPayRewardArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
