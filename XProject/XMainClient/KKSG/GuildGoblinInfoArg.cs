using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000DE RID: 222
	[ProtoContract(Name = "GuildGoblinInfoArg")]
	[Serializable]
	public class GuildGoblinInfoArg : IExtensible
	{
		// Token: 0x06000E43 RID: 3651 RVA: 0x0001D96C File Offset: 0x0001BB6C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000396 RID: 918
		private IExtension extensionObject;
	}
}
