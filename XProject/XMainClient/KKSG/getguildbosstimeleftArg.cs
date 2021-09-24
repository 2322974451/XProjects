using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "getguildbosstimeleftArg")]
	[Serializable]
	public class getguildbosstimeleftArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
