using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryResWarEnum")]
	public enum QueryResWarEnum
	{

		[ProtoEnum(Name = "RESWAR_FLOWAWARD", Value = 1)]
		RESWAR_FLOWAWARD = 1,

		[ProtoEnum(Name = "RESWAR_BATTLE", Value = 2)]
		RESWAR_BATTLE
	}
}
