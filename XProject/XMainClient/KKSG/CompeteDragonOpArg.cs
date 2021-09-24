using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CompeteDragonOpArg")]
	public enum CompeteDragonOpArg
	{

		[ProtoEnum(Name = "CompeteDragon_GetInfo", Value = 1)]
		CompeteDragon_GetInfo = 1,

		[ProtoEnum(Name = "CompeteDragon_GetReward", Value = 2)]
		CompeteDragon_GetReward
	}
}
