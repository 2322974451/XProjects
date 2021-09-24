using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GameAppType")]
	public enum GameAppType
	{

		[ProtoEnum(Name = "GAME_APP_WECHAT", Value = 1)]
		GAME_APP_WECHAT = 1,

		[ProtoEnum(Name = "GAME_APP_QQ", Value = 2)]
		GAME_APP_QQ
	}
}
