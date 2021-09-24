using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkillCoolPara")]
	[Serializable]
	public class SkillCoolPara : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
