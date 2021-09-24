using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NpcFlReqType")]
	public enum NpcFlReqType
	{

		[ProtoEnum(Name = "NPCFL_GIVE_GIFT", Value = 1)]
		NPCFL_GIVE_GIFT = 1,

		[ProtoEnum(Name = "NPCFL_EXCHANGE", Value = 2)]
		NPCFL_EXCHANGE,

		[ProtoEnum(Name = "NPCFL_BASE_DATA", Value = 3)]
		NPCFL_BASE_DATA,

		[ProtoEnum(Name = "NPCFL_NPC_LEVEL_UP", Value = 4)]
		NPCFL_NPC_LEVEL_UP,

		[ProtoEnum(Name = "NPCFL_UNITE_ACT", Value = 5)]
		NPCFL_UNITE_ACT,

		[ProtoEnum(Name = "NPCFL_BUY_GIFT_COUNT", Value = 6)]
		NPCFL_BUY_GIFT_COUNT
	}
}
