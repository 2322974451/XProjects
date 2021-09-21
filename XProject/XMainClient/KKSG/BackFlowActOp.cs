using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000830 RID: 2096
	[ProtoContract(Name = "BackFlowActOp")]
	public enum BackFlowActOp
	{
		// Token: 0x04002807 RID: 10247
		[ProtoEnum(Name = "BackFlowAct_TreasureData", Value = 1)]
		BackFlowAct_TreasureData = 1,
		// Token: 0x04002808 RID: 10248
		[ProtoEnum(Name = "BackFlowAct_GetTreasure", Value = 2)]
		BackFlowAct_GetTreasure,
		// Token: 0x04002809 RID: 10249
		[ProtoEnum(Name = "BackFlowAct_ShopData", Value = 3)]
		BackFlowAct_ShopData,
		// Token: 0x0400280A RID: 10250
		[ProtoEnum(Name = "BackFlowAct_ShopBuy", Value = 4)]
		BackFlowAct_ShopBuy,
		// Token: 0x0400280B RID: 10251
		[ProtoEnum(Name = "BackFlowAct_ShopUpdate", Value = 5)]
		BackFlowAct_ShopUpdate
	}
}
