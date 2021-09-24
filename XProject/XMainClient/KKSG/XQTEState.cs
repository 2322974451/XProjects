using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "XQTEState")]
	public enum XQTEState
	{

		[ProtoEnum(Name = "QTE_None", Value = 0)]
		QTE_None,

		[ProtoEnum(Name = "QTE_HitBackPresent", Value = 1)]
		QTE_HitBackPresent,

		[ProtoEnum(Name = "QTE_HitBackStraight", Value = 2)]
		QTE_HitBackStraight,

		[ProtoEnum(Name = "QTE_HitBackGetUp", Value = 3)]
		QTE_HitBackGetUp,

		[ProtoEnum(Name = "QTE_HitFlyPresent", Value = 4)]
		QTE_HitFlyPresent,

		[ProtoEnum(Name = "QTE_HitFlyLand", Value = 5)]
		QTE_HitFlyLand,

		[ProtoEnum(Name = "QTE_HitFlyBounce", Value = 6)]
		QTE_HitFlyBounce,

		[ProtoEnum(Name = "QTE_HitFlyStraight", Value = 7)]
		QTE_HitFlyStraight,

		[ProtoEnum(Name = "QTE_HitFlyGetUp", Value = 8)]
		QTE_HitFlyGetUp,

		[ProtoEnum(Name = "QTE_HitRollPresent", Value = 9)]
		QTE_HitRollPresent,

		[ProtoEnum(Name = "QTE_HitRollStraight", Value = 10)]
		QTE_HitRollStraight,

		[ProtoEnum(Name = "QTE_HitRollGetUp", Value = 11)]
		QTE_HitRollGetUp,

		[ProtoEnum(Name = "QTE_HitFreeze", Value = 12)]
		QTE_HitFreeze
	}
}
