using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000797 RID: 1943
	[ProtoContract(Name = "PayCardType")]
	public enum PayCardType
	{
		// Token: 0x0400248B RID: 9355
		[ProtoEnum(Name = "WEEK_CARD", Value = 1)]
		WEEK_CARD = 1,
		// Token: 0x0400248C RID: 9356
		[ProtoEnum(Name = "MONTH_CARD", Value = 2)]
		MONTH_CARD
	}
}
