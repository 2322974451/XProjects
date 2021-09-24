using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemFindBackInfoArg")]
	[Serializable]
	public class ItemFindBackInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
