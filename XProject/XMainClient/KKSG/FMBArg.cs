using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FMBArg")]
	[Serializable]
	public class FMBArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
