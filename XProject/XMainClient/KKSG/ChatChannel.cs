using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200075A RID: 1882
	[ProtoContract(Name = "ChatChannel")]
	public enum ChatChannel
	{
		// Token: 0x040022F5 RID: 8949
		[ProtoEnum(Name = "WorldChannel", Value = 1)]
		WorldChannel = 1,
		// Token: 0x040022F6 RID: 8950
		[ProtoEnum(Name = "GuildChannel", Value = 2)]
		GuildChannel,
		// Token: 0x040022F7 RID: 8951
		[ProtoEnum(Name = "PrivateChannel", Value = 3)]
		PrivateChannel,
		// Token: 0x040022F8 RID: 8952
		[ProtoEnum(Name = "SystemChannel", Value = 4)]
		SystemChannel,
		// Token: 0x040022F9 RID: 8953
		[ProtoEnum(Name = "LampShortChannel", Value = 5)]
		LampShortChannel,
		// Token: 0x040022FA RID: 8954
		[ProtoEnum(Name = "LampLongChannel", Value = 6)]
		LampLongChannel,
		// Token: 0x040022FB RID: 8955
		[ProtoEnum(Name = "TeamChannel", Value = 7)]
		TeamChannel,
		// Token: 0x040022FC RID: 8956
		[ProtoEnum(Name = "CampChannel", Value = 8)]
		CampChannel,
		// Token: 0x040022FD RID: 8957
		[ProtoEnum(Name = "SpectateChannel", Value = 9)]
		SpectateChannel,
		// Token: 0x040022FE RID: 8958
		[ProtoEnum(Name = "CurrentChannel", Value = 10)]
		CurrentChannel,
		// Token: 0x040022FF RID: 8959
		[ProtoEnum(Name = "PartnerChannel", Value = 11)]
		PartnerChannel,
		// Token: 0x04002300 RID: 8960
		[ProtoEnum(Name = "AudioChannel", Value = 12)]
		AudioChannel,
		// Token: 0x04002301 RID: 8961
		[ProtoEnum(Name = "BattleChannel", Value = 13)]
		BattleChannel,
		// Token: 0x04002302 RID: 8962
		[ProtoEnum(Name = "GroupChatChannel", Value = 14)]
		GroupChatChannel
	}
}
