using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildOpType")]
	public enum GuildOpType
	{

		[ProtoEnum(Name = "STUDY_SKILL", Value = 1)]
		STUDY_SKILL = 1,

		[ProtoEnum(Name = "GUILD_DARE_INFO", Value = 2)]
		GUILD_DARE_INFO
	}
}
