using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GardenQuestType")]
	public enum GardenQuestType
	{

		[ProtoEnum(Name = "MYSELF", Value = 1)]
		MYSELF = 1,

		[ProtoEnum(Name = "FRIEND", Value = 2)]
		FRIEND,

		[ProtoEnum(Name = "GUILD", Value = 3)]
		GUILD
	}
}
