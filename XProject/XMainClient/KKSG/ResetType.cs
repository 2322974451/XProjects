using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000750 RID: 1872
	[ProtoContract(Name = "ResetType")]
	public enum ResetType
	{
		// Token: 0x04002270 RID: 8816
		[ProtoEnum(Name = "RESET_SKILL", Value = 0)]
		RESET_SKILL,
		// Token: 0x04002271 RID: 8817
		[ProtoEnum(Name = "RESET_PROFESSION", Value = 1)]
		RESET_PROFESSION,
		// Token: 0x04002272 RID: 8818
		[ProtoEnum(Name = "RESET_GUILD_SKILL", Value = 2)]
		RESET_GUILD_SKILL
	}
}
