using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007B2 RID: 1970
	[ProtoContract(Name = "CardMatchState")]
	public enum CardMatchState
	{
		// Token: 0x04002532 RID: 9522
		[ProtoEnum(Name = "CardMatch_StateBegin", Value = 0)]
		CardMatch_StateBegin,
		// Token: 0x04002533 RID: 9523
		[ProtoEnum(Name = "CardMatch_StateWaiting", Value = 1)]
		CardMatch_StateWaiting,
		// Token: 0x04002534 RID: 9524
		[ProtoEnum(Name = "CardMatch_StateRoundWaiting", Value = 2)]
		CardMatch_StateRoundWaiting,
		// Token: 0x04002535 RID: 9525
		[ProtoEnum(Name = "CardMatch_StateRoundBegin", Value = 3)]
		CardMatch_StateRoundBegin,
		// Token: 0x04002536 RID: 9526
		[ProtoEnum(Name = "CardMatch_StateRounding", Value = 4)]
		CardMatch_StateRounding,
		// Token: 0x04002537 RID: 9527
		[ProtoEnum(Name = "CardMatch_StateRoundEnd", Value = 5)]
		CardMatch_StateRoundEnd,
		// Token: 0x04002538 RID: 9528
		[ProtoEnum(Name = "CardMatch_StateEnd", Value = 6)]
		CardMatch_StateEnd,
		// Token: 0x04002539 RID: 9529
		[ProtoEnum(Name = "CardMatch_StateDummy", Value = 7)]
		CardMatch_StateDummy
	}
}
