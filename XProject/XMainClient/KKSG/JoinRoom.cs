using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001BD RID: 445
	[ProtoContract(Name = "JoinRoom")]
	[Serializable]
	public class JoinRoom : IExtensible
	{
		// Token: 0x060019E6 RID: 6630 RVA: 0x0003357C File Offset: 0x0003177C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000672 RID: 1650
		private IExtension extensionObject;
	}
}
