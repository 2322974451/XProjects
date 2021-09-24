using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GCFReadyInfoArg")]
	[Serializable]
	public class GCFReadyInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
