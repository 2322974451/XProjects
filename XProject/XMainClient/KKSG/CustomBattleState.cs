using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CustomBattleState")]
	public enum CustomBattleState
	{

		[ProtoEnum(Name = "CustomBattle_Ready", Value = 1)]
		CustomBattle_Ready = 1,

		[ProtoEnum(Name = "CustomBattle_Going", Value = 2)]
		CustomBattle_Going,

		[ProtoEnum(Name = "CustomBattle_End", Value = 3)]
		CustomBattle_End,

		[ProtoEnum(Name = "CustomBattle_Destory", Value = 4)]
		CustomBattle_Destory
	}
}
