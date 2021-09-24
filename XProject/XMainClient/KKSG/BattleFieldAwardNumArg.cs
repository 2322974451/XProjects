using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleFieldAwardNumArg")]
	[Serializable]
	public class BattleFieldAwardNumArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
