using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007B1 RID: 1969
	[ProtoContract(Name = "CardMatchOp")]
	public enum CardMatchOp
	{
		// Token: 0x04002527 RID: 9511
		[ProtoEnum(Name = "CardMatch_Begin", Value = 0)]
		CardMatch_Begin,
		// Token: 0x04002528 RID: 9512
		[ProtoEnum(Name = "CardMatch_Add", Value = 2)]
		CardMatch_Add = 2,
		// Token: 0x04002529 RID: 9513
		[ProtoEnum(Name = "CardMatch_Del", Value = 3)]
		CardMatch_Del,
		// Token: 0x0400252A RID: 9514
		[ProtoEnum(Name = "CardMatch_RoundBegin", Value = 4)]
		CardMatch_RoundBegin,
		// Token: 0x0400252B RID: 9515
		[ProtoEnum(Name = "CardMatch_RoundChange", Value = 5)]
		CardMatch_RoundChange,
		// Token: 0x0400252C RID: 9516
		[ProtoEnum(Name = "CardMatch_RoundEnd", Value = 6)]
		CardMatch_RoundEnd,
		// Token: 0x0400252D RID: 9517
		[ProtoEnum(Name = "CardMatch_End", Value = 7)]
		CardMatch_End,
		// Token: 0x0400252E RID: 9518
		[ProtoEnum(Name = "CardMatch_Query", Value = 8)]
		CardMatch_Query,
		// Token: 0x0400252F RID: 9519
		[ProtoEnum(Name = "CardMatch_RoundWaiting", Value = 9)]
		CardMatch_RoundWaiting,
		// Token: 0x04002530 RID: 9520
		[ProtoEnum(Name = "CardMatch_SignUp", Value = 10)]
		CardMatch_SignUp
	}
}
