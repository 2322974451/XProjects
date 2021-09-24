using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SurviveFightStage")]
	public enum SurviveFightStage
	{

		[ProtoEnum(Name = "SURVIVE_STAGE_READY", Value = 1)]
		SURVIVE_STAGE_READY = 1,

		[ProtoEnum(Name = "SURVIVE_STAGE_FIGHT", Value = 2)]
		SURVIVE_STAGE_FIGHT
	}
}
