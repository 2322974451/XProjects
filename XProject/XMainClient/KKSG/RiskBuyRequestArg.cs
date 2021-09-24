using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiskBuyRequestArg")]
	[Serializable]
	public class RiskBuyRequestArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
