using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AskGuildWageInfoArg")]
	[Serializable]
	public class AskGuildWageInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
