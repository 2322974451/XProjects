using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200082E RID: 2094
	[ProtoContract(Name = "SurviveFightEndType")]
	public enum SurviveFightEndType
	{
		// Token: 0x040027FF RID: 10239
		[ProtoEnum(Name = "SURVIVE_LOAD_TIMEOUT", Value = 1)]
		SURVIVE_LOAD_TIMEOUT = 1,
		// Token: 0x04002800 RID: 10240
		[ProtoEnum(Name = "SURVIVE_DIE", Value = 2)]
		SURVIVE_DIE,
		// Token: 0x04002801 RID: 10241
		[ProtoEnum(Name = "SURVIVE_QUIT", Value = 3)]
		SURVIVE_QUIT,
		// Token: 0x04002802 RID: 10242
		[ProtoEnum(Name = "SURVIVE_WIN", Value = 4)]
		SURVIVE_WIN
	}
}
