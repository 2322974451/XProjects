using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamEventG2M")]
	public enum TeamEventG2M
	{

		[ProtoEnum(Name = "TEAM_EVENT_BUYCOUNT", Value = 1)]
		TEAM_EVENT_BUYCOUNT = 1
	}
}
