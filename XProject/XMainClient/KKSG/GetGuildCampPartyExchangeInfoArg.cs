using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003F2 RID: 1010
	[ProtoContract(Name = "GetGuildCampPartyExchangeInfoArg")]
	[Serializable]
	public class GetGuildCampPartyExchangeInfoArg : IExtensible
	{
		// Token: 0x06003593 RID: 13715 RVA: 0x00066A9C File Offset: 0x00064C9C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D50 RID: 3408
		private IExtension extensionObject;
	}
}
