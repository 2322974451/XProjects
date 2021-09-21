using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003E8 RID: 1000
	[ProtoContract(Name = "CloseSkyCraftEliNtf")]
	[Serializable]
	public class CloseSkyCraftEliNtf : IExtensible
	{
		// Token: 0x06003533 RID: 13619 RVA: 0x00065F84 File Offset: 0x00064184
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D36 RID: 3382
		private IExtension extensionObject;
	}
}
