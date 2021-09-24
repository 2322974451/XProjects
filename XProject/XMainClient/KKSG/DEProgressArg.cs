using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DEProgressArg")]
	[Serializable]
	public class DEProgressArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
