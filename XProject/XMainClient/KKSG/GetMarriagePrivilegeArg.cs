using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMarriagePrivilegeArg")]
	[Serializable]
	public class GetMarriagePrivilegeArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
