using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001BB RID: 443
	[ProtoContract(Name = "GetWorldBossTimeLeftArg")]
	[Serializable]
	public class GetWorldBossTimeLeftArg : IExtensible
	{
		// Token: 0x060019D6 RID: 6614 RVA: 0x000333B4 File Offset: 0x000315B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400066E RID: 1646
		private IExtension extensionObject;
	}
}
