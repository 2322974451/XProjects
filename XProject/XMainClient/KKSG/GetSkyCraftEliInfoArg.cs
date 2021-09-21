using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003E4 RID: 996
	[ProtoContract(Name = "GetSkyCraftEliInfoArg")]
	[Serializable]
	public class GetSkyCraftEliInfoArg : IExtensible
	{
		// Token: 0x06003514 RID: 13588 RVA: 0x00065C2C File Offset: 0x00063E2C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D2C RID: 3372
		private IExtension extensionObject;
	}
}
