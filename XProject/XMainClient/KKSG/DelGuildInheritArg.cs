using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DelGuildInheritArg")]
	[Serializable]
	public class DelGuildInheritArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
