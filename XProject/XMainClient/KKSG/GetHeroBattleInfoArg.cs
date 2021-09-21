using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000320 RID: 800
	[ProtoContract(Name = "GetHeroBattleInfoArg")]
	[Serializable]
	public class GetHeroBattleInfoArg : IExtensible
	{
		// Token: 0x06002BE8 RID: 11240 RVA: 0x000550B8 File Offset: 0x000532B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AE0 RID: 2784
		private IExtension extensionObject;
	}
}
