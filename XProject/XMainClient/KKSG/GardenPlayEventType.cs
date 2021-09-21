using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007B8 RID: 1976
	[ProtoContract(Name = "GardenPlayEventType")]
	public enum GardenPlayEventType
	{
		// Token: 0x04002555 RID: 9557
		[ProtoEnum(Name = "PLANT", Value = 1)]
		PLANT = 1,
		// Token: 0x04002556 RID: 9558
		[ProtoEnum(Name = "PLANT_STAGE", Value = 2)]
		PLANT_STAGE,
		// Token: 0x04002557 RID: 9559
		[ProtoEnum(Name = "PLANT_STATE_CHANGE", Value = 3)]
		PLANT_STATE_CHANGE,
		// Token: 0x04002558 RID: 9560
		[ProtoEnum(Name = "BANQUET", Value = 4)]
		BANQUET,
		// Token: 0x04002559 RID: 9561
		[ProtoEnum(Name = "BANQUET_STAGE", Value = 5)]
		BANQUET_STAGE,
		// Token: 0x0400255A RID: 9562
		[ProtoEnum(Name = "PLANT_DELETE", Value = 6)]
		PLANT_DELETE,
		// Token: 0x0400255B RID: 9563
		[ProtoEnum(Name = "PLANT_SPRITE", Value = 7)]
		PLANT_SPRITE,
		// Token: 0x0400255C RID: 9564
		[ProtoEnum(Name = "PLANT_MATURE", Value = 8)]
		PLANT_MATURE,
		// Token: 0x0400255D RID: 9565
		[ProtoEnum(Name = "FISH_FACE", Value = 9)]
		FISH_FACE,
		// Token: 0x0400255E RID: 9566
		[ProtoEnum(Name = "FISH_RESULT", Value = 10)]
		FISH_RESULT,
		// Token: 0x0400255F RID: 9567
		[ProtoEnum(Name = "FISH_STOP", Value = 11)]
		FISH_STOP
	}
}
