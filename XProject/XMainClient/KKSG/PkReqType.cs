using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200079C RID: 1948
	[ProtoContract(Name = "PkReqType")]
	public enum PkReqType
	{
		// Token: 0x0400249F RID: 9375
		[ProtoEnum(Name = "PKREQ_ADDPK", Value = 1)]
		PKREQ_ADDPK = 1,
		// Token: 0x040024A0 RID: 9376
		[ProtoEnum(Name = "PKREQ_REMOVEPK", Value = 2)]
		PKREQ_REMOVEPK,
		// Token: 0x040024A1 RID: 9377
		[ProtoEnum(Name = "PKREQ_ALLINFO", Value = 3)]
		PKREQ_ALLINFO,
		// Token: 0x040024A2 RID: 9378
		[ProtoEnum(Name = "PKREQ_FETCHPOINTREWARD", Value = 4)]
		PKREQ_FETCHPOINTREWARD
	}
}
