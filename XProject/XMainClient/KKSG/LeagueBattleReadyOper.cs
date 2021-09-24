using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueBattleReadyOper")]
	public enum LeagueBattleReadyOper
	{

		[ProtoEnum(Name = "LBReady_Up", Value = 1)]
		LBReady_Up = 1,

		[ProtoEnum(Name = "LBReady_Down", Value = 2)]
		LBReady_Down
	}
}
