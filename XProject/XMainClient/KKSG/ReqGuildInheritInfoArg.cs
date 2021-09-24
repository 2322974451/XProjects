using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReqGuildInheritInfoArg")]
	[Serializable]
	public class ReqGuildInheritInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
