using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000183 RID: 387
	[ProtoContract(Name = "AskGuildBossInfoArg")]
	[Serializable]
	public class AskGuildBossInfoArg : IExtensible
	{
		// Token: 0x0600174E RID: 5966 RVA: 0x0002E944 File Offset: 0x0002CB44
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005C4 RID: 1476
		private IExtension extensionObject;
	}
}
