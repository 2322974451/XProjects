using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetActivityInfoArg")]
	[Serializable]
	public class GetActivityInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
