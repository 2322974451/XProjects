using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCraftType")]
	public enum SkyCraftType
	{

		[ProtoEnum(Name = "SCT_RacePoint", Value = 1)]
		SCT_RacePoint = 1,

		[ProtoEnum(Name = "SCT_Eliminate", Value = 2)]
		SCT_Eliminate
	}
}
