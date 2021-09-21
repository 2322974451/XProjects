using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007C7 RID: 1991
	[ProtoContract(Name = "EnumServerState")]
	public enum EnumServerState
	{
		// Token: 0x040025B6 RID: 9654
		[ProtoEnum(Name = "ServerState_Maintain", Value = 0)]
		ServerState_Maintain,
		// Token: 0x040025B7 RID: 9655
		[ProtoEnum(Name = "ServerState_Smooth", Value = 1)]
		ServerState_Smooth,
		// Token: 0x040025B8 RID: 9656
		[ProtoEnum(Name = "ServerState_Hot", Value = 2)]
		ServerState_Hot,
		// Token: 0x040025B9 RID: 9657
		[ProtoEnum(Name = "ServerState_Full", Value = 3)]
		ServerState_Full,
		// Token: 0x040025BA RID: 9658
		[ProtoEnum(Name = "ServerState_Recommend", Value = 4)]
		ServerState_Recommend,
		// Token: 0x040025BB RID: 9659
		[ProtoEnum(Name = "ServerState_Auto", Value = 5)]
		ServerState_Auto
	}
}
