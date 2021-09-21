using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000751 RID: 1873
	[ProtoContract(Name = "LotteryType")]
	public enum LotteryType
	{
		// Token: 0x04002274 RID: 8820
		[ProtoEnum(Name = "Sprite_Draw_One", Value = 1)]
		Sprite_Draw_One = 1,
		// Token: 0x04002275 RID: 8821
		[ProtoEnum(Name = "Sprite_Draw_Ten", Value = 2)]
		Sprite_Draw_Ten,
		// Token: 0x04002276 RID: 8822
		[ProtoEnum(Name = "Sprite_Draw_One_Free", Value = 3)]
		Sprite_Draw_One_Free,
		// Token: 0x04002277 RID: 8823
		[ProtoEnum(Name = "Sprite_GoldDraw_One", Value = 4)]
		Sprite_GoldDraw_One,
		// Token: 0x04002278 RID: 8824
		[ProtoEnum(Name = "Sprite_GoldDraw_Ten", Value = 5)]
		Sprite_GoldDraw_Ten,
		// Token: 0x04002279 RID: 8825
		[ProtoEnum(Name = "Sprite_GoldDraw_One_Free", Value = 6)]
		Sprite_GoldDraw_One_Free
	}
}
