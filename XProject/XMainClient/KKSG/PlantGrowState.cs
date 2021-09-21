using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007B7 RID: 1975
	[ProtoContract(Name = "PlantGrowState")]
	public enum PlantGrowState
	{
		// Token: 0x0400254E RID: 9550
		[ProtoEnum(Name = "growDrought", Value = 1)]
		growDrought = 1,
		// Token: 0x0400254F RID: 9551
		[ProtoEnum(Name = "growPest", Value = 2)]
		growPest,
		// Token: 0x04002550 RID: 9552
		[ProtoEnum(Name = "growSluggish", Value = 3)]
		growSluggish,
		// Token: 0x04002551 RID: 9553
		[ProtoEnum(Name = "growCD", Value = 4)]
		growCD,
		// Token: 0x04002552 RID: 9554
		[ProtoEnum(Name = "growMature", Value = 5)]
		growMature,
		// Token: 0x04002553 RID: 9555
		[ProtoEnum(Name = "growCorrect", Value = 6)]
		growCorrect
	}
}
