using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200082F RID: 2095
	[ProtoContract(Name = "SurviveFightStage")]
	public enum SurviveFightStage
	{
		// Token: 0x04002804 RID: 10244
		[ProtoEnum(Name = "SURVIVE_STAGE_READY", Value = 1)]
		SURVIVE_STAGE_READY = 1,
		// Token: 0x04002805 RID: 10245
		[ProtoEnum(Name = "SURVIVE_STAGE_FIGHT", Value = 2)]
		SURVIVE_STAGE_FIGHT
	}
}
