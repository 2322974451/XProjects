using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetCrossGvgDataArg")]
	[Serializable]
	public class GetCrossGvgDataArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
