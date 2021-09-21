using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000806 RID: 2054
	[ProtoContract(Name = "CustomBattleRoleState")]
	public enum CustomBattleRoleState
	{
		// Token: 0x04002728 RID: 10024
		[ProtoEnum(Name = "CustomBattle_RoleState_Ready", Value = 1)]
		CustomBattle_RoleState_Ready = 1,
		// Token: 0x04002729 RID: 10025
		[ProtoEnum(Name = "CustomBattle_RoleState_Join", Value = 2)]
		CustomBattle_RoleState_Join,
		// Token: 0x0400272A RID: 10026
		[ProtoEnum(Name = "CustomBattle_RoleState_Reward", Value = 3)]
		CustomBattle_RoleState_Reward,
		// Token: 0x0400272B RID: 10027
		[ProtoEnum(Name = "Custombattle_RoleState_Taken", Value = 4)]
		Custombattle_RoleState_Taken
	}
}
