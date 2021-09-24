using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkillInitCoolPara")]
	[Serializable]
	public class SkillInitCoolPara : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
