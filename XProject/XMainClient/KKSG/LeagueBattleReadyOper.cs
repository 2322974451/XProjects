using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007E7 RID: 2023
	[ProtoContract(Name = "LeagueBattleReadyOper")]
	public enum LeagueBattleReadyOper
	{
		// Token: 0x04002668 RID: 9832
		[ProtoEnum(Name = "LBReady_Up", Value = 1)]
		LBReady_Up = 1,
		// Token: 0x04002669 RID: 9833
		[ProtoEnum(Name = "LBReady_Down", Value = 2)]
		LBReady_Down
	}
}
