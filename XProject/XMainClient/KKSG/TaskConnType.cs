using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000826 RID: 2086
	[ProtoContract(Name = "TaskConnType")]
	public enum TaskConnType
	{
		// Token: 0x040027C8 RID: 10184
		[ProtoEnum(Name = "TaskConn_ItemID", Value = 1)]
		TaskConn_ItemID = 1,
		// Token: 0x040027C9 RID: 10185
		[ProtoEnum(Name = "TaskConn_StageID", Value = 2)]
		TaskConn_StageID,
		// Token: 0x040027CA RID: 10186
		[ProtoEnum(Name = "TaskConn_MonsterID", Value = 3)]
		TaskConn_MonsterID,
		// Token: 0x040027CB RID: 10187
		[ProtoEnum(Name = "TaskConn_ItemTypeQuality", Value = 4)]
		TaskConn_ItemTypeQuality,
		// Token: 0x040027CC RID: 10188
		[ProtoEnum(Name = "TaskConn_Activity", Value = 5)]
		TaskConn_Activity,
		// Token: 0x040027CD RID: 10189
		[ProtoEnum(Name = "TaskConn_WorldBossRank", Value = 6)]
		TaskConn_WorldBossRank,
		// Token: 0x040027CE RID: 10190
		[ProtoEnum(Name = "TaskConn_StageType", Value = 7)]
		TaskConn_StageType
	}
}
