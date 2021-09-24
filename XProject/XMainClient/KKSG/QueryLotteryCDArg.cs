using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryLotteryCDArg")]
	[Serializable]
	public class QueryLotteryCDArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
