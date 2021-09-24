using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "JoinRoom")]
	[Serializable]
	public class JoinRoom : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
