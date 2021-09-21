using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004DB RID: 1243
	[ProtoContract(Name = "BattleFieldRankArg")]
	[Serializable]
	public class BattleFieldRankArg : IExtensible
	{
		// Token: 0x06004055 RID: 16469 RVA: 0x0007A854 File Offset: 0x00078A54
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001006 RID: 4102
		private IExtension extensionObject;
	}
}
