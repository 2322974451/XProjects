using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000834 RID: 2100
	[ProtoContract(Name = "CrossGvgRoomState")]
	public enum CrossGvgRoomState
	{
		// Token: 0x0400281D RID: 10269
		[ProtoEnum(Name = "CGRS_Idle", Value = 1)]
		CGRS_Idle = 1,
		// Token: 0x0400281E RID: 10270
		[ProtoEnum(Name = "CGRS_Fighting", Value = 2)]
		CGRS_Fighting,
		// Token: 0x0400281F RID: 10271
		[ProtoEnum(Name = "CGRS_Finish", Value = 3)]
		CGRS_Finish
	}
}
