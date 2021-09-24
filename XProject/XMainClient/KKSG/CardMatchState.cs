using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CardMatchState")]
	public enum CardMatchState
	{

		[ProtoEnum(Name = "CardMatch_StateBegin", Value = 0)]
		CardMatch_StateBegin,

		[ProtoEnum(Name = "CardMatch_StateWaiting", Value = 1)]
		CardMatch_StateWaiting,

		[ProtoEnum(Name = "CardMatch_StateRoundWaiting", Value = 2)]
		CardMatch_StateRoundWaiting,

		[ProtoEnum(Name = "CardMatch_StateRoundBegin", Value = 3)]
		CardMatch_StateRoundBegin,

		[ProtoEnum(Name = "CardMatch_StateRounding", Value = 4)]
		CardMatch_StateRounding,

		[ProtoEnum(Name = "CardMatch_StateRoundEnd", Value = 5)]
		CardMatch_StateRoundEnd,

		[ProtoEnum(Name = "CardMatch_StateEnd", Value = 6)]
		CardMatch_StateEnd,

		[ProtoEnum(Name = "CardMatch_StateDummy", Value = 7)]
		CardMatch_StateDummy
	}
}
