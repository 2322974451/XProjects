using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SpriteType")]
	public enum SpriteType
	{

		[ProtoEnum(Name = "Sprite_Feed", Value = 1)]
		Sprite_Feed = 1,

		[ProtoEnum(Name = "Sprite_Evolution", Value = 2)]
		Sprite_Evolution,

		[ProtoEnum(Name = "Sprite_Awake", Value = 3)]
		Sprite_Awake,

		[ProtoEnum(Name = "Sprite_Awake_Retain", Value = 4)]
		Sprite_Awake_Retain,

		[ProtoEnum(Name = "Sprite_Awake_Replace", Value = 5)]
		Sprite_Awake_Replace,

		[ProtoEnum(Name = "Sprite_InFight", Value = 6)]
		Sprite_InFight,

		[ProtoEnum(Name = "Sprite_OutFight", Value = 7)]
		Sprite_OutFight,

		[ProtoEnum(Name = "Sprite_Decompose", Value = 8)]
		Sprite_Decompose,

		[ProtoEnum(Name = "Sprite_SwapLeader", Value = 9)]
		Sprite_SwapLeader,

		[ProtoEnum(Name = "Sprite_QueryEvolutionPPT", Value = 10)]
		Sprite_QueryEvolutionPPT,

		[ProtoEnum(Name = "Sprite_Train", Value = 11)]
		Sprite_Train,

		[ProtoEnum(Name = "Sprite_ResetTrain", Value = 12)]
		Sprite_ResetTrain,

		[ProtoEnum(Name = "Sprite_Rebirth", Value = 13)]
		Sprite_Rebirth
	}
}
