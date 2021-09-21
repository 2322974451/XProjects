using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000A7 RID: 167
	[ProtoContract(Name = "GuildHistoryArg")]
	[Serializable]
	public class GuildHistoryArg : IExtensible
	{
		// Token: 0x06000B87 RID: 2951 RVA: 0x00018978 File Offset: 0x00016B78
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002DF RID: 735
		private IExtension extensionObject;
	}
}
