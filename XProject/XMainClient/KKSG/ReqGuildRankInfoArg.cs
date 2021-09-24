using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReqGuildRankInfoArg")]
	[Serializable]
	public class ReqGuildRankInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
