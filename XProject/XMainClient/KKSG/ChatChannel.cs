using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChatChannel")]
	public enum ChatChannel
	{

		[ProtoEnum(Name = "WorldChannel", Value = 1)]
		WorldChannel = 1,

		[ProtoEnum(Name = "GuildChannel", Value = 2)]
		GuildChannel,

		[ProtoEnum(Name = "PrivateChannel", Value = 3)]
		PrivateChannel,

		[ProtoEnum(Name = "SystemChannel", Value = 4)]
		SystemChannel,

		[ProtoEnum(Name = "LampShortChannel", Value = 5)]
		LampShortChannel,

		[ProtoEnum(Name = "LampLongChannel", Value = 6)]
		LampLongChannel,

		[ProtoEnum(Name = "TeamChannel", Value = 7)]
		TeamChannel,

		[ProtoEnum(Name = "CampChannel", Value = 8)]
		CampChannel,

		[ProtoEnum(Name = "SpectateChannel", Value = 9)]
		SpectateChannel,

		[ProtoEnum(Name = "CurrentChannel", Value = 10)]
		CurrentChannel,

		[ProtoEnum(Name = "PartnerChannel", Value = 11)]
		PartnerChannel,

		[ProtoEnum(Name = "AudioChannel", Value = 12)]
		AudioChannel,

		[ProtoEnum(Name = "BattleChannel", Value = 13)]
		BattleChannel,

		[ProtoEnum(Name = "GroupChatChannel", Value = 14)]
		GroupChatChannel
	}
}
