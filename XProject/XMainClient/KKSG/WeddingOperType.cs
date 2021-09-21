using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200081D RID: 2077
	[ProtoContract(Name = "WeddingOperType")]
	public enum WeddingOperType
	{
		// Token: 0x04002794 RID: 10132
		[ProtoEnum(Name = "WeddingOper_Flower", Value = 1)]
		WeddingOper_Flower = 1,
		// Token: 0x04002795 RID: 10133
		[ProtoEnum(Name = "WeddingOper_Fireworks", Value = 2)]
		WeddingOper_Fireworks,
		// Token: 0x04002796 RID: 10134
		[ProtoEnum(Name = "WeddingOper_ApplyVows", Value = 3)]
		WeddingOper_ApplyVows,
		// Token: 0x04002797 RID: 10135
		[ProtoEnum(Name = "WeddingOper_AgreeVows", Value = 4)]
		WeddingOper_AgreeVows,
		// Token: 0x04002798 RID: 10136
		[ProtoEnum(Name = "WeddingOper_DisAgreeVows", Value = 5)]
		WeddingOper_DisAgreeVows,
		// Token: 0x04002799 RID: 10137
		[ProtoEnum(Name = "WeddingOper_VowsPrepare", Value = 6)]
		WeddingOper_VowsPrepare,
		// Token: 0x0400279A RID: 10138
		[ProtoEnum(Name = "WeddingOper_VowsStart", Value = 7)]
		WeddingOper_VowsStart,
		// Token: 0x0400279B RID: 10139
		[ProtoEnum(Name = "WeddingOper_FlowerRewardOverMax", Value = 8)]
		WeddingOper_FlowerRewardOverMax,
		// Token: 0x0400279C RID: 10140
		[ProtoEnum(Name = "WeddingOper_FireworksRewardOverMax", Value = 9)]
		WeddingOper_FireworksRewardOverMax,
		// Token: 0x0400279D RID: 10141
		[ProtoEnum(Name = "WeddingOper_CandyRewardOverMax", Value = 10)]
		WeddingOper_CandyRewardOverMax,
		// Token: 0x0400279E RID: 10142
		[ProtoEnum(Name = "WeddingOper_Candy", Value = 11)]
		WeddingOper_Candy,
		// Token: 0x0400279F RID: 10143
		[ProtoEnum(Name = "WeddingOper_RoleNum", Value = 12)]
		WeddingOper_RoleNum
	}
}
