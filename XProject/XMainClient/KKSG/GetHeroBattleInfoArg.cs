using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetHeroBattleInfoArg")]
	[Serializable]
	public class GetHeroBattleInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
