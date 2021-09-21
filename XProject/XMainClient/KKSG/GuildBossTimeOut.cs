using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001A0 RID: 416
	[ProtoContract(Name = "GuildBossTimeOut")]
	[Serializable]
	public class GuildBossTimeOut : IExtensible
	{
		// Token: 0x060018C8 RID: 6344 RVA: 0x0003148C File Offset: 0x0002F68C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000623 RID: 1571
		private IExtension extensionObject;
	}
}
