using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003B2 RID: 946
	[ProtoContract(Name = "ReqGuildTerrIntellInfoArg")]
	[Serializable]
	public class ReqGuildTerrIntellInfoArg : IExtensible
	{
		// Token: 0x06003299 RID: 12953 RVA: 0x0006149C File Offset: 0x0005F69C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C96 RID: 3222
		private IExtension extensionObject;
	}
}
