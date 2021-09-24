using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDragonTopInfoArg")]
	[Serializable]
	public class GetDragonTopInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
