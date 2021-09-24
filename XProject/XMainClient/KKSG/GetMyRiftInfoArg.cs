using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMyRiftInfoArg")]
	[Serializable]
	public class GetMyRiftInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
