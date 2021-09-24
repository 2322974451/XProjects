using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGuildBonusListArg")]
	[Serializable]
	public class GetGuildBonusListArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
