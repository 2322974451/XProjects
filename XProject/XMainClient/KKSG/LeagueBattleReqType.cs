using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueBattleReqType")]
	public enum LeagueBattleReqType
	{

		[ProtoEnum(Name = "LBReqType_Match", Value = 1)]
		LBReqType_Match = 1,

		[ProtoEnum(Name = "LBReqType_CancelMatch", Value = 2)]
		LBReqType_CancelMatch
	}
}
