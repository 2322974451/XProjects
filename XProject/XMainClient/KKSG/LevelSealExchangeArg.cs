using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LevelSealExchangeArg")]
	[Serializable]
	public class LevelSealExchangeArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
