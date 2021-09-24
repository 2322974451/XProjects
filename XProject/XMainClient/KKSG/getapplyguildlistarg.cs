using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "getapplyguildlistarg")]
	[Serializable]
	public class getapplyguildlistarg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
