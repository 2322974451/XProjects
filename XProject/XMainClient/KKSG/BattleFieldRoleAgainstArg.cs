using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleFieldRoleAgainstArg")]
	[Serializable]
	public class BattleFieldRoleAgainstArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
