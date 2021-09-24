using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BuyExtraSkillEmblemSlotArg")]
	[Serializable]
	public class BuyExtraSkillEmblemSlotArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
