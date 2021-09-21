using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000405 RID: 1029
	[ProtoContract(Name = "BuyExtraSkillEmblemSlotArg")]
	[Serializable]
	public class BuyExtraSkillEmblemSlotArg : IExtensible
	{
		// Token: 0x060036DD RID: 14045 RVA: 0x000691B8 File Offset: 0x000673B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D9A RID: 3482
		private IExtension extensionObject;
	}
}
