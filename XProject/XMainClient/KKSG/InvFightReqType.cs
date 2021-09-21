using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007D7 RID: 2007
	[ProtoContract(Name = "InvFightReqType")]
	public enum InvFightReqType
	{
		// Token: 0x04002617 RID: 9751
		[ProtoEnum(Name = "IFRT_INV_ONE", Value = 1)]
		IFRT_INV_ONE = 1,
		// Token: 0x04002618 RID: 9752
		[ProtoEnum(Name = "IFRT_REFUSH_ONE", Value = 2)]
		IFRT_REFUSH_ONE,
		// Token: 0x04002619 RID: 9753
		[ProtoEnum(Name = "IFRT_IGNORE_ALL", Value = 3)]
		IFRT_IGNORE_ALL,
		// Token: 0x0400261A RID: 9754
		[ProtoEnum(Name = "IFRT_REQ_LIST", Value = 4)]
		IFRT_REQ_LIST,
		// Token: 0x0400261B RID: 9755
		[ProtoEnum(Name = "IFRT_ACCEPT_ONE", Value = 5)]
		IFRT_ACCEPT_ONE
	}
}
