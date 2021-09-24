using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WorldBossEndArg")]
	[Serializable]
	public class WorldBossEndArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
