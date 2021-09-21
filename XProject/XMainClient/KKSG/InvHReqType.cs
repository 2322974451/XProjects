using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000782 RID: 1922
	[ProtoContract(Name = "InvHReqType")]
	public enum InvHReqType
	{
		// Token: 0x040023FA RID: 9210
		[ProtoEnum(Name = "INVH_REQ_UNF_LIST", Value = 1)]
		INVH_REQ_UNF_LIST = 1,
		// Token: 0x040023FB RID: 9211
		[ProtoEnum(Name = "INVH_UNF_IGNORE_ALL", Value = 2)]
		INVH_UNF_IGNORE_ALL,
		// Token: 0x040023FC RID: 9212
		[ProtoEnum(Name = "INVH_REFUSE_FORNOW", Value = 3)]
		INVH_REFUSE_FORNOW
	}
}
