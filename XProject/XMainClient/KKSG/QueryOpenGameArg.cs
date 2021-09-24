using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryOpenGameArg")]
	[Serializable]
	public class QueryOpenGameArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
