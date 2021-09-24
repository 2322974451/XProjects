using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NpcFlItemType")]
	public enum NpcFlItemType
	{

		[ProtoEnum(Name = "NPCFL_ITEM_NORMAL", Value = 1)]
		NPCFL_ITEM_NORMAL = 1,

		[ProtoEnum(Name = "NPCFL_ITEM_RANDOM", Value = 2)]
		NPCFL_ITEM_RANDOM,

		[ProtoEnum(Name = "NPCFL_ITEM_TRIGGER_FAVOR", Value = 3)]
		NPCFL_ITEM_TRIGGER_FAVOR
	}
}
