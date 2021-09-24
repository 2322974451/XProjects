using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDailyTaskRefreshInfoArg")]
	[Serializable]
	public class GetDailyTaskRefreshInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
