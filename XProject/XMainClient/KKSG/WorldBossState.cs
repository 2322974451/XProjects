using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WorldBossState")]
	public enum WorldBossState
	{

		[ProtoEnum(Name = "WorldBoss_BeginPre", Value = 0)]
		WorldBoss_BeginPre,

		[ProtoEnum(Name = "WorldBoss_Begin", Value = 1)]
		WorldBoss_Begin,

		[ProtoEnum(Name = "WorldBoss_Going", Value = 2)]
		WorldBoss_Going,

		[ProtoEnum(Name = "WorldBoss_WaitEnd", Value = 3)]
		WorldBoss_WaitEnd,

		[ProtoEnum(Name = "WorldBoss_End", Value = 4)]
		WorldBoss_End
	}
}
