using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004C3 RID: 1219
	[ProtoContract(Name = "GetDragonGuildShopArg")]
	[Serializable]
	public class GetDragonGuildShopArg : IExtensible
	{
		// Token: 0x06003F7F RID: 16255 RVA: 0x000790E8 File Offset: 0x000772E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FCF RID: 4047
		private IExtension extensionObject;
	}
}
