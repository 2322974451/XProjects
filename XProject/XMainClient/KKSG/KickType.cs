using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000748 RID: 1864
	[ProtoContract(Name = "KickType")]
	public enum KickType
	{
		// Token: 0x04001E6B RID: 7787
		[ProtoEnum(Name = "KICK_NORMAL", Value = 0)]
		KICK_NORMAL,
		// Token: 0x04001E6C RID: 7788
		[ProtoEnum(Name = "KICK_RELOGIN", Value = 1)]
		KICK_RELOGIN,
		// Token: 0x04001E6D RID: 7789
		[ProtoEnum(Name = "KICK_GMFORBID", Value = 2)]
		KICK_GMFORBID,
		// Token: 0x04001E6E RID: 7790
		[ProtoEnum(Name = "KICK_SERVER_SHUTDOWN", Value = 3)]
		KICK_SERVER_SHUTDOWN,
		// Token: 0x04001E6F RID: 7791
		[ProtoEnum(Name = "KICK_DEL_ROLE", Value = 4)]
		KICK_DEL_ROLE,
		// Token: 0x04001E70 RID: 7792
		[ProtoEnum(Name = "KICK_CHANGE_PROFESSION", Value = 5)]
		KICK_CHANGE_PROFESSION,
		// Token: 0x04001E71 RID: 7793
		[ProtoEnum(Name = "KICK_HG", Value = 6)]
		KICK_HG
	}
}
