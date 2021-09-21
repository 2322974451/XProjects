using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000812 RID: 2066
	[ProtoContract(Name = "MobaOp")]
	public enum MobaOp
	{
		// Token: 0x0400275B RID: 10075
		[ProtoEnum(Name = "MobaOp_LevelSkill", Value = 1)]
		MobaOp_LevelSkill = 1,
		// Token: 0x0400275C RID: 10076
		[ProtoEnum(Name = "MobaOp_Upgrade", Value = 2)]
		MobaOp_Upgrade
	}
}
