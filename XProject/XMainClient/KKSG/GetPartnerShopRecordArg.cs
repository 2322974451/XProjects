using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000342 RID: 834
	[ProtoContract(Name = "GetPartnerShopRecordArg")]
	[Serializable]
	public class GetPartnerShopRecordArg : IExtensible
	{
		// Token: 0x06002DB2 RID: 11698 RVA: 0x00058690 File Offset: 0x00056890
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B5B RID: 2907
		private IExtension extensionObject;
	}
}
