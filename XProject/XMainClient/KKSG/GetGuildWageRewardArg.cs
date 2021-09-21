using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200028C RID: 652
	[ProtoContract(Name = "GetGuildWageRewardArg")]
	[Serializable]
	public class GetGuildWageRewardArg : IExtensible
	{
		// Token: 0x060024AC RID: 9388 RVA: 0x000478B0 File Offset: 0x00045AB0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400090E RID: 2318
		private IExtension extensionObject;
	}
}
