using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DERankArg")]
	[Serializable]
	public class DERankArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
