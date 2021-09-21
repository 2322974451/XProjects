using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000445 RID: 1093
	[ProtoContract(Name = "GetMobaBattleWeekRewardArg")]
	[Serializable]
	public class GetMobaBattleWeekRewardArg : IExtensible
	{
		// Token: 0x060039A1 RID: 14753 RVA: 0x0006E3D4 File Offset: 0x0006C5D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E4D RID: 3661
		private IExtension extensionObject;
	}
}
