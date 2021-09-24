using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetNextDayRewardArg")]
	[Serializable]
	public class GetNextDayRewardArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
