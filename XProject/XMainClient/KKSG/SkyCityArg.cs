using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCityArg")]
	[Serializable]
	public class SkyCityArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
