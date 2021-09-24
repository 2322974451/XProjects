using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGrowthFundTimeArg")]
	[Serializable]
	public class GetGrowthFundTimeArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
