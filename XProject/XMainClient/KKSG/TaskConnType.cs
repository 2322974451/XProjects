using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TaskConnType")]
	public enum TaskConnType
	{

		[ProtoEnum(Name = "TaskConn_ItemID", Value = 1)]
		TaskConn_ItemID = 1,

		[ProtoEnum(Name = "TaskConn_StageID", Value = 2)]
		TaskConn_StageID,

		[ProtoEnum(Name = "TaskConn_MonsterID", Value = 3)]
		TaskConn_MonsterID,

		[ProtoEnum(Name = "TaskConn_ItemTypeQuality", Value = 4)]
		TaskConn_ItemTypeQuality,

		[ProtoEnum(Name = "TaskConn_Activity", Value = 5)]
		TaskConn_Activity,

		[ProtoEnum(Name = "TaskConn_WorldBossRank", Value = 6)]
		TaskConn_WorldBossRank,

		[ProtoEnum(Name = "TaskConn_StageType", Value = 7)]
		TaskConn_StageType
	}
}
