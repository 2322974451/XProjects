using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LogDBType")]
	public enum LogDBType
	{

		[ProtoEnum(Name = "LOG_DB_NORMAL", Value = 0)]
		LOG_DB_NORMAL,

		[ProtoEnum(Name = "LOG_DB_TENCENT", Value = 1)]
		LOG_DB_TENCENT
	}
}
