using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetLeagueBattleRecordArg")]
	[Serializable]
	public class GetLeagueBattleRecordArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
