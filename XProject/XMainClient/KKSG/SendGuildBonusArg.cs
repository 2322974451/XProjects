using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SendGuildBonusArg")]
	[Serializable]
	public class SendGuildBonusArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
