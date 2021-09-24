using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayFirstAwardArg")]
	[Serializable]
	public class PayFirstAwardArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
