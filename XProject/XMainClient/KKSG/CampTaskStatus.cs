using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CampTaskStatus")]
	public enum CampTaskStatus
	{

		[ProtoEnum(Name = "CAMPTASK_GET", Value = 1)]
		CAMPTASK_GET = 1,

		[ProtoEnum(Name = "CAMPTASK_VIEW", Value = 2)]
		CAMPTASK_VIEW,

		[ProtoEnum(Name = "CAMPTASK_FINISH", Value = 3)]
		CAMPTASK_FINISH,

		[ProtoEnum(Name = "CAMPTASK_REWARD", Value = 4)]
		CAMPTASK_REWARD
	}
}
