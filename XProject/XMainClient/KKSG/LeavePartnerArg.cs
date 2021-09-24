using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeavePartnerArg")]
	[Serializable]
	public class LeavePartnerArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
