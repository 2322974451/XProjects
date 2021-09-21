using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007F8 RID: 2040
	[ProtoContract(Name = "ArenaStarReqType")]
	public enum ArenaStarReqType
	{
		// Token: 0x040026E0 RID: 9952
		[ProtoEnum(Name = "ASRT_ROLEDATA", Value = 1)]
		ASRT_ROLEDATA = 1,
		// Token: 0x040026E1 RID: 9953
		[ProtoEnum(Name = "ASRT_DIANZAN", Value = 2)]
		ASRT_DIANZAN
	}
}
