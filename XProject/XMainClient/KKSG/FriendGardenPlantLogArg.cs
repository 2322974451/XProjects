using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FriendGardenPlantLogArg")]
	[Serializable]
	public class FriendGardenPlantLogArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
