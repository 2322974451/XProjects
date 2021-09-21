using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000335 RID: 821
	[ProtoContract(Name = "GetPartnerShopArg")]
	[Serializable]
	public class GetPartnerShopArg : IExtensible
	{
		// Token: 0x06002D36 RID: 11574 RVA: 0x00057818 File Offset: 0x00055A18
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B37 RID: 2871
		private IExtension extensionObject;
	}
}
