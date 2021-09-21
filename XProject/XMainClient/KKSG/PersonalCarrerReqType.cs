using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007EE RID: 2030
	[ProtoContract(Name = "PersonalCarrerReqType")]
	public enum PersonalCarrerReqType
	{
		// Token: 0x04002690 RID: 9872
		[ProtoEnum(Name = "PCRT_HOME_PAGE", Value = 1)]
		PCRT_HOME_PAGE = 1,
		// Token: 0x04002691 RID: 9873
		[ProtoEnum(Name = "PCRT_PVP_PKINFO", Value = 2)]
		PCRT_PVP_PKINFO,
		// Token: 0x04002692 RID: 9874
		[ProtoEnum(Name = "PCRT_TROPHY", Value = 3)]
		PCRT_TROPHY
	}
}
