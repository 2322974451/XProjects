using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007CB RID: 1995
	[ProtoContract(Name = "StartUpType")]
	public enum StartUpType
	{
		// Token: 0x040025D0 RID: 9680
		[ProtoEnum(Name = "StartUp_Normal", Value = 1)]
		StartUp_Normal = 1,
		// Token: 0x040025D1 RID: 9681
		[ProtoEnum(Name = "StartUp_QQ", Value = 2)]
		StartUp_QQ,
		// Token: 0x040025D2 RID: 9682
		[ProtoEnum(Name = "StartUp_WX", Value = 3)]
		StartUp_WX
	}
}
