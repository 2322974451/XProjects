using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetLuckyActivityInfoArg")]
	[Serializable]
	public class GetLuckyActivityInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
