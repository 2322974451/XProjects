using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BossRushReqStatus")]
	public enum BossRushReqStatus
	{

		[ProtoEnum(Name = "BOSSRUSH_RESULT_WIN", Value = 1)]
		BOSSRUSH_RESULT_WIN = 1,

		[ProtoEnum(Name = "BOSSRUSH_RESULT_FAILED", Value = 2)]
		BOSSRUSH_RESULT_FAILED,

		[ProtoEnum(Name = "BOSSRUSH_REQ_BASEDATA", Value = 3)]
		BOSSRUSH_REQ_BASEDATA,

		[ProtoEnum(Name = "BOSSRUSH_REQ_REFRESH", Value = 4)]
		BOSSRUSH_REQ_REFRESH,

		[ProtoEnum(Name = "BOSSRUSH_REQ_APPEARANCE", Value = 5)]
		BOSSRUSH_REQ_APPEARANCE,

		[ProtoEnum(Name = "BOSSRUSH_REQ_LEFTCOUNT", Value = 6)]
		BOSSRUSH_REQ_LEFTCOUNT,

		[ProtoEnum(Name = "BOSSRUSH_REQ_CONTINUE", Value = 7)]
		BOSSRUSH_REQ_CONTINUE
	}
}
