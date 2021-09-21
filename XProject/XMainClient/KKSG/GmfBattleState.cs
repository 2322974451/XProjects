using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007B4 RID: 1972
	[ProtoContract(Name = "GmfBattleState")]
	public enum GmfBattleState
	{
		// Token: 0x04002541 RID: 9537
		[ProtoEnum(Name = "GMF_BS_NONE", Value = 4)]
		GMF_BS_NONE = 4,
		// Token: 0x04002542 RID: 9538
		[ProtoEnum(Name = "GMF_BS_WAIT", Value = 1)]
		GMF_BS_WAIT = 1,
		// Token: 0x04002543 RID: 9539
		[ProtoEnum(Name = "GMF_BS_FIGHT", Value = 2)]
		GMF_BS_FIGHT,
		// Token: 0x04002544 RID: 9540
		[ProtoEnum(Name = "GMF_BS_RESULT", Value = 3)]
		GMF_BS_RESULT
	}
}
