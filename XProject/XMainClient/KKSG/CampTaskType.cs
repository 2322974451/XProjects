using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CampTaskType")]
	public enum CampTaskType
	{

		[ProtoEnum(Name = "CAMPTASK_ITEM", Value = 1)]
		CAMPTASK_ITEM = 1,

		[ProtoEnum(Name = "CAMPTASK_SCENE", Value = 2)]
		CAMPTASK_SCENE,

		[ProtoEnum(Name = "CAMPTASK_PATROL", Value = 3)]
		CAMPTASK_PATROL,

		[ProtoEnum(Name = "CAMPTASK_SPY", Value = 4)]
		CAMPTASK_SPY
	}
}
