using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000793 RID: 1939
	[ProtoContract(Name = "NoticeType")]
	public enum NoticeType
	{
		// Token: 0x04002473 RID: 9331
		[ProtoEnum(Name = "Notice_Role", Value = 1)]
		Notice_Role = 1,
		// Token: 0x04002474 RID: 9332
		[ProtoEnum(Name = "Notice_Team", Value = 2)]
		Notice_Team,
		// Token: 0x04002475 RID: 9333
		[ProtoEnum(Name = "Notice_Guild", Value = 3)]
		Notice_Guild,
		// Token: 0x04002476 RID: 9334
		[ProtoEnum(Name = "Notice_World", Value = 4)]
		Notice_World,
		// Token: 0x04002477 RID: 9335
		[ProtoEnum(Name = "Notice_Partner", Value = 5)]
		Notice_Partner,
		// Token: 0x04002478 RID: 9336
		[ProtoEnum(Name = "Notice_Server", Value = 6)]
		Notice_Server
	}
}
