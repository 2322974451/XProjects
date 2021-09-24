using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PVP_ONEGAMEEND_REASON")]
	public enum PVP_ONEGAMEEND_REASON
	{

		[ProtoEnum(Name = "PVP_OGE_LEADER_DIE", Value = 1)]
		PVP_OGE_LEADER_DIE = 1,

		[ProtoEnum(Name = "PVP_OGE_LEADER_QUIT", Value = 2)]
		PVP_OGE_LEADER_QUIT,

		[ProtoEnum(Name = "PVP_OGE_TIMELIMIT", Value = 3)]
		PVP_OGE_TIMELIMIT,

		[ProtoEnum(Name = "PVP_OGE_ROLE_QUIT", Value = 4)]
		PVP_OGE_ROLE_QUIT
	}
}
