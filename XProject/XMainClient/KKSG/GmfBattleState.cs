using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GmfBattleState")]
	public enum GmfBattleState
	{

		[ProtoEnum(Name = "GMF_BS_NONE", Value = 4)]
		GMF_BS_NONE = 4,

		[ProtoEnum(Name = "GMF_BS_WAIT", Value = 1)]
		GMF_BS_WAIT = 1,

		[ProtoEnum(Name = "GMF_BS_FIGHT", Value = 2)]
		GMF_BS_FIGHT,

		[ProtoEnum(Name = "GMF_BS_RESULT", Value = 3)]
		GMF_BS_RESULT
	}
}
