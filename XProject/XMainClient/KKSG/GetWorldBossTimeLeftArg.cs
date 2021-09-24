using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetWorldBossTimeLeftArg")]
	[Serializable]
	public class GetWorldBossTimeLeftArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
