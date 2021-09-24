using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LotteryType")]
	public enum LotteryType
	{

		[ProtoEnum(Name = "Sprite_Draw_One", Value = 1)]
		Sprite_Draw_One = 1,

		[ProtoEnum(Name = "Sprite_Draw_Ten", Value = 2)]
		Sprite_Draw_Ten,

		[ProtoEnum(Name = "Sprite_Draw_One_Free", Value = 3)]
		Sprite_Draw_One_Free,

		[ProtoEnum(Name = "Sprite_GoldDraw_One", Value = 4)]
		Sprite_GoldDraw_One,

		[ProtoEnum(Name = "Sprite_GoldDraw_Ten", Value = 5)]
		Sprite_GoldDraw_Ten,

		[ProtoEnum(Name = "Sprite_GoldDraw_One_Free", Value = 6)]
		Sprite_GoldDraw_One_Free
	}
}
