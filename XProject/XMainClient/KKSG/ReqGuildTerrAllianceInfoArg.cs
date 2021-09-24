using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReqGuildTerrAllianceInfoArg")]
	[Serializable]
	public class ReqGuildTerrAllianceInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
