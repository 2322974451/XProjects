using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000785 RID: 1925
	[ProtoContract(Name = "LiveType")]
	public enum LiveType
	{
		// Token: 0x04002411 RID: 9233
		[ProtoEnum(Name = "LIVE_RECOMMEND", Value = 1)]
		LIVE_RECOMMEND = 1,
		// Token: 0x04002412 RID: 9234
		[ProtoEnum(Name = "LIVE_PVP", Value = 2)]
		LIVE_PVP,
		// Token: 0x04002413 RID: 9235
		[ProtoEnum(Name = "LIVE_NEST", Value = 3)]
		LIVE_NEST,
		// Token: 0x04002414 RID: 9236
		[ProtoEnum(Name = "LIVE_PROTECTCAPTAIN", Value = 4)]
		LIVE_PROTECTCAPTAIN,
		// Token: 0x04002415 RID: 9237
		[ProtoEnum(Name = "LIVE_GUILDBATTLE", Value = 5)]
		LIVE_GUILDBATTLE,
		// Token: 0x04002416 RID: 9238
		[ProtoEnum(Name = "LIVE_DRAGON", Value = 6)]
		LIVE_DRAGON,
		// Token: 0x04002417 RID: 9239
		[ProtoEnum(Name = "LIVE_FRIEND", Value = 7)]
		LIVE_FRIEND,
		// Token: 0x04002418 RID: 9240
		[ProtoEnum(Name = "LIVE_GUILD", Value = 8)]
		LIVE_GUILD,
		// Token: 0x04002419 RID: 9241
		[ProtoEnum(Name = "LIVE_FRIENDANDGUILD", Value = 9)]
		LIVE_FRIENDANDGUILD,
		// Token: 0x0400241A RID: 9242
		[ProtoEnum(Name = "LIVE_HEROBATTLE", Value = 10)]
		LIVE_HEROBATTLE,
		// Token: 0x0400241B RID: 9243
		[ProtoEnum(Name = "LIVE_LEAGUEBATTLE", Value = 11)]
		LIVE_LEAGUEBATTLE,
		// Token: 0x0400241C RID: 9244
		[ProtoEnum(Name = "LIVE_PVP2", Value = 12)]
		LIVE_PVP2,
		// Token: 0x0400241D RID: 9245
		[ProtoEnum(Name = "LIVE_CUSTOMPK", Value = 13)]
		LIVE_CUSTOMPK,
		// Token: 0x0400241E RID: 9246
		[ProtoEnum(Name = "LIVE_CROSSGVG", Value = 14)]
		LIVE_CROSSGVG,
		// Token: 0x0400241F RID: 9247
		[ProtoEnum(Name = "LIVE_MAX", Value = 15)]
		LIVE_MAX
	}
}
