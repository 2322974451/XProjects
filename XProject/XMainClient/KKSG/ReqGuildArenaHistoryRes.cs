using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002C5 RID: 709
	[ProtoContract(Name = "ReqGuildArenaHistoryRes")]
	[Serializable]
	public class ReqGuildArenaHistoryRes : IExtensible
	{
		// Token: 0x06002740 RID: 10048 RVA: 0x0004C53C File Offset: 0x0004A73C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009C2 RID: 2498
		private IExtension extensionObject;
	}
}
