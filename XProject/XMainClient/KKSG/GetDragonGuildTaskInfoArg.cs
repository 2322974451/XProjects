using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDragonGuildTaskInfoArg")]
	[Serializable]
	public class GetDragonGuildTaskInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
