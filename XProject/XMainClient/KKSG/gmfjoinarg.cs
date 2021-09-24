using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "gmfjoinarg")]
	[Serializable]
	public class gmfjoinarg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
