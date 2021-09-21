using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007A7 RID: 1959
	[ProtoContract(Name = "ReviveType")]
	public enum ReviveType
	{
		// Token: 0x040024F2 RID: 9458
		[ProtoEnum(Name = "ReviveNone", Value = 0)]
		ReviveNone,
		// Token: 0x040024F3 RID: 9459
		[ProtoEnum(Name = "ReviveFree", Value = 1)]
		ReviveFree,
		// Token: 0x040024F4 RID: 9460
		[ProtoEnum(Name = "ReviveItem", Value = 2)]
		ReviveItem,
		// Token: 0x040024F5 RID: 9461
		[ProtoEnum(Name = "ReviveMoney", Value = 3)]
		ReviveMoney,
		// Token: 0x040024F6 RID: 9462
		[ProtoEnum(Name = "ReviveSprite", Value = 4)]
		ReviveSprite,
		// Token: 0x040024F7 RID: 9463
		[ProtoEnum(Name = "ReviveVIP", Value = 5)]
		ReviveVIP,
		// Token: 0x040024F8 RID: 9464
		[ProtoEnum(Name = "ReviveMax", Value = 6)]
		ReviveMax
	}
}
