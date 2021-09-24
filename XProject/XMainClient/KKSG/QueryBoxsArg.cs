using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryBoxsArg")]
	[Serializable]
	public class QueryBoxsArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
