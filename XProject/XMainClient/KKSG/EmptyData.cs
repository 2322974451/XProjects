using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EmptyData")]
	[Serializable]
	public class EmptyData : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
