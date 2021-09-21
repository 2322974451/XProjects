using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200031B RID: 795
	[ProtoContract(Name = "GetPartnerLivenessArg")]
	[Serializable]
	public class GetPartnerLivenessArg : IExtensible
	{
		// Token: 0x06002BA1 RID: 11169 RVA: 0x0005486C File Offset: 0x00052A6C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AD0 RID: 2768
		private IExtension extensionObject;
	}
}
