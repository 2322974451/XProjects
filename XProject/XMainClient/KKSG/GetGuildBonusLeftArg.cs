using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGuildBonusLeftArg")]
	[Serializable]
	public class GetGuildBonusLeftArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
