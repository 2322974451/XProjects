using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReturnToSelectRoleArg")]
	[Serializable]
	public class ReturnToSelectRoleArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
