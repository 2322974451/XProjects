using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AskGuildArenaTeamInfoArg")]
	[Serializable]
	public class AskGuildArenaTeamInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
