using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetLeagueBattleInfoArg")]
	[Serializable]
	public class GetLeagueBattleInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
