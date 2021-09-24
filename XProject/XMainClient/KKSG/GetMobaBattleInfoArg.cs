using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMobaBattleInfoArg")]
	[Serializable]
	public class GetMobaBattleInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
