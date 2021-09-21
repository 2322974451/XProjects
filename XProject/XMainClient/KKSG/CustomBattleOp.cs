using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000802 RID: 2050
	[ProtoContract(Name = "CustomBattleOp")]
	public enum CustomBattleOp
	{
		// Token: 0x04002708 RID: 9992
		[ProtoEnum(Name = "CustomBattle_Query", Value = 1)]
		CustomBattle_Query = 1,
		// Token: 0x04002709 RID: 9993
		[ProtoEnum(Name = "CustomBattle_Create", Value = 2)]
		CustomBattle_Create,
		// Token: 0x0400270A RID: 9994
		[ProtoEnum(Name = "CustomBattle_Join", Value = 3)]
		CustomBattle_Join,
		// Token: 0x0400270B RID: 9995
		[ProtoEnum(Name = "CustomBattle_Match", Value = 4)]
		CustomBattle_Match,
		// Token: 0x0400270C RID: 9996
		[ProtoEnum(Name = "CustomBattle_Reward", Value = 5)]
		CustomBattle_Reward,
		// Token: 0x0400270D RID: 9997
		[ProtoEnum(Name = "CustomBattle_ClearCD", Value = 6)]
		CustomBattle_ClearCD,
		// Token: 0x0400270E RID: 9998
		[ProtoEnum(Name = "CustomBattle_QueryRandom", Value = 7)]
		CustomBattle_QueryRandom,
		// Token: 0x0400270F RID: 9999
		[ProtoEnum(Name = "CustomBattle_QueryOne", Value = 8)]
		CustomBattle_QueryOne,
		// Token: 0x04002710 RID: 10000
		[ProtoEnum(Name = "CustomBattle_DoCreate", Value = 9)]
		CustomBattle_DoCreate,
		// Token: 0x04002711 RID: 10001
		[ProtoEnum(Name = "CustomBattle_DoJoin", Value = 10)]
		CustomBattle_DoJoin,
		// Token: 0x04002712 RID: 10002
		[ProtoEnum(Name = "CustomBattle_UnJoin", Value = 11)]
		CustomBattle_UnJoin,
		// Token: 0x04002713 RID: 10003
		[ProtoEnum(Name = "CustomBattle_UnMatch", Value = 12)]
		CustomBattle_UnMatch,
		// Token: 0x04002714 RID: 10004
		[ProtoEnum(Name = "CustomBattle_Modify", Value = 13)]
		CustomBattle_Modify,
		// Token: 0x04002715 RID: 10005
		[ProtoEnum(Name = "CustomBattle_QuerySelf", Value = 14)]
		CustomBattle_QuerySelf,
		// Token: 0x04002716 RID: 10006
		[ProtoEnum(Name = "CustomBattle_StartNow", Value = 15)]
		CustomBattle_StartNow,
		// Token: 0x04002717 RID: 10007
		[ProtoEnum(Name = "CustomBattle_DoClearCD", Value = 16)]
		CustomBattle_DoClearCD,
		// Token: 0x04002718 RID: 10008
		[ProtoEnum(Name = "CustomBattle_Drop", Value = 17)]
		CustomBattle_Drop,
		// Token: 0x04002719 RID: 10009
		[ProtoEnum(Name = "CustomBattle_Search", Value = 18)]
		CustomBattle_Search
	}
}
