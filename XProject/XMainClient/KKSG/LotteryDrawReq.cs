using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004F6 RID: 1270
	[ProtoContract(Name = "LotteryDrawReq")]
	[Serializable]
	public class LotteryDrawReq : IExtensible
	{
		// Token: 0x060041A0 RID: 16800 RVA: 0x0007CF08 File Offset: 0x0007B108
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400105E RID: 4190
		private IExtension extensionObject;
	}
}
