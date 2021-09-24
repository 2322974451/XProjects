using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeekEnd4v4GetInfoArg")]
	[Serializable]
	public class WeekEnd4v4GetInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
