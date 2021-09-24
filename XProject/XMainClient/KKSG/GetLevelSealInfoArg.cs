using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetLevelSealInfoArg")]
	[Serializable]
	public class GetLevelSealInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
