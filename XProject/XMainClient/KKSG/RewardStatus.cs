using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000776 RID: 1910
	[ProtoContract(Name = "RewardStatus")]
	public enum RewardStatus
	{
		// Token: 0x040023C5 RID: 9157
		[ProtoEnum(Name = "REWARD_STATUS_CANNOT", Value = 0)]
		REWARD_STATUS_CANNOT,
		// Token: 0x040023C6 RID: 9158
		[ProtoEnum(Name = "REWARD_STATUS_CAN", Value = 1)]
		REWARD_STATUS_CAN,
		// Token: 0x040023C7 RID: 9159
		[ProtoEnum(Name = "REWARD_STATUS_GOT", Value = 2)]
		REWARD_STATUS_GOT
	}
}
