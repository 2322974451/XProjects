using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetSkyCraftRecordArg")]
	[Serializable]
	public class GetSkyCraftRecordArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
