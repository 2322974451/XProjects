using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GCFFightInfoArg")]
	[Serializable]
	public class GCFFightInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
