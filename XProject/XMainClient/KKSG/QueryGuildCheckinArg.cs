using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryGuildCheckinArg")]
	[Serializable]
	public class QueryGuildCheckinArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
