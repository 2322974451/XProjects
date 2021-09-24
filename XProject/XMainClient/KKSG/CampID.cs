using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CampID")]
	public enum CampID
	{

		[ProtoEnum(Name = "CAMP_DRAGON", Value = 1)]
		CAMP_DRAGON = 1,

		[ProtoEnum(Name = "CAMP_KNIGHT", Value = 2)]
		CAMP_KNIGHT,

		[ProtoEnum(Name = "CAMP_ADVENTURER", Value = 3)]
		CAMP_ADVENTURER
	}
}
