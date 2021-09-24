using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SCEliRoundType")]
	public enum SCEliRoundType
	{

		[ProtoEnum(Name = "SCEliRound_None", Value = 0)]
		SCEliRound_None,

		[ProtoEnum(Name = "SCEliRound_8to4", Value = 1)]
		SCEliRound_8to4,

		[ProtoEnum(Name = "SCEliRound_4to2", Value = 2)]
		SCEliRound_4to2,

		[ProtoEnum(Name = "SCEliRound_2to1", Value = 3)]
		SCEliRound_2to1
	}
}
