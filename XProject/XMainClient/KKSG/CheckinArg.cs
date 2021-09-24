using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CheckinArg")]
	[Serializable]
	public class CheckinArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
