using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200077A RID: 1914
	[ProtoContract(Name = "LoginRewardState")]
	public enum LoginRewardState
	{
		// Token: 0x040023D3 RID: 9171
		[ProtoEnum(Name = "LOGINRS_CANNOT", Value = 1)]
		LOGINRS_CANNOT = 1,
		// Token: 0x040023D4 RID: 9172
		[ProtoEnum(Name = "LOGINRS_HAVEHOT", Value = 2)]
		LOGINRS_HAVEHOT,
		// Token: 0x040023D5 RID: 9173
		[ProtoEnum(Name = "LOGINRS_HAVE", Value = 3)]
		LOGINRS_HAVE
	}
}
