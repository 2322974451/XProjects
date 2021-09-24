using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildCampItemOperate")]
	public enum GuildCampItemOperate
	{

		[ProtoEnum(Name = "SWINGUPITEM", Value = 1)]
		SWINGUPITEM = 1,

		[ProtoEnum(Name = "SWINGDOWNITEM", Value = 2)]
		SWINGDOWNITEM,

		[ProtoEnum(Name = "CANCEL", Value = 3)]
		CANCEL,

		[ProtoEnum(Name = "CONFIRM", Value = 4)]
		CONFIRM,

		[ProtoEnum(Name = "AUDIOCHAT", Value = 5)]
		AUDIOCHAT,

		[ProtoEnum(Name = "TEXTCHAT", Value = 6)]
		TEXTCHAT
	}
}
