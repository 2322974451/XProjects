using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000825 RID: 2085
	[ProtoContract(Name = "CompeteDragonOpArg")]
	public enum CompeteDragonOpArg
	{
		// Token: 0x040027C5 RID: 10181
		[ProtoEnum(Name = "CompeteDragon_GetInfo", Value = 1)]
		CompeteDragon_GetInfo = 1,
		// Token: 0x040027C6 RID: 10182
		[ProtoEnum(Name = "CompeteDragon_GetReward", Value = 2)]
		CompeteDragon_GetReward
	}
}
