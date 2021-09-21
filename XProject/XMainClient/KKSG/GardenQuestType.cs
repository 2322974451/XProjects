using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007C0 RID: 1984
	[ProtoContract(Name = "GardenQuestType")]
	public enum GardenQuestType
	{
		// Token: 0x0400258B RID: 9611
		[ProtoEnum(Name = "MYSELF", Value = 1)]
		MYSELF = 1,
		// Token: 0x0400258C RID: 9612
		[ProtoEnum(Name = "FRIEND", Value = 2)]
		FRIEND,
		// Token: 0x0400258D RID: 9613
		[ProtoEnum(Name = "GUILD", Value = 3)]
		GUILD
	}
}
