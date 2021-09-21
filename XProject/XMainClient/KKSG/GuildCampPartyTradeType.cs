using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000809 RID: 2057
	[ProtoContract(Name = "GuildCampPartyTradeType")]
	public enum GuildCampPartyTradeType
	{
		// Token: 0x04002738 RID: 10040
		[ProtoEnum(Name = "TRADE_INVITATION", Value = 1)]
		TRADE_INVITATION = 1,
		// Token: 0x04002739 RID: 10041
		[ProtoEnum(Name = "UPDATA_TRADE_STATUS", Value = 2)]
		UPDATA_TRADE_STATUS
	}
}
