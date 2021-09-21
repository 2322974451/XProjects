using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000255 RID: 597
	[ProtoContract(Name = "ReqGuildRankInfoArg")]
	[Serializable]
	public class ReqGuildRankInfoArg : IExtensible
	{
		// Token: 0x06002161 RID: 8545 RVA: 0x00041578 File Offset: 0x0003F778
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400084E RID: 2126
		private IExtension extensionObject;
	}
}
