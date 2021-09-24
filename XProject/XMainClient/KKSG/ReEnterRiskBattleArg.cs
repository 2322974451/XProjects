using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReEnterRiskBattleArg")]
	[Serializable]
	public class ReEnterRiskBattleArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
