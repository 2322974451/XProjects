using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007E4 RID: 2020
	[ProtoContract(Name = "LeagueBattleReqType")]
	public enum LeagueBattleReqType
	{
		// Token: 0x0400265A RID: 9818
		[ProtoEnum(Name = "LBReqType_Match", Value = 1)]
		LBReqType_Match = 1,
		// Token: 0x0400265B RID: 9819
		[ProtoEnum(Name = "LBReqType_CancelMatch", Value = 2)]
		LBReqType_CancelMatch
	}
}
