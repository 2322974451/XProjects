using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AskGuildSkillInfoArg")]
	[Serializable]
	public class AskGuildSkillInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
