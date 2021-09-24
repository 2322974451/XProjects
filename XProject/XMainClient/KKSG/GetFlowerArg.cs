using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetFlowerArg")]
	[Serializable]
	public class GetFlowerArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
