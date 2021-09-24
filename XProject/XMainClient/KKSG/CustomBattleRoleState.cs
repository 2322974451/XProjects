using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CustomBattleRoleState")]
	public enum CustomBattleRoleState
	{

		[ProtoEnum(Name = "CustomBattle_RoleState_Ready", Value = 1)]
		CustomBattle_RoleState_Ready = 1,

		[ProtoEnum(Name = "CustomBattle_RoleState_Join", Value = 2)]
		CustomBattle_RoleState_Join,

		[ProtoEnum(Name = "CustomBattle_RoleState_Reward", Value = 3)]
		CustomBattle_RoleState_Reward,

		[ProtoEnum(Name = "Custombattle_RoleState_Taken", Value = 4)]
		Custombattle_RoleState_Taken
	}
}
