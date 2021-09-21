using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007C3 RID: 1987
	[ProtoContract(Name = "GuildAuctResultType")]
	public enum GuildAuctResultType
	{
		// Token: 0x040025A2 RID: 9634
		[ProtoEnum(Name = "GA_RESULT_BUY_NOW", Value = 1)]
		GA_RESULT_BUY_NOW = 1,
		// Token: 0x040025A3 RID: 9635
		[ProtoEnum(Name = "GA_RESULT_BUY_AUCT", Value = 2)]
		GA_RESULT_BUY_AUCT,
		// Token: 0x040025A4 RID: 9636
		[ProtoEnum(Name = "GA_RESULT_TO_WORLD", Value = 3)]
		GA_RESULT_TO_WORLD
	}
}
