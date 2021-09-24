using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDailyTaskRefreshRecordArg")]
	[Serializable]
	public class GetDailyTaskRefreshRecordArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
