using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200041E RID: 1054
	[ProtoContract(Name = "GetFlowerActivityRewardArg")]
	[Serializable]
	public class GetFlowerActivityRewardArg : IExtensible
	{
		// Token: 0x060037F8 RID: 14328 RVA: 0x0006B27C File Offset: 0x0006947C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DDE RID: 3550
		private IExtension extensionObject;
	}
}
