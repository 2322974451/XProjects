using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ServerTag")]
	public enum ServerTag
	{

		[ProtoEnum(Name = "SERVER_TAG_NORMAL", Value = 1)]
		SERVER_TAG_NORMAL = 1,

		[ProtoEnum(Name = "SERVER_TAG_IOS_AUDIT", Value = 2)]
		SERVER_TAG_IOS_AUDIT
	}
}
