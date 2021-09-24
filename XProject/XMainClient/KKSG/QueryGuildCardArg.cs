using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryGuildCardArg")]
	[Serializable]
	public class QueryGuildCardArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
