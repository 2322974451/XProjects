using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetFlowerRewardListArg")]
	[Serializable]
	public class GetFlowerRewardListArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
