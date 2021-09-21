using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000786 RID: 1926
	[ProtoContract(Name = "BossRushReqStatus")]
	public enum BossRushReqStatus
	{
		// Token: 0x04002421 RID: 9249
		[ProtoEnum(Name = "BOSSRUSH_RESULT_WIN", Value = 1)]
		BOSSRUSH_RESULT_WIN = 1,
		// Token: 0x04002422 RID: 9250
		[ProtoEnum(Name = "BOSSRUSH_RESULT_FAILED", Value = 2)]
		BOSSRUSH_RESULT_FAILED,
		// Token: 0x04002423 RID: 9251
		[ProtoEnum(Name = "BOSSRUSH_REQ_BASEDATA", Value = 3)]
		BOSSRUSH_REQ_BASEDATA,
		// Token: 0x04002424 RID: 9252
		[ProtoEnum(Name = "BOSSRUSH_REQ_REFRESH", Value = 4)]
		BOSSRUSH_REQ_REFRESH,
		// Token: 0x04002425 RID: 9253
		[ProtoEnum(Name = "BOSSRUSH_REQ_APPEARANCE", Value = 5)]
		BOSSRUSH_REQ_APPEARANCE,
		// Token: 0x04002426 RID: 9254
		[ProtoEnum(Name = "BOSSRUSH_REQ_LEFTCOUNT", Value = 6)]
		BOSSRUSH_REQ_LEFTCOUNT,
		// Token: 0x04002427 RID: 9255
		[ProtoEnum(Name = "BOSSRUSH_REQ_CONTINUE", Value = 7)]
		BOSSRUSH_REQ_CONTINUE
	}
}
