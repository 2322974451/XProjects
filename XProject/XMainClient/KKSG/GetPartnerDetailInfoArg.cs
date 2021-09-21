using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000319 RID: 793
	[ProtoContract(Name = "GetPartnerDetailInfoArg")]
	[Serializable]
	public class GetPartnerDetailInfoArg : IExtensible
	{
		// Token: 0x06002B78 RID: 11128 RVA: 0x00054368 File Offset: 0x00052568
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AC7 RID: 2759
		private IExtension extensionObject;
	}
}
