using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonGroupRecordC2S")]
	[Serializable]
	public class DragonGroupRecordC2S : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
