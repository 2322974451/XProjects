using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007E6 RID: 2022
	[ProtoContract(Name = "LeagueBattleRoleState")]
	public enum LeagueBattleRoleState
	{
		// Token: 0x04002661 RID: 9825
		[ProtoEnum(Name = "LBRoleState_None", Value = 1)]
		LBRoleState_None = 1,
		// Token: 0x04002662 RID: 9826
		[ProtoEnum(Name = "LBRoleState_Waiting", Value = 2)]
		LBRoleState_Waiting,
		// Token: 0x04002663 RID: 9827
		[ProtoEnum(Name = "LBRoleState_Leave", Value = 3)]
		LBRoleState_Leave,
		// Token: 0x04002664 RID: 9828
		[ProtoEnum(Name = "LBRoleState_Fighting", Value = 4)]
		LBRoleState_Fighting,
		// Token: 0x04002665 RID: 9829
		[ProtoEnum(Name = "LBRoleState_Win", Value = 5)]
		LBRoleState_Win,
		// Token: 0x04002666 RID: 9830
		[ProtoEnum(Name = "LBRoleState_Failed", Value = 6)]
		LBRoleState_Failed
	}
}
