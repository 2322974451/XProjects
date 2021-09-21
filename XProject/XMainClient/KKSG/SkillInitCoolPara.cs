using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000376 RID: 886
	[ProtoContract(Name = "SkillInitCoolPara")]
	[Serializable]
	public class SkillInitCoolPara : IExtensible
	{
		// Token: 0x06003068 RID: 12392 RVA: 0x0005D670 File Offset: 0x0005B870
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BFF RID: 3071
		private IExtension extensionObject;
	}
}
