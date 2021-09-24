using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarState")]
	public enum ResWarState
	{

		[ProtoEnum(Name = "ResWarExploreState", Value = 1)]
		ResWarExploreState = 1,

		[ProtoEnum(Name = "ResWarCancelState", Value = 2)]
		ResWarCancelState
	}
}
