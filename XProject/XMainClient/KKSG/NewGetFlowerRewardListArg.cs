using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NewGetFlowerRewardListArg")]
	[Serializable]
	public class NewGetFlowerRewardListArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
