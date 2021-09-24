using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetPayAllInfoArg")]
	[Serializable]
	public class GetPayAllInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
