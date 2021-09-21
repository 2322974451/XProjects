using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000796 RID: 1942
	[ProtoContract(Name = "SyncTeamM2C")]
	public enum SyncTeamM2C
	{
		// Token: 0x04002481 RID: 9345
		[ProtoEnum(Name = "STM2C_CREATE_TEAM", Value = 1)]
		STM2C_CREATE_TEAM = 1,
		// Token: 0x04002482 RID: 9346
		[ProtoEnum(Name = "STM2C_ADD_MEMBER", Value = 2)]
		STM2C_ADD_MEMBER,
		// Token: 0x04002483 RID: 9347
		[ProtoEnum(Name = "STM2C_DEL_MEMBER", Value = 3)]
		STM2C_DEL_MEMBER,
		// Token: 0x04002484 RID: 9348
		[ProtoEnum(Name = "STM2C_ALL_DATA", Value = 4)]
		STM2C_ALL_DATA,
		// Token: 0x04002485 RID: 9349
		[ProtoEnum(Name = "STM2C_TEAM_LIST", Value = 5)]
		STM2C_TEAM_LIST,
		// Token: 0x04002486 RID: 9350
		[ProtoEnum(Name = "STM2C_DESTROY", Value = 6)]
		STM2C_DESTROY,
		// Token: 0x04002487 RID: 9351
		[ProtoEnum(Name = "STM2C_GETEXTRADATA", Value = 7)]
		STM2C_GETEXTRADATA,
		// Token: 0x04002488 RID: 9352
		[ProtoEnum(Name = "STM2C_RESETCOST", Value = 8)]
		STM2C_RESETCOST,
		// Token: 0x04002489 RID: 9353
		[ProtoEnum(Name = "STM2C_TS_DISCONNECTED", Value = 9)]
		STM2C_TS_DISCONNECTED
	}
}
