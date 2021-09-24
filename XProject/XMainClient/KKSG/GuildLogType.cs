using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildLogType")]
	public enum GuildLogType
	{

		[ProtoEnum(Name = "GLog_Member", Value = 1)]
		GLog_Member = 1,

		[ProtoEnum(Name = "GLog_CheckIn", Value = 2)]
		GLog_CheckIn,

		[ProtoEnum(Name = "GLog_RedBonus", Value = 3)]
		GLog_RedBonus
	}
}
