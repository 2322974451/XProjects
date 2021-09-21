using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200076E RID: 1902
	[ProtoContract(Name = "CampTaskType")]
	public enum CampTaskType
	{
		// Token: 0x0400239C RID: 9116
		[ProtoEnum(Name = "CAMPTASK_ITEM", Value = 1)]
		CAMPTASK_ITEM = 1,
		// Token: 0x0400239D RID: 9117
		[ProtoEnum(Name = "CAMPTASK_SCENE", Value = 2)]
		CAMPTASK_SCENE,
		// Token: 0x0400239E RID: 9118
		[ProtoEnum(Name = "CAMPTASK_PATROL", Value = 3)]
		CAMPTASK_PATROL,
		// Token: 0x0400239F RID: 9119
		[ProtoEnum(Name = "CAMPTASK_SPY", Value = 4)]
		CAMPTASK_SPY
	}
}
