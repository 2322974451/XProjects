using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMyWatchRecordArg")]
	[Serializable]
	public class GetMyWatchRecordArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
