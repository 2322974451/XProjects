using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SurviveFightEndType")]
	public enum SurviveFightEndType
	{

		[ProtoEnum(Name = "SURVIVE_LOAD_TIMEOUT", Value = 1)]
		SURVIVE_LOAD_TIMEOUT = 1,

		[ProtoEnum(Name = "SURVIVE_DIE", Value = 2)]
		SURVIVE_DIE,

		[ProtoEnum(Name = "SURVIVE_QUIT", Value = 3)]
		SURVIVE_QUIT,

		[ProtoEnum(Name = "SURVIVE_WIN", Value = 4)]
		SURVIVE_WIN
	}
}
