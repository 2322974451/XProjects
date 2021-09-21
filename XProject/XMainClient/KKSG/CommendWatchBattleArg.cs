using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000181 RID: 385
	[ProtoContract(Name = "CommendWatchBattleArg")]
	[Serializable]
	public class CommendWatchBattleArg : IExtensible
	{
		// Token: 0x06001744 RID: 5956 RVA: 0x0002E840 File Offset: 0x0002CA40
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005C1 RID: 1473
		private IExtension extensionObject;
	}
}
