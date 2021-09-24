using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueBattleStopMatchNtf")]
	[Serializable]
	public class LeagueBattleStopMatchNtf : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
