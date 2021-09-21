using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000801 RID: 2049
	[ProtoContract(Name = "QueryResWarEnum")]
	public enum QueryResWarEnum
	{
		// Token: 0x04002705 RID: 9989
		[ProtoEnum(Name = "RESWAR_FLOWAWARD", Value = 1)]
		RESWAR_FLOWAWARD = 1,
		// Token: 0x04002706 RID: 9990
		[ProtoEnum(Name = "RESWAR_BATTLE", Value = 2)]
		RESWAR_BATTLE
	}
}
