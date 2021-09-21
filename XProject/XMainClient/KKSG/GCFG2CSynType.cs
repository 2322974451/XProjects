using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007DE RID: 2014
	[ProtoContract(Name = "GCFG2CSynType")]
	public enum GCFG2CSynType
	{
		// Token: 0x0400263A RID: 9786
		[ProtoEnum(Name = "GCF_G2C_SYN_KILL_ONE", Value = 1)]
		GCF_G2C_SYN_KILL_ONE = 1,
		// Token: 0x0400263B RID: 9787
		[ProtoEnum(Name = "GCF_G2C_SYN_MUL_POINT", Value = 2)]
		GCF_G2C_SYN_MUL_POINT,
		// Token: 0x0400263C RID: 9788
		[ProtoEnum(Name = "GCF_G2C_SYN_OCCUPY", Value = 3)]
		GCF_G2C_SYN_OCCUPY,
		// Token: 0x0400263D RID: 9789
		[ProtoEnum(Name = "GCF_G2C_SYN_KILL_COUNT", Value = 4)]
		GCF_G2C_SYN_KILL_COUNT
	}
}
