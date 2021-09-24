using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CardMatchOp")]
	public enum CardMatchOp
	{

		[ProtoEnum(Name = "CardMatch_Begin", Value = 0)]
		CardMatch_Begin,

		[ProtoEnum(Name = "CardMatch_Add", Value = 2)]
		CardMatch_Add = 2,

		[ProtoEnum(Name = "CardMatch_Del", Value = 3)]
		CardMatch_Del,

		[ProtoEnum(Name = "CardMatch_RoundBegin", Value = 4)]
		CardMatch_RoundBegin,

		[ProtoEnum(Name = "CardMatch_RoundChange", Value = 5)]
		CardMatch_RoundChange,

		[ProtoEnum(Name = "CardMatch_RoundEnd", Value = 6)]
		CardMatch_RoundEnd,

		[ProtoEnum(Name = "CardMatch_End", Value = 7)]
		CardMatch_End,

		[ProtoEnum(Name = "CardMatch_Query", Value = 8)]
		CardMatch_Query,

		[ProtoEnum(Name = "CardMatch_RoundWaiting", Value = 9)]
		CardMatch_RoundWaiting,

		[ProtoEnum(Name = "CardMatch_SignUp", Value = 10)]
		CardMatch_SignUp
	}
}
