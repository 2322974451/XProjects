using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003B1 RID: 945
	[ProtoContract(Name = "NoticeGuildTerrEnd")]
	[Serializable]
	public class NoticeGuildTerrEnd : IExtensible
	{
		// Token: 0x06003297 RID: 12951 RVA: 0x0006147C File Offset: 0x0005F67C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C95 RID: 3221
		private IExtension extensionObject;
	}
}
