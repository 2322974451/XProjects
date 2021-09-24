using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "getintegralbattleInfoarg")]
	[Serializable]
	public class getintegralbattleInfoarg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
