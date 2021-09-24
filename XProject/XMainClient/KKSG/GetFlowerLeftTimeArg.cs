using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetFlowerLeftTimeArg")]
	[Serializable]
	public class GetFlowerLeftTimeArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
