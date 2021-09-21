using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007A3 RID: 1955
	[ProtoContract(Name = "SpriteType")]
	public enum SpriteType
	{
		// Token: 0x040024D3 RID: 9427
		[ProtoEnum(Name = "Sprite_Feed", Value = 1)]
		Sprite_Feed = 1,
		// Token: 0x040024D4 RID: 9428
		[ProtoEnum(Name = "Sprite_Evolution", Value = 2)]
		Sprite_Evolution,
		// Token: 0x040024D5 RID: 9429
		[ProtoEnum(Name = "Sprite_Awake", Value = 3)]
		Sprite_Awake,
		// Token: 0x040024D6 RID: 9430
		[ProtoEnum(Name = "Sprite_Awake_Retain", Value = 4)]
		Sprite_Awake_Retain,
		// Token: 0x040024D7 RID: 9431
		[ProtoEnum(Name = "Sprite_Awake_Replace", Value = 5)]
		Sprite_Awake_Replace,
		// Token: 0x040024D8 RID: 9432
		[ProtoEnum(Name = "Sprite_InFight", Value = 6)]
		Sprite_InFight,
		// Token: 0x040024D9 RID: 9433
		[ProtoEnum(Name = "Sprite_OutFight", Value = 7)]
		Sprite_OutFight,
		// Token: 0x040024DA RID: 9434
		[ProtoEnum(Name = "Sprite_Decompose", Value = 8)]
		Sprite_Decompose,
		// Token: 0x040024DB RID: 9435
		[ProtoEnum(Name = "Sprite_SwapLeader", Value = 9)]
		Sprite_SwapLeader,
		// Token: 0x040024DC RID: 9436
		[ProtoEnum(Name = "Sprite_QueryEvolutionPPT", Value = 10)]
		Sprite_QueryEvolutionPPT,
		// Token: 0x040024DD RID: 9437
		[ProtoEnum(Name = "Sprite_Train", Value = 11)]
		Sprite_Train,
		// Token: 0x040024DE RID: 9438
		[ProtoEnum(Name = "Sprite_ResetTrain", Value = 12)]
		Sprite_ResetTrain,
		// Token: 0x040024DF RID: 9439
		[ProtoEnum(Name = "Sprite_Rebirth", Value = 13)]
		Sprite_Rebirth
	}
}
