using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeddingOperType")]
	public enum WeddingOperType
	{

		[ProtoEnum(Name = "WeddingOper_Flower", Value = 1)]
		WeddingOper_Flower = 1,

		[ProtoEnum(Name = "WeddingOper_Fireworks", Value = 2)]
		WeddingOper_Fireworks,

		[ProtoEnum(Name = "WeddingOper_ApplyVows", Value = 3)]
		WeddingOper_ApplyVows,

		[ProtoEnum(Name = "WeddingOper_AgreeVows", Value = 4)]
		WeddingOper_AgreeVows,

		[ProtoEnum(Name = "WeddingOper_DisAgreeVows", Value = 5)]
		WeddingOper_DisAgreeVows,

		[ProtoEnum(Name = "WeddingOper_VowsPrepare", Value = 6)]
		WeddingOper_VowsPrepare,

		[ProtoEnum(Name = "WeddingOper_VowsStart", Value = 7)]
		WeddingOper_VowsStart,

		[ProtoEnum(Name = "WeddingOper_FlowerRewardOverMax", Value = 8)]
		WeddingOper_FlowerRewardOverMax,

		[ProtoEnum(Name = "WeddingOper_FireworksRewardOverMax", Value = 9)]
		WeddingOper_FireworksRewardOverMax,

		[ProtoEnum(Name = "WeddingOper_CandyRewardOverMax", Value = 10)]
		WeddingOper_CandyRewardOverMax,

		[ProtoEnum(Name = "WeddingOper_Candy", Value = 11)]
		WeddingOper_Candy,

		[ProtoEnum(Name = "WeddingOper_RoleNum", Value = 12)]
		WeddingOper_RoleNum
	}
}
