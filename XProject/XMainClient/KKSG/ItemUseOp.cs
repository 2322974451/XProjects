using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007BC RID: 1980
	[ProtoContract(Name = "ItemUseOp")]
	public enum ItemUseOp
	{
		// Token: 0x0400256B RID: 9579
		[ProtoEnum(Name = "BagFind", Value = 0)]
		BagFind,
		// Token: 0x0400256C RID: 9580
		[ProtoEnum(Name = "BodyFind", Value = 1)]
		BodyFind,
		// Token: 0x0400256D RID: 9581
		[ProtoEnum(Name = "FashionWear", Value = 2)]
		FashionWear,
		// Token: 0x0400256E RID: 9582
		[ProtoEnum(Name = "FashionOff", Value = 3)]
		FashionOff,
		// Token: 0x0400256F RID: 9583
		[ProtoEnum(Name = "Composite", Value = 4)]
		Composite,
		// Token: 0x04002570 RID: 9584
		[ProtoEnum(Name = "FashionSuitWear", Value = 5)]
		FashionSuitWear,
		// Token: 0x04002571 RID: 9585
		[ProtoEnum(Name = "FashionSuitOff", Value = 6)]
		FashionSuitOff,
		// Token: 0x04002572 RID: 9586
		[ProtoEnum(Name = "ItemBuffAdd", Value = 7)]
		ItemBuffAdd,
		// Token: 0x04002573 RID: 9587
		[ProtoEnum(Name = "FashionDisplayWear", Value = 8)]
		FashionDisplayWear,
		// Token: 0x04002574 RID: 9588
		[ProtoEnum(Name = "FashionDisplayOff", Value = 9)]
		FashionDisplayOff,
		// Token: 0x04002575 RID: 9589
		[ProtoEnum(Name = "FashionSuitDisplayWear", Value = 10)]
		FashionSuitDisplayWear,
		// Token: 0x04002576 RID: 9590
		[ProtoEnum(Name = "FashionSuitDisplayOff", Value = 11)]
		FashionSuitDisplayOff,
		// Token: 0x04002577 RID: 9591
		[ProtoEnum(Name = "ActivationFashion", Value = 12)]
		ActivationFashion,
		// Token: 0x04002578 RID: 9592
		[ProtoEnum(Name = "ActivationHairColor", Value = 13)]
		ActivationHairColor,
		// Token: 0x04002579 RID: 9593
		[ProtoEnum(Name = "UseHairColor", Value = 14)]
		UseHairColor
	}
}
