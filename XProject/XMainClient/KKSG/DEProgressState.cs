using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007A6 RID: 1958
	[ProtoContract(Name = "DEProgressState")]
	public enum DEProgressState
	{
		// Token: 0x040024EE RID: 9454
		[ProtoEnum(Name = "DEPS_FINISH", Value = 1)]
		DEPS_FINISH = 1,
		// Token: 0x040024EF RID: 9455
		[ProtoEnum(Name = "DEPS_FIGHT", Value = 2)]
		DEPS_FIGHT,
		// Token: 0x040024F0 RID: 9456
		[ProtoEnum(Name = "DEPS_NOTOPEN", Value = 3)]
		DEPS_NOTOPEN
	}
}
