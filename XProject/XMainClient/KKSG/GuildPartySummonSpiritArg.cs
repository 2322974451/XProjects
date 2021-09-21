using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000513 RID: 1299
	[ProtoContract(Name = "GuildPartySummonSpiritArg")]
	[Serializable]
	public class GuildPartySummonSpiritArg : IExtensible
	{
		// Token: 0x060042D9 RID: 17113 RVA: 0x0007F34C File Offset: 0x0007D54C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010AC RID: 4268
		private IExtension extensionObject;
	}
}
