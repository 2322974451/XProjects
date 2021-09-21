using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000789 RID: 1929
	[ProtoContract(Name = "TeamInvRoleState")]
	public enum TeamInvRoleState
	{
		// Token: 0x04002437 RID: 9271
		[ProtoEnum(Name = "TIRS_IN_OTHER_TEAM", Value = 1)]
		TIRS_IN_OTHER_TEAM = 1,
		// Token: 0x04002438 RID: 9272
		[ProtoEnum(Name = "TIRS_IN_MY_TEAM", Value = 2)]
		TIRS_IN_MY_TEAM,
		// Token: 0x04002439 RID: 9273
		[ProtoEnum(Name = "TIRS_IN_BATTLE", Value = 3)]
		TIRS_IN_BATTLE,
		// Token: 0x0400243A RID: 9274
		[ProtoEnum(Name = "TIRS_NORMAL", Value = 4)]
		TIRS_NORMAL,
		// Token: 0x0400243B RID: 9275
		[ProtoEnum(Name = "TIRS_NOT_OPEN", Value = 5)]
		TIRS_NOT_OPEN,
		// Token: 0x0400243C RID: 9276
		[ProtoEnum(Name = "TIRS_COUNT_LESS", Value = 6)]
		TIRS_COUNT_LESS,
		// Token: 0x0400243D RID: 9277
		[ProtoEnum(Name = "TIRS_FATIGUE_LESS", Value = 7)]
		TIRS_FATIGUE_LESS
	}
}
