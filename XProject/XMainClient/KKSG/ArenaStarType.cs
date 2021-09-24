using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ArenaStarType")]
	public enum ArenaStarType
	{

		[ProtoEnum(Name = "AST_PK", Value = 1)]
		AST_PK = 1,

		[ProtoEnum(Name = "AST_HEROBATTLE", Value = 2)]
		AST_HEROBATTLE,

		[ProtoEnum(Name = "AST_WEEKNEST", Value = 3)]
		AST_WEEKNEST,

		[ProtoEnum(Name = "AST_LEAGUE", Value = 4)]
		AST_LEAGUE
	}
}
