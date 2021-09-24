using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FirstPassInfoReqArg")]
	[Serializable]
	public class FirstPassInfoReqArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
