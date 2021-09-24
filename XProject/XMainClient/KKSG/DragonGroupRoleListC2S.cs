using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonGroupRoleListC2S")]
	[Serializable]
	public class DragonGroupRoleListC2S : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
