using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReqGuildTerrCityInfoArg")]
	[Serializable]
	public class ReqGuildTerrCityInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
