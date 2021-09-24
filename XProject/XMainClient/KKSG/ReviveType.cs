using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReviveType")]
	public enum ReviveType
	{

		[ProtoEnum(Name = "ReviveNone", Value = 0)]
		ReviveNone,

		[ProtoEnum(Name = "ReviveFree", Value = 1)]
		ReviveFree,

		[ProtoEnum(Name = "ReviveItem", Value = 2)]
		ReviveItem,

		[ProtoEnum(Name = "ReviveMoney", Value = 3)]
		ReviveMoney,

		[ProtoEnum(Name = "ReviveSprite", Value = 4)]
		ReviveSprite,

		[ProtoEnum(Name = "ReviveVIP", Value = 5)]
		ReviveVIP,

		[ProtoEnum(Name = "ReviveMax", Value = 6)]
		ReviveMax
	}
}
