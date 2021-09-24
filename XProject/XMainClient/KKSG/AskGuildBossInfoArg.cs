using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AskGuildBossInfoArg")]
	[Serializable]
	public class AskGuildBossInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
