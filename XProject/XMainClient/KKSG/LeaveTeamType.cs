using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007CA RID: 1994
	[ProtoContract(Name = "LeaveTeamType")]
	public enum LeaveTeamType
	{
		// Token: 0x040025CA RID: 9674
		[ProtoEnum(Name = "LTT_BY_SELF", Value = 0)]
		LTT_BY_SELF,
		// Token: 0x040025CB RID: 9675
		[ProtoEnum(Name = "LTT_KICK", Value = 1)]
		LTT_KICK,
		// Token: 0x040025CC RID: 9676
		[ProtoEnum(Name = "LTT_DEL_ROBOT", Value = 2)]
		LTT_DEL_ROBOT,
		// Token: 0x040025CD RID: 9677
		[ProtoEnum(Name = "LTT_MS_CRASH", Value = 3)]
		LTT_MS_CRASH,
		// Token: 0x040025CE RID: 9678
		[ProtoEnum(Name = "LLT_LEADER_TIMEOVER", Value = 4)]
		LLT_LEADER_TIMEOVER
	}
}
