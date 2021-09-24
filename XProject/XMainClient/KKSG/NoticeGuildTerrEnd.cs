using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NoticeGuildTerrEnd")]
	[Serializable]
	public class NoticeGuildTerrEnd : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
