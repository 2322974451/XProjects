using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200082B RID: 2091
	[ProtoContract(Name = "NpcFlItemType")]
	public enum NpcFlItemType
	{
		// Token: 0x040027F2 RID: 10226
		[ProtoEnum(Name = "NPCFL_ITEM_NORMAL", Value = 1)]
		NPCFL_ITEM_NORMAL = 1,
		// Token: 0x040027F3 RID: 10227
		[ProtoEnum(Name = "NPCFL_ITEM_RANDOM", Value = 2)]
		NPCFL_ITEM_RANDOM,
		// Token: 0x040027F4 RID: 10228
		[ProtoEnum(Name = "NPCFL_ITEM_TRIGGER_FAVOR", Value = 3)]
		NPCFL_ITEM_TRIGGER_FAVOR
	}
}
