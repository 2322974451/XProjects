using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000772 RID: 1906
	[ProtoContract(Name = "LogDBType")]
	public enum LogDBType
	{
		// Token: 0x040023AE RID: 9134
		[ProtoEnum(Name = "LOG_DB_NORMAL", Value = 0)]
		LOG_DB_NORMAL,
		// Token: 0x040023AF RID: 9135
		[ProtoEnum(Name = "LOG_DB_TENCENT", Value = 1)]
		LOG_DB_TENCENT
	}
}
