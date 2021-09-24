using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildBindStatus")]
	public enum GuildBindStatus
	{

		[ProtoEnum(Name = "GBS_NotBind", Value = 1)]
		GBS_NotBind = 1,

		[ProtoEnum(Name = "GBS_Owner", Value = 2)]
		GBS_Owner,

		[ProtoEnum(Name = "GBS_Admin", Value = 3)]
		GBS_Admin,

		[ProtoEnum(Name = "GBS_Member", Value = 4)]
		GBS_Member,

		[ProtoEnum(Name = "GBS_NotMember", Value = 5)]
		GBS_NotMember
	}
}
