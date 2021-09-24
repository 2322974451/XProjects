using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildCampInfoArg")]
	[Serializable]
	public class GuildCampInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
