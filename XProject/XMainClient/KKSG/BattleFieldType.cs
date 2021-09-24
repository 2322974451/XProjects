using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleFieldType")]
	public enum BattleFieldType
	{

		[ProtoEnum(Name = "BATTLE_FIELD_READY_ENTER", Value = 1)]
		BATTLE_FIELD_READY_ENTER = 1,

		[ProtoEnum(Name = "BATTLE_FIELD_READY_LEAVE", Value = 2)]
		BATTLE_FIELD_READY_LEAVE
	}
}
