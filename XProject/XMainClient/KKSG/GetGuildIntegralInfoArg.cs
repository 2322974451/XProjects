using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGuildIntegralInfoArg")]
	[Serializable]
	public class GetGuildIntegralInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
