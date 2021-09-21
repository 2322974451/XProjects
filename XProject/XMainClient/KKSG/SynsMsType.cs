using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000791 RID: 1937
	[ProtoContract(Name = "SynsMsType")]
	public enum SynsMsType
	{
		// Token: 0x04002466 RID: 9318
		[ProtoEnum(Name = "SynsGuild", Value = 1)]
		SynsGuild = 1,
		// Token: 0x04002467 RID: 9319
		[ProtoEnum(Name = "SynsTeam", Value = 2)]
		SynsTeam
	}
}
