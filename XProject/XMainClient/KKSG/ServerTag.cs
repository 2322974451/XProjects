using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007A0 RID: 1952
	[ProtoContract(Name = "ServerTag")]
	public enum ServerTag
	{
		// Token: 0x040024BC RID: 9404
		[ProtoEnum(Name = "SERVER_TAG_NORMAL", Value = 1)]
		SERVER_TAG_NORMAL = 1,
		// Token: 0x040024BD RID: 9405
		[ProtoEnum(Name = "SERVER_TAG_IOS_AUDIT", Value = 2)]
		SERVER_TAG_IOS_AUDIT
	}
}
