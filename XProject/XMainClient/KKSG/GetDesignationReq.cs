using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDesignationReq")]
	[Serializable]
	public class GetDesignationReq : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
