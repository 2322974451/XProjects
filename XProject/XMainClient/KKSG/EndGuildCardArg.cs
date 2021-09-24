using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EndGuildCardArg")]
	[Serializable]
	public class EndGuildCardArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
