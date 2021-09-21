using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002E7 RID: 743
	[ProtoContract(Name = "DailyTaskGiveUpArg")]
	[Serializable]
	public class DailyTaskGiveUpArg : IExtensible
	{
		// Token: 0x060028E8 RID: 10472 RVA: 0x0004F72C File Offset: 0x0004D92C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A2A RID: 2602
		private IExtension extensionObject;
	}
}
