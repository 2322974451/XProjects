using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueBattleRoleState")]
	public enum LeagueBattleRoleState
	{

		[ProtoEnum(Name = "LBRoleState_None", Value = 1)]
		LBRoleState_None = 1,

		[ProtoEnum(Name = "LBRoleState_Waiting", Value = 2)]
		LBRoleState_Waiting,

		[ProtoEnum(Name = "LBRoleState_Leave", Value = 3)]
		LBRoleState_Leave,

		[ProtoEnum(Name = "LBRoleState_Fighting", Value = 4)]
		LBRoleState_Fighting,

		[ProtoEnum(Name = "LBRoleState_Win", Value = 5)]
		LBRoleState_Win,

		[ProtoEnum(Name = "LBRoleState_Failed", Value = 6)]
		LBRoleState_Failed
	}
}
