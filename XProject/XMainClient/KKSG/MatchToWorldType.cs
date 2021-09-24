using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MatchToWorldType")]
	public enum MatchToWorldType
	{

		[ProtoEnum(Name = "MTWT_ADD", Value = 1)]
		MTWT_ADD = 1,

		[ProtoEnum(Name = "MTWT_DEL", Value = 2)]
		MTWT_DEL,

		[ProtoEnum(Name = "MTWT_MATCH_INWORLD", Value = 3)]
		MTWT_MATCH_INWORLD
	}
}
