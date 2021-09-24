using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CustomBattleType")]
	public enum CustomBattleType
	{

		[ProtoEnum(Name = "CustomBattle_PK_Normal", Value = 1)]
		CustomBattle_PK_Normal = 1,

		[ProtoEnum(Name = "CustomBattle_PKTwo_Normal", Value = 2)]
		CustomBattle_PKTwo_Normal
	}
}
