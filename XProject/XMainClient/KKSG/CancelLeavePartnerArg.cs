using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CancelLeavePartnerArg")]
	[Serializable]
	public class CancelLeavePartnerArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
