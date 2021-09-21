using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007B3 RID: 1971
	[ProtoContract(Name = "GuildBindStatus")]
	public enum GuildBindStatus
	{
		// Token: 0x0400253B RID: 9531
		[ProtoEnum(Name = "GBS_NotBind", Value = 1)]
		GBS_NotBind = 1,
		// Token: 0x0400253C RID: 9532
		[ProtoEnum(Name = "GBS_Owner", Value = 2)]
		GBS_Owner,
		// Token: 0x0400253D RID: 9533
		[ProtoEnum(Name = "GBS_Admin", Value = 3)]
		GBS_Admin,
		// Token: 0x0400253E RID: 9534
		[ProtoEnum(Name = "GBS_Member", Value = 4)]
		GBS_Member,
		// Token: 0x0400253F RID: 9535
		[ProtoEnum(Name = "GBS_NotMember", Value = 5)]
		GBS_NotMember
	}
}
