using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200075F RID: 1887
	[ProtoContract(Name = "GuildLogType")]
	public enum GuildLogType
	{
		// Token: 0x0400231C RID: 8988
		[ProtoEnum(Name = "GLog_Member", Value = 1)]
		GLog_Member = 1,
		// Token: 0x0400231D RID: 8989
		[ProtoEnum(Name = "GLog_CheckIn", Value = 2)]
		GLog_CheckIn,
		// Token: 0x0400231E RID: 8990
		[ProtoEnum(Name = "GLog_RedBonus", Value = 3)]
		GLog_RedBonus
	}
}
