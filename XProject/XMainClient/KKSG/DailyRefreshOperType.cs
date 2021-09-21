using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200082C RID: 2092
	[ProtoContract(Name = "DailyRefreshOperType")]
	public enum DailyRefreshOperType
	{
		// Token: 0x040027F6 RID: 10230
		[ProtoEnum(Name = "DROT_Refresh", Value = 1)]
		DROT_Refresh = 1,
		// Token: 0x040027F7 RID: 10231
		[ProtoEnum(Name = "DROT_Refuse", Value = 2)]
		DROT_Refuse,
		// Token: 0x040027F8 RID: 10232
		[ProtoEnum(Name = "DROT_BuyCount", Value = 3)]
		DROT_BuyCount,
		// Token: 0x040027F9 RID: 10233
		[ProtoEnum(Name = "DROT_AskHelp", Value = 4)]
		DROT_AskHelp
	}
}
