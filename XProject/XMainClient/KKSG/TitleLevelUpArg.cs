using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TitleLevelUpArg")]
	[Serializable]
	public class TitleLevelUpArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
