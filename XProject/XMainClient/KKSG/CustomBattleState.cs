using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000805 RID: 2053
	[ProtoContract(Name = "CustomBattleState")]
	public enum CustomBattleState
	{
		// Token: 0x04002723 RID: 10019
		[ProtoEnum(Name = "CustomBattle_Ready", Value = 1)]
		CustomBattle_Ready = 1,
		// Token: 0x04002724 RID: 10020
		[ProtoEnum(Name = "CustomBattle_Going", Value = 2)]
		CustomBattle_Going,
		// Token: 0x04002725 RID: 10021
		[ProtoEnum(Name = "CustomBattle_End", Value = 3)]
		CustomBattle_End,
		// Token: 0x04002726 RID: 10022
		[ProtoEnum(Name = "CustomBattle_Destory", Value = 4)]
		CustomBattle_Destory
	}
}
