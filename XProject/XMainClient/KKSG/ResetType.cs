using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResetType")]
	public enum ResetType
	{

		[ProtoEnum(Name = "RESET_SKILL", Value = 0)]
		RESET_SKILL,

		[ProtoEnum(Name = "RESET_PROFESSION", Value = 1)]
		RESET_PROFESSION,

		[ProtoEnum(Name = "RESET_GUILD_SKILL", Value = 2)]
		RESET_GUILD_SKILL
	}
}
