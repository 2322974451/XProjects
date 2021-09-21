using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003D0 RID: 976
	[ProtoContract(Name = "GetGrowthFundTimeArg")]
	[Serializable]
	public class GetGrowthFundTimeArg : IExtensible
	{
		// Token: 0x06003404 RID: 13316 RVA: 0x00063D1C File Offset: 0x00061F1C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CEC RID: 3308
		private IExtension extensionObject;
	}
}
