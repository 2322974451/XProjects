using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BackFlowActOp")]
	public enum BackFlowActOp
	{

		[ProtoEnum(Name = "BackFlowAct_TreasureData", Value = 1)]
		BackFlowAct_TreasureData = 1,

		[ProtoEnum(Name = "BackFlowAct_GetTreasure", Value = 2)]
		BackFlowAct_GetTreasure,

		[ProtoEnum(Name = "BackFlowAct_ShopData", Value = 3)]
		BackFlowAct_ShopData,

		[ProtoEnum(Name = "BackFlowAct_ShopBuy", Value = 4)]
		BackFlowAct_ShopBuy,

		[ProtoEnum(Name = "BackFlowAct_ShopUpdate", Value = 5)]
		BackFlowAct_ShopUpdate
	}
}
