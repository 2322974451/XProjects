using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CustomBattleOp")]
	public enum CustomBattleOp
	{

		[ProtoEnum(Name = "CustomBattle_Query", Value = 1)]
		CustomBattle_Query = 1,

		[ProtoEnum(Name = "CustomBattle_Create", Value = 2)]
		CustomBattle_Create,

		[ProtoEnum(Name = "CustomBattle_Join", Value = 3)]
		CustomBattle_Join,

		[ProtoEnum(Name = "CustomBattle_Match", Value = 4)]
		CustomBattle_Match,

		[ProtoEnum(Name = "CustomBattle_Reward", Value = 5)]
		CustomBattle_Reward,

		[ProtoEnum(Name = "CustomBattle_ClearCD", Value = 6)]
		CustomBattle_ClearCD,

		[ProtoEnum(Name = "CustomBattle_QueryRandom", Value = 7)]
		CustomBattle_QueryRandom,

		[ProtoEnum(Name = "CustomBattle_QueryOne", Value = 8)]
		CustomBattle_QueryOne,

		[ProtoEnum(Name = "CustomBattle_DoCreate", Value = 9)]
		CustomBattle_DoCreate,

		[ProtoEnum(Name = "CustomBattle_DoJoin", Value = 10)]
		CustomBattle_DoJoin,

		[ProtoEnum(Name = "CustomBattle_UnJoin", Value = 11)]
		CustomBattle_UnJoin,

		[ProtoEnum(Name = "CustomBattle_UnMatch", Value = 12)]
		CustomBattle_UnMatch,

		[ProtoEnum(Name = "CustomBattle_Modify", Value = 13)]
		CustomBattle_Modify,

		[ProtoEnum(Name = "CustomBattle_QuerySelf", Value = 14)]
		CustomBattle_QuerySelf,

		[ProtoEnum(Name = "CustomBattle_StartNow", Value = 15)]
		CustomBattle_StartNow,

		[ProtoEnum(Name = "CustomBattle_DoClearCD", Value = 16)]
		CustomBattle_DoClearCD,

		[ProtoEnum(Name = "CustomBattle_Drop", Value = 17)]
		CustomBattle_Drop,

		[ProtoEnum(Name = "CustomBattle_Search", Value = 18)]
		CustomBattle_Search
	}
}
