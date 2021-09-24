using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetFlowerRewardArg")]
	[Serializable]
	public class GetFlowerRewardArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
