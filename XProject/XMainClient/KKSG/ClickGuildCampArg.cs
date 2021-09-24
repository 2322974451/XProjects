using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ClickGuildCampArg")]
	[Serializable]
	public class ClickGuildCampArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
