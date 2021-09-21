using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200012E RID: 302
	[ProtoContract(Name = "SendGuildBonusArg")]
	[Serializable]
	public class SendGuildBonusArg : IExtensible
	{
		// Token: 0x060012B8 RID: 4792 RVA: 0x00025FA8 File Offset: 0x000241A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004AB RID: 1195
		private IExtension extensionObject;
	}
}
