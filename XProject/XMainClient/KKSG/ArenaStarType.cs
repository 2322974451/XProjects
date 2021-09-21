using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007F7 RID: 2039
	[ProtoContract(Name = "ArenaStarType")]
	public enum ArenaStarType
	{
		// Token: 0x040026DB RID: 9947
		[ProtoEnum(Name = "AST_PK", Value = 1)]
		AST_PK = 1,
		// Token: 0x040026DC RID: 9948
		[ProtoEnum(Name = "AST_HEROBATTLE", Value = 2)]
		AST_HEROBATTLE,
		// Token: 0x040026DD RID: 9949
		[ProtoEnum(Name = "AST_WEEKNEST", Value = 3)]
		AST_WEEKNEST,
		// Token: 0x040026DE RID: 9950
		[ProtoEnum(Name = "AST_LEAGUE", Value = 4)]
		AST_LEAGUE
	}
}
