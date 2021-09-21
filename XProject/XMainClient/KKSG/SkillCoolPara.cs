using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200027B RID: 635
	[ProtoContract(Name = "SkillCoolPara")]
	[Serializable]
	public class SkillCoolPara : IExtensible
	{
		// Token: 0x0600235D RID: 9053 RVA: 0x000450CC File Offset: 0x000432CC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008C6 RID: 2246
		private IExtension extensionObject;
	}
}
