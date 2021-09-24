using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OpenGuildQAReq")]
	[Serializable]
	public class OpenGuildQAReq : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
