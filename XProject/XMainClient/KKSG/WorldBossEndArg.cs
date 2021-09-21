using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000208 RID: 520
	[ProtoContract(Name = "WorldBossEndArg")]
	[Serializable]
	public class WorldBossEndArg : IExtensible
	{
		// Token: 0x06001D6C RID: 7532 RVA: 0x00039E64 File Offset: 0x00038064
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400075A RID: 1882
		private IExtension extensionObject;
	}
}
