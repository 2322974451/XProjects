using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyTeamState")]
	public enum SkyTeamState
	{

		[ProtoEnum(Name = "SkyTeamState_Idle", Value = 1)]
		SkyTeamState_Idle = 1,

		[ProtoEnum(Name = "SkyTeamState_Match", Value = 2)]
		SkyTeamState_Match,

		[ProtoEnum(Name = "SkyTeamState_Battle", Value = 3)]
		SkyTeamState_Battle
	}
}
