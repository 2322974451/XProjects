using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000759 RID: 1881
	[ProtoContract(Name = "UnitAppearanceField")]
	public enum UnitAppearanceField
	{
		// Token: 0x040022E5 RID: 8933
		[ProtoEnum(Name = "UNIT_BASIC", Value = 15)]
		UNIT_BASIC = 15,
		// Token: 0x040022E6 RID: 8934
		[ProtoEnum(Name = "UNIT_ATTR", Value = 32)]
		UNIT_ATTR = 32,
		// Token: 0x040022E7 RID: 8935
		[ProtoEnum(Name = "UNIT_FASHION", Value = 64)]
		UNIT_FASHION = 64,
		// Token: 0x040022E8 RID: 8936
		[ProtoEnum(Name = "UNIT_EQUIP", Value = 128)]
		UNIT_EQUIP = 128,
		// Token: 0x040022E9 RID: 8937
		[ProtoEnum(Name = "UNIT_SKILL", Value = 256)]
		UNIT_SKILL = 256,
		// Token: 0x040022EA RID: 8938
		[ProtoEnum(Name = "UNIT_EMBLEM", Value = 512)]
		UNIT_EMBLEM = 512,
		// Token: 0x040022EB RID: 8939
		[ProtoEnum(Name = "UNIT_VIPLEVEL", Value = 1024)]
		UNIT_VIPLEVEL = 1024,
		// Token: 0x040022EC RID: 8940
		[ProtoEnum(Name = "UNIT_TIMELOGIN", Value = 2048)]
		UNIT_TIMELOGIN = 2048,
		// Token: 0x040022ED RID: 8941
		[ProtoEnum(Name = "UNIT_GUILD", Value = 16384)]
		UNIT_GUILD = 16384,
		// Token: 0x040022EE RID: 8942
		[ProtoEnum(Name = "UNIT_TITLE", Value = 524288)]
		UNIT_TITLE = 524288,
		// Token: 0x040022EF RID: 8943
		[ProtoEnum(Name = "UNIT_SPRITELEADER", Value = 8388608)]
		UNIT_SPRITELEADER = 8388608,
		// Token: 0x040022F0 RID: 8944
		[ProtoEnum(Name = "UNIT_SPRITE", Value = 16777216)]
		UNIT_SPRITE = 16777216,
		// Token: 0x040022F1 RID: 8945
		[ProtoEnum(Name = "UNIT_PETS", Value = 33554432)]
		UNIT_PETS = 33554432,
		// Token: 0x040022F2 RID: 8946
		[ProtoEnum(Name = "UNIT_ARTIFACT", Value = 32768)]
		UNIT_ARTIFACT = 32768,
		// Token: 0x040022F3 RID: 8947
		[ProtoEnum(Name = "UNIT_PRE", Value = 65536)]
		UNIT_PRE = 65536
	}
}
