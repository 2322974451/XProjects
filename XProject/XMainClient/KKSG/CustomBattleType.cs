using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000804 RID: 2052
	[ProtoContract(Name = "CustomBattleType")]
	public enum CustomBattleType
	{
		// Token: 0x04002720 RID: 10016
		[ProtoEnum(Name = "CustomBattle_PK_Normal", Value = 1)]
		CustomBattle_PK_Normal = 1,
		// Token: 0x04002721 RID: 10017
		[ProtoEnum(Name = "CustomBattle_PKTwo_Normal", Value = 2)]
		CustomBattle_PKTwo_Normal
	}
}
