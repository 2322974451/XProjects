using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007C6 RID: 1990
	[ProtoContract(Name = "ServerFlag")]
	public enum ServerFlag
	{
		// Token: 0x040025AE RID: 9646
		[ProtoEnum(Name = "ServerFlag_Maintain", Value = 0)]
		ServerFlag_Maintain,
		// Token: 0x040025AF RID: 9647
		[ProtoEnum(Name = "ServerFlag_New", Value = 1)]
		ServerFlag_New,
		// Token: 0x040025B0 RID: 9648
		[ProtoEnum(Name = "ServerFlag_Hot", Value = 2)]
		ServerFlag_Hot,
		// Token: 0x040025B1 RID: 9649
		[ProtoEnum(Name = "ServerFlag_Full", Value = 3)]
		ServerFlag_Full,
		// Token: 0x040025B2 RID: 9650
		[ProtoEnum(Name = "ServerFlag_Recommend", Value = 4)]
		ServerFlag_Recommend,
		// Token: 0x040025B3 RID: 9651
		[ProtoEnum(Name = "ServerFlag_Dummy", Value = 5)]
		ServerFlag_Dummy,
		// Token: 0x040025B4 RID: 9652
		[ProtoEnum(Name = "ServerFlag_Smooth", Value = 7)]
		ServerFlag_Smooth = 7
	}
}
