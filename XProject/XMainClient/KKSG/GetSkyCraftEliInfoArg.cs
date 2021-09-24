using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetSkyCraftEliInfoArg")]
	[Serializable]
	public class GetSkyCraftEliInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
