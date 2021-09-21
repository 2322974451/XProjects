using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200082A RID: 2090
	[ProtoContract(Name = "NpcFlReqType")]
	public enum NpcFlReqType
	{
		// Token: 0x040027EB RID: 10219
		[ProtoEnum(Name = "NPCFL_GIVE_GIFT", Value = 1)]
		NPCFL_GIVE_GIFT = 1,
		// Token: 0x040027EC RID: 10220
		[ProtoEnum(Name = "NPCFL_EXCHANGE", Value = 2)]
		NPCFL_EXCHANGE,
		// Token: 0x040027ED RID: 10221
		[ProtoEnum(Name = "NPCFL_BASE_DATA", Value = 3)]
		NPCFL_BASE_DATA,
		// Token: 0x040027EE RID: 10222
		[ProtoEnum(Name = "NPCFL_NPC_LEVEL_UP", Value = 4)]
		NPCFL_NPC_LEVEL_UP,
		// Token: 0x040027EF RID: 10223
		[ProtoEnum(Name = "NPCFL_UNITE_ACT", Value = 5)]
		NPCFL_UNITE_ACT,
		// Token: 0x040027F0 RID: 10224
		[ProtoEnum(Name = "NPCFL_BUY_GIFT_COUNT", Value = 6)]
		NPCFL_BUY_GIFT_COUNT
	}
}
