using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StartWeddingCarArg")]
	[Serializable]
	public class StartWeddingCarArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
