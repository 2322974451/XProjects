using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004C6 RID: 1222
	[ProtoContract(Name = "GetDragonGuildShopRecordArg")]
	[Serializable]
	public class GetDragonGuildShopRecordArg : IExtensible
	{
		// Token: 0x06003F97 RID: 16279 RVA: 0x00079394 File Offset: 0x00077594
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FD5 RID: 4053
		private IExtension extensionObject;
	}
}
