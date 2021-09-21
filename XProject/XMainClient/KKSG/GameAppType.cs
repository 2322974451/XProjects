using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000779 RID: 1913
	[ProtoContract(Name = "GameAppType")]
	public enum GameAppType
	{
		// Token: 0x040023D0 RID: 9168
		[ProtoEnum(Name = "GAME_APP_WECHAT", Value = 1)]
		GAME_APP_WECHAT = 1,
		// Token: 0x040023D1 RID: 9169
		[ProtoEnum(Name = "GAME_APP_QQ", Value = 2)]
		GAME_APP_QQ
	}
}
