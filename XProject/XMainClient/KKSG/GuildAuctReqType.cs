using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007BF RID: 1983
	[ProtoContract(Name = "GuildAuctReqType")]
	public enum GuildAuctReqType
	{
		// Token: 0x04002584 RID: 9604
		[ProtoEnum(Name = "GART_ACT_TYPE", Value = 1)]
		GART_ACT_TYPE = 1,
		// Token: 0x04002585 RID: 9605
		[ProtoEnum(Name = "GART_ITEM_TYPE", Value = 2)]
		GART_ITEM_TYPE,
		// Token: 0x04002586 RID: 9606
		[ProtoEnum(Name = "GART_BUY_AUCT", Value = 5)]
		GART_BUY_AUCT = 5,
		// Token: 0x04002587 RID: 9607
		[ProtoEnum(Name = "GART_BUY_NOW", Value = 6)]
		GART_BUY_NOW,
		// Token: 0x04002588 RID: 9608
		[ProtoEnum(Name = "GART_AUCT_GUILD_HISTORY", Value = 7)]
		GART_AUCT_GUILD_HISTORY,
		// Token: 0x04002589 RID: 9609
		[ProtoEnum(Name = "GART_AUCT_WORLD_HISTORY", Value = 8)]
		GART_AUCT_WORLD_HISTORY
	}
}
