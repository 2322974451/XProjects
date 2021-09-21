using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200036E RID: 878
	[ProtoContract(Name = "GetHeroBattleWeekRewardArg")]
	[Serializable]
	public class GetHeroBattleWeekRewardArg : IExtensible
	{
		// Token: 0x06002FA6 RID: 12198 RVA: 0x0005BED4 File Offset: 0x0005A0D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BD7 RID: 3031
		private IExtension extensionObject;
	}
}
