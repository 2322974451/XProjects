using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004FA RID: 1274
	[ProtoContract(Name = "GetDailyTaskAskHelpArg")]
	[Serializable]
	public class GetDailyTaskAskHelpArg : IExtensible
	{
		// Token: 0x060041E0 RID: 16864 RVA: 0x0007D6C4 File Offset: 0x0007B8C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400106D RID: 4205
		private IExtension extensionObject;
	}
}
